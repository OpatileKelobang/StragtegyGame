using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StragtegyGame
{
    public partial class Form1 : Form
    {
        MeleeUnit meleeUnit = new MeleeUnit();
        Random randomNumber = new Random();

        public Form1()
        {
            InitializeComponent();
            meleeUnit.move(randomNumber.Next(1, 21), randomNumber.Next(1, 21));
        }


        private void textBoxGrid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
