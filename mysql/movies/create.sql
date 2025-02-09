CREATE TABLE
  `movies` (
    `id` int (11) NOT NULL AUTO_INCREMENT,
    `name` varchar(100) CHARACTER
    SET
      utf8mb4 NOT NULL,
      `actors` varchar(100) CHARACTER
    SET
      utf8mb4 NOT NULL,
      PRIMARY KEY (`id`)
  ) ENGINE = InnoDB AUTO_INCREMENT = 11 DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_bin COMMENT = 'movies'