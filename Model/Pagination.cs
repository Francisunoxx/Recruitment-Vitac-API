using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pagination
    {
        public int ItemPerPage { get; set; } = 10;
        public int Counter { get; set; }
        public bool IsNext { get; set; }
        public bool IsPrevious { get; set; }
        public string SectionToSearch { get; set; }
    }
}
