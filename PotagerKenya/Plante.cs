public abstract class Plante
{
    public string variete {get; set;} 

    public int numeroSerie {get; set;} // Pour identifier la plante
    
    public string visuelPlante {get; set;} 

    public int x {get; set;} //Coordonnées de la plante sur le terrain
    
    public int y {get; set;}

    // Attributs définissant les conditions de vie de la plante
    
    public bool malade {get; set;} // Plante malade ou non
    
    public int semainesMalade {get; set;} // Semaines depuis sa contamination

    public double tempMaxEnDeg {get; set;} // Conditions climatiques de la plante

    public double tempMinEnDeg {get; set;}

    public double humiditeSolMax {get; set;}

    public double humiditeSolMin {get; set;}

    public bool comestible {get; set;}

    public bool enVie {get; set;}

    public double seuilLuminosite {get; set;}

    public Plante(int ChoixNumeroSerie)
    {
        enVie = true; //Lorsque la plante est créée, elle est en vie
        malade = false; //La plante est en bonne santé à sa création
        numeroSerie = ChoixNumeroSerie;
        if(numeroSerie == 1) // ID
        {
            variete = "mangue";     // Définition des plantes existant dans le monde
            visuelPlante = "🥭";
        }
        else if(numeroSerie == 2)
        {
            variete = "avocat";
            visuelPlante = "🥑";
        }
        else if(numeroSerie == 3)
        {
            variete = "ananas";
            visuelPlante = "🍍";
        }
        else if(numeroSerie == 4)
        {
            variete = "palmier à huile";
            visuelPlante = "🌴";
        }
        else if(numeroSerie == 5)
        {
            variete = "rose";
            visuelPlante = "🌹";
        }
        else if(numeroSerie == 6)
        {
            variete = "tomate";
            visuelPlante = "🍅";
        }
        else if(numeroSerie == 7)
        {
            variete = "lentille";
            visuelPlante = "🟢";
        }
        else if(numeroSerie == 8)
        {
            variete = "baobab";
            visuelPlante = "🌳";
        }
        else if(numeroSerie == 9)
        {
            variete = "sorgho";
            visuelPlante = "🌿";
        }
        else if(numeroSerie == 10)
        {
            variete = "safou";
            visuelPlante = "🍆";
        }
        else if(numeroSerie == 11)
        {
            variete = "cocotier";
            visuelPlante = "🥥";
        }
        else if(numeroSerie == 12)
        {
            variete = "blé";
            visuelPlante = "🌾";
        }
    }
}