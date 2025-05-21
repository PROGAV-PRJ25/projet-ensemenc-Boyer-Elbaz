public class Safou : Plante
{
    public Safou() : base(10) // 10 = identifiant pour Safou
    {
        tempMinEnDeg = 18;         // °C
        tempMaxEnDeg = 28;         // °C
        humiditeSolMin = 60;       // %
        humiditeSolMax = 85;       // %
        comestible = true;         // Le fruit est très nutritif
        seuilLuminosite = 75;      // % - tolère ombre partielle
        vitesseCroissance = 1;     // Croissance modérée
    }
}
