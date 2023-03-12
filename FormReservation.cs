using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Hotel.Models;

namespace Hotel
{
    public partial class FormReservation : Form
    {
        public FormReservation()
        {
            InitializeComponent();
        }

        private void FormReservation_Load(object sender, EventArgs e)
        {
            SettingDataGridView();
            LoadData();
        }
        private void LoadData()
        {
            using (HotelContext db = new HotelContext())
            {
                var reservationList = db.Reservationss.Include(x => x.Client).Include(x => x.HotelRoom).ToList();

                foreach (var item in reservationList)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                    row.Cells[0].Value = item.Id;
                    row.Cells[1].Value = item.Client.Surname;
                    row.Cells[2].Value = item.Client.Id;
                    row.Cells[3].Value = item.ReservationDate;
                    row.Cells[4].Value = item.ArrivalDate;
                    row.Cells[5].Value = item.DateOfDeparture;
                    row.Cells[6].Value = item.HotelRoom.Id;
                    row.Cells[7].Value = item.HotelRoom.NumberRoom;
                    row.Cells[8].Value = item.HotelRoom.Category;
                    row.Cells[9].Value = item.HotelRoom.PriceOfDay;
                    dataGridView2.Rows.Add(row);
                }
            }
        }
        private void SettingDataGridView()
        {
            dataGridView2.Columns.Add("ID бронирования", "ID бронирования");
            dataGridView2.Columns.Add("Фамилия клиента", "Фамилия клиента");
            dataGridView2.Columns.Add("ID клиента", "ID клиента");
            dataGridView2.Columns.Add("Дата бронирования", "Дата бронирования");
            dataGridView2.Columns.Add("Дата заезда", "Дата заезда");
            dataGridView2.Columns.Add("Дата выезда", "Дата выезда");
            dataGridView2.Columns.Add("ID комнаты", "ID комнаты");
            dataGridView2.Columns.Add("Номер комнаты", "Номер комнаты");
            dataGridView2.Columns.Add("Категория комнаты", "Категория комнаты");
            dataGridView2.Columns.Add("Стоимость за день", "Стоимость за день");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Hide();
            form.ShowDialog();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Reservations reservations = new Reservations();

            int idReservations = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());

            using (HotelContext db = new HotelContext())
            {
                reservations = db.Reservationss.Include(x => x.Client)
                                               .Include(x => x.HotelRoom)
                                               .Where(x => x.Id == idReservations)
                                               .FirstOrDefault();
            }

            UpdateReservation updateReservation = new UpdateReservation(reservations);
            updateReservation.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            LoadData();
        }
    }
}
