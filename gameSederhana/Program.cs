using gameLib;


class Program {
    static void Main(string[] args) {
        Game game = new Game();

        // Setup Game
        game.SetupGame();

        // Memulai Game
        game.StartGame();

        // Mengakhiri Game dan Menampilkan Hasil Game
        game.EndGame();

        Console.ReadLine();
    }
}