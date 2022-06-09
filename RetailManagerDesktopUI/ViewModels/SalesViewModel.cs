﻿using Caliburn.Micro;
using System.ComponentModel;

namespace RetailManagerDesktopUI.ViewModels
{
    public class SalesViewModel: Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set 
            { 
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }
        public string SubTotal 
        {
            get
            {
                return "R0.00";
            } 
        }
        public string Vat 
        {
            get
            {
                return "R0.00";
            } 
        }
        public string Total 
        {
            get
            {
                return "R0.00";
            } 
        }
        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                //Make sure something is selected
                return output;
            }
        }
        public void AddToCart()
        {

        }
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
               //Make sure something is selected
                return output;
            }
        }
        public void RemoveFromCart()
        {

        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;
               //Make sure there is something in the Cart
                return output;
            }
        }
        public void Checkout()
        {

        }

    }
}