DROP PROCEDURE IF EXISTS insert_movie;

DELIMITER $$
$$
CREATE PROCEDURE insert_movie(movieName VARCHAR(100))
BEGIN
  INSERT INTO movies (name) VALUES (movieName);
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE insert_movie
-- CALL insert_movie('Test')
