// JScript File
//var flag1="0";
//var flag2="0";
//var show="0";

var ginput;


//global for execute and delete.
var gDay;
var gPubCode;
var gCenterCode;
var gEdiCode;
var gSupCode;
var gCompCode;

var del=0;
//for checking duplicate recode is presented or not
var dup="n";

/////dataset declared globally for execution
var ds_execute;

//rowN as row number for navigation.
var rowN=0;


//This variable is used for checking that the data is saving or modifying; 1 for modify(uddate) and 0 for new(insert)
var modify="0";

//This variable is used for receiving the value of dataset return by the cs as parameter.


function adDDPNew()
{
    modify="0";
    //document.getElementById();
    
    document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').enable = true;	
	document.getElementById('btnQuery').disabled=true;
	
	document.getElementById('drpDay').disabled=false;
	document.getElementById('drpPName').disabled=false;
	document.getElementById('drpPCName').disabled=false;
	document.getElementById('drpEdition').disabled=false;
	document.getElementById('drpSuppliment').disabled=false;
	document.getElementById('txtNPages').disabled=false;
	document.getElementById('txtFrom').disabled=false;
	document.getElementById('txtTo').disabled=false;
	
	document.getElementById('hiddenRecordId').value="";
	
	chkstatus(FlagStatus);
	
	
	var compcode=document.getElementById('hiddencompcode').value;
	//addummydaypages.fillPubName(compcode,resFillPubName);//calling a addummydaypages.aspx.cs function which returns a dataset
	document.getElementById('drpDay').focus();
	return false;
}

//*************This function takes dataset object as parameter and fill the Publication Name dropdown********
function resFillPubName(response)
{
    var ds=response.value;
    pName = document.getElementById("drpPName");
    pName.options.length = 1; 
    pName.options[0]=new Option("--Select Publication--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pName.options[pName.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Name,ds.Tables[0].Rows[i].Pub_Code);
            pName.options.length;
        }
    }
}
//**********************************************************************************************************


//calling a addummydaypages.aspx.cs function which returns a dataset and pass to called function fillPCName
function fillCenter_client()
{
    var pubcode=document.getElementById('drpPName');
    if(pubcode.value=="0")//Cheching if Publication Name dropdown is blank than blank the Other dropdowns
    {
        var PCName=document.getElementById("drpPCName");
        PCName.options.length=0;
        PCName.options[0]=new Option("--Select Center Name--","0");
        
        var ediName=document.getElementById("drpEdition");
        ediName.options.length=0;
        ediName.options.value="";
        ediName.options[0]=new Option("--Select Edition--","0");
        
        supp=document.getElementById("drpSuppliment");
        supp.options.length=0;
        supp.options.value="";
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    {
        if(modify=="1")
        {
            var ediName=document.getElementById("drpEdition");
            ediName.options.length=0;
            ediName.options[0]=new Option("--Select Edition--","0");
            ediName.value="0";
            
            var ediName=document.getElementById("drpSuppliment");
            ediName.options.length=0;
            ediName.options[0]=new Option("--Select Suppliment--","0");
            ediName.value="0";
            
        }
        addummydaypages.fillPCName(resFillPCName);
    }
}
//**********************************************************************************************************

//*******This function takes dataset object as parameter and fill the Publication Center Name dropdown******
function resFillPCName(response)
{
    var ds=response.value;
    pCName = document.getElementById("drpPCName");
    pCName.options.length = 1; 
    pCName.options[0]=new Option("--Select Center Name--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pCName.options[pCName.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Cent_name,ds.Tables[0].Rows[i].Pub_cent_Code);
            pCName.options.length;
        }
    }
    if(ds_execute!=undefined && ds_execute!="" && ds_execute!=null)
    {
        document.getElementById("drpPCName").value=ds_execute.Tables[0].Rows[rowN].center_code;
        fillEdiName_client();
    }
}
//**********************************************************************************************************

//calling a addummydaypages.aspx.cs function which returns a dataset and pass to called function resFillEdiName
function fillEdiName_client()
{
    var pubcode=document.getElementById('drpPName');
    var pubcenter=document.getElementById('drpPCName');    
    
    if(pubcenter.value=="0")//Cheching if Publication Name dropdown is blank than blank the Other dropdowns
    {
        var ediName=document.getElementById("drpEdition");
        ediName.options.length=0;
        ediName.options[0]=new Option("--Select Edition--","0");
        
        supp=document.getElementById("drpSuppliment");
        supp.options.length=0;
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    {
        var pubcodeV=pubcode.value;
        var pubcenterV=pubcenter.value;
        addummydaypages.fillEdiName(pubcodeV,pubcenterV,resFillEdiName);
    }
}
//**********************************************************************************************************

//*******This function takes dataset object as parameter and fill the Edition Name dropdown*****************
function resFillEdiName(response)
{
    var ds=response.value;
    ediName = document.getElementById("drpEdition");
    ediName.options.length = 1; 
    ediName.options[0]=new Option("--Select Edition--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            ediName.options[ediName.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Name,ds.Tables[0].Rows[i].Edition_code);
            ediName.options.length;
        }
    }
    
    if(modify=="1")
    {
        var ediName=document.getElementById("drpEdition");
        document.getElementById("drpSuppliment").value="0";
        //ediName.options.length=0;
        //ediName.options[0]=new Option("--Select Suppliment--","0");
        ds_execute=null;
        ediName.value="0";
        
        
    }
    
    if(ds_execute!=undefined && ds_execute!="" && ds_execute!=null)
    {
        document.getElementById("drpEdition").value=ds_execute.Tables[0].Rows[rowN].edition_code;
        fillSuppliment_client();
    }
}
//**********************************************************************************************************

//calling a addummydaypages.aspx.cs function which returns a dataset and pass to called function resFillfillSuppliment
function fillSuppliment_client()
{
    var pubcodesupp=document.getElementById('drpPName');
    var pubeditsupp=document.getElementById('drpEdition');
    if(pubeditsupp.value=="0")
    {
        supp=document.getElementById("drpSuppliment");
        supp.options.length=0;
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    {
        //var pubcodesuppV=pubcodesupp.value;
        var compcodesupp=document.getElementById('hiddencompcode').value;
        var pubeditsuppV=pubeditsupp.value;
        addummydaypages.fillSuppliment(compcodesupp,pubeditsuppV,resFillSuppliment);
    }
}
//**********************************************************************************************************

//*******This function takes dataset object as parameter and fill the Suppliment dropdown*****************
function resFillSuppliment(response)
{
    var ds=response.value;
    supp = document.getElementById("drpSuppliment");
    supp.options.length = 1; 
    supp.options[0]=new Option("--Select Suppliment--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            supp.options[supp.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
            supp.options.length;
        }
        
    }
    supp.options[supp.options.length] = new Option("MN","MN");
    
    
    if(ds_execute!=undefined && ds_execute!="" && ds_execute!=null)
    {
        document.getElementById("drpSuppliment").value=ds_execute.Tables[0].Rows[rowN].SUB_PUB;
    
    }
}
//*********************************************************************************************************

//*********************************************************************************************************
function adDDPModify_client()
{
    chkstatus(FlagStatus);
    modify="1";
    ds_ds_execute=null;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnnext').disabled=true;
    document.getElementById('btnlast').disabled=true;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnSave').disabled=false;
    
     document.getElementById('drpDay').disabled=false;
	document.getElementById('drpPName').disabled=false;
	document.getElementById('drpPCName').disabled=false;
	document.getElementById('drpEdition').disabled=false;
	document.getElementById('drpSuppliment').disabled=false;
	document.getElementById('txtNPages').disabled=false;
	document.getElementById('txtFrom').disabled=false;
	document.getElementById('txtTo').disabled=false;
	
	return false;
}
//*********************************************************************************************************

//*********************************************************************************************************
//*****This function is worked on save button click and checks the call chkDup for duplicate record********
function adDDPSave_client()
{
    
    var fromDate=document.getElementById('txtFrom').value;
    var toDate=document.getElementById('txtTo').value;
    var fd=new Date(fromDate);
    var td=new Date(toDate);
    
    var day=document.getElementById('drpDay').value;
    var pubCode=document.getElementById('drpPName').value;
    var centerCode=document.getElementById('drpPCName').value;
    var ediCode=document.getElementById('drpEdition').value;
    var supCode=document.getElementById('drpSuppliment').value;
    var nPages=document.getElementById('txtNPages').value;
    var dFrom=document.getElementById('txtFrom').value;
    var dTo=document.getElementById('txtTo').value;
    
    var compCode=document.getElementById('hiddencompcode').value;
    var userId=document.getElementById('hiddenuserid').value;
    
    if(day=="0"  || day=="")
    {
        alert("Please Enter The Publication Day");
        document.getElementById('drpDay').value="0"
        document.getElementById('drpDay').focus();
        return false;
    }
    
    else if(pubCode=="0"  || pubCode=="")
    {
        alert("Please Enter The Publication");
        document.getElementById('drpPName').value="0"
        document.getElementById('drpPName').focus();
        return false;
    }
    
    else if(centerCode=="0"  || centerCode=="")
    {
        alert("Please Enter The Publication Center Name");
        document.getElementById('drpPCName').value="0"
        document.getElementById('drpPCName').focus();
        return false;
    }
    
    else if(ediCode=="0"  || ediCode=="")
    {
        alert("Please Enter The Edition");
        document.getElementById('drpEdition').value="0"
        document.getElementById('drpEdition').focus();
        return false;
    }
    
    else if(supCode=="0"  || supCode=="")
    {
        alert("Please Enter The Suppliment");
        document.getElementById('drpSuppliment').value="0"
        document.getElementById('drpSuppliment').focus();
        return false;
    }
    
    if(td<fd)
    {
        alert('To date should be greater than from date');
        document.getElementById('txtTo').value="";
		document.getElementById('txtTo').focus();
        return false;
    }
    
    var recordId=document.getElementById('hiddenRecordId').value;
    
    
    addummydaypages.chkDup(day,pubCode,centerCode,ediCode,supCode,recordId,resChkDup);
    return false;
    
//    else
//    {
//        if(gDay==day && gPubCode==pubCode && gCenterCode==centerCode && gEdiCode && gSupCode==supCode)
//        {
//            addummydaypages.saveUpdate(recordId,day,pubCode,centerCode,ediCode,supCode,nPages,dFrom,dTo,compCode,userId);
//            alert("Your Data Modified Successfully");
//            
//            document.getElementById('btnfirst').disabled=false;
//            document.getElementById('btnprevious').disabled=false;
//            document.getElementById('btnnext').disabled=false;
//            document.getElementById('btnlast').disabled=false;
//            
//            document.getElementById('btnSave').disabled=true;
//            document.getElementById('btnNew').disabled = false;	
//            document.getElementById('btnQuery').disabled=false;
//            document.getElementById('btnExecute').disabled=true;
//            
//            document.getElementById('drpDay').disabled=true;
//            document.getElementById('drpPName').disabled=true;
//            document.getElementById('drpPCName').disabled=true;
//            document.getElementById('drpEdition').disabled=true;
//            document.getElementById('drpSuppliment').disabled=true;
//            document.getElementById('txtNPages').disabled=true;
//            document.getElementById('txtFrom').disabled=true;
//            document.getElementById('txtTo').disabled=true;
//            return false;
//        }
//        else
//        {
//            //Function calling for duplicate record checking
//            addummydaypages.chkDup(day,pubCode,centerCode,ediCode,supCode,recordId,resChkDup);
//            return false;
//        }
    //}
}

//*****This function is used to Insert and Update the record using adDDPInsert and adDDPUpdate S.Ps*********
function resChkDup(response)
{
    dup=response.value;
    if(dup=="y")
    {
        alert("This Data has already been assigned");
        document.getElementById('drpDay').focus();
    }
    else
    {
        var day=document.getElementById('drpDay').value;
        var pubCode=document.getElementById('drpPName').value;
        var centerCode=document.getElementById('drpPCName').value;
        var ediCode=document.getElementById('drpEdition').value;
        var supCode=document.getElementById('drpSuppliment').value;
        var nPages=document.getElementById('txtNPages').value;
        var dFrom=document.getElementById('txtFrom').value;
        var dTo=document.getElementById('txtTo').value;
        
        var compCode=document.getElementById('hiddencompcode').value;
        var userId=document.getElementById('hiddenuserid').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        
        if(modify=="0")
        {
            addummydaypages.saveInsert(day,pubCode,centerCode,ediCode,supCode,nPages,dFrom,dTo,compCode,userId,dateformat);
            
            alert("Data Saved Successfully");
            
            document.getElementById('drpDay').value="0";
            document.getElementById('drpPName').value="0";
            
            document.getElementById('drpPCName').length=0;
            document.getElementById('drpPCName').value="";
            
            document.getElementById('drpEdition').length=0;
            document.getElementById('drpEdition').value="";
            
            document.getElementById('drpSuppliment').length=0;
            document.getElementById('drpSuppliment').value="";
            
            document.getElementById('txtNPages').value="";
            
            document.getElementById('txtFrom').value="";
            document.getElementById('txtTo').value="";
            
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnNew').disabled = false;	
            document.getElementById('btnQuery').disabled=false;
        	
            document.getElementById('drpDay').disabled=true;
            document.getElementById('drpPName').disabled=true;
            document.getElementById('drpPCName').disabled=true;
            document.getElementById('drpEdition').disabled=true;
            document.getElementById('drpSuppliment').disabled=true;
            document.getElementById('txtNPages').disabled=true;
            document.getElementById('txtFrom').disabled=true;
            document.getElementById('txtTo').disabled=true;
            
            document.getElementById('btnNew').focus();	
        }
        
        else
        {
            //addummydaypages.saveUpdate(gDay,gPubCode,gCenterCode,gEdiCode,gSupCode,day,pubCode,centerCode,ediCode,supCode,nPages,dFrom,dTo,compCode,userId);
            var recordId=document.getElementById('hiddenRecordId').value;
            
            addummydaypages.saveUpdate(recordId,day,pubCode,centerCode,ediCode,supCode,nPages,dFrom,dTo,compCode,userId,dateformat);
            alert("Data Updated Successfully");
            updateStatus();
            
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnNew').disabled = true;	
            document.getElementById('btnQuery').disabled=false;
            document.getElementById('btnExecute').disabled=true;
            document.getElementById('btnModify').disabled=false;
            
            document.getElementById('drpDay').disabled=true;
            document.getElementById('drpPName').disabled=true;
            document.getElementById('drpPCName').disabled=true;
            document.getElementById('drpEdition').disabled=true;
            document.getElementById('drpSuppliment').disabled=true;
            document.getElementById('txtNPages').disabled=true;
            document.getElementById('txtFrom').disabled=true;
            document.getElementById('txtTo').disabled=true;
            addummydaypages.adDDPExecute(gCompCode,gDay,gPubCode,gCenterCode,gEdiCode,gSupCode,resAdDDPExecute);
            updateStatus();
        }
    }
}

//*********************************************************************************************************

//*********************************************************************************************************
//****************This function is used to Clear all changes and data the data*****************************
function adDDPCancel(formname)
{
    chkstatus(FlagStatus);
    modify="0";
    
    ds_execute=null;    
    document.getElementById('btnSave').disabled =true;	
	document.getElementById('btnNew').disabled =false;	
	document.getElementById('btnQuery').disabled=false;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnDelete').disabled=true;
	document.getElementById('btnModify').disabled=true;
	
	document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnnext').disabled=true;
    document.getElementById('btnlast').disabled=true;
	
	document.getElementById('drpDay').disabled=true;
	document.getElementById('drpPName').disabled=true;
	document.getElementById('drpPCName').disabled=true;
	document.getElementById('drpEdition').disabled=true;
	document.getElementById('drpSuppliment').disabled=true;
	document.getElementById('txtNPages').disabled=true;
	document.getElementById('txtFrom').disabled=true;
	document.getElementById('txtTo').disabled=true;

	document.getElementById('drpDay').value="0";
	document.getElementById('drpPName').value="0";
	
	document.getElementById('drpPCName').length=0;
	for (var i = (document.getElementById('drpPCName').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpPCName').value="";
	
	document.getElementById('drpEdition').length=0;
	for (var i = (document.getElementById('drpEdition').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpEdition').value="";
	
	document.getElementById('drpSuppliment').length=0;
	for (var i = (document.getElementById('drpSuppliment').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpSuppliment').value="";
	
    document.getElementById('txtNPages').value="";
	document.getElementById('txtFrom').value="";
	document.getElementById('txtTo').value="";
    return false;
}

//*********************************************************************************************************
//*********************************************************************************************************
//**************************This function is used to unlock the controls for query*************************
function adDDPQuery_client()
{
    ds_execute=null;
    chkstatus(FlagStatus);
    rowN=0;
    document.getElementById('btnSave').disabled = true;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnModify').disabled=true;
	
	document.getElementById('drpDay').disabled=false;
	document.getElementById('drpPName').disabled=false;
	document.getElementById('drpPCName').disabled=false;
	document.getElementById('drpEdition').disabled=false;
	document.getElementById('drpSuppliment').disabled=false;
	document.getElementById('txtNPages').disabled=false;
	document.getElementById('txtFrom').disabled=false;
	document.getElementById('txtTo').disabled=false;
	
	document.getElementById('drpDay').value="0";
	document.getElementById('drpPName').value="0";
	
    document.getElementById('drpPCName').length=0;
	for (var i = (document.getElementById('drpPCName').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpPCName').value="";
	
    addummydaypages.fillPCName(resFillPCName);//Added after hand over to sir.	
	
	document.getElementById('drpEdition').length=0;
	for (var i = (document.getElementById('drpEdition').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpEdition').value="";
	
	document.getElementById('drpSuppliment').length=0;
	for (var i = (document.getElementById('drpSuppliment').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
    document.getElementById('drpDay').value="0";
    document.getElementById('drpPName').value="0";
    document.getElementById('drpPCName').value="0";
    document.getElementById('drpEdition').value="0";
	document.getElementById('drpSuppliment').value="0";
	
    document.getElementById('txtNPages').value="";
	document.getElementById('txtFrom').value="";
	document.getElementById('txtTo').value="";
	
	document.getElementById('drpDay').focus();
	var compcode=document.getElementById('hiddencompcode').value;
	
	//addummydaypages.fillPubName(compcode,resFillPubName);//calling a addummydaypages.aspx.cs function which returns a dataset 
	fillCenter_client();
	return false;
}

//*********************************************************************************************************

//*********************************************************************************************************
//**************************This function is used to Execute the client query******************************
function adDDPExecute_client()
{
    
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnQuery').disabled=false;
    
    document.getElementById('btnDelete').disabled=false;
    document.getElementById('btnModify').disabled=false;
    
    gDay=document.getElementById('drpDay').value;
    gPubCode=document.getElementById('drpPName').value;
    gCenterCode=document.getElementById('drpPCName').value;
    gEdiCode=document.getElementById('drpEdition').value;
    gSupCode=document.getElementById('drpSuppliment').value;
    
    document.getElementById('drpDay').disabled=true;
	document.getElementById('drpPName').disabled=true;
	document.getElementById('drpPCName').disabled=true;
	document.getElementById('drpEdition').disabled=true;
	document.getElementById('drpSuppliment').disabled=true;
	document.getElementById('txtNPages').disabled=true;
	document.getElementById('txtFrom').disabled=true;
	document.getElementById('txtTo').disabled=true;
    
    document.getElementById('btnModify').focus();
                             
    //var day=document.getElementById('drpDay').value;
    //var pubCode=document.getElementById('drpPName').value;
    //var centerCode=document.getElementById('drpPCName').value;
    //var ediCode=document.getElementById('drpEdition').value;
    //var supCode=document.getElementById('drpSuppliment').value;
    
    //var compCode=document.getElementById('hiddencompcode').value;
    gCompCode=document.getElementById('hiddencompcode').value;
    var userId=document.getElementById('hiddenuserid').value;
    var dateformat=document.getElementById('hiddendateformat').value;
    updateStatus();
    //addummydaypages.adDDPExecute(compCode,day,pubCode,centerCode,ediCode,supCode,resAdDDPExecute)
    addummydaypages.adDDPExecute(gCompCode,gDay,gPubCode,gCenterCode,gEdiCode,gSupCode,dateformat,resAdDDPExecute);
    return false;
    
}
//*********************************************************************************************************

//*********************************************************************************************************
//****************This function is used to bind the controls on the basis of client query******************
function resAdDDPExecute(response)
{
    modify="0";
    ds_execute=response.value;
    if(ds_execute!= null && typeof(ds_execute) == "object" && ds_execute.Tables[0].Rows.length > 0) 
    {
        //document.getElementById('drpDay').length=0;
        //if(ds.Tables[0].Rows[0].day_code=="MON")
        
        if(ds_execute.Tables[0].Rows.length==1)
        {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            
            bind_controls();
            fillCenter_client();
            
            
            //document.getElementById('btnfirst').disabled=false;
            
            //document.getElementById('drpPCName').value=ds_execute.Tables[0].Rows[rowN].center_code;
        }
        else
        {
            if(rowN==0)
            {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                document.getElementById('btnnext').disabled=false;
                document.getElementById('btnlast').disabled=false;
            }
            
            else if(rowN==ds_execute.Tables[0].Rows.length-1)
            {
                document.getElementById('btnfirst').disabled=false;
                document.getElementById('btnprevious').disabled=false;
                document.getElementById('btnnext').disabled=true;
                document.getElementById('btnlast').disabled=true;
            }
            
            else
            {
                document.getElementById('btnfirst').disabled=false;
                document.getElementById('btnprevious').disabled=false;
                document.getElementById('btnnext').disabled=false;
                document.getElementById('btnlast').disabled=false;
            }
            
            bind_controls();
            fillCenter_client();
            
            //document.getElementById('btnfirst').disabled=false;
            
        }
    }
    else
    {
        document.getElementById('btnExecute').disabled=false;
        document.getElementById('btnQuery').disabled=true;
        document.getElementById('btnDelete').disabled=true;
        document.getElementById('btnModify').disabled=true;
        
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnlast').disabled=true;
        
        if(del==1)
        {
            alert('There Is No More Data To Be Deleted');
            ds_execute=null;
            
            document.getElementById('btnExecute').disabled=true;
            document.getElementById('btnQuery').disabled=false;
            document.getElementById('btnNew').disabled=false;
            
            document.getElementById('drpDay').disabled=true;
	        document.getElementById('drpPName').disabled=true;
	        document.getElementById('drpPCName').disabled=true;
	        document.getElementById('drpEdition').disabled=true;
	        document.getElementById('drpSuppliment').disabled=true;
	        document.getElementById('txtNPages').disabled=true;
	        document.getElementById('txtFrom').disabled=true;
	        document.getElementById('txtTo').disabled=true;

	        document.getElementById('drpDay').value="0";
	        document.getElementById('drpPName').value="0";
	        document.getElementById('drpPCName').value="";
	        document.getElementById('drpEdition').value="";
	        document.getElementById('drpSuppliment').value="";
            document.getElementById('txtNPages').value="";
	        document.getElementById('txtFrom').value="";
	        document.getElementById('txtTo').value="";
        }
        else
        {
            alert('Your Search Produces No Result!!!!');
            document.getElementById('drpDay').disabled=false;
	        document.getElementById('drpPName').disabled=false;
	        document.getElementById('drpPCName').disabled=false;
	        document.getElementById('drpEdition').disabled=false;
	        document.getElementById('drpSuppliment').disabled=false;
	        document.getElementById('txtNPages').disabled=false;
	        document.getElementById('txtFrom').disabled=false;
	        document.getElementById('txtTo').disabled=false;
        }
        
    }
}

//*********************************************************************************************************
//**************************This function is used to Navigate the first data******************************

function adDDPFirst()
{
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnlast').disabled=false;
    
    rowN=0;
    

    bind_controls();
    fillCenter_client();
    return false;
}
//*********************************************************************************************************

//**************************This function is used to Navigate the previous data******************************

function adDDPPrevious()
{
    rowN=rowN-1;
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnlast').disabled=false;

    if(rowN>=0)
    {
        bind_controls();
        fillCenter_client();       
        updateStatus();
    }
    
    rowN=rowN-1
    if(rowN>=0)
    {
        rowN=rowN+1
        return false;
    }
    else
    {
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnfirst').disabled=true;
        rowN=rowN+1;
    }
    return false;
}

//*********************************************************************************************************

//**************************This function is used to Navigate the next data******************************
function adDDPNext()
{
    rowN=rowN+1;
    
    document.getElementById('btnprevious').disabled=false;
    document.getElementById('btnfirst').disabled=false;
    
    if(rowN<ds_execute.Tables[0].Rows.length)
    {
        bind_controls();
        fillCenter_client();
        updateStatus();
    }
    rowN=rowN+1
    if(rowN<ds_execute.Tables[0].Rows.length)
    {
        rowN=rowN-1
        return false;
    }
    else
    {
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
        rowN=rowN-1;
    }
    return false;
}
//*********************************************************************************************************

//**************************This function is used to Navigate the last data******************************
function adDDPLast()
{
    document.getElementById('btnfirst').disabled=false;
    document.getElementById('btnprevious').disabled=false;
    document.getElementById('btnnext').disabled=true;
    document.getElementById('btnlast').disabled=true;
    
    rowN=ds_execute.Tables[0].Rows.length-1;
    
    
    bind_controls();
    fillCenter_client();
    return false;

}
//*********************************************************************************************************
//**************************This function is used to delete the current record******************************
function adDDPDelete_client()
{
    if(confirm("Are You Sure Want To Delete The Data"))
    {
//	    var day=document.getElementById('drpDay').value;
//        var pubCode=document.getElementById('drpPName').value;
//        var centerCode=document.getElementById('drpPCName').value;
//        var ediCode=document.getElementById('drpEdition').value;
//        var supCode=document.getElementById('drpSuppliment').value;
//        
//        var compCode=document.getElementById('hiddencompcode').value;
//        var userId=document.getElementById('hiddenuserid').value;
        
        var recordId=document.getElementById('hiddenRecordId').value;
        
        //addummydaypages.adDDPDelete(compCode,day,pubCode,centerCode,ediCode,supCode,resAdDDPDelete);
        addummydaypages.adDDPDelete(recordId,resAdDDPDelete);
        del=1;
        
        return false;
    }
    else
    {
        return false;
    }
    
}
//*********************************************************************************************************

//**************************This function is used to bind the data after delete******************************
function resAdDDPDelete(response)
{
    alert("Data Deleted Successfully");    
    
    if(rowN==ds_execute.Tables[0].Rows.length-1)
    {
        rowN=rowN-1;
    }    
    addummydaypages.adDDPExecute(gCompCode,gDay,gPubCode,gCenterCode,gEdiCode,gSupCode,resAdDDPExecute);
}
//*********************************************************************************************************

//****************This function is used to Close the page*****************************
function adDDPExit()
{
    if(confirm("Do you want to skip this page"))
    {
	    window.close();
	    return false;
    }
    return false;
}
//*********************************************************************************************************

//****************This function is used to Lock the control(user is unable to write any thing)***************
function lockCont()
{
    if(bquery=="1")
    {
        event.keyCode=0;
    }
}
//**********************************************************************************************************

//************************This function is used to bind the controls on navigation*************************
function bind_controls()
{
    document.getElementById('drpDay').value=ds_execute.Tables[0].Rows[rowN].pub_day;
    document.getElementById('drpPName').value=ds_execute.Tables[0].Rows[rowN].pub_code;
    
    document.getElementById('hiddenRecordId').value=ds_execute.Tables[0].Rows[rowN].record_id;
    
    //alert(document.getElementById('hiddenRecordId').value);
    
        if(ds_execute.Tables[0].Rows[rowN].number_of_pages!=null)
    {
        document.getElementById('txtNPages').value=ds_execute.Tables[0].Rows[rowN].number_of_pages;
    }
    else
    {
        document.getElementById('txtNPages').value="";
    }
    if(ds_execute.Tables[0].Rows[rowN].valid_date_fom!=null)
    {
        document.getElementById('txtFrom').value=ds_execute.Tables[0].Rows[rowN].valid_date_fom;
    }
    else
    {
        document.getElementById('txtFrom').value="";
    }
    if(ds_execute.Tables[0].Rows[rowN].valid_date_fom!=null)
    {
        document.getElementById('txtTo').value=ds_execute.Tables[0].Rows[rowN].valid_date_to;
    }
    else
    {
        document.getElementById('txtTo').value="";
    }
}
//**********************************************************************************************************

//*********************************************************************************************************
//**************************This function is used to work enter key as tab******************************
function tabvalue (id)
{
    var flag="n";
    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
            flag=checkdate(document.getElementById('txtTo'));
            if(flag!="y")
            {
                if(document.getElementById('btnSave').disabled==false)
                {
                    document.getElementById('btnSave').focus();
                }
                //return;
            }
        }
        
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        
        else
        {
            event.keyCode=9;
            return event.keyCode;
        }
    }
}

//*********************************************************************************************************

//***********************This function is used to give alert to user if he enters wrong date**************
 function settime1()
 {
     var dateformat=document.getElementById('hiddendateformat').value;
     if(ginput.id=="txtTo")
     {
        daid.focus();
     }
     if(document.activeElement.id.indexOf('dan')<0 && document.activeElement.id!='')
     {
        
        daid.focus();
        daid.value="";
        alert(" Please Fill The Date In "+dateformat+" Format");
        var blank="y";
        return blank;
        
      }
      else
      {
        blank="n";
        return blank;
      }
     //input.focus();
 }

//*********************************************************************************************************

//**************************This function is used to work enter key as tab******************************
function tabvalue (id)
{
    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
            var flag=checkdate(document.getElementById('txtTo'));
            if(flag==true)
            {
                if(document.getElementById('btnSave').disabled==false)
                {
                    document.getElementById('btnSave').focus();
                }
                return;
            }
            else
            {
                return false;
            }
        }
        
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        
        else
        {
            event.keyCode=9;
            return event.keyCode;
        }
    }
}

//*********************************************************************************************************

//***********************This function is used to give alert to user if he enters wrong date**************
 function settime1()
 {
     var dateformat=document.getElementById('hiddendateformat').value;
     if(ginput.id=="txtTo")
     {
        daid.focus();
     }
     if(document.activeElement.id.indexOf('dan')<0 && document.activeElement.id!='')
     {
        
        daid.focus();
        daid.value="";
        alert(" Please Fill The Date In "+dateformat+" Format");
        var blank="y";
        return blank;
        
      }
      else
      {
        blank="n";
        return blank;
      }
     //input.focus();
 }

//*********************************************************************************************************

//***********************This function is used to the date**************
function checkdate(input)
 {
    ginput=input;
    var dateformat=document.getElementById('hiddendateformat').value;
    if(dateformat=="mm/dd/yyyy")
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity 
    }
    
    if(dateformat=="yyyy/mm/dd")
    {
        var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
    }
    
    if(dateformat=="dd/mm/yyyy")
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
    }

    if (!validformat.test(input.value))
    {
        if(input.value=="")
        {
            return true;
        }
        
        daid=input;
        var conf=settime1();
        

        return conf;
    }
    else
    { //Detailed check for valid date ranges
        if(dateformat=="yyyy/mm/dd")
        {
            var yearfield=input.value.split("/")[0]
            var monthfield=input.value.split("/")[1]
            var dayfield=input.value.split("/")[2]
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
        if(dateformat=="mm/dd/yyyy")
        {
            var yearfield=input.value.split("/")[2]
            var monthfield=input.value.split("/")[0]
            var dayfield=input.value.split("/")[1]
            //var dayobj = new Date(monthfield-1, dayfield, yearfield)
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
        if(dateformat=="dd/mm/yyyy")
        {
            var yearfield=input.value.split("/")[2]
            var monthfield=input.value.split("/")[1]
            var dayfield=input.value.split("/")[0]
            //var dayobj = new Date(dayfield, monthfield-1, yearfield)
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
    }

//if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
    var abcd= dayobj.getMonth()+1;

    var date1=dayobj.getDate();
    var year1=dayobj.getFullYear();
    if(input.id=="txtdob")
    {   
        var cD=new Date();
        var newM;
        newM=cD.getMonth();
        newM=newM+1;
        if(monthfield>newM || dayfield>=cD.getDate() || yearfield>cD.getFullYear())
        {
           alert("Date shuold be less then current Date");
           input.value="";
           input.focus();
           return false;
        }
    }
    if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
    {
        alert(" Please Fill The Date In "+dateformat+" Format");
        input.value="";
        return false;
    }
    returnval=true
    
    if (returnval==false) 

    input.select()
    return returnval
}
//*********************************************************************************************************