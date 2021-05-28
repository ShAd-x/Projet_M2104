using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    class Carte 
    {
        const int longueur = 10;
        const int largeur = 10;
        char[,] carteClair = new char[longueur, largeur];
        public Carte() {
            for (int i = 0; i < largeur; i++) {
                for (int x = 0; x < longueur; x++) {
                    Console.WriteLine("Entrez une lettre en minuscule ou F (pour une foret) / M (pour une parcelle d'eau) aux coordonnée [ {0} , {1} ]", i, x);
                    Console.ForegroundColor = ConsoleColor.White;
                    string tempString = Console.ReadLine();
                    char tempChar = tempString[0];
                    if (char.IsLower(tempChar) || tempChar == 'F' || tempChar == 'M') {
                        carteClair[i, x] = tempChar;
                        AfficheClair();
                    } else {
                        x--;
                        Console.WriteLine("Erreur: Le caractère entré ne peut être que une lettre entre a et z ou F ou M \n \n ");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }         
                }
            }
            //PromptEcriture();
        }
        public Carte(string cheminFichier) {
            try {
                int y = 0;
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < largeur; i++)
                    {
                        carteClair[i, y] = str[i];
                    }
                    y++;
                }
                sr.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
            //AfficheClair();
            //PromptEcriture();
        }
        public void PromptEcriture() {
            /*Console.WriteLine("Voulez vous écrire cette carte ? Y pour oui");
            if (Console.ReadLine().Equals('Y') || Console.ReadLine().Equals('y'))
            {*/
            Console.WriteLine("Veuillez donner le nom de fichier pour écrire la carte");
            EcritureClair(Console.ReadLine());
        }
        public void EcritureClair(string nomFichierEcriture) {
            StreamWriter sw = new StreamWriter("../../../../"+nomFichierEcriture+".txt");
            for (int i = 0; i < largeur; i++)
            {
                for (int x = 0; x < longueur; x++)
                {
                    sw.Write(carteClair[x, i]);
                }
                sw.WriteLine("\n");
            }
            sw.Close();
        }
        public void AfficheClair() {
            Console.WriteLine("Voici la carte: \n");
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
    }
}