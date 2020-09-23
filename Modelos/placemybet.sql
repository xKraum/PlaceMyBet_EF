CREATE DATABASE IF NOT EXISTS `placemybet` CHARSET UTF8;
USE `placemybet`;

CREATE TABLE `EVENTOS` (
  `idEvento` int(11) NOT NULL AUTO_INCREMENT,
  `equipoLocal` varchar(30) NOT NULL,
  `equipoVisitante` varchar(30) NOT NULL,
  `fecha` date NOT NULL,
  PRIMARY KEY (`idEvento`)
);

CREATE TABLE `MERCADOS` (
  `idMercado` int(11) NOT NULL AUTO_INCREMENT,
  `refEvento` int(11) NOT NULL,
  `tipoMercado` double NOT NULL,
  `cuotaOver` double NOT NULL,
  `cuotaUnder` double NOT NULL,
  `dineroOver` double NOT NULL,
  `dineroUnder` double NOT NULL,
  PRIMARY KEY (`idMercado`),
  CONSTRAINT FK_idEvento FOREIGN KEY (`refEvento`) REFERENCES `EVENTOS`(`idEvento`) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE `USUARIOS` (
  `idEmail` varchar(50) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellidos` varchar(30) NOT NULL,
  `edad` int(11) NOT NULL,
  PRIMARY KEY (`idEmail`)
);

CREATE TABLE `CUENTAS` (
  `idTarjeta` int(11) NOT NULL AUTO_INCREMENT,
  `saldo` double NOT NULL,
  `nombreBanco` varchar(30) NOT NULL,
  `refEmail` varchar(50) NOT NULL UNIQUE,
  PRIMARY KEY (`idTarjeta`),
  CONSTRAINT FK_email FOREIGN KEY (`refEmail`) REFERENCES `USUARIOS`(`idEmail`) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE `APUESTAS` (
  `idApuesta` int(11) NOT NULL AUTO_INCREMENT,
  `refEmail` varchar(50) NOT NULL,
  `refMercado` int(11) NOT NULL,
  `tipoOverUnder` varchar(6) NOT NULL,
  `cuota` double NOT NULL,
  `dineroApostado` double NOT NULL,
  `fecha` date NOT NULL,
    PRIMARY KEY (`idApuesta`),
	 CONSTRAINT FK_email_apuesta FOREIGN KEY (`refEmail`) REFERENCES `USUARIOS`(`idEmail`) ON UPDATE CASCADE ON DELETE CASCADE,
	 CONSTRAINT FK_idMercado_apuesta FOREIGN KEY (`refMercado`) REFERENCES `MERCADOS`(`idMercado`) ON UPDATE CASCADE ON DELETE CASCADE
);

INSERT INTO `EVENTOS` (`idEvento`, `equipoLocal`, `equipoVisitante`, `fecha`) VALUES
(1, 'Valencia', 'Espanyol', '2020-09-27');

INSERT INTO `MERCADOS` (`idMercado`, `refEvento`, `tipoMercado`, `cuotaOver`, `cuotaUnder`, `dineroOver`, `dineroUnder`) VALUES
(1, 1, 1.5, 1.43, 2.85, 100, 50),
(2, 1, 2.5, 1.9, 1.9, 100, 100),
(3, 1, 3.5, 2.85, 1.43, 50, 100);

INSERT INTO `USUARIOS` (`idEmail`, `nombre`, `apellidos`, `edad`) VALUES
('jolame@floridauniversitaria.es', 'Jose', 'Lacueva', 21);

INSERT INTO `CUENTAS` (`idTarjeta`, `saldo`, `nombreBanco`, `refEmail`) VALUES
(1, 2500, 'Bankia', 'jolame@floridauniversitaria.es');

INSERT INTO `APUESTAS` (`idApuesta`, `refEmail`, `refMercado`, `tipoOverUnder`, `cuota`, `dineroApostado`, `fecha`) VALUES
(1, 'jolame@floridauniversitaria.es', 1, 'Over', 10, 1000, '2020-09-27');