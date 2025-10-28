CREATE TABLE employer (
    employer_id INT NOT NULL AUTO_INCREMENT,
    company_name VARCHAR(100) NOT NULL UNIQUE,
    industry VARCHAR(50) NOT NULL,
    contact_person VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    vacancies_count INT UNSIGNED NOT NULL,
    PRIMARY KEY (employer_id)

);

INSERT INTO employer (company_name, industry, contact_person, phone_number, vacancies_count) VALUES
('TechSolutions Inc', 'IT', 'Ivan Petrov', '+79001112233', 5),
('Global Retail LLC', 'Retail', 'Elena Sidorova', '+79002223344', 12),
('StroyInvest Group', 'Construction', 'Oleg Ivanov', '+79003334455', 8),
('FinanceHub Co', 'Finance', 'Anna Kuzmina', '+79004445566', 3),
('MediaWave Agency', 'Marketing', 'Pavel Morozov', '+79005556677', 6),
('LogisticsMaster', 'Logistics', 'Dmitry Orlov', '+79006667788', 10),
('EduPro Center', 'Education', 'Maria Petrova', '+79007778899', 4),
('PharmaHealth', 'Healthcare', 'Sergey Volkov', '+79008889900', 7),
('EnergySystems', 'Energy', 'Natalia Zaitseva', '+79009990011', 2),
('FoodDelight Chain', 'Hospitality', 'Viktor Titov', '+79000001122', 15);
