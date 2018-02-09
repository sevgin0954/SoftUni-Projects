using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue player1Cards = new Queue(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries));
        Queue player2Cards = new Queue(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries));

        int turnsCount = 0;
        string gameResult = "";

        while (true)
        {
                if (player1Cards.Count == 0 || player2Cards.Count == 0 || turnsCount >= 1000000)
                {
                    if (player1Cards.Count == player2Cards.Count)
                    {
                        gameResult = "Draw";
                    }
                    else if (player1Cards.Count > player2Cards.Count)
                    {
                        gameResult = "First player wins";
                    }
                    else
                    {
                        gameResult = "Second player wins";
                    }

                    break;
                }

                turnsCount++;

                string player1Card = player1Cards.Dequeue().ToString();
                string player2Card = player2Cards.Dequeue().ToString();

                int cardNum1 = int.Parse(player1Card.Substring(0, player1Card.Length - 1));
                int cardNum2 = int.Parse(player2Card.Substring(0, player2Card.Length - 1));

                if (cardNum1 == cardNum2)
                {
                    List<string> playedCards = new List<string>();
                    playedCards.Add(player1Card);
                    playedCards.Add(player2Card);
                    bool isWarEnded = false;

                    while (isWarEnded == false)
                    {
                        int cards1Sum = 0;
                        int cards2Sum = 0;

                        for (int a = 0; a < 3; a++)
                        {
                            if (player1Cards.Count == 0 || player2Cards.Count == 0)
                            {
                                isWarEnded = true;
                                break;
                            }

                            string card1 = player1Cards.Dequeue().ToString();
                            string card2 = player2Cards.Dequeue().ToString();
                            playedCards.Add(card1);
                            playedCards.Add(card2);

                            int card1Power = card1[card1.Length - 1] - 'a' + 1;
                            int card2Power = card2[card2.Length - 1] - 'a' + 1;

                            cards1Sum += card1Power;
                            cards2Sum += card2Power;
                        }

                        if (cards1Sum != cards2Sum && isWarEnded == false)
                        {
                            playedCards = playedCards.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ToList();
                            isWarEnded = true;

                            if (cards1Sum > cards2Sum)
                            {
                                AddCardsToPlayer(player1Cards, playedCards);
                            }
                            else
                            {
                                AddCardsToPlayer(player2Cards, playedCards);
                            }
                        }
                    }
                }
                else if (cardNum1 > cardNum2)
                {
                    player1Cards.Enqueue(player1Card);
                    player1Cards.Enqueue(player2Card);
                }
                else
                {
                    player2Cards.Enqueue(player2Card);
                    player2Cards.Enqueue(player1Card);
                }
        }

        Console.WriteLine($"{gameResult} after {turnsCount} turns");
    }

    static void AddCardsToPlayer(Queue player, List<string> cards)
    {
        foreach (string card in cards)
        {
            player.Enqueue(card);
        }
    }
}