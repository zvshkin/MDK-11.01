CREATE DATABASE IF NOT EXISTS PR14_TEST;
USE PR14_TEST;

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
('Дмитриев К.К.', '5555666677778888', '1988-03-15', '89005550000', 'ул. Чехова, 3');

INSERT INTO doctor (full_name, specialty, cabinet_num, shift_start, shift_end) VALUES
('Др. Хаус Г.', 'Терапевт', 101, '08:00', '16:00'),
('Др. Ватсон Д.', 'Хирург', 202, '09:00', '17:00'),
('Др. Живаго Ю.', 'Кардиолог', 305, '08:00', '14:00'),
('Др. Преображенский Ф.', 'Хирург', 203, '12:00', '20:00'),
('Др. Айболит К.', 'Педиатр', 105, '08:00', '16:00');

INSERT INTO appointment_ticket (patient_id, doctor_id, visit_time, visit_type) VALUES
(1, 1, '2025-12-09 08:30:00', 'Первичный'),
(2, 2, '2025-12-09 09:15:00', 'Повторный'),
(3, 3, '2025-12-10 10:00:00', 'Консультация'),
(4, 1, '2025-12-10 11:30:00', 'Выписка'),
(5, 5, '2025-12-11 08:00:00', 'Первичный');