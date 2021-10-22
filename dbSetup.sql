CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS castles(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  name varchar(255) comment 'castles name',
  kingdom varchar(255) comment 'kingdom name',
  creatorId varchar(255) comment 'id of creator'
) default charset utf8 comment'';
CREATE TABLE IF NOT EXISTS knights(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  knightName varchar(255) comment 'Knights name',
  castleId int NOT NULL,
  FOREIGN KEY (castleId) REFERENCES castles(id) ON DELETE CASCADE
)default charset utf8 comment '';


INSERT INTO knights (knightName, castleId)
VALUES("shining armor", 4);

SELECT * FROM knights;

SELECT
*
FROM knights k 
JOIN castles c 
ON c.id = k.castleId;


UPDATE castles
      SET
      name = @Name,
      kingdom = @Kingdom