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
        ecranTitreSimule.AfficherEcranTitre();
        Console.ReadLine();
        ecranTitreSimule.ReglesDuJeu();
        Console.ReadLine();

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
      ╔══════════════════════════════════════════════════════════════════╗
      ║                                                                  ║
      ║        🌿 CHOISISSEZ UN NOMBRE DE SEMAINES A SIMULER 🌿          ║
      ║                                                                  ║
      ╚══════════════════════════════════════════════════════════════════╝

      ");
        Console.ResetColor();
        int NbeTours = Convert.ToInt32(Console.ReadLine());


        foreach (var terrain in mondeSimule.terrainsDuMonde)
        {
            terrain.DebutJeu();
        }

        meteoSimulee.NouvelleMeteo(mondeSimule);
        Console.WriteLine(mondeSimule);
        Console.ReadLine();


        for (int i = 1; i <= NbeTours; i++)
        {
            Console.WriteLine($"===== Semaine passée =====");
            mondeSimule.MaladieOuMort(); // Dire au joueur quelles plantes sont en danger
            mondeSimule.SemaineNiveauxRessources(); //Recap des plantes qui ont grandi
            Console.WriteLine(mondeSimule);
            mondeSimule.PlanterNouvellePlante(); // Donner au joueur la possibilité de planter si ressources nécessaires

            // Afficher s'il y a un intrus

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