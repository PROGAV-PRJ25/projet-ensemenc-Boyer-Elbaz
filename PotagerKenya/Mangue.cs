public class Mangue: Plante
{
    public Mangue():base(1)
    {
        tempMinEnDeg = 24;
        tempMaxEnDeg = 30;
        humiditeSolMin = 45;
        humiditeSolMax = 80;
        comestible = true;
        seuilLuminosite = 75;
    }
}