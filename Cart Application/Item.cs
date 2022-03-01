using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Item
    {
        private string type;
        private string name;
        private string serialNumber;
        private double price;
        private int stockQuantity;
        private int cartQuantity;
        public string itemName { get; set; }
        public string itemType { get; set; }
        public string itemSerialNumber { get; set; }
        public int itemStockQuantity { get; set; }
        public int itemCartQuantity { get; set; }
        

        public Item(string type, string name, double price, int stockQuantity, string serialNumber)
        {
            this.type = type;
            this.name = name;
            this.serialNumber = serialNumber;
            this.price = price;
            this.cartQuantity = 0;
            this.stockQuantity = stockQuantity;
            itemType = type;
            itemName = name;
            itemCartQuantity = cartQuantity;
            itemStockQuantity = stockQuantity;
            itemSerialNumber = serialNumber;
        }

        public string displayInfo(string inventoryType)
        {
            int tempQuantity = (inventoryType == "cart") ? cartQuantity : stockQuantity;
            return "\nType: " + type + "\nName: " + name + "\nPrice: " + price + "\nSerial Number: "+ serialNumber +"\nQuantity: " + tempQuantity + "\n";
        }

        public void UpdateQuantity()
        {
            cartQuantity = itemCartQuantity;
            stockQuantity = itemStockQuantity;
        }

    }
}
