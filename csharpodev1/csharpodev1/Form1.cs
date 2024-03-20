using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace csharpodev1
{
    public partial class Form1 : Form
    {
        private string dosyaYolu = "";
        public Form1()
        {
            InitializeComponent();

            kesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            kopyalaToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            yapıştırToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            çıkışToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            dosyaAçToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            dosyaKaydetToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kes();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kopyala();
        }

        private void yapıştırToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Yapıştır();
        }
        
        private void Kes()
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (richTextBox1.SelectedText != "")
                {
                    Clipboard.SetText(richTextBox1.SelectedText);
                    richTextBox1.SelectedText = "";
                }
            }
        }

        private void Kopyala()
        {
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void Yapıştır()
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (richTextBox1.SelectedText != "")
                {
                    Clipboard.SetText(richTextBox1.SelectedText);
                    richTextBox1.SelectedText = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (dosyaYolu != "" && richTextBox1.Text != File.ReadAllText(dosyaYolu))
            {
                result = MessageBox.Show("Dosyayı kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    File.WriteAllText(dosyaYolu, richTextBox1.Text);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            else if (dosyaYolu == "" && richTextBox1.Text != "")
            {
                result = MessageBox.Show("Dosyayı kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            dosyaYolu = saveFileDialog.FileName;
                            File.WriteAllText(dosyaYolu, richTextBox1.Text);
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Application.Exit();
        }

   

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void arkaPlanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog.Color;
            }
        }

        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dosyaYolu = openFileDialog.FileName;
                    richTextBox1.Text = File.ReadAllText(dosyaYolu);
                }
            }
        }
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = saveFileDialog.FileName;

                    File.WriteAllText(dosyaYolu, "");

                    richTextBox1.LoadFile(dosyaYolu, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dosyaYolu == "")
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dosyaYolu = saveFileDialog.FileName;
                        File.WriteAllText(dosyaYolu, richTextBox1.Text);
                    }
                }
            }
            else
            {
                File.WriteAllText(dosyaYolu, richTextBox1.Text);
            }
        }
    }
}