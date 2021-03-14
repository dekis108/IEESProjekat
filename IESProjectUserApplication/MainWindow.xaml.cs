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
        private TestGda tgda;

        public MainWindow()
        {
            IntializeTestGda();
            InitializeComponent();
        }

        private void IntializeTestGda()
        {
            tgda = new TestGda();
        }

        private void comboBoxModelSelect_Initialized(object sender, EventArgs e)
        {
            List<ModelCode> modelCodes = new List<ModelCode>();
         
            foreach(DMSType type in Enum.GetValues(typeof(DMSType))) //depends on DMSType and ModelCode having the same string name
            {
                if (type == DMSType.MASK_TYPE)
                {
                    continue;
                }
                modelCodes.Add((ModelCode)Enum.Parse(typeof(ModelCode), type.ToString()));
            }

            comboBoxModelSelect.ItemsSource = modelCodes;
            comboBoxModelSelect.SelectedItem = comboBoxModelSelect.Items[0];
        }

        private void btnExtentValues_Click(object sender, RoutedEventArgs e)
        {
            txtBlockOutput.Text = tgda.GetExtentValues((ModelCode)comboBoxModelSelect.SelectedItem);
        }

        private void comboBoxIdSelect_Initialized(object sender, EventArgs e)
        {
            comboBoxIdSelect.ItemsSource = tgda.TestGetExtentValuesAllTypes();
            comboBoxIdSelect.SelectedItem = comboBoxIdSelect.Items[0];
        }

        private void btnGetValues_Click(object sender, RoutedEventArgs e)
        {
            txtBlockOutput.Text = tgda.GetValues((long)comboBoxIdSelect.SelectedItem);
        }
    }
}
