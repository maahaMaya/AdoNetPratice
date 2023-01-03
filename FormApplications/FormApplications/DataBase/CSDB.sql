CREATE DATABASE CSDB;
USE CSDB;
CREATE TABLE Dept(
Deptno INT CONSTRAINT Deptno_Pk PRIMARY KEY, Dname VARCHAR(50), Location VARCHAR(50));
INSERT INTO Dept VALUES (10, 'Marketing', 'Mumbai'), (20, 'Sales', 'Chennai'), (30, 'Finance', 'Delhi'), (40, 'Production', 'Kolkata');
SELECT * FROM Dept;

CREATE TABLE Emp (Empno INT CONSTRAINT Empno_Pk  PRIMARY KEY, Ename VARCHAR(100), Job VARCHAR(100), Mgr Int, HireDate DATE, Salary MONEY, Comm MONEY, Deptno Int REFERENCES Dept(Deptno));

INSERT INTO Emp VALUES
(1001, 'Scott', 'President', NULL, '01/01/88', 5000, NULL, 10), 
(1002, 'Clark', 'Manager', 1001, '01/01/88', 4000, NULL, 10),
(1003, 'Smith', 'Manager', 1001, '01/01/90', 3500, 500, 20),
(1004, 'Vijay', 'Manager', 1001, '01/01/92', 4000, NULL, 30),
(1005, 'Ajay', 'Salesman', 1003, '02/04/89', 3000, 300, 20),
(1006, 'John Smith', 'Salesman', 1003, '02/08/88', 3300, 600, 20),
(1007, 'Venkat', 'Salesman', 1003, '04/15/88', 3300, 0, 20),
(1008, 'Vinod', 'Clerk', 1003, '01/15/88', 2400, NULL, 20),
(1009, 'Suneel', 'Clerk', 1004, '05/12/83', 2000, NULL, 30),
(1010, 'Srinivas', 'Analyst', 1004, '03/01/89', 3400, NULL, 30),
(1011, 'Smyth', 'Analyst', 1004, '03/01/89', 3600, NULL, 30),
(1012,'Madan', 'Analyst', 1004, '01/09/91', 3100, NULL, 30),
(1013, 'JohnSmith', 'Clerk', 1002, '01/06/88', 1800, NULL, 10),
(1014,'Raju', 'Clerk', 1005, '06/01/89', 2300, NULL, 20),
(1015, 'Ramesh', 'Clerk', 1011, '08/22/90', 2500, NULL, 30),
(1016, 'Aarush', 'Manager', 1001, '07/15/90', 4200, NULL, 40),
(1017, 'Sridhar', 'Clerk', 1016, '07/20/90', 2500, NULL, 40),
(1018, 'Rahul', 'Supervisor', 1016, '08/01/90', 3500, NULL, 40),
(1019, 'Krishna', 'Fabricator', 1018, '08/12/90', 3100, NULL, 40),
(1020, 'Aaron', 'Fabricator', 1018, '08/21/90', 2900, NULL, 40) ,
(1021, 'Dave', 'Analyst', 1004, '08/22/90', 3500, NULL, 30),
(1022, 'Kristane', 'Administrator', 1002, '08/22/90', 3000, NULL, 10),
(1023, 'Sophia', 'Administrator', 1003, '08/22/90', 3000, NULL, 20),
(1024, 'Racheal', 'Administrator', 1004, '08/22/90', 3000, NULL, 30),
(1025, 'Elizabeth', 'Administrator', 1016, '08/22/90', 3000, NULL, 40)
Go
SELECT * FROM Emp;

CREATE TABLE SalGrade(Grade INT, LoSal Money, Hisal Money);
INSERT INTO SalGrade VALUES
(1, 1300, 1800),
(2, 1801, 2700),
(3, 2701, 3500),
(4, 3501, 5000),
(5, 5001, 8000),
(6, 8001, 10000);
SELECT * FROM SalGrade;
