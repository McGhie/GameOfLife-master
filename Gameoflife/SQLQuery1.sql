create table [User]
(
    UserID int not null identity,
    Email nvarchar(256) not null,
    Password nvarchar(128) not null,
    FirstName nvarchar(max) not null,
    LastName nvarchar(max) not null,
    IsAdmin bit not null,
    constraint PK_User primary key (UserID),
    constraint UN_User_Email unique (Email)
);

create table UserTemplate
(
    UserTemplateID int identity not null,
    UserID int not null,
    Name nvarchar(max) not null,
    Height int not null,
    Width int not null,
    Cells nvarchar(max) not null,
    constraint PK_UserTemplate primary key (UserTemplateID),
    constraint FK_UserTemplate_To_User foreign key 
    (UserID) references [User] (UserID)
);

create table UserGame
(
    UserGameID int identity not null,
    UserID int not null,
    Name nvarchar(max) not null,
    Height int not null,
    Width int not null,
    Cells nvarchar(max) not null,
    constraint PK_UserGame primary key (UserGameID),
    constraint FK_UserGame_To_User foreign key 
    (UserID) references [User] (UserID)
);

insert into [User] 
(Email, Password, FirstName, LastName, IsAdmin) 
values 
(N'admin@gmail.com', 'rmit', 'Site', 'Admin', 1);
-- (N'admin@gmail.com', N'$2a$06$aa3rgX0rr7TcdxFPFUHRj.8vlRzfOd52pwLkJvaCEL5ZWGT2aL/f6', 'Site', 'Admin', 1);
