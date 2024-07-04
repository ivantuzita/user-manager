# UserManager

# Como rodar:

### 1. Base de dados

#### Adicionando usuários padrão e ligando o banco de dados SQL Express LocalDB:

- Como projeto de inicialização, selecione 'UserManager.API'.
- Na barra de menu, clique em 'Ferramentas' -> 'Gerenciador de Pacotes do NuGet' -> 'Console do Gerenciador de Pacotes'.
- No console, existe um dropdown para escolha de 'Projeto padrão'. Nesse dropdown, escolha UserManager.Identity.
- Escreva no console o seguinte comando: `add-migration initialMigration`.
- Após sucesso, escreva no console o seguinte comando: `update-database`. Após sucesso, a base de dados contém as tabelas e os usuários padrão do projeto.
- O usuário admin que tem acesso ao dashboard de usuários é `admin@duett.com` e sua senha é `P@ssword1`.

### 2. Executar aplicação:

- Para executar a aplicação, basta clicar com o botão direito na solução,
- Clicar em 'Configurar projetos de inicialização...',
- Clicar no radio button 'Vários projetos de inicialização',
- E setar para iniciar os projetos 'UserManager.API' e 'UserManager.BlazorUI'.
- Após isso, só iniciar os projetos. O swagger da API irá abrir automaticamente. Alternativamente, seu JSON está no arquivo 'swagger.json'.
