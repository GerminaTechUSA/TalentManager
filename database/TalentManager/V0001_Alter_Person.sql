begin 
    if(OBJECT_ID('dbo.Persons') is not null)
    begin
        if COLUMNPROPERTY(OBJECT_ID('dbo.Persons'), 'Family', 'ColumnId') is null 
        begin
          alter table Persons 
           add Family varchar(100) null; 
        end  
    end 
end 

begin 
    if(OBJECT_ID('dbo.Persons') is not null)
    begin
        if COLUMNPROPERTY(OBJECT_ID('dbo.Persons'), 'BusinessAreaID', 'ColumnId') is null 
        begin
          alter table Persons 
           add BusinessAreaID integer not null; 
        end

        if not exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_NAME = 'fk_Persons_BusinessAreas' and CONSTRAINT_TYPE = 'FOREIGN KEY')
        begin
            alter table Persons
              add constraint fk_Persons_BusinessAreas foreign key (BusinessAreaID) references BusinessAreas(Id);
        end
    end
end 

begin 
    if(OBJECT_ID('dbo.Persons') is not null)
    begin
        if COLUMNPROPERTY(OBJECT_ID('dbo.Persons'), 'Value', 'ColumnId') is null 
        begin
          alter table Persons 
           add [Value] varchar(50) not null; 
        end
    end
end
