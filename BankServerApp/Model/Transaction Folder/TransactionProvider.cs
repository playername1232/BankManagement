namespace BankClientApp.Model;

public class TransactionProvider
{
    /// <summary>
    /// Registers incoming transaction for both Sender and Receiver
    /// </summary>
    /// <param name="transaction">New transaction</param>
    public static void RegisterNewTransaction(Transaction transaction)
    {
        transaction.Receiver.HistoryOfTransactions.Add(transaction);
        transaction.Sender.HistoryOfTransactions.Add(transaction);
    }
}