using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using OChat.Core.Communication.ClientSide;

namespace OChat.ClientUI1
{
    public partial class LoginWindow
    {
        private bool _isOnlyConnectedToServer;
        private readonly ClientServerMiddleman _clientServerMiddleman;

        public LoginWindow()
        {
            InitializeComponent();
            LblVersion.Content = System.Configuration.ConfigurationManager.AppSettings["version"];
            _clientServerMiddleman = new ClientServerMiddleman();
        }

        private void BeginLoginProcessOnServer()
        {
            SpinnerCog1.Visibility = System.Windows.Visibility.Visible;
            BrdPort.BorderBrush = Brushes.DarkGray;
            BrdUsername.BorderBrush = Brushes.DarkGray;
            BrdIpv4Adress.BorderBrush = Brushes.DarkGray;

            new Thread(() =>
            {
                var port = string.Empty;
                var ipv4Adress = string.Empty;

                Dispatcher.Invoke(() =>
                {
                    port = TxtPort.Text;
                    ipv4Adress = TxtIpv4Adress.Text;
                });

                _isOnlyConnectedToServer = _clientServerMiddleman.ConnectToServer(int.Parse(port), ipv4Adress);

                Dispatcher.Invoke(() =>
                {
                    if (!_isOnlyConnectedToServer)
                    {
                        BrdIpv4Adress.BorderBrush = Brushes.IndianRed;
                        BrdPort.BorderBrush = Brushes.IndianRed;

                        SpinnerCog1.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    else if (!_clientServerMiddleman.CheckIfUsernameAvailable(TxtUsername.Text))
                    {
                        BrdUsername.BorderBrush = Brushes.IndianRed;

                        SpinnerCog1.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    else
                    {
                        new ChatWindow(_clientServerMiddleman, TxtUsername.Text).Show();
                        _isOnlyConnectedToServer = false;
                        Close();
                    }
                });
            }).Start();
        }

        private void ImgBugReport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new BugReportWindow(Left, Top, Width)
            {
                Owner = this
            }.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ipv4Regex = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
            ImgBeginLogin.Opacity = 0.6;
            ImgBeginLogin.IsEnabled = false;

            try
            {
                if (TxtIpv4Adress.Text == "" || TxtPort.Text == "" || TxtUsername.Text == "")
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            if (!ipv4Regex.IsMatch(TxtIpv4Adress.Text))
            {
                return;
            }

            if (int.TryParse(TxtPort.Text, out var parsedPort))
            {
                if (parsedPort < 0 || parsedPort > 65535)
                {
                    return;
                }
            }
            else
            {
                return;
            }

            ImgBeginLogin.IsEnabled = true;
            ImgBeginLogin.Opacity = 1;
        }

        private void ImgBeginLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BeginLoginProcessOnServer();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left) return;
            try
            {
                DragMove();
            }
            catch
            {
                // ignored
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && ImgBeginLogin.IsEnabled)
            {
                BeginLoginProcessOnServer();
            }
        }
    }
}
