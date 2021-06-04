using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet {
    class Decodage : Carte {
        string[] RecupCarteCodee;
        public Decodage(string cheminFichier) : base(cheminFichier) { // Decodage d'une carte .chiffre uniquement.
            try {
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null) {
                    RecupCarteCodee = str.Split(':', '|');
                }
                sr.Close();
                for (int i = 0; i < 100; i++) {
                    carteChiffre[i] = Convert.ToInt32(RecupCarteCodee[i]);
                }
                int count = 0, nbAscii = 97; // 97 -> a 
                int ASCIICode = nbAscii;
                for (int i = 0; i < longueur; i++) {
                    for (int x = 0; x < largeur; x++) {

                        char ASCIIChar = Convert.ToChar(ASCIICode);
                        int decode = Convert.ToInt32(RecupCarteCodee[count]);
                        if (decode >= 64) {
                            carteClair[x, i] = 'M';
                        } else if (decode >= 32) {
                            carteClair[x, i] = 'F';
                        } else {
                            carteClair[x, i] = ASCIIChar;
                            if (decode == 1) // N
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 2) // O
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 3) // N-O
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 4) // S
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 5) // N-S
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 6) // S-O
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 7) // N-O-S
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 8) // E
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 9) // N-E
                            {
                                ASCIICode = nbAscii + 10;
                            }
                            if (decode == 10) // O-E
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 11) // O-E-N
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 12) // S-E
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 13) // S-E-N
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 14) // O-S-E
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            if (decode == 15) // FULL N-S-O-E
                            {
                                ASCIICode = nbAscii + 1;
                            }
                            nbAscii++ ;
                            // on veut le meme que celui du dessus vu que seul N reste il faudrait
                            // donc faire ascii = i-10 (pas sur enfaite)


                            //if (decode > )
                            //{
                            //  ASCIICode = nbAscii + 1;
                            //}

                            //int Nord = 1, Ouest = 2, Sud = 4, Est = 8;
                            // N-O = 3 ; N-S = 5 ; N-E = 9
                            // O-S = 6 ; O-E = 10
                            // S-E = 12
                            // N-O-S = 7
                            // O-S-E = 14
                            // FULL = 15


                        }
                        count++;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
        }  
    }
}