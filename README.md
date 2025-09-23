# 🐞 ProjetoTesteMantis

Projeto de automação de testes desenvolvido em C# com Selenium WebDriver e NUnit, voltado para validações na aplicação Mantis Bug Tracker.

O objetivo é demonstrar boas práticas em automação de testes aplicadas a um projeto real, incluindo:

Organização modular do código

Separação de responsabilidades

Parametrização de dados de execução no appsettings.json

Estrutura de testes de interface (UI) com relatórios automatizados

🚀 Tecnologias utilizadas

C# .NET – Linguagem principal do projeto

NUnit – Framework de testes unitários e automatizados

Selenium WebDriver – Automação de aplicações Web

ExtentReports – Geração de relatórios de execução dos testes

WebDriverManager – Gerenciamento automático de drivers do navegador

⚙️ Arquitetura do Projeto
📌 appsettings.json

Arquivo de configuração centralizado, utilizado para armazenar:

URL da aplicação

Parâmetros gerais de execução

Isso permite maior flexibilidade e manutenção, já que qualquer alteração é feita sem precisar modificar diretamente o código.

📂 Bases

Contém classes fundamentais e reutilizáveis para toda a automação.

Browsers.cs → Gerencia os navegadores suportados nos testes.

BuilderJson.cs → Responsável por carregar e mapear configurações do appsettings.json.

DriverFactory.cs → Cria e controla instâncias do WebDriver.

ExtentManager.cs → Configuração e geração de relatórios via ExtentReports.

PageBase.cs → Classe base para as páginas, contendo métodos genéricos de interação.

TestBase.cs → Classe base para os testes, garantindo inicialização e finalização corretas.

WebDriverExtensions.cs → Métodos de extensão úteis para manipulação do WebDriver.

📂 Documents

Pasta dedicada a manter artefatos gerados pelos testes, como relatórios de execução e prints.

📂 Page

Contém as classes de Page Object Model (POM) que mapeiam e organizam os elementos e ações da aplicação.

📂 Teste

Inclui os cenários de teste automatizados, organizados por funcionalidade.
Exemplo:

ChallengingTeste.cs

CriarTarefaTest.cs

TesteAcesso.cs

📊 Fluxo de Execução

O NUnit executa os testes da pasta Teste

Cada teste utiliza o Page Object Model para interagir com a aplicação

As configurações são carregadas via appsettings.json

O ExtentReports gera relatórios detalhados de execução

🧪 Exemplo de Uso
var page = new CriarTarefaPage();
page.CriarTarefa();

🎯 Objetivo

Este repositório foi criado para demonstrar minhas habilidades como Analista de Testes de Software, com foco em:

Automação de testes Web

Estrutura de testes escalável e organizada

Boas práticas em QA e automação de testes

Relatórios automatizados e de fácil interpretação
