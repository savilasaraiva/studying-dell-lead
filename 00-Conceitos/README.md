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