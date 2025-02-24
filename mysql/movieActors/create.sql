CREATE TABLE
	movieActors (
		movieId int (11) NOT NULL COMMENT 'Movie Id',
		actorId int (11) NOT NULL COMMENT 'Actor Id',
		PRIMARY KEY movieId (movieId, actorId),
		FOREIGN KEY (movieId) REFERENCES movies (id),
		FOREIGN KEY (actorId) REFERENCES actors (id)
	) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_bin COMMENT = 'Movie actors';