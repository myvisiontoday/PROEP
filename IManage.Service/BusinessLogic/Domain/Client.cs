using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace IManageService.BusinessLogic.Domain
{
    /// <summary>
    /// A class representing client information
    /// </summary>
    [Table("Clients")]
    [DataContract]
    public class Client
    {
        #region Properties
        /// <summary>
        /// Id of a client
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///User name of a client 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of a client
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Indicates whether the subscription of client is not expired or not
        /// false when subscription is not expired otherwise true
        /// </summary>
        [DataMember]
        public bool IsSubscriptionsExpired { get; set; }

        /// <summary>
        /// Clients subscriptions start date
        /// </summary>
        public DateTime SubscriptionsStartDate { get; set; }

        /// <summary>
        /// Clients subcriptins end date
        /// </summary>
        public DateTime SubscriptionsEndDate { get; set; }
        #endregion
    }
}
