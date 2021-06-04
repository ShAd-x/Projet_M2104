using System;
using System.IO;

namespace Projet {
    class Program {
        static void Main(string[] args) {

            Codage Phatt = new Codage("../../../../Phatt.clair");
            Codage Scabb = new Codage("../../../../Scabb.clair");

            //Decodage PhattDec = new Decodage("../../../../Phatt.chiffre");
            Decodage ScabbDec = new Decodage("../../../../Scabb.chiffre");

            //PhattDec.AfficheChiffre();
            ScabbDec.AfficheChiffre();

            ScabbDec.AfficheClair();

            //Phatt.AfficheChiffre();
            //Phatt.AfficheClair();
            //Scabb.AfficheClair();
            //Phatt.CountParcelles();

            //Phatt.ParcelleSize(Convert.ToChar("b"));
            //Phatt.ParcelleSize('h');
            //Phatt.ParcelleSize('z');
            //Phatt.ParcelleSize();

            //Phatt.ParcelleBornee();
            //Phatt.ParcelleAVG();
            //Phatt.PromptEcritureChiffre();
            //Codage s = new Codage("../../../../Phatt.clair");
        }
    }
}