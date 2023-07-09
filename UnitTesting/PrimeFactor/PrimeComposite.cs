using System.Text;

namespace PrimeFactor
{
    public class PrimeComposite
    {
        public readonly string PRIME = "prime ";

        public readonly string COMPOSITE = "composite ";

        public string GetPrimeCompositeNumbers(int start, int end)
        {
            StringBuilder sb = new StringBuilder();

            for (int number = start; number <= end; number++)
            {
                if (IsPrime(number))
                {
                    sb.Append(PRIME);
                }
                else if (IsComposite(number) && !IsEven(number))
                {
                    sb.Append(COMPOSITE);
                }
                else
                {
                    sb.Append(number + " ");
                }
            }

            return sb.ToString().Trim();
        }

        public bool IsPrime(int num)
        {
            if (num <= 2)
                return false;

            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        public bool IsComposite(int num)
        {
            return num > 1 && !IsPrime(num);
        }

        public bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
