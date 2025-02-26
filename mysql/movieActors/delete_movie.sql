DROP PROCEDURE IF EXISTS delete_movie;

DELIMITER $$
$$
CREATE PROCEDURE delete_movie(movie_id INT)
BEGIN
	-- delete all actors in this movie
	DELETE FROM movieActors WHERE movieId = movie_id;
	
	-- delete movie
 	DELETE FROM movies WHERE id = movie_id;
	-- for ef core FromSqlRaw
	SELECT movie_id AS id, '' AS name, '' AS actors;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE delete_movie
-- CALL delete_movie(1999)
