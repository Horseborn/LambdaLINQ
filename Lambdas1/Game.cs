namespace Lambdas1;

public class Game
{
    public Game(string name, DateTime releaseDate, int steamScore)
    {
        this._name = name;
        this._releaseDate = releaseDate;
        this._steamScore = steamScore;
    }

    public string _name { get; set; }
    public DateTime _releaseDate { get; set; }
    public int _steamScore { get; set; }
    
    
}