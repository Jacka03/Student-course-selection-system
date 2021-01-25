/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     2021/1/11 10:51:33                           */
/*==============================================================*/



-- Type package declaration
create or replace package PDTypes  
as
    TYPE ref_cursor IS REF CURSOR;
end;

-- Integrity package declaration
create or replace package IntegrityPackage AS
 procedure InitNestLevel;
 function GetNestLevel return number;
 procedure NextNestLevel;
 procedure PreviousNestLevel;
 end IntegrityPackage;
/

-- Integrity package definition
create or replace package body IntegrityPackage AS
 NestLevel number;

-- Procedure to initialize the trigger nest level
 procedure InitNestLevel is
 begin
 NestLevel := 0;
 end;


-- Function to return the trigger nest level
 function GetNestLevel return number is
 begin
 if NestLevel is null then
     NestLevel := 0;
 end if;
 return(NestLevel);
 end;

-- Procedure to increase the trigger nest level
 procedure NextNestLevel is
 begin
 if NestLevel is null then
     NestLevel := 0;
 end if;
 NestLevel := NestLevel + 1;
 end;

-- Procedure to decrease the trigger nest level
 procedure PreviousNestLevel is
 begin
 NestLevel := NestLevel - 1;
 end;

 end IntegrityPackage;
/


drop trigger Trigger_1
/

alter table class
   drop constraint FK_CLASS_REFERENCE_TEACHER
/

alter table open
   drop constraint FK_OPEN_REFERENCE_CLASS
/

alter table open
   drop constraint FK_OPEN_REFERENCE_TEACHER_
/

alter table sc_choose
   drop constraint FK_SC_CHOOS_REFERENCE_STUDENT
/

alter table sc_choose
   drop constraint FK_SC_CHOOS_REFERENCE_COURSE
/

alter table student
   drop constraint FK_STUDENT_REFERENCE_CLASS
/

alter table teacher_group
   drop constraint FK_TEACHER__REFERENCE_TEACHER
/

alter table teacher_group
   drop constraint FK_TEACHER__REFERENCE_COURSE
/



drop view teaInfo
/

drop view stuInfo
/

drop view sc_chosen
/

drop view chosen
/

drop view choose_course
/

drop table class cascade constraints
/

drop table course cascade constraints
/

drop table open cascade constraints
/

drop table sc_choose cascade constraints
/

drop table student cascade constraints
/

drop table teacher cascade constraints
/

drop table teacher_group cascade constraints
/

/*==============================================================*/
/* Table: class                                                 */
/*==============================================================*/
create table class 
(
   class_id             NUMBER(10)           not null,
   teacher_id           NUMBER(10),
   class_name           VARCHAR(10),
   constraint PK_CLASS primary key (class_id)
)
/

/*==============================================================*/
/* Table: course                                                */
/*==============================================================*/
create table course 
(
   course_id            NUMBER(10)           not null,
   course_name          VARCHAR(50)          not null,
   course_type          CHAR(16),
   course_investigate   CHAR(15),
   course_credit        INT,
   course_class         INT,
   constraint PK_COURSE primary key (course_id)
)
/

/*==============================================================*/
/* Table: open                                                  */
/*==============================================================*/
create table open 
(
   new_course_id        NUMBER(10)           not null,
   teacher_id           NUMBER(10)           not null,
   class_id             NUMBER(10)           not null,
   course_id            NUMBER(10)           not null,
   course_time          VARCHAR(20),
   course_len           VARCHAR(20),
   course_count         int,
   constraint PK_OPEN primary key (new_course_id, teacher_id, class_id)
)
/

/*==============================================================*/
/* Table: sc_choose                                             */
/*==============================================================*/
create table sc_choose 
(
   student_id           NUMBER(10)           not null,
   new_course_id        NUMBER(10)           not null,
   course_id            NUMBER(10),
   student_grade        FLOAT,
   student_gpa          FLOAT,
   student_credit       INT,
   constraint PK_SC_CHOOSE primary key (student_id, new_course_id)
)
/

/*==============================================================*/
/* Table: student                                               */
/*==============================================================*/
create table student 
(
   student_id           NUMBER(10)           not null,
   class_id             NUMBER(10),
   student_name         VARCHAR(20)          not null,
   student_sex          CHAR(8),
   student_entime       DATE,
   student_department   VARCHAR(30),
   student_password     NUMBER(10)           not null,
   constraint PK_STUDENT primary key (student_id)
)
/

/*==============================================================*/
/* Table: teacher                                               */
/*==============================================================*/
create table teacher 
(
   teacher_id           NUMBER(10)           not null,
   teacher_name         VARCHAR(20),
   teacher_sex          CHAR(8),
   teacher_department   VARCHAR(50),
   teacher_position     VARCHAR(20),
   teacher_password     NUMBER(10),
   constraint PK_TEACHER primary key (teacher_id)
)
/

/*==============================================================*/
/* Table: teacher_group                                         */
/*==============================================================*/
create table teacher_group 
(
   course_id            NUMBER(10)           not null,
   teacher_id           NUMBER(10)           not null,
   constraint PK_TEACHER_GROUP primary key (teacher_id, course_id)
)
/

/*==============================================================*/
/* View: choose_course                                          */
/*==============================================================*/
create or replace view choose_course as
select student_id, new_course_id, course_name, teacher_name, course_time, course_len, course_type, 
course_investigate,course_credit, course_class
from open, course, student, teacher
where course_type='רҵѡ�޿�' and student.class_id = open.class_id and open.course_id=course.course_id
and open.teacher_id=teacher.teacher_id
with read only
/

/*==============================================================*/
/* View: chosen                                                 */
/*==============================================================*/
create or replace view chosen as
select sc_choose.student_id, sc_choose.new_course_id, course_name, course_type, course_investigate,
course_credit, course_class, student_grade, student_gpa, student_credit,teacher_name,course_time,course_len
from sc_choose, course, open, teacher, student, class
where sc_choose.course_id =course.course_id and open.new_course_id=sc_choose.new_course_id and 
open.teacher_id=teacher.teacher_id and student.student_id=sc_choose.student_id and student.class_id=class.class_id and open.class_id = student.class_id

with read only
/

/*==============================================================*/
/* View: sc_chosen                                              */
/*==============================================================*/
create or replace view sc_chosen as
select student_id, new_course_id, course_name, course_type, course_investigate,
course_credit, course_class, student_grade, student_gpa, student_credit
from sc_choose, course
where sc_choose.course_id =course.course_id
with read only
/

/*==============================================================*/
/* View: stuInfo                                                */
/*==============================================================*/
create or replace view stuInfo as
select student_id, student_name, student_sex, student_entime,student_department,
student_password, class_name, teacher_name
from student, class, teacher
where student.class_id=class.class_id and class.teacher_id=teacher.teacher_id
with read only
/

/*==============================================================*/
/* View: teaInfo                                                */
/*==============================================================*/
create or replace view teaInfo as
select teacher.teacher_id, teacher_name, teacher_sex, teacher_department,teacher_position,
 teacher_password, class_name
from teacher, class
where teacher.teacher_id=class.teacher_id
with read only
/

alter table class
   add constraint FK_CLASS_REFERENCE_TEACHER foreign key (teacher_id)
      references teacher (teacher_id)
/

alter table open
   add constraint FK_OPEN_REFERENCE_CLASS foreign key (class_id)
      references class (class_id)
/

alter table open
   add constraint FK_OPEN_REFERENCE_TEACHER_ foreign key (teacher_id, course_id)
      references teacher_group (teacher_id, course_id)
/

alter table sc_choose
   add constraint FK_SC_CHOOS_REFERENCE_STUDENT foreign key (student_id)
      references student (student_id)
/

alter table sc_choose
   add constraint FK_SC_CHOOS_REFERENCE_COURSE foreign key (course_id)
      references course (course_id)
/

alter table student
   add constraint FK_STUDENT_REFERENCE_CLASS foreign key (class_id)
      references class (class_id)
/

alter table teacher_group
   add constraint FK_TEACHER__REFERENCE_TEACHER foreign key (teacher_id)
      references teacher (teacher_id)
/

alter table teacher_group
   add constraint FK_TEACHER__REFERENCE_COURSE foreign key (course_id)
      references course (course_id)
/

