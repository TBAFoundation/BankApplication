namespace BankApplication
{
    public class UserInfo
    {
        public string? IdNumber { get; set; }
        public double Balance { get; set; }
        public string Address {get; set;} = default!;
        public string? Occupation {get; set;}
        public DateTime BirthDate { get; set; }
        
    }
}