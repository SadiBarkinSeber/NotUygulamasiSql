using Microsoft.EntityFrameworkCore;
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
    public partial class Login : Form
    {
        AppDbContext db;
        public Login()
        {
            InitializeComponent();
            db = new AppDbContext();
        }
        

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string username = txtKullaniciAdi.Text;
            string password = txtSifre.Text;

            // Kullanıcı adı ve şifre doğrulaması
            Person person = db.Persons.FirstOrDefault(x => x.UserName == username && x.Password == password);

            if (person != null)
            {
                if (username.ToLower() == "admin" && password == "12345")
                {
                    if (person.Durum == Durum.Pasif)
                    {
                        MessageBox.Show("Admin onayı bekleniyor.");
                    }
                    else
                    {
                        // Admin ise ve durumu aktifse AdminScreen formunu aç
                        AdminScreen adminScreen = new AdminScreen();
                        adminScreen.Show();
                        this.Hide(); 
                    }
                }
                else
                {
                    if (person.Durum == Durum.Pasif)
                    {
                        MessageBox.Show("Admin onayı bekleniyor.");
                    }
                    else
                    {
                        // Admin değilse ve durumu aktifse SignInScreen formunu aç
                        UserScreen userScreen = new UserScreen(person.UserName);
                        userScreen.ShowDialog();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private void linkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInScreen signInScreen = new SignInScreen();
            signInScreen.Show();
            this.Hide();
        }
    }
}
