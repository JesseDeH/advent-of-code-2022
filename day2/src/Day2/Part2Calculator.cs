using System.Diagnostics;

namespace Day2;

public class Part2Calculator
{
    public static int GetScore(string[] input)
    {
        var score = 0;
        
        foreach (var line in input)
        {
            var opponentMove = OpponentMove(line[0]);
            var playerMove = PlayerMove(line[2], opponentMove);
            score += RockPaperScissors.TotalRoundScore(playerMove, opponentMove);
        }

        return score;
    }

    private static RockPaperScissors.Move PlayerMove(char moveChar, RockPaperScissors.Move opponentMove) => moveChar switch
    {
        'X' => RockPaperScissors.WinsFrom(opponentMove),
        'Y' => RockPaperScissors.TiesWith(opponentMove),
        'Z' => RockPaperScissors.LosesTo(opponentMove),
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