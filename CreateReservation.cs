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
    public partial class CreateReservation : Form
    {
        public int IdClient;
        public CreateReservation()
        {
            InitializeComponent();
        }

        private void CreateReservation_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            using(HotelContext db = new HotelContext())
            {
                var result = db.HotelRooms.ToList();

                foreach(var room in result)
                {
                    comboBox1.Items.Add(room.Id);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(HotelContext db = new HotelContext())
            {
                int id = Convert.ToInt32(comboBox1.Text);
                var result = db.HotelRooms.Where(r => r.Id == id).FirstOrDefault();

                label10.Text = result.NumberRoom;
                label11.Text = result.NumberFloor;
                label12.Text = result.PriceOfDay.ToString();
                label13.Text = result.Category;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & comboBox1.Text != "")
            {
                if (InsertClient() == false)
                    InsertClient();

                Reservations reservations = new Reservations()
                {
                    ReservationDate = dateTimePicker1.Value,
                    ArrivalDate = dateTimePicker1.Value,
                    DateOfDeparture = dateTimePicker3.Value,
                    ClientId = IdClient,
                    HotelRoomId = Convert.ToInt32(comboBox1.Text)
                };

                using (HotelContext db = new HotelContext())
                {
                    db.Reservationss.Add(reservations);
                    db.SaveChanges();
                }

                MessageBox.Show("Бронь успешно добавлена");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Заполните поля ввода 'Клиент' и выберите ID номера");
            }
            
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private bool InsertClient()
        {
            using(HotelContext db = new HotelContext())
            {
                var result = db.Clients.Where(r => r.PassportData == textBox4.Text).FirstOrDefault(); 

                if(result != null) 
                {
                    IdClient = result.Id;
                    return true;
                }

                else
                {
                    Client client = new Client
                    {
                        Surname = textBox1.Text,
                        Name = textBox2.Text,
                        MiddleName = textBox3.Text,
                        PassportData = textBox4.Text,
                    };

                    db.Clients.Add(client);
                    db.SaveChanges();
                    return false;
                }
            }
        }
    }
}
