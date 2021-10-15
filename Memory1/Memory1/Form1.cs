using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory1
{
    public partial class Memory : Form
    {
        public Memory()
        {
            InitializeComponent();
            
        }
        string[] animationCarte = new string[8];
        bool turno;
        bool[] sceltaGiocatore = new bool[] { false, false, false, false, false, false, false, false };
        string player1;
        string player2;
        int carteSelezionate = 0, coppie1 = 0, coppie2 = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            sceltaTurno();
            string[] Animation = new string[] { "troll", "sax", "pirate", "superman" };
            int nGenTroll = 0, nGenSax = 0, nGenPirate = 0, nGenSuperman = 0;
            Random genCarte = new Random();
            for (int i = 0; i < 8; i++)
            {
                string animationGenerato
                    = genCarteRandom(Animation, genCarte, ref nGenTroll, ref nGenSax, ref nGenPirate, ref nGenSuperman);
                //controlla se il fiore generato è stato sorteggiato già più di due volte
                if (i > 1 && controlloCarte(animationCarte, ref animationGenerato, ref nGenTroll, ref nGenSax, ref nGenPirate, ref nGenSuperman) == -1)
                {
                    i--;//torna indietro di un ciclo, per permettere quando il ciclo si conclude di ripetere
                        //dopo lo stesso ciclo per rigenerare un altro fiore per la medesima posizione nell'array
                }
                else
                {
                    animationCarte[i] = animationGenerato;
                }
            }
            getSfondoCarte();
        }
        //viene generato randomicamente il turno del giocatore
        private void sceltaTurno()
        {
            Random turnoRnd = new Random();
            int scelta = turnoRnd.Next(0, 2);
            if (scelta == 0)
            {
                turno = false;//giocatore 1
                this.BackColor = Color.RoyalBlue;
                nturno.Text = player1;
            }
            else
            {
                turno = true;//giocatore 2
                this.BackColor = Color.GreenYellow;
                nturno.Text = player2;
            }
        }
        //assegna alle picturebox l'immagine iniziale
        private void getSfondoCarte()
        {
            carta1.Image = Properties.Resources.qd;
            carta2.Image = Properties.Resources.qd;
            carta3.Image = Properties.Resources.qd;
            carta4.Image = Properties.Resources.qd;
            carta5.Image = Properties.Resources.qd;
            carta6.Image = Properties.Resources.qd;
            carta7.Image = Properties.Resources.qd;
            carta8.Image = Properties.Resources.qd;
        }
        //genera un'immagine random
        private string genCarteRandom(string[] arraycarte, Random gnCard, ref int nGenptroll, ref int nGensax, ref int nGenpirate, ref int nGensuperman)
        {
            string animationGenerato = "";
            int posGenerata = 0;
            posGenerata = gnCard.Next(0, 4);
            animationGenerato = arraycarte[posGenerata];
            switch (animationGenerato)
            {
                case "troll":
                    nGenptroll = aumentoNumAnimGen(nGenptroll);
                    break;
                case "sax":
                    nGensax = aumentoNumAnimGen(nGensax);
                    break;
                case "pirate":
                    nGenpirate = aumentoNumAnimGen(nGenpirate);
                    break;
                case "superman":
                    nGensuperman = aumentoNumAnimGen(nGensuperman);
                    break;
            }
            return animationGenerato;
        }
        //controlla se il fiore è già stato generato più di due volte
        private int controlloCarte(string[] arrayCard, ref string animationGenerato, ref int nGentroll, ref int nGensax, ref int nGenpirate, ref int nGensuperman)
        {
            //per togliere i valori nulli
            arrayCard = arrayCard.Where(c => c != null).ToArray();
            for (int i = 0; i < arrayCard.Length; i++)
            {
                if (arrayCard[i] == animationGenerato)
                {
                    switch (animationGenerato)
                    {
                        case "troll":
                            if (nGentroll == 3)
                            {
                                return -1;
                            }
                            break;
                        case "sax":
                            if (nGensax == 3)
                            {
                                return -1;
                            }
                            break;
                        case "pirate":
                            if (nGenpirate == 3)
                            {
                                return -1;
                            }
                            break;
                        case "nGensuperman":
                            if (nGensuperman == 3)
                            {
                                return -1;
                            }
                            break;
                    }
                }
            }
            return 1;
        }
        //controlla per tutte le variabili se sono stati sorteggiati più di due volte
        private int aumentoNumAnimGen(int genNum)
        {
            if (genNum < 3)
            {
                genNum++;
            }
            return genNum;
        }
        //funzione al clikc di una carta
        private void clickCarta(int numCarta)
        {
            numCarta -= 1; //per conformarlo alla posizione dell'array
            if (sceltaGiocatore[numCarta] == false)
            {
                switch (numCarta)
                {
                    case 0:
                        carta1.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 1:
                        carta2.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 2:
                        carta3.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 3:
                        carta4.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 4:
                        carta5.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 5:
                        carta6.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 6:
                        carta7.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                    case 7:
                        carta8.Image = immaginecarta(numCarta);
                        sceltaGiocatore[numCarta] = true;
                        controlloTurno(numCarta);
                        break;
                }
            }
        }
        //assegna alle carte un immagine a seconda dell'array generato
        private System.Drawing.Image immaginecarta(int nCarta)
        {
            if (animationCarte[nCarta] == "troll")
            {
                return Properties.Resources.troll;
            }
            else if (animationCarte[nCarta] == "pirate")
            {
                return Properties.Resources.pirate;
            }
            else if (animationCarte[nCarta] == "sax")
            {
                return Properties.Resources.sax;
            }
            else if (animationCarte[nCarta] == "superman")
            {
                return Properties.Resources.superman;
            }
            return null;
        }
        private void controlloTurno(int nCard)
        {
            carteSelezionate++;
            controlloCoppie(ref nCard);
        }
        int card1, card2;
      

        private void controlloCoppie(ref int nCard)
        {
            if (carteSelezionate % 2 == 0)
            {
                card2 = nCard;
                if (animationCarte[card1] != animationCarte[card2])
                {
                    sceltaGiocatore[card1] = false;
                    sceltaGiocatore[card2] = false;
                    wait(500);//fa aspettare 0,5s all'operazione successiva
                    assegnazioneSfondoCarteNonCoppie(card1);
                    assegnazioneSfondoCarteNonCoppie(card2);
                    carteSelezionate -= 2;
                    turno = !turno;//cambia il valore da true a false o da false a true
                    if (turno)
                    {
                        this.BackColor = Color.Beige;
                        nturno.Text = player2;
                    }
                    else
                    {
                        this.BackColor = Color.DarkOliveGreen;
                        nturno.Text = player1;
                    }
                }
                else
                {
                    if (turno)//assegna il punteggio a seconda del turno
                    {
                        coppie2++;
                    }
                    else
                    {
                        coppie1++;
                    }
                }
            }
            else
            {
                card1 = nCard;
            }
            if (carteSelezionate == 8)//mostra il tasto per ricominciare a giocare
            {
                restartGame.Visible = true;
                this.BackColor = Color.White;
                if (coppie1 > coppie2)
                {
                    MessageBox.Show($"La partita si è conclusa\nHa vinto "+ player1);
                }
                else
                {
                    MessageBox.Show($"La partita si è conclusa\nHa vinto "+ player2);
                }
                //è impossible fare un pareggio con 4 coppie
            }
        }

        private void assegnazioneSfondoCarteNonCoppie(int cardNum)
        {
            switch (cardNum)
            {
                case 0:
                    carta1.Image = Properties.Resources.qd;
                    break;
                case 1:
                    carta2.Image = Properties.Resources.qd;
                    break;
                case 2:
                    carta3.Image = Properties.Resources.qd;
                    break;
                case 3:
                    carta4.Image = Properties.Resources.qd;
                    break;
                case 4:
                    carta5.Image = Properties.Resources.qd;
                    break;
                case 5:
                    carta6.Image = Properties.Resources.qd;
                    break;
                case 6:
                    carta7.Image = Properties.Resources.qd;
                    break;
                case 7:
                    carta8.Image = Properties.Resources.qd;
                    break;
            }
        }

        public void wait(int milliseconds)
        {
            //crea un oggetto Timer
            var timer1 = new System.Windows.Forms.Timer();
            //controlla che il valore dei millisecondi non sia 0 o minore di 0
            if (milliseconds == 0 || milliseconds < 0) return;

            // inizia il timer
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            //controlla se il valore inserito in millisecondi è trascorso
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // finisce il timer
            };

            while (timer1.Enabled)//permette di elaborare le azioni che il form riceve
            {
                Application.DoEvents();
            }
        }


        private void restartGame_Click(object sender, EventArgs e)
        {
            if (nikname1.Text==""||nikname2.Text=="")
            {
                MessageBox.Show("Inserisci nick name");
            }
            else
            {
                player1 = nikname1.Text;
                player2 = nikname2.Text;
                nikname1.Visible = false;
                nikname2.Visible = false;
                dNickname.Visible = false;
                carteSelezionate = 0;
                card1 = 0; card2 = 0;
                for (int i = 0; i < 8; i++) { sceltaGiocatore[i] = false; }
                coppie1 = 0; coppie2 = 0;
                startGame();
                restartGame.Visible = false;
                scrittaMemory.Visible = false;
            }

        }

        private void carta1_Click(object sender, EventArgs e)
        {
            clickCarta(1);
        }

        private void carta2_Click(object sender, EventArgs e)
        {
            clickCarta(2);
        }

        private void carta3_Click(object sender, EventArgs e)
        {
            clickCarta(3);
        }

        private void carta4_Click(object sender, EventArgs e)
        {
            clickCarta(4);
        }

        private void carta5_Click(object sender, EventArgs e)
        {
            clickCarta(5);
        }

        private void carta6_Click(object sender, EventArgs e)
        {
            clickCarta(6);
        }

        private void carta7_Click(object sender, EventArgs e)
        {
            clickCarta(7);
        }

        private void carta8_Click(object sender, EventArgs e)
        {
            clickCarta(8);
        }
    }
}
