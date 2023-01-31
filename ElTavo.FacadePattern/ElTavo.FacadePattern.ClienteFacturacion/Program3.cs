using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElTavo.FacadePattern.ClienteFacturacion
{
    public class Program3
    {

        public static void Run()
        {
            Console.WriteLine("Hola mundo");
        }
        static void Main(string[] args)
        {
            Task.Factory.StartNew(Run);
            Task<string> task = Task.Factory.StartNew<string>
                                    (() => DownloadString("http://www.c-sharpcorner.com/"));

            Console.WriteLine("Hola estoy testeando \n");

            Console.WriteLine(task.Result);


            Console.WriteLine("\nSigo testeando \n");
            Console.Read();
        }


        static string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        }
    }
}
