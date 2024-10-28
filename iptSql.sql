-- Database: PatientBookingSystem

-- DROP DATABASE IF EXISTS "PatientBookingSystem";

-- CREATE DATABASE "PatientBookingSystem"
--     WITH
--     OWNER = postgres
--     ENCODING = 'UTF8'
--     LC_COLLATE = 'English_United States.1252'
--     LC_CTYPE = 'English_United States.1252'
--     LOCALE_PROVIDER = 'libc'
--     TABLESPACE = pg_default
--     CONNECTION LIMIT = -1
--     IS_TEMPLATE = False;

create type categories as enum('childCare','cardio','diabetes','general');
create type status as enum('accepted','rejected','pending','completed');


CREATE TABLE IF NOT EXISTS public."Doctors"
(
    doctor_id serial,
    email character varying(255) NOT NULL,
    password character varying(255) NOT NULL,
    full_name character varying(255) NOT NULL,
    price integer NOT NULL,
	category categories NOT NULL,
    PRIMARY KEY (doctor_id)
);

CREATE TABLE IF NOT EXISTS public."Patients"
(
    patient_id serial,
    full_name character varying(255) NOT NULL,
    email character varying(255) NOT NULL,
    password character varying(255) NOT NULL,
    PRIMARY KEY (patient_id)
);

CREATE TABLE IF NOT EXISTS public."Bookings"
(
    "Doctors_doctor_id" serial NOT NULL,
    "Patients_patient_id" serial NOT NULL,
    booking_id serial,
    description text,
    "BookingTime" timestamp without time zone NOT NULL,
	bookingStatus status NOT NULL,
    PRIMARY KEY (booking_id)
);

CREATE TABLE IF NOT EXISTS public."Reviews"
(
    review_id serial,
    description text NOT NULL,
    stars integer NOT NULL,
    booking_id serial NOT NULL,
    PRIMARY KEY (review_id)
);

ALTER TABLE IF EXISTS public."Bookings"
    ADD FOREIGN KEY ("Doctors_doctor_id")
    REFERENCES public."Doctors" (doctor_id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public."Bookings"
    ADD FOREIGN KEY ("Patients_patient_id")
    REFERENCES public."Patients" (patient_id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public."Reviews"
    ADD CONSTRAINT booking_id FOREIGN KEY (booking_id)
    REFERENCES public."Bookings" (booking_id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;

