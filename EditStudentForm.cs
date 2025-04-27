using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class EditStudentForm : Form
    {
        private int studentId;
        public EditStudentForm(int id, string name, int age, string gender, string email, string phone)
        {
            InitializeComponent();
            studentId = id;

            txtName.Text = name;
            txtAge.Text = age.ToString();
            txtGender.Text = gender;
            txtCourse.Text = email;
            txtPhone.Text = phone;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);
            string gender = txtGender.Text;
            string email = txtCourse.Text;
            string phone = txtPhone.Text;

            try
            {
                string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Students SET Name=@Name, Age=@Age, Gender=@Gender, Email=@Email, Phone=@Phone WHERE StudentID=@StudentID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@StudentID", studentId);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Student updated successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
