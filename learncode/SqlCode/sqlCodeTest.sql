//多表查询 leetcode175
//"LEFT JOIN" 是 SQL 中的一种连接操作，用于将两个或多个表中的数据合并，返回左侧表中的所有行，以及与右侧表匹配的行。如果右侧表中没有匹配的行，则会用 NULL 填充。
select firstName,secondName,city,state
from Person left join Address
on Person.PersonId=Address.PersonId;