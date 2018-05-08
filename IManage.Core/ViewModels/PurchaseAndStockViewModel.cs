using IManage.Core.IManageStockService1;
using IManage.Core.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of PurchaseAndStock View
    /// </summary>
    public class PurchaseAndStockViewModel : MvxViewModel
    {
        #region Private Data

        private readonly StockServiceClient _stockServiceClient;

        #region Bindings

        private Item _selectedItem;
        private MvxObservableCollection<Item> _itemsToOrder;
        private MvxObservableCollection<Item> _items;
        private string _itemSearchText;
        private Message? _message;
        private string _addOrUpdateButtonContent;
        private string _itemName;
        private double? _itemPrice;
        private int? _itemQuantity;
        #endregion

        #region Commands

        private MvxCommand _addButtonClickCommand;
        private MvxCommand _updateButtonClickCommand;
        private MvxCommand _deleteButtonClickCommand;
        private MvxCommand _logOutButtonClickCommand;

        #endregion

        #endregion

        #region Properties

        #region Bindings

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);

                if ((SelectedItem != null))
                {
                    ItemName = SelectedItem.Name;
                    ItemPrice = SelectedItem.Price;
                    ItemQuantity = SelectedItem.Quantity;
                    AddOrUpdateButtonContent = "Update Item";
                }
                else
                {
                    ResetItemFormValue();
                }
            }
        }

        public MvxObservableCollection<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        public MvxObservableCollection<Item> ItemsToOrder
        {
            get => _itemsToOrder;
            set
            {
                _itemsToOrder = value;
                RaisePropertyChanged(() => ItemsToOrder);
            }
        }
        public string ItemSearchText
        {
            get => _itemSearchText;
            set
            {
                _itemSearchText = value;
                RaisePropertyChanged(() => ItemSearchText);
                ItemsView?.Refresh();
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

        public string AddOrUpdateButtonContent
        {
            get => _addOrUpdateButtonContent;
            set
            {
                _addOrUpdateButtonContent = value;
                RaisePropertyChanged(() => AddOrUpdateButtonContent);
            }
        }

        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                RaisePropertyChanged(() => ItemName);
                AddOrUpdateButtonContent = CheckAtLeastOneFieldFormHasValue() ? "Update Item" : "Add Item";

            }
        }

        public double? ItemPrice
        {
            get => _itemPrice;
            set
            {
                _itemPrice = value;
                RaisePropertyChanged(() => ItemPrice);
                AddOrUpdateButtonContent = CheckAtLeastOneFieldFormHasValue() ? "Update Item" : "Add Item";
            }
        }

        public int? ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                RaisePropertyChanged(() => ItemQuantity);
                AddOrUpdateButtonContent = CheckAtLeastOneFieldFormHasValue() ? "Update Item" : "Add Item";
            }
        }
        public ICollectionView ItemsView => CollectionViewSource.GetDefaultView(Items);

        #endregion

        #region Commands

        public MvxCommand AddButtonClickCommand
        {
            get
            {
                _addButtonClickCommand =
                    _addButtonClickCommand ?? new MvxCommand(WhenAddButtonIsClicked);
                return _addButtonClickCommand;
            }
        }

        public MvxCommand UpdateButtonClickCommand
        {
            get
            {
                _updateButtonClickCommand =
                    _updateButtonClickCommand ?? new MvxCommand(WhenUpdateButtonIsClicked);
                return _updateButtonClickCommand;
            }
        }
        public MvxCommand DeleteButtonClickCommand
        {
            get
            {
                _deleteButtonClickCommand =
                    _deleteButtonClickCommand ?? new MvxCommand(WhenDeleteButtonIsClicked);
                return _deleteButtonClickCommand;
            }
        }

        public MvxCommand LogOutButtonClickCommand
        {
            get
            {
                _logOutButtonClickCommand =
                    _logOutButtonClickCommand ?? new MvxCommand(WhenLogOutButtonIsClicked);
                return _logOutButtonClickCommand;
            }
        }

        #endregion

        #endregion

        #region Constructor

        public PurchaseAndStockViewModel()
        {
            Items = new MvxObservableCollection<Item>();
            ItemsToOrder = new MvxObservableCollection<Item>();
            ItemsView.Filter = item => Filter(item as Item);
            _stockServiceClient = new StockServiceClient();
            SelectedItem = null;
            AddOrUpdateButtonContent = "Add Item";
            _stockServiceClient.GetAllItemsCompleted += GetAllItemsCompleted;
            _stockServiceClient.GetAllItemsAsync();
        }
        #endregion

        #region Private Methods
        private bool Filter(Item item)
        {
            return string.IsNullOrEmpty(ItemSearchText) ||
                   ItemSearchText.ToLower().StartsWith(item.Name.ToLower());
        }

        private bool CheckAtLeastOneFieldFormHasValue()
        {
            return string.IsNullOrEmpty(ItemName) && !ItemPrice.HasValue && !ItemQuantity.HasValue;
        }

        private void ResetItemFormValue()
        {
            ItemName = null;
            ItemPrice = null;
            ItemQuantity = null;
        }
        #region Callback Methods of button click

        private void WhenAddButtonIsClicked()
        {

            if (_stockServiceClient != null)
            {


                if (!string.IsNullOrEmpty(ItemName) && ItemPrice.HasValue && ItemQuantity.HasValue)
                {
                    _stockServiceClient.AddItemCompleted += AddItemCompleted;
                    Items.Add(new Item { Name = ItemName, Quantity = ItemQuantity.Value, Price = ItemPrice.Value });
                    _stockServiceClient.AddItemAsync(ItemName, ItemQuantity.Value, ItemPrice.Value);
                }
                else
                {
                    Message = Models.Message.NotAllFieldsComplete;
                }
            }
        }

        private void WhenUpdateButtonIsClicked()
        {
            if (_stockServiceClient != null)
            {
                if ((SelectedItem != null) && !string.IsNullOrEmpty(ItemName) && ItemPrice.HasValue &&
                    ItemQuantity.HasValue)
                {

                    if (SelectedItem.Name != ItemName)
                    {
                        SelectedItem.Name = ItemName;
                    }

                    if (SelectedItem.Price != ItemPrice.Value)
                    {
                        SelectedItem.Price = ItemPrice.Value;
                    }

                    if (SelectedItem.Quantity != ItemQuantity.Value)
                    {
                        SelectedItem.Quantity = ItemQuantity.Value;
                    }

                    SelectedItem.UpdateDate = DateTime.Now;

                    _stockServiceClient.UpdateItemCompleted += UpdateItemCompleted;
                    _stockServiceClient.UpdateItemAsync(SelectedItem);

                    Item foundItem = Items.SingleOrDefault(item => item.Id == SelectedItem.Id);
                    if (foundItem != null)
                    {
                        Items.Remove(foundItem);
                    }

                    Items.Add(SelectedItem);

                }
            }
        }
        private void WhenDeleteButtonIsClicked()
        {
            if ((SelectedItem != null) && (_stockServiceClient != null))
            {
                _stockServiceClient.DeleteItemCompleted += DeleteItemCompleted;
                _stockServiceClient.DeleteItemAsync(SelectedItem);
                Items.Remove(SelectedItem);
            }
        }

        private void WhenLogOutButtonIsClicked()
        {
            ShowViewModel<StockUpdaterLoginViewModel>();
        }
        #endregion

        #region Service callback methods
        private void AddItemCompleted(object sender, AddItemCompletedEventArgs e)
        {
            _stockServiceClient.AddItemCompleted -= AddItemCompleted;
            Message = e.Result ? Models.Message.ItemAdded : Models.Message.UnableToAddedItem;
        }
        private void UpdateItemCompleted(object sender, UpdateItemCompletedEventArgs e)
        {
            _stockServiceClient.UpdateItemCompleted -= UpdateItemCompleted;
            Message = e.Result ? Models.Message.ItemUpdated : Models.Message.UnableToUpdateItem;
        }
        private void DeleteItemCompleted(object sender, DeleteItemCompletedEventArgs e)
        {
            _stockServiceClient.DeleteItemCompleted -= DeleteItemCompleted;
            Message = e.Result ? Models.Message.ItemDeleted : Models.Message.UnableToDeleteItem;
        }
        private void GetAllItemsCompleted(object sender, GetAllItemsCompletedEventArgs e)
        {
            _stockServiceClient.GetAllItemsCompleted -= GetAllItemsCompleted;
            //  Items = new MvxObservableCollection<Item>();
            IEnumerable<Item> itemsToOrder = e.Result.Where(item => item.Quantity <= 1);

            foreach (Item item in itemsToOrder)
            {
                ItemsToOrder.Add(item);
            }


            foreach (Item item in e.Result)
            {
                Items.Add(item);
            }

        }
        #endregion

        #endregion
    }
}
