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
                int count = 0, ASCIICode = 97; // 97 -> a 
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