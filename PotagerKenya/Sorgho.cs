public class Sorgho : Plante
{
    public Sorgho() : base(9) // 9 = identifiant pour Sorgho
    {
        tempMinEnDeg = 22;         // °C
        tempMaxEnDeg = 35;         // °C
        humiditeSolMin = 40;       // %
        humiditeSolMax = 65;       // %
        comestible = true;         // Céréale comestible
        seuilLuminosite = 70;      // % - aime la lumière mais supporte la sécheresse
        vitesseCroissance = 2;     // Croissance rapide (saison de culture courte)
    }
}