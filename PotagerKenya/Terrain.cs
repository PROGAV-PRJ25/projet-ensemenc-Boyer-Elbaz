public class Terrain
{
    public int Lignes {get; set;}
    public int Colonnes {get; set;}
    public string[][] Grille {get; set;}

    public Terrain(int LesLignes=5, int LesColonnes=5) 
    {
        Lignes = LesLignes;
        Colonnes = LesColonnes;
        Grille = new string[Lignes][];
        for(int i=0; i<Grille.Length; i++)
        {
            Grille[i] = new int[Colonnes];
            for(int j=0; j<Grille[i].Length; j++)
            {
                Grille[i][j] = " ";
            }
        }
    }
}