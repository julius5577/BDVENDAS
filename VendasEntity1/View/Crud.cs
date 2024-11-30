using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasEntity1.Controller;
using VendasEntity1.Model;

namespace VendasEntity1.View
{
    internal class Crud
    {
        static void Main(string[] args)
        {


            string op;

            do
            {
                Console.WriteLine("Seja Bem Vindos \n");
                Console.WriteLine("Escolha uma Opção \n");
                Console.WriteLine("1.Incluir Produto");
                Console.WriteLine("2.Alterar Produto");
                Console.WriteLine("3.Deletar Produto");
                Console.WriteLine("4.Select (selecionar a tabela)");

                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)


                {

                    case 1:
                        incluir();
                        break;


                    case 2:
                        alterar();
                        break;


                    case 3:
                        deletar();
                        break;

                    case 4:
                        select();
                        break;

                    default:
                        Console.WriteLine("Operação inválida.");

                        break;
                }

                Console.WriteLine("Deseja continuar \n");
                op = Console.ReadLine().ToLower();

            } while (op == "s");




        }

        private static void select()
        {
             using (var contexto = new DBVendas())
            {
                // Exemplo de consulta simples para selecionar todos os usuários da agenda
                var cadastros = contexto.vendas.ToList();

                foreach (var listacadastro in cadastros)
                {
                    Console.WriteLine($"ID: {listacadastro.Id}, Produto: {listacadastro.Produto}," +
                        $" Descrição: {listacadastro.Descricao}, DataVenda: {listacadastro.DataVenda}, Valor: {listacadastro.Valor}");
                }
            }
            Console.ReadKey();
        }

        private static void deletar()
        {
            using (var contexto = new DBVendas())
            {
                Console.WriteLine("Digite ID que deseja apagar: ");
                var busca = contexto.vendas.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Voçê esta prestes a apagar o usuario:  {busca.Produto}");
                Console.WriteLine("Tem certeza que deseja apagar, digite S para apagar ou qualquer tecla para anular ");
                var apaga = Console.ReadLine();

                if (apaga == "S")

                {

                    contexto.vendas.Remove(busca);
                    contexto.SaveChanges();
                    Console.WriteLine("Usuario excluido com sucesso");
                }

                else
                {
                    Console.WriteLine("Operação anulada");


                }

            }
        }

        private static void alterar()
        {
            using (var contexto = new DBVendas())
            {

                Console.WriteLine("Digite o ID que deseja alterar: ");
                var busca = contexto.vendas.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine(busca.Produto);
                Console.WriteLine(busca.Descricao);
                Console.WriteLine("Entre com a corrreção do nome: ");
                busca.Produto = Console.ReadLine();
               

                contexto.SaveChanges();
                Console.WriteLine("Usuario alterado com sucesso!!");




            }
        }

        public static void incluir()
        {
            string vProduto, vDescricao;
            DateTime vdata;
            decimal vValor;
            Console.WriteLine(" digite o produto");
            vProduto = Console.ReadLine();
            Console.WriteLine("descrição do produto");
            vDescricao = Console.ReadLine();
            Console.WriteLine("data da venda");
            vdata = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("valor");
            vValor = decimal.Parse(Console.ReadLine());

            using (var contexto = new DBVendas())

            {
                contexto.vendas.Add(new Vendas()
                {

                    Produto = vProduto,
                    Descricao = vDescricao,
                    DataVenda = vdata,
                    Valor = vValor



                });
                contexto.SaveChanges();
            }
                 
            
               Console.ReadKey();   
               
               
        }
    }
}