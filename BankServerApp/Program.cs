namespace BankServerApp;

class Program
{
    private static void PrintServerLog(string msg)
    {
        Console.WriteLine($"[Server log]: {msg}");
    }
    
    static void Main(string[] args)
    {
        PrintServerLog("\nHello, World!");

        ConsoleKeyInfo key = new ConsoleKeyInfo();
        while (key.Key != ConsoleKey.A)
        {
            PrintServerLog("Press A key to exit");
            key = Console.ReadKey();
        }
        
        PrintServerLog("Exit key pressed. Shutting down server");
    }
}