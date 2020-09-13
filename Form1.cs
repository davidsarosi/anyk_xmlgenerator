using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Szamlakezeles
{
    public partial class Form1 : Form
    {

        public SzamlaCollection SzamlaCollection { get; private set; }
        public Manager XMLManager { get; set; } = new Manager();
        public nyomtatvanyok XMLdocument { get; set; }
        public string Tol { get; set; }
        public string Ig { get; set; }

        public string xmlPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void ExcelLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // f�jl megnyit�sa
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string path = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
                ExcelTextbox.Text = path;
                if (ExcelTextbox.Text != "")
                {
                    SzamlaCollection = new SzamlaCollection(ExcelTextbox.Text);
                    string messeage = "K�sz";
                    MessageBox.Show(messeage);
                }
            }
            catch (Exception)
            {
                string messeage = "Nem kezelt hiba!";
                MessageBox.Show(messeage, "Figyelmeztet�s", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XMLLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // f�jl megnyit�sa
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string path = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
                XMLTextbox.Text = path;
                if (XMLTextbox.Text != "")
                {
                    XMLdocument = XMLManager.Beolvas(path);
                    xmlPath = path;
                    string messeage = "K�sz";
                    MessageBox.Show(messeage);
                }
            }
            catch (Exception)
            {
                string messeage = "Nem kezelt hiba!";
                MessageBox.Show(messeage, "Figyelmeztet�s", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            XMLManager.Tol = Tol;
            XMLManager.Ig = Ig;
            XMLManager.Osszefuz(XMLdocument, SzamlaCollection.SzamlaList);
            XMLManager.Export(XMLdocument,xmlPath);
            string messeage = "K�sz";
            MessageBox.Show(messeage);
        }

        private void BevallasiIdoszakTol_Click(object sender, EventArgs e)
        {
            if(BevallasiIdoszakTol.Text != "")
            {
                if (BevallasiIdoszakTol.Text[0] == '�')
                {
                    BevallasiIdoszakTol.Text = "";
                }
            }
        }

        private void BevallasiIdoszakIg_Click(object sender, EventArgs e)
        {
            if (BevallasiIdoszakIg.Text != "")
            {
                if (BevallasiIdoszakIg.Text[0] == '�')
                {
                    BevallasiIdoszakIg.Text = "";
                }
            }
        }

        private void BevallasiIdoszakTol_TextChanged(object sender, EventArgs e)
        {
            Tol = BevallasiIdoszakTol.Text;
        }

        private void BevallasiIdoszakIg_TextChanged(object sender, EventArgs e)
        {
            Ig = BevallasiIdoszakIg.Text;
        }
    }
}
