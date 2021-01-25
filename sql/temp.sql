SELECT
    "A1"."STUDENT_ID"           "STUDENT_ID",
    "A1"."STUDENT_NAME"         "STUDENT_NAME",
    "A1"."STUDENT_SEX"          "STUDENT_SEX",
    "A1"."STUDENT_ENTIME"       "STUDENT_ENTIME",
    "A1"."STUDENT_DEPARTMENT"   "STUDENT_DEPARTMENT",
    "A1"."STUDENT_PASSWORD"     "STUDENT_PASSWORD",
    "A1"."CLASS_NAME"           "CLASS_NAME",
    "A1"."TEACHER_NAME"         "TEACHER_NAME"
FROM
    (
        SELECT
            "A4"."STUDENT_ID"           "STUDENT_ID",
            "A4"."STUDENT_NAME"         "STUDENT_NAME",
            "A4"."STUDENT_SEX"          "STUDENT_SEX",
            "A4"."STUDENT_ENTIME"       "STUDENT_ENTIME",
            "A4"."STUDENT_DEPARTMENT"   "STUDENT_DEPARTMENT",
            "A4"."STUDENT_PASSWORD"     "STUDENT_PASSWORD",
            "A3"."CLASS_NAME"           "CLASS_NAME",
            "A2"."TEACHER_NAME"         "TEACHER_NAME"
        FROM
            "C##EXP"."STUDENT"   "A4",
            "C##EXP"."CLASS"     "A3",
            "C##EXP"."TEACHER"   "A2"
        WHERE
            "A4"."CLASS_ID" = "A3"."CLASS_ID"
            AND "A3"."TEACHER_ID" = "A2"."TEACHER_ID"
    ) "A1"
WHERE
    "A1"."STUDENT_ID" = '1806100166'
    AND "A1"."STUDENT_PASSWORD" = '123456'