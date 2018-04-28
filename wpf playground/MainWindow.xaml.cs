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

namespace wpf_playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Model> ThisList
        {
            get;
            set;
        }

        public MainWindow()
        {
            InitializeComponent();

            ThisList =  new List<Model> { new Model { Name = "Oscar", Age = 123 } };

            DtdGrd1.DataContext = this;

            for (int i = 0; i < DtdGrd1.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)DtdGrd1.ItemContainerGenerator
                                                           .ContainerFromIndex(i);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < DtdGrd1.Items.Count; i++)
            {
                try
                {

                    DataGridRow row = (DataGridRow)DtdGrd1.ItemContainerGenerator
                                                               .ContainerFromIndex(i);

                    if ((row.Item as Model).Name == "Alex")
                    {
                        row.Foreground = Brushes.Blue;
                    }

                    if ((row.Item as Model).Name == "Tobi")
                    {
                        row.Foreground = Brushes.Red;
                    }
                }
                catch
                {

                }
            }
        }
    }
}