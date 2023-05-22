using playerLib;
using gameLib;
using battleLib;

class Program {
    static void Main(string[] args) {
        
        // Create Players
        Player player1 = new Player(1, 2);
        Player player2 = new Player(2, 2);

        // Create the game
        Game game = new Game(player1, player2);
        Battle battle = new Battle(player1, player2);

        // Start the game
        game.StartGame();
    }
}