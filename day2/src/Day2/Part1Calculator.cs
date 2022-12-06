namespace Day2;

public static class Part1Calculator
{
    public static int GetScore(string[] input)
    {
        var score = 0;
        
        foreach (var line in input)
        {
            var opponentMove = OpponentMove(line[0]);
            var playerMove = PlayerMove(line[2]);
            score += RockPaperScissors.TotalRoundScore(playerMove, opponentMove);
        }

        return score;
    }

    private static RockPaperScissors.Move PlayerMove(char moveChar) => moveChar switch
    {
        'X' => RockPaperScissors.Move.Rock,
        'Y' => RockPaperScissors.Move.Paper,
        'Z' => RockPaperScissors.Move.Scissors,
        _ => throw new ArgumentOutOfRangeException(nameof(moveChar), $"Unexpected move: {moveChar}")
    };

    private static RockPaperScissors.Move OpponentMove(char moveChar) => moveChar switch
    {
        'A' => RockPaperScissors.Move.Rock,
        'B' => RockPaperScissors.Move.Paper,
        'C' => RockPaperScissors.Move.Scissors,
        _ => throw new ArgumentOutOfRangeException(nameof(moveChar), $"Unexpected move: {moveChar}")
    };
}