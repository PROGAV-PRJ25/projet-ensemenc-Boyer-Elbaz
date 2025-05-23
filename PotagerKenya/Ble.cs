public class Ble : Plante
{
    public Ble() : base(12) // 12 = identifiant pour Blé
    {
        tempMinEnDeg = 10;         // °C
        tempMaxEnDeg = 22;         // °C - au-delà, il souffre
        humiditeSolMin = 50;       // %
        humiditeSolMax = 70;       // %
        comestible = true;
        seuilLuminosite = 65;      // % - besoin de lumière mais tolère les nuages
    }
}