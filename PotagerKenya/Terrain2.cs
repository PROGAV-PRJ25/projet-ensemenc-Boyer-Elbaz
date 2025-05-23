public class Terrain2: Terrain
{
    public Terrain2():base()
    {
        numeroTerrain = 2; //ID
        biome = "Forêt tropicale";
        altitudeEnMetres = 1500;
        typeDeSol = "ferrallitiques";
        
        temperatureMoyenneEnDeg = 20; // Caractéristques météorologiques
        humiditeMoyenne = 67;
        luminositeMoyenne = 80; 
    }
}