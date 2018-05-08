using System.Text.RegularExpressions;
using System.Windows.Input;

namespace IManage.Views
{
    /// <summary>
    /// Interaction logic for PurchaseAndStockView.xaml
    /// </summary>
    public partial class PurchaseAndStockView
    {
        public PurchaseAndStockView()
        {
            InitializeComponent();
        }

        private void NumberValidationTextbox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
