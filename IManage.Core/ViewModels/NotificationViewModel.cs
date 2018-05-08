using IManage.Core.IManageEmployeeService;
using IManage.Core.IManageNotificationService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System;
using Notification = IManage.Core.IManageNotificationService.Notification;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of Notification View
    /// </summary>
    public class NotificationViewModel : BaseEmployeeViewModel
    {
        #region Private Data

        private readonly NotificationServiceClient _notificationServiceClient;

        private readonly EmployeeServiceClient _employeeServiceClient;
        #region Bindings

        private MvxObservableCollection<string> _notificationMessages;

        private string _customNotificationMessage;

        private string _selectedNotificationMessage;

        private Message? _message;

        #endregion

        #region Commands

        private MvxCommand _sendButtonClickCommand;
        private MvxCommand _cancelButtonClickCommand;
        #endregion

        #endregion

        #region Properties

        public EmployeeDetailParameter EmployeeDetailParameter { get; set; }
        #region Bindings

        public MvxObservableCollection<string> NotificationsMessages
        {
            get => _notificationMessages;
            set
            {
                _notificationMessages = value;
                RaisePropertyChanged(() => NotificationsMessages);
            }
        }

        public string CustomNotificationMessage
        {
            get => _customNotificationMessage;
            set
            {
                _customNotificationMessage = value;
                RaisePropertyChanged(() => CustomNotificationMessage);
            }
        }

        public string SelectedNotificationMessage
        {
            get => _selectedNotificationMessage;
            set
            {
                _selectedNotificationMessage = value;
                RaisePropertyChanged(() => SelectedNotificationMessage);
            }
        }

        public Message? Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }
        #endregion

        #region Commands

        public MvxCommand SendButtonClickCommand
        {
            get
            {
                _sendButtonClickCommand = _sendButtonClickCommand ?? new MvxCommand(WhenSendButtonClicked);
                return _sendButtonClickCommand;

            }
        }

        public MvxCommand CancelButtonClickCommand
        {
            get
            {
                _cancelButtonClickCommand = _cancelButtonClickCommand ?? new MvxCommand(WhenCancelButtonClick);
                return _cancelButtonClickCommand;
            }
        }
        #endregion

        #endregion

        #region Constructor

        public NotificationViewModel()
        {
            NotificationsMessages = new MvxObservableCollection<string>
            {
                "Dish washer is not working",
                "Cannot find fire exhauster",
                "Exhause fan is not working",
                "Emergency exit light bulb is not working"
            };
            Message = null;
            _notificationServiceClient = new NotificationServiceClient();
            _employeeServiceClient = new EmployeeServiceClient();

        }
        #endregion

        #region Public Methods

        public void Init(EmployeeDetailParameter employeeDetailParameter)
        {
            if (employeeDetailParameter != null)
            {
                EmployeeDetailParameter = employeeDetailParameter;
            }
        }
        #endregion

        #region Private Methods

        private void SendNotification()
        {
            _notificationServiceClient.SendNotificationCompleted += SendNotificationCompleted;
            Notification notification = new Notification
            {
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                IsResolved = false,

                EmployeePinCode = EmployeeDetailParameter.Pincode,
                Message = CustomNotificationMessage
            };

            _notificationServiceClient.SendNotificationAsync(notification);
        }

        #region Callback Method for button click

        public void WhenSendButtonClicked()
        {
            if (!string.IsNullOrEmpty(CustomNotificationMessage) &&
                !NotificationsMessages.Contains(CustomNotificationMessage) &&
                (_notificationServiceClient != null) && (EmployeeDetailParameter != null))
            {
                NotificationsMessages.Add(CustomNotificationMessage);
                SendNotification();
            }
            else if (!string.IsNullOrEmpty(SelectedNotificationMessage) &&
                     (_notificationServiceClient != null) && (EmployeeDetailParameter != null))
            {
                SendNotification();


            }
        }

        private void SendNotificationCompleted(object sender, SendNotificationCompletedEventArgs e)
        {
            _notificationServiceClient.SendNotificationCompleted -= SendNotificationCompleted;
            if (e.Result)
            {
                Message = Models.Message.NotificationSent;
            }
            else
            {
                Message = Models.Message.UnableToSendNotification;
            }
        }

        private void WhenCancelButtonClick()
        {
            ShowViewModel<NotificationSenderLoginViewModel>();
        }
        #endregion
        #endregion
    }
}
