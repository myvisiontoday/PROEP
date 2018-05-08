using System;
using System.Runtime.Serialization;

namespace IManageService.BusinessLogic.Domain
{
    /// <summary>
    /// A class representing notifcation messages
    /// </summary>
    [DataContract]
    public class Notification
    {
        /// <summary>
        /// Gets and sets the notification id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets and sets the message to be sent
        /// </summary>
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// Gets and sets when notification is created
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets and sets date when notification is deleted
        /// </summary>
        [DataMember]
        public DateTime? DeletedDate { get; set; }
        /// <summary>
        /// Gets and sets delete status of the notification
        /// </summary>
        [DataMember]
        public bool IsResolved { get; set; }

        /// <summary>
        /// Gets and sets the employee entity
        /// </summary>
        [DataMember]
        public Employee Employee { get; set; }

        [DataMember]
        public string EmployeePinCode { get; set; }

        /// <summary>
        /// Gets and sets the employee id
        /// </summary>
        public int EmployeeId { get; set; }
    }
}
