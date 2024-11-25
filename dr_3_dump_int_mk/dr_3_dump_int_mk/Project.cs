﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dr_3_dump_int_mk.enums;

namespace dr_3_dump_int_mk
{
    class Project
    {
        //title
        public string title;
        //description
        public string description;
        //date start
        public DateTime start_time;
        //date end
        public DateTime end_time;
        //status active, on hold or done
        public Status status;
        public Project() { }
        public Project(string title_,string description_, DateTime start_, DateTime end_, Status status_)
        {
            this.title = title_;
            this.description = description_;
            this.start_time = start_;
            this.end_time = end_;
            this.status = status_;
        }
    }
}