public class Rose : Plante
{
    public Rose() : base(5) // 7 = identifiant pour Rose
    {
        tempMinEnDeg = 10;         // °C
        tempMaxEnDeg = 22;         // °C
        humiditeSolMin = 55;       // %
        humiditeSolMax = 80;       // %
        comestible = false;        // décorative (sauf exception)
        seuilLuminosite = 65;      // % - évite lumière trop directe
    }
}
                