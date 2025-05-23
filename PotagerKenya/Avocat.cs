public class Avocat: Plante
{
    public Avocat():base(2)
    {
        tempMinEnDeg = 15;     
        tempMaxEnDeg = 30;     
        humiditeSolMin = 60;   
        humiditeSolMax = 85;   
        comestible = true;     
        seuilLuminosite = 80;  
    }
}