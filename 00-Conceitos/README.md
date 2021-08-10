<p align="center">
  <h1>Conteúdo Teórico - Conceitos</h1>
</p>

<br>

<h2>Sumário</h2>
<details>
  <summary> <b> POO - Conceitos Básicos</b> <i>(click to expand!)</i> </summary>
  
  <br>
  
  # CONCEITOS BÁSICOS - Orientação a Objetos


## **Herança**
“A herança é um princípio próprio à programação orientada a objetos (POO) que permite criar uma nova classe a partir de uma já existente. Herança, também chamada de subclasses, provém da subclasse, da classe recém-criada que contém atributos e métodos da qual deriva. A principal vantagem da herança é a capacidade para definir novos atributos e métodos para a subclasse, que se somam aos atributos e métodos herdados.” (SPADARI, 2020)

Desta forma uma relação de herança é estabelecida quando por exemplo dizemos que uma classe X é do tipo Z e assim a classe Z é mãe de X, fazendo X herdar características de Z.

## **Classes Abstratas**
“Pode-se dizer que as classes abstratas servem como “modelo” para outras classes que dela herdem, não podendo ser instanciada por si só. Para ter um objeto de uma classe abstrata é necessário criar uma classe mais especializada herdando dela e então instanciar essa nova classe. Os métodos da classe abstrata devem então ser sobrescritos nas classes filhas.” (DEVMEDIA, 2021)

Sendo assim as classes abstratas são feitas em especial para serem modelos para suas classes derivadas, e estas por sua vez, sobrescrevem os métodos para realizar a implementação dos mesmos.


## **Interfaces**
“Podemos definir como interface o contrato entre a classe e o mundo exterior. Quando uma classe implementa uma interface, se compromete a fornecer o comportamento publicado por esta interface. As classes ajudam a definir um objeto e seu comportamento e as interfaces que auxiliam na definição dessas classes. As interfaces são formadas pela declaração de um ou mais métodos, os quais obrigatoriamente não possuem corpo.” (DEVMEDIA, 2021)

Neste podemos entender que a herança da interface tende a ser mais bem definida, pois permite que especifiquemos todos os métodos e propriedades que desejamos que as classes que implementam a interface disponibilizem.

## **Enums**
“Uma das boas práticas de programação em C# é o uso do enum. Ele serve para substituirmos constantes nomeadas que são relacionadas mas ficam “perdidas” no código. A palavra-chave enum é usada para declarar uma enumeração, um tipo distinto que consiste em um conjunto de constantes. O Enum é um tipo de valor e não pode herdar ou ser herdado.
Geralmente é melhor definir um enum dentro de um namespace para que todas as classes dele possam acessá-lo. No entanto, um enum também pode ser aninhado em classes ou Structures.” (DEVMEDIA, 2021)
Como o próprio nome já nos diz a raiz da palavra parte de enumerado, são bem estruturados e definidos para serem usados para armazenar dados mais discretos e de um tipo bem específico.



# **REFERÊNCIAS**

SPADARI, Ana. **Programação Orientada à Objetos.** CCM, 2020. Disponível em: <https://br.ccm.net/contents/414-poo-heranca>. Acesso em: 08, Agosto 2021.

**Interfaces - POO.** DEVMEDIA, 2021. Disponível em: <https://www.devmedia.com.br/interfaces-programacao-orientada-a-objetos/18695>. Acesso em: 08, Agosto 2021.


**Trabalhando com Structures e Enum em C#.** DEVMEDIA, 2021. Disponível em: <https://www.devmedia.com.br/trabalhando-com-structures-e-enum-em-csharp/32259>. Acesso em: 08, Agosto 2021.


**Polimorfismo, Classes abstratas e Interfaces: Fundamentos da POO em Java.** DEVMEDIA, 2021. Disponível em: <https://www.devmedia.com.br/polimorfismo-classes-abstratas-e-interfaces-fundamentos-da-poo-em-java/26387>. Acesso em: 08, Agosto 2021.

</details>

<details>
  <summary> </i> <b> API </b> </i>  </summary>
  
  <br>
  
  # CONCEITOS BÁSICOS - API


## **API**

"API é um conjunto de definições e protocolos usado no desenvolvimento e na integração de software de aplicações. API é um acrônimo em inglês que significa interface de programação de aplicações." (REDHAT, 2021)

A intenção de criar uma API é está voltada para utilização da mesma no desenvolvimento de diferentes tipos de softwares de outros devs que queiram associar ao seu serviço. Um grande exemplo é o Google Maps, ele disponibiliza códigos e instrução para serem usados em diversos formatos, visando atender aos usuários que usam o serviço em diferentes tipos de sistemas.

Dessa forma a API liga as diversas funções em um website, por exemplo, de maneira que possam ser utilizadas em outras aplicações.

## **JSON**

"Outro fator comum entre diferentes APIs é a utilização de um formato pré-definido de dados para o compartilhamento de informações entre os sistemas, como o XML ou o YAML. Nas aplicações Web, o mais utilizado é o JSON." (TECNOBLOG, 2021)

JSON é um formato de arquivo de texto leve, compacto, no qual os dados são guardados em formato de pares atributo e valor, sendo o atributo o identificador do valor, e este por sua vez podendo guardar arrays e objetos.

Atualmente é bastante utilizado tanto pela web e quanto mobile que consomem os mesmos dados, mas também podendo ser bastante útil para guardar atributos que auxiliam na configuração de vários tipos de programas.


## **Padrão REST**

"Para as APIs Web, existe um padrão adicional chamado REST. A palavra é um acrônimo para Representational State Transfer, algo como “Trasferência Representacional de Estado”, em português. Outro termo para esse padrão é “API RESTful”." (TECNOBLOG, 2021)

Ou seja, para ser uma API RESTful tem que estar de acordo as restrições que são estabelecidas pela arquitetura REST, permitindo assim que os projetos sejam padronizados e a criados com interfaces bem definidas, facilitando a compreensão de quem for utilizar.


## **HTTP/HTTPS**

"Dentre os requisitos, o mais comum é ter as solicitações gerenciadas pelo protocolo HTTP." (TECNOBLOG, 2021)

O HTTP é um protocolo de comunicação baseado na arquitetura cliente/servidor, a troca de informações funciona através de mensagens enviadas pelo cliente(requests) e retornos pelo servidor através de respostas(responses) onde geralmente contém o status da requisição e algum contéudo.

Quando há a necessidade de proteger essa comunicação é ultizado uma camada a mais, que provém segurança no transporte dessas informações, e essa troca de informações passa a ser HTTPs que passa a usar certificado criptografado (SSL ou TSL), essa criptrografia permite que seja quase impossível alguém de fora saber as informações que são trocadas entre cliente e servidor. 


## **GET/POST/PUT/DELETE**

"O protocolo HTTP define um conjunto de métodos de requisição responsáveis por indicar a ação a ser executada para um dado recurso. Embora esses métodos possam ser descritos como substantivos, eles também são comumente referenciados como HTTP Verbs (Verbos HTTP)." (MOZILLA, 2021)

Existem vários tipos de métodos, porém a maior parte dos serviços lida principalmente com as 4 operações crud: POST, GET, PUT e DELETE.

* POST: O método POST é utilizado para submeter uma entidade a um recurso específico, frequentemente causando uma mudança no estado do recurso ou efeitos colaterais no servidor.

* GET: O método GET solicita a representação de um recurso específico. Requisições utilizando o método GET devem retornar apenas dados.

* PUT: O método PUT substitui todas as atuais representações do recurso de destino pela carga de dados da requisição.

* DELETE: O método DELETE remove um recurso específico.

## **Códigos de retorno HTTP**
1. Respostas de informação (100-199),
2. Respostas de sucesso (200-299),
3. Redirecionamentos (300-399),
4. Erros do cliente (400-499),
5. Erros do servidor (500-599).

Os status HTTP mais utilizados são:
| Status | Descrição |
| ---: | :--- |
| 200 | **Sucesso** - a requisição foi processada com sucesso |
| 201 | **Criado** - a requisição foi processada com sucesso e resultou em um novo recurso criado |
| 204 | **Sem conteúdo** - a requisição foi processada com sucesso e não existe conteúdo adicional na resposta |
| 400 | **Requisição mal formada** - a requisição não está de acordo com o formato esperado. Verifique o JSON (body) que está sendo enviado |
| 401 | **Não autenticado** - os dados de autenticação estão incorretos. Verifique o cabeçalho (header) da requisição o e-mail e o token |
| 403 | **Não autorizado** - você está tentando acessar um recurso ao qual não tem permissão |
| 404 | **Não encontrado** - você está tentando acessar um recurso que não existe na SkyHub |
| 406 | **Formato não aceito** - a SkyHub não suporta o formato de dados especificado no cabeçalho (Accept) |
| 415 | **Formato de mídia não aceito** - SkyHub não consegue processar os dados enviados por conta de seu formato. Certifique-se do uso do charset UTF-8 (tanto no header "Content-Type", quanto no próprio body da requisição) |
| 422 | **Erro semântico** - apesar do formato da requisição estar correto, os dados ferem alguma regra de negócio (por exemplo: transição inválida do status de pedido) |
| 429 | **Limite de requisições ultrapassado** - você fez mais requisições do que o permitido em um determinado recurso |
| 500 ou 502 | **Erro interno** - ocorreu um erro no servidor da SkyHub ao tentar processar a requisição |
| 503 | **Serviço indisponível** - a API da SkyHub está temporariamente fora do ar |
| 504 | **Timeout** - a requisição levou muito tempo e não pode ser processada |


## **Query parameters**
"Os parâmetros de consulta são um conjunto definido de parâmetros anexados ao final de uma url. São extensões da URL que são usadas para ajudar a definir conteúdo ou ações específicas com base nos dados que estão sendo passados." (BRANCH, 2021)

Neste caso os parametros ficam expostos na URL, então é preciso avaliar a necessidade de atribuir esses valores e expor-los na URL. 


<br/>

# **REFERÊNCIAS**

**O que é API?** REDHAT, 2021. Disponível em: <https://www.redhat.com/pt-br/topics/api/what-are-application-programming-interfaces>. Acesso em: 10, Agosto 2021.


**O que é uma API? [Guia para iniciantes]** TECNOBLOG, 2021. Disponível em: <https://tecnoblog.net/436350/o-que-e-uma-api-guia-para-iniciantes/>. Acesso em: 10, Agosto 2021.


**Métodos de requisição HTTP** MOZILLA, 2021. Disponível em: <https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Methods>. Acesso em: 10, Agosto 2021.


**Códigos de status de respostas HTTP** MOZILLA, 2021. Disponível em: <https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status>. Acesso em: 10, Agosto 2021.


**CQuery Parameters** BRANCH, 2021. Disponível em: <https://branch.io/glossary/query-parameters/>. Acesso em: 10, Agosto 2021.

</details>

<br>

<p align="center">
  <i> Espero ter ajudado =) </i>
</p>