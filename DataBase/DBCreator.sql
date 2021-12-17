-- MySQL Script generated by MySQL Workbench
-- Thu Dec 16 12:21:43 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema droxid
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `droxid` ;

-- -----------------------------------------------------
-- Schema droxid
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `droxid` DEFAULT CHARACTER SET utf16 ;
USE `droxid` ;

-- -----------------------------------------------------
-- Table `droxid`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`guilds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`guilds` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `owner_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_guilds_users1_idx` (`owner_id` ASC) VISIBLE,
  CONSTRAINT `fk_guilds_users1`
    FOREIGN KEY (`owner_id`)
    REFERENCES `droxid`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`roles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `guilds_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_roles_guilds1_idx` (`guilds_id` ASC) VISIBLE,
  CONSTRAINT `fk_roles_guilds1`
    FOREIGN KEY (`guilds_id`)
    REFERENCES `droxid`.`guilds` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`channels`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`channels` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `guild_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_channels_guilds1_idx` (`guild_id` ASC) VISIBLE,
  CONSTRAINT `fk_channels_guilds1`
    FOREIGN KEY (`guild_id`)
    REFERENCES `droxid`.`guilds` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`messages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`messages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `content` MEDIUMTEXT NOT NULL,
  `channel_id` INT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_messages_channels1_idx` (`channel_id` ASC) VISIBLE,
  INDEX `fk_messages_users1_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_messages_channels1`
    FOREIGN KEY (`channel_id`)
    REFERENCES `droxid`.`channels` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_messages_users1`
    FOREIGN KEY (`user_id`)
    REFERENCES `droxid`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`guilds_has_users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`guilds_has_users` (
  `guilds_id` INT NOT NULL,
  `users_id` INT NOT NULL,
  PRIMARY KEY (`guilds_id`, `users_id`),
  INDEX `fk_guilds_has_users_users1_idx` (`users_id` ASC) VISIBLE,
  INDEX `fk_guilds_has_users_guilds_idx` (`guilds_id` ASC) VISIBLE,
  CONSTRAINT `fk_guilds_has_users_guilds`
    FOREIGN KEY (`guilds_id`)
    REFERENCES `droxid`.`guilds` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_guilds_has_users_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `droxid`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`permissions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`permissions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `description` MEDIUMTEXT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`users_has_roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`users_has_roles` (
  `users_id` INT NOT NULL,
  `roles_id` INT NOT NULL,
  PRIMARY KEY (`users_id`, `roles_id`),
  INDEX `fk_Users_has_Roles_Roles1_idx` (`roles_id` ASC) VISIBLE,
  INDEX `fk_Users_has_Roles_Users1_idx` (`users_id` ASC) VISIBLE,
  CONSTRAINT `fk_users_has_roles_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `droxid`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_users_has_roles_roles1`
    FOREIGN KEY (`roles_id`)
    REFERENCES `droxid`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `droxid`.`roles_has_permissions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `droxid`.`roles_has_permissions` (
  `roles_id` INT NOT NULL,
  `permissions_id` INT NOT NULL,
  `channels_id` INT NULL,
  PRIMARY KEY (`roles_id`, `permissions_id`),
  INDEX `fk_roles_has_permissions_permissions1_idx` (`permissions_id` ASC) VISIBLE,
  INDEX `fk_roles_has_permissions_roles1_idx` (`roles_id` ASC) VISIBLE,
  INDEX `fk_roles_has_permissions_channels1_idx` (`channels_id` ASC) VISIBLE,
  CONSTRAINT `fk_roles_has_permissions_roles1`
    FOREIGN KEY (`roles_id`)
    REFERENCES `droxid`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_roles_has_permissions_permissions1`
    FOREIGN KEY (`permissions_id`)
    REFERENCES `droxid`.`permissions` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_roles_has_permissions_channels1`
    FOREIGN KEY (`channels_id`)
    REFERENCES `droxid`.`channels` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
