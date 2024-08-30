namespace BankClientApp.Model;

public class FinanceProfile
{
    public ulong  AccountId       { get; private set; }
    public decimal AccountBalance { get; private set; }
    public string  CurrencyName   { get; private set; }
    public List<Transaction> HistoryOfTransactions   { get; private set; }

    public FinanceProfile(ulong accountId, decimal accountBalance, string currencyName)
    {
        AccountId = accountId;
        AccountBalance = accountBalance;
        CurrencyName = currencyName;
        HistoryOfTransactions = new List<Transaction>();
    }

    // ctor for deserialization
    public FinanceProfile(ulong accountId, decimal accountBalance, string currencyName, List<Transaction> historyOfTransactions)
    {
        AccountId = accountId;
        AccountBalance = accountBalance;
        CurrencyName = currencyName;
        HistoryOfTransactions = historyOfTransactions;
    }

    public void AddTransaction(Transaction transaction)
    {
        if (HistoryOfTransactions.Any(x => x.TransactionId == transaction.TransactionId))
            return;
        
        HistoryOfTransactions.Add(transaction);
    }
}