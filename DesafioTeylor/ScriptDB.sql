-- create database test;
use test;
create table if not exists `user`(
Id int not null auto_increment,
`Name` varchar(100),
Birthdate date,
CPF varchar(14),
Address varchar(100),
City varchar(100),
primary key(Id)
)engine=InnoDB;
