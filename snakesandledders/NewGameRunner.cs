namespace GameRunnerLib;
using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using TileTypeLib;

class GameRunner
{
    private List<Player> _players;
    private Dice _dice;
    private Board _board;
    private Dictionary<Player, int> _playerPostions;

    public event Action<string> DisplayMessage;

    public GameRunner(Board board, Dice numberOfDices)
    {
        _players = new List<Player>();
        _dice = numberOfDices;
        _board = board;
        _playerPostions = new Dictionary<Player, int>();
    }

    public void SetPlayers(List<Player> players)
    {
        _players = players;
    }

    public List<Player> GetPlayers()
    {
        return _players;
    }

    public void SetNumberOfDices(int numberOfDices)
    {
        _dice = new Dice(numberOfDices);
    }

    public int GetNumberOfDices()
    {
        return _dice;
    }

    public void SetBoardSize(int size)
    {
        _board = new Board(size);
    }

    public void AddPlayer(string name)
    {
        _players.Add(new Player(name));
    }

    public void RemovePlayer(string name)
    {
        _players.Remove(new Player(name));
    }

    public void GetPlayerPosition(int position)
    {
        
    }

    public void StartGame()
    {
        DisplayMessage?.Invoke("Game Started");
        while (!IsGameFinished())
        {
            foreach (Player player in _players)
            {
                PlayerInfo(player);
                Console.ReadLine();

                bool rollAgain = true;
                int totalRolls = 0;

                while (rollAgain && totalRolls < 3)
                {
                    RollDice(player);
                    MoveForward(player);
                    totalRolls++;

                    if (ShouldRollAgain(player))
                    {
                        DisplayMessage?.Invoke($"Player {player.GetName()} roll a {numberOfDices.GetNumberOfDices()} Roll Again.");
                    }
                    else
                    {
                        rollAgain = false;
                    }
                    AllPlayerPositions();
                }

            }
        }
        EndGame();
    }
    private void PlayerInfo(Player player)
    {
        DisplayMessage?.Invoke($"\nPlayer: {player.GetName()} Position: {}");
        DisplayMessage?.Invoke($"Press Enter to roll the dice for Player {player.GetName()} ...");
    }

    
}
