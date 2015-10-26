-- use this script inside sql shell

drop role if exists "Assignment5";
create role "Assignment5" login;
comment on role "Assignment5" is 'Restricted ISS app pool user';

drop database if exists "Assignment_5";
create database "Assignment_5";
comment on database "Assignment_5" is 'Database for Assignment5';

grant connect on database "Assignment_5" to "Assignment5";