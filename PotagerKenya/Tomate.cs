public class Tomate : Plante
{
    public Tomate() : base(6) // 4 = identifiant pour Tomate
    {
        tempMinEnDeg = 18;         // °C
        tempMaxEnDeg = 27;         // °C - au-delà, elle souffre
        humiditeSolMin = 50;       // %
        humiditeSolMax = 70;       // %
        comestible = true;
        seuilLuminosite = 70;      // % - aime la lumière mais craint l'excès
        vitesseCroissance = 2;     // Croissance rapide (2–3 mois)
    }
}