using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        private bool fileOpen = false;
        private bool textChanged = false;
        private string filter = "Tekstowy|*.txt";
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMain.Text = File.ReadAllText(ofd.FileName);
                fileOpen = true;
                FileName = ofd.FileName;
                textChanged = false;
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fileOpen)
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
                return;
            }

            File.WriteAllText(FileName, richTextBoxMain.Text);
            textChanged = false;
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textChanged)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisac zmiany?", "Plik zostal zmieniony", MessageBoxButtons.YesNoCancel);
                if(result == DialogResult.Yes)
                {
                    zapiszToolStripMenuItem_Click(sender, e);
                    return;
                }
            }
            FileName = "";
            richTextBoxMain.Text = "";
            textChanged = false;
            fileOpen = false;
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = filter;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richTextBoxMain.Text);
                textChanged = false;
                FileName = sfd.FileName;
            }
        }

        private void richTextBoxMain_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }

        private void zakonczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textChanged)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisac zmiany?", "Plik zostal zmieniony", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    zapiszToolStripMenuItem_Click(sender, e);
                }
                else if(result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void kolorkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config c = new Config();
            c.BgColor = richTextBoxMain.BackColor;
            c.FColor = richTextBoxMain.ForeColor;
            if(c.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMain.BackColor = c.BgColor;
                richTextBoxMain.ForeColor = c.FColor;
            }
        }
    }
}
