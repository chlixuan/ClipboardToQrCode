using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace QRCodeLibExTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = int.Parse(txtQRCodeScale.Text);// 2;
            qrCodeEncoder.QRCodeVersion = int.Parse(txtQRCodeVersion.Text);//2
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            Image mImage;

            string strExError = string.Empty;
            try
            {
                mImage = qrCodeEncoder.Encode(txtText.Text);
                pictureBox1.Image = mImage;
                if (chkSave.Checked)
                {
                    mImage.Save(txtPath.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            txtPath.ReadOnly = !chkSave.Checked;
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            lblCount.Text = ""+txtText.Text.Length;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblCount.Text = "" + txtText.Text.Length;
        }
    }
}
