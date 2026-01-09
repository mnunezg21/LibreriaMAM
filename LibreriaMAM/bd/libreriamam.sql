-- phpMyAdmin SQL Dump
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `libreriamam`
--
CREATE DATABASE IF NOT EXISTS `libreriamam` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `libreriamam`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tfactura`
--

CREATE TABLE `tfactura` (
  `CodFactura` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `Cliente` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `FechaFactura` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Borrado` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `tfactura`
--

INSERT INTO `tfactura` (`CodFactura`, `Cliente`, `FechaFactura`, `Borrado`) VALUES
('fac001', 'cliente', '10/01/2026', '0'),
('fac002', 'sergio', '15/01/2026', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tgenero`
--

CREATE TABLE `tgenero` (
  `Genero` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `Imagen` text COLLATE utf8_unicode_ci NOT NULL,
  `Borrado` varchar(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `tgenero`
--

INSERT INTO `tgenero` (`Genero`, `Imagen`, `Borrado`) VALUES
('Fantasía', 'https://imagessl4.casadellibro.com/a/l/s7/64/9791387629564.webp', '0'),
('Novela Histórica', 'https://imagessl6.casadellibro.com/a/l/t5/01/9788466682701.jpg', '0'),
('Terror', 'https://imagessl2.casadellibro.com/a/l/t5/97/9788418431197.jpg', '0'),

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tlineafactura`
--

CREATE TABLE `tlineafactura` (
  `CodFactura` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `CodLibro` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `Cantidad` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Total` varchar(25) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `tlineafactura`
--

INSERT INTO `tlineafactura` (`CodFactura`, `CodLibro`, `Cantidad`, `Total`) VALUES
('fac001', 'lib001', '1', '25'),
('fac001', 'lib003', '2', '40');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tusuario`
--

CREATE TABLE `tusuario` (
  `CodUsuario` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `Nick` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `Pass` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `Rol` varchar(10) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `tusuario`
--

INSERT INTO `tusuario` (`CodUsuario`, `Nick`, `Pass`, `Rol`) VALUES
('cod001', 'admin', '123', 'admin'),
('cod002', 'cliente', '123', 'user');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tlibro`
--

CREATE TABLE `tlibro` (
  `CodLibro` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `Autor` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Titulo` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Genero` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `FechaPublicacion` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Paginas` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Precio` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Formatouno` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Formatodos` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Formatotres` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Estado` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Imagen` text COLLATE utf8_unicode_ci NOT NULL,
  `Borrado` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;
-- Indices de la tabla `tfactura`
--
ALTER TABLE `tfactura`
  ADD PRIMARY KEY (`CodFactura`),
  ADD KEY `usuario` (`Cliente`);

--
-- Indices de la tabla `tgenero`
--
ALTER TABLE `tgenero`
  ADD PRIMARY KEY (`Genero`),
  ADD UNIQUE KEY `genero` (`Genero`);

--
-- Indices de la tabla `tlineafactura`
--
ALTER TABLE `tlineafactura`
  ADD PRIMARY KEY (`CodFactura`,`CodLibro`);

--
-- Indices de la tabla `tusuario`
--
ALTER TABLE `tusuario`
  ADD PRIMARY KEY (`CodUsuario`),
  ADD UNIQUE KEY `nick` (`Nick`);

--
-- Indices de la tabla `tlibro`
--
ALTER TABLE `tlibro`
  ADD PRIMARY KEY (`CodLibro`),
  ADD KEY `Genero` (`Genero`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;