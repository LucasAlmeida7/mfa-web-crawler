
using System.Linq;
using System;
using CrawlerConsultaRAB.Utils;
using CrawlerConsultaRAB.System;

namespace CrawlerConsultaRAB
{
    public class Index
    {
        public static void Main(string[] args)
        {
            try
            {
                Index index = new Index();
            index.Menu();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Menu()
        {
            Consulta();

            Console.WriteLine("Deseja efeuar uma nova consulta? [S/N]");
            Single option = Console.ReadLine().ToUpper();

            switch (option)
            {
                case "S":
                    Console.WriteLine("Sim");
                    Menu();
                    break;

                case "N":
                    Console.WriteLine("Não - FIM");
                    break;
                    
                default:
                    Console.WriteLine("Opção Inválida - FIM");
                    break;
            }
        }

        private void Consulta()
        {
            Navigator navigator = new Navigator();
            
            Console.WriteLine("Digite uma chave: ");
            string chave = Console.ReadLine().ToUpper();

            Console.Clear();
            Console.WriteLine("Efetuando pesquisas...");
            Console.Clear();

            navigator.NavToQueryPage(chave);

            Console.WriteLine("---------------------------------------------");

            foreach (Registro reg in navigator.registros)
            {
                Console.WriteLine(reg.Indice);
                if(indice.Contains("Motivos(s)") && reg.Motivos.Count > 0)
                {
                    foreach (string item in reg.Motivos)
                    {
                        Console.WriteLine(item);        
                    }
                }
                else
                    Console.WriteLine(reg.Texto + Environment.NewLine);
            }

            Console.WriteLine("---------------------------------------------");
            Console.ReadKey();
        }

    }
}