Create Procedure InsertAddressBook
(
  @FirstName varchar(100),
  @LastName varchar(100),
  @Address varchar(200),
  @City varchar(50),
  @State varchar(100),
  @ZipCode bigint,
  @PhoneNumber bigint,
  @Email varchar(50)
)
As
Begin
Insert Into Address_Book_Table(FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,Email) values(@FirstName,@LastName,@Address,@City,@State,@ZipCode,@PhoneNumber,@Email)
End
