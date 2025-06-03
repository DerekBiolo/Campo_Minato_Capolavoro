using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato2
{
    public partial class FInformazioni : Form
    {
        public FInformazioni()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.BackgroundImage = Image.FromFile("bg_Info.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "Informazioni";
            this.StartPosition = FormStartPosition.CenterScreen;

            btn_Close.BackgroundImage = Image.FromFile("x.png");
            btn_Close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Close.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                e.Graphics.DrawImage(this.BackgroundImage, this.ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
