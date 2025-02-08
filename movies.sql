CREATE TABLE
  `movies` (
    `id` int (11) IDENTITY (1, 1) NOT NULL,
    `name` varchar(100) CHARACTER
    SET
      utf8mb4 NOT NULL,
      `actors` varchar(100) CHARACTER
    SET
      utf8mb4 NOT NULL,
      PRIMARY KEY (`id`)
  ) ENGINE = InnoDB AUTO_INCREMENT = 11 DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_bin COMMENT = 'movies'
INSERT INTO 
  movies (id, name, actors)
VALUES
  (1, 'Movie 1', 'actorA, actorB'),
  (2, 'Movie 2', 'actorC, actorD'),
  (3, 'Movie 3', 'actorE, actorF')