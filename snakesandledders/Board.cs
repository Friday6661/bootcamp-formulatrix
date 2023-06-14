namespace BoardLib;
using IBoardLib;
//using TileTypeLib;

public class Board : IBoard
{
    private int _size;
    private Dictionary<int, int> _snake;
    private Dictionary<int, int> _ladder;

    public Board(int size)
    {
        _size = size;
        _snake = new Dictionary<int, int>();
        _ladder = new Dictionary<int, int>();
    }

    public int GetSize()
    {
        return _size;
    }

    public void SetSize(int size)
    {
        _size = size;
    }

    public void AddSnake(int start, int end)
    {
        if (start <= end)
        {
            throw new ArgumentException("Invalid snake configuration");
        }
        _snake[start] = end;
    }

    public void AddLadder(int start, int end)
    {
        if (start >= end)
        {
            throw new ArgumentException("Invalid ladder configuration");
        }
        _ladder[start] = end;
    }

    public Dictionary<int, int> GetSnakes()
    {
        return _snake;
    }

    public Dictionary<int, int> GetLadders()
    {
        return _ladder;
    }

    public int GetSnakeEndPosition(int start)
    {
        if (_snake.TryGetValue(start, out int end))
        {
            return end;
        }
        throw new ArgumentException("No Snake found at the specified position");
    }

    public int GetLadderEndPosition(int start)
    {
        if (_ladder.TryGetValue(start, out int end))
        {
            return end;
        }
        throw new ArgumentException("No Ladder found at the specified position");
    }
}
