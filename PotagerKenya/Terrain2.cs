public class Terrain2: Terrain
{
    public Terrain2():base()
    {
        numeroTerrain = 2;
        biome = "Forêt tropicale";
        altitudeEnMetres = 1500;
        typeDeSol = "ferrallitiques";
        
        temperatureMoyenneEnDeg = 20;
        humiditeMoyenne = 67;
        luminositeMoyenne = 80; //Pas forcément précis
    }
}