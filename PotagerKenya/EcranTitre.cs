public class EcranTitre
{
  public void AfficherEcranTitre()
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine(@"
      ╔══════════════════════════════════════════════════════════════════╗
      ║                                                                  ║
      ║     🌿 BIENVENUE DANS LE SIMULATEUR DE POTAGER AU KENYA 🌿       ║
      ║                                                                  ║
      ║   🥭 Gérez votre potager comme un pro avec ce simulateur! 🥥     ║
      ║                                                                  ║
      ╚══════════════════════════════════════════════════════════════════╝
                > Appuyez sur ENTREE pour commencer <

      ");

    Console.ResetColor();
  }

  public void ReglesDuJeu()
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine(@"╔══════════════════════════════════════════════════════════════════════════════╗
║                                                                              ║
║                             REGLES DU JEU                                    ║
║                                                                              ║
║  Vous disposez de 4 terrains :                                               ║
║    ▸ Une Savane                                                              ║
║    ▸ Une Forêt Tropicale                                                     ║
║    ▸ Une Zône Montagneuse                                                    ║
║    ▸ Une Zône Côtière                                                        ║
║                                                                              ║
║  🌿 Chaque terrain possède ses plantes caractéristiques :                    ║
║    ▸ Savane : mangue 🥭, baobab 🌳, sorgho 🌿                                ║
║    ▸ Forêt tropicale : avocat 🥑, safou 🍆, cocotier 🥥                      ║
║    ▸ Zône montagneuse : lentille 🟢, blé 🌾, rose 🌹                         ║
║    ▸ Zône côtière : ananas 🍍, tomate 🍅, palmier 🌴                         ║
║                                                                              ║
║  📅 Le jeu est simulé par semaine :                                          ║
║    ▸ Chaque plante peut progresser d’un niveau si elle est en bonne santé.   ║
║    ▸ À partir du niveau 3, elle commence à produire des ressources.          ║
║                                                                              ║
║  📈 Exemple d’évolution d’une plante :                                       ║
║    ▸ Mangue Nv.0 🥭   ▸ Mangue Nv.1 🥭I   ▸ Mangue Nv.2 🥭II   ▸ 🥭III       ║
║                                                                              ║
║  ⚠️ Attention ! Un individu nommé *Chunk* 🐿️ rôde dans les parages...          ║
║     Il aime manger vos récoltes ! Soyez vigilant et protégez vos plantes.    ║ 
║     Un chat nommé Larry le malicieux aime vous jouer des tours...            ║
║     Heureusement, il paraît qu'une bonne fée aime passer dans les parages... ║
║                                                                              ║
║  🎮 Que la partie commence !                                                 ║
╚══════════════════════════════════════════════════════════════════════════════╝
            > Appuyez sur ENTREE pour commencer à jouer <  
");


    Console.ResetColor();
  }
  


}