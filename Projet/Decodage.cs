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
                int ASCIICode = 97, maxchar = 97; // 97 -> a 
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
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i] + 1); 
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 2) { // O
                                if(i != 0) {
                                    carteClair[x, i] = carteClair[x, i-1];
                                    ASCIICode = Convert.ToInt32(carteClair[x, i - 1] + 1);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 3) { // N-O
                                carteClair[x, i] = Convert.ToChar(maxchar);
                            }
                            if (decode == 4) { // S
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i] + 1);
                                } else if (i != 0) {
                                    carteClair[x, i] = carteClair[x, i-1];
                                    ASCIICode = Convert.ToInt32(carteClair[x, i-1] + 1);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }              
                            }
                            if (decode == 5) { // N-S
                                if(x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i] + 1);
                                } else {
                                    carteClair[x, i] = Convert.ToChar(maxchar);
                                }
                            }
                            if (decode == 6) { // S-O
                                if(i != 0) { 
                                    carteClair[x, i] = carteClair[x, i-1];
                                    ASCIICode = Convert.ToInt32(carteClair[x, i - 1] + 1);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 7) { // N-O-S   
                                if (x != 0 && i != 0) {
                                    if (CarteCodee[x + 1, i] != 5 && CarteCodee[x + 1, i] != 3 && CarteCodee[x + 1, i] != 1 && CarteCodee[x + 1, i] != 7
                                            && CarteCodee[x + 1, i] != 9 && CarteCodee[x + 1, i] != 11 && CarteCodee[x + 1, i] != 13) {
                                        if (CarteCodee[x + 1, i - 1] < 32) {
                                            carteClair[x, i] = carteClair[x + 1, i - 1];
                                            ASCIICode = Convert.ToInt32(carteClair[x + 1, i - 1]);
                                        } else {
                                            carteClair[x, i] = Convert.ToChar(maxchar);
                                        }
                                    } else {
                                        carteClair[x, i] = Convert.ToChar(maxchar);
                                    }
                                } else {
                                    carteClair[x, i] = Convert.ToChar(maxchar);
                                }
                            }
                            if (decode == 8) { // E
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i] + 1);
                                } else if (i != 0) {
                                    carteClair[x, i] = carteClair[x, i - 1];
                                    ASCIICode = Convert.ToInt32(carteClair[x, i - 1] + 1);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 9) { // N-E
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i]+1);
                                } else {
                                    carteClair[x, i] = Convert.ToChar(maxchar);
                                }
                            }
                            if (decode == 10) { // O-E
                                if(i != 0){
                                    ASCIICode = Convert.ToInt32(carteClair[x, i-1]);
                                    carteClair[x, i] = Convert.ToChar(ASCIICode);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                                ASCIICode++;
                            }
                            if (decode == 11) { // O-E-N
                                carteClair[x, i] = Convert.ToChar(maxchar);
                                ASCIICode = carteClair[x, i] + 1;
                            }
                            if (decode == 12) { // S-E
                                if (x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i] + 1);
                                } else if(i != 0){
                                    carteClair[x, i] = carteClair[x, i-1];
                                    ASCIICode = Convert.ToInt32(carteClair[x, i - 1] + 1);
                                }
                            }
                            if (decode == 13) { // S-E-N
                                if(x != 0) {
                                    carteClair[x, i] = carteClair[x - 1, i];
                                    ASCIICode = Convert.ToInt32(carteClair[x - 1, i] + 1);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }   
                            }
                            if (decode == 14) { // O-S-E
                                if (i != 0) {
                                    ASCIICode = Convert.ToInt32(carteClair[x, i - 1]);
                                    carteClair[x, i] = Convert.ToChar(ASCIICode);
                                } else {
                                    carteClair[x, i] = ASCIIChar;
                                }
                            }
                            if (decode == 15) { // FULL N-S-O-E
                                carteClair[x, i] = Convert.ToChar(maxchar+1);
                                maxchar = carteClair[x, i];
                            }

                            if(ASCIICode > maxchar) {
                                maxchar = ASCIICode;
                            }

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