using MvvmCross.Wpf.Views.Presenters.Attributes;

namespace IManage.Views
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    [MvxContentPresentation(WindowIdentifier = nameof(MainView), StackNavigation = true)]
    public partial class EmployeeListView
    {
        public EmployeeListView()
        {
            InitializeComponent();
        }
    }
}
