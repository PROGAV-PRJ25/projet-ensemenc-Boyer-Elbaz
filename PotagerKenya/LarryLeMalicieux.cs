public class LarryLeMalicieux : Animal
{
    private static Random rng = new Random();

    public LarryLeMalicieux() : base("LarryLeMalicieux") {}
    

    public override void ApparitionAnimal(Monde monde)
  {
    int probaDisparition;
    Random rng = new Random();
    int probaApparition = rng.Next(0, 5); // Larry le malicieux apparaît 1 fois sur 5
    if (probaApparition == 0)
    {

      int numeroTerrainLarry = rng.Next(1, 5);
      foreach (Terrain terrain in monde.terrainsDuMonde)
      {
        if (terrain.numeroTerrain == numeroTerrainLarry)
        {
          int x_random, y_random;
          do
          {
            x_random = rng.Next(0, 7);
            y_random = rng.Next(0, 7);
          }
          while (terrain.grille[x_random][y_random] != "🟫");

          this.x = x_random;
          this.y = y_random;

          terrain.grille[this.x][this.y] = "🐈";

          Console.WriteLine(terrain);
          Console.WriteLine($"LARRY LE MALICIEUX EST SUR LE TERRAIN {numeroTerrainLarry}!! (Appuyer sur ENTREE)");
          Console.ReadLine();

          Console.WriteLine("Vous pouvez : Lui faire peur (tapez 1), lui donner une ressource pour qu'il s'en aille (tapez 2)");
          int reaction = Convert.ToInt32(Console.ReadLine());

          if (reaction == 1)
          {
            Console.WriteLine("Vous : *Oust petit chat empli de malice*");
            probaDisparition = rng.Next(0, 3);
            if (probaDisparition == 0)
            {
              terrain.grille[this.x][this.y] = "🟫";
              Console.WriteLine(terrain);
              Console.WriteLine("LARRY LE MALICIEUX EST PARTI EMPLI DE MALICE");
            }
            else
            {
              // On remplace la case par un piège noir
              terrain.grille[this.x][this.y] += "⬛";
              Console.WriteLine(terrain);
              Console.WriteLine("LARRY LE MALICIEUX A DEPOSE UN PIEGE MALICIEUX (Aucune plante ne peut pousser dessus) (Appuyez sur ENTREE)");
              Console.ReadLine();
              terrain.grille[this.x][this.y] = "⬛";
              Console.WriteLine(terrain);
              Console.WriteLine("LARRY LE MALICIEUX EST PARTI EMPLI DE MALICE");
            }
          }
          else if (reaction == 2) // Si vous voulez offrir une ressource à Larry le malicieux
          {
            string ressourcePourLarry;
            if (terrain.ressourcesTotales == 0) // Si vous n'avez aucune ressource
            {
              Console.WriteLine("Vous n'avez aucune ressource à donner à Larry le malicieux... il va se venger (Appuyez sur ENTREE)"); // Vous ne donnez rien à Chunk donc il dévore vos plantes :
              Console.ReadLine();
              terrain.grille[this.x][this.y] += "⬛";
              Console.WriteLine(terrain);
              Console.WriteLine("LARRY LE MALICIEUX A DEPOSE UN PIEGE MALICIEUX (Aucune plante ne peut pousser dessus) (Appuyez sur ENTREE)"); // Chunk mange
              Console.ReadLine();
              terrain.grille[this.x][this.y] = "⬛";
              Console.WriteLine(terrain);
              Console.WriteLine("LARRY LE MALICIEUX EST PARTI EMPLI DE MALICE");
            }
            else // Si vous avez des ressources à lui donner
            {
              probaDisparition = rng.Next(0, 2);
              if (probaDisparition == 0) // Larry le malicieux ne pose pas de piège et part quand on lui donne une ressource (1/2)
              {
                switch (numeroTerrainLarry)
                {
                  case 1:
                    Console.WriteLine("Voulez-vous lui donner ? (mangue 🥭, baobab 🌳, sorgho 🌿)");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "mangue")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus de mangue à donner à Chuck");
                    }
                    else if (ressourcePourLarry == "baobab")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de baobab à donner à Chuck");

                    }
                    else if (ressourcePourLarry == "sorgho")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    break;
                  case 2:
                    Console.WriteLine("Voulez-vous lui donner ? (avocat 🥑, sorgho 🍆, coco 🥥)");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "avocat")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus d'avocat à donner à Chuck");
                    }
                    if (ressourcePourLarry == "sorgho")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    if (ressourcePourLarry == "coco")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    break;
                  case 3:
                    Console.WriteLine("Voulez-vous lui donner ?  (lentille 🟢, blé 🌾, rose 🌹)");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "lentille")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus de lentille à donner à Chuck");
                    }
                    if (ressourcePourLarry == "blé")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de blé à donner à Chuck");
                    }
                    if (ressourcePourLarry == "rose")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de rose à donner à Chuck");
                    }
                    break;
                  case 4:
                    Console.WriteLine("Voulez-vous lui donner ? (ananas 🍍, tomate 🍅, palmier 🌴)");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "ananas")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus d'ananas à donner à Chuck");
                    }
                    if (ressourcePourLarry == "tomate")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de tomate à donner à Chuck");
                    }
                    if (ressourcePourLarry == "palmier")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de palmier à donner à Chuck");
                    }
                    break;
                }
                terrain.grille[this.x][this.y] = "🟫";
                Console.WriteLine(terrain);
                Console.WriteLine("LARRY LE MALICIEUX A ACCEPTE VOTRE CADEAU ET EST PARTI EMPLI DE MALICE"); // Larry le malicieux part sans causer de dégâts
              }
              else //Larry le malicieux pose son piège et part alors même qu'on lui donne une ressource pour qu'il ne le fasse pas (1/2)
              {
                switch (numeroTerrainLarry)
                {
                  case 1:
                    Console.WriteLine("Voulez-vous lui donner ? (mangue 🥭, baobab 🌳, sorgho 🌿)");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "mangue")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus de mangue à donner à Chuck");
                    }
                    else if (ressourcePourLarry == "baobab")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de baobab à donner à Chuck");

                    }
                    else if (ressourcePourLarry == "sorgho")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    break;
                  case 2:
                    Console.WriteLine("Voulez-vous lui donner ? (avocat 🥑, sorgho 🍆, coco 🥥");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "avocat")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus d'avocat à donner à Chuck");
                    }
                    if (ressourcePourLarry == "sorgho")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    if (ressourcePourLarry == "coco")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de sorgho à donner à Chuck");
                    }
                    break;
                  case 3:
                    Console.WriteLine("Voulez-vous lui donner ?  (lentille 🟢, blé 🌾, rose 🌹");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "lentille")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus de lentille à donner à Chuck");
                    }
                    if (ressourcePourLarry == "blé")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de blé à donner à Chuck");
                    }
                    if (ressourcePourLarry == "rose")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de rose à donner à Chuck");
                    }
                    break;
                  case 4:
                    Console.WriteLine("Voulez-vous lui donner ? (ananas 🍍, tomate 🍅, palmier 🌴");
                    ressourcePourLarry = Convert.ToString(Console.ReadLine());
                    if (ressourcePourLarry == "ananas")
                    {
                      if (terrain.ressources[0] > 0)
                        terrain.ressources[0]--;
                      else
                        Console.WriteLine("Vous n'avez plus d'ananas à donner à Chuck");
                    }
                    if (ressourcePourLarry == "tomate")
                    {
                      if (terrain.ressources[1] > 0)
                        terrain.ressources[1]--;
                      else
                        Console.WriteLine("Vous n'avez plus de tomate à donner à Chuck");
                    }
                    if (ressourcePourLarry == "palmier")
                    {
                      if (terrain.ressources[2] > 0)
                        terrain.ressources[2]--;
                      else
                        Console.WriteLine("Vous n'avez plus de palmier à donner à Chuck");
                    }
                    break;
                }
                terrain.grille[this.x][this.y] += "⬛";
                Console.WriteLine(terrain);
                Console.WriteLine("LARRY LE MALICIEUX A DEPOSE UN PIEGE MALICIEUX (Aucune plante ne peut pousser dessus)  et a pris la plante que vous lui avez gentiment donnée (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[this.x][this.y] = "⬛";
                Console.WriteLine(terrain);
                Console.WriteLine("LARRY LE MALICIEUX EST PARTI EMPLI DE MALICE");
              }

            }
          }


        }
      }
      Console.WriteLine("Appuyez sur ENTREE");
      Console.ReadLine();
    }
  }
}
