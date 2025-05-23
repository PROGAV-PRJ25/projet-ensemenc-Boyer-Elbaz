public class Baobab : Plante
{
    public Baobab() : base(8) // 8 = identifiant pour Baobab
    {
        tempMinEnDeg = 20;         // °C
        tempMaxEnDeg = 35;         // °C
        humiditeSolMin = 30;       // %
        humiditeSolMax = 80;       // %
        comestible = false;        // Utilisé en médecine et pour ombre, pas directement comestible
        seuilLuminosite = 60;      // % - plein soleil
    }
}