using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_AdoNet_Project
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T9KCH5P;Initial Catalog=DbIstabulAkademi;Integrated Security=True;");


        private void ProductList()
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from TblProduct", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;


            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
          

            ProductList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command =new SqlCommand("insert into TblProduct (ProductName, ProductStock, PurchasePrice,Sale,CategoryID,Status1) values(@p1,@p2,@p3,@p4,@p5,@status1)",connection);

            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            command.Parameters.AddWithValue("@p2", txtStock.Text);
            command.Parameters.AddWithValue("@p3", txtPurPrice.Text);
            command.Parameters.AddWithValue("@p4",  txtPrice.Text);
            command.Parameters.AddWithValue("@p5", cbCategory.SelectedValue);
            if (rbActive.Checked == true)
            {
                command.Parameters.AddWithValue("@status1", "True");
            }
            if (rbPasivve.Checked == true)
            {
                command.Parameters.AddWithValue("@status1", 0);
            }
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı bir şekilde sisteme kaydedildi");
            connection.Close();
            ProductList();

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblCategory", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";
            cbCategory.DataSource = dataTable;
           

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From TblProduct Where ProductID=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtProductID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün sistemden başarılı bir şekilde silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();
             ProductList();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update TblProduct Set ProductName=@p1,ProductStock=@p2,PurchasePrice=@p3,Sale=@p4,CategoryID=@p5,Status1=@p6 where ProductId=@p7", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            command.Parameters.AddWithValue("@p2", txtStock.Text);
            command.Parameters.AddWithValue("@p3", txtPurPrice.Text);
            command.Parameters.AddWithValue("@p4", txtPrice.Text);
            command.Parameters.AddWithValue("@p5", cbCategory.SelectedValue);
            if (rbActive.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "True");
            }
            if (rbPasivve.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "False");
            }
            command.Parameters.AddWithValue("@p7", txtProductID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı bir şekilde sistemde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            connection.Close();
            ProductList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from TblProduct where ProductName=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;


            connection.Close();
        }

        private void btnSearchDown_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from TblProduct where ProductStock<@p1", connection);
            command.Parameters.AddWithValue("@p1", txtStock.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;


            connection.Close();
        }

        private void btnSearchUp_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from TblProduct where ProductStock>@p1", connection);
            command.Parameters.AddWithValue("@p1", txtStock.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;


            connection.Close();
        }
    }
}
