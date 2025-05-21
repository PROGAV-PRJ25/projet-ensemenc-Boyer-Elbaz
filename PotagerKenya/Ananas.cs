public class Ananas : Plante
{
    public Ananas() : base(3) // 3 = identifiant pour Ananas
    {
        tempMinEnDeg = 20;         // °C
        tempMaxEnDeg = 30;         // °C
        humiditeSolMin = 60;       // %
        humiditeSolMax = 80;       // %
        comestible = true;
        seuilLuminosite = 85;      // % - aime plein soleil
        vitesseCroissance = 1;     // Croissance moyenne (12-18 mois)
    }
}