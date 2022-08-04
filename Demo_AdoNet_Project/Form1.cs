using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Demo_AdoNet_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T9KCH5P;Initial Catalog=DbIstabulAkademi;Integrated Security=True;");

           connection.Open();

            SqlCommand command=new SqlCommand("select * from TblCategory",connection);

            SqlDataAdapter adapter=new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dtgCategory.DataSource = dataTable;


            connection.Close();






        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T9KCH5P;Initial Catalog=DbIstabulAkademi;Integrated Security=True;");

            connection.Open();

            SqlCommand command = new SqlCommand("insert into TblCategory (CategoryName) values(@p1)", connection);

            command.Parameters.AddWithValue("@p1", txtcategoryName.Text);

            command.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Kategori başarılı bir şekilde eklendi.");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T9KCH5P;Initial Catalog=DbIstabulAkademi;Integrated Security=True;");

            connection.Open();
            SqlCommand command = new SqlCommand("delete from TblCategory where CategoryID=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryId.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori silindi");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T9KCH5P;Initial Catalog=DbIstabulAkademi;Integrated Security=True;");

            connection.Open();

            SqlCommand command =new SqlCommand("update TblCategory set CategoryName=@p1 where CategoryID=@p2",connection);
            command.Parameters.AddWithValue("@p1", txtcategoryName.Text);
            command.Parameters.AddWithValue("@p2", txtCategoryId.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori Güncellendi.");



            connection.Close();
            MessageBox.Show("Kategori Güncellendi");
        }
    }
}
