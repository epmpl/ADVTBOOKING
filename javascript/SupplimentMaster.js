var z=0;
var  hiddentext;
var auto="";
var cityvar;
var cityvar1;
var suppdataset;//global  variable for run time dummy table.......
var suppcode="";
///////global variables for deletion.........
var glpubname="";
var gleditionname="";
var glcityname="";
var glsuppname="";
var glalias="";
var glsuppcode="";
var editionvar;
var gbuom;
var gbcolumn;
var gbheight;
var gbwidth;
var gbarea;
var gbperiodicty;
var insert="0";	
var gbchkperiod;
var gbsupptyp;
var lchk=0;
var popwin;
var kchk=0;
var gbgut,gbcol,gbhr,gbmin,gbpro;
var period;
var chknamemod;
///************************************************************************************************************//

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
    ClickCancel('SupplimentMaster');

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
}
function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
 if (xmlDoc.readyState != 4) 
 { 
   return false; 
 } 
}





function opensupplement()
{
//    if(document.getElementById('txtSuppCode').value=="")
//    {
//    alert('Please Enter The Supplement Code');
//    //document.getElementById('txtcurrcode').focus();s
//    return false;
//    }

if(document.getElementById('lbsupplement').disabled==false)
{
if ((document.getElementById('txtSuppCode').value=="" )&& (document.getElementById('hiddenauto').value!=1))
		{
		alert("Please Select Suppliment Code");
		document.getElementById('txtSuppCode').focus();
		return false;
		}
		else
		{
		var SuppCode=document.getElementById('txtSuppCode').value;
		}
	
	if (document.getElementById('drpPubName').value=="0")
		{
		alert("Please Select Publication Name");
		document.getElementById('drpPubName').focus();
		return false;
		}
		else
		{
		var PubName=document.getElementById('drpPubName').value;
		}
		
		if (document.getElementById('drEditonName').value=="0")
		{
		alert("Please Select Edition Name");
		document.getElementById('drEditonName').focus();
		return false;
		}
		else
		{
		var EditonName=document.getElementById('drEditonName').value;
		}
		if (document.getElementById('drsupptyp').value=="0")
		{
		alert("Please Select Supplement Type");
		document.getElementById('drsupptyp').focus();
		return false;
		}
		else
		{
		var supptyp=document.getElementById('drsupptyp').value;
		}

		
		
		if (document.getElementById('txtSuppName').value=="")
		{
		alert("Please Select Suppliment Name");
		document.getElementById('txtSuppName').focus();
		return false;
		}
		else
		{
		var SuppName=document.getElementById('txtSuppName').value;

		}
		
		 if (document.getElementById('drperiodicity').value=="0")
            {
            alert("Please Select Periodicity");
            document.getElementById('drperiodicity').focus();
            return false;
            }
//    else
//    {
         if(document.getElementById('drperiodicity').value=="0")
            {
            alert('Please Select The Periodicity');
            //document.getElementById('txtcurrcode').focus();s
            return false;
            }
        else
        {
          var periodicity=document.getElementById('drperiodicity').value;
                 //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.chkperiodicty(periodicity,opensupp_popup);
                 return false;
           }
            return false;
     //}
     }
      
}


function opensupp_popup(response)
{
//document.getElementById('pnl1').style.display="block";
 var ds=response.value;
if((ds.Tables[0].Rows[0].ValidationCode!="1")&&(ds.Tables[0].Rows[0].ValidationCode!="5"))
    {

    if(document.getElementById('txtSuppCode').value=="")
    {
    alert('Please Enter The Supplement Code');
    //document.getElementById('txtcurrcode').focus();s
    return false;
    }
    var suppcode=document.getElementById('txtSuppCode').value;
    var periodicity=document.getElementById('drperiodicity').value;
    if(document.getElementById('txtAlias').value=="")
       {
       alert('Please Enter The Edition Alias');
        //document.getElementById('txtcurrcode').focus();s
        return false;
        }
       
    var alias=document.getElementById('txtAlias').value;
var validationco=ds.Tables[0].Rows[0].ValidationCode;
 period = document.getElementById('drperiodicity').value;
    var suppcode1,periodicity1,alias1;
        for ( var index = 0; index < 200; index++ ) 
          { 
          
        popwin=window.open('popupsupplement.aspx?show='+show+' &periodicity1='+periodicity+'&validationco='+validationco+' &alias1='+alias+'&suppcode1='+suppcode,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=515px');
        //' &show='+show
        popwin.focus();

        return false;
        }
    return false;
    }
else
{
alert("Whenever Periodicity is Daily or Weekly ,Suppliment Issue Date is not required.");
return false;
}

}//*******************************************************************************************************
//********************This function is used to enter new records*****************************************
//*******************************************************************************************************
function ClickNew()
{
count=0;
//dan
var strtextd = "";
document.getElementById('hdnbntstatus').value = "N";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.blankSession();
document.getElementById('hiddeneditalias').value="";
document.getElementById('hiddeneditdate').value="";
document.getElementById('hiddeneditaddate').value="";
 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtSuppCode').disabled=true;
		      document.getElementById('txtAlias').disabled=true;

    	      }
		     else
		       {
		       document.getElementById('txtSuppCode').disabled=false;
		      // document.getElementById('txtAlias').disabled=false;

    	       }
    	       
    	      

document.getElementById('drpPubName').value="0";
document.getElementById('drEditonName').value="0";
document.getElementById('txtSuppName').value = "";
document.getElementById('txtepr').value = "";
document.getElementById('drsupptyp').value="0";

//document.getElementById('txtAlias').value="";
document.getElementById('txtSuppCode').value="";
document.getElementById('druom').value="0";
document.getElementById('txtcolumn').value="";
document.getElementById('txtsizeheight').value="";
document.getElementById('txtsizewidth').value="";
document.getElementById('txtarea').value="";
document.getElementById('drperiodicity').value = "0";
document.getElementById('txtshortname').value="";


	
	

document.getElementById('drpPubName').disabled=false;
document.getElementById('drEditonName').disabled=false;
document.getElementById('txtSuppName').disabled = false;

document.getElementById('txtepr').disabled = false;
//document.getElementById('txtAlias').disabled=false;
document.getElementById('druom').disabled=false;
document.getElementById('txtcolumn').disabled=false;
document.getElementById('txtsizeheight').disabled=false;
document.getElementById('txtsizewidth').disabled=false;
document.getElementById('txtarea').disabled=true;
document.getElementById('drperiodicity').disabled=false;
document.getElementById('drsupptyp').disabled=false;

document.getElementById('txtgutter').disabled=false;
document.getElementById('txtcol').disabled=false;
document.getElementById('txthr').disabled=false;
document.getElementById('txtmin').disabled=false;
document.getElementById('txtshortname').disabled = false;


/*********/
document.getElementById('Table5').disabled=false;
/*******/
document.getElementById('txtgutter').value="";
document.getElementById('txtcol').value="";
document.getElementById('txthr').value="";
//document.getElementById('hidro').value="";
document.getElementById('txtmin').value="";
document.getElementById('txtproduction').value="";


document.getElementById('lbsupplement').disabled=false;

  if(document.getElementById('hiddenauto').value==1)
                    {
                    document.getElementById('drpPubName').focus();
                    }
                    else
                    {
                    document.getElementById('drpPubName').focus();
                    }
		
	
	
//document.getElementById('txtSuppCode').disabled=false;

/*document.getElementById('btnNew').enabled=false;
document.getElementById('btnSave').disabled=false;
document.getElementById('btnExit').disabled=true;
document.getElementById('btnQuery').disabled=true;
document.getElementById('btnNew').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnExecute').disabled=true;*/

chkstatus(FlagStatus);
	hiddentext="new";
	show="1";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;


			document.getElementById('txtcolumn').value = '8';
			document.getElementById('txtsizeheight').value = '51';
			document.getElementById('txtsizewidth').value = '33';

			document.getElementById('txtgutter').value = '0.40';
			document.getElementById('txtcol').value = '3.67';
			document.getElementById('txtmin').value = '0';
			document.getElementById('txthr').value = '0';


			document.getElementById('txtproduction').value = '0';
			document.getElementById('txtarea').value = '1683';

flag=0;
setButtonImages();
return false;
}
//*********************************************************************************************************
//*******************************This function is used to clear records from screen*******************************
//*********************************************************************************************************
function ClickCancel(formname)
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.blankSession();
document.getElementById('hiddeneditalias').value="";
document.getElementById('hiddeneditdate').value="";
document.getElementById('hiddeneditaddate').value="";
document.getElementById('drpPubName').value="0";
document.getElementById('drEditonName').value="0";
var pkgitem=document.getElementById('drEditonName');
 pkgitem.options.length=1;
 pkgitem.options[0]=new Option("----Select Edititon----","0");
show="0";

//document.getElementById('drEditonName').options.length=1;
document.getElementById('txtSuppName').value = "";
document.getElementById('txtepr').value = "";
document.getElementById('txtAlias').value="";
document.getElementById('txtSuppCode').value="";
document.getElementById('druom').value="0";
document.getElementById('txtcolumn').value="";
document.getElementById('txtsizeheight').value="";
document.getElementById('txtsizewidth').value="";
document.getElementById('txtarea').value="";
document.getElementById('drperiodicity').value="0";
document.getElementById('drsupptyp').value = "0";
document.getElementById('txtshortname').value = "";



document.getElementById('txtgutter').disabled=true;
document.getElementById('txtcol').disabled=true;
document.getElementById('txthr').disabled=true;
document.getElementById('txtmin').disabled=true;
document.getElementById('txtproduction').disabled=true;

document.getElementById('txtgutter').value="";
document.getElementById('txtcol').value="";
document.getElementById('txthr').value="";
//document.getElementById('hidro').value="";
document.getElementById('txtmin').value="";
document.getElementById('txtproduction').value="";
	

/*document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnExit').disabled=true;
document.getElementById('btnQuery').disabled=false;
document.getElementById('btnNew').disabled=false;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
document.getElementById('btnExit').disabled=false;*/
 //givebuttonpermission('SupplimentMaster');
	

document.getElementById('drpPubName').disabled=true;
document.getElementById('drEditonName').disabled=true;
document.getElementById('txtSuppName').disabled = true;
document.getElementById('txtepr').disabled = true;
document.getElementById('txtAlias').disabled=true;
document.getElementById('txtSuppCode').disabled=true;
document.getElementById('druom').disabled=true;
document.getElementById('txtcolumn').disabled=true;
document.getElementById('txtsizeheight').disabled=true;
document.getElementById('txtsizewidth').disabled=true;
document.getElementById('txtarea').disabled=true;
  document.getElementById('drperiodicity').disabled=true;
  document.getElementById('drsupptyp').disabled=true;
  document.getElementById('lbsupplement').disabled=true;

	
	
	
  if (document.getElementById('hdnbntstatus').value != "S") {
      document.getElementById('CheckBox1').checked = false;
      document.getElementById('CheckBox2').checked = false;
      document.getElementById('CheckBox3').checked = false;
      document.getElementById('CheckBox4').checked = false;
      document.getElementById('CheckBox5').checked = false;
      document.getElementById('CheckBox6').checked = false;
      document.getElementById('CheckBox7').checked = false;
      document.getElementById('CheckBox8').checked = false;
      document.getElementById('hdnbntstatus').value = "";
  }

document.getElementById('CheckBox1').disabled=true;
document.getElementById('CheckBox2').disabled=true;
document.getElementById('CheckBox3').disabled=true;
document.getElementById('CheckBox4').disabled=true;
document.getElementById('CheckBox5').disabled=true;
document.getElementById('CheckBox6').disabled=true;
document.getElementById('CheckBox7').disabled=true;
document.getElementById('CheckBox8').disabled=true;
document.getElementById('btnNew').disabled=false;
document.getElementById('btnNew').focus();
	givebuttonpermission('SupplimentMaster');


//getPermission('SupplimentMaster');

setButtonImages();
return false;
}
//******************************************************************************************************
//********************This function is used to modify existing record***********************************
//*******************************************************************************************************

var preval;
var count=0;
function ClickModify()
{
    document.getElementById('hdnbntstatus').value = "M";
flag=1;
/********ssa**/
addcount11();

count=1;
preval=document.getElementById('txthr').value;
/*document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=false;
document.getElementById('btnExit').disabled=true;
document.getElementById('btnQuery').disabled=true;
document.getElementById('btnNew').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
document.getElementById('btnExit').disabled=false;*/
chkstatus(FlagStatus);
document.getElementById('btnModify').disabled=true;


hiddentext="modify";
show="1";
		
////document.getElementById('drpPubName').disabled=false;
////document.getElementById('drEditonName').disabled=false;
document.getElementById('txtSuppName').disabled = false;
document.getElementById('txtepr').disabled = false;
document.getElementById('txtAlias').disabled=true;
document.getElementById('txtSuppCode').disabled=true;
var edition=document.getElementById('drEditonName').value;
document.getElementById('druom').disabled=false;
document.getElementById('txtcolumn').disabled=false;
document.getElementById('txtsizeheight').disabled=false;
document.getElementById('txtsizewidth').disabled=false;
document.getElementById('txtarea').disabled=true;
document.getElementById('drperiodicity').disabled=true;
document.getElementById('drsupptyp').disabled = false;
document.getElementById('txtshortname').disabled = false;


var  periodicity5=document.getElementById('drperiodicity').value;
var response5=SupplimentMaster.chkperiodicty(periodicity5);
var ds5=response5.value;
	if(hiddentext!="query" && ds5.Tables[0].Rows[0].ValidationCode!="4" && ds5.Tables[0].Rows[0].ValidationCode!="2")
	{
     //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

SupplimentMaster.fillsupplement(edition,fillchk_callback);
     }


document.getElementById('txtgutter').disabled=false;
document.getElementById('txtcol').disabled=false;
document.getElementById('txthr').disabled=false;
document.getElementById('txtmin').disabled=false;
document.getElementById('txtproduction').disabled=false;

chknamemod=document.getElementById('txtSuppName').value;
//document.getElementById('txtgutter').value="";
//document.getElementById('txtcol').value="";
//document.getElementById('txthr').value="";
//document.getElementById('txtmin').value="";
//document.getElementById('txtproduction').value="";

document.getElementById('btnSave').disabled=false;

/*document.getElementById('CheckBox1').disabled=false;
document.getElementById('CheckBox2').disabled=false;
document.getElementById('CheckBox3').disabled=false;
document.getElementById('CheckBox4').disabled=false;
document.getElementById('CheckBox5').disabled=false;
document.getElementById('CheckBox6').disabled=false;
document.getElementById('CheckBox7').disabled=false;
document.getElementById('CheckBox8').disabled=false;*/
setButtonImages();
return false;
}

var flag="";

//**********************************************************************************************
//**************************************This function is used to save records*******************
//**********************************************************************************************

function ClickSave()
{
    //count=0;
    document.getElementById('hdnbntstatus').value = "S";
    document.getElementById('hdnsuppcode').value = trim(document.getElementById('txtSuppCode').value);
    	document.getElementById('txtSuppCode').value=trim(document.getElementById('txtSuppCode').value);
    	document.getElementById('txtSuppName').value = trim(document.getElementById('txtSuppName').value);
    	document.getElementById('txtshortname').value = trim(document.getElementById('txtshortname').value);
        
        var compcode=document.getElementById('hiddencompcode').value;
	    var userid=document.getElementById('hiddenuserid').value;
	
	   
	    if (document.getElementById('drpPubName').value=="0")
		{
		    alert("Please Select Publication Name");
		    document.getElementById('drpPubName').focus();
		    return false;
		}
		else
		{
		   var PubName=document.getElementById('drpPubName').value;
		}
		
		if (document.getElementById('drEditonName').value=="0")
		{
		    alert("Please Select Edition Name");
		    if(document.getElementById('drEditonName').disable==false)
		    document.getElementById('drEditonName').focus();
		    return false;
		}
		else
		{
		    var EditonName=document.getElementById('drEditonName').value;
		}
		if (document.getElementById('drsupptyp').value=="0")
		{
		    alert("Please Select Supplement Type");
		    document.getElementById('drsupptyp').focus();
		    return false;
		}
		else
		{
		   var supptyp=document.getElementById('drsupptyp').value;
		}


	
    
         if ((document.getElementById('txtSuppCode').value=="" )&& (document.getElementById('hiddenauto').value!=1))
	    {
		    alert("Please Select Suppliment Code");
		    document.getElementById('txtSuppCode').focus();
		    return false;
		}
		else
		{
		    var SuppCode=document.getElementById('txtSuppCode').value;
		}
	    
		if (document.getElementById('txtSuppName').value=="")
		{
		    alert("Please Select Suppliment Name");
		    document.getElementById('txtSuppName').focus();
		    return false;
		}
		else
		{
		    var SuppName=document.getElementById('txtSuppName').value;
        }


        if (document.getElementById('txtshortname').value == "") {
            alert("Please Select Short Name");
            document.getElementById('txtshortname').focus();
            return false;
        }
    
		if (document.getElementById('drperiodicity').value=="0")
        {
            alert("Please Select Periodicity");
            document.getElementById('drperiodicity').focus();
            return false;
        }
            
        if(parseInt(ro) < parseInt(document.getElementById('txthr').value))
        {
                alert('RO Time is Greater Than Publication RO Time');
                if(count==0)
                {
                    document.getElementById('txthr').value=ro;
                    document.getElementById('txthr').focus();
                 }
                 else
                 {
                    document.getElementById('txthr').value=preval;
                    document.getElementById('txthr').focus();
                    count=0;
                 }
                return false;
        }
            
		 
		 if(document.getElementById('druom').style.display!="none" && document.getElementById('druom').value=="0")
        {
            alert("Please Select Volume Unit");
            document.getElementById('druom').focus();
            return false;
        }
         if(document.getElementById('txtcolumn').value=="")
        {
            alert("Please Enter No. Of Columns");
            document.getElementById('txtcolumn').focus();
            return false;
        }
            
        if(document.getElementById('txtsizeheight').value=="")
        {
            alert("Please Enter Height");
            document.getElementById('txtsizeheight').focus();
            return false;
        }
        if(document.getElementById('txtsizewidth').value=="")
        {
            alert("Please Enter Width");
            document.getElementById('txtsizewidth').focus();
            return false;
        }
        
        if (document.getElementById('txtgutter').value=="")
		{
		    alert("Please Enter Gutter Space");
		    document.getElementById('txtgutter').focus();
		    return false;
		}
		else
		{
		   var gut=document.getElementById('txtgutter').value;
		}
                  
        if (document.getElementById('txtcol').value=="")
		{
	        alert("Please Enter Column Space");
	        document.getElementById('txtcol').focus();
	        return false;
		}
		else
		{
		    var col=document.getElementById('txtcol').value;
		}    
            
        if (((document.getElementById('txthr').value=="") || (document.getElementById('txtmin').value=="")) && (document.getElementById('txtproduction').value==""))
		{
		    alert("Please Enter RO Time or Production days");
            //document.getElementById('txthr').focus();
            return false;
	    }
		/*if(document.getElementById('txtmin').value=="")
		{
            alert("Please Enter RO Time");
            document.getElementById('txtmin').focus();
            return false;
	    } 
        if(document.getElementById('txtproduction').value=="")
        {
            alert("Please Enter Production days");
            document.getElementById('txtproduction').focus();
            return false;
        }*/
		if(document.getElementById('txtproduction').value>365)        
		{
		   alert("Production days cannot be greater than 365.");
		   return false;
		}     
		else
		{
		    var hr=document.getElementById('txtgutter').value;
		    var min=document.getElementById('txthr').value;
		    var pro=document.getElementById('txtmin').value;
		}
		    
        var Alias=document.getElementById('txtAlias').value;
        var uom=document.getElementById('druom').value;
		var column=document.getElementById('txtcolumn').value;
		var height=document.getElementById('txtsizeheight').value;
		var width=document.getElementById('txtsizewidth').value;
		var area=document.getElementById('txtarea').value;
		var periodicity = document.getElementById('drperiodicity').value;
		var SHORTNAME = document.getElementById('txtshortname').value;		
		
		
     //dan
      var strtextd="";
      var  httpRequest =null;
      httpRequest= new XMLHttpRequest();
      if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
           if(strtextd!="sess")
           {
               alert('session expired');
               window.location.href="Default.aspx";
               return false;
           } 
           SupplimentMaster.chkperiodicty(periodicity,callbck_periodicitysave);
           return false;
             
  }

            
            
  function callbck_periodicitysave(response)     
  { 
      var ds=response.value;
      var SuppCode=document.getElementById('txtSuppCode').value;
     
        if((ds.Tables[0].Rows[0].ValidationCode=="1")||(ds.Tables[0].Rows[0].ValidationCode=="5"))
       {
    
             if(document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
            {
            alert("Please Select Supplement Day First...");
            return false;
            }
            else
            {
             call_finallysavemodify();
             return false;
            }
       }
       gbchkperiod=ds.Tables[0].Rows[0].ValidationCode;
          
      if((ds.Tables[0].Rows[0].ValidationCode=="2")||(ds.Tables[0].Rows[0].ValidationCode=="3")||(ds.Tables[0].Rows[0].ValidationCode=="4"||ds.Tables[0].Rows[0].ValidationCode=="6"))
      {
          
            if (flag==1)
            {
              call_finallysavemodify();
            }
           else
           {
              SupplimentMaster.chkperiodicty_edition(SuppCode,call_finallychkperiodictyjssupp);
           }
        return false; 
          
       }
       return false; 
  }
        
        
        
     function  call_finallychkperiodicty(res)
     {
      
          var dschk=res.value;
          if(dschk.Tables[0].Rows.length==0)
          {
          alert("Please Fill Supplement Issue Date");
          return false;
          }  
          else if((gbchkperiod=="2")&&((dschk.Tables[0].Rows[0].Date_Supplement=="")||(dschk.Tables[0].Rows[0].Date_Supplement==null)))
          {
          alert("Please Fill First Cycle Date In Supplement Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="3") &&((dschk.Tables[0].Rows[0].AdditionalDate_Supp=="")||(dschk.Tables[0].Rows[0].AdditionalDate_Supp==null)))
          {
          alert("Please Fill Second Cycle Date In Supplement Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="4") &&((dschk.Tables[0].Rows[0].AdditionalDate_Supp=="")||(dschk.Tables[0].Rows[0].AdditionalDate_Supp==null)||(dschk.Tables[0].Rows[0].Date_Supplement=="")||(dschk.Tables[0].Rows[0].Date_Supplement==null)))
          {
          alert("Please Fill First and Second Cycle Date In Supplement Issue Date Pop-Up");
          return false;
          }
          else
          {
           call_finallysavemodify();
           return false;
          }
          
     }
 
     
  function call_finallysavemodify()
    {
        	var PubName=document.getElementById('drpPubName').value;
		    var EditonName=document.getElementById('drEditonName').value;
		    var supptyp=document.getElementById('drsupptyp').value;
		      
		    var SuppCode=document.getElementById('txtSuppCode').value;
			var SuppName=document.getElementById('txtSuppName').value;
            var Alias=document.getElementById('txtAlias').value;
                
	        var compcode=document.getElementById('hiddencompcode').value;
	        var userid=document.getElementById('hiddenuserid').value;
            	
	     
            var uom=document.getElementById('druom').value;
            var column=document.getElementById('txtcolumn').value;
            var height=document.getElementById('txtsizeheight').value;
            var width=document.getElementById('txtsizewidth').value;
            var area=document.getElementById('txtarea').value;
            var periodicity=document.getElementById('drperiodicity').value;
   	        var gut=document.getElementById('txtgutter').value;
            var col=document.getElementById('txtcol').value;
            var hr=document.getElementById('txthr').value;
            var min=document.getElementById('txtmin').value;
            var pro=document.getElementById('txtproduction').value;
            var akh = document.getElementById('txtSuppCode').value
            var SHORTNAME = document.getElementById('txtshortname').value;

           if (flag==1)
	       {
	               show="0";
	               if(chknamemod==document.getElementById('txtSuppName').value)
                   {
                      updatesupplement();
                   }
                   else
                   {
                         SupplimentMaster.chkid(SuppName,SuppCode,Alias,compcode,userid,PubName,EditonName,callmodify);
                        return false; 
                   }
	           
          }
	      else
		  {
               SupplimentMaster.chkid(SuppName,SuppCode,Alias,compcode,userid,PubName,EditonName,callsave);
              return false;
          }
}
//*******************************************************************************************************//

function updatesupplement()
{
            var PubName=document.getElementById('drpPubName').value;
		    var EditonName=document.getElementById('drEditonName').value;
		    var supptyp=document.getElementById('drsupptyp').value;
		      
		    var SuppCode=document.getElementById('txtSuppCode').value;
			var SuppName=document.getElementById('txtSuppName').value;
            var Alias=document.getElementById('txtAlias').value;
                
	        var compcode=document.getElementById('hiddencompcode11').value;
	        var userid=document.getElementById('hiddenuserid').value;
            	
	     
            var uom=document.getElementById('druom').value;
            var column=document.getElementById('txtcolumn').value;
            var height=document.getElementById('txtsizeheight').value;
            var width=document.getElementById('txtsizewidth').value;
            var area=document.getElementById('txtarea').value;
            var periodicity=document.getElementById('drperiodicity').value;
   	        var gut=document.getElementById('txtgutter').value;
            var col=document.getElementById('txtcol').value;
            var hr=document.getElementById('txthr').value;
            var min=document.getElementById('txtmin').value;
            var pro=document.getElementById('txtproduction').value;
            var akh=document.getElementById('txtSuppCode').value

            selectedtionday(akh);

            var SHORTNAME = document.getElementById('txtshortname').value;

            var ip2 = document.getElementById('ip1').value;
            var epaper = document.getElementById('txtepr').value;
                SupplimentMaster.modify(PubName,EditonName,SuppName,Alias,SuppCode,compcode,userid,uom,column,height,width,area,periodicity,supptyp,gut,col,hr,min,pro,ip2,SHORTNAME,epaper);
                suppdataset.Tables[0].Rows[z].Pub_Code=document.getElementById('drpPubName').value;
                suppdataset.Tables[0].Rows[z].Edition_Code = document.getElementById('drEditonName').value;
                
                if(document.getElementById('txtSuppName').value!=null)
                    suppdataset.Tables[0].Rows[z].Supp_Name = document.getElementById('txtSuppName').value;
                else
                    suppdataset.Tables[0].Rows[z].Supp_Name =""
                suppdataset.Tables[0].Rows[z].SUPP_URL= document.getElementById('txtepr').value;
                suppdataset.Tables[0].Rows[z].Supp_Alias=document.getElementById('txtAlias').value;
                suppdataset.Tables[0].Rows[z].Supp_Code=document.getElementById('txtSuppCode').value;
                suppdataset.Tables[0].Rows[z].UOM_Code=document.getElementById('druom').value;
		        suppdataset.Tables[0].Rows[z].No_Of_Columns=document.getElementById('txtcolumn').value;
		        suppdataset.Tables[0].Rows[z].Size_Height=document.getElementById('txtsizeheight').value;
		        suppdataset.Tables[0].Rows[z].Size_Width=document.getElementById('txtsizewidth').value;
		        suppdataset.Tables[0].Rows[z].Supp_Area=document.getElementById('txtarea').value;
		        suppdataset.Tables[0].Rows[z].Preodicity_Code=document.getElementById('drperiodicity').value;
	            suppdataset.Tables[0].Rows[z].supptypcode=document.getElementById('drsupptyp').value;
	    
	            suppdataset.Tables[0].Rows[z].gutter_space=document.getElementById('txtgutter').value;
	            suppdataset.Tables[0].Rows[z].column_space=document.getElementById('txtcol').value;
	            suppdataset.Tables[0].Rows[z].ro_hr=document.getElementById('txthr').value;
	            suppdataset.Tables[0].Rows[z].ro_min=document.getElementById('txtmin').value;
	            suppdataset.Tables[0].Rows[z].production=document.getElementById('txtproduction').value;
	
                txteditionname=document.getElementById('hiddeneditalias').value;
                txtdate=document.getElementById('hiddeneditdate').value;
                txtaddate=document.getElementById('hiddeneditaddate').value;
                   
                SupplimentMaster.popinsertsupp(txteditionname,txtdate,txtaddate,compcode,userid,SuppCode);	
        	      
     
                document.getElementById('hiddeneditalias').value="";
                document.getElementById('hiddeneditdate').value="";
                document.getElementById('hiddeneditaddate').value="";
               // document.getElementById('hdnsuppcode').value = "";
		        updateStatus();
		        flag=0;

		        document.getElementById('CheckBox1').disabled=true;
		        document.getElementById('CheckBox2').disabled=true;
		        document.getElementById('CheckBox3').disabled=true;
		        document.getElementById('CheckBox4').disabled=true;
		        document.getElementById('CheckBox5').disabled=true;
		        document.getElementById('CheckBox6').disabled=true;
		        document.getElementById('CheckBox7').disabled=true;
		        document.getElementById('CheckBox8').disabled=true;

		        document.getElementById('drpPubName').disabled=true;
		        document.getElementById('drEditonName').disabled=true;
		        document.getElementById('txtSuppName').disabled = true;
		        document.getElementById('txtepr').disabled = true;
		        document.getElementById('txtAlias').disabled=true;
		        document.getElementById('txtSuppCode').disabled=true;
		        document.getElementById('druom').disabled=true;
		        document.getElementById('txtcolumn').disabled=true;
		        document.getElementById('txtsizeheight').disabled=true;
		        document.getElementById('txtsizewidth').disabled=true;
		        document.getElementById('txtarea').disabled=true;
		        document.getElementById('drperiodicity').disabled=true;
		        document.getElementById('drsupptyp').disabled=true;
        	    document.getElementById('txtgutter').disabled=true;
                document.getElementById('txtcol').disabled=true;
                document.getElementById('txthr').disabled=true;
                document.getElementById('txtmin').disabled=true;
                document.getElementById('txtproduction').disabled = true;

                document.getElementById('txtshortname').disabled = true;

                if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }
                
                 if (z==0)
                {
                    document.getElementById('btnfirst').disabled=true;
                    document.getElementById('btnprevious').disabled=true;
                }

                if(z==(suppdataset.Tables[0].Rows.length-1))
                {
                    document.getElementById('btnnext').disabled=true;
	                document.getElementById('btnlast').disabled=true;
                }
                setButtonImages();
                return false;
  
}


function callmodify(res)
{
  var ds=res.value;
  if(ds.Tables[1].Rows.length > 0)
    {
        alert("This Name already in use!!  please try another name ! ");
        return false;
    }
   updatesupplement();
}
//*********************************This function is call back response for call save*********************//
//*******************************************************************************************************

function callsave(res)
{
  var ds=res.value;
    if(ds.Tables[0].Rows.length > 0)
    {
       alert("This Code already in use!!  please try another code ! ");
        return false;
    }
    else if(ds.Tables[1].Rows.length > 0)
    {
        alert("This Name already in use!!  please try another name ! ");
        return false;
    }
    else if(ds.Tables[2].Rows.length > 0)
    {
        alert("This Alias already in use!!  please try another  Suppname ! ");
        return false;
    }
    else
   {
	var compcode=document.getElementById('hiddencompcode11').value;
	var userid=document.getElementById('hiddenuserid').value;
	if (document.getElementById('drpPubName').value=="0")
	{
	    alert("Please Select Publication Name");
	    document.getElementById('drpPubName').focus();
	    return false;
	}
	else
	{
	     var PubName=document.getElementById('drpPubName').value;
	}
	if (document.getElementById('drEditonName').value=="0")
	{
	    alert("Please Select Edition Name");
	    document.getElementById('drEditonName').focus();
	    return false;
	}
	else
	{
	    var EditonName=document.getElementById('drEditonName').value;
	}
	if (document.getElementById('drsupptyp').value=="0")
    {
		alert("Please Select Supplement Type");
		document.getElementById('drsupptyp').focus();
		return false;
     }
	else
	{
		var supptyp=document.getElementById('drsupptyp').value;
    }

	if (document.getElementById('txtSuppCode').value=="")
	{
		alert("Please Select Suppliment Code");
		document.getElementById('txtSuppCode').focus();
		return false;
    }
	else
	{
		var SuppCode=document.getElementById('txtSuppCode').value;
    }
	
	if (document.getElementById('txtSuppName').value=="")
    {
		alert("Please Select Suppliment Name");
		document.getElementById('txtSuppName').focus();
		return false;
	}
	else
	{
		var SuppName=document.getElementById('txtSuppName').value;
}




//if (document.getElementById('txtshortname').value == "") {
//    alert("Please Select Short Name");
//    document.getElementById('txtshortname').focus();
//    return false;
//}
//else {
//    var SHORTNAME = document.getElementById('txtshortname').value;
//}
//    
//    
		
	if (document.getElementById('drperiodicity').value=="0")
    {
            alert("Please Select Periodicity");
            document.getElementById('drperiodicity').focus();
            return false;
        }
     
     
     
     
     
            
    if (document.getElementById('txtgutter').value=="")
	{
		alert("Please Enter Gutter Space");
		document.getElementById('txtgutter').focus();
		return false;
	}
	else
	{
		var gut=document.getElementById('txtgutter').value;
	}
            
    if (document.getElementById('txtcol').value=="")
	{
		alert("Please Enter Column Space");
		document.getElementById('txtcol').focus();
		return false;
	}
	else
	{
		var col=document.getElementById('txtcol').value;
}



	
            
    if (document.getElementById('txthr').value=="")
	{
		    if(document.getElementById('txtmin').value=="")
		    {
		        if(document.getElementById('txtproduction').value=="")
		        {
		            alert("Please Enter either RO Time or Production days Before");
		            document.getElementById('txthr').focus();
		            return false;
		        }
		    }        
	}
	else
	{
	    var hr=document.getElementById('txtgutter').value;
	    var min=document.getElementById('txthr').value;
	    var pro=document.getElementById('txtmin').value;
	}
		
         
	var Alias=document.getElementById('txtAlias').value;
    var uom=document.getElementById('druom').value;
	var column=document.getElementById('txtcolumn').value;
	var height=document.getElementById('txtsizeheight').value;
	var width=document.getElementById('txtsizewidth').value;
	var area=document.getElementById('txtarea').value;
	var  periodicity=document.getElementById('drperiodicity').value;
	var supptyp=document.getElementById('drsupptyp').value;
    var gut=document.getElementById('txtgutter').value;
    var col=document.getElementById('txtcol').value;
    var hr=document.getElementById('txthr').value;
    var min=document.getElementById('txtmin').value;
    var pro=document.getElementById('txtproduction').value;
    var akh = document.getElementById('txtSuppCode').value


    selectedtionday(akh);
    var SHORTNAME = document.getElementById('txtshortname').value;
    var ip2 = document.getElementById('ip1').value;
    var epaper = document.getElementById('txtepr').value;
	SupplimentMaster.insert(PubName, EditonName, SuppName, Alias, SuppCode, compcode, userid, uom, column, height, width, area, periodicity, supptyp, gut, col, hr, min, pro, ip2, SHORTNAME,epaper);
        
     txteditionname=document.getElementById('hiddeneditalias').value;
     txtdate=document.getElementById('hiddeneditdate').value;
     txtaddate=document.getElementById('hiddeneditaddate').value;
                   
     SupplimentMaster.popinsertsupp(txteditionname,txtdate,txtaddate,compcode,userid,SuppCode);	
        	      
     document.getElementById('hiddeneditalias').value="";
     document.getElementById('hiddeneditdate').value="";
     document.getElementById('hiddeneditaddate').value="";
        
	document.getElementById('btnNew').disabled=false;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnCancel').disabled=false;		
    document.getElementById('btnExit').disabled=false;	
    document.getElementById('btnSave').disabled=true;
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=true;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=true;
	ClickCancel('SupplimentMaster');

	document.getElementById('drpPubName').value="0";
	document.getElementById('drEditonName').value="0";
	document.getElementById('txtSuppName').value = "";
	document.getElementById('txtepr').value = "";
	document.getElementById('txtAlias').value="";
	document.getElementById('txtSuppCode').value="";
	document.getElementById('druom').value="0";
	document.getElementById('txtcolumn').value="";
	document.getElementById('txtsizeheight').value="";
	document.getElementById('txtsizewidth').value="";
	document.getElementById('txtarea').value="";
    document.getElementById('drperiodicity').value="0";
    document.getElementById('drsupptyp').value="0";
      	
      	
    document.getElementById('txtgutter').disabled=true;
    document.getElementById('txtcol').disabled=true;
    document.getElementById('txthr').disabled=true;
    document.getElementById('txtmin').disabled=true;
    document.getElementById('txtproduction').disabled=true;

    document.getElementById('txtgutter').value="";
    document.getElementById('txtcol').value="";
    document.getElementById('txthr').value="";
    document.getElementById('txtmin').value="";
    document.getElementById('txtproduction').value="";
    //document.getElementById('hdnsuppcode').value = "";

	document.getElementById('drpPubName').disabled=true;
	document.getElementById('drEditonName').disabled=true;
	document.getElementById('txtSuppName').disabled = true;

	document.getElementById('txtepr').disabled = true;
	document.getElementById('txtAlias').disabled=true;
	document.getElementById('txtSuppCode').disabled=true;
	document.getElementById('druom').disabled=true;
	document.getElementById('txtcolumn').disabled=true;
	document.getElementById('txtsizeheight').disabled=true;
	document.getElementById('txtsizewidth').disabled=true;
	document.getElementById('txtarea').disabled=true;
    document.getElementById('drperiodicity').disabled=true;
    document.getElementById('drsupptyp').disabled=true;
      	
	

    
		
	if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
         return false;
    }
    else
    {
	    alert(xmlObj.childNodes(0).childNodes(0).text);
	     return false;
	}
	 return false;
	}
	
    ClickCancel('SupplimentMaster');
    return false;
}
//********************************************************************************************************
//*******************************This function is used to execute ****************************************
//********************************************************************************************************
function ClickExecute()
{

/*document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnExit').disabled=true;
document.getElementById('btnQuery').disabled=false;
document.getElementById('btnNew').disabled=true;
document.getElementById('btnModify').disabled=false;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnDelete').disabled=false;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=false;
document.getElementById('btnprevious').disabled=false;
document.getElementById('btnnext').disabled=false;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnExit').disabled=false;*/

updateStatus();
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
            document.getElementById('btnlast').disabled=false;


document.getElementById('drpPubName').disabled=true;
document.getElementById('txtSuppName').disabled = true;
document.getElementById('txtepr').disabled = true;
document.getElementById('drEditonName').disabled=true;
		
document.getElementById('txtAlias').disabled=true;
document.getElementById('txtSuppCode').disabled=true;
document.getElementById('druom').disabled=true;
document.getElementById('txtcolumn').disabled=true;
document.getElementById('txtsizeheight').disabled=true;
document.getElementById('txtsizewidth').disabled=true;
document.getElementById('txtarea').disabled=true;
document.getElementById('drperiodicity').disabled=true;
document.getElementById('drsupptyp').disabled=true;
document.getElementById('lbsupplement').disabled=false;
     
  
      			document.getElementById('txtgutter').disabled=true;
document.getElementById('txtcol').disabled=true;
document.getElementById('txthr').disabled=true;
document.getElementById('txtmin').disabled=true;
document.getElementById('txtproduction').disabled=true;

//document.getElementById('txtgutter').value="";
//document.getElementById('txtcol').value="";
//document.getElementById('txthr').value="";
//document.getElementById('txtmin').value="";
//document.getElementById('txtproduction').value="";
        	


var PubName=document.getElementById('drpPubName').value;
var EditonName=document.getElementById('drEditonName').value;
var SuppName=document.getElementById('txtSuppName').value;
var Alias=document.getElementById('txtAlias').value;
var SuppCode=document.getElementById('txtSuppCode').value;

var compcode=document.getElementById('hiddencompcode11').value;
var userid=document.getElementById('hiddenuserid').value;
glpubname=document.getElementById('drpPubName').value;
gleditionname=document.getElementById('drEditonName').value;
glsuppcode=document.getElementById('txtSuppCode').value;
glsuppname=document.getElementById('txtSuppName').value;
glalias=document.getElementById('txtAlias').value;
  var uom=document.getElementById('druom').value;
	    gbuom=uom;
		var column=document.getElementById('txtcolumn').value;
		gbcolumn=column;
		var height=document.getElementById('txtsizeheight').value;
		gbheight=height;
		var width=document.getElementById('txtsizewidth').value;
		gbwidth=width;
		var area=document.getElementById('txtarea').value;
		gbarea=area;
	var periodicty=document.getElementById('drperiodicity').value;
		gbperiodicty=periodicty;
		var supptyp=document.getElementById('drsupptyp').value;
        gbsupptyp=supptyp;
        
        
        
            	
    var gut=document.getElementById('txtgutter').value;
    gbgut=gut;
var col=document.getElementById('txtcol').value;
gbcol=col;
var hr=document.getElementById('txthr').value;
gbhr=hr;
var min=document.getElementById('txtmin').value;
gbmin=min;
var pro=document.getElementById('txtproduction').value;        	
gbpro=pro;

var SHORTNAME = document.getElementById('txtshortname').value;        
        
        
	
	
		show="0";
			
		


//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.Select(PubName,EditonName,SuppName,Alias,SuppCode,compcode,userid,uom,column,height,width,area,periodicty,supptyp,gut,col,hr,min,pro,SHORTNAME,call_Execute);
				
document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			return false;

}

function call_Execute(response)

{
//var ds=response.value;
suppdataset=response.value;

			if (suppdataset.Tables[0].Rows.length>0)
			{
			document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[0].Pub_Code;
			//document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[0].Edition_Code;
			document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[0].Supp_Name;
			
			
			    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[0].SUPP_URL;
		
			document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[0].Supp_Alias;
			document.getElementById('txtSuppCode').value = suppdataset.Tables[0].Rows[0].Supp_Code;

			
			    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[0].SUPP_URL;
		
			document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[0].Comp_Code;
			//document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[0].UserId;
			  document.getElementById('druom').value=suppdataset.Tables[0].Rows[0].UOM_Code;
		    document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[0].No_Of_Columns;
		    document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[0].Size_Height;
		    document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[0].Size_Width;
		    document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[0].Supp_Area;
		    document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[0].Preodicity_Code;
		    document.getElementById('drsupptyp').value = suppdataset.Tables[0].Rows[0].supptypcode;
		    if(suppdataset.Tables[0].Rows[0].SHORT_NAME!=null)
		        document.getElementById('txtshortname').value = suppdataset.Tables[0].Rows[0].SHORT_NAME;
		    else
		        document.getElementById('txtshortname').value = "";
	        
	        
	        if(suppdataset.Tables[0].Rows[0].Gutter_Space==null||suppdataset.Tables[0].Rows[0].Gutter_Space=="null")
	        {
	            document.getElementById('txtgutter').value="";
	        }
	        else
	        {
	            document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[0].Gutter_Space;
	        }
	        if(suppdataset.Tables[0].Rows[0].Column_Space==null||suppdataset.Tables[0].Rows[0].Column_Space=="null")
	        {
	            document.getElementById('txtcol').value="";
	        }
	        else
	        {
		        document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[0].Column_Space;
		    }
		    
		    if(suppdataset.Tables[0].Rows[0].RO_hr==null||suppdataset.Tables[0].Rows[0].RO_hr=="null")
	        {
	            document.getElementById('txthr').value="";
	        }
	        else
	        {
		        document.getElementById('txthr').value=suppdataset.Tables[0].Rows[0].RO_hr;
		    }
		    
		    if(suppdataset.Tables[0].Rows[0].RO_min==null||suppdataset.Tables[0].Rows[0].RO_min=="null")
	        {
	            document.getElementById('txtmin').value="";
	        }
	        else
	        {
		        document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[0].RO_min;
		    }
		    
		     if(suppdataset.Tables[0].Rows[0].Production==null||suppdataset.Tables[0].Rows[0].Production=="null")
	        {
	            document.getElementById('txtproduction').value="";
	        }
	        else
	        {
		        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[0].Production;
		    }
		    		    
		    //document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[0].Production;
	        
	        
	        
	        
		    if (suppdataset.Tables[0].Rows.length==1)
		    {
		    document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            }

		    addcount(suppdataset.Tables[0].Rows[0].Pub_Code);
		    editionvar=suppdataset.Tables[0].Rows[0].Edition_Code;
				var akh=document.getElementById('txtSuppCode').value;
			fillcheckboxes(akh);
			z=0;
			}
		else
		{
		alert("Search Not Match");
		ClickCancel('SupplimentMaster');
		return false;
		}
		setButtonImages();
return false;
}


function ClickQuery()
{
//dan
    var strtextd = "";
    document.getElementById('hdnbntstatus').value = "Q";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

SupplimentMaster.blankSession();
/*document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnExit').disabled=true;
document.getElementById('btnQuery').disabled=true;
document.getElementById('btnNew').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnExecute').disabled=false;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
document.getElementById('btnExit').disabled=false;*/
z=0;
chkstatus(FlagStatus);
hiddentext="query";
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
		document.getElementById('lbsupplement').disabled=true;

document.getElementById('drpPubName').value="0";
document.getElementById('drEditonName').value="0";
document.getElementById('txtSuppName').value = "";
document.getElementById('txtepr').value = "";
document.getElementById('txtAlias').value="";
document.getElementById('txtSuppCode').value="";
document.getElementById('druom').value="0";
document.getElementById('drperiodicity').value="0";
document.getElementById('txtcolumn').value="";
document.getElementById('txtsizeheight').value="";
document.getElementById('txtsizewidth').value="";
document.getElementById('txtarea').value="";
document.getElementById('txtgutter').value="";
document.getElementById('txtcol').value="";
document.getElementById('txthr').value="";
document.getElementById('txtmin').value="";
document.getElementById('txtproduction').value="";
document.getElementById('drsupptyp').value="0";





       document.getElementById('txtcolumn').disabled=true;
	   document.getElementById('txtsizeheight').disabled=true;
	   document.getElementById('txtsizewidth').disabled=true;
	   document.getElementById('txtarea').disabled=true;
       document.getElementById('drperiodicity').disabled=true;
	





document.getElementById('CheckBox1').disabled=true;
document.getElementById('CheckBox2').disabled=true;
document.getElementById('CheckBox3').disabled=true;
document.getElementById('CheckBox4').disabled=true;
document.getElementById('CheckBox5').disabled=true;
document.getElementById('CheckBox6').disabled=true;
document.getElementById('CheckBox7').disabled=true;
document.getElementById('CheckBox8').disabled=true;

document.getElementById('drpPubName').disabled=false;
document.getElementById('drEditonName').disabled=false;
document.getElementById('txtSuppName').disabled = false;
document.getElementById('txtepr').disabled = false;
document.getElementById('txtAlias').disabled=false;
document.getElementById('txtSuppCode').disabled=false;
document.getElementById('druom').disabled=false;
document.getElementById('drsupptyp').disabled=false;
  

document.getElementById('CheckBox1').checked=false;
document.getElementById('CheckBox2').checked=false;
document.getElementById('CheckBox3').checked=false;
document.getElementById('CheckBox4').checked=false;
document.getElementById('CheckBox5').checked=false;
document.getElementById('CheckBox6').checked=false;
document.getElementById('CheckBox7').checked=false;
document.getElementById('CheckBox8').checked=false;
setButtonImages();
return false;
}


function ClickFirst()
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.blankSession();
var PubName=document.getElementById('drpPubName').value;
var EditonName=document.getElementById('drEditonName').value;
var SuppName=document.getElementById('txtSuppName').value;
var Alias=document.getElementById('txtAlias').value;
var SuppCode = document.getElementById('txtSuppCode').value;
var SHORTNAME = document.getElementById('txtshortname').value;


var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

SupplimentMaster.Selectfnpl(PubName, EditonName, SuppName, Alias, SuppCode, compcode, userid, SHORTNAME,call_First);
return false;
}

function call_First(response)
{
z=0;
//var ds=response.value;
document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[0].Pub_Code;
//document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[0].Edition_Code
document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[0].Supp_Name;


    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[0].SUPP_URL;



document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[0].Supp_Alias;
document.getElementById('txtSuppCode').value=suppdataset.Tables[0].Rows[0].Supp_Code;
document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[0].Comp_Code;
//document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[0].UserId;
document.getElementById('druom').value=suppdataset.Tables[0].Rows[0].UOM_Code;
document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[0].No_Of_Columns;
document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[0].Size_Height;
document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[0].Size_Width;
document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[0].Supp_Area;
  document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[0].Preodicity_Code;
  document.getElementById('drsupptyp').value = suppdataset.Tables[0].Rows[0].supptypcode;
  if (suppdataset.Tables[0].Rows[z].SHORT_NAME != null)
      document.getElementById('txtshortname').value = suppdataset.Tables[0].Rows[z].SHORT_NAME;
  else
      document.getElementById('txtshortname').value = "";
	  
	  	     if(suppdataset.Tables[0].Rows[0].Gutter_Space==null||suppdataset.Tables[0].Rows[0].Gutter_Space=="null")
	        {
	            document.getElementById('txtgutter').value="";
	        }
	        else
	        {
	            document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[0].Gutter_Space;
	        }
	        if(suppdataset.Tables[0].Rows[0].Column_Space==null||suppdataset.Tables[0].Rows[0].Column_Space=="null")
	        {
	            document.getElementById('txtcol').value="";
	        }
	        else
	        {
		        document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[0].Column_Space;
		    }
		    
		    if(suppdataset.Tables[0].Rows[0].RO_hr==null||suppdataset.Tables[0].Rows[0].RO_hr=="null")
	        {
	            document.getElementById('txthr').value="";
	        }
	        else
	        {
		        document.getElementById('txthr').value=suppdataset.Tables[0].Rows[0].RO_hr;
		    }
		    
		    if(suppdataset.Tables[0].Rows[0].RO_min==null||suppdataset.Tables[0].Rows[0].RO_min=="null")
	        {
	            document.getElementById('txtmin').value="";
	        }
	        else
	        {
		        document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[0].RO_min;
		    }
		    
		     if(suppdataset.Tables[0].Rows[0].Production==null||suppdataset.Tables[0].Rows[0].Production=="null")
	        {
	            document.getElementById('txtproduction').value="";
	        }
	        else
	        {
		        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[0].Production;
		    }
	  
	  
	  
	  
	  
editionvar=suppdataset.Tables[0].Rows[0].Edition_Code;
addcount(suppdataset.Tables[0].Rows[0].Pub_Code);
	var akh=document.getElementById('txtSuppCode').value
fillcheckboxes(akh);
updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
        document.getElementById('btnlast').disabled=false;	
        setButtonImages();
}



function ClickNext()
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.blankSession();
var PubName=document.getElementById('drpPubName').value;
var EditonName=document.getElementById('drEditonName').value;
var SuppName=document.getElementById('txtSuppName').value;
var Alias=document.getElementById('txtAlias').value;
var SuppCode = document.getElementById('txtSuppCode').value;

var SHORTNAME = document.getElementById('txtshortname').value;


var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
SupplimentMaster.Selectfnpl(PubName, EditonName, SuppName, Alias, SuppCode, compcode, userid, SHORTNAME,call_Next);
return false;
}

function call_Next(response)
{
	z++;
	//var ds=response.value;
	
	var x=suppdataset.Tables[0].Rows.length;
	
	if(z <= x && z >= 0)

	{
		if(suppdataset.Tables[0].Rows.length != z && z !=-1)
		
		{
		document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[z].Pub_Code;
		//document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[z].Edition_Code
		document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[z].Supp_Name;

		
		    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[z].SUPP_URL;
	
		
		document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[z].Supp_Alias;
		document.getElementById('txtSuppCode').value=suppdataset.Tables[0].Rows[z].Supp_Code;
		document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[z].Comp_Code;
		//document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[z].UserId;
		document.getElementById('druom').value=suppdataset.Tables[0].Rows[z].UOM_Code;
		document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[z].No_Of_Columns;
		document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[z].Size_Height;
		document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[z].Size_Width;
		document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[z].Supp_Area;
		  document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[z].Preodicity_Code;
		  document.getElementById('drsupptyp').value = suppdataset.Tables[0].Rows[z].supptypcode;
		  if (suppdataset.Tables[0].Rows[z].SHORT_NAME != null)

		      document.getElementById('txtshortname').value = suppdataset.Tables[0].Rows[z].SHORT_NAME;
		  else
		      document.getElementById('txtshortname').value = "";
	        
		
		
		
		
		
		
		if(suppdataset.Tables[0].Rows[z].Gutter_Space==null||suppdataset.Tables[0].Rows[z].Gutter_Space=="null")
	        {
	            document.getElementById('txtgutter').value="";
	        }
	        else
	        {
	            document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[z].Gutter_Space;
	        }
	        if(suppdataset.Tables[0].Rows[z].Column_Space==null||suppdataset.Tables[0].Rows[z].Column_Space=="null")
	        {
	            document.getElementById('txtcol').value="";
	        }
	        else
	        {
		        document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[z].Column_Space;
		    }
		    
		    if(suppdataset.Tables[0].Rows[z].RO_hr==null||suppdataset.Tables[0].Rows[z].RO_hr=="null")
	        {
	            document.getElementById('txthr').value="";
	            //document.getElementById('hidro').value="";
	        }
	        else
	        {
		        document.getElementById('txthr').value=suppdataset.Tables[0].Rows[z].RO_hr;
		        //document.getElementById('hidro').value=suppdataset.Tables[0].Rows[z].RO_hr;
		    }
		    
		    if(suppdataset.Tables[0].Rows[z].RO_min==null||suppdataset.Tables[0].Rows[z].RO_min=="null")
	        {
	            document.getElementById('txtmin').value="";
	        }
	        else
	        {
		        document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[z].RO_min;
		    }
		    
		     if(suppdataset.Tables[0].Rows[z].Production==null||suppdataset.Tables[0].Rows[z].Production=="null")
	        {
	            document.getElementById('txtproduction').value="";
	        }
	        else
	        {
		        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[z].Production;
		    }
		
		
		
		
//		
//		
//		
//		
//			        document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[z].gutter_space;
//		    document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[z].column_space;
//		    document.getElementById('txthr').value=suppdataset.Tables[0].Rows[z].ro_hr;
//		    document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[z].ro_min;
//	        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[z].production;
		
		
		
		
    	
	    editionvar=suppdataset.Tables[0].Rows[z].Edition_Code;
		addcount(suppdataset.Tables[0].Rows[z].Pub_Code);
		var akh=document.getElementById('txtSuppCode').value;
		fillcheckboxes(akh);
		updateStatus();
//document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=false;			
		document.getElementById('btnlast').disabled=false;
		
	} 
	else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		}
		else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		if(z==x-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		setButtonImages();
		return false;
}



function ClickPrevious()
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.blankSession();
var PubName=document.getElementById('drpPubName').value;
var EditonName=document.getElementById('drEditonName').value;
var SuppName=document.getElementById('txtSuppName').value;
var Alias=document.getElementById('txtAlias').value;
var SuppCode=document.getElementById('txtSuppCode').value;
var SHORTNAME = document.getElementById('txtshortname').value;	

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
SupplimentMaster.Selectfnpl(PubName, EditonName, SuppName, Alias, SuppCode, compcode, userid, SHORTNAME,call_Previous);
return false;
}




function call_Previous(response)
{
	z--;
	//ds=response.value;
	
	var x=suppdataset.Tables[0].Rows.length;
	
	

			if(z>x)
			{
						document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						setButtonImages();
						return false;
			}
			
			
			
			if(z!=-1 && z>=0)
					{
						if(suppdataset.Tables[0].Rows.length != z)
							{
									document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[z].Pub_Code;
									document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[z].Edition_Code
									document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[z].Supp_Name;
									
									    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[z].SUPP_URL;
									
									document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[z].Supp_Alias;
									document.getElementById('txtSuppCode').value=suppdataset.Tables[0].Rows[z].Supp_Code;
									document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[z].Comp_Code;
									//document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[z].UserId;
									document.getElementById('druom').value=suppdataset.Tables[0].Rows[z].UOM_Code;
		                            document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[z].No_Of_Columns;
		                            document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[z].Size_Height;
		                            document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[z].Size_Width;
		                            document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[z].Supp_Area;
		                              document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[z].Preodicity_Code;
		                              document.getElementById('drsupptyp').value = suppdataset.Tables[0].Rows[z].supptypcode;
		                              if (suppdataset.Tables[0].Rows[z].SHORT_NAME != null)
		                                  document.getElementById('txtshortname').value = suppdataset.Tables[0].Rows[z].SHORT_NAME;
		                              else
		                                  document.getElementById('txtshortname').value = "";
		
		
		
		
		
		
		
		if(suppdataset.Tables[0].Rows[z].Gutter_Space==null||suppdataset.Tables[0].Rows[z].Gutter_Space=="null")
	        {
	            document.getElementById('txtgutter').value="";
	        }
	        else
	        {
	            document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[z].Gutter_Space;
	        }
	        if(suppdataset.Tables[0].Rows[z].Column_Space==null||suppdataset.Tables[0].Rows[z].Column_Space=="null")
	        {
	            document.getElementById('txtcol').value="";
	        }
	        else
	        {
		        document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[z].Column_Space;
		    }
		    
		    if(suppdataset.Tables[0].Rows[z].RO_hr==null||suppdataset.Tables[0].Rows[z].RO_hr=="null")
	        {
	            document.getElementById('txthr').value="";
	            //document.getElementById('hidro').value="";
	        }
	        else
	        {
		        document.getElementById('txthr').value=suppdataset.Tables[0].Rows[z].RO_hr;
		        //document.getElementById('hidro').value=suppdataset.Tables[0].Rows[z].RO_hr;
		    }
		    
		    if(suppdataset.Tables[0].Rows[z].RO_min==null||suppdataset.Tables[0].Rows[z].RO_min=="null")
	        {
	            document.getElementById('txtmin').value="";
	        }
	        else
	        {
		        document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[z].RO_min;
		    }
		    
		     if(suppdataset.Tables[0].Rows[z].Production==null||suppdataset.Tables[0].Rows[z].Production=="null")
	        {
	            document.getElementById('txtproduction').value="";
	        }
	        else
	        {
		        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[z].Production;
		    }
		
		
		
		
		
		
		
//		document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[z].gutter_space;
//		    document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[z].column_space;
//		    document.getElementById('txthr').value=suppdataset.Tables[0].Rows[z].ro_hr;
//		    document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[z].ro_min;
//	        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[z].production;
		
		
		
		
                            	
									editionvar=suppdataset.Tables[0].Rows[z].Edition_Code;
									addcount(suppdataset.Tables[0].Rows[z].Pub_Code);
									var akh=document.getElementById('txtSuppCode').value;
								fillcheckboxes(akh);
									updateStatus();
									document.getElementById('btnfirst').disabled=false;				
									document.getElementById('btnnext').disabled=false;					
									document.getElementById('btnprevious').disabled=false;			
									document.getElementById('btnlast').disabled=false;
									
							}
							else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
			
			
					}	
					else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
					
					if (z<=0)
	{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			setButtonImages();
			return false;		
	}
	setButtonImages();
	return false;
}



function ClickLast()
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.blankSession();
var PubName=document.getElementById('drpPubName').value;
var EditonName=document.getElementById('drEditonName').value;
var SuppName=document.getElementById('txtSuppName').value;
var Alias=document.getElementById('txtAlias').value;
var SuppCode = document.getElementById('txtSuppCode').value;
var SHORTNAME = document.getElementById('txtshortname').value;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
SupplimentMaster.Selectfnpl(PubName, EditonName, SuppName, Alias, SuppCode, compcode, userid, SHORTNAME,call_Last);
return false;
}

function call_Last(response)
{
//ds= response.value;
				var x=suppdataset.Tables[0].Rows.length;
				//z=x-1;
				
				x=x-1;
				z=x;
									document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[x].Pub_Code;
									//document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[x].Edition_Code
									document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[x].Supp_Name;
									
									    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[x].SUPP_URL;
							
									document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[x].Supp_Alias;
									document.getElementById('txtSuppCode').value=suppdataset.Tables[0].Rows[x].Supp_Code;
									document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[x].Comp_Code;
									//document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[x].UserId;
								   	document.getElementById('druom').value=suppdataset.Tables[0].Rows[x].UOM_Code;
		                                document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[x].No_Of_Columns;
		                                document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[x].Size_Height;
		                                document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[x].Size_Width;
		                                document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[x].Supp_Area;
		                                  document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[x].Preodicity_Code;
		                                  document.getElementById('drsupptyp').value = suppdataset.Tables[0].Rows[x].supptypcode;
		                                  if( suppdataset.Tables[0].Rows[x].SHORT_NAME !=null)
		                                  
	                                         document.getElementById('txtshortname').value = suppdataset.Tables[0].Rows[x].SHORT_NAME ;
	                                         else
	                                          document.getElementById('txtshortname').value ="";
	                                         
		
		
		
		
		
		if(suppdataset.Tables[0].Rows[x].Gutter_Space==null||suppdataset.Tables[0].Rows[x].Gutter_Space=="null")
	        {
	            document.getElementById('txtgutter').value="";
	        }
	        else
	        {
	            document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[x].Gutter_Space;
	        }
	        if(suppdataset.Tables[0].Rows[x].Column_Space==null||suppdataset.Tables[0].Rows[x].Column_Space=="null")
	        {
	            document.getElementById('txtcol').value="";
	        }
	        else
	        {
		        document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[x].Column_Space;
		    }
		    
		    if(suppdataset.Tables[0].Rows[x].RO_hr==null||suppdataset.Tables[0].Rows[x].RO_hr=="null")
	        {
	            document.getElementById('txthr').value="";
	            //document.getElementById('hidro').value="";
	        }
	        else
	        {
		        document.getElementById('txthr').value=suppdataset.Tables[0].Rows[x].RO_hr;
		        //document.getElementById('hidro').value=suppdataset.Tables[0].Rows[x].RO_hr;
		    }
		    
		    if(suppdataset.Tables[0].Rows[x].RO_min==null||suppdataset.Tables[0].Rows[x].RO_min=="null")
	        {
	            document.getElementById('txtmin').value="";
	        }
	        else
	        {
		        document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[x].RO_min;
		    }
		    
		     if(suppdataset.Tables[0].Rows[x].Production==null||suppdataset.Tables[0].Rows[x].Production=="null")
	        {
	            document.getElementById('txtproduction').value="";
	        }
	        else
	        {
		        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[x].Production;
		    }
		
			
		
		
//		document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[x].gutter_space;
//		    document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[x].column_space;
//		    document.getElementById('txthr').value=suppdataset.Tables[0].Rows[x].ro_hr;
//		    document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[x].ro_min;
//	        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[x].production;
		
		
		
		
		
                                	 
        								  editionvar=suppdataset.Tables[0].Rows[x].Edition_Code;
									addcount(suppdataset.Tables[0].Rows[x].Pub_Code);
		                            var akh=document.getElementById('txtSuppCode').value;
									fillcheckboxes(akh);
									updateStatus();
						//document.getElementById('btnlast').disabled=true;
			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;

setButtonImages();

return false;
}


	function disablecheck()
		{

		document.getElementById('CheckBox1').disabled=true;
		document.getElementById('CheckBox2').disabled=true;
		document.getElementById('CheckBox3').disabled=true;
		document.getElementById('CheckBox4').disabled=true;
		document.getElementById('CheckBox5').disabled=true;
		document.getElementById('CheckBox6').disabled=true;
		document.getElementById('CheckBox7').disabled=true;
		document.getElementById('CheckBox8').disabled=true;
		//getPermission('SupplimentMaster');
		givebuttonpermission('SupplimentMaster');

		return false;

		}

function ClickExit()
{

if(confirm("Do You Want To Skip This Page"))
		{
		if(popwin && !popwin.closed)
		    {
    		
		    popwin.close();
	}

		window.close();
		return false;
		}
		return false;
}



function selectedtionday(response)
{
var compcode=document.getElementById('hiddencompcode11').value;
var suppcode=document.getElementById('txtSuppCode').value;
var userid=document.getElementById('hiddenuserid').value;
/*******************/
var pubcode=document.getElementById('drpPubName').value;
var editioncode=document.getElementById('drEditonName').value;
/************/
SupplimentMaster.checkedtioncode1(compcode,suppcode,userid,pubcode,editioncode,pubcodever);
return false;

}


function pubcodever(response)
{
var ds=response.value;
var chk1;
var chk2;
var chk3;
var chk4;
var chk5;
var chk6;
var chk7;
var chk8;
var compcode=document.getElementById('hiddencompcode11').value;
var suppcode = document.getElementById('hdnsuppcode').value;
var userid=document.getElementById('hiddenuserid').value;
/*if(document.getElementById('CheckBox1').checked==true)
{
chk1="Y";
}
else
{
chk1="N";
}
if(document.getElementById('CheckBox2').checked==true)
{
chk2="Y";
}
else
{
chk2="N";
}
if(document.getElementById('CheckBox3').checked==true)
{
chk3="Y";
}
else
{
chk3="N";
}
if(document.getElementById('CheckBox4').checked==true)
{
chk4="Y";
}
else
{
chk4="N";
}
if(document.getElementById('CheckBox5').checked==true)
{
chk5="Y";
}
else
{
chk5="N";
}
if(document.getElementById('CheckBox6').checked==true)
{
chk6="Y";
}
else
{
chk6="N";
}
if(document.getElementById('CheckBox7').checked==true)
{
chk7="Y";
}
else
{
chk7="N";
}
if(document.getElementById('CheckBox8').checked==true)
{


 if(document.getElementById('CheckBox1').disabled==false  && document.getElementById('CheckBox1').checked==true )
        {
        chk1="Y";
         }
        if(document.getElementById('CheckBox2').disabled==false)
        {
        chk2="Y";
        //document.getElementById('CheckBox2').checked=true;
        }
        if(document.getElementById('CheckBox3').disabled==false)
        {
        chk3="Y";
          }
        if(document.getElementById('CheckBox4').disabled==false)
        {
        chk4="Y";
        //document.getElementById('CheckBox4').checked=true;
        }
        if(document.getElementById('CheckBox5').disabled==false)
        {
       chk5="Y";
        }
        if(document.getElementById('CheckBox6').disabled==false)
        {
        chk6="Y";
        //document.getElementById('CheckBox6').checked=true;
        }
        if(document.getElementById('CheckBox7').disabled==false)
        {
        chk7="Y";
        //document.getElementById('CheckBox7').checked=true;
        }
chk8="Y";

}
else
{
chk8="N";
}*/

if(document.getElementById('CheckBox1').checked==true)
{
chk1="Y";
}
else
{
chk1="N";
}
if(document.getElementById('CheckBox2').checked==true)
{
chk2="Y";
}
else
{
chk2="N";
}
if(document.getElementById('CheckBox3').checked==true)
{
chk3="Y";
}
else
{
chk3="N";
}
if(document.getElementById('CheckBox4').checked==true)
{
chk4="Y";
}
else
{
chk4="N";
}
if(document.getElementById('CheckBox5').checked==true)
{
chk5="Y";
}
else
{
chk5="N";
}
if(document.getElementById('CheckBox6').checked==true)
{
chk6="Y";
}
else
{
chk6="N";
}
if(document.getElementById('CheckBox7').checked==true)
{
chk7="Y";
}
else
{
chk7="N";
}
if(document.getElementById('CheckBox8').checked==true)
{

chk8="Y";
if(document.getElementById('CheckBox1').disabled==false)
{
chk1="Y";
}
if(document.getElementById('CheckBox2').disabled=false)
{
chk2="Y";
}
if(document.getElementById('CheckBox3').disabled==false)
{
chk3="Y";
}
if(document.getElementById('CheckBox4').disabled==false)
{
chk4="Y";
}
if (document.getElementById('CheckBox5').disabled==false)
{
chk5="Y";
}
if (document.getElementById('CheckBox6').disabled==false)
{
chk6="Y";
}
if (document.getElementById('CheckBox7').disabled==false)
{
chk7="Y";
}
chk8="Y";
}
else
{
chk8="N";
}

if(ds.Tables[0].Rows.length>0)
{
    SupplimentMaster.edtiondaymodify1(compcode, suppcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
    document.getElementById('hdnsuppcode').value = "";
    document.getElementById('CheckBox1').disabled = true;
    document.getElementById('CheckBox2').disabled = true;
    document.getElementById('CheckBox3').disabled = true;
    document.getElementById('CheckBox4').disabled = true;
    document.getElementById('CheckBox5').disabled = true;
    document.getElementById('CheckBox6').disabled = true;
    document.getElementById('CheckBox7').disabled = true;
    document.getElementById('CheckBox8').disabled = true;

    document.getElementById('CheckBox1').checked = false;
    document.getElementById('CheckBox2').checked = false;
    document.getElementById('CheckBox3').checked = false;
    document.getElementById('CheckBox4').checked = false;
    document.getElementById('CheckBox5').checked = false;
    document.getElementById('CheckBox6').checked = false;
    document.getElementById('CheckBox7').checked = false;
    document.getElementById('CheckBox8').checked = false;
return false;
}
else
{
//alert("bhanu")
    SupplimentMaster.editionpubdaysave1(compcode, suppcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
    document.getElementById('hdnsuppcode').value = "";
    document.getElementById('CheckBox1').disabled = true;
    document.getElementById('CheckBox2').disabled = true;
    document.getElementById('CheckBox3').disabled = true;
    document.getElementById('CheckBox4').disabled = true;
    document.getElementById('CheckBox5').disabled = true;
    document.getElementById('CheckBox6').disabled = true;
    document.getElementById('CheckBox7').disabled = true;
    document.getElementById('CheckBox8').disabled = true;

    document.getElementById('CheckBox1').checked = false;
    document.getElementById('CheckBox2').checked = false;
    document.getElementById('CheckBox3').checked = false;
    document.getElementById('CheckBox4').checked = false;
    document.getElementById('CheckBox5').checked = false;
    document.getElementById('CheckBox6').checked = false;
    document.getElementById('CheckBox7').checked = false;
    document.getElementById('CheckBox8').checked = false;
return false;
}
return false;
}




function fillcheckboxes(response)
{
var compcode=document.getElementById('hiddencompcode11').value;
var suppcode=document.getElementById('txtSuppCode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubcode=document.getElementById('drpPubName').value;
var editioncode=document.getElementById('drEditonName').value;
SupplimentMaster.checkedtioncode1(compcode,suppcode,userid,pubcode,editioncode,fillcheck);
return false;
}




function fillcheck(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length>0)
{
var sun=ds.Tables[0].Rows[0].sun;
var mon=ds.Tables[0].Rows[0].mon;
var tue=ds.Tables[0].Rows[0].tue;
var wed=ds.Tables[0].Rows[0].wed;
var thu=ds.Tables[0].Rows[0].thu;
var fri=ds.Tables[0].Rows[0].fri;
var sat=ds.Tables[0].Rows[0].sat;
var all=ds.Tables[0].Rows[0].all;
if(sun=="Y")
    {
    document.getElementById('CheckBox1').checked=true;
    }
else
    {
    document.getElementById('CheckBox1').checked=false;
    }

if(mon=="Y")
    {
    document.getElementById('CheckBox2').checked=true;
    }
else
    {
    document.getElementById('CheckBox2').checked=false;
    }
if(tue=="Y")
    {
    document.getElementById('CheckBox3').checked=true;
    }
else
    {
    document.getElementById('CheckBox3').checked=false;
    }
if(wed=="Y")
    {
    document.getElementById('CheckBox4').checked=true;
    }
else
    {
    document.getElementById('CheckBox4').checked=false;
    }
if(thu=="Y")
    {
    document.getElementById('CheckBox5').checked=true;
    }
else
    {
    document.getElementById('CheckBox5').checked=false;
    }
if(fri=="Y")
    {
    document.getElementById('CheckBox6').checked=true;
    }
else
    {
    document.getElementById('CheckBox6').checked=false;
    }
if(sat=="Y")
    {
    document.getElementById('CheckBox7').checked=true;
    }
else
    {
    document.getElementById('CheckBox7').checked=false;
    }
if(all=="Y")
    {
      document.getElementById('CheckBox8').checked=true;
    }
else
    {
    document.getElementById('CheckBox8').checked=false;
    }
}

else
    {
    document.getElementById('CheckBox1').checked=false;
    document.getElementById('CheckBox2').checked=false;
    document.getElementById('CheckBox3').checked=false;
    document.getElementById('CheckBox4').checked=false;
    document.getElementById('CheckBox5').checked=false;
    document.getElementById('CheckBox6').checked=false;
    document.getElementById('CheckBox7').checked=false;
    }
}





/*if(sun=="Y")
{
document.getElementById('CheckBox1').checked=true;
}
else
{
document.getElementById('CheckBox1').checked=false;
}

if(mon=="Y")
{
document.getElementById('CheckBox2').checked=true;
}
else
{
document.getElementById('CheckBox2').checked=false;
}
if(tue=="Y")
{
document.getElementById('CheckBox3').checked=true;
}
else
{
document.getElementById('CheckBox3').checked=false;
}
if(wed=="Y")
{
document.getElementById('CheckBox4').checked=true;
}
else
{
document.getElementById('CheckBox4').checked=false;
}
if(thu=="Y")
{
document.getElementById('CheckBox5').checked=true;
}
else
{
document.getElementById('CheckBox5').checked=false;
}
if(fri=="Y")
{
document.getElementById('CheckBox6').checked=true;
}
else
{
document.getElementById('CheckBox6').checked=false;
}
if(sat=="Y")
{
document.getElementById('CheckBox7').checked=true;
}
else
{
document.getElementById('CheckBox7').checked=false;
}
if(all=="Y")
{
document.getElementById('CheckBox1').checked=true;
document.getElementById('CheckBox2').checked=true;
document.getElementById('CheckBox3').checked=true;
document.getElementById('CheckBox4').checked=true;
document.getElementById('CheckBox5').checked=true;
document.getElementById('CheckBox6').checked=true;
document.getElementById('CheckBox7').checked=true;
document.getElementById('CheckBox8').checked=false;
}
else
{
document.getElementById('CheckBox8').checked=false;
}
}

else
{
document.getElementById('CheckBox1').checked=false;
document.getElementById('CheckBox2').checked=false;
document.getElementById('CheckBox3').checked=false;
document.getElementById('CheckBox4').checked=false;
document.getElementById('CheckBox5').checked=false;
document.getElementById('CheckBox6').checked=false;
document.getElementById('CheckBox7').checked=false;
}
}*/

function FillEditonInPub()
{
var edit= document.getElementById('drpPubName').value
SupplimentMaster.addSub(edit);
}


//************This function is used to check all checkboxes if all is clicked************//
function checkedunchecked(q)
{
	var status = document.getElementById('CheckBox8').checked;
	

if(status==true)
    {
    
    document.getElementById('CheckBox8').checked=true;
  
        
   
        if(document.getElementById('CheckBox1').disabled==false)
        
        {
        document.getElementById('CheckBox1').checked=true;
        }
        if(document.getElementById('CheckBox2').disabled==false)
        {
        document.getElementById('CheckBox2').checked=true;
        }
        if(document.getElementById('CheckBox3').disabled==false)
        {
        document.getElementById('CheckBox3').checked=true;
        }
        if(document.getElementById('CheckBox4').disabled==false)
        {
        document.getElementById('CheckBox4').checked=true;
        }
        if(document.getElementById('CheckBox5').disabled==false)
        {
        document.getElementById('CheckBox5').checked=true;
        }
        if(document.getElementById('CheckBox6').disabled==false)
        {
        document.getElementById('CheckBox6').checked=true;
        }
        if(document.getElementById('CheckBox7').disabled==false)
        {
        document.getElementById('CheckBox7').checked=true;
        }
         document.getElementById('CheckBox8').checked=true;
        return ;
        
    }
   else
    {
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;
		return ;
		}
		return ;

	
}


function ClickDelete()
{

var compcode=document.getElementById('hiddencompcode11').value;
var suppcode=document.getElementById('txtSuppCode').value;
var userid=document.getElementById('hiddenuserid').value;
/*******************/
var pubcode=document.getElementById('drpPubName').value;
var editioncode=document.getElementById('drEditonName').value;
/************/
        if(confirm("Are You Sure To Delete The Data ?"))
					{
					////SupplimentMaster.delsup(suppcode,compcode,userid);
					//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
       var ip2=document.getElementById('ip1').value;
SupplimentMaster.delsup(suppcode,compcode,userid,pubcode,editioncode,ip2);
						if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
					//alert(xmlObj.childNodes(0).childNodes(2).text);
					//alert("date deleted");
					SupplimentMaster.Select(glpubname,gleditionname,glsuppname,glalias,glsuppcode,compcode,userid,gbuom,gbcolumn,gbheight,gbwidth,gbarea,gbperiodicty,gbsupptyp,gbgut,gbcol,gbhr,gbmin,gbpro,filldel);
                   // SupplimentMaster.Select(glpubname,gleditionname,glsuppname,glalias,glsuppcode,compcode,userid,gbuom,gbcolumn,gbheight,gbwidth,gbarea,filldel);
				    
				    return false;
					}
					else
		            {
			            return false;
		            }
return false;
}


function filldel(res)
{

suppdataset=res.value;
//var ds=res.value;
var a=suppdataset.Tables[0].Rows.length;
var y=a-1;
if( a==0)
	{
	alert("There Is No Data In The Database");
		document.getElementById('drpPubName').value="0";
		document.getElementById('drEditonName').value="0";
		document.getElementById('txtSuppName').value = "";
		document.getElementById('txtepr').value = "";
		document.getElementById('txtAlias').value="";
		document.getElementById('txtSuppCode').value="";
		document.getElementById('druom').value="0";
		document.getElementById('txtcolumn').value="";
		document.getElementById('txtsizeheight').value="";
		document.getElementById('txtsizewidth').value="";
		document.getElementById('txtarea').value="";
		
		
		
	

		document.getElementById('CheckBox1').disabled=true;
		document.getElementById('CheckBox2').disabled=true;
		document.getElementById('CheckBox3').disabled=true;
		document.getElementById('CheckBox4').disabled=true;
		document.getElementById('CheckBox5').disabled=true;
		document.getElementById('CheckBox6').disabled=true;
		document.getElementById('CheckBox7').disabled=true;
		document.getElementById('CheckBox8').disabled=true;

		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;
		
		ClickCancel('SupplimentMaster');
		return false;
	}
	
	else if(z==-1 ||z>=a)
	{
	document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[0].Pub_Code;
	//document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[0].Edition_Code
	document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[0].Supp_Name;


	    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[0].SUPP_URL;

	document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[0].Supp_Alias;
	document.getElementById('txtSuppCode').value=suppdataset.Tables[0].Rows[0].Supp_Code;
	document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[0].Comp_Code;
	//document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[0].UserId;
	document.getElementById('druom').value=suppdataset.Tables[0].Rows[0].UOM_Code;
	document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[0].No_Of_Columns;
	document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[0].Size_Height;
	document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[0].Size_Width;
	document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[0].Supp_Area;
	  document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[0].Preodicity_Code;
	      document.getElementById('drsupptyp').value=suppdataset.Tables[0].Rows[0].supptypcode;;
		
		
		document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[0].gutter_space;
		    document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[0].column_space;
		    document.getElementById('txthr').value=suppdataset.Tables[0].Rows[0].ro_hr;
		    /***********/
		    //document.getElementById('hidro').value=suppdataset.Tables[0].Rows[0].ro_hr;
		    /**********/
		    document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[0].ro_min;
	        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[0].production;
		
		
	  
	editionvar=suppdataset.Tables[0].Rows[0].Edition_Code;
	addcount(suppdataset.Tables[0].Rows[0].Pub_Code);
	
	return false;
	}
	
	else
	{
		document.getElementById('drpPubName').value=suppdataset.Tables[0].Rows[z].Pub_Code;
		//document.getElementById('drEditonName').value=suppdataset.Tables[0].Rows[z].Edition_Code
		document.getElementById('txtSuppName').value = suppdataset.Tables[0].Rows[z].Supp_Name;

		
		    document.getElementById('txtepr').value = suppdataset.Tables[0].Rows[z].SUPP_URL;
	
		document.getElementById('txtAlias').value=suppdataset.Tables[0].Rows[z].Supp_Alias;
		document.getElementById('txtSuppCode').value=suppdataset.Tables[0].Rows[z].Supp_Code;
		document.getElementById('hiddencompcode').value=suppdataset.Tables[0].Rows[z].Comp_Code;
//		document.getElementById('hiddenuserid').value=suppdataset.Tables[0].Rows[z].UserId;
		document.getElementById('druom').value=suppdataset.Tables[0].Rows[z].UOM_Code;
		document.getElementById('txtcolumn').value=suppdataset.Tables[0].Rows[z].No_Of_Columns;
		document.getElementById('txtsizeheight').value=suppdataset.Tables[0].Rows[z].Size_Height;
		document.getElementById('txtsizewidth').value=suppdataset.Tables[0].Rows[z].Size_Width;
		document.getElementById('txtarea').value=suppdataset.Tables[0].Rows[z].Supp_Area;
		document.getElementById('drperiodicity').value=suppdataset.Tables[0].Rows[z].Preodicity_Code;
		document.getElementById('drsupptyp').value=suppdataset.Tables[0].Rows[z].supptypcode;
		
		
		
		if(suppdataset.Tables[0].Rows[z].Gutter_Space==null||suppdataset.Tables[0].Rows[z].Gutter_Space=="null")
	        {
	            document.getElementById('txtgutter').value="";
	        }
	        else
	        {
	            document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[z].Gutter_Space;
	        }
	        if(suppdataset.Tables[0].Rows[z].Column_Space==null||suppdataset.Tables[0].Rows[z].Column_Space=="null")
	        {
	            document.getElementById('txtcol').value="";
	        }
	        else
	        {
		        document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[z].Column_Space;
		    }
		    
		    if(suppdataset.Tables[0].Rows[z].RO_hr==null||suppdataset.Tables[0].Rows[z].RO_hr=="null")
	        {
	            document.getElementById('txthr').value="";
	            //document.getElementById('hidro').value="";
	        }
	        else
	        {
		        document.getElementById('txthr').value=suppdataset.Tables[0].Rows[z].RO_hr;
		        //document.getElementById('hidro').value=suppdataset.Tables[0].Rows[x].RO_hr;
		    }
		    
		    if(suppdataset.Tables[0].Rows[z].RO_min==null||suppdataset.Tables[0].Rows[z].RO_min=="null")
	        {
	            document.getElementById('txtmin').value="";
	        }
	        else
	        {
		        document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[z].RO_min;
		    }
		    
		     if(suppdataset.Tables[0].Rows[z].Production==null||suppdataset.Tables[0].Rows[z].Production=="null")
	        {
	            document.getElementById('txtproduction').value="";
	        }
	        else
	        {
		        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[z].Production;
		    }
		
		
		
		
	
//	document.getElementById('txtgutter').value=suppdataset.Tables[0].Rows[z].gutter_space;
//		    document.getElementById('txtcol').value=suppdataset.Tables[0].Rows[z].column_space;
//		    document.getElementById('txthr').value=suppdataset.Tables[0].Rows[z].ro_hr;
//		    document.getElementById('txtmin').value=suppdataset.Tables[0].Rows[z].ro_min;
//	        document.getElementById('txtproduction').value=suppdataset.Tables[0].Rows[z].production;
//	
	 
		editionvar=suppdataset.Tables[0].Rows[z].Edition_Code;
		addcount(suppdataset.Tables[0].Rows[z].Pub_Code);
		
	return false;
	}



return false;
}


function autoornot()
 {
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    return false;
    }
    
else
    {
    userdefine();
    if(hiddentext=="new")
    {
    fillalias();
    }
    return false;
    }
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
			{
	
            uppercase3();
           
           }
           
  else if (hiddentext=="modify")
               {
                 str=document.getElementById('drEditonName').value;
                 strpub=document.getElementById('drpPubName').value;
//                 fillalias();            
             //  EditorMaster.editmaster(str,strpub,strcity,fillcall_modify);
            		   		     
               }
            else
            {
            document.getElementById('txtSuppName').value=document.getElementById('txtSuppName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		 document.getElementById('txtSuppName').value=document.getElementById('txtSuppName').value.toUpperCase();
        document.getElementById('txtSuppName').value=trim(document.getElementById('txtSuppName').value);
         lstr=document.getElementById('txtSuppName').value;
            cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
	
                
		    if((document.getElementById('txtSuppName').value!="")&&(document.getElementById('drEditonName').value!="0"))
                {
                
              // document.getElementById('txtSuppName').value=document.getElementById('txtSuppName').value.toUpperCase();
	           // document.getElementById('txtAlias').value=document.getElementById('txtSuppName').value;
		       // str=document.getElementById('txtSuppName').value;
		       str=mstr;
		        editstr=document.getElementById('drEditonName').value;
		        pubeditstr=document.getElementById('drpPubName').value;
		        SupplimentMaster.chkcsupcode(str,editstr,pubeditstr,fillcall)
		        
		        return false;
                }
		     return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		   if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Suppliment name has already assigned in this Edition !! ");
		    document.getElementById('txtSuppName').focus();
    		
		    return false;
		    }
		
		        else
		         {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Supp_Code;
		                        }
		                    if(newstr !=null )
		                        {
   							var code=newstr;
		                     //var code=newstr.substr(2,4);
		                     str=str.toUpperCase();
		                        code++;
		                        document.getElementById('txtSuppCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                           str=str.toUpperCase();
		                          document.getElementById('txtSuppCode').value=str.substr(0,2)+ "0";
		                           
		                          }
		                         fillalias();
		          // document.getElementById('txtcolumn').focus();         
		           return false;     
		    }
		    
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtSuppCode').disabled=false;
        document.getElementById('txtSuppName').value=document.getElementById('txtSuppName').value.toUpperCase();
        //document.getElementById('txtAlias').value=document.getElementById('txtSuppName').value;
        auto=document.getElementById('hiddenauto').value;
         var EditonName=document.getElementById('drEditonName').value;
		var PubName=document.getElementById('drpPubName').value;
		 var SuppName=document.getElementById('txtSuppName').value;
		var  SuppCode=document.getElementById('txtSuppCode').value;
		 var Alias=document.getElementById('txtAlias').value;
		   var compcode=document.getElementById('hiddencompcode').value;
	        var userid=document.getElementById('hiddenuserid').value;
          SupplimentMaster.chkid(SuppName,SuppCode,Alias,compcode,userid,PubName,EditonName,calluserdef);
         return false;
        }

return false;
}



function calluserdef(res)
{
  var ds=res.value;
    if(ds.Tables[1].Rows.length > 0)
    {
        alert("This Name already in use!!  please try another name ! ");
        document.getElementById('txtSuppName').value="";
        return false;
    }
   
   else  if(ds.Tables[0].Rows.length > 0)
    {
       alert("This Code already in use!!  please try another code ! ");
       document.getElementById('txtSuppCode').value="";
       document.getElementById('txtSuppCode').focus();
       
        return false;
    }
//    else if(ds.Tables[2].Rows.length > 0)
//    {
//        alert("This Alias already in use!!  please try another  Suppname ! ");
//        return false;
//    }
}











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

////////////////////////////////////////////////////////////////////////////////////////////////




function addeditionname()
{
var publi=document.getElementById('drpPubName').value;
SupplimentMaster.addedi(publi,callcount);

return false;
}

function callcount(res)
{

var ds=res.value;

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

var pkgitem = document.getElementById("ListBox1");
//alert(pkgitem);
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("--Select Edition Name--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; i++)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].edition_name,res.value.Tables[0].Rows[i].city_code);
        
       pkgitem.options.length;
       
    }
    //alert(cityvar);
// if(cityvar == undefined || cityvar=="")
// {
//  document.getElementById('ListBox1').value="0";
// 
// }
// else
// {
//  document.getElementById('ListBox1').value=cityvar;
//  cityvar="";
//  } 
}
else
{
alert("There is No Matching Value Found");
return false;

}
//addcityname();
return false;
}
///////////check box visibility on the basic of publication print///////////////
 function chkboxvisibil()
 {
   var chkbox=document.getElementById('drpPubName').value;
   var compcode=document.getElementById('hiddencompcode').value;
   var userid=document.getElementById('hiddenuserid').value;
SupplimentMaster.addchkvisibil(chkbox,compcode,userid,callcount1);
return false;
 
 }
 
 
 function  callcount1(res)
 {
 
 var ds=res.value;
if(ds.Tables[0].Rows.length>0)
{
 var sun=ds.Tables[0].Rows[0].sun;
 var mon=ds.Tables[0].Rows[0].mon;
 var tue=ds.Tables[0].Rows[0].tue;
 var wed=ds.Tables[0].Rows[0].wed;
 var thu=ds.Tables[0].Rows[0].thu;
 var fri=ds.Tables[0].Rows[0].fri;
 var sat=ds.Tables[0].Rows[0].sat;
 var all=ds.Tables[0].Rows[0].all;

if(sun=="Y")
{
document.getElementById('CheckBox1').disabled=false;
}
else
{
document.getElementById('CheckBox1').disabled=true;
}

if(mon=="Y")
{
document.getElementById('CheckBox2').disabled=false;
}
else
{
document.getElementById('CheckBox2').disabled=true;
}

if(tue=="Y")
{
document.getElementById('CheckBox3').disabled=false;
}
else
{
document.getElementById('CheckBox3').disabled=true;
}

if(wed=="Y")
{
document.getElementById('CheckBox4').disabled=false;
}
else
{
document.getElementById('CheckBox4').disabled=true;
}

if(thu=="Y")
{
document.getElementById('CheckBox5').disabled=false;
}
else
{
document.getElementById('CheckBox5').disabled=true;
}

if(fri=="Y")
{
document.getElementById('CheckBox6').disabled=false;
}
else
{
document.getElementById('CheckBox6').disabled=true;
}

if(sat=="Y")
{
document.getElementById('CheckBox7').disabled=false;
}
else
{
document.getElementById('CheckBox7').disabled=true;
}

 if(all=="Y")
  {
  document.getElementById('CheckBox1').disabled=false;
  document.getElementById('CheckBox2').disabled=false;
  document.getElementById('CheckBox3').disabled=false;
  document.getElementById('CheckBox4').disabled=false;
  document.getElementById('CheckBox5').disabled=false;
  document.getElementById('CheckBox6').disabled=false;
  document.getElementById('CheckBox7').disabled=false;
  document.getElementById('CheckBox8').disabled=false;
 }
 else
 {
document.getElementById('CheckBox8').disabled=true;
 }
}

else
{
document.getElementById('CheckBox1').disabled=false;
document.getElementById('CheckBox2').disabled=false;
document.getElementById('CheckBox3').disabled=false;
document.getElementById('CheckBox4').disabled=false;
document.getElementById('CheckBox5').disabled=false;
document.getElementById('CheckBox6').disabled=false;
document.getElementById('CheckBox7').disabled=false;

 }
 addeditionname();
 return false;
 }
//////////////////////////////////////////////////
function addcount11()
{

//SupplimentMaster.getRo(document.getElementById('drpPubName').value,document.getElementById('hiddencompcode').value);
var pubname=document.getElementById('drpPubName').value;

    if(hiddentext=="query")
    {
 
      var dl="";
     if(browser!="Microsoft Internet Explorer")
      //alert('browser');
                       {
                       
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","SupplementgetRO.aspx?pubname="+pubname, false);
                        httpRequest.send('');
                       
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
    else
          {
           var xml = new ActiveXObject("Microsoft.XMLHTTP");
		    xml.Open( "GET","SupplementgetRO.aspx?pubname="+pubname, false );
		     xml.Send();
		    dl=xml.responseText;
		   }   
		    //alert(dl);
		    var ss=dl.split("+");
		    //alert(browser);
////		    if(ss[0]==null || ss[0]=="null")
////		    {
////		        document.getElementById('txtgutter').value="";
////		        document.getElementById('txtgutter').disabled=false;
////		    } 
////		    else
////		    {
////		        document.getElementById('txtgutter').value=ss[0];
////		        document.getElementById('txtgutter').disabled=false;
////		    }
////		    
////		    if(ss[1]==null || ss[1]=="null")
////		    {
////		        document.getElementById('txtcol').value="";
////		        document.getElementById('txtcol').disabled=false;
////		    } 
////		    else
////		    {
////		        document.getElementById('txtcol').value=ss[1];
////		        document.getElementById('txtcol').disabled=false;
////		    }
		   
		    if(ss[2]==null || ss[2]=="null")
		    {
////		        document.getElementById('txthr').value="";
////		        //document.getElementById('hidro').value="";
////		        document.getElementById('txthr').disabled=false;
		    } 
		    else
		    {
		       // document.getElementById('txthr').value=ss[2];
		        document.getElementById('hidro').value=ss[2];
		        ro  = document.getElementById('hidro').value;
		        //document.getElementById('txthr').disabled=false;
		    }
		    
////		    if(ss[3]==null || ss[3]=="null")
////		    {
////		        document.getElementById('txtmin').value="";
////		        document.getElementById('txtmin').disabled=false;
////		    } 
////		    else
////		    {
////		        document.getElementById('txtmin').value=ss[3];
////		        document.getElementById('txtmin').disabled=false;
////		    }
////		    
////		     if(ss[4]==null || ss[4]=="null")
////		    {
////		        document.getElementById('txtproduction').value="";
////		        document.getElementById('txtproduction').disabled=false;
////		    } 
////		    else
////		    {
////		        document.getElementById('txtproduction').value=ss[4];
////		        document.getElementById('txtproduction').disabled=false;
////		    }
		    
    }


if(document.getElementById('drpPubName').value!="0")
{
var pubname=document.getElementById('drpPubName').value;

////SupplimentMaster.addedition(pubname,callbind11);

}
else
{
    var pkgitem=document.getElementById('drEditonName');
         pkgitem.options[0]=new Option("------Select Edititon------","0");
      pkgitem.options.length = 1; 
   return false;
     
}

return false;
}
/////////This function is call back response for filling city///////
//var ro;
function callbind11(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drEditonName");
 //ro  = document.getElementById('hidro').value;

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
        var pkgitem=document.getElementById('drEditonName');
         pkgitem.options[0]=new Option("------Select Edititon------","0");
     
//var pkgitem = document.getElementById("drpcity");
//alert(pkgitem);
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Edition_Alias,res.value.Tables[0].Rows[i].Edition_Code);
        
       pkgitem.options.length;
       
    }
 if(editionvar == undefined || editionvar=="")
 {
 // document.getElementById('drpcity').value=res.value.Tables[0].Rows[0].City_Code;
 document.getElementById('drEditonName').value="0";
 }
 else
 {
  document.getElementById('drEditonName').value=editionvar;
  editionvar="";
  } 
 /* if((hiddentext=="new")||(hiddentext=="modify"))
  {
  document.getElementById('drpcity').focus();
  return false;
  }*/
  }
else
{
alert("There is No Matching value Found");
pkgitem.options.length=1;
return false;

}

return false;
}
/***********************ffff******/
////////////This function is used to generate city corresponding to particular country/////////
function addcount(ab)
{

//SupplimentMaster.getRo(document.getElementById('drpPubName').value,document.getElementById('hiddencompcode').value);
var pubname=document.getElementById('drpPubName').value;
var dl="";
    if(hiddentext=="new")
    {
         if(browser!="Microsoft Internet Explorer")
                       {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","SupplementgetRO.aspx?pubname="+pubname, false);
                        httpRequest.send('');
                       
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
           else
           {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
		    xml.Open( "GET","SupplementgetRO.aspx?pubname="+pubname, false );
		     xml.Send();
		    dl=xml.responseText;
		    }
		    
		    var ss=dl.split("+");
		    //alert(ss);
		    if(ss[0]==null || ss[0]=="null")
		    {
		        document.getElementById('txtgutter').value="";
		        document.getElementById('txtgutter').disabled=false;
		    } 
		    else
		    {
		        document.getElementById('txtgutter').value=ss[0];
		        document.getElementById('txtgutter').disabled=false;
		    }
		    
		    if(ss[1]==null || ss[1]=="null")
		    {
		        document.getElementById('txtcol').value="";
		        document.getElementById('txtcol').disabled=false;
		    } 
		    else
		    {
		        document.getElementById('txtcol').value=ss[1];
		        document.getElementById('txtcol').disabled=false;
		    }
		    
		    if(ss[2]==null || ss[2]=="null")
		    {
		        document.getElementById('txthr').value="";
		       // document.getElementById('hidro').value="";
		        document.getElementById('txthr').disabled=false;
		    } 
		    else
		    {
		        document.getElementById('txthr').value=ss[2];
		        //document.getElementById('hidro').value=ss[2];
		        document.getElementById('txthr').disabled=false;
		    }
		    
		    if(ss[3]==null || ss[3]=="null")
		    {
		        document.getElementById('txtmin').value="";
		        document.getElementById('txtmin').disabled=false;
		    } 
		    else
		    {
		        document.getElementById('txtmin').value=ss[3];
		        document.getElementById('txtmin').disabled=false;
		    }
		    
		     if(ss[4]==null || ss[4]=="null")
		    {
		        document.getElementById('txtproduction').value="";
		        document.getElementById('txtproduction').disabled=false;
		    } 
		    else
		    {
		        document.getElementById('txtproduction').value=ss[4];
		        document.getElementById('txtproduction').disabled=false;
		    }
		    
    }


if(document.getElementById('drpPubName').value!="0")
{
var pubname=document.getElementById('drpPubName').value;

SupplimentMaster.addedition(pubname,callbind);

}
else
{
    var pkgitem=document.getElementById('drEditonName');
         pkgitem.options[0]=new Option("------Select Edititon------","0");
      pkgitem.options.length = 1; 
   return false;
     
}

return false;
}
/////////This function is call back response for filling city///////
var ro;
function callbind(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drEditonName");
 ro  = document.getElementById('txthr').value;

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
        var pkgitem=document.getElementById('drEditonName');
         pkgitem.options[0]=new Option("------Select Edititon------","0");
     
//var pkgitem = document.getElementById("drpcity");
//alert(pkgitem);
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Edition_Alias,res.value.Tables[0].Rows[i].Edition_Code);
        
       pkgitem.options.length;
       
    }
 if(editionvar == undefined || editionvar=="")
 {
 // document.getElementById('drpcity').value=res.value.Tables[0].Rows[0].City_Code;
 document.getElementById('drEditonName').value="0";
 }
 else
 {
  document.getElementById('drEditonName').value=editionvar;
  editionvar="";
  } 
 /* if((hiddentext=="new")||(hiddentext=="modify"))
  {
  document.getElementById('drpcity').focus();
  return false;
  }*/
  }
else
{
alert("There is No Matching value Found");
document.getElementById('drpPubName').focus();
pkgitem.options.length=1;
return false;

}

return false;
}

function chkbox_supplement()
{
var edition=document.getElementById('drEditonName').value;
if(hiddentext!="query")
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

SupplimentMaster.fillsupplement(edition,fillchk_callback);
}
return false;

}

function fillchk_callback(response)
{
var ds=response.value;
kchk=0;
if(ds.Tables[0].Rows.length>0)
{
    var sun=ds.Tables[0].Rows[0].sun;
    var mon=ds.Tables[0].Rows[0].mon;
    var tue=ds.Tables[0].Rows[0].tue;
    var wed=ds.Tables[0].Rows[0].wed;
    var thu=ds.Tables[0].Rows[0].thu;
    var fri=ds.Tables[0].Rows[0].fri;
    var sat=ds.Tables[0].Rows[0].sat;
    var all=ds.Tables[0].Rows[0].all;

if(sun=="Y")
    {
    
    document.getElementById('CheckBox1').disabled=false;
    kchk++;
    }
else
    {
    document.getElementById('CheckBox1').disabled=true;
     document.getElementById('CheckBox1').checked=false;
  
    }

if(mon=="Y")
    {
   
    document.getElementById('CheckBox2').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox2').disabled=true;
    document.getElementById('CheckBox2').checked=false;
  
    }
if(tue=="Y")
    {
    
    document.getElementById('CheckBox3').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox3').disabled=true;
    document.getElementById('CheckBox3').checked=false;
  
    }
if(wed=="Y")
    {
   kchk++;
    document.getElementById('CheckBox4').disabled=false;
    }
else
    {
    document.getElementById('CheckBox4').disabled=true;
    document.getElementById('CheckBox4').checked=false;
  
    }
if(thu=="Y")
    {
    
    document.getElementById('CheckBox5').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox5').disabled=true;
    document.getElementById('CheckBox5').checked=false;
  
    }
if(fri=="Y")
    {
   
    document.getElementById('CheckBox6').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox6').disabled=true;
    document.getElementById('CheckBox6').checked=false;
  
    }
if(sat=="Y")
    {
  
    document.getElementById('CheckBox7').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox7').disabled=true;
    document.getElementById('CheckBox7').checked=false;
  
    }
if(all=="Y")
    {
//    document.getElementById('CheckBox1').disabled=false;
//    document.getElementById('CheckBox2').disabled=false;
//    document.getElementById('CheckBox3').disabled=false;
//    document.getElementById('CheckBox4').disabled=false;
//    document.getElementById('CheckBox5').disabled=false;
//    document.getElementById('CheckBox6').disabled=false;
//    document.getElementById('CheckBox7').disabled=false;
    document.getElementById('CheckBox8').disabled=false;
    if(sun=="Y")
    {
    
    document.getElementById('CheckBox1').disabled=false;
    kchk++;
    }
else
    {
    document.getElementById('CheckBox1').disabled=true;
     document.getElementById('CheckBox1').checked=false;
  
    }

if(mon=="Y")
    {
   
    document.getElementById('CheckBox2').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox2').disabled=true;
    document.getElementById('CheckBox2').checked=false;
  
    }
if(tue=="Y")
    {
    
    document.getElementById('CheckBox3').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox3').disabled=true;
    document.getElementById('CheckBox3').checked=false;
  
    }
if(wed=="Y")
    {
   kchk++;
    document.getElementById('CheckBox4').disabled=false;
    }
else
    {
    document.getElementById('CheckBox4').disabled=true;
    document.getElementById('CheckBox4').checked=false;
  
    }
if(thu=="Y")
    {
    
    document.getElementById('CheckBox5').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox5').disabled=true;
    document.getElementById('CheckBox5').checked=false;
  
    }
if(fri=="Y")
    {
   
    document.getElementById('CheckBox6').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox6').disabled=true;
    document.getElementById('CheckBox6').checked=false;
  
    }
if(sat=="Y")
    {
  
    document.getElementById('CheckBox7').disabled=false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox7').disabled=true;
    document.getElementById('CheckBox7').checked=false;
  
    }
    }
else
     {
    if((sun=="N")&&(mon=="N")&&(tue=="N")&&(wed=="N")&&(thu=="N")&&(fri=="N")&&(sat=="N"))
    document.getElementById('CheckBox8').disabled=true;
    else
    document.getElementById('CheckBox8').disabled=false;
    }
}

else
    {
    document.getElementById('CheckBox1').disabled=true;
    document.getElementById('CheckBox2').disabled=true;
    document.getElementById('CheckBox3').disabled=true;
    document.getElementById('CheckBox4').disabled=true;
    document.getElementById('CheckBox5').disabled=true;
    document.getElementById('CheckBox6').disabled=true;
    document.getElementById('CheckBox7').disabled=true;
    document.getElementById('CheckBox8').disabled=true;
  
    }
  
    return false;
}

///******************************************************************************************************
//function fillchk_callback(response)
//{
//var ds=response.value;
//if(ds.Tables[0].Rows.length>0)
//{
//    var sun=ds.Tables[0].Rows[0].sun;
//    var mon=ds.Tables[0].Rows[0].mon;
//    var tue=ds.Tables[0].Rows[0].tue;
//    var wed=ds.Tables[0].Rows[0].wed;
//    var thu=ds.Tables[0].Rows[0].thu;
//    var fri=ds.Tables[0].Rows[0].fri;
//    var sat=ds.Tables[0].Rows[0].sat;
//    var all=ds.Tables[0].Rows[0].all;

//if(sun=="Y")
//    {
//   
//    document.getElementById('CheckBox1').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox1').disabled=true;
//     document.getElementById('CheckBox1').checked=false;
//    }

//if(mon=="Y")
//    {
//   
//    document.getElementById('CheckBox2').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox2').disabled=true;
//    document.getElementById('CheckBox2').checked=false;
//    }
//if(tue=="Y")
//    {
//   
//    document.getElementById('CheckBox3').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox3').disabled=true;
//     document.getElementById('CheckBox3').checked=false;
// 
//    }
//if(wed=="Y")
//    {
//   
//    document.getElementById('CheckBox4').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox4').disabled=true;
//     document.getElementById('CheckBox4').checked=false;
// 
//    }
//if(thu=="Y")
//    {
//    
//    document.getElementById('CheckBox5').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox5').disabled=true;
//     document.getElementById('CheckBox5').checked=false;
// 
//    }
//if(fri=="Y")
//    {
//   
//    document.getElementById('CheckBox6').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox6').disabled=true;
//     document.getElementById('CheckBox6').checked=false;
// 
//    }
//if(sat=="Y")
//    {
//   
//    document.getElementById('CheckBox7').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox7').disabled=true;
//     document.getElementById('CheckBox7').checked=false;
// 
//    }
//if(all=="Y")
//    {
//   /* document.getElementById('CheckBox1').disabled=false;
//    document.getElementById('CheckBox2').disabled=false;
//    document.getElementById('CheckBox3').disabled=false;
//    document.getElementById('CheckBox4').disabled=false;
//    document.getElementById('CheckBox5').disabled=false;
//    document.getElementById('CheckBox6').disabled=false;
//    document.getElementById('CheckBox7').disabled=false;*/
//    document.getElementById('CheckBox8').disabled=false;
//    }
//else
//    {
//    if((sun=="N")&&(mon=="N")&&(tue=="N")&&(wed=="N")&&(thu=="N")&&(fri=="N")&&(sat=="N"))
//    document.getElementById('CheckBox8').disabled=true;
//    else
//    document.getElementById('CheckBox8').disabled=false;
//    }
//}

//else
//    {
//    document.getElementById('CheckBox1').disabled=true;
//    document.getElementById('CheckBox2').disabled=true;
//    document.getElementById('CheckBox3').disabled=true;
//    document.getElementById('CheckBox4').disabled=true;
//    document.getElementById('CheckBox5').disabled=true;
//    document.getElementById('CheckBox6').disabled=true;
//    document.getElementById('CheckBox7').disabled=true;
//    }
//        
//    return false;
//}



////////******************************************************************************
function fillchk_chkbox()
{
lchk=0;
	 if((document.getElementById('CheckBox1').disabled==false)&&(document.getElementById('CheckBox1').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
  
    if((document.getElementById('CheckBox2').disabled==false)&&(document.getElementById('CheckBox2').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox3').disabled==false)&&(document.getElementById('CheckBox3').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox4').disabled==false)&&(document.getElementById('CheckBox4').checked==false))
    {
   document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox5').disabled==false)&&(document.getElementById('CheckBox5').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
     if((document.getElementById('CheckBox6').disabled==false)&&(document.getElementById('CheckBox6').checked==false))
    {
   document.getElementById('CheckBox8').checked=false;
    }
     if((document.getElementById('CheckBox7').disabled==false)&&(document.getElementById('CheckBox7').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }

 if((document.getElementById('CheckBox1').disabled==false)&&(document.getElementById('CheckBox1').checked==true))
    {
     lchk++;
    }
   
    if((document.getElementById('CheckBox2').disabled==false)&&(document.getElementById('CheckBox2').checked==true))
    {
  lchk++;
      }
    if((document.getElementById('CheckBox3').disabled==false)&&(document.getElementById('CheckBox3').checked==true))
    {
     lchk++;
    }
    if((document.getElementById('CheckBox4').disabled==false)&&(document.getElementById('CheckBox4').checked==true))
    {
      lchk++;
     }
    if((document.getElementById('CheckBox5').disabled==false)&&(document.getElementById('CheckBox5').checked==true))
    {
    lchk++;
        }
     if((document.getElementById('CheckBox6').disabled==false)&&(document.getElementById('CheckBox6').checked==true))
    {
     lchk++;
    }
     if((document.getElementById('CheckBox7').disabled==false)&&(document.getElementById('CheckBox7').checked==true))
    {
   lchk++;
      }
      
      if(lchk==kchk)
      {
   
    
      document.getElementById('CheckBox8').checked=true;
      }
      
 
 return ;
 }
 
 

///**********************************************************
function fillheight()
{
if(document.getElementById('txtsizeheight').value=="" && document.getElementById('txtsizewidth').value =="")
{

//document.getElementById('txtarea').value="";
//document.getElementById('txtcolumn').focus();

return false;
}
if(document.getElementById('txtsizeheight').value=="" && document.getElementById('txtsizewidth').value !="")
{
//document.getElementById('txtarea').value="";
////document.getElementById('txtsizeheight').focus();
//document.getElementById('txtcolumn').focus();


	
return false;
}
if(document.getElementById('txtsizeheight').value!="" && document.getElementById('txtsizewidth').value !="")
{

document.getElementById('txtarea').value=document.getElementById('txtsizeheight').value * document.getElementById('txtsizewidth').value;
//document.getElementById('txtcolumn').focus();
return false;
}


}

function fillwidth()
{
//document.getElementById('txtsizewidth1').value=document.getElementById('txtsizewidth').value;
if(document.getElementById('txtsizeheight').value=="" && document.getElementById('txtsizewidth').value =="")
{

//document.getElementById('txtarea').value="";
//document.getElementById('txtcolumn').focus();
return false;
}
if(document.getElementById('txtsizeheight').value!="" && document.getElementById('txtsizewidth').value =="" )
{
//document.getElementById('txtarea').value="";
////document.getElementById('txtsizewidth').focus();
//document.getElementById('txtcolumn').focus();

	
return false;
}
if(document.getElementById('txtsizeheight').value!="" && document.getElementById('txtsizewidth').value !="")
{

document.getElementById('txtarea').value=document.getElementById('txtsizeheight').value * document.getElementById('txtsizewidth').value;
//document.getElementById('txtcolumn').focus();
return false;
}

return false;

}




//////////This function is used to generate alias name depending on publication name,edition name and city///////////////
function fillalias()
{
chkbox_supplement();
document.getElementById('txtAlias').value="";
if(hiddentext !="query")
if(document.getElementById('drpPubName').value=="0")
{
alert("Please Select Publication Name");
 document.getElementById('drpPubName').focus();
         
return false;
}
else if(document.getElementById('drEditonName').value=="0")
{
alert("Please Select Edition Name");
 document.getElementById('drEditonName').focus();
         
return false;
}


 if((document.getElementById('drEditonName').value!="0")&&(document.getElementById('drpPubName').value!="0")&&(document.getElementById('txtSuppName').value!=""))
		          {
                   chkstr=document.getElementById('drEditonName').value;
                 strpub=document.getElementById('drpPubName').value;
               
		        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
SupplimentMaster.findedition(chkstr,call_fillalias);
 		        return false;
                }
 else
       {
        document.getElementById('txtAlias').value="";
        return false;
        }
return false;
}

//////This function is call back response for filling alias name///////////

function call_fillalias(res)
{
ds=res.value;
//        if(document.getElementById('txtcolumn').disabled==false)
//              document.getElementById('txtcolumn').focus();    
            suppnam=document.getElementById('txtSuppName').value;
              suppname=suppnam.substr(0,5);
		   	pubstr=ds.Tables[0].Rows[0].Edition_Alias;
		     var pubnamearr=new Array();
             pubnamearr=pubstr.split('-');
             code1=pubnamearr[0];
             code3 = "";
             var suppcodename = document.getElementById('txtSuppCode').value.substr(2, 7);
            for(i=1;i<pubnamearr.length;i++)
              {
               code2="-";
               pubcode=pubnamearr[i];
               code3=code3+code2+pubcode;
               }  

    //var alias=code1+"-"+suppname+code3;
            var alias = code1 + "-" + suppname + suppcodename + code3;
      // EditorMaster.chkalias(alias,call_alias);
      var d=new Date();
      var dm=d.getFullYear().toString()+ parseInt(d.getMonth()+1,10).toString();
    //document.getElementById('txtAlias').value=code1+"-"+suppname+dm+code3;
      document.getElementById('txtAlias').value = code1 + "-" + suppname + suppcodename + dm + code3;
     var spllitting=document.getElementById('txtAlias').value.split("-");
      if(spllitting.length=="3")
      {
         document.getElementById('txtAlias').value=code1+"-"+suppname+dm+code3+"-"+"MN";
      
      }
     chkbox_supplement();
    // document.getElementById('drperiodicity').focus();
       
       
return false;

}




//////////////this is for pop up

//function submitclick()
//{

//       

//var periodicity=document.getElementById('hiddenperiodicity').value;
//popupsupplement.chkperiodicty(periodicity,callbck_periodicity);
//return false;
//}




/*function submitclick()
{

        var page;
       var supplement="";
        var date1="";
        var date2="";
         var period = document.getElementById('hiddenperiodicity').value;
        if (document.getElementById('txtaddate').value == "--Select Date--" && period == "FO0 ")
        {
            alert('Fill Both ');
            return false;
        }
        if(browser!="Microsoft Internet Explorer")
                       {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+date1+"&date2="+date2, false);
                        httpRequest.send('');
                       
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                ds=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
        else
        {
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+date1+"&date2="+date2, false );
		xml.Send();
		var ds=xml.responseText; 
         }

//var ds=response.value;

/*var fromdate=document.getElementById('txtdate').value;
var todate=document.getElementById('txtaddate').value;
//-----------------------------------------------------------------------//
var dateformat = document.getElementById('hiddendateformat').value;
if(dateformat=="mm/dd/yyyy")
	{
        var fromdate=document.getElementById('txtdate').value;
        var todate=document.getElementById('txtaddate').value;
	}
		
	if(dateformat=="dd/mm/yyyy")
	{
		var txtfrom=fromdate.split("/");
		var ddfrom=txtfrom[0];
		var mmfrom=txtfrom[1];
		var yyfrom=txtfrom[2];
		fromdate=mmfrom+'/'+ddfrom+'/'+yyfrom;
		
		var txttill=todate.split("/");
		var ddtill=txttill[0];
		var mmtill=txttill[1];
		var yytill=txttill[2];
		todate=mmtill+'/'+ddtill+'/'+yytill;
	}
	if(dateformat=="yyyy/mm/dd")
	{
		var txtfrom=fromdate.split("/");
		var yyfrom=txtfrom[0];
		var mmfrom=txtfrom[1];
		var ddfrom=txtfrom[2];
		fromdate=mmfrom+'/'+ddfrom+'/'+yyfrom;
		
		var txttill=todate.split("/");
		var yytill=txttill[0];
		var mmtill=txttill[1];
		var ddtill=txttill[2];
		todate=mmtill+'/'+ddtill+'/'+yytill;
	}
	
//	var fdate=new Date(fromdate);
//	var tdate=new Date(todate);

	var currdate=new Date();
    var ftdate=new Date(fromdate);
    var eddate=new Date(todate);*/
    //////////////bhanu////////
    //var dateformat=document.getElementById('hiddendateformat').value;
//var txtdate="";
//var txtaddate="";
////this is for from date
//if(dateformat=="dd/mm/yyyy")
//{
//if(document.getElementById('txtdate').value != "")
//{
//var txt=document.getElementById('txtdate').value;
//var txt1=txt.split("/");
//var dd=txt1[0];
//var mm=txt1[1];
//var yy=txt1[2];
// txtdate=mm+'/'+dd+'/'+yy;
//}
//else
//{
// txtdate=document.getElementById('txtdate').value;
//}

//}
//if(dateformat=="yyyy/mm/dd")
//{
//if(document.getElementById('txtdate').value!="")
//{
//var txt=document.getElementById('txtdate').value;
//var txt1=txt.split("/");
//var yy=txt1[0];
//var mm=txt1[1];
//var dd=txt1[2];
// txtdate=mm+'/'+dd+'/'+yy;
//}
//else
//{
// txtdate=document.getElementById('txtdate').value;
//}
//}
//if(dateformat=="mm/dd/yyyy")
//{
// txtdate=document.getElementById('txtdate').value;
//}
//if(dateformat==null || dateformat=="" || dateformat=="undefined")
//{
// txtdate=document.getElementById('txtdate').value;
//}

////this is for till date

//if(dateformat=="dd/mm/yyyy")
//{
//if(document.getElementById('txtaddate').value != "")
//{
//var txt=document.getElementById('txtaddate').value;
//var txt1=txt.split("/");
//var dd=txt1[0];
//var mm=txt1[1];
//var yy=txt1[2];
// txtaddate=mm+'/'+dd+'/'+yy;
//}
//else
//{
//txtaddate=document.getElementById('txtaddate').value;
//}

//}
//if(dateformat=="yyyy/mm/dd")
//{
//if(document.getElementById('txtaddate').value!="")
//{
//var txt=document.getElementById('txtaddate').value;
//var txt1=txt.split("/");
//var yy=txt1[0];
//var mm=txt1[1];
//var dd=txt1[2];
// txtaddate=mm+'/'+dd+'/'+yy;
//}
//else
//{
// txtaddate=document.getElementById('txtaddate').value;
//}
//}
//if(dateformat=="mm/dd/yyyy")
//{
//var txtaddate=document.getElementById('txtaddate').value;
//}
//if(dateformat==null || dateformat=="" || dateformat=="undefined")
//{
// txtaddate=document.getElementById('txtaddate').value;
//}

//var ds=response.value;
/*
var fromdate=document.getElementById('txtdate').value;
var todate=document.getElementById('txtaddate').value;
//var currdate=new Date();
//var ftdate=new Date(txtdate);
//var eddate=new Date(txtaddate);
    ///////////////////////////
//-----------------------------------------------------------------------//
txtaddate=document.getElementById('txtaddate').value;
txtdate=document.getElementById('txtdate').value;
//if(document.getElementById('txteditionname').value=="")
//{
//alert("Please Fill The Suppliment  name");
//document.getElementById('txteditionname').focus();
//return false;
//}

//else if(document.getElementById('txtdate').value=="")
//{
//alert("Please Fill First Cycle Day");
//document.getElementById('txtdate').focus();
//return false;
//}
//else if((ds=="2")&&(document.getElementById('txtaddate').value!="")&&(document.getElementById('txtdate').value!=""))
//{
//    dateDifference(txtdate,txtaddate);
//    if(date<30)
//{
//alert("Second Cycle Date should be 30 days more than First Cycle Date(Periodicity is MONTHLY) ");
//document.getElementById('txtaddate').value="";
//document.getElementById('txtaddate').focus();
//return false;
//}
//}
//else if((ds=="4") && (document.getElementById('txtdate').value==""))
//{
//alert("Please Fill First Cycle Date");
//document.getElementById('txtdate').focus();
//return false;
//}
//else if((ds=="4")&&(document.getElementById('txtaddate').value!="")&&(document.getElementById('txtdate').value!=""))
//{
//    dateDifference(txtdate,txtaddate);
//    if(date<15)
//{
//alert("Second Cycle Date should be 15 days more than First Cycle Date(Periodicity is FORTNIGHT) ");
//document.getElementById('txtaddate').value="";
//document.getElementById('txtaddate').focus();
//return false;
//}
//}

//else if(ftdate < currdate)
//{
//alert("First Cycle Date must be greater than current date ");
//document.getElementById('txtdate').focus();
//return false;
//}

//else if((ds=="3")&& (document.getElementById('txtdate').value==""))
//{
//  alert("Please Fill  First Cycle");
//document.getElementById('txtdate').focus();
//return false;
//}
//else if((ds=="3")&& (document.getElementById('txtaddate').value==""))
//{
//  alert("Please Fill  Second Cycle");
//document.getElementById('txtdate').focus();
//return false;
//}

//else if( eddate <= ftdate)
//{
//alert("Second Cycle Date must be greater than First Cycle date ");
//document.getElementById('txtaddate').focus();
//return false;
//}

////else if(eddate != ftdate)
////{
////alert("Second Cycle Date should be greater than First Cycle date ");
////document.getElementById('txtaddate').focus();
////return false;
////}


//else if((ds=="4")&& (document.getElementById('txtaddate').value==""))
//{
//  alert("Please Fill  Second Cycle");
//document.getElementById('txtaddate').focus();
//return false;
//}



////else if(document.getElementById('txtaddate').value=="")
////{
////alert("Please Fill Addtional Date");
////document.getElementById('txtaddate').focus();
////return false;
////}
if(document.getElementById('txteditionname').value=="")
{
alert("Please Enter The Edition name");
document.getElementById('txteditionname').focus();
return false;
}
if( document.getElementById('txtdate').value=="0")
{
alert("Please Fill First Cycle  Day");
document.getElementById('txtdate').focus();
return false;
}
if((ds=="4")&& (document.getElementById('txtaddate').value=="0"))
{
  alert("Please Fill  Second Cycle Day.");
document.getElementById('txtaddate').focus();
return false;
}
if((ds=="4")&& (parseInt(document.getElementById('txtdate').value)>parseInt(document.getElementById('txtaddate').value)))
{
alert("Second Cycle Day Should be greater than First Cycle  Day")
return false;
}
if((ds=="2")&& (document.getElementById('txtaddate').value=="0"))
{
 document.getElementById('txtaddate').value="";
}
var fromdate=document.getElementById('txtdate').value;
var todate=document.getElementById('txtaddate').value;


var txteditionname=document.getElementById('txteditionname').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var suppcode=document.getElementById('hiddensuppcode').value; 

//this is for from date
//if(dateformat=="dd/mm/yyyy")
//{
//if(document.getElementById('txtdate').value != "")
//{
//var txt=document.getElementById('txtdate').value;
//var txt1=txt.split("/");
//var dd=txt1[0];
//var mm=txt1[1];
//var yy=txt1[2];
//var txtdate=mm+'/'+dd+'/'+yy;
//}
//else
//{
//var txtdate=document.getElementById('txtdate').value;
//}

//}
//if(dateformat=="yyyy/mm/dd")
//{
//if(document.getElementById('txtdate').value!="")
//{
//var txt=document.getElementById('txtdate').value;
//var txt1=txt.split("/");
//var yy=txt1[0];
//var mm=txt1[1];
//var dd=txt1[2];
//var txtdate=mm+'/'+dd+'/'+yy;
//}
//else
//{
//var txtdate=document.getElementById('txtdate').value;
//}
//}
//if(dateformat=="mm/dd/yyyy")
//{
//var txtdate=document.getElementById('txtdate').value;
//}
//if(dateformat==null || dateformat=="" || dateformat=="undefined")
//{
//var txtdate=document.getElementById('txtdate').value;
//}

//this is for till date

//if(dateformat=="dd/mm/yyyy")
//{
//if(document.getElementById('txtaddate').value != "")
//{
//var txt=document.getElementById('txtaddate').value;
//var txt1=txt.split("/");
//var dd=txt1[0];
//var mm=txt1[1];
//var yy=txt1[2];
//var txtaddate=mm+'/'+dd+'/'+yy;
//}
//else
//{
//var txtaddate=document.getElementById('txtaddate').value;
//}

//}
//if(dateformat=="yyyy/mm/dd")
//{
//if(document.getElementById('txtaddate').value!="")
//{
//var txt=document.getElementById('txtaddate').value;
//var txt1=txt.split("/");
//var yy=txt1[0];
//var mm=txt1[1];
//var dd=txt1[2];
//var txtaddate=mm+'/'+dd+'/'+yy;
//}
//else
//{
//var txtaddate=document.getElementById('txtaddate').value;
//}
//}
//if(dateformat=="mm/dd/yyyy")
//{
//var txtaddate=document.getElementById('txtaddate').value;
//}
//if(dateformat==null || dateformat=="" || dateformat=="undefined")
//{
//var txtaddate=document.getElementById('txtaddate').value;
//}
if(insert!="1" && insert!=null)
{
if((document.getElementById('DataGrid1'))!=null  )
{
if(document.getElementById('DataGrid1').rows.length-1==1)
{
    alert('Single row should de inserted.');
    return false;
    }
}

        var page="";
        var supplement=suppcode;
        var date1="";
        var date2="";
        if(browser!="Microsoft Internet Explorer")
                       {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+txtdate+"&date2="+txtaddate, false);
                        httpRequest.send('');
                       
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
        else
        {
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+txtdate+"&date2="+txtaddate, false );
		xml.Send();
		var dl=xml.responseText;
		}
		if(dl == "Y")
	{
	alert("Issue Date has already been assigned ");
	return false;
	}
	
	else
	{
	opener.document.getElementById('hiddeneditalias').value=txteditionname;
	opener.document.getElementById('hiddeneditdate').value=txtdate;
    opener.document.getElementById('hiddeneditaddate').value=txtaddate;
    document.getElementById('hiddenfdate').value=document.getElementById('txtdate').value;
    document.getElementById('hiddentaddate').value=document.getElementById('txtaddate').value;
}
return;
////popupsupplement.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,call_insert);
//popupsupplement.insert(txteditionname,txtdate,txtaddate,compcode,userid,editcode);


}
else
{
popupsupplement.chkupdate(txteditionname,txtdate,txtaddate,compcode,userid,suppcode,code10,call_update);
//popupsupplement.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);
document.getElementById('btndelete').disabled=true;
insert="0";

}



return false;


}*/

function submitclick()
{



    if (document.getElementById('txtdate').value == "undefined" || document.getElementById('txtdate').value == "") {

        alert("Please Select First Cycle");
        return false;
    }

    if (document.getElementById('txtaddate').value == "undefined" || document.getElementById('txtaddate').value == "") {

        alert("Please Select Second Cycle");
        return false;
    }
    

        var page;
       var supplement="";
        var date1="";
        var date2="";
         var period = document.getElementById('hiddenperiodicity').value;
        if (document.getElementById('txtaddate').value == "--Select Date--" && period == "FO0 ")
        {
            alert('Fill Both ');
            return false;
        }
        if(browser!="Microsoft Internet Explorer")
                       {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+date1+"&date2="+date2, false);
                        httpRequest.send('');
                       
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
        else
        {
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+date1+"&date2="+date2, false );
		xml.Send();
		var ds=xml.responseText; 
         }

//var ds=response.value;

var fromdate=document.getElementById('txtdate').value;
var todate=document.getElementById('txtaddate').value;
//chk date=====//
if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
  {
      var startdateC=fromdate.split("/")[1] + '/' + fromdate.split("/")[0] + '/' + fromdate.split("/")[2];
      var enddateC=todate.split("/")[1] + '/' + todate.split("/")[0] + '/' + todate.split("/")[2];
  }
  else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
  {
      var startdateC=fromdate.split("/")[1] + '/' + fromdate.split("/")[2] + '/' + fromdate.split("/")[0];
      var enddateC=todate.split("/")[1] + '/' + todate.split("/")[2] + '/' + todate.split("/")[0];
  }
   else  if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
  {
      var startdateC=document.getElementById("txtdate").value;
      var enddateC=document.getElementById("txtaddate").value;
  }
var currdate=new Date();
var ftdate=new Date(startdateC);
var eddate=new Date(enddateC);
//alert(ds);
if(document.getElementById('txteditionname').value=="")
{
alert("Please Fill The Suppliment  name");
document.getElementById('txteditionname').focus();
return false;
}

else if((ds=="2") && (document.getElementById('txtdate').value==""))
{
alert("Please Fill First Cycle Date");
document.getElementById('txtdate').focus();
return false;
}
else if((ds=="4") && (document.getElementById('txtdate').value==""))
{
alert("Please Fill First Cycle Date");
document.getElementById('txtdate').focus();
return false;
}


//else if(ftdate < currdate)
//{
//alert("First Cycle Date must be greater than current date ");
//document.getElementById('txtdate').focus();
//return false;
//}

else if((ds=="3")&& (document.getElementById('txtdate').value==""))
{
  alert("Please Fill  First Cycle");
document.getElementById('txtdate').focus();
return false;
}
else if((ds=="3")&& (document.getElementById('txtaddate').value==""))
{
  alert("Please Fill  Second Cycle");
document.getElementById('txtdate').focus();
return false;
}

else if( eddate < ftdate)
{
alert("Second Cycle Date must be greater than First Cycle date ");
document.getElementById('txtaddate').focus();
return false;
}

//else if(eddate != ftdate)
//{
//alert("Second Cycle Date should be greater than First Cycle date ");
//document.getElementById('txtaddate').focus();
//return false;
//}


else if((ds=="4")&& (document.getElementById('txtaddate').value==""))
{
  alert("Please Fill  Second Cycle");
document.getElementById('txtaddate').focus();
return false;
}



////else if(document.getElementById('txtaddate').value=="")
////{
////alert("Please Fill Addtional Date");
////document.getElementById('txtaddate').focus();
////return false;
////}



var txteditionname=document.getElementById('txteditionname').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var suppcode=trim(document.getElementById('hiddensuppcode').value); 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdate').value != "")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtdate=document.getElementById('txtdate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdate').value!="")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtdate=document.getElementById('txtdate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtdate=document.getElementById('txtdate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtdate=document.getElementById('txtdate').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtaddate').value != "")
{
var txt=document.getElementById('txtaddate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtaddate=mm+'/'+dd+'/'+yy;
}
else
{
var txtaddate=document.getElementById('txtaddate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtaddate').value!="")
{
var txt=document.getElementById('txtaddate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtaddate=mm+'/'+dd+'/'+yy;
}
else
{
var txtaddate=document.getElementById('txtaddate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtaddate=document.getElementById('txtaddate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtaddate=document.getElementById('txtaddate').value;
}
var txtdate1=document.getElementById('txtdate').value
var txtaddate1=document.getElementById('txtaddate').value;
if(insert!="1" && insert!=null)
{

        var page="";
        var supplement=suppcode;
        var date1="";
        var date2="";
        if(browser!="Microsoft Internet Explorer")
                       {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+txtdate+"&date2="+txtaddate, false);
                        httpRequest.send('');
                       
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
        else
        {
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","checksupplement.aspx?page="+document.getElementById('hiddenperiodicity').value+"&supplement="+supplement+"&date1="+txtdate+"&date2="+txtaddate, false );
		xml.Send();
		var dl=xml.responseText;
		}
		if(dl == "Y")
	{
	alert("Issue Date has already been assigned ");
	return false;
	}
	
	else
	{
	        if(opener.hiddentext != "modify")
                  {
                  opener.document.getElementById('hiddeneditalias').value=txteditionname;
                  opener.document.getElementById('hiddeneditdate').value=txtdate;
                  opener.document.getElementById('hiddeneditaddate').value=txtaddate;
			        return  ;
                  
                  }
              else
                  {
//                  if (opener.document.getElementById('hiddenchk').value=="1")
//                       {
                        popupsupplement.insert(txteditionname,txtdate1,txtaddate1,compcode,userid,suppcode);
                        
                        document.getElementById('txtdate').value="";
                        document.getElementById('txtaddate').value="";
//                        document.getElementById('txtcommrate').value="";
//                        document.getElementById('drpcommdetail').value="NET";

                        window.location=window.location;
                        return false;
//                      }
                   
                 }
	    
    }
   //* return;
////popupsupplement.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,call_insert);
//popupsupplement.insert(txteditionname,txtdate,txtaddate,compcode,userid,editcode);


}
else
{
popupsupplement.chkupdate(txteditionname,txtdate,txtaddate,compcode,userid,suppcode,code10,call_update);
//popupsupplement.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);
document.getElementById('btndelete').disabled=true;
insert="0";

}



return false;


}
function selectclick(ab)
{
var id=ab;

if(document.getElementById(id).checked==false)
{
//document.getElementById('txteditionname').value="";
document.getElementById('txtdate').value="";
document.getElementById('txtaddate').value="";
document.getElementById('btndelete').disabled=true;

document.getElementById(id).checked=false;

return;
}

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
var editcode=document.getElementById('hiddensuppcode').value;

var j;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;

//	alert(document.getElementById(str));
     if(id==str)
        {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	code10=document.getElementById(str).value;
	chk123=document.getElementById(id);
	}
	}
	}
	if(k==1)
	{
	if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=false;
	}
	popupsupplement.selected(editcode,compcode,userid,code10,call_select12);
	
	}
	else if(k==0)
	{
	//chk123.checked=false;
	//document.getElementById('txteditionname').value="";
    document.getElementById('txtdate').value="";
    document.getElementById('txtaddate').value="";
	return false;
	}
	document.getElementById(ab).checked=true;
	
	//return false;



}










function call_select12(response)
{
var ds=response.value;
insert="1";
var txteditionname=document.getElementById('txteditionname').value=ds.Tables[0].Rows[0].Supp_Alias;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 

//this is for from date

if(ds.Tables[0].Rows[0].Date_Supplement != null && ds.Tables[0].Rows[0].Date_Supplement != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].Date_Supplement;
			var dd=enrolldate.getDate();
			var mm=enrolldate.getMonth() + 1;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			document.getElementById('txtdate').value=enrolldate1;
	}
	else
	{
	document.getElementById('txtdate').value="";
	}
	
	//this for till date
	
	if(ds.Tables[0].Rows[0].AdditionalDate_Supp != null && ds.Tables[0].Rows[0].AdditionalDate_Supp != "")
	{

	var enrolldatet=ds.Tables[0].Rows[0].AdditionalDate_Supp;
			var dd=enrolldatet.getDate();
			var mm=enrolldatet.getMonth() + 1;
			var yyyy=enrolldatet.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1t=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1t=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1t=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1t=mm+'/'+dd+'/'+yyyy;
			}
			document.getElementById('txtaddate').value=enrolldate1t;
	}
	else
	{
	document.getElementById('txtaddate').value="";
	}

//document.getElementById('txtdate').value=ds.Tables[0].Rows[0].Date_Supplement;
//document.getElementById('txtaddate').value=ds.Tables[0].Rows[0].AdditionalDate_Supp;
return false;
}

function deletegridclick()
{

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var editcode=trim(document.getElementById('hiddensuppcode').value); 

//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
popupsupplement.deletegrid(editcode,compcode,userid,code10);

window.location=window.location;
return false;
}

//********************************************************
function clearclick()
{
document.getElementById('txtaddate').value="";
document.getElementById('txtdate').value="";
//document.getElementById('txteditionname').value="";
  //chk123.checked=false;
return false;
}



function call_insert(response)
{

var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("Issue Date has already been assigned ");
	return false;
	}
	else
		{
var txteditionname=document.getElementById('txteditionname').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=document.getElementById('hiddensuppcode').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdate').value != "")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtdate=document.getElementById('txtdate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdate').value!="")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtdate=document.getElementById('txtdate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtdate=document.getElementById('txtdate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtdate=document.getElementById('txtdate').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtaddate').value != "")
{
var txt=document.getElementById('txtaddate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtaddate=mm+'/'+dd+'/'+yy;
}
else
{
var txtaddate=document.getElementById('txtaddate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtaddate').value!="")
{
var txt=document.getElementById('txtaddate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtaddate=mm+'/'+dd+'/'+yy;
}
else
{
var txtaddate=document.getElementById('txtaddate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtaddate=document.getElementById('txtaddate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtaddate=document.getElementById('txtaddate').value;
}
opener.document.getElementById('hiddeneditalias').value=txteditionname;
opener.document.getElementById('hiddeneditdate').value=txtdate;
opener.document.getElementById('hiddeneditaddate').value=txtaddate;

//popupsupplement.insert(txteditionname,txtdate,txtaddate,compcode,userid,editcode);		

document.getElementById('txteditionname').value="";
document.getElementById('txtdate').value="";
document.getElementById('txtaddate').value="";

		}
		window.location=window.location
		return false;
}

function call_update(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	insert="1";
	alert("This Date Has Been Assigned");
	return false;
	}
	else
		{
var txteditionname=document.getElementById('txteditionname').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=document.getElementById('hiddensuppcode').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdate').value != "")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtdate=document.getElementById('txtdate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdate').value!="")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtdate=document.getElementById('txtdate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtdate=document.getElementById('txtdate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtdate=document.getElementById('txtdate').value;
}

//this is for additional date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtaddate').value != "")
{
var txt=document.getElementById('txtaddate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtaddate=mm+'/'+dd+'/'+yy;
}
else
{
var txtaddate=document.getElementById('txtaddate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtaddate').value!="")
{
var txt=document.getElementById('txtaddate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtaddate=mm+'/'+dd+'/'+yy;
}
else
{
var txtaddate=document.getElementById('txtaddate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtaddate=document.getElementById('txtaddate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtaddate=document.getElementById('txtaddate').value;
}	
//var txtdate=document.getElementById('txtdate').value;
//var txtaddate=document.getElementById('txtaddate').value;
popupsupplement.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);	
		}
		window.location=window.location
		return false;
}



function call_finallychkperiodictyjssupp()
{

var txteditionname=document.getElementById('hiddeneditalias').value ;
var txtdate=document.getElementById('hiddeneditdate').value;
var txtaddate=document.getElementById('hiddeneditaddate').value;
// var dschk=res.value;

         /* if((txtdate=="")&&(txtaddate==""))
          {
          alert("Please Fill Supplement Issue Date");
          return false;
          }  */
        //  else
           if((gbchkperiod=="2")&&((txtdate=="")||(txtdate==null)))
          {
          alert("Please Fill First Cycle Date In Supplement Issue Date Pop-Up");
          return false;
          }
         else if((gbchkperiod=="3") && ((txtdate=="")||(txtdate==null)))
          {
          alert("Please Fill First Cycle Date In Supplement Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="4") && ((txtdate=="")||(txtdate==null))&& ((txtaddate=="")||(txtaddate==null)))
          {
          alert("Please Fill First and Second Cycle Date In Supplement Issue Date Pop-Up");
          return false;
          }
          else
          {
          call_finallysavemodify();
           return false;
          }



}
        
function chkheight(e)
{
//return allamount121(e);

var fld=document.getElementById('txtsizeheight').value;
		if(fld!="")
			{
			    //var expression= ^-{0,1}\d*\.{0,1}\d+$;
			    if(fld.match(/^\d+(\.\d{1,2})?$/i))
			        {
			        //return true;
			        }
			    else
			    {
			        alert("Input Error");
			        //alert(e.id);
			        //var str=document.getElementById('txtsizeheight').value;
			        document.getElementById('txtsizeheight').value="";
			        document.getElementById('txtsizeheight').focus();
			        //e.id.focus();
			        return false;
			    }
			
			}
	}
	
	
function chkwidth(e)
{
//return allamount121(e);

var fld=document.getElementById('txtsizewidth').value;
		if(fld!="")
			{
			    //var expression= ^-{0,1}\d*\.{0,1}\d+$;
			    if(fld.match(/^\d+(\.\d{1,2})?$/i))
			        {
			            //return true;
			        }
			    else
			        {
			            alert("Input error");
			            //alert(e.id);
			            //var str=document.getElementById('txtsizeheight').value;
			            document.getElementById('txtsizewidth').value="";
			            document.getElementById('txtsizewidth').focus();
			            //e.id.focus();
			            return false;
			        }
			
			}
	}


        

       
function Multiply()
{
	if ((event.keyCode>=49 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)||(event.keyCode==46))
	{
		
		return true;
	}
	else
	{
		return false;
	}
} 


///////////////sorting of a drop down

function keySort(dropdownlist,caseSensitive) {
  // check the keypressBuffer attribute is defined on the dropdownlist 
  var undefined; 
  if (dropdownlist.keypressBuffer == undefined) { 
    dropdownlist.keypressBuffer = ''; 
  } 
  // get the key that was pressed 
  var key = String.fromCharCode(window.event.keyCode); 
  dropdownlist.keypressBuffer += key;
  if (!caseSensitive) {
    // convert buffer to lowercase
    dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
  }
  // find if it is the start of any of the options 
  var optionsLength = dropdownlist.options.length; 
  for (var n=0; n<optionsLength; n++) { 
    var optionText = dropdownlist.options[n].text; 
    if (!caseSensitive) {
      optionText = optionText.toLowerCase();
    }
    if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
      dropdownlist.selectedIndex = n; 
      return false; // cancel the default behavior since 
                    // we have selected our own value 
    } 
  } 
  // reset initial key to be inline with default behavior 
  dropdownlist.keypressBuffer = key; 
  return true; // give default behavior 
} 
/////////////////////////////////////////////////////////////////////////////
        
       
        
function checkgutter()
{
var num=document.getElementById('txtgutter').value;
var num2=parseFloat(document.getElementById('txtgutter').value);
if(document.getElementById('txtgutter').value!=null &&document.getElementById('txtgutter').value!="")
{
document.getElementById('txtgutter').value=num2;
}

var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
document.getElementById('txtgutter').value="";
alert("Input error");
document.getElementById('txtgutter').focus();
document.getElementById('txtgutter').value="";
return false; 
}
}

function checkcol()
{
var num=document.getElementById('txtcol').value;
var num2=parseFloat(document.getElementById('txtcol').value);
if(document.getElementById('txtcol').value!=null &&document.getElementById('txtcol').value!="")
{
document.getElementById('txtcol').value=num2;
}
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
document.getElementById('txtcol').value="";
alert("Input error");
document.getElementById('txtcol').focus();
document.getElementById('txtcol').value="";
return false; 
}
}

function checkmin()
{

var num=document.getElementById('txtmin').value;
var num2=parseInt(document.getElementById('txtmin').value);

if(num2>59)
{
    alert("RO Min. should not be greater than 59");
    document.getElementById('txtmin').value="";
    document.getElementById('txtmin').focus();
    return false;
}

}



function checkhr()
{

var num=document.getElementById('txthr').value;
var num2=parseInt(document.getElementById('txthr').value);

if(num2>23)
{
    alert("RO Hr. should not be greater than 23");
    document.getElementById('txthr').value="";
    document.getElementById('txthr').focus();
    return false;
}

}
			
			
//-------------------- On preodicity change---------------------------------//



function chkbox_periodicity()
{
SupplimentMaster.blankSession();
    var periodicity=document.getElementById('drperiodicity').value;
    if(periodicity=="0")
    {
        return;
    }
    else
    {
     
      SupplimentMaster.chkperiodicty(periodicity,callbck_periodicitychkbox);
    }
    return false;
}

            
            
      function callbck_periodicitychkbox(response)     
      { 
      var ds=response.value;
      var EditonCode=document.getElementById('drEditonName').value;
     
      if((ds.Tables[0].Rows[0].ValidationCode!="1")&&(ds.Tables[0].Rows[0].ValidationCode!="5"))
      {
           
        document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;

       document.getElementById('CheckBox1').disabled=true;
		document.getElementById('CheckBox2').disabled=true;
		document.getElementById('CheckBox3').disabled=true;
		document.getElementById('CheckBox4').disabled=true;
		document.getElementById('CheckBox5').disabled=true;
		document.getElementById('CheckBox6').disabled=true;
		document.getElementById('CheckBox7').disabled=true;
		document.getElementById('CheckBox8').disabled=true;
            }
            if((ds.Tables[0].Rows[0].ValidationCode=="4")||(ds.Tables[0].Rows[0].ValidationCode=="2"))
            {
            strpub=document.getElementById('drpPubName').value;
                    var response5=SupplimentMaster.fillsupplement(EditonCode)
                    var ds5=response5.value;
                        kchk=0;
                        if(ds5.Tables[0].Rows.length>0)
                        {
                            var sun=ds5.Tables[0].Rows[0].sun;
                            var mon=ds5.Tables[0].Rows[0].mon;
                            var tue=ds5.Tables[0].Rows[0].tue;
                            var wed=ds5.Tables[0].Rows[0].wed;
                            var thu=ds5.Tables[0].Rows[0].thu;
                            var fri=ds5.Tables[0].Rows[0].fri;
                            var sat=ds5.Tables[0].Rows[0].sat;
                            var all=ds5.Tables[0].Rows[0].all;

                        if(sun=="Y")
                            {
                            
                            document.getElementById('CheckBox1').disabled=false;
                            kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox1').disabled=true;
                             document.getElementById('CheckBox1').checked=false;
                          
                            }

                        if(mon=="Y")
                            {
                           
                            document.getElementById('CheckBox2').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox2').disabled=true;
                            document.getElementById('CheckBox2').checked=false;
                          
                            }
                        if(tue=="Y")
                            {
                            
                            document.getElementById('CheckBox3').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox3').disabled=true;
                            document.getElementById('CheckBox3').checked=false;
                          
                            }
                        if(wed=="Y")
                            {
                           kchk++;
                            document.getElementById('CheckBox4').disabled=false;
                            }
                        else
                            {
                            document.getElementById('CheckBox4').disabled=true;
                            document.getElementById('CheckBox4').checked=false;
                          
                            }
                        if(thu=="Y")
                            {
                            
                            document.getElementById('CheckBox5').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox5').disabled=true;
                            document.getElementById('CheckBox5').checked=false;
                          
                            }
                        if(fri=="Y")
                            {
                           
                            document.getElementById('CheckBox6').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox6').disabled=true;
                            document.getElementById('CheckBox6').checked=false;
                          
                            }
                        if(sat=="Y")
                            {
                          
                            document.getElementById('CheckBox7').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox7').disabled=true;
                            document.getElementById('CheckBox7').checked=false;
                          
                            }
                        if(all=="Y")
                            {
//                            document.getElementById('CheckBox1').disabled=false;
//                            document.getElementById('CheckBox2').disabled=false;
//                            document.getElementById('CheckBox3').disabled=false;
//                            document.getElementById('CheckBox4').disabled=false;
//                            document.getElementById('CheckBox5').disabled=false;
//                            document.getElementById('CheckBox6').disabled=false;
//                            document.getElementById('CheckBox7').disabled=false;

                            document.getElementById('CheckBox8').disabled=false;
                            if(sun=="Y")
                            {
                            
                            document.getElementById('CheckBox1').disabled=false;
                            kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox1').disabled=true;
                             document.getElementById('CheckBox1').checked=false;
                          
                            }

                        if(mon=="Y")
                            {
                           
                            document.getElementById('CheckBox2').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox2').disabled=true;
                            document.getElementById('CheckBox2').checked=false;
                          
                            }
                        if(tue=="Y")
                            {
                            
                            document.getElementById('CheckBox3').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox3').disabled=true;
                            document.getElementById('CheckBox3').checked=false;
                          
                            }
                        if(wed=="Y")
                            {
                           kchk++;
                            document.getElementById('CheckBox4').disabled=false;
                            }
                        else
                            {
                            document.getElementById('CheckBox4').disabled=true;
                            document.getElementById('CheckBox4').checked=false;
                          
                            }
                        if(thu=="Y")
                            {
                            
                            document.getElementById('CheckBox5').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox5').disabled=true;
                            document.getElementById('CheckBox5').checked=false;
                          
                            }
                        if(fri=="Y")
                            {
                           
                            document.getElementById('CheckBox6').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox6').disabled=true;
                            document.getElementById('CheckBox6').checked=false;
                          
                            }
                        if(sat=="Y")
                            {
                          
                            document.getElementById('CheckBox7').disabled=false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox7').disabled=true;
                            document.getElementById('CheckBox7').checked=false;
                          
                            }
                            }
                        else
                             {
                            if((sun=="N")&&(mon=="N")&&(tue=="N")&&(wed=="N")&&(thu=="N")&&(fri=="N")&&(sat=="N"))
                            document.getElementById('CheckBox8').disabled=true;
                            else
                            document.getElementById('CheckBox8').disabled=false;
                            }
                        }

                        else
                            {
                            document.getElementById('CheckBox1').disabled=true;
                            document.getElementById('CheckBox2').disabled=true;
                            document.getElementById('CheckBox3').disabled=true;
                            document.getElementById('CheckBox4').disabled=true;
                            document.getElementById('CheckBox5').disabled=true;
                            document.getElementById('CheckBox6').disabled=true;
                            document.getElementById('CheckBox7').disabled=true;
                             document.getElementById('CheckBox8').disabled=true;
                          
                            }
                    
                    document.getElementById('CheckBox8').checked=true;
                    if(document.getElementById('CheckBox1').disabled==false)
                    {
                       document.getElementById('CheckBox1').checked=true;
                       document.getElementById('CheckBox1').disabled=true;
                    }
                    if(document.getElementById('CheckBox2').disabled==false)
                    {
                       document.getElementById('CheckBox2').checked=true;
                       document.getElementById('CheckBox2').disabled=true;
                    }
                    if(document.getElementById('CheckBox3').disabled==false)
                    {
                       document.getElementById('CheckBox3').checked=true;
                       document.getElementById('CheckBox3').disabled=true;
                    }
                    if(document.getElementById('CheckBox4').disabled==false)
                    {
                       document.getElementById('CheckBox4').checked=true;
                       document.getElementById('CheckBox4').disabled=true;
                    }
                    if(document.getElementById('CheckBox5').disabled==false)
                    {
                       document.getElementById('CheckBox5').checked=true;
                       document.getElementById('CheckBox5').disabled=true;
                    }
                    if(document.getElementById('CheckBox6').disabled==false)
                    {
                       document.getElementById('CheckBox6').checked=true;
                       document.getElementById('CheckBox6').disabled=true;
                    }
                    if(document.getElementById('CheckBox7').disabled==false)
                    {
                       document.getElementById('CheckBox7').checked=true;
                       document.getElementById('CheckBox7').disabled=true;
                    }
                       document.getElementById('CheckBox8').checked=true;
                       document.getElementById('CheckBox8').disabled=true;
            }
      if((ds.Tables[0].Rows[0].ValidationCode=="1")||(ds.Tables[0].Rows[0].ValidationCode=="5"))
      {
            strpub=document.getElementById('drpPubName').value;

            //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
        if(strtextd!="sess")
       {
           alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
       SupplimentMaster.fillsupplement(EditonCode,fillchk_callback);
        //SupplimentMaster.enablechkbox(strpub,fillchk_callback);
            return false;
      
          if(document.getElementById('CheckBox1').disabled==true)
          {
           document.getElementById('CheckBox1').disabled=true;
          }
          else
          {
            document.getElementById('CheckBox1').disabled=false;
          }
          
            if(document.getElementById('CheckBox2').disabled==true)
            {
            document.getElementById('CheckBox2').disabled=true;
            }
            else
            {
		    document.getElementById('CheckBox2').disabled=false;
		    }
		    
		    if(document.getElementById('CheckBox3').disabled==true)
		    {
		    document.getElementById('CheckBox3').disabled=true;
		    }
		    else
		    {
		    document.getElementById('CheckBox3').disabled=false;
		    }
		    
		    if(  document.getElementById('CheckBox4').disabled==true)
		    {
		      document.getElementById('CheckBox4').disabled=true;
		    }
		    else
		    {
		    document.getElementById('CheckBox4').disabled=false;
		    }
		    if(  document.getElementById('CheckBox5').disabled==true)
		    {
		      document.getElementById('CheckBox5').disabled=true;
		    }
		    else
		    {
		    document.getElementById('CheckBox5').disabled=false;
		    }
		    
		    if(document.getElementById('CheckBox6').disabled==true)
		    {
		    document.getElementById('CheckBox6').disabled=true;
		    }
		    else
		    {
		    document.getElementById('CheckBox6').disabled=false;
		    }
		    if(document.getElementById('CheckBox7').disabled==true)
		    {
		    document.getElementById('CheckBox7').disabled=true;
		    }
		    else
		    {
		    document.getElementById('CheckBox7').disabled=false;
		    }
		    if( document.getElementById('CheckBox8').disabled==true)
		    {
		     document.getElementById('CheckBox8').disabled=true;
		    }
		    else
		    {
		    document.getElementById('CheckBox8').disabled=false;
		    }
            }
            return false;
       }




    function fillchk_callback(response)
    {
        var ds=response.value;
        kchk=0;
        if(ds.Tables[0].Rows.length>0)
        {
            var sun=ds.Tables[0].Rows[0].sun;
            var mon=ds.Tables[0].Rows[0].mon;
            var tue=ds.Tables[0].Rows[0].tue;
            var wed=ds.Tables[0].Rows[0].wed;
            var thu=ds.Tables[0].Rows[0].thu;
            var fri=ds.Tables[0].Rows[0].fri;
            var sat=ds.Tables[0].Rows[0].sat;
            var all=ds.Tables[0].Rows[0].all;

        if(sun=="Y")
            {
            
            document.getElementById('CheckBox1').disabled=false;
            kchk++;
            }
        else
            {
            document.getElementById('CheckBox1').disabled=true;
             document.getElementById('CheckBox1').checked=false;
          
            }

        if(mon=="Y")
            {
           
            document.getElementById('CheckBox2').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox2').disabled=true;
            document.getElementById('CheckBox2').checked=false;
          
            }
        if(tue=="Y")
            {
            
            document.getElementById('CheckBox3').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox3').disabled=true;
            document.getElementById('CheckBox3').checked=false;
          
            }
        if(wed=="Y")
            {
           kchk++;
            document.getElementById('CheckBox4').disabled=false;
            }
        else
            {
            document.getElementById('CheckBox4').disabled=true;
            document.getElementById('CheckBox4').checked=false;
          
            }
        if(thu=="Y")
            {
            
            document.getElementById('CheckBox5').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox5').disabled=true;
            document.getElementById('CheckBox5').checked=false;
          
            }
        if(fri=="Y")
            {
           
            document.getElementById('CheckBox6').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox6').disabled=true;
            document.getElementById('CheckBox6').checked=false;
          
            }
        if(sat=="Y")
            {
          
            document.getElementById('CheckBox7').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox7').disabled=true;
            document.getElementById('CheckBox7').checked=false;
          
            }
        if(all=="Y")
            {
//            document.getElementById('CheckBox1').disabled=false;
//            document.getElementById('CheckBox2').disabled=false;
//            document.getElementById('CheckBox3').disabled=false;
//            document.getElementById('CheckBox4').disabled=false;
//            document.getElementById('CheckBox5').disabled=false;
//            document.getElementById('CheckBox6').disabled=false;
//            document.getElementById('CheckBox7').disabled=false;
            document.getElementById('CheckBox8').disabled=false;
if(sun=="Y")
            {
            
            document.getElementById('CheckBox1').disabled=false;
            kchk++;
            }
        else
            {
            document.getElementById('CheckBox1').disabled=true;
             document.getElementById('CheckBox1').checked=false;
          
            }

        if(mon=="Y")
            {
           
            document.getElementById('CheckBox2').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox2').disabled=true;
            document.getElementById('CheckBox2').checked=false;
          
            }
        if(tue=="Y")
            {
            
            document.getElementById('CheckBox3').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox3').disabled=true;
            document.getElementById('CheckBox3').checked=false;
          
            }
        if(wed=="Y")
            {
           kchk++;
            document.getElementById('CheckBox4').disabled=false;
            }
        else
            {
            document.getElementById('CheckBox4').disabled=true;
            document.getElementById('CheckBox4').checked=false;
          
            }
        if(thu=="Y")
            {
            
            document.getElementById('CheckBox5').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox5').disabled=true;
            document.getElementById('CheckBox5').checked=false;
          
            }
        if(fri=="Y")
            {
           
            document.getElementById('CheckBox6').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox6').disabled=true;
            document.getElementById('CheckBox6').checked=false;
          
            }
        if(sat=="Y")
            {
          
            document.getElementById('CheckBox7').disabled=false;
             kchk++;
            }
        else
            {
            document.getElementById('CheckBox7').disabled=true;
            document.getElementById('CheckBox7').checked=false;
          
            }
            }
        else
             {
            if((sun=="N")&&(mon=="N")&&(tue=="N")&&(wed=="N")&&(thu=="N")&&(fri=="N")&&(sat=="N"))
            document.getElementById('CheckBox8').disabled=true;
            else
            document.getElementById('CheckBox8').disabled=false;
            }
        }

        else
            {
            document.getElementById('CheckBox1').disabled=true;
            document.getElementById('CheckBox2').disabled=true;
            document.getElementById('CheckBox3').disabled=true;
            document.getElementById('CheckBox4').disabled=true;
            document.getElementById('CheckBox5').disabled=true;
            document.getElementById('CheckBox6').disabled=true;
            document.getElementById('CheckBox7').disabled=true;
             document.getElementById('CheckBox8').disabled=true;
          
            }
          
            return false;
  }
/////////////bhanu
function dateDifference(strDate1,strDate2)
{

datDate1= Date.parse(strDate1);

datDate2= Date.parse(strDate2);

date=(datDate2-datDate1)/(24*60*60*1000);
return;
}

function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}
function LTrim( value )
 {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 
{
	
	return LTrim(RTrim(value));
	
}	
///////////////////////
function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && charCode > 32 && (charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90))
        return false;

    return true;
}

function checkfield(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == "13" || event.keyCode == "9") {


        if (document.activeElement.id == "txtSuppName") {
            if (key == 13 || key == 9) {
                document.getElementById('txtshortname').focus();
                return false;
            }
        }
       
    }


}