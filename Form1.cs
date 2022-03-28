using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Db db = new Db();

        public bool select(Student newRegister)
        {
            foreach (var student in db.students)
            {
                if (newRegister.Name == student.Name && newRegister.FamilyName == student.FamilyName)
                {
                    return true;
                }
            }
            return false;
        }
         public bool Register(Student form)
        {
            if (select(form) != true)
            {
                if (form.Age >= 18  )
                {
                    db.students.Add(new Student() { Name = form.Name, FamilyName = form.FamilyName, Age = form.Age, Mark = form.Mark });
                    db.SaveChanges();
                    return true;

                }
                else
                {
                    MessageBox.Show("Sorry,your are not allowed to registeration!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You have already registered!");
                return false;
            }
        }
        




        private void button1_Click(object sender, EventArgs e)
        {
            if(Register(new Student { Name = textBox1.Text, FamilyName = textBox2.Text,Age= Convert.ToByte(textBox3.Text) , Mark = Convert.ToByte(textBox4.Text) }))
            {
                MessageBox.Show("Your Registeration has been Completed");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db.students.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            List<Student> AllFailedStudents = new List<Student>();

            foreach (var person in db.students )
            {
                if(person.Mark <= 15)
                {
                    AllFailedStudents.Add(person);
                    dataGridView2.DataSource = AllFailedStudents.ToList();
                }
                
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.students.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    (item as TextBox).Clear();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.students.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Student> searchList=new List<Student>();
            foreach(var student in db.students)
            {

                if (student.Name.Contains(textBox5.Text) || student.FamilyName.Contains(textBox5.Text))
                {
                    searchList.Add(student);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource =searchList.ToList();
                }
            }
        }
    }
 
}
