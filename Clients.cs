using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Паспортные данные";

        }

        private void LoadData()
        {
            using(HotelContext db = new HotelContext())
            {
                dataGridView1.DataSource = db.Clients.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerchClientBySurname();
        }

        private void SerchClientBySurname()
        {
            List<Client> clientList;

            using (HotelContext db = new HotelContext())
            {
                clientList = db.Clients.Where(p => p.Surname == textBox1.Text).ToList();
            }

            if (clientList.Count > 0)
                dataGridView1.DataSource = clientList;
            else
                MessageBox.Show("Клиентов с такой фамилией не найдено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Hide();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SerachClientByPassport();
        }

        private void SerachClientByPassport()
        {
            List<Client> client;

            using (HotelContext db = new HotelContext())
            {
                client = db.Clients.Where(p => p.PassportData == textBox2.Text).ToList();
            }

            if (client.Count > 0)
                dataGridView1.DataSource = client;
            else
                MessageBox.Show("Клиентов с такими паспортными данными не найдено");
        }
    }
}
