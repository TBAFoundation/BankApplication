using Humanizer;
using ConsoleTables;

namespace BankApplication
{
    public class AccountInfo : UserInfo
    {
        public string AccountNumber { get; private set; } = default!;
        public string BVNNumber { get; private set; } = default!;
        private string ATMNumber;
        private string ATMPin;
        private string CSVNumber;
        public double Balance { get; private set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountType accountType { get; internal set; }

        Random random = new Random();

        public AccountInfo(int id, string idNumber, string address, string occupation, string lastName, string firstName, string middleName, string phoneNumber, string email, AccountType accountType) 
        : base(idNumber, address, occupation, lastName, firstName, middleName, phoneNumber, email)
        {
            Id = id;
            AccountNumber = GenerateAccountNumber();
            BVNNumber = GenerateBVNNumber();
            ATMNumber = GenerateATMNumber();
            ATMPin = GenerateATMPin();
            CSVNumber = GenerateCSVNumber();
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
        
        // public void PrintAccountInfo()
        // {
        //     string fullName = $"{LastName} {FirstName}";
        //     if (!string.IsNullOrWhiteSpace(MiddleName))
        //     {
        //         fullName = $"{fullName} {MiddleName[0]}.";
        //     }            
            // Console.WriteLine("Account Information");
            // Console.WriteLine("Account ID: " + Id);
            // Console.WriteLine("Account Name: " + fullName);
            // Console.WriteLine("Phone Number: " + PhoneNumber);
            // Console.WriteLine("Email: " + Email);
            // Console.WriteLine("ID Number: " + GetIDNumber());
            // Console.WriteLine("Address: " + GetAddress());
            // Console.WriteLine("Occupation: " + GetOccupation());
            // Console.WriteLine("Account Number: " + AccountNumber);
            // Console.WriteLine("BVN Number: " + BVNNumber);
            // Console.WriteLine("ATM Number: " + ATMNumber);
            // Console.WriteLine("ATM Pin: " + ATMPin);
            // Console.WriteLine("CSV Number: " + CSVNumber);
            // Console.WriteLine("Account Balance: " + Balance.ToString("C"));
            // Console.WriteLine("Time Created: " + DateTime.Now);
    }
}