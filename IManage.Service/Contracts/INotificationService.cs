using IManageService.BusinessLogic.Domain;
using System.Collections.Generic;
using System.ServiceModel;

namespace IManageService.Contracts
{
    /// <summary>
    /// An interface class for a class capable providing notification service
    /// </summary>
    [ServiceContract(Name = "INotificationService")]
    public interface INotificationService
    {
        [OperationContract]
        bool SendNotification(Notification notification);

        [OperationContract]
        IEnumerable<Notification> GetAllNotifications();
    }
}
