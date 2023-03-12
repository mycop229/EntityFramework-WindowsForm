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
    public partial class AddHotelRoom : Form
    {
        public AddHotelRoom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InsertHotelRoom() == true)
            {
                MessageBox.Show("Номер успешно добавлен");
                Hide();
            }
            else
            {
                MessageBox.Show("Заполните поля ввода корректно");
            }
        }

        private bool InsertHotelRoom()
        {
            if(textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & comboBox1.Text != "")
            {
                HotelRoom hotelRoom = new HotelRoom
                {
                    NumberRoom = textBox1.Text,
                    NumberFloor = textBox2.Text,
                    NumberOfPlaces = textBox3.Text,
                    PriceOfDay = Convert.ToDecimal(textBox4.Text),
                    Category = comboBox1.Text,
                };

                using (HotelContext db = new HotelContext())
                {
                    db.HotelRooms.Add(hotelRoom);
                    db.SaveChanges();
                }
                return true;
            }
            return false;
        }
    }
}
