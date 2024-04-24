using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionareLoc;
using NivelStocareDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareLoc_FisierText adminLocuri;
        AdministrareClient_FisierText adminClienti;
        private Label lblNr;
        private Label lblNume;
        private Label lblAdresa;
        private TextBox txtNume;
        private TextBox txtAdresa;
        private TextBox txtNr;
        private Label[] lblsNr;
        private Label[] lblsNume;
        private Label[] lblsAdresa;
        private Button btnAdauga;
        private Button btnRefresh;

        private Label lblNrc;
        private Label lblNumeC;
        private Label lblVarstaC;
        private TextBox txtNumeC;
        private TextBox txtVarstaC;
        private TextBox txtNrC;
        private Label[] lblsNrC;
        private Label[] lblsNumeC;
        private Label[] lblsVarstaC;
        private Button btnAdaugaC;
        private Button btnRefreshC;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        public Form1()
        {   InitializeComponent();
            //LOCURI DE JOACA
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string numeFisierC= ConfigurationManager.AppSettings["NumeFisierC"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            string caleCompletaFisierC = locatieFisierSolutie + "\\" + numeFisierC;
            adminLocuri = new AdministrareLoc_FisierText(caleCompletaFisier);
            adminClienti = new AdministrareClient_FisierText(caleCompletaFisierC);
            int nrLocuri = 0;
            int nrClienti = 0;
            LocDeJoaca[] locdejoaca = adminLocuri.GetLocuri(out  nrLocuri);
            //proprietati
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            this.ForeColor = Color.RoyalBlue;
            this.Text = "Locuri de joaca";
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false; 
            this.MinimizeBox = false; 
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;

            //control label 'nr'
            lblNr = new Label();
            lblNr.Width = LATIME_CONTROL;
            lblNr.Text = "Nr";
            lblNr.Left = 50;
            lblNr.ForeColor = Color.BlueViolet;
            this.Controls.Add(lblNr);

            //control Label 'Nume';
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.BlueViolet;
            this.Controls.Add(lblNume);

            //control Label 'Adresa';
            lblAdresa = new Label();
            lblAdresa.Width = LATIME_CONTROL;
            lblAdresa.Text = "Adresa";
            lblAdresa.Left = 2 * DIMENSIUNE_PAS_X;
            lblAdresa.ForeColor = Color.BlueViolet;
            this.Controls.Add(lblAdresa);


            //TextBox 'Nume'
            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL;
            txtNume.Left = DIMENSIUNE_PAS_X-50;
            txtNume.Top = DIMENSIUNE_PAS_Y + 500;
            this.Controls.Add(txtNume);
            

            //TextBox 'Adresa'
            txtAdresa = new TextBox();
            txtAdresa.Width = LATIME_CONTROL;
            txtAdresa.Left = DIMENSIUNE_PAS_X-50;
            txtAdresa.Top = DIMENSIUNE_PAS_Y + 530;
            this.Controls.Add(txtAdresa);

            txtNume.TextChanged += TxtNume_TextChanged;
            txtAdresa.TextChanged += TxtAdresa_TextChanged;


            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Location = new System.Drawing.Point( DIMENSIUNE_PAS_X+100, DIMENSIUNE_PAS_Y + 500);
            btnAdauga.Text = "Adauga";
            btnAdauga.Click += OnButtonClicked;
            this.Controls.Add(btnAdauga);

            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.Location = new System.Drawing.Point( DIMENSIUNE_PAS_X+100, DIMENSIUNE_PAS_Y + 530);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += Form1_Load;
            this.Controls.Add(btnRefresh);

            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = 20;
            lblNume.Top = DIMENSIUNE_PAS_Y + 500;
            lblNume.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblNume);

            
            lblAdresa = new Label();
            lblAdresa.Width = LATIME_CONTROL;
            lblAdresa.Text = "Adresa";
            lblAdresa.Left = 20;
            lblAdresa.Top = DIMENSIUNE_PAS_Y + 530;
            lblAdresa.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblAdresa);


            //CLIENTI
            Client[] client = adminClienti.GetClienti(out nrClienti);
            
            //control label 'nr'
            lblNrc = new Label();
            lblNrc.Width = LATIME_CONTROL;
            lblNrc.Text = "Nr";
            lblNrc.Left = 3*DIMENSIUNE_PAS_X+50;
            lblNrc.ForeColor = Color.BlueViolet;
            this.Controls.Add(lblNrc);

            //control Label 'Nume';
            lblNumeC = new Label();
            lblNumeC.Width = LATIME_CONTROL;
            lblNumeC.Text = "Nume";
            lblNumeC.Left = 4*DIMENSIUNE_PAS_X;
            lblNumeC.ForeColor = Color.BlueViolet;
            this.Controls.Add(lblNumeC);

            //control Label 'Varsta';
            lblVarstaC = new Label();
            lblVarstaC.Width = LATIME_CONTROL;
            lblVarstaC.Text = "Varsta";
            lblVarstaC.Left = 5 * DIMENSIUNE_PAS_X;
            lblVarstaC.ForeColor = Color.BlueViolet;
            this.Controls.Add(lblVarstaC);


            //TextBox 'Nume'
            txtNumeC = new TextBox();
            txtNumeC.Width = LATIME_CONTROL;
            txtNumeC.Left = 4* DIMENSIUNE_PAS_X;
            txtNumeC.Top = DIMENSIUNE_PAS_Y + 500;
            this.Controls.Add(txtNumeC);


            //TextBox 'Adresa'
            txtVarstaC = new TextBox();
            txtVarstaC.Width = LATIME_CONTROL;
            txtVarstaC.Left = 4*DIMENSIUNE_PAS_X;
            txtVarstaC.Top = DIMENSIUNE_PAS_Y + 530;
            this.Controls.Add(txtVarstaC);

            btnAdaugaC = new Button();
            btnAdaugaC.Width = LATIME_CONTROL;
            btnAdaugaC.Location = new System.Drawing.Point(5 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y + 500);
            btnAdaugaC.Text = "Adauga";
            btnAdaugaC.Click += OnClientButtonClicked;
            this.Controls.Add(btnAdaugaC);

            btnRefreshC = new Button();
            btnRefreshC.Width = LATIME_CONTROL;
            btnRefreshC.Location = new System.Drawing.Point(5 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y + 530);
            btnRefreshC.Text = "Refresh";
            btnRefreshC.Click += Form1_LoadC;
            this.Controls.Add(btnRefreshC);

            lblNumeC = new Label();
            lblNumeC.Width = LATIME_CONTROL;
            lblNumeC.Text = "Nume";
            lblNumeC.Left = 3*DIMENSIUNE_PAS_X;
            lblNumeC.Top = DIMENSIUNE_PAS_Y + 500;
            lblNumeC.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblNumeC);
            

            lblVarstaC = new Label();
            lblVarstaC.Width = LATIME_CONTROL;
            lblVarstaC.Text = "Varsta";
            lblVarstaC.Left = 3*DIMENSIUNE_PAS_X;
            lblVarstaC.Top = DIMENSIUNE_PAS_Y + 530;
            lblVarstaC.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblVarstaC);

        }
        private void TxtNume_TextChanged(object sender, EventArgs e)
        {
            if (txtNume.Text.Length > 15)
            {
                txtNume.ForeColor = Color.Red;
            }
            else
            {
                txtNume.ForeColor = SystemColors.ControlText; 
            }
        }

        private void TxtAdresa_TextChanged(object sender, EventArgs e)
        {
            if (txtAdresa.Text.Length > 15)
            {
                txtAdresa.ForeColor = Color.Red;
            }
            else
            {
                txtAdresa.ForeColor = SystemColors.ControlText; 
            }
        }


        private void OnButtonClicked(object sender, EventArgs e)
        {
            int errorCode = Validare(); 

            if (errorCode == 0) 
            {

                string nume = txtNume.Text;
                string adresa = txtAdresa.Text;
                LocDeJoaca l = new LocDeJoaca(0, nume, adresa);


                adminLocuri.AddLoc(l);
            }
            else
            {
                MessageBox.Show("Date invalide! Va rugam sa completati cu mai putin de 15 caractere", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int Validare()
        {
            int errorCode = 0; 
            if (string.IsNullOrEmpty(txtNume.Text) || txtNume.Text.Length > 15)
            {
                lblNume.ForeColor = Color.Red; 
                errorCode = 1; 
            }
            else
            {
                lblNume.ForeColor = Color.BlueViolet; 
            }

            
            if (string.IsNullOrEmpty(txtAdresa.Text) || txtAdresa.Text.Length > 15)
            {
                lblAdresa.ForeColor = Color.Red; 
                errorCode = 2; 
            }
            else
            {
                lblAdresa.ForeColor = Color.BlueViolet; 
            }

            return errorCode; 
        }

        private void OnClientButtonClicked(object sender, EventArgs e)
        {
            int errorCode = ValidareC();

            if (errorCode == 0)
            {

                string nume = txtNumeC.Text;
                string varsta = txtVarstaC.Text;
                Client c = new Client( nume,  varsta);


                adminClienti.AddClient(c);
            }
            else
            {
                MessageBox.Show("Date invalide! Va rugam sa completati cu mai putin de 15 caractere", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ValidareC()
        {
            int errorCode = 0; 
            if (string.IsNullOrEmpty(txtNumeC.Text) || txtNumeC.Text.Length > 15)
            {
                errorCode = 1; 
            }
            else
            {
                lblNumeC.ForeColor = Color.BlueViolet; 
            }

            
            if (string.IsNullOrEmpty(txtVarstaC.Text) || txtVarstaC.Text.Length > 15)
            {
                errorCode = 2; 
            }
            else
            {
                lblVarstaC.ForeColor = Color.BlueViolet; 
            }

            return errorCode; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaLocuri();
        }
        private void Form1_LoadC(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }

        /*private void AfiseazaLocuri()
        {
            LocDeJoaca[] locuridejoaca = adminLocuri.GetLocuri(out int nrLocuri);

            lblsNume = new Label[locuridejoaca.Length];
            lblsAdresa = new Label[locuridejoaca.Length];
            lblsNr = new Label[locuridejoaca.Length];

            int i = 0;
            foreach (LocDeJoaca locdejoaca in locuridejoaca)
            {
                lblsNr[i] = new Label();
                lblsNr[i].Width = LATIME_CONTROL;
                lblsNr[i].Text = (i+1).ToString();
                lblsNr[i].Left = 50;
                lblsNr[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNr[i]);

                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = locdejoaca.Nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                lblsAdresa[i] = new Label();
                lblsAdresa[i].Width = LATIME_CONTROL;
                lblsAdresa[i].Text = locdejoaca.Adresa;
                lblsAdresa[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsAdresa[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAdresa[i]);

               
                i++;
            }
        }*/
        private void AfiseazaLocuri()
        {
            LocDeJoaca[] locuridejoaca = adminLocuri.GetLocuri(out int nrLocuri);

            Label[,] lblsLocuri = new Label[locuridejoaca.Length, 3]; // Tablou bidimensional pentru toate label-urile

            int i = 0;
            foreach (LocDeJoaca locdejoaca in locuridejoaca)
            {
                for (int j = 0; j < 3; j++) // Iteram pentru fiecare coloana (Nr, Nume, Adresa)
                {
                    lblsLocuri[i, j] = new Label();
                    lblsLocuri[i, j].Width = LATIME_CONTROL;
                    lblsLocuri[i, j].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsLocuri[i, j]);
                }

                lblsLocuri[i, 0].Text = (i + 1).ToString(); // Nr
                lblsLocuri[i, 0].Left = 50;

                lblsLocuri[i, 1].Text = locdejoaca.Nume; // Nume
                lblsLocuri[i, 1].Left = DIMENSIUNE_PAS_X;

                lblsLocuri[i, 2].Text = locdejoaca.Adresa; // Adresa
                lblsLocuri[i, 2].Left = 2 * DIMENSIUNE_PAS_X;

                i++;
            }
        }
        private void AfiseazaClienti()
        {
            Client[] clienti = adminClienti.GetClienti(out int nrClienti);

            Label[,] lblsClienti = new Label[clienti.Length, 3]; // Tablou bidimensional pentru toate label-urile

            int i = 0;
            foreach (Client client in clienti)
            {
                for (int j = 0; j < 3; j++) // Iteram pentru fiecare coloana (Nr, Nume, Adresa)
                {
                    lblsClienti[i, j] = new Label();
                    lblsClienti[i, j].Width = LATIME_CONTROL;
                    lblsClienti[i, j].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsClienti[i, j]);
                }

                lblsClienti[i, 0].Text = (i + 1).ToString(); // Nr
                lblsClienti[i, 0].Left = 3*DIMENSIUNE_PAS_X+50;

                lblsClienti[i, 1].Text = client.Nume; // Nume
                lblsClienti[i, 1].Left = 4*DIMENSIUNE_PAS_X;

                lblsClienti[i, 2].Text = client.Varstas;
                lblsClienti[i, 2].Left = 4 * DIMENSIUNE_PAS_X+50;

                i++;
            }
        }
    }
}