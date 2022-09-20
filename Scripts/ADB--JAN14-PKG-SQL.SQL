--14/01/2014==========================================================


ALTER PROCEDURE [dbo].[advtypbind]

@compcode as varchar(8)

AS

select Adv_Type_Code, Adv_Type_Name 
from adv_type_mast where comp_code=@compcode order by Adv_Type_Name

******************************************************************



ALTER PROCEDURE [dbo].[select_addType_with_plus]
@compcode as varchar(8),
@adtype as varchar(8)
AS
BEGIN
	

select combin_code,Package_Name from combin_mast where comp_code=@compcode and ad_type_code=@adtype
and combin_desc like '%+%'  order by Package_Name

   
END

********************************************************************


ALTER PROCEDURE [dbo].[select_edition_combin_code] 
	@packdes as varchar(250),
	@combin_code as varchar(250)
AS
BEGIN

		--select distinct edition_combin_code from combin_mast where package_name = @packdes and combin_code=@combin_code

	if exists(SELECT * FROM tbl_combinPrintEdition WHERE package_name=@packdes AND combin_code=@combin_code)
		begin
		 select 'Already added.' as combin_desc;
		end
	ELSE  
		BEGIN
		select distinct combin_desc from combin_mast where package_name = @packdes and combin_code=@combin_code
		END
	
END

***********************************************************************************

ALTER PROCEDURE [dbo].[execute_packbill]

@pcompcode as varchar(10),
@padtype as varchar(10),
@ppackagecode as varchar(30)

AS
BEGIN
declare @query as varchar(2000)
	set @query ='select * from tbl_combinPrintEdition where comp_code='''+@pcompcode+''''

if(@padtype <>'')
begin
set @query=@query+ '  and adtype = '''+@padtype+''''
end

if(@ppackagecode <>'')
begin
set @query=@query+ '  and combin_code = '''+@ppackagecode+''''
end

--and (adtype=@padtype or @padtype is null or @padtype='')
--and (combin_code=@ppackagecode or @ppackagecode is null or @ppackagecode='')
 
end
print(@query)
exec(@query)


********************************************************************************************


ALTER PROCEDURE [dbo].[SP_combinPrintEdition]
@prctype nvarchar(2000),
@pack_name NVARCHAR(250) ='',
@flag NVARCHAR(250) ='',
@combin_code NVARCHAR(250) ='',
@package_name NVARCHAR(250) ='',
@adtye nvarchar (250) = '',
@comp_code nvarchar (250) = ''


AS
BEGIN
	if @prctype = 'MOD_INSERT'
	BEGIN
	INSERT INTO tbl_combinPrintEdition (pack_name,flag,combin_code,package_name,creat_date,adtype,comp_code)
	VALUES(@pack_name,@flag,@package_name,@combin_code,getdate(),@adtye,@comp_code)
	END
	IF @prctype = 'MOD_UPDATE'
	BEGIN 
		UPDATE tbl_combinPrintEdition SET FLAG = @pack_name WHERE ID=@flag
	END
	
	IF @prctype = 'MOD_SELECT'
	BEGIN
			SELECT  distinct combin_code, (rtrim(package_name)+'~'+combin_code)as package_name,adtype  FROM tbl_combinPrintEdition WHERE comp_code=@pack_name
	END
	
	IF @prctype = 'MOD_SELECT_DISTINCT_PACKAGE_NAME'
	BEGIN
			SELECT distinct package_name FROM tbl_combinPrintEdition 
	END
END


============== start 18-01-2-14=============================

USE [erp]
GO
/****** Object:  StoredProcedure [dbo].[advtypbind]    Script Date: 01/18/2014 15:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[advtypbind]

@compcode as varchar(8)

AS

select Adv_Type_Code, Adv_Type_Name 
from adv_type_mast where comp_code=@compcode order by Adv_Type_Name
=========================

USE [erp]
GO
/****** Object:  StoredProcedure [dbo].[select_addType_with_plus]    Script Date: 01/18/2014 15:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[select_addType_with_plus]
@compcode as varchar(8),
@adtype as varchar(8)
AS
BEGIN
	

select Combin_Code,Package_Name from combin_mast where comp_code=@compcode and ad_type_code=@adtype
and combin_desc like '%+%'  order by Package_Name

   
END
====================================================================================


USE [erp]
GO
/****** Object:  StoredProcedure [dbo].[select_edition_combin_code]    Script Date: 01/18/2014 15:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[select_edition_combin_code] 
	@packdes as varchar(250),
	@combin_code as varchar(250)
AS
BEGIN

		--select distinct edition_combin_code from combin_mast where package_name = @packdes and combin_code=@combin_code

	if exists(SELECT * FROM tbl_combinPrintEdition WHERE package_name=@packdes AND combin_code=@combin_code)
		begin
		 select 'Already added.' as COMBIN_DESC;
		end
	ELSE  
		BEGIN
		select distinct COMBIN_DESC from combin_mast where package_name = @packdes and combin_code=@combin_code
		END
	
END
=====================================================================================================



USE [erp]
GO
/****** Object:  StoredProcedure [dbo].[execute_packbill]    Script Date: 01/18/2014 15:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[execute_packbill]

@pcompcode as varchar(10),
@padtype as varchar(10),
@ppackagecode as varchar(30)

AS
BEGIN
declare @query as varchar(2000)
	set @query ='select ID,pack_name AS "PACK_NAME",flag AS "FLAG",combin_code AS COMBIN_CODE,package_name AS PACKAGE_NAME,adtype,comp_code AS COMP_CODE from tbl_combinPrintEdition where comp_code='''+@pcompcode+''''

if(@padtype <>'')
begin
set @query=@query+ '  and adtype = '''+@padtype+''''
end

if(@ppackagecode <>'')
begin
set @query=@query+ '  and combin_code = '''+@ppackagecode+''''
end

--and (adtype=@padtype or @padtype is null or @padtype='')
--and (combin_code=@ppackagecode or @ppackagecode is null or @ppackagecode='')
 
end
print(@query)
exec(@query)

=============================================================================================


USE [erp]
GO
/****** Object:  StoredProcedure [dbo].[SP_combinPrintEdition]    Script Date: 01/18/2014 15:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_combinPrintEdition]
@prctype nvarchar(2000),
@pack_name NVARCHAR(250) ='',
@flag NVARCHAR(250) ='',
@combin_code NVARCHAR(250) ='',
@package_name NVARCHAR(250) ='',
@adtye nvarchar (250) = '',
@comp_code nvarchar (250) = ''


AS
BEGIN
	if @prctype = 'MOD_INSERT'
	BEGIN
	INSERT INTO tbl_combinPrintEdition (pack_name,flag,combin_code,package_name,creat_date,adtype,comp_code)
	VALUES(@pack_name,@flag,@package_name,@combin_code,getdate(),@adtye,@comp_code)
	END
	IF @prctype = 'MOD_UPDATE'
	BEGIN 
		UPDATE tbl_combinPrintEdition SET FLAG = @pack_name WHERE ID=@flag
	END
	
	IF @prctype = 'MOD_SELECT'
	BEGIN
			SELECT  distinct combin_code as "COMBIN_CODE", (rtrim(package_name)+'~'+combin_code)as "PACKAGE_NAME",adtype AS "ADTYPE"  FROM tbl_combinPrintEdition WHERE comp_code=@pack_name
	END
	
	IF @prctype = 'MOD_SELECT_DISTINCT_PACKAGE_NAME'
	BEGIN
			SELECT distinct package_name FROM tbl_combinPrintEdition 
	END
END





==================end 18-01-2014==============================