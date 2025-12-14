CREATE DATABASE IF NOT EXISTS PR15_TEST;
USE PR15_TEST;

CREATE TABLE reader (
    reader_id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(150) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    address VARCHAR(255),
    registration_date DATE NOT NULL,
    PRIMARY KEY (reader_id)
);

CREATE TABLE book (
    book_id INT NOT NULL AUTO_INCREMENT,
    title VARCHAR(200) NOT NULL,
    author VARCHAR(150) NOT NULL,
    isbn VARCHAR(17) NOT NULL UNIQUE,
    publication_year INT UNSIGNED NOT NULL,
    pages INT UNSIGNED NOT NULL, 
    PRIMARY KEY (book_id)
);

CREATE TABLE books_on_hand (
    loan_id INT NOT NULL AUTO_INCREMENT,
    reader_id INT NOT NULL, 
    book_id INT NOT NULL, 
    borrow_date DATE NOT NULL,
    due_date DATE NOT NULL,
    actual_return_date DATE NULL,
    fine_amount DECIMAL(10, 2) DEFAULT 0.00,
    PRIMARY KEY (loan_id),
    FOREIGN KEY (reader_id) REFERENCES reader(reader_id),
    FOREIGN KEY (book_id) REFERENCES book(book_id)
);

INSERT INTO reader (full_name, phone_number, email, address, registration_date) VALUES
('Иванов А.П.', '79001111111', 'ivanov@lib.com', 'ул. Мира, 10, кв. 5', '2024-01-10'),
('Петрова К.И.', '79002222222', 'petrova@lib.com', 'пр. Победы, 25', '2023-11-20'),
('Сидоров Г.В.', '79003333333', 'sidorov@lib.com', 'пер. Лесной, 8', '2024-05-01'),
('Козлова Е.А.', '79004444444', 'kozlova@lib.com', 'ул. Садовая, 32', '2024-02-15'),
('Смирнов Д.М.', '79005555555', 'smirnov@lib.com', 'ш. Энтузиастов, 15', '2023-10-01'),
('Федорова Н.П.', '79006666666', 'fedorova@lib.com', 'ул. Цветочная, 1', '2024-04-22'),
('Михайлов Г.Р.', '79007777777', 'mikhailov@lib.com', 'ул. Гагарина, 7', '2024-03-05'),
('Волкова Л.С.', '79008888888', 'volkova@lib.com', 'ул. Пушкина, 40', '2023-09-12'),
('Кузнецов В.А.', '79009999999', 'kuznetsov@lib.com', 'пр. Строителей, 12', '2024-06-18'),
('Зайцева И.О.', '79000000000', 'zaitseva@lib.com', 'ул. Весенняя, 5', '2023-12-01');

INSERT INTO book (title, author, isbn, publication_year, pages) VALUES
('Война и мир', 'Лев Толстой', '978-5-17-062402-9', 2012, 1300),
('Преступление и наказание', 'Федор Достоевский', '978-5-17-112000-5', 2020, 600),
('Мастер и Маргарита', 'Михаил Булгаков', '978-5-17-074472-8', 2018, 450),
('1984', 'Джордж Оруэлл', '978-5-17-101459-0', 2021, 350),
('Гарри Поттер', 'Дж. К. Роулинг', '978-5-389-18357-1', 2019, 700),
('Три товарища', 'Эрих Мария Ремарк', '978-5-17-116524-2', 2022, 500),
('Портрет Дориана Грея', 'Оскар Уайльд', '978-5-17-096739-1', 2017, 300),
('451 градус по Фаренгейту', 'Рэй Брэдбери', '978-5-17-065842-0', 2015, 250),
('Шерлок Холмс', 'Артур Конан Дойл', '978-5-389-08206-5', 2016, 900),
('Алхимик', 'Пауло Коэльо', '978-5-17-094199-5', 2023, 200);

INSERT INTO books_on_hand (reader_id, book_id, borrow_date, due_date, actual_return_date, fine_amount) VALUES
(1, 1, '2025-11-01', '2025-12-01', '2025-12-05', 50.00),   
(2, 3, '2025-10-25', '2025-11-25', '2025-11-25', 0.00),   
(3, 5, '2025-12-10', '2026-01-10', NULL, 0.00),          
(4, 2, '2025-11-15', '2025-12-15', '2025-12-14', 0.00),   
(5, 7, '2025-11-01', '2025-12-01', NULL, 150.00),         
(6, 4, '2025-11-05', '2025-12-05', '2025-12-05', 0.00),   
(7, 9, '2025-12-12', '2026-01-12', NULL, 0.00),          
(8, 6, '2025-11-20', '2025-12-20', NULL, 0.00),          
(9, 8, '2025-10-01', '2025-11-01', '2025-12-10', 400.00), 
(10, 10, '2025-12-01', '2026-01-01', NULL, 0.00);