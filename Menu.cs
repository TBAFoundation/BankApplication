namespace BankApplication
{
    public class Menu
    {
        private IAccountManager accountManager;

        public Menu(IAccountManager manager)
        {
            accountManager = manager;
        }

        public void DisplayMenu()
        {
            bool exit = false;
            int choice;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Bank Account Application");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. Find Account");
                Console.WriteLine("7. Print All Accounts");
                Console.WriteLine("8. Close Account");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            accountManager.CreateAccount();
                            break;
                        case 2:
                            accountManager.Deposit();
                            break;
                        case 3:
                            accountManager.Withdraw();
                            break;
                        case 4:
                            accountManager.Transfer();
                            break;
                        case 5:
                            accountManager.CheckBalance();
                            break;
                        case 6:
                            accountManager.GetAccount();
                            break;
                        case 7:
                            accountManager.GetAllAccounts();
                            break;
                        case 8:
                            accountManager.CloseAccount();
                            break;
                        case 9:
                            Console.WriteLine("Exiting...");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    Console.WriteLine();
                    HoldScreen();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
        private void HoldScreen()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}