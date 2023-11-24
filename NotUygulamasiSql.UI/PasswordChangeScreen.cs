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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NoteProject.UI
{
    public partial class PasswordChangeScreen : Form
    {
        private AppDbContext dbContext;

        public PasswordChangeScreen()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        private void btnSifreDegis_Click(object sender, EventArgs e)
        {
            string eskiSifre = txtEskiSifre.Text;
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;


            // Kullanıcı bilgilerini al
            Person currentUser = dbContext.Persons.FirstOrDefault(p => p.UserName == username && p.Password == password); // Bu fonksiyonu, mevcut oturum açmış kullanıcıyı getiren bir şekilde implemente ediniz

            if (currentUser != null)
            {
                // Eski şifre kontrolü
                if (currentUser.Password == eskiSifre)
                {
                    // Yeni şifre ve tekrarı kontrol et
                    if (yeniSifre == yeniSifreTekrar)
                    {
                        // Yeni şifreyi güncelle
                        currentUser.Password = yeniSifre;

                        // Değişiklikleri veritabanına kaydet
                        dbContext.SaveChanges();

                        MessageBox.Show("Şifre başarıyla değiştirildi.");
                    }
                    else
                    {
                        MessageBox.Show("Yeni şifreler uyuşmuyor. Lütfen doğru bir şekilde giriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Eski şifre yanlış. Lütfen doğru bir şekilde giriniz.");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.");
            }
        }
    }

}
