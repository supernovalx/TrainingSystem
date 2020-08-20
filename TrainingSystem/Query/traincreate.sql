use [TrainDb]

CREATE TABLE Users (
    UserID varchar(255) PRIMARY KEY,
	Password varchar(255) NOT NULL,
    Role varchar(255) NOT NULL,
    Name varchar(255) NOT NULL,
    Email varchar(255),
	DOB datetime,
	Education varchar(255),
	ProgrammingLanguage varchar(255),
	TOEIC int,
	Experience varchar(255),
	Department varchar(255),
	Location varchar(255),
    Type varchar(255),
	Phone varchar(255),
	Workplace varchar(255)
);

CREATE TABLE Topic (
    TopicID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Description varchar(255)
);

CREATE TABLE Category (
    CategoryID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Description varchar(255),
    Image varchar(255)
);

CREATE TABLE Course (
    CourseID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Description varchar(255),
    Image varchar(255),
	CategoryID int FOREIGN KEY REFERENCES Category(CategoryID)
);

CREATE TABLE TrainerTopic (
    UserID varchar(255) FOREIGN KEY REFERENCES Users(UserID),
	TopicID int FOREIGN KEY REFERENCES Topic(TopicID),
	CONSTRAINT PK_TrainerTopic PRIMARY KEY (UserID,TopicID)
);

CREATE TABLE TraineeCourse (
    UserID varchar(255) FOREIGN KEY REFERENCES Users(UserID),
	CourseID int FOREIGN KEY REFERENCES Course(CourseID),
	CONSTRAINT PK_TraineeCourse PRIMARY KEY (UserID,CourseID)
);

CREATE TABLE CourseTopic (
    CourseID int FOREIGN KEY REFERENCES Course(CourseID),
	TopicID int FOREIGN KEY REFERENCES Topic(TopicID),
	CONSTRAINT PK_CourseTopic PRIMARY KEY (CourseID,TopicID)
);