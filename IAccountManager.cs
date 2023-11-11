namespace BankApplication
{
    public interface IAccountManager
    {
        void CreateAccount();
        void Deposit();
        void Withdraw();
        void Transfer();
        void CheckBalance();
        void GetAccount();
        void GetAllAccounts();
        void CloseAccount();
    }
}