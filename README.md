# biblioteca

## Grupo composto por Gustavo Freitas e Deivid Ferreira.
Link para video no youtube [aqui](https://www.youtube.com/watch?v=r4wlKn_a95Y)
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

### Dia 13/12/2021
Implementado as funcionalidades do menu de realizar o cadastro de um novo colaborador, a edição de um colaborador e também o cadastro do cliente, sendo que possui diversas validações que
estão sendo realizadas para não permitir dados iguais, ou então para permitir uma edição que não deveria acontecer.

#### Validações em cadastro de funcionário
* Verifica se o usuário logado possui permissão de ADM. Caso tenha, permite que ele realize o cadastro de novos ADMs ou colaboradores normais. Caso não, irá permitir apenas realizar o cadastro de funcionários normais, sem a permissão de ADM;
* Verifica se existe CPF ou EMAIL já cadastrado nos arquivos. Caso possua, não irá permitir este cadastro.

#### Validações em edição de funcionário
* Verifica se existe o CPF do funcionário que está tentando editar nos cadastros. Caso tenha, permite continuar a edição, se não, é finalizado;
* Verifica se o usuário que está tentando editar, é o mesmo que está logado. Caso seja, irá finalizar a operação, pois o usuário não pode editar o próprio cadastro;
* Precisa validar a senha que está cadastrada no sistema, para poder editar a senha e cadastrar uma nova. Caso erre a senha que está cadastrado no sistema, a operação é finalizada;
* A opção de TIPO DE USUÁRIO para editar, só aparece quando o usuario logado é Administrador. Caso seja um colaborador normal, essa opção não aparece, pois funcionários normais não podem atribuir ADM para outras pessoas.

#### Validação em cadastro de cliente
* Apenas valida se o CPF é único entre os cadastros do sistema. Essa é a única regra que o cadastro de cliente possuí.

### Dia 15/12/2021
Finalizado o projeto. Empréstimo funcional e devolução também está funcional.