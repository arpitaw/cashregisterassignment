using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Item

    {

        private int _productID;

        private string _productName;

        private int _quantity;

        private decimal _unitPrice;

        public Item()
        {
        }

        public Item(int productID, string productName, int quantity, decimal unitPrice)
        {
            ProductID = productID;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int ProductID

        {

            get { return _productID; }

            set { _productID = value; }

        }


        public string ProductName

        {

            get { return _productName; }

            set { _productName = value; }

        }


        public int Quantity

        {

            get { return _quantity; }

            set { _quantity = value; }

        }


        public decimal UnitPrice

        {

            get { return _unitPrice; }

            set { _unitPrice = value; }

        }
        public decimal ItemTotal

        {

            get { return _quantity * _unitPrice; }

        }
        public override int GetHashCode()

        {

            return _productID.GetHashCode();

        }
    }

    public abstract class ShoppingCart : IEnumerable

    {

        public abstract decimal SubTotal { get; }

        public abstract Item CreateItem();

        public abstract void AddItem(Item item);

        public abstract void DeleteItem(Item item);

        public abstract void UpdateItem(Item item);

        public abstract IEnumerator GetEnumerator();

    }

    public class ArrayListCart : ShoppingCart

    {

        private ArrayList _items;

        public override decimal SubTotal

        {

            get { return GetSubTotal(); }

        }


        public ArrayListCart()

        {

            _items = new ArrayList();

        }


        #region Public Methods


        public override Item CreateItem()

        {

            return new Item();

        }


        public override void AddItem(Item item)

        {

            int index = _items.IndexOf(item);


            if (index >= 0)

                UpdateItem(item);

            else

                _items.Add(new Item(item.ProductID, item.ProductName,

                    item.Quantity, item.UnitPrice));

        }


        

        

     


        public override IEnumerator GetEnumerator()

        {

            return (_items as IEnumerable).GetEnumerator();

        }


       


        


        private decimal GetSubTotal()

        {

            decimal subTotal = 0m;


            foreach (Item item in _items)

                subTotal += item.ItemTotal;


            return subTotal;

        }

        public override void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public override void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class ShoppingCartFactory

    {

        private ShoppingCartFactory() { }

        public static ShoppingCart CreateShoppingCart()

        {

            return new ArrayListCart();

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = ShoppingCartFactory.CreateShoppingCart();

            

            Item apples = cart.CreateItem();

            apples.ProductID = 1;

            apples.ProductName = "Apples";

            apples.Quantity = 5;

            apples.UnitPrice = 1m;


            cart.AddItem(apples);


            


            // Update Existing Item in Cart.

            Item moreApples = cart.CreateItem();

            moreApples.ProductID = 1;

            moreApples.Quantity = 10;

            moreApples.UnitPrice = 5m;


            cart.UpdateItem(moreApples);


            


            // Add New Item in Cart

            // that already exists in cart.

            // It should update quantity.

            Item newApples = cart.CreateItem();

            newApples.ProductID = 1;

            newApples.ProductName = "Apples";

            newApples.Quantity = 5;

            newApples.UnitPrice = 1m;


            cart.AddItem(newApples);


            


            // Add New Item in Cart

            Item bananas = cart.CreateItem();

            bananas.ProductID = 2;

            bananas.ProductName = "Banana";

            bananas.Quantity = 3;

            bananas.UnitPrice = 4m;


            cart.AddItem(bananas);


            


            

        }


        
    }
    }

#endregion