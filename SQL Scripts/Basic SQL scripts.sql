USE LearningSQL

INSERT INTO Users
(FNAME, LNAME, DOB)
VALUES
('Brian', 'Lee', '09/14/1981'),
('Yeji', 'Choi', '09/21/1982')


--find userID
SELECT USER_ID FROM Users 
WHERE FNAME like '%Brian' 
AND DOB = '09/14/1981'


SELECT GETDATE()


INSERT INTO Notes
(NOTE_BODY, DATE, USER_ID)
VALUES
('This will be an interesing class.  I am learning about SQL.', GetDate(), 1)


--let's see some notes
SELECT * FROM NOTES
WHERE USER_ID = 1
