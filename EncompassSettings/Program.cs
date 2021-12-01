using System.Collections.Generic;


namespace EncompassSettings
{
    public static class Global
    {
        public static Dictionary<int, string> PersonaMap = new Dictionary<int, string>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            new EllieMae.Encompass.Runtime.RuntimeServices().Initialize();
            BLAH.RUN();
        }
    }

    class BLAH
    {
        public static void RUN()
        {
            Converters.ConverterRegistry.Register();
            EncompassSessionManager manager = new EncompassSessionManager("ServerURL", "UserName", "Password");
        }
    }
}