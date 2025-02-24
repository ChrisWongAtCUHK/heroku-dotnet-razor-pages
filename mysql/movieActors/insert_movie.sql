DROP PROCEDURE IF EXISTS insert_movie;

DELIMITER $$
$$
CREATE PROCEDURE insert_movie(movieName VARCHAR(100), actors VARCHAR(65535))
BEGIN
	DECLARE remainder TEXT;
	DECLARE delimiter CHAR(1);
	DECLARE pos INT DEFAULT 1 ;
	DECLARE str VARCHAR(1000);
	DECLARE query varchar(65535);

 	-- INSERT INTO movies (name) VALUES (movieName);

 	SET delimiter = ',';
	SET remainder = actors;
	SET query = 'INSERT INTO actors (name) VALUES ';  
	
	WHILE CHAR_LENGTH(remainder) > 0 AND pos > 0 DO
		SET pos = INSTR(remainder, `Delimiter`);
		IF pos = 0 THEN
			SET str = remainder;
		ELSE
			SET str = LEFT(remainder, pos - 1);
		END IF;
		SET str = TRIM(str);
		IF  str != '' THEN
			BEGIN
				SET @count = (SELECT COUNT(*) FROM actors WHERE name = str);
				IF @count = 0 THEN
					SET query = CONCAT(query, '(\'', str, '\'), ');
				END IF;
			END;
		END IF;
		
		SET remainder = SUBSTRING(remainder, pos + 1);
	END WHILE;
	
	SET query = LEFT(query, CHAR_LENGTH(query) - 1);
	SELECT query;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE insert_movie
-- CALL insert_movie('Test movie', 'Actor 1, Actor 2, Actor 3')
