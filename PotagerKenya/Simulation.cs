public class Simulation
{
    public Monde mondeSimule;
    public Meteo meteoSimulee;

    public Simulation()
    {
        mondeSimule =  new Monde();
        meteoSimulee = new Meteo();
    }

    public void Simuler()
    {
        foreach (var terrain in mondeSimule.terrainsDuMonde)
        {
            terrain.DebutJeu();
        }

        meteoSimulee.NouvelleMeteo(mondeSimule);
        Console.WriteLine(mondeSimule);
        Console.ReadLine();
        



        for(int i=1; i<=20; i++)
        {
            Console.WriteLine($"===== Semaine passée =====");
            mondeSimule.MaladieOuMort(); // Dire au joueur quelles plantes sont en danger
            mondeSimule.SemaineNiveauxRessources(); //Recap des plantes qui ont grandi
            Console.WriteLine(mondeSimule);
            mondeSimule.PlanterNouvellePlante(); // Donner au joueur la possibilité de planter si ressources nécessaires

            // Afficher s'il y a un intrus

            

            Console.ReadLine();
        }
    }
}