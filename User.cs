namespace BankApplication
{
    public class User : UserInfo
    {
        public int Id {get; set;}
        public string LastName {get; set;} = default!;
        public string FirstName {get; set;} = default!;
        public string? MiddleName {get; set;}
        public string PhoneNumber {get; set;} = default!;
        public string? Email {get; set;}
        public DateTime CreatedAt {get; set;}
            
    }
}