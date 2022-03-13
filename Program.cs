using System;
using System.Collections.Generic;
using System.IO;

namespace POC_RepositorioLocal
{
    /// <summary>
    /// Prova prática de um <c>conceito<c> teórico.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CriarArquivo(@"C:\CriarDiretorio","Testar", 
                new List<string>(){
                    "Lorem Ipsum",
                    "Ave Maria",
                    "Crein Deus Pai!",
                    "Chumbo pesado",
                    "Coendro de cevácia!",
                });

        }
        
        /// <summary>
        /// Listar todos arquivos de uma com base no tipo do arquivo.
        /// </summary>
        /// <param name="path">Caminho do diretório.</param>
        /// <param name="searchPattern">Tipo do arquivo para busca.</param>
        public static void ListarAquivosComFiltro(string path, string searchPattern)
        {
            // O SearchOption.AllDirectories inclue também todos subdiretórios para uma busca completa.
            string[] arquivos = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);

            Console.WriteLine("Arquivos:");
            foreach (string arq in arquivos)
            {
                Console.WriteLine(arq);
            }
        }

        /// <summary>
        /// Listar todos os arquivos e diretórios existentes.
        /// </summary>
        /// <param name="path">Caminho do diretório.</param>
        static void ListarTodasPastasArquivos(string path)
        {
            string[] diretorios = Directory.GetDirectories(path);
            string[] arquivos = Directory.GetFiles(path);
    
            Console.WriteLine("Diretórios:");
            foreach (string dir in diretorios)
            {
                Console.WriteLine(dir);
            }
    
            Console.WriteLine("Arquivos:");
            foreach (string arq in arquivos)
            {
                Console.WriteLine(arq);
            }
        }
        
        /// <summary>
        /// Criar diretório.
        /// </summary>
        /// <param name="path">Caminho do diretório.</param>
        static void CriarDiretorio(string path)
        {   
            var diretorio = new DirectoryInfo(path);

            // Caso o diretório não exista ele será criado.
            if(!Directory.Exists(path))
                diretorio = Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Criar arquivo.
        /// </summary>
        /// <param name="path">Caminho do arquivo.</param>
        /// <param name="nomeArquivo">Nome do arquivo.</param>
        /// <param name="conteudo">Conteúdo do arquivo criado.</param>
        public static void CriarArquivo(string path, string nomeArquivo, List<string> conteudo)
        {
            Console.WriteLine("Criando diretório!");
            CriarDiretorio(path);
            Console.WriteLine("Diretório criado!");
            
            string arquivo = Path.Combine(path, nomeArquivo);

            Console.WriteLine("Criando arquivo!");
            if (!File.Exists(nomeArquivo)) 
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(arquivo)) 
                    foreach (var item in conteudo)
                        sw.WriteLine(item);
            }

            Console.WriteLine("Arquivo criado com sucesso!");
        }
    }
}
