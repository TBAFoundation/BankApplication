namespace BankApplication
{
    public class UserInfo
    {
        private string IDNumber;
        private string Address;
        private string Occupation;
        public string LastName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; } 
        public string PhoneNumber { get; set; } = default!;
        public string? Email { get; set; }

        public UserInfo(string lastName, string firstName, string middleName, string phoneNumber, string email, string idNumber, string address, string occupation)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            Email = email;
            IDNumber = idNumber;
            Address = address;
            Occupation = occupation;
        }

        public UserInfo(string idNumber, string address, string occupation)
        {
            IDNumber = idNumber;
            Address = address;
            Occupation = occupation;
        }

        public string GetIDNumber()
        {
            return IDNumber;
        }

        public string GetAddress()
        {
            return Address;
        }

        public string GetOccupation()
        {
            return Occupation;
        }
    }
}