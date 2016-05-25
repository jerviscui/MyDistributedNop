using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure;

namespace WebServices.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "i":
                        break;
                    case "u":
                        break;
                    case "t":
                        OnStart += ServiceHelper.Run;
                        OnStop += ServiceHelper.Stop;
                        OnStart?.Invoke();
                        Console.WriteLine("Started Ok!");
                        Console.WriteLine("Enter any key to stop.");
                        Console.ReadLine();
                        OnStop?.Invoke();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                RunAsWinService();
            }
        }

        public static event Action OnStart;

        public static event Action OnStop;

        private static void RunAsWinService()
        {
            Console.WriteLine("Start as windows services");

            try
            {
                ServiceBase.Run(new WinService());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Services startup error!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
