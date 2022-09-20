



ALTER PROCEDURE [dbo].[paymantinsert]

@paycode as varchar(8),
@payname as varchar(30),
@compcode as varchar(8),
@userid  as varchar(8),
@alias as varchar(8),
@CASH AS VARCHAR(1)

AS





begin

insert into payment_mode_mast([Comp_Code]
           ,[Pay_Mode_Code]
           ,[Payment_Mode_Name]
           ,[Userid]
           ,[Creation_Datetime]
           ,[PAYMENT_MODE_ALIAS],CASHDISCOUNT) values(  @compcode, @paycode, @payname, @userid, getdate(),@alias,@CASH )

end


