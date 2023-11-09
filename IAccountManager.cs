using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication
{
    public interface IAccountManager
    {
        string CreateAccount(string lastName, string firstName, string? middleName, string? email, string phoneNumber, string idNumber, string address, string occupation, DateTime birthDate, double initialBalance);

        void FindAccount();

        void CheckBalance();

        void Withdraw();

        void Deposit();

        void Transfer();

        void SetAccountType();

        void SetAccountLimit();

        void BankTransactionCharges();

        void GetAccountStatement();

        void UpdateAccount();

        void GetAccount();

        void GetAllAccount();

        void CloseAccount();
    }
}