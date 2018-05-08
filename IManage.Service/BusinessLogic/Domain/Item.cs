using System;
using System.Runtime.Serialization;

namespace IManageService.BusinessLogic.Domain
{
    /// <summary>
    /// A class representing Item information
    /// </summary>
    [DataContract]
    public class Item
    {
        #region Properties
        /// <summary>
        /// Gets and sets the item id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the item name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the item quantity
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets and sets the item price
        /// </summary>
        [DataMember]
        public double Price { get; set; }

        /// <summary>
        /// Gets and sets the item added date 
        /// </summary>
        [DataMember]
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Gets and sets the item deleted date
        /// </summary>
        [DataMember]
        public DateTime? DeletedDate { get; set; }

        [DataMember]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets and sets the item deleted status
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor which doesnot initiazes members
        /// </summary>
        public Item()
        {

        }
        /// <summary>
        /// Initializes the members
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="quantity">Item quantity</param>
        /// <param name="price">Item price</param>
        public Item(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
        #endregion
    }
}
