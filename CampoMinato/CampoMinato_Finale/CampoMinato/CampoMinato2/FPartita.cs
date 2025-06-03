using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato2
{
    public partial class FPartita : Form
    {
        Image imgFlag;
        int[,] campo;
        FImpostazioni impostazioni;

        public FPartita(double ncelle, int bombe, FImpostazioni i, Form1 f)
        {
            impostazioni = i;
            //pulisco tutto dal form1 per ridurre l'uso di memoria
            f.Controls.Clear();
            f.BackgroundImage = null;
            f.Hide();

            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.BackgroundImage = Image.FromFile("bg_Partita.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            CreaTabellone(ncelle);
            Inizializzazioni();
            generaMine(bombe, ncelle);
            imgFlag = Image.FromFile("flag.png");
        }

        //CONSTRUCTOR DELLA PARTITA CON CARICAMENTO DA FILE
        public FPartita(int[,] campoCaricato, string[,] campoCliccatoCaricato, int righeCaricate, int colonneCaricate, FImpostazioni im, Form1 f, FCarica c)
        {
            impostazioni = im;
            //pulisco tutto dal form1 per ridurre l'uso di memoria
            f.Controls.Clear();
            f.BackgroundImage = null;
            f.Hide();

            c.Close(); // chiudo il form di caricamento per liberare memoria

            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.BackgroundImage = Image.FromFile("bg_Partita.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            double righe = (double)righeCaricate / 10; // converto le righe in celle
            CreaTabellone(righe);

            Inizializzazioni();

            campo = campoCaricato;

            //carico il campo cliccato
            for (int i = 0; i < righeCaricate; i++)
            {
                for (int j = 0; j < colonneCaricate; j++)
                {
                    if (campoCliccatoCaricato[i, j] != "")
                    {
                        dgv_main.Rows[i].Cells[j].Value = campoCliccatoCaricato[i, j];
                        dgv_main.Rows[i].Cells[j].Tag = campoCliccatoCaricato[i, j];
                        if (campoCliccatoCaricato[i, j] == "FLAG")
                        {
                            dgv_main.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            dgv_main.Rows[i].Cells[j].Value = "F"; // mostra il flag
                        }
                        else
                        {
                            dgv_main.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                            string colore = ColoreFont(Convert.ToInt32(campoCliccatoCaricato[i, j]));
                            dgv_main.Rows[i].Cells[j].Style.ForeColor = Color.FromName(colore);
                        }
                    }
                }
            }
            imgFlag = Image.FromFile("flag.png");

            foreach (DataGridViewRow row in dgv_main.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == "0")
                    {
                        cell.Value = ""; // imposta la cella come vuota
                        cell.Style.BackColor = Color.Gray; // cambia il colore della cella 
                    }
                }
            }
        }

        private void CreaTabellone(double ncelle)
        {
            int numeroCelle = (int)(ncelle * 10);

            dgv_main.CellClick += dgv_main_CellClick;
            dgv_main.CellMouseDown += dgv_main_CellMouseDown;

            dgv_main.RowHeadersVisible = false;
            dgv_main.ColumnHeadersVisible = false;
            dgv_main.ScrollBars = ScrollBars.None;
            dgv_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_main.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgv_main.ColumnCount = numeroCelle;
            dgv_main.RowCount = numeroCelle;

            int cellWidth = dgv_main.ClientSize.Width / numeroCelle;
            int cellHeight = dgv_main.ClientSize.Height / numeroCelle;

            for (int i = 0; i < numeroCelle; i++)
            {
                dgv_main.Columns[i].Width = cellWidth;
                dgv_main.Rows[i].Height = cellHeight;
            }

            for (int i = 0; i < numeroCelle; i++)
            {
                for (int j = 0; j < numeroCelle; j++)
                {
                    var cella = dgv_main.Rows[i].Cells[j];
                    cella.Value = ""; // inizializzo la cella come vuota
                    cella.Style.BackColor = Color.LightGray; // imposto il colore di sfondo della cella
                    cella.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // allineamento del testo al centro
                    cella.Style.Font = new Font("Roboto Mono", 14, FontStyle.Bold); // imposto il font della cella
                    cella.Style.ForeColor = Color.Black; // imposto il colore del testo della cell

                }
            }

            dgv_main.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgv_main.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_main.ClearSelection();
        } //FUNZIONE PER CREARE IL TABELLONE

        private void Inizializzazioni()
        {
            this.FormBorderStyle = FormBorderStyle.None; //Tolgo il bordo della finestra
            this.WindowState = FormWindowState.Maximized; //Metto a schermo intero

            //metto il campo in centro a sinistra
            int width = this.Width = Screen.PrimaryScreen.Bounds.Width; //Larghezza della finestra
            int height = this.Height = Screen.PrimaryScreen.Bounds.Height; //Altezza della finestra

            dgv_main.Left = (width - dgv_main.Width) / 2; //centro in orizzontale
            dgv_main.Top = ((height - dgv_main.Height) / 2) - 100; //centro in verticale

            //pulsante in alto a destra
            btn_Informazioni.Left = width - btn_Informazioni.Width - 20; //posizione a destra
            btn_Informazioni.Top = 20; //posizione in alto
            btn_Informazioni.BackgroundImage = Image.FromFile("question.png"); //Immagine del pulsante informazioni
            btn_Informazioni.BackgroundImageLayout = ImageLayout.Stretch; //Adatta l'immagine al pulsante
            btn_Informazioni.FlatStyle = FlatStyle.Flat; //Rende il pulsante senza bordi
            btn_Informazioni.FlatAppearance.BorderSize = 0; //Rimuove il bordo del pulsante
            btn_Informazioni.FlatAppearance.MouseOverBackColor = Color.Transparent; //Rende il pulsante trasparente quando si passa sopra con il mouse
            btn_Informazioni.FlatAppearance.MouseDownBackColor = Color.Transparent; //Rende il pulsante trasparente quando si clicca sopra

            btn_Impostazioni.Left = width - btn_Impostazioni.Width - 20; //posizione a destra
            btn_Impostazioni.Top = btn_Informazioni.Top + btn_Informazioni.Height + 20; //posizione sotto il pulsante informazioni
            btn_Impostazioni.BackgroundImage = Image.FromFile("impo_small.png"); //Immagine del pulsante impostazioni
            btn_Impostazioni.BackgroundImageLayout = ImageLayout.Stretch; //Adatta l'immagine al pulsante
            btn_Impostazioni.FlatStyle = FlatStyle.Flat; //Rende il pulsante senza bordi
            btn_Impostazioni.FlatAppearance.BorderSize = 0; //Rimuove il bordo del pulsante
            btn_Impostazioni.FlatAppearance.MouseOverBackColor = Color.Transparent; //Rende il pulsante trasparente quando si passa sopra con il mouse
            btn_Impostazioni.FlatAppearance.MouseDownBackColor = Color.Transparent; //Rende il pulsante trasparente quando si clicca sopra

            btn_SaveGame.Left = width - btn_SaveGame.Width - 20; //posizione a destra
            btn_SaveGame.Top = btn_Impostazioni.Top + btn_Impostazioni.Height + 20; //posizione sotto il pulsante impostazioni
            btn_SaveGame.BackgroundImage = Image.FromFile("save.png"); //Immagine del pulsante salvataggio
            btn_SaveGame.BackgroundImageLayout = ImageLayout.Stretch; //Adatta l'immagine al pulsante
            btn_SaveGame.FlatStyle = FlatStyle.Flat; //Rende il pulsante senza bordi
            btn_SaveGame.FlatAppearance.BorderSize = 0; //Rimuove il bordo del pulsante
            btn_SaveGame.FlatAppearance.MouseOverBackColor = Color.Transparent; //Rende il pulsante trasparente quando si passa sopra con il mouse
            btn_SaveGame.FlatAppearance.MouseDownBackColor = Color.Transparent; //Rende il pulsante trasparente quando si clicca sopra

            btn_Close.Left = 20;
            btn_Close.Top = 20;
            btn_Close.BackgroundImage = Image.FromFile("x.png"); //Immagine del pulsante chiudi
            btn_Close.BackgroundImageLayout = ImageLayout.Stretch; //Adatta l'immagine al pulsante
            btn_Close.FlatStyle = FlatStyle.Flat; //Rende il pulsante senza bordi
            btn_Close.FlatAppearance.BorderSize = 0; //Rimuove il bordo del pulsante
            btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent; //Rende il pulsante trasparente quando si passa sopra con il mouse
            btn_Close.FlatAppearance.MouseDownBackColor = Color.Transparent; //Rende il pulsante trasparente quando si clicca sopra
        }


        private void generaMine(int nMine, double larghezza)
        {
            larghezza *= 10;
            Random rnd = new Random();
            int area = (int)(larghezza * larghezza); // calcolo l'area del campo di gioco


            //le mine sono passate come percentuale del numero di celle
            nMine = (int)((area * nMine) / 100.0); // calcolo il numero di mine in base alla percentuale

            // genero una matrice di interi per gestire il campo di gioco
            campo = new int[(int)larghezza, (int)larghezza];

            // genero le mine
            for (int i = 0; i < nMine; i++)
            {
                int x, y;
                do
                {
                    x = rnd.Next(0, (int)larghezza);
                    y = rnd.Next(0, (int)larghezza);
                } while (campo[x, y] == -1);
                campo[x, y] = -1;
            }

            // calcolo i numeri delle celle
            for (int i = 0; i < larghezza; i++)
            {
                for (int j = 0; j < larghezza; j++)
                {
                    if (campo[i, j] != -1)
                    {
                        int count = 0;
                        // controllo le celle vicine
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                if (x == 0 && y == 0) continue; // salto la cella corrente
                                int newX = i + x;
                                int newY = j + y;
                                if (newX >= 0 && newX < larghezza && newY >= 0 && newY < larghezza && campo[newX, newY] == -1)
                                {
                                    count++;
                                }
                            }
                        }
                        campo[i, j] = count;
                    }
                }
            }
        }

        private void dgv_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            impostazioni.cellaCliccata(); // trigger del suono quando si preme una cella

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // esce se la cella non è valida
            if (dgv_main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "F") return; // esce se la cella è flaggata
            int x = e.RowIndex;
            int y = e.ColumnIndex;

            // se clicco una cella con un numero gia scoperta, scopro le 8 circostanti anche se hanno una bomba, ma non scopro quelle con il flag
            if (campo[x, y] > 0 && dgv_main.Rows[x].Cells[y].Value.ToString() != "")
            {
                ScopriCircostanti(x + 1, y + 1);
                ScopriCircostanti(x + 1, y);
                ScopriCircostanti(x + 1, y - 1);
                ScopriCircostanti(x, y + 1);
                ScopriCircostanti(x, y - 1);
                ScopriCircostanti(x - 1, y + 1);
                ScopriCircostanti(x - 1, y);
                ScopriCircostanti(x - 1, y - 1);
            }

            if (campo[x, y] == -1)
            {
                dgv_main.Rows[x].Cells[y].Value = "B"; // mostra una mina
                dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Red; // cambio colore della cella
                LoseGame();
            }
            if (campo[x, y] >= 0)
            {
                //"scopro" tutte le celle che hanno 0 nelle vicinanze fino to a che non trovo celle con numeri
                if (campo[x, y] == 0)
                {
                    ScopriCelle(x, y);
                }
                else
                {
                    //aggiungo alla cella un tag che indichi il suo valore
                    dgv_main.Rows[x].Cells[y].Tag = campo[x, y];
                    dgv_main.Rows[x].Cells[y].Value = campo[x, y]; // mostra il numero della cella
                    int valore = campo[x, y];
                    string colore = ColoreFont(valore); // prendo il colore del font in base al valore della cella
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Gray; // cambio colore della cella
                    dgv_main.Rows[x].Cells[y].Style.ForeColor = Color.FromName(colore); // cambio colore del font della cella
                }
            }

            foreach (DataGridViewRow row in dgv_main.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == "0")
                    {
                        cell.Value = ""; // imposta la cella come vuota
                        cell.Style.BackColor = Color.Gray; // cambia il colore della cella
                    }
                }
            }

            dgv_main.ClearSelection(); // rimuove la selezione della cella dopo il click
        }

        private string ColoreFont(int valore)
        {
            //in base al valore della cella, ritorno il colore del font
            switch (valore)
            {
                case 1:
                    return "Blue"; // Colore per il numero 1
                case 2:
                    return "Green"; // Colore per il numero 2
                case 3:
                    return "Red"; // Colore per il numero 3
                case 4:
                    return "Purple"; // Colore per il numero 4
                case 5:
                    return "Maroon"; // Colore per il numero 5
                case 6:
                    return "Cyan"; // Colore per il numero 6
                case 7:
                    return "Lightblue"; // Colore per il numero 7
                case 8:
                    return "Pink"; // Colore per il numero 8
                default:
                    return "Black"; // Colore di default
            }
        }

        private void ScopriCircostanti(int x, int y)
        {
            // Controllo se le coordinate sono valide
            if (x < 0 || x >= campo.GetLength(0) || y < 0 || y >= campo.GetLength(1)) return; // esce se la cella non è valida

            if (dgv_main.Rows[x].Cells[y].Value.ToString() != "F")
            { // Controllo prima se la cella è flaggata
                ScopriCelle(x, y);

                // Controllo se la cella scoperta è una mina
                if (campo[x, y] == -1)
                {
                    dgv_main.Rows[x].Cells[y].Value = "B"; // mostra una mina
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Red; // cambio colore della cella
                    LoseGame(); // funzione per perdere la partita
                }
            }
        }

        private async void LoseGame()
        {
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    //se si ha messo un flag nel posto sbagliato allora faccio una X arancione
                    if (campo[i, j] == -1)
                    {
                        //se ce una flag, metto arancione e una X

                        if (dgv_main.Rows[i].Cells[j].Value.ToString() == "F")
                        {
                            dgv_main.Rows[i].Cells[j].Value = "F";
                            dgv_main.Rows[i].Cells[j].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            Image img = Image.FromFile("mina.png");
                            DataGridViewImageCell imgCell = new DataGridViewImageCell();
                            imgCell.Value = img;
                            imgCell.Style.BackColor = Color.FromArgb(45, 45, 48);
                            imgCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            dgv_main.Rows[i].Cells[j] = imgCell;
                        }
                    }
                    else if (dgv_main.Rows[i].Cells[j].Value.ToString() == "F")
                    {
                        Image flagImg = Image.FromFile("flagSbagliata.png");
                        DataGridViewImageCell imgCell = new DataGridViewImageCell();
                        imgCell.Value = flagImg;
                        imgCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        dgv_main.Rows[i].Cells[j] = imgCell;
                        dgv_main.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(159, 114, 32);
                    }
                }
            }

            dgv_main.Refresh(); // forza ridisegno
            await Task.Delay(3000); // attende in modo non bloccante

            immagineLose();
        }

        private void immagineLose()
        {
            Thread.Sleep(1000); // attende 1 secondo prima di mostrare l'immagine


            this.BackgroundImage = Image.FromFile("ah.png");
            dgv_main.Hide();

            //messagebox con scelta di ricominciare o uscire
            DialogResult result = MessageBox.Show("Hai perso! Vuoi ricominciare?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                Application.Restart(); // riavvia l'applicazione
            }
            else
            {
                Application.Exit(); // chiude l'applicazione
            }
        }

        private void ScopriCelle(int x, int y)
        {
            if (x < 0 || x >= campo.GetLength(0) || y < 0 || y >= campo.GetLength(1)) return; // esce se la cella non è valida

            if (dgv_main.Rows[x].Cells[y].Value != null && dgv_main.Rows[x].Cells[y].Value.ToString() != "") return;

            if (dgv_main.Rows[x].Cells[y].Value.ToString() == "F") return; // esce se la cella è flaggata

            // aggiungo alla cella un tag che indichi il suo valore
            dgv_main.Rows[x].Cells[y].Tag = campo[x, y]; // aggiungo il tag con il valore della cella
            dgv_main.Rows[x].Cells[y].Value = campo[x, y]; // mostra il numero della cella
            string colore = ColoreFont(campo[x, y]); // prendo il colore del font in base al valore della cella
            dgv_main.Rows[x].Cells[y].Style.ForeColor = Color.FromName(colore); // cambio colore del font della cella
            dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Gray; // cambio colore della cella

            if (campo[x, y] == 0)
            {
                //scopro le celle vicine
                ScopriCelle(x - 1, y - 1);
                ScopriCelle(x - 1, y);
                ScopriCelle(x - 1, y + 1);
                ScopriCelle(x, y - 1);
                ScopriCelle(x, y + 1);
                ScopriCelle(x + 1, y - 1);
                ScopriCelle(x + 1, y);
                ScopriCelle(x + 1, y + 1);
            }
        }

        private void dgv_main_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // esce se la cella non è valida

                //prendo le coordinate della cella
                int x = e.RowIndex;
                int y = e.ColumnIndex;

                //se la cella è flaggata la rimuovo, altrimenti la flaggo come mina

                if (dgv_main.Rows[x].Cells[y].Value == null || dgv_main.Rows[x].Cells[y].Value.ToString() == "")
                {
                    dgv_main.Rows[x].Cells[y].Value = "F"; // segna la cella come mina
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.DarkGray; // cambio colore della cella
                    dgv_main.Rows[x].Cells[y].Tag = "FLAG"; // aggiungo un tag per indicare che è una flag
                }

                else if (dgv_main.Rows[x].Cells[y].Value.ToString() == "F")
                {
                    dgv_main.Rows[x].Cells[y].Value = ""; // rimuove la segnalazione della mina
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.LightGray; // ripristina il colore originale della cella
                    dgv_main.Rows[x].Cells[y].Tag = null; // rimuove il tag
                }
                ControllaFlag();
            }
        }

        private void ControllaFlag()
        {
            int righe = campo.GetLength(0);
            int colonne = campo.GetLength(1);

            int[,] campoMine = new int[righe, colonne];
            int[,] campoFlag = new int[righe, colonne];
            int numeroMine = 0;
            int numeroFlag = 0;

            // 1. Scansiona la matrice per segnare le mine
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    if (campo[i, j] == -1)
                    {
                        campoMine[i, j] = 1;
                        numeroMine++;
                    }
                }
            }

            // 2. Scansiona la griglia per segnare le flag
            foreach (DataGridViewRow row in dgv_main.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == "F")
                    {
                        campoFlag[cell.RowIndex, cell.ColumnIndex] = 1;
                        numeroFlag++;
                    }
                }
            }

            // 3. Verifica che il numero di flag sia corretto
            if (numeroFlag != numeroMine)
                return; // numero sbagliato, quindi niente vittoria

            // 4. Verifica che ogni flag sia su una mina
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    if (campoFlag[i, j] == 1 && campoMine[i, j] != 1)
                    {
                        return; // flag su una cella che non è mina => no vittoria
                    }
                }
            }

            // 5. Se siamo qui, la vittoria è corretta
            MessageBox.Show("Hai vinto! Hai scoperto tutte le mine.", "Vittoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void FPartita_Load(object sender, EventArgs e)
        {
            dgv_main.CellPainting += dgv_main_CellPainting;
        }

        private void dgv_main_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cell = dgv_main.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string value = cell.Value?.ToString();

            // Disegna solo lo sfondo
            e.PaintBackground(e.ClipBounds, true);

            // Dimensione e posizione dell'immagine centrata
            int imgSize = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 6;
            Rectangle imgRect = new Rectangle(
                e.CellBounds.X + (e.CellBounds.Width - imgSize) / 2,
                e.CellBounds.Y + (e.CellBounds.Height - imgSize) / 2,
                imgSize,
                imgSize);

            if (value == "F")
            {
                e.Graphics.DrawImage(imgFlag, imgRect); // immagine "F"
                e.Handled = true;
            }
        }


        private void btn_Informazioni_Click(object sender, EventArgs e)
        {
            FInformazioni info = new FInformazioni();
            info.ShowDialog();

        }

        private void btn_Impostazioni_Click(object sender, EventArgs e)
        {
            impostazioni.pulsantePremuto();
            this.Hide(); // nasconde il form della partita
            impostazioni.ShowDialog(); // mostra il form delle impostazioni
            this.Show(); // riporta a visibilità il form della partita
        }

        private void btn_SaveGame_Click(object sender, EventArgs e)
        {
            string[,] campoCliccate = new string[campo.GetLength(0), campo.GetLength(1)];
            //controllo i tag e popoplo la matrice
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    if (dgv_main.Rows[i].Cells[j].Tag != null)
                    {
                        campoCliccate[i, j] = dgv_main.Rows[i].Cells[j].Tag.ToString();
                    }
                    else
                    {
                        campoCliccate[i, j] = "";
                    }
                }
            }

            FSalva salvaPartita = new FSalva(campo, campoCliccate, dgv_main.RowCount, dgv_main.ColumnCount, impostazioni);
            salvaPartita.ShowDialog(); // mostra il form per salvare la partita
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vuoi davvero uscire?", "Conferma uscita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // chiude l'applicazione
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mostro in un messagebox le celle taggate
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    if (dgv_main.Rows[i].Cells[j].Tag != null)
                    {
                        sb.AppendLine($"Cella ({i}, {j}): {dgv_main.Rows[i].Cells[j].Tag}");
                    }
                }
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Celle Taggate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nessuna cella taggata.", "Celle Taggate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
