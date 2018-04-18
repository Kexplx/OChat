using MahApps.Metro.Controls;
using System;
using System.Net.Sockets;

namespace OChatNew.GUI
{
    public partial class LoginWindow : MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private bool CheckTextBoxEntries()
        {
            if (TxtIpAdress.Text == "" || TxtPort.Text == "" || TxtUserName.Text == "")
            {
                LblStatus.Content = "Fill the boxes";
                return false;
            }

            if (TxtUserName.Text.Contains("|"))
            {
                LblStatus.Content = "Name can't contain '|'";
                return false;
            }

            if (!int.TryParse(TxtPort.Text, out int x))
            {
                LblStatus.Content = "Port must be decimal";
                return false;
            }

            return true;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!CheckTextBoxEntries())
            {
                return;
            }

            var client = new TcpClient();
            var result = client.BeginConnect(TxtIpAdress.Text, int.Parse(TxtPort.Text), null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));

            if (!success)
            {
                LblStatus.Content = "Connection failed";
                return;
            }

            var mainWindow = new MainWindow(client, TxtUserName.Text);
            mainWindow.Show();
            Close();
        }
    }
}