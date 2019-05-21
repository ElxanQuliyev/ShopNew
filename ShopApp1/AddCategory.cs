using ShopApp1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp1
{
    public partial class AddCategory : Form
    {
        ShoppingEntities db = new ShoppingEntities();
        public AddCategory()
        {
            InitializeComponent();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            FillDgcategories();
        }
        private void FillDgcategories()
        {
            dtgCategory.DataSource = db.Category.Select(c => new
            {
                Category=c.Name
            }).ToList();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            if (categoryName!=string.Empty)
            {
                if (db.Category.Any(c => c.Name == categoryName)){
                    lblError.Text = "Admin yeke oglansan .Bu adda category var.Agresivik!!!";
                    lblError.Visible = true;
                }
                else
                {
                    db.Category.Add(new Category
                    {
                        Name = categoryName
                    });
                    db.SaveChanges();
                    MessageBox.Show("Category ugurla əlavə olundu");
                    FillDgcategories();
                }
            }
            else
            {
                lblError.Text = "Boş gonderme brat!";
                lblError.Visible = true;
            }
        }
    }
}
