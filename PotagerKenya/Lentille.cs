public class Lentille : Plante
{
    public Lentille() : base(7) 
    {
        tempMinEnDeg = 8;         // °C
        tempMaxEnDeg = 24;        // °C
        humiditeSolMin = 45;      // %
        humiditeSolMax = 75;      // % - tolère jusqu'à ce niveau
        comestible = true;
        seuilLuminosite = 60;     // % - croissance possible sous nuages
    }
}