namespace BankApplication
{
    public class AccountInfo : UserInfo
    {
        public string AccountNumber { get; private set; } = default!;
        public string BVNNumber { get; private set; }
        public string ATMNumber { get; private set; }
        public string ATMPin { get; private set; }
        public string CSVNumber { get; private set; }
        public decimal Balance { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountType AccountType { get; set; }

        Random random = new Random();

        public AccountInfo(int id, string lastName, string firstName, string middleName, string phoneNumber, string email, string idNumber, string address, string occupation,  AccountType accountType)
            : base(lastName, firstName, middleName, phoneNumber, email, idNumber, address, occupation)
        {
            Id = id;
            AccountNumber = GenerateAccountNumber();
            BVNNumber = GenerateBVNNumber();
            ATMNumber = GenerateATMNumber();
            ATMPin = GenerateATMPin();
            CSVNumber = GenerateCSVNumber();
            AccountType = accountType;
            Balance = 0;
            CreatedAt = DateTime.Now;
        }

        private string GenerateAccountNumber()
        {
            string accountNumber = string.Empty;
            for(int i = 0; i < 10; i++)
            {
                int digit = random.Next(10);
                accountNumber += digit.ToString();
            }
            return accountNumber.ToString();
        }

        private string GenerateBVNNumber()
        {
            string bvn = string.Empty;
            for(int i = 0; i < 11; i++)
            {
                int digit = random.Next(10);
                bvn += digit.ToString();
            }
            return bvn.ToString();
        }

        private string GenerateATMNumber()
        {
        string atmNumber = string.Empty;
        for(int i = 0; i < 16; i++)
        {
            int digit = random.Next(10);
            atmNumber += digit.ToString();
        }
        return atmNumber;
        }

        private string GenerateATMPin()
        {
            return random.Next(1000, 9999).ToString();
        }

        private string GenerateCSVNumber()
        {
            return random.Next(100, 999).ToString();
        }
        
        
    }
}