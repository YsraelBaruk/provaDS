-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 27-Nov-2022 às 18:35
-- Versão do servidor: 8.0.27
-- versão do PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `adote_pet`
--
CREATE DATABASE IF NOT EXISTS `adote_pet` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `adote_pet`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `adocao`
--

DROP TABLE IF EXISTS `adocao`;
CREATE TABLE IF NOT EXISTS `adocao` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `fk_Tutor_Id` int DEFAULT NULL,
  `fk_Pet_Id` int DEFAULT NULL,
  `data_adocao` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `fk_Tutor_Id` (`fk_Tutor_Id`),
  KEY `fk_Pet_Id` (`fk_Pet_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `pet`
--

DROP TABLE IF EXISTS `pet`;
CREATE TABLE IF NOT EXISTS `pet` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) DEFAULT NULL,
  `especie` varchar(100) DEFAULT NULL,
  `animal` varchar(100) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `peso` double DEFAULT NULL,
  `vacinado` smallint DEFAULT NULL,
  `sobre` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Extraindo dados da tabela `pet`
--

INSERT INTO `pet` (`Id`, `nome`, `especie`, `animal`, `data_nasc`, `peso`, `vacinado`, `sobre`) VALUES
(1, 'Pingo', 'Mamífero ', 'Cachorro', '2022-11-01', 1, 1, 'Lindinho'),
(2, 'Piu Pui', 'Aves', 'Galinha (Galo)', '2022-11-25', 0.2, 1, 'Acho que vi um gatinho'),
(3, 'Doke', 'Mamíferos', 'Cão', '2022-10-03', 15, 1, 'Meu cão');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tutor`
--

DROP TABLE IF EXISTS `tutor`;
CREATE TABLE IF NOT EXISTS `tutor` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `cpf` varchar(20) DEFAULT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `telefone` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `cep` varchar(20) DEFAULT NULL,
  `uf` char(2) DEFAULT NULL,
  `cidade` varchar(100) DEFAULT NULL,
  `bairro` varchar(100) DEFAULT NULL,
  `logradouro` varchar(100) DEFAULT NULL,
  `numero` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `cpf` (`cpf`,`email`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Extraindo dados da tabela `tutor`
--

INSERT INTO `tutor` (`Id`, `cpf`, `nome`, `telefone`, `email`, `data_nasc`, `cep`, `uf`, `cidade`, `bairro`, `logradouro`, `numero`) VALUES
(1, '11122233300', 'Eliton Camargo de Oliveira', '(14)99988-7766', 'elitonoliveira@fatec.sp.gov.br', '1988-11-16', '13550-00', 'SP', 'Tietê', 'Serra', 'Rua Teste', 100),
(2, '21242423432', 'Marcos', '12434252343', 'marcos@gmail.com', '1977-03-01', '3123213', 'MT', 'Teste Mato', 'Não sei', 'Rua dos Esquecimentos', 100);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `adocao`
--
ALTER TABLE `adocao`
  ADD CONSTRAINT `adocao_ibfk_1` FOREIGN KEY (`fk_Tutor_Id`) REFERENCES `tutor` (`Id`),
  ADD CONSTRAINT `adocao_ibfk_2` FOREIGN KEY (`fk_Pet_Id`) REFERENCES `pet` (`Id`);