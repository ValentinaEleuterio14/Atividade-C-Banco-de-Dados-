# Atividade-C-Banco-de-Dados-
1. Como C# realiza uma conexão com um banco de dados?
R: O C# realiza a conexão através de strings de conexão e classes provedoras especificas para acesso de dados. 

2. Qual biblioteca/driver é utilizado pelo banco escolhido?
R: Nosso banco escolhido foi o MySQL, e as bibliotecas mais comuns são o 'MySql.Data' e 'MySqlConnector'.

3. Como essa biblioteca é adicionada ao projeto?
R: Utilizamos o NuGet, que é o gerenciador de pacotes do .NET, e executamos o seguinte comando no terminal do VS CODE: 'dotnet add package MySqlConnector'

4. O que é uma string de conexão?
R: É um texto que contém as informações necessárias para localizar e acessar o banco.

5. Quais informações normalmente aparecem em uma string de conexão?
R: Servidor, Nome do banco de dados, usuário e senha.

6. Pesquise como executar comandos SQL utilizando C#.
R: Para conseguir executar os comandos precisamos utilixar a classe 'MysqlCommand', parâmetros para evitar ataques de SQL Injection e using para fechar as conexões automaticamente.

7. Explique como realizar:

a. INSERT:
R: Usamos o método 'ExecuteNonQuery()'

b. SELECT:
R: Usamos o método 'ExecuteReader()'

c. UPDATE:
R: Também usamos o método 'ExecuteNonQuery()'

d. DELETE:
R: Também usamos o método 'ExecuteNonQuery()'

8. Como o C# recebe os dados retornados por um SELECT?
R: Recebe um objeto 'MySqlDataReader'.

9. Como percorrer os resultados de uma consulta?
R: O objeto recebido pelo 'MySqlDataReader' funciona como um cursor que lê os registros linha por linha através do método '.Read()'

10. Como transformar os dados retornados pelo banco em objetos de uma classe?
R: Você deve instanciar a sua classe dentro do laço while 'leitor.Read()' e preencher as propriedades dela com os dados lidos do 'MySqlDataReader'.

11. O que são parâmetros em comandos SQL e por que eles são importantes?
R: Os parâmetros são marcadores de posições, representados pelo símbolo (@), utilizados para separar a estrutura de consulta SQL.

12. Explique o que pode acontecer quando um sistema monta comandos SQL diretamente utilizando textos digitados pelo usuário.
R: Se usarmos os textos digitados pelos usuários estamos abrindo uma brecha de segurança no nosso sistema. Podemos ter ataques onde o banco não consiga istinguir o que é a estrutura do código e o que não é, podemos sofrer roubo, alteração de dados e também bugs.