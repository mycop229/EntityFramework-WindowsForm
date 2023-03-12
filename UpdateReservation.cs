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
using System.Data.Entity;

namespace Hotel
{
    public partial class UpdateReservation : Form
    {
        public UpdateReservation()
        {
            InitializeComponent();
        }
        public UpdateReservation(Reservations reservation)
        {
            InitializeComponent();

            dateTimePicker1.Value = reservation.ReservationDate;
            dateTimePicker2.Value = reservation.ArrivalDate;
            dateTimePicker3.Value = reservation.DateOfDeparture;
            label27.Text = reservation.Id.ToString();

            label9.Text = reservation.Client.Id.ToString();
            label10.Text = reservation.Client.Surname;
            label11.Text = reservation.Client.Name;
            label12.Text = reservation.Client.MiddleName;
            label13.Text = reservation.Client.PassportData;

            label18.Text = reservation.HotelRoom.Id.ToString();
            label17.Text = reservation.HotelRoom.NumberRoom;
            label16.Text = reservation.HotelRoom.NumberFloor;
            label15.Text = reservation.HotelRoom.NumberOfPlaces;
            label14.Text = reservation.HotelRoom.PriceOfDay.ToString();
            label24.Text = reservation.HotelRoom.Category;

        }
        private void UpdateReservation_Load(object sender, EventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clients clients = new Clients();
            Hide();
            clients.ShowDialog();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void label25_Click(object sender, EventArgs e)
        {

        }
        private void label24_Click(object sender, EventArgs e)
        {

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HotelRooms hotelRooms = new HotelRooms();
            Hide();
            hotelRooms.ShowDialog();
        }
        private void UpdatedReservation()
        {
            Reservations reservations = new Reservations();

            int id = Convert.ToInt32(label27.Text);

            using (HotelContext db = new HotelContext())
            {
                reservations = db.Reservationss.Include(s => s.Client)
                                               .Include(s => s.HotelRoom)
                                               .Where(s => s.Id == id)
                                               .FirstOrDefault();

                if(reservations != null)
                {
                    reservations.ReservationDate = dateTimePicker1.Value;
                    reservations.ArrivalDate = dateTimePicker2.Value;
                    reservations.DateOfDeparture = dateTimePicker3.Value;
                    db.SaveChanges();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdatedReservation();
            MessageBox.Show("Запись успешно обновлена");
            Hide();
        }
        private void DeleteReservation()
        {
            Reservations reservations = new Reservations();
            int id = Convert.ToInt32(label27.Text);

            using (HotelContext db = new HotelContext())
            {
                reservations = db.Reservationss.Include(s => s.Client)
                                               .Include(s => s.HotelRoom)
                                               .Where(s => s.Id == id)
                                               .FirstOrDefault();

                if (reservations != null)
                {
                    db.Reservationss.Remove(reservations);
                    db.SaveChanges();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteReservation();
            MessageBox.Show("Запись успешно удалена");
            Hide();
        }
    }
}
