using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* Name: Brooke Wilson
         * Date: November 2024
         * This program rolls one dice or calculates mark stats.
         * Link to your repo in GitHub: https://github.com/bwilson09/Lab5
         * */

        //class-level random object
        Random rand = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            //select one roll radiobutton
            radOneRoll.Checked = true;
            //add your name to end of form title
            Text += "Brooke Wilson";
            
        } // end form load

        private void btnClear_Click(object sender, EventArgs e)
        {
            //call the function
            ClearOneRoll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //call the function
            ClearStats();
            
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            int dice1, dice2;
            //call ftn RollDice, placing returned number into integers
            dice1 = RollDice();
            dice2 = RollDice();
            //place integers into labels
            lblDice1.Text = dice1.ToString();
            lblDice2.Text = dice2.ToString();
            // call ftn GetName sending total and returning name
            int total = dice1 + dice2;
            GetName(total);
            //display name in label
            string rollName = GetName(total);
            lblRollName.Text = rollName;
        }

        /* Name: ClearOneRoll
        *  Sent: nothing
        *  Return: nothing
        *  Clear the labels */
        private void ClearOneRoll()
        {
            //reset labels on onerool grp
            lblDice1.Text = "";
            lblDice2.Text = "";
            lblRollName.Text = "";

        }


        /* Name: ClearStats
        *  Sent: nothing
        *  Return: nothing
        *  Reset nud to minimum value, chkbox unselected, 
        *  clear labels and listbox */
        private void ClearStats()
        {
            //reset display on the mark stats grpbox
            nudNumber.Value= nudNumber.Minimum;
            chkSeed.Checked = false;
            lblPass.ResetText();
            lblFail.ResetText();
            lblAverage.ResetText();
            lstMarks.Items.Clear();
        }


        /* Name: RollDice
        * Sent: nothing
        * Return: integer (1-6)
        * Simulates rolling one dice */
        private int RollDice()
        {
            //get the random # between 1-6
            int number = rand.Next(1, 7);
            return number;
        }


        /* Name: GetName
        * Sent: 1 integer (total of dice1 and dice2) 
        * Return: string (name associated with total) 
        * Finds the name of dice roll based on total.
        * Use a switch statement with one return only
        * Names: 2 = Snake Eyes
        *        3 = Litle Joe
        *        5 = Fever
        *        7 = Most Common
        *        9 = Center Field
        *        11 = Yo-leven
        *        12 = Boxcars
        * Anything else = No special name*/
        private string GetName(int num1)
        {
            //declare variable to return
            string rollName = "";
            //check the total of the numbers to display correct name
            switch (num1)
            {
                case 2:
                    rollName = "Snake Eyes";
                    break;
                case 3:
                    rollName = "Little Joe";
                    break;
                case 5:
                    rollName = "Fever";
                    break;
                case 7:
                    rollName = "Most Common";
                    break;
                case 9:
                    rollName = "Center Field";
                    break;
                case 11:
                    rollName = "Yo-leven";
                    break;
                case 12:
                    rollName = "Boxcars";
                    break;

                default:
                    rollName = "No special name";
                    break;
            }
            return rollName;
        }

        private void btnSwapNumbers_Click(object sender, EventArgs e)
        {
            //call ftn DataPresent twice sending string returning boolean
            string roll1 = lblDice1.Text;
            string roll2 = lblDice2.Text;
            bool roll1Present = DataPresent(roll1);
            bool roll2Present = DataPresent(roll2);
            //if data present in both labels, call SwapData sending both strings
            if (roll1Present && roll2Present)
            {
                SwapData(ref roll1, ref roll2);
            }
            //put data back into labels
            lblDice1.Text = roll1.ToString();
            lblDice2.Text = roll2.ToString();
            //if data not present in either label display error msg
            if (!roll1Present || !roll2Present)
            {
                MessageBox.Show("Roll the dice", "Data Missing");
            }
        }

        /* Name: DataPresent
        * Sent: string
        * Return: bool (true if data, false if not) 
        * See if string is empty or not*/
        private bool DataPresent(string data)
        {
            //declare variable to return
            bool present = true;
            //check if data is empty
            if (data == "")
            {
                present = false;
            }

            return present;
        }

        /* Name: SwapData
        * Sent: 2 strings
        * Return: none 
        * Swaps the memory locations of two strings*/
        private void SwapData(ref string roll1, ref string roll2)
        {
            //put roll1 into a variable
            string temp = roll1;
            //assign opposite inputs to the rolls
            roll1 = roll2;
            roll2 = temp;

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declare variables and array
            int pass = 0;
            int fail = 0;
            double average;
            int nud = (int)nudNumber.Value;
            int[] marks = new int[nud];
            //check if seed value
            if (chkSeed.Checked)
            {
                rand = new Random(1000);                
            }
            else
            {
                rand = new Random();
            }
            lstMarks.Items.Clear();

            //fill array using random number
            int counter = 0;
            while (counter < nud)
            {
                int num = rand.Next(40, 101);
                marks[counter] = num;
                lstMarks.Items.Add(num);
                counter++;
            }
            //call CalcStats sending and returning data
            average = CalcStats(marks, ref pass, ref fail);

            //display data sent back in labels - average, pass and fail
            lblPass.Text = pass.ToString();
            lblFail.Text = fail.ToString();
            // Format average always showing 2 decimal places 
            lblAverage.Text = average.ToString("n2");


        } // end Generate click

        private void radOneRoll_CheckedChanged(object sender, EventArgs e)
        {
            //change grpbox display depending on which rad button is checked
            switch (radOneRoll.Checked)
            {
                case true:
                    grpMarkStats.Hide();
                    grpOneRoll.Show();
                    ClearOneRoll();
                    break;

                case false:
                    grpOneRoll.Hide();
                    grpMarkStats.Show();
                    ClearStats();
                    break;
            }

        }

        private void chkSeed_CheckedChanged(object sender, EventArgs e)
        {
            //check if selected
            if (chkSeed.Checked)
            {
                //show message with yes/no and question icon
               DialogResult selection = MessageBox.Show("Are you sure you want a seed value?", "Confirm Seed Value", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if user click no, un check seed
                if (selection == DialogResult.No)
                {
                    chkSeed.Checked = false;
                }
            }
            
           
        }

        /* Name: CalcStats
        * Sent: array and 2 integers
        * Return: average (double) 
        * Run a foreach loop through the array.
        * Passmark is 60%
        * Calculate average and count how many marks pass and fail
        * The pass and fail values must also get returned for display*/
        private double CalcStats(int[] array, ref int pass, ref int fail)
        {
            //declare variables
            double average = 0;
            double sum = 0;
            pass = 0;
            fail = 0;
            //use foreach loop to sum and find pass.fail marks in array
            foreach (int marks in array)
            {
                sum += marks;

                if (marks >= 60)
                {
                    pass++;
                }
                else
                {
                    fail++;
                }
            }
            //find the average of the array numbers
            if (array.Length > 0)
            {
                average = sum / array.Length;
            }
            //return the average
            return average;           

        }

    }
}
