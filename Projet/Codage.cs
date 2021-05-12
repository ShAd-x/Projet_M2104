using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    class Codage
    {
        public Codage(string cheminFichier)
        {
            try
            {
                const int longueur = 10;
                const int largeur = 10;
                int code;

                int[,] transi = new int[longueur, largeur];
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        char Char = str[i];
                        
                        if (Char == 'M')
                        {
                            code += 64;
                        } else if (Char == 'F')
                        {
                            code += 32;
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
