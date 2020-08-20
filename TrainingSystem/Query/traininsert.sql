use [TrainDb]

insert into Users(UserID, Password, Role, Name, Email, DOB, Education, ProgrammingLanguage, TOEIC, Experience, Department, Location, Type, Phone, Workplace)
values
	('admin01','1','Administrator','Jordon DuBuque V','tad00@maliesed.com', '20000130', '', '', NULL, '', '', '', '', '', ''),
	('staff01', '1', 'TrainingStaff', 'Janice Beatty', 'oreinger@best566.xyz', '20000130','', '', NULL, '', '', '', '', '', ''),
	('trainer01', '1', 'Trainer', 'Arianna Armstrong', 'jeramy83@tguide.site', '20000130', '', '', NULL, '', '', '','Internal', '0981663737', 'Building 1'),
	('trainer02', '1', 'Trainer', 'Mr. Jedidiah Gulgowski', 'yboehm@khoastore.net', '20000130', '', '', NULL, '', '', '','External', '0981693637', 'Building 2'),
	('trainee01', '1', 'Trainee', 'Janelle Bradtke', 'yawdehm@khoastore.net', '20000130', 'B.A', 'C#', 450, '1 year', 'Department of ABC', 'Earth', '', '', ''),
	('trainee02', '1', 'Trainee', 'Elda Durgan', 'yboi@khd.net', '20000423', 'B.A', 'Brainfuck', 369, '2 years', 'Department of XYZ', 'Earth', '', '', '')

SET IDENTITY_INSERT Topic ON;
insert into Topic(TopicID, Name, Description)
values
	(1, 'C# overview', 'Overview of C# language'),
	(2, 'C# program structure', 'Structure of a C# program'),
	(3, 'Python overview', 'Overview of python language'),
	(4, 'Python program structure', 'Structure of a python program')
SET IDENTITY_INSERT Topic OFF;

SET IDENTITY_INSERT Category ON;
insert into Category(CategoryID, Name, Description, Image)
values
	(1, 'C#', 'C# topic', 'category1.jpg'),
	(2, 'Python', 'Python topic', 'category2.jpg')
SET IDENTITY_INSERT Category OFF;

SET IDENTITY_INSERT Course ON;
insert into Course(CourseID, Name, Description, Image, CategoryID)
values
	(1, 'Introduction to C#', 'Basic C# course', 'course1.jpg', 1),
	(2, 'Introduction to Python', 'Basic python course', 'course2.jpg', 2)
SET IDENTITY_INSERT Course OFF;

insert into TrainerTopic(UserID, TopicID)
values
	('trainer02', 1),
	('trainer02', 2),
	('trainer01', 3),
	('trainer01', 4)

insert into TraineeCourse(UserID, CourseID)
values
	('trainee01', 1),
	('trainee02', 2)

insert into CourseTopic(CourseID, TopicID)
values
	(1, 1),
	(1, 2),
	(2, 3),
	(2, 4)

