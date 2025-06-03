namespace CampoMinato2
{
    using System;
    using System.Runtime.CompilerServices;
    using NAudio.Wave;
    public partial class Form1 : Form
    {

        FImpostazioni impostazioni = new FImpostazioni();
        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.BackgroundImage = Image.FromFile("background_main.png"); //Immagine di sfondo
            this.BackgroundImageLayout = ImageLayout.Stretch; //Adatto l'immagine di sfondo alla finestra

            Inizializzazioni();
            InizializzazioneGrafica();
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

        private void btn_Impostazioni_Click(object sender, EventArgs e)
        {
            impostazioni.pulsantePremuto();
            impostazioni.ShowDialog();
        }

        private void InizializzazioneGrafica()
        {
            //metto a schermo intero
            this.FormBorderStyle = FormBorderStyle.None; //Tolgo il bordo della finestra
            this.WindowState = FormWindowState.Maximized; //Metto a schermo intero

            this.Text = "Campo Minato";

            //prendo i dati della finestra
            int width = this.Width = Screen.PrimaryScreen.Bounds.Width; //Larghezza della finestra
            int height = this.Height = Screen.PrimaryScreen.Bounds.Height; //Altezza della finestra

            //centro la picturebox "Entrate Esplosive"
            EntrateEsplosive.Left = (width - EntrateEsplosive.Width) / 2; //centro in orizzontale
            EntrateEsplosive.Top = ((height - EntrateEsplosive.Height) / 2) - 350; //centro in verticale

            //dim pulsanti
            btn_esci.Width = 452;
            btn_esci.Height = 190;
            btn_gioca.Width = 452;
            btn_gioca.Height = 190;
            btn_Impostazioni.Width = 452;
            btn_Impostazioni.Height = 190;


            //pulsante esci
            btn_esci.Left = (width - btn_esci.Width) / 2; //centro in orizzontale
            btn_esci.Top = ((height - btn_esci.Height) / 2) + 420; //centro in verticale
            btn_esci.BackgroundImage = Image.FromFile("Esci.png"); // immagine
            btn_esci.BackgroundImageLayout = ImageLayout.Stretch; //adatto l'immagine al pulsante
            btn_esci.FlatStyle = FlatStyle.Flat; //pulsante senza bordo
            btn_esci.FlatAppearance.BorderSize = 0; //pulsante senza bordo
            btn_esci.FlatAppearance.MouseOverBackColor = Color.Transparent;

            //pulsante gioca
            btn_gioca.Left = (width - btn_gioca.Width) / 2; //centro in orizzontale
            btn_gioca.Top = ((height - btn_gioca.Height) / 2 - 20); //centro in verticale
            btn_gioca.BackgroundImage = Image.FromFile("btn_play.png"); // immagine
            btn_gioca.BackgroundImageLayout = ImageLayout.Stretch; //adatto l'immagine al pulsante
            btn_gioca.FlatStyle = FlatStyle.Flat; //pulsante senza bordo
            btn_gioca.FlatAppearance.BorderSize = 0; //pulsante senza bordo
            btn_gioca.FlatAppearance.MouseOverBackColor = Color.Transparent; //colore del pulsante al passaggio del mouse



            //pulsante impostazioni
            btn_Impostazioni.Left = (width - btn_Impostazioni.Width) / 2; //centro in orizzontale
            btn_Impostazioni.Top = ((height - btn_Impostazioni.Height) / 2) +200; //centro in verticale
            btn_Impostazioni.BackgroundImage = Image.FromFile("Impostazioni.png"); // immagine
            btn_Impostazioni.BackgroundImageLayout = ImageLayout.Stretch; //adatto l'immagine al pulsante
            btn_Impostazioni.FlatStyle = FlatStyle.Flat; //pulsante senza bordo
            btn_Impostazioni.FlatAppearance.BorderSize = 0; //pulsante senza bordo
            btn_Impostazioni.FlatAppearance.MouseOverBackColor = Color.Transparent;

        }
        public void Inizializzazioni()
        {
            impostazioni.Show();
            impostazioni.Hide();
        }

        private void btn_gioca_Click(object sender, EventArgs e)
        {
            FGioca gioca = new FGioca(impostazioni, this);

            impostazioni.pulsantePremuto();
            gioca.Show();
        }

        private void btn_esci_Click(object sender, EventArgs e)
        {
            impostazioni.pulsantePremuto();
            Application.Exit();
        }
    }
}
