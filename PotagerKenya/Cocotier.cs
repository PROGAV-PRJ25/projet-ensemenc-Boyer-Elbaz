public class Cocotier : Plante
{
    public Cocotier() : base(11) // 11 = identifiant pour Cocotier
    {
        tempMinEnDeg = 19;         // °C - limite inférieure tolérable
        tempMaxEnDeg = 25;         // °C
        humiditeSolMin = 57;       // %
        humiditeSolMax = 90;       // %
        comestible = true;         // Fruits comestibles (noix de coco)
        seuilLuminosite = 75;      // % - préfère plein soleil
    }
}
