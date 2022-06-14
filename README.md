# ProfSystem_CRUD
(EN) ASP.NET Core 6.0 app where crud operations are performed and overtime is calculated added to the employee's wage. I used Fluent APIs to database generation using 
EF Core migrations and generated two screens: a collaborators tab and an overtime tab.
The collaborators tab shows the information of collaborators registered in the database and allows all CRUD operations, allowing in this same tab that the registration
of a new employee is carried out.
The overtime tab shows only the name, wage, overtime and the wage calculated with overtime or negative hours of the employee. This part of the system allows the user to
change the overtime of one of the registered employees and recalculate the salary with overtime or negative hours. The calculation is done as follows: 5% of the 
employee's salary is added to each overtime hour. The same logic works in the case of negative hours, subtracting 5% from the salary.

(PT) Aplicação ASP.NET Core 6.0 onde as operações CRUD são realizadas e as horas extras são calculadas adicionadas ao salário do funcionário. Utilizei Fluent APIs para 
geração do banco de dados utilizando as migrações do EF Core e gerei duas telas: uma aba de colaboradores e uma aba de horas extras. 
A aba de colaboradores mostra as informações dos colaboradores registrados na base de dados e possibilita todas as operações de CRUD, permitindo nessa mesma aba que 
o cadastro de um novo colaborador seja efetuado. 
Por sua vez, a aba de horas extras mostra apenas o nome, o salário, as horas extras e o salário calculado com horas extras ou horas negativas do colaborador. Essa parte 
do sistema permite que o usuário altere as horas extras de um dos colaboradores registrados e recalcule o salário com as horas extras ou negativas. O cálculo é feito 
da seguinte maneira: a cada hora extra é adicionado 5% do salário do colaborador. A mesma lógica funciona no caso de horas negativas, subtraindo-se 5% do salário.
