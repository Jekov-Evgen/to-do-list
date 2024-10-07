using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list
{
    class Logics : INotifyPropertyChanged
    {
        private bool completed;
        private string task;

        public DateTime DateGeneration { get; set; } = DateTime.Now;

        public bool Completed 
        { 
            get  {  return completed; } 

            set 
            {
                if (completed == value) 
                {
                    return;
                }

                completed = value;

                OnProperty("Completed");
            } 
        }

        public string Task 
        { 
            get { return task; } 

            set 
            {
                if (task == value) 
                {
                    return;
                }

                task = value;

                OnProperty("Task");
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperty(string propName = "") 
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}