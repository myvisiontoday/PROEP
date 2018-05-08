using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Windows;

namespace IManage
{
    /// <summary>
    /// Class responsible for starting an app
    /// </summary>
    public partial class App : Application
    {
        #region Private Data
        /// <summary>
        /// Indicates completion of the setup
        /// </summary>
        private bool _setupComplete;
        #endregion

        #region Private Methods
        /// <summary>
        /// Loads MVX resources from the assembly
        /// </summary>
        private void LoadMvxAssemblyResources()
        {
            for (var i = 0; ; i++)
            {
                var key = "MvxAssemblyImport" + i;
                var data = TryFindResource(key);
                if (data == null)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Performs setup
        /// </summary>
        private void DoSetup()
        {
            LoadMvxAssemblyResources();

            var setup = new Setup(Dispatcher, MainWindow);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _setupComplete = true;
        }
        #endregion

        #region Application Class Overrides
        protected override void OnActivated(EventArgs e)
        {
            if (!_setupComplete)
            {
                DoSetup();
            }

            base.OnActivated(e);
        }

        #endregion
    }
}