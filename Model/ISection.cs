using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ISection
    {
        int SectionId { get; set; }
        string Text { get; set; }
        string Description { get; set; }
    }
}
