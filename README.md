
# SuperDigital
Projeto de teste de conhecimento

 **1**. EXPLIQUE COM SUAS PALAVRAS O QUE É DOMAIN DRIVEN DESIGN E SUA IMPORTÂNCIA NA ESTRATÉGIA DE DESENVOLVIMENTO DE SOFTWARE:

> O modelo de desenvolvimento seguindo DDD é quando a arquitetura do
> software  fala a mesma linguá do negocio, linguagem obliqua. E também
> pelo fato de toda a regra de negocio ficar centralizada dentro do
> domínio da aplicação. e toda a comunicação com componentes externos, 
> repositório por exemplo, é feita através de interface, ou seja,  se a
> implementação do repositório em si tiver que ser alterada, somente a
> alterada na implementa do repositório em si deve ser alterada, não
> mudando  nada dentro do domínio da aplicação, e sem contar o fato de
> que isso também ajuda no teste da aplicação pois a utilização de
> interfaces facilita e muito os teste,  com mocks por exemplo.

 **2.** EXPLIQUE COM SUAS PALAVRAS O QUE É E COMO FUNCIONA UMA ARQUITETURA
    BASEADA EM MICROSERVICES. EXPLIQUE GANHOS COM ESTE MODELO E DESAFIOS
    EM SUA IMPLEMENTAÇÃO

> Uma arquitetura focada em microservicos, é uma arquitetura onde varias
> aplicações conversam entre si, onde cada um tem a sua responsabilidade
> dentro do fluxo de um negocio, por exemplo: um serviço de compras, 
> dados de clientes, emissão de NF, etc. O ganho da utilização deste
> modelo de arquitetura é que cada microservico  pode ser escrito em uma
> linguagem diferente, por exemplo, um microservico  que escrito em uma
> linguagem é mais performático do que escrito em outra linguagem, ao
> contrario de um sistema monolitico onde toda aplicação deve ser
> escrita na mesma linguagem,  alem do fato de que a escalabilidade da
> arquitetura é por microservico, um microservico com grande numero de
> acesso só exige que somente o numero de  instancias daquele serviço
> seja aumentado. O ponto a se atentar para este tipo de arquitetura é a
> manutenção de todos os microservicos e garantir que o fluxo critico da
> solução esteja sempre funcionando. E o fato do monitoramento das
> aplicações se toram mais complicada onde antes com uma arquitetura
> monolítica se possui somente uma aplicação,  agora existem n
> aplicações que devem ser monitoradas, sem contar o fato de que quando
> um microservico faz comunicação com uma base de dados especifica esse
> repositório também deve escalar juntamente com o microservico, e com
> isso  um problema de sincronização/replicação de dados deve ser
> solucionado.

 **3.** EXPLIQUE QUAL A DIFERENÇA ENTRE COMUNICAÇÃO SINCRONA E ASSINCRONA E QUAL O MELHOR CENÁRIO PARA UTILIZAR UMA OU OUTRA.

> Comunicação síncrona é quando por exemplo uma requisição é feita para
> uma api  e a requisição somente é concluída quando toda a rotina for
> completa dentro dessa requisição.  Já uma requisição assíncrona, é
> quando o não é  necessário aguardar que todo o fluxo seja completo
> para retornar os dados para o cliente.
> 
> Por exemplo: em um cenário onde deve ser feito o cadastro de um
> produto no estoque, onde o mesmo deve ser efetuado somente na base de
> dados, essa rotina deve ser executada de maneira síncrona.  Porem caso
> esse cadastro enviar os dados também para outro sistema,  como por
> exemplo para uma api de um ERP, essa rotina deve ser feita de maneria
> assíncrona, onde uma vez que o sistema não deve ficar aguardando o
> cadastro do produto no estoque do ERP, o sistema deve simplesmente
> cadastrar o produto no estoque na base de dados e apos isso enviar os
> dados para uma fila, e em um determinado momento uma rotina é
> executada para processar esses dados,  sem fazer com que o usuário nem
> o sistema fiquem aguardando que todos esses processos sejam
> finalizados.
