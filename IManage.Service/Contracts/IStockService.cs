using IManageService.BusinessLogic.Domain;
using System.Collections.Generic;
using System.ServiceModel;


namespace IManageService.Contracts
{
    /// <summary>
    /// An interface for a class capable of providing stock services
    /// </summary>
    [ServiceContract(Name = "IStockService")]
    public interface IStockService
    {
        /// <summary>
        /// Add an item stock and adds it to the stock items
        /// </summary>
        /// <param name = "itemName" > Item name</param>
        /// <param name = "quantity" > Item quantity to add</param>
        /// <param name = "price" > Item price</param>
        /// <returns></returns>
        [OperationContract(Name = "AddItem")]
        bool AddItem(string itemName, int quantity, double price);

        /// <summary>
        /// Updates a particular stock item quantity using the item id to find that specific stock
        /// </summary>
        /// <param name="itemToBeUpdated">Item to be update</param>
        /// <returns></returns>
        [OperationContract(Name = "UpdateItem")]
        bool UpdateItem(Item itemToBeUpdated);

        /// <summary>
        /// Delete a particular stock item quantity using the item id to find that specific stock
        /// </summary>
        /// <param name="itemToBeDelete">Item to be delete</param>
        /// <returns></returns>
        [OperationContract(Name = "DeleteItem")]
        bool DeleteItem(Item itemToBeDelete);

        /// <summary>
        /// Gets all items
        /// </summary>
        /// <returns>All items</returns>
        [OperationContract(Name = "GetAllItems")]
        IEnumerable<Item> GetAllItems();
    }
}
