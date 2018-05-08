using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace IManageService.Services
{
    [ServiceBehavior]
    public class StockService : Contracts.IStockService
    {
        #region Public Constant Data
        public const string NameOfService = "Stock Service";
        public const string ServiceAddress = "http://localhost:8090/IManageService/Services/StockService/";
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets and sets the unit of work instance
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region IStockService Implementation

        public bool AddItem(string itemName, int quantity, double price)
        {
            bool onSuccess = false;
            if (UnitOfWork != null)
            {
                UnitOfWork.Items.Add(new Item(itemName, quantity, price) { AddedDate = DateTime.Now });
                if (UnitOfWork.SaveChanges() >= 1)
                {
                    onSuccess = true;
                }
            }
            return onSuccess;
        }

        public bool UpdateItem(Item itemToBeUpdated)
        {
            bool onSuccess = false;
            if (UnitOfWork != null)
            {
                Item item = UnitOfWork.Items.Get(itemToBeUpdated.Id);
                if (item != null)
                {
                    item.Name = itemToBeUpdated.Name;
                    item.Quantity = itemToBeUpdated.Quantity;
                    item.Price = itemToBeUpdated.Price;
                    item.UpdateDate = itemToBeUpdated.UpdateDate;
                    if (UnitOfWork.SaveChanges() >= 1)
                    {
                        onSuccess = true;
                    }
                }
            }
            return onSuccess;
        }

        public bool DeleteItem(Item itemToBeDelete)
        {
            bool onSuccess = false;
            Item tobeDelete = UnitOfWork?.Items.GetAll().FirstOrDefault(item => item.Id == itemToBeDelete.Id);

            if (tobeDelete != null)
            {

                UnitOfWork.Items.Remove(tobeDelete);
                if (UnitOfWork.SaveChanges() >= 1)
                {
                    onSuccess = true;
                }
            }
            return onSuccess;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return UnitOfWork?.Items.GetAll();
        }
        #endregion
    }
}
