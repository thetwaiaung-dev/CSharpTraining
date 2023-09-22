using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTraining.Helper
{
    public static class DevCode
    {
        public static void ToLog(this object obj)
        {
            string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(jsonStr);
        }
    }
}
