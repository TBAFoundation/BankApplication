using System.Text.RegularExpressions;

namespace BankApplication
{
    public class UserAccount
    {
        public UserInfo CreateAccount()
        {
            Console.WriteLine("Enter user information:");
            Console.WriteLine();

            string lastName = GetValidInput("Last Name", IsValidName);
            string firstName = GetValidInput("First Name", IsValidName);
            string middleName = GetValidInput("Middle Name", IsValidName, true);
            string phoneNumber = GetValidInput("Phone Number", IsValidPhoneNumber);
            string email = GetValidInput("Email", IsValidEmail, true);
            string idNumber = GetValidInput("Identification Number", IsValidIDNumber);
            string address = GetValidInput("Home Address", IsValidAddress);
            string occupation = GetValidInput("Occupation", IsValidName);

            return new UserInfo(lastName, firstName, middleName, phoneNumber, email, idNumber, address, occupation);
        }

        private string GetValidInput(string prompt, Func<string, bool> validationFunc, bool isOptional = false)
        {
            string userInput;
            do
            {
                Console.Write($"{prompt}: ");
                userInput = Console.ReadLine()!;
                if (isOptional && string.IsNullOrWhiteSpace(userInput))
                {
                    break;
                }

                if (!validationFunc(userInput))
                {
                    Console.WriteLine($"{prompt} is required. Please provide a valid {prompt}!");
                }
            } while (!validationFunc(userInput));

            return userInput;
        }

        private bool IsValidName(string name)
        {
            Regex nameRegex = new Regex("^[A-Za-z ]+$");
            return !string.IsNullOrWhiteSpace(name) && nameRegex.IsMatch(name);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex phoneNumberRegex = new Regex(@"^\d{11}$");
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumberRegex.IsMatch(phoneNumber);
        }

        private bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^[A-Za-z0-9]+@[a-z]+\.[A-Za-z]{2,}$");
            return string.IsNullOrWhiteSpace(email) || emailRegex.IsMatch(email);
        }

        private bool IsValidIDNumber(string idNumber)
        {
            Regex idNumberRegex = new Regex("^[A-Za-z0-9]+$");
            return !string.IsNullOrWhiteSpace(idNumber) && idNumberRegex.IsMatch(idNumber);
        }

        private bool IsValidAddress(string address)
        {
            Regex addressRegex = new Regex("^[0-9, A-Za-z]+$");
            return !string.IsNullOrWhiteSpace(address) && addressRegex.IsMatch(address);
        }

    }
}