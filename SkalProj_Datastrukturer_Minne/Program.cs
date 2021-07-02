using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. CheckRekursive"
                    + "\n6. CheckIterative"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        RekursionMethod();
                        break;
                    case '6':
                        IterationMethod();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4), 5, 6");
                        break;
                }
            }
        }

      

        /// <summary>
        /// Examines the datastructure List
        /// </summary>

        // 2.   först är listans kapacitet 4. det betyder att när listan skapas skapar den faktiskt en underliggande array med storlek 4
        //      och när liststorleken blir 4 kommer den att öka sin kapacitet med dubbelt så stor som den tidigare arrayen.
        //      det betyder att det först skapar 4 storleks array och när det behövs för att lägga till mer data  skapar den sedan 8 storleks arrat
        //      och därefter skapas 16 och så vidare.

        //3.    kapaciteten okar med dubbelt så stor som tidigare kapaciteten.

        //4.
        //
        //5.    nej, kapaciteten inte minskar när element tas bort ur listan.
        //
        //6.    om storlek är fixed sen det är bättre att använda array
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //list<string> thelist = new list<string>();
            //string input = console.readline();
            //char nav = input[0];
            //string value = input.substring(1);

            var userinputlist = new List<string>();

            Console.WriteLine($"list capacity: {userinputlist.Capacity}");
            Console.WriteLine("\nEnter the +inputstring to add in the list ,\n-inputstring to delete from the list and \npress e to Exit");

            do
            {
                string userinput = Console.ReadLine();
                char nav = userinput[0];
                string value = userinput.Substring(1);
               
                if (value.Length <= 0 && nav!='e')
                {
                    Console.WriteLine("Fel input type ...");
                }
                else
                {
                    switch (nav)
                    {
                        case '+':
                            userinputlist.Add(value);
                            Console.WriteLine($"Added {value} to list. \tList Count: {userinputlist.Count}. \tLlist Capacity: {userinputlist.Capacity}. ");
                            break;

                        case '-':
                            if (userinputlist.Contains(value))
                            {
                                userinputlist.Remove(value);
                                Console.WriteLine($"Removed {value} from list .\t List Count: {userinputlist.Count}. \tList Capacity: {userinputlist.Capacity}. ");
                            }
                            else
                                Console.WriteLine($" List does not contain in the {value}");

                            break;

                        case 'e':
                            return;

                        default:
                            Console.WriteLine("Fel input.. type string that begins with + and - sign to add and remove strings in the list");
                            break;
                    }

                }
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        /// 
       
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            
             */
            SimulateICAQueue();
            TestQueue();
        }

        private static void TestQueue()
        {
            Console.WriteLine("\nEnter the +name to enter the queue ,\n- to exit from the queue and \nPress e to Exit");

            var que = new Queue<string>();
            do
            {
                string userinput = Console.ReadLine();

                char nav = userinput[0];

                string value = userinput.Substring(1);

                if (value.Length <= 0 && nav != 'e'&& nav != '-')
                {
                    Console.WriteLine("Fel input type ...");
                }
                else
                {
                    switch (nav)
                    {
                        case '+':
                            que.Enqueue(value);
                            Console.WriteLine($"{value} ställer sig i kö and Queue count: {que.Count}");
                            break;

                        case '-':

                            if (que.Count <= 0)
                                Console.WriteLine("Queue is empty");
                            else
                            {
                                var name = que.Dequeue();
                                Console.WriteLine($"{name} blir expedieriad och lämnar kön");
                            }
                            break;

                        case 'e':
                            return;

                        default:
                            Console.WriteLine("Fel input.. type a name that begins with + to Add in queue and press - sign to remove from the queue");
                            break;
                    }

                }
            } while (true);
        }

        private static void SimulateICAQueue()
        {
            string name;
            Console.WriteLine("ICA oppnar och kassan till kön är tom.");
            var IcaQue = new Queue<string>();
            IcaQue.Enqueue("Kalle");
            Console.WriteLine("Kalle ställer sig i kön");
            IcaQue.Enqueue("Greta");
            Console.WriteLine("Greta ställer sig i kön");
            name = IcaQue.Dequeue();
            Console.WriteLine($"{name} blir expedierad och lämnar kön");
            IcaQue.Enqueue("Olle");
            Console.WriteLine("Olle ställer sig i kön");
            while (IcaQue.Count > 0)
            {
                name = IcaQue.Dequeue();
                Console.WriteLine($"{name} blir expedierad och lämnar kön");
            }

        }


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        /// 
        //det är fel  om sista peroson som stå att qö blir expedieriad first så att använda en stack i den här fället(for ICA kön) är inte smart.
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<char> revstring = new Stack<char>();
            var que = new Queue<string>();
            do
            {
                Console.WriteLine("\nEnter the word that you want to reverse . Press e to Exit");
                string userinput = Console.ReadLine();
                if (userinput == "e")
                    return;
                foreach (char c in userinput)
                {
                    revstring.Push(c);
                }

                while (revstring.Count > 0)
                {
                    char rc = revstring.Pop();
                    Console.Write(rc);
                }
                Console.WriteLine("");

            } while (true);

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            do
            {
                Console.WriteLine("\nEnther sentence to check the parantheses. \n Press e to Exit");
                string str = Console.ReadLine();
                if (str == "e")
                    return;
                bool chk = str.CheckForParanthesis();

                if (chk)
                    Console.WriteLine($"{str} är Välformed sträng");
                else
                    Console.WriteLine($"{str} är Ej välformed sträng");
            } while (true);

        }

        private static void IterationMethod()
        {
            Console.WriteLine("Enter en num");
            int num = int.Parse(Console.ReadLine());

            int res1 = num.IterationEven();
            Console.WriteLine($"Result {num}th Even nummer: {res1} ");

            int res2 = num.IterateFibonacciSequence();
            Console.WriteLine($"Result {num}th fibonnacisekvensen: {res2}");

            Console.ReadKey();
        }

        private static void RekursionMethod()
        {
            Console.WriteLine("Enter en num");
            int num = int.Parse(Console.ReadLine());

            int res1 = num.RecursiveEven();
            Console.WriteLine($"Result {num}th Even nummer: {res1} ");

            int res2 = num.FibonacciSequence();
            Console.WriteLine($"Result {num}th fibonnacisekvensen: {res2}");
            Console.ReadKey();

        }
    }
}


