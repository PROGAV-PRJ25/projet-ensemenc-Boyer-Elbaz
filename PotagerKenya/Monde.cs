public class Monde
{
    public List<Terrain> terrainsDuMonde {get; set;}

    public Chunk leChunk {get; set;}

    public int semaine {get; set;}

    public int mois {get; set;}

    public Monde()
    {
        terrainsDuMonde = new List<Terrain>();

        Terrain1 terrain1 = new Terrain1();
        Terrain2 terrain2 = new Terrain2();
        Terrain3 terrain3 = new Terrain3();
        Terrain4 terrain4 = new Terrain4();

        terrainsDuMonde.Add(terrain1);
        terrainsDuMonde.Add(terrain2);
        terrainsDuMonde.Add(terrain3);
        terrainsDuMonde.Add(terrain4);

        leChunk = new Chunk();

        semaine = 1;
    }

    public void SemaineNiveauxRessources()
    {
        semaine++;
        foreach (Terrain terrain in terrainsDuMonde)
        {
            foreach (Plante plante in terrain.plantes)
            {
                if ((plante.enVie)&&(plante.malade == false)) // La plante doit être en vie ET en bonne santé pour grandir ou donner des ressources
                {
                    // La plante grandit
                    char newLevel = 'I';
                    if (plante.visuelPlante.Length <= 4) // Le niveau d'une plante ne peut pas être supérieur à 3
                    {
                        Console.WriteLine($"{plante.visuelPlante} a grandi");
                        plante.visuelPlante += newLevel;
                        terrain.grille[plante.x][plante.y] = plante.visuelPlante;
                    }
                    else
                    {
                        switch (terrain.numeroTerrain)
                        {
                            case 1:
                                if (plante.numeroSerie == 1) // Mangue
                                {
                                    terrain.ressources[0]++;
                                }
                                else if (plante.numeroSerie == 8) // Baobab
                                {
                                    terrain.ressources[1]++;
                                }
                                else if (plante.numeroSerie == 9) // Sorgho
                                {
                                    terrain.ressources[2]++;
                                }
                                break;
                            case 2:
                                if (plante.numeroSerie == 1) // Avocat
                                {
                                    terrain.ressources[0]++;
                                }
                                else if (plante.numeroSerie == 10) // Safou
                                {
                                    terrain.ressources[1]++;
                                }
                                else if (plante.numeroSerie == 11) // Cocotier
                                {
                                    terrain.ressources[2]++;
                                }
                                break;
                            case 3:
                                if (plante.numeroSerie == 7) // Lentille
                                {
                                    terrain.ressources[0]++;
                                }
                                else if (plante.numeroSerie == 12) // Blé
                                {
                                    terrain.ressources[1]++;
                                }
                                else if (plante.numeroSerie == 5) // Rose
                                {
                                    terrain.ressources[2]++;
                                }
                                break;
                            case 4:
                                if (plante.numeroSerie == 3) // Ananas
                                {
                                    terrain.ressources[0]++;
                                }
                                else if (plante.numeroSerie == 6) // Tomate
                                {
                                    terrain.ressources[1]++;
                                }
                                else if (plante.numeroSerie == 4) // Palmier
                                {
                                    terrain.ressources[2]++;
                                }
                                break;
                        }
                    }
                }
            }
        }
    }

    public void MaladieOuMort()
    {
        List<Plante> plantesRetirer = new List<Plante>(); // Les plantes qui vont mourir

        foreach (Terrain terrain in terrainsDuMonde)
        {
            foreach (Plante plante in terrain.plantes)
            {
                // Cas de la maladie de la plante

                if (plante.semainesMalade == 3) // Une plante guérit au bout de 3 semaines, même si elle peut retomber malade
                {
                    plante.malade = false;
                    plante.semainesMalade = 0;
                }

                Random rng = new Random();
                int maladie = rng.Next(0, 7); // 1/7 pour chaque plante de tomber malade
                if (maladie == 0)
                {
                    plante.malade = true;
                    plante.semainesMalade++;
                    Console.WriteLine($"{plante.visuelPlante} malade");
                }



                // Cas de la mort d'une plante

                double deathVariable = 0;

                if (terrain.luminositeActuelle < plante.seuilLuminosite)
                {
                    deathVariable += 0.33;
                }
                if ((terrain.humiditeActuelle < plante.humiditeSolMin) || (plante.humiditeSolMax < terrain.humiditeActuelle))
                {
                    deathVariable += 0.33;
                }
                if ((terrain.temperatureActuelleEnDeg < plante.tempMinEnDeg) || (plante.tempMaxEnDeg < terrain.temperatureActuelleEnDeg))
                {
                    deathVariable += 0.33;
                }

                if (deathVariable >= 0.5)
                {
                    plante.enVie = false;
                    Console.WriteLine($"La plante {plante.visuelPlante} est morte...");
                    terrain.grille[plante.x][plante.y] = "🟫";
                    plantesRetirer.Add(plante);
                }
            }
            foreach (Plante planteMorte in plantesRetirer)
            {
                terrain.plantes.Remove(planteMorte);
            }
        }
    }

    public void PlanterNouvellePlante()
    {
        bool reponseInvalide; // Variable qui va nous être utile lorsque le joueur doit répondre à des questions
        bool reponseInvalide2; // Variable qui va nous être utile lorsque l'on rentre dans une double boucle while
        
        // On vérifie que le joueur dispose de ressources pour planter
        int ressourcesTotalesDesTerrains = 0;

        foreach (Terrain terrain in terrainsDuMonde)
        {
            ressourcesTotalesDesTerrains += terrain.ressourcesTotales;
        }

        if (ressourcesTotalesDesTerrains == 0)
        {
            Console.WriteLine("Vous n'avez actuellement aucune ressource. Appuyer sur entrée pour passer à la semaine suivante.");
        }
        else if (ressourcesTotalesDesTerrains > 0)
            {
                string reponse;
                do
                {
                    reponseInvalide = true;
                    Console.WriteLine($"Vous disposez de {ressourcesTotalesDesTerrains} ressources. Voulez-vous ensemencer ? (oui/non)");
                    reponse = Convert.ToString(Console.ReadLine());
                    if((reponse != "oui")&&(reponse != "non"))
                    {
                        Console.WriteLine("Veuillez entrer une réponse valide.");
                    }
                    else
                    {
                        reponseInvalide = false;
                    }
                }
                while(reponseInvalide);

                if (reponse == "non")
                {
                    Console.WriteLine($"Il vous reste {ressourcesTotalesDesTerrains} ressources. Appuyer sur entrée pour passer à la semaine suivante");
                }
                else if (reponse == "oui")
                {
                    int nbePlantes;
                    do
                    {
                        reponseInvalide = true;
                        Console.WriteLine($"Combien de plantes voulez-vous semer ?");
                        string input = Console.ReadLine();
                        
                        // Essayer de convertir l'entrée en entier
                        if (int.TryParse(input, out nbePlantes))
                        {
                            // Vérifier si le nombre de plantes est valide
                            if (nbePlantes > ressourcesTotalesDesTerrains)
                            {
                                Console.WriteLine("Le nombre de plantes dépasse les ressources disponibles.");
                            }
                            else
                            {
                                reponseInvalide = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez entrer un nombre entier valide.");
                        }
                    }
                    while (reponseInvalide);



                    for (int i = 0; i < nbePlantes; i++)
                    {
                        int numeroTerrainChoisi;
                        
                        // Le joueur doit choisir un terrain disposant de ressources afin de semer
                        do
                        {
                            reponseInvalide = true;
                            Console.WriteLine("Choisissez un terrain à semer. (1/2/3/4)");
                            string input = Console.ReadLine();
                            
                            if (int.TryParse(input, out numeroTerrainChoisi))
                            {
                                foreach (Terrain terrain in terrainsDuMonde)
                                {
                                    if ((terrain.numeroTerrain == numeroTerrainChoisi) && (terrain.ressourcesTotales > 0))
                                    {
                                        reponseInvalide = false;
                                    }
                                    else if((terrain.numeroTerrain == numeroTerrainChoisi) && (terrain.ressourcesTotales == 0))
                                    {
                                        Console.WriteLine("Ce terrain ne dispose pas de ressources.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Veuillez entrer un nombre entier valide.");
                            }
                        }
                        while (reponseInvalide);

                        int lignePlante;
                        int colonnePlante;
                        string ressourceChoisie;
                        foreach (Terrain terrain in terrainsDuMonde)
                    {
                        if (terrain.numeroTerrain == numeroTerrainChoisi)
                        {
                            switch (numeroTerrainChoisi)
                            {
                                case 1: // Le joueur veut planter sur le terrain 1

                                    do
                                    {
                                        reponseInvalide = true;
                                        Console.WriteLine($"Choisissez une plante à semer (vous ne pouvez pas semer si vous n'avez pas de ressource pour la plante) (mangue 🥭 / baobab 🌳 / sorgho 🌿)");
                                        ressourceChoisie = Convert.ToString(Console.ReadLine());
                                        if ((ressourceChoisie != "mangue") && (ressourceChoisie != "baobab") && (ressourceChoisie != "sorgho"))
                                        {
                                            Console.WriteLine("Veuillez resaissir une plante valide");
                                        }
                                        else
                                        {
                                            reponseInvalide = false;
                                        }
                                    }
                                    while (reponseInvalide);

                                
                                // On traite les cas où il y a des ressources sur le terrain 1 mais le joueur choisit une plante n'ayant pas de ressource
                                    if ((ressourceChoisie == "mangue") && (terrain.ressources[0] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource mangue");
                                    }
                                    else if ((ressourceChoisie == "baobab") && (terrain.ressources[1] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource baobab");
                                    }
                                    else if ((ressourceChoisie == "sorgho") && (terrain.ressources[2] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource sorgho");
                                    }

                                    if ((ressourceChoisie == "mangue") && (terrain.ressources[0] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Mangue nouvellePlante = new Mangue();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🥭";
                                        terrain.ressources[0]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    else if ((ressourceChoisie == "baobab") && (terrain.ressources[1] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Baobab nouvellePlante = new Baobab();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌳";
                                        terrain.ressources[1]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    else if ((ressourceChoisie == "sorgho") && (terrain.ressources[2] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Sorgho nouvellePlante = new Sorgho();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌿";
                                        terrain.ressources[2]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    break;
                                case 2:
                                    do
                                    {
                                        reponseInvalide = true;
                                        Console.WriteLine($"Choisissez une plante à semer (vous ne pouvez pas semer si vous n'avez pas de ressource pour la plante) (avocat 🥑 / safou 🍆 / cocotier 🥥)");
                                        ressourceChoisie = Convert.ToString(Console.ReadLine());
                                        if ((ressourceChoisie != "avocat") && (ressourceChoisie != "safou") && (ressourceChoisie != "cocotier"))
                                        {
                                            Console.WriteLine("Veuillez resaissir une plante valide");
                                        }
                                        else
                                        {
                                            reponseInvalide = false;
                                        }
                                    }
                                    while (reponseInvalide);

                                    // On traite les cas où il y a des ressources sur le terrain 2 mais le joueur choisit une plante n'ayant pas de ressource
                                    if ((ressourceChoisie == "avocat") && (terrain.ressources[0] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource avocat");
                                    }
                                    else if ((ressourceChoisie == "safou") && (terrain.ressources[1] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource safou");
                                    }
                                    else if ((ressourceChoisie == "cocotier") && (terrain.ressources[2] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource cocotier");
                                    }


                                    if ((ressourceChoisie == "avocat") && (terrain.ressources[0] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Avocat nouvellePlante = new Avocat();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🥑";
                                        terrain.ressources[0]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    else if ((ressourceChoisie == "safou") && (terrain.ressources[1] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Safou nouvellePlante = new Safou();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🍆";
                                        terrain.ressources[1]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    else if ((ressourceChoisie == "cocotier") && (terrain.ressources[2] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            do
                                            {
                                                reponseInvalide2 = true;
                                                Console.WriteLine("Choisissez la ligne de la plante");
                                                lignePlante = Convert.ToInt32(Console.ReadLine());
                                                lignePlante--;
                                                Console.WriteLine("Choisissez la colonne de la plante");
                                                colonnePlante = Convert.ToInt32(Console.ReadLine());
                                                colonnePlante--;
                                                if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6))
                                                {
                                                    Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                                }
                                                else
                                                {
                                                    reponseInvalide2 = false;
                                                }
                                            }
                                            while (reponseInvalide2);
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if (terrain.grille[lignePlante][colonnePlante] != "🟫")
                                            {
                                                Console.WriteLine("Une plante existe déjà à cet emplacement, veuillez rechoisir.");
                                            }
                                            else
                                            {
                                                reponseInvalide = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Cocotier nouvellePlante = new Cocotier();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🥥";
                                        terrain.ressources[2]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");

                                    }
                                    break;
                                case 3:
                                    do
                                    {
                                        Console.WriteLine($"Choisissez une plante à semer (vous ne pouvez pas semer si vous n'avez pas de ressource pour la plante) (lentille 🟢 / ble 🌾 / rose 🌹)");
                                        ressourceChoisie = Convert.ToString(Console.ReadLine());
                                        if ((ressourceChoisie != "lentille") && (ressourceChoisie != "ble") && (ressourceChoisie != "rose"))
                                        {
                                            Console.WriteLine("Veuillez resaissir une plante valide");
                                        }
                                        else
                                        {
                                            reponseInvalide = false;
                                        }
                                    }
                                    while (reponseInvalide);

                                    // On traite les cas où il y a des ressources sur le terrain 3 mais le joueur choisit une plante n'ayant pas de ressource
                                    if ((ressourceChoisie == "lentille") && (terrain.ressources[0] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource lentille");
                                    }
                                    else if ((ressourceChoisie == "ble") && (terrain.ressources[1] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource ble");
                                    }
                                    else if ((ressourceChoisie == "rose") && (terrain.ressources[2] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource rose");
                                    }

                                    if ((ressourceChoisie == "lentille") && (terrain.ressources[0] > 0))
                                    {

                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Lentille nouvellePlante = new Lentille();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🟢";
                                        terrain.ressources[0]--;
                                    }
                                    else if ((ressourceChoisie == "ble") && (terrain.ressources[1] > 0))
                                    {

                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Ble nouvellePlante = new Ble();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌾";
                                        terrain.ressources[1]--;
                                    }
                                    else if ((ressourceChoisie == "rose") && (terrain.ressources[2] > 0))
                                    {

                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else if ((terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Rose nouvellePlante = new Rose();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌹";
                                        terrain.ressources[2]--;
                                    }

                                    break;
                                case 4:
                                    do
                                    {
                                        reponseInvalide = true;
                                        Console.WriteLine($"Choisissez une plante à semer (vous ne pouvez pas semer si vous n'avez pas de ressource pour la plante) (ananas 🍍 / tomate 🍅 / palmier 🌴)");
                                        ressourceChoisie = Convert.ToString(Console.ReadLine());
                                        if ((ressourceChoisie != "ananas") && (ressourceChoisie != "tomate") && (ressourceChoisie != "palmier"))
                                        {
                                            Console.WriteLine("Veuillez resaissir une plante valide");
                                        }
                                        else
                                        {
                                            reponseInvalide = false;
                                        }
                                    }
                                    while (reponseInvalide);

                                // On traite les cas où il y a des ressources sur le terrain 4 mais le joueur choisit une plante n'ayant pas de ressource
                                    if ((ressourceChoisie == "ananas") && (terrain.ressources[0] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource ananas");
                                    }
                                    else if ((ressourceChoisie == "tomate") && (terrain.ressources[1] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource tomate");
                                    }
                                    else if ((ressourceChoisie == "palmier") && (terrain.ressources[2] == 0))
                                    {
                                        Console.WriteLine("Vous n'avez pas encore de ressource palmier");
                                    }



                                    if ((ressourceChoisie == "ananas") && (terrain.ressources[0] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Ananas nouvellePlante = new Ananas();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🍍";
                                        terrain.ressources[0]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    else if ((ressourceChoisie == "tomate") && (terrain.ressources[1] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        Tomate nouvellePlante = new Tomate();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🍅";
                                        terrain.ressources[1]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    else if ((ressourceChoisie == "palmier") && (terrain.ressources[2] > 0))
                                    {
                                        do
                                        {
                                            reponseInvalide = true;
                                            Console.WriteLine("Choisissez la ligne de la plante");
                                            lignePlante = Convert.ToInt32(Console.ReadLine());
                                            lignePlante--;
                                            Console.WriteLine("Choisissez la colonne de la plante");
                                            colonnePlante = Convert.ToInt32(Console.ReadLine());
                                            colonnePlante--;
                                            if ((lignePlante < 0) && (lignePlante > 6) || (colonnePlante < 0) && (colonnePlante > 6) || (terrain.grille[lignePlante][colonnePlante] != "🟫"))
                                            {
                                                Console.WriteLine("Veuillez entrer une ligne ou colonne valide");
                                            }
                                            else
                                            {
                                                reponseInvalide2 = false;
                                            }
                                        }
                                        while (reponseInvalide);

                                        PalmierAHuile nouvellePlante = new PalmierAHuile();
                                        terrain.plantes.Add(nouvellePlante);
                                        nouvellePlante.x = lignePlante;
                                        nouvellePlante.y = colonnePlante;
                                        terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌴";
                                        terrain.ressources[2]--;
                                        Console.WriteLine("Votre plante à été plantée avec succès.");
                                    }
                                    break;

                            }
                        }

                    }





                    }
                }

            }
    }

    public override string ToString()
    {
        string afficher = $"===== POTAGER semaine {semaine} =====\n\n";

        foreach (var terrain in terrainsDuMonde)
        {
            afficher += terrain.Afficher() + "\n";
        }

        return afficher;
    }
}