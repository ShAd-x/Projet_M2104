using System;
using System.IO;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Carte carte = new Carte("../../../../Scabb.clair");
            carte.AfficheClair();*/
            //carte.PromptEcriture();

            Codage c = new Codage("../../../../Phatt.clair");
            //c.CountP();
            c.Affiche();
            //Codage s = new Codage("../../../../Phatt.clair");

            //"../../../../Phatt.chiffre"
        }
    }
}