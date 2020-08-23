using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class MainForm : Form
    {
        private TextFile m_current_file;
        private const string m_program_name = "Text Editor v.1.0.0 | by John-9198";

        public MainForm()
        {
            InitializeComponent();
        }

        // =====================================================================================
        // Form methods
        // =====================================================================================

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_current_file != null) {
                if (m_current_file.IsSaved == false) // if file isn't saved
                {
                    DialogResult dialog_result = MessageBox.Show("Do you want to save the current file?", "Creating new file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialog_result == DialogResult.Yes) {
                        m_current_file.Save();
                    }
                    else if (dialog_result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            m_current_file = new TextFile();
            UpdateRichTextBoxState();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog_result;

            if (m_current_file != null)
            {
                if (m_current_file.IsSaved == false) // if file isn't saved
                {
                    dialog_result = MessageBox.Show("Do you want to save the current file?", "Opening existing file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialog_result == DialogResult.Yes)
                    {
                        m_current_file.Save();
                    }
                    else if (dialog_result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog_result = dialog.ShowDialog();
            if (dialog_result == DialogResult.OK)
            {
                m_current_file = new TextFile(dialog.FileName);
                UpdateRichTextBoxState();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_current_file != null)
            {
                if (m_current_file.IsSaved == false) // if file isn't saved
                {
                    DialogResult dialog_result = MessageBox.Show("Do you want to save the current file?", "Closing file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialog_result == DialogResult.Yes)
                    {
                        m_current_file.Save();
                    }
                    else if (dialog_result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            m_current_file = null;
            UpdateRichTextBoxState();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_current_file.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showStatusbarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setStyleToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox_text_TextChanged(object sender, EventArgs e)
        {
            if (m_current_file != null)
            {
                m_current_file.SetText(richTextBox_text.Text);
            }
        }

        // =====================================================================================
        // Other methods
        // =====================================================================================

        private void UpdateRichTextBoxState()
        {
            if (m_current_file == null) // if there is no opened file
            {
                richTextBox_text.Enabled = false;
                closeToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                richTextBox_text.Clear();
                this.Text = m_program_name;
            }
            else // if any file is opened
            {
                richTextBox_text.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                if (m_current_file.GetPath() == null)
                {
                    saveToolStripMenuItem.Enabled = false;
                    this.Text = m_program_name;
                }
                else
                {
                    saveToolStripMenuItem.Enabled = true;
                    this.Text = m_current_file.GetPath() + " | " + m_program_name;
                }
                saveAsToolStripMenuItem.Enabled = true;
                richTextBox_text.Text = m_current_file.GetText();
            }
        }
    }
}
