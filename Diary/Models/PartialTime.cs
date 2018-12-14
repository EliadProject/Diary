﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class PartialTime
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int peopleNum { get; set; }
        public string names { get; set; }

        public void addPerson(string name)
        {
            string str = "";
            if (this.names != "")
            {
                str = ", ";
            }
            this.names += str + name;
        }
    }
}
