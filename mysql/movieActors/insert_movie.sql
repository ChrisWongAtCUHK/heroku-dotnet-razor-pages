DROP PROCEDURE IF EXISTS insert_movie;

DELIMITER $$
$$
CREATE PROCEDURE insert_movie(movie_name VARCHAR(100), actors VARCHAR(65535))
BEGIN
	DECLARE movie_id INT;
	DECLARE remainder TEXT;
	DECLARE delimiter CHAR(1);
	DECLARE pos INT DEFAULT 1 ;
	DECLARE str VARCHAR(1000);
	DECLARE new_actor_count INT DEFAULT 0;
	DECLARE actor_query varchar(65535);
	DECLARE actor_select_query varchar(65535);
	DECLARE movie_actor_query varchar(65535);
	DECLARE done INT DEFAULT FALSE;
	DECLARE actor_id INT;
	DECLARE actor_cur CURSOR FOR SELECT id FROM tmp_view;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	
 	INSERT INTO movies (name) VALUES (movie_name);	
	SET movie_id = LAST_INSERT_ID();
 	
 	SET delimiter = ';';
	SET remainder = actors;
	SET actor_query = 'INSERT INTO actors (name) VALUES ';
 	SET actor_select_query = 'CREATE OR REPLACE VIEW tmp_view as SELECT id FROM actors WHERE name IN (';
 	SET movie_actor_query = 'INSERT INTO movieActors (movieId, actorId) VALUES ';
	
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
				SET @actor_id = (SELECT id FROM actors WHERE name = str);
				IF @actor_id = 0 THEN
				BEGIN
					SET actor_query = CONCAT(actor_query, '(\'', str, '\'),');
					SET actor_select_query = CONCAT(actor_select_query, '\'', str, '\',');
					SET new_actor_count = new_actor_count + 1;
				END;
				ELSE
					SET movie_actor_query = CONCAT(movie_actor_query, '(',  movie_id, ',', @actor_id, '),');
				END IF;
			END;
		END IF;
		
		SET remainder = SUBSTRING(remainder, pos + 1);
	END WHILE;
	
	IF new_actor_count > 0 THEN
		BEGIN
			SET @sql = LEFT(actor_query, CHAR_LENGTH(actor_query) - 1);
			PREPARE stmt FROM @sql;  
			EXECUTE stmt;  
			DEALLOCATE PREPARE stmt;
	
			SET @sql = CONCAT(LEFT(actor_select_query, CHAR_LENGTH(actor_select_query) - 1), ')');
			PREPARE stmt FROM @sql;  
			EXECUTE stmt;  
			
			-- Open the cursor
		    OPEN actor_cur;
		
		    -- Loop through the rows
		    read_loop: LOOP
		        FETCH actor_cur INTO actor_id;
		        IF done = 1 THEN
		            LEAVE read_loop;
		        END IF;
		
		        -- Process each row
		        SET movie_actor_query = CONCAT(movie_actor_query, '(',  movie_id, ',', actor_id, '),');
		
		    END LOOP read_loop;
		
		    -- Close the cursor
		    CLOSE actor_cur;
		    DEALLOCATE PREPARE stmt;
	    END;
	END IF;
	
	SET @sql = LEFT(movie_actor_query, CHAR_LENGTH(movie_actor_query) - 1);
	PREPARE stmt FROM @sql;  
	EXECUTE stmt;  
	DEALLOCATE PREPARE stmt;
	
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE insert_movie
-- CALL insert_movie('Test movie', 'Actor 1; George Buza; Actor 3')
