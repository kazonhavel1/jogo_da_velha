using System;

class Program {
    public static void Main (string[] args) {
        string[,] jogo = new string[3, 3]
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };

        int linhas = jogo.GetLength(0);
        int colunas = jogo.GetLength(1);

        bool jogadorX = true;

        for (int l = 0; l < linhas; l++) {
            for (int c = 0; c < colunas; c++) {
                Console.Write(jogo[l, c] + " ");
            }
            Console.WriteLine();
        }

        while (true) {
            string jogadorAtual = jogadorX ? "X" : "Y";

            Console.Write("(Vez do " + jogadorAtual + ") Selecione de 1 a 9 o local que deseja Marcar ou 0 para SAIR: ");

            int escolha;
            escolha = Int32.Parse(Console.ReadLine());

            if (escolha == 0) {
                Console.WriteLine("Obrigado por jogar!");
                break;
            }
            else if (escolha > 9 || escolha < 1) {
                Console.WriteLine("Favor inserir um número de 1 a 9!");
            }
            else {

                int linha = (escolha - 1) / 3;
                int coluna = (escolha - 1) % 3;
                if (jogo[linha, coluna] != "X" && jogo[linha, coluna] != "O") {
                    jogo[linha, coluna] = jogadorAtual;
                    jogadorX = !jogadorX;

                    bool vitoria = VerificarVitoria(jogo, jogadorAtual);
                    if (vitoria) {
                        Console.WriteLine("O jogador " + jogadorAtual + " venceu!");
                        break;
                    }
                    else if (VerificarEmpate(jogo)) {
                        Console.WriteLine("O jogo terminou em empate!");
                        break;
                    }
                }
                else {
                    Console.WriteLine("Essa posição já está marcada!");
                }
            }

            for (int l = 0; l < linhas; l++) {
                for (int c = 0; c < colunas; c++) {
                    Console.Write(jogo[l, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public static bool VerificarVitoria(string[,] jogo, string jogador) {
       
        for (int i = 0; i < 3; i++) {
            if (jogo[i, 0] == jogador && jogo[i, 1] == jogador && jogo[i, 2] == jogador) {
                return true;
            }
        }

       
        for (int i = 0; i < 3; i++) {
            if (jogo[0, i] == jogador && jogo[1, i] == jogador && jogo[2, i] == jogador) {
                return true;
            }
        }

       
        if (jogo[0, 0] == jogador && jogo[1, 1] == jogador && jogo[2, 2] == jogador) {
            return true;
        }

        if (jogo[0, 2] == jogador && jogo[1, 1] == jogador && jogo[2, 0] == jogador) {
            return true;
        }

        return false;
    }

    public static bool VerificarEmpate(string[,] jogo) {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (jogo[i, j] != "X" && jogo[i, j] != "Y") {
                    return false; 
                }
            }
        }
        return true; 
    }
}
