public class Ananas : Plante
{
    public Ananas() : base(3) // 3 = identifiant pour Ananas
    {
        tempMinEnDeg = 20;         // °C
        tempMaxEnDeg = 31;         // °C
        humiditeSolMin = 60;       // %
        humiditeSolMax = 95;       // %
        comestible = true;
        seuilLuminosite = 85;      // % - aime plein soleil
    }
}