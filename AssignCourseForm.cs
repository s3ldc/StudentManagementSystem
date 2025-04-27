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
    public partial class AssignCourseForm : Form
    {
        string connectionString = "server=localhost;user=root;password=tiger;database=StudentDB;";
        public AssignCourseForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AssignCourseForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadCourses();
        }

        private void LoadStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StudentID, Name FROM Students";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Items.Add(new ComboBoxItem(reader["Name"].ToString(), Convert.ToInt32(reader["StudentID"])));
                }
            }
        }

        private void LoadCourses()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CourseID, CourseCode, CourseName FROM Courses";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string displayText = reader["CourseCode"].ToString() + " - " + reader["CourseName"].ToString();
                    course.Items.Add(new ComboBoxItem(displayText, Convert.ToInt32(reader["CourseID"])));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (students.SelectedItem == null || course.SelectedItem == null)
            {
                MessageBox.Show("Please select both Student and Course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ComboBoxItem selectedStudent = (ComboBoxItem)students.SelectedItem;
            ComboBoxItem selectedCourse = (ComboBoxItem)course.SelectedItem;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO StudentCourses (StudentID, CourseID) VALUES (@StudentID, @CourseID)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", selectedStudent.Value);
                cmd.Parameters.AddWithValue("@CourseID", selectedCourse.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Course assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void students_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
