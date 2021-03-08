using DIO.Bank.Models;
using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            char op = PrintMenu();
            while (op != 'X')
            {
                switch (op)
                {
                    case '1':
                        ListarContas();
                        break;
                    case '2':
                        InserirContas();
                        break;
                    case '3':
                        Transferir();
                        break;
                    case '4':
                        Sacar();
                        break;
                    case '5':
                        Depositar();
                        break;
                    default:
                        break;
                }
                op = PrintMenu();
            }
            ClearScreen();
            Console.WriteLine("\n\n\n\n");
            TextCenter("OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS");
            Console.WriteLine("\n\n");
            TextCenter("Estaremos aguardando seu retorno");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            ClearScreen();
            TextCenter("DIO Bank a seu dispor!!!\n\n");
            TextCenter("DEPOSITANDO VALOR\n\n");
            TextCenter("Digite o Número da Conta..: ", 40);
            int.TryParse(Console.ReadLine(), out int numero);
            TextCenter("Digite o Valor a Depositar: ", 40);
            double.TryParse(Console.ReadLine(), out double valor);
            listContas[numero - 1].Depositar(valor);
            Console.ReadLine();
        }

        private static void Sacar()
        {
            ClearScreen();
            TextCenter("DIO Bank a seu dispor!!!\n\n");
            TextCenter("SACANDO VALOR\n\n");
            TextCenter("Digite o Número da Conta: ", 40);
            int.TryParse(Console.ReadLine(), out int numero);
            TextCenter("Digite o Valor a Sacar..: ", 40);
            double.TryParse(Console.ReadLine(), out double valor);
            listContas[numero - 1].Sacar(valor);
            Console.ReadLine();
        }

        private static void Transferir()
        {
            ClearScreen();
            TextCenter("DIO Bank a seu dispor!!!\n\n");
            TextCenter("TRANSFERÊNCIA ENTRE CONTAS\n\n");
            TextCenter("Digite o Número da Conta de Origem.: ", 50);
            int.TryParse(Console.ReadLine(), out int origem);
            TextCenter("Digite o Número da Conta de Destino: ", 50);
            int.TryParse(Console.ReadLine(), out int destino);
            TextCenter("Digite o Valor a Transferir........: ", 50);
            double.TryParse(Console.ReadLine(), out double valor);
            listContas[origem - 1].Transferir(valor, listContas[destino - 1]);
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            ClearScreen();
            TextCenter("DIO Bank a seu dispor!!!\n\n");
            TextCenter("LISTANDO CONTAS CADASTRADAS\n\n");
            if (listContas.Count == 0)
            {
                TextCenter("NENHUMA CONTA CADASTRADA");
            }
            int i = 1;
            foreach (var item in listContas)
            {
                Console.WriteLine($"\t#{i} - {item.ToString()}");
                i += 1;
            }
            Console.ReadLine();
        }

        private static void InserirContas()
        {
            ClearScreen();
            TextCenter("DIO Bank a seu dispor!!!\n\n");
            TextCenter("INSERINDO NOVA CONTA\n\n");
            TextCenter("Digite 1 para Conta Física ou 2 para Jurídica: ", 60);
            int.TryParse(Console.ReadLine(), out int tipoConta);
            TextCenter("Digite o Nome do Cliente: ", 60);
            string nome = Console.ReadLine();
            TextCenter("Digite o Saldo Inicial: ", 60);
            double.TryParse(Console.ReadLine(), out double saldo);
            TextCenter("Digite o Crédito: ", 60);
            double.TryParse(Console.ReadLine(), out double credito);
            Conta conta = new Conta((TipoConta)tipoConta, saldo, credito, nome);
            listContas.Add(conta);
        }

        private static char PrintMenu()
        {
            ClearScreen();
            TextCenter("DIO Bank a seu dispor!!!\n\n");
            TextCenter("1 - Lista Contas\n", 40);
            TextCenter("2 - Inserir Nova Conta\n", 40);
            TextCenter("3 - Transferir\n", 40);
            TextCenter("4 - Sacar\n", 40);
            TextCenter("5 - Depositar\n", 40);
            TextCenter("X - Sair\n\n", 40);
            TextCenter("Informe a opção desejada: ", 40);
            return Console.ReadLine().ToUpper()[0];
        }

        private static void TextCenter(string texto)
        {
            int x = (Console.WindowWidth - texto.Length) / 2;
            for (int i = 0; i < x; i++)
                Console.Write(" ");
            Console.Write(texto);
        }

        private static void TextCenter(string texto, int tamanho)
        {
            int x = (Console.WindowWidth - tamanho) / 2;
            for (int i = 0; i < x; i++)
                Console.Write(" ");
            Console.Write(texto);
        }

        private static void ClearScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
        }

    }
}
