# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.6.38)
# Database: webshop
# Generation Time: 2018-04-12 11:55:02 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table Cart
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Cart`;

CREATE TABLE `Cart` (
  `cart_item_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` int(11) DEFAULT NULL,
  `cart_id` text,
  PRIMARY KEY (`cart_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

LOCK TABLES `Cart` WRITE;
/*!40000 ALTER TABLE `Cart` DISABLE KEYS */;

INSERT INTO `Cart` (`cart_item_id`, `product_id`, `cart_id`)
VALUES
	(115,2,'0a15cb6c-baf2-4b1e-8d37-0a73281a2346'),
	(116,2,'0a15cb6c-baf2-4b1e-8d37-0a73281a2346'),
	(117,3,'0a15cb6c-baf2-4b1e-8d37-0a73281a2346'),
	(118,2,'a572f9aa-eb08-42d4-9211-9b13f1885c0d'),
	(119,1,'59852c80-48b3-4b61-b865-7caadd763a4a'),
	(120,1,'15c4c9ea-7b45-4609-bb3d-6111fae5373b'),
	(121,1,'29166fc3-fc74-4b12-8ef8-ec12b772fa7a'),
	(122,1,'e875a687-31b4-4c08-898c-5bfcd8046d7f'),
	(123,2,'7d180bc1-9fc9-4eec-b5c9-85957668cc43'),
	(124,3,'7d180bc1-9fc9-4eec-b5c9-85957668cc43'),
	(125,1,'6eaa0681-f820-4002-b3fd-cb50b3e4bcbb'),
	(126,4,'6eaa0681-f820-4002-b3fd-cb50b3e4bcbb'),
	(127,1,'d42c477f-21dd-468b-bd05-621fe6af5d10'),
	(128,1,'d42c477f-21dd-468b-bd05-621fe6af5d10'),
	(129,2,'f05f6f37-7e20-4e0d-a181-48ddbeecef67'),
	(130,2,'62ea4253-5943-4792-b00f-ed54dc80f7f3'),
	(131,3,'5b51a87a-e4f7-4478-ba1b-87525b209f5d'),
	(132,1,'5b51a87a-e4f7-4478-ba1b-87525b209f5d');

/*!40000 ALTER TABLE `Cart` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table OrderInfo
# ------------------------------------------------------------

DROP TABLE IF EXISTS `OrderInfo`;

CREATE TABLE `OrderInfo` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `order_id` text,
  `cat_battle_armor` int(11) DEFAULT NULL,
  `cage_face_mug` int(11) DEFAULT NULL,
  `unicorn` int(11) DEFAULT NULL,
  `prosecco_pong` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

LOCK TABLES `OrderInfo` WRITE;
/*!40000 ALTER TABLE `OrderInfo` DISABLE KEYS */;

INSERT INTO `OrderInfo` (`id`, `order_id`, `cat_battle_armor`, `cage_face_mug`, `unicorn`, `prosecco_pong`)
VALUES
	(18,'3b7d7c58-c4fd-4818-815f-167bf1c055bc',0,1,0,0),
	(19,'11cf9576-48d1-40d2-8f09-199dd04bdc83',1,0,0,0),
	(20,'0a15cb6c-baf2-4b1e-8d37-0a73281a2346',0,2,1,0),
	(21,'a572f9aa-eb08-42d4-9211-9b13f1885c0d',0,1,0,0),
	(22,'15c4c9ea-7b45-4609-bb3d-6111fae5373b',1,0,0,0),
	(23,'29166fc3-fc74-4b12-8ef8-ec12b772fa7a',1,0,0,0),
	(24,'7d180bc1-9fc9-4eec-b5c9-85957668cc43',0,1,1,0),
	(25,'6eaa0681-f820-4002-b3fd-cb50b3e4bcbb',1,0,0,1),
	(26,'d42c477f-21dd-468b-bd05-621fe6af5d10',2,0,0,0),
	(27,'f05f6f37-7e20-4e0d-a181-48ddbeecef67',0,1,0,0),
	(28,'62ea4253-5943-4792-b00f-ed54dc80f7f3',0,1,0,0),
	(29,'5b51a87a-e4f7-4478-ba1b-87525b209f5d',1,0,1,0);

/*!40000 ALTER TABLE `OrderInfo` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Orders
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Orders`;

CREATE TABLE `Orders` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `customer_name` text,
  `address` text,
  `creditcard` int(11) DEFAULT NULL,
  `cost` int(11) DEFAULT NULL,
  `cart_id` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

LOCK TABLES `Orders` WRITE;
/*!40000 ALTER TABLE `Orders` DISABLE KEYS */;

INSERT INTO `Orders` (`id`, `customer_name`, `address`, `creditcard`, `cost`, `cart_id`)
VALUES
	(57,'Abbe','Abbegatan',123,5,'3b7d7c58-c4fd-4818-815f-167bf1c055bc'),
	(58,'Crille','Humlekärret 45',1234,100000,'11cf9576-48d1-40d2-8f09-199dd04bdc83'),
	(59,'Maja','MAjavägen 15',123456,160,'0a15cb6c-baf2-4b1e-8d37-0a73281a2346'),
	(60,'Anders','Addevägen',123,5,'a572f9aa-eb08-42d4-9211-9b13f1885c0d'),
	(61,'Maja','Majavägen',123,100000,'15c4c9ea-7b45-4609-bb3d-6111fae5373b'),
	(62,'Crippa','Crippavägen',123456,100000,'29166fc3-fc74-4b12-8ef8-ec12b772fa7a'),
	(63,'Crippa Mattsson','Humlekärret 45',123456,155,'7d180bc1-9fc9-4eec-b5c9-85957668cc43'),
	(64,'Christopher Mattsson','Humlekärret 45',45680293,100023,'6eaa0681-f820-4002-b3fd-cb50b3e4bcbb'),
	(65,'Dennis','Dennisgatan 12',123456,200000,'d42c477f-21dd-468b-bd05-621fe6af5d10'),
	(66,'Gabbe Aanesen','Gabbevägen 1',456234,5,'f05f6f37-7e20-4e0d-a181-48ddbeecef67'),
	(67,'Maja','MAjavägen 15',123,5,'62ea4253-5943-4792-b00f-ed54dc80f7f3'),
	(68,'William Mattsson','Humlekärret 45',666666666,10150,'5b51a87a-e4f7-4478-ba1b-87525b209f5d');

/*!40000 ALTER TABLE `Orders` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Things
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Things`;

CREATE TABLE `Things` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `name` text,
  `slug` text,
  `info` text,
  `price` int(11) DEFAULT NULL,
  `img` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

LOCK TABLES `Things` WRITE;
/*!40000 ALTER TABLE `Things` DISABLE KEYS */;

INSERT INTO `Things` (`id`, `name`, `slug`, `info`, `price`, `img`)
VALUES
	(1,'Cat Battle Armor','cat-battle-armor','If your cat spends any time out in the wild it’s time to level them up with this cat battle armor. Your cat will be a hero in this custom made flexible armor harness made out of veg-tan leather.\n\nNote: it’s not recommended to keep this on your cat',10000,'https://img.etsystatic.com/il/435860/548391270/il_570xN.548391270_ropy.jpg?version=0'),
	(2,'Nicolas Cage Face Mug','nicolas-cage-face-mug','If you’re a fan of our National Treasure Nicolas Cage this kick-a** mug is for you. Your coffee will be gone in 60 seconds while you’re drinking from this cup.\n\nAnd as a plus it’s dishwasher safe! so you’ll never ruin Nicholas’ face.',5,'https://img0.etsystatic.com/177/0/11204714/il_570xN.1138216472_eqpc.jpg'),
	(3,'Giant Inflatable Unicorn','giant-inflatable-unicorn','It’s a horse, no it’s a zebra, no it’s your own 7 foot Giant Inflatable Unicorn. You’ll be the talk of the town with this far out unicorn. Be the first in your neighborhood to have this mythical character. With his pink hooves and colorful mane and tail, he’ll be the perfect guest anywhere. He’s completely potty trained and makes a great pet. Have fun now!',150,'https://media.firebox.com/product/7857/column_grid_10/giant-inflatable-unicorn_23933.jpg'),
	(4,'Prosecco Pong','prosecco-pong','Frat party beer pong not your forte? That’s ok! Here’s a more sophisticated way to have fun drinking with friends at your next soiree.\n\nProsecco Pong is the drinking game with class. The point isn’t to get drunk off your ass! Just a nice night of drinking entertainment among civilized friends. Because hey —us adults don’t get schnockered, right? We just get pleasantly tipsy',23,'https://media.firebox.com/product/8260/extra2_column_grid_10/prosecco-pong_28736.jpg');

/*!40000 ALTER TABLE `Things` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
