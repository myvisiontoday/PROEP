using IManage.Core.IManageEmployeeService;
using IManage.Core.Models;
using JobTitle = IManage.Core.IManageEmployeeService.JobTitle;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of StockUpdaterLogin View
    /// </summary>
    public class StockUpdaterLoginViewModel : NotificationSenderLoginViewModel
    {
        #region Base Class Overrides
        protected override void GetEmployeeWithGivenPinCodeCompleted(object sender, GetEmployeeWithGivenPinCodeCompletedEventArgs e)
        {
            EmployeeServiceClient.GetEmployeeWithGivenPinCodeCompleted -= GetEmployeeWithGivenPinCodeCompleted;
            if (e.Result != null)
            {
                if (e.Result.JobTitle == JobTitle.Chef)
                {
                    Message = Models.Message.LoggedIn;
                    ShowViewModel<PurchaseAndStockViewModel>(new EmployeeDetailParameter { Pincode = e.Result.PinCode, Id = e.Result.EmployeeId });
                }
                else
                {
                    Message = Models.Message.NotEnoughCerendital;
                }
            }
            else
            {
                Message = Models.Message.ErrorTryAgain;
            }
        }
        #endregion
    }
}
