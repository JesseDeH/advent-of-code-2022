namespace Day2;

public class RockPaperScissors
{
    public enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public static int TotalRoundScore(RockPaperScissors.Move playerMove, RockPaperScissors.Move opponentMove)
    {
        return (int)playerMove + BattleScore(playerMove, opponentMove);
    }

    public static int BattleScore(RockPaperScissors.Move playerMove, RockPaperScissors.Move opponentMove)
    {
        if (WinsFrom(playerMove) == opponentMove) return 6;
        if (TiesWith(playerMove) == opponentMove) return 3;
        return 0;
    }

    public static Move WinsFrom(Move move) => move switch
    {
        Move.Rock => Move.Scissors,
        Move.Paper => Move.Rock,
        Move.Scissors => Move.Paper,
        _ => throw new ArgumentOutOfRangeException()
    };

    public static Move TiesWith(Move move) => move;

    public static Move LosesTo(Move move) => move switch
    {
        Move.Rock => Move.Paper,
        Move.Paper => Move.Scissors,
        Move.Scissors => Move.Rock,
        _ => throw new ArgumentOutOfRangeException()
    };

}