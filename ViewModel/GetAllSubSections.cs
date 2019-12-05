﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GetAllSubSections : ISection
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
