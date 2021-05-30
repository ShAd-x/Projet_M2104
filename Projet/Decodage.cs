using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet {
    class Decodage : Carte {
        public Decodage(string cheminFichier) : base(cheminFichier) {
           /* try
            {
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null)
                {
                    string[] T = str.Split(':', '|');
                    Carte Map = new Carte(T);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            } */
        }  
    }
}