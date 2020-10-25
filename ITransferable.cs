namespace BankOfDotNet
{
    public interface ITransferable
    {
        void Transfer(Account to, double Amount);
    }
}