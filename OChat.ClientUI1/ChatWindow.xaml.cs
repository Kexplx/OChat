using OChat.Core.ClientSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using OChat.ClientUI1.ViewModels;
using OChat.Core.Communication.ClientSide;
using System.Windows.Input;
using System.Threading;

namespace OChat.ClientUI1
{
    public partial class ChatWindow
    {
        private readonly object _monitor = new object();
        private readonly ClientServerMiddleman _clientServerMiddleman;
        private readonly string _username;

        private int _lastColorCollectionIndexUsed = -1;
        private readonly IList<Brush> _userColors = new List<Brush>
        {
            Brushes.SlateGray,
            Brushes.SteelBlue,
            Brushes.MediumPurple,
            Brushes.RosyBrown,
            Brushes.CadetBlue,
        };

        public ChatWindow(ClientServerMiddleman clientToServerMiddleman, string username)
        {
            InitializeComponent();

            _clientServerMiddleman = clientToServerMiddleman;
            clientToServerMiddleman.ConnectToChat(username);
            _username = username;

            var usersNames = clientToServerMiddleman.GetCurrentUsers()
                                                    .Select(x => new UserView { Name = x, Color = GetNextBrushFromColorCollection() })
                                                    .OrderBy(x => x.Name)
                                                    .ToList();
            usersNames.Where(x => x.Name == username).First().FontWeight = "Bold";

            ListBoxUsers.ItemsSource = usersNames.OrderBy(x => x.Name)
                                                 .OrderByDescending(x => x.Name == _username).ToList();

            new Thread(() => clientToServerMiddleman.GetNewMessagesAndCallbackOnSpecifiedDelegates(ReceiveIncomingChatMessage,
                                                                                                   ReceiveUserConnectedToChatNotification,
                                                                                                   ReceiveUserDisconnectedFromChatNotification))
                                                    .Start();
        }

        public void ReceiveIncomingChatMessage(ChatMessage message)
        {
            lock (_monitor)
            {
                Dispatcher.Invoke(() =>
                {
                    var username = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    username.Text = message.Username;
                    username.ApplyPropertyValue(TextElement.ForegroundProperty, (ListBoxUsers.ItemsSource as List<UserView>).Where(x => x.Name == message.Username).First().Color);

                    var date = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    date.Text = "  " + DateTime.Now.ToString("[HH:mm]") + ": ";
                    date.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Gray);

                    var content = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    content.Text = message.Content;
                    content.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.DimGray);

                    RichTextBoxMainChatWindow.AppendText(Environment.NewLine);
                    RichTextBoxMainChatWindow.ScrollToEnd();
                });
            }
        }

        public void ReceiveUserDisconnectedFromChatNotification(string username)
        {
            lock (_monitor)
            {
                Dispatcher.Invoke(() =>
                {
                    var usernameText = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    usernameText.Text = username;
                    usernameText.ApplyPropertyValue(TextElement.ForegroundProperty, (ListBoxUsers.ItemsSource as List<UserView>).Where(x => x.Name == username).First().Color);

                    var content = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    content.Text = " disconnected";
                    content.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.DimGray);

                    RichTextBoxMainChatWindow.AppendText(Environment.NewLine);
                    RichTextBoxMainChatWindow.ScrollToEnd();

                    (ListBoxUsers.ItemsSource as List<UserView>).RemoveAll(x => x.Name == username);
                    ListBoxUsers.Items.Refresh();
                });
            }
        }

        public void ReceiveUserConnectedToChatNotification(string username)
        {
            lock (_monitor)
            {
                Dispatcher.Invoke(() =>
                {
                    (ListBoxUsers.ItemsSource as List<UserView>)?.Add(new UserView { Name = username, Color = GetNextBrushFromColorCollection() });
                    ListBoxUsers.Items.Refresh();

                    var usernameText = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    usernameText.Text = username;
                    usernameText.ApplyPropertyValue(TextElement.ForegroundProperty, (ListBoxUsers.ItemsSource as List<UserView>).Where(x => x.Name == username).First().Color);

                    var content = new TextRange(RichTextBoxMainChatWindow.Document.ContentEnd, RichTextBoxMainChatWindow.Document.ContentEnd);
                    content.Text = " connected";
                    content.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.DimGray);

                    RichTextBoxMainChatWindow.AppendText(Environment.NewLine);
                    RichTextBoxMainChatWindow.ScrollToEnd();
                });
            }
        }

        private Brush GetNextBrushFromColorCollection()
        {
            _lastColorCollectionIndexUsed++;
            return _userColors[_lastColorCollectionIndexUsed % _userColors.Count];
        }

        private void ImgBugReport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new BugReportWindow(Left, Top, Width)
            {
                Owner = this
            }.Show();
        }

        private void ImgLogout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _clientServerMiddleman.DisconnectFromChatAndServer(_username);

            new LoginWindow().Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _clientServerMiddleman.DisconnectFromChatAndServer(_username);
        }

        private void TxtMessage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                var message = new ChatMessage { Content = TxtChatMessage.Text, Timestamp = DateTime.Now, Username = _username };

                ReceiveIncomingChatMessage(message);
                TxtChatMessage.Text = string.Empty;

                _clientServerMiddleman.SendNewChatMessage(message);
            }
        }
    }
}
