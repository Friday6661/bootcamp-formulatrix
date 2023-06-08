namespace BoardLib;
using IBoardLib;
using TileTypesLib;

public class Board : IBoard
{
    private int _size;
    private Dictionary<int, int> _snakes;
    private Dictionary<int, int> _ladders;
    private Dictionary<int, TileType> _tiles;
    public Board(int size)
    {
        _size = size;
        _snakes = new Dictionary<int, int>();
        _ladders = new Dictionary<int, int>();
        _tiles = new Dictionary<int, TileType>();
    }

    public int GetSize()
    {
        return _size;
    }

    public void SetSize(int size)
    {
        _size = size;
    }

    public void SetTileType(int position, TileType type)
    {
        if (position < 0 || position >= _size)
        {
            throw new ArgumentOutOfRangeException("Invalid position");
        }
        _tiles[position] = type;
    }

    public TileType GetTileType(int position)
    {
        if (!_tiles.ContainsKey(position))
        {
            return TileType.Normal;
        }
        return _tiles[position];
    }

    public void AddSnake()
    {
        int maxPosition = _size / 2 - 1;
        int minPosition = 0;
        int start = GenerateRandomPosition(minPosition, maxPosition);

        if (_ladders.ContainsKey(start))
        {
            AddSnake();
            return;
        }

        int end = GenerateRandomPosition(start+1, _size -1);

        if (start <= end)
        {
            throw new ArgumentException("Invalid snake configuration");
        }
        _snakes[start] = end;
    }
    public void AddLadder()
    {
        int maxPosition = _size / 2 - 1;
        int minPosition = 0;
        int start = GenerateRandomPosition(minPosition, maxPosition);

        if (_snakes.ContainsKey(start))
        {
            AddLadder();
            return;
        }

        int end = GenerateRandomPosition(start +1, _size -1);
        
        if (start >= end)
        {
            throw new ArgumentException("Invalid ladder position");
        }
        _ladders[start] = end;
    }
    public int GetSnakeEndPosition(int start)
    {
        if (_snakes.TryGetValue(start, out int end))
        {
            return end;
        }

        throw new ArgumentException("No snake found at the specified position");
    }
    public int GetLadderEndPosition(int start)
    {
        if (_ladders.TryGetValue(start, out int end))
        {
            return end;
        }

        throw new ArgumentException("No ladder found at the specified position");
    }
    private int GenerateRandomPosition(int minValue, int maxValue)
    {
        Random random = new Random();
        return random.Next(minValue, maxValue + 1);
    }
}