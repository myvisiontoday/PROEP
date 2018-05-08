using MvvmCross.Binding.Wpf;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Wpf.Platform;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IManage
{
    public class Setup
        : MvxWpfSetup
    {
        #region Constructor
        public Setup(Dispatcher uiThreadDispatcher, ContentControl root)
            : base(uiThreadDispatcher, root)
        {
        }
        #endregion

        #region MvxWpfSetup class overrides
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            var builder = new MvxWindowsBindingBuilder();
            builder.DoRegistration();
        }

        #endregion
    }
}
