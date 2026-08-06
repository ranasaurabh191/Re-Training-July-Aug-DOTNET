-- 1. Display the count of records in the COURSE_INFO table.
SELECT COUNT(*) AS TotalCourses
FROM COURSE_INFO;
-- 2. Display the total number of records in ENROLLMENT_INFO.
SELECT COUNT(*) AS TotalEnrollments
FROM ENROLLMENT_INFO;
-- 3. Display the sum of NUMERIC_GRADE from GRADE_INFO.
SELECT SUM(NUMERIC_GRADE) AS TotalGrade
FROM GRADE_INFO;
-- 4. Display the average, total, minimum, and maximum numeric grade.
SELECT
    AVG(NUMERIC_GRADE) AS AverageGrade,
    SUM(NUMERIC_GRADE) AS TotalGrade,
    MIN(NUMERIC_GRADE) AS MinimumGrade,
    MAX(NUMERIC_GRADE) AS MaximumGrade
FROM GRADE_INFO;
-- 5. Display the count of grade type codes.
SELECT COUNT(GRADE_TYPE_CODE) AS GradeTypeCount
FROM GRADE_INFO;
-- 6. Display the total number of courses that do not have any prerequisite.
SELECT COUNT(*) AS CoursesWithoutPrerequisite
FROM COURSE_INFO
WHERE COURSE_PREREQUISITE IS NULL;
-- 7. Display the date of the student who was most recently enrolled.
SELECT MAX(ENROLLMENT_DATE) AS RecentEnrollmentDate
FROM ENROLLMENT_INFO;
GROUP BY and HAVING
-- 1. Display the count of cities for each state.
SELECT
    STATE,
    COUNT(CITY) AS CityCount
FROM ZIPCODE_INFO
GROUP BY STATE;
-- 2. Display the minimum numeric grade section-wise for each student.
SELECT
    STUDENT_ID,
    SECTION_ID,
    MIN(NUMERIC_GRADE) AS MinimumGrade
FROM GRADE_INFO
GROUP BY STUDENT_ID, SECTION_ID;
-- 3. Display the average numeric grade for each student.
SELECT
    STUDENT_ID,
    AVG(NUMERIC_GRADE) AS AverageGrade
FROM GRADE_INFO
GROUP BY STUDENT_ID;
-- 4. Display the count of students enrolled in each section. Display only those sections where the number of students enrolled is more than 5.
SELECT
    SECTION_ID,
    COUNT(STUDENT_ID) AS StudentCount
FROM ENROLLMENT_INFO
GROUP BY SECTION_ID
HAVING COUNT(STUDENT_ID) > 5;
-- 5. Display the average numeric grade for each student and section. The average numeric grade should be more than 75.
SELECT
    STUDENT_ID,
    SECTION_ID,
    AVG(NUMERIC_GRADE) AS AverageGrade
FROM GRADE_INFO
GROUP BY STUDENT_ID, SECTION_ID
HAVING AVG(NUMERIC_GRADE) > 75;
-- 6. For the above query display the data for STUDENT_ID more than 280.
SELECT
    STUDENT_ID,
    SECTION_ID,
    AVG(NUMERIC_GRADE) AS AverageGrade
FROM GRADE_INFO
WHERE STUDENT_ID > 280
GROUP BY STUDENT_ID, SECTION_ID
HAVING AVG(NUMERIC_GRADE) > 75;
-- 7. Display each prerequisite and its count from the COURSE_INFO table.
SELECT
    COURSE_PREREQUISITE,
    COUNT(*) AS CourseCount
FROM COURSE_INFO
GROUP BY COURSE_PREREQUISITE;
-- 8. Display STUDENT_ID and the number of courses they are enrolled in. Show only students enrolled in more than 2 courses.
SELECT
    STUDENT_ID,
    COUNT(SECTION_ID) AS NumberOfCourses
FROM ENROLLMENT_INFO
GROUP BY STUDENT_ID
HAVING COUNT(SECTION_ID) > 2;
-- 9. Display the average capacity of each course.
SELECT
    COURSE_NO,
    AVG(CAPACITY) AS AverageCapacity
FROM SECTION_INFO
GROUP BY COURSE_NO;
-- 10. For the above query display those courses which have exactly 2 sections.
SELECT
    COURSE_NO,
    AVG(CAPACITY) AS AverageCapacity
FROM SECTION_INFO
GROUP BY COURSE_NO
HAVING COUNT(SECTION_ID) = 2;