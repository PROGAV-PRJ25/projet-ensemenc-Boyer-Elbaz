public class Meteo
{
    public Monde monde {get; set;}

    public Meteo()
    {
        monde = new Monde();
    }

    public void NouvelleMeteo(Monde monde)
    {
        Random rng = new Random();

        // Variables changeant à chaque tour modifiant la température, luminosité et l'humidité
        int indicateurTemp;
        int indicateurLumi;
        int indicateurHumi;

        foreach(var terrain in monde.terrainsDuMonde)
        {
            terrain.temperatureActuelleEnDeg = terrain.temperatureMoyenneEnDeg; //Avant chaque nouvelle météo, les valeurs sont réinitiallisées : les météos sont donc indépendantes 
            terrain.luminositeActuelle = terrain.luminositeMoyenne;
            terrain.humiditeActuelle = terrain.luminositeMoyenne;


            // Définition de la température pour le tour
            indicateurTemp = rng.Next(0,101);
            if((indicateurTemp<=5)||(indicateurTemp>=95))
            {
                terrain.temperatureActuelleEnDeg += 3;
            }
            else if((indicateurTemp>5)&&(indicateurTemp<=15)||(indicateurTemp<95)&&(indicateurTemp>=80))
            {
                terrain.temperatureActuelleEnDeg += 2;
            }
            else if((indicateurTemp>15)&&(indicateurTemp<=25)||(indicateurTemp<80)&&(indicateurTemp>=70))
            {
                terrain.temperatureActuelleEnDeg++;
            }

        // Définition de la luminosité pour le tour
            indicateurLumi = rng.Next(0,101);
            if((indicateurLumi<=5)||(indicateurLumi>=95))
            {
                terrain.luminositeActuelle -= 20;
            }
            else if((indicateurLumi>5)&&(indicateurLumi<=15)||(indicateurLumi<95)&&(indicateurLumi>=80))
            {
                terrain.luminositeActuelle -= 10;
            }
            else if((indicateurLumi>15)&&(indicateurLumi<=25)||(indicateurLumi<80)&&(indicateurLumi>=70))
            {
                terrain.luminositeActuelle -= 5;
            }
            
        // Définition de l'humidité pour le tour
            indicateurHumi = rng.Next(0,101);
            if((indicateurHumi<=5)||(indicateurHumi>=95))
            {
                terrain.humiditeActuelle -= 20;
            }
            else if((indicateurHumi>5)&&(indicateurHumi<=15)||(indicateurHumi<95)&&(indicateurHumi>=80))
            {
                terrain.humiditeActuelle -= 10;
            }
            else if((indicateurHumi>15)&&(indicateurHumi<=25)||(indicateurHumi<80)&&(indicateurHumi>=70))
            {
                terrain.humiditeActuelle -= 5;
            }
        }
    }
}