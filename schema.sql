DROP DATABASE IF EXISTS password_manager;
CREATE DATABASE IF NOT EXISTS password_manager;
use password_manager;

CREATE TABLE IF NOT EXISTS user (
	id BIGINT NOT NULL,
    password VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    created DATETIME NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS login_data (
	id BIGINT NOT NULL,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    link VARCHAR(500),
    user_id BIGINT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (user_id) REFERENCES user(id)
);

CREATE USER 'application'@'%' IDENTIFIED BY 'pwdManager2020';
GRANT ALL ON password_manager.* TO 'application'@'%';