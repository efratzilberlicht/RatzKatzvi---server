using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class WordLocation1
    {
        public int ID { get; set; }
        public int BookSenteceID { get; set; }
        public int BookItemID { get; set; }
        public int BookPage { get; set; }
        public Nullable<int> SearchId { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public int Counter { get; set; }

    }
}
