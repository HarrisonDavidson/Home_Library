USE [HomeLibrary]
GO

set identity_insert [Movies] on
insert into [Movies] ([Id], [Name], [YearReleased], [Director], [Image], [Format], [Notes])
values (1, 'Full Metal Jacket', '1987', 'Stanley Kubrick', 'www', 'DVD', 'My 2nd favorite movie'), 
(2, 'The Lord of the Rings: The Fellowship of the Ring', '2001', 'Peter Jackson', 'www', 'DVD', 'My all time favorite movie'),
(3, 'Pulp Fiction', '1994', 'Quentin Tarantino', 'www', 'VHS', 'My old favorite movie')
set identity_insert [Movies] off