-- phpMyAdmin SQL Dump
-- version 4.2.8
-- http://www.phpmyadmin.net
--
-- Machine: localhost
-- Gegenereerd op: 03 dec 2014 om 13:57
-- Serverversie: 5.5.37
-- PHP-versie: 5.4.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Databank: `eu186781_test`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_afspraak`
--

CREATE TABLE IF NOT EXISTS `rhbj_afspraak` (
  `receptID` int(11) NOT NULL,
  `locatieID` int(11) NOT NULL,
  `datum` date NOT NULL,
  `tijd` varchar(10) NOT NULL,
  `actief` int(11) NOT NULL DEFAULT '0' COMMENT '0 = niet actief, 1 = actief'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_locatie`
--

CREATE TABLE IF NOT EXISTS `rhbj_locatie` (
`locatieID` int(11) NOT NULL,
  `naam` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_login`
--

CREATE TABLE IF NOT EXISTS `rhbj_login` (
`userID` int(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `locatieID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_medicatie`
--

CREATE TABLE IF NOT EXISTS `rhbj_medicatie` (
`medicatieID` int(11) NOT NULL,
  `patientID` int(11) NOT NULL,
  `medicijnID` int(11) NOT NULL,
  `geruikstart` date NOT NULL,
  `gebruikeind` date NOT NULL,
  `hoeveelheid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_medicijn`
--

CREATE TABLE IF NOT EXISTS `rhbj_medicijn` (
`medicijnID` int(11) NOT NULL,
  `naam` varchar(50) NOT NULL,
  `gebruik` text NOT NULL,
  `bijwerking` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_pas`
--

CREATE TABLE IF NOT EXISTS `rhbj_pas` (
`pasnummer` int(11) NOT NULL,
  `patientID` int(11) NOT NULL,
  `geblokkeerd` int(11) NOT NULL DEFAULT '0' COMMENT '0 = actief, 1= geblokkeerd'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_patient`
--

CREATE TABLE IF NOT EXISTS `rhbj_patient` (
`patientID` int(11) NOT NULL,
  `voornamen` varchar(100) NOT NULL,
  `achternaam` varchar(50) NOT NULL,
  `geboortedatum` date NOT NULL,
  `email` text NOT NULL,
  `telefoon` int(13) NOT NULL,
  `adres` text NOT NULL,
  `gemeente` text NOT NULL,
  `provincie` text NOT NULL,
  `bsn` int(9) NOT NULL,
  `pasfoto` text NOT NULL,
  `bloedgroep` varchar(3) NOT NULL,
  `mobiel` int(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_recept`
--

CREATE TABLE IF NOT EXISTS `rhbj_recept` (
`receptID` int(11) NOT NULL,
  `medicatieID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_ziekte`
--

CREATE TABLE IF NOT EXISTS `rhbj_ziekte` (
`ziekteID` int(11) NOT NULL,
  `naam` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rhbj_ziekteoverzicht`
--

CREATE TABLE IF NOT EXISTS `rhbj_ziekteoverzicht` (
  `ziekteID` int(11) NOT NULL,
  `patientID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `rhbj_afspraak`
--
ALTER TABLE `rhbj_afspraak`
 ADD PRIMARY KEY (`receptID`,`locatieID`,`datum`);

--
-- Indexen voor tabel `rhbj_locatie`
--
ALTER TABLE `rhbj_locatie`
 ADD PRIMARY KEY (`locatieID`);

--
-- Indexen voor tabel `rhbj_login`
--
ALTER TABLE `rhbj_login`
 ADD PRIMARY KEY (`userID`,`username`);

--
-- Indexen voor tabel `rhbj_medicatie`
--
ALTER TABLE `rhbj_medicatie`
 ADD PRIMARY KEY (`medicatieID`,`patientID`,`medicijnID`);

--
-- Indexen voor tabel `rhbj_medicijn`
--
ALTER TABLE `rhbj_medicijn`
 ADD PRIMARY KEY (`medicijnID`);

--
-- Indexen voor tabel `rhbj_pas`
--
ALTER TABLE `rhbj_pas`
 ADD PRIMARY KEY (`pasnummer`);

--
-- Indexen voor tabel `rhbj_patient`
--
ALTER TABLE `rhbj_patient`
 ADD PRIMARY KEY (`patientID`);

--
-- Indexen voor tabel `rhbj_recept`
--
ALTER TABLE `rhbj_recept`
 ADD PRIMARY KEY (`receptID`,`medicatieID`);

--
-- Indexen voor tabel `rhbj_ziekte`
--
ALTER TABLE `rhbj_ziekte`
 ADD PRIMARY KEY (`ziekteID`);

--
-- Indexen voor tabel `rhbj_ziekteoverzicht`
--
ALTER TABLE `rhbj_ziekteoverzicht`
 ADD PRIMARY KEY (`ziekteID`,`patientID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `rhbj_locatie`
--
ALTER TABLE `rhbj_locatie`
MODIFY `locatieID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_login`
--
ALTER TABLE `rhbj_login`
MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_medicatie`
--
ALTER TABLE `rhbj_medicatie`
MODIFY `medicatieID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_medicijn`
--
ALTER TABLE `rhbj_medicijn`
MODIFY `medicijnID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_pas`
--
ALTER TABLE `rhbj_pas`
MODIFY `pasnummer` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_patient`
--
ALTER TABLE `rhbj_patient`
MODIFY `patientID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_recept`
--
ALTER TABLE `rhbj_recept`
MODIFY `receptID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rhbj_ziekte`
--
ALTER TABLE `rhbj_ziekte`
MODIFY `ziekteID` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
