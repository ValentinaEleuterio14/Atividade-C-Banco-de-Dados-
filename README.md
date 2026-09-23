# Atividade-C-Banco-de-Dados-

Nome do projeto: 
Sistema de Biblioteca

Integrantes: 
Lívia Tanese, Mª Fernanda Vargas & Valentina Eleuterio.

Banco de dados utilizado: 
MySQL

Biblioteca/driver utilizado:
MySqlConnector

Como instalar as dependências:
Abra o terminal com um 'ctrl + j', use o comando 'dotnet add package MySqlConnector' para instalar a biblioteca, e depois pode execultar a conexão.


Como configurar o banco:
Primeiro entre no servidor no MySql Workbench, depois é necessário executar o código SQL do arquivo 'bancoDados.sql' para criar o banco e a tabela. Depois, no terminal do arquivo 'Program.cs', execute o código e teste a conexão.

Como executar o projeto:
Primeiro verifique se o banco de dados está funionando e com a database criada. Se tudo estiver nos conformes, é só ir no arquivo 'Program.cs', abrir o terminal com um 'ctrl + j' e execultar o código com 'dotnet run'.


Breve explicação de como funciona a conexão:
O sistema utiliza o método 'Conectar()' para criar uma conexão com o banco de dados. Ele utiliza as informações do servidor, banco, usuário e senha para tentar estabelecer a conexão. Se a conexão for realizada com sucesso, aparece uma mensagem informando que ela foi realizada; caso aconteça algum erro, o sistema mostra a mensagem do erro.