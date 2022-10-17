drop table gramaticas;

create table gramaticas(
	id  int identity primary key,
	identificador varchar(15),
	estado0 varchar(15),
	estado1 varchar(15),
	estado2 varchar(15),
	estado3 varchar(15),
	estado4 varchar(15),
	estado5 varchar(15),
	estado6 varchar(15),
	estado7 varchar(15),
	estado8 varchar(15),
	estado9 varchar(15),
	estado10 varchar(15),
	estado11 varchar(15),
	estado12 varchar(15),
	estado13 varchar(15),
	estado14 varchar(15),
	estado15 varchar(15),
	estado16 varchar(15),
	estado17 varchar(15),
	estado18 varchar(15),
	estado19 varchar(15),
	estado20 varchar(15),
);

--insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, null);

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'IDEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPAS', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'IDEN', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CNEN', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CNRE', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CNEX', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CDNA', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_ASIG', null, null, null, 'CE12');

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'IDEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CNEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CNRE', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CNEX', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPSU', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPRES', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPMU', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPDI', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPEX', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'IDEN', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CNEN ', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CNRE', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'CNEX', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_ARIT', null, null, null, 'CE12');

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'IDEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CNEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CNRE', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CNEX', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPR1', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPR2', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPR3', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPR4', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPR5', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPR6', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_REL', null, null, 'IDEN', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_REL', null, null, 'CNEN ', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_REL', null, null, 'CNRE', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_REL', null, null, 'CNEX', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CE14', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'IDEN', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CNEN', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CNRE', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CNEX', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPR1', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPR2', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPR3', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPR4', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPR5', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPR6', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, 'IDEN');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, 'CNEN ');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, 'CNRE');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, 'CNEX');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3, estado4) values ('INS_REL', null, null, null, null, 'CE15');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'INS_REL', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_REL', null, null, 'CE15', null);

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'IDEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_DECLA', null, 'CE12', null, null);

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'IDEN', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'INS_REL', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPLA', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'OPLO', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_LOG', null, null, 'IDEN', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_LOG', null, null, 'INS_REL', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'CE14', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'IDEN', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'INS_REL', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPLA', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'OPLO', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, 'IDEN');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, null, 'INS_REL');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3, estado4) values ('INS_LOG', null, null, null, null, 'CE15');
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'INS_LOG', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_LOG', null, null, 'CE15', null);

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_COM', 'COME', null, null, null);

insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'PR04', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'IDEN', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CNEN', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CNRE', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CNEX', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CDNA', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_E/S', null, null, 'CE12', null);


insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, 'PR05', null, null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, 'CE14', null, null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'INS_REL', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values (null, null, null, 'INS_LOG', null);
insert into gramaticas (identificador, estado0, estado1, estado2, estado3) values ('INS_IF', null, null, null, 'CE15');