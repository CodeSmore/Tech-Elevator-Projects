-- Your  sql to define your tables and constrains goes in this file
Begin Transaction

CREATE TABLE super_pet (
	id integer NOT NULL,
	name varchar(64) NOT NULL,
	type varchar(64) NOT NULL,
	age integer NOT NULL,
	owner_first_name varchar(64) NOT NULL,
	owner_last_name varchar(64) NOT NULL,

	CONSTRAINT pk_pet_id PRIMARY KEY (id),
	CONSTRAINT pet_type_check CHECK ((type = 'DOG') OR (type = 'CAT') OR (type = 'BIRD'))
);

CREATE TABLE petprocedure (
	id integer NOT NULL,
	name varchar(64) NOT NULL,
	pet_id integer NOT NULL,
	cost integer NOT NULL,

	CONSTRAINT pk_petprocedure_id PRIMARY KEY (id),
	CONSTRAINT fk_pet_id FOREIGN KEY (pet_id) REFERENCES super_pet(id),
);

CREATE TABLE appointment (
	id integer NOT NULL,
	appointment_date date NOT NULL,
	pet_id integer NOT NULL,
	procedure_id integer NOT NULL,

	CONSTRAINT pk_appointment_id PRIMARY KEY (id),
	CONSTRAINT fk_super_pet_id FOREIGN KEY (pet_id) REFERENCES super_pet(id),
	CONSTRAINT fk_procedure_id FOREIGN KEY (procedure_id) REFERENCES petprocedure(id)
);



INSERT INTO super_pet (id, name, type, age, owner_first_name, owner_last_name) VALUES (1, 'Zoey', 'DOG', 12, 'Melissa', 'Petrov');
INSERT INTO super_pet (id, name, type, age, owner_first_name, owner_last_name) VALUES (2, 'Lucy', 'CAT', 3, 'Peter', 'Kirk');
INSERT INTO super_pet (id, name, type, age, owner_first_name, owner_last_name) VALUES (3, 'Prim', 'CAT', 5, 'John', 'Fulton');

INSERT INTO petprocedure (id, name, pet_id, cost) VALUES (302, 'Rabies Vaccination', 1, 20000);
INSERT INTO petprocedure (id, name, pet_id, cost) VALUES (113, 'Bordetella Vaccination', 2, 1);
INSERT INTO petprocedure (id, name, pet_id, cost) VALUES (25, 'Nail-Trim', 3, 5000000);
INSERT INTO petprocedure (id, name, pet_id, cost) VALUES (999, 'Anal Gland Checkup', 1, 20);

INSERT INTO appointment (id, appointment_date, pet_id, procedure_id) VALUES (2, '1912-01-20', 2, 113);
INSERT INTO appointment (id, appointment_date, pet_id, procedure_id) VALUES (3, '2010-06-29', 1, 302);
INSERT INTO appointment (id, appointment_date, pet_id, procedure_id) VALUES (1, '1990-12-01', 1, 999);
INSERT INTO appointment (id, appointment_date, pet_id, procedure_id) VALUES (4, '2111-01-01', 3, 25);

ROLLBACK
COMMIT;

SELECT *
FROM appointment

SELECT *
FROM super_pet

SELECT *
FROM petprocedure

SELECT pro.pet_id
FROM petprocedure pro
JOIN super_pet sp ON sp.id = pro.pet_id

SELECT SUM(pro.cost)
FROM petprocedure pro
WHERE pro.pet_id = 1
