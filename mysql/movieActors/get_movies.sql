DROP PROCEDURE IF EXISTS get_movies;

DELIMITER $$
$$
CREATE PROCEDURE get_movies(skip INT, take INT)
BEGIN
  SELECT
    m.id,
    m.name,
    GROUP_CONCAT(a.name) AS `actors`
  FROM
    movies m
    INNER JOIN movieActors ma ON ma.movieId = m.id
    INNER JOIN actors a ON a.id = ma.actorId
  GROUP BY
    m.id
  LIMIT
    take
  OFFSET
    skip;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE get_movies
-- CALL get_movies(0, 10)
