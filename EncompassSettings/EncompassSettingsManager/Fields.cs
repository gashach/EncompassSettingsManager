using System;
using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.DataEngine;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Fields
    {
        public static string GetAllPiggybackFields(this EncompassSessionManager manager)
        {
            var pfFields = (PiggybackFields)manager.EncompassDefaultInstance.GetSystemSettings(typeof(PiggybackFields));
            return JsonConvert.SerializeObject(pfFields.GetSyncFields());
        }

        public static void AddUpdateCustomFields(this EncompassSessionManager manager, List<CustomFieldInfo> fields)
        {
            var existingFields = manager.EncompassSessionObjects.ConfigurationManager.GetLoanCustomFields()
                .Cast<CustomFieldInfo>().ToList();
            var cfi = new CustomFieldsInfo(false);
            foreach (var newField in fields)
            {
                cfi.Add(newField);
            }
            manager.EncompassSessionObjects.ConfigurationManager.UpdateLoanCustomFields(cfi,false);
        }

        public static List<LoanXDBField> GetRdbFields(this EncompassSessionManager manager)
        {
            var fields = manager.EncompassSessionObjects.LoanManager.GetLoanXDBTableList(false).GetAllFields().ToList();
            return fields;
        }

        public static void AddUpdateRdbFields(this EncompassSessionManager manager, List<LoanXDBField> fields)
        {
            var existingFieldMgr = manager.EncompassSessionObjects.LoanManager.GetLoanXDBTableList(false);
            var existingFields = existingFieldMgr.GetAllFields();
            var existingFieldsNames = existingFields.Select(x => x.FieldID).ToList();
            var status = manager.EncompassSessionObjects.LoanManager.GetLoanXDBStatus(false);

            var addList = fields.Where(x =>
                !existingFields.Any(y => y.FieldID == x.FieldID && y.ComortgagorPair == x.ComortgagorPair)).ToList();
            foreach (var field in fields)
            {
                if (existingFields.Any(x => x.FieldID == field.FieldID && x.ComortgagorPair == field.ComortgagorPair))
                {
                    existingFieldMgr.AddUpdateList(new LoanXDBField(field),LoanXDBField.FieldStatus.Updated);
                }
                else
                {
                    var newField = new LoanXDBField(field);
                    newField.Auditable = field.Auditable;
                    newField.TableName = String.Empty;
                    existingFieldMgr.AddUpdateList(newField, LoanXDBField.FieldStatus.New);
                }
            }
            existingFieldMgr.UpdateTable();
        }
    }
}