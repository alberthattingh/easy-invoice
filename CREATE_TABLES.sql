
CREATE TABLE Users (
    UserId INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(320) NOT NULL,
    UserPassword VARCHAR(100) NOT NULL,
    Cell VARCHAR(12) NULL,
    DefaultFee DECIMAL(18, 2) NULL,
    Logo VARCHAR(100) NULL,

    PRIMARY KEY (UserId),
    UNIQUE (Email)
);

CREATE TABLE AccountDetails (
    AccountId INT NOT NULL AUTO_INCREMENT,
    UserId INT NOT NULL,
    AccountType VARCHAR(50) NULL,
    Bank VARCHAR(50) NOT NULL,
    AccountHolder VARCHAR(50) NOT NULL,
    AccountNumber VARCHAR(20) NOT NULL,
    BranchCode VARCHAR(20) NULL,
    PaymentInstruction VARCHAR(500) NULL,
    
    PRIMARY KEY (AccountId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Qualifications (
    QualificationId INT NOT NULL AUTO_INCREMENT,
    UserId INT NOT NULL,
    Qualification VARCHAR(500) NOT NULL,
    
    PRIMARY KEY (QualificationId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Invoices (
    InvoiceId INT NOT NULL AUTO_INCREMENT,
    UserId INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Total DECIMAL(18, 2) NOT NULL,
    
    PRIMARY KEY (InvoiceId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Students (
    StudentId INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(320) NOT NULL,
    Cell VARCHAR(12) NULL,
    FeePayable DECIMAL(18, 2) NOT NULL,,
    
    PRIMARY KEY (StudentId),
    UNIQUE (Email)
);

CREATE TABLE StudentsPerInvoice (
    StudentGroupId INT NOT NULL AUTO_INCREMENT,
    InvoiceId INT NOT NULL,
    StudentId INT NOT NULL,
    
    PRIMARY KEY (StudentGroupId),
    FOREIGN KEY (InvoiceId) REFERENCES Invoices(InvoiceId),
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId)
);

CREATE TABLE Lessons (
    LessonId INT NOT NULL AUTO_INCREMENT,
    UserId INT NOT NULL,
    StudentId INT NOT NULL,
    Duration DECIMAL(18, 2) NOT NULL,
    LessonDate DATETIME NOT NULL,
    
    PRIMARY KEY (LessonId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId)
);

CREATE TABLE Classes (
    ClassId INT NOT NULL AUTO_INCREMENT,
    UserId INT NOT NULL,
    StudentId INT NOT NULL,
    IsActive BIT NOT NULL,
    
    PRIMARY KEY (ClassId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId)
);
