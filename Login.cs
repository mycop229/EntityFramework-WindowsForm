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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" & textBox2.Text != "")
            {
                using(HotelContext db = new HotelContext())
                {
                    User user = db.Users.Where(u => u.Login == textBox1.Text)
                                        .Where(u => u.Password == textBox2.Text)
                                        .FirstOrDefault();
                    if(user != null)
                    {
                        Form1 form = new Form1();
                        Hide();
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели не верный логин или пароль");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля ввода корректно");
            }
        }
    }
}
