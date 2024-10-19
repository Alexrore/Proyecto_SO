drop database if exists Juego;
create database Juego;
use Juego;

Create table Jugador (
ID INTEGER,
Nombre Varchar(25),
contraseña Varchar(25));

CREATE TABLE PartidasGanadas (
ID integer, 
victorias integer);

CREATE TABLE MedallasObtenidas (
    ID integer, 
    Medallas INTEGER
)ENGINE = InnoDB;
