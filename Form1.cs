using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable All

namespace StragtegyGame
{
    public partial class Form1 : Form
    {
        MeleeUnit meleeUnit = new MeleeUnit();
        Random randomNumber = new Random();
        GameEngine gameEngine = new GameEngine();

        public Form1()
        {
            InitializeComponent();
            meleeUnit.move(randomNumber.Next(1, 21), randomNumber.Next(1, 21));
            
        }


        private void textBoxGrid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameEngine.start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
            gameEngine.start();
        }
    }
}
