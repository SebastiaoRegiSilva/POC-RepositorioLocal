using System;
using System.IO;

namespace POC_RepositorioLocal
{
    /// <summary>
    /// Prova prática de um conceito teórico.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        /// <summary>
        /// Listar todos arquivos de uma com base no tipo do arquivo.
        /// </summary>
        /// <param name="path">Caminho do diretório.</param>
        /// <param name="searchPattern">Tipo do arquivo para busca.</param>
        public void ListarAquivosComFiltro(string path, string searchPattern)
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
        private void ListarTodasPastasArquivos(string path)
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
        private void CriarDiretorio(string path)
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
        public string CriarArquivo(string path, string nomeArquivo)
        {   
            var arquivo = new FileInfo(nomeArquivo);
            
            // Caso o arquivo não exista ele será criado.
            if(!File.Exists(nomeArquivo))
                File.Create(path, 150, FileOptions.WriteThrough);

                return "Arquivo criado com sucesso!";
        }
    }
}
