using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet {
    class Decodage : Carte {
        string[] RecupCarteCodee;
        public Decodage(string cheminFichier) : base(cheminFichier) { // Decodage d'une carte .chiffre uniquement.
            try {
                int[,] CarteCodee = new int[longueur, largeur];
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null) { // RECUP LIGNE AVEC TOUT LES CHIFFRES
                    RecupCarteCodee = str.Split(':', '|'); // ON ENLEVE : et /
                }
                sr.Close();
                for (int i = 0; i < 100; i++) {
                    carteChiffre[i] = Convert.ToInt32(RecupCarteCodee[i]); // ON MET TOUT CA DANS UN TABLEAU DE 100 VALEURS
                }
                int count = 0;
                for (int i = 0; i < longueur; i++) {
                    for (int x = 0; x < largeur; x++){
                        CarteCodee[x, i] = carteChiffre[count]; // ON RECUP LES 100 VALEURS ET TOUT FORMALISE CA COMME UNE VRAIE CARTE
                        count++;
                        //Console.Write(CarteCodee[x, i] + " ");
                    }
                    //Console.WriteLine("\n");
                }
                int ASCIICode = 97; // 97 -> a 
                //int nbAscii = nbAscii;
                for (int i = 0; i < longueur; i++) { // ON DECODE.
                    for (int x = 0; x < largeur; x++) {
                        char ASCIIChar = Convert.ToChar(ASCIICode);
                        int decode = CarteCodee[x, i];
                        if (decode >= 64) {
                            carteClair[x, i] = 'M';
                        } else if (decode >= 32) {
                            carteClair[x, i] = 'F';
                        } else {
                            //carteClair[x, i] = ASCIIChar;
                            //char nord, ouest;
                            /*if (i != 0) { // N
                                nord = carteClair[x, i-1];
                            }
                            if (i != 0) { // S
                                char sud = carteClair[x, i+1];
                            }
                            if (x != 0) { // O
                                ouest = carteClair[x - 1, i];
                            }
                            if (x != 9) { // E
                                char ouest = carteClair[x + 1, i];
                            }*/

                            if (decode == 1) { // N
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 2) { // O
                                carteClair[x, i] = carteClair[x, i-1];
                                //ASCIICode++;
                            }
                            if (decode == 3) { // N-O
                                if(x != 0) { 
                                    int code = carteClair[x - 1, i];
                                    code++;
                                    carteClair[x, i] = (char)code;
                                    ASCIICode++;
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 4) { // S
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 5) { // N-S
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 6) { // S-O
                                carteClair[x, i] = carteClair[x, i-1];
                            }
                            if (decode == 7) { // N-O-S
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 8) { // E
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    //ASCIICode++;
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 9) { // N-E
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    //ASCIICode++;
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 10) { // O-E
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 11) { // O-E-N
                                carteClair[x, i] = ASCIIChar;
                                ASCIICode++;
                            }
                            if (decode == 12) { // S-E
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                } else if(i != 0){
                                    carteClair[x, i] = carteClair[x, i-1];
                                }
                                ASCIICode++;
                            }
                            if (decode == 13) { // S-E-N
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 14) { // O-S-E
                                carteClair[x, i] = ASCIIChar;
                            }
                            if (decode == 15) { // FULL N-S-O-E
                                carteClair[x, i] = ASCIIChar;
                            }
                            
                            // on veut le meme que celui du dessus vu que seul N reste il faudrait
                            // donc faire ascii = i-10 (pas sur enfaite)

                            //int Nord = 1, Ouest = 2, Sud = 4, Est = 8;
                            // N-O = 3 ; N-S = 5 ; N-E = 9
                            // O-S = 6 ; O-E = 10
                            // S-E = 12
                            // N-O-S = 7
                            // O-S-E = 14
                            // FULL = 15
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
        }  
    }
}