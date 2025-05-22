public class Chunk : Animal
{
  public Chunk(): base("Chunk")
  {

  }

  public override void ApparitionAnimal(Monde monde)
  {
    Random rng = new Random();
    int probaApparition = 0; // Chunk le malicieux 🐿️ apparaît une fois sur 5 pour s'emparer de nos récoltes
    if(probaApparition == 0)
    {
      int numeroTerrainChunk = rng.Next(1,5);
      foreach(Terrain terrain in monde.terrainsDuMonde)
      {
        if(terrain.numeroTerrain == numeroTerrainChunk)
        {
          Console.WriteLine($"Chunk est apparu sur le terrain {numeroTerrainChunk}");
        }
      }
    }
  }
}