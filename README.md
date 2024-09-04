# MVCCoreDemo

```
dotnet new mvc MvcCoreDemo
```

```
dotnet run
```

```
dotnet add package MySql.Data --version 9.0.0

```

```
CREATE TABLE tblStudent (
    StudId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(20) NOT NULL,
    City VARCHAR(20) NOT NULL,
    Department VARCHAR(20) NOT NULL,
    Gender VARCHAR(6) NOT NULL
);

```

```
INSERT INTO tblStudent (Name, City, Department, Gender) VALUES ('John Doe', 'New York', 'Computer Science', 'Male');
INSERT INTO tblStudent (Name, City, Department, Gender) VALUES ('Jane Smith', 'Los Angeles', 'Mathematics', 'Female');
INSERT INTO tblStudent (Name, City, Department, Gender) VALUES ('Alice Johnson', 'Chicago', 'Physics', 'Female');
INSERT INTO tblStudent (Name, City, Department, Gender) VALUES ('Bob Brown', 'Houston', 'Chemistry', 'Male');
INSERT INTO tblStudent (Name, City, Department, Gender) VALUES ('Charlie Davis', 'Phoenix', 'Biology', 'Male');

```

```
DELIMITER //

CREATE PROCEDURE spAddStudent (
    IN p_Name VARCHAR(20),
    IN p_City VARCHAR(20),
    IN p_Department VARCHAR(20),
    IN p_Gender VARCHAR(6)
)
BEGIN
    INSERT INTO tblStudent (Name, City, Department, Gender)
    VALUES (p_Name, p_City, p_Department, p_Gender);
END //

DELIMITER ;

```

```
DELIMITER //

CREATE PROCEDURE spUpdateStudent (
    IN p_StudId INT,
    IN p_Name VARCHAR(20),
    IN p_City VARCHAR(20),
    IN p_Department VARCHAR(20),
    IN p_Gender VARCHAR(6)
)
BEGIN
    UPDATE tblStudent
    SET Name = p_Name,
        City = p_City,
        Department = p_Department,
        Gender = p_Gender
    WHERE StudId = p_StudId;
END //

DELIMITER ;

```

```
DELIMITER //

CREATE PROCEDURE spDeleteStudent (
    IN p_StudId INT
)
BEGIN
    DELETE FROM tblStudent WHERE StudId = p_StudId;
END //

DELIMITER ;

```
```
DELIMITER //

CREATE PROCEDURE spGetAllStudent ()
BEGIN
    SELECT * FROM tblStudent ORDER BY StudId;
END //

DELIMITER ;

```