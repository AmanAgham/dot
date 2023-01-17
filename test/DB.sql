create database FACULTY;

use FACULTY;

create table Feedback(
Id int primary key,
Name varchar(100),
Communication varchar(100),
Entusiasm varchar(100),
Feedback int);
insert into Feedback values(1,'Piyush','Average','good','2');
insert into Feedback values(2,'Aman','Average','good','4');
insert into Feedback values(3,'Rutvik','Average','good','1');
insert into Feedback values(4,'tejas','Average','good','3');
insert into Feedback values(5,'Anvesh','Average','excellent','4');

create table Admin(
User int primary key,
Pass varchar(100)
);
insert into Admin values("1","aman123");
insert into Admin values("2","anvesh123");
insert into Admin values("3","tejas123");