using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace CampoMinato2
{
    public partial class FSalva : Form
    {
        //Variabili
        int[,] campoCaricato;
        string[,] campoCliccatoCaricato;
        int righeCaricate;
        int colonneCaricate;
        FImpostazioni impo;

        //Costruttore
        public FSalva(int[,] campo, string[,] campoCliccate, int righe, int colonne, FImpostazioni impostazioni)
        {
            InitializeComponent();
            Inizializzazioni();
            campoCaricato = campo;
            campoCliccatoCaricato = campoCliccate;
            righeCaricate = righe;
            colonneCaricate = colonne;
            impo = impostazioni;
        }

        private void Inizializzazioni()
        {
            btn_Salva.BackgroundImage = Image.FromFile("save.png"); //Immagine del bottone Salva
            btn_Salva.BackgroundImageLayout = ImageLayout.Stretch; //Adatto l'immagine del bottone Salva
            btn_Salva.FlatStyle = FlatStyle.Flat; //Rendo il bottone Salva piatto
            btn_Salva.FlatAppearance.BorderSize = 0; //Tolgo il bordo del bottone Salva
            btn_Salva.FlatAppearance.MouseOverBackColor = Color.Transparent; //Non cambia colore al passaggio del mouse
            btn_Salva.FlatAppearance.MouseDownBackColor = Color.Transparent; //Non cambia colore al click del mouse

            btn_Close.BackgroundImage = Image.FromFile("x.png"); //Immagine del bottone Chiudi
            btn_Close.BackgroundImageLayout = ImageLayout.Stretch; //Adatto l'immagine del bottone Chiudi
            btn_Close.FlatStyle = FlatStyle.Flat; //Rendo il bottone Chiudi piatto
            btn_Close.FlatAppearance.BorderSize = 0; //Tolgo il bordo del bottone Chiudi
            btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent; //Non cambia colore al passaggio del mouse
            btn_Close.FlatAppearance.MouseDownBackColor = Color.Transparent; //Non cambia colore al click del mouse

            //posiziono il form al centro dello schermo
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; //Faccio in modo che non si possa ridimensionare
            this.MaximizeBox = false; //Tolgo il pulsante di massimizzazione
            this.MinimizeBox = false; //Tolgo il pulsante di minimizzazione
            this.Text = "Salva partita"; //Titolo del form

        }


        //carico in un csv tutte le informazioni del campo
        private void btn_Salva_Click(object sender, EventArgs e)
        {
            string directory = "salvataggi";
            string nomeSalvataggio = tbx_NomeFile.Text.Trim();

            //controllo se il nome e valido
            if (nomeSalvataggio.Contains(Path.DirectorySeparatorChar) || nomeSalvataggio.Contains(Path.AltDirectorySeparatorChar))
            {
                MessageBox.Show("Il nome del salvataggio non può contenere caratteri di percorso.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(nomeSalvataggio))
            {
                MessageBox.Show("Il nome del salvataggio non può essere vuoto.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (string.IsNullOrEmpty(nomeSalvataggio))
            {
                MessageBox.Show("Inserisci un nome per il salvataggio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string filePath = Path.Combine(directory, nomeSalvataggio + ".csv");

            //carico il file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Scrivo le dimensioni del campo
                writer.WriteLine($"{righeCaricate},{colonneCaricate}");
                // Scrivo il campo con i numeri delle mine
                for (int i = 0; i < righeCaricate; i++)
                {
                    for (int j = 0; j < colonneCaricate; j++)
                    {
                        writer.Write(campoCaricato[i, j]);
                        if (j < colonneCaricate - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
                // Scrivo il campo cliccato
                for (int i = 0; i < righeCaricate; i++)
                {
                    for (int j = 0; j < colonneCaricate; j++)
                    {
                        writer.Write(campoCliccatoCaricato[i, j]);
                        if (j < colonneCaricate - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }

            //quando finisco chiedo se vuole continuare giocare, riavviare, o uscire
            DialogResult result = MessageBox.Show("Salvataggio completato! Vuoi continuare a giocare?", "Salvataggio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (File.Exists(filePath))
                {
                    this.Close();
                }
            }
            else if (result == DialogResult.Cancel || result == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
