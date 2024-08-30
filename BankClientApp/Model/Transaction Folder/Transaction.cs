namespace BankClientApp.Model;

public class Transaction
{
    public ulong         TransactionId { get; private set; } 
    public FinanceProfile Sender        { get; private set; }
    public FinanceProfile Receiver      { get; private set; }
    public decimal        Amount       { get; private set; }
    public string         Description   { get; private set; }
    public string         EmbedMessage { get; private set; }
    public DateTime DateOfTransaction { get; private set; }
    
    
    public Transaction(FinanceProfile sender, FinanceProfile receiver, decimal amount, 
        string description, string embedMessage = "")
    {
        this.Sender      = sender;
        this.Receiver    = receiver;
        this.Amount     = amount;
        this.Description = description;
        this.EmbedMessage = embedMessage;

        this.DateOfTransaction = DateTime.Now;
    }

    // ctor for deserialization
    public Transaction(FinanceProfile sender, FinanceProfile receiver, decimal amount, 
        string description, string embedMessage = "", DateTime dateOfTransaction = new DateTime())
    {
        Sender = sender;
        Receiver = receiver;
        this.Amount = amount;
        this.Description = description;
        this.EmbedMessage = embedMessage;
        DateOfTransaction = dateOfTransaction;
    }
}