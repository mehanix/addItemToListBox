using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string formString()
        {
            //strings where info is stored
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string sex;
            string item;
            //determining which radio button is pressed
            if (radioButton1.Checked)
                sex = "M";
            else sex = "F";
            //forming the string to be added
            item = nume + " " + prenume + " -" + sex;
            //adding other attributes, depending on which checkboxes have been ticked
            if (checkBox1.Checked)
                item += ", frumos";
            if (checkBox2.Checked)
                item += ", destept";
            if (checkBox3.Checked)
                item += ", modest";
            return item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create string
            string item = formString();
            //put the string in the list
            if (!listBox1.Items.Contains(item))
                 listBox1.Items.Add(item);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //on button click, clear the list
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //on button click, remove last element. The use of the
            //try-catch is for the case when the listbox is empty
            try
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
            }
            catch { };
            }

        private void button4_Click(object sender, EventArgs e)
        {
            //create string
            string item = formString();
            //search for item and remove it
            try
            {
                listBox1.Items.Remove(item);
            }
            catch { };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //on click move selected one up
            try
            {
                //insert the element one position up
                listBox1.Items.Insert(listBox1.SelectedIndex - 1, listBox1.SelectedItem);
                //select the newly moved element
                listBox1.SetSelected(listBox1.SelectedIndex - 2, true);
                //remove the old element which is below (we use +2 instead of +1 because
                //the element count is 0-based (starts from 0))
                listBox1.Items.RemoveAt(listBox1.SelectedIndex+2);
            }
            catch { };

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //on click move selected one down
            try
            {
                //insert item one position below(0-based count)
                listBox1.Items.Insert(listBox1.SelectedIndex +2, listBox1.SelectedItem);
                //select newly-moved item
                listBox1.SetSelected(listBox1.SelectedIndex +2, true);
                //remove the old entry(which is 2 positions above the now-selected item
                listBox1.Items.RemoveAt(listBox1.SelectedIndex-2);
            }
            catch { };
        }
    }
}
