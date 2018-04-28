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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> myList;
        public MainWindow()
        {
            InitializeComponent();
            Dtdgrd.DataContext = this;

            myList = new List<User>
            {
                new User{Username = "Oscar", Color = Brushes.Red},
                new User{Username = "Tobi", Color = Brushes.Blue}
            };

            Dtdgrd.ItemsSource = myList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myList.Add(new User { Username = "Hans", Color = Brushes.Red });

            for (int i = 0; i < Dtdgrd.Items.Count; i++)
            {
                var row = (DataGridRow)Dtdgrd.ItemContainerGenerator.ContainerFromIndex(i);
            }

            Dtdgrd.Items.Refresh();
        }
    }
}
