# Relatório De Erros
A falta de um construtor implica na realiação de testes devido a falta de dados dos objetos, abrindo possibilidades para erros diversos.
O método de Atualizar dados da model não faz a validação se os dados passados são válidos. Portanto, é possivel passar Dados vazios e nulos.
O método de Verificar aprovação deveria ser >= a 5 e não só >5, pq quando se é passado 5 como dado ele retorna negativo.
