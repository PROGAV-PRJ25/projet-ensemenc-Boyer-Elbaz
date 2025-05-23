public class PalmierAHuile : Plante
{
    public PalmierAHuile() : base(4) // 2 = identifiant pour Palmier à huile
    {
        tempMinEnDeg = 25;         // °C - légèrement supérieur à la limite basse de Mangue
        tempMaxEnDeg = 32;         // °C - cohérent avec climat côtier
        humiditeSolMin = 60;       // % - sol humide requis
        humiditeSolMax = 90;       // %
        comestible = true;         // Produit des fruits (huile)
        seuilLuminosite = 80;      // % - besoin de forte luminosité, ok avec Terrain4 (90)
    }
}