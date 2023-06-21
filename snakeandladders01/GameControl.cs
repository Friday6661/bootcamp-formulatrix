using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using CellTypeLib;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace GameControlLib;

class GameControl
{
    private IList<IPlayer> _players;
    private Dice _dice;
    private Board _board;
    private CellType _cellType;
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
    public void AddPlayer(string name)
    {
        _players.Add(new Player(name));
    }
    public bool SetPlayers(IList<IPlayer> players)
    {
        if (players.Count >= 2 && players.Count <= 4)
        {
            _players = players;
            return true;
        }
        return false;
    }
    public IList<IPlayer> GetPlayers()
    {
        return _players;
    }
    public int GetPlayersCount()
    {
        return _players.Count();
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
    public string GetPlayerName(IPlayer player)
    {
        if (player != null)
        {
            return player.GetName();
        }
        return string.Empty;
    }
    public string GetPlayerID(IPlayer player)
    {
        if (player != null)
        {
            return player.GetId();
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
    public IList<IPlayer> GetPlayersInPosition(int position)
    {
        IList<IPlayer> playersInPosition = new List<IPlayer>();
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
    public IList<string> GetAllPlayerNames()
    {
        return _players.Select(player => player.GetName()).ToList();
    }
    public IList<string> GetAllPlayerIDs()
    {
        return _players.Select(player => player.GetId()).ToList();
    }
    public IList<IPlayer> GetPlayersAtFinished()
    {
        IList<IPlayer> playersAtFinished = new List<IPlayer>();
        foreach (var player in _players)
        {
            if (GetPlayerPosition(player) == _board.GetSize())
            {
                playersAtFinished.Add(player);
            }
        }
        return playersAtFinished;
    }
    public void MovePlayer(IPlayer player)
    {
        int currentPosition = GetPlayerPosition(player);
        int newPosition = currentPosition + _lastRollValue[player];
        if (newPosition < _board.GetSize())
        {
            switch (GetCellType(newPosition))
            {
                case CellType.SnakeHead:
                    newPosition = HandleSnakeEncounter(player, newPosition);
                    break;
                case CellType.LadderBottom:
                    newPosition = HandleLadderEncounter(player, newPosition);
                    break;
                default:
                    break;
            }
        }
        else if (newPosition > _board.GetSize())
        {
            newPosition = _board.GetSize() - (newPosition - _board.GetSize());
        }
        else if (newPosition == _board.GetSize())
        {
            IList<IPlayer> playersAtFinished = GetPlayersAtFinished();
        }
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
    public void RollDice(IPlayer player)
    {
        int roll = _dice.GetRoll();
        _lastRollValue[player] = roll;
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
    public bool SetBoard(int size)
    {
        if (size > 0)
        {
            _board = new Board(size);
            return true;
        }
        return false;
    }
    public Board GetBoard()
    {
        return _board;
    }
    public bool SetSnake(Dictionary<int, int> snakes)
    {
        foreach (var snake in snakes)
        {
            if (snake.Key > snake.Value && snake.Key < _board.GetSize() && snake.Value > 0)
            {
                _board.AddSnake(snake.Key, snake.Value);
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    public bool SetLadder(Dictionary<int, int> ladders)
    {
        foreach (var ladder in ladders)
        {
            if (ladder.Key > ladder.Value && ladder.Key < _board.GetSize() && ladder.Value > 0)
            {
                _board.AddSnake(ladder.Key, ladder.Value);
            }
            else
            {
                return false;
            }
        }
        return true;
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
    public int GetLadderBottom(int topPosition)
    {
        foreach (var ladder in _board.GetLadder())
        {
            if (ladder.Value == topPosition)
            {
                return ladder.Key;
            }
        }
        return 0;
    }
    public int GetLadderTop(int bottomPosition)
    {
        foreach (var ladder in _board.GetLadder())
        {
            if (ladder.Key == bottomPosition)
            {
                return ladder.Value;
            }
        }
        return 0;
    }
    public int HandleSnakeEncounter(IPlayer player, int currentPosition)
    {
        return GetSnakeTail(currentPosition);
    }
    public int HandleLadderEncounter(IPlayer player, int currentPosition)
    {
        return GetLadderTop(currentPosition);
    }
    public bool SetGameFinished()
    {
        foreach (IPlayer player in _players)
        {
            if (GetPlayerPosition(player) == _board.GetSize())
            {
                return true;
            }
        }
        return false;
    }
    public CellType GetCellType(int position)
    {
        if (_board.GetSnake().ContainsKey(position))
        {
            int tailPosition = _board.GetSnake()[position];
            return GetSnakeHead(tailPosition) != 0 ? CellType.SnakeHead : CellType.SnakeTail;
        }
        else if (_board.GetLadder().ContainsKey(position))
        {
            int topPosition = _board.GetLadder()[position];
            return GetLadderBottom(topPosition) != 0 ? CellType.LadderBottom : CellType.LadderTop;
        }
        else if (_playerPosition.ContainsValue(position))
        {
            return CellType.Player;
        }
        else
        {
            return CellType.Normal;
        }
    }
}
