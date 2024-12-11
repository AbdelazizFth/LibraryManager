using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class Book
    {
        public string title { get; set; }

        public string author { get; set; }

        public int publicationYear { get; set; } 

        public bool isAvailable { get; set; } = true;

    }
}
