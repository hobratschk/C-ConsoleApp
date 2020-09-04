using System;

namespace DieRoller
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Roll Dice");
            Console.WriteLine("2. Get nakey");
            Console.WriteLine("3. Factorial");
            Console.WriteLine("4. Obfuscate");
            Console.WriteLine("0. Exit");
            string answerString = Console.ReadLine();
            try
            {
                int answerInt = Int32.Parse(answerString);
                if (answerInt > -1 && answerInt < 6)
                {
                   switch (answerInt)
                    {
                        case 1:
                            RollDice();
                            break;
                        case 2:
                            GetNakey();
                            break;
                        case 3:
                            Factorial();
                            break;
                        case 4:
                            Obfuscate();
                            break;
                        default:
                            break;
                    }
                } else
                {
                    Console.WriteLine("You have to enter a number that corresponds to choices 0-5.");
                    Main();
                }
            } catch
            {
                Console.WriteLine("You have to enter a number that corresponds to choices 0-5.");
                Main();
            };
        }

        public static void GetNakey() {
            Console.WriteLine("Let's get dirty. Type something and I'll make it dirty.");
            string stringToGetNakey = Console.ReadLine();
            Console.WriteLine(stringToGetNakey.Trim(new Char[] { ' ', '.', '!', '?' }) + " naked.");
            Main();
        }

        public static void Factorial()
        {
            Console.WriteLine("Enter a positive integer for which you'd like a factorial.");
            string stringInput = Console.ReadLine();
            try
            {
                 int intInput = Int32.Parse(stringInput);
                if ( intInput > 0 )
                {
                    int i, factorialValue;
                    factorialValue = intInput;
                    for (i = factorialValue - 1; i >= 1; i--)
                    {
                        factorialValue = factorialValue * i;
                    }
                    Console.WriteLine("\nFactorial of Given Number is: " + factorialValue);
                    Main();
                }
            } catch
            {
                Console.WriteLine("You have to enter a number for a factorial.");
                Factorial();
            }
        }
        public static void Obfuscate()
        {
            Console.WriteLine("Enter something you want to obfuscate, but don't include any numbers or punctuation.");
            string stringToObfuscate = Console.ReadLine();
            char[] charArr = stringToObfuscate.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == 'z')
                {
                    charArr[i] = 'a'; 
                } else
                {
                    charArr[i] = (char)(charArr[i] + 1);
                }
            }
            string obfuscated = string.Join("", charArr);
            Console.WriteLine(obfuscated);
            Console.WriteLine("Would you like to de-obfuscate the above string? Answer 'y' for yes, or press any key to return to the main menu.");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                Console.WriteLine(stringToObfuscate);
                Main();
                //hack!

            } else { Main(); }
            
        }
        public static void RollDice()
        {
                Console.WriteLine("Welcome to dice roller. Where you roll dice. How many dice would you like to roll?");
                string numDieString = Console.ReadLine();
                try
                {
                    int numDieInt = Int32.Parse(numDieString);
                    if (numDieInt > 0)
                    {
                        string isSingular;
                        isSingular = (numDieInt == 1) ? "Great. You've got " + numDieInt + " die. How many sides would you like it to have?" : "Great. You've got " + numDieInt + " dice. How many sides would you like them to have?";
                        Console.WriteLine(isSingular);
                        string numSides = Console.ReadLine();
                        try
                        {
                            int numSidesInt = Int32.Parse(numSides);
                            if (numSidesInt >= 3)
                            {
                                //C#s random class
                                Random randomInt = new Random();
                                int totalRollValue = 0;
                                for (int i = 1; i <= numDieInt; i++)
                                {
                                    int rollValue = randomInt.Next(1, numSidesInt);
                                    totalRollValue = totalRollValue + rollValue;
                                    Console.WriteLine("Roll number " + i + " is " + rollValue);
                                    if (i == numDieInt)
                                    {
                                        Console.WriteLine("The total of your " + numDieInt + " rolls is " + totalRollValue);
                                    };
                                }
                                Console.WriteLine("We'll take you back to the main menu.");
                            Main();
                            }
                            else if (numSidesInt == 2)
                            {
                                string isSingleCoin;
                                isSingleCoin = (numDieInt == 1) ? "1 coin" : numDieInt + " coins";
                                Console.WriteLine("Well, a two-sided die is a coin. So your flipping " + isSingleCoin + ", not rolling dice, but whatever, here ya go.");

                            int headsTotal = 0;
                            int tailsTotal = 0;
                                for (int i = 1; i <= numDieInt; i++)
                                {
                                    Random randomFlip = new Random();
                                    string[] headsOrTails = { "heads", "tails" };
                                    int flipValue = randomFlip.Next(0, headsOrTails.Length);
                                if (headsOrTails[flipValue] == "heads")
                                {
                                    headsTotal++;
                                } else
                                {
                                    tailsTotal++;
                                }
                                    Console.WriteLine("Flip number " + i + " is " + headsOrTails[flipValue]);
                                    if (i == numDieInt)
                                    {
                                       Console.WriteLine("Total number of heads:" + headsTotal + " and total number of tails:" + tailsTotal + ".");
                                    };
                                }
                            Main();
                            }
                            else
                            {
                                Console.WriteLine("You have to enter a NUMBER greater than 1. Let's start over. Or you can leave. That's fine, too.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("You have to enter a NUMBER greater than 0. Let's start over. Or you can leave. That's fine, too.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jackass. You have to enter a NUMBER greater than 0. Let's start over. Or you can leave. That's fine, too.");
                    }
                }
                catch
                {
                    Console.WriteLine("You have to enter a NUMBER. You're being booted to the main menu to start over.");
                        Main();
                }


        }
    }
}
