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
        GameEngine engine = new GameEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBoxGrid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            timer.Enabled = true;
            timer.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            timer.Stop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Exit Game",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
            engine.start();

            // SHow grid
            textBoxGrid.Text = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (!engine.map.Grid[i, j].Equals(Map.FIELD_SYMBOL))
                    {
                        foreach (Unit u in engine.map.UnitsOnMap)
                        {
                            if (u.X == i && u.Y == j)
                            {
                                if (u.Faction.Equals("RED"))
                                    textBoxGrid.AppendText(engine.map.Grid[i, j], Color.Red);
                                else
                                    textBoxGrid.AppendText(engine.map.Grid[i, j], Color.Green);
                                break;
                            }
                        }
                    }
                    else
                        textBoxGrid.AppendText(Map.FIELD_SYMBOL);

                    textBoxGrid.AppendText(" ");
                }
                textBoxGrid.AppendText("\n");
            }
        }
    }


    public static class RichTexboxExtensions
    {
        public static void AppendText(this RichTextBox textBoxGrid, string text, Color color)
        {
            textBoxGrid.SelectionStart = textBoxGrid.TextLength;
            textBoxGrid.SelectionLength = 0;
            textBoxGrid.SelectionColor = color;
            textBoxGrid.AppendText(text);
            textBoxGrid.SelectionColor = textBoxGrid.ForeColor;
        }
    }
}
