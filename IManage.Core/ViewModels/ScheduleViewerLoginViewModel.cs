using IManage.Core.IManageEmployeeService;

namespace IManage.Core.ViewModels
{
    public class ScheduleViewerLoginViewModel : NotificationSenderLoginViewModel
    {
        #region Base Class Overrides
        protected override void GetEmployeeWithGivenPinCodeCompleted(object sender, GetEmployeeWithGivenPinCodeCompletedEventArgs e)
        {
            EmployeeServiceClient.GetEmployeeWithGivenPinCodeCompleted -= GetEmployeeWithGivenPinCodeCompleted;
            if (e.Result != null)
            {
                Message = Models.Message.LoggedIn;
                ShowViewModel<ScheduleViewModel>();
            }
            else
            {
                Message = Models.Message.ErrorTryAgain;
            }
        }
        #endregion
    }
}
