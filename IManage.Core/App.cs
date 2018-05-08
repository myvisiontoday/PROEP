using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace IManage.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        #region Constructor
        /// <summary>
        /// Does registration of business logics, services, models and ViewModel with MVVMCross framework
        /// </summary>
        public App()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Mvx.RegisterSingleton<IMvxAppStart>(new AppStart());
        }
        #endregion
    }
}
