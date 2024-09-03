namespace BankClientApp.Model;

public abstract class TransactionProvider
{
    /// <summary>
    /// Registers incoming transaction for both Sender and Receiver
    /// </summary>
    /// <param name="transaction">New transaction</param>
    public static void RegisterNewTransaction(Transaction transaction)
    {
        transaction.Receiver.AddTransaction(transaction);
        transaction.Sender.AddTransaction(transaction);
    }

    public static void RevertTransaction(Transaction transaction)
    {
        transaction.Receiver.RemoveTransaction(transaction);
        transaction.Sender.RemoveTransaction(transaction);
    }
}