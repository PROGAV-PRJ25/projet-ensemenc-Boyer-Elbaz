public class Terrain1: Terrain
{
   public Terrain1():base()
    {
        numeroTerrain = 1;  // ID terrain
        biome = "Savane";  
        altitudeEnMetres = 1500;
        typeDeSol = "ferrallitiques";
        
        temperatureMoyenneEnDeg = 27; // Caractéristques météorologiques
        humiditeMoyenne = 55;
        luminositeMoyenne = 85;
    }
}