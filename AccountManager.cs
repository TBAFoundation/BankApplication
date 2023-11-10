namespace BankApplication
{
    internal class AccountManager : IAccountManager
    {
        private List<AccountInfo> accounts = new List<AccountInfo>();
        private bool hasAccount = false;
        public void CreateAccount()
        {
            int id = accounts.Count > 0 ? accounts.Count + 1 : 1;
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;
            var hasAccount = HasAccount(accountNumber);
            if (hasAccount)
            {
                Console.WriteLine("You already have an account with the bank.");
                return;
            }

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine()!;
            Console.Write("First Name: ");
            string firstName = Console.ReadLine()!;
            Console.Write("Middle Name: ");
            string middleName = Console.ReadLine()!;
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine()!;
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            Console.WriteLine("Enter user information:");
            Console.Write("ID Number: ");
            string idNumber = Console.ReadLine()!;
            Console.Write("Address: ");
            string address = Console.ReadLine()!;
            Console.Write("Occupation: ");
            string occupation = Console.ReadLine()!;

            AccountInfo account = new AccountInfo(id, lastName, firstName, middleName, phoneNumber, email,idNumber, address, occupation);
            accounts.Add(account);

            Console.WriteLine("Account created successfully!");
        }

        public void Deposit()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;
            Console.Write("Enter amount to deposit: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            AccountInfo account = FindAccountByAccountNumber(accountNumber);
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

            AccountInfo account = FindAccountByAccountNumber(accountNumber);
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

            AccountInfo senderAccount = FindAccountByAccountNumber(senderAccountNumber);
            AccountInfo recipientAccount = FindAccountByAccountNumber(recipientAccountNumber);
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

            AccountInfo account = FindAccountByAccountNumber(accountNumber);
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

        public void PrintAllAccounts()
        {
            Console.WriteLine("Printing all accounts:");
            foreach (AccountInfo account in accounts)
            {
                account.PrintAccountInfo();
                Console.WriteLine("----------------------------------------");
            }
        }

        public void CloseAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine()!;

            AccountInfo account = FindAccountByAccountNumber(accountNumber);
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

        private AccountInfo FindAccountByAccountNumber(string accountNumber)
        {
            return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber)!;
        }

        private double GetAccountBalance(string accountNumber)
        {
            AccountInfo account = FindAccountByAccountNumber(accountNumber);
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