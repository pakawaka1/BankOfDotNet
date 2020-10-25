using System;

namespace BankOfDotNet
{
    public class OverdraftException : Exception
    {
        public double deficitAmount;
        public OverdraftException(string message, double deficitAmount) : base(message)
        {
            DeficitAmount = deficitAmount;
        }

        public double DeficitAmount
        {
            get { return deficitAmount; }
            private set { deficitAmount = value; }
        }
    }

}
