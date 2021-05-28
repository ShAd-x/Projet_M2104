using System;
using System.IO;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Carte carte = new Carte("../../../../Scabb.clair.txt");
            carte.AfficheClair();
            //carte.PromptEcriture();

            /*Codage c = new Codage("../../../../Scabb.clair.txt");
            c.CountP();
            c.Affiche();*/
            //Codage s = new Codage("../../../../Phatt.clair.txt");

            //"../../../../Phatt.chiffre.txt"
        }
    }
}