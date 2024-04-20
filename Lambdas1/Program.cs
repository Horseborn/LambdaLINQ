namespace Lambdas1;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        var myNumbers = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

        // var numbersOver5 = new List<int>();
        //
        // foreach (var number in myNumbers)
        // {
        //     if (number > 5 )
        //     {
        //         numbersOver5.Add(number);
        //     }

        var numbersOver5 = myNumbers.Where(number => number > 5);
        // Give me the items from thist list WHERE my condition is met
        // number is the argument - "=>" is the arrow operator or the lambda operator, inline function withouth a name


        var gameList = new List<Game>
        {
            new Game("Death Stranding", new DateTime(2019, 11, 8), 9),
            new Game("Dark Souls 3", new DateTime(2015, 3, 24), 9),
            new Game("Cyberpunk 2077", new DateTime(2020, 7, 17), 7),
            new Game("Valheim", new DateTime(2021, 2, 2), 10),
            new Game("Loop Hero", new DateTime(2021, 3, 4), 9),
            new Game("The Forest", new DateTime(2014, 5, 3), 8),
            new Game("Factorio", new DateTime(2016, 2, 21), 10),
            new Game("Mass Effect 3", new DateTime(2012, 3, 6), 7)
        };

        var suggestedGames = gameList
            .Where(game => game._steamScore >= 9 && game._releaseDate.Year > 2018)
            .OrderBy(game => rand.Next())
            .Take(3)
            .AddRatingToNames();
        Console.WriteLine(suggestedGames);


        bool allHave9ScoreOrBetter = gameList.All(game => game._steamScore >= 9);

        IEnumerable<string> gameNames = gameList.Select(game => game._name);

        //Game gameWithScoreOf2 = gameList.First(game => game._steamScore == 2); //beware as this will throw an error if no matching is found
        Game gameWithScoreOf2Proper =
            gameList.FirstOrDefault(game =>
                game._steamScore == 2); // This will return it if any is found, else return null
    }
}

public static class Helpers
{
    public static IEnumerable<Game> AddRatingToNames(this IEnumerable<Game> games)
    {
        foreach (var game in games)
        {
            game._name = $"{game._name} - {game._steamScore}";
        }

        return games;
    }
}