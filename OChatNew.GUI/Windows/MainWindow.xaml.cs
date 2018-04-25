using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace OChatNew.GUI
{
    public partial class MainWindow : MetroWindow
    {
        private BinaryReader _reader;
        private BinaryWriter _writer;
        private List<string> _currentOnlineClients = new List<string>();
        private string _userName;

        private bool _windowClosedWithButton = false;
        private bool _windowClosed = false;

        private int lastColorIndexUsed = 0;

        private IDictionary<int, Brush> colorCollection = new Dictionary<int, Brush>
        {
            {0, Brushes.CornflowerBlue},
            {1, Brushes.OrangeRed },
            {2, Brushes.DarkSeaGreen },
            {3, Brushes.Cyan },
            {4, Brushes.MediumPurple },
            {5, Brushes.Teal },
            {6, Brushes.RosyBrown }
        };

        private IDictionary<string, Brush> _userColorCollection = new Dictionary<string, Brush>();

        public MainWindow(TcpClient client, string userName)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _userName = userName;
            _currentOnlineClients.Add(_userName + " (You)");

            _reader = new BinaryReader(client.GetStream());
            _writer = new BinaryWriter(client.GetStream());
            DtGrdOnlineUsers.ItemsSource = _currentOnlineClients;

            DtGrdOnlineUsers.ItemsSource = _currentOnlineClients;

            StartReaderThread();
            _writer.Write("USERWENTONLINE:" + _userName);
            BindUserToColor(_userName);
        }

        public void BindUserToColor(string userName)
        {
            try
            {
                _userColorCollection.Add(userName, colorCollection[lastColorIndexUsed % 6]);
                lastColorIndexUsed++;
            }
            catch
            {

            }
        }

        #region Reading
        private void StartReaderThread()
        {
            var backGroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backGroundWorker.DoWork += ReadThread_DoWork;
            backGroundWorker.ProgressChanged += ReaderThread_MessageReceived;

            backGroundWorker.RunWorkerAsync();
        }

        private void ReadThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_windowClosed)
            {
                try
                {
                    var receivedMessage = _reader.ReadString();
                    (sender as BackgroundWorker).ReportProgress(0, receivedMessage);
                }
                catch
                { }
            }
        }

        private void ReaderThread_MessageReceived(object sender, ProgressChangedEventArgs e)
        {
            var receivedMessage = e.UserState as string;

            switch (receivedMessage.Split(':')[0])
            {
                case "ONLINEUSERS":
                    var onlineUsers = (receivedMessage.Split(':')[1].Split('|')).ToList();

                    if (onlineUsers.Count == 1)
                    {
                        break;
                    }

                    foreach (var user in onlineUsers)
                    {
                        if (user != _userName && user != string.Empty)
                        {
                            _currentOnlineClients.Add(user);
                            BindUserToColor(user);
                        }
                    }
                    DtGrdOnlineUsers.ItemsSource = _currentOnlineClients;

                    DtGrdOnlineUsers.Items.Refresh();
                    break;

                case "USERWENTOFFLINE":
                    var tr = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    tr.Text = "Server [" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "]: " + receivedMessage.Split(':')[1] + " has disconnected";
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.LightGoldenrodYellow);

                    _currentOnlineClients.Remove(receivedMessage.Split(':')[1]);
                    DtGrdOnlineUsers.Items.Refresh();

                    MainChatBox.AppendText(Environment.NewLine);
                    break;

                case "USERWENTONLINE":
                    tr = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    tr.Text = "Server [" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "]: " + receivedMessage.Split(':')[1] + " has connected";
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.LightGoldenrodYellow);

                    _currentOnlineClients.Add(receivedMessage.Split(':')[1]);
                    DtGrdOnlineUsers.Items.Refresh();

                    BindUserToColor(receivedMessage.Split(':')[1]);

                    MainChatBox.AppendText(Environment.NewLine);
                    break;

                case "CONTENTMSG":
                    tr = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    tr.Text = receivedMessage.Split(':')[1] + " [" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "]: " + receivedMessage.Split(':')[2];
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, _userColorCollection[receivedMessage.Split(':')[1]]);

                    MainChatBox.AppendText(Environment.NewLine);
                    break;
            }

            MainChatBox.ScrollToEnd();
        }

        #endregion Reading

        /// <summary>
        /// Reads the clients input from the textbox, writes it into the richtext box and sends it to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var tr = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                tr.Text = _userName + " [" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "]: " + TxtBoxEnter.Text;
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, _userColorCollection[_userName]);

                MainChatBox.AppendText(Environment.NewLine);
                MainChatBox.ScrollToEnd();

                _writer.Write("CONTENTMSG:" + _userName + ":" + TxtBoxEnter.Text);
                TxtBoxEnter.Clear();
            }
        }

        #region Closing
        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            _windowClosed = true;
            _windowClosedWithButton = true;
            _writer.Write("USERWENTOFFLINE:" + _userName);

            var login = new LoginWindow();
            login.Show();
            Close();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _windowClosed = true;
            if (!_windowClosedWithButton)
            {
                _writer.Write("USERWENTOFFLINE:" + _userName);
            }
        }
        #endregion
    }
}