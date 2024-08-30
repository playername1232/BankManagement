namespace BankClientApp.Model;

public class ClientProfile
{
    public long   ClientId { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public List<FinanceProfile> ClientBankAccounts { get; private set; }

    public ClientProfile(long clientId, string username, string password)
    {
        this.ClientId = clientId;
        this.Username = username;
        this.Password = password;
        
        ClientBankAccounts = new List<FinanceProfile>();
    }
    
    // ctor for deserialization
    public ClientProfile(long clientId, string username, string password, List<FinanceProfile> bankAccounts)
    {
        this.ClientId = clientId;
        this.Username = username;
        this.Password = password;
        
        this.ClientBankAccounts = bankAccounts;
    }

    public void AddFinanceAccount(FinanceProfile profile)
    {
        if (ClientBankAccounts.Any(x => x.AccountId == profile.AccountId))
            return;

        ClientBankAccounts.Add(profile);
    }
}