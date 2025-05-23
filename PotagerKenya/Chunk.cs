public class Chunk : Animal
{
  public Chunk() : base("Chunk") {}


  public override void ApparitionAnimal(Monde monde) //Chunk apparaît dans un monde choisi
  {
    bool chunkReste = true; // Tant que true Chunk recommence ses actions
    int probaDisparition;  // Proba qu'il s'en aille à chaque tour
    string caseAvantChunk; // Permet de bien afficher la case sur laquelle était Chunk
    int reaction;
    Chunk unChunk = new Chunk(); // Chunk
    int x_random;
    int y_random;
    Random rng = new Random();
    int probaApparition = rng.Next(0,4); // Chunk le gourmand 🐿️ apparaît 1 fois sur 4 pour s'emparer de nos récoltes
    if (probaApparition == 0)
    {
      int numeroTerrainChunk = rng.Next(1, 5);
      foreach (Terrain terrain in monde.terrainsDuMonde)
      {
        if (terrain.numeroTerrain == numeroTerrainChunk) // Je selectionne le terrain de Chunk
        {
          do
          {
            x_random = rng.Next(0, 7);
            y_random = rng.Next(0, 7);
          }
          while (terrain.grille[x_random][y_random] == "🟫"); // La fée apparaît sur une case avec une plante

          unChunk.x = x_random;
          unChunk.y = y_random;
          caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
          terrain.grille[unChunk.x][unChunk.y] += "🐿️"; // Chunk arrive sur la case


          Console.WriteLine(terrain);
          do // Chunk réalise ses actions tant qu'il ne s'est pas décidé à partir
          {
            Console.WriteLine($"CHUNK EST SUR LE TERRAIN {numeroTerrainChunk}!! (Appuyer sur ENTREE)");
            Console.ReadLine();

            Console.WriteLine("Vous pouvez : Lui faire peur (tapez 1), lui donner une ressource pour qu'il s'en aille (tapez 2)");
            reaction = Convert.ToInt32(Console.ReadLine());
            if (reaction == 1)
            {
              Console.WriteLine("Vous : *ROOOAAAAR*");
              probaDisparition = rng.Next(0, 3);
              if (probaDisparition == 0) // Chunk part quand on lui fait peur (1/3)
              {
                chunkReste = false;
                terrain.grille[unChunk.x][unChunk.y] = caseAvantChunk;
                Console.WriteLine(terrain);
                Console.WriteLine("CHUNK S'EST ENFUI"); // Chunk s'enfui
              }
              else //Chunk dévort la plante même quand on lui fait peur (2/3)
              {
                terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                Console.WriteLine(terrain);
                Console.WriteLine("CHUNK A DEVORE TOUT CE QUI SE TROUVAIT SUR SA CASE (Appuyez sur ENTREE)"); // Chunk mange
                Console.ReadLine();
                terrain.grille[unChunk.x][unChunk.y] = "🟫"; //Chunk se déplace
                if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] == "🟫"))
                {
                  unChunk.x++; //Chunk se déplace ensuite vers le bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                }
                else if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] != "🟫"))
                {
                  unChunk.x++; //Chunk se déplace ensuite vers le bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] += "🐿️";

                }
                else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] == "🟫"))
                {
                  unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                }
                else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] != "🟫"))
                {
                  unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] += "🐿️";
                }
                Console.WriteLine(terrain);
                Console.WriteLine("CHUNK SE DEPLACE POUR DEVORER DE NOUVELLES PLANTES"); // Il se déplace puis nouveau tour de boucle
              }
            }
            else if (reaction == 2) // Si on veut donner une ressource à Chunk
            {
              string ressourcePourChunk;
              if (terrain.ressourcesTotales == 0) // Si on a pas de ressources
              {
                Console.WriteLine("Vous n'avez aucune ressource à donner à Chunk... il va se venger (Appuyez sur ENTREE)"); // Vous ne donnez rien à Chunk donc il dévore vos plantes :
                Console.ReadLine();
                terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                Console.WriteLine(terrain);
                Console.WriteLine("CHUNK A DEVORE TOUT CE QUI SE TROUVAIT SUR SA CASE (Appuyez sur ENTREE)"); // Chunk mange
                Console.ReadLine();
                terrain.grille[unChunk.x][unChunk.y] = "🟫"; //Chunk se déplace
                if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] == "🟫"))
                {
                  unChunk.x++; //Chunk se déplace ensuite vers le bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                }
                else if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] != "🟫"))
                {
                  unChunk.x++; //Chunk se déplace ensuite vers le bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] += "🐿️";

                }
                else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] == "🟫"))
                {
                  unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                }
                else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] != "🟫"))
                {
                  unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                  caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                  terrain.grille[unChunk.x][unChunk.y] += "🐿️";
                }
                Console.WriteLine(terrain);
                Console.WriteLine("CHUNK SE DEPLACE POUR DEVORER DE NOUVELLES PLANTES"); // Il se déplace puis nouveau tour de boucle
              }
              else // Si vous avez des ressources à lui donner
              {
                probaDisparition = rng.Next(0, 2);
                if (probaDisparition == 0) // Chunk part quand on lui donne une ressource (1/2)
                {
                  chunkReste = false;
                  terrain.grille[unChunk.x][unChunk.y] = caseAvantChunk;
                  switch (numeroTerrainChunk)
                  {
                    case 1:
                      Console.WriteLine("Voulez-vous lui donner ? (mangue 🥭, baobab 🌳, sorgho 🌿)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "mangue")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus de mangue à donner à Chuck");
                      }
                      else if (ressourcePourChunk == "baobab")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de baobab à donner à Chuck");

                      }
                      else if (ressourcePourChunk == "sorgho")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                      }
                      break;
                    case 2:
                      Console.WriteLine("Voulez-vous lui donner ? (avocat 🥑, safou 🍆, coco 🥥)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "avocat")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus d'avocat à donner à Chuck");
                      }
                      if (ressourcePourChunk == "safou")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de safou à donner à Chuck");
                      }
                      if (ressourcePourChunk == "coco")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de coco à donner à Chuck");
                      }
                      break;
                    case 3:
                      Console.WriteLine("Voulez-vous lui donner ?  (lentille 🟢, blé 🌾, rose 🌹)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "lentille")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus de lentille à donner à Chuck");
                      }
                      if (ressourcePourChunk == "blé")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de blé à donner à Chuck");
                      }
                      if (ressourcePourChunk == "rose")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de rose à donner à Chuck");
                      }
                      break;
                    case 4:
                      Console.WriteLine("Voulez-vous lui donner ? (ananas 🍍, tomate 🍅, palmier 🌴)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "ananas")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus d'ananas à donner à Chuck");
                      }
                      if (ressourcePourChunk == "tomate")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de tomate à donner à Chuck");
                      }
                      if (ressourcePourChunk == "palmier")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de palmier à donner à Chuck");
                      }
                      break;
                  }
                  terrain.grille[unChunk.x][unChunk.y] = caseAvantChunk;
                  Console.WriteLine(terrain);
                  Console.WriteLine("CHUNK A ACCEPTE VOTRE CADEAU ET S'EST ENFUI"); // Chunk s'enfui
                }
                else //Chunk dévort la plante alors même qu'on lui donne une ressource pour qu'il parte (1/2)
                {
                  switch (numeroTerrainChunk)
                  {
                    case 1:
                      Console.WriteLine("Voulez-vous lui donner ? (mangue 🥭, baobab 🌳, sorgho 🌿)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "mangue")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus de mangue à donner à Chuck");
                      }
                      else if (ressourcePourChunk == "baobab")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de baobab à donner à Chuck");

                      }
                      else if (ressourcePourChunk == "sorgho")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                      }
                      break;
                    case 2:
                      Console.WriteLine("Voulez-vous lui donner ? (avocat 🥑, safou 🍆, coco 🥥)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "avocat")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus d'avocat à donner à Chuck");
                      }
                      if (ressourcePourChunk == "safou")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de safou à donner à Chuck");
                      }
                      if (ressourcePourChunk == "coco")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de coco à donner à Chuck");
                      }
                      break;
                    case 3:
                      Console.WriteLine("Voulez-vous lui donner ?  (lentille 🟢, blé 🌾, rose 🌹)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "lentille")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus de lentille à donner à Chuck");
                      }
                      if (ressourcePourChunk == "blé")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de blé à donner à Chuck");
                      }
                      if (ressourcePourChunk == "rose")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de rose à donner à Chuck");
                      }
                      break;
                    case 4:
                      Console.WriteLine("Voulez-vous lui donner ? (ananas 🍍, tomate 🍅, palmier 🌴)");
                      ressourcePourChunk = Convert.ToString(Console.ReadLine());
                      if (ressourcePourChunk == "ananas")
                      {
                        if (terrain.ressources[0] > 0)
                          terrain.ressources[0]--;
                        else
                          Console.WriteLine("Vous n'avez plus d'ananas à donner à Chuck");
                      }
                      if (ressourcePourChunk == "tomate")
                      {
                        if (terrain.ressources[1] > 0)
                          terrain.ressources[1]--;
                        else
                          Console.WriteLine("Vous n'avez plus de tomate à donner à Chuck");
                      }
                      if (ressourcePourChunk == "palmier")
                      {
                        if (terrain.ressources[2] > 0)
                          terrain.ressources[2]--;
                        else
                          Console.WriteLine("Vous n'avez plus de palmier à donner à Chuck");
                      }
                      break;
                  }
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                  Console.WriteLine(terrain);
                  Console.WriteLine("CHUNK A DEVORE TOUT CE QUI SE TROUVAIT SUR SA CASE et a pris la plante que vous lui avez gentiment donnée (Appuyez sur ENTREE)"); // Chunk mange
                  Console.ReadLine();
                  terrain.grille[unChunk.x][unChunk.y] = "🟫"; //Chunk se déplace
                  if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] == "🟫"))
                  {
                    unChunk.x++; //Chunk se déplace ensuite vers le ba
                    caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                    terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                  }
                  else if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] != "🟫"))
                  {
                    unChunk.x++; //Chunk se déplace ensuite vers le bas
                    caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                    terrain.grille[unChunk.x][unChunk.y] += "🐿️";

                  }
                  else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] == "🟫"))
                  {
                    unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                    caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                    terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                  }
                  else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] != "🟫"))
                  {
                    unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                    caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
                    terrain.grille[unChunk.x][unChunk.y] += "🐿️";
                  }
                  Console.WriteLine(terrain);
                  Console.WriteLine("CHUNK SE DEPLACE POUR DEVORER DE NOUVELLES PLANTES");
                }

              }
            }
          }
          while (chunkReste); // Tant que Chunk est sur le terrain en question, il continue de manger les plantes et se déplacer
        }




      }
      Console.WriteLine("Appuyez sur ENTREE");
      Console.ReadLine();
    }
  }

}

