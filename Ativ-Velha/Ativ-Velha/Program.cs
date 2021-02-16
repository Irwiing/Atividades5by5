using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ativ_Velha
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[3, 3];
            string[,] players = new string[2,2];
            int status = 0, round = 1, playing = 0;

            while(true)
            {
                if(status != 3)
                {
                    //resetar o jogo                   
                    playing = CreatePlayers(players);
                    ResetBoard(board);                    
                    status = 3;
                }
                RenderScreen(board);
                AwaitPlayerInput(board, players, playing);
                if (round >= 5)
                {
                    status = Validate(board, players, playing, round);
                }
                playing = ChangePlayer(playing);
                round++;
            }
        }

        static void ResetBoard(string[,] board)
        {
            //terá a responsabilidade de Limpar o board para começar o jogo
            for (int l = 0; l < board.GetLength(0); l++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    board[l, c] = "_";
                }                
            }
        }
        static int CreatePlayers(string[,] players)
        {
            //Terá a responsabilidade de Receber os nomes de usuarios e selecionar quem jogará primeiro
            Random tmp = new Random();
            Console.Clear();
            Console.Write("Informe o nome do jogador 1: ");
            players[0,0] = Console.ReadLine();

            Console.Write("Informe o nome do jogador 2: ");
            players[1,0] = Console.ReadLine();

            if(players[0,0] == "")
            {
                players[0,0] = "Jogador 1";
            }

            if (players[1,0] == "")
            {
                players[1,0] = "Jogador 2";
            }

            if(tmp.Next(6)%2 == 0)
            {
                players[0, 1] = "X";
                players[1, 1] = "O";
                Console.WriteLine($"{players[0, 0]} será o primeiro a jogar");
                return 0;
            }
            else
            {
                players[0, 1] = "O";
                players[1, 1] = "X";
                Console.WriteLine($"{players[1, 0]} será o primeiro a jogar");
                return 1;
            }
            
        }
        static void RenderScreen(string[,] board)
        {
            //Terá a responsabilidade de renderizar o estado do jogo para o usuario
            Console.Clear();
            Console.WriteLine("\t[0]\t[1]\t[2]");
            for (int l = 0; l < board.GetLength(0); l++)
            {
                Console.Write($"[{l}]");
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Console.Write("\t" + board[l, c]);
                }
                Console.WriteLine();
            }
        }

        static void AwaitPlayerInput(string[,] board, string[,]players ,int playing)
        {
            //Terá a responsabilidade de aguardar e validar o input do usuario
            int[] jogada = new int[2] { -1, -1 };
            string x, y;
            Console.WriteLine($"vez de {players[playing,0]} jogar ----> {players[playing, 1]}");
            Console.Write("Informe a linha (0 ~ 2): ");
            x = Console.ReadLine();
            Console.Write("Informe a coluna (0 ~ 2): ");
            y = Console.ReadLine();

            if (int.TryParse(x, out jogada[0]) && int.TryParse(y, out jogada[1]))
            {
                if (jogada[0] < 0 || jogada[0] > 2 || jogada[1] < 0 || jogada[1] > 2)
                {
                    RenderScreen(board);
                    Console.WriteLine("\nNão existe essa posição\n");
                    AwaitPlayerInput(board, players, playing);
                }
                else if (board[jogada[0], jogada[1]] != "_")
                {
                    RenderScreen(board);
                    Console.WriteLine("\nVocê não pode jogar nesta posição\n");
                    AwaitPlayerInput(board, players, playing);
                } else
                {
                    board[jogada[0], jogada[1]] = players[playing, 1];
                }
            }
            else 
            {
                RenderScreen(board);
                Console.WriteLine("\nVocê precisa jogar uma posição válida!\n");
                AwaitPlayerInput(board, players, playing); 
            }
            
        }

        static int Validate(string[,] board, string[,] players, int playing, int round)
        {
            //Terá a responsabilidade de validar o estado do jogo
            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) && board[0, 0] != "_")
            {
                Console.WriteLine($"\nO jogador {players[playing, 0]} ganhou!\n");
                Console.WriteLine($"Aperte qualquer tecla para jogar novamente!\n");
                Console.ReadKey();
                return playing;
            }

            if ((board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) && board[0, 2] != "_")
            {
                Console.WriteLine($"\nO jogador {players[playing,0]} ganhou!\n");
                Console.WriteLine($"Aperte qualquer tecla para jogar novamente!\n");
                Console.ReadKey();
                return playing;
            }

            for (int l = 0; l < board.GetLength(0); l++)
            {
                if ((board[l, 0] == board[l, 1] && board[l, 0] == board[l, 2]) && board[l, 0] != "_")
                {
                    Console.WriteLine($"\nO jogador {players[playing, 0]} ganhou!\n");
                    Console.WriteLine($"Aperte qualquer tecla para jogar novamente!\n");
                    Console.ReadKey();
                    return playing;
                }
            }

            for (int c = 0; c < board.GetLength(0); c++)
            {
                if ((board[0, c] == board[1, c] && board[0, c] == board[2, c]) && board[0, c] != "_")
                {
                    Console.WriteLine($"\nO jogador {players[playing, 0]} ganhou!\n");
                    Console.WriteLine($"Aperte qualquer tecla para jogar novamente!\n");
                    Console.ReadKey();
                    return playing;
                }
            }

            if (round == 9)
            {
                Console.WriteLine($"\nO jogo empatou!\n");
                Console.WriteLine($"Aperte qualquer tecla para jogar novamente!\n");
                Console.ReadKey();
                return playing;
            }

            return 3;
        }

        static int ChangePlayer(int playing) 
        {
            if (playing == 0)
                return 1;
            else
                return 0;
        }


    }
}
