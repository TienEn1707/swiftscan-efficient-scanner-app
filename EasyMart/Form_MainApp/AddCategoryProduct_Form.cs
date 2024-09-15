using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EasyMart.Form_MainApp
{
    public partial class AddCategoryProduct_Form : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");

        public AddCategoryProduct_Form()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                con.Open();
                string Query = "SELECT ID, Product_Category, Create_At, Update_At FROM Product_Category_Table";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["Product_Category"].HeaderText = "Product Category";
                dataGridView1.Columns["Create_At"].HeaderText = "Create At";
                dataGridView1.Columns["Update_At"].HeaderText = "Update At";

                dataGridView1.Columns["ID"].Visible = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Load Data: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddCategoryProduct_Form_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbProductCat.Text == "")
                {
                    MessageBox.Show("Please fill in the Product Category Name first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();

                // Periksa apakah Nama Kategori Product sudah digunakan
                SqlCommand checkCategory = new SqlCommand("SELECT COUNT(*) FROM Product_Category_Table WHERE Product_Category = @Product_Category", con);
                checkCategory.Parameters.AddWithValue("@Product_Category", tbProductCat.Text);

                int existingCategory = (int)checkCategory.ExecuteScalar();
                if (existingCategory > 0)
                {
                    MessageBox.Show("Product Category has been used, please use another Product Category!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string Query = "INSERT INTO Product_Category_Table (ID, Product_Category, Create_At, Update_At) VALUES (@ID, @Product_Category, @Create_At, @Update_At)";
                SqlCommand cmd = new SqlCommand(Query, con);

                // Code untuk membuat ID 
                string Query_ID = "SELECT MAX(ID) FROM Product_Category_Table";
                SqlCommand cmd_ID = new SqlCommand(Query_ID, con);
                object Eksekusi_ID = cmd_ID.ExecuteScalar();
                int Make_ID = (Eksekusi_ID == DBNull.Value) ? 0 : Convert.ToInt32(Eksekusi_ID);
                int Category_ID = Make_ID + 1;

                cmd.Parameters.AddWithValue("@ID", Category_ID);
                cmd.Parameters.AddWithValue("@Product_Category", tbProductCat.Text);

                // Code untuk membuat Time Stamp
                DateTime CreateAt = DateTime.Now;
                cmd.Parameters.AddWithValue("@Create_At", CreateAt);
                cmd.Parameters.AddWithValue("@Update_At", CreateAt);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Category created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbProductCat.Clear();
                lbCreateAt.Text = "-";
                lbUpdateAt.Text = "-";
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Create Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                tbProductCat.Text = selectedRow.Cells["Product_Category"].Value.ToString();
                lbCreateAt.Text = selectedRow.Cells["Create_At"].Value.ToString();
                lbUpdateAt.Text = selectedRow.Cells["Update_At"].Value.ToString();
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbProductCat.Clear();
            lbCreateAt.Text = "-";
            lbUpdateAt.Text = "-";
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbProductCat.Text == "")
                {
                    MessageBox.Show("Select the Product Category you want to update first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Periksa apakah Nama Kategori Product sudah digunakan
                SqlCommand checkCategory = new SqlCommand("SELECT COUNT(*) FROM Product_Category_Table WHERE Product_Category = @Product_Category AND ID != @ID", con);
                checkCategory.Parameters.AddWithValue("@Product_Category", tbProductCat.Text);
                checkCategory.Parameters.AddWithValue("@ID", selectedID);

                int existingCategory = (int)checkCategory.ExecuteScalar();
                if (existingCategory > 0)
                {
                    MessageBox.Show("Product Category Name has been used, please use another Product Category Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Perbarui Product Category 
                string updateCategoryQuery = "UPDATE Product_Category_Table SET Product_Category = @Product_Category, Update_At = @Update_At WHERE ID = @ID";
                SqlCommand updateCategoryCmd = new SqlCommand(updateCategoryQuery, con);
                updateCategoryCmd.Parameters.AddWithValue("@ID", selectedID);
                updateCategoryCmd.Parameters.AddWithValue("@Product_Category", tbProductCat.Text);

                // Code untuk membuat Time Stamp
                DateTime UpdateAt = DateTime.Now;
                updateCategoryCmd.Parameters.AddWithValue("@Update_At", UpdateAt);
                updateCategoryCmd.ExecuteNonQuery();  // Untuk Update Category Product

                // Perbarui kategori untuk semua produk terkait
                string updateProductsQuery = "UPDATE Product_Table SET Category = @NewCategory WHERE Category = @OldCategory";
                SqlCommand updateProductsCmd = new SqlCommand(updateProductsQuery, con);
                updateProductsCmd.Parameters.AddWithValue("@NewCategory", selectedID);
                updateProductsCmd.Parameters.AddWithValue("@OldCategory", selectedID);
                updateProductsCmd.ExecuteNonQuery();  // Untuk Update Product

                MessageBox.Show("Product Category and related products updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbProductCat.Clear();
                lbCreateAt.Text = "-";
                lbUpdateAt.Text = "-";
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Update Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select the Product Category you want to delete first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Product Category?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Hapus data Product (jadi ketika Kategori Product di hapus, maka Product berdasarkan Kategori Product tersebut akan ikut terhapus)
                    string deleteProductsQuery = "DELETE FROM Product_Table WHERE Category = @Category";
                    SqlCommand deleteProductsCmd = new SqlCommand(deleteProductsQuery, con);
                    deleteProductsCmd.Parameters.AddWithValue("@Category", selectedID);
                    deleteProductsCmd.ExecuteNonQuery();

                    string Query = "DELETE FROM Product_Category_Table WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product Category successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    tbProductCat.Clear();
                    lbCreateAt.Text = "-";
                    lbUpdateAt.Text = "-";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Delete Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // Variabel untuk menyimpan nilai dari TextBox dan menghapus spasi di awal dan di akhir (text kosong)
            string searchTerm = tbSearch.Text.Trim();

            if (searchTerm != "")
            {
                try
                {
                    con.Open();
                    string Query = "SELECT ID, Product_Category, Create_At, Update_At FROM Product_Category_Table WHERE Product_Category LIKE @searchTerm";
                    SqlCommand cmd = new SqlCommand(Query, con);

                    // Menambahkan wildcard '%' untuk mencari ID yang mengandung teks pencarian
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error Searching Data: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                LoadData();
            }
        }
    }
}