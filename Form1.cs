using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_5_Task_B
{
    public partial class Form1 : Form
    {
        Graph<string> socialNetwork;
        public Form1()
        {
            InitializeComponent();
            socialNetwork = new Graph<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            countLabel.Text = "Count: " + socialNetwork.NumNodesGraph().ToString();
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            if (personTextBox.Text != "")
            {
                socialNetwork.AddNode(personTextBox.Text);
                countLabel.Text = "Count: " + socialNetwork.NumNodesGraph().ToString();
                personTextBox.Clear();
                personTextBoxOutput.Text = "Inserted";
            }
            else { personTextBoxOutput.Text = "Entry Field is Empty"; }
        }

        private void removePersonButton_Click(object sender, EventArgs e)
        {
            if (personTextBox.Text != "")
            {               
                socialNetwork.RemoveNode(personTextBox.Text);
                countLabel.Text = "Count: " + socialNetwork.NumNodesGraph().ToString();
                personTextBox.Clear();
                personTextBoxOutput.Text = "Removed";
            }
            else { personTextBoxOutput.Text = "Entry Field is Empty"; }

        }
       
        private void displayButton_Click(object sender, EventArgs e)
        {
            if (personTextBox.Text != "" && socialNetwork.ContainsGraph(personTextBox.Text) == true)
            {
                displayTextBox.Clear();
                List<string> relatedPeople = new List<string>();
                socialNetwork.BreadthFirstTraverse(personTextBox.Text, ref relatedPeople);
                foreach (String s in relatedPeople)
                {
                    displayTextBox.Text += s + "\n";
                }
                if (displayTextBox.Text.Contains(personTextBox.Text))
                {
                    displayTextBox.Select(displayTextBox.Text.IndexOf(personTextBox.Text), personTextBox.Text.Length);
                    displayTextBox.SelectionColor = Color.Red;
                }
            }
            else { personTextBoxOutput.Text = "Entry Field is Empty"; }
        }

        private void addDirectedEdgeButton_Click(object sender, EventArgs e)
        {
            if (directedEdgeFromTextBox.Text != "" && directedEdgeFromTextBox.Text != "")
            {
                if (socialNetwork.ContainsGraph(directedEdgeFromTextBox.Text) == true && socialNetwork.ContainsGraph(directedEdgeToTextBox.Text) == true)
                {
                    socialNetwork.AddEdge(directedEdgeFromTextBox.Text, directedEdgeToTextBox.Text);
                    addEdgeOutput.Text = "Submitted";
                }
                else
                    addEdgeOutput.Text = "Nodes do not exist";
                directedEdgeFromTextBox.Clear();
                directedEdgeToTextBox.Clear();
            }
            else { addEdgeOutput.Text = "Entry Field is Empty"; }
        }
    }
}
