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
            string phoneNumber = null!;
            var hasAccount = HasAccount(phoneNumber);
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
            string accountNumber = GetAccountNumber();
            AccountInfo account = FindAccount(accountNumber);

            if (account != null)
            {
                Console.Write("Enter the amount to deposit: ");
                decimal amount = ReadDecimalInput();

                account.Balance += amount;
                PrintTransactionNotification("Deposit successful.", amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw()
        {
            string accountNumber = GetAccountNumber();
            AccountInfo account = FindAccount(accountNumber);

            if (account != null)
            {
                Console.Write("Enter the amount to withdraw: ");
                decimal amount = ReadDecimalInput();

                if (account.Balance >= amount)
                {
                    account.Balance -= amount;
                    PrintTransactionNotification("Withdrawal successful.", amount);
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        
        public void Transfer()
        {
            string fromAccountNumber = GetAccountNumber("Enter the account number to transfer from: ");
            AccountInfo fromAccount = FindAccount(fromAccountNumber);

            if (fromAccount != null)
            {
                string toAccountNumber = GetAccountNumber("Enter the account number to transfer to: ");
                AccountInfo toAccount = FindAccount(toAccountNumber);

                if (toAccount != null)
                {
                    Console.Write("Enter the amount to transfer: ");
                    decimal amount = ReadDecimalInput();

                    if (fromAccount.Balance >= amount)
                    {
                        fromAccount.Balance -= amount;
                        toAccount.Balance += amount;
                        PrintTransactionNotification("Transfer successful.", amount);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                }
                else
                {
                    Console.WriteLine("Destination account not found.");
                }
            }
            else
            {
                Console.WriteLine("Source account not found.");
            }
        }

        public void CheckBalance()
        {
            string accountNumber = GetAccountNumber();
            AccountInfo account = FindAccount(accountNumber);

            if (account != null)
            {
                Console.WriteLine($"Account Balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void GetAccount()
        {
            Console.Write("Enter Acount Name: ");
            string LastName = Console.ReadLine()!;

            Console.WriteLine("Finding Acount Details... ");
            AccountInfo account = FindAccountByName(LastName);
            
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

        private bool HasAccount(string phoneNumber)
        {
            return accounts.Any(account => account.PhoneNumber == phoneNumber);
        }

        private AccountInfo FindAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber)!;
        }

        private string GetAccountNumber(string prompt = "Enter the account number: ")
        {
            Console.Write(prompt);
            string accountNumber = Console.ReadLine()!;
            return accountNumber;
        }

        private AccountInfo FindAccountByName(string LastName)
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

        private decimal ReadDecimalInput()
        {
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive decimal value.");
                Console.Write("Enter the amount: ");
            }

            return amount;
        }

        private void PrintTransactionNotification(string transactionType, decimal amount)
        {
            foreach (AccountInfo account in accounts)
            {
                Console.WriteLine($"Transaction Notification");
                Console.WriteLine($"Hi {account.LastName},");
                Console.WriteLine($"{amount} has been {transactionType.ToLower()} from your account.");
                Console.WriteLine();
                Console.WriteLine("Here is what you need to know:");
                Console.WriteLine($"Reference No: {GenerateReferenceNumber()}");
                Console.WriteLine($"Account No: {account.AccountNumber}");
                Console.WriteLine($"Account Name: {account.LastName}");
                Console.WriteLine($"Date and Time: {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}");
                Console.WriteLine($"Value Date: {DateTime.Now.ToString("dd-MM-yyyy")}");
                Console.WriteLine($"Account Balance: {account.Balance}");
                Console.WriteLine();
            }
        }

        private string GenerateReferenceNumber()
        {
            Random random = new Random();
            string randomDigits = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                randomDigits += random.Next(10);
            }
            string referenceNumber = $"S{randomDigits}";
            return referenceNumber;
        }
    }
}