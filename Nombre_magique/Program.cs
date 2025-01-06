using System;

class NombreMagiqueGame
{
    // Constantes
    private const int NOMBRE_MIN = 1;
    private const int NOMBRE_MAX = 10;
    private const int NOMBRE_MAX_TENTATIVE = 3;

    // Attributs de classe
    private int viesRestantes = NOMBRE_MAX_TENTATIVE;
    private int nombreMagique;
    private bool nombreTrouvé = false;

    // Méthode principale
    public static void Main(string[] args)
    {
        NombreMagiqueGame jeu = new NombreMagiqueGame();
        jeu.LancerJeu();
    }

    // Méthode pour lancer le jeu
    public void LancerJeu()
    {
        Console.WriteLine("Bienvenue dans le jeu du Nombre Magique !");
        GenererNombreMagique();

        // Boucle principale du jeu
        while (!nombreTrouvé)
        {
            int nombreUtilisateur = DemanderNombre(NOMBRE_MIN, NOMBRE_MAX);
            nombreTrouvé = VerifierNombre(nombreUtilisateur);

            if (viesRestantes == 0 && !nombreTrouvé)
            {
                Console.WriteLine("Vous avez perdu !");
                Console.WriteLine($"Le nombre magique était : {nombreMagique}");
                break;
            }
        }
        
        Console.WriteLine("Appuyez sur une touche pour quitter...");
        Console.ReadKey();
    }

    // Génère un nombre aléatoire
    private void GenererNombreMagique()
    {
        Random rand = new Random();
        nombreMagique = rand.Next(NOMBRE_MIN, NOMBRE_MAX + 1); // +1 pour inclure NOMBRE_MAX
    }

    // Demande un nombre à l'utilisateur
    private int DemanderNombre(int min, int max)
    {
        int nombreUtilisateur = 0;
        while (nombreUtilisateur < min || nombreUtilisateur > max)
        {
            Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max} : ");
            string? reponse = Console.ReadLine();

            if (!string.IsNullOrEmpty(reponse))
            {
                try
                {
                    nombreUtilisateur = int.Parse(reponse);
                    if (nombreUtilisateur < min || nombreUtilisateur > max)
                    {
                        Console.WriteLine($"ERREUR : Le nombre doit être entre {min} et {max}.");
                    }
                }
                catch
                {
                    Console.WriteLine("ERREUR : Veuillez entrer un nombre valide.");
                } 
            }
            
        }
        return nombreUtilisateur;
    }

    // Vérifie si le nombre est correct
    private bool VerifierNombre(int nombreUtilisateur)
    {
        if (nombreUtilisateur == nombreMagique)
        {
            Console.WriteLine("Bravo, vous avez trouvé le nombre magique !");
            return true;
        }
        else if (nombreUtilisateur < nombreMagique)
        {
            Console.WriteLine("Trop petit !");
            PerdreUneVie();
        }
        else
        {
            Console.WriteLine("Trop grand !");
            PerdreUneVie();
        }
        return false;
    }

    // Diminue les vies restantes
    private void PerdreUneVie()
    {
        viesRestantes--;
        if (viesRestantes > 0)
        {
            Console.WriteLine($"Vous avez perdu une vie ! Il vous reste {viesRestantes} tentatives.");
        }
    }
}
