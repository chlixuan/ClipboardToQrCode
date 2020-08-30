//using MarkupConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace ClipboardToQrCode
{
    public partial class FormConverting : Form
    {
        public FormConverting()
        {
            InitializeComponent();
        }


        public string LoadingText
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        private void FormConverting_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        /// <summary>
        /// return time out in milisecond to close this window.
        /// </summary>
        /// <returns></returns>
        private void OnLoad()
        {
            try
            {

                IDataObject dataObject = Clipboard.GetDataObject();
                string text = (string)dataObject.GetData(DataFormats.Text);

                if (string.IsNullOrEmpty(text))
                {
                    LoadingText = "剪切板没有文本内容！";
                    return;
                }

                string msg = null;
                TranslateToQrCode(text, out msg);
                //OutQrInfo(text, out msg);
                LoadingText = msg;

            }
            catch (Exception ex)
            {
                LoadingText = ex.Message;
            }
        }




        #region 转二维码


        private bool OutQrInfo(string Info, out string errMsg)
        {
            errMsg = null;
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 8;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Bitmap image = qrCodeEncoder.Encode(Info, Encoding.UTF8);
                //string filepath = AppDomain.CurrentDomain.BaseDirectory;
                //image.Save(filepath + "/QRCodeImg/" + picFileName); //, System.Drawing.Imaging.ImageFormat.Gif);

                pictureBox1.Image = image;

                //由图片尺寸计算窗口大小
                this.Size = new Size(image.Size.Width + 60, image.Size.Height + 90);//图片尺寸加上窗体边框和图片外边距


                return true;
            }
            catch (Exception te)
            {
                errMsg = te.Message;
                return false;
            }

        }

        private bool TranslateToQrCode(string text, out string msg)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

            //字数决定分辨率
            //int size = Math.Min(5, Math.Max(1, text.Length / 32));
            qrCodeEncoder.QRCodeScale = 4;// 8 * size;// int.Parse(txtQRCodeScale.Text);// 2;
            qrCodeEncoder.QRCodeVersion = 4;// int.Parse(txtQRCodeVersion.Text);//2
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            Image mImage;

            string strExError = string.Empty;
            msg = "";
            int i = 4;
            //循环尝试，直到成功 或者 QRCodeVersion>=40
            for (; i < 40; i += 2)
            {
                try
                {
                    qrCodeEncoder.QRCodeVersion = i;
                    mImage = qrCodeEncoder.Encode(text,Encoding.UTF8);
                    pictureBox1.Image = mImage;

                    //由图片尺寸计算窗口大小
                    this.Size = new Size(mImage.Size.Width + 60, mImage.Size.Height + 90);//图片尺寸加上窗体边框和图片外边距

                    msg = "转换成二维码成功！";
                    break;
                }
                catch (Exception ex)
                {
                    msg = "转换成二维码失败！ " + ex.Message;
                    continue;
                }
            }

            return i < 40;
        }

        #endregion
    }
}
