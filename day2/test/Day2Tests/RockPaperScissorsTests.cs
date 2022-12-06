using Day2;

namespace Day2Tests;

public class RockPaperScissorsTests
{
    [Test]
    public void SimpleExample()
    {
        // Arrange
        var input = """
            A Y
            B X
            C Z
            """.Split(Environment.NewLine);
        
        
        // Act
        var result = Part1Calculator.GetScore(input);

        // Assert
        Assert.That(result, Is.EqualTo(15));
    }
    
    [Test]
    public void SimplePart2Example()
    {
        // Arrange
        var input = """
            A Y
            B X
            C Z
            """.Split(Environment.NewLine);
        
        
        // Act
        var result = Part2Calculator.GetScore(input);

        // Assert
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void LongerExample()
    {
        // Arrange
        var input = """
            A Y
            B X
            C Z
            A Y
            B Y
            C Z
            """.Split(Environment.NewLine);
        
        
        // Act
        var result = Part1Calculator.GetScore(input);

        // Assert
        Assert.AreEqual(34, result);
    }
    
    [Test]
    public void LongerPart2Example()
    {
        // Arrange
        var input = """
            A Y
            B X
            C Z
            A Y
            B Y
            C Z
            """.Split(Environment.NewLine);
        
        
        // Act
        var result = Part2Calculator.GetScore(input);

        // Assert
        Assert.AreEqual(28, result);
    }

    [Test]
    [TestCase(RockPaperScissors.Move.Rock, RockPaperScissors.Move.Scissors, 6)]
    [TestCase(RockPaperScissors.Move.Paper, RockPaperScissors.Move.Rock, 6)]
    [TestCase(RockPaperScissors.Move.Scissors, RockPaperScissors.Move.Paper, 6)]
    [TestCase(RockPaperScissors.Move.Rock, RockPaperScissors.Move.Rock, 3)]
    [TestCase(RockPaperScissors.Move.Paper, RockPaperScissors.Move.Paper, 3)]
    [TestCase(RockPaperScissors.Move.Scissors, RockPaperScissors.Move.Scissors, 3)]
    [TestCase(RockPaperScissors.Move.Rock, RockPaperScissors.Move.Paper, 0)]
    [TestCase(RockPaperScissors.Move.Paper, RockPaperScissors.Move.Scissors, 0)]
    [TestCase(RockPaperScissors.Move.Scissors, RockPaperScissors.Move.Rock, 0)]
    [Parallelizable(ParallelScope.All)]
    public void TestScore(RockPaperScissors.Move playerMove, RockPaperScissors.Move opponentMove, int expectedScore)
    {
        var actual = RockPaperScissors.BattleScore(playerMove, opponentMove);
        Assert.That(actual, Is.EqualTo(expectedScore));
    }
}