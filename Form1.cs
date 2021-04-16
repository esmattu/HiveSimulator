using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiveSimulator.Model;
namespace HiveSimulator
{
    public partial class HiveSimulator : Form
    {

        //Create list of bee objects
        protected List<QueenBee> queenBeeList = new();
        protected List<WorkerBee> workerBeeList = new();
        protected List<DroneBee> droneBeeList = new();


        public HiveSimulator()
        {
            InitializeComponent();
            //Disable the damage button
            DamageButton.Enabled = false;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void StartSim_Click(object sender, EventArgs e)
        {
            Random rnd = new();
            for (int i = 0; i < 11; i++)
            {

                int rndNumber = rnd.Next(1, 4);

                switch (rndNumber)
                {
                    case 1:
                        queenBeeList.Add(new QueenBee());
                        break;
                    case 2:
                        workerBeeList.Add(new WorkerBee());
                        break;
                    case 3:
                        droneBeeList.Add(new DroneBee());
                        break;
                }

            }
            DamageButton.Enabled = true;
            StartButton.Enabled = false;
            UpdateTextBoxes();
        }

        private void RestartSimButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = true;
            BeesAliveTextBox.Text = null;
            BeesDeadTextBox.Text = null;
            queenBeeList.Clear();
            droneBeeList.Clear();
            workerBeeList.Clear();
        }

        //Loop through each list of bees and call the damage method then update the textboxes
        private void DamageButton_Click(object sender, EventArgs e)
        {

            Random rnd = new();

            foreach (var bee in queenBeeList)
            {

                bee.DamageQueen(rnd.Next(0, 81));
            }

            foreach (var bee in droneBeeList)
            {

                bee.DamageDrone(rnd.Next(0, 81));
            }

            foreach (var bee in workerBeeList)
            {

                bee.DamageWorker(rnd.Next(0, 81));
            }

            UpdateTextBoxes();

        }

        /*
         * Update the textboxes with results of the simulation. when called it will clear both text boxes
         * and update the new results after damage has been applied
         * 
         */

        private void UpdateTextBoxes()
        {
            BeesDeadTextBox.Text = null;
            BeesAliveTextBox.Text = null;

            foreach (var bee in queenBeeList)
            {
                if (bee.CurrentBeeStatus == BeeStatus.Alive)
                {
                    BeesAliveTextBox.Text += "Queen Bee - Current Health: " + bee.Health + Environment.NewLine;
                }
                else
                {
                    BeesDeadTextBox.Text += "Queen Bee has died! Sad Times!" + Environment.NewLine;

                }
            }

            foreach (var bee in droneBeeList)
            {
                if (bee.CurrentBeeStatus == BeeStatus.Alive)
                {
                    BeesAliveTextBox.Text += "Drone Bee - Current Health: " + bee.Health + Environment.NewLine;
                }
                else
                {
                    BeesDeadTextBox.Text += "Drone Bee has died! Sad Times!" + Environment.NewLine;

                }
            }

            foreach (var bee in workerBeeList)
            {
                if (bee.CurrentBeeStatus == BeeStatus.Alive)
                {
                    BeesAliveTextBox.Text += "Worker Bee - Current Health: " + bee.Health + Environment.NewLine;
                }
                else
                {
                    BeesDeadTextBox.Text += "Worker Bee has died! Sad Times!" + Environment.NewLine;

                }
            }

        }
    }
}
