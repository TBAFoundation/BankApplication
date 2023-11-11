namespace BankApplication
{
    public static class Utility
    {
        public static int SelectEnum(string label, int start, int end)
        {
            int selectedOption;

            do
            {
                Console.Write(label);
            }
            while (!(int.TryParse(Console.ReadLine(), out selectedOption) && IsRangeValid(selectedOption, start, end)));

            return selectedOption;
        }

        public static bool IsRangeValid(int value, int start, int end)
        {
            return value >= start && value <= end;
        }
    }
}