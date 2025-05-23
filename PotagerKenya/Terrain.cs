public abstract class Terrain
{
    public int x { get; set; } // Coordonnées des cases du terrain
    public int y { get; set; }

    public string[][] grille { get; set; } // Chaque terrain est une grille

    public List<Plante> plantes { get; set; } // Chaque terrain possède une liste de plantes

    public int[] ressources { get; set; } // Chaque terrain à des ressources stockables

    public int ressourcesTotales => ressources.Sum();



    // Attributs définissant le type de terrain :
    public int numeroTerrain { get; set; }

    public string biome { get; set; }

    public int altitudeEnMetres { get; set; }

    public string typeDeSol { get; set; }

    public int temperatureMoyenneEnDeg { get; set; }

    public int humiditeMoyenne { get; set; } // l'humidité peut varier de 0 à 100

    public int luminositeMoyenne { get; set; }

    // Attributs définissant les conditions climatiques en temps réel :
    public int temperatureActuelleEnDeg { get; set; }

    public int humiditeActuelle { get; set; }

    public int luminositeActuelle { get; set; }

    public Terrain(int X = 7, int Y = 7) // Taille 7
    {
        x = X;
        y = Y;
        grille = new string[x][];
        plantes = new List<Plante>();
        ressources = new int[3];

        for (int i = 0; i < grille.Length; i++) // Définition de la grille de terrain
        {
            grille[i] = new string[y];
            for (int j = 0; j < grille[i].Length; j++)
            {
                grille[i][j] = "🟫";
            }
        }
    }

    public void DebutJeu() // Le début du jeu donne au joueur une plante de chaque espèce en fonction du terrain (NB : chaque terrain possède des plantes différentes)
    {
        Random rng = new Random();
        switch (numeroTerrain)
        {
            case 1: // Dans la savane, le joueur commence avec deux manguiers, deux sorghos et deux baobabs

                Mangue mangue1 = new Mangue();
                plantes.Add(mangue1);
                Mangue mangue2 = new Mangue();
                plantes.Add(mangue2);
                Sorgho sorgho1 = new Sorgho();
                plantes.Add(sorgho1);
                Sorgho sorgho2 = new Sorgho();
                plantes.Add(sorgho2);
                Baobab baobab1 = new Baobab();
                plantes.Add(baobab1);
                Baobab baobab2 = new Baobab();
                plantes.Add(baobab2);

                // Position des plantes

                int x_aleatoire = rng.Next(0, x);
                int y_aleatoire = rng.Next(0, y);

                foreach (Plante plante in plantes)
                {
                    while (grille[x_aleatoire][y_aleatoire] != "🟫") // Création des plantes sur un espace vierge
                    {
                        x_aleatoire = rng.Next(0, x);
                        y_aleatoire = rng.Next(0, y);
                    }

                    grille[x_aleatoire][y_aleatoire] = plante.visuelPlante;
                    plante.x = x_aleatoire;
                    plante.y = y_aleatoire;
                }
                break;
            case 2: // Dans la forêt tropicale, le joueur commence avec un avocatier, un safou et un cocotier
                Avocat avocat1 = new Avocat();
                plantes.Add(avocat1);
                Safou safou1 = new Safou();
                plantes.Add(safou1);
                Cocotier cocotier1 = new Cocotier();
                plantes.Add(cocotier1);
                Avocat avocat2 = new Avocat();
                plantes.Add(avocat2);
                Safou safou2 = new Safou();
                plantes.Add(safou2);
                Cocotier cocotier2 = new Cocotier();
                plantes.Add(cocotier2);

                // Position des plantes

                x_aleatoire = rng.Next(0, x);
                y_aleatoire = rng.Next(0, y);

                foreach (Plante plante in plantes)
                {
                    while (grille[x_aleatoire][y_aleatoire] != "🟫")
                    {
                        x_aleatoire = rng.Next(0, x);
                        y_aleatoire = rng.Next(0, y);
                    }

                    grille[x_aleatoire][y_aleatoire] = plante.visuelPlante;
                    plante.x = x_aleatoire;
                    plante.y = y_aleatoire;
                }
                break;
            case 3: // Dans la zône montagneuse, le joueur commence avec une lentille, un blé et un rosier

                Lentille lentille1 = new Lentille();
                plantes.Add(lentille1);
                Ble ble1 = new Ble();
                plantes.Add(ble1);
                Rose rose1 = new Rose();
                plantes.Add(rose1);
                Lentille lentille2 = new Lentille();
                plantes.Add(lentille2);
                Ble ble2 = new Ble();
                plantes.Add(ble2);
                Rose rose2 = new Rose();
                plantes.Add(rose2);

                // Position des plantes

                x_aleatoire = rng.Next(0, x);
                y_aleatoire = rng.Next(0, y);

                foreach (Plante plante in plantes)
                {
                    while (grille[x_aleatoire][y_aleatoire] != "🟫")
                    {
                        x_aleatoire = rng.Next(0, x);
                        y_aleatoire = rng.Next(0, y);
                    }

                    grille[x_aleatoire][y_aleatoire] = plante.visuelPlante;
                    plante.x = x_aleatoire;
                    plante.y = y_aleatoire;
                }
                break;
            case 4: // Dans la zône côtuère, le joueur commence avec un ananas, un tomatier et un palmier à huile

                Ananas ananas1 = new Ananas();
                plantes.Add(ananas1);
                Tomate tomate1 = new Tomate();
                plantes.Add(tomate1);
                PalmierAHuile palmier1 = new PalmierAHuile();
                plantes.Add(palmier1);
                Ananas ananas2 = new Ananas();
                plantes.Add(ananas2);
                Tomate tomate2 = new Tomate();
                plantes.Add(tomate2);
                PalmierAHuile palmier2 = new PalmierAHuile();
                plantes.Add(palmier2);

                // Position des plantes

                x_aleatoire = rng.Next(0, x);
                y_aleatoire = rng.Next(0, y);

                foreach (Plante plante in plantes)
                {
                    while (grille[x_aleatoire][y_aleatoire] != "🟫")
                    {
                        x_aleatoire = rng.Next(0, x);
                        y_aleatoire = rng.Next(0, y);
                    }

                    grille[x_aleatoire][y_aleatoire] = plante.visuelPlante;
                    plante.x = x_aleatoire;
                    plante.y = y_aleatoire;
                }
                break;
        }

    }

    public string RessourceParTerrain(int numeroTerrain)
    {
        switch (numeroTerrain)
        {
            case 1:
                return $"{ressources[0]} 🥭, {ressources[1]} 🌳, {ressources[2]} 🌿";
            case 2:
                return $"{ressources[0]} 🥑, {ressources[1]} 🍆, {ressources[2]} 🥥";
            case 3:
                return $"{ressources[0]} 🟢, {ressources[1]} 🌾, {ressources[2]} 🌹";
            case 4:
                return $"{ressources[0]} 🍍, {ressources[1]} 🍅, {ressources[2]} 🌴";
            default:
                return "Terrain inconnu.";
        }
    }


    public string Afficher() // Méthode Afficher permet de l'appeler dans l'override string ToString() de la classe Monde
    {
        string enclos = "";

        enclos += $"Terrain {numeroTerrain} \nBiome : {biome} \nTempérature : {temperatureActuelleEnDeg} °C \nHumidité : {humiditeActuelle}% \nLuminosité : {luminositeActuelle}% \n";

        for (int i = 0; i < grille.Length; i++)
        {
            for (int j = 0; j < grille[i].Length; j++)
            {
                enclos += grille[i][j] + "   ";
            }
            enclos += "\n";
            enclos += "\n";
        }
        enclos += $"Ressources accumulées pour la {biome} : " + RessourceParTerrain(numeroTerrain) + "\n";
        return enclos;
    }

  public override string ToString() // Cet override est appelé uniquement lorsque le terrain a besoin d'être affiché seul
  {
    string enclos = "";

    enclos += $"Terrain {numeroTerrain} \nBiome : {biome} \nTempérature : {temperatureActuelleEnDeg} °C \nHumidité : {humiditeActuelle}% \nLuminosité : {luminositeActuelle}% \n";

    for (int i = 0; i < grille.Length; i++)
    {
        for (int j = 0; j < grille[i].Length; j++)
        {
            enclos += grille[i][j] + "   ";
        }
        enclos += "\n";
        enclos += "\n";
    }
    enclos += $"Ressources accumulées pour la {biome} : " + RessourceParTerrain(numeroTerrain) + "\n";
    return enclos;
  }
}