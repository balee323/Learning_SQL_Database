using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes_CRUD_App.Models
{
    class User
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public Int64 UserID { get; set; }

        public DateTime DOB { get; set; }

    }
}
