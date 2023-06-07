namespace TileLib;
using ITileLib;

public enum TileType
{
    Normal,
    Snake,
    Ladder
}

public class Tile : ITile
{
    private int _position;
    private TileType _type;

    public Tile(int position, TileType type)
    {
        _position = position;
        _type = type;
    }
    public int GetPosition()
    {
        return position;
    }

    public TileType GetType()
    {
        return type;
    }

}
