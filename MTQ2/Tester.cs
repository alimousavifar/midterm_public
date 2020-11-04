using System;
namespace MTQ2
{
    public class Tester
    {
          static int Main() {
              //===================================================================
              // TODO: generate data and call the Tester Functions in try/catch
              // format like lab 3
              //===================================================================

              try
              {

                  Console.WriteLine("****BinarySearch Testing Begins****");
                  //Your test cases go here
                  Console.WriteLine("****Successfully Tested BinarySearch****");
                  Console.WriteLine("****GeneratePrime Testing Begins****");
                  //Your test cases go here
                  Console.WriteLine("****Successfully Tested GeneratePrime****");
                  Console.WriteLine("****IsPrime Testing Begins****");
                  //Your test cases go here
                  Console.WriteLine("****Successfully Tested IsPrime****");
                  Console.WriteLine("****Done Testing");

              }
              catch (UnitTestException ute) {
                  Console.WriteLine(ute);
              }

              return 0;
          }





          /**
          * Unit Tests for binary_search
          * @throws TestException if a test fails
          */
         void TestBinarySearch(...) {


           // single element found
           var result = BinarySearch(...);
           //===================================================================
           // TODO: Do something with the results and expected value
           //===================================================================


         }

        /**
         * Unit tests for IsPrime
         * @throws TestException if a unit test fails
         */
        void TestIsPrime(...) {


          var results = IsPrime(...);
          //===================================================================
          // TODO: Do something with the results and expectation value
          //===================================================================


        }

        /**
         * Unit Tests for generate_primes
         * @throws TestException if a unit test fails
         */
        static void TestGeneratePrimes(...) {


          var results = GeneratePrimes(...);
          //===================================================================
          // TODO: Do something with the results and expected value
          //===================================================================


        }

    }
}
