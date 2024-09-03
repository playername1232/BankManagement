using BankClientApp.Model;

namespace BankServerApp.Server_Functions;

public abstract class ServerFunctions
{
    #region ClientSection
    public static void RegisterNewClient(ClientProfile client)
    {
        // TODO: Check if record exists in the database, if not Upload the record to database
        throw new NotImplementedException();
    }

    public static ClientProfile GetClientById(ulong clientId)
    {
        // TODO: Get client from database by ClientId
        throw new NotImplementedException();
    }
    
    #endregion

    
    #region BankAccountSection
    public static void AssignBankAccountToClient(ClientProfile client, FinanceProfile finance)
    {
        if (client.GetBankAccounts().Any(x => x.AccountId == finance.AccountId))
            return;

        client.AddFinanceAccount(finance);
        // TODO: Upload to the database
        throw new NotImplementedException();
    }

    public static void GetBankAccountById(ulong bankAccId)
    {
        // TODO: Get Bank account from database by Bank account id
        throw new NotImplementedException();
    }
    #endregion
    
    
    #region TransactionSection
    public static void RegisterNewTransaction(Transaction transaction)
    {
        TransactionProvider.RegisterNewTransaction(transaction);
        // TODO: Upload Bank accounts changes and register transaction in the database
        throw new NotImplementedException();
    }

    public static void RevertTransaction(Transaction transaction)
    {
        TransactionProvider.RevertTransaction(transaction);
        // TODO: Upload Bank accounts changes and register transaction in the database
        throw new NotImplementedException();
    }

    #endregion
}