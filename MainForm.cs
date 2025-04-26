using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //private void button6_Click_1(object sender, EventArgs e)
        //{
        //    UpdateStudentForm updateForm = new UpdateStudentForm();
        //    updateForm.ShowDialog();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentForm addForm = new AddStudentForm();
            addForm.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ViewStudentsForm viewForm = new ViewStudentsForm();
            viewForm.ShowDialog();
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    DeleteStudentForm deleteForm = new DeleteStudentForm();
        //    deleteForm.ShowDialog();
        //}

        private void button4_Click_1(object sender, EventArgs e)
        {
            AssignCourseForm assignForm = new AssignCourseForm();
            assignForm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            EnterMarksForm marksForm = new EnterMarksForm();
            marksForm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CalculateGPAForm gpaForm = new CalculateGPAForm();
            gpaForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SearchStudentForm searchForm = new SearchStudentForm();
            searchForm.ShowDialog();
        }
    }
}
