using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static StudentManagementSystem.AssignCourseForm;

namespace StudentManagementSystem
{
    public partial class CalculateGPAForm : Form
    {
        public CalculateGPAForm()
        {
            InitializeComponent();
        }

        private void CalculateGPAForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StudentID, Name FROM Students";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbStudents.Items.Add(new ComboboxItem
                    {
                        Text = reader["Name"].ToString(),
                        Value = reader["StudentID"]
                    });
                }
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnCalculateGPA_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem is ComboboxItem selectedStudent)
            {
                int studentId = Convert.ToInt32(selectedStudent.Value);

                string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AVG(MarksObtained) as GPA FROM Marks WHERE StudentID = @StudentID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        double gpa = Convert.ToDouble(result);
                        textBox1.Text = gpa.ToString("0.00"); // Show GPA rounded to 2 decimal places
                    }
                    else
                    {
                        textBox1.Text = "0.00"; // If no marks found
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student first.");
            }
        }
    }
}
