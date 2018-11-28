﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    // have to add calls to database throughout.
    class RepeatableTask : Task
    {
        ToDoDB db = new ToDoDB();
        protected Dictionary<int, SubTask> subTasks { get; set; } //subTaskId maps to subTask


        public RepeatableTask(String title, String descrip, Dictionary<int,SubTask> subTaskss)
        {

            this.taskTitle = title;
            this.complete = false;
            this.notificationsOn = false;
            this.descrip = descrip;
            this.subTasks = subTaskss;
            this.isRepeatable = true;
            // what if this is a new task? 
            // db.SaveRepeatTask(this);

        }
       
        

        public override void AddSubtask(int  subTaskId)
        {
            subTasks.Add(subTaskId, db.FetchSubTask(subTaskId));
            db.SaveRepeatTask(this);
        }

        // Overloaded version of AddSubtask, would require different input
        //public void AddSubtask(int subTaskId, SubTask newSubTask)
       // {
           // subTasks.Add(subTaskId, newSubTask);
       // }

        public override void DeleteSubtask(int subTaskId)
        {
            subTasks.Remove(subTaskId);
            db.SaveRepeatTask(this);

        }

      
        public override void EditSubtask(int oldSubTaskId, int newSubTaskId)
        {
                subTasks.Remove(oldSubTaskId);
                subTasks.Add(newSubTaskId, db.FetchSubTask(newSubTaskId));
                db.SaveRepeatTask(this);
        }
        //////////////////////////////////// At the end of each one of these setters have to add saves to the database, should just be "save repeat"
        public override void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public override void setTitle(String theTitle)
        {
            this.taskTitle = theTitle;
        }

        // Is called when all subtasks have been marked complete.
        public override void setIsComplete(Boolean complete)
        {
            foreach( KeyValuePair<int, SubTask> entry in subTasks)
            {
               entry.Value.setDueDate(entry.Value.getDueDate().AddDays(7));
            }
            db.SaveRepeatTask(this);

        }

        public override void setAllowNotifications(Boolean notifications)
        {
            this.notificationsOn = notifications;
        }


        public override void setDescription(String descri)
        {
            this.descrip = descri;
        }

        public override void setTaskFKey(int taskFKey)
        {
            
        }

        public void setSubTasks(Dictionary<int, SubTask> subTasks)
        {
            this.subTasks = subTasks;
        }
        ///////////////////////////////////////////////Getters are below///////////////////////////////////////
        public override int getTaskId()
        {
            return this.taskId;
        }

        public override String getTitle()
        {
            return this.taskTitle;
        }

        public override Boolean getIsComplete()
        {
            return this.complete;
        }

        public override Boolean getAllowNotifications()
        {
            return this.notificationsOn;
        }

        public override String getDescription()
        {
            return this.descrip;
        }

        public override int getTaskFKey()
        {
            return this.taskFKey;
        }
        ///////////////////////////////////////////////////
        public void turnRepeatableOff()
        {
            //need to finish
            db.SaveRepeatTask(this);
        }

        public override void SaveTask()
        {
            db.SaveRepeatTask(this);
        }

        public override bool getRepeatability(){
            return this.isRepeatable;
        }
    }
}
