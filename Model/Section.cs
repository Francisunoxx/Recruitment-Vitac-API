﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Section : ISection
    {
        public int SectionId { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
