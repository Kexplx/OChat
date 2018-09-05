using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OChatNew.Client
{
    /// <summary>
    /// Interaction logic for BugReportWindow.xaml
    /// </summary>
    public partial class BugReportWindow : Window
    {
        public BugReportWindow()
        {
            InitializeComponent();
            LblVersion.Content = System.Configuration.ConfigurationManager.AppSettings["version"];
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
    }
}
