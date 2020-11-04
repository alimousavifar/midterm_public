using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace MTQ1
{
    public class Program
    {

      static void Main(string[] args)
      {
        long counter = 0;
        int numberOfThreads = 5;
        for (int i = 0; i < numberOfThreads; i++)
        {
            thread_increment(ref counter);

        }
        Console.WriteLine("Counter:{0}", counter);
      }

      static void thread_increment(ref long counter) {

          for (int i = 0; i < 100000; i++)
          {
              counter++;
          }
      }
    }
}
