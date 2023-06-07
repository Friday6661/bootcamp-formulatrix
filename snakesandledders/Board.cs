namespace BoardLib;
using IBoardLib;
using ITileLib;

public class Board : IBoard
{
    private int _size;
    private Dictionary<int, int> _snake;
    private Dictionary<int, int> _ladder;
    private ITile[] _tile;
    public Board(int size)
    {
        _size = size;
        _snake = new Dictionary<int, int>();
        _ladder = new Dictionary<int, int>();
        _tiles = new ITileLib[size];
    }
    public int Size => _size;
    public void AddSnake(int start, int end)
    {
        _snake[start] = end;
    }
    public void AddLadder(int start, int end)
    {
        _ladder[start] = end;
    }
    public ITile GetTile(int position)
    {
        if (position < 0 || position >= _size) 
        {
            throw new ArgumentOutOfRangeException("Invalid position");
        }
        return _tile[position];

    }
}