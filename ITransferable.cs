using System;
using System.Collections.Generic;
using System.Text;

namespace BankofDotNet
{
    public interface ITransferable
    {
        void Transfer(BankOfDotNet.Account to, double Amount);
    }
}
