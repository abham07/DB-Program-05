drop table if exists LoginTable cascade;

create table LoginTable
(
	name text primary key check (length(name) > 0),
	password bytea
);

comment on table  LoginTable is 'An authentication database.';
comment on column LoginTable.name is 'Names of all users within database.';
comment on column LoginTable.password is 'MD5 Hash passwords of all users within database';
