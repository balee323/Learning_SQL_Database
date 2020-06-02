using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes_CRUD_App.Models
{
    class Note
    {
        public Int64 NoteId { get; set; }

        public string NoteBody { get; set; }

        public string User { get; set; }

        public DateTime NoteDate { get; set; }

    }
}
