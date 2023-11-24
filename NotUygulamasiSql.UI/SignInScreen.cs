using NotUygulamasiSql.DAL.Context;
using NotUygulamasiSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteProject.UI
{
    public partial class SignInScreen : Form
    {
        AppDbContext db;
        public SignInScreen()
        {
            InitializeComponent();
            db = new AppDbContext();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Person person = db.Persons.FirstOrDefault(x => x.UserName == txtKullaniciAdi.Text);
            if (person == null)
            {
                person = new Person()
                {
                    FirstName = txtAd.Text,
                    LastName = txtSoyad.Text,
                    UserName = txtKullaniciAdi.Text,
                    Password = txtSifre.Text,
                    Durum = Durum.Pasif,
                };

                db.Persons.Add(person);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aynı kullanıcı adına sahip kullanıcı var");
            }
            Login login = new Login();
            login.ShowDialog();
            this.Hide();
        }
    }
}
