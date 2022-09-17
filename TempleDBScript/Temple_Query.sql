create database Temple
use Temple
create table Pooja(pid int primary key identity(1,1),name varchar(30),cost int,details varchar(200))
create table ConHallBkng(bkid int primary key identity(1,1),cost int,det varchar(200),sdt datetime,edt datetime,userid int foreign key references user_(uid))
create table AnDhanBkng(bkid int primary key identity(1,1),cost int,det varchar(200),sdt datetime,edt datetime,userid int foreign key references user_(uid))
create table FnHallBkng(bkid int primary key identity(1,1),cost int,det varchar(200),sdt datetime,edt datetime,userid int foreign key references user_(uid))
create table PoojaBkng(bkid int primary key identity(1,1),cost int,pooid int foreign key references Pooja(pid),det varchar(200),sdt datetime,edt datetime,userid int foreign key references user_(uid))
create table user_(uid int primary key identity,uname varchar(20),pword varchar(20),emailid varchar(50))
create table admin_(uid int primary key identity,uname varchar(20),pword varchar(20),emailid varchar(50))
delete from AnDhanBkng where bkid=6
select * from FnHallBkng