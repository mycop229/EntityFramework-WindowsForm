using Hotel.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hotel
{
    public partial class HotelRooms : Form
    {
        public HotelRooms()
        {
            InitializeComponent();
        }

        private void HotelRooms_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Номер комнаты";
            dataGridView1.Columns[2].HeaderText = "Этаж";
            dataGridView1.Columns[3].HeaderText = "Количество мест";
            dataGridView1.Columns[4].HeaderText = "Стоимость за сутки";
            dataGridView1.Columns[5].HeaderText = "Категория";
        }

        private void LoadData()
        {
            using(HotelContext db = new HotelContext())
            {
                dataGridView1.DataSource = db.HotelRooms.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddHotelRoom addHotelRoom = new AddHotelRoom();
            addHotelRoom.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HotelRoom hotelroom = new HotelRoom();
            int idHotelRoom = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            using (HotelContext db = new HotelContext())
            {
                hotelroom = db.HotelRooms.Find(idHotelRoom);
            }

            UpdateHotelRooms updateHotelRooms = new UpdateHotelRooms(hotelroom);
            updateHotelRooms.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Hide();
            form.ShowDialog();
        }
    }
}
