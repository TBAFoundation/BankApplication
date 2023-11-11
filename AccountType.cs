using System.ComponentModel;

namespace BankApplication
{
    public enum AccountType
    {
        [Description("Current Acount")]
        Current = 1,
        [Description("Saving Acount")]
        Savings
    }
}