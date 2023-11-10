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
            while (true)
            {
                Console.WriteLine("Bank Account Application");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. Print All Accounts");
                Console.WriteLine("7. Close Account");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine()!);

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
                        accountManager.PrintAllAccounts();
                        break;
                    case 7:
                        accountManager.CloseAccount();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}