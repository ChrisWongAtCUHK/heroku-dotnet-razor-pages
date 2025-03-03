DROP PROCEDURE IF EXISTS create_movie;

DELIMITER $$
$$
CREATE PROCEDURE update_movie(movie_id INT, movie_name VARCHAR(100), actors VARCHAR(65535))
BEGIN
	DECLARE remainder TEXT;
	DECLARE delimiter CHAR(1);
	DECLARE pos INT DEFAULT 1 ;
	DECLARE str VARCHAR(1000);
	DECLARE new_actor_count INT DEFAULT 0;
	DECLARE actor_insert_query varchar(65535);
	DECLARE actor_select_query varchar(65535);
	DECLARE movie_actor_count INT DEFAULT 0;
	DECLARE movie_actor_query varchar(65535);
	DECLARE done INT DEFAULT FALSE;
	DECLARE actor_id INT;
	-- use view to be created for cursor
	DECLARE actor_cur CURSOR FOR SELECT id FROM tmp_view;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	
	-- update movies
 	UPDATE movies SET name = movie_name WHERE id = movie_id;
	-- delete all actors
	DELETE FROM movieActors WHERE movieId = movie_id;
 	
	
 	SET delimiter = ';';
	SET remainder = actors;
	SET actor_insert_query = 'INSERT INTO actors (name) VALUES ';
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
				SET @actor_count = (SELECT COUNT(*) FROM actors WHERE name = str);
				-- new actor
				IF @actor_count = 0 THEN
				BEGIN
					SET actor_insert_query = CONCAT(actor_insert_query, '(\'', str, '\'),');
					SET actor_select_query = CONCAT(actor_select_query, '\'', str, '\',');
					SET new_actor_count = new_actor_count + 1;
				END;
				ELSE
					SET @actor_id = (SELECT id FROM actors WHERE name = str);
					SET movie_actor_query = CONCAT(movie_actor_query, '(',  movie_id, ',', @actor_id, '),');
					SET movie_actor_count = movie_actor_count + 1;
				END IF;
			END;
		END IF;
		
		SET remainder = SUBSTRING(remainder, pos + 1);
	END WHILE;
	
	IF new_actor_count > 0 THEN
		BEGIN
			SET @sql = LEFT(actor_insert_query, CHAR_LENGTH(actor_insert_query) - 1);
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
		        SET movie_actor_count = movie_actor_count + 1;
		    END LOOP read_loop;
		
		    -- Close the cursor
		    CLOSE actor_cur;
		    DEALLOCATE PREPARE stmt;
	    END;
	END IF;
	
	IF movie_actor_count > 0 THEN
		BEGIN
		SET @sql = LEFT(movie_actor_query, CHAR_LENGTH(movie_actor_query) - 1);
		PREPARE stmt FROM @sql;  
		EXECUTE stmt;  
		DEALLOCATE PREPARE stmt;
		END;
	END IF;
	SELECT id, name, actors FROM movies WHERE id = movie_id;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE create_movie
-- CALL create_movie('Test movie', 'Actor 1; George Buza; Actor 3')
