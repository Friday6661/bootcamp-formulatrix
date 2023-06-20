using IBoardLib;
namespace BoardLib;

public class Board : IBoard
{
    private int _size;
    private IDictionary<int, int> _snake;
    private IDictionary<int, int> _ladder;

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
    public bool SetSize(int size)
    {
        if (size > 0)
        {
            _size = size;
            return true;
        }
        return false;
    }
    public void AddSnake(int head, int tail)
    {
        _snake[head] = tail;
    }
    public void RemoveSnake(int head, int tail)
    {
        _snake[head] = tail;
    }
    public IDictionary<int, int> GetSnake()
    {
        return _snake;
    }
    public void AddLadder(int bottom, int top)
    {
        _ladder[bottom] = top;
    }
    public void RemoveLadder(int bottom, int top)
    {
        _ladder[bottom] = top;
    }
    public IDictionary<int, int> GetLadder()
    {
        return _ladder;
    }
}