public class LarryLeMalicieux : Animal
{
  public LarryLeMalicieux() : base("LarryLeMalicieux")
  {

  }

  public override void ApparitionAnimal(Monde monde)
  {
    int probaDisparition;
    int reaction;
    LarryLeMalicieux unLarry = new LarryLeMalicieux();
    int x_random;
    int y_random;
    Random rng = new Random();
    int probaApparition = rng.Next(0,5); // Larry le malicieux 🐈‍⬛ apparaît une fois sur 4 pour poser des pièges
    if (probaApparition == 0)
    {
      int numeroTerrainLarry = rng.Next(1, 5);
      foreach (Terrain terrain in monde.terrainsDuMonde)
      {
        if (terrain.numeroTerrain == numeroTerrainLarry)
        {
          do
          {
            x_random = rng.Next(0, 7);
            y_random = rng.Next(0, 7);
          }
          while (terrain.grille[x_random][y_random] != "🟫");

          unLarry.x = x_random;
          unLarry.y = y_random;
          terrain.grille[unLarry.x][unLarry.y] = "🐈‍⬛";
        }

        Console.WriteLine(terrain);

        Console.WriteLine($"LARRY LE MALICIEUX EST SUR LE TERRAIN {numeroTerrainLarry}!! (Appuyer sur ENTREE)");
        Console.ReadLine();

        Console.WriteLine("Vous pouvez : Lui faire peur (tapez 1), lui donner une ressource pour qu'il s'en aille (tapez 2)");
        reaction = Convert.ToInt32(Console.ReadLine());

        if (reaction == 1) // Vous voulez lui faire peur
        {
          Console.WriteLine("Vous : *Oust petit chat empli de malice*");
          probaDisparition = rng.Next(0, 3);
          if (probaDisparition == 0) // Larry le malicieux part quand on lui dit de partir (1/3)
          {
            terrain.grille[unLarry.x][unLarry.y] = "🟫";
            Console.WriteLine(terrain);
            Console.WriteLine("LARRY LE MALICIEUX EST PARTI EMPLI DE MALICE"); // Larry le malicieux s'enfui
          }
          else //Larry le malicieux pose un piège même quand on lui dit de partir (2/3)
          {
            terrain.grille[unLarry.x][unLarry.y] += "⬛";
            Console.WriteLine(terrain);
            Console.WriteLine("LARRY LE MALICIEUX A DEPOSE UN PIEGE MALICIEUX (Aucune plante ne peut pousser dessus) (Appuyez sur ENTREE)"); // Chunk mange
            Console.ReadLine();
            terrain.grille[unLarry.x][unLarry.y] = "⬛";
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
            terrain.grille[unLarry.x][unLarry.y] += "⬛";
            Console.WriteLine(terrain);
            Console.WriteLine("LARRY LE MALICIEUX A DEPOSE UN PIEGE MALICIEUX (Aucune plante ne peut pousser dessus) (Appuyez sur ENTREE)"); // Chunk mange
            Console.ReadLine();
            terrain.grille[unLarry.x][unLarry.y] = "⬛";
            Console.WriteLine(terrain);
            Console.WriteLine("LARRY LE MALICIEUX EST PARTI EMPLI DE MALICE");
          }
          else
          {
            
          }
        }
      }
    }


    
  }
}