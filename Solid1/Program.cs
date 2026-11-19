using System.Collections.Generic;

namespace Solid1
{
    class Item
    {
    }

    // Робота зі складом і вартістю замовлення.
    class Order
    {
        private List<Item> itemList = new List<Item>();

        internal List<Item> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }

        public void CalculateTotalSum() { /* ... */ }
        public void GetItems() { /* ... */ }
        public void GetItemCount() { /* ... */ }
        public void AddItem(Item item) { /* ... */ }
        public void DeleteItem(Item item) { /* ... */ }
    }

    // Представлення замовлення.
    class OrderViewer
    {
        public void PrintOrder(Order order) { /* ... */ }

        public void ShowOrder(Order order) { /* ... */ }
    }

    // Робота зі сховищем даних.
    class OrderRepository
    {
        public void Load(Order order) { /* ... */ }

        public void Save(Order order) { /* ... */ }

        public void Update(Order order) { /* ... */ }

        public void Delete(Order order) { /* ... */ }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}