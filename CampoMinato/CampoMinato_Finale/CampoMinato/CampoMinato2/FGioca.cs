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
    public partial class FGioca : Form
    {
        int valoreScroll;

        public double grandezza { get; private set; }
        public int bombe { get; private set; }

        FImpostazioni impostazioni;
        Form1 f1;
        public FGioca(FImpostazioni i, Form1 f)
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.BackgroundImage = Image.FromFile("bgGioca.png"); //Immagine di sfondo
            this.BackgroundImageLayout = ImageLayout.Stretch; //Adatto l'immagine di sfondo alla finestra

            Inizializzazioni();

            impostazioni = i;
            f1 = f;
            tbr_Bombe.Value = 1;
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

        private void Inizializzazioni()
        {
            this.FormBorderStyle = FormBorderStyle.None; //Tolgo il bordo della finestra
            this.WindowState = FormWindowState.Maximized; //Metto a schermo intero
            this.Text = "Imposta partita";

            //DIMENSIONI FORM
            int width = this.Width = Screen.PrimaryScreen.Bounds.Width;
            int height = this.Height = Screen.PrimaryScreen.Bounds.Height;

            //POSIZIONI
            //Titlo grandezza griglia
            lbl_grandezzagriglia.Left = ((width - lbl_grandezzagriglia.Width) / 2) - 270;
            lbl_grandezzagriglia.Top = ((height - lbl_grandezzagriglia.Height) / 2) - 50;

            //Scrollbar griglia
            tbr_Griglia.Left = ((width - tbr_Griglia.Width) / 2) - 275;
            tbr_Griglia.Top = ((height - tbr_Griglia.Height) / 2);

            //Label scrollbar
            lbl_10x10.Left = (width / 2) - (tbr_Griglia.Width) - 62;
            lbl_10x10.Top = ((height - tbr_Griglia.Height) / 2) + 25;
            lbl_30x30.Left = tbr_Griglia.Left + (tbr_Griglia.Width / 2) - (lbl_30x30.Width / 2) + 3;
            lbl_30x30.Top = ((height - tbr_Griglia.Height) / 2) + 25;
            lbl_50x50.Left = ((width / 2) - (tbr_Griglia.Width / 2)) + 96;
            lbl_50x50.Top = ((height - tbr_Griglia.Height) / 2) + 25;

            //Titolo numero bombe
            lbl_Bombe.Left = ((width - lbl_Bombe.Width) / 2) - 270;
            lbl_Bombe.Top = lbl_grandezzagriglia.Top + 190;

            //Scrollbar numero bombe
            tbr_Bombe.Left = ((width - tbr_Bombe.Width) / 2) - 275;
            tbr_Bombe.Top = lbl_Bombe.Top + 50;

            //Label scrollbar numero bombe
            lbl_10.Left = (width / 2) - (tbr_Bombe.Width) - 62;
            lbl_10.Top = tbr_Bombe.Top + 25;
            lbl_25.Left = tbr_Bombe.Left + (tbr_Bombe.Width / 2) - (lbl_25.Width / 2) + 3;
            lbl_25.Top = tbr_Bombe.Top + 25;
            lbl_50.Left = ((width / 2) - (tbr_Bombe.Width / 2)) + 96;
            lbl_50.Top = tbr_Bombe.Top + 25;

            //Pulsante Esci
            btn_Esci.Left = (width / 4) + 47;
            btn_Esci.Top = tbr_Bombe.Top + 180;

            btn_Esci.BackgroundImage = Image.FromFile("Esci.png");
            btn_Esci.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Esci.FlatStyle = FlatStyle.Flat;
            btn_Esci.FlatAppearance.BorderSize = 0;
            btn_Esci.FlatAppearance.MouseOverBackColor = Color.Transparent;


            //Pulsante Gioca
            btn_Gioca.Left = btn_Esci.Left + btn_Esci.Width + 20;
            btn_Gioca.Top = tbr_Bombe.Top + 180;

            btn_Gioca.BackgroundImage = Image.FromFile("btn_play.png");
            btn_Gioca.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Gioca.FlatStyle = FlatStyle.Flat;
            btn_Gioca.FlatAppearance.BorderSize = 0;
            btn_Gioca.FlatAppearance.MouseOverBackColor = Color.Transparent;

            //lo posiziono nell'altra meta dello schermo
            btn_Carica.Left = (width / 2) - (btn_Carica.Width / 2) + 100;
            btn_Carica.Top = lbl_grandezzagriglia.Top;
            btn_Carica.BackgroundImage = Image.FromFile("Carica.png");
            btn_Carica.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Carica.FlatStyle = FlatStyle.Flat;
            btn_Carica.FlatAppearance.BorderSize = 0;
            btn_Carica.FlatAppearance.MouseOverBackColor = Color.Transparent;


        }

        private void btn_Esci_Click(object sender, EventArgs e)
        {
            impostazioni.pulsantePremuto();
            this.Close();
        }

        private void btn_Gioca_Click(object sender, EventArgs e)
        {
            impostazioni.pulsantePremuto();
            int gScelta = tbr_Griglia.Value;
            int bScelta = valoreScroll;

            switch (gScelta)
            {
                case 1:
                    grandezza = 0.5;
                    break;

                case 2:
                    grandezza = 1;
                    break;

                case 3:
                    grandezza = 1.5;
                    break;
            }

            switch (bScelta)
            {
                case 0:
                    bombe = 10;
                    break;
                case 1:
                    bombe = 10;
                    break;
                case 2:
                    bombe = 15;
                    break;
                case 3:
                    bombe = 25;
                    break;
            }

            var tabella = new FPartita(grandezza, bombe, impostazioni, f1);
            tabella.Show();
            this.Close();
        }

        private void tbr_Bombe_Scroll(object sender, EventArgs e)
        {
            valoreScroll = tbr_Bombe.Value;
        }

        private void btn_Carica_Click(object sender, EventArgs e)
        {
            FCarica carica = new FCarica(impostazioni, f1);
            impostazioni.pulsantePremuto();
            carica.ShowDialog();
        }
    }
}
