﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    abstract class Task
    {
        private String taskTitle;
        private Boolean complete;
        private Boolean notificationsOn;
        private String descrip;


        public abstract void setTitle(String theTitle);

        public abstract void setIsComplete(Boolean complete);

        public abstract void setAllowNotifications(Boolean notifications);

        public abstract void setDescription(String descrip);

        public abstract void AddSubtask(SubTask newSubTask);

        public abstract void DeleteSubtask(SubTask subTasktoDelete);

        public abstract void EditSubtask(SubTask oldSubTask, SubTask newSubTask);

        public abstract void getTitle(String theTitle);

        public abstract void getIsComplete(Boolean complete);

        public abstract void getAllowNotifications(Boolean notifications);

        public abstract void getDescription(String descrip);
    }
}
