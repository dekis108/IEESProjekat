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
                                                                     //mozda iskoristi GetModelCodeFromType
            {
                if (type == DMSType.MASK_TYPE)
                {
                    continue;
                }
                modelCodes.Add((ModelCode)Enum.Parse(typeof(ModelCode), type.ToString()));
            }

            comboBoxModelSelect.ItemsSource = modelCodes;
        }

        private void btnExtentValues_Click(object sender, RoutedEventArgs e)
        {
            List<ModelCode> props = new List<ModelCode>();
            foreach(var prop in listBoxPropertiesExtent.SelectedItems)
            {
                props.Add((ModelCode)prop);
            }
            txtBlockOutput.Text = tgda.GetExtentValues((ModelCode)comboBoxModelSelect.SelectedItem, props);
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

        private void btnGetRelatedValues_Click(object sender, RoutedEventArgs e)
        {
            Association ass = new Association();

            ass.PropertyId = (ModelCode)comboBoxSelectAssType.SelectedItem;
            ass.Type = ModelCode.MUTUALCOUPLING;

            txtBlockOutput.Text = tgda.GetRelatedValues((long)comboBoxIdSelectRelated.SelectedItem, ass);
        }

        private void comboBoxIdSelectRelated_Initialized(object sender, EventArgs e) 
        {
            comboBoxIdSelectRelated.ItemsSource = tgda.TestGetExtentValuesAllTypes();
        }

        private void comboBoxIdSelectRelated_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var source = Enum.GetValues(typeof(ModelCode));

            ModelResourcesDesc modelResources = new ModelResourcesDesc();

            ModelCode modelCode = modelResources.GetModelCodeFromId((long)comboBoxIdSelectRelated.SelectedItem);

            string concreteType = ((long)modelCode).ToString("x");

            List<string> sourceString = new List<string>();
            foreach(ModelCode s in source)
            {

                string temp = s.ToString("x");
                if (tgda.ModelCodeStringCompareHelper(concreteType, temp))
                {
                    sourceString.Add(temp);
                }
                
            }

            List<ModelCode> codes = new List<ModelCode>();
            foreach(string s in sourceString)
            {
                codes.Add((ModelCode)long.Parse(s, System.Globalization.NumberStyles.HexNumber));
            }

            comboBoxSelectAssType.ItemsSource = codes;
            comboBoxSelectAssType.SelectedItem = comboBoxSelectAssType.Items[0];
        }

        private void comboBoxSelectAssType_Initialized(object sender, EventArgs e)
        {
            comboBoxIdSelectRelated.SelectionChanged += comboBoxIdSelectRelated_SelectionChanged;
            comboBoxIdSelectRelated.SelectedItem = comboBoxIdSelectRelated.Items[0];
        }

        private void listBoxPropertiesExtent_Initialized(object sender, EventArgs e)
        {
            comboBoxModelSelect.SelectedItem = comboBoxModelSelect.Items[0];
        }

        private void comboBoxModelSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelResourcesDesc modelResources = new ModelResourcesDesc();
            listBoxPropertiesExtent.ItemsSource = modelResources.GetAllPropertyIds((ModelCode)comboBoxModelSelect.SelectedItem);
            listBoxPropertiesExtent.UnselectAll();
        }
    }
}
