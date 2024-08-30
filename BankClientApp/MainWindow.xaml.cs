using System.Windows;
using WpfApp1.AppWindows;

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
}