﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    class Carte
    {
        const int longueur = 10;
        const int largeur = 10;
        //string[,] carte = new string[longueur, largeur];
        string [,] transi = {

                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          {"X","X","X","X","X","X","X","X","X","X"},
                          

                        };
        public Carte(string[] args)
            
        {
            for(int j = 0; j < largeur; j++)
               {
                for (int y = 0; y < longueur; y++){
                    Console.WriteLine("{0}," , transi[j,y]);
                }
                Console.WriteLine("\n");
            }
            for(int i = 0; i < largeur; i++)
            {
                for (int x = 0; x < longueur; x++)
                {
                    for(int j = 0; j < largeur; j++)
                    {
                        for (int y = 0; y < longueur; y++){
                            Console.WriteLine("{0}" , transi[j,y]);
                        }
                        Console.WriteLine("\n");
                    }
                    transi[i,x] = Console.ReadLine();
                                  
                }
            }
        }
    }
}