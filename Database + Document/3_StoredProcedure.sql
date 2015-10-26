drop function add_user(text,text);

create or replace function add_user(name text, password text)
	returns void
as $$
begin
	insert into LoginTable values (name, md5(password)::bytea);
end;
$$ language plpgsql;

--select * from add_user('Abad', 'passwd');
--select * from add_user('John', 'qwerty');
--select * from add_user('Annie', '123abc');
--select * from add_user('Greg', 'atlantis');
--select * from add_user('Meghan', 'abc123');

--select * from LoginTable;