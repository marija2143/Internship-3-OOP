﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dr_3_dump_int_mk
{
    class Task
    {
        //title
        public string title;
        //descriptionž
        public string description;
        //deadline
        public DateTime deadline;
        //status active, on hold or done
        public string status;
        //expected work time in minutes
        //private TimeSpan.Minutes {get;} workload;

        //related project
        public Project project;
        public Task(string title_, string description_, DateTime deadline_, string status_,Project project_)
        {
            this.title = title_;
            this.description = description_;
            this.deadline = deadline_;
            this.status = status_;
            //this.workload=workload;
            this.project = project_;

        }
    }
}