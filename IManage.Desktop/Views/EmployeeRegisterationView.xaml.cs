using System.Text.RegularExpressions;
using System.Windows.Input;

namespace IManage.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class EmployeeRegisterationView
    {
        public EmployeeRegisterationView()
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
