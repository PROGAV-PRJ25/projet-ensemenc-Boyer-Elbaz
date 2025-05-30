public class Fee : Animal
{
  public Fee() : base("Fée") { }

  public override void ApparitionAnimal(Monde monde)
  {
    int planteChoisieParLaFee;
    Random rng = new Random();
    int probaReine = rng.Next(0, 10); //La reine des fées peut arriver 1 fois sur 10
    int probaApparition = rng.Next(0, 2); // La fée apparaît 1 fois sur 3
    if (probaApparition == 0)
    {

      int numeroTerrainFee = rng.Next(1, 5); // La fée apparaît sur un terrain au hasard
      foreach (Terrain terrain in monde.terrainsDuMonde)
      {
        if (terrain.numeroTerrain == numeroTerrainFee) // Sur le terrain où est la fée
        {
          int x_random, y_random;
          do
          {
            x_random = rng.Next(0, 7);
            y_random = rng.Next(0, 7);
          }
          while (terrain.grille[x_random][y_random] != "🟫"); // La fée apparaît sur une case vierge

          this.x = x_random;
          this.y = y_random;
          if (probaReine == 0) // Apparition de la reine des fées (elle n'a pas de pouvoirs supplémentaires)
          {
            terrain.grille[this.x][this.y] = "🧝";
            Console.WriteLine(terrain);
            Console.WriteLine($"⚠️  EVENEMENT RARE : LA REINE DES FEES EST APPARUE SUR LE TERRAIN {numeroTerrainFee}! POUR VOUS AIDER ! (Appuyer sur ENTREE)");
            Console.ReadLine();
          }
          else // Apparition de la fée classique
          {
            terrain.grille[this.x][this.y] = "🧚";
            Console.WriteLine(terrain);
            Console.WriteLine($"UNE FEE EST APPARUE SUR LE TERRAIN {numeroTerrainFee}! POUR VOUS AIDER ! (Appuyer sur ENTREE)");
            Console.ReadLine();
          }
   


          
        switch (numeroTerrainFee)
          {

            case 1: // Si la fée est apparue sur le terrain 1
              planteChoisieParLaFee = rng.Next(1, 4);
              if (planteChoisieParLaFee == 1)
              {
                Mangue nouvellePlante = new Mangue();    // Affichage de la plante, puis disparition de la fée
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🥭";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître une mangue (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🥭";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 2)
              {
                Baobab nouvellePlante = new Baobab();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🌳";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître un baobab (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌳";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 3)
              {
                Sorgho nouvellePlante = new Sorgho();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🌿";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître un sorgho (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌿";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              break;
            case 2: // Si la fée est apparue sur le terrain 2
              planteChoisieParLaFee = rng.Next(1, 4);
              if (planteChoisieParLaFee == 1)
              {
                Avocat nouvellePlante = new Avocat();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🥑";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître un avocat (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🥑";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 2)
              {
                Safou nouvellePlante = new Safou();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🍆";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître un safou (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🍆";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 3)
              {
                Cocotier nouvellePlante = new Cocotier();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🥥";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître une noix de coco (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🥥";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              break;
            case 3: // Si la fée est apparue sur le terrain 3
              planteChoisieParLaFee = rng.Next(1, 4);
              if (planteChoisieParLaFee == 1)
              {
                Lentille nouvellePlante = new Lentille();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🟢";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître une lentille (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🟢";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 2)
              {
                Ble nouvellePlante = new Ble();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🌾";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître du blé (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌾";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 3)
              {
                Rose nouvellePlante = new Rose();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🌹";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître une rose (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌹";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              break;
            case 4: // Si la fée est apparue sur le terrain 4
              planteChoisieParLaFee = rng.Next(1, 4);
              if (planteChoisieParLaFee == 1)
              {
                Ananas nouvellePlante = new Ananas();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🍍";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître un ananas (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🍍";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 2)
              {
                Tomate nouvellePlante = new Tomate();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🍅";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître une tomate (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🍅";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              else if (planteChoisieParLaFee == 3)
              {
                PalmierAHuile nouvellePlante = new PalmierAHuile();
                terrain.plantes.Add(nouvellePlante);
                nouvellePlante.x = this.x;
                nouvellePlante.y = this.y;
                terrain.grille[nouvellePlante.x][nouvellePlante.y] += "🌴";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a fait apparaître un palmier (Appuyez sur ENTREE)");
                Console.ReadLine();
                terrain.grille[nouvellePlante.x][nouvellePlante.y] = "🌴";
                Console.WriteLine(terrain);
                Console.WriteLine("La fée a disparu comme elle est arrivée (Appuyez sur ENTREE)");
                Console.ReadLine();
              }
              break;

          }
        }



        

        
      }
    }

  }
}