using System;
using System.IO;
using System.Windows.Forms;

namespace CampoMinato2
{
    public partial class FCarica : Form
    {
        // Variabili
        FImpostazioni impostazioni;
        Form1 form1;
        string directory = "salvataggi"; // Cartella dei salvataggi

        public FCarica(FImpostazioni i, Form1 f1)
        {
            InitializeComponent();

            //non permetto il ridimensionamento della finestra
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Faccio in modo che non si possa ridimensionare
            this.MaximizeBox = false; // Tolgo il pulsante di massimizzazione
            this.MinimizeBox = false; // Tolgo il pulsante di minimizzazione
            this.Text = "Carica partita"; // Titolo del form
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(970, 530);



            impostazioni = i;
            form1 = f1;
            dgv_Lista.CellContentClick += dgv_Lista_CellContentClick; // Associo l'evento una sola volta
            Cerca();
        }

        private void Cerca()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string[] files = Directory.GetFiles(directory, "*.csv");

            if (files.Length == 0)
            {
                MessageBox.Show("Nessun salvataggio trovato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv_Lista.Rows.Clear(); // Pulisce la griglia se non ci sono salvataggi
                return;
            }

            AggiornaDGV(files);
        }

        private void AggiornaDGV(string[] files)
        {
            dgv_Lista.Rows.Clear();
            dgv_Lista.Columns.Clear();
            dgv_Lista.Columns.Add("NomeSalvataggio", "Nome Salvataggio");
            dgv_Lista.Columns.Add("Dimensioni", "Dimensioni");

            foreach (string file in files)
            {
                string nomeFile = Path.GetFileNameWithoutExtension(file);
                string[] lines = File.ReadAllLines(file);
                if (lines.Length > 0)
                {
                    string[] dimensioni = lines[0].Split(',');
                    if (dimensioni.Length == 2)
                    {
                        dgv_Lista.Rows.Add(nomeFile, $"{dimensioni[0]} x {dimensioni[1]}");
                    }
                }
            }

            var btnCarica = new DataGridViewButtonColumn
            {
                HeaderText = "Carica",
                Text = "Carica",
                UseColumnTextForButtonValue = true
            };
            
            var btnElimina = new DataGridViewButtonColumn
            {
                HeaderText = "Elimina",
                Text = "Elimina",
                UseColumnTextForButtonValue = true
            };

            dgv_Lista.Columns.Add(btnCarica);
            dgv_Lista.Columns.Add(btnElimina);
            dgv_Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Lista.AllowUserToAddRows = false; // no righe manuali
            dgv_Lista.AllowUserToDeleteRows = false; // no cancellazione righe
            dgv_Lista.ReadOnly = true; // rendi la griglia di sola lettura
            //font
            dgv_Lista.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //seleziona solo una riga
            dgv_Lista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dgv_Lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string headerText = dgv_Lista.Columns[e.ColumnIndex].HeaderText;

            if (headerText == "Carica")
            {
                string nomeSalvataggio = dgv_Lista.Rows[e.RowIndex].Cells["NomeSalvataggio"].Value.ToString();
                CaricaSalvataggio(nomeSalvataggio);
                this.Close();
            }
            else if (headerText == "Elimina")
            {
                string nomeSalvataggio = dgv_Lista.Rows[e.RowIndex].Cells["NomeSalvataggio"].Value.ToString();
                EliminaSalvataggio(nomeSalvataggio);
                // Ricarica la lista dei salvataggi dopo l'eliminazione
                Cerca();
            }
        }


        private void EliminaSalvataggio(string name)
        {
            string filePath = Path.Combine(directory, name + ".csv");
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Salvataggio non trovato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                File.Delete(filePath);
                MessageBox.Show("Salvataggio eliminato con successo.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cerca(); // Ricarica la lista dei salvataggi
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'eliminazione del salvataggio: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaricaSalvataggio(string name)
        {
            string filePath = Path.Combine(directory, name + ".csv");
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Salvataggio non trovato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2)
            {
                MessageBox.Show("Salvataggio corrotto o incompleto.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] dimensioni = lines[0].Split(',');
            if (dimensioni.Length != 2 || !int.TryParse(dimensioni[0], out int righe) || !int.TryParse(dimensioni[1], out int colonne))
            {
                MessageBox.Show("Dimensioni del salvataggio non valide.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[,] campoCaricato = new int[righe, colonne];
            string[,] campoCliccatoCaricato = new string[righe, colonne];

            for (int i = 0; i < righe; i++)
            {
                if (i + 1 >= lines.Length) break;
                string[] valori = lines[i + 1].Split(',');
                for (int j = 0; j < colonne; j++)
                {
                    if (j < valori.Length && int.TryParse(valori[j], out int valore))
                    {
                        campoCaricato[i, j] = valore;
                    }
                }
            }

            for (int i = 0; i < righe; i++)
            {
                if (i + 1 + righe >= lines.Length) break;
                string[] valori = lines[i + 1 + righe].Split(',');
                for (int j = 0; j < colonne; j++)
                {
                    if (j < valori.Length)
                    {
                        campoCliccatoCaricato[i, j] = valori[j];
                    }
                }
            }

            // CREA E MOSTRA FPartita
            FPartita partita = new FPartita(campoCaricato, campoCliccatoCaricato, righe, colonne, impostazioni, form1, this);
            partita.ShowDialog();
            //metto sopra la finestra della parti
            partita.TopMost = true;
        }


        private void FCarica_Load(object sender, EventArgs e)
        {
            // Eventuale codice di inizializzazione
        }
    }
}
