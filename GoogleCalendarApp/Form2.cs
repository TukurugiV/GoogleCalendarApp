using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleCalendarApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] ffArray = fonts.Families;
            foreach (FontFamily ff in ffArray)
            {
                fontBox.Items.Add(ff.Name);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ColorDialog_Click(object sender, EventArgs e)
        {
            ColorDialog cd  = new ColorDialog();
            cd.Color = Color.Black;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                ColorDialog.BackColor = cd.Color;
            }
        }
        public string fonts { get; private set; } = "MS UI Gothic";
        public Color fontColor { get; private set; } = Color.Black;
        private void submit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
