using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KiemTra
{
    public partial class Form1 : Form
    {
        private List<Product> products;
        private List<Product> shoppingCart;

        public Form1()
        {
            InitializeComponent();
            InitializeProducts();
            shoppingCart = new List<Product>();
            LoadProducts();
        }

        private void InitializeProducts()
        {
            // Khởi tạo danh sách sản phẩm
            products = new List<Product>
            {
                new Product("image1.png", "Tủ Lạnh", 10000,1),
                new Product("image2.png", "Ti Vi", 20000,2),
                new Product("image3.png", "Máy Tính ", 15000,3)
            };
        }

        private void LoadProducts()
        {
            dataGridView1.Rows.Clear();
            foreach (var product in products)
            {
                dataGridView1.Rows.Add(product.Image, product.Name, product.Price,product.Quantity);
            }
        }


        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var productName = selectedRow.Cells[1].Value.ToString();
                var quantity = (int)selectedRow.Cells[3].Value;
                var existingProduct = shoppingCart.Find(p => p.Name == productName);

                if (existingProduct != null)
                {
                    existingProduct.Quantity += quantity;
                }
                else
                {
                    var product = new Product(
                        selectedRow.Cells[0].Value.ToString(),
                        productName,
                        Convert.ToDecimal(selectedRow.Cells[2].Value),
                        quantity
                    );
                    shoppingCart.Add(product);
                }
                UpdateCart();
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedProductName = listBox1.SelectedItem.ToString().Split('-')[0].Trim();
                shoppingCart.RemoveAll(p => p.Name == selectedProductName);
                UpdateCart();
            }
        }

        private void UpdateCart()
        {
            listBox1.Items.Clear();
            foreach (var product in shoppingCart)
            {
                listBox1.Items.Add($"{product.Name} - {product.Price:C} x {product.Quantity} = {(product.Price * product.Quantity):C}");
            }
            label2.Text = $"Tổng: {GetTotalPrice():C}";
        }

        private decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var product in shoppingCart)
            {
                total += product.Price * product.Quantity;
            }
            return total;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                MessageBox.Show("Xác nhận đơn hàng thành công!");
                shoppingCart.Clear();
                UpdateCart();
            }
            else
            {
                MessageBox.Show("Giỏ hàng trống!");
            }
        }
    }

    public class Product
    {
        public string Image { get; set; }
        public string Name { get; set; }   
        public decimal Price { get; set; } 
        public int Quantity { get; set; }   

        public Product(string image, string name, decimal price, int quantity)
        {
            Image = image;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
