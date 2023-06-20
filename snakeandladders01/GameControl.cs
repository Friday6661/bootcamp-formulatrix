using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace GameControlLib;

class GameControl
{
    private List<IPlayer> _players;
    private Dice _dice;
    private Board _board;
    private Dictionary<IPlayer, int> _playerPosition;
    private Dictionary<IPlayer, int> _lastRollValue;
    public GameControl()
    {
        _players = new List<IPlayer>();
        _dice = new Dice(0);
        _board = new Board(0);
        _playerPosition = new Dictionary<IPlayer, int>();
        _lastRollValue = new Dictionary<IPlayer, int>();
    }
    
    // Setup Players
    public bool SetPlayers(List<IPlayer> players)
    {
        if (players.Count >= 2 && players.Count <= 4)
        {
            _players = players;
            return true;
        }
        return false;
    }
    public List<IPlayer> GetPlayers()
    {
        return _players;
    }
    public bool SetPlayerName(IPlayer player, string name)
    {
        if (GetPlayersCount() != null && name.Length > 2)
        {
            player.SetName(name);
            return true;
        }
        return false;
    }
    public int GetPlayersCount()
    {
        return _players.Count();
    }
    public string GetPlayerName(IPlayer player)
    {
        if (player != null)
        {
            return player.GetName();
        }
        return string.Empty;
    }
    public IPlayer GetPlayerAtPosition(int position)
    {
        foreach (KeyValuePair<IPlayer, int> entry in _playerPosition)
        {
            if (entry.Value == position)
            {
                return entry.Key;
            }
        }
        return null;
    } 
    public List<IPlayer> GetPlayersInPosition(int position)
    {
        List<IPlayer> playersInPosition = new List<IPlayer>();
        foreach (KeyValuePair<IPlayer, int> entry in _playerPosition)
        {
            if (entry.Value == position)
            {
                playersInPosition.Add(entry.Key);
            }
        }
        return playersInPosition;
    }
    public int GetPlayerPosition(IPlayer player)
    {
        if (_playerPosition.ContainsKey(player))
        {
            return _playerPosition[player];
        }
        return 0;
    }
    public bool SetPlayerPosition(IPlayer player, int position)
    {
        if (_playerPosition.ContainsKey(player))
        {
            _playerPosition[player] = position;
        }
        return true;
    }

    // Setup Dice
    public bool SetDice(Dice dice)
    {
        if (dice != null)
        {
            _dice = dice;
            return true;
        }
        return false;
    }
    public Dice GetDice(){
        return _dice;
    }
    public int GetNumberOfSides()
    {
        return _dice.GetNumberOfSides();
    }
    public bool SetRollAgain(IPlayer player, bool rollAgain)
    {
        if (_lastRollValue.ContainsKey(player))
        {
            _lastRollValue[player] = rollAgain ? _dice.GetNumberOfSides() : 0;
            return true;
        }
        return false;
    }

    // Setup Board
    public bool SetBoard(Board board)
    {
        if (board != null)
        {
            _board = board;
            return true;
        }
        return false;
    }
    public Board GetBoard()
    {
        return _board;
    }
    public bool SetSnake(int head, int tail)
    {
        if (head > tail && head <= _board.GetSize() && tail > 0)
        {
            _board.AddSnake(head, tail);
            return true;
        }
        return false;
    }
    public bool SetLadder(int bottom, int top)
    {
        if (top > bottom && top <= _board.GetSize() && bottom > 0)
        {
            _board.AddLadder(bottom, top);
            return true;
        }
        return false;
    }
    public int GetSnakeHead(int tailPosition)
    {
        foreach (var snake in _board.GetSnake())
        {
            if (snake.Value == tailPosition)
            {
                return snake.Key;
            }
        }
        return 0;
    }
    public int GetSnakeTail(int headPosition)
    {
        foreach (var snake in _board.GetSnake())
        {
            if (snake.Key == headPosition)
            {
                return snake.Value;
            }
        }
        return 0;
    }
}