DROP PROCEDURE IF EXISTS get_movie;

DELIMITER $$
$$
CREATE PROCEDURE get_movie(findId INT)
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
-- SHOW CREATE PROCEDURE get_movie
-- CALL get_movie(1)
