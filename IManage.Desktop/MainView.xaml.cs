using MvvmCross.Wpf.Views.Presenters.Attributes;

namespace IManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [MvxWindowPresentation(Identifier = nameof(MainView), Modal = false)]
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
