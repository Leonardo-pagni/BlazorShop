<h1>📚 Projeto Blazor WebAssembly + .NET Core API</h1>

  <p>Projeto desenvolvido com foco em <strong>aprendizado</strong> e aplicação prática de tecnologias modernas do ecossistema .NET, seguindo os princípios de <strong>arquitetura limpa e modular</strong>.</p>

  <h2>🧱 Estrutura da Solução</h2>

  <p>A solução é composta por múltiplos projetos, cada um com responsabilidade clara:</p>

  <h3>🔹 Web (Blazor WebAssembly)</h3>
  <ul>
    <li>Interface do usuário moderna e responsiva</li>
    <li>Desenvolvida com <strong>C#</strong> e <strong>Blazor WebAssembly</strong></li>
    <li>Executada diretamente no navegador (SPA - Single Page Application)</li>
    <li>Comunicação com o backend via chamadas HTTP à API</li>
  </ul>

  <h3>🔹 API (.NET Core Web API)</h3>
  <ul>
    <li>Responsável pela lógica de backend e persistência de dados</li>
    <li>Exposição de serviços RESTful</li>
    <li>Implementada em <strong>.NET Core</strong></li>
  </ul>

  <h3>🔹 Class Library</h3>
  <ul>
    <li>Camada de <strong>domínio</strong> e <strong>regras de negócio</strong></li>
    <li>Compartilhada entre os projetos</li>
    <li>Facilita reutilização de código e separação de responsabilidades</li>
  </ul>

  <h2>🧰 Tecnologias Utilizadas</h2>
  <ul>
    <li><a href="https://dotnet.microsoft.com/">.NET 6/7 ou superior</a></li>
    <li><a href="https://learn.microsoft.com/aspnet/core/blazor/">Blazor WebAssembly</a></li>
    <li><a href="https://learn.microsoft.com/aspnet/core/web-api/">ASP.NET Core Web API</a></li>
    <li><a href="https://learn.microsoft.com/ef/core/">Entity Framework Core</a></li>
    <li><a href="https://www.microsoft.com/sql-server">SQL Server</a></li>
    <li>Arquitetura limpa com separação entre Camadas (Apresentação, Aplicação, Domínio, Infraestrutura)</li>
  </ul>

  <h2>🎯 Objetivos do Projeto</h2>
  <ul>
    <li>Explorar o desenvolvimento de aplicações modernas com .NET</li>
    <li>Aplicar conceitos de arquitetura limpa e boas práticas</li>
    <li>Consolidar o uso do Blazor WebAssembly como alternativa moderna ao JavaScript no frontend</li>
    <li>Integrar frontend e backend via Web API</li>
  </ul>

  <h2>🚀 Como Executar</h2>
  <ol>
    <li>Clone este repositório:
      <pre><code>git clone https://github.com/seu-usuario/seu-repositorio.git</code></pre>
    </li>
    <li>Abra a solução no Visual Studio ou VS Code</li>
    <li>Configure a string de conexão no projeto API (<code>appsettings.json</code>)</li>
    <li>Execute a <strong>API</strong> primeiro</li>
    <li>Execute o projeto <strong>Blazor WebAssembly</strong></li>
    <li>Acesse a aplicação no navegador (geralmente <code>https://localhost:port</code>)</li>
  </ol>

  <h2>📦 Possibilidades Futuras</h2>
  <ul>
    <li>Autenticação com JWT e Identity</li>
    <li>Injeção de dependência avançada com MediatR</li>
    <li>Testes automatizados com xUnit</li>
    <li>Deploy em Azure ou Docker</li>
  </ul>
