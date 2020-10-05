using System;
using System.Collections.Generic;

namespace popo
{
    class Program
    {

        enum niveaux 
        {
            Facile = 1,
            Moyen = 2,
            Difficile = 3,
        }

        static void Main(string[] args)
        {
            int Min = 0;
            int Max = 0;

            int compteur = 0; // création de la variable compteur pour la boucle
            int resultat = -1;// c'est ce que l'utilisateur saisie

            List<int> scores = new List<int>(); // création de la liste
   

            niveaux niveauDeLaPartie;
            if (args.Length == 3) // s'il y a pas d'argument alors on mets le menu utilisateur
            {
                niveauDeLaPartie = (niveaux)Convert.ToInt32(args[2]); // convertir l'argument en int
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Bienvenue !");
                Console.ResetColor();
                Console.WriteLine("___________________________");
                Console.WriteLine("Choisissez le niveau du jeu:");
                Console.WriteLine("Facile : taper 1\n" + "Moyen : taper 2\n" + "Difficile : taper 3\n");

                string saisieNiveau = Console.ReadLine();

                while (int.TryParse(saisieNiveau, out resultat) == false) // si l'utilisateur a écrit une chaine de caractére au lieu  d'un entier, alors erreur!
                {
                    Console.WriteLine("Erreur de frappe, recommence !");
                    saisieNiveau = Console.ReadLine();
                }

                niveauDeLaPartie = (niveaux)Convert.ToInt32(saisieNiveau);

                switch (niveauDeLaPartie)
                {
                    case niveaux.Facile:
                        Min = 1;
                        Max = 50;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Tu as choisi le niveau Facile\n\nCherche une valeur entre " + Min + " et 50"); //bloc d'instructions à utiliser si saisieNiveau vaut "1"
                        Console.ResetColor();
                        break;

                    case niveaux.Moyen:
                        Min = 1;
                        Max = 100;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Tu as choisi le niveau Moyen\nCherche une valeur entre 1 et 100"); //bloc d'instructions à utiliser si saisieNiveau vaut "2"
                        Console.ResetColor();
                        break;

                    case niveaux.Difficile:
                        Min = 1;
                        Max = 500;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tu as choisi le niveau Difficile\nCherche une valeur entre 1 et 500");//bloc d'instructions à utiliser si saisieNiveau vaut "3"
                        Console.ResetColor();
                        break;
                }
            }
            int partie;
            for (partie = 1; partie <= 5; partie++) // Boucle afin de passer à la partie suivante
            {
                int valeurATrouver = new Random().Next(Min, Max); // lancement de la valeur aléatoire à trouver
                Console.ForegroundColor = ConsoleColor.DarkRed; 
                Console.WriteLine("Partie n° :" + partie); // annonce de la partie
                Console.ResetColor();

                for (compteur = 0; resultat != valeurATrouver; compteur++) // boucle afin d'executer le jeu
                {
                    Console.WriteLine("Veuillez taper la valeur à trouver et appuyer sur  \"Entrée\"");
                    string saisie = Console.ReadLine();

                    if (int.TryParse(saisie, out resultat) == false) // si l'utilisateur a écrit une chaine de caractére au lieu  d'un entier, alors erreur!
                    {
                        Console.WriteLine("Tapez une valeur entre" + Min + Max);
                        continue;
                    }

                    int difference = valeurATrouver - resultat;

                    if (resultat != valeurATrouver + difference && niveauDeLaPartie == niveaux.Difficile) // Niveau difficile : Mauvaise valeur
                    {
                        Console.WriteLine("Mauvaise valeur, essayez encore");
                    }
                    else if (resultat > valeurATrouver)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Plus petite");
                        Console.ResetColor();
                        if ((difference >= -5 && difference <= 5) && niveauDeLaPartie == niveaux.Facile)
                        {
                            Console.WriteLine("Vous y êtes bientot!");
                        }
                    }

                    else if (resultat < valeurATrouver)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Plus grande");
                        Console.ResetColor();
                        if ((difference >= -5 && difference <= 5) && niveauDeLaPartie == niveaux.Facile)
                        {
                            Console.WriteLine("Allez Bientot");
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bravo !");
                        Console.ResetColor();
                        Console.WriteLine("Vous avez reussi au bout de " + (compteur + 1) + " fois ");

                    }
                    if (compteur >= 10)
                    {
                        Console.WriteLine("Plus de 10 coups, vous avez perdu :'( "); // le compteur s'arrête au bout de 10 coups!
                        break;

                    }

                }
                int scorePartie = (10 - compteur); // 10 coups total divisé par le nombre de coups effectués dans une partie
                
                scores.Add(scorePartie);
                Console.WriteLine("Votre score est de " + scorePartie + " points");
            }

            int cumulDesScores = 0;
            foreach (int score in scores) // Boucle pour calculer la moyenne du score de chaque partie. Grace à cette boucle, je parcours la liste.
            {
                cumulDesScores = score + cumulDesScores;
            }

            double scoreTotal = cumulDesScores;
            Console.WriteLine("Votre score total est de " + scoreTotal + " points");
        }
    }
}
