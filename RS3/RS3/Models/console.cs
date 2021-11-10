using System;
using System.Collections.Generic;
using System.Text;

namespace RS3.Models
{
    internal class console
    {
        //Made this cuz I was sick of scrolling around for ages in Output to find my Console.Writeline's / Debug.log's...
        public static void log(object data)
        {
            _ = logAsync(data);
        }
        public static void log(string data)
        {
            _ = logAsync(data);
        }
        public static async Task logAsync(object data)
        {
            await logAsync(data.ToString());
        }
        public static async Task logAsync(string data)
        {
            Console.WriteLine(data);
            _ = await HTTP.Get("http://172.30.248.55:8080/" + data);
        }
    }
}
