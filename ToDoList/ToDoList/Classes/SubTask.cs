﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    class SubTask
    {
        ToDoDB db = new ToDoDB();
        private string connectionStringToDB = "server =localhost; user=team3; password=x143; database=team3";

        DateTime dueDate;
        bool complete;
        LinkedList<String> files;
        String title;
        String notes;
        int subtaskId; //Key for subtask ID for subtask table of DB - Added by Jake
        DateTime repeatFrom;
        Boolean taskComplete;
        int subtaskFKey;

        public SubTask(DateTime inDueDate, LinkedList<String> inFiles, String inTitle, String inNotes, int inId, DateTime repeatFrom, Boolean taskComplete)
        {
            dueDate = inDueDate;
            complete = false;
            files = inFiles;
            title = inTitle;
            notes = inNotes;
            subtaskId = inId;
            this.repeatFrom = repeatFrom;
            this.taskComplete = taskComplete;
        }

        public SubTask()
        {
            dueDate = DateTime.MinValue;
            complete = false;
            files = null;
            title = null;
            notes = null;
        }

        public void SaveSubTask()
        {
            if (db.CheckSubTaskExistsInDB(subtaskId))
            {
                //Update Table Row
                db.UpdateSubTask(this);
            }
            else
            {
                //Insert new Table Row
                db.InsertSubTask(this);
            }
        }

        public void setRepeatFrom(DateTime date)
        {
            this.repeatFrom = date;
        }

        public void setSubtaskFKey(int FKey)
        {
            this.subtaskFKey = FKey;
        }

        public DateTime getRepeatFrom()

        {
            return this.repeatFrom;
        }

        public int getSubtaskFKey()

        {
            return this.subtaskFKey;
        }

        public Boolean getTaskComplete()
        {
            return this.taskComplete;
        }

        public void setTaskComplete(Boolean complete)
        {
            this.taskComplete = complete;
        }

        public void setId(int inId)
        {
            subtaskId = inId;
        }

        public  int getId()
        {
            return subtaskId;
        }
        public void setDueDate(int month, int day, int year)
        {
            dueDate = new DateTime(year, month, day);
        }

        public void setDueDate(DateTime date)
        {
            dueDate = date;
        }

        public DateTime getDueDate()
        {
            return dueDate;
        }

        public void markComplete()
        {
            complete = true;
        }

        public bool isComplete()
        {
            return complete;
        }

        public void setFiles(LinkedList<String> inFiles)
        {
            files = inFiles;
        }

        public void addFile(String inFile)
        {
            files.AddLast(inFile);
        }

        public LinkedList<String> getFiles()
        {
            return files;
        }

        public void setTitle(String inTitle)
        {
            title = inTitle;
        }

        public String getTitle()
        {
            return title;
        }

        public void setNotes(String inNotes)
        {
            notes = inNotes;
        }

        public void addToNotes(String inNotes)
        {
            notes = notes + inNotes;
        }

        public String getNotes()
        {
            return notes;
        }



        public String toString()
        {
            //String tmp = title + " " + notes + " due " + dueDate.toString() + " done:";
            String tmp = ""; //Done to compile
            if (complete)
            {
                return tmp + "yes";
            }
            return tmp + "no";
        }
    }
}