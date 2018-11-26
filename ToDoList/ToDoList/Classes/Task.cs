﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public abstract class Task
    {
        protected int taskId;
        protected String taskTitle;
        protected Boolean complete;
        protected Boolean notificationsOn;
        protected String descrip;
        protected int taskFKey; //Add getters and setters
        protected DateTime taskDueDate;

        public abstract void setTaskId(int taskId);

        public abstract void setTitle(String theTitle);

        public abstract void setIsComplete(Boolean complete);

        public abstract void setAllowNotifications(Boolean notifications);

        public abstract void setDescription(String descrip);

        public abstract void setTaskDueDate(DateTime taskDueDate);

        public abstract void AddSubtask(int subTaskId);

        //Marks Subtask Complete
        public abstract void DeleteSubtask(int subTaskId);

        //Edit Subtask: Should this be done through task or through subtask setters?
        public abstract void EditSubtask(int oldSubTaskId, int newSubTaskId);

        public abstract int getTaskId();

        public abstract String getTitle();

        public abstract Boolean getIsComplete();

        public abstract Boolean getAllowNotifications();

        public abstract String getDescription();

        public abstract DateTime getTaskDueDate();
    }
}
