CREATE DATABASE IF NOT EXISTS PR16_TEST;
USE PR16_TEST;

CREATE TABLE user_category (
    category_id INT NOT NULL AUTO_INCREMENT,
    category_name VARCHAR(50) NOT NULL,
    PRIMARY KEY (category_id)
);

CREATE TABLE users (
    user_id INT NOT NULL AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(64) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20),
    category_id INT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (user_id),
    FOREIGN KEY (category_id) REFERENCES user_category(category_id)
);

INSERT INTO user_category (category_name) VALUES ('Administrator'), ('User');

INSERT INTO users (login, password_hash, full_name, phone_number, category_id) VALUES 
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'Админов Админ Админович', '89001112233', 1),
('user', '04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb', 'Юзеров Юзер Юзерович', '89004445566', 2),
('TEST', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'TEST TEST TEST', '89007778899', 1),
('root', '4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2', 'Рутов Рут Рутович', '89002223344', 2),
('student', '264c8c381bf16c982a4e59b0dd4c6f7808c51a05f64c35db42cc78a2a72875bb', 'Студентов Студент Студентович', '89005556677', 2);