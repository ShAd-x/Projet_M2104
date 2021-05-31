using System;
using System.IO;

namespace Projet {
    class Program {
        static void Main(string[] args) {

            Codage Phatt = new Codage("../../../../Phatt.clair");
            Codage Scabb = new Codage("../../../../Scabb.clair");

            //Phatt.AfficheChiffre();
            Phatt.AfficheClair();
            //Scabb.AfficheClair();
            //Phatt.CountParcelles();
            //Phatt.ParcelleSize(Convert.ToChar("b"));
            //Phatt.ParcelleSize('h');
            //Phatt.ParcelleSize('z');
            Phatt.ParcelleBornée();
            //Phatt.PromptEcritureChiffre();
            //Codage s = new Codage("../../../../Phatt.clair");
        }
    }
}