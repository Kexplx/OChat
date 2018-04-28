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
        private List<Client> _currentOnlineClients = new List<Client>();
        private Client _thisClient;

        private bool _windowClosedWithButton = false;
        private bool _windowClosed = false;

        private int lastColorIndexUsed = -1;

        private IDictionary<int, Brush> colorCollection = new Dictionary<int, Brush>
        {
            {0, Brushes.CornflowerBlue},
            {1, Brushes.OrangeRed },
            {2, Brushes.DarkSeaGreen },
            {3, Brushes.Cyan },
            {4, Brushes.MediumPurple },
            {5, Brushes.Teal },
            {6, Brushes.RosyBrown },
            {7, Brushes.Tan }
        };

        public MainWindow(TcpClient client, string userName)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _thisClient = new Client { Name = userName, Color = GetColorForUser() };
            DtGrdOnlineUsers.ItemsSource = _currentOnlineClients;

            _currentOnlineClients.Add(_thisClient);

            _reader = new BinaryReader(client.GetStream());
            _writer = new BinaryWriter(client.GetStream());

            StartReaderThread();
            _writer.Write("USERWENTONLINE:" + _thisClient.Name);
        }

        public Brush GetColorForUser()
        {
            lastColorIndexUsed++;
            return colorCollection[lastColorIndexUsed % colorCollection.Count];
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
                        if (user != _thisClient.Name && user != string.Empty)
                        {
                            _currentOnlineClients.Add(new Client { Name = user, Color = GetColorForUser() });
                        }
                    }
                    DtGrdOnlineUsers.ItemsSource = _currentOnlineClients;

                    DtGrdOnlineUsers.Items.Refresh();
                    break;

                case "USERWENTOFFLINE":
                    var tr = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    tr.Text = "Server  [" + DateTime.Now.ToString("HH:mm") + "]: " + receivedMessage.Split(':')[1] + " has disconnected";
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.LightGoldenrodYellow);

                    _currentOnlineClients.RemoveAll(x => x.Name == receivedMessage.Split(':')[1]);
                    DtGrdOnlineUsers.Items.Refresh();

                    MainChatBox.AppendText(Environment.NewLine);
                    break;

                case "USERWENTONLINE":
                    tr = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    tr.Text = "Server  [" + DateTime.Now.ToString("HH:mm") + "]: " + receivedMessage.Split(':')[1] + " has connected";
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.LightGoldenrodYellow);

                    _currentOnlineClients.Add(new Client { Name = receivedMessage.Split(':')[1], Color = GetColorForUser() });
                    DtGrdOnlineUsers.Items.Refresh();

                    MainChatBox.AppendText(Environment.NewLine);
                    break;

                case "CONTENTMSG":
                    var userName = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    userName.Text = receivedMessage.Split(':')[1];
                    userName.ApplyPropertyValue(TextElement.ForegroundProperty, _currentOnlineClients.Where(x => x.Name == receivedMessage.Split(':')[1]).First().Color);

                    var date = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    date.Text = "  " + DateTime.Now.ToString("[HH:mm]") + ": ";
                    date.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Gray);

                    var content = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                    content.Text = receivedMessage.Split(':')[2];
                    content.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.White);

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
                var userName = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                userName.Text = _thisClient.Name;
                userName.ApplyPropertyValue(TextElement.ForegroundProperty, _currentOnlineClients.Where(x => x.Name == _thisClient.Name).First().Color);

                var date = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                date.Text = "  " + DateTime.Now.ToString("[HH:mm]") + ": ";
                date.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Gray);

                var content = new TextRange(MainChatBox.Document.ContentEnd, MainChatBox.Document.ContentEnd);
                content.Text = TxtBoxEnter.Text;
                content.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.White);

                MainChatBox.AppendText(Environment.NewLine);
                MainChatBox.ScrollToEnd();

                _writer.Write("CONTENTMSG:" + _thisClient.Name + ":" + TxtBoxEnter.Text);
                TxtBoxEnter.Clear();
            }
        }

        #region Closing

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            _windowClosed = true;
            _windowClosedWithButton = true;
            _writer.Write("USERWENTOFFLINE:" + _thisClient.Name);

            var login = new LoginWindow();
            login.Show();
            Close();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _windowClosed = true;
            if (!_windowClosedWithButton)
            {
                _writer.Write("USERWENTOFFLINE:" + _thisClient.Name);
            }
        }

        #endregion Closing
    }
}