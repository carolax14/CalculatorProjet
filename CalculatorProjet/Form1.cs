using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorProjet
{
    public partial class Form1 : Form
    {
        bool operandPerformed = false;
        string operand = "";
        double result = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // "NumEvent" permet d'affichier lors d'un click d'un sur un bouton sa valeur  
        private void NumEvent(object sender, EventArgs e)  
        {
            if (tbResult.Text == "0" || operandPerformed)
                tbResult.Clear();

            // Lors du click sur le bouton
            // La valeur inscrit sur le bouton s'affichera dans la textBox 
            // Pas d'opération effectuée
            Button btn = (Button)sender;
            tbResult.Text += btn.Text;
            operandPerformed = false;

        }

       // "operandEvent" permet d'affichier lors d'un click sur un bouton sa valeur
        private void OperandEvent(object sender, EventArgs e)
        {   
            // Opération effectuée
            // Lors du click sur le bouton
            // La variable "newOperand" est égal à la valeur du bouton selectionné
            operandPerformed = true;
            Button btn = (Button)sender;
            string newOperand = btn.Text;

            // Affiche dans le label : le détails de l'opération
            lbResult.Text = lbResult.Text + " " + tbResult.Text + " " + newOperand; 

            switch (operand)
            {
                case "+": tbResult.Text = (result + Double.Parse(tbResult.Text)).ToString(); break;
                case "-": tbResult.Text = (result - Double.Parse(tbResult.Text)).ToString(); break;
                case "x": tbResult.Text = (result * Double.Parse(tbResult.Text)).ToString(); break;
                case "÷": tbResult.Text = (result / Double.Parse(tbResult.Text)).ToString(); break;
                default: break;
            }

            //Affiche dans la texbox : Le résultat de l'opération
            // 
            result = Double.Parse(tbResult.Text);
            operand = newOperand;
        }

        private void panelKeys_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void btnClean_Click(object sender, EventArgs e)
        {
            tbResult.Text = "0"; // Vide la texbox 
            lbResult.Text = "";  // Vide le label 
            result = 0;          // Remet le conteur à 0
            operand = ""; 
        }

        private void btnEgal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string newOperand = btn.Text;

            //Vide le label des détails de l'opération
            /*lbResult.Text = "";*/

            lbResult.Text = lbResult.Text + " " + tbResult.Text + " " + newOperand;
            operandPerformed = true;

            switch (operand)
            {
                case "+": tbResult.Text = (result + Double.Parse(tbResult.Text)).ToString(); break;
                case "-": tbResult.Text = (result - Double.Parse(tbResult.Text)).ToString(); break;
                case "x": tbResult.Text = (result * Double.Parse(tbResult.Text)).ToString(); break;
                case "÷": tbResult.Text = (result / Double.Parse(tbResult.Text)).ToString(); break;
                default: break;
            }

            result = Double.Parse(tbResult.Text);
            tbResult.Text = result.ToString(); // Retourne sous chaine de caractère le contenu de "result"
            result = 0; // Remet le conteur à 0
            operand = "";
        }

        private void btnVirgule_Click(object sender, EventArgs e)
        {
            if (!operandPerformed && !tbResult.Text.Contains(","))
            {
                tbResult.Text += ",";
            }
            else if (operandPerformed)
            {
                tbResult.Text = "0";
            }

            if (!tbResult.Text.Contains(","))
            {
                tbResult.Text += ",";
            }

            operandPerformed = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (lbResult.Text == "")
            {
                if (tbResult.Text.Length > 0)
                {
                    tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length - 1, 1);
                }
            }
            if (lbResult.Text.Length > 0)
            {
                lbResult.Text = lbResult.Text.Remove(lbResult.Text.Length - 1, 1);
            }
            if (result == 0 && operand == "")
            {
                lbResult.Text = "";
            }

        }

        // Ajoute le signe "-" devant un chiffre
        private void btnSMoins_Click(object sender, EventArgs e)
        {
            if (tbResult.Text.Contains("-"))
            {
                tbResult.Text = tbResult.Text.Remove(0, 1);
            }
            else
            {
                tbResult.Text = "-" + tbResult.Text;
            }
        }
    }
}
