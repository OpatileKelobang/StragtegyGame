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

            // SHow grid
            textBoxGrid.Text = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (gameEngine.map.Grid[i, j].Equals(Map.FIELD_SYMBOL))
                    {
                        foreach (Unit u in gameEngine.map.UnitsOnMap)
                        {
                            if (u.X == i && u.Y == j)
                            {
                                /*if (u.Faction.Equals("RED"))
                                    textBoxGrid.AppendText(gameEngine.map.Grid[i, j], Color.Red);
                                else
                                    textBoxGrid.AppendText(gameEngine.map.Grid[i, j], Color.Green);
                                break;*/
                            }
                        }
                    }
                    else
                        textBoxGrid.AppendText(Map.FIELD_SYMBOL);
                    textBoxGrid.AppendText(" ");
                }
            }
        }

        public static class RichTexboxExtensions
        {
            public static void AppendText(this RichTextBox box, string text, Color color)
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = color;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
            }
        }
    }
}
