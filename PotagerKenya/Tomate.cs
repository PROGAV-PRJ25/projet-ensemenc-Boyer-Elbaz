public class Tomate : Plante
{
    public Tomate() : base(6) // 4 = identifiant pour Tomate
    {
        tempMinEnDeg = 18;         // °C
        tempMaxEnDeg = 30;         // °C - au-delà, elle souffre
        humiditeSolMin = 70;       // %
        humiditeSolMax = 95;       // %
        comestible = true;
        seuilLuminosite = 70;       
    }
}