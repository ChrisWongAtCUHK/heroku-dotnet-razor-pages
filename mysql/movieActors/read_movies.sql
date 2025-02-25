DROP PROCEDURE IF EXISTS read_movies;

DELIMITER $$
$$
CREATE PROCEDURE read_movies(skip INT, take INT)
BEGIN
  SELECT
    m.id,
    m.name,
    GROUP_CONCAT(a.name) AS `actors`
  FROM
    movies m
    LEFT JOIN movieActors ma ON ma.movieId = m.id
    LEFT JOIN actors a ON a.id = ma.actorId
  GROUP BY
    m.id
  LIMIT
    take
  OFFSET
    skip;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE read_movies
-- CALL read_movies(0, 10)
