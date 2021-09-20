using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            //minhaConta.Nome = "Nicole"; => Nome é um atributo privado. P/ alterar é preciso de um método => Encapsulamento

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Insira um comando válido!");
                        break;

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Contas:");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta");
            try
            {
                Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
                int entradaTipoConta = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o nome do(a) Cliente");
                string entradaNome = Console.ReadLine();

                Console.WriteLine("Digite o saldo inicial");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite o crédito inicial");
                double entradaCredito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                        saldo: entradaSaldo,
                                                        credito: entradaCredito,
                                                        nome: entradaNome);
                listaContas.Add(novaConta);
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        private static void Transferir()
        {
            ListarContas();

            Console.WriteLine("Escolha conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha conta de destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Conta contaDestino = listaContas[indiceDestino];

            Console.WriteLine("Insira o valor da transferência: ");
            double valorTransf = double.Parse(Console.ReadLine());

            listaContas[contaOrigem].Transferir(valorTransf, contaDestino);
            Console.WriteLine($"Transferência de {listaContas[contaOrigem]} para {listaContas[indiceDestino]}");
            Console.WriteLine("Valor: {0}", valorTransf);

        }

        private static void Sacar()
        {
            ListarContas();

            Console.WriteLine("Escolha a conta para o saque: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor do saque: ");
            double saque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(saque);
        }
        private static void Depositar()
        {
            ListarContas();

            Console.WriteLine("Escolha a conta para o saque: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor do deposito: ");
            double deposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(deposito);
        }
        // Método para criar um menu
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Listar contas.");
            Console.WriteLine("2- Inserir nova conta.");
            Console.WriteLine("3- Transferir.");
            Console.WriteLine("4- Sacar.");
            Console.WriteLine("5- Depositar.");
            Console.WriteLine("6- Limpar tela.");
            Console.WriteLine("X- Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
