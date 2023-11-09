namespace BankApplication
{
    internal class AccountManager : IAccountManager
    {
        private List<User> users = new List<User>();
        private bool hasAccount = false;
        private Random random = new Random();
        public string CreateAccount(string lastName, string firstName, string? middleName, string? email, string phoneNumber, string idNumber, string address, string occupation, DateTime birthDate, double initialBalance)        {
            if (hasAccount)
            {
                Console.WriteLine("You already have an account with the bank.");
                return string.Empty;
            }

            int id = users.Count > 0 ? users.Count + 1 : 1;

            var user = new User
            {
                Id = id,
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                PhoneNumber = phoneNumber,
                Email = email,
                IdNumber = idNumber,
                CreatedAt = DateTime.Now,
                Address = address,
                Occupation = occupation,
                BirthDate = birthDate,
                Balance = initialBalance
            };
            users.Add(user);

            string fullName = $"{user.LastName} {user.FirstName}";
            if (!string.IsNullOrWhiteSpace(user.MiddleName))
            {
                fullName = $"{fullName} {user.MiddleName[0]}.";
            }

            string accountNumber = GenerateAccountNumber();
            string atmNumber = GenerateATMNumber();
            string csv = GenerateCSV();
            string bvn = GenerateBVN();
            string atmPin = GenerateATMPin();

            Console.WriteLine($"Creating a new account for {fullName}...");
            Console.WriteLine($"Account created successfully. Account Number: {accountNumber}");
            Console.WriteLine($"ATM Number: {atmNumber}");
            Console.WriteLine($"CSV: {csv}");
            Console.WriteLine($"BVN: {bvn}");
            Console.WriteLine($"ATM PIN: {atmPin}");
            Console.WriteLine($"BALANCE: {initialBalance}");

            hasAccount = true;
            return accountNumber;
        }

        public void BankTransactionCharges()
        {
            throw new NotImplementedException();
        }

        public void CheckBalance()
        {
            throw new NotImplementedException();
        }

        public void CloseAccount()
        {
            throw new NotImplementedException();
        }

        public void Deposit()
        {
            throw new NotImplementedException();
        }

        public void FindAccount()
        {
            throw new NotImplementedException();
        }

        public void GetAccount()
        {
            throw new NotImplementedException();
        }

        public void GetAccountStatement()
        {
            throw new NotImplementedException();
        }

        public void GetAllAccount()
        {
            throw new NotImplementedException();
        }

        public void SetAccountLimit()
        {
            throw new NotImplementedException();
        }

        public void SetAccountType()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount()
        {
            throw new NotImplementedException();
        }

        public void Withdraw()
        {
            throw new NotImplementedException();
        }
        private string GenerateAccountNumber()
        {
            int accountNumber = random.Next(100000000, 1000000000);
            return accountNumber.ToString();
        }

        private string GenerateATMNumber()
        {
        // Generate a 16-digit ATM number
        string atmNumber = string.Empty;
        for(int i = 0; i < 17; i++)
        {
            int digit = random.Next(10);
            atmNumber += digit.ToString();
        }
        return atmNumber;
        }

        private string GenerateCSV()
        {
            // Generate a three-digit CSV
            int csv = random.Next(100, 1000);
            return csv.ToString();
        }

        private string GenerateBVN()
        {
            // Generate an 11-digit BVN
            string bvn = string.Empty;
            for(int i = 0; i < 11; i++)
            {
                int digit = random.Next(10);
                bvn += digit.ToString();
            }
            return bvn.ToString();
        }

        private string GenerateATMPin()
        {
            // Generate a four-digit unique ATM PIN
            int atmPin = random.Next(1000, 10000);
            return atmPin.ToString();
        }
    }

}