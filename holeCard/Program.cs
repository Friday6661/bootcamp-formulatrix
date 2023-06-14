using System;
using System.Collections.Generic;
using System.Linq;

enum CardSuit
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}

enum CardRank
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

class Card
{
    public CardRank Rank { get; set; }
    public CardSuit Suit { get; set; }

    public Card(CardRank rank, CardSuit suit)
    {
        Rank = rank;
        Suit = suit;
    }
}

class Rule
{
    public static bool IsRoyalFlush(List<Card> hand)
    {
        // Cek apakah kombinasi kartu adalah Royal Flush
        bool hasTen = false;
        bool hasJack = false;
        bool hasQueen = false;
        bool hasKing = false;
        bool hasAce = false;

        foreach (Card card in hand)
        {
            if (card.Rank == CardRank.Ten)
            {
                hasTen = true;
            }
            else if (card.Rank == CardRank.Jack)
            {
                hasJack = true;
            }
            else if (card.Rank == CardRank.Queen)
            {
                hasQueen = true;
            }
            else if (card.Rank == CardRank.King)
            {
                hasKing = true;
            }
            else if (card.Rank == CardRank.Ace)
            {
                hasAce = true;
            }
        }

        if (hasTen && hasJack && hasQueen && hasKing && hasAce)
        {
            return true;
        }

        return false;
    }

    public static bool IsStraightFlush(List<Card> hand)
    {
        // Cek apakah kombinasi kartu adalah Straight Flush
        if (IsStraight(hand) && IsFlush(hand))
        {
            return true;
        }

        return false;
    }

    public static bool IsFourOfAKind(List<Card> hand)
    {
        // Cek apakah kombinasi kartu adalah Four of a Kind
        Dictionary<CardRank, int> rankCounts = new Dictionary<CardRank, int>();

        foreach (Card card in hand)
        {
            if (rankCounts.ContainsKey(card.Rank))
            {
                rankCounts[card.Rank]++;
            }
            else
            {
                rankCounts.Add(card.Rank, 1);
            }
        }

        foreach (KeyValuePair<CardRank, int> pair in rankCounts)
        {
            if (pair.Value == 4)
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsFullHouse(List<Card> hand)
    {
        if (IsThreeOfAKind(hand) && IsOnePair(hand))
        {
            return true;
        }

        return false;
    }

    public static bool IsFlush(List<Card> hand)
    {
        CardSuit suit = hand[0].Suit;

        foreach (Card card in hand)
        {
            if (card.Suit != suit)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsStraight(List<Card> hand)
    {
        List<CardRank> ranks = hand.Select(card => card.Rank).Distinct().OrderBy(rank => rank).ToList();

        if (ranks.Count == 5)
        {
            if (ranks[4] - ranks[0] == 4)
            {
                return true;
            }
            else if (ranks[0] == CardRank.Ace && ranks[3] == CardRank.Five && ranks[4] == CardRank.King)
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsThreeOfAKind(List<Card> hand)
    {
        Dictionary<CardRank, int> rankCounts = new Dictionary<CardRank, int>();

        foreach (Card card in hand)
        {
            if (rankCounts.ContainsKey(card.Rank))
            {
                rankCounts[card.Rank]++;
            }
            else
            {
                rankCounts.Add(card.Rank, 1);
            }
        }

        foreach (KeyValuePair<CardRank, int> pair in rankCounts)
        {
            if (pair.Value == 3)
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsOnePair(List<Card> hand)
    {
        Dictionary<CardRank, int> rankCounts = new Dictionary<CardRank, int>();

        foreach (Card card in hand)
        {
            if (rankCounts.ContainsKey(card.Rank))
            {
                rankCounts[card.Rank]++;
            }
            else
            {
                rankCounts.Add(card.Rank, 1);
            }
        }

        foreach (KeyValuePair<CardRank, int> pair in rankCounts)
        {
            if (pair.Value == 2)
            {
                return true;
            }
        }

        return false;
    }
}
class TexasHoldemGame
{
    private List<string> players;
    private List<Card> deck;
    private List<Card> communityCards;

    public TexasHoldemGame(List<string> players)
    {
        this.players = players;
        communityCards = new List<Card>();
        deck = GenerateDeck();
    }

    public void Preflop()
    {
        Console.WriteLine("=== PREFLOP ===");

        foreach (string player in players)
        {
            CardSuit suit1 = GetRandomSuit();
            CardRank rank1 = GetRandomRank();

            CardSuit suit2;
            CardRank rank2;

            do
            {
                suit2 = GetRandomSuit();
                rank2 = GetRandomRank();
            }
            while ((suit2.Equals(suit1) && rank2.Equals(rank1)) || (suit2.Equals(rank1) && rank2.Equals(suit1))); // Memastikan kartu kedua berbeda dari kartu pertama

            // Hapus kartu dari deck setelah dibagikan
            RemoveCardFromDeck(rank1, suit1);
            RemoveCardFromDeck(rank2, suit2);

            Console.WriteLine($"{player} receives {rank1} of {suit1} and {rank2} of {suit2}.");
        }
        Console.WriteLine("Preflop betting round begins.");

        foreach (string player in players)
        {
            Console.WriteLine($"{player}, it's your turn.");
            Console.WriteLine("Choose your action: (1) Check, (2) Bet, (3) Fold");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{player} checks.");
                    break;
                case 2:
                    Console.WriteLine("Enter your bet amount:");
                    int betAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine($"{player} bets {betAmount} chips.");
                    break;
                case 3:
                    Console.WriteLine($"{player} folds.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid action.");
                    break;
            }
        }

        Console.WriteLine("Preflop betting round ends.");
    }

    public void Flop()
    {
        Console.WriteLine("\n=== FLOP ===");

        Console.WriteLine("Dealing three community cards.");
        for (int i = 0; i < 3; i++)
        {
            CardSuit suit = GetRandomSuit();
            CardRank rank = GetRandomRank();

            // Hapus kartu dari deck setelah dibagikan
            RemoveCardFromDeck(rank, suit);

            Card communityCard = new Card(rank, suit);
            communityCards.Add(communityCard);

            Console.WriteLine($"Community card: {rank} of {suit}");
        }

        Console.WriteLine("Flop betting round begins.");

        foreach (string player in players)
        {
            Console.WriteLine($"{player}, it's your turn.");
            Console.WriteLine("Choose your action: (1) Check, (2) Bet, (3) Fold");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{player} checks.");
                    break;
                case 2:
                    Console.WriteLine("Enter your bet amount:");
                    int betAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine($"{player} bets {betAmount} chips.");
                    break;
                case 3:
                    Console.WriteLine($"{player} folds.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid action.");
                    break;
            }
        }

        Console.WriteLine("Flop betting round ends.");
    }

    public void Turn()
    {
        Console.WriteLine("\n=== TURN ===");

        Console.WriteLine("Dealing the turn card.");
        CardSuit suit = GetRandomSuit();
        CardRank rank = GetRandomRank();

        // Hapus kartu dari deck setelah dibagikan
        RemoveCardFromDeck(rank, suit);

        Card turnCard = new Card(rank, suit);
        communityCards.Add(turnCard);

        Console.WriteLine($"Turn card: {rank} of {suit}");

        Console.WriteLine("Turn betting round begins.");

        foreach (string player in players)
        {
            Console.WriteLine($"{player}, it's your turn.");
            Console.WriteLine("Choose your action: (1) Check, (2) Bet, (3) Fold");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{player} checks.");
                    break;
                case 2:
                    Console.WriteLine("Enter your bet amount:");
                    int betAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine($"{player} bets {betAmount} chips.");
                    break;
                case 3:
                    Console.WriteLine($"{player} folds.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid action.");
                    break;
            }
        }

        Console.WriteLine("Turn betting round ends.");
    }

    public void River()
    {
        Console.WriteLine("\n=== RIVER ===");

        Console.WriteLine("Dealing the river card.");
        CardSuit suit = GetRandomSuit();
        CardRank rank = GetRandomRank();

        // Hapus kartu dari deck setelah dibagikan
        RemoveCardFromDeck(rank, suit);

        Card riverCard = new Card(rank, suit);
        communityCards.Add(riverCard);

        Console.WriteLine($"River card: {rank} of {suit}");

        Console.WriteLine("River betting round begins.");

        foreach (string player in players)
        {
            Console.WriteLine($"{player}, it's your turn.");
            Console.WriteLine("Choose your action: (1) Check, (2) Bet, (3) Fold");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{player} checks.");
                    break;
                case 2:
                    Console.WriteLine("Enter your bet amount:");
                    int betAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine($"{player} bets {betAmount} chips.");
                    break;
                case 3:
                    Console.WriteLine($"{player} folds.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid action.");
                    break;
            }
        }

        Console.WriteLine("River betting round ends.");
    }

    public void Showdown()
    {
        Console.WriteLine("\n=== SHOWDOWN ===");

        foreach (string player in players)
        {
            Console.WriteLine($"{player}'s hand: ");
            // Menampilkan kartu pemain
            // ...
        }

        Console.WriteLine("Community cards: ");
        foreach (Card card in communityCards)
        {
            Console.WriteLine($"{card.Rank} of {card.Suit}");
        }

        // Menerapkan logika penentuan pemenang
        Dictionary<string, List<Card>> playerHands = new Dictionary<string, List<Card>>();

        foreach (string player in players)
        {
            List<Card> playerHand = new List<Card>();
            playerHand.AddRange(communityCards);
            // Menggabungkan kartu pemain dengan kartu community
            // ...
            playerHands.Add(player, playerHand);
        }

        // Menentukan pemenang berdasarkan kombinasi kartu terbaik
        List<string> winners = DetermineWinners(playerHands);

        Console.WriteLine("Winner(s):");
        foreach (string winner in winners)
        {
            Console.WriteLine(winner);
        }
    }

    private List<Card> GenerateDeck()
    {
        List<Card> deck = new List<Card>();

        foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                deck.Add(new Card(rank, suit));
            }
        }

        return deck;
    }

    private CardSuit GetRandomSuit()
    {
        Random random = new Random();
        Array values = Enum.GetValues(typeof(CardSuit));
        return (CardSuit)values.GetValue(random.Next(values.Length));
    }

    private CardRank GetRandomRank()
    {
        Random random = new Random();
        Array values = Enum.GetValues(typeof(CardRank));
        return (CardRank)values.GetValue(random.Next(values.Length));
    }

    private void RemoveCardFromDeck(CardRank rank, CardSuit suit)
    {
        Card cardToRemove = deck.Find(c => c.Rank == rank && c.Suit == suit);
        deck.Remove(cardToRemove);
    }

    private List<string> DetermineWinners(Dictionary<string, List<Card>> playerHands)
    {
        List<string> winners = new List<string>();

        // Menghitung skor tangan setiap pemain
        Dictionary<string, int> playerScores = new Dictionary<string, int>();

        foreach (KeyValuePair<string, List<Card>> pair in playerHands)
        {
            List<Card> hand = pair.Value;

            // Menghitung skor tangan berdasarkan kombinasi kartu terbaik
            int score = CalculateHandScore(hand);
            playerScores.Add(pair.Key, score);
        }

        // Menentukan skor tertinggi
        int highestScore = playerScores.Values.Max();

        // Mencari pemain yang memiliki skor tertinggi
        foreach (KeyValuePair<string, int> pair in playerScores)
        {
            if (pair.Value == highestScore)
            {
                winners.Add(pair.Key);
            }
        }

        return winners;
    }

    private int CalculateHandScore(List<Card> hand)
    {
        int score = 0;

        // Lakukan pengecekan kombinasi kartu terbaik berdasarkan urutan prioritas
        if (Rule.IsRoyalFlush(hand))
        {
            score = 10;
        }
        else if (Rule.IsStraightFlush(hand))
        {
            score = 9;
        }
        else if (Rule.IsFourOfAKind(hand))
        {
            score = 8;
        }
        else if (Rule.IsFullHouse(hand))
        {
            score = 7;
        }
        else if (Rule.IsFlush(hand))
        {
            score = 6;
        }
        else if (Rule.IsStraight(hand))
        {
            score = 5;
        }
        else if (Rule.IsThreeOfAKind(hand))
        {
            score = 4;
        }
        /*else if (Rule.IsTwoPair(hand))
        {
            score = 3;
        }*/
        else if (Rule.IsOnePair(hand))
        {
            score = 2;
        }
        else
        {
            score = 1;
        }

        return score;
    }
}

class Program
{
    static void Main()
    {
        // Contoh penggunaan kelas TexasHoldemGame
        List<string> players = new List<string> { "Player 1", "Player 2", "Player 3" };
        TexasHoldemGame game = new TexasHoldemGame(players);

        game.Preflop();
        game.Flop();
        game.Turn();
        game.River();
        game.Showdown();
    }
}
