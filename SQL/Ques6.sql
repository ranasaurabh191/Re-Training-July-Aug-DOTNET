-- 1. Display the course number, course name, and cost whose cost is equal to the minimum cost.
SELECT COURSE_NO, COURSE_NAME, COST
FROM COURSE_INFO
WHERE COST =
(
    SELECT MIN(COST)
    FROM COURSE_INFO
);
-- 2. Display the names of the students enrolled in section no. 8 and course no. 20.
SELECT STUDENT_FIRST_NAME, STUDENT_LAST_NAME
FROM STUDENT_INFO
WHERE STUDENT_ID IN
(
    SELECT E.STUDENT_ID
    FROM ENROLLMENT_INFO E
    JOIN SECTION_INFO S
        ON E.SECTION_ID = S.SECTION_ID
    WHERE S.SECTION_NO = 8
      AND S.COURSE_NO = 20
);
-- 3. Display the student IDs who registered first.
SELECT STUDENT_ID
FROM ENROLLMENT_INFO
WHERE ENROLLMENT_DATE =
(
    SELECT MIN(ENROLLMENT_DATE)
    FROM ENROLLMENT_INFO
);
-- 4. Display the course number and sum of capacity where the total capacity is less than the average capacity.
SELECT COURSE_NO,
       SUM(CAPACITY) AS TOTAL_CAPACITY
FROM SECTION_INFO
GROUP BY COURSE_NO
HAVING SUM(CAPACITY) <
(
    SELECT AVG(CAPACITY)
    FROM SECTION_INFO
);
Subqueries Returning Multiple Rows
-- 1. Display the course number and course name whose cost is the same as that of the course whose prerequisite is 20.
SELECT COURSE_NO,
       COURSE_NAME
FROM COURSE_INFO
WHERE COST IN
(
    SELECT COST
    FROM COURSE_INFO
    WHERE COURSE_PREREQUISITE = 20
);
-- 2. Display the course number and course name whose cost is not the same as that of the course whose prerequisite is 20.
SELECT COURSE_NO,
       COURSE_NAME
FROM COURSE_INFO
WHERE COST NOT IN
(
    SELECT COST
    FROM COURSE_INFO
    WHERE COURSE_PREREQUISITE = 20
);
-- 3. Display the course name and cost where capacity is less than or equal to the average capacity and cost equals the minimum cost.
SELECT COURSE_NAME,
       COST
FROM COURSE_INFO
WHERE COST =
(
    SELECT MIN(COST)
    FROM COURSE_INFO
)
AND COURSE_NO IN
(
    SELECT COURSE_NO
    FROM SECTION_INFO
    WHERE CAPACITY <=
    (
        SELECT AVG(CAPACITY)
        FROM SECTION_INFO
    )
);
-- 4. Display the student ID and section ID of students living in ZIP code 06820.
SELECT STUDENT_ID,
       SECTION_ID
FROM ENROLLMENT_INFO
WHERE STUDENT_ID IN
(
    SELECT STUDENT_ID
    FROM STUDENT_INFO
    WHERE ZIP_CODE = '06820'
);
-- 5. Display the course number and course name taught by instructor Frank Hank.
SELECT COURSE_NO,
       COURSE_NAME
FROM COURSE_INFO
WHERE COURSE_NO IN
(
    SELECT COURSE_NO
    FROM SECTION_INFO
    WHERE INSTRUCTOR_ID =
    (
        SELECT INSTRUCTOR_ID
        FROM INSTRUCTOR_INFO
        WHERE INSTRUCTOR_FIRST_NAME = 'Frank'
          AND INSTRUCTOR_LAST_NAME = 'Hank'
    )
);
-- 6. Display the students enrolled in the course 'Introduction to Java'.
SELECT STUDENT_FIRST_NAME,
       STUDENT_LAST_NAME
FROM STUDENT_INFO
WHERE STUDENT_ID IN
(
    SELECT E.STUDENT_ID
    FROM ENROLLMENT_INFO E
    JOIN SECTION_INFO S
        ON E.SECTION_ID = S.SECTION_ID
    JOIN COURSE_INFO C
        ON S.COURSE_NO = C.COURSE_NO
    WHERE C.COURSE_NAME = 'Introduction to Java'
);
-- 7. Display the last name and enrollment date of students who enrolled on 22-Jan-2001.
SELECT STUDENT_LAST_NAME,
       ENROLLMENT_DATE
FROM STUDENT_INFO
JOIN ENROLLMENT_INFO
ON STUDENT_INFO.STUDENT_ID = ENROLLMENT_INFO.STUDENT_ID
WHERE ENROLLMENT_DATE = '2001-01-22';
-- 8. Display the student names who enrolled on Tuesday.
SELECT STUDENT_FIRST_NAME,
       STUDENT_LAST_NAME
FROM STUDENT_INFO
WHERE STUDENT_ID IN
(
    SELECT STUDENT_ID
    FROM ENROLLMENT_INFO
    WHERE DATENAME(WEEKDAY, ENROLLMENT_DATE) = 'Tuesday'
);
Correlated Subqueries (EXISTS)
-- 1. Display the student ID, section ID, and numeric grade where the numeric grade is less than the average grade for that section.
SELECT G1.STUDENT_ID,
       G1.SECTION_ID,
       G1.NUMERIC_GRADE
FROM GRADE_INFO G1
WHERE G1.NUMERIC_GRADE <
(
    SELECT AVG(G2.NUMERIC_GRADE)
    FROM GRADE_INFO G2
    WHERE G1.SECTION_ID = G2.SECTION_ID
);
-- 2. Display instructor details only if the instructor teaches a section.
SELECT *
FROM INSTRUCTOR_INFO I
WHERE EXISTS
(
    SELECT *
    FROM SECTION_INFO S
    WHERE S.INSTRUCTOR_ID = I.INSTRUCTOR_ID
);
-- 3. Display instructors who do not teach a section.
SELECT *
FROM INSTRUCTOR_INFO I
WHERE NOT EXISTS
(
    SELECT *
    FROM SECTION_INFO S
    WHERE S.INSTRUCTOR_ID = I.INSTRUCTOR_ID
);
-- 4. Display the names of students who are enrolled.
SELECT STUDENT_FIRST_NAME,
       STUDENT_LAST_NAME
FROM STUDENT_INFO S
WHERE EXISTS
(
    SELECT *
    FROM ENROLLMENT_INFO E
    WHERE E.STUDENT_ID = S.STUDENT_ID
);
-- 5. Display the courses enrolled by students.
SELECT *
FROM COURSE_INFO C
WHERE EXISTS
(
    SELECT *
    FROM SECTION_INFO S
    JOIN ENROLLMENT_INFO E
        ON S.SECTION_ID = E.SECTION_ID
    WHERE S.COURSE_NO = C.COURSE_NO
);
-- 6. Display the courses that do not have sections.
SELECT *
FROM COURSE_INFO C
WHERE NOT EXISTS
(
    SELECT *
    FROM SECTION_INFO S
    WHERE S.COURSE_NO = C.COURSE_NO
);
-- 7. Display the sections in which no student is enrolled.
SELECT *
FROM SECTION_INFO S
WHERE NOT EXISTS
(
    SELECT *
    FROM ENROLLMENT_INFO E
    WHERE E.SECTION_ID = S.SECTION_ID
);
Subqueries Using ANY and ALL
-- 1. Display the section ID and numeric grade where the numeric grade is less than the average numeric grade of either student 280 or 283.
SELECT SECTION_ID,
       NUMERIC_GRADE
FROM GRADE_INFO
WHERE NUMERIC_GRADE < ANY
(
    SELECT AVG(NUMERIC_GRADE)
    FROM GRADE_INFO
    WHERE STUDENT_ID IN (280,283)
    GROUP BY STUDENT_ID
);
-- 2. Display the section ID and numeric grade where the numeric grade is less than the average numeric grade of both students 280 and 283.
SELECT SECTION_ID,
       NUMERIC_GRADE
FROM GRADE_INFO
WHERE NUMERIC_GRADE < ALL
(
    SELECT AVG(NUMERIC_GRADE)
    FROM GRADE_INFO
    WHERE STUDENT_ID IN (280,283)
    GROUP BY STUDENT_ID
);