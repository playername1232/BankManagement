using BankClientApp.Model;

namespace BankServerApp;

class Program
{
    private static void PrintServerLog(string msg)
    {
        Console.WriteLine($"[Server log]: {msg}");
    }
    
    static void Main(string[] args)
    {
        TestingFunction();

        ConsoleKeyInfo key = new ConsoleKeyInfo();
        while (key.Key != ConsoleKey.A)
        {
            PrintServerLog("Press A key to exit");
            key = Console.ReadKey();
        }
        
        PrintServerLog("Exit key pressed. Shutting down server");
    }

    static void TestingFunction()
    {
        FinanceProfile first  = new FinanceProfile(45145154, 4000, "CZK");
        FinanceProfile second = new FinanceProfile(454544, 4000, "CZK");
        FinanceProfile third = new FinanceProfile(4121, 20000000, "USD");

        Transaction trans1 = new Transaction(11111111,first, second, (decimal)4000.0, "Wire Transfer", "");
        Transaction trans2 = new Transaction(22222222, first, second, (decimal)4000.0, "Wire Transfer", "Here You go");
        Transaction trans3 = new Transaction(33333333, third, second, (decimal)4000.0, "Wire Transfer", "And here I go");

        ClientProfile profileOne = new ClientProfile(155415555, "firstUsername", "firstPass");
        ClientProfile profileTwo = new ClientProfile(1234635, "secondUsername", "secondPass");
        
        profileOne.AddFinanceAccount(first);
        profileOne.AddFinanceAccount(second);
        profileTwo.AddFinanceAccount(third);
        
        TransactionProvider.RegisterNewTransaction(trans1);
        TransactionProvider.RegisterNewTransaction(trans2);
        TransactionProvider.RegisterNewTransaction(trans3);
    }
}