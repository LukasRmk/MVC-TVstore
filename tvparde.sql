-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2019 m. Geg 13 d. 15:08
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tvparde`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `filialas`
--

CREATE TABLE `filialas` (
  `Adresas` varchar(20) NOT NULL,
  `pastoKodas` int(5) NOT NULL,
  `Direktorius` char(20) NOT NULL,
  `id_Filialas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Miestasid_Miestas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `filialas`
--

INSERT INTO `filialas` (`Adresas`, `pastoKodas`, `Direktorius`, `id_Filialas`, `fk_Miestasid_Miestas`) VALUES
('8 Lotheville Crossin', 72865, 'Angel Vasyutichev', 1, 1),
('3 Sugar Parkway', 52136, 'Eliot Kynder', 2, 2),
('5 Kinsman Place', 21356, 'Lion Giggie', 3, 3),
('9 Norway Maple Drive', 12345, 'Helsa Meneyer', 4, 4),
('41 Mendota Drive', 12368, 'Remy Capponeer', 5, 5),
('5 Oak Valley Alley', 89746, 'Pinchas Dossettor', 6, 6),
('6 6th Way', 64825, 'Anna-maria Tindall', 7, 7),
('4 Namekagon Plaza', 65479, 'Travis Ball', 8, 8),
('7 Lawn Place', 30328, 'Melosa Barstock', 9, 9),
('4 Victoria Park', 68432, 'Henrik Essame', 10, 10),
('9 Stuart Road', 67073, 'Shoshana Winwood', 11, 11),
('1 Brickson Park Cour', 20354, 'Marena Watsam', 12, 12),
('Oakridge Terrace', 31526, 'Normy Wittier', 13, 13),
('1 Lake View Trail', 73250, 'Julian Henniger', 14, 14),
('3 Dakota Court', 24203, 'Athena Patley', 15, 15),
('9 Schmedeman Pass', 30304, 'Rad Critcher', 16, 16),
('4 Farmco Circle', 20315, 'Bobby Peyto', 17, 17),
('0 Tony Court', 62189, 'Dionysus Radmer', 18, 18),
('4 Lyons Plaza', 30648, 'Merci Taylor', 19, 19),
('1 Vidon Avenue', 83954, 'Lezlie Hunnybun', 20, 20),
('8 Southridge Court', 16000, 'Horacio Gernier', 21, 21),
('1 Cascade Pass', 30628, 'Rosalynd Frostdyke', 22, 22),
('6 Sommers Street', 63248, 'Theodosia Alcalde', 23, 23),
('4 East Park', 30249, 'Giustina Meech', 24, 24),
('8 Leroy Drive', 30146, 'Whitney Birks', 25, 25);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `gamintojas`
--

CREATE TABLE `gamintojas` (
  `pavadinimas` char(10) NOT NULL,
  `id_Gamintojas` int(11) NOT NULL AUTO_INCREMENT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `gamintojas`
--

INSERT INTO `gamintojas` (`pavadinimas`, `id_Gamintojas`) VALUES
('Samsung', 1),
('LG', 2),
('Sony', 3),
('Philips', 4),
('Blaupunkt', 5),
('Panasonic', 6),
('Xiaomi', 7),
('TCL', 8),
('Finlux', 9),
('Manta', 10),
('TVstar', 11),
('Sharp', 12),
('Toshiba', 13),
('Telefunken', 14),
('Pioneer', 15),
('Hitachi', 16),
('Fujitsu', 17),
('Dell', 18),
('Gorenje', 19),
('Acer', 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `garantija`
--

CREATE TABLE `garantija` (
  `GarantinisTerminas` int(2) NOT NULL,
  `TelevizoriausSerN` varchar(20) NOT NULL,
  `isigyjimoData` date NOT NULL,
  `PirkimoKaina` decimal(8,2) NOT NULL,
  `id_Garantija` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Pirkimo_sutartisid_Pirkimo_sutartis` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `garantija`
--

INSERT INTO `garantija` (`GarantinisTerminas`, `TelevizoriausSerN`, `isigyjimoData`, `PirkimoKaina`, `id_Garantija`, `fk_Pirkimo_sutartisid_Pirkimo_sutartis`) VALUES
(1, 'JM1NC2LF5F0596160', '0000-00-00', '78.00', 1, 1),
(2, '1FTFW1E82AK211507', '0000-00-00', '45.00', 2, 2),
(3, '5FRYD4H87FB226604', '0000-00-00', '72.00', 3, 3),
(4, 'WAUVVAFR1CA269218', '0000-00-00', '49.00', 4, 4),
(5, 'WBAYA6C54DD939853', '0000-00-00', '19.00', 5, 5),
(2, '4USBU33596L216226', '0000-00-00', '5.00', 6, 6),
(5, '3VW4A7AT3DM663806', '0000-00-00', '12.00', 7, 7),
(4, 'SAJWA4EC1DM060578', '0000-00-00', '12.00', 8, 8),
(4, 'JN1CV6EK9AM800112', '0000-00-00', '25.00', 9, 9),
(2, '5LMJJ2H53DE656093', '0000-00-00', '72.00', 10, 10),
(2, '3GYFK66N15G396821', '0000-00-00', '95.00', 11, 11),
(2, 'WBAYA8C57ED582679', '0000-00-00', '56.00', 12, 12),
(1, 'JM3TB2BV2E0394109', '0000-00-00', '95.00', 13, 13),
(4, '1GKS1EEF8CR157926', '0000-00-00', '34.00', 14, 14),
(5, 'WAUBFAFL8DA476492', '0000-00-00', '39.00', 15, 15),
(3, 'WVWBN7AN0FE658958', '0000-00-00', '99.00', 16, 16),
(5, '19UUA75598A718018', '0000-00-00', '21.00', 17, 17),
(2, 'WAUCKAFR0AA631228', '0000-00-00', '77.00', 18, 18),
(2, 'WBA5A5C50ED704039', '0000-00-00', '40.00', 19, 19),
(2, '1D7RW2BKXAS850245', '0000-00-00', '50.00', 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `klientas`
--

CREATE TABLE `klientas` (
  `Vardas` varchar(10) NOT NULL,
  `Pavarde` varchar(10) NOT NULL,
  `KlientoKodas` int(11) NOT NULL,
  `id_Klientas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Garantijaid_Garantija` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `klientas`
--

INSERT INTO `klientas` (`Vardas`, `Pavarde`, `KlientoKodas`, `id_Klientas`, `fk_Garantijaid_Garantija`) VALUES
('Brietta', 'Haken', 2147483647, 1, 1),
('Vincenty', 'MacGebenay', 1245723286, 2, 2),
('Morrie', 'Bittleston', 2147483647, 3, 3),
('Serena', 'Muxworthy', 2147483647, 4, 4),
('Roscoe', 'MacDonald', 2147483647, 5, 5),
('Neale', 'Hasslocher', 465018777, 6, 6),
('Marlon', 'Sayre', 2147483647, 7, 7),
('Jeannine', 'Churms', 2147483647, 8, 8),
('Valli', 'Cicerone', 2147483647, 9, 9),
('Coriss', 'Wilbraham', 2147483647, 10, 10),
('Erie', 'Tomaszynsk', 2147483647, 11, 11),
('Daveen', 'Bloan', 119308320, 12, 12),
('Bobbe', 'O\'Breen', 2147483647, 13, 13),
('Ruthe', 'Sumshon', 2147483647, 14, 14),
('Beckie', 'Eversfield', 2147483647, 15, 15),
('Moe', 'Giaomozzo', 2147483647, 16, 16),
('Micki', 'Gillott', 2147483647, 17, 17),
('Vito', 'L\'Episcopi', 2147483647, 18, 18),
('Trefor', 'Perrycost', 2147483647, 19, 19),
('Kirstin', 'Pudan', 2147483647, 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `miestas`
--

CREATE TABLE `miestas` (
  `pavadinimas` char(20) NOT NULL,
  `id_Miestas` int(11) NOT NULL AUTO_INCREMENT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `miestas`
--

INSERT INTO `miestas` (`pavadinimas`, `id_Miestas`) VALUES
('Taquile', 1),
('Nicosia', 2),
('Zhonghechang', 3),
('Aradac', 4),
('Norrköping', 5),
('Bogandinskiy', 6),
('Orlando', 7),
('Bensonville', 8),
('Verkh-Usugli', 9),
('Meipu', 10),
('Yingtou', 11),
('Nanxi', 12),
('Svalöv', 13),
('São Sepé', 14),
('Gaowu', 15),
('Ust’-Dzheguta', 16),
('Herrán', 17),
('Faruka', 18),
('Ribaldeira', 19),
('Malbug', 20),
('‘Amrān', 21),
('Yuen Long Kau Hui', 22),
('Wulipu', 23),
('Asarum', 24),
('Minneapolis', 25),
('Chyhyryn', 26),
('Merton', 27),
('Ekenäs', 28),
('Rueil-Malmaison', 29),
('Pesisir', 30);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `modelis`
--

CREATE TABLE `modelis` (
  `dydis` int(3) NOT NULL,
  `ekranoTipas` char(10) NOT NULL,
  `pavadimimas` varchar(10) NOT NULL,
  `id_Modelis` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Gamintojasid_Gamintojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `modelis`
--

INSERT INTO `modelis` (`dydis`, `ekranoTipas`, `pavadimimas`, `id_Modelis`, `fk_Gamintojasid_Gamintojas`) VALUES
(32, 'LED', 'Zontrax', 1, 1),
(32, 'LED', 'Zoolab', 2, 2),
(24, 'OLED', 'Matsoft', 3, 3),
(55, 'LED', 'Y-find', 4, 4),
(55, 'OLED', 'Transcof', 5, 5),
(65, 'LED', 'Keylex', 6, 6),
(75, 'OLED', 'Zaam-Dox', 7, 7),
(82, 'LED', 'Opela', 8, 8),
(22, 'LED', 'Domainer', 9, 9),
(43, 'LED', 'Stim', 10, 10),
(49, 'LED', 'Andalax', 11, 11),
(50, 'OLED', 'Temp', 12, 12),
(22, 'QLED', 'Cardify', 13, 13),
(55, 'QLED', 'Ventosanza', 14, 14),
(65, 'QLED', 'Lotstring', 15, 15),
(65, 'OLED', 'Tin', 16, 16),
(49, 'OLED', 'Namfix', 17, 17),
(43, 'OLED', 'Stim', 18, 18),
(43, 'QLED', 'Daltfresh', 19, 19),
(49, 'OLED', 'Pannier', 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `mokejimas`
--

CREATE TABLE `mokejimas` (
  `data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `id_Mokejimas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Klientasid_Klientas` int(11) NOT NULL,
  `fk_Saskaitaid_Saskaita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `mokejimas`
--

INSERT INTO `mokejimas` (`data`, `suma`, `id_Mokejimas`, `fk_Klientasid_Klientas`, `fk_Saskaitaid_Saskaita`) VALUES
('2018-06-27', '3482.75', 1, 1, 1),
('2018-09-03', '557.97', 2, 2, 2),
('2018-07-15', '961.53', 3, 3, 3),
('2018-07-14', '1712.96', 4, 4, 4),
('2018-05-24', '641.48', 5, 5, 5),
('2018-12-14', '2333.06', 6, 6, 6),
('2019-01-22', '3200.69', 7, 7, 7),
('2018-08-28', '3581.49', 8, 8, 8),
('2019-02-11', '3658.07', 9, 9, 9),
('2018-03-21', '210.79', 10, 10, 10),
('2018-03-18', '1202.40', 11, 11, 11),
('2018-06-14', '1277.48', 12, 12, 12),
('2018-09-29', '3734.30', 13, 13, 13),
('2018-08-21', '1270.93', 14, 14, 14),
('2018-11-15', '1424.95', 15, 15, 15),
('2018-07-08', '1248.13', 16, 16, 16),
('2018-04-23', '3318.06', 17, 17, 17),
('2018-03-09', '3729.32', 18, 18, 18),
('2018-12-26', '2029.88', 19, 19, 19),
('2018-11-29', '180.46', 20, 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `pardavejas`
--

CREATE TABLE `pardavejas` (
  `Vardas` char(11) NOT NULL,
  `Pavarde` char(11) NOT NULL,
  `TabelioNumeris` int(5) NOT NULL,
  `DarboSutartiesNr` int(9) NOT NULL,
  `id_Pardavejas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Filialasid_Filialas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `pardavejas`
--

INSERT INTO `pardavejas` (`Vardas`, `Pavarde`, `TabelioNumeris`, `DarboSutartiesNr`, `id_Pardavejas`, `fk_Filialasid_Filialas`) VALUES
('Pablo', 'Rominov', 71856, 1122045476, 1, 1),
('Kristoforo', 'Mouan', 69964, 2147483647, 2, 2),
('Alvan', 'Gerge', 85546, 2147483647, 3, 3),
('Georgina', 'Vickery', 81643, 2147483647, 4, 4),
('Albert', 'Dennidge', 39644, 2147483647, 5, 5),
('Basilius', 'Rollin', 52619, 1429388471, 6, 6),
('Pearline', 'Aughtie', 20760, 2147483647, 7, 7),
('Charlie', 'Hulstrom', 74288, 2147483647, 8, 8),
('Natassia', 'Fritzer', 38324, 2147483647, 9, 9),
('Nike', 'Ferrari', 61813, 2147483647, 10, 10),
('Martita', 'Fogarty', 81508, 2147483647, 11, 11),
('Giff', 'Grzesiewicz', 60231, 50467875, 12, 12),
('Carroll', 'Cremer', 67461, 2147483647, 13, 13),
('Meta', 'Dugan', 46370, 2147483647, 14, 14),
('Lizabeth', 'Culshaw', 58747, 2147483647, 15, 15),
('Porty', 'Gilluley', 92693, 849414512, 16, 16),
('Carol', 'Wolseley', 89901, 738223220, 17, 17),
('Tisha', 'Grattan', 97477, 2147483647, 18, 18),
('Grethel', 'Cotte', 68409, 2147483647, 19, 19),
('Licha', 'Gors', 78266, 2147483647, 20, 20),
('Gaby', 'Scurlock', 70567, 918290112, 21, 21),
('Aggy', 'McAlroy', 92942, 993337031, 22, 22),
('Beauregard', 'Meaking', 26671, 93584482, 23, 23),
('Jarrett', 'Dummett', 16461, 2147483647, 24, 24),
('Ashley', 'Pooly', 38399, 2147483647, 25, 25);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `pirkimo_sutartis`
--

CREATE TABLE `pirkimo_sutartis` (
  `PirkimoData` date NOT NULL,
  `SutartiesNumeris` int(10) NOT NULL,
  `SaskaitosNumeris` int(10) NOT NULL,
  `PapildomosPaslaugos` char(30) NOT NULL,
  `PapildomuPaslauguKaina` decimal(8,2) NOT NULL,
  `id_Pirkimo_sutartis` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Pardavejasid_Pardavejas` int(11) NOT NULL,
  `fk_Televizoriusid_Televizorius` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `pirkimo_sutartis`
--

INSERT INTO `pirkimo_sutartis` (`PirkimoData`, `SutartiesNumeris`, `SaskaitosNumeris`, `PapildomosPaslaugos`, `PapildomuPaslauguKaina`, `id_Pirkimo_sutartis`, `fk_Pardavejasid_Pardavejas`, `fk_Televizoriusid_Televizorius`) VALUES
('2017-04-08', 2147483647, 2147483647, 'Draudimas', '770.23', 1, 1, 1),
('2017-10-19', 939066629, 2147483647, 'Draudimas', '624.72', 2, 2, 2),
('2017-03-27', 355019205, 998967351, 'Draudimas', '982.43', 3, 3, 3),
('2018-05-12', 2147483647, 2147483647, 'Draudimas', '990.46', 4, 4, 4),
('2018-12-14', 2147483647, 2147483647, 'Draudimas', '1647.54', 5, 5, 5),
('2018-08-08', 960002065, 2147483647, 'Pap. Garantija', '1964.30', 6, 6, 6),
('2017-07-25', 2147483647, 2147483647, 'Pap. Garantija', '1816.06', 7, 7, 7),
('2018-05-16', 632892005, 643193987, 'Pap. Garantija', '654.56', 8, 8, 8),
('2017-06-24', 2147483647, 1122021380, 'Pap. Garantija', '1265.38', 9, 9, 9),
('2017-12-18', 268103267, 728582546, 'Pap. Garantija', '682.26', 10, 10, 10),
('2018-07-18', 272520292, 2147483647, 'Draudimas', '1983.29', 11, 11, 11),
('2018-06-13', 2147483647, 2147483647, 'Draudimas', '464.29', 12, 12, 12),
('2017-10-17', 2147483647, 822719908, 'Draudimas', '1458.42', 13, 13, 13),
('2017-09-04', 747857407, 602559006, 'Pap. Garantija', '194.23', 14, 14, 14),
('2018-02-09', 2147483647, 2147483647, 'Pap. Garantija', '515.30', 15, 15, 15),
('2017-08-15', 1888297662, 1501943901, 'Pap. Garantija', '1808.83', 16, 16, 16),
('2018-05-04', 2147483647, 780305019, 'Draudimas', '238.33', 17, 17, 17),
('2018-08-06', 929819136, 2147483647, 'Draudimas', '1590.97', 18, 18, 18),
('2017-05-21', 2147483647, 2147483647, 'Draudimas', '1375.32', 19, 19, 19),
('2017-08-24', 2147483647, 2147483647, 'Draudimas', '1095.01', 20, 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `platintojas`
--

CREATE TABLE `platintojas` (
  `pavadinimas` varchar(50) NOT NULL,
  `adresas` varchar(50) NOT NULL,
  `pastoKodas` int(5) NOT NULL,
  `e_paštas` varchar(30) NOT NULL,
  `id_Platintojas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Televizoriusid_Televizorius` int(11) NOT NULL,
  `fk_Miestasid_Miestas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `platintojas`
--

INSERT INTO `platintojas` (`pavadinimas`, `adresas`, `pastoKodas`, `e_paštas`, `id_Platintojas`, `fk_Televizoriusid_Televizorius`, `fk_Miestasid_Miestas`) VALUES
('Waddell & Reed Financial, Inc.', '464 Mayer Lane', 12345, 'bcelloni0@tripod.com', 1, 1, 1),
('Exelon Corporation', '66 Havey Park', 54700, 'blindro1@kickstarter.com', 2, 2, 2),
('Vident Core US Equity ETF', '1 Sycamore Plaza', 23156, 'ptiron2@histats.com', 3, 3, 3),
('Twin Disc, Incorporated', '447 Green Ridge Road', 83000, 'aspreadbury3@photobucket.com', 4, 4, 4),
('Constellation Brands Inc', '49789 Eastlawn Point', 67030, 'hfawcitt4@dell.com', 5, 5, 5),
('Amphenol Corporation', '6 Monterey Park', 98531, 'mfalck5@yahoo.co.jp', 6, 6, 6),
('PennantPark Floating Rate Capital Ltd.', '5746 Linden Plaza', 21436, 'thulke6@clickbank.net', 7, 7, 7),
('Versum Materials, Inc.', '09 Acker Trail', 14604, 'fchisholme7@yale.edu', 8, 8, 8),
('Asia Pacific Fund, Inc. (The)', '926 Glendale Point', 39340, 'cgerrey8@meetup.com', 9, 9, 9),
('Horizon Pharma plc', '982 Laurel Junction', 54702, 'mcorkell9@prnewswire.com', 10, 10, 10),
('Angie&#39;s List, Inc.', '30998 Rowland Street', 51216, 'branalda@g.co', 11, 11, 11),
('Laureate Education, Inc.', '7 Sunbrook Park', 30198, 'sbradenb@bandcamp.com', 12, 12, 12),
('Lear Corporation', '13722 Lotheville Point', 21140, 'taynoldc@dyndns.org', 13, 13, 13),
('New Relic, Inc.', '94875 Alpine Trail', 13530, 'aburrelld@yelp.com', 14, 14, 14),
('FBL Financial Group, Inc.', '0 Pierstorff Avenue', 23304, 'jmithone@sina.com.cn', 15, 15, 15),
('Xcel Energy Inc.', '3 Pond Way', 33680, 'ktamlettf@sakura.ne.jp', 16, 16, 16),
('PowerShares DWA SmallCap Momentum Portfolio', '65 Onsgard Drive', 37741, 'cjandlg@123-reg.co.uk', 17, 17, 17),
('AnaptysBio, Inc.', '040 Sloan Terrace', 63632, 'cwillcocksh@bing.com', 18, 18, 18),
('Jagged Peak Energy Inc.', '1 Maple Wood Pass', 32014, 'apreedyi@mail.ru', 19, 19, 19),
('Atlantic Alliance Partnership Corp.', '350 Portage Trail', 6207, 'rfawderyj@trellian.com', 20, 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `saskaita`
--

CREATE TABLE `saskaita` (
  `numeris` int(11) NOT NULL,
  `data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `id_Saskaita` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Pirkimo_sutartisid_Pirkimo_sutartis` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `saskaita`
--

INSERT INTO `saskaita` (`numeris`, `data`, `suma`, `id_Saskaita`, `fk_Pirkimo_sutartisid_Pirkimo_sutartis`) VALUES
(2147483647, '2019-01-01', '2239.13', 1, 1),
(2147483647, '2018-12-02', '2247.29', 2, 2),
(2147483647, '2019-01-16', '1559.26', 3, 3),
(2147483647, '2018-07-30', '757.90', 4, 4),
(2147483647, '2018-03-09', '3268.66', 5, 5),
(2147483647, '2018-05-19', '1216.64', 6, 6),
(2147483647, '2019-02-02', '2802.86', 7, 7),
(2147483647, '2018-06-13', '3872.08', 8, 8),
(2147483647, '2018-07-29', '1610.90', 9, 9),
(2147483647, '2018-08-03', '3253.80', 10, 10),
(2147483647, '2018-09-29', '3065.24', 11, 11),
(1090793634, '2018-05-08', '1422.13', 12, 12),
(2147483647, '2018-03-19', '2304.37', 13, 13),
(2147483647, '2018-03-29', '691.07', 14, 14),
(1183196164, '2018-04-02', '217.43', 15, 15),
(607350687, '2018-09-10', '2867.74', 16, 16),
(2147483647, '2018-12-05', '504.31', 17, 17),
(914929917, '2018-03-17', '377.93', 18, 18),
(2147483647, '2018-07-02', '2884.15', 19, 19),
(2147483647, '2018-08-29', '922.27', 20, 20);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `televizorius`
--

CREATE TABLE `televizorius` (
  `SerN` varchar(20) NOT NULL,
  `pagaminimoData` date NOT NULL,
  `remoSpalva` varchar(11) NOT NULL,
  `remoKoja` char(11) NOT NULL,
  `ekranoDaznis` varchar(5) NOT NULL,
  `rezoliucija` varchar(9) NOT NULL,
  `papildomosFunkcijos` char(30) NOT NULL,
  `imtuvas` varchar(30) NOT NULL,
  `id_Televizorius` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Modelisid_Modelis` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `televizorius`
--

INSERT INTO `televizorius` (`SerN`, `pagaminimoData`, `remoSpalva`, `remoKoja`, `ekranoDaznis`, `rezoliucija`, `papildomosFunkcijos`, `imtuvas`, `id_Televizorius`, `fk_Modelisid_Modelis`) VALUES
('1B3CB3HA8AD124874', '0000-00-00', 'Violet', 'per vidury', '50hz', 'HD', 'Smart TV', 'Skaitemeninis', 1, 1),
('1ZVBP8AMXC5230380', '0000-00-00', 'Teal', 'per vidury', '50hz', 'HD', 'Smart TV', 'Skaitemeninis', 2, 2),
('WBAGN63515D373443', '0000-00-00', 'Green', 'sonuose', '50hz', 'HD', 'Smart TV', 'Skaitemeninis', 3, 3),
('WBAYM9C59DD655143', '0000-00-00', 'Yellow', 'per vidury', '50hz', 'UHD', 'Smart TV', 'Skaitemeninis', 4, 4),
('1G6DM5E39D0411492', '0000-00-00', 'Blue', 'per vidury', '100hz', 'UHD', 'Nera', 'Skaitemeninis', 5, 5),
('1HGCP2E78AA050572', '0000-00-00', 'Maroon', 'sonuose', '100hz', 'UHD', 'Smart TV', 'Skaitemeninis', 6, 6),
('JM3TB2MA5A0523707', '0000-00-00', 'Blue', 'sonuose', '50hz', 'HD', 'Nera', 'Skaitemeninis', 7, 7),
('5N1AT2MKXFC248603', '0000-00-00', 'Indigo', 'sonuose', '100hz', 'UHD', 'Smart TV', 'Skaitemeninis', 8, 8),
('5N1AN0NU9AC744872', '0000-00-00', 'Fuscia', 'per vidury', '100hz', 'UHD', 'Smart TV', 'Skaitmeninis', 9, 9),
('1G6KF54995U667911', '0000-00-00', 'Red', 'per vidury', '50hz', 'UHD', 'Smart TV', 'Analoginis', 10, 10),
('1G4GD5EG2AF018595', '0000-00-00', 'Crimson', 'sonuose', '50hz', 'UHD', 'Smart TV', 'Analoginis', 11, 11),
('WAUFFAFLXCA031865', '0000-00-00', 'Red', 'per vidury', '50hz', 'UHD', 'Smart TV', 'Analoginis', 12, 12),
('JHMFA3F23AS142218', '0000-00-00', 'Yellow', 'per vidury', '100hz', 'UHD', 'Nera', 'Analoginis', 13, 13),
('JTHBP5C29E5087176', '0000-00-00', 'Maroon', 'per vidury', '100hz', 'UHD', 'Nera', 'Analoginis', 14, 14),
('WA1BV94L07D901837', '0000-00-00', 'Violet', 'sonuose', '50hz', 'UHD', 'Smart TV', 'Analoginis', 15, 15),
('5FRYD4H23GB083079', '0000-00-00', 'Mauv', 'per vidury', '50hz', 'UHD', 'Smart TV', 'Analoginis', 16, 16),
('WAUPN44E77N974758', '0000-00-00', 'Orange', 'sonuose', '100hz', 'UHD', 'Smart TV', 'Skaitemeninis', 17, 17),
('WAUEFAFL6BN401485', '0000-00-00', 'Indigo', 'per vidury', '50hz', 'HD', 'Smart TV', 'Analoginis', 18, 18),
('1G4HR57Y88U395921', '0000-00-00', 'Turquoise', 'per vidury', '100hz', 'UHD', 'Nera', 'Analoginis', 19, 19),
('3GYFNBE39ES478454', '0000-00-00', 'Crimson', 'sonuose', '100hz', 'UHD', 'Nera', 'Skaitemeninis', 20, 20);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `filialas`
--
ALTER TABLE `filialas`
  ADD PRIMARY KEY (`id_Filialas`),
  ADD KEY `turi4` (`fk_Miestasid_Miestas`);

--
-- Indexes for table `gamintojas`
--
ALTER TABLE `gamintojas`
  ADD PRIMARY KEY (`id_Gamintojas`);

--
-- Indexes for table `garantija`
--
ALTER TABLE `garantija`
  ADD PRIMARY KEY (`id_Garantija`),
  ADD KEY `suteikia` (`fk_Pirkimo_sutartisid_Pirkimo_sutartis`);

--
-- Indexes for table `klientas`
--
ALTER TABLE `klientas`
  ADD PRIMARY KEY (`id_Klientas`),
  ADD KEY `israsyta1` (`fk_Garantijaid_Garantija`);

--
-- Indexes for table `miestas`
--
ALTER TABLE `miestas`
  ADD PRIMARY KEY (`id_Miestas`);

--
-- Indexes for table `modelis`
--
ALTER TABLE `modelis`
  ADD PRIMARY KEY (`id_Modelis`),
  ADD KEY `turi2` (`fk_Gamintojasid_Gamintojas`);

--
-- Indexes for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD PRIMARY KEY (`id_Mokejimas`),
  ADD KEY `sumokejo` (`fk_Klientasid_Klientas`),
  ADD KEY `apmoka` (`fk_Saskaitaid_Saskaita`);

--
-- Indexes for table `pardavejas`
--
ALTER TABLE `pardavejas`
  ADD PRIMARY KEY (`id_Pardavejas`),
  ADD KEY `dirba` (`fk_Filialasid_Filialas`);

--
-- Indexes for table `pirkimo_sutartis`
--
ALTER TABLE `pirkimo_sutartis`
  ADD PRIMARY KEY (`id_Pirkimo_sutartis`),
  ADD KEY `parduoda` (`fk_Pardavejasid_Pardavejas`),
  ADD KEY `itrauktas_i` (`fk_Televizoriusid_Televizorius`);

--
-- Indexes for table `platintojas`
--
ALTER TABLE `platintojas`
  ADD PRIMARY KEY (`id_Platintojas`),
  ADD KEY `turi3` (`fk_Televizoriusid_Televizorius`),
  ADD KEY `turi5` (`fk_Miestasid_Miestas`);

--
-- Indexes for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD PRIMARY KEY (`id_Saskaita`),
  ADD KEY `israsyta` (`fk_Pirkimo_sutartisid_Pirkimo_sutartis`);

--
-- Indexes for table `televizorius`
--
ALTER TABLE `televizorius`
  ADD PRIMARY KEY (`id_Televizorius`),
  ADD KEY `turi1` (`fk_Modelisid_Modelis`);

--
-- Apribojimai eksportuotom lentelėm
--

--
-- Apribojimai lentelei `filialas`
--
ALTER TABLE `filialas`
  ADD CONSTRAINT `turi4` FOREIGN KEY (`fk_Miestasid_Miestas`) REFERENCES `miestas` (`id_Miestas`);

--
-- Apribojimai lentelei `garantija`
--
ALTER TABLE `garantija`
  ADD CONSTRAINT `suteikia` FOREIGN KEY (`fk_Pirkimo_sutartisid_Pirkimo_sutartis`) REFERENCES `pirkimo_sutartis` (`id_Pirkimo_sutartis`);

--
-- Apribojimai lentelei `klientas`
--
ALTER TABLE `klientas`
  ADD CONSTRAINT `israsyta1` FOREIGN KEY (`fk_Garantijaid_Garantija`) REFERENCES `garantija` (`id_Garantija`);

--
-- Apribojimai lentelei `modelis`
--
ALTER TABLE `modelis`
  ADD CONSTRAINT `turi2` FOREIGN KEY (`fk_Gamintojasid_Gamintojas`) REFERENCES `gamintojas` (`id_Gamintojas`);

--
-- Apribojimai lentelei `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD CONSTRAINT `apmoka` FOREIGN KEY (`fk_Saskaitaid_Saskaita`) REFERENCES `saskaita` (`id_Saskaita`),
  ADD CONSTRAINT `sumokejo` FOREIGN KEY (`fk_Klientasid_Klientas`) REFERENCES `klientas` (`id_Klientas`);

--
-- Apribojimai lentelei `pardavejas`
--
ALTER TABLE `pardavejas`
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_Filialasid_Filialas`) REFERENCES `filialas` (`id_Filialas`);

--
-- Apribojimai lentelei `pirkimo_sutartis`
--
ALTER TABLE `pirkimo_sutartis`
  ADD CONSTRAINT `itrauktas_i` FOREIGN KEY (`fk_Televizoriusid_Televizorius`) REFERENCES `televizorius` (`id_Televizorius`),
  ADD CONSTRAINT `parduoda` FOREIGN KEY (`fk_Pardavejasid_Pardavejas`) REFERENCES `pardavejas` (`id_Pardavejas`);

--
-- Apribojimai lentelei `platintojas`
--
ALTER TABLE `platintojas`
  ADD CONSTRAINT `turi3` FOREIGN KEY (`fk_Televizoriusid_Televizorius`) REFERENCES `televizorius` (`id_Televizorius`),
  ADD CONSTRAINT `turi5` FOREIGN KEY (`fk_Miestasid_Miestas`) REFERENCES `miestas` (`id_Miestas`);

--
-- Apribojimai lentelei `saskaita`
--
ALTER TABLE `saskaita`
  ADD CONSTRAINT `israsyta` FOREIGN KEY (`fk_Pirkimo_sutartisid_Pirkimo_sutartis`) REFERENCES `pirkimo_sutartis` (`id_Pirkimo_sutartis`);

--
-- Apribojimai lentelei `televizorius`
--
ALTER TABLE `televizorius`
  ADD CONSTRAINT `turi1` FOREIGN KEY (`fk_Modelisid_Modelis`) REFERENCES `modelis` (`id_Modelis`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
