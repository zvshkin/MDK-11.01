CREATE TABLE doctor (
    doctor_id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(100) NOT NULL,
    specialization VARCHAR(50) NOT NULL,
    cabinet_number INT UNSIGNED NOT NULL,
    shift_type VARCHAR(20) NOT NULL,
    experience_years INT UNSIGNED NOT NULL,
    PRIMARY KEY (doctor_id)
);

INSERT INTO doctor (full_name, specialization, cabinet_number, shift_type, experience_years) VALUES
('Смирнов А.В.', 'Терапевт', 201, 'Утро', 15),
('Иванова Е.Д.', 'Хирург', 310, 'Вечер', 8),
('Петров К.М.', 'Окулист', 105, 'Утро', 5),
('Козлова О.И.', 'ЛОР', 203, 'Вечер', 12),
('Васильев Р.Т.', 'Кардиолог', 401, 'Утро', 25),
('Зайцева Л.П.', 'Невролог', 302, 'Утро', 10),
('Николаев Г.С.', 'Терапевт', 202, 'Вечер', 4),
('Соколов И.М.', 'Хирург', 311, 'Утро', 20),
('Рыбакова А.О.', 'Окулист', 106, 'Вечер', 6),
('Кузнецов В.Ф.', 'Педиатр', 115, 'Утро', 18);