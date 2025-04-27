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

namespace StudentManagementSystem
{
    public partial class EnterMarksForm : Form
    {
        public EnterMarksForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EnterMarksForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT StudentID, Name FROM Students";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<int, string> students = new Dictionary<int, string>();
                while (reader.Read())
                {
                    students.Add(reader.GetInt32("StudentID"), reader.GetString("Name"));
                }

                comboBox1.DataSource = new BindingSource(students, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int studentId = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            int courseId = ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key;
            float marks;

            if (!float.TryParse(textBox1.Text, out marks))
            {
                MessageBox.Show("Please enter valid marks.");
                return;
            }

            string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Marks (StudentID, CourseID, MarksObtained) VALUES (@StudentID, @CourseID, @MarksObtained)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@MarksObtained", marks);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Marks saved successfully!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                        int selectedStudentId = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;

            string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT c.CourseID, c.CourseName
            FROM Courses c
            INNER JOIN StudentCourses sc ON c.CourseID = sc.CourseID
            WHERE sc.StudentID = @StudentID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", selectedStudentId);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<int, string> courses = new Dictionary<int, string>();
                while (reader.Read())
                {
                    courses.Add(reader.GetInt32("CourseID"), reader.GetString("CourseName"));
                }

                comboBox2.DataSource = new BindingSource(courses, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
            }
        }
    }
}
