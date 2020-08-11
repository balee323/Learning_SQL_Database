USE LearningSQL

INSERT INTO Users
(FNAME, LNAME, DOB)
VALUES
('John', 'Doe', '09/14/1975'),
('Jane', 'Doe', '07/21/1976')


--find userID
SELECT USER_ID FROM Users 
WHERE FNAME like '%John' 
AND DOB = '09/14/1975'


SELECT GETDATE()


INSERT INTO Notes
(NOTE_BODY, DATE, USER_ID)
VALUES
('This will be an interesing class.  I am learning about SQL.', GetDate(), 1)


--let's see some notes
SELECT * FROM NOTES
WHERE USER_ID = 1
