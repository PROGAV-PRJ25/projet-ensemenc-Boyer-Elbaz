public class Simulation
{
    public Monde mondeSimule;

    public Meteo meteoSimulee;

    public EcranTitre ecranTitreSimule;

    public Simulation()
    {
        mondeSimule = new Monde();
        meteoSimulee = new Meteo();
        ecranTitreSimule = new EcranTitre();
    }

    public void Simuler()
    {
        ecranTitreSimule.AfficherEcranTitre();  // Ecran titre
        Console.ReadLine();
        ecranTitreSimule.ReglesDuJeu(); // Règles du jeu
        Console.ReadLine();

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Green; // Choix du nombre de semaines à simuler
        Console.WriteLine(@"
      ╔══════════════════════════════════════════════════════════════════╗
      ║                                                                  ║
      ║        🌿 CHOISISSEZ UN NOMBRE DE SEMAINES A SIMULER 🌿          ║
      ║         [UNE PARTIE LONGUE EST D'ENVIRON 90 SEMAINES]            ║
      ║                                                                  ║
      ╚══════════════════════════════════════════════════════════════════╝

      ");
        Console.ResetColor();
        int NbeTours = Convert.ToInt32(Console.ReadLine());


        foreach (var terrain in mondeSimule.terrainsDuMonde) // Initialisation des plantes sur chaque terrain
        {
            terrain.DebutJeu();
        }

        meteoSimulee.NouvelleMeteo(mondeSimule); //Création de la première météo du monde
        Console.WriteLine(mondeSimule); // Affichage du monde semaine 1
        Console.ReadLine();


        for (int i = 1; i <= NbeTours; i++) // Nombre de tours de jeu simulés en fonction de ce que voulait le joueur
        {
            meteoSimulee.NouvelleMeteo(mondeSimule); //Création de la nouvelle météo du monde
            Console.WriteLine($"===== Semaine passée =====");
            mondeSimule.MaladieOuMort(); // Dire au joueur quelles plantes sont en danger
            mondeSimule.SemaineNiveauxRessources(); //Recap des plantes qui ont grandi
            Console.WriteLine(mondeSimule);
            mondeSimule.PlanterNouvellePlante(); // Donner au joueur la possibilité de planter si ressources nécessaires

            mondeSimule.laFee.ApparitionAnimal(mondeSimule); // La fée peut arriver (probabilité)
            if (i >= 3) // Dans un soucis d'équilibrage du jeu, les malus arrivent à partir de la la semaine 3
            {
                mondeSimule.leChunk.ApparitionAnimal(mondeSimule);   // Chunk peut arriver (probabilité de 1/4)
                mondeSimule.leLarry.ApparitionAnimal(mondeSimule);  // Larry le malicieux peut arriver (probabilité de 1/5)
            }

            Console.ReadLine();
        }

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
      ╔════════════════════════════════════════════════════════════════════════════════╗
      ║                                                                                ║
      ║        🌿 FIN DU NOMBRE DE SEMAINES SIMULEES, MERCI D'AVOIR JOUE ! 🌿          ║
      ║                                                                                ║
      ╚════════════════════════════════════════════════════════════════════════════════╝

      ");
        Console.ResetColor();
    }
}