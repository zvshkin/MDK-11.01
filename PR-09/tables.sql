CREATE TABLE employer (
    employer_id INT NOT NULL AUTO_INCREMENT,
    company_name VARCHAR(100) NOT NULL UNIQUE,
    industry VARCHAR(50) NOT NULL,
    contact_person VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    vacancies_count INT UNSIGNED NOT NULL,
    PRIMARY KEY (employer_id)
);