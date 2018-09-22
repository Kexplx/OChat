using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Input;

namespace OChat.ClientUI1
{
    public partial class BugReportWindow
    {
        public BugReportWindow(double loginWindowLeftMargin, double loginWindowTopMargin, double loginWindowWidth)
        {
            InitializeComponent();
            LblVersion.Content = System.Configuration.ConfigurationManager.AppSettings["version"];

            //opens this window to the right of it's parent
            Left = loginWindowLeftMargin + loginWindowWidth - 10;
            Top = loginWindowTopMargin;
        }

        private void imgSend_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var worker = new BackgroundWorker { WorkerReportsProgress = true };

            worker.DoWork += (x, y) =>
            {
                (x as BackgroundWorker)?.ReportProgress(0);
                var client = new SmtpClient
                {
                    Port = 25,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("addonmaster404@gmail.com", "fpo120**.sad21ioiosa")
                };

                var mail = new MailMessage("addonmaster404@gmail.com", "oscar.rosner@web.de")
                {
                    Subject = "OChat: Bug Report",
                    Body = y.Argument as string ?? throw new InvalidOperationException()
                };

                client.Send(mail);
            };

            worker.ProgressChanged += (x, y) => SpinnerCog1.Visibility = Visibility.Visible;
            worker.RunWorkerCompleted += (x, y) =>
            {
                SpinnerCog1.Visibility = Visibility.Collapsed;
                TxtBugReportMessage.Text = string.Empty;
                Keyboard.ClearFocus();
            };

            worker.RunWorkerAsync(TxtBugReportMessage.Text);
        }
        #region UI
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    Keyboard.ClearFocus();
                    DragMove();
                }
            }
            catch
            {
                // ignored
            }
        }
        #endregion
    }
}
