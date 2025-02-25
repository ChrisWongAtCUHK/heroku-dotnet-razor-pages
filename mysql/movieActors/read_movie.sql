DROP PROCEDURE IF EXISTS read_movie;

DELIMITER $$
$$
CREATE PROCEDURE read_movie(findId INT)
BEGIN
  SELECT
    m.id,
    m.name,
    GROUP_CONCAT(a.name) AS `actors`
  FROM
    movies m
    LEFT JOIN movieActors ma ON ma.movieId = m.id
    LEFT JOIN actors a ON a.id = ma.actorId
   WHERE m.id = findId
  GROUP BY
    m.id;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE read_movie
-- CALL read_movie(1)
