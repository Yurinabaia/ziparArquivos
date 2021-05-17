<p align="center"><img src="download.png" width="400"></a></p>


## Sobre Projeto

Projeto destinado a zipar arquivos de maneira automatica, usando a biblioteca Ionic.Zip;

dot.net versão: 2.1.300

Ionic.zip versão: 1.9.1.8

System.Text.Json versão: 5.0.2

System.Configuration.ConfigurationManager versão: 5.0.0



### Para usar é preciso baixar o SDK 2.1. 

https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-2.1.524-windows-x64-installer


### Video explicativo do script.

https://www.youtube.com/watch?v=K9FOR0dnUyw

### Codigo

~~~c#

 List<string> nomesArquivosDiretorio = new List<string>();//Lista que vai receber os nomes do diretorio e todos os arquivos


string nomeLocal = @"//lOCAL DOS REPOSITORIOS";
//Inserir o local do backup.


arquivosIgnorar.Add(@"//LOCAL DOS ARQUIVOS QUE SERÃO IGNORADOS");
//Inserir os arquvos que você não queira zipar.

//exemplo:

arquivosIgnorar.Add(@"C:\Users\yuri.duarte\Documents\Angular");

//Tem que especificar todo o caminho.


~~~