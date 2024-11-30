using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            GetName(dice1 + dice2);
            //display name in label
            string rollName = GetName(dice1 + dice2);
            lblRollName.Text = rollName;
        }

        /* Name: ClearOneRoll
        *  Sent: nothing
        *  Return: nothing
        *  Clear the labels */
        private void ClearOneRoll()
        {
            //radOneRoll.Checked = true;
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
            nudNumber.Value= nudNumber.Minimum;
            chkSeed.Checked = false;
            lblPass.ResetText();
            //make sure reset text works- if so add to all in this function
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
            string rollName = "";
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

            //if data present in both labels, call SwapData sending both strings

            //put data back into labels

            //if data not present in either label display error msg
        }

        /* Name: DataPresent
        * Sent: string
        * Return: bool (true if data, false if not) 
        * See if string is empty or not*/


        /* Name: SwapData
        * Sent: 2 strings
        * Return: none 
        * Swaps the memory locations of two strings*/

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declare variables and array

            //check if seed value

            //fill array using random number

            //call CalcStats sending and returning data

            //display data sent back in labels - average, pass and fail
            // Format average always showing 2 decimal places 

        } // end Generate click

        private void radOneRoll_CheckedChanged(object sender, EventArgs e)
        {
            
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

        /* Name: CalcStats
        * Sent: array and 2 integers
        * Return: average (double) 
        * Run a foreach loop through the array.
        * Passmark is 60%
        * Calculate average and count how many marks pass and fail
        * The pass and fail values must also get returned for display*/

    }
}
