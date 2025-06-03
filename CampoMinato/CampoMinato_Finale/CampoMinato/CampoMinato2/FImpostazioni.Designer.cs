namespace CampoMinato2
{
    partial class FImpostazioni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trk_AudioMusica = new TrackBar();
            lbl_Musica = new Label();
            btn_MuteMusic = new Button();
            btn_MaxMusic = new Button();
            btn_MaxSounds = new Button();
            btn_MuteSounds = new Button();
            lbl_Suoni = new Label();
            trk_Sounds = new TrackBar();
            btn_Esci = new Button();
            ((System.ComponentModel.ISupportInitialize)trk_AudioMusica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trk_Sounds).BeginInit();
            SuspendLayout();
            // 
            // trk_AudioMusica
            // 
            trk_AudioMusica.BackColor = Color.FromArgb(195, 195, 197);
            trk_AudioMusica.Cursor = Cursors.Hand;
            trk_AudioMusica.Location = new Point(201, 143);
            trk_AudioMusica.Margin = new Padding(0);
            trk_AudioMusica.Maximum = 100;
            trk_AudioMusica.Name = "trk_AudioMusica";
            trk_AudioMusica.Size = new Size(750, 56);
            trk_AudioMusica.TabIndex = 0;
            trk_AudioMusica.Value = 100;
            trk_AudioMusica.Scroll += trk_AudioMusica_Scroll;
            // 
            // lbl_Musica
            // 
            lbl_Musica.AutoSize = true;
            lbl_Musica.BackColor = Color.Transparent;
            lbl_Musica.Font = new Font("Cooper Black", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Musica.Location = new Point(171, 120);
            lbl_Musica.Name = "lbl_Musica";
            lbl_Musica.Size = new Size(119, 39);
            lbl_Musica.TabIndex = 1;
            lbl_Musica.Text = "label1";
            // 
            // btn_MuteMusic
            // 
            btn_MuteMusic.BackColor = Color.Transparent;
            btn_MuteMusic.Location = new Point(114, 143);
            btn_MuteMusic.Name = "btn_MuteMusic";
            btn_MuteMusic.Size = new Size(65, 65);
            btn_MuteMusic.TabIndex = 4;
            btn_MuteMusic.UseVisualStyleBackColor = false;
            btn_MuteMusic.Click += btn_MuteMusic_Click;
            // 
            // btn_MaxMusic
            // 
            btn_MaxMusic.BackColor = Color.Transparent;
            btn_MaxMusic.Location = new Point(647, 143);
            btn_MaxMusic.Name = "btn_MaxMusic";
            btn_MaxMusic.Size = new Size(65, 65);
            btn_MaxMusic.TabIndex = 5;
            btn_MaxMusic.UseVisualStyleBackColor = false;
            btn_MaxMusic.Click += btn_MaxMusic_Click;
            // 
            // btn_MaxSounds
            // 
            btn_MaxSounds.BackColor = Color.Transparent;
            btn_MaxSounds.Location = new Point(647, 255);
            btn_MaxSounds.Name = "btn_MaxSounds";
            btn_MaxSounds.Size = new Size(65, 65);
            btn_MaxSounds.TabIndex = 10;
            btn_MaxSounds.UseVisualStyleBackColor = false;
            btn_MaxSounds.Click += btn_MaxSounds_Click;
            // 
            // btn_MuteSounds
            // 
            btn_MuteSounds.BackColor = Color.Transparent;
            btn_MuteSounds.Location = new Point(114, 255);
            btn_MuteSounds.Name = "btn_MuteSounds";
            btn_MuteSounds.Size = new Size(65, 65);
            btn_MuteSounds.TabIndex = 9;
            btn_MuteSounds.UseVisualStyleBackColor = false;
            btn_MuteSounds.Click += btn_MuteSounds_Click;
            // 
            // lbl_Suoni
            // 
            lbl_Suoni.AutoSize = true;
            lbl_Suoni.BackColor = Color.Transparent;
            lbl_Suoni.Font = new Font("Cooper Black", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Suoni.Location = new Point(171, 232);
            lbl_Suoni.Name = "lbl_Suoni";
            lbl_Suoni.Size = new Size(119, 39);
            lbl_Suoni.TabIndex = 7;
            lbl_Suoni.Text = "label1";
            // 
            // trk_Sounds
            // 
            trk_Sounds.BackColor = Color.FromArgb(195, 195, 197);
            trk_Sounds.Cursor = Cursors.Hand;
            trk_Sounds.Location = new Point(201, 255);
            trk_Sounds.Margin = new Padding(0);
            trk_Sounds.Maximum = 100;
            trk_Sounds.Name = "trk_Sounds";
            trk_Sounds.Size = new Size(750, 56);
            trk_Sounds.TabIndex = 6;
            trk_Sounds.Value = 100;
            trk_Sounds.Scroll += trk_Sounds_Scroll;
            // 
            // btn_Esci
            // 
            btn_Esci.BackColor = Color.Transparent;
            btn_Esci.Location = new Point(304, 348);
            btn_Esci.Name = "btn_Esci";
            btn_Esci.Size = new Size(500, 200);
            btn_Esci.TabIndex = 11;
            btn_Esci.UseVisualStyleBackColor = false;
            btn_Esci.Click += btn_Esci_Click;
            // 
            // FImpostazioni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Esci);
            Controls.Add(btn_MaxSounds);
            Controls.Add(btn_MuteSounds);
            Controls.Add(lbl_Suoni);
            Controls.Add(trk_Sounds);
            Controls.Add(btn_MaxMusic);
            Controls.Add(btn_MuteMusic);
            Controls.Add(lbl_Musica);
            Controls.Add(trk_AudioMusica);
            Name = "FImpostazioni";
            Text = "FImpostazioni";
            Load += FImpostazioni_Load;
            ((System.ComponentModel.ISupportInitialize)trk_AudioMusica).EndInit();
            ((System.ComponentModel.ISupportInitialize)trk_Sounds).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trk_AudioMusica;
        private Label lbl_Musica;
        private Button btn_MuteMusic;
        private Button btn_MaxMusic;
        private Button btn_MaxSounds;
        private Button btn_MuteSounds;
        private Label lbl_Suoni;
        private TrackBar trk_Sounds;
        private Button btn_Esci;
    }
}