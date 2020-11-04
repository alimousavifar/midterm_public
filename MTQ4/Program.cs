using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace MTQ4
{
    class Program
    {
        public static int rollerCoasterCapacity = 4;
        public static int passengersInLine = 8;


        static void Main(string[] args)
        {
            // TO-DO ROLLER-COASTER METHOD IN A THREAD

            // TO-DO PASSENGER/THREAD


            //SYNCHRONIZE THREADS


        }


        private static void Passenger()
        {

            //TO-DO Implement each condition below//

            /* Condition 1/Condition 4: wait to get on coaster
             until it is boarding and there is still room on coaster
            */



            // Condition 3: wait until ride is over


            // Condition 4: notify coaster that there is one less passenger

        }

        static void RollerCoster (){

            while (true)
            {
                //TO-DO Implement each condition //
                //condition 1 semaphore boarding

                Console.WriteLine("All Entered");
                Thread.Sleep(1500);

                //Condition 2

                Console.WriteLine("All Boarded");
                Thread.Sleep(1500);

                //condition 3


                Console.WriteLine("Ride Begins");
                Thread.Sleep(1500);


                //condition 4

                Console.WriteLine("All Exited");
                Thread.Sleep(1500);
            }
        }
    }
}
