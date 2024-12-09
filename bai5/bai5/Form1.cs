using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void loadFont()
        {
            foreach (FontFamily fontFamily in new InstalledFontCollection().Families)
            {
                cbxFont.Items.Add(fontFamily.Name);
            }
            
            cbxFont.SelectedItem = "Tahoma";
        }

        private void loadSize()
        {
            int[] sizeValues = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cbxSize.ComboBox.DataSource = sizeValues; cbxSize.SelectedItem = 14;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog(); fontDlg.ShowColor = true; 
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true; 
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                rtbVanBan.ForeColor = fontDlg.Color;
                rtbVanBan.Font = fontDlg.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFont();
            loadSize();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rtbVanBan.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                String savedFilePath = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(selectedFileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                    }
                    MessageBox.Show("Tập tin đã được mở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void newDocMenuStrip_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                saveFileDialog.Title = "Save File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        if (Path.GetExtension(filePath).ToLower() == ".txt")
                        {
                            File.WriteAllText(filePath, rtbVanBan.Text);
                        }
                        else if (Path.GetExtension(filePath).ToLower() == ".rtf")
                        {
                            rtbVanBan.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        }
                        MessageBox.Show("Tập tin đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi trong quá trình lưu tập tin:e: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

       

       
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBold_Click_1(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Bold)
                {
                    style &= ~FontStyle.Bold;
                }
                else
                {
                    style |= FontStyle.Bold;

                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }

        private void btnItalic_Click_1(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Italic)
                {
                    style &= ~FontStyle.Italic;
                }
                else
                {
                    style |= FontStyle.Italic;

                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }

        private void btnUnderline_Click_1(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Underline)
                {
                    style &= ~FontStyle.Underline;
                }
                else
                {
                    style |= FontStyle.Underline;

                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                saveFileDialog.Title = "Save File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        if (Path.GetExtension(filePath).ToLower() == ".txt")
                        {
                            File.WriteAllText(filePath, rtbVanBan.Text);
                        }
                        else if (Path.GetExtension(filePath).ToLower() == ".rtf")
                        {
                            rtbVanBan.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        }
                        MessageBox.Show("Tập tin đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi trong quá trình lưu tập tin:e: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
        }

        private void cbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
                ApplyFontChange(null, Convert.ToInt32(cbxSize.SelectedItem));
        }
        private void ApplyFontChange(string fontName, int? fontSize)
        {
            Font currentFont = rtbVanBan.SelectionFont ?? rtbVanBan.Font;
            string newFontName = fontName ?? currentFont.Name;
            float newFontSize = fontSize ?? currentFont.Size;

            rtbVanBan.SelectionFont = new Font(newFontName, newFontSize, currentFont.Style);
        }

        private void cbxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
                ApplyFontChange(cbxFont.SelectedItem.ToString(), null);
        }
    }
}
