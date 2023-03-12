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
    public partial class UpdateHotelRooms : Form
    {
        public UpdateHotelRooms()
        {
            InitializeComponent();
        }

        public UpdateHotelRooms(HotelRoom hotelRoom)
        {
            InitializeComponent();
            textBox1.Text = hotelRoom.NumberRoom;
            textBox2.Text = hotelRoom.NumberFloor;
            textBox3.Text = hotelRoom.NumberOfPlaces;
            textBox4.Text = hotelRoom.PriceOfDay.ToString();
            comboBox1.Text = hotelRoom.Category;
            label7.Text = hotelRoom.Id.ToString();
        }

        private void UpdateHotelRooms_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateHotelRoom();
            MessageBox.Show("Запись успешно обновлена");
            Hide();
        }

        private void UpdateHotelRoom()
        {
            using (HotelContext db = new HotelContext())
            {
                var result = db.HotelRooms.Find(Convert.ToInt32(label7.Text));
                if (result != null)
                {
                    result.NumberRoom = textBox1.Text;
                    result.NumberFloor = textBox2.Text;
                    result.NumberOfPlaces = textBox3.Text;
                    result.PriceOfDay = Convert.ToDecimal(textBox4.Text);
                    result.Category = comboBox1.Text;
                    result.Id = Convert.ToInt32(label7.Text);

                    db.SaveChanges();
                }
            }
        }

        private void DeleteHotelRoom()
        {
            using (HotelContext db = new HotelContext())
            {
                var result = db.HotelRooms.Find(Convert.ToInt32(label7.Text));
                if (result != null)
                {
                    db.HotelRooms.Remove(result);
                    db.SaveChanges();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteHotelRoom();
            MessageBox.Show("Запись успешно удалена");
            Hide();
        }
    }
}
