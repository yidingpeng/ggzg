using RW.PMS.Utils.Driver;

namespace RW.PMS.WinForm
{
    public static class Var
    {
        //public static OPCDriver opcDriver = new OPCDriver("KEPware.KEPServerEx.V4");
        public static OPCDriver opcDriver = new OPCDriver("KEPware.KEPServerEx.V6");

        static Var()
        {
            opcDriver.Connect();
        }

        public static bool isGood(string key)
        {
            return opcDriver.IsGood(key);
        }
    }
}
