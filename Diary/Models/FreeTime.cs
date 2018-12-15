﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class FreeTime
    {
        public FreeTime(string name, string startTime, string endTime)
        {
            this.name = name;
            this.startTime = startTime;
            this.endTime = endTime;

        }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string name { get; set; }
    }
}
