﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class RepeatableTask
    {
        List<DisposableTask> copiesOfRepeatableTask;

        RepeatableTask(DateTime repeatTaskDate, String title, Boolean isComplet, Boolean allowNotif, String note  )
        {

        }
        public string title { get; set; }

        public string isComplete { get; set; }

        public string allowNotifications { get; set; }

        public string notes { get; set; }
        // test add

    }
}
