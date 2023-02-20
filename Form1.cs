using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditorProject
{
    public partial class Form1 : Form
    {
        string fileName = "";
        bool saveFlag = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtString.Font = fontDialog1.Font;
            }
        }

        private void backgoundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtString.BackColor = colorDialog1.Color;
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtString.ForeColor = colorDialog1.Color;
            }
        }

        private void breakTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtString.WordWrap == true)
            {
                txtString.WordWrap = false;
            }
            else
            {
                txtString.WordWrap = true;
            }

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtString.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtString.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtString.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtString.Cut();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtString.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtString.SelectAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFlag == false)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Do you want to save changes before exit or not?", "warning", MessageBoxButtons.YesNoCancel);
                if(dr == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        saveFileDialog1.ShowDialog();
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, txtString.Text);
                        saveFlag = true;
                    }
                    else
                    {
                        System.IO.File.WriteAllText(fileName, txtString.Text);
                        saveFlag = true;
                    }
                    Application.Exit();
                    
                }
                if (dr == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtString.Text);
                fileName = saveFileDialog1.FileName;
                saveFlag = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFlag ==false)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Do you want to save the changes?", "warning", MessageBoxButtons.YesNoCancel);
                if(dr == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        saveFileDialog1.ShowDialog();
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, txtString.Text);
                        saveFlag = true;
                    }
                    else
                    {
                        System.IO.File.WriteAllText(fileName, txtString.Text);
                        saveFlag = true;
                    }
                    openFileDialog1.ShowDialog();
                    txtString.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    fileName = openFileDialog1.FileName;
                    saveFlag = true;
                }
                if (dr == DialogResult.No)
                {
                    openFileDialog1.ShowDialog();
                    txtString.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                }
            }
            else
            {
                openFileDialog1.ShowDialog();
                txtString.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, txtString.Text);
                    fileName = saveFileDialog1.FileName;
                    saveFlag = true;
                }
            }
            else
            {
                System.IO.File.WriteAllText(fileName, txtString.Text);
                saveFlag = true;
            }
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            saveFlag = false;
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFlag == false)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Do you want save the changes?", "warning", MessageBoxButtons.YesNoCancel);
                if(dr == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        saveFileDialog1.ShowDialog();
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, txtString.Text);
                        saveFlag = true;
                    }
                    else
                    {
                        System.IO.File.WriteAllText(fileName, txtString.Text);
                        saveFlag = true;
                    }
                    txtString.Text = "";
                    fileName = "";
                    saveFlag = true;
                }
                if(dr == DialogResult.No)
                {
                    txtString.Text = "";
                    fileName = "";
                    saveFlag = true;
                }
            }
        }
    }
}
