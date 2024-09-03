using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using BankClientApp.Model;
using BankClientApp.Packets.ResponsePackets;
using BankServerApp.Server_Functions;
using WpfApp1.Packets;

namespace BankServerApp;

class Program
{
    private const string ServerLogPrefix = "[Server log]: ";
    private const int ListeningPort = 6666;
    private static void PrintServerLog(string msg)
    {
        Console.WriteLine($"{ServerLogPrefix}{msg}");
    }

    private static void DebugServerLog(string msg)
    {
        Debug.WriteLine($"{ServerLogPrefix}{msg}");
    }

    static async Task HandleReceivedPacket(string json)
    {
        BasePacket packet = BasePacket.DeserializePacket(json);

        switch (packet.PacketId)
        {
            case (int)EPacketIDs.CreateClientProfilePacket:
            {
                PrintServerLog($"Received packet {nameof(EPacketIDs.CreateClientProfilePacket)}");
                // TODO: After RegisterNewClient function is implemented
                // ServerFunctions.RegisterNewClient(CreateClientProfilePacket.ConvertToClientProfile(JsonSerializer.Deserialize<CreateClientProfilePacket>(json)));
                break;
            }
            case (int)EPacketIDs.CreateFinanceAccountPacket:
            {
                PrintServerLog($"Received packet {nameof(EPacketIDs.CreateFinanceAccountPacket)}");
                // TODO: After AssignBankAccountToClient function is implemented
                /* CreateFinanceProfilePacket finance = JsonSerializer.Deserialize<CreateFinanceProfilePacket>(json);
                ClientProfile client = ServerFunctions.GetClientById(finance.AccountOwnerId);
                
                ServerFunctions.AssignBankAccountToClient(client, CreateFinanceProfilePacket.ConvertToFinanceProfile(finance)); */
                
                break;
            }
            default:
            {
                PrintServerLog("Switch has jumped to default state!");
                break;
            }
        }
    }
    
    static async Task TcpConnectionListenerAsync()
    {
        PrintServerLog("Listening for TCP Connection...");
        IPAddress ipAdd = IPAddress.Parse("127.0.0.1");
        
        TcpListener listener = new TcpListener(ipAdd, ListeningPort);
        listener.Start();
        PrintServerLog($"Listener has started");
        
        while (true)
        {
            Socket socket = await listener.AcceptSocketAsync();
        
            PrintServerLog($"Connection from {socket.RemoteEndPoint}");

            byte[] buffer = new byte[8096];
            int count = socket.Receive(buffer);
            string str = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

            await HandleReceivedPacket(str);

            string json = JsonSerializer.Serialize(new ErrorPacket("Testing error message", PacketErrorCodes.DefaultError));
            
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            int res = socket.Send(bytes);
            
            socket.Close();
        }
    }
    
    static async Task Main(string[] args)
    {
        // Temporal implementation. Instead of having List of profiles we will store the data in database
        List<ClientProfile> profiles = new List<ClientProfile>();
        
        TestingFunction();

        ConsoleKeyInfo key = new ConsoleKeyInfo();
        Task[] tasks = new Task[2];
        tasks[0] = Task.Run(() =>
        {
            while (key.Key != ConsoleKey.A)
            {
                PrintServerLog("Press A key to exit");
                key = Console.ReadKey();
            }
        });

        tasks[1] = Task.Run(() => TcpConnectionListenerAsync());

        await Task.WhenAny(tasks);
        
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