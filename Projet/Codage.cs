using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet {
    class Codage : Carte {
        public Codage(string cheminFichier) : base(cheminFichier) { // Decodage d'une carte .clair uniquement.
            try {
                int y = 0;
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null) {
                    for(int i = 0; i < largeur ; i++)
                        carteClair[i, y] = str[i];
                    y++;
                }
                sr.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
            int count = 0;
            for (int i = 0; i < longueur; i++) {
                for (int y = 0; y < largeur; y++) {
                    char Char = carteClair[y, i];

                    /*Error out of array (logique)
                     * char Nord = recup[y, i-1]; -> Nord + 1
                    char Sud = recup[y, i+1]; -> Sud + 4
                    char Ouest = recup[y-1, i]; -> Ouest + 2
                    char Est = recup[y+1, i]; -> Est + 8 */

                    // i = lignes
                    // y = colonnes

                    carteChiffre[count] = 0;

                    // Directions
                    // Nord
                    if (i != 0)
                        if (carteClair[y, i - 1] != Char)
                            carteChiffre[count] += 1;
                    // Sud
                    if (i != 9)
                        if(carteClair[y, i + 1] != Char)
                            carteChiffre[count] += 4;
                    // Ouest
                    if (y != 0)
                        if(carteClair[y - 1, i] != Char)
                            carteChiffre[count] += 2;
                    // Est
                    if (y != 9)
                        if(carteClair[y + 1, i] != Char)
                            carteChiffre[count] += 8;

                    // Cas spéciaux
                    if (Char == 'M')
                        carteChiffre[count] += 64;
                    if (Char == 'F')
                        carteChiffre[count] += 32;

                    // Bordures
                    if (i == 0)
                        carteChiffre[count] += 1;
                    if (i == 9)
                        carteChiffre[count] += 4;
                    if (y == 0)
                        carteChiffre[count] += 2;
                    if (y == 9)
                        carteChiffre[count] += 8;

                    /*if(y != 9) { Affichage de la carte dès son obtention désactivé 
                        Console.Write(carteChiffre[count] + ":");
                    } else {
                        Console.Write(carteChiffre[count] + "|");
                    }*/
                    count++;
                }
            }
            //Console.WriteLine("\n");
        }
    }
}