using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using BankClientApp.Model;
using BankClientApp.Packets.ResponsePackets;
using WpfApp1.AppWindows;
using WpfApp1.Packets;

namespace BankClientApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void BankingMainWinLoaded(object sender, RoutedEventArgs e)
    {
        LoginWindow window = new LoginWindow
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        window.Show();
        this.IsEnabled = false;
    }

    public void GetLoginData(string username, string password)
    {
        MessageBox.Show($"Given username: {username}\nGiven password: {password}", "GetLoginData<void>(string, string)", MessageBoxButton.OK);
        TestingFunction(username, password);
    }
    
    private void TestingFunction(string username, string password)
    {
        ClientProfile profile = new ClientProfile(418474, username, password);
        // profile.AddFinanceAccount(new FinanceProfile(15233, (decimal)230145.35, "CZK"));

        
        string json = JsonSerializer.Serialize(new CreateClientProfilePacket(profile));
        
        try
        {
            TcpClient client = new TcpClient("127.0.0.1", 6666);
            Stream stream = client.GetStream();
            
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            stream.Write(bytes, 0, bytes.Length);

            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);

            string received = Encoding.UTF8.GetString(bytesToRead).TrimEnd('\0') ?? JsonSerializer.Serialize(new BasePacket());

            BasePacket packet = BasePacket.DeserializePacket(received);

            if (packet.PacketId == (int)EPacketIDs.OkPacket)
            {
                MessageBox.Show("Packet was successful!");
            }
            else if (packet.PacketId == (int)EPacketIDs.BadPacket)
            {
                ErrorPacket errPacket = JsonSerializer.Deserialize<ErrorPacket>(received);
                MessageBox.Show($"Error has occured!\nMessage: {errPacket.Message}", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show($"Invalid packet received!\nReceived: {received}");
            }

            client.Close();
            stream.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);

            LoginWindow win = new LoginWindow()
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            
            win.Show();
            this.IsEnabled = false;
        }
    }
}