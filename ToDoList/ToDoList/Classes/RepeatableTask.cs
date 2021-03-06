﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    // have to add calls to database throughout.
    public class RepeatableTask : Task
    {
        ToDoDB db = new ToDoDB();
        

        public RepeatableTask(String title, String descrip, Dictionary<int,SubTask> subTaskss)
        {
            this.taskTitle = title;
            this.complete = false;
            this.notificationsOn = false;
            this.descrip = descrip;
            this.subTasks = subTaskss;
            this.isRepeatable = true;

        }
       
        
        public override void AddSubtask(int  subTaskId)
        {
            subTasks.Add(subTaskId, db.FetchSubTask(subTaskId));
            SaveTask();
        }



        public override void DeleteSubtask(int subTaskId)
        {
            subTasks.Remove(subTaskId);
            SaveTask();
        }

      
        public override void EditSubtask(int oldSubTaskId, int newSubTaskId)
        {
            subTasks.Remove(oldSubTaskId);
            subTasks.Add(newSubTaskId, db.FetchSubTask(newSubTaskId));
            SaveTask();
        }
      
        public override void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }
        public override void setRepeatability(Boolean Repeatable)
        {
            this.isRepeatable = Repeatable;
        }

        public override void setTitle(String theTitle)
        {
            this.taskTitle = theTitle;
            SaveTask();
        }

        // Is called when all subtasks have been marked complete.
        public override void setIsComplete(Boolean complete)
        {
            foreach( KeyValuePair<int, SubTask> entry in subTasks)
            {
               entry.Value.setDueDate(entry.Value.getDueDate().AddDays(7));
            }
            SaveTask();

        }

        public override void setAllowNotifications(Boolean notifications)
        {
            this.notificationsOn = notifications;
        }


        public override void setDescription(String descri)
        {
            this.descrip = descri;
            SaveTask();
        }

        public override void setTaskFKey(int taskFKey)
        {
            this.taskFKey = taskFKey;
        }

        public void setSubTasks(Dictionary<int, SubTask> subTasks)
        {
            this.subTasks = subTasks;
            SaveTask();
        }
        ///////////////////////////////////////////////Getters are below///////////////////////////////////////
        public override Boolean getRepeatability()
        {
            return this.isRepeatable;
        }

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
        //////////////////////////////////////

        public override void SaveTask()
        {
            if(db.doesTaskExist(this.taskId) == false)
            {
                db.InsertRepeatTask(this);
            }
            else
            {
                db.SaveRepeatTask(this);
            }
            
        }

        public override Dictionary<int, SubTask> getSubTask()
        {
            return subTasks;
        }
    }
}
