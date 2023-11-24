using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotUygulamasiSql.Domain.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public Person person { get; set; }
        public int PersonID { get; set; }

    }
}
