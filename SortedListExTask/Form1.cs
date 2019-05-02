// Author: Harley Veillette
// Date: 2019-05-02
// Exercise: Task Manager
// Notes: 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        //Datetime should be the key
        SortedList<DateTime, string> myTaskSortedList = new SortedList<DateTime, string>();

        public Form1()
        {
            InitializeComponent();
        }

        //Code for if Add button is click
        private void AddTask()
        {
            //If button is click with nothing inside the textbox
            if (txtTask.Text == string.Empty)
            {
                MessageBox.Show("You must enter a task", "Invalid Data",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {

                //look if a date is already in 
                if (myTaskSortedList.ContainsKey(dtpTaskDate.Value))
                {
                    MessageBox.Show("Only one task per date is allowed", "Invalid Data",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    //Add task to the list 
                    myTaskSortedList.Add(dtpTaskDate.Value, txtTask.Text);

                    //Show the date inside the list
                    lstTasks.Items.Add(dtpTaskDate.Value);

                    //Clear the textbox for new inputs
                    txtTask.Text = string.Empty;
                    txtTask.Focus();
                }

            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Datetime variable
            if(lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Test");
            }
            else
            {
                DateTime dDate = (DateTime)lstTasks.SelectedItem;
                lblTaskDetails.Text = myTaskSortedList[dDate];
            }

        }

        private void RemoveTask()
        {
                myTaskSortedList.RemoveAt(lstTasks.SelectedIndex);
                lstTasks.Items.Remove(lstTasks.SelectedItem);
 
            //lstTasks.Items.Remove(lstTasks.SelectedItem);
        }
        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            RemoveTask();
        }

        private void PrintTasks()
        {
            string msg = string.Empty;
            foreach(var task in myTaskSortedList)
            {
                msg += $"{task.Key} \n {task.Value} \n"; 
            }
            MessageBox.Show(msg);
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintTasks();
        }
    }
}
