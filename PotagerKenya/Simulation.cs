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
            Console.WriteLine($"===== Semaine passée =====");
            mondeSimule.MaladieOuMort(); // Dire au joueur quelles plantes sont en danger
            mondeSimule.SemaineNiveauxRessources(); //Recap des plantes qui ont grandi
            Console.WriteLine(mondeSimule);
            mondeSimule.PlanterNouvellePlante(); // Donner au joueur la possibilité de planter si ressources nécessaires

            mondeSimule.leChunk.ApparitionAnimal(mondeSimule); // Afficher s'il y a un intrus

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