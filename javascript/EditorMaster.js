  var sunny="";
var z=0;
var flag="0";
var cityvar;
var cityvarprint;
var chk;
var mod;
//-----------------
//this flag is for permission
var flag="";
var hiddentext;
var auto="";
var hiddentext1="";
var dseditorexecute;
var gbpubname;
var gbeditionname;
var gbeditioncode;
var gbedcountry;
var	gbedcity;
var gbalias;
var gbcirculation;
var gbuom;
var gbcolumn;
var gbheight;
var gbwidth;
var gbarea;
var gbperiodicty;
var gbgutter;
var gbcol_space;
var gbtype;
var k=0;
var l=0;	
var edinsert="0";	
var gbchkperiod;
var lchk=0;
var kchk=0;
var popwin1;
var htext;
var extype;
///************************************************************************************************************//
var editionco;


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


function openfont() {


    if (document.getElementById('lblfont').disabled== true) {
        return false;
    }

    if (document.getElementById('txtEditonCode').value == "") {

        alert("Please Enter Edition Code");
        return false;
    }
    var editioncode = document.getElementById('txtEditonCode').value;
    if (hiddentext == "modify") {

        popwin1 = window.open('fontleading.aspx?editioncode=' + editioncode+'&hiddentext='+hiddentext, 'font', 'resizable=0,toolbar=0,top=244,left=210,width=850px,height=400px');
    
    }
    else {

        popwin1 = window.open('fontleading.aspx?editioncode=' + editioncode+'&hiddentext='+hiddentext, 'font', 'resizable=0,toolbar=0,top=244,left=210,width=850px,height=400px');

    }


    return false;
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





function openedit()
{
        var txtnam=document.getElementById('lbpublicationname').innerHTML;
        var txtcod=document.getElementById('lbeditioncode').innerHTML;
        var txteditionnam=document.getElementById('lbeditionname').innerHTML;
        var txtcountr=document.getElementById('lbCountry').innerHTML;
        var txtcit=document.getElementById('lbcity').innerHTML;
        //var txtalia=document.getElementById('lbalias').innerText;
        var txtperiodicit=document.getElementById('lbperiodicity').innerHTML;
        //var txtcirculatio=document.getElementById('lbcirculation').innerText;
        var txtuo=document.getElementById('lbuom').innerHTML;
        var txtcolum=document.getElementById('lbcolumn').innerHTML;
        var txtheigh=document.getElementById('lbheight').innerHTML;
        var txtwidt=document.getElementById('lbwidth').innerHTML;
        var txtsiz=document.getElementById('lbsize').innerHTML;
        var txtgut=document.getElementById('lbgutterspace').innerHTML;
        var txtcol = document.getElementById('lbcolumnspace').innerHTML;
      
        
        
if(document.getElementById('lbedit').disabled==false)
{
if((document.getElementById('drpPubName').value=="0")&&(txtnam.indexOf("*")>=0))
 {
    alert('Please Select Publication Name');
    document.getElementById('drpPubName').focus();
    return false;
 }
 if(document.getElementById('drpeditiontype').value=="0")
 {
 alert('Please Select Edition Type');
    document.getElementById('drpeditiontype').focus();
    return false;
 }
if((document.getElementById('txtEditonCode').value=="")&& (document.getElementById('hiddenauto').value!=1)&&(txtcod.indexOf("*")>=0))
    {
     alert('Please Enter The Edition Code');
    document.getElementById('txtEditonCode').focus();
    //return false;
      return false;
   }
  else
     {
     var editcode=document.getElementById('txtEditonCode').value;
     }
  if((document.getElementById('txtEditionName').value=="")&&(txteditionnam.indexOf("*")>=0))
    {
         alert('Please Enter The Edition Name');
         document.getElementById('txtEditionName').focus();
         return false;
    }
    else
     {
     var EditionName=document.getElementById('txtEditionName').value;
     }
     
   if((document.getElementById('txtcountry').value=="0")&&(txtcountr.indexOf("*")>=0))
    {
         alert('Please Select the Country');
         document.getElementById('txtcountry').focus();
         return false;
    }
    else
     {
      var country=document.getElementById('txtcountry').value;
     }
    if((document.getElementById('drpcity').value=="0")&&(txtcit.indexOf("*")>=0))
    {
         alert('Please Select Publication Center');
         document.getElementById('drpcity').focus();
         return false;
    }
     else
     {
     var CityName=document.getElementById('drpcity').value;
     }
    if((document.getElementById('drpprintcent').value=="0")&&(document.getElementById('lblprintcent').innerHTML.indexOf("*")>=0))
    {
         alert('Please Select Physical Printing Center');
         if(document.getElementById('drpprintcent').disabled==false)
         document.getElementById('drpprintcent').focus();
         return false;
    }
   
   if((document.getElementById('drperiodicity').value=="0")&&(txtperiodicit.indexOf("*")>=0))
        {
            alert('Please Select The Periodicity');
            document.getElementById('drperiodicity').focus();
            return false;
        }
    else
         {
            var periodicity=document.getElementById('drperiodicity').value;
            //EditorMaster.chkperiodicty(periodicity,openedit_popup);
       var res= EditorMaster.chkperiodicty(periodicity,"foredition", "", "", "");
       openedit_popup(res)
              //EditorMaster.chkperiodicty(periodicity, "foredition", "", "", "",callbck_periodicitychkbox);
             return false;
              }
    if((document.getElementById('txtgutterspace').value=="")&&(txtgut.indexOf("*")>=0))
    {
         alert('Please Enter Gutter Width');
         document.getElementById('txtgutterspace').focus();
         return false;
    }
     else
     {
     var GutterSpace=document.getElementById('txtgutterspace').value;
     }
     if((document.getElementById('txtcolumnspace').value=="")&&(txtcol.indexOf("*")>=0))
    {
         alert('Please Enter Column Width');
         document.getElementById('txtcolumnspace').focus();
         return false;
    }
     else
     {
     var ColumnSpace=document.getElementById('txtcolumnspace').value;
     }
     //........
   if(document.getElementById('txthr').value!="")
{
    var hr=document.getElementById('txthr').value;
}

if(document.getElementById('txtmin').value!="")
{
var min=document.getElementById('txtmin').value;
}



if(document.getElementById('txtproduction').value!="")
{
var prod=document.getElementById('txtproduction').value;
}
if(document.getElementById('txthr').value=="")
{
    if(document.getElementById('txtmin').value=="")
    {
        if(document.getElementById('txtproduction').value=="")
        {
            alert("Please Enter the value for either 'RO Time' or 'Production Days Before' or both ");
            document.getElementById('txtproduction').focus();
            return false;
        }
    }
}  
     //......  
            return false;
      }
   
}
function openedit_popup(response)
{
//document.getElementById('pnl1').style.display="block";
   var ds=response.value;
if((ds.Tables[0].Rows[0].ValidationCode!="1")&&(ds.Tables[0].Rows[0].ValidationCode!="5"))
    {
    if(document.getElementById('txtEditonCode').value=="")
    {
    alert('Please Enter The Edition Code');
    //document.getElementById('txtcurrcode').focus();s
    return false;
    }
        var editcode=document.getElementById('txtEditonCode').value;
        var periodicity=document.getElementById('drperiodicity').value;
   if(document.getElementById('txtAlias').value=="")
   {
       alert('Please Enter The Edition Alias');
        //document.getElementById('txtcurrcode').focus();s
        return false;
    }
   
        var alias=document.getElementById('txtAlias').value;
	var validationco=ds.Tables[0].Rows[0].ValidationCode;

    //var editcode1,periodicity1,alias1;
for ( var index = 0; index < 200; index++ ) 
  { 
  
popwin1=window.open('popupedit.aspx?periodicity1='+periodicity+'&validationco='+validationco+' &htext='+htext+' &show='+show+' &alias1='+alias+'   &editcode1='+editcode,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');
popwin1.focus();

return false;
}
return false;
}
else
{
alert("Whenever Periodicity is Daily or Weekly ,Edition Issue Date is not required.");
return false;
}

}





//***************This function is used when new Button is clicked to enable all disable fields...***************//
function editionnew()
{
		chk=0;
		sunny="0";
		htext = "new";
		extype = "new";
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

EditorMaster.blankSession();
		document.getElementById('drpPubName').value="0";
		document.getElementById('drpcity').value="0";
		document.getElementById('drpprintcent').value="0";
		document.getElementById('txtEditionName').value="";
		document.getElementById('txtAlias').value="";
		document.getElementById('txtEditonCode').value="";
		document.getElementById('txtcountry').value="0";
		document.getElementById('txtcirculation').value="";
		document.getElementById('druom').value="0";
		document.getElementById('txtcolumn').value="";
		document.getElementById('txtsizeheight').value="";
		document.getElementById('txtsizewidth').value="";
		document.getElementById('txtarea').value="";
	    document.getElementById('drperiodicity').value="0";
	    document.getElementById('txtgutterspace').value="";
		document.getElementById('txtcolumnspace').value="";
		document.getElementById('txthr').value="";
		document.getElementById('txtmin').value="";
		document.getElementById('txtproduction').value="";
		document.getElementById('drpeditiontype').value="0";
		document.getElementById('txtsegment').value = "";
		document.getElementById('txtgrpcod').value = "";
		document.getElementById('txterp').value = "";
		document.getElementById('txtshortname').value = "";
		document.getElementById('ddlspeciality').value="";
		if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtEditonCode').disabled=true;
		          document.getElementById('txtAlias').disabled=true;
	
    	          }
		 else
		           {
		           document.getElementById('txtEditonCode').disabled=false;
		          // document.getElementById('txtAlias').disabled=false;
	
    	           }
    	           
    	           /*chane ankur*/
    	document.getElementById('txtnoofcol').value="";          
    	document.getElementById('txtnoofcol').disabled=false;
		///////////////////////////////////////
		
		document.getElementById('ddlspeciality').disabled=false;
		document.getElementById('drpPubName').disabled=false;
		document.getElementById('drpcity').disabled=false;
		document.getElementById('drpprintcent').disabled=false;
		document.getElementById('txtEditionName').disabled=false;
		document.getElementById('txtcountry').disabled=false;
		document.getElementById('txtcirculation').disabled=false;
		document.getElementById('druom').disabled=false;
		document.getElementById('txtcolumn').disabled=false;
		document.getElementById('txtsizeheight').disabled=false;
		document.getElementById('txtsizewidth').disabled=false;
		document.getElementById('txtarea').disabled=true;
	    document.getElementById('drperiodicity').disabled=false;
	    document.getElementById('lbedit').disabled = false;
document.getElementById('lblcirc').disabled = false;
	    document.getElementById('lblfont').disabled = false; 
	    document.getElementById('txtgutterspace').disabled=false;
	    document.getElementById('txtcolumnspace').disabled=false;
	    document.getElementById('txthr').disabled=false;
	    document.getElementById('txtmin').disabled=false;
	    document.getElementById('txtproduction').disabled=false;
	    document.getElementById('drpeditiontype').disabled = false;
	    document.getElementById('txtsegment').disabled = false;
	    document.getElementById('txtgrpcod').disabled = false
	    document.getElementById('txterp').disabled = false
	    document.getElementById('txtshortname').disabled = false;
	  
	      document.getElementById('btn').disabled = false;
	    
	      if(document.getElementById('hiddenauto').value==1)
                    {
                    document.getElementById('drpPubName').focus();
                    }
                    else
                    {
                    document.getElementById('drpPubName').focus();
                    }
		
		
		//document.getElementById('txtEditonCode').disabled=false;

		chkstatus(FlagStatus);
		hiddentext="new";	
		show="2";
		document.getElementById('btnSave').disabled = false;	
		document.getElementById('btnNew').disabled = true;	
		document.getElementById('btnQuery').disabled=true;
	
		
		enablecheck();
		flag=0;
		
		/*document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=false;
		document.getElementById('btnQuery').disabled=true;
		
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;*/
		
		setButtonImages();
		document.getElementById('txtcolumn').value = '8';
		document.getElementById('txtsizeheight').value = '51';
		document.getElementById('txtsizewidth').value = '33';
		 
		document.getElementById('txtgutterspace').value = '0';
		document.getElementById('txtcolumnspace').value = '0';
		 
		
		document.getElementById('txtproduction').value = '0';
		document.getElementById('txtarea').value = '1683';
        
		document.getElementById('lblfont').disabled = false; 	
		return false;
}
//**************This function is used to enable all checkboxes************//
function enablecheck
()
{
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;

		document.getElementById('CheckBox1').disabled=false;
		document.getElementById('CheckBox2').disabled=false;
		document.getElementById('CheckBox3').disabled=false;
		document.getElementById('CheckBox4').disabled=false;
		document.getElementById('CheckBox5').disabled=false;
		document.getElementById('CheckBox6').disabled=false;
		document.getElementById('CheckBox7').disabled=false;
		document.getElementById('CheckBox8').disabled=false;
		return false;
}
//**************This function is used to delete the record from database*************//
function editiondelete()
{
		chk=0;
		var PubName=document.getElementById('drpPubName').value;
		var CityName=document.getElementById('drpcity').value;
		var EditionName=document.getElementById('txtEditionName').value;
		var Alias=document.getElementById('txtAlias').value;
		var EditonCode=document.getElementById('txtEditonCode').value.toUpperCase();
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
	    var country=document.getElementById('txtcountry').value;
		var circulation=document.getElementById('txtcirculation').value;
		var uom=document.getElementById('druom').value;
		var column=document.getElementById('txtcolumn').value;
		var height=document.getElementById('txtsizeheight').value;
		var width=document.getElementById('txtsizewidth').value;
		var area=document.getElementById('txtarea').value;
        var gut_space=document.getElementById('txtgutterspace').value;
        var col_space=document.getElementById('txtcolumnspace').value;
        var type = document.getElementById('drpeditiontype').value;
        var segment = document.getElementById('hdnsegment').value;
        var grpsav = document.getElementById('txtgrpcod').value;
        var SHORTNAME = document.getElementById('txtshortname').value;
        
        
		boolReturn = confirm("Are you sure you want to delete this record?");
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
		if(boolReturn==1)
		{
		    //alert(xmlObj.childNodes(0).childNodes(2).text);
			//alert("Data Deleted Successfully");
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
var ip2=document.getElementById('ip1').value;		
EditorMaster.deleteedition(EditonCode,compcode,userid,ip2);

EditorMaster.Select(gbpubname, gbedcity, gbeditionname, gbalias, gbeditioncode, compcode, userid, gbedcountry, gbcirculation, gbuom, gbcolumn, gbheight, gbwidth, gbarea, gbperiodicty, '', '', gbtype, segment, grpsav, SHORTNAME, document.getElementById('txterp').value, call_Exedelcall);
		
			
		}     
		else
		{
			return false;
		}
		return false;
}
//*************This is call back response function for deleting the record**************//	
function call_Exedelcall(res)
{
	
	dseditorexecute= res.value;
	len=dseditorexecute.Tables[0].Rows.length;	
	if(dseditorexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drpPubName').value="0";
		document.getElementById('drpcity').value="0";
		document.getElementById('drpprintcent').value="0";
		document.getElementById('txtEditionName').value="";
		document.getElementById('txtAlias').value="";
		document.getElementById('txtEditonCode').value="";
		document.getElementById('txtcountry').value="0";
		document.getElementById('txtcirculation').value="";
		document.getElementById('druom').value="0";
		document.getElementById('txtcolumn').value="";
		document.getElementById('txtsizeheight').value="";
		document.getElementById('txtsizewidth').value="";
		document.getElementById('txtarea').value="";
	     document.getElementById('drperiodicity').value="0";
	    document.getElementById('txtgutterspace').value="";
		document.getElementById('txtcolumnspace').value="";		
		document.getElementById('txthr').value="";
		document.getElementById('txtmin').value="";
		document.getElementById('txtproduction').value="";
		document.getElementById('drpeditiontype').value=="0";
		/*change ankur*/
		document.getElementById('txtnoofcol').value == "";
		document.getElementById('txtshortname').value == "";
		////////////////////////////////////
		disablecheck();
		
		editioncancel('EditorMaster');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
        editionco=dseditorexecute.Tables[0].Rows[0].Edition_Code;
        document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[0].Edition_Code;
        document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[0].Pub_Code;
        //document.getElementById('drpcity').value=ds.Tables[0].Rows[0].City_Code;
        document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[0].Edition_Name;
        document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[0].Edition_Alias;
        document.getElementById('txtcountry').value=dseditorexecute.Tables[0].Rows[0].Country_Code;
        document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[0].No_Of_Circulation;
        document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[0].SHORT_NAME;
		//document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[0].UOM_Code;
		/*new change ankur 27 feb*/
		
		for(var t=0;t<document.getElementById('druom').options.length;t++)
		{
		     document.getElementById('druom').options[t].selected=false;
		    
		}
		
		/*new change ankur 27 feb*/
		if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[0].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                    
                    }
                }
            
            
            }
		}
		////////////////
		document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[0].No_Of_Columns;
		document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[0].Size_Height;
		document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[0].Size_Width;
		document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[0].Edition_Area;
	    document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[0].Preodicity_Code;
		document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[0].Gutter_Space;
		document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[0].Column_Space;
		document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[0].RO_hr;	
		if(dseditorexecute.Tables[0].Rows[0].RO_min!=null && dseditorexecute.Tables[0].Rows[0].RO_min!="null")
		{
		    document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[0].RO_min;
		}
		else
		{
		    document.getElementById('txtmin').value="";
		}
		
		if(dseditorexecute.Tables[0].Rows[0].SPENAME!=null)
            {
            document.getElementById('ddlspeciality').value=dseditorexecute.Tables[0].Rows[0].SPENAME;
            }
            else
            {
             document.getElementById('ddlspeciality').value="";
            }
		
		document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[0].Production;
		document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[0].Edition_Type;
		
		/*change ankur*/
		document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[0].No_Of_Collumn;
		///////////////////////////////////
		
			cityvar=dseditorexecute.Tables[0].Rows[0].City_Code;
			cityvarprint=dseditorexecute.Tables[0].Rows[0].PRINT_CENT;
			addcount(dseditorexecute.Tables[0].Rows[0].Country_Code);
		 //sunny

			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
            z=0;

		var akh=document.getElementById('txtEditionName').value;
			fillcheckboxes(akh);
	}
	else
	{
		document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[z].Edition_Code;
		document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[z].Pub_Code;
		//document.getElementById('drpcity').value=ds.Tables[0].Rows[z].City_Code;
		document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[z].Edition_Name;
		document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[z].Edition_Alias;
		document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[z].No_Of_Circulation;
		document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[z].SHORT_NAME;
		//document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[z].UOM_Code;
		/*new change ankur 27 feb*/
		
		for(var t=0;t<document.getElementById('druom').options.length;t++)
		{
		     document.getElementById('druom').options[t].selected=false;
		    
		}
		
		/*new change ankur 27 feb*/
		if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[z].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                    
                    }
                }
            
            
            }
		}
		////////////////
		
		document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[z].No_Of_Columns;
		document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[z].Size_Height;
		document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[z].Size_Width;
		document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[z].Edition_Area;
	     document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[z].Preodicity_Code;
		document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[z].Gutter_Space;
		document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[z].Column_Space;
		document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[z].RO_hr;	
		
		if(dseditorexecute.Tables[0].Rows[z].RO_min!=null && dseditorexecute.Tables[0].Rows[z].RO_min!="null")
		{
		    document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[z].RO_min;
		}
		else
		{
		    document.getElementById('txtmin').value="";
		}
		document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[z].Production;
		document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[z].Edition_Type;
		
		/*change ankur*/
		document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[z].No_Of_Collumn;
		///////////////////////////////////
		
		var akh=document.getElementById('txtEditionName').value;
			fillcheckboxes(akh);
				cityvar=dseditorexecute.Tables[0].Rows[z].City_Code;
				cityvarprint=dseditorexecute.Tables[0].Rows[z].PRINT_CENT;
			addcount(dseditorexecute.Tables[0].Rows[z].Country_Code);
		
	}
	setButtonImages();
	return false;
}
//******************This function is used to clear all fields ************//

function editioncancel(formname)
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

EditorMaster.blankSession();
		chk=0;
		hiddentext="clear";
		show="0";
		document.getElementById('drpPubName').value="0";
		document.getElementById('ddlspeciality').value="0";
		document.getElementById('drpcity').value="0";
		document.getElementById('drpprintcent').value="0";
		document.getElementById('txtEditionName').value="";
		document.getElementById('txtAlias').value="";
		document.getElementById('txtEditonCode').value="";
		document.getElementById('txtcountry').value="0";
        document.getElementById('txtcirculation').value="";
        document.getElementById('druom').value="0";
		document.getElementById('txtcolumn').value="";
		document.getElementById('txtsizeheight').value="";
		document.getElementById('txtsizewidth').value="";
		document.getElementById('txtarea').value="";
	    document.getElementById('drperiodicity').value="0";
		document.getElementById('txtgutterspace').value="";
		document.getElementById('txtcolumnspace').value="";
		document.getElementById('txthr').value="";
		document.getElementById('txtmin').value="";
		document.getElementById('txtproduction').value="";
	    document.getElementById('drpeditiontype').value="0";
	    document.getElementById('hiddeneditalias').value="";
        document.getElementById('hiddeneditdate').value="";
        document.getElementById('hiddeneditaddate').value = "";
        document.getElementById('hiddenedityear').value = "";
      
        document.getElementById('txtshortname').value = "";
	    /*change ankur*/
    	    document.getElementById('txtnoofcol').value="";
    	    document.getElementById('txtnoofcol').disabled=true;
    	    ////////////////////////////////////
    	    document.getElementById('txtsegment').value = "";
    	    document.getElementById('txtgrpcod').value = "";

    	    document.getElementById('txterp').value = "";
    	    document.getElementById('hdnsegment').value = "";
    	    
		document.getElementById('drpPubName').disabled=true;
		document.getElementById('ddlspeciality').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('drpprintcent').disabled=true;
		document.getElementById('txtEditionName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('txtEditonCode').disabled=true;
		document.getElementById('txtcountry').disabled=true;
		document.getElementById('txtcirculation').disabled=true;
		document.getElementById('druom').disabled=true;
		document.getElementById('txtcolumn').disabled=true;
		document.getElementById('txtsizeheight').disabled=true;
		document.getElementById('txtsizewidth').disabled=true;
		document.getElementById('txtarea').disabled=true;
	    document.getElementById('drperiodicity').disabled=true;
	    document.getElementById('lbedit').disabled = true;
	    document.getElementById('lblcirc').disabled = true;
	    document.getElementById('lblfont').disabled = true; 
	    document.getElementById('txtgutterspace').disabled=true;
		document.getElementById('txtcolumnspace').disabled=true;
		document.getElementById('txthr').disabled=true;
		document.getElementById('txtmin').disabled=true;
		document.getElementById('drpeditiontype').disabled=true;
		document.getElementById('txtproduction').disabled = true;
		document.getElementById('txtshortname').disabled = true;
		
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;
		
		disablecheck();
		edition="save";
		var id;
		 if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkperiodicity.aspx?page="+edition+"&edition="+edition+"&date1="+edition+"&date2="+edition+"&date3="+edition, false);
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
				xml.Open( "GET","chkperiodicity.aspx?page="+edition+"&edition="+edition+"&date1="+edition+"&date2="+edition+"&date3="+edition, false );
		        xml.Send();
		        }
		   
		//getPermission('EditorMaster');
		givebuttonpermission(formname);
		setButtonImages();
		if(document.getElementById('btnNew').disabled==false)
		    document.getElementById('btnNew').focus();
		/*document.getElementById('btnNew').disabled=false;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;*/
		
		return false;
}

//*****************This function is used to modify the existing record except Edition Code*********************/
function editionmodify()
{
		flag=1;
		mod=document.getElementById('txtEditionName').value;
		chk=0;
		sunny="0";
		htext="mod";
	   /* document.getElementById('btnNew').disabled=true;*/
		//document.getElementById('btnSave').disabled=false;
		/*document.getElementById('btnQuery').disabled=true;
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
			updateStatus();
			
			chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
		hiddentext="modify";
		//document.getElementById('btnSave').disabled=false;
	
		show="2";
		document.getElementById('drpPubName').disabled=true;
		document.getElementById('drpcity').disabled=false;
		document.getElementById('drpprintcent').disabled=false;
		if(document.getElementById('drpeditiontype').value=="Main Edition")
		{
		document.getElementById('txtEditionName').disabled=true;
		}
		else
		{
		document.getElementById('txtEditionName').disabled=false;
		}
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('txtEditonCode').disabled=true;
		document.getElementById('txtcountry').disabled=false;
		document.getElementById('txtcirculation').disabled=false;
		document.getElementById('druom').disabled=false;
		document.getElementById('txtcolumn').disabled=false;
		document.getElementById('txtsizeheight').disabled=false;
		document.getElementById('txtsizewidth').disabled=false;
		document.getElementById('txtarea').disabled=true;
		document.getElementById('txtcountry').disabled=true;
		////enable by mohit////
	    document.getElementById('drperiodicity').disabled=false;   // periodicity disabled
	    ////end//////
	    document.getElementById('drpcity').disabled=true;
	    document.getElementById('lbedit').disabled = false;
	    document.getElementById('lblcirc').disabled = false;
	    document.getElementById('lblfont').disabled = false; 
	    document.getElementById('txtgutterspace').disabled=false;
		document.getElementById('txtcolumnspace').disabled=false;
		document.getElementById('txthr').disabled=false;
		document.getElementById('txtmin').disabled=false;
		document.getElementById('txtproduction').disabled=false;
		document.getElementById('drpeditiontype').disabled = true;
		document.getElementById('txtsegment').disabled = false;
		document.getElementById('txtshortname').disabled = false;
		
		/*change ankur*/
		document.getElementById('txtnoofcol').disabled=false;
		/////////////////////
		document.getElementById('txtsegment').disabled = false;
		document.getElementById('txtgrpcod').disabled = false;
		document.getElementById('txterp').disabled = false;
		document.getElementById('ddlspeciality').disabled = false;
		document.getElementById('btn').disabled=false;
		 strpub=document.getElementById('drpPubName').value;
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
EditorMaster.enablechkbox(strpub,fillchk_callback);
        }
        
    	var periodicity=document.getElementById('drperiodicity').value;
    	/*new change ankur */
    	
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
EditorMaster.chkperiodicty(periodicity, "foredition", "", "", "",callbck_periodicitychkbox);
        
       // document.getElementById('hiddeneditdate').value="01/01/1900";
        //document.getElementById('hiddeneditaddate').value="01/01/1900";
        //********************************************************************
 
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

//**************This function is used to save all fields data into Database**************//
function editionsave()
{
        chk=0;
         //hiddentext="save";
		//hiddentext="new";
		//alert(document.getElementById('lbgutterspace'));
		document.getElementById('txtEditonCode').value=trim(document.getElementById('txtEditonCode').value);
        document.getElementById('txtEditionName').value=trim(document.getElementById('txtEditionName').value);
                var txtnam=document.getElementById('lbpublicationname').innerHTML;
        var txtcod=document.getElementById('lbeditioncode').innerHTML;
        var txteditionnam=document.getElementById('lbeditionname').innerHTML;
        var txtcountr=document.getElementById('lbCountry').innerHTML;
        var txtcit=document.getElementById('lbcity').innerHTML;
        //var txtalia=document.getElementById('lbalias').innerText;
        var txtperiodicit=document.getElementById('lbperiodicity').innerHTML;
        //var txtcirculatio=document.getElementById('lbcirculation').innerText;
        var txtuo=document.getElementById('lbuom').innerHTML;
        var txtcolum=document.getElementById('lbcolumn').innerHTML;
        var txtheigh=document.getElementById('lbheight').innerHTML;
        var txtwidt=document.getElementById('lbwidth').innerHTML;
        var txtsiz=document.getElementById('lbsize').innerHTML;
        var txtgut=document.getElementById('lbgutterspace').innerHTML;
        var txtcol=document.getElementById('lbcolumnspace').innerHTML;
        var periodicity=document.getElementById('lbnoofcol').innerHTML;
        var compcode = document.getElementById('hiddencompcode').value;

        var txtpro = document.getElementById('lbproduction').innerHTML; 
        var userid=document.getElementById('hiddenuserid').value;
        if ((document.getElementById('drpPubName').value=="0" )&&(txtnam.indexOf("*")>=0))
            {
                alert("Please Select Publication Name");
                document.getElementById('drpPubName').focus();
                return false;
            }
            else if(document.getElementById('drpeditiontype').value=="0" )
            {
                alert("Please Select Edition Type");
                document.getElementById('drpeditiontype').focus();
                return false;
            }
        else if ((document.getElementById('txtEditonCode').value=="")&& (document.getElementById('hiddenauto').value!=1)&&(txtcod.indexOf("*")>=0))
            {
                alert("Please Enter Editon Code");
                document.getElementById('txtEditonCode').focus();
                return false;
            }
        else if((document.getElementById('txtEditionName').value=="")&&(txteditionnam.indexOf("*")>=0))
            {
                alert("Please Enter Edition Name");
                document.getElementById('txtEditionName').focus();
                return false;
            }
       
       
        else if((document.getElementById('txtcountry').value=="0")&&(txtcountr.indexOf("*")>=0))
            {
                alert("Please Select Country");
                document.getElementById('txtcountry').focus();
                return false;
            }

        else if ((document.getElementById('drpcity').value=="0")&&(txtcit.indexOf("*")>=0))
            {
                alert("Please Select Publication Center");
                document.getElementById('drpcity').focus();
                return false;
            }
             else if ((document.getElementById('drpprintcent').value=="0") && document.getElementById('lblprintcent').style.display!="none" )
            {
                alert("Please Select Physical Printing Center");
                document.getElementById('drpprintcent').focus();
                return false;
            }
       
              else if ((document.getElementById('drperiodicity').value=="0")&&(txtperiodicit.indexOf("*")>=0))
            {
                alert("Please Select Periodicity");
                document.getElementById('drperiodicity').focus();
                return false;
            }
            /*nea change ankur 11 feb*/
               else if ((document.getElementById('txtnoofcol').value=="")&&(periodicity.indexOf("*")>=0) && document.getElementById('lbnoofcol').style.display!="none")
            {
                alert("Please Select Priority");
                document.getElementById('txtnoofcol').focus();
                return false;
            }
                 else if((document.getElementById('hiddensolorate').value!="solo")&&(document.getElementById('txtcirculation').value=="") && document.getElementById('lbcirculation').style.display!="none")
            {
                alert("Please Enter No. of Circulations");
                document.getElementById('txtcirculation').focus();
                return false;
            }
          
             else if ((document.getElementById('druom').value=="0")&&(txtuo.indexOf("*")>=0) && document.getElementById('lbuom').style.display!="none")
            {
                alert("Please Enter UOM");
                document.getElementById('druom').focus();
                return false;
            }
             else if((document.getElementById('txtcolumn').value=="")&&(txtcolum.indexOf("*")>=0))
            {
                    alert("Please Enter No. Of Columns");
                    document.getElementById('txtcolumn').focus();
                    return false;
            }
            
             else if((document.getElementById('txtsizeheight').value=="")&&(txtheigh.indexOf("*")>=0))
            {
                alert("Please Enter Height");
                document.getElementById('txtsizeheight').focus();
                return false;
            }
             else if((document.getElementById('txtsizewidth').value=="")&&(txtwidt.indexOf("*")>=0))
            {
                alert("Please Enter Width");
                document.getElementById('txtsizewidth').focus();
                return false;
            }
            //xxxx
            
            else if((document.getElementById('txtgutterspace').value=="")&&(txtgut.indexOf("*")>=0))
            {
                alert("Please Enter Gutter Width");
                document.getElementById('txtgutterspace').focus();
                return false;
            }
            else if((document.getElementById('txtcolumnspace').value=="")&&(txtcol.indexOf("*")>=0))
            {
                alert("Please Enter Column Width");
                document.getElementById('txtcolumnspace').focus();
                return false;
            }

            if ((document.getElementById('txtproduction').value == "") && (txtpro.indexOf("*") >= 0)) {
                alert('Please Enter Production');
                document.getElementById('txtproduction').focus();
                return false;
            }
            
            
             if ((document.getElementById('txtshortname').value == "") && (txtpro.indexOf("*") >= 0)) {
                alert('Please Enter Short Name');
                document.getElementById('txtshortname').focus();
                return false;
            }
            var result=EditorMaster.flagadtype();
            if(result.value == "" ||  result.value == null){
              alert('Please Click On Submit Button');
                document.getElementById('btn').focus();
                return false;        
            }

            

if(document.getElementById('txthr').value=="")
{
    if(document.getElementById('txtmin').value=="")
    {
        if(document.getElementById('txtproduction').value=="")
        {
            alert("Please Enter the value for either 'RO Time' or 'Production Days Before' or both ");
            document.getElementById('txtproduction').focus();
            return false;
        }
    }
}  
            //..........
            /*new change ankur 27feb*/
            var pu_blic=document.getElementById('drpPubName').value
            var period_edit=document.getElementById('txtnoofcol').value
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
       
       
       
       
       
       
EditorMaster.chkperiodicty(periodicity,pu_blic,period_edit,flag,document.getElementById('txtEditonCode').value,callbck_periodicitysave);
                 document.getElementById('txtshortname').disabled = true;
                 return false;
             
       }

            
            
      function callbck_periodicitysave(response)     
      { 
      var ds=response.value;
      var EditonCode=document.getElementById('txtEditonCode').value;
      
      /*new change ankur 27 feb*/
      if(document.getElementById('lbnoofcol').style.display!="none")
      if(ds.Tables[1].Rows.length>0)
      {
        alert("This edition Priority has been assigned to "+ds.Tables[1].Rows[0].edition_alias+" ");
        document.getElementById('txtnoofcol').focus();
        return false;
      
      }

      if ((ds.Tables[0].Rows[0].ValidationCode == "1") || (ds.Tables[0].Rows[0].ValidationCode == "5" || ds.Tables[0].Rows[0].ValidationCode == "6"))
      {
           
         if(document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
            {
            alert("Please Select Edition Day First...");
            return false;
            }
          else
            {
                call_finallysavemodify();
                return false;
            }
            
            
          }
          gbchkperiod=ds.Tables[0].Rows[0].ValidationCode;
          
          if((ds.Tables[0].Rows[0].ValidationCode=="2")||(ds.Tables[0].Rows[0].ValidationCode=="3")||(ds.Tables[0].Rows[0].ValidationCode=="4"))
          {
          	if(hiddentext=="modify")
          	{
          	    EditorMaster.chkperiodicty_edition(EditonCode,call_finallychkperiodictyjs);
                return false;       
          	}
          	else
          	{	
           EditorMaster.chkperiodicty_edition(EditonCode,call_finallychkperiodictyjs);
           return false; 
           }
          
          }
          
           call_finallysavemodify();
        
          return false; 
            
        }
        
        
        
     function  call_finallychkperiodicty(res)
     {
      
          var dschk=res.value;
          
var txteditionname=document.getElementById('hiddeneditalias').value ;
var txtdate=document.getElementById('hiddeneditdate').value;
var txtaddate=document.getElementById('hiddeneditaddate').value;
var year=document.getElementById('hiddenedityear').value ;


 //var year=document.getElementById('drpyear').value
// var dschk=res.value;
            if((txtdate=="")&&(txtaddate==""))
          {
          if(dschk.Tables[0].Rows.length==0)
          {
                  alert("Please Fill Edition Issue Date");
          return false;
          } 
          } 
          else if((gbchkperiod=="2")&&((dschk.Tables[0].Rows[0].Date_Edition=="")||(dschk.Tables[0].Rows[0].Date_Edition==null)))
          {
          alert("Please Fill First Cycle Date In Edition Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="3") &&((dschk.Tables[0].Rows[0].AdditionalDate_Edit=="")||(dschk.Tables[0].Rows[0].AdditionalDate_Edit==null)))
          {
          alert("Please Fill Second Cycle Date In Edition Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="4") &&((dschk.Tables[0].Rows[0].AdditionalDate_Edit=="")||(dschk.Tables[0].Rows[0].AdditionalDate_Edit==null)||(dschk.Tables[0].Rows[0].Date_Edition=="")||(dschk.Tables[0].Rows[0].Date_Edition==null)))
          {
          alert("Please Fill First and Second Cycle Date In Edition Issue Date Pop-Up");
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
				var CityName=document.getElementById('drpcity').value;
				var CityNamePrint=document.getElementById('drpprintcent').value;
				var EditionName=document.getElementById('txtEditionName').value;
				var Alias=document.getElementById('txtAlias').value;
				var EditonCode=document.getElementById('txtEditonCode').value;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var akh=document.getElementById('txtEditonCode').value;
                var country=document.getElementById('txtcountry').value;
				var circulation=document.getElementById('txtcirculation').value;
				//var uom=document.getElementById('druom').value;
				/*new change ankur 27 feb*/
				var uom="";
				var tem_uom="";
				for(var ui=0;ui<document.getElementById('druom').options.length;ui++)
				{
				    if(document.getElementById('druom').options[ui].selected==true)
				    {
				        if(document.getElementById('druom').options[ui].value!="0")
				        {
				            tem_uom=document.getElementById('druom').options[ui].value;
				            if(uom=="")
				            {
				                uom=tem_uom;
				            }
				            else
				            {
				                uom=uom+","+tem_uom;
				            
				            }
				        }
				    
				    }
				
				}
				if(uom=="")
				{
				uom=uom;
				}
				else{
				uom=uom+",";
				}
				
				///////////////////////////////
		        var column=document.getElementById('txtcolumn').value;
		        var height=document.getElementById('txtsizeheight').value;
		        var width=document.getElementById('txtsizewidth').value;
		        var area=document.getElementById('txtarea').value;
        	    var  periodicity=document.getElementById('drperiodicity').value;
	            var ColumnSpace=document.getElementById('txtcolumnspace').value;
                var GutterSpace=document.getElementById('txtgutterspace').value;
                var hr=document.getElementById('txthr').value;       
                var min=document.getElementById('txtmin').value;
                var prod=document.getElementById('txtproduction').value;
                var type=document.getElementById('drpeditiontype').value;
                /*change ankur*/
                var noofcol=parseFloat(document.getElementById('txtnoofcol').value);
                ////////////////////////////////////////////////////
                var segment = document.getElementById('hdnsegment').value;
                var grpsav = document.getElementById('txtgrpcod').value;
                var SHORTNAME = document.getElementById('txtshortname').value;
		       var length = document.getElementById('ddlspeciality').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('ddlspeciality').options[li].selected == true) {
                if (document.getElementById('ddlspeciality').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('ddlspeciality').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('ddlspeciality').options[li].value;
                }

            }
        }
            var specialityname=abc+ ",";
        
        if (flag==1)
        {
        /*change ankur*/
         selectedtionday(EditonCode,'0');
         var ip2 = document.getElementById('ip1').value;

         var epaper = document.getElementById('txterp').value;
            EditorMaster.modify(PubName,CityName,EditionName,Alias,EditonCode,compcode,userid,country,circulation,uom,column,height,width,area,periodicity,GutterSpace,ColumnSpace,hr,min,prod,type,noofcol,CityNamePrint,ip2,segment,grpsav,SHORTNAME,epaper,specialityname);
           
            dseditorexecute.Tables[0].Rows[z].Pub_Code=document.getElementById('drpPubName').value;
		    dseditorexecute.Tables[0].Rows[z].Edition_Alias=document.getElementById('txtAlias').value;
		    dseditorexecute.Tables[0].Rows[z].Edition_Name=document.getElementById('txtEditionName').value;
		    dseditorexecute.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountry').value;
		    dseditorexecute.Tables[0].Rows[z].City_Code=document.getElementById('drpcity').value;
	        dseditorexecute.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountry').value;
		    dseditorexecute.Tables[0].Rows[z].No_Of_Circulation=document.getElementById('txtcirculation').value;
		    dseditorexecute.Tables[0].Rows[z].PRINT_CENT=document.getElementById('drpprintcent').value;
		    //dseditorexecute.Tables[0].Rows[z].UOM_Code=document.getElementById('druom').value;  uom
		    /*new change ankur 27 feb*/
		    dseditorexecute.Tables[0].Rows[z].UOM_Code=uom;
		    //////////////////////////
		    dseditorexecute.Tables[0].Rows[z].No_Of_Columns=document.getElementById('txtcolumn').value;
		    dseditorexecute.Tables[0].Rows[z].Size_Height=document.getElementById('txtsizeheight').value;
		    dseditorexecute.Tables[0].Rows[z].Size_Width=document.getElementById('txtsizewidth').value;
		    dseditorexecute.Tables[0].Rows[z].Edition_Area=document.getElementById('txtarea').value;
		    dseditorexecute.Tables[0].Rows[z].Preodicity_Code=document.getElementById('drperiodicity').value;
		    dseditorexecute.Tables[0].Rows[z].Gutter_Space=document.getElementById('txtgutterspace').value;
		    dseditorexecute.Tables[0].Rows[z].Column_Space=document.getElementById('txtcolumnspace').value; 
		    dseditorexecute.Tables[0].Rows[z].RO_hr=document.getElementById('txthr').value; 
		    dseditorexecute.Tables[0].Rows[z].RO_min=document.getElementById('txtmin').value; 
		    dseditorexecute.Tables[0].Rows[z].Production=document.getElementById('txtproduction').value; 
		    dseditorexecute.Tables[0].Rows[z].Edition_Type=document.getElementById('drpeditiontype').value; 
		    dseditorexecute.Tables[0].Rows[z].PRINT_CENT=document.getElementById('drpprintcent').value; 
		    
		    /*change ankur*/
		    dseditorexecute.Tables[0].Rows[z].No_Of_Collumn = document.getElementById('txtnoofcol').value;
		    dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE = document.getElementById('txtsegment').value;  
		    //////////////////////////////////////////////////
		    
                    var x=dseditorexecute.Tables[0].Rows.length;
                    y=z;	
                    if (z==0)
                    {
                    document.getElementById('btnfirst').disabled=true;
                    document.getElementById('btnprevious').disabled=true;
                    }

                    if(z==(dseditorexecute.Tables[0].Rows.length-1))
                    {
                    document.getElementById('btnnext').disabled=true;
                    document.getElementById('btnlast').disabled=true;
                    }
		    
        	     txteditionname=document.getElementById('hiddeneditalias').value;
                 txtdate=document.getElementById('hiddeneditdate').value;
                 txtaddate=document.getElementById('hiddeneditaddate').value;
               
               year=  document.getElementById('hiddenedityear').value 
              
                 if(hiddentext!="modify")
                 {
                   
             // popupedit.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,EditonCode,call_insert);
                EditorMaster.popinsert(txteditionname,txtdate,txtaddate,compcode,userid,EditonCode,year);	
                }
        	      
     
                	document.getElementById('hiddeneditalias').value="";
                    document.getElementById('hiddeneditdate').value="";
                    document.getElementById('hiddeneditaddate').value="";
                       document.getElementById('hiddenedityear').value="";

        updateStatus();

        document.getElementById('CheckBox1').disabled=true;
        document.getElementById('CheckBox2').disabled=true;
        document.getElementById('CheckBox3').disabled=true;
        document.getElementById('CheckBox4').disabled=true;
        document.getElementById('CheckBox5').disabled=true;
        document.getElementById('CheckBox6').disabled=true;
        document.getElementById('CheckBox7').disabled=true;
        document.getElementById('CheckBox8').disabled=true;
      	
        	
        		        
				document.getElementById('drpPubName').disabled=true;
				document.getElementById('drpcity').disabled=true;
				document.getElementById('drpprintcent').disabled=true;
				document.getElementById('txtEditionName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('txtEditonCode').disabled=true;
				document.getElementById('txtcountry').disabled=true;
				document.getElementById('txtcirculation').disabled=true;
				document.getElementById('druom').disabled=true;
		        document.getElementById('txtcolumn').disabled=true;
		        document.getElementById('txtsizeheight').disabled=true;
		        document.getElementById('txtsizewidth').disabled=true;
		        document.getElementById('txtarea').disabled=true;
        	    document.getElementById('drperiodicity').disabled=true;
        	    document.getElementById('txtgutterspace').disabled=true;
        	    document.getElementById('txtcolumnspace').disabled=true;
        	    document.getElementById('txthr').disabled=true;
        	    document.getElementById('txtmin').disabled=true;
        	    document.getElementById('txtproduction').disabled=true;
        	    document.getElementById('drpeditiontype').disabled=true;
        	    document.getElementById('lbedit').disabled = false;
        	    document.getElementById('lblcirc').disabled = false;
        	    document.getElementById('lblfont').disabled = false; 
        	    document.getElementById('txtshortname').disabled = true;
        	    document.getElementById('ddlspeciality').disabled = true;
        	    
        	    /*change ankur*/
        	    document.getElementById('txtnoofcol').disabled=true;
        	    //////////////////////
        	    document.getElementById('txtsegment').disabled = true;
        	    var grpsav = document.getElementById('txtgrpcod').disabled = true;

        	    document.getElementById('txterp').disabled = true;
        	 //sunny
        	 var len=dseditorexecute.Tables[0].Rows.length-1;
        	 if(z==0)
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			}
			else if(z==len)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;			
			}
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
        	    //alert(xmlObj.childNodes(0).childNodes(1).text);
        //alert("Updated Successfully");
        flag=0;
setButtonImages();
        return false;
        }
       
else
{
var compcode=document.getElementById('hiddencompcode').value;
var userid = document.getElementById('hiddenuserid').value;
var editionalias = document.getElementById('txtAlias').value;
if(EditonCode!="")
		 
{
    EditorMaster.editioncodecheck(EditonCode, compcode, userid, editionalias, callsave); 
            
            document.getElementById('btnNew').disabled=true;
            document.getElementById('btnSave').disabled=false;
            document.getElementById('btnQuery').disabled=false;
            document.getElementById('btnModify').disabled=true;
            document.getElementById('btnExecute').disabled=true;
            document.getElementById('btnDelete').disabled=true;
            document.getElementById('btnCancel').disabled=false;
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            document.getElementById('btnExit').disabled=false;
setButtonImages();
return false;
}
else
{
    str=document.getElementById('txtEditionName').value;
    strpub=document.getElementById('drpPubName').value;
    strcity=document.getElementById('drpcity').value;
            
    EditorMaster.editmaster(str,strpub,strcity, fillcall_edit);
		  
 return false;
 }     
return false;
}
}
//***********This function is call back response function to save record*******************//
function callsave(res)
{
			var ds=res.value;
			if (ds == null) {
			    alert(res.error.description);
			    return false;
			}
			if (ds.Tables[1].Rows.length > 0) {
			    alert("This Alias Name is already in use.");
			    return false;
			}
			if(ds.Tables[0].Rows.length==0)
			{
				var PubName=document.getElementById('drpPubName').value;
				var CityName=document.getElementById('drpcity').value;
				var CityNamePrint=document.getElementById('drpprintcent').value;
				var EditionName=document.getElementById('txtEditionName').value;
				var Alias=document.getElementById('txtAlias').value;
				var EditonCode=document.getElementById('txtEditonCode').value;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var akh=document.getElementById('txtEditonCode').value;
                var country=document.getElementById('txtcountry').value;
				var circulation=document.getElementById('txtcirculation').value;
				//var uom=document.getElementById('druom').value;
				/*new change ankur 27 feb*/
				var uom="";
				var tem_uom="";
				for(var ui=0;ui<document.getElementById('druom').options.length;ui++)
				{
				    if(document.getElementById('druom').options[ui].selected==true)
				    {
				        if(document.getElementById('druom').options[ui].value!="0")
				        {
				            tem_uom=document.getElementById('druom').options[ui].value;
				            if(uom=="")
				            {
				                uom=tem_uom;
				            }
				            else
				            {
				                uom=uom+","+tem_uom;
				            
				            }
				        }
				    
				    }
				
				}
				if(uom=="")
				{
				uom=uom;
				}
				else{
				uom=uom+",";
				}
		        var column=document.getElementById('txtcolumn').value;
		        var height=document.getElementById('txtsizeheight').value;
		        var width=document.getElementById('txtsizewidth').value;
		        var area=document.getElementById('txtarea').value;
        	    var  periodicity=document.getElementById('drperiodicity').value;
        	    var ColumnSpace=document.getElementById('txtcolumnspace').value;
                var GutterSpace=document.getElementById('txtgutterspace').value;
	            var hr=document.getElementById('txthr').value;
	            var min=document.getElementById('txtmin').value;
	            var prod=document.getElementById('txtproduction').value;
                var type=document.getElementById('drpeditiontype').value;
                /*change ankur*/
                
                var noofcol=parseFloat(document.getElementById('txtnoofcol').value);
                //////////////////////////////////////////////////////////////
                var segment = document.getElementById('hdnsegment').value;
                var grpsav = document.getElementById('txtgrpcod').value;
                var SHORTNAME = document.getElementById('txtshortname').value;
                                
                var length = document.getElementById('ddlspeciality').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('ddlspeciality').options[li].selected == true) {
                if (document.getElementById('ddlspeciality').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('ddlspeciality').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('ddlspeciality').options[li].value;
                }

            }
        }
            var spename=abc+ ",";
				//selectedtionday(akh);
				/*change ankur*/
                var ip2 = document.getElementById('ip1').value;

                var epaper = document.getElementById('txterp').value;
                EditorMaster.insert(PubName, CityName, EditionName, Alias, EditonCode, compcode, userid, country, circulation, uom, column, height, width, area, periodicity, GutterSpace, ColumnSpace, hr, min, prod, type, noofcol, CityNamePrint, ip2, segment, grpsav, SHORTNAME, epaper,spename);
               // mainsave(EditonCode);
				selectedtionday(EditonCode,'1');
				///////////////
				//alert(xmlObj.childNodes(0).childNodes(0).text);
				 if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
				//alert("Saved Successfully");
				
				document.getElementById('drpPubName').value="0";
				document.getElementById('ddlspeciality').value="0";
				document.getElementById('drpcity').value="0";
				document.getElementById('drpprintcent').value="0";
				document.getElementById('txtEditionName').value="";
				document.getElementById('txtAlias').value="";
				document.getElementById('txtEditonCode').value="";
			    document.getElementById('txtcountry').value="0";
		        document.getElementById('txtcirculation').value="";
		        document.getElementById('druom').value="0";
		        document.getElementById('txtcolumn').value="";
		        document.getElementById('txtsizeheight').value="";
		        document.getElementById('txtsizewidth').value="";
		        document.getElementById('txtarea').value="";
        	    document.getElementById('drperiodicity').value="0";
        	    document.getElementById('txtgutterspace').value="";
        	    document.getElementById('txtcolumnspace').value=""; 
        	    document.getElementById('txthr').value=""; 
        	    document.getElementById('txtmin').value="";
        	    document.getElementById('txtproduction').value="";
        	    document.getElementById('txtshortname').value="";
        	    document.getElementById('drpeditiontype').value="0"; 
        	     txteditionname=document.getElementById('hiddeneditalias').value;
                 txtdate=document.getElementById('hiddeneditdate').value;
                 txtaddate=document.getElementById('hiddeneditaddate').value;
                 year=document.getElementById('hiddenedityear').value;
                 
               //  year=document.getElementById('drpyear').value;
                 
                 
                      
                      /*change ankur*/
                      document.getElementById('txtnoofcol').value="";
                      //////////////////////////////////////////////
                      document.getElementById('txtsegment').value = "";
                      document.getElementById('txtgrpcod').value = "";
                      document.getElementById('txterp').value = "";
                   
             // popupedit.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,EditonCode,call_insert);
             if(txtdate!="")
                    EditorMaster.popinsert(txteditionname,txtdate,txtaddate,compcode,userid,EditonCode,year);	
        	
        		    
        		    
        		document.getElementById('hiddeneditalias').value="";
                 document.getElementById('hiddeneditdate').value="";
                document.getElementById('hiddeneditaddate').value="";
                var id;
                edition="save";
		 if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkperiodicity.aspx?page="+edition+"&edition="+edition+"&date1="+edition+"&date2="+edition+"&date3="+edition, false );
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
				xml.Open( "GET","chkperiodicity.aspx?page="+edition+"&edition="+edition+"&date1="+edition+"&date2="+edition+"&date3="+edition, false );
		        xml.Send();
		        }
		      //  var ds=xml.responseText;

                 document.getElementById('ddlspeciality').disabled=true;
				document.getElementById('drpPubName').disabled=true;
				document.getElementById('drpcity').disabled=true;
				document.getElementById('drpprintcent').disabled=true;
				document.getElementById('txtEditionName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('txtEditonCode').disabled=true;
				document.getElementById('txtcountry').disabled=true;
				document.getElementById('txtcirculation').disabled=true;
				document.getElementById('druom').disabled=true;
		        document.getElementById('txtcolumn').disabled=true;
		        document.getElementById('txtsizeheight').disabled=true;
		        document.getElementById('txtsizewidth').disabled=true;
		        document.getElementById('txtarea').disabled=true;
        	    document.getElementById('drperiodicity').disabled=true;
        	    document.getElementById('txtgutterspace').disabled=true;
        	    document.getElementById('txtcolumnspace').disabled=true;
        	    document.getElementById('txthr').disabled=true;
        	    document.getElementById('txtmin').disabled=true;
        	    document.getElementById('txtproduction').disabled=true;
        	    document.getElementById('drpeditiontype').disabled=true;
        	    document.getElementById('lbedit').disabled = true;
        	    document.getElementById('lblcirc').disabled = true;
        	    document.getElementById('lblfont').disabled = false; 
        	    
        	    /*change ankur*/
        	    document.getElementById('txtnoofcol').disabled=true;
        	    /////////////////////////
        	    
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
				setButtonImages();
			
				
				
				return false;
			}
			else
			{
				alert("This Edition Code already Exists");
				document.getElementById('txtEditonCode').value="";
                document.getElementById('txtEditonCode').focus();
				return false;
			}
			
			editioncancel('EditorMaster');
			return false;
}


function fillcall_edit(res)
		{
		var ds=res.value;
		 var newstr;
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Edition name has already assigned in this publication Center!! ");
		  	 document.getElementById('txtEditionName').focus();
		    return false;
		    }
		 if((document.getElementById('txtcountry').value!="0")&&(document.getElementById('drpcity').value!="0"))
	 	{
	 	fillalias();
	 	return false;
	 	}
	 	else
	 	{
	 	document.getElementById('txtAlias').value="";
	 	return false;
	 	}
		    
		    return false;
		 }


function fillcall_editmodify(res)
{
var ds=res.value;
		
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Edition name has already assigned in this publication Center!! ");
		  	 document.getElementById('txtEditionName').focus();
		    return false;
		    }
		if((document.getElementById('txtcountry').value!="0")&&(document.getElementById('drpcity').value!="0"))
	 	{
	 	var PubName=document.getElementById('drpPubName').value;
		var CityName=document.getElementById('drpcity').value;
		var CityNamePrint=document.getElementById('drpprintcent').value;
		var EditionName=document.getElementById('txtEditionName').value;
		var Alias=document.getElementById('txtAlias').value;
		var EditonCode=document.getElementById('txtEditonCode').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var akh=document.getElementById('txtEditonCode').value;
        var country=document.getElementById('txtcountry').value;
		var circulation=document.getElementById('txtcirculation').value;
		var uom=document.getElementById('druom').value;
		var column=document.getElementById('txtcolumn').value;
		var height=document.getElementById('txtsizeheight').value;
		var width=document.getElementById('txtsizewidth').value;
		var area=document.getElementById('txtarea').value;
        var  periodicity=document.getElementById('drperiodicity').value;
        var ColumnSpace=document.getElementById('txtcolumnspace').value;
        var GutterSpace=document.getElementById('txtgutterspace').value;	
	    var hr=document.getElementById('txthr').value;	    
	    var min=document.getElementById('txtmin').value;	    
	    var prod=document.getElementById('txtproduction').value;
	    var type=document.getElementById('drpeditiontype').value;
	    var segment = document.getElementById('hdnsegment').value;
	    var grpsav = document.getElementById('txtgrpcod').value;

	    var epaper = document.getElementById('txterp').value;
	    
	 	EditorMaster.modify(PubName,CityName,EditionName,Alias,EditonCode,compcode,userid,country,circulation,uom,column,height,width,area,periodicity,GutterSpace,ColumnSpace,hr,min,prod,type,CityNamePrint,segment,grpsav,epaper);
        dseditorexecute.Tables[0].Rows[z].Pub_Code=document.getElementById('drpPubName').value;
		dseditorexecute.Tables[0].Rows[z].Edition_Alias=document.getElementById('txtAlias').value;
		dseditorexecute.Tables[0].Rows[z].Edition_Name=document.getElementById('txtEditionName').value;
		dseditorexecute.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountry').value;
		dseditorexecute.Tables[0].Rows[z].City_Code=document.getElementById('drpcity').value;
		dseditorexecute.Tables[0].Rows[z].PRINT_CENT=document.getElementById('drpprintcent').value;
	    dseditorexecute.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountry').value;
		dseditorexecute.Tables[0].Rows[z].No_Of_Circulation=document.getElementById('txtcirculation').value;
		dseditorexecute.Tables[0].Rows[z].UOM_Code=document.getElementById('druom').value;
		dseditorexecute.Tables[0].Rows[z].No_Of_Columns=document.getElementById('txtcolumn').value;
		dseditorexecute.Tables[0].Rows[z].Size_Height=document.getElementById('txtsizeheight').value;
		dseditorexecute.Tables[0].Rows[z].Size_Width=document.getElementById('txtsizewidth').value;
		dseditorexecute.Tables[0].Rows[z].Edition_Area=document.getElementById('txtarea').value;
		dseditorexecute.Tables[0].Rows[z].Preodicity_Code=document.getElementById('drperiodicity').value;
	    dseditorexecute.Tables[0].Rows[z].Gutter_Space=document.getElementById('txtgutterspace').value;   
     	dseditorexecute.Tables[0].Rows[z].Column_Space=document.getElementById('txtcolumnspace').value;          
     	dseditorexecute.Tables[0].Rows[z].RO_hr=document.getElementById('txthr').value;                 
        dseditorexecute.Tables[0].Rows[z].RO_min=document.getElementById('txtmin').value;                 
        dseditorexecute.Tables[0].Rows[z].Production=document.getElementById('txtproduction').value;  
        dseditorexecute.Tables[0].Rows[z].Edition_Type=document.getElementById('drpeditiontype').value;               
       
       
       


        updateStatus();

        document.getElementById('CheckBox1').disabled=true;
        document.getElementById('CheckBox2').disabled=true;
        document.getElementById('CheckBox3').disabled=true;
        document.getElementById('CheckBox4').disabled=true;
        document.getElementById('CheckBox5').disabled=true;
        document.getElementById('CheckBox6').disabled=true;
        document.getElementById('CheckBox7').disabled=true;
        document.getElementById('CheckBox8').disabled=true;

        	
        		        
				document.getElementById('drpPubName').disabled=true;
				document.getElementById('drpcity').disabled=true;
				document.getElementById('drpprintcent').disabled=true;
				document.getElementById('txtEditionName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('txtEditonCode').disabled=true;
				document.getElementById('txtcountry').disabled=true;
				document.getElementById('txtcirculation').disabled=true;
				document.getElementById('druom').disabled=true;
		        document.getElementById('txtcolumn').disabled=true;
		        document.getElementById('txtsizeheight').disabled=true;
		        document.getElementById('txtsizewidth').disabled=true;
		        document.getElementById('txtarea').disabled=true;
        	    document.getElementById('drperiodicity').disabled=true;
        	    document.getElementById('txtgutterspace').disabled=true;
        	    document.getElementById('txtcolumnspace').disabled=true;
        	    document.getElementById('txthr').disabled=true;
        	    document.getElementById('txtmin').disabled=true;
        	    document.getElementById('txtproduction').disabled=true;
        	    document.getElementById('drpeditiontype').disabled=true;
        	
              //alert(xmlObj.childNodes(0).childNodes(1).text);
if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
			
       // alert("Updated Successfully");
        flag=0;
        setButtonImages();
        return false;
		    }
		 

}

//************This function is used to execute the record according to particular query*****************//
function editionexecute()
{
    chk = 0;
   extype = "query";		   
		   /* document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnCancel').disabled=false;*/
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			//document.getElementById('btnExit').disabled=false;
			
			updateStatus();
		
			document.getElementById('drpPubName').disabled=true;
			document.getElementById('ddlspeciality').disabled=true;
			document.getElementById('drpcity').disabled=true;
			document.getElementById('drpprintcent').disabled=true;
			document.getElementById('txtEditionName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('txtEditonCode').disabled=true;
		    document.getElementById('txtcountry').disabled=true;
		    document.getElementById('txtcirculation').disabled=true;
	        document.getElementById('druom').disabled=true;
		    document.getElementById('txtcolumn').disabled=true;
		    document.getElementById('txtsizeheight').disabled=true;
		    document.getElementById('txtsizewidth').disabled=true;
		     document.getElementById('txtarea').disabled=true;
        	 document.getElementById('drperiodicity').disabled=true;
        	 document.getElementById('lbedit').disabled = false;
        	 document.getElementById('lblcirc').disabled = false;
        	 document.getElementById('lblfont').disabled = false; 
        	 document.getElementById('txtgutterspace').disabled=true;
        	 document.getElementById('txtcolumnspace').disabled=true;
             document.getElementById('txthr').disabled=true;
        	    document.getElementById('txtmin').disabled=true;
        	    document.getElementById('txtproduction').disabled=true;
        	    document.getElementById('drpeditiontype').disabled=true;
        	    document.getElementById('txtsegment').disabled = true;
        	    document.getElementById('txtgrpcod').disabled = true;
        	    document.getElementById('txterp').disabled = true;
        	    /*change ankur*/
        	    document.getElementById('txtnoofcol').disabled=true;
        	    
        	    
        	    
        	    
        	    
        	    //////////////////////
        	       
			var PubName=document.getElementById('drpPubName').value;
			gbpubname=PubName;

			var CityName=document.getElementById('drpcity').value;
			gbedcity=CityName;
			
			var EditionName=document.getElementById('txtEditionName').value;
			gbeditionname=EditionName;
			
			var Alias=document.getElementById('txtAlias').value;
			gbalias=Alias;
			var EditonCode=document.getElementById('txtEditonCode').value.toUpperCase();
			gbeditioncode=EditonCode;
			var circulation=document.getElementById('txtcirculation').value;
            gbcirculation=circulation;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var country=document.getElementById('txtcountry').value;
			gbedcountry=country;
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
		var type=document.getElementById('drpeditiontype').value;
		gbtype = type;
		var segment = document.getElementById('hdnsegment').value;
		var grpsav = document.getElementById('txtgrpcod').value;
		var SHORTNAME = document.getElementById('txtshortname').value;		
		
		//var gs=document.getElementByID('txtgutterspace').value;
//	    var GutterSpace=document.getElementByID('txtgutterspace').value;
//	    gbgutter=GutterSpace;
//	    var ColumnSpace=document.getElementByID('txtcolumnspace').value;
//	    gbcol_space=ColumnSpace;
			
			hiddentext="execute";
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
       EditorMaster.Select(PubName, CityName, EditionName, Alias, EditonCode, compcode, userid, country, circulation, uom, column, height, width, area, periodicty, "", "", type, segment, grpsav, SHORTNAME, document.getElementById('txterp').value, call_Execute);
			
			document.getElementById('btnfirst').disabled=true;			
			document.getElementById('btnprevious').disabled=true;
			
			return false;
}

//***************This function is call back response for execute function to execute according to query*****************//

function call_Execute(response)
{
		 dseditorexecute=response.value;
		 
		if (dseditorexecute.Tables[0].Rows.length>0)
		{   
		    editionco=dseditorexecute.Tables[0].Rows[0].Edition_Code;
			document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[0].Pub_Code;
			//document.getElementById('drpcity').value=ds.Tables[0].Rows[0].City_Code;
			document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[0].Edition_Name;
			document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[0].Edition_Alias;
			document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[0].Edition_Code;
			document.getElementById('txtcountry').value = dseditorexecute.Tables[0].Rows[0].Country_Code;
			document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[0].SHORT_NAME;
			
            if(dseditorexecute.Tables[0].Rows[0].No_Of_Circulation!=null)
            {
            document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[0].No_Of_Circulation;
            }
            else
            {
             document.getElementById('txtcirculation').value="";
            }
            var adcatlen = document.getElementById('ddlspeciality').options.length;
           for (var t2 = 0; t2 < adcatlen; t2++) {
            document.getElementById('ddlspeciality').options[t2].selected = false;
              }
            if(dseditorexecute.Tables[0].Rows[0].SPENAME!=null)
            {
            var adcat = dseditorexecute.Tables[0].Rows[0].SPENAME;
            var len1 = adcat.split(",");
             for (var a1 = 0; a1 < len1.length; a1++) {
             for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('ddlspeciality').options[j].value == len1[a1]) {
                document.getElementById('ddlspeciality').options[j].selected = true;
                                       }
                                    }
                               }
            }
            else
            {
             document.getElementById('ddlspeciality').value="";
            }
            //document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[0].UOM_Code;
            /*new change ankur 27 feb*/
            if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[0].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                        
                    
                    }
                }
            
            
            }
            document.getElementById('druom').options[0].selected=false
            }
            
            
            
		    document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[0].No_Of_Columns;
		    document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[0].Size_Height;
		    document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[0].Size_Width;
		    document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[0].Edition_Area;
		     document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[0].Preodicity_Code;
		    document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[0].Gutter_Space;
    	    document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[0].Column_Space;
    	    document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[0].RO_hr;
    	    if(dseditorexecute.Tables[0].Rows[0].RO_min!=null && dseditorexecute.Tables[0].Rows[0].RO_min!="null")
    	    {
    	        document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[0].RO_min;
    	    }
    	    else
    	    {
    	        document.getElementById('txtmin').value="";
    	    }
    	    
    	   if (dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE != null) {
		    document.getElementById('txtsegment').value = getcentername(dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE);
		$('hdnsegment').value =dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE;
		}
		else {
		    document.getElementById('txtsegment').value = "";
		    $('hdnsegment').value ="";
		}
		if(dseditorexecute.Tables[0].Rows[z].GROUPCODE!=null)
		 document.getElementById('txtgrpcod').value=dseditorexecute.Tables[0].Rows[z].GROUPCODE;
		else
		    document.getElementById('txtgrpcod').value = "";



		if (dseditorexecute.Tables[0].Rows[z].EDTN_URL != null)
		    document.getElementById('txterp').value = dseditorexecute.Tables[0].Rows[z].EDTN_URL;
		else
		    document.getElementById('txterp').value = "";
		
    	    
    	    
    	    document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[0].Production;
    	    document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[0].Edition_Type;
    	    
    	    /*change ankur*/
    	    document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[0].No_Of_Collumn;
    	    ////////////////////////////////////
    	    document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
    	    
    	    if(dseditorexecute.Tables[0].Rows.length==1)
    	    {
    	    document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=true;
		
    	    }
	
		
			var akh=document.getElementById('txtEditionName').value;
			cityvar=dseditorexecute.Tables[0].Rows[0].City_Code;
			cityvarprint=dseditorexecute.Tables[0].Rows[0].PRINT_CENT;
			addcount(dseditorexecute.Tables[0].Rows[0].Country_Code);
				
			
			fillcheckboxes(akh);
			z=0;
		}
		else
		{
			alert("Search Criteria Does Not Exist");
			editioncancel('EditorMaster');
			return false;
		}
		setButtonImages();
		return false;
}
//**************This function is used to enable the fields on which query can be executed****************//
function editionquery()
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

EditorMaster.blankSession();
	/*document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=false;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;*/
        chk=1;
		z=0;
		chkstatus(FlagStatus);
			hiddentext="query";

			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('lbedit').disabled=true; 
	  document.getElementById('lblcirc').disabled=true; 
		document.getElementById('drpPubName').value="0";
		document.getElementById('ddlspeciality').value="0";
		document.getElementById('drpcity').value="0";
		document.getElementById('drpprintcent').value="0";
		document.getElementById('txtEditionName').value="";
		document.getElementById('txtAlias').value="";
		document.getElementById('txtEditonCode').value="";
		document.getElementById('txtcountry').value="0";
		document.getElementById('druom').value="0";
		document.getElementById('txtcolumn').value="";
		document.getElementById('txtsizeheight').value="";
		document.getElementById('txtsizewidth').value="";
		document.getElementById('txtarea').value="";
		document.getElementById('txtcirculation').value="";
        document.getElementById('txtgutterspace').value="";
        document.getElementById('txtcolumnspace').value="";
        document.getElementById('drperiodicity').value="0";
       	document.getElementById('txthr').value="";
       	document.getElementById('txtmin').value="";
       	document.getElementById('txtproduction').value="";
       	document.getElementById('drpeditiontype').value = "0";
       	document.getElementById('txtsegment').value = "";
       	document.getElementById('txtgrpcod').value = "";
       	document.getElementById('txterp').value = "";    
			        document.getElementById('txtcolumn').disabled=true;
		            document.getElementById('txtsizeheight').disabled=true;
		            document.getElementById('txtsizewidth').disabled=true;
		            document.getElementById('txtarea').disabled=true;
        
        /*change ankur*/
        document.getElementById('txtnoofcol').value="";
        document.getElementById('txtnoofcol').disabled=false;
        ////////////////////////////////////////////////////	
		

		document.getElementById('drpPubName').disabled=false;
		document.getElementById('ddlspeciality').disabled=true;
		document.getElementById('drpcity').disabled=false;
		document.getElementById('txtEditionName').disabled=false;
		document.getElementById('txtAlias').disabled=false;
		document.getElementById('txtEditonCode').disabled=false;
		document.getElementById('txtcountry').disabled=false;
        document.getElementById('druom').disabled=false;
		document.getElementById('txtcirculation').disabled=true;
		document.getElementById('drperiodicity').disabled=true;
		document.getElementById('txtgutterspace').disabled=true;
		document.getElementById('txtcolumnspace').disabled=true;
		document.getElementById('txthr').disabled=true;
		document.getElementById('txtmin').disabled=true;
		document.getElementById('txtproduction').disabled=true;
		document.getElementById('drpeditiontype').disabled=false;
		//document.getElementById('lbedit').disabled=false;
		document.getElementById('txtsegment').disabled = false;
		document.getElementById('txtgrpcod').disabled = false;
		document.getElementById('txterp').disabled = false;
		document.getElementById('txtshortname').value = '';
		document.getElementById('txtshortname').disabled = true;
			
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
//**************This function is used to fetch first record*******************//

//*************This function is call back response for first record***************//txtnoofcol
function editionfirst()
{
		z=0;
		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
           
            if (httpRequest.readyState == 4) 
            {
               
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    
                    if(browser!="Microsoft Internet Explorer")
                    {
                        
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       }

       EditorMaster.blankSession();
editionco=dseditorexecute.Tables[0].Rows[0].Edition_Code;
		document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[0].Pub_Code;
		document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[0].Edition_Name;
		document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[0].Edition_Alias;
		document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[0].Edition_Code;
		document.getElementById('txtcountry').value = dseditorexecute.Tables[0].Rows[0].Country_Code;
		document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[0].SHORT_NAME;
		
		
		if(dseditorexecute.Tables[0].Rows[0].No_Of_Circulation!=null)
		{
		document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[0].No_Of_Circulation;
		}
		else
		{
		document.getElementById('txtcirculation').value="";
		}
		//document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[0].UOM_Code;
		/*new change ankur 27 feb*/
		
		for(var t=0;t<document.getElementById('druom').options.length;t++)
		{
		     document.getElementById('druom').options[t].selected=false;
		    
		}
		
		/*new change ankur 27 feb*/
		 if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[0].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                    
                    }
                }
            
            
            }
		}
		////////////////
		document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[0].No_Of_Columns;
		document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[0].Size_Height;
		document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[0].Size_Width;
		document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[0].Edition_Area;
		document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[0].Preodicity_Code;
		document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[0].Gutter_Space;
		document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[0].Column_Space;
		document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[0].RO_hr;
		if(dseditorexecute.Tables[0].Rows[0].RO_min!=null && dseditorexecute.Tables[0].Rows[0].RO_min!="null")
		{
		    document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[0].RO_min;
		}
		else
		{
		    document.getElementById('txtmin').value="";
		}
		document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[0].Production;
		document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[0].Edition_Type;
		
		/*change ankur*/
		document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[0].No_Of_Collumn;
		///////////////////
		if (dseditorexecute.Tables[0].Rows[0].SEGMENT_CODE != null) {
		    document.getElementById('txtsegment').value = getcentername(dseditorexecute.Tables[0].Rows[0].SEGMENT_CODE);
		}
		else {
		    document.getElementById('txtsegment').value = "";
		}
		if(dseditorexecute.Tables[0].Rows[0].GROUPCODE!=null)
		 document.getElementById('txtgrpcod').value=dseditorexecute.Tables[0].Rows[0].GROUPCODE;
		else
		    document.getElementById('txtgrpcod').value = "";


		if (dseditorexecute.Tables[0].Rows[0].EDTN_URL != null)
		    document.getElementById('txterp').value = dseditorexecute.Tables[0].Rows[0].EDTN_URL;
		else
		    document.getElementById('txterp').value = "";
		
		 var adcatlen = document.getElementById('ddlspeciality').options.length;
           for (var t2 = 0; t2 < adcatlen; t2++) {
            document.getElementById('ddlspeciality').options[t2].selected = false;
              }
		
		if(dseditorexecute.Tables[0].Rows[0].SPENAME!=null)
            {
            var adcat = dseditorexecute.Tables[0].Rows[0].SPENAME;
            var len1 = adcat.split(",");
             for (var a1 = 0; a1 < len1.length; a1++) {
             for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('ddlspeciality').options[j].value == len1[a1]) {
                document.getElementById('ddlspeciality').options[j].selected = true;
                                       }
                                    }
                               }
            
            }
            else
            {
             document.getElementById('ddlspeciality').value="";
            }
	        cityvar=dseditorexecute.Tables[0].Rows[0].City_Code;
	         cityvarprint=dseditorexecute.Tables[0].Rows[0].PRINT_CENT;
		    addcount(dseditorexecute.Tables[0].Rows[0].City_Code);
			
		var akh=document.getElementById('txtEditonCode').value;
		fillcheckboxes(akh);
		updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;	
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnlast').disabled=false;
		setButtonImages();
		return false;	
}

//*************This function is used to fetch next record*******************///
function editionnext()
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

EditorMaster.blankSession();
		chk=0;
		var PubName=document.getElementById('drpPubName').value;
		var CityName=document.getElementById('drpcity').value;
		var EditionName=document.getElementById('txtEditionName').value;
		var Alias=document.getElementById('txtAlias').value;
		var EditonCode=document.getElementById('txtEditonCode').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var country=document.getElementById('txtcountry').value;
		var circulation = document.getElementById('txtcirculation').value;
		var SHORTNAME = document.getElementById('txtshortname').value;


		EditorMaster.Selectfnpl(PubName, CityName, EditionName, Alias, EditonCode, compcode, userid, country, circulation, SHORTNAME,call_Next);

		document.getElementById('drpPubName').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtEditionName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('txtEditonCode').disabled=true;
		document.getElementById('txtcountry').disabled=true;
        document.getElementById('txtcolumn').disabled=true;
        document.getElementById('txtsizeheight').disabled=true;
        document.getElementById('txtsizewidth').disabled=true;
        document.getElementById('txtarea').disabled=true;
        document.getElementById('txtgutterspace').disabled=true;
        document.getElementById('txtcolumnspace').disabled=true;
        document.getElementById('txthr').disabled=true;
		document.getElementById('txtmin').disabled=true;
		document.getElementById('txtproduction').disabled=true;
		document.getElementById('drpeditiontype').disabled = true;
		document.getElementById('txtshortname').disabled = true;
        
		return false;
}
//*************This function is call back response for fetching next record*****************//
function call_Next(response)
{
	z++;
	//ds=response.value;
	var x=dseditorexecute.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(dseditorexecute.Tables[0].Rows.length != z && z !=-1)
		{
		editionco=dseditorexecute.Tables[0].Rows[z].Edition_Code;
			document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[z].Pub_Code;
			document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[z].Edition_Name;
			document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[z].Edition_Alias;
			document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[z].Edition_Code;
			document.getElementById('txtcountry').value = dseditorexecute.Tables[0].Rows[z].Country_Code;
			document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[z].SHORT_NAME;
		    if(dseditorexecute.Tables[0].Rows[z].No_Of_Circulation!=null)
		    {
		    document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[z].No_Of_Circulation;
		    }
		    else
		    {
		       document.getElementById('txtcirculation').value="";
		    }
		  	//document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[z].UOM_Code;
		  	/*new change ankur 27 feb*/
		
		for(var t=0;t<document.getElementById('druom').options.length;t++)
		{
		     document.getElementById('druom').options[t].selected=false;
		    
		}
		
		/*new change ankur 27 feb*/
		if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[z].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                    
                    }
                }
            
            
            }
		}
		////////////////
		  	
		  	
		    document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[z].No_Of_Columns;
		    document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[z].Size_Height;
		    document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[z].Size_Width;
		    document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[z].Edition_Area;
		    document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[z].Preodicity_Code;
		    document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[z].Gutter_Space;
		    document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[z].Column_Space;
		    document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[z].RO_hr;
		    if(dseditorexecute.Tables[0].Rows[z].RO_min!=null && dseditorexecute.Tables[0].Rows[z].RO_min!="null")
		    {
		        document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[z].RO_min;
		    }
		    else
		    {
		        document.getElementById('txtmin').value="";
		    }
		    document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[z].Production;
    	    document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[z].Edition_Type;
    	    
    	    /*change ankur*/
		document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[z].No_Of_Collumn;
		///////////////////
		if (dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE != null) {
		    document.getElementById('txtsegment').value = getcentername(dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE);
		 $('hdnsegment').value =dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE;
		}
		else {
		    document.getElementById('txtsegment').value = "";
		     $('hdnsegment').value ="";
		}
		
		if(dseditorexecute.Tables[0].Rows[z].GROUPCODE!=null)
		 document.getElementById('txtgrpcod').value=dseditorexecute.Tables[0].Rows[z].GROUPCODE;
		else
		    document.getElementById('txtgrpcod').value = "";

		if (dseditorexecute.Tables[0].Rows[z].EDTN_URL != null)
		    document.getElementById('txterp').value = dseditorexecute.Tables[0].Rows[z].EDTN_URL;
		else
		    document.getElementById('txterp').value = "";
		    
		     var adcatlen = document.getElementById('ddlspeciality').options.length;
           for (var t2 = 0; t2 < adcatlen; t2++) {
            document.getElementById('ddlspeciality').options[t2].selected = false;
              }
		    
		    if(dseditorexecute.Tables[0].Rows[z].SPENAME!=null)
            {
           
            var adcat = dseditorexecute.Tables[0].Rows[z].SPENAME;
            var len1 = adcat.split(",");
             for (var a1 = 0; a1 < len1.length; a1++) {
             for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('ddlspeciality').options[j].value == len1[a1]) {
                document.getElementById('ddlspeciality').options[j].selected = true;
                                       }
                                    }
                               }
            }
            else
            {
             document.getElementById('ddlspeciality').value="";
            }
		
		        cityvar=dseditorexecute.Tables[0].Rows[z].City_Code;
		        cityvarprint=dseditorexecute.Tables[0].Rows[z].PRINT_CENT;
			    addcount(dseditorexecute.Tables[0].Rows[z].Country_Code);
			
		    updateStatus();
			var akh=document.getElementById('txtEditonCode').value;
			fillcheckboxes(akh);
			
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
	
//**************This function is used to execute previous record***************///
function editionprevious()
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

EditorMaster.blankSession();
		chk=0;
		var PubName=document.getElementById('drpPubName').value;
		var CityName=document.getElementById('drpcity').value;
		var EditionName=document.getElementById('txtEditionName').value;
		var Alias=document.getElementById('txtAlias').value;
		var EditonCode=document.getElementById('txtEditonCode').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var country=document.getElementById('txtcountry').value;
		var circulation = document.getElementById('txtcirculation').value;
		var SHORTNAME = document.getElementById('txtshortname').value;

		EditorMaster.Selectfnpl(PubName, CityName, EditionName, Alias, EditonCode, compcode, userid, country, circulation, SHORTNAME,call_Previous);
		
		document.getElementById('drpPubName').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtEditionName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('txtEditonCode').disabled=true;
		document.getElementById('txtcountry').disabled=true;
        document.getElementById('txtcolumn').disabled=true;
        document.getElementById('txtsizeheight').disabled=true;
        document.getElementById('txtsizewidth').disabled=true;
        document.getElementById('txtarea').disabled=true;
        document.getElementById('txtgutterspace').disabled=true;
        document.getElementById('txtcolumnspace').disabled=true;
        document.getElementById('txthr').disabled=true;       
        document.getElementById('txtmin').disabled=true;
        document.getElementById('txtproduction').disabled=true;
        document.getElementById('drpeditiontype').disabled = true;
        document.getElementById('txtshortname').disabled = true;
        document.getElementById('ddlspeciality').disabled = true;
		return false;
}


//***************This function is call back response for fetching previous record************///
function call_Previous(response)
{
	z--;
	//ds=response.value;
	var x=dseditorexecute.Tables[0].Rows.length;
	
	if(z>x)
	{
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			return false;
	}
			
	if(z!=-1 && z>=0)
	{
			if(dseditorexecute.Tables[0].Rows.length != z)
			{
			editionco=dseditorexecute.Tables[0].Rows[z].Edition_Code;
				document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[z].Pub_Code;
				document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[z].Edition_Name;
				document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[z].Edition_Alias;
				document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[z].Edition_Code;
				document.getElementById('txtcountry').value = dseditorexecute.Tables[0].Rows[z].Country_Code;

				document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[z].SHORT_NAME;
				
				if(dseditorexecute.Tables[0].Rows[z].No_Of_Circulation!=null)
				{
				document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[z].No_Of_Circulation;
				}
				else
				{
				document.getElementById('txtcirculation').value="";
				}
		       	//document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[z].UOM_Code;
		       	/*new change ankur 27 feb*/
		
		for(var t=0;t<document.getElementById('druom').options.length;t++)
		{
		     document.getElementById('druom').options[t].selected=false;
		    
		}
		
		/*new change ankur 27 feb*/
		if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[z].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                    
                    }
                }
            
            
            }
		}
		////////////////
		       	 var adcatlen = document.getElementById('ddlspeciality').options.length;
           for (var t2 = 0; t2 < adcatlen; t2++) {
            document.getElementById('ddlspeciality').options[t2].selected = false;
              }
		       	
		       	if(dseditorexecute.Tables[0].Rows[z].SPENAME!=null)
            {
            var adcat = dseditorexecute.Tables[0].Rows[z].SPENAME;
            var len1 = adcat.split(",");
             for (var a1 = 0; a1 < len1.length; a1++) {
             for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('ddlspeciality').options[j].value == len1[a1]) {
                document.getElementById('ddlspeciality').options[j].selected = true;
                                       }
                                    }
                               }
            
            }
            else
            {
             document.getElementById('ddlspeciality').value="";
            }
		        document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[z].No_Of_Columns;
		        document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[z].Size_Height;
		        document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[z].Size_Width;
		        document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[z].Edition_Area;
        	    document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[z].Preodicity_Code;
		        document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[z].Gutter_Space;
		        document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[z].Column_Space;
        	    document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[z].RO_hr;
        	    if(dseditorexecute.Tables[0].Rows[z].RO_min!=null && dseditorexecute.Tables[0].Rows[z].RO_min!="null")
        	    {
        	        document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[z].RO_min;
        	    }
        	    else
        	    {
        	        document.getElementById('txtmin').value="";
        	    }
        	    document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[z].Production;
        	    document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[z].Edition_Type;
        	    
        	    /*change ankur*/
		document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[z].No_Of_Collumn;
		///////////////////
		if (dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE != null) {
		    document.getElementById('txtsegment').value = getcentername(dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE);
		$('hdnsegment').value =dseditorexecute.Tables[0].Rows[z].SEGMENT_CODE;
		}
		else {
		    document.getElementById('txtsegment').value = "";
		    $('hdnsegment').value ="";
		}
		
		if(dseditorexecute.Tables[0].Rows[z].GROUPCODE!=null)
		 document.getElementById('txtgrpcod').value=dseditorexecute.Tables[0].Rows[z].GROUPCODE;
		else
		    document.getElementById('txtgrpcod').value = "";

		if (dseditorexecute.Tables[0].Rows[z].EDTN_URL != null)
		    document.getElementById('txterp').value = dseditorexecute.Tables[0].Rows[z].EDTN_URL;
		else
		    document.getElementById('txterp').value = "";
		
				updateStatus();
				cityvar=dseditorexecute.Tables[0].Rows[z].City_Code;
				 cityvarprint=dseditorexecute.Tables[0].Rows[z].PRINT_CENT;
			    addcount(dseditorexecute.Tables[0].Rows[z].Country_Code);
			
				var akh=document.getElementById('txtEditonCode').value;
				fillcheckboxes(akh);

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
//***************This function is used to fetch last record****************///
function editionlast()
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

EditorMaster.blankSession();
			chk=0;
			var PubName=document.getElementById('drpPubName').value;
			var CityName=document.getElementById('drpcity').value;
			var EditionName=document.getElementById('txtEditionName').value;
			var Alias=document.getElementById('txtAlias').value;
			var EditonCode=document.getElementById('txtEditonCode').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var country=document.getElementById('txtcountry').value;
			var circulation = document.getElementById('txtcirculation').value;
			var SHORTNAME = document.getElementById('txtshortname').value;

			EditorMaster.Selectfnpl(PubName, CityName, EditionName, Alias, EditonCode, compcode, userid, country, circulation, SHORTNAME,call_Last);
			
			document.getElementById('drpPubName').disabled=true;
			document.getElementById('drpcity').disabled=true;
			document.getElementById('txtEditionName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('txtEditonCode').disabled=true;
			document.getElementById('txtcountry').disabled=true;
            document.getElementById('txtcolumn').disabled=true;
            document.getElementById('txtsizeheight').disabled=true;
            document.getElementById('txtsizewidth').disabled=true;
            document.getElementById('txtarea').disabled=true;
            document.getElementById('txtgutterspace').disabled=true;
            document.getElementById('txtcolumnspace').disabled=true;
            document.getElementById('txthr').disabled=true;
            document.getElementById('txtmin').disabled=true;
            document.getElementById('txtproduction').disabled=true;
            document.getElementById('drpeditiontype').disabled = true;
            document.getElementById('txtshortname').disabled = true;
            
            
			return false;
}
//*************This function is call back response for fetching last record*****************//
function call_Last(response)
{
			//ds= response.value;
			var x=dseditorexecute.Tables[0].Rows.length;
			z=x-1;
			x=x-1;
			editionco=dseditorexecute.Tables[0].Rows[x].Edition_Code;
			document.getElementById('drpPubName').value=dseditorexecute.Tables[0].Rows[x].Pub_Code;
			document.getElementById('txtEditionName').value=dseditorexecute.Tables[0].Rows[x].Edition_Name;
			document.getElementById('txtAlias').value=dseditorexecute.Tables[0].Rows[x].Edition_Alias;
			document.getElementById('txtEditonCode').value=dseditorexecute.Tables[0].Rows[x].Edition_Code;
			document.getElementById('txtcountry').value = dseditorexecute.Tables[0].Rows[x].Country_Code;
			document.getElementById('txtshortname').value = dseditorexecute.Tables[0].Rows[x].SHORT_NAME;
			
			
			if(dseditorexecute.Tables[0].Rows[x].No_Of_Circulation!=null)
			{
			document.getElementById('txtcirculation').value=dseditorexecute.Tables[0].Rows[x].No_Of_Circulation;
			}
			else
			{
			document.getElementById('txtcirculation').value="";
			}
			//document.getElementById('druom').value=dseditorexecute.Tables[0].Rows[x].UOM_Code;
			/*new change ankur 27 feb*/
		
		for(var t=0;t<document.getElementById('druom').options.length;t++)
		{
		     document.getElementById('druom').options[t].selected=false;
		    
		}
		
		/*new change ankur 27 feb*/
		if(document.getElementById('lbuom').style.display!="none")
		{
            var uom_temp=dseditorexecute.Tables[0].Rows[x].UOM_Code;
            uom_temp=uom_temp.split(",");
            for(var ui=0;ui<uom_temp.length;ui++)
            {
                
                if(uom_temp[ui]!="" || uom_temp[ui]!="0")
                {
                    for(var ui1=0;ui1<document.getElementById('druom').options.length;ui1++)
                    {
                        if(uom_temp[ui]==document.getElementById('druom').options[ui1].value)
                        {
                            document.getElementById('druom').options[ui1].selected=true;
                        }
                    
                    }
                }
            
            
            }
		}
		
		////////////////
			
			
		    document.getElementById('txtcolumn').value=dseditorexecute.Tables[0].Rows[x].No_Of_Columns;
		    document.getElementById('txtsizeheight').value=dseditorexecute.Tables[0].Rows[x].Size_Height;
		    document.getElementById('txtsizewidth').value=dseditorexecute.Tables[0].Rows[x].Size_Width;
		    document.getElementById('txtarea').value=dseditorexecute.Tables[0].Rows[x].Edition_Area;
    	     document.getElementById('drperiodicity').value=dseditorexecute.Tables[0].Rows[x].Preodicity_Code;
		    document.getElementById('txtgutterspace').value=dseditorexecute.Tables[0].Rows[x].Gutter_Space;
		    document.getElementById('txtcolumnspace').value=dseditorexecute.Tables[0].Rows[x].Column_Space;
		    document.getElementById('txthr').value=dseditorexecute.Tables[0].Rows[x].RO_hr;
		    if(dseditorexecute.Tables[0].Rows[x].RO_min!=null&& dseditorexecute.Tables[0].Rows[x].RO_min!="null")
		    {
		        document.getElementById('txtmin').value=dseditorexecute.Tables[0].Rows[x].RO_min;
		    }
		    else
		    {
		        document.getElementById('txtmin').value="";
		    }
            document.getElementById('txtproduction').value=dseditorexecute.Tables[0].Rows[x].Production;
            document.getElementById('drpeditiontype').value=dseditorexecute.Tables[0].Rows[x].Edition_Type;	
            
            /*change ankur*/
		document.getElementById('txtnoofcol').value=dseditorexecute.Tables[0].Rows[x].No_Of_Collumn;
		///////////////////
		if (dseditorexecute.Tables[0].Rows[x].SEGMENT_CODE != null) {
		    document.getElementById('txtsegment').value = getcentername(dseditorexecute.Tables[0].Rows[x].SEGMENT_CODE);
		}
		else {
		    document.getElementById('txtsegment').value = "";
		}
		if(dseditorexecute.Tables[0].Rows[x].GROUPCODE!=null)
		 document.getElementById('txtgrpcod').value=dseditorexecute.Tables[0].Rows[x].GROUPCODE;
		else
		    document.getElementById('txtgrpcod').value = "";

		if (dseditorexecute.Tables[0].Rows[x].EDTN_URL != null)
		    document.getElementById('txterp').value = dseditorexecute.Tables[0].Rows[x].EDTN_URL;
		else
		    document.getElementById('txterp').value = "";
		
		
		 var adcatlen = document.getElementById('ddlspeciality').options.length;
           for (var t2 = 0; t2 < adcatlen; t2++) {
            document.getElementById('ddlspeciality').options[t2].selected = false;
              }
		if(dseditorexecute.Tables[0].Rows[x].SPENAME!=null)
            {
            var adcat = dseditorexecute.Tables[0].Rows[x].SPENAME;
            var len1 = adcat.split(",");
             for (var a1 = 0; a1 < len1.length; a1++) {
             for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('ddlspeciality').options[j].value == len1[a1]) {
                document.getElementById('ddlspeciality').options[j].selected = true;
                                       }
                                    }
                               }
            }
            else
            {
             document.getElementById('ddlspeciality').value="";
            }
		
			cityvar=dseditorexecute.Tables[0].Rows[x].City_Code;
			 cityvarprint=dseditorexecute.Tables[0].Rows[x].PRINT_CENT;
			addcount(dseditorexecute.Tables[0].Rows[x].Country_Code);
			
						
			var akh=document.getElementById('txtEditonCode').value;
			fillcheckboxes(akh);
			
			updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
			return false;
}
//*************This function is used to select edition day and checkboxes are used for it**************//
function selectedtionday(response,flag)
{
        editcodeverchk(document.getElementById('txtEditonCode').value,flag);
//			var compcode=document.getElementById('hiddencompcode').value;
//			var editoncode=document.getElementById('txtEditonCode').value;
//			var userid=document.getElementById('hiddenuserid').value;
//			EditorMaster.checkedtioncode1(compcode,editoncode,userid,editcodeverchk);
//			return false;
			}
			
			
			
//***************This function is call back response for selecting edition day****************//
/*function editcodever(response)
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
var compcode=document.getElementById('hiddencompcode').value;
var editoncode=document.getElementById('txtEditonCode').value;
var userid=document.getElementById('hiddenuserid').value;
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
EditorMaster.edtiondaymodify1(compcode,editoncode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
return false;
}
else
{
EditorMaster.editionpubdaysave1(compcode,editoncode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
return false;
}
}*/
//***************This function is call back response for selecting edition day****************//
function editcodeverchk(editioncode,flag)
{
//var ds=response.value;
var chk1;
var chk2;
var chk3;
var chk4;
var chk5;
var chk6;
var chk7;
var chk8;
var compcode=document.getElementById('hiddencompcode').value;
var editoncode=document.getElementById('txtEditonCode').value;
var userid = document.getElementById('hiddenuserid').value;

var txt1 = document.getElementById('txt1').value;
var txt2 = document.getElementById('txt2').value;
var txt3 = document.getElementById('txt3').value;
var txt4 = document.getElementById('txt4').value;
var txt5 = document.getElementById('txt5').value;
var txt6 = document.getElementById('txt6').value;
var txt7 = document.getElementById('txt7').value;

if((document.getElementById('CheckBox1').checked==true))//&&(document.getElementById('CheckBox1').disabled==false))
{
chk1="Y";
}
else
{
chk1="N";
}
if((document.getElementById('CheckBox2').checked==true))//&&(document.getElementById('CheckBox2').disabled==false))
{
chk2="Y";
}
else
{
chk2="N";
}
if((document.getElementById('CheckBox3').checked==true))//&&(document.getElementById('CheckBox3').disabled==false))
{
chk3="Y";
}
else
{
chk3="N";
}
if((document.getElementById('CheckBox4').checked==true))//&&(document.getElementById('CheckBox4').disabled==false))
{
chk4="Y";
}
else
{
chk4="N";
}
if((document.getElementById('CheckBox5').checked==true))//&&(document.getElementById('CheckBox5').disabled==false))
{
chk5="Y";
}
else
{
chk5="N";
}
if((document.getElementById('CheckBox6').checked==true))//&&(document.getElementById('CheckBox6').disabled==false))
{
chk6="Y";
}
else
{
chk6="N";
}
if((document.getElementById('CheckBox7').checked==true))//&&(document.getElementById('CheckBox7').disabled==false))
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
if(document.getElementById('CheckBox2').disabled==false)
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
chk8="Y"
}
else
{
chk8="N";
}
    
       
if(flag=='0')
{
    EditorMaster.edtiondaymodify1(compcode, editoncode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
    EditorMaster.edtiontxtmodify1(compcode, editoncode, txt1, txt2, txt3, txt4, txt5, txt6, txt7, userid, call_backclear);
return false;
}
else
{
    EditorMaster.editionpubdaysave1(compcode, editoncode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
    EditorMaster.editionpubtxtsave1(compcode, editoncode, txt1, txt2, txt3, txt4, txt5, txt6, txt7, userid, call_backclear);
return false;
}
}

///***********************************************************************************************
function fillcheckboxes(response)
{
var compcode=document.getElementById('hiddencompcode').value;
var editioncode=document.getElementById('txtEditonCode').value;
var userid=document.getElementById('hiddenuserid').value;
EditorMaster.checkedtioncode1(compcode, editioncode, userid, fillcheck);
EditorMaster.checkedtiontxt(compcode, editioncode, userid, filltxt);
return false;
}
//*************This is call back response to check the checkboxes********************///
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

//*************This is call back response to fill the text box********************///

function filltxt(res) 
{

    var ds = res.value;
    if (ds.Tables[0].Rows.length > 0) {
        var txtsun = fndnull(ds.Tables[0].Rows[0].TXTSUN);
        var txtmon = fndnull(ds.Tables[0].Rows[0].TXTMON);
        var txttue = fndnull(ds.Tables[0].Rows[0].TXTTUE);
        var txtwed = fndnull(ds.Tables[0].Rows[0].TXTWED);
        var txtthu = fndnull(ds.Tables[0].Rows[0].TXTTHU);
        var txtfri = fndnull(ds.Tables[0].Rows[0].TXTFRI);
        var txtsat = fndnull(ds.Tables[0].Rows[0].TXTSAT);
        document.getElementById('txt1').value = txtsun;
        document.getElementById('txt2').value = txtmon;
        document.getElementById('txt3').value = txttue;
        document.getElementById('txt4').value = txtwed;
        document.getElementById('txt5').value = txtthu;
        document.getElementById('txt6').value = txtfri;
        document.getElementById('txt7').value = txtsat;


    }
    else {

        document.getElementById('txt1').value = "";
        document.getElementById('txt2').value = "";
        document.getElementById('txt3').value = "";
        document.getElementById('txt4').value = "";
        document.getElementById('txt5').value = "";
        document.getElementById('txt6').value = "";
        document.getElementById('txt7').value = "";
    
    
    
    
    }
    return false;


}









//*********This function is used to check the checkbox which ever is selected***************//
//***********If all is selected then automatically all checkboxes will be checked***********//
function fillcheckboxes1(response)
{
var compcode=document.getElementById('hiddencompcode').value;
var editioncode=document.getElementById('txtEditonCode').value;
var userid=document.getElementById('hiddenuserid').value;
EditorMaster.checkedtioncode1(compcode,editioncode,userid,fillcheck1);
return false;
}
//*************This is call back response to check the checkboxes********************///
function fillcheck1(response)
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

if((sun=="Y")&&(document.getElementById('CheckBox1').disabled==false))
    {
    document.getElementById('CheckBox1').checked=true;
    }
else
    {
    document.getElementById('CheckBox1').checked=false;
    }

if((mon=="Y")&&(document.getElementById('CheckBox2').disabled==false))
    {
    document.getElementById('CheckBox2').checked=true;
    }
else
    {
    document.getElementById('CheckBox2').checked=false;
    }
if((tue=="Y")&&(document.getElementById('CheckBox3').disabled==false))
    {
    document.getElementById('CheckBox3').checked=true;
    }
else
    {
    document.getElementById('CheckBox3').checked=false;
    }
if((wed=="Y")&&(document.getElementById('CheckBox4').disabled==false))
    {
    document.getElementById('CheckBox4').checked=true;
    }
else
    {
    document.getElementById('CheckBox4').checked=false;
    }
if((thu=="Y")&&(document.getElementById('CheckBox5').disabled==false))
    {
    document.getElementById('CheckBox5').checked=true;
    }
else
    {
    document.getElementById('CheckBox5').checked=false;
    }
if((fri=="Y")&&(document.getElementById('CheckBox6').disabled==false))
    {
    document.getElementById('CheckBox6').checked=true;
    }
else
    {
    document.getElementById('CheckBox6').checked=false;
    }
if((sat=="Y")&&(document.getElementById('CheckBox7').disabled==false))
    {
    document.getElementById('CheckBox7').checked=true;
    }
else
    {
    document.getElementById('CheckBox7').checked=false;
    }
if(all=="Y")
    {
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
}
//***********************This function is used to disable all checkboxes**********************///
function disablecheck() {

    extype = "new";
		document.getElementById('CheckBox1').disabled=true;
		document.getElementById('CheckBox2').disabled=true;
		document.getElementById('CheckBox3').disabled=true;
		document.getElementById('CheckBox4').disabled=true;
		document.getElementById('CheckBox5').disabled=true;
		document.getElementById('CheckBox6').disabled=true;
		document.getElementById('CheckBox7').disabled=true;
		document.getElementById('CheckBox8').disabled = true;
		
		document.getElementById('txt1').value = "";
		document.getElementById('txt2').value = "";
		document.getElementById('txt3').value = "";
		document.getElementById('txt4').value = "";
		document.getElementById('txt5').value = "";
		document.getElementById('txt6').value = "";
		document.getElementById('txt7').value = "";
		document.getElementById('txt8').value = "";

		document.getElementById('txt1').disabled = true;
		document.getElementById('txt2').disabled = true;
		document.getElementById('txt3').disabled = true;
		document.getElementById('txt4').disabled = true;
		document.getElementById('txt5').disabled = true;
		document.getElementById('txt6').disabled = true;
		document.getElementById('txt7').disabled = true;
		document.getElementById('txt8').disabled = true;

		
		
		//getPermission();
		givebuttonpermission('EditorMaster');
		return false;
}
///*******************This function is used to close current window**********************///
function editionexit()
{
var id;
edition="save";
		 if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                        httpRequest.open("GET", "chkperiodicity.aspx?page=" + edition + "&edition=" + edition + "&date1=" + edition + "&date2=" + edition + "&date3=" + edition, false);
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
  	           xml.Open("GET", "chkperiodicity.aspx?page=" + edition + "&edition=" + edition + "&date1=" + edition + "&date2=" + edition + "&date3=" + edition, false);
		        xml.Send();
		}
		if(confirm("Do You Want To Skip This Page"))
		{
		if(popwin1 && !popwin1.closed)
		    {
    		
		    popwin1.close();
	      }
			//window.location.href='EnterPage.aspx';
			window.close();
			return false;
		}
		return false;
}

//************This function is used to check all checkboxes if all is clicked************//
function checkedunchecked(q)
{
	var status = document.getElementById('CheckBox8').checked;
	
       
	
/*if(document.getElementById('CheckBox1').disabled==false)
    {
    document.getElementById('CheckBox1').checked=true;
    }
else
    {
    document.getElementById('CheckBox1').checked=false;
    }

if(document.getElementById('CheckBox2').disabled==false)
    {
    document.getElementById('CheckBox2').checked=true;
    }
else
    {
    document.getElementById('CheckBox2').checked=false;
    }
if(document.getElementById('CheckBox3').disabled==false)
    {
    document.getElementById('CheckBox3').checked=true;
    }
else
    {
    document.getElementById('CheckBox3').checked=false;
    }
if(document.getElementById('CheckBox4').disabled==false)
    {
    document.getElementById('CheckBox4').checked=true;
    }
else
    {
    document.getElementById('CheckBox4').checked=false;
    }
if(document.getElementById('CheckBox5').disabled==false)
    {
    document.getElementById('CheckBox5').checked=true;
    }
else
    {
    document.getElementById('CheckBox5').checked=false;
    }
if(document.getElementById('CheckBox6').disabled==false)
    {
    document.getElementById('CheckBox6').checked=true;
    }
else
    {
    document.getElementById('CheckBox6').checked=false;
    }
if(document.getElementById('CheckBox7').disabled==false)
    {
    document.getElementById('CheckBox7').checked=true;
    }
else
    {
    document.getElementById('CheckBox7').checked=false;
    }*/
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
 









///*************This function is used for focusing the edition name***************///
function filledit()
{    
document.getElementById('drperiodicity').value="0";
	
	if((document.getElementById('txtcountry').value!="0")&&(document.getElementById('drpcity').value!="0")&&(document.getElementById('txtEditionName').value!=""))
	 	{
	 	fillalias();
	 	}
    //document.getElementById('txtEditionName').focus();
    strpub=document.getElementById('drpPubName').value;
    if(chk==0)
    {
    if(strpub=="0")
    {
     return ;
    }
    else
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
EditorMaster.bindspace(strpub,bindings);
    }
    }
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
EditorMaster.enablechkbox(strpub,fillchk_callback);
    }
    
   return false;
   }
   
function bindings(res11)
{
var ds1=res11.value;
document.getElementById('txtgutterspace').value=ds1.Tables[0].Rows[0].Gutter_Space;
document.getElementById('txtcolumnspace').value=ds1.Tables[0].Rows[0].Column_Space;
document.getElementById('txthr').value=ds1.Tables[0].Rows[0].rotimehr;
if(ds1.Tables[0].Rows[0].rotimemin!=null && ds1.Tables[0].Rows[0].rotimemin!="null")
{
    document.getElementById('txtmin').value=ds1.Tables[0].Rows[0].rotimemin;
}
else
{
    document.getElementById('txtmin').value="";
}
if(ds1.Tables[0].Rows[0].production!=null)
{
document.getElementById('txtproduction').value=ds1.Tables[0].Rows[0].production;
}
/*change ankur*/
if(ds1.Tables[0].Rows[0].No_Of_collumn!=null)
{
document.getElementById('txtcolumn').value=ds1.Tables[0].Rows[0].No_Of_collumn;
}
///////////////////
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

        document.getElementById('CheckBox1').disabled = false;
        document.getElementById('txt1').disabled = false;
    kchk++;
    }
else
    {
    document.getElementById('CheckBox1').disabled=true;
    document.getElementById('CheckBox1').checked = false;
    document.getElementById('txt1').disabled = true;
  
    }

if(mon=="Y")
    {

        document.getElementById('CheckBox2').disabled = false;
        document.getElementById('txt2').disabled = false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox2').disabled=true;
    document.getElementById('CheckBox2').checked=false;
    document.getElementById('txt2').disabled = true;
    }
if(tue=="Y")
    {

        document.getElementById('CheckBox3').disabled = false;
        document.getElementById('txt3').disabled = false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox3').disabled=true;
    document.getElementById('CheckBox3').checked = false;
    document.getElementById('txt3').disabled = true;
  
    }
if(wed=="Y")
    {
   kchk++;
   document.getElementById('CheckBox4').disabled = false;
   document.getElementById('txt4').disabled = false;
    }
else
    {
    document.getElementById('CheckBox4').disabled=true;
    document.getElementById('CheckBox4').checked = false;
    document.getElementById('txt4').disabled = true;
  
    }
if(thu=="Y")
    {

        document.getElementById('CheckBox5').disabled = false;
        document.getElementById('txt5').disabled = false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox5').disabled=true;
    document.getElementById('CheckBox5').checked = false;
    document.getElementById('txt5').disabled = true;
  
    }
if(fri=="Y")
    {

        document.getElementById('CheckBox6').disabled = false;
        document.getElementById('txt6').disabled = false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox6').disabled=true;
    document.getElementById('CheckBox6').checked = false;
    document.getElementById('txt6').disabled = true;
  
    }
if(sat=="Y")
    {

        document.getElementById('CheckBox7').disabled = false;
        document.getElementById('txt7').disabled = false;
     kchk++;
    }
else
    {
    document.getElementById('CheckBox7').disabled=true;
    document.getElementById('CheckBox7').checked = false;
    document.getElementById('txt7').disabled = true;
  
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
    document.getElementById('CheckBox8').disabled = false;


    document.getElementById('txt1').disabled = false;
    document.getElementById('txt2').disabled = false;
    document.getElementById('txt3').disabled = false;
    document.getElementById('txt4').disabled = false;
    document.getElementById('txt5').disabled = false;
    document.getElementById('txt6').disabled = false;
    document.getElementById('txt7').disabled = false;
    document.getElementById('txt8').disabled = false;
    }
else
     {
         if ((sun == "N") && (mon == "N") && (tue == "N") && (wed == "N") && (thu == "N") && (fri == "N") && (sat == "N")) {
             document.getElementById('CheckBox8').disabled = true;
             document.getElementById('txt8').disabled = true;
         }
         else {
             document.getElementById('CheckBox8').disabled = false;
             document.getElementById('txt8').disabled = false;
         }
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


     document.getElementById('txt1').disabled = true;
     document.getElementById('txt2').disabled = true;
     document.getElementById('txt3').disabled = true;
     document.getElementById('txt4').disabled = true;
     document.getElementById('txt5').disabled = true;
     document.getElementById('txt6').disabled = true;
     document.getElementById('txt7').disabled = true;
     document.getElementById('txt8').disabled = true;
    }
  
    return false;
}

///response for typecheck
function call_chktype(response0)
{
var ds=response0.value;
if(hiddentext!="query")
{
if(document.getElementById('drpeditiontype').value=="Main Edition")
{
if(ds.Tables[0].Rows.length!=0)
{
sunny="1";
alert("Main Edition already allotted!")
document.getElementById('txtEditionName').disabled=false;
document.getElementById('txtEditionName').value="";
document.getElementById('drpcity').value="0";
document.getElementById('txtEditonCode').value="";
 document.getElementById('txtcountry').value="0";
 document.getElementById('txtAlias').value="";
 document.getElementById('drpeditiontype').value="0";
 document.getElementById('drpeditiontype').focus();
 return false;
 }
 }
 else if((document.getElementById('drpeditiontype').value=="Edition")&&(document.getElementById('drpcity').value!="0"))
 {
 if(ds.Tables[1].Rows.length==0)
{
//sunny="1";
alert("Main Edition not allotted yet!")
document.getElementById('txtEditionName').disabled=false;
document.getElementById('txtEditionName').value="";
document.getElementById('drpcity').value="0";
document.getElementById('txtEditonCode').value="";
 document.getElementById('txtcountry').value="0";
 document.getElementById('txtAlias').value="";
 document.getElementById('drpeditiontype').value="0";
 document.getElementById('drpeditiontype').focus();
 return false;
 }
 }
 }
}

/////////////////////////////

// ******************************Code For Auto Generation********************
       
function autoornot()
 {
 sunny="0";
var PubName=document.getElementById('drpPubName').value;
var CodeName=document.getElementById('drpeditiontype').value;
var CityName=document.getElementById('drpcity').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

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
EditorMaster.editiontypecheck(PubName,CodeName,CityName,compcode,userid,call_chktype);
 
  if(document.getElementById('hiddenauto').value==1)
    {
    autochange();
     //return false;
    }
else
    {
    userdefine();
    fill_aliascall();
     return false;
    }
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function autochange()
{
if(hiddentext=="new" )
			{
	
            UPPERCASE();
           
           }
           
   else if (hiddentext=="modify")
   {
     str=document.getElementById('txtEditionName').value;
    strpub=document.getElementById('drpPubName').value;
   strcity=document.getElementById('drpcity').value;
               
   EditorMaster.editmaster(str,strpub,strcity,fillcall_modify);
		   		     
   }
   
   else
     {
      document.getElementById('txtEditionName').value=document.getElementById('txtEditionName').value.toUpperCase();
      }
return false;
}

/////////This function is used to create alias name if preference is auto-generated//////////
function fillcall_modify(res)
		{
		var ds=res.value;
		 var newstr;
		  if(ds.Tables[0].Rows.length!=0)
		    {

		    if(document.getElementById('txtEditionName').value!=mod)
		    {
		    alert("This Edition name has already assigned in this publication center!! ");
		  	 document.getElementById('txtEditionName').value="";
		  	 document.getElementById('txtEditionName').focus();
		    return false;
		    }
		    }
		    //}
		 if((document.getElementById('txtcountry').value!="0")&&(document.getElementById('drpcity').value!="0"))
	 	{
	 	//fillalias();
	 	fillalias_modify();
	 	return false;
	 	}
	 	else
	 	{
	 	document.getElementById('txtAlias').value="";
	 	return false;
	 
	 	}
		    
		    return false;
		 }
		
	

//auto generated
//this is used for increment in code

function UPPERCASE()
		{
		        //document.getElementById('txtEditonCode').value=trim(document.getElementById('txtEditonCode').value);
        document.getElementById('txtEditionName').value=trim(document.getElementById('txtEditionName').value);
            
           lstr=document.getElementById('txtEditionName').value;
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
	
            
            
		     if((document.getElementById('txtEditionName').value!="")&& (document.getElementById('drpPubName').value=="0"))
		          {
		          
		          alert("Please Select Publication Name ");
		          document.getElementById('drpPubName').focus();
		          return false;
		          }
		          if(document.getElementById('drpeditiontype').value=="0")
{
alert("Please select Edition Type first");
document.getElementById('txtEditionName').value="";
document.getElementById('drpeditiontype').focus();
return false;
}
		         if((document.getElementById('txtEditionName').value!="")&&(document.getElementById('drpPubName').value!="0")&&(document.getElementById('drpcity').value!="0"))
		          {
                  // str=document.getElementById('txtEditionName').value;
                  str=mstr;
                 strpub=document.getElementById('drpPubName').value;
                 strcity=document.getElementById('drpcity').value;
               
		        EditorMaster.editmaster(str,strpub,strcity,fillcall);
		      //  document.getElementById('txtAlias').focus();
		        }
		        
		      /*  if((document.getElementById('txtEditionName').value!="")&&(document.getElementById('drpPubName').value!="0"))
		          {
                   str=document.getElementById('txtEditionName').value;
                 strpub=document.getElementById('drpPubName').value;
                // strcity=document.getElementById('drpcity').value;
            
                 // EditorMaster.editmaster(str,strpub,strcity, fillcall);
		  
		       EditorMaster.editmaster1(str,strpub,fillcall);
		      //  document.getElementById('txtAlias').focus();
		        }*/
		       	       
               
 return false;
		
}


/////This function is call back response for generating code//////////
function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    		    if(sunny!="1")
		    {
		    alert("This Edition name has already assigned in this publication center!! ");
		    
		  	 //document.getElementById('txtEditionName').focus();
		  	 document.getElementById('txtAlias').value="";
		  	 document.getElementById('txtEditionName').value="";
		        sunny="0";
		    return false;
		    }
		    }
		
		        else
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Edition_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                          code++;
		                         str=str.toUpperCase();
		                        
		                        document.getElementById('txtEditonCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                            str=str.toUpperCase();
		                            document.getElementById('txtEditonCode').value=str.substr(0,2)+ "0";
		                          }
		               
		//document.getElementById('txtEditionName').value=document.getElementById('txtEditionName').value.toUpperCase();
	 	//document.getElementById('txtcountry').focus();
	 	if((document.getElementById('txtcountry').value!="0")&&(document.getElementById('drpcity').value!="0"))
	 	{
	 	fillalias();
	 	}
	 	else
	 	{
	 	document.getElementById('txtAlias').value="";
	    return false;
	 	}
   }
	return false;
		}

/////////////This function is used if preference is user-defined/////////		
function userdefine()
    {
        if(hiddentext=="new")
        {
       
        
        document.getElementById('txtEditonCode').disabled=false;
        document.getElementById('txtEditionName').value=document.getElementById('txtEditionName').value.toUpperCase();
        //document.getElementById('txtAlias').value=document.getElementById('txtEditionName').value;
        auto=document.getElementById('hiddenauto').value;
        return false;
        }

return false;
}

	
//////////////This function is used to generate capital letters if small letters are inserted///////		
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

//******************************************************************************
////////////This function is used to generate city corresponding to particular country/////////
function addcount(ab)
{
if(document.getElementById('txtcountry').value!="0")
{
var country=document.getElementById('txtcountry').value;

EditorMaster.addcou(country,callcount);

}
else
{
   document.getElementById('drpcity').value="0";
    document.getElementById('txtAlias').value="";
   return false;
     
}

return false;
}
/////////This function is call back response for filling city///////
function callcount(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drpcity");


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
        var pkgitem=document.getElementById('drpcity');
         var pkgitemphy=document.getElementById('drpprintcent');
         pkgitem.options[0]=new Option("----Select Center----","0");
      pkgitemphy.options[0]=new Option("-Select Printing Center-","0");
//var pkgitem = document.getElementById("drpcity");
//alert(pkgitem);
    pkgitem.options.length = 1; 
     pkgitemphy.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Pub_Cent_name,res.value.Tables[0].Rows[i].Pub_cent_Code);
        
       pkgitem.options.length;
       if(res.value.Tables[0].Rows[i].PRINT_CENT!='N')
       {
         pkgitemphy.options[pkgitemphy.options.length] = new Option(res.value.Tables[0].Rows[i].Pub_Cent_name,res.value.Tables[0].Rows[i].Pub_cent_Code);
        
       pkgitemphy.options.length;
       }
    }
 if(cityvar == undefined || cityvar=="")
 {
 // document.getElementById('drpcity').value=res.value.Tables[0].Rows[0].City_Code;
 document.getElementById('drpcity').value="0";
 }
 else
 {
  document.getElementById('drpcity').value=cityvar;
  cityvar="";
  } 
  
   if(cityvarprint == undefined || cityvarprint=="")
 {
 // document.getElementById('drpcity').value=res.value.Tables[0].Rows[0].City_Code;
 document.getElementById('drpprintcent').value="0";
 }
 else
 {
  document.getElementById('drpprintcent').value=cityvarprint;
  cityvarprint="";
  } 
 /* if((hiddentext=="new")||(hiddentext=="modify"))
  {
  document.getElementById('drpcity').focus();
  return false;
  }*/
  }
else
{
alert("There Is No Matching Value Found");
pkgitem.options.length=1;
return false;

}

return false;
}

//////////This function is used to generate alias name depending on publication name,edition name and city///////////////
function fillalias()
{
document.getElementById('txtAlias').value="";
if(document.getElementById('drpPubName').value=="0")
{
alert("Please Select Publication Name");
 document.getElementById('drpPubName').focus();
         
return false;
}
else if(document.getElementById('txtEditionName').value=="")
{
alert("Please Enter Edition Name");
 document.getElementById('txtEditionName').focus();
         
return false;
}
else if(document.getElementById('txtcountry').value=="0")
{
alert("Please Select Country Name");
document.getElementById('txtcountry').focus();
return false;
}
else if(document.getElementById('drpcity').value=="0")
{
alert("Please Select Publication Center");
document.getElementById('drpcity').focus();
return false;
}
 if((document.getElementById('txtEditionName').value!="")&&(document.getElementById('drpPubName').value!="0")&&(document.getElementById('drpcity').value!="0"))
		          {
                   str=document.getElementById('txtEditionName').value;
                 strpub=document.getElementById('drpPubName').value;
                 strcity=document.getElementById('drpcity').value;
               
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
EditorMaster.editmaster(str,strpub,strcity,fill_aliascall);
		      //  document.getElementById('txtAlias').focus();
		        }
		  return false;
  }
function fill_aliascall()
{
 
if(document.getElementById('txtEditionName').value!="" && document.getElementById('drpcity').value!="0" && document.getElementById('drpPubName').value!="0")
{
 chkstr=document.getElementById('txtEditionName').value;
var city=document.getElementById('drpcity').value;
var pubname=document.getElementById('drpPubName').value;
EditorMaster.findcity(city,pubname,call_fillalias);
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
if(ds!=null)
{

		  	citystr=ds.Tables[1].Rows[0].Pub_Cent_name;
		  	pubstr=ds.Tables[0].Rows[0].Pub_Name;
		  var EditonCode=document.getElementById('txtEditonCode').value;
		 var edicode=EditonCode.length;
		 var code4=EditonCode.substr(2,edicode);
/*new change ankur 27 feb*/
    var code1=citystr.substr(0,3);
    //var code2=chkstr.substr(0,3);
    var code2=chkstr;
    var code3;
    var pubnamearr=new Array();
     pubnamearr=pubstr.split(' ');
   //  if(pubnamearr.length==1)
    // {
        code3=pubnamearr[0].substr(0,3);
    // }
    /* else
     {
         code3=pubnamearr[0].substr(0,1);
         for(i=1;i<pubnamearr.length;i++)
           {
           pubcode=pubnamearr[i].substr(0,1);
           code3=code3+pubcode;
           }
    }  */
       var alias=code3+"-"+code1+"-"+code2;
      // EditorMaster.chkalias(alias,call_alias);
      if(document.getElementById('drpeditiontype').value=="Edition")
      {
     document.getElementById('txtAlias').value=code3+"-"+code1+"-"+code2+"-"+code4; 
     }
     else if(document.getElementById('drpeditiontype').value=="Main Edition")
     {
     document.getElementById('txtAlias').value=code3+"-"+code1+"-"+code4; 
     }
    // document.getElementById('drpcity').focus();
           
     
       
       }
return false;
}

function call_alias(res)
{
var ds=res.value;
aliasname=ds.Tables[0].Rows[0].Pub_Name;
 var aliasnamearr=new Array();
     aliasnamearr=pubstr.split(' ');
   

document.getElementById('txtAlias').value=code3+"-"+code1+"-"+code2;
return false;
}


///**********************************************************
function fillheight()
{
if(document.getElementById('txtsizeheight').value=="" && document.getElementById('txtsizewidth').value =="")
{

//document.getElementById('txtarea').value="";
//document.getElementById('txtcirculation').focus();

return false;
}
if(document.getElementById('txtsizeheight').value=="" && document.getElementById('txtsizewidth').value !="")
{
document.getElementById('txtarea').value="";
//document.getElementById('txtsizeheight').focus();
//document.getElementById('txtcirculation').focus();


	
return false;
}
if(document.getElementById('txtsizeheight').value!="" && document.getElementById('txtsizewidth').value !="")
{

document.getElementById('txtarea').value=document.getElementById('txtsizeheight').value * document.getElementById('txtsizewidth').value;
//document.getElementById('txtcirculation').focus();
return false;
}


}

function fillwidth()
{
//document.getElementById('txtsizewidth1').value=document.getElementById('txtsizewidth').value;
if(document.getElementById('txtsizeheight').value=="" && document.getElementById('txtsizewidth').value =="")
{

document.getElementById('txtarea').value="";
//document.getElementById('txtcirculation').focus();
return false;
}
if(document.getElementById('txtsizeheight').value!="" && document.getElementById('txtsizewidth').value =="" )
{
document.getElementById('txtarea').value="";
//document.getElementById('txtsizewidth').focus();
//document.getElementById('txtcirculation').focus();

	
return false;
}
if(document.getElementById('txtsizeheight').value!="" && document.getElementById('txtsizewidth').value !="")
{

document.getElementById('txtarea').value=document.getElementById('txtsizeheight').value * document.getElementById('txtsizewidth').value;
//document.getElementById('txtcirculation').focus();
return false;
}

return false;

}





//////////////this is for pop up

//function submitclick()
//{

//var periodicity=document.getElementById('hiddenperiodicity').value;
////var EditonCode=document.getElementById('txtEditonCode').value;
//   
//popupedit.chkperiodicty(periodicity,callbck_periodicity);
//return false;
//}
var date;
function dateDifference(strDate1,strDate2)
{

datDate1= Date.parse(strDate1);

datDate2= Date.parse(strDate2);

date=(datDate2-datDate1)/(24*60*60*1000);
return;
}





function submitclick()
{
////this is to chk the periodicity





        var page;
        var edition="";
        var date1="";
        var date2="";
        var date3="";
        var ds="";

		 if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkperiodicity.aspx?page="+document.getElementById('hiddenperiodicity').value+"&edition="+edition+"&date1="+date1+"&date2="+date2+"&date3="+date3, false);
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
		xml.Open( "GET","chkperiodicity.aspx?page="+document.getElementById('hiddenperiodicity').value+"&edition="+edition+"&date1="+date1+"&date2="+date2+"&date3="+date3, false );
		xml.Send();
		ds=xml.responseText;
           }

var dateformat=document.getElementById('hiddendateformat').value;
var txtdate="";
var txtaddate="";
var year="";


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
var editcode=document.getElementById('hiddeneditcode').value; 
var year=document.getElementById('drpyear').value;



var result=popupedit.year2(year,compcode,txteditionname);

var ds=result.value;



if (ds.Tables[0].Rows.length > 0)
{
var year1=ds.Tables[0].Rows[0].YEAR;
if (year1!="" || year1!="null"|| year1==undefined)
{
alert('This year is Alredy Selected.');
return false;
}

}







if(edinsert!="1" && edinsert!=null)
{
//popupedit.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,call_insert);
if((document.getElementById('DataGrid1'))!=null  )
{
if(document.getElementById('DataGrid1').rows.length-1==1)
{
    alert('Single row should de inserted.');
    return false;
    }
} 
        var page="";
        var edition=editcode;
        var date1="";
        var date2="";
        var date3="";
      //  var year="";
          var id;

		 if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkperiodicity.aspx?page="+document.getElementById('hiddenperiodicity').value+"&edition="+edition+"&date1="+fromdate+"&date2="+todate+"&date3="+year, false );
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
		xml.Open( "GET","chkperiodicity.aspx?page="+document.getElementById('hiddenperiodicity').value+"&edition="+edition+"&date1="+fromdate+"&date2="+todate+"&date3="+year, false );
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
	 if(document.getElementById('htext').value=="mod")
	
	 {
	    edition="save";
	     var id;


        var dateformat=document.getElementById('hiddendateformat').value;
        var flag="0";
        
       
        
        
        
        
	    popupedit.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,year,call_insert);
	 
   	 window.location=window.location;
   	  return false;

	// return ;
	 }
      
      else
              
	{
	opener.document.getElementById('hiddeneditalias').value=txteditionname;
	opener.document.getElementById('hiddeneditdate').value=fromdate;
    opener.document.getElementById('hiddeneditaddate').value=todate;
    opener.document.getElementById('hiddenedityear').value=year;

    
    


return;
	}



}


}
else
{
opener.document.getElementById('hiddeneditalias').value=txteditionname;
opener.document.getElementById('hiddeneditdate').value=fromdate;
opener.document.getElementById('hiddeneditaddate').value=todate;
opener.document.getElementById('hiddenedityear').value=year;


popupedit.chkupdate(txteditionname,fromdate,todate,compcode,userid,editcode,code10,call_update);
//popupedit.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);
document.getElementById('btndelete').disabled=true;
edinsert="0";

}



return false;


}

function selectclick(ab)
{
var id=ab;
if(document.getElementById(id).checked==false)
{
//document.getElementById('txteditionname').value="";
document.getElementById('txtdate').value="0";
document.getElementById('txtaddate').value="0";
document.getElementById('drpyear').value="0";


document.getElementById('btndelete').disabled=true;
document.getElementById('btnsubmit').disabled=true;
document.getElementById(id).checked=false;

return;
}
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
var editcode=trim(document.getElementById('hiddeneditcode').value);

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
	    document.getElementById('btnsubmit').disabled=false;
	    }
	popupedit.selected(editcode,compcode,userid,code10,call_select12);
	
	}
	else if(k==0)
	{
	//chk123.checked=false;
	document.getElementById('txteditionname').value="";
    document.getElementById('txtdate').value="";
    document.getElementById('txtaddate').value="";
    document.getElementById('drpyear').value="";
	return false;
	}
	document.getElementById(ab).checked=true;
	
	//return false;



}










function call_select12(response)
{
var ds=response.value;
edinsert="1";
var txteditionname=document.getElementById('txteditionname').value=ds.Tables[0].Rows[0].Edition_Alias;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 

//this is for from date

/*if(ds.Tables[0].Rows[0].Date_Edition != null && ds.Tables[0].Rows[0].Date_Edition != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].Date_Edition;
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
	
	if(ds.Tables[0].Rows[0].AdditionalDate_Edit != null && ds.Tables[0].Rows[0].AdditionalDate_Edit != "")
	{

	var enrolldatet=ds.Tables[0].Rows[0].AdditionalDate_Edit;
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
*/
document.getElementById('txtdate').value=ds.Tables[0].Rows[0].Date_Edition;
document.getElementById('txtaddate').value=ds.Tables[0].Rows[0].AdditionalDate_Edit;

document.getElementById('drpyear').value=ds.Tables[0].Rows[0].YEAR;



return false;
}

function deletegridclick()
{

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var editcode=trim(document.getElementById('hiddeneditcode').value);
if(document.getElementById('DataGrid1').rows.length-1==1)
{
    alert('One row should be present here');
    return false;
} 

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
popupedit.deletegrid(editcode,compcode,userid,code10);
document.getElementById('txtaddate').enabled=true;
document.getElementById('txtdate').enabled=true;
document.getElementById('drpyear').enabled=true;




window.location=window.location;
return false;
}

//********************************************************
function clearclick()
{
document.getElementById('txtaddate').value="0";
document.getElementById('txtdate').value="0";
document.getElementById('drpyear').value="0";

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
            var editcode=document.getElementById('hiddeneditcode').value; 
            
            var year=document.getElementById('drpyear').value
            
            
            
            
            
            

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

opener.document.getElementById('hiddenedityear').value=year;


//opener.document.getElementById('hiddeneditalias').value="";
//opener.document.getElementById('hiddeneditdate').value="";
//opener.document.getElementById('hiddeneditaddate').value="";

 popupedit.insert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,year);		

document.getElementById('txteditionname').value="";
document.getElementById('txtdate').value="";
document.getElementById('txtaddate').value="";
document.getElementById('drpyear').value="";
window.location=window.location
    }
	//	window.location=window.location
		return false;
}

function call_update(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("This Date Has Been Assigned");
	return false;
	}
	else
		{
var txteditionname=document.getElementById('txteditionname').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=trim(document.getElementById('hiddeneditcode').value);
var txtdate=document.getElementById('txtdate').value;
var txtaddate=document.getElementById('txtaddate').value;
var year=document.getElementById('drpyear').value;

//this is for from date
/*if(dateformat=="dd/mm/yyyy")
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
}	*/

popupedit.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10,year);	
		}
		window.location=window.location
		return false;
}


function call_finallychkperiodictyjs()
{

var txteditionname=document.getElementById('hiddeneditalias').value ;
var txtdate=document.getElementById('hiddeneditdate').value;
var txtaddate=document.getElementById('hiddeneditaddate').value;
var year=document.getElementById('hiddenedityear').value;
//opener.document.getElementById('hiddenedityear').value=year;

// var dschk=res.value;
if(hiddentext !="modify")
{
        if((txtdate=="")&&(txtaddate==""))
          {
          alert("Please Fill Edition Issue Date");
          return false;
          }  
          else if((gbchkperiod=="2")&&((txtdate=="")||(txtdate==null)))
          {
          alert("Please Fill First Cycle Date In Edition Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="3") && ((txtaddate=="")||(txtaddate==null)))
          {
          alert("Please Fill Month In Edition Issue Date Pop-Up");
          return false;
          }
          else if((gbchkperiod=="4") && ((txtdate=="")||(txtdate==null))&& ((txtaddate=="")||(txtaddate==null)))
          {
          alert("Please Fill First and Second Cycle Date In Edition Issue Date Pop-Up");
          return false;
          }
  }        
  //else
  //{
    call_finallysavemodify();
    return false;
 // }



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

//////////This function is used to generate alias name depending on publication name,edition name and city///////////////
function fillalias_modify()
{
document.getElementById('txtAlias').value="";

 if((document.getElementById('txtEditionName').value!="")&&(document.getElementById('drpPubName').value!="0")&&(document.getElementById('drpcity').value!="0"))
		          {
                   str=document.getElementById('txtEditionName').value;
                 strpub=document.getElementById('drpPubName').value;
                 strcity=document.getElementById('drpcity').value;
               
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
EditorMaster.editmaster(str,strpub,strcity,fill_aliascall);
		      // document.getElementById('txtAlias').focus();
		        }
		        
	
		
		  return false;
  }
function checkgutter()
{
     var num=document.getElementById('txtgutterspace').value;
	 var tomatch=/^\d*(\.\d{1,2})?$/;
     if (tomatch.test(num))
     {
		return true;
     }
     else
     {
         alert("Input error");
        
         document.getElementById('txtgutterspace').value="";
          document.getElementById('txtgutterspace').focus();
         return false; 
     }
}
function checkcolumn()
{
     var num=document.getElementById('txtcolumnspace').value;
	 var tomatch=/^\d*(\.\d{1,2})?$/;
     if (tomatch.test(num))
     {
		return true;
     }
     else
     {
         alert("Input error");
             document.getElementById('txtcolumnspace').value="";
         document.getElementById('txtcolumnspace').focus();
     
         return false; 
     }
}       
function chkmins()
{
var i=parseInt(document.getElementById('txtmin').value);
if(document.getElementById('txtmin').value!="")
{
    if (i>60)
    {
            alert("The minutes should not be greater than 60 ");
            document.getElementById('txtmin').value="";
            document.getElementById('txtmin').focus();
            return false;
    }
}
}


function chkbox_periodicity()
{
EditorMaster.blankSession();
    var periodicity=document.getElementById('drperiodicity').value;
    if(periodicity=="0")
    {
        return;
    }
    else
    {
     //EditorMaster.chkperiodicty(periodicity,callbck_periodicitychkbox);
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
EditorMaster.chkperiodicty(periodicity, "foredition", "", "", "",callbck_periodicitychkbox);
    }
    return false;
}

            
            
      function callbck_periodicitychkbox(response)     
      { 
      var ds=response.value;
      var EditonCode=document.getElementById('txtEditonCode').value;
     
      if((ds.Tables[0].Rows[0].ValidationCode!="1")&&(ds.Tables[0].Rows[0].ValidationCode!="5") &&(ds.Tables[0].Rows[0].ValidationCode!="4")&&(ds.Tables[0].Rows[0].ValidationCode!="2"))
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
		document.getElementById('CheckBox8').disabled = true;


		document.getElementById('txt1').disabled = true;
		document.getElementById('txt2').disabled = true;
		document.getElementById('txt3').disabled = true;
		document.getElementById('txt4').disabled = true;
		document.getElementById('txt5').disabled = true;
		document.getElementById('txt6').disabled = true;
		document.getElementById('txt7').disabled = true;
		document.getElementById('txt8').disabled = true;
            }
            if((ds.Tables[0].Rows[0].ValidationCode=="4")||(ds.Tables[0].Rows[0].ValidationCode=="2") ||(ds.Tables[0].Rows[0].ValidationCode=="3"))
            {
                    strpub=document.getElementById('drpPubName').value;
                    var response5=EditorMaster.enablechkbox(strpub)
                    var ds1=response5.value;
                        kchk=0;
                        if(ds1.Tables[0].Rows.length>0)
                        {
                            var sun=ds1.Tables[0].Rows[0].sun;
                            var mon=ds1.Tables[0].Rows[0].mon;
                            var tue=ds1.Tables[0].Rows[0].tue;
                            var wed=ds1.Tables[0].Rows[0].wed;
                            var thu=ds1.Tables[0].Rows[0].thu;
                            var fri=ds1.Tables[0].Rows[0].fri;
                            var sat=ds1.Tables[0].Rows[0].sat;
                            var all=ds1.Tables[0].Rows[0].all;

                        if(sun=="Y")
                            {

                                document.getElementById('CheckBox1').disabled = false;
                                document.getElementById('txt1').disabled = false;
                            kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox1').disabled=true;
                            document.getElementById('CheckBox1').checked = false;
                            document.getElementById('txt1').disabled = true;
                          
                            }

                        if(mon=="Y")
                            {

                                document.getElementById('CheckBox2').disabled = false;
                                document.getElementById('txt2').disabled = false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox2').disabled=true;
                            document.getElementById('CheckBox2').checked = false;
                            document.getElementById('txt2').disabled = true;
                          
                            }
                        if(tue=="Y")
                            {

                                document.getElementById('CheckBox3').disabled = false;
                                document.getElementById('txt3').disabled = false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox3').disabled=true;
                            document.getElementById('CheckBox3').checked = false;
                            document.getElementById('txt3').disabled = true;
                          
                            }
                        if(wed=="Y")
                            {
                           kchk++;
                           document.getElementById('CheckBox4').disabled = false;
                           document.getElementById('txt4').disabled = false;
                            }
                        else
                            {
                            document.getElementById('CheckBox4').disabled=true;
                            document.getElementById('CheckBox4').checked = false;
                            document.getElementById('txt4').disabled = true;
                          
                            }
                        if(thu=="Y")
                            {

                                document.getElementById('CheckBox5').disabled = false;
                                document.getElementById('txt5').disabled = false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox5').disabled=true;
                            document.getElementById('CheckBox5').checked = false;
                            document.getElementById('txt5').disabled = true;
                          
                            }
                        if(fri=="Y")
                            {

                                document.getElementById('CheckBox6').disabled = false;
                                document.getElementById('txt6').disabled = false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox6').disabled=true;
                            document.getElementById('CheckBox6').checked = false;
                            document.getElementById('txt6').disabled = true;
                          
                            }
                        if(sat=="Y")
                            {

                                document.getElementById('CheckBox7').disabled = false;
                                document.getElementById('txt7').disabled = false;
                             kchk++;
                            }
                        else
                            {
                            document.getElementById('CheckBox7').disabled=true;
                            document.getElementById('CheckBox7').checked = false;
                            document.getElementById('txt7').disabled = true;
                          
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
                            document.getElementById('CheckBox8').disabled = false;

                            document.getElementById('txt1').disabled = false;
                            document.getElementById('txt2').disabled = false;
                            document.getElementById('txt3').disabled = false;
                            document.getElementById('txt4').disabled = false;
                            document.getElementById('txt5').disabled = false;
                            document.getElementById('txt6').disabled = false;
                            document.getElementById('txt7').disabled = false;
                            document.getElementById('txt8').disabled = false;
                            }
                        else
                             {
                                 if ((sun == "N") && (mon == "N") && (tue == "N") && (wed == "N") && (thu == "N") && (fri == "N") && (sat == "N"))
                                  {
                                      document.getElementById('CheckBox8').disabled = true;
                                      document.getElementById('txt8').disabled = true;
                                 }
                                 else {
                                     document.getElementById('CheckBox8').disabled = false;
                                     document.getElementById('txt8').disabled = false;
                                 }
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
                            document.getElementById('CheckBox8').disabled = true;

                            document.getElementById('txt1').disabled = true;
                            document.getElementById('txt2').disabled = true;
                            document.getElementById('txt3').disabled = true;
                            document.getElementById('txt4').disabled = true;
                            document.getElementById('txt5').disabled = true;
                            document.getElementById('txt6').disabled = true;
                            document.getElementById('txt7').disabled = true;
                            document.getElementById('txt8').disabled = true;
                          
                            }

                            document.getElementById('CheckBox8').checked = true;
                            document.getElementById('txt8').disabled = true;
                    if(document.getElementById('CheckBox1').disabled==false)
                    {
                       document.getElementById('CheckBox1').checked=true;
                       document.getElementById('CheckBox1').disabled = true;
                       document.getElementById('txt1').disabled = true;
                    }
                    if(document.getElementById('CheckBox2').disabled==false)
                    {
                       document.getElementById('CheckBox2').checked=true;
                       document.getElementById('CheckBox2').disabled = true;
                       document.getElementById('txt2').disabled = true;
                    }
                    if(document.getElementById('CheckBox3').disabled==false)
                    {
                       document.getElementById('CheckBox3').checked=true;
                       document.getElementById('CheckBox3').disabled = true;
                       document.getElementById('txt3').disabled = true;
                    }
                    if(document.getElementById('CheckBox4').disabled==false)
                    {
                       document.getElementById('CheckBox4').checked=true;
                       document.getElementById('CheckBox4').disabled = true;
                       document.getElementById('txt4').disabled = true;
                    }
                    if(document.getElementById('CheckBox5').disabled==false)
                    {
                       document.getElementById('CheckBox5').checked=true;
                       document.getElementById('CheckBox5').disabled = true;
                       document.getElementById('txt5').disabled = true;
                    }
                    if(document.getElementById('CheckBox6').disabled==false)
                    {
                       document.getElementById('CheckBox6').checked=true;
                       document.getElementById('CheckBox6').disabled = true;
                       document.getElementById('txt6').disabled = true;
                    }
                    if(document.getElementById('CheckBox7').disabled==false)
                    {
                       document.getElementById('CheckBox7').checked=true;
                       document.getElementById('CheckBox7').disabled = true;
                       document.getElementById('txt7').disabled = true;
                    }
                       document.getElementById('CheckBox8').checked=true;
                       document.getElementById('CheckBox8').disabled = true;
                       document.getElementById('txt8').disabled = true;
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
EditorMaster.enablechkbox(strpub,fillchk_callback);
            return false;
      
          if(document.getElementById('CheckBox1').disabled==true)
          {
              document.getElementById('CheckBox1').disabled = true;
              document.getElementById('txt1').disabled = true;
          }
          else
          {
              document.getElementById('CheckBox1').disabled = false;
              document.getElementById('txt1').disabled = false;
          }
          
            if(document.getElementById('CheckBox2').disabled==true)
            {
                document.getElementById('CheckBox2').disabled = true;
                document.getElementById('txt2').disabled = true;
            }
            else
            {
		    document.getElementById('CheckBox2').disabled=false;
		     document.getElementById('txt2').disabled = false;
		    }
		    
		    if(document.getElementById('CheckBox3').disabled==true)
		    {
		    document.getElementById('CheckBox3').disabled=true;
		     document.getElementById('txt3').disabled = true;
		    }
		    else
		    {
		    document.getElementById('CheckBox3').disabled=false;
		     document.getElementById('txt3').disabled = false;
		    
		    }
		    
		    if(  document.getElementById('CheckBox4').disabled==true)
		    {
		      document.getElementById('CheckBox4').disabled=true;
		       document.getElementById('txt4').disabled = true;
		    }
		    else
		    {
		    document.getElementById('CheckBox4').disabled=false;
		     document.getElementById('txt4').disabled = false;
		    }
		    if(  document.getElementById('CheckBox5').disabled==true)
		    {
		      document.getElementById('CheckBox5').disabled=true;
		       document.getElementById('txt5').disabled = true;
		    }
		    else
		    {
		    document.getElementById('CheckBox5').disabled=false;
		     document.getElementById('txt5').disabled = false;
		    }
		    
		    if(document.getElementById('CheckBox6').disabled==true)
		    {
		    document.getElementById('CheckBox6').disabled=true;
		     document.getElementById('txt6').disabled = true;
		    }
		    else
		    {
		    document.getElementById('CheckBox6').disabled=false;
		     document.getElementById('txt6').disabled = false;
		    }
		    if(document.getElementById('CheckBox7').disabled==true)
		    {
		    document.getElementById('CheckBox7').disabled=true;
		     document.getElementById('txt7').disabled = true;
		    }
		    else
		    {
		    document.getElementById('CheckBox7').disabled=false;
		     document.getElementById('txt7').disabled = false;
		    }
		    if( document.getElementById('CheckBox8').disabled==true)
		    {
		     document.getElementById('CheckBox8').disabled=true;
		      document.getElementById('txt8').disabled = true;
		    }
		    else
		    {
		    document.getElementById('CheckBox8').disabled=false;
		     document.getElementById('txt8').disabled = false;
		    }
            }
return false;
       }
       
function fillname()
{
    if(hiddentext!="query")
    {
    if(document.getElementById('drpeditiontype').value=="Main Edition")
    {   
        document.getElementById('txtAlias').value="";
        document.getElementById('txtEditonCode').value="";
        document.getElementById('txtEditionName').value="MAIN";
        document.getElementById('txtEditionName').disabled=false;
        return false; 
    }
    else
    {
        document.getElementById('txtAlias').value="";
        document.getElementById('txtEditionName').value="";
        document.getElementById('txtEditonCode').value="";
        document.getElementById('txtEditionName').disabled=false;
        return false; 
    }
    }   
    return;
} 

//function to check circulations validity
function chkcirculations()
{
var PubName=document.getElementById('drpPubName').value;
//var CodeName=document.getElementById('drpeditiontype').value;
var CityName=document.getElementById('drpcity').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
if(document.getElementById('hiddensolorate').value!="solo")
{
if(document.getElementById('drpeditiontype').value!="Main Edition")
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
EditorMaster.circulation(PubName,CityName,compcode,userid,call_circ_chk);
}
}
}
//end
//response for circulation
function call_circ_chk(response01)
{
var ds=response01.value;
var len=0;
for(var i=0;i<ds.Tables[1].Rows.length;++i)
{
len=len+parseInt(ds.Tables[1].Rows[i].No_Of_Circulation);
}
var len1=parseInt(ds.Tables[0].Rows[0].No_Of_Circulation)-len;
len=len+parseInt(document.getElementById('txtcirculation').value);

if(len>parseInt(ds.Tables[0].Rows[0].No_Of_Circulation))
{
alert("No of circulations exceeds maximum value (Maximum value can be: "+len1+" )");
document.getElementById('txtcirculation').value="";
document.getElementById('txtcirculation').focus();
return false;
}
}
/*new change ankur 11 feb*/
function  givetheperidicity()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var period=parseFloat(document.getElementById('txtnoofcol').value);
    if(document.getElementById('drpPubName').value=="0")
    {
        alert("Please select the publication");
        document.getElementById('drpPubName').focus();
        return false;
    }
    else if(document.getElementById('txtAlias').value=="")
    {
        alert("Please get the edition alias name");
        return false;
    }
    else if(period=="")
    {
        alert("Please get Priority");
        document.getElementById('txtnoofcol').focus();
        return false;
    }
    /*new change ankur 27 feb*/
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
EditorMaster.chkperiodicityno(document.getElementById('drpPubName').value,document.getElementById('txtEditonCode').value,period,compcode,flag,call_getperiodno);
    //return false;

}
function call_getperiodno(res)
{
    var ds=res.value;
    if(ds.Tables!=null && ds.Tables!=undefined)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            alert("This Priority has been assigned to "+ds.Tables[0].Rows[0].alias+" please get another");
            if(document.getElementById('txtnoofcol').disabled==false)
            {
                document.getElementById('txtnoofcol').focus();
            }
            return false;
        
        }
    
    }
//return false;
}

//
function LTrim( value ) {
	
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
//////////////////////////////////////

/////new change
function ClientUpperCase2()
{
document.getElementById('txtEditonCode').value=document.getElementById('txtEditonCode').value.toUpperCase();
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
if(hiddentext=="new")
{
var res2=EditorMaster.editioncodecheck(document.getElementById('txtEditonCode').value,compcode,userid);

           var ds3=res2.value;
			if(ds3.Tables[0].Rows.length!=0)
			{
                alert("This Edition Code already Exists");
				document.getElementById('txtEditonCode').value="";
                document.getElementById('txtEditonCode').focus();
				return false;
			}	
}
//return false;
}
//////////////////
function chkhor()
{
if(document.getElementById('txthr').value>=25)
{
alert("RO Time value should be less than 24");
document.getElementById('txthr').value="";
return false;
}
return false;
}


function chkmin()
{
if(document.getElementById('txtmin').value>=61)
{
alert("RO Minutes value should be less than 60");
document.getElementById('txtmin').value="";
return false;
}
return false;
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


function chkecod()
{

 if(hiddentext=="new")
        {
 var ecode=trim(document.getElementById('txtEditonCode').value);
        var compcode=document.getElementById('hiddencompcode').value; 
       resd=EditorMaster.ecodechk(compcode,ecode);
       var ds=resd.value;
		if(ds.Tables[0].Rows.length!=0)
		    
		    {
		    alert("This Edition code has already assigned!! ");
		    document.getElementById('txtEditonCode').focus();
		    document.getElementById('txtEditonCode').value="";
		    return false;
		    }
}
//return true;
}

//////////////////////



///////////////////////////////////////New change SEGMENT  BIND/////////////////////////////////

function fillsegment(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtsegment") {
            $('lstsegment').value = "";
            var compcode = $('hiddencompcode').value;
            var dateformat = $('hiddendateformat').value;

            var extra2 = "";
            var extra1 = "";

            activeid = document.activeElement.id;
            aTag = eval(document.getElementById(activeid))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('divsegment').scrollLeft;
            var scrolltop = document.getElementById('divsegment').scrollTop;
            document.getElementById('divsegment').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('divsegment').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



            $("divsegment").style.display = "block";


            $('lstsegment').focus();
            EditorMaster.bind_segment(compcode, dateformat, extra1, extra2,bind_segment_callback)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
        $('txtsegment').value = "";
        $('hdnsegment').value = "";

        return false;
    }

    else if (event.ctrlKey == true && event.keyCode == 88) {
        $('txtsegment').value = "";
        $('hdnsegment').value = "";

        return false;
    }
    else if (event.keyCode == 9) {
        return event.keyCode;
    }

    return true;
}

function onclicksegment(event) {
    var browser = navigator.appName;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstsegment") {
            if ($('lstsegment').value == "0") {
                $('txtsegment').value = "";
                $('hdnsegment').value = "";
                $("divsegment").style.display = "none";
                $('txtsegment').focus();
                return false;
            }
            $("divsegment").style.display = "none";
            var page = $('lstsegment').value;
            agencycodeglo = page;
            for (var k = 0; k <= $("lstsegment").length - 1; k++) {
                if ($('lstsegment').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = $('lstsegment').options[k].textContent;
                    }
                    else {
                        var abc = $('lstsegment').options[k].innerText;
                    }
                    //var abc=$('lstsegment').options[k].innerText;
                    var fival = abc.split("-");
                    $('txtsegment').value = fival[0];
                    $('hdnsegment').value = fival[1];
                    $('txtsegment').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
        $('divsegment').style.display = "none";
        $('txtsegment').focus();
        return false;
    }
}
function bind_segment_callback(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        var pkgitem = $("lstsegment");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Segment -", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SEG_DESC + "-" + ds.Tables[0].Rows[i].SEG_CODE, ds.Tables[0].Rows[i].SEG_CODE);


            pkgitem.options.length;
        }
    }
    $("lstsegment").value = "0";
    return false;
}

//////////////////////////

function getcentername(centcod) 
{
    var centname = "";
    var compcode = document.getElementById('hiddencompcode').value;
    var aa = EditorMaster.getcentername(compcode, centcod);
    var ds = aa.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        centname = ds.Tables[0].Rows[0].COST_CENTER_NAME;
    }
    else {
        centname = ds.Tables[0].Rows[0].COST_CENTER_NAME;
    }

    return centname;

}


function compare() {
    var aa = parseFloat(document.getElementById('txtarea').value);
    var bb =parseFloat(document.getElementById('txtgutterspace').value);
    if (aa< bb) {
        alert('Gutter Width should not be greater then page area')
        document.getElementById('txtgutterspace').value = "";
    document.getElementById('txtgutterspace').focus();
    return false;
   
    }
    }



function compare1() 
{
    var aa = parseFloat(document.getElementById('txtarea').value);
    var bb =parseFloat(document.getElementById('txtcolumnspace').value);
    if (aa< bb) {
        alert('Column Width should not be greater then page area')
        document.getElementById('txtcolumnspace').value = "";
    document.getElementById('txtcolumnspace').focus();
    return false;
   
    }



}


function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 45) || (charCode == 8) ||  (charCode >= 48 && charCode <= 57))
        return true;
    else
        return false;
}





/*---------------------------------------*/
function txtckeckvalue(id,event)
 {
     var ectiveid = id;

     if (document.getElementById(ectiveid).value != "") 
    {
        var j = 0;
        var i = 23;

        var pageno = document.getElementById(ectiveid).value;
        if (j <= pageno && i >= pageno) {
           // document.getElementById(ectiveid).focus();
            return true;
        }
        else 
        {
            alert("Please enter value less than 24 ");
            document.getElementById(ectiveid).value = "";
            document.getElementById(ectiveid).focus();
            return false;
        }
    }
    else 
    {
        return true;
    }
    return false;
}



function call_backclear() {

    document.getElementById('txt1').value = "";
    document.getElementById('txt2').value = "";
    document.getElementById('txt3').value = "";
    document.getElementById('txt4').value = "";
    document.getElementById('txt5').value = "";
    document.getElementById('txt6').value = "";
    document.getElementById('txt7').value = "";


    document.getElementById('txt1').disabled = true;
    document.getElementById('txt2').disabled = true;
    document.getElementById('txt3').disabled = true;
    document.getElementById('txt4').disabled = true;
    document.getElementById('txt5').disabled = true;
    document.getElementById('txt6').disabled = true;
    document.getElementById('txt7').disabled = true;

    return false;
}


/////////// Added By DIMPY //////////

function opencirc() {
if(document.getElementById('drpPubName').value=="0")
 {
    alert('Please Select Publication Name');
    document.getElementById('drpPubName').focus();
    return false;
 }
 if(document.getElementById('drpeditiontype').value=="0")
 {
 alert('Please Select Edition Type');
    document.getElementById('drpeditiontype').focus();
    return false;
 }
if((document.getElementById('txtEditonCode').value=="")&& (document.getElementById('hiddenauto').value!=1)&&(txtcod.indexOf("*")>=0))
    {
     alert('Please Enter The Edition Code');
    document.getElementById('txtEditonCode').focus();
    //return false;
      return false;
   }
  else
     {
     var editcode=document.getElementById('txtEditonCode').value;
     }
  if((document.getElementById('txtEditionName').value=="")&&(txteditionnam.indexOf("*")>=0))
    {
         alert('Please Enter The Edition Name');
         document.getElementById('txtEditionName').focus();
         return false;
    }
    else
     {
     var EditionName=document.getElementById('txtEditionName').value;
     }
     
   if(document.getElementById('txtcountry').value=="0")
    {
         alert('Please Select the Country');
         document.getElementById('txtcountry').focus();
         return false;
    }
    else
     {
      var country=document.getElementById('txtcountry').value;
     }
    if(document.getElementById('drpcity').value=="0")
        {
         alert('Please Select Publication Center');
         document.getElementById('drpcity').focus();
         return false;
    }
     else
     {
     var CityName=document.getElementById('drpcity').value;
     }
    if(document.getElementById('drpprintcent').value=="0")
    {
         alert('Please Select Physical Printing Center');
         if(document.getElementById('drpprintcent').disabled==false)
         document.getElementById('drpprintcent').focus();
         return false;
    }
   
   if(document.getElementById('drperiodicity').value=="0")
        {
            alert('Please Select The Periodicity');
            document.getElementById('drperiodicity').focus();
            return false;
        }
    else
         {
            var periodicity=document.getElementById('drperiodicity').value;
          }
        var popwin2=window.open("editiormast_pop.aspx?&cityname="+ CityName + "&editioncode=" + editcode + "&type=" + extype + "", "", "resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px");
 popwin2.focus();
 return false;
 }
        
var statcode = "";
var distcode = "";
function filldistrict() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    if (extype == "query") {
        statecode = document.getElementById('hidnstate').value;
    }
    else{
    statcode = document.getElementById('drpState').value;
    }
    editiormast_pop.filldistrict(statcode, compcode, userid, calldist);
    return false;
}
function calldist(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("drpdistrct");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById('drpdistrct');
        pkgitem.options[0] = new Option("----Select District----", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Dist_Name, res.value.Tables[0].Rows[i].Dist_Code);
            pkgitem.options.length;
        }
    }
    else {
        alert("There Is No Matching Value Found");
        pkgitem.options.length = 1;
        return false;
    }
    return false;
}
function fillcity() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    statcode = document.getElementById('drpState').value;
    distcode = document.getElementById('drpdistrct').value;
    editiormast_pop.fillcity(distcode, statcode, compcode, userid, callCity);
    return false;
}
function callCity(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("drpCity");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById('drpCity');
        pkgitem.options[0] = new Option("----Select City----", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);
            pkgitem.options.length;
        }
    }
    else {
        alert("There Is No Matching Value Found");
        pkgitem.options.length = 1;
        return false;
    }
    return false;
}

function btnsave() {
    var comcode = document.getElementById('hiddencompcode').value;
    var editioncode=document.getElementById('edicod').value;
    if (document.getElementById('txtcrcu').value == "") {
        alert("Please Enter Circulation NO");
        document.getElementById('txtcrcu').focus();
        return false;
    }
    else {
        var crcuno = document.getElementById('txtcrcu').value;
    }
    if (document.getElementById('txtno').value == "") {
        alert("Please Enter ReaderShip Number");
        document.getElementById('txtno').focus();
        return false;
    }
    else {
        var rdrsno = document.getElementById('txtno').value;
    }
//    if (document.getElementById('drpState').value == "") {
//        alert("Please Enter State");
//        document.getElementById('drpState').focus();
//        return false;
//    }
//    else {
//        if (browser != "Microsoft Internet Explorer") {
//        var state = document.getElementById('drpState').textContent;
//    }
//    else {
//        var state = document.getElementById('drpState').innerText;
//    }
//    }
//    if (document.getElementById('drpdistrct').value == "") {
//        alert("Please Enter District");
//        document.getElementById('drpdistrct').focus();
//        return false;
//    }
//    else {
//       if (browser != "Microsoft Internet Explorer") {
//        var district = document.getElementById('drpdistrct').textContent;
//    }
//    else {
//        var district = document.getElementById('drpdistrct').innerText;
//    }
//    }
//    if (document.getElementById('drpCity').value == "") {
//        alert("Please Enter City");
//        document.getElementById('drpCity').focus();
//        return false;
//    }
//    else {
//        if (browser != "Microsoft Internet Explorer") {
//        var city = document.getElementById('drpCity').textContent;
//    }
//    else {
//        var city = document.getElementById('drpCity').innerText;
//    }
//    }
////    if (browser != "Microsoft Internet Explorer") {
//        var state = document.getElementById('drpState').textContent;
//    }
//    else {
//        var state = document.getElementById('drpState').innerText;
//    }
//    if (browser != "Microsoft Internet Explorer") {
//        var district = document.getElementById('drpdistrct').textContent;
//    }
//    else {
//        var district = document.getElementById('drpdistrct').innerText;
//    }
//    if (browser != "Microsoft Internet Explorer") {
//        var city = document.getElementById('drpCity').textContent;
//    }
//    else {
//        var city = document.getElementById('drpCity').innerText;
//    }
    var state = document.getElementById('drpState').value;
    var district = document.getElementById('drpdistrct').value;
    var city = document.getElementById('drpCity').value;
    var pseq = editiormast_pop.getseq();
    pseq = pseq.value;

    opener.document.getElementById('hidccode').value = comcode;
    opener.document.getElementById('hidcrcu').value = crcuno;
    opener.document.getElementById('hidrdrno').value = rdrsno;
    opener.document.getElementById('hidstate').value = state;
    opener.document.getElementById('hiddist').value = district;
    opener.document.getElementById('hidcty').value = city;
    opener.document.getElementById('hidseq').value = pseq;

    editiormast_pop.saveinfo(pseq, comcode, crcuno, rdrsno, state, district, city,editioncode);
     editiormast_pop.mainsaveinfo(pseq, comcode, crcuno, rdrsno, state, district, city,editioncode);
    //mainsave(editioncode);
    alert("Data save Sucessfully");
    document.getElementById('drpState').value="0";
    document.getElementById('drpdistrct').value="0";
    document.getElementById('drpCity').value="0";
    document.getElementById('txtcrcu').value="";
    document.getElementById('txtno').value="";
    document.getElementById('chklistsubmit').selected=false;
    }
function mainsave(edcode) {
    var comcode = document.getElementById('hidccode').value;
    var pcrcu = document.getElementById('hidcrcu').value;
    var prdrno = document.getElementById('hidrdrno').value;
    var pstate = document.getElementById('hidstate').value;
    var pdist = document.getElementById('hiddist').value;
    var pcty = document.getElementById('hidcty').value;
    var pseq = document.getElementById('hidseq').value;
    EditorMaster.mainsaveinfo(pseq, comcode, pcrcu, prdrno ,pstate ,pdist ,pcty ,edcode);
}
function btnmodify() {
    var comcode = document.getElementById('hiddencompcode').value;
    var pcrcu = document.getElementById('txtcrcu').value;
    var prdrno = document.getElementById('txtno').value;
    var pstate = document.getElementById('drpState').value;
    var pdist = document.getElementById('drpdistrct').value;
    var pcty = document.getElementById('drpCity').value;
    var pseq = document.getElementById('hidseq').value;
    var tseq=codeexe;
    editiormast_pop.mainupdateinfo(tseq, comcode, pcrcu, prdrno, pstate, pdist, pcty);
    editiormast_pop.tempupdateinfo(tseq, comcode, pcrcu, prdrno, pstate, pdist, pcty);
    alert("Data Updated Sucessfully");
    document.getElementById('drpState').value="0";
    document.getElementById('drpdistrct').value="0";
    document.getElementById('drpCity').value="0";
    document.getElementById('txtcrcu').value="";
    document.getElementById('txtno').value="";
    //window.close();
}

function btndelete() {
    var comcode = document.getElementById('hiddencompcode').value;
    var pcrcu = document.getElementById('txtcrcu').value;
    var prdrno = document.getElementById('txtno').value;
    var pstate = document.getElementById('drpState').value;
    var pdist = document.getElementById('drpdistrct').value;
    var pcty = document.getElementById('drpCity').value;
    var pseq = document.getElementById('hidseq').value; var pseq = document.getElementById('hidseq').value;
    var tseq=codeexe;
    editiormast_pop.maindeleteinfo(tseq, comcode);
    editiormast_pop.tempdeleteinfo(tseq, comcode);
    alert("Data Deleted Sucessfully");
    document.getElementById('drpState').value="0";
    document.getElementById('drpdistrct').value="0";
    document.getElementById('drpCity').value="0";
    document.getElementById('txtcrcu').value="";
    document.getElementById('txtno').value="";
    //window.close();
}
/////////////////add by mohit/////////////
var cl;
    function selected(id) {
        var compcode = document.getElementById("hiddencompcode").value; ;
        var userid = document.getElementById("hiddenuserid").value;
        var j;
        var k = 0;
        cl = id;
        if (document.getElementById(id).checked == false) {
            document.getElementById(id).checked = false;
             document.getElementById('drpState').value="0";
    document.getElementById('drpdistrct').value="0";
    document.getElementById('drpCity').value="0";
    document.getElementById('txtcrcu').value="";
    document.getElementById('txtno').value="";
            codeexe = "";
            return;
        }
        var i = document.getElementById("contactgrid").rows.length - 1;
        for (j = 0; j < i; j++) {
            var str = "DataGrid1__ctl_CheckBox1" + j;
            document.getElementById(str).checked = false;
            document.getElementById(id).checked = true;
            if (document.getElementById(id).checked == true) {
                k = k + 1;
                codeexe = document.getElementById(id).value;
            }
        }
        editiormast_pop.fillgridtxt(compcode, codeexe, call_selectexe);
        return;
    }
    
    function call_selectexe(res) {
        var ds = res.value;
        
        if (ds.Tables[0].Rows[0].CIRC_NO != null) {
            document.getElementById('txtcrcu').value = ds.Tables[0].Rows[0].CIRC_NO;
        }
        else {
            document.getElementById("txtcrcu").value = "";
        }
        if (ds.Tables[0].Rows[0].READER_NO != null) {
            document.getElementById('txtno').value = ds.Tables[0].Rows[0].READER_NO;
        }
        else {
            document.getElementById("txtno").value = "";
        }
//        if (ds.Tables[0].Rows[0].STATE != null) {
//            document.getElementById('drpState').value = ds.Tables[0].Rows[0].STATE;
//        }
//        else {
//            document.getElementById("drpState").value = "";
//        }
//        if (ds.Tables[0].Rows[0].DISTRICT != null) {
//        binddist();
//            document.getElementById('drpdistrct').value = ds.Tables[0].Rows[0].DISTRICT;
//        }
//        else {
//            document.getElementById("drpdistrct").value = "";
//        }
//        
//        if (ds.Tables[0].Rows[0].CITY != null) {
//        bindcity();
//            document.getElementById('drpCity').value = ds.Tables[0].Rows[0].CITY;
//        }
//        else {
//            document.getElementById("drpCity").value = "";
//        }
//               
        return false;
    }
 function binddist()
{
 var compcode = document.getElementById('hiddencompcode').value;
 var userid = document.getElementById('hiddenuserid').value;
statecode = document.getElementById('drpState').value;
var response=editiormast_pop.filldistrict(statecode, compcode, userid);
var ds=response.value;
var i;
/*NEW CHANGE ANKUR 11 FEB*/
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
                    var bindname=document.getElementById('drpdistrct');
                    bindname.options[0]=new Option("----Select District----","0");

                    bindname.options.length=1;

                    for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
                    {
                    bindname.options[bindname.options.length]=new Option(ds.Tables[0].Rows[i].Dist_Name,ds.Tables[0].Rows[i].Dist_Code);
                    bindname.options.length;
                    }
              }
            else
            {
                  document.getElementById('drpdistrct').options.length=0;
            document.getElementById('drpdistrct').options[0]=new Option("----Select District----","0");
           // alert("There is No Matching value Found");
            return false;

            }
 return false;
}
function bindcity()
{
 var compcode = document.getElementById('hiddencompcode').value;
 var userid = document.getElementById('hiddenuserid').value;
statecode = document.getElementById('drpState').value;
distcode = document.getElementById('drpdistrct').value;
   var response= editiormast_pop.fillcity(distcode, statecode, compcode, userid);
var ds=response.value;
var i;
/*NEW CHANGE ANKUR 11 FEB*/
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
                    var bindname=document.getElementById('drpCity');
                    bindname.options[0]=new Option("----Select City----","0");

                    bindname.options.length=1;

                    for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
                    {
                    bindname.options[bindname.options.length]=new Option(ds.Tables[0].Rows[i].City_Name,ds.Tables[0].Rows[i].City_Code);
                    bindname.options.length;
                    }
            }
            else
            {
                  document.getElementById('drpCity').options.length=0;
            document.getElementById('drpCity').options[0]=new Option("----Select City----","0");
           // alert("There is No Matching value Found");
            return false;

            }
 return false;
}
