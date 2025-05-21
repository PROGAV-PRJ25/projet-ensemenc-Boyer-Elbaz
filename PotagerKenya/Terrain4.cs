public class Terrain4: Terrain
{
    public Terrain4():base()
    {
        numeroTerrain = 4;
        biome = "Zone côtière";
        altitudeEnMetres = 10; // Altitude très basse, presque au niveau de la mer
        typeDeSol = "sableux et alluvial"; // Typique des plages et plaines côtières

        temperatureMoyenneEnDeg = 28; // Chaleur constante tout au long de l'année
        humiditeMoyenne = 85; // Forte humidité due à la proximité de l'océan Indien
        luminositeMoyenne = 90; // Ensoleillement intense, sauf pendant la mousson
    }

}