using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS3.Models
{
    internal class console
    {
        //Made this cuz I was sick of scrolling around for ages in Output to find my Console.Writeline's / Debug.log's...
        public static string Pending = "";
        public static bool IsBusy = false;
        public static bool Sending = false;
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
            _ = logAsync(data.ToString());
        }
        public static async Task logAsync(string data)
        {
            Console.WriteLine(data);
            Pending += ("\n" + data);
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            String Send = Pending;
            Pending = "";
            if (Sending)
            {
                _ = await HTTP.Get("http://192.168.137.1:8080/" + Uri.EscapeDataString(Send));
            }
            IsBusy = false;
        }
    }
}
