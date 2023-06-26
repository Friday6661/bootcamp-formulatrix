using IBoardLib;
namespace BoardLib;

public class Board : IBoard
{
    private int _size;
    private Dictionary<int, int> _snake;
    private Dictionary<int, int> _ladder;

    public Board(){}
    public Board(int size, Dictionary<int, int> snake, Dictionary<int, int> ladder)
    {
        _size = size;
        _snake = snake;
        _ladder = ladder;
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
    // public void SetSnake(int snakeHead, int snakeTail)
    // {
    //     _snake.Add(new(snakeHead, snakeTail));
    // }
    public void AddSnake(int head, int tail)
    {
        _snake[head] = tail;
    }
    public void RemoveSnake(int head, int tail)
    {
        _snake[head] = tail;
    }
    public Dictionary<int, int> GetSnake()
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
    public Dictionary<int, int> GetLadder()
    {
        return _ladder;
    }
}