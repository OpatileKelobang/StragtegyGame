using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Reshaper disable all

namespace StragtegyGame
{
    public partial class Form1 : Form
    {
        GameEngine engine = new GameEngine();
        ArrayList addToList;
        int x = 0, y = 0, health = 0, speed = 0, attackRange = 0;
        string faction = null, symbol = null, unitName = null;
        bool attack = false;

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

            // Show grid
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

        private void resumeGame()
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
            //engine.start(); do not call start

            MessageBox.Show("Left Read method and ready to display grid");

            // Update Grid Manually
            textBoxGrid.Text = "";

            MessageBox.Show("Cleared Grid");

            //foreach (Unit u in engine.map.UnitsOnMap )
            {
                MessageBox.Show(""+engine.map.UnitsOnMap.Count);
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {

            FileStream outFile = null;
            StreamWriter writer = null;

            try
            {
                outFile = new FileStream(@"Files\savegame.txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(outFile);

                foreach (Unit u in engine.map.UnitsOnMap)
                {
                    writer.WriteLine(u.X);
                    writer.WriteLine(u.Y);
                    writer.WriteLine(u.Health);
                    writer.WriteLine(u.Speed);
                    writer.WriteLine(u.Attack);
                    writer.WriteLine(u.AttackRange);
                    writer.WriteLine(u.Faction);
                    writer.WriteLine(u.Symbol);
                    writer.WriteLine(u.UnitName);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

                if (outFile != null)
                {
                    outFile.Close();
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            FileStream inFile = null;
            StreamReader reader = null;
            engine.map.UnitsOnMap.Clear();
            try
            {
                inFile = new FileStream(@"Files\savegame.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);

                while (reader != null)
                {
                    x = int.Parse(reader.ReadLine());
                    y = int.Parse(reader.ReadLine());
                    health = int.Parse(reader.ReadLine());
                    speed = int.Parse(reader.ReadLine());
                    attack = Boolean.Parse(reader.ReadLine());
                    attackRange = int.Parse(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    unitName = reader.ReadLine();

                    if (symbol.Equals("R"))
                    {
                        RangedUnit r = new RangedUnit(x, y, health, speed, attack, attackRange, faction, symbol,
                            unitName);

                       // MessageBox.Show(r.toString());

                        engine.map.UnitsOnMap.Add(r);
                    }
                    else
                    {
                        MeleeUnit m = new MeleeUnit(x, y, health, speed, attack, attackRange, faction, symbol,
                            unitName);

                       // MessageBox.Show(m.toString());

                        engine.map.UnitsOnMap.Add(m);
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (inFile != null)
                {
                    inFile.Close();
                    resumeGame();
                }
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
