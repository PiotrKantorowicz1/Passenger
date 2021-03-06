CREATE DATABASE Passenger

USE Passenger

CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(200) NOT NULL,
    Salt NVARCHAR(300) NOT NULL,
    Username NVARCHAR(100) NOT NULL,
    Fullname NVARCHAR(100),
    Role NVARCHAR(10) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

select * from users;

delete from users;