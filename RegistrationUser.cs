using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class RegistrationUser : Form
    {
        public RegistrationUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" & textBox2.Text != "" & textBox3.Text == textBox4.Text)
            {
                User user = new User()
                {
                    Fio = textBox1.Text,
                    Login = textBox2.Text,
                    Password = textBox3.Text,
                };

                using (HotelContext db = new HotelContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                MessageBox.Show("Сотрудник зарегестрирован");

                ClearForm();
            }
            else
            {
                MessageBox.Show("Проверьте введеные данные"); 
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
