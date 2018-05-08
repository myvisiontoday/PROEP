using IManage.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace IManage.Core
{
    /// <summary>
    /// A class which is responsible for deciding ViewModel that should be presented  
    /// </summary>
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        #region Implementation of IMvxAppStart
        public void Start(object hint = null)
        {
            ShowViewModel<LogInViewModel>();
        }
        #endregion
    }
}
