using NotUygulamasiSql.DAL.Context;
using NotUygulamasiSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteProject.UI
{
    public partial class AdminScreen : Form
    {
        private AppDbContext db;

        public AdminScreen()
        {
            InitializeComponent();
            db = new AppDbContext();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // ListView sütunlarını tanımla
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Ad", 100);
            listView1.Columns.Add("Soyad", 100);
            listView1.Columns.Add("Kullanıcı Adı", 100);
            listView1.Columns.Add("Durum", 50);

            // Veritabanındaki kişileri ListView'e ekle
            foreach (Person person in db.Persons)
            {
                ListViewItem item = new ListViewItem(person.PersonID.ToString());
                item.SubItems.Add(person.FirstName);
                item.SubItems.Add(person.LastName);
                item.SubItems.Add(person.UserName);
                item.SubItems.Add(person.Durum.ToString());

                listView1.Items.Add(item);
            }
        }

        private void btnDurum_Click(object sender, EventArgs e)
        {
            // Seçilen kişinin durumunu değiştir
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedPersonId = int.Parse(listView1.SelectedItems[0].Text);
                Person selectedPerson = db.Persons.FirstOrDefault(x => x.PersonID == selectedPersonId);

                if (selectedPerson != null)
                {
                    // Durumu değiştir (örneğin, ters çevir)
                    selectedPerson.Durum = (selectedPerson.Durum == Durum.Aktif) ? Durum.Pasif : Durum.Aktif;

                    // ListView'deki durumu güncelle
                    listView1.SelectedItems[0].SubItems[4].Text = selectedPerson.Durum.ToString();

                    // Veritabanını güncelle
                    db.SaveChanges();
                }
            }

        }
    }
}
