-- 1. Display the first name and last name of both the instructor and student in one result set.
SELECT INSTRUCTOR_FIRST_NAME AS FIRST_NAME,
       INSTRUCTOR_LAST_NAME AS LAST_NAME
FROM INSTRUCTOR_INFO

UNION

SELECT STUDENT_FIRST_NAME,
       STUDENT_LAST_NAME
FROM STUDENT_INFO;
-- 2. Modify the above query to display duplicate names also.
SELECT INSTRUCTOR_FIRST_NAME AS FIRST_NAME,
       INSTRUCTOR_LAST_NAME AS LAST_NAME
FROM INSTRUCTOR_INFO

UNION ALL

SELECT STUDENT_FIRST_NAME,
       STUDENT_LAST_NAME
FROM STUDENT_INFO;
-- 3. Modify the above query to add a column Name to display text as 'Instructor' or 'Student'.
SELECT INSTRUCTOR_FIRST_NAME AS FIRST_NAME,
       INSTRUCTOR_LAST_NAME AS LAST_NAME,
       'Instructor' AS Name
FROM INSTRUCTOR_INFO

UNION ALL

SELECT STUDENT_FIRST_NAME,
       STUDENT_LAST_NAME,
       'Student'
FROM STUDENT_INFO;
-- 4. Display the instructor IDs not having any section.
SELECT INSTRUCTOR_ID
FROM INSTRUCTOR_INFO

EXCEPT

SELECT INSTRUCTOR_ID
FROM SECTION_INFO;
-- 5. Display the course numbers having a section.
SELECT COURSE_NO
FROM COURSE_INFO

INTERSECT

SELECT COURSE_NO
FROM SECTION_INFO;
-- 6. Display a list of courses and sections having no students enrolled. Add a column called STATUS with the text 'No Student Enrolled'.
SELECT
    S.COURSE_NO,
    S.SECTION_ID,
    'No Student Enrolled' AS STATUS
FROM SECTION_INFO S

EXCEPT

SELECT
    S.COURSE_NO,
    E.SECTION_ID,
    'No Student Enrolled'
FROM SECTION_INFO S
JOIN ENROLLMENT_INFO E
    ON S.SECTION_ID = E.SECTION_ID;
-- 7. Display all the ZIP codes that are present in both the instructor and the student tables.
SELECT ZIP_CODE
FROM INSTRUCTOR_INFO

INTERSECT

SELECT ZIP_CODE
FROM STUDENT_INFO;
-- 8. Display the student IDs who have enrolled.
SELECT STUDENT_ID
FROM STUDENT_INFO

INTERSECT

SELECT STUDENT_ID
FROM ENROLLMENT_INFO;