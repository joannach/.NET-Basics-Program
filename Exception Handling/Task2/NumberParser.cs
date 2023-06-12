using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            stringValue = stringValue.Trim();
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new FormatException();
            }

            try
            {
                int sign = 1;
                int startIndex = 0;

                if (stringValue[0] == '-')
                {
                    sign = -1;
                    startIndex = 1;
                }
                else if (stringValue[0] == '+')
                {
                    startIndex = 1;
                }

                long result = 0;
                for (int i = startIndex; i < stringValue.Length; i++)
                {
                    char c = stringValue[i];

                    if (result > 0 && c == ' ')
                        break;

                    if (c < '0' || c > '9')
                    {
                        throw new FormatException();
                    }

                    int digit = c - '0';

                    checked
                    {
                        result = result * 10 + digit;
                    }
                }

                return Convert.ToInt32(result * sign);
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
        }
    }
}