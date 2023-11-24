using Microsoft.EntityFrameworkCore;
using NotUygulamasiSql.DAL.Context;
using NotUygulamasiSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoteProject.UI
{
    public partial class UserScreen : Form
    {
        private string kullaniciAdi;
        private AppDbContext db;

        public UserScreen(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.db = new AppDbContext();

            LoadNotes();
        }

        private void btnYeniNot_Click(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedIndex != -1)
            {
                string secilenNotAdi = lboxNotlar.SelectedItem.ToString();

                var user = db.Persons.FirstOrDefault(p => p.UserName == kullaniciAdi);

                if (user != null)
                {
                    var secilenNot = db.Notes.FirstOrDefault(n => n.UserName== secilenNotAdi && n.PersonID == user.PersonID);

                    if (secilenNot != null)
                    {
                        if (secilenNot.NoteContent != null)
                        {
                            txtBaslik.Text = secilenNot.NoteTitle;
                            txtIcerik.Text = secilenNot.NoteContent;
                        }
                        else
                        {
                            MessageBox.Show("Seçilen notun içeriği boş.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seçilen not veritabanında bulunamadı.");
                        // Başarısız durumda temizleme
                        txtBaslik.Clear();
                        txtIcerik.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                    // Başarısız durumda temizleme
                    txtBaslik.Clear();
                    txtIcerik.Clear();
                }
            }
        }

        private void btnNotSil_Click(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedIndex != -1)
            {
                string secilenNotAdi = lboxNotlar.SelectedItem.ToString();

                var user = db.Persons.FirstOrDefault(p => p.UserName == kullaniciAdi);
                var secilenNot = db.Notes.FirstOrDefault(n => n.UserName == secilenNotAdi && n.PersonID == user.PersonID);

                if (user != null)
                {

                    if (secilenNot != null)
                    {
                        db.Notes.Remove(secilenNot);
                        db.SaveChanges();

                        MessageBox.Show("Not silindi.");

                        // Notları tekrar yükle
                        LoadNotes();

                        // Başarılı silme sonrası temizleme
                        txtBaslik.Clear();
                        txtIcerik.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen not veritabanında bulunamadı.");
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedIndex != -1)
            {
                string secilenNotAdi = lboxNotlar.SelectedItem.ToString();

                var user = db.Persons.FirstOrDefault(p => p.UserName == kullaniciAdi);

                if (user != null)
                {
                    var secilenNot = db.Notes.FirstOrDefault(n => n.UserName == secilenNotAdi && n.PersonID == user.PersonID);

                    if (secilenNot != null)
                    {
                        txtBaslik.Text = secilenNot.NoteTitle;
                        txtIcerik.Text = secilenNot.NoteContent;
                    }
                    else
                    {
                        MessageBox.Show("Seçilen not veritabanında bulunamadı.");
                        // Başarısız durumda temizleme
                        txtBaslik.Clear();
                        txtIcerik.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                    // Başarısız durumda temizleme
                    txtBaslik.Clear();
                    txtIcerik.Clear();
                }
            }
        }

        private void lboxNotlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedIndex != -1)
            {
                var selectedNote = lboxNotlar.SelectedItem as Note; // Seçili öğeyi Note türüne dönüştür

                if (selectedNote != null)
                {
                    txtBaslik.Text = selectedNote.NoteTitle;
                    txtIcerik.Text = selectedNote.NoteContent;
                }
                else
                {
                    MessageBox.Show("Seçilen not veritabanında bulunamadı.");
                }
            }
        }

        private void LoadNotes()
        {
            // Kullanıcının notlarını veritabanından yükle
            var user = db.Persons.FirstOrDefault(p => p.UserName == kullaniciAdi);

            if (user != null)
            {
                var notes = db.Notes.Where(n => n.PersonID == user.PersonID).ToList();

                lboxNotlar.DisplayMember = "NoteTitle"; // Bu satırı ekleyin
                lboxNotlar.Items.Clear();
                lboxNotlar.Items.AddRange(notes.ToArray());
            }
        }
    }
}
