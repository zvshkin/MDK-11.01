CREATE DATABASE IF NOT EXISTS PR13_TEST;
USE PR13_TEST;

CREATE TABLE patient (
    patient_id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(100) NOT NULL,
    insurance_policy VARCHAR(16) NOT NULL UNIQUE,
    birth_date DATE NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    address VARCHAR(150) NOT NULL,
    PRIMARY KEY (patient_id)
);

CREATE TABLE doctor (
    doctor_id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(100) NOT NULL,
    specialty VARCHAR(50) NOT NULL,
    cabinet_num INT UNSIGNED NOT NULL,
    shift_start TIME NOT NULL,
    shift_end TIME NOT NULL,
    PRIMARY KEY (doctor_id)
);

CREATE TABLE appointment_ticket (
    ticket_id INT NOT NULL AUTO_INCREMENT,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    visit_time DATETIME NOT NULL,
    visit_type VARCHAR(50) NOT NULL,
    PRIMARY KEY (ticket_id),
    FOREIGN KEY (patient_id) REFERENCES patient(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctor(doctor_id)
);

INSERT INTO patient (full_name, insurance_policy, birth_date, phone_number, address) VALUES
('Алексеев И.И.', '1111222233334444', '1980-05-12', '89001110000', 'ул. Ленина, 1'),
('Борисова А.А.', '2222333344445555', '1995-08-20', '89002220000', 'ул. Мира, 15'),
('Викторов П.С.', '3333444455556666', '1975-12-01', '89003330000', 'пр. Победы, 5'),
('Глебова М.М.', '4444555566667777', '2000-01-10', '89004440000', 'ул. Садовая, 8'),
('Дмитриев К.К.', '5555666677778888', '1988-03-15', '89005550000', 'ул. Чехова, 3'),
('Еремина О.Л.', '6666777788889999', '1992-07-30', '89006660000', 'ул. Гоголя, 12'),
('Жуков Д.В.', '7777888899990000', '1965-11-25', '89007770000', 'ул. Пушкина, 7'),
('Зимина Е.С.', '8888999900001111', '1999-09-09', '89008880000', 'пер. Тихий, 2'),
('Иванов С.С.', '9999000011112222', '1983-04-14', '89009990000', 'ул. Новая, 20'),
('Котова Н.В.', '0000111122223333', '1990-06-22', '89000000000', 'ул. Речная, 4');

INSERT INTO doctor (full_name, specialty, cabinet_num, shift_start, shift_end) VALUES
('Др. Хаус Г.', 'Терапевт', 101, '08:00', '16:00'),
('Др. Ватсон Д.', 'Хирург', 202, '09:00', '17:00'),
('Др. Живаго Ю.', 'Кардиолог', 305, '08:00', '14:00'),
('Др. Преображенский Ф.', 'Хирург', 203, '12:00', '20:00'),
('Др. Айболит К.', 'Педиатр', 105, '08:00', '16:00'),
('Др. Стрэндж С.', 'Невролог', 310, '10:00', '18:00'),
('Др. Быков А.Е.', 'Терапевт', 102, '14:00', '20:00'),
('Др. Купитман И.Н.', 'Венеролог', 404, '09:00', '15:00'),
('Др. Кисегач А.К.', 'Главврач', 500, '08:00', '17:00'),
('Др. Лобанов С.А.', 'Интерн', 100, '08:00', '20:00');

INSERT INTO appointment_ticket (patient_id, doctor_id, visit_time, visit_type) VALUES
(1, 1, '2023-10-25 08:30:00', 'Первичный');