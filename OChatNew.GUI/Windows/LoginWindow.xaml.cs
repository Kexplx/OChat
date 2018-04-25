using MahApps.Metro.Controls;
using System;
using System.IO;
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

        private bool CheckIfUsernameAvaiable(TcpClient client)
        {
            var writer = new BinaryWriter(client.GetStream());
            var reader = new BinaryReader(client.GetStream());

            writer.Write("CHECKNAME:" + TxtUserName.Text);

            return bool.Parse(reader.ReadString().Split(':')[1]);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!CheckTextBoxEntries())
            {
                return;
            }

            var client = new TcpClient();
            try
            {
                client.Connect(TxtIpAdress.Text, int.Parse(TxtPort.Text));
            }
            catch
            {
                LblStatus.Content = "Connection failed";
                return;
            }

            if (!CheckIfUsernameAvaiable(client))
            {
                LblStatus.Content = "Username not available";
                return;
            }

            var mainWindow = new MainWindow(client, TxtUserName.Text);
            mainWindow.Show();
            Close();
        }
    }
}