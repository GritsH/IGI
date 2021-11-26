using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953505_Grits.Entities;

namespace WEB_953505_Grits.Models
{
    public class CartItem
    {
        public Bouquet Bouquet { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        virtual public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        virtual public void AddToCart(Bouquet bouquet)
        {
            if (Items.ContainsKey(bouquet.BouquetId))
            {
                Items[bouquet.BouquetId].Quantity++;
            }
            else
            {
                Items.Add(bouquet.BouquetId, new CartItem
                {
                    Bouquet = bouquet,
                    Quantity = 1
                });
            }
        }
        virtual public void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        virtual public void ClearAll()
        {
            Items.Clear();
        }
    }
}
