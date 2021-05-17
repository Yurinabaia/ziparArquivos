using Ionic.Zip;
using ShellProgressBar;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			//O exemplo eu zipei treis pastas de locais diferentes, para um arquivo zip.
			//Para zipar mais pasta de caminhos diferentes criar um novo metodo e seguindo o que é exigido.			
            aplicacoes();
            //lib();
            //os();
        }

        public static void aplicacoes()
        {
            List<string> nomesArquivosDiretorio = new List<string>();//Lista que vai receber os nomes do diretorio e todos os arquivos
            string nomeLocal = @"//lOCAL DOS REPOSITORIOS";

            List<string> arquivosIgnorar = new List<string>();
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");

            var nomesDiretorio = Directory.GetDirectories(nomeLocal)
                      .Select(c => new DirectoryInfo(c).ToString())
                      .ToList();

            var nomeArquivos = Directory.GetFiles(nomeLocal)
                    .Select(c => new FileInfo(c).ToString())
                    .ToList();

            nomesDiretorio = nomesDiretorio.Except(arquivosIgnorar).ToList();
            nomeArquivos = nomeArquivos.Except(arquivosIgnorar).ToList();


            nomesDiretorio.ForEach(delegate (string nomaA)
            {
                nomesArquivosDiretorio.Add(nomaA);
            });
            nomeArquivos.ForEach(delegate (string nomeF)
            {
                nomesArquivosDiretorio.Add(nomeF);
            });

            CriarArquivoZip(nomesArquivosDiretorio, @"C:\local onde vai ficar o backup", "Nome do primeiro projeto");//Local onde vai ficar armazenado os backups

        }

        public static void lib()
        {
            List<string> nomesArquivosDiretorio = new List<string>();//Lista que vai receber os nomes do diretorio e todos os arquivos
            string nomeLocal = @"//lOCAL DOS REPOSITORIOS";

            List<string> arquivosIgnorar = new List<string>();
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
            arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");


            var nomesDiretorio = Directory.GetDirectories(nomeLocal)
                      .Select(c => new DirectoryInfo(c).ToString())
                      .ToList();

            var nomeArquivos = Directory.GetFiles(nomeLocal)
                    .Select(c => new FileInfo(c).ToString())
                    .ToList();

            nomesDiretorio = nomesDiretorio.Except(arquivosIgnorar).ToList();
            nomeArquivos = nomeArquivos.Except(arquivosIgnorar).ToList();


            nomesDiretorio.ForEach(delegate (string nomaA)
            {
                nomesArquivosDiretorio.Add(nomaA);
            });
            nomeArquivos.ForEach(delegate (string nomeF)
            {
                nomesArquivosDiretorio.Add(nomeF);
            });

            CriarArquivoZip(nomesArquivosDiretorio, @"C:\local onde vai ficar o backup", "Nome do segundo projeto");//Local onde vai ficar armazenado os backups

        }

        public static void os()
        {
            List<string> nomesArquivosDiretorio = new List<string>();//Lista que vai receber os nomes do diretorio e todos os arquivos
            //string nomeLocal = @"\\netuno\c$\wamp\www";

            string nomeLocal = @"//lOCAL DOS REPOSITORIOS";

            //List<string> arquivosIgnorar = new List<string>();


            //var nomesDiretorio = Directory.GetDirectories(nomeLocal)
            //          .Select(c => new DirectoryInfo(c).ToString())
            //          .ToList();

            //var nomeArquivos = Directory.GetFiles(nomeLocal)
            //        .Select(c => new FileInfo(c).ToString())
            //        .ToList();

            //nomesDiretorio = nomesDiretorio.Except(arquivosIgnorar).ToList();
            //nomeArquivos = nomeArquivos.Except(arquivosIgnorar).ToList();


            //nomesDiretorio.ForEach(delegate (string nomaA)
            //{
            //    nomesArquivosDiretorio.Add(nomaA);
            //});
            //nomeArquivos.ForEach(delegate (string nomeF)
            //{
            //    nomesArquivosDiretorio.Add(nomeF);
            //});

            CriarArquivoZip(nomesArquivosDiretorio, @"C:\local onde vai ficar o backup", "Nome do terceiro projeto");//Local onde vai ficar armazenado os backups

        }

        public static void CriarArquivoZip(List<string> arquivos, string ArquivoDestino, string projeto)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            const int totalTicks = 2;
            var options = new ProgressBarOptions
            {
                ProgressCharacter = '─',
                ProgressBarOnBottom = true
            };
            using (var pbar = new ProgressBar(totalTicks, "progress bar is on the bottom now", options))
            {
                using (ZipFile zip = new ZipFile())
                {
                    pbar.Tick("Step 1 of 2: "+projeto);
                    for (int i = 0; i < arquivos.Count; i++)
                    {

                        // se o arquivos[i] é um arquivo
                        if (File.Exists(arquivos[i]))
                        {
                            try
                            {
                                // Adiciona o arquivo na pasta raiz dentro do arquivo zip
                                zip.AddFile(arquivos[i], "");
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        // se o arquivos[i] é uma pasta
                        else if (Directory.Exists(arquivos[i]))
                        {
                            try
                            {
                                // Adiciona a pasta no arquivo zip com o nome da pasta 
                                zip.AddDirectory(arquivos[i], new DirectoryInfo(arquivos[i]).Name);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                    // Salva o arquivo zip para o destino
                    try
                    {
                        zip.Save(ArquivoDestino);
                        pbar.Tick("Step 2 of 2: "+projeto);
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }
    }
}
