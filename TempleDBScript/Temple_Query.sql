create database Temple
use Temple
create table Pooja(pid int primary key identity(1,1),name varchar(30),cost int,details varchar(200))
create table PoojaBkng(bkid int primary key identity(1,1),det varchar(200),sdt datetime,edt datetime)
create table ConHallBkng(bkid int primary key identity(1,1),det varchar(200),sdt datetime,edt datetime)
create table AnDhanBkng(bkid int primary key identity(1,1),det varchar(200),sdt datetime,edt datetime)
create table FnHallBkng(bkid int primary key identity(1,1),det varchar(200),sdt datetime,edt datetime)
