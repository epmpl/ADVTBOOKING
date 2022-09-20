// JScript File

/////dataset declared globally for execution
var ds_execute;

//rowN as row number for navigation.
var rowN=0;

//is used for execute purpose
var del=0;

//Global variablas for modification
var modDay;
var modPName;
var modPCName;
var modEdi;
var modSupp;
var modPageNo;

//Global variablas for executiom
var exeDay;
var exePName;
var exePCName;
var exeEdi;
var exeSup;
var exePageNo;
var exeCompCode;

//This variable is used for checking that the data is saving or modifying; 1 for modify(uddate) and 0 for new(insert)
var modify="0";

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

function loadXML(xmlFile) 
{
    var  httpRequest =null;

    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
            }
        }
        
        var parser=new DOMParser();
        //alert(xmlFile + "  Test"); 
        //xmlDoc.load(xmlFile);
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
        //debugger;
        //alert(xmlObj);  
        //alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
}

function verify() 
{ 
    if (xmlDoc.readyState != 4) 
    { 
        return false; 
    } 
}

//This function will work when New button id clicked

function adDDPSNew()
{
    modify="0";
    //document.getElementById();
    
    document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	
	document.getElementById('drpDay').disabled=false;
	document.getElementById('drpPName').disabled=false;
	document.getElementById('drpPCName').disabled=false;
	document.getElementById('drpEdition').disabled=false;
	document.getElementById('drpSuppliment').disabled=false;
	document.getElementById('txtPageNo').disabled=false;
	document.getElementById('txtPageHeading').disabled=false;
	document.getElementById('txtNPages').disabled=false;
	document.getElementById('drpAdCtg').disabled=false;
	document.getElementById('drpSubAdCtg').disabled=false;
	document.getElementById('txtMaxRow').disabled=false;
	document.getElementById('txtMaxCol').disabled=false;
	document.getElementById('txtStartRow').disabled=false;
	document.getElementById('txtStartCol').disabled=false;
	document.getElementById('txtMaxAd').disabled=false;
	document.getElementById('txtPagiCode').disabled=false;
	document.getElementById('txtFrom').disabled=false;
	document.getElementById('txtTo').disabled=false;
	document.getElementById('txtLaderStatus').disabled=false;
	document.getElementById('txtPDate').disabled=false;
	document.getElementById('drpColor').disabled=false;
	document.getElementById('txtAdVolume').disabled=false;
	
	chkstatus(FlagStatus);
	
	var compcode=document.getElementById('hiddencompcode').value;
	
	document.getElementById('drpDay').focus();
	return false;
}

//**********************************************************************************************************


//calling a adDummyDayPS.aspx.cs function which returns a dataset and pass to called function fillPCName
function fillCenter_client()
{
    var pubcode=document.getElementById('drpPName');
    if(pubcode.value=="0")//Cheching if Publication Name dropdown is blank than blank the Other dropdowns
    {
        var PCName=document.getElementById("drpPCName");
        //PCName.options.length=0;
        //PCName.options[0]=new Option("--Select Center Name--","0");
        PCName.value="0";
        
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
        adDummyDayPS.fillPCName(resFillPCName);
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
        document.getElementById("drpPCName").value=ds_execute.Tables[0].Rows[rowN].pub_center;
        fillEdiName_client();
    }
}

//**********************************************************************************************************

//calling a adDummyDayPS.aspx.cs function which returns a dataset and pass to called function resFillEdiName
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
        adDummyDayPS.fillEdiName(pubcodeV,pubcenterV,resFillEdiName);
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
        //ds_execute=null;
        ediName.value="0";
        
        
    }
    
    else if(ds_execute!=undefined && ds_execute!="" && ds_execute!=null)
    {
        document.getElementById("drpEdition").value=ds_execute.Tables[0].Rows[rowN].edition_code;
        fillSuppliment_client();
    }
    else
    {
        fillSuppliment_client();
    }
}
//**********************************************************************************************************

//calling a adDummyDayPS.aspx.cs function which returns a dataset and pass to called function resFillfillSuppliment
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

        var compcodesupp=document.getElementById('hiddencompcode').value;
        var pubeditsuppV=pubeditsupp.value;
        adDummyDayPS.fillSuppliment(compcodesupp,pubeditsuppV,resFillSuppliment);
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
    supp.value="0";
    
    if(ds_execute!=undefined && ds_execute!="" && ds_execute!=null)
    {
        document.getElementById("drpSuppliment").value=ds_execute.Tables[0].Rows[rowN].SUB_PUB;
    
    }
}
//*********************************************************************************************************


//calling a adDummyDayPS.aspx.cs function which returns a dataset and pass to called function resFillSubAdCat
function fillSubAdCat_client()
{
    var adcat=document.getElementById('drpAdCtg');
    //var compcode=document.getElementById('hiddencompcode');
    if(adcat.value=="0")
    {
        var subadcat=document.getElementById("drpSubAdCtg");
        subadcat.options.length=0;
        subadcat.options[0]=new Option("--Select Sub Ad Category--","0");
        return false;
    }
    else
    {
        //var pubcodesuppV=pubcodesupp.value;
        var compcodeSAd=document.getElementById('hiddencompcode').value;
        var adcatV=adcat.value;
        adDummyDayPS.fillSubAdCat(compcodeSAd,adcatV,resFillSubAdCat);
    }
}
//**********************************************************************************************************

//*******This function takes dataset object as parameter and fill the Sub Category dropdown*****************
function resFillSubAdCat(response)
{
    var ds=response.value;
    var subadcat=document.getElementById("drpSubAdCtg");
    subadcat.options.length = 1; 
    subadcat.options[0]=new Option("--Select Suppliment--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            subadcat.options[subadcat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i]. Adv_Subcat_Code);
            subadcat.options.length;
        }
        
    }
    
    if(ds_execute!=undefined && ds_execute!="" && ds_execute!=null)
    {
        document.getElementById("drpSubAdCtg").value=ds_execute.Tables[0].Rows[rowN].secadctg;
    
    }
}
//*********************************************************************************************************

//*********************************************************************************************************
//****************This function is used to Clear all changes and data**************************************
function adDDPSCancel()
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
	
	disable_controls();

	document.getElementById('drpDay').value="0";
	document.getElementById('drpPName').value="0";
	document.getElementById('drpAdCtg').value="0";
	document.getElementById('drpColor').value="0";
	
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
	document.getElementById('drpSubAdCtg').value="";
	
	document.getElementById('drpSubAdCtg').length=0;
	for (var i = (document.getElementById('drpSubAdCtg').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpSubAdCtg').value="";
	
	document.getElementById('txtPageNo').value="";
	document.getElementById('txtPageHeading').value="";
    document.getElementById('txtNPages').value="";
    document.getElementById('txtMaxRow').value="";
	document.getElementById('txtMaxCol').value="";
	document.getElementById('txtStartRow').value="";
	document.getElementById('txtStartCol').value="";
	document.getElementById('txtMaxAd').value="";
	document.getElementById('txtPagiCode').value="";
	document.getElementById('txtFrom').value="";
	document.getElementById('txtTo').value="";
	document.getElementById('txtLaderStatus').value="";
	document.getElementById('txtPDate').value="";
	document.getElementById('txtAdVolume').value="";
    return false;
}

//*********************************************************************************************************

//**************************This function is used to unlock the controls for query*************************
function adDDPSQuery_client()
{
    adDDPSCancel();
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
	document.getElementById('txtPageNo').disabled=false;
	
	document.getElementById('drpDay').value="0";
	document.getElementById('drpPName').value="0";
	document.getElementById('drpAdCtg').value="0"
	
    document.getElementById('drpPCName').length=0;
	for (var i = (document.getElementById('drpPCName').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
	document.getElementById('drpPCName').value="";
	
    adDummyDayPS.fillPCName(resFillPCName);//Added after hand over to sir.	
	
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
    
    document.getElementById('drpSubAdCtg').length=0;
	for (var i = (document.getElementById('drpSubAdCtg').length-1); i >= 0; i--)
    {
        options[i]=null;
    }
    
    document.getElementById('drpDay').value="0";
    document.getElementById('drpPName').value="0";
    document.getElementById('drpPCName').value="0";
    document.getElementById('drpEdition').value="0";
	document.getElementById('drpSuppliment').value="0";
	document.getElementById('drpSubAdCtg').value="0";
	
    document.getElementById('txtNPages').value="";
	document.getElementById('txtFrom').value="";
	document.getElementById('txtTo').value="";
	
	document.getElementById('drpDay').focus();
	var compcode=document.getElementById('hiddencompcode').value;

	fillCenter_client();
	return false;
}

//*********************************************************************************************************

//**************************This function is used to Execute the client query******************************
function adDDPSExecute_client()
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
	document.getElementById('txtPageNo').disabled=true;
	
	exeDay=document.getElementById('drpDay').value;
	exePName=document.getElementById('drpPName').value;
	exePCName=document.getElementById('drpPCName').value;
	exeEdi=document.getElementById('drpEdition').value;
	exeSupp=document.getElementById('drpSuppliment').value;
	exePageNo=document.getElementById('txtPageNo').value;
    
    document.getElementById('btnModify').focus();
                             
    
    exeCompCode=document.getElementById('hiddencompcode').value;
        
    
    adDummyDayPS.adDDPSExecute(exeCompCode,exeDay,exePName,exePCName,exeEdi,exeSupp,exePageNo,resAdDDPSExecute);
    updateStatus();
    return false;
}
//*********************************************************************************************************

//*********************************************************************************************************
//****************This function is used to bind the controls on the basis of client query******************
function resAdDDPSExecute(response)
{
    modify="0";
    ds_execute=response.value;
    if(ds_execute!= null && typeof(ds_execute) == "object" && ds_execute.Tables[0].Rows.length > 0) 
    {
        
        if(ds_execute.Tables[0].Rows.length==1)
        {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            
            bind_controls();
            fillCenter_client();

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
            adDDPSCancel()
        }
        else
        {
            alert('Your Search Produces No Result!!!!');
            adDDPSQuery_client();
	        
        }
        
    }
}
//*********************************************************************************************************

//**************************This function is used to Navigate the first data******************************

function adDDPSFirst()
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

//**************************This function is used to Navigate the previous data******************************

function adDDPSPrevious()
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
function adDDPSNext()
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
function adDDPSLast()
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

//*********************************************************************************************************
//****************************This function is used to unlockes the controls for modification**************
function adDDPSModify_client()
{
    chkstatus(FlagStatus);
    modify="1";
    ds_execute=null;
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
	document.getElementById('txtPageNo').disabled=false;
	document.getElementById('txtPageHeading').disabled=false;
	document.getElementById('txtNPages').disabled=false;
	document.getElementById('drpAdCtg').disabled=false;
	document.getElementById('drpSubAdCtg').disabled=false;
	document.getElementById('txtMaxRow').disabled=false;
	document.getElementById('txtMaxCol').disabled=false;
	document.getElementById('txtStartRow').disabled=false;
	document.getElementById('txtStartCol').disabled=false;
	document.getElementById('txtMaxAd').disabled=false;
	document.getElementById('txtPagiCode').disabled=false;
	document.getElementById('txtFrom').disabled=false;
	document.getElementById('txtTo').disabled=false;
	document.getElementById('txtLaderStatus').disabled=false;
	document.getElementById('txtPDate').disabled=false;
	document.getElementById('drpColor').disabled=false;
	document.getElementById('txtAdVolume').disabled=false;
	
	modDay=document.getElementById('drpDay').value;
	modPName=document.getElementById('drpPName').value;
	modPCName=document.getElementById('drpPCName').value;
	modEdi=document.getElementById('drpEdition').value;
	modSupp=document.getElementById('drpSuppliment').value;
	modPageNo=document.getElementById('txtPageNo').value;
	
	return false;
}
//*********************************************************************************************************

//**This function is used to chech the unfilled data, call function for save and also check duplicate data*

function adDDPSSave_client()
{
    var browser=navigator.appName;
    var bc="";
    
    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbDay').textContent;
    }
    else
    {
        bc=document.getElementById('lbDay').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpDay').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpDay').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbPName').textContent;
    }
    else
    {
        bc=document.getElementById('lbPName').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpPName').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpPName').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbPCName').textContent;
    }
    else
    {
        bc=document.getElementById('lbPCName').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpPCName').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpPCName').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbEdition').textContent;
    }
    else
    {
        bc=document.getElementById('lbEdition').innerText; 
    } 
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpEdition').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpEdition').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbSuppliment').textContent;
    }
    else
    {
        bc=document.getElementById('lbSuppliment').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpSuppliment').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpSuppliment').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbPageNo').textContent;
    }
    else
    {
        bc=document.getElementById('lbPageNo').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtPageNo').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtPageNo').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbPageHeading').textContent;
    }
    else
    {
        bc=document.getElementById('lbPageHeading').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtPageHeading').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtPageHeading').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbNPages').textContent;
    }
    else
    {
        bc=document.getElementById('lbNPages').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtNPages').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtNPages').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbAdCtg').textContent;
    }
    else
    {
        bc=document.getElementById('lbAdCtg').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpAdCtg').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpAdCtg').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbSubAdCtg').textContent;
    }
    else
    {
        bc=document.getElementById('lbSubAdCtg').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpSubAdCtg').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpSubAdCtg').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbMaxRow').textContent;
    }
    else
    {
        bc=document.getElementById('lbMaxRow').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtMaxRow').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtMaxRow').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbMaxCol').textContent;
    }
    else
    {
        bc=document.getElementById('lbMaxCol').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtMaxCol').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtMaxCol').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbStartRow').textContent;
    }
    else
    {
        bc=document.getElementById('lbStartRow').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtStartRow').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtStartRow').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbStartCol').textContent;
    }
    else
    {
        bc=document.getElementById('lbStartCol').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtStartCol').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtStartCol').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbMaxAd').textContent;
    }
    else
    {
        bc=document.getElementById('lbMaxAd').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtMaxAd').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtMaxAd').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbPagiCode').textContent;
    }
    else
    {
        bc=document.getElementById('lbPagiCode').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtPagiCode').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtPagiCode').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbFrom').textContent;
    }
    else
    {
        bc=document.getElementById('lbFrom').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtFrom').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtFrom').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbTo').textContent;
    }
    else
    {
        bc=document.getElementById('lbTo').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtTo').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtTo').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbLaderStatus').textContent;
    }
    else
    {
        bc=document.getElementById('lbLaderStatus').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtLaderStatus').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtLaderStatus').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbPDate').textContent;
    }
    else
    {
        bc=document.getElementById('lbPDate').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtPDate').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtPDate').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbColor').textContent;
    }
    else
    {
        bc=document.getElementById('lbColor').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('drpColor').value)== "0" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drpColor').focus();
            return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbAdVolume').textContent;
    }
    else
    {
        bc=document.getElementById('lbAdVolume').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(trim(document.getElementById('txtAdVolume').value)== "" )
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('txtAdVolume').focus();
            return false;
	    }
	}
	
	var fd=new Date(document.getElementById('txtFrom').value);
    var td=new Date(document.getElementById('txtTo').value);
    
    if(td<fd)
    {
        alert('To date should be greater than from date');
        document.getElementById('txtTo').value="";
		document.getElementById('txtTo').focus();
        return false;
    }
	
	
	var fromDate=document.getElementById('txtFrom').value;
    var toDate=document.getElementById('txtTo').value;
    var fd=new Date(fromDate);
    var td=new Date(toDate);
    
    var day=document.getElementById('drpDay').value;
    var pName=document.getElementById('drpPName').value;
    var pCName=document.getElementById('drpPCName').value;
    var edi=document.getElementById('drpEdition').value;
    var supp=document.getElementById('drpSuppliment').value;
    var pageNo=document.getElementById('txtPageNo').value;
    
    if(modify=="0")
    {
        adDummyDayPS.chkDup(day,pName,pCName,edi,supp,pageNo,resChkDup);
        return false;
    }
    else
    {
        if(day==modDay && pName==modPName && pCName==modPCName && edi==modEdi && supp==modSupp && pageNo==modPageNo)
        {
            var pageHead=document.getElementById('txtPageHeading').value
            var nPages=document.getElementById('txtNPages').value;
            var adCtg=document.getElementById('drpAdCtg').value;
            var subAdCtg=document.getElementById('drpSubAdCtg').value;
            var maxRow=document.getElementById('txtMaxRow').value;
            var maxCol=document.getElementById('txtMaxCol').value;
            var startRow=document.getElementById('txtStartRow').value;
            var startCol=document.getElementById('txtStartCol').value;
            var maxAd=document.getElementById('txtMaxAd').value;
            var pagiCode=document.getElementById('txtPagiCode').value;
            var dFrom=document.getElementById('txtFrom').value;
            var dTo=document.getElementById('txtTo').value;
            var ladStatus=document.getElementById('txtLaderStatus').value;
            
            var pDate=document.getElementById('txtPDate').value;
            var color=document.getElementById('drpColor').value;
            var adVolume=document.getElementById('txtAdVolume').value;
        
        
            var compCode=document.getElementById('hiddencompcode').value;
            adDummyDayPS.saveUpdate(day,pName,pCName,edi,supp,pageNo,pageHead,nPages,adCtg,subAdCtg,maxRow,maxCol,startRow,startCol,maxAd,pagiCode,dFrom,dTo,ladStatus,pDate,color,adVolume,compCode,modDay,modPName,modPCName,modEdi,modSupp,modPageNo);
            if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(1).text);
            }
            
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnNew').disabled = true;	
            document.getElementById('btnQuery').disabled=false;
            document.getElementById('btnExecute').disabled=true;
            document.getElementById('btnModify').disabled=false;
            
            modify="0";
            
            disable_controls();
            adDummyDayPS.adDDPSExecute(exeCompCode,exeDay,exePName,exePCName,exeEdi,exeSupp,exePageNo,resAdDDPSExecute);
            
            return false;
        }
        else
        {
            adDummyDayPS.chkDup(day,pName,pCName,edi,supp,pageNo,resChkDup);
            return false;
        }
    }
    
}
//***********************************************************************************************************

//**This function is used to check is data is duplicate if not then save the data****************************
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
        var pageHead=document.getElementById('txtPageHeading').value
        var pageNo=document.getElementById('txtPageNo').value;
        var nPages=document.getElementById('txtNPages').value;
        var adCtg=document.getElementById('drpAdCtg').value;
        var subAdCtg=document.getElementById('drpSubAdCtg').value;
        var maxRow=document.getElementById('txtMaxRow').value;
        var maxCol=document.getElementById('txtMaxCol').value;
        var startRow=document.getElementById('txtStartRow').value;
        var startCol=document.getElementById('txtStartCol').value;
        var maxAd=document.getElementById('txtMaxAd').value;
        var pagiCode=document.getElementById('txtPagiCode').value;
        var dFrom=document.getElementById('txtFrom').value;
        var dTo=document.getElementById('txtTo').value;
        var ladStatus=document.getElementById('txtLaderStatus').value;
        
        var pDate=document.getElementById('txtPDate').value;
        var color=document.getElementById('drpColor').value;
        var adVolume=document.getElementById('txtAdVolume').value;
        
        var compCode=document.getElementById('hiddencompcode').value;
        var userId=document.getElementById('hiddenuserid').value;
        
        if(modify==0)
        {
            adDummyDayPS.saveInsert(day,pubCode,centerCode,ediCode,supCode,pageNo,pageHead,nPages,adCtg,subAdCtg,maxRow,maxCol,startRow,startCol,maxAd,pagiCode,dFrom,dTo,ladStatus,pDate,color,adVolume,compCode,userId);
            if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(0).text);
            }
            adDDPSCancel();
            return false;
        }
        else
        {
            updateStatus();
            adDummyDayPS.saveUpdate(day,pubCode,centerCode,ediCode,supCode,pageNo,pageHead,nPages,adCtg,subAdCtg,maxRow,maxCol,startRow,startCol,maxAd,pagiCode,dFrom,dTo,ladStatus,pDate,color,adVolume,compCode,modDay,modPName,modPCName,modEdi,modSupp,modPageNo);
            if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(1).text);
            }
//            alert("Data Updated Successfully");
            
            
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnNew').disabled = true;	
            document.getElementById('btnQuery').disabled=false;
            document.getElementById('btnExecute').disabled=true;
            document.getElementById('btnModify').disabled=false;
            
            disable_controls();
            adDummyDayPS.adDDPSExecute(exeCompCode,exeDay,exePName,exePCName,exeEdi,exeSupp,exePageNo,resAdDDPSExecute);
            updateStatus();
            return false;
        }
    }
}

//*********************************************************************************************************

//*********************************************************************************************************
//**************************This function is used to delete the current record******************************
function adDDPSDelete_client()
{
    if(confirm("Are You Sure Want To Delete The Data"))
    {
	    var day=document.getElementById('drpDay').value;
	    var pubCode=document.getElementById('drpPName').value;
	    var centerCode=document.getElementById('drpPCName').value;
	    var ediCode=document.getElementById('drpEdition').value;
	    var supCode=document.getElementById('drpSuppliment').value;
	    var pageNo=document.getElementById('txtPageNo').value;

	    var compCode=document.getElementById('hiddencompcode').value;
	    
        adDummyDayPS.adDDPSDelete(compCode,day,pubCode,centerCode,ediCode,supCode,pageNo,resAdDDPSDelete);
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
function resAdDDPSDelete(response)
{
    if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
    }
    else
    {
        alert(xmlObj.childNodes(0).childNodes(2).text);
    }
    //alert("Data Deleted Successfully");    
    
    if(rowN==ds_execute.Tables[0].Rows.length-1)
    {
        rowN=rowN-1;
    }    
    adDummyDayPS.adDDPSExecute(exeCompCode,exeDay,exePName,exePCName,exeEdi,exeSupp,exePageNo,resAdDDPSExecute);
}
//*********************************************************************************************************

//****************This function is used to Close the page*****************************
function adDDPSExit()
{
    if(confirm("Do you want to skip this page"))
    {
	    window.close();
	    return false;
    }
    return false;
}
//*********************************************************************************************************

//************************This function is used to bind the controls on navigation*************************
function bind_controls()
{
    document.getElementById('drpDay').value=ds_execute.Tables[0].Rows[rowN].pub_day;
    document.getElementById('drpPName').value=ds_execute.Tables[0].Rows[rowN].pri_pub;
    document.getElementById('drpAdCtg').value=ds_execute.Tables[0].Rows[rowN].priadctg;
    
    fillSubAdCat_client();
    
    document.getElementById('drpColor').value=ds_execute.Tables[0].Rows[rowN].page_colour;
    
    document.getElementById('txtPageNo').value=ds_execute.Tables[0].Rows[rowN].page_no;
    document.getElementById('txtPageHeading').value=ds_execute.Tables[0].Rows[rowN].page_heading;
    
    //alert(document.getElementById('hiddenRecordId').value);
    
//    if(ds_execute.Tables[0].Rows[rowN].number_of_pages!=null)
//    {
    document.getElementById('txtNPages').value=ds_execute.Tables[0].Rows[rowN].no_of_pages;
//    }
//    else
//    {
//        document.getElementById('txtNPages').value="";
//    }
    document.getElementById('txtMaxRow').value=ds_execute.Tables[0].Rows[rowN].max_row;
    document.getElementById('txtMaxCol').value=ds_execute.Tables[0].Rows[rowN].max_col;
    document.getElementById('txtStartRow').value=ds_execute.Tables[0].Rows[rowN].starting_row;
    document.getElementById('txtStartCol').value=ds_execute.Tables[0].Rows[rowN].starting_col;
    document.getElementById('txtMaxAd').value=ds_execute.Tables[0].Rows[rowN].max_ad;
    document.getElementById('txtPagiCode').value=ds_execute.Tables[0].Rows[rowN].pagination_code;
    
    document.getElementById('txtFrom').value=ds_execute.Tables[0].Rows[rowN].valid_date_from;
    
    document.getElementById('txtTo').value=ds_execute.Tables[0].Rows[rowN].valid_date_to;
    
    document.getElementById('txtLaderStatus').value=ds_execute.Tables[0].Rows[rowN].ladder_status;
    document.getElementById('txtPDate').value=ds_execute.Tables[0].Rows[rowN].pdate;
    
    document.getElementById('txtAdVolume').value=ds_execute.Tables[0].Rows[rowN].ad_volume;
    
}
//**********************************************************************************************************

//****************This function is used to convert data input string in to uppercase**********************
function eventcalling(event)
{

    if(event.keyCode==97) 
        event.keyCode= 65;
    if(event.keyCode==98) 
        event.keyCode= 66;
    if(event.keyCode==99) 
        event.keyCode= 67;
    if(event.keyCode==100) 
        event.keyCode= 68;
    if(event.keyCode==101) 
        event.keyCode= 69;
    if(event.keyCode==102) 
        event.keyCode= 70;
    if(event.keyCode==103) 
        event.keyCode= 71;
    if(event.keyCode==104) 
        event.keyCode= 72;
    if(event.keyCode==105) 
        event.keyCode= 73;
    if(event.keyCode==106) 
        event.keyCode= 74;
    if(event.keyCode==107) 
        event.keyCode= 75;
    if(event.keyCode==108) 
        event.keyCode= 76;
    if(event.keyCode==109) 
        event.keyCode= 77;
    if(event.keyCode==110) 
        event.keyCode= 78;
    if(event.keyCode==111) 
        event.keyCode= 79;
    if(event.keyCode==112) 
        event.keyCode= 80;
    if(event.keyCode==113) 
        event.keyCode= 81;
    if(event.keyCode==114) 
        event.keyCode= 82;
    if(event.keyCode==115) 
        event.keyCode= 83;
    if(event.keyCode==116) 
        event.keyCode= 84;
    if(event.keyCode==117) 
        event.keyCode= 85;
    if(event.keyCode==118) 
        event.keyCode= 86;
    if(event.keyCode==119) 
        event.keyCode= 87;
    if(event.keyCode==120) 
        event.keyCode= 88;
    if(event.keyCode==121) 
        event.keyCode= 89;
    if(event.keyCode==122) 
        event.keyCode= 90;

}
//**********************************************************************************************************

//********This function is used to disable the visible controls*********************************************
function disable_controls()
{
    document.getElementById('drpDay').disabled=true;
	document.getElementById('drpPName').disabled=true;
	document.getElementById('drpPCName').disabled=true;
	document.getElementById('drpEdition').disabled=true;
	document.getElementById('drpSuppliment').disabled=true;
	document.getElementById('txtPageNo').disabled=true;
	document.getElementById('txtPageHeading').disabled=true;
	document.getElementById('txtNPages').disabled=true;
	document.getElementById('drpAdCtg').disabled=true;
	document.getElementById('drpSubAdCtg').disabled=true;
	document.getElementById('txtMaxRow').disabled=true;
	document.getElementById('txtMaxCol').disabled=true;
	document.getElementById('txtStartRow').disabled=true;
	document.getElementById('txtStartCol').disabled=true;
	document.getElementById('txtMaxAd').disabled=true;
	document.getElementById('txtPagiCode').disabled=true;
	document.getElementById('txtFrom').disabled=true;
	document.getElementById('txtTo').disabled=true;
	document.getElementById('txtLaderStatus').disabled=true;
	document.getElementById('txtPDate').disabled=true;
	document.getElementById('drpColor').disabled=true;
	document.getElementById('txtAdVolume').disabled=true;   
}

function tabvalue (id)
{

    if(event.keyCode==13)
    {
        if(document.activeElement.id==document.getElementById('txtPageNo').id && document.getElementById('txtAdVolume').disabled==true)
        {
            if(document.getElementById('btnSave').disabled==false)
            {
                document.getElementById('btnSave').focus();
            }
            return;
        }
        else if(document.activeElement.id==id)
        {
            if(document.getElementById('btnSave').disabled==false)
            {
                document.getElementById('btnSave').focus();
            }
            return;

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
