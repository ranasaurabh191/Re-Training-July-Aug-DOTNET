-- 1. Create a view stud_enroll that displays student ID, last name and number of sections the student is enrolled in.
CREATE VIEW stud_enroll
AS
SELECT
    S.STUDENT_ID,
    S.STUDENT_LAST_NAME,
    COUNT(E.SECTION_ID) AS NUMBER_OF_SECTIONS
FROM STUDENT_INFO S
JOIN ENROLLMENT_INFO E
    ON S.STUDENT_ID = E.STUDENT_ID
GROUP BY
    S.STUDENT_ID,
    S.STUDENT_LAST_NAME;
GO

SELECT * FROM stud_enroll;
-- 2. Create a view stud_zip containing student ID, first name, last name, city and state. Display only students not living in New Jersey, New York and Connecticut.
CREATE VIEW stud_zip
AS
SELECT
    S.STUDENT_ID,
    S.STUDENT_FIRST_NAME,
    S.STUDENT_LAST_NAME,
    Z.CITY,
    Z.STATE
FROM STUDENT_INFO S
JOIN ZIPCODE_INFO Z
    ON S.ZIP_CODE = Z.ZIP_CODE
WHERE Z.STATE NOT IN ('NJ','NY','CT');
GO

SELECT * FROM stud_zip;
-- 3. Create a view lowcost_course with course number, course name and cost less than 4000.
CREATE VIEW lowcost_course
AS
SELECT
    COURSE_NO,
    COURSE_NAME,
    COST
FROM COURSE_INFO
WHERE COST < 4000;
GO

SELECT * FROM lowcost_course;
-- 4. Insert a record with cost greater than 4000 through the view.
INSERT INTO lowcost_course
(
    COURSE_NO,
    COURSE_NAME,
    COURSE_PREREQUISITE,
    COST
)
VALUES
(
    999,
    'Advanced SQL',
    NULL,
    5000
);


-- In SQL Server, because the view does not have WITH CHECK OPTION, the insert succeeds. However:

SELECT * FROM lowcost_course;

-- will not show the new row because COST = 5000 does not satisfy the view's WHERE COST < 4000 condition.

-- The row does exist in COURSE_INFO:

SELECT *
FROM COURSE_INFO
WHERE COURSE_NO = 999;
-- 5. Recreate the view with WITH CHECK OPTION.

First drop the existing view.

DROP VIEW lowcost_course;
GO

Create it again.

CREATE VIEW lowcost_course
AS
SELECT
    COURSE_NO,
    COURSE_NAME,
    COURSE_PREREQUISITE,
    COST
FROM COURSE_INFO
WHERE COST < 4000
WITH CHECK OPTION;
GO

Now try the same insert again.

INSERT INTO lowcost_course
(
    COURSE_NO,
    COURSE_NAME,
    COURSE_PREREQUISITE,
    COST
)
VALUES
(
    1000,
    'Cloud Computing',
    NULL,
    5000
);