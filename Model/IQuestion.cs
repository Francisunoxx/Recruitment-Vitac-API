﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IQuestion
    {
        int QuestionId { get; set; }
        string Quiz { get; set; }
    }
}
