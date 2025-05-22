public class Chunk : Animal
{
  public Chunk() : base("Chunk")
  {

  }

  public override void ApparitionAnimal(Monde monde)
  {
    bool chunkReste = true;
    int probaDisparition;
    string caseAvantChunk;
    int reaction;
    Chunk unChunk = new Chunk();
    int x_random;
    int y_random;
    Random rng = new Random();
    int probaApparition = 0; // Chunk le malicieux 🐿️ apparaît une fois sur 4 pour s'emparer de nos récoltes
    if (probaApparition == 0)
    {
      int numeroTerrainChunk = rng.Next(1, 5);
      foreach (Terrain terrain in monde.terrainsDuMonde)
      {
        if (terrain.numeroTerrain == numeroTerrainChunk)
        {
          do
          {
            x_random = rng.Next(0, 7);
            y_random = rng.Next(0, 7);
          }
          while (terrain.grille[x_random][y_random] == "🟫");

          unChunk.x = x_random;
          unChunk.y = y_random;
          caseAvantChunk = terrain.grille[unChunk.x][unChunk.y];
          terrain.grille[unChunk.x][unChunk.y] += "🐿️";


          Console.WriteLine(terrain);

          Console.WriteLine($"CHUNK EST APPARU SUR LE TERRAIN {numeroTerrainChunk}!! Appuyer sur ENTREE");
          Console.ReadLine();

          Console.WriteLine("Vous pouvez : Lui faire peur (tapez 1), lui donner une ressource pour qu'il s'en aille (tapez 2)");
          reaction = Convert.ToInt32(Console.ReadLine());
          if (reaction == 1)
          {
            Console.WriteLine("Vous : *AAAARRRRGGH*");
            probaDisparition = rng.Next(0, 4);
            if (probaDisparition == 0)
            {
              chunkReste = false;
              terrain.grille[unChunk.x][unChunk.y] = caseAvantChunk;
              Console.WriteLine(terrain);
              Console.WriteLine("CHUNK S'EST ENFUI"); // Chunk s'enfui
            }
            else
            {
              terrain.grille[unChunk.x][unChunk.y] = "🐿️";
              Console.WriteLine(terrain);
              Console.WriteLine("CHUNK A DEVORE LA PLANTE (Appuyez sur ENTREE)"); // Chunk mange
              Console.ReadLine();
              terrain.grille[unChunk.x][unChunk.y] = "🟫"; //Chunk se déplace
              if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] == "🟫"))
              {
                unChunk.x++; //Chunk se déplace ensuite vers le bas
                terrain.grille[unChunk.x][unChunk.y] = "🐿️";
              }
              else if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] != "🟫"))
              {
                unChunk.x++; //Chunk se déplace ensuite vers le bas
                terrain.grille[unChunk.x][unChunk.y] += "🐿️";

              }
              else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] == "🟫"))
              {
                unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                terrain.grille[unChunk.x][unChunk.y] = "🐿️";
              }
              else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] != "🟫"))
              {
                unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                terrain.grille[unChunk.x][unChunk.y] += "🐿️";
              }
              Console.WriteLine(terrain);
              Console.WriteLine("CHUNK SE DEPLACE POUR DEVORER DE NOUVELLES PLANTES");
            }
          }
          else if (reaction == 2)
          {
            string ressourcePourChunk;
            if (terrain.ressourcesTotales == 0)
            {
              chunkReste = false;
              Console.WriteLine("Vous n'avez aucune ressource à donner à Chunk...");
            }
            else
            {
              probaDisparition = rng.Next(0, 3);
              if (probaDisparition == 0)
              {
                chunkReste = false;
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
                    Console.WriteLine("Voulez-vous lui donner ? (avocat 🥑, sorgho 🍆, coco 🥥");
                    ressourcePourChunk = Convert.ToString(Console.ReadLine());
                    if (ressourcePourChunk == "avocat")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus d'avocat à donner à Chuck");
                    }
                    if (ressourcePourChunk == "sorgho")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    if (ressourcePourChunk == "coco")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    break;
                  case 3:
                    Console.WriteLine("Voulez-vous lui donner ?  (lentille 🟢, blé 🌾, rose 🌹");
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
                    Console.WriteLine("Voulez-vous lui donner ? (ananas 🍍, tomate 🍅, palmier 🌴");
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
              }
              else
              {
                //Code pour donner fruits
                terrain.grille[unChunk.x][unChunk.y] = "🟫"; //Chunk se déplace
                if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] == "🟫"))
                {
                  unChunk.x++; //Chunk se déplace ensuite vers le bas
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                }
                else if ((unChunk.x < 6) && (terrain.grille[unChunk.x + 1][unChunk.y] != "🟫"))
                {
                  unChunk.x++; //Chunk se déplace ensuite vers le bas
                  terrain.grille[unChunk.x][unChunk.y] += "🐿️";

                }
                else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] == "🟫"))
                {
                  unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                  terrain.grille[unChunk.x][unChunk.y] = "🐿️";
                }
                else if ((unChunk.x == 6) && (terrain.grille[unChunk.x - 1][unChunk.y] != "🟫"))
                {
                  unChunk.x--; //Chunk se déplace vers le haut s'il ne peut pas aller en bas
                  terrain.grille[unChunk.x][unChunk.y] += "🐿️";
                }
                Console.WriteLine(terrain);
                Console.WriteLine("CHUNK SE DEPLACE POUR DEVORER DE NOUVELLES PLANTES");
              }
              terrain.grille[unChunk.x][unChunk.y] = caseAvantChunk;
              Console.WriteLine(terrain);
              Console.WriteLine("CHUNK S'EST ENFUI");

            }








          }
        }




      }
    }
  }

}

