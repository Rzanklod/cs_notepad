using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Config : Form
    {
        private Color bgColor;
        private Color foreColor;
        public Color BgColor
        {
            get { return buttonBackground.BackColor; }
            set { buttonBackground.BackColor = value; }
        }
        public Color FColor
        {
            get { return buttonFont.BackColor; }
            set { buttonFont.BackColor = value; }
        }

        public Config()
        {
            InitializeComponent();
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = BgColor;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                BgColor = cd.Color;
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = FColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                FColor = cd.Color;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
