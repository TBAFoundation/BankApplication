using ConsoleTables;
using Humanizer;

namespace BankApplication
{
    internal class AccountManager : IAccountManager
    {
        private List<AccountInfo> accounts = new List<AccountInfo>();
        private UserAccount userAccount = new UserAccount();
        public void CreateAccount()
        {
            int id = accounts.Count > 0 ? accounts.Count + 1 : 1;

            string accountNumber = default!;
            var hasAccount = HasAccount(accountNumber);
            if (hasAccount)
            {
                Console.WriteLine("You already have an account with the bank.");
                return;
            }

            var userInfo = userAccount.CreateAccount();
            var accountType = (AccountType)Utility.SelectEnum("Select Account type:\n1. Current Account\n2. Savings Account\n",1, 2);

            AccountInfo account = new (id, userInfo.LastName, userInfo.FirstName, userInfo.MiddleName, userInfo.PhoneNumber, userInfo.Email, userInfo.GetIDNumber(), userInfo.GetAddress(), userInfo.GetOccupation(), accountType);
            accounts.Add(account);

            Console.WriteLine("Account created successfully!");
        }

        public void Deposit()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;
            Console.Write("Enter amount to deposit: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            AccountInfo account = FindAccount(accountNumber);
            if (account != null)
            {
                // Perform deposit operation on the account
                Console.WriteLine($"Deposited {amount:C} to account {accountNumber}");
            }
            else
            {
                Console.WriteLine("Account not found!");
            }
        }

        public void Withdraw()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;
            Console.Write("Enter amount to withdraw: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            AccountInfo account = FindAccount(accountNumber);
            if (account != null)
            {
                // Perform withdraw operation on the account
                Console.WriteLine($"Withdrawn {amount:C} from account {accountNumber}");
            }
            else
            {
                Console.WriteLine("Account not found!");
            }
        }
        
        public void Transfer()
        {
            Console.Write("Enter sender account number: ");
            string senderAccountNumber = Console.ReadLine()!;
            Console.Write("Enter recipient account number: ");
            string recipientAccountNumber = Console.ReadLine()!;
            Console.Write("Enter amount to transfer: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            AccountInfo senderAccount = FindAccount(senderAccountNumber);
            AccountInfo recipientAccount = FindAccount(recipientAccountNumber);
            if (senderAccount != null && recipientAccount != null)
            {
                // Perform transfer operation from sender to recipient
                Console.WriteLine($"Transferred {amount:C} from account {senderAccountNumber} to account {recipientAccountNumber}");
            }
            else
            {
                Console.WriteLine("One or both of the accounts not found!");
            }
        }

        public void CheckBalance()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;
            AccountInfo account = FindAccount(accountNumber);
            if (account != null)
            {
                // Perform check balance operation on the account
                Console.WriteLine($"Account Number: {accountNumber}");
                Console.WriteLine($"Balance: {GetAccountBalance(accountNumber):C}");
            }
            else
            {
                Console.WriteLine("Account not found!");
            }
        }

        public void GetAccount()
        {
            Console.Write("Enter Acount Name: ");
            string LastName = Console.ReadLine()!;

            Console.WriteLine("Finding Acount Details... ");
            AccountInfo account = FindAccount(LastName);
            
            if (account is null)
            {
                Console.WriteLine($"Accout with {LastName} not found");
            }
            else
            {
                Print();
                Console.WriteLine("========================================================================");
            }
        }

        public void GetAllAccounts()
        {
            Console.WriteLine("Printing Accounts...");
            int accountCount = accounts.Count;
            Console.WriteLine("You have " + "contact".ToQuantity(accountCount));
            Console.WriteLine("==================Accounts Information=======================================");
            if (accountCount == 0)
            {
                Console.WriteLine("There is no account added yet.");
                return;
            }
            else
            {
                PrintAllAccounts();
                Console.WriteLine("========================================================================");
            }
        }

        public void CloseAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;

            AccountInfo account = FindAccount(accountNumber);
            if (account != null)
            {
                accounts.Remove(account);
                Console.WriteLine($"Account {accountNumber} closed successfully!");
            }
            else
            {
                Console.WriteLine("Account not found!");
            }
        }

        private bool HasAccount(string accountNumber)
        {
            return accounts.Any(account => account.AccountNumber == accountNumber);
        }

        private AccountInfo FindAccount(string LastName)
        {
            return accounts.FirstOrDefault(account => account.LastName == LastName)!;
        }

        private void Print()
        {
            foreach (AccountInfo account in accounts)
            {
            string fullName = $"{account.LastName} {account.FirstName} {account.MiddleName}";
                
                Console.WriteLine($"Name: {fullName}\nAccount Number: {account.AccountNumber}\nEmail: {account.Email}\nPhone Number: {account.PhoneNumber}\nAccount Balance: {account.Balance}");   
            }
        }

        private void PrintAllAccounts()
        {
            var table = new ConsoleTable("Id", "Name", "Account Number", "Phone Number", "Email", "ID Number", "Address", "Occupation", "BVN Number", "ATM Number", "ATM Pin", "CSV Number", "Account Type", "Balance", "Date Created");

            foreach (AccountInfo account in accounts)
            {
            string fullName = $"{account.LastName} {account.FirstName}";
                if (!string.IsNullOrWhiteSpace(account.MiddleName))
                {
                    fullName = $"{fullName} {account.MiddleName[0]}.";
                }
            table.AddRow(account.Id, fullName, account.AccountNumber, account.PhoneNumber, account.Email, account.GetIDNumber(), account.GetAddress(), account.GetOccupation(), account.BVNNumber, account.ATMNumber, account.ATMPin, account.CSVNumber, account.AccountType.Humanize(), account.Balance, account.CreatedAt.Humanize());
            }
            table.Write(Format.Alternative);
        }

        private double GetAccountBalance(string accountNumber)
        {
            AccountInfo account = FindAccount(accountNumber);
            if (account != null)
            {
                return account.Balance;
            }
            else
            {
                throw new ArgumentException("Account not found!");
            }
        }
    }
}