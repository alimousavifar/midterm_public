---
layout: exam
title:  Midterm
date:   2020-11-03 21:00:00
authors: [Ali Mousavifar, Antonio Sánchez]
categories: [exam, Synchronization, Multi-Threading, Testing]
usemath: true

---

# Midterm


Welcome to the CPEN 333-102 -- System Software Engineering Take-Home Midterm!  Please take the time to read all the instructions and the questions carefully.

Before beginning, you will be asked to read and sign a [Take-Home Midterm Agreement Form ({{site.url}}/MidtermAgreement.pdf)](./MidtermAgreement.pdf).  This signed form **must be included** with your submission for you to receive a grade.

Submissions will be accepted through TurnItIn.  The deadline listed on Connect is final. You will have at least 48 hours from the time the midterm is posted to complete and submit your exam solutions.  Late entries will not be graded.

Good luck!


## General Instructions

This is an open-book, open-note, open-IDE, open-internet midterm exam.  You may reference any *existing* materials or documentation you find anywhere, including course notes, C\# class or method specifications, web forums, and your own lab solutions.

You **may not**, however, discuss problems **or *any* material related to the course** with *anyone* during the period of the exam.  This includes classmates, teaching assistants, instructors, friends, enemies, parents, siblings, or long lost cousins.  You may not ask material-related questions on Piazza, Stack Overflow, Reddit, or any other digital, analog, or live forum.

Before you begin, you **must** read, initial and sign the [Take-Home Midterm Agreement Form ({{site.url}}/MidtermAgreement.pdf)](./MidtermAgreement.pdf).  This signed form **must be included** with your submission for you to receive a grade.

Much of the code is provided for you for this midterm, available on GitHub [here (https://github.com/cpen333/midterm)](https://github.com/alimousavifar/midterm).

There are four main problems to complete, each with several tasks.  Similar to the labs, most of the code is already provided for you.  Unless explicitly stated otherwise, you are free to change *any* of the code if it will help you to solve the problem at hand.  You should document any changes using comments in your code.

If any question or task is unclear, make assumptions that will help you solve the problem, mark them down as comments in your code, and continue with your solution.

While you are not explicitly being graded on coding style, anything you do to help with the clarity of your code will go a long way to helping us understand your intentions.  This includes proper indentation to indicate scope, meaningful variable and function names, and comments on non-trivial sections of code to explain your approach.

Part marks will be awarded as long as we understand your intentions.  If you're not entirely sure how to implement something, or can't quite get part of your code to work correctly, write down your approach in the form of comments.  If you identify a bug in your own code but don't know how to fix it, write down what you *think* is happening and how you might solve it given more time.

## Question 1 -- Multi-threading and Thread-safety Practices [Difficulty: Easy]

In this section, we will first convert a sequential task into threads. Then, we use a variety of techniques to protect the critical section of the code (shared memory) against the threads over-stepping on each other. The framework is in MTQ1.

### **Task 1: Sequential Tasks to Multi Thread  [10 marks]**
Currently, the main function is calling the `thread_increment` method, sequentially.
 - Change the code in the `for loop`, so that number of threads equal to `numberOfThreads` are first created and then started. Ensure that all the tasks are synchronized before the main function returns. Once you have tested that you can successfully create threads in this method, comment it.
 - Change the code in the `for loop`, so that number of Tasks Class equal to `numberOfThreads` are first created and then started. Ensure that all the tasks are synchronized before the main function returns. Once you have tested that you can successfully create threads in this method, comment it.
 - Change the code in the `for loop`, so that number of Tasks Class equal to `numberOfThreads` are created and started in one line. Ensure that all the tasks are synchronized before the main function returns. Once you have tested that you can successfully create threads in this method, comment it.


```csharp
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
```

### **Task 2: Thread Safety [10 marks]**
The `counter` is a shared resource amongst the threads/tasks. We have many methods to protect this variable. Implement the following to protect the counter:
 - Monitor Class
 - Lock Class
 - Mutex Class
 - Interlocked.Exchange()
 - SemaphoreSlim alone
 - Combination of SemaphoreSlim with initial capacity of 3 and Interlocked.Increment()



## Question 2 -- Primes  [Difficulty: Easy]

A prime number is a *positive integer* that has exactly *two divisors*: 1 and itself.  The first 10 prime numbers are: 2, 3, 5, 7, 11, 13, 17, 19, 23 and 29.

We are going to write and test a method to check whether any number in the range [1, $$2^{31}-1$$] is prime (i.e. will work for any positive 4-byte integer).

One of the fastest methods for checking whether or not a number is prime is to store a pre-generated list of prime numbers and check if a given number is contained in this list.  Unfortunately, there are 105,097,565 prime numbers less than $$2^{31}$$, which would take about 401 MB of memory.  We can get away with a much smaller list by combining this approach with trial-division.  If a number $$N$$ is *not* prime, then it must have a prime divisor less than or equal to $$\sqrt{N}$$.  For $$N = 2^{31}-1$$, this means we only need a list of primes less than 46341, of which there are 4792 (19 KB of memory).

Therefore we can check if a number $$N$$ is prime by doing the following:
- generate a list of primes less than 46341
- if $$N < 46341$$ search our list of primes
   - if $$N$$ is found within this list then it is prime, otherwise it is not
- if $$N \geq 46341$$ check the remainder of $$N/p$$ for every prime $$p\leq\sqrt{N}$$
   - if any remainder is zero, $$N$$ is not prime
   - if all remainders are non-zero, $$N$$ is prime

Some programmers have already implemented most of the required methods.  However, they forgot to document one of the major methods, and they couldn't quite get the prime-checking to work correctly.  We will use unit-testing to try to uncover and fix any bugs, and complete any missing function specifications.

The code for this question can be found in the `MTQ2` folder.
- `HelperFunctions.cs`: Include framework for BinarySearch, IsPrime, GeneratePrimes
- `TestException.h`: a simple exception class
- `Tester.cs`: Tester code is implemented
- `UnitTestExceptions.cs`: where a simple exception class is defined. Feel free to add specific exception class for each unit test in this question. Or use the generic one provided to you.

For the unit-test implementations, you may choose to use your own unit-testing framework in place of `Tester.cs` if you wish.  Make sure to document your approach using comments.

### **Task 1: Specifications [10 marks]**

The `HelperFunctions.cs` contains/will contain three function declarations/implementation, two of which are documented:

```csharp
//===================================================================
// TODO: Write specification for GeneratePrimes
//===================================================================
public static List<int> GeneratePrimes(int n){


}

/**
 * Finds a value within the supplied vector of integers
 * @param data array to search
 * @param val value to find
 * @return the index of the FIRST occurrence of the value val in data
 *         or -1 if not found
 */
public static int BinarySearch(int[] data, int val){


}

/**
 * Checks if a positive integer is prime
 * @param n integer to check, must satisfy 0 < n <= 2^31-1
 * @return true if number is prime, false otherwise
 */
 public static bool IsPrime(int n){


 }
```

In the `Tester.cs` file there is a method defined to help with testing `GeneratePrimes(...)`, `BinarySearch(...)`, and `IsPrime(...)`:

```csharp
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

```


```csharp
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
```

By carefully selecting a set of tests and seeing what is returned, try to figure out exactly what `GeneratePrimes(...)` does for a given set of inputs.

Your task:
1. Write a few tests to determine the set of valid inputs and corresponding outputs
2. Use this information to write a full function specification in `HelperFunctions.cs` for `GeneratePrimes`.

### **Task 2: Binary Search [10 marks]**

You begin to suspect that there may be a few bugs in the `BinarySearch(...)` method.  To find and fix them all, you need to write unit tests for the function.

1. Inside `Tester.cs`, write a complete set of unit tests for `BinarySearch(...)`.  Document your test strategy using comments inside the method.

   ```csharp
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
   ```
2. In `HelperFunctions.cs`, fix each of the errors in the `BinarySearch(...)` function as you encounter them.

### **Task 3: Checking Primes [10 marks]**

Unfortunately, after further testing, the `IsPrime(...)` function still doesn't seem to always work correctly.  Now that you are confident in `GeneratePrimes(...)` and `BinarySearch(...)`, you have narrowed-down any potential bugs to the `IsPrime(...)` function itself.

1. Inside `Tester.cs`, write a complete set of unit tests for `IsPrime(...)`.  Document your test strategy using comments inside the method.

   ```csharp
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
   ```
2. In `HelperFunctions.cs`, fix each of the errors in the `IsPrime(...)` function as you encounter them.




## Question 3 -- UML [Difficulty: Medium]
In this section we present you with a few classes, their properties, member variables and functions, etc. You are required to create the Class and Sequence diagram from the code. If you find any error in the code, make an assumption (document the assumption) and continue with the diagram. You are welcome to use any tools available online to create these diagrams.

```csharp
using System;

namespace MTQ3
{
    class Program
    {
        static void Main(string[] args)
        {

            User user1 = new User("Joe", "Biden", 100, 1);
            HDMI[] user1HDMIArray = { new HDMI(2.1, "INPUT1", 1), new HDMI(2.1, "INPUT2", 2), new HDMI(2.1, "INPUT3", 3) };
            Monitor[] user1Monitors = { new Monitor(user1HDMIArray.Length, user1HDMIArray, new Button()) };
            Console.WriteLine("User name {0}, User Age {1}", user1._firstName+ user1._lastName , user1.GetOwnedMonitors());
            for (int i = 0; i < user1Monitors.Length; i++)
            {
                if (user1Monitors[i].GetMonitorStatus()) user1Monitors[i].TurnOnMonitor(user1Monitors[i]._powerButton);

                for (int j = 0; j < user1HDMIArray.Length; j++)
                    Console.WriteLine("MonitorStatus: {0}, HDMI name: {1}, HDMI version: {2}", user1Monitors[i].GetMonitorStatus(), user1HDMIArray[j].GetHDMIName(), user1HDMIArray[j].GetVersion());

            }


            User user2 = new User("Donold", "Trump", 99, 2);
            HDMI[] user2HDMIArray = { new HDMI(2.1, "INPUT1", 1), new HDMI(3.1, "INPUT2", 2)};
            Monitor[] user2Monitors = { new Monitor(user2HDMIArray.Length, user2HDMIArray, new Button()),
                                        new Monitor(user2HDMIArray.Length, user2HDMIArray, new Button()) };
            Console.WriteLine("User name {0}, User Age {1}", user2._firstName + user2._lastName, user2.GetOwnedMonitors());
            for (int i = 0; i < user1Monitors.Length; i++)
            {
                if (user2Monitors[i].GetMonitorStatus()) user1Monitors[i].TurnOnMonitor(user1Monitors[i]._powerButton);
                for (int j = 0; j < user2HDMIArray.Length; j++)
                    Console.WriteLine("MonitorStatus{0}, HDMI name: {1}, HDMI version: {2}", user1Monitors[i].GetMonitorStatus(), user2HDMIArray[j].GetHDMIName(), user2HDMIArray[j].GetVersion());


            }

        }

    }

    public class Monitor
    {
        protected int _NumberOfHDMIConnections;
        public HDMI[] _Hdmi;
        public Button _powerButton;

        public Monitor(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton)
        {
            this._NumberOfHDMIConnections = NumberOfHDMIConnections;
            this._Hdmi = Hdmi;
            this._powerButton = powerButton;
        }
        public void TurnOnMonitor(Button powerButton)
        {
            powerButton.SetStatus(true);
        }
        public bool GetMonitorStatus()
        {
            if (_powerButton.GetStatus()) return true;
            else return false;
        }

    }

    class User
    {
        public string  _firstName;
        public string _lastName;
        public int _age;
        public int _ownedMonitors;

        public User(string fName, string lName, int age, int ownedMonitors) {
            this._firstName = fName;
            this._lastName = lName;
            this._age = age;
            this._ownedMonitors = ownedMonitors;
        }

        public  int GetOwnedMonitors() {
            return this._ownedMonitors;

        }

    }

    public class Monitor4k : Monitor
    {
        public Monitor4k(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton) : base(NumberOfHDMIConnections, Hdmi, powerButton) {

        }

    }

    public class MonitorOLED : Monitor
    {
        public MonitorOLED(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton) : base(NumberOfHDMIConnections, Hdmi, powerButton)
        {

        }

    }

    public class MonitorLCD : Monitor
    {
        public MonitorLCD(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton) : base(NumberOfHDMIConnections, Hdmi, powerButton)
        {

        }

    }

    public class Button
    {
        private bool _status;
        public Button() {
            this._status = false;
        }
        public bool GetStatus()
        {
            return this._status;

        }
        public void SetStatus(bool myStatus)
        {
            this._status = myStatus;

        }

    }

    public class HDMI
    {
        private double _version;
        private string _HDMIName;
        protected int _HDMIInputNumber;

        public HDMI(double version, string HDMIName, int HDMIInputNumber)
        {
            this._version = version;
            this._HDMIName = HDMIName;
            this._HDMIInputNumber = HDMIInputNumber;
        }
        public double GetVersion()
        {
            return this._version;
        }
        public void SetVersion(double _version)
        {
            this._version = _version;
        }
        public string GetHDMIName()
        {
            return this._HDMIName;
        }
    }
}
```


### Task 1: Class Diagram [10]
For the Class Diagram please make sure all of the following are included wherever it is applicable:
 - Class Name, Attribute, and Operations with appropriate syntax
 - Class Relationships:
   - Association (multiplicity, label, role name, direction)
   - Composition(aggregation and composition)
   - Generalization (Substitution and Inheritance)
Use any available online tool to draw the diagrams.



### Task 2: Sequence Diagram [10]
Draw the Sequence diagram for User1 (Initiating Actor) with the rest of the objects. Make sure all of the following are included wherever it is applicable:
 - Initiating Actor
 - Lifeline
 - Activation lines
 - Messages
 - All of the participants (Objects, Actors, Roles)
 - Iterations
 - And other Sequence Diagrams components where it is applicable
Use any available online tool to draw the diagrams.

## Question 4 -- Roller Coaster Ride  [Difficulty: Medium]
A roller coaster has a single car that can hold *up to four* passengers.  Your task is to design the synchronization mechanism that satisfies the following conditions:
1. Only 4 passengers can get on the roller coaster at a time (i.e. they wait their turn while people are boarding)
2. The roller coaster will wait to start until *either*
  - four passengers have boarded
  - at least one passenger has boarded and there are no other passengers waiting in line
3. Each passenger will wait until the ride is over before getting off
4. New passengers will wait until all previous passengers are off before boarding


The suggested mechanisms are Semaphoreslim which has less overhead than Semaphore (related information is provided on Page 17 Lecture 13). However, you may use whichever synchronization primitives you wish to solve this problem.

Starter code for this question can be found in the `MTQ4` folder.
- `Passenger`: Passenger method - each passenger should get its own thread.
- `Rollercoaster`: Roller Coaster method - will be executed in one thread.


### **Condition 1 -- Boarding [7.5 marks]**

When the roller coaster is boarding, a maximum of four passengers can enter at a time.  If there is a fifth passenger waiting, she/he must wait for the next ride.

Implement this *boarding* synchronization stage.  Document your approach using comments in your code at the appropriate sections beginning with:

```csharp
// Condition 1:
```

### **Condition 2 -- Starting [10 marks]**

The roller coaster will continue boarding until either it is full with four passengers **[5 marks]**, or until there is at least one passenger on board and no more passengers waiting **[5 marks]**.

Implement this *starting* synchronization stage.  Document your approach using comments in your code at the appropriate sections beginning with:

```csharp
// Condition 2:
```

**Note:** if you only get the roller coaster working when it is full with 4 passengers (and not the *up to* part), you can still receive the marks for that portion.

### **Condition 3 -- Riding [7.5 marks]**

A passenger must remain on the ride until the roller coaster has come to a complete stop and allows her/him to exit.

Implement this *riding* synchronization stage.  Document your approach using comments in your code at the appropriate sections beginning with:

```csharp
// Condition 3:
```

### **Condition 4 -- Exiting [5 marks]**

No one is allowed to board until all previous passengers have exited the ride.  Once the final passenger has left, the roller coaster can signal new passengers to begin boarding again.

Implement this *exiting* synchronization stage.  Document your approach using comments in your code at the appropriate sections beginning with:

```csharp
// Condition 4:
```

## Submission

All submissions should be made through
- TurnItIn - All of the code related to Q1-Q4 should be copy and pasted in one text file and submitted under `midterm` assignment in TurnItIn. If your midterm is not submitted to TurnItIn, your midterm will *NOT* be marked. Exclude the binaries. Just your `csharp` code and your documents that includes your UMLs.

- github - Submit Q1 to Q4 in one `private` repository named `cpen333Fall2020midterm` and add myself and your TA as collaborators. Shanny will be marking your exam. Please note that your last commit before the deadline will be graded.


Please also ensure that you have submitted the signed [Take-Home Midterm Agreement Form({{site.url}}/MidtermAgreement.pdf)](./MidtermAgreement.pdf)] to your git repo as a binary file.  

If you are having trouble either digitally signing the agreement form, or scanning/taking a picture of a signed physical copy, then you may do the following:
- Create a new text file with a declaration that you have read the form and have adhered to all terms
- Include your name, student #, and email address

Congratulations on finishing the take-home midterm for CPEN 333 -- System Software Engineering!
