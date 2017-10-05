using System;

namespace DataHandler
{
    public class InputChecker
    {
        public static bool InputNotNull(string InputText)
        {
            if (InputText == null || InputText == String.Empty) return false;
            return true;
        }




    }
}
