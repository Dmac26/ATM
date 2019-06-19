using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Project
{
    class Program
    {
        static void Main()
        {
            #region Project Manifest
            /*
            1. Write a program that will:
                a. Ask the user to enter an account number for their account
                    i. Continue to ask the user for this number until they get it right (the
                       correct account number will be hard coded in your code. See Login
                       section for an example). You can also lock them out after a certain
                       number of failures.
                b. Once they get the correct account number, ask them for a pin number. Just as
                   you did for their account number, continue to prompt the user for their pin until
                   they get it correct. (The correct value will be hard coded just as it was for the
                   account number)
                c. Once the user has successfully given their account and pin number, ask them if
                   they want to do a deposit, a withdraw, or exit.
                d. If they choose to do a deposit, ask them for the amount to deposit, and display
                   the amount deposited.
                    i. “$500.00 has been deposited into account number 12345” for example.
                e. If they choose to withdraw money, ask them for the amount to withdraw.
                    i. Then display “$500.00 has been withdrawn from account number
                       12345” for example.
                f. After each transaction, ask the user again if they want to do a deposit, withdraw,
                   or exit.
                g. Thank the user for their business when they choose exit.
                   Additional Optional Features:

            Additional Options:
                a. Keep a running tally of the account balance, assuming that the account starts at $0.
                    i. Every time they deposit or withdraw from the account, the balance should be
                       updated and displayed.
                b. Add a feature where the user can also make a balance request to display their current
                   balance without making a deposit or withdrawal.
               */

            //    private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
            //{
            //    if (e.KeyChar == (char)13)
            //    {
            //        // Enter key pressed
            //    }
            //}
            #endregion

            #region programVariables

            bool runPrgrm = true;
            bool mainMenu = true;
            bool acntVerified = false; int accountAttempts = 0;
            bool pinCorrect = false; int pinAttempts = 0;
            int userAcnt = 12345678;
            int userPin = 1234;
            double accountBalance = 0.00;

            #endregion

            #region Main Program Loop
            do 
            {
                #region Verify Account Loop
               
                while (acntVerified == false && runPrgrm == true)
                {
                        Console.WriteLine("Please enter your Account Number.");
                        Console.Write("Account Number: ");
                        int userInput = Convert.ToInt32(Console.ReadLine());


                        if (userInput == userAcnt)//if else statement to authenticate user's account number
                        {
                            acntVerified = true;
                        }//end if
                        else if (userInput != userAcnt && accountAttempts < 2)
                        {
                            accountAttempts++;
                            Console.WriteLine("That is not a valid Account Number. Press \"Enter\" to try again.");
                            Console.ReadLine();
                            Console.Clear();
                        }//end else if
                        else //if(userInput != userAcnt && accountAttempts >= 3)
                        {
                            Console.WriteLine("You have exceeded the allowed number of attempts. Please try again later.");
                            runPrgrm = false;
                        }//end else
                }
                #endregion//End of verify account loop

                #region Verify Pin Loop
                
                while (runPrgrm == true && pinCorrect == false)//while loop for userPin
                {
                    Console.WriteLine("\n\nPlease enter your Pin Number.");
                    Console.Write("Account Number: ");
                    int userInput2 = Convert.ToInt32(Console.ReadLine());


                    if (userInput2 == userPin)//if else statement for authenticating user's pin number
                    {
                        pinCorrect = true;
                    }//end if
                    else if (pinAttempts < 3)
                    {
                        pinAttempts++;
                        Console.WriteLine("That is not a valid Pin Number. Press \"Enter\" to try again.");
                        Console.ReadLine();
                        Console.Clear();
                    }//end else if
                    else
                    {
                        Console.WriteLine("You have exceeded the allowed number of attempts. Please try again later.");
                        runPrgrm = false;
                    }//end else

                }
                #endregion//end verify pin loop

                #region Main Menu Loop
                while (pinCorrect == true && runPrgrm == true)//while loop for Main Menu
                    {
                        Console.Clear();
                        Console.WriteLine("Please indicate what you would like to do.\nType\"D\" for DEPOSIT, \"W\" for WITHDRAWAL," +
                            "\n\"B\" for SEE BALANCE, and \"E\" for EXIT:");
                        string userOption = Console.ReadLine().ToUpper();


                        switch (userOption)//switch for Main Menu
                        {
                            case "D":
                                Console.Write("\n\nHow much would you like to deposit: $");
                                double userDeposit = double.Parse(Console.ReadLine());
                                accountBalance = accountBalance + userDeposit;
                                Console.WriteLine("\n\n{0:c} {1} been deposited into Account: {2}." +
                                    "\nThe updated balance is now: {3:c}",
                                    userDeposit,
                                    userDeposit == 1 ? "has" : "have",
                                    userAcnt,
                                    accountBalance);
                              break;

                            case "W":
                                Console.Write("How much would you like to withdrawal: $");
                                double userWithdrawal = double.Parse(Console.ReadLine());
                                accountBalance = accountBalance - userWithdrawal;
                                Console.WriteLine("\n\n{0:c} {1} been withdrawn from Account: {2}." +
                                    "\nThe updated balance is now: {3:c}",
                                    userWithdrawal,
                                    userWithdrawal == 1 ? "has" : "have",
                                    userAcnt,
                                    accountBalance);
                                break;
                            case "B":
                                Console.WriteLine($"\n\nThe current Balance for {userAcnt} is {accountBalance:c}");
                                break;
                            case "E":
                                runPrgrm = false;
                                break;
                        }//end user Option switch

                    Console.WriteLine("Would you like to do something else?Y/N: ");
                    string somethingElse = Console.ReadLine().ToUpper();
                    switch (somethingElse)//Switch to determine if the user would like to do something else or exit the porgram.
                    {
                        case "N":
                        case "NO":
                            runPrgrm = false;
                            break;
                            //default:
                            //    break;
                    }//end somethingElse switch
                }//end Main Menu loop
                #endregion  
            } while (runPrgrm == true);
        
            #endregion
            Console.WriteLine("\nThanks for letting us use your money to make frivolous loans!");
        }//end Main()
    }//end Program
}//end Namespace

