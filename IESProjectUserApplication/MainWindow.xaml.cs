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
using FTN.Common;
using FTN.ServiceContracts;

namespace IESProjectUserApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IntializeTestGda();
        }

        private void IntializeTestGda()
        {
            TestGda tgda = new TestGda();
            MessageBoxResult result = MessageBox.Show("Uspeh","Dobro",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
        }
    }
}
