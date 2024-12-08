INSERT INTO [Author](Name, Birth, Housing)
VALUES
    ('J.K. Rowling', '1965-07-31', 'Edinburgh, Scotland'),
    ('George R.R. Martin', '1948-09-20', 'Bayonne, New Jersey'),
    ('J.R.R. Tolkien', '1892-01-03', 'Bloemfontein, South Africa'),
    ('Agatha Christie', '1890-09-15', 'Torquay, England'),
    ('Isaac Asimov', '1920-01-02', 'Petrovichi, Russia');

INSERT INTO [Category]([Name])
VALUES
    ('Fiction'),
    ('Science Fiction'),
    ('Mystery'),
    ('Fantasy'),
    ('Non-fiction');

INSERT INTO [Book]([Name], [CategoryId], [AuthorId], [Launch])
VALUES
    ('Harry Potter and the Sorcerers Stone', 2, 1, '1997-06-26'),
    ('Harry Potter and the Chamber of Secrets', 3, 1, '1998-07-02'),
    ('A Game of Thrones', 4, 2, '1996-08-06'),
    ('A Clash of Kings', 4, 2, '1998-11-16'),
    ('The Hobbit', 4, 3, '1937-09-21'),
    ('The Lord of the Rings', 4, 3, '1954-07-29'),
    ('Murder on the Orient Express', 5, 4, '1934-01-01'),
    ('And Then There Were None', 5, 4, '1939-11-06'),
    ('I, Robot', 2, 5, '1950-12-02'),
    ('The Foundation', 2, 5, '1951-06-01')

