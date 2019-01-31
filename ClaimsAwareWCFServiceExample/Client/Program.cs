using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the client for the service  
            Service1Client  client = new Service1Client ();

            Console.WriteLine("-------------WCF Client Application--------------\n");

            while (!ShouldQuitApplication())
            {
                try
                {
                    Console.WriteLine(client.ComputeResponse("Hello World"));
                }
                catch (CommunicationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Exception ex = e.InnerException;
                    while (ex != null)
                    {
                        Console.WriteLine("===========================");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        ex = ex.InnerException;
                    }
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Timed out...");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An unexpected exception occurred.");
                    Console.WriteLine(e.StackTrace);
                }
            }

            client.Close();

            if (client != null)
            {
                client.Abort();
            }
        }
        static bool ShouldQuitApplication()
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Press Enter key to invoke service, any other key to quit application:");
            Console.WriteLine("----------------------------------------------------------------------");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
                return false;
            return true;
        }
    }
}
