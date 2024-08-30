using System.Text.Json;
using System.Windows;
using BankClientApp.Model;
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

    private void TestingFunction()
    {
        FinanceProfile first  = new FinanceProfile(45145154, 4000, "CZK");
        FinanceProfile second = new FinanceProfile(454544, 4000, "CZK");
        FinanceProfile third = new FinanceProfile(4121, 20000000, "USD");

        first.AddTransaction(new Transaction(first, second, 
            (decimal)4000.0, "", ""));
        
        first.AddTransaction(new Transaction(third, first, 
            (decimal)9000.0, "Druha transakce", "Davaj prachy kamo"));
        
        third.AddTransaction(new Transaction(third, first, 
            (decimal)9000.0, "Druha transakce", "Davaj prachy kamo"));

        ClientProfile profileOne = new ClientProfile(155415555, "firstUsername", "firstPass");
        ClientProfile profileTwo = new ClientProfile(1234635, "secondUsername", "secondPass");
        
        profileOne.AddFinanceAccount(first);
        profileOne.AddFinanceAccount(second);
        profileTwo.AddFinanceAccount(third);
    }
}