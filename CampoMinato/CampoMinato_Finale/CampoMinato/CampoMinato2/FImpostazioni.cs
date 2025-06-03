using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;


namespace CampoMinato2
{
    public partial class FImpostazioni : Form
    {

        private AudioFileReader audio; // lettore audio di NAudio (libreria installata)
        private WaveOutEvent player; // riproduttore dell'audio

        public AudioFileReader suono;
        public WaveOutEvent playerSuono;



        public FImpostazioni()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.BackgroundImage = Image.FromFile("bgImpo.png"); //Immagine di sfondo
            this.BackgroundImageLayout = ImageLayout.Stretch; //Adatto l'immagine di sfondo alla finestra

            Inizializzazioni(); // funzione per le inizializzazioni
            caricaImpostazioniSalvate(); // carico le impostazioni salvate all'avvio del programma
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
            //Fullscreen
            this.FormBorderStyle = FormBorderStyle.None; //no bordo
            this.WindowState = FormWindowState.Maximized; //fullscreen
            this.TopMost = true; //finesra in primo piano

            //Centramenti
            int larghezza = this.Width = Screen.PrimaryScreen.Bounds.Width; // larghezza
            int altezza = this.Height = Screen.PrimaryScreen.Bounds.Height; // altezza

            trk_AudioMusica.Left = (larghezza - trk_AudioMusica.Width) / 2;
            trk_AudioMusica.Top = 450;
            trk_Sounds.Left = (larghezza - trk_Sounds.Width) / 2;
            trk_Sounds.Top = 685;


            //pulsanti mute / max vol
            btn_MuteMusic.Left = trk_AudioMusica.Left - btn_MuteMusic.Width - 57;
            btn_MuteMusic.Top = trk_AudioMusica.Top - 5;
            btn_MaxMusic.Left = trk_AudioMusica.Left + trk_AudioMusica.Width + 57;
            btn_MaxMusic.Top = trk_AudioMusica.Top - 5;

            //pulsanti mute / max vol suon
            btn_MuteSounds.Left = trk_Sounds.Left - btn_MuteSounds.Width - 57;
            btn_MuteSounds.Top = trk_Sounds.Top - 5;
            btn_MaxSounds.Left = trk_Sounds.Left + trk_Sounds.Width + 57;
            btn_MaxSounds.Top = trk_Sounds.Top - 5;

            //pulsante esci
            btn_Esci.Width = 150;
            btn_Esci.Height = 150;
            btn_Esci.Left = 77;
            btn_Esci.Top = 77;
            btn_Esci.BackgroundImage = Image.FromFile("home.png");
            btn_Esci.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Esci.FlatStyle = FlatStyle.Flat;
            btn_Esci.FlatAppearance.BorderSize = 0;
            btn_Esci.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Esci.FlatAppearance.MouseDownBackColor = Color.Transparent;



            //MUSICA IMPOSTAZIONI
            trk_AudioMusica.Minimum = 0;
            trk_AudioMusica.Maximum = 100;
            trk_AudioMusica.Value = 50;
            trk_AudioMusica.TickFrequency = 10;
            trk_AudioMusica.Scroll += Trk_AudioMusica_Scroll;

            audio = new AudioFileReader("musica.mp3");
            player = new WaveOutEvent();
            player.Init(audio);
            //la musica suona in loop
            player.Play();
            player.PlaybackStopped += (s, e) => { audio.Position = 0; player.Play(); };

            player.Volume = trk_AudioMusica.Value / 100f; // Imposta il volume iniziale

            //prendo l'immagine di background del pulsante dalla cartella del progetto
            btn_MaxMusic.BackgroundImage = Image.FromFile("maxvol.png");
            btn_MaxMusic.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MuteMusic.BackgroundImage = Image.FromFile("muta.png");
            btn_MuteMusic.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MaxMusic.FlatStyle = FlatStyle.Flat;
            btn_MaxMusic.FlatAppearance.BorderSize = 0;
            btn_MuteMusic.FlatStyle = FlatStyle.Flat;
            btn_MuteMusic.FlatAppearance.BorderSize = 0;
            btn_MaxMusic.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_MuteMusic.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_MaxMusic.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_MuteMusic.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_MaxSounds.BackgroundImage = Image.FromFile("maxvol.png");
            btn_MaxSounds.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MuteSounds.BackgroundImage = Image.FromFile("muta.png");
            btn_MuteSounds.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MaxSounds.FlatStyle = FlatStyle.Flat;
            btn_MaxSounds.FlatAppearance.BorderSize = 0;
            btn_MuteSounds.FlatStyle = FlatStyle.Flat;
            btn_MuteSounds.FlatAppearance.BorderSize = 0;
            btn_MaxSounds.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_MuteSounds.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_MaxSounds.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_MuteSounds.FlatAppearance.MouseDownBackColor = Color.Transparent;

            //SUONI IMPOSTAZIONI
            trk_Sounds.Minimum = 0;
            trk_Sounds.Maximum = 100;
            trk_Sounds.Value = 50;
            trk_Sounds.TickFrequency = 10;
            trk_Sounds.Scroll += Trk_Sounds_Scroll;

            suono = new AudioFileReader("buttonSounds.mp3");
            player = new WaveOutEvent();
            player.Init(suono);
        }

        private void Trk_Sounds_Scroll(object? sender, EventArgs e)
        {
            if (suono != null)
            {
                suono.Volume = trk_Sounds.Value / 100f;
            }
        }

        private void Trk_AudioMusica_Scroll(object? sender, EventArgs e)
        {
            if (audio != null)
            {
                audio.Volume = trk_AudioMusica.Value / 100f;
            }
        }

        private void FImpostazioni_Load(object sender, EventArgs e)
        {
            trk_AudioMusica_Scroll(sender, e);
            trk_Sounds_Scroll(sender, e);
        }

        private void trk_AudioMusica_Scroll(object sender, EventArgs e)
        {
            lbl_Musica.Text = trk_AudioMusica.Value.ToString();
            float percentuale = (float)(trk_AudioMusica.Value - trk_AudioMusica.Minimum) / (trk_AudioMusica.Maximum - trk_AudioMusica.Minimum);
            int lunghezzaUtilizzabile = trk_AudioMusica.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_AudioMusica.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Musica.Location = new Point(posizioneX - (lbl_Musica.Width / 2), trk_AudioMusica.Top - lbl_Musica.Height);
            SalvaImpostazioni();
        }

        private void trk_Sounds_Scroll(object sender, EventArgs e)
        {
            lbl_Suoni.Text = trk_Sounds.Value.ToString();
            float percentuale = (float)(trk_Sounds.Value - trk_Sounds.Minimum) / (trk_Sounds.Maximum - trk_Sounds.Minimum);
            int lunghezzaUtilizzabile = trk_Sounds.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_Sounds.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Suoni.Location = new Point(posizioneX - (lbl_Suoni.Width / 2), trk_Sounds.Top - lbl_Suoni.Height);
            SalvaImpostazioni();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Controlla se l'utente ha richiesto la chiusura (non l'applicazione che termina)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;   // Annulla la chiusura
                this.Hide();       // Nasconde la finestra
            }
        }

        private void btn_MuteMusic_Click(object sender, EventArgs e)
        {
            trk_AudioMusica.Value = 0; // Imposta il volume a 0
            audio.Volume = 0; // Imposta il volume a 0
            lbl_Musica.Text = trk_AudioMusica.Value.ToString();
            float percentuale = (float)(trk_AudioMusica.Value - trk_AudioMusica.Minimum) / (trk_AudioMusica.Maximum - trk_AudioMusica.Minimum);
            int lunghezzaUtilizzabile = trk_AudioMusica.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_AudioMusica.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Musica.Location = new Point(posizioneX, trk_AudioMusica.Top - lbl_Musica.Height);

            pulsantePremuto();
            SalvaImpostazioni();
        }

        private void btn_MaxMusic_Click(object sender, EventArgs e)
        {
            trk_AudioMusica.Value = 100; // Imposta il volume a 100
            audio.Volume = 1; // Imposta il volume a 100
            lbl_Musica.Text = trk_AudioMusica.Value.ToString();
            float percentuale = (float)(trk_AudioMusica.Value - trk_AudioMusica.Minimum) / (trk_AudioMusica.Maximum - trk_AudioMusica.Minimum);
            int lunghezzaUtilizzabile = trk_AudioMusica.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_AudioMusica.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Musica.Location = new Point(posizioneX, trk_AudioMusica.Top - lbl_Musica.Height);

            pulsantePremuto();
            SalvaImpostazioni();
        }

        private void btn_MuteSounds_Click(object sender, EventArgs e)
        {
            trk_Sounds.Value = 0; // Imposta il volume a 0
            suono.Volume = 0; // Imposta il volume a 0
            lbl_Suoni.Text = trk_Sounds.Value.ToString();
            float percentuale = (float)(trk_Sounds.Value - trk_Sounds.Minimum) / (trk_Sounds.Maximum - trk_Sounds.Minimum);
            int lunghezzaUtilizzabile = trk_Sounds.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_Sounds.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Suoni.Location = new Point(posizioneX, trk_Sounds.Top - lbl_Suoni.Height);

            pulsantePremuto();
            SalvaImpostazioni();
        }

        private void btn_MaxSounds_Click(object sender, EventArgs e)
        {
            trk_Sounds.Value = 100; // Imposta il volume a 100
            suono.Volume = 1; // Imposta il volume a 100
            lbl_Suoni.Text = trk_Sounds.Value.ToString();
            float percentuale = (float)(trk_Sounds.Value - trk_Sounds.Minimum) / (trk_Sounds.Maximum - trk_Sounds.Minimum);
            int lunghezzaUtilizzabile = trk_Sounds.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_Sounds.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Suoni.Location = new Point(posizioneX, trk_Sounds.Top - lbl_Suoni.Height);

            pulsantePremuto();
            SalvaImpostazioni();
        }

        public void pulsantePremuto()
        {
            // trigger del suono quando si preme un pulsante
            if (playerSuono != null)
            {
                playerSuono.Stop();
                playerSuono.Dispose();
            }
            playerSuono = new WaveOutEvent();
            playerSuono.Init(new AudioFileReader("buttonSounds.mp3"));
            playerSuono.Volume = trk_Sounds.Value / 100f; // volume con trackbar
            playerSuono.Play();
        }

        public void cellaCliccata()
        {
            if (playerSuono != null)
            {
                playerSuono.Stop();
                playerSuono.Dispose();
            }

            playerSuono = new WaveOutEvent();
            playerSuono.Init(new AudioFileReader("btnGameplay.mp3"));
            playerSuono.Volume = trk_Sounds.Value / 100f;
            playerSuono.Play();
        }

        private void btn_Esci_Click(object sender, EventArgs e)
        {
            pulsantePremuto();
            this.Hide(); // Nasconde la finestra delle impostazioni
        }

        private void SalvaImpostazioni()
        {
            //se non ce il file lo crea
            string filePath = "impostazioni.txt";
            if (!System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(filePath))
                {
                    sw.WriteLine(trk_AudioMusica.Value);
                    sw.WriteLine(trk_Sounds.Value);
                }
            }
            else
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false))
                {
                    sw.WriteLine(trk_AudioMusica.Value);
                    sw.WriteLine(trk_Sounds.Value);
                }
            }
        }

        private void caricaImpostazioniSalvate()
        {
            //quando carico il gioco leggo i valori
            string filePath = "impostazioni.txt";
            if (System.IO.File.Exists(filePath))
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    if (int.TryParse(lines[0], out int musicaVolume))
                    {
                        trk_AudioMusica.Value = musicaVolume;
                        audio.Volume = musicaVolume / 100f;
                    }
                    if (int.TryParse(lines[1], out int suoniVolume))
                    {
                        trk_Sounds.Value = suoniVolume;
                        suono.Volume = suoniVolume / 100f;
                    }
                }
            }
        }
    }
}
