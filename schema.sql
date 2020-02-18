DROP DATABASE IF EXISTS password_manager;
CREATE DATABASE IF NOT EXISTS password_manager;
use password_manager;

CREATE TABLE IF NOT EXISTS user (
	id BIGINT NOT NULL,
    password VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    created TIMESTAMP NOT NULL DEFAULT current_timestamp,
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

CREATE USER 'application'@'localhost' IDENTIFIED BY 'pwdManager2020';

select * from user;