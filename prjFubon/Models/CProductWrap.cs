using prjFubon.Models.Entities;
using System.ComponentModel;

namespace prjFubon.Models
{
    public class CProductWrap
    {
        private Product _product;
        public CProductWrap() 
        {
         _product = new Product();
        }
        public Product product { get { return _product; } set { _product = value; } }
        [DisplayName("產品編號")]
        public int ProductId { get { return _product.ProductId; } set { this.product.ProductId = value; } }
        [DisplayName("產品名稱")]
        public string? ProductName 
        { 
            get { return _product.ProductName; } 
            
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    this.product.ProductName = value;
                else
                    this.product.ProductName = "尚無名稱";
            } 
        
        }
        [DisplayName("供應商編號")]
        public int? SupplierId { get { return _product.SupplierId; } set { this.product.SupplierId = value; } }
        [DisplayName("類別編號")]
        public int? CategoryId { get { return _product.CategoryId; } set { this.product.CategoryId = value; } }
        [DisplayName("每單位數量")]
        public string? QuantityPerUnit { get { return _product.QuantityPerUnit; } set { this.product.QuantityPerUnit = value; } }
        [DisplayName("每單位價格")]
        public decimal? UnitPrice { get { return _product.UnitPrice; } set { this.product.UnitPrice = value; } }
        [DisplayName("存貨")]
        public short? UnitsInStock { get { return _product.UnitsInStock; } set { this.product.UnitsInStock = value; } }

        public short? UnitsOnOrder { get { return _product.UnitsOnOrder; } set { this.product.UnitsOnOrder = value; } }

        public short? ReorderLevel { get { return _product.ReorderLevel; } set { this.product.ReorderLevel = value; } }
        [DisplayName("折扣")]
        public bool Discontinued { get { return _product.Discontinued; } set { this.product.Discontinued = value; } }

        public virtual Category? Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual Supplier? Supplier { get; set; }
    }
}
