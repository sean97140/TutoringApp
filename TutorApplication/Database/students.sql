-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 30, 2012 at 12:22 AM
-- Server version: 5.5.24-log
-- PHP Version: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `students`
--

-- --------------------------------------------------------

--
-- Table structure for table `demographics`
--

CREATE TABLE IF NOT EXISTS `demographics` (
  `id` int(30) NOT NULL AUTO_INCREMENT,
  `f_name` text,
  `mi` text,
  `l_name` text,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `id_2` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=955424 ;

--
-- Dumping data for table `demographics`
--

INSERT INTO `demographics` (`id`, `f_name`, `mi`, `l_name`) VALUES
(1, 'Sean', 'P', 'Mahan'),
(955142, 'Sean', 'P', 'Mahan'),
(955423, 'Sean', 'P', 'Mahan');

-- --------------------------------------------------------

--
-- Table structure for table `passwords`
--

CREATE TABLE IF NOT EXISTS `passwords` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `password` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `subjectinfo`
--

CREATE TABLE IF NOT EXISTS `subjectinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `subject1` text NOT NULL,
  `subject2` text NOT NULL,
  `subject3` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=955143 ;

--
-- Dumping data for table `subjectinfo`
--

INSERT INTO `subjectinfo` (`id`, `subject1`, `subject2`, `subject3`) VALUES
(1, 'Math', 'Comp Sci', '0'),
(955142, 'Math', 'Computer Science', 'Chemistry');

-- --------------------------------------------------------

--
-- Table structure for table `tutorsskype`
--

CREATE TABLE IF NOT EXISTS `tutorsskype` (
  `name` text NOT NULL,
  `skypeID` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tutorsskype`
--

INSERT INTO `tutorsskype` (`name`, `skypeID`) VALUES
('Azad', 'azadseanbogolubov@gmail.com'),
('Sean', 'sean97140@gmail.com');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
