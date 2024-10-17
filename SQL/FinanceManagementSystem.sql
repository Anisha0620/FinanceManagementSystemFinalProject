create database FinanceManagementSystem
use FinanceManagementSystem

-- Create the Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    Username NVARCHAR(50) NOT NULL UNIQUE,  -- Unique username
    Password NVARCHAR(255) NOT NULL,  -- Password (hashed preferably)
    Email NVARCHAR(100) NOT NULL UNIQUE  -- Unique email
);

-- Create the ExpenseCategories table
CREATE TABLE ExpenseCategories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    CategoryName NVARCHAR(50) NOT NULL UNIQUE  -- Unique category name
);

-- Create the Expenses table
CREATE TABLE Expenses (
    ExpenseId INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    UserId INT NOT NULL,  -- Foreign key to Users table
    Amount DECIMAL(18, 2) NOT NULL,  -- Expense amount
    CategoryId INT NOT NULL,  -- Foreign key to ExpenseCategories table
    Date DATETIME NOT NULL DEFAULT GETDATE(),  -- Expense date
    Description NVARCHAR(255),  -- Description of the expense
    FOREIGN KEY (UserId) REFERENCES Users(UserId),  -- Foreign key constraint
    FOREIGN KEY (CategoryId) REFERENCES ExpenseCategories(CategoryId)  -- Foreign key constraint
);

INSERT INTO Users (Username, Password, Email) VALUES
('anisha_chennai', 'ani_password1', 'anishak@example.com'),  
('varshakone_mumbai', 'vk_password2', 'varshakone@example.com'),      
('samantha_coimbatore', 'sam_password3', 'samantha@example.com'),  
('Preity_trichy', 'preity_password4', 'preity@example.com'),  
('sharuk_mumbai', 'sharuk_password5', 'sharuk@example.com');      

INSERT INTO ExpenseCategories (CategoryName) VALUES
('Food & Groceries'),      
('Transportation'),         
('Utilities'),             
('Healthcare'),          
('Entertainment'),         
('Education'),             
('Travel'),                
('Miscellaneous');         

INSERT INTO Expenses (UserId, Amount, CategoryId, Date, Description) VALUES
(1, 50.00, 1, '2024-10-10', 'Groceries'),
(1, 15.00, 2, '2024-10-11', 'Bus ticket'),
(2, 100.00, 3, '2024-10-12', 'Electricity bill'),
(2, 60.00, 4, '2024-10-13', 'Movie night'),
(3, 30.00, 1, '2024-10-14', 'Lunch with friends'),
(3, 75.00, 5, '2024-10-15', 'Gym membership'),
(4, 60.00, 6, '2024-10-19', 'Tuition fees for online classes'),
(4, 300.00, 3, '2024-10-16', 'Gas bill for cooking'),
(5, 150.00, 6, '2024-10-12', 'School fees for children in Mumbai'),
(5, 100.00, 2, '2024-10-10', 'Local train fare to work');


select * from Users
select * from ExpenseCategories
select * from Expenses