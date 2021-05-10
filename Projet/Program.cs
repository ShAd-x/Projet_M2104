using System;
using System.IO;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string str;
                StreamReader sr = new StreamReader("../../../../Phatt.chiffre.txt");
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
            }
        }        
    }
}
