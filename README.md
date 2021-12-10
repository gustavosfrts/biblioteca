# biblioteca

## Grupo composto por Gustavo Freitas e Deivid Ferreira.
Link para video no youtube [aqui](#)
### Dia 25/11/2021
Foi criado as classes que irão serão compostas pelo o sistema (até o momento).  
Classe de **livro**, que irá ter as informações básicas do livro como nome do livro, nome do autor, quantidade disponível 
e por enquanto apenas.  
Classe de **pessoa**, que terá dados comuns a todas pessoas do sistema, como nome e CPF.  
Classe de **cliente**, que terá as informações de endereço e telefone de contato por enquanto.  
Classe de **funcionario**, que terá as informações do email (para poder fazer o login), senha, e o tipo de usuario, se é funcionario ou adm do sistema.  
E por último (até o momento), a classe de **empréstimo**, que terá as informações pertinentes no momento que o empréstimo foi realizado.


### Dia 02/12/2021
Foi implementado os getters e setters de todas as classes (cliente, emprestimo, funcionario, livro, pessoa), implementado o cadastro de um novo funcionário no sistema, e salvar suas informações no arquivo, e também a autenticação, ou seja, o login no sistema, onde apenas funcionários (seja gerente ou colaborador) terão acesso ao sistema para poder acessar suas funcionalidades.

### Dia 09/12/2021
Implementado menu com algumas opções, ainda não funcionais. Cadastro/edição de livro, Cadastro/edição de colaborador(ou administrador, porém apenas administradores tem a permissão de cadastrar novos administradores),
Cadastro de novos clientes, Realizar empréstimo e visualizar empréstimos ativos.
Algumas regras que serão implementadas.
* Para cadastrar novo colaborador ou adm, a pessoa logada deve ter a permissão de administrador. Apenas administradores podem realizar cadastro de outros colaboradores (seja ele ADM mesmo, ou
um funcionário regular);
* Cadastro de novo cliente pode ser feito tanto por adm ou por funcionário regular, ou seja, precisa apenas de estar logado;
* Cadastro/edição de novo livro pode ser feito tanto por adm ou por funcionário regular, ou seja, precisa apenas de estar logado;
* Realizar ou visualizar empréstimos pode ser realizado por adm ou funcionário regular;
* Ao visualizar os empréstimos ativos, terá a opção de se finalizar algum destes empréstimos (pelo código deste empréstimo). Caso tenha dias em atraso, será informado na tela
quanto deve ser pago pelo atraso (levando em conta que cada dia de atraso aumenta 10 reais);
* Ao realizar o empréstimo, deve-se adicionar 10 dias corridos após a data atual para levar como a data de vencimento;

Foi deixado hoje funcional as opções no menu de CADASTRO e EDIÇÃO de livros.