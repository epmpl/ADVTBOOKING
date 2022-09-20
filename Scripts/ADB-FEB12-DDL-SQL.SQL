/********************mimoh 0006796***********************************************/
ALTER TABLE PUB_CENT_MAST ADD CENTER_COMP_NAME VARCHAR(50)


***********************************************************************
CREATE  procedure chkpanclientagency

@pcompcode   as varchar(50),
@pbranch as varchar(50),
@pagency as varchar(50),
@ppanno as varchar(50),
@pextera  as varchar(50),
@pextera2  as varchar(50),
@pextera3  as varchar(50)


as

select "PAN_No" from agency_mast where "Comp_Code"=@pcompcode and ("Branch_code"=@pbranch OR @pbranch IS NULL) and "Agency_Name"=@pagency and "PAN_No"=@ppanno;


select "PAN_No" from cust_mast where "Comp_Code"=@pcompcode and  "Cust_Name"=@pagency and "PAN_No"=@ppanno


/********************mimoh 0006796***********************************************/