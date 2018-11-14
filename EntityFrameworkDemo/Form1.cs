using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Bu eski hali
            //Product product = new Product();
            //product.Name = tbxName.Text;
            //product.StockAmount = Convert.ToInt32(tbxStockAmount.Text);
            //product.UnitPrice = Convert.ToDecimal(tbxStockAmount.Text);
            //_productDal.Add(product);

             //bu da yeni öğrendiğim
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),
                UnitPrice = Convert.ToDecimal(tbxStockAmount.Text)
            });

            MessageBox.Show("Added!");
            LoadProducts();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
            });

            MessageBox.Show("Updated!");
            LoadProducts();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value)
                //bunda sdece Id versende olur çünkü primarykey olayı işte
                //Name = tbxNameUpdate.Text,
                //StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
                //UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
            });

            MessageBox.Show("Deleted!");
            LoadProducts();
        }
    }
}
