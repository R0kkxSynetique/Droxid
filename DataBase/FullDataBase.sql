-- --------------------------------------------------------

-- Hôte:                         127.0.0.1
-- Version du serveur:           8.0.25 - MySQL Community Server - GPL
-- SE du serveur:                Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Listage de la structure de la base pour droxid
DROP DATABASE IF EXISTS `droxid`;
CREATE DATABASE IF NOT EXISTS `droxid` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_bin */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `droxid`;

-- Listage de la structure de la table droxid. channels
DROP TABLE IF EXISTS `channels`;
CREATE TABLE IF NOT EXISTS `channels` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8mb4_bin NOT NULL,
  `guild_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_channels_guilds1_idx` (`guild_id`),

  CONSTRAINT `fk_channels_guilds1` FOREIGN KEY (`guild_id`) REFERENCES `guilds` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Listage des données de la table droxid.channels : ~29 rows (environ)
/*!40000 ALTER TABLE `channels` DISABLE KEYS */;
REPLACE INTO `channels` (`id`, `name`, `guild_id`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 'accueil', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 'idees', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 'discussion-generale', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 'streams', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(5, 'spam', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(6, 'infos-commandes', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(7, 'bots', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(8, 'rank', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(9, 'roles', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(10, 'luxhub', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(11, 'agenda', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(12, 'coaching', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(13, 'programming-chat', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(14, 'github-updates', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(15, 'free-games', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(16, 'game-choice', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(17, 'général', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(18, 'hello-et-bienvenue', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(19, 'les-règles', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(20, 'pour-la-commu', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(21, 'twitched', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(22, 'bot', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(23, 'demandes', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(24, 'privé', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(25, 'général', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(26, 'régles', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(27, 'papotage', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(28, 'clips', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(29, 'bot', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0);
/*!40000 ALTER TABLE `channels` ENABLE KEYS */;

-- Listage de la structure de la table droxid. guilds
DROP TABLE IF EXISTS `guilds`;
CREATE TABLE IF NOT EXISTS `guilds` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8mb4_bin NOT NULL,
  `owner_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  `isPrivate` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_guilds_users1_idx` (`owner_id`),

  CONSTRAINT `fk_guilds_users1` FOREIGN KEY (`owner_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Listage des données de la table droxid.guilds : ~4 rows (environ)
/*!40000 ALTER TABLE `guilds` DISABLE KEYS */;
REPLACE INTO `guilds` (`id`, `name`, `owner_id`, `created_at`, `updated_at`, `deleted`, `isPrivate`) VALUES
	(1, 'Server.sh', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0, 1),
	(2, '#LetMePost', 13, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0, 1),
	(3, 'R0kkx Team', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0, 1),
	(4, 'R0kkxRyuk', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0, 1);
/*!40000 ALTER TABLE `guilds` ENABLE KEYS */;

-- Listage de la structure de la table droxid. guilds_has_users
DROP TABLE IF EXISTS `guilds_has_users`;
CREATE TABLE IF NOT EXISTS `guilds_has_users` (
  `guilds_id` int NOT NULL,
  `users_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`guilds_id`,`users_id`),
  KEY `fk_guilds_has_users_users1_idx` (`users_id`),
  KEY `fk_guilds_has_users_guilds_idx` (`guilds_id`),
  CONSTRAINT `fk_guilds_has_users_guilds` FOREIGN KEY (`guilds_id`) REFERENCES `guilds` (`id`),
  CONSTRAINT `fk_guilds_has_users_users1` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;


-- Listage des données de la table droxid.guilds_has_users : ~23 rows (environ)
/*!40000 ALTER TABLE `guilds_has_users` DISABLE KEYS */;
REPLACE INTO `guilds_has_users` (`guilds_id`, `users_id`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 9, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 11, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(1, 13, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 13, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 13, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0);
/*!40000 ALTER TABLE `guilds_has_users` ENABLE KEYS */;

-- Listage de la structure de la table droxid. messages
DROP TABLE IF EXISTS `messages`;
CREATE TABLE IF NOT EXISTS `messages` (
  `id` int NOT NULL AUTO_INCREMENT,
  `content` mediumtext COLLATE utf8mb4_bin NOT NULL,
  `channel_id` int NOT NULL,
  `user_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_messages_channels1_idx` (`channel_id`),
  KEY `fk_messages_users1_idx` (`user_id`),
  CONSTRAINT `fk_messages_channels1` FOREIGN KEY (`channel_id`) REFERENCES `channels` (`id`),
  CONSTRAINT `fk_messages_users1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Listage des données de la table droxid.messages : ~100 rows (environ)
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
REPLACE INTO `messages` (`id`, `content`, `channel_id`, `user_id`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 'Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante.', 28, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 'Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus. Curabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla.', 29, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 'Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl.', 3, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 'Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl.', 1, 9, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(5, 'In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', 25, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(6, 'In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.', 28, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(7, 'Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante.', 27, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(8, 'Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.', 1, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(9, 'Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.', 20, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(10, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.', 18, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(11, 'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque. Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla.', 21, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(12, 'In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.', 5, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(13, 'Vivamus vel nulla eget eros elementum pellentesque. Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis.', 3, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(14, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl. Duis ac nibh.', 24, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(15, 'Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius. Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi. Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus.', 20, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(16, 'Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.', 5, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(17, 'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', 2, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(18, 'Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat.', 12, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(19, 'Aliquam non mauris. Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.', 13, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(20, 'Vivamus vel nulla eget eros elementum pellentesque. Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis.', 10, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(21, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti. Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.', 25, 13, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(22, 'Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.', 13, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(23, 'Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.', 12, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(24, 'Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.', 24, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(25, 'Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst.', 27, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(26, 'Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.', 18, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(27, 'Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.', 26, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(28, 'Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.', 24, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(29, 'Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.', 17, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(30, 'Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.', 8, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(31, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.', 6, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(32, 'Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.', 13, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(33, 'Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', 20, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(34, 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem. Sed sagittis.', 18, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(35, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 8, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(36, 'Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus.', 12, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(37, 'Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.', 2, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(38, 'Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.', 7, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(39, 'Suspendisse potenti. Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris. Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl.', 21, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(40, 'Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus. Curabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla.', 20, 12, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(41, 'Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl.', 26, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(42, 'Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.', 1, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(43, 'Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst. Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst.', 2, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(44, 'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio. Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', 7, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(45, 'Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.', 28, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(46, 'Aenean lectus.', 24, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(47, 'Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus.', 27, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(48, 'Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', 21, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(49, 'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat.', 24, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(50, 'Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.', 20, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(51, 'Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', 18, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(52, 'Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus. Suspendisse potenti.', 12, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(53, 'Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.', 19, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(54, 'Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat.', 17, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(55, 'Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', 27, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(56, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.', 2, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(57, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna.', 24, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(58, 'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio. Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.', 12, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(59, 'Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', 1, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(60, 'Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.', 26, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(61, 'Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti.', 26, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(62, 'Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo.', 2, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(63, 'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.', 28, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(64, 'Pellentesque eget nunc.', 23, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(65, 'Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.', 24, 9, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(66, 'Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.', 10, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(67, 'Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui.', 2, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(68, 'Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.', 26, 9, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(69, 'Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus.', 18, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(70, 'Donec vitae nisi.', 25, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(71, 'Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.', 8, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(72, 'Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.', 6, 9, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(73, 'Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.', 17, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(74, 'In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.', 13, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(75, 'Morbi porttitor lorem id ligula.', 7, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(76, 'Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.', 11, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(77, 'Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', 15, 11, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(78, 'Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl.', 6, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(79, 'Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla.', 4, 6, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(80, 'Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna.', 10, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(81, 'Etiam faucibus cursus urna. Ut tellus.', 22, 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(82, 'Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl.', 25, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(83, 'Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl.', 15, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(84, 'Cras in purus eu magna vulputate luctus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia.', 28, 10, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(85, 'Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue.', 10, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(86, 'Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.', 23, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(87, 'Curabitur gravida nisi at nibh.', 13, 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(88, 'Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo.', 17, 11, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(89, 'Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.', 7, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(90, 'Donec vitae nisi. Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus. Curabitur at ipsum ac tellus semper interdum.', 2, 9, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(91, 'Phasellus sit amet erat.', 15, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(92, 'Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui.', 6, 7, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(93, 'Donec posuere metus vitae ipsum. Aliquam non mauris. Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl.', 24, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(94, 'Cras in purus eu magna vulputate luctus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue.', 16, 11, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(95, 'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.', 28, 8, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(96, 'Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque. Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui.', 24, 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(97, 'Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo.', 28, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(98, 'Pellentesque at nulla.', 27, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(99, 'Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.', 4, 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(100, 'Phasellus sit amet erat. Nulla tempus.', 13, 5, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0);
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;

-- Listage de la structure de la table droxid. permissions
DROP TABLE IF EXISTS `permissions`;
CREATE TABLE IF NOT EXISTS `permissions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8mb4_bin NOT NULL,
  `description` mediumtext COLLATE utf8mb4_bin NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Dumping data for table droxid.permissions: ~6 rows (approximately)
/*!40000 ALTER TABLE `permissions` DISABLE KEYS */;
REPLACE INTO `permissions` (`id`, `name`, `description`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 'Envoyer des messages', 'Permet aux membres d\'envoyer des messages', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 'Voir les channels', 'Permet aux utilisateurs de voir les channels', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 'Gérer les channels', 'Permet aux membres de créer, modifier ou supp', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 'Gérer les rôles', 'Permet aux membres de créer, modifier ou supp', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(5, 'Gérer la guilde', 'Permet aux membres de modifier la guilde.', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(6, 'Gérer les messages', 'Permet aux membres de supprimer les messages', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0);
/*!40000 ALTER TABLE `permissions` ENABLE KEYS */;

-- Listage de la structure de la table droxid. roles
DROP TABLE IF EXISTS `roles`;
CREATE TABLE IF NOT EXISTS `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8mb4_bin NOT NULL,
  `guilds_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_roles_guilds1_idx` (`guilds_id`),
  CONSTRAINT `fk_roles_guilds1` FOREIGN KEY (`guilds_id`) REFERENCES `guilds` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Dumping data for table droxid.roles: ~21 rows (approximately)
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
REPLACE INTO `roles` (`id`, `name`, `guilds_id`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 'MonCorp', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 'Staff', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 'Admin', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 'Bots', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(5, 'Alcoolique annonyme', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(6, 'Simp Lord', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(7, 'Sheep', 1, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(8, 'Participant', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(9, 'Bot', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(10, 'Owner', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(11, 'Prisonnier politique', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(12, 'résistant', 2, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(13, 'Le big boss', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(14, 'Le ptit soufifre du boss', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(15, 'Gars inutile mais là quand même', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(16, 'Membre de la team', 3, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(17, 'Admin', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(18, 'Bot', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(19, 'Membres', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(20, 'Modos', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(21, 'Bota testeur', 4, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;

-- Listage de la structure de la table droxid. roles_has_permissions
DROP TABLE IF EXISTS `roles_has_permissions`;
CREATE TABLE IF NOT EXISTS `roles_has_permissions` (
  `roles_id` int NOT NULL,
  `permissions_id` int NOT NULL,
  `channels_id` int DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`roles_id`,`permissions_id`),
  KEY `fk_roles_has_permissions_permissions1_idx` (`permissions_id`),
  KEY `fk_roles_has_permissions_roles1_idx` (`roles_id`),
  KEY `fk_roles_has_permissions_channels1_idx` (`channels_id`),
  CONSTRAINT `fk_roles_has_permissions_channels1` FOREIGN KEY (`channels_id`) REFERENCES `channels` (`id`),
  CONSTRAINT `fk_roles_has_permissions_permissions1` FOREIGN KEY (`permissions_id`) REFERENCES `permissions` (`id`),
  CONSTRAINT `fk_roles_has_permissions_roles1` FOREIGN KEY (`roles_id`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Listage des données de la table droxid.roles_has_permissions : ~34 rows (environ)
/*!40000 ALTER TABLE `roles_has_permissions` DISABLE KEYS */;
REPLACE INTO `roles_has_permissions` (`roles_id`, `permissions_id`, `channels_id`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(1, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(1, 3, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(1, 4, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(1, 5, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(1, 6, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(2, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(2, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(2, 3, 3, '2022-01-21 08:29:08', '2022-01-24 16:01:53', 0),
	(2, 4, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(2, 6, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(3, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(3, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(3, 3, NULL, '2022-01-24 16:04:00', '2022-01-24 16:04:00', 0),
	(3, 4, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(3, 5, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(3, 6, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(4, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(4, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(4, 3, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(4, 6, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(5, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(5, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(6, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(6, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(7, 1, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(7, 2, NULL, '2022-01-21 08:29:08', '2022-01-21 08:29:08', 0),
	(8, 2, NULL, '2022-01-21 08:34:37', '2022-01-21 08:34:37', 0),
	(13, 2, NULL, '2022-01-21 08:35:04', '2022-01-21 08:35:04', 0),
	(17, 1, NULL, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(17, 5, NULL, '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(20, 1, NULL, '2022-01-21 08:35:44', '2022-01-21 08:35:44', 0),
	(20, 2, NULL, '2022-01-21 08:35:32', '2022-01-21 08:35:32', 0),
	(20, 6, NULL, '2022-01-21 08:35:57', '2022-01-21 08:35:57', 0);
/*!40000 ALTER TABLE `roles_has_permissions` ENABLE KEYS */;

-- Listage de la structure de la table droxid. users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) COLLATE utf8mb4_bin NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Dumping data for table droxid.users: ~13 rows (approximately)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
REPLACE INTO `users` (`id`, `username`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 'R0kkxSynetique', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(2, 'R0kkxRyuk', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(3, 'R0kkxDragon', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(4, 'Mon', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(5, 'MonDotOsz', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(6, 'FMM Mon', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(7, 'Cip04lol', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(8, 'Cip04', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(9, 'Beusis', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(10, 'RustyBarley', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(11, 'Labello03', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(12, 'R0kkxBalançoire', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0),
	(13, 'VicVicMat', '2022-01-24 13:10:20', '2022-01-24 13:10:20', 0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Listage de la structure de la table droxid. users_has_roles
DROP TABLE IF EXISTS `users_has_roles`;
CREATE TABLE IF NOT EXISTS `users_has_roles` (
  `users_id` int NOT NULL,
  `roles_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deleted` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`users_id`,`roles_id`),
  KEY `fk_Users_has_Roles_Roles1_idx` (`roles_id`),
  KEY `fk_Users_has_Roles_Users1_idx` (`users_id`),
  CONSTRAINT `fk_users_has_roles_roles1` FOREIGN KEY (`roles_id`) REFERENCES `roles` (`id`),
  CONSTRAINT `fk_users_has_roles_users1` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- Listage des données de la table droxid.users_has_roles : ~12 rows (environ)
/*!40000 ALTER TABLE `users_has_roles` DISABLE KEYS */;
REPLACE INTO `users_has_roles` (`users_id`, `roles_id`, `created_at`, `updated_at`, `deleted`) VALUES
	(1, 2, '2022-01-14 09:29:47', '2022-01-14 09:29:47', 0),
	(1, 3, '2022-01-18 14:54:07', '2022-01-18 14:54:08', 0),
	(1, 8, '2022-01-21 08:37:10', '2022-01-21 08:37:10', 0),
	(1, 13, '2022-01-21 08:36:44', '2022-01-21 08:36:44', 0),
	(1, 17, '2022-01-17 14:02:31', '2022-01-17 14:02:32', 0),
	(1, 20, '2022-01-21 08:36:57', '2022-01-21 08:36:57', 0),
	(2, 5, '2022-01-14 09:29:47', '2022-01-14 09:29:47', 0),
	(2, 6, '2022-01-14 09:29:47', '2022-01-14 09:29:47', 0),
	(4, 1, '2022-01-14 09:29:47', '2022-01-14 09:29:47', 0),
	(9, 7, '2022-01-14 09:29:47', '2022-01-14 09:29:47', 0),
	(11, 17, '2022-01-17 14:03:13', '2022-01-17 14:03:14', 0),
	(13, 10, '2022-01-14 09:29:47', '2022-01-14 09:29:47', 0);
/*!40000 ALTER TABLE `users_has_roles` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
