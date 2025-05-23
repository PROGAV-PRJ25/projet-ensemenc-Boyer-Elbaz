public class Terrain3: Terrain
{
    public Terrain3():base()
    {
        numeroTerrain = 3; //ID
        biome = "Zone montagneuse";
        altitudeEnMetres = 2500; // Typique des montagnes kényanes
        typeDeSol = "andosols volcaniques"; // Sols riches souvent trouvés en zone volcanique

        temperatureMoyenneEnDeg = 12; // Plus frais en altitude
        humiditeMoyenne = 75; // Relativement humide à cause des forêts montagnardes
        luminositeMoyenne = 70; // Peut varier selon la couverture nuageuse
    }

}