using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Application.Interfaces;
using Microsoft.Azure.WebJobs;
using SearchFilters;

namespace CarSimulator
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {

        static System.Timers.Timer timer;
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            
            
            start_timer();

            
            Console.WriteLine("Press Enter to Exit");

            Console.ReadLine();

        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var scope = SimpleInjector.Lifestyles.AsyncScopedLifestyle.BeginScope(DiManager.Container))
                {
                    Console.WriteLine($"Car Simulator job Started at { DateTime.UtcNow } Utc");
                    var service = DiManager.Container.GetInstance<IVehicleService>();
                    var vehicles = service.Read(new VehicleFilters());

                    var rand = new Random();
                    foreach (var v in vehicles)
                    {
                        var randomIsAlive = rand.NextDouble() >= 0.5;
                        if (randomIsAlive) service.AddStamp(v.Id);
                    }

                    Console.WriteLine($"Car Simulator job Ended at { DateTime.UtcNow } Utc");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceptions at Car Simulator job { DateTime.UtcNow } Utc - Exception: {ex}");
            }

        }
        private static void start_timer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000 * 45; //update vehicle status every 45 seconds
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
    }
}
