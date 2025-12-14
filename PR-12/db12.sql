CREATE DATABASE IF NOT EXISTS PR12_TEST;
USE PR12_TEST;

CREATE TABLE employee (
    employee_id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(100) NOT NULL,
    position VARCHAR(50) NOT NULL,
    hire_date DATE NOT NULL,
    salary DECIMAL(8, 2) UNSIGNED NOT NULL,
    is_shift_manager BOOLEAN NOT NULL,
    PRIMARY KEY (employee_id)
);

INSERT INTO employee (full_name, position, hire_date, salary, is_shift_manager) VALUES
('Иванов А.С.', 'Мойщик', '2023-01-15', 35000.00, 0),
('Петров В.К.', 'Администратор', '2022-08-20', 55000.00, 1),
('Сидорова М.И.', 'Мойщик', '2023-11-01', 32000.00, 0),
('Ковалев Р.О.', 'Старший Мойщик', '2022-05-10', 40000.00, 1),
('Михайлов Г.Т.', 'Мойщик', '2024-03-25', 31000.00, 0),
('Федорова Е.Л.', 'Администратор', '2023-04-05', 52000.00, 0),
('Васильев П.Р.', 'Мойщик', '2022-10-01', 37000.00, 0),
('Захаров Н.М.', 'Старший Мойщик', '2023-02-10', 42000.00, 1),
('Рыжова В.А.', 'Мойщик', '2024-01-20', 33000.00, 0),
('Кузнецов С.Д.', 'Мойщик', '2023-06-12', 36000.00, 0);