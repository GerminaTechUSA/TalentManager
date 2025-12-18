if(DB_ID(N'TalentManagerDB') is null)
    begin
    create database TalentManagerDB;
    end
go
 
if (OBJECT_ID (N'dbo.Roles', N'U') is null)
    begin
    create table Roles ( Id     integer     not null identity unique
                       , [Name] varchar(60) not null
                       , Notes  text            null
                       , constraint pk_Roles primary key (Id)
                       );
    end
go
 
if (OBJECT_ID (N'dbo.Skills', N'U') is null)
    begin
    create table Skills ( Id        integer     not null identity unique
                        , [Name]    varchar(60) not null
                        , [Type]    varchar(20) not null
                        , constraint pk_Skills primary key (Id)
                        );
    end
go
 
if (OBJECT_ID (N'dbo.Hobbies', N'U') is null)
    begin
    create table Hobbies ( Id        integer     not null identity unique
                         , [Name]    varchar(60) not null
                         , constraint pk_Hobbies primary key (Id)
                         );
    end
go
 
if (OBJECT_ID (N'dbo.Companies', N'U') is null)
    begin
    create table Companies ( Id        integer     not null identity unique
                           , [Name]    varchar(60) not null
                           , constraint pk_Companies primary key (Id)
                           );
    end
go
 
 
if (OBJECT_ID (N'dbo.BusinessAreas', N'U') is null)
    begin
    create table BusinessAreas ( Id         integer     not null identity unique
                               , [Name]     varchar(60) not null
                               , Hierarchy  varchar(10) not null
                               , constraint pk_BusinessAreas primary key (Id)
                               );
    end
go
 
if (OBJECT_ID (N'dbo.ExperienceTypes', N'U') is null)
    begin
    create table ExperienceTypes ( Id        integer     not null identity unique
                                 , [Name]    varchar(60) not null
                                 , constraint pk_ExperienceTypes primary key (Id)
                                 );
    end
go
  
if (OBJECT_ID (N'dbo.Softwares', N'U') is null)
    begin
    create table Softwares ( Id        integer     not null identity unique
                           , [Name]    varchar(60) not null
                           , constraint pk_Softwares primary key (Id)
                           );
    end
go

if (OBJECT_ID (N'dbo.Modules', N'U') is null)
    begin
    create table Modules ( Id               integer     not null identity unique
                         , [Name]           varchar(60) not null
                         , SoftwareId       integer     not null
                         , Notes            text            null
                         , TargetAudience   varchar(20) not null
                         , constraint pk_Modules primary key (Id)
                         , constraint fk_Modules_Softwares foreign key (SoftwareId) references Softwares(Id)
                         );
    end
go
 
if (OBJECT_ID (N'dbo.Persons', N'U') is null)
    begin
    create table Persons ( Id               integer         not null identity unique
                         , [Name]           varchar(60)     not null
                         , Email            varchar(255)    not null
                         , Phone            varchar(20)     not null
                         , Gender           char(1)         not null
                         , Document         varchar(100)    not null
                         , BirthDate        datetime        not null
                         , [Password]       varchar(20)     not null
                         , BirthLocation    varchar(50)     not null
                         , [Address]        varchar(50)     not null
                         , EnglishLevel     integer         not null
                         , Notes            text                null
                         , Picture          varchar(max)        null
                         , IsAdm            bit             not null    default(0)
                         , RoleId           integer         not null
                         , CompanyId        integer         not null
                         , constraint pk_Persons primary key (Id)
                         , constraint fk_Persons_Roles      foreign key (RoleId)    references Roles(Id)
                         , constraint fk_Persons_Companies  foreign key (CompanyId) references Companies(Id)
                         );
    end
go
 
if (OBJECT_ID (N'dbo.PersonHobbies', N'U') is null)
    begin
    create table PersonHobbies ( Id        integer  not null identity unique
                               , PersonId  integer  not null
                               , HobbyId   integer  not null
                               , constraint pk_PersonHobbies primary key (Id)
                               , constraint fk_PersonHobbies_Persons foreign key (PersonId) references Persons(Id)
                               , constraint fk_PersonHobbies_Hobbies foreign key (HobbyId)  references Hobbies(Id)
                               );
    end
go

if (OBJECT_ID (N'dbo.Experiences', N'U') is null)
    begin
    create table Experiences ( Id                   integer     not null identity unique
                             , [Name]               varchar(60) not null
                             , Notes                text            null
                             , Client               varchar(60)     null
                             , CompanyId            integer         null
                             , BusinessAreaId       integer         null
                             , ExperienceTypeId     integer         null
                             , SoftwareId           integer         null
                             , constraint pk_Experiences primary key (Id)
                             , constraint fk_Experiences_Companies       foreign key (CompanyId)         references Companies(Id)
                             , constraint fk_Experiences_BusinessAreas   foreign key (BusinessAreaId)    references BusinessAreas(Id)
                             , constraint fk_Experiences_ExperienceTypes foreign key (ExperienceTypeId)  references ExperienceTypes(Id)
                             , constraint fk_Experiences_Softwares       foreign key (SoftwareId)        references Softwares(Id)
                             );
    end
go

if (OBJECT_ID (N'dbo.ExperiencePersons', N'U') is null)
    begin
    create table ExperiencePersons ( Id             integer     not null identity unique
                                   , StartDate      datetime    not null
                                   , EndDate        datetime        null
                                   , Notes          text            null
                                   , Ranking        integer     not null
                                   , [Hours]        time        not null
                                   , ExperienceId   integer     not null
                                   , PersonId       integer     not null
                                   , SkillId        integer     not null
                                   , constraint pk_ExperinencePersons primary key (Id)
                                   , constraint fk_ExperinencePersons_Persons     foreign key (PersonId)     references Persons(Id)
                                   , constraint fk_ExperinencePersons_Experiences foreign key (ExperienceId) references Experiences(Id)
                                   , constraint fk_ExperinencePersons_Skills      foreign key (SkillId)      references Skills(Id)
                                   );
    end
go
 
 