using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class matchinggame : Form
    {
        Random random = new Random();
        // and each icon appears twice in this list
        List<string> icons = new List<string>()//crée une liste de chaînes de caractères
        {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
        };
        Label first_click=null;
        Label second_click=null;

        public matchinggame()
        {
            InitializeComponent();
            assignIconsToSquares();
            timerClock.Start();
            

        }
        int score=0;
        int elapsedSeconds=0;
        int pairesTotal=8; // 16labels =8paires
        private void assignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {

                if (control is Label)
                {

                    int nombreicon = icons.Count;//taille du la liste
                    int x = random.Next(0, nombreicon);
                    control.Text = icons[x];
                    icons.RemoveAt(x);
                    control.ForeColor = control.BackColor;
                    control.Click += label1_Click;//cree une line evtre les label est le evenement lable_click
                }


            }
        }



        private void matchinggame_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedlabel = sender as Label;
            if(sender is Label)
            {
                if (clickedlabel== null)
                {
                    return;
                }
                if (clickedlabel.ForeColor == Color.Black)
                {
                    return;
                }
                if (first_click == null)
                {
                    first_click = clickedlabel;
                    first_click.ForeColor = Color.Black;

                    return;
                }
                if (second_click == null)
                {
                    second_click = clickedlabel;
                    second_click.ForeColor = Color.Black;

                    return;
                }
                timer1.Start();

                if (first_click.Text == second_click.Text)
                {
                    score++;
                    if (score == pairesTotal)
                    {
                        timerClock.Stop();
                        MessageBox.Show("Bravo ! Terminé en " + elapsedSeconds + " secondes.");
                       
                    }
                    first_click = null;
                    second_click = null;
                   
                }
                else
                {
                    timer1.Start();  
                }
                return;


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            first_click.ForeColor= first_click.BackColor;
            second_click.ForeColor= first_click.BackColor;
            //reset
            first_click = null;
            second_click = null;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
        }
    }
}