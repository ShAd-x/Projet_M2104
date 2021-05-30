using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet {
    abstract class Carte {

        protected const int longueur = 10;
        protected const int largeur = 10;
        protected char[,] carteClair = new char[longueur, largeur];
        protected int[] carteChiffre = new int[longueur * largeur];
        protected string cheminFichier;

        private string pathToEcriture = "../../../../";
        private string chiffreExt = ".chiffre.test";
        private string clairExt = ".clair.test";

        public Carte(string cheminFichier) {
            this.cheminFichier = cheminFichier;
        }
        public void CountParcelles() {
            int countNbParcelles = 0;
            for (int ASCIICode = 97; ASCIICode < 123; ASCIICode++) {
                for (int i = 0; i < longueur; i++) {
                    for (int y = 0; y < largeur; y++) {
                        if (carteClair[i, y] == ASCIICode) {
                            countNbParcelles++;
                            Console.Write("({0},{1}) ; ", i, y);
                        }
                    }
                }
                if (countNbParcelles != 0) {
                    char ASCIIChar = Convert.ToChar(ASCIICode);
                    Console.WriteLine("Il y a {0} parcelles : {1}", countNbParcelles, ASCIIChar);
                }
                countNbParcelles = 0;
            }
            Console.WriteLine("Pour toutes les autres lettres il n'existe aucune parcelle dans la carte.");
            Console.WriteLine("\n");
        }
        public void PromptEcritureChiffre() {
            Console.WriteLine("Voulez vous écrire cette carte ? => 'oui'");
            if (Console.ReadLine().Equals("oui")) {
                Console.WriteLine("Veuillez donner le nom de fichier pour écrire la carte codée");
                EcritureChiffre(Console.ReadLine());
            } else
                Console.WriteLine("La carte n'a pas été écrite.");
        }
        public void EcritureChiffre(string nomFichierEcriture) {
            StreamWriter sw = null;
            try {
                sw = new StreamWriter(pathToEcriture + nomFichierEcriture + chiffreExt);
                int count = 0;
                for (int i = 0; i < largeur; i++) {
                    for (int y = 0; y < longueur; y++) {
                        if (y != 9) {
                            sw.Write(carteChiffre[count] + ":");
                        } else {
                            sw.Write(carteChiffre[count] + "|");
                        }
                        count++;
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            } finally {
                if (sw != null)
                    sw.Close();
            }
        }
        public void EcritureClair(string nomFichierEcriture) {
            StreamWriter sw = null;
            try {
                sw = new StreamWriter(pathToEcriture + nomFichierEcriture + clairExt);
                for (int i = 0; i < largeur; i++) {
                    for (int x = 0; x < longueur; x++) {
                        sw.Write(carteClair[x, i]);
                    }
                    sw.WriteLine("\n");
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            } finally {
                if (sw != null)
                    sw.Close();
            }
        }
        public void AfficheClair() {
            Console.WriteLine("Voici la carte claire:");
            for (int x = 0; x < largeur; x++) {
                for (int j = 0; j < longueur; j++) {
                    if (carteClair[j, x] == 'M') {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } else if (carteClair[j, x] == 'F') {
                        Console.ForegroundColor = ConsoleColor.Green;
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(carteClair[j, x]);
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void AfficheChiffre() {
            Console.WriteLine("Voici la carte chiffré:");
            int count = 0;
            for (int i = 0; i < largeur; i++) {
                for (int y = 0; y < longueur; y++) {
                    if (y != 9) {
                        Console.Write(carteChiffre[count] + ":");
                    } else {
                        Console.Write(carteChiffre[count] + "|");
                    }
                    count++;
                }
            }
            Console.WriteLine("\n");
        }
    }
}