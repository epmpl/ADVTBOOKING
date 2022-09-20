// JScript File
var cmb;
var supp;
var supp1
var k="";
var chk="0";;
var chknamemod;
var show="0";
var varchk;
var z="0";

var mod="";
var hiddentext;
var auto="";
var hiddentext1="";
var kprapp="0";
var mdlast="0";

//Variable declare for execute
var Advpageexecute;
//Variable declare for global
var glapremiumcode;
var glaadvtype;
var glaadcategory;
var glapublication;
var glaedition;
var glacolor;
var glarategroup;
var glaadsize;
var glapageno;
var glaspecialposition;
var glapremium;
var glavalidfrom;
var glapremiumname;
var glasupplement;

var lchk=0;
var kchk=0;

//******************************************************************************************************************
//*************************************Select Messages From XML****************************************************
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
    advpageCancelclick('AdvPagePositionMaster');

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




function multiple()
		{
		        var premiumcode=document.getElementById('premcode').value;
		      
		    
        		
		        var ab;
		        //alert(special);
		        if(premiumcode!=null && premiumcode!="")
		        {
		        for ( var index = 0; index < 200; index++ ) 
                       { 
		                    //window.open('multi_adsize.aspx');
		                    popup=window.open('multi_adcategory.aspx?premiumcode='+premiumcode+'&chk='+chk+'&show='+show,'xyz','status=0,toolbar=0,resizable=0,top=205,left=573,top=205,left=800,width=200px,height=130px');
		                    popup.focus();
                    		
		            return false;
			            }
		        }
		        else
		            {
		            alert("Please Enter Premium Code");
		            return false;
		            }
		  return false;
		}
		
		//*******************************************************************************************//
		//****************************Function For New click****************************************//
		//*******************************************************************************************//
function advpageNewclick()	
{				
varchk=1;
document.getElementById('hiddenalert').value="0";
                chk="n";
                show="1";
                k="1";
                mod="0";
                hiddentext="new";
                if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('premcode').disabled=true;
		          //autogenerate();
    	          }
		         else
		           {
		           document.getElementById('premcode').disabled=false;
    	           }
    	            
				document.getElementById('txtpremname').value="";
				document.getElementById('txtpage').value="";
				document.getElementById('txtpremium').value="";
				document.getElementById('txtvalid').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('dradvtyp').value="0";
				document.getElementById('drpedition').value="0";
				document.getElementById('drpsupplement').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpublication').value="0";
				document.getElementById('dcolor').value="0";
				document.getElementById('drpadvsizedesc').value="0";
				document.getElementById('drprategrp').value="0";
				document.getElementById('drpspecialposition').value="0";
				document.getElementById('drpremium').value="0";
				//document.getElementById('multi').disabled=false;
				document.getElementById('txtpremname').disabled=false;			
				document.getElementById('txtpage').disabled=false;
				document.getElementById('txtpremium').disabled=false;
				document.getElementById('txtvalid').disabled=false;
				document.getElementById('txtvalidtill').disabled=false;
				document.getElementById('dradvtyp').disabled=false;			
				document.getElementById('drpadvcat').disabled=false;							
				document.getElementById('drpublication').disabled=false;			
				document.getElementById('drpedition').disabled=false;
				//document.getElementById('radio').disabled=false;
	            document.getElementById('rd1').disabled=false;
				document.getElementById('rd2').disabled=false;
				document.getElementById('drpsupplement').disabled=false;							
				document.getElementById('dcolor').disabled=false;			
				document.getElementById('drpadvsizedesc').disabled=false;							
				document.getElementById('drprategrp').disabled=false;			
				document.getElementById('drpspecialposition').disabled=false;							
				document.getElementById('drpremium').disabled=false;
				document.getElementById('txtpageheading').value="0";
				
				document.getElementById('txtpageheading').disabled=false;
				
				 if(document.getElementById('hiddenauto').value==1)
                    {
                    document.getElementById('txtpremname').focus();
                    }
                    else
                    {
                    document.getElementById('premcode').focus();
                    }
					
				chkstatus(FlagStatus);
				
					
				
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
			
			
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
			
			document.getElementById('drpremium').value=document.getElementById('hiddenprem').value;
			//document.getElementById('drpremium').disabled=true;
			
			
	setButtonImages();
				return false;
}

        //*******************************************************************************************//
		//****************************Function For Save click****************************************//
		//*******************************************************************************************//
function advpageSaveclick()
{
    var bc="";
    document.getElementById('hiddenalert').value="0";
    document.getElementById('premcode').value=trim(document.getElementById('premcode').value);
    document.getElementById('txtpremname').value=trim(document.getElementById('txtpremname').value);
     //document.getElementById('txtpageheading').value=trim(document.getElementById('txtpageheading').value);
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
      var chmandat;
if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('AdvType').textContent;
}
else
{
chmandat=document.getElementById('AdvType').innerText;
}
if(chmandat.indexOf('*')>= 0)
{  
     if(document.getElementById('dradvtyp').value=="0"  && document.getElementById('dradvtyp').style.display!="none" )
			{
				alert("Please Select Ad Type");
				document.getElementById('dradvtyp').focus();
				return false;
			}
}			
//else if(browser!="Microsoft Internet Explorer")
//{
//chmandat=document.getElementById('PremiumCode').textContent;
//}
//else
//{
//chmandat=document.getElementById('PremiumCode').innerText;
//}
//if(chmandat.indexOf('*')>= 0)
//{    if((document.getElementById('hiddenauto').value!=1)&&(document.getElementById('premcode').value==""))
//			{
//				alert("Please Enter Premium Code");
//				document.getElementById('premcode').focus();
//				return false;
//			}
//}			
 if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('premname').textContent;
}
else
{
chmandat=document.getElementById('premname').innerText;
}
if(chmandat.indexOf('*')>= 0)
{ if(document.getElementById('txtpremname').value=="")
			{
				alert("Please Enter Premium Name");
				document.getElementById('txtpremname').focus();
				return false;
			}
			
}			

 if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('AdvCategory').textContent;
}
else
{
chmandat=document.getElementById('AdvCategory').innerText;
}
if(chmandat.indexOf('*')>= 0)
{ if(document.getElementById('drpadvcat').value=="0" && document.getElementById('drpadvcat').style.display!="none")
			{
				alert("Please Select Ad Category");
				document.getElementById('drpadvcat').focus();
				return false;
			}
}			
		/*	else if(document.getElementById('drpublication').value=="0")
			{
				alert("Please Select Publication");
				document.getElementById('drpublication').focus();
				return false;
			}*/
		//========= comment by 
		/*else if((document.getElementById('drpublication').value!="0")&&(document.getElementById('drpublication').value!="")&&(document.getElementById('drpedition').value=="0"))
		{
				alert("Please Select Edition");
			 document.getElementById('drpedition').focus();
				return false;
			}
			
            
            else if(document.getElementById('dcolor').value=="0")
			{
                if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('Color').textContent;
                }
                else
                {
                    bc=document.getElementById('Color').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
                {
                    alert('Please Select '+(bc.replace('*', "")));
                    document.getElementById('dcolor').focus();
                    return false;
                }
			}*/
			
//				alert("Please Select Color");
//				document.getElementById('dcolor').focus();
//				return false;
			
			
//			else if(document.getElementById('drpadvsizedesc').value=="0")
//			{
//				alert("Please Select Ad Size Description");
//				document.getElementById('drpadvsizedesc').focus();
//				return false;
//			}
			/*else if(document.getElementById('txtpage').value=="")
			{
			    
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('PageNo').textContent;
                }
                else
                {
                    bc=document.getElementById('PageNo').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
                {
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('txtpage').focus();
                    return false;
                }
			}*/
 if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('premium').textContent;
}
else
{
chmandat=document.getElementById('premium').innerText;
}
if(chmandat.indexOf('*')>= 0)
{ if(document.getElementById('drpremium').value=="0")
			{
				alert("Please Select Premium");
				document.getElementById('drpremium').focus();
				return false;
			}
}			
			
 if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('premium').textContent;
}
else
{
chmandat=document.getElementById('premium').innerText;
}
if(chmandat.indexOf('*')>= 0)
{ if(document.getElementById('txtpremium').value=="")
			{
				alert("Please Enter Premium");
				document.getElementById('txtpremium').focus();
				return false;
			}
}			
			
			/*else if(document.getElementById('drprategrp').value=="0")
			{
				alert("Please Select Rate Group");
				document.getElementById('drprategrp').focus();
				return false;
			}
			
			else if(document.getElementById('drpspecialposition').value=="0")
			{
			    
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('SpecialPosition').textContent;
                }
                else
                {
                    bc=document.getElementById('SpecialPosition').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
                {
                    alert('Please Select '+(bc.replace('*', "")));
                    document.getElementById('drpspecialposition').focus();
                    return false;
                }
			}
			
			else if((document.getElementById('drpspecialposition').value!="0")&&(document.getElementById('rd1').checked==false)&& (document.getElementById('rd2').checked==false))
			{
	            alert("Please Select whether Position is Solus Or Semi Solus");
	            return false;
			}*/
			        
//			else if(document.getElementById('drpremium').value=="0")
//			{
//				alert("Please Select Premium");
//				document.getElementById('drpremium').focus();
//				return false;
//			}
//			
//			else if(document.getElementById('txtpremium').value=="")
//			{
//				alert("Please Fill Premium");
//				document.getElementById('txtpremium').focus();
//				return false;
//			}
//			
 if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('ValidFrom').textContent;
}
else
{
chmandat=document.getElementById('ValidFrom').innerText;
}
if(chmandat.indexOf('*')>= 0)
{ if(document.getElementById('txtvalid').value=="")
			{
				alert("Please Select Valid From Date");
				document.getElementById('txtvalid').focus();
				return false;
			}
			else if(document.getElementById('txtvalidtill').value=="")
			{
				alert("Please Select Valid To Date");
				document.getElementById('txtvalidtill').focus();
				return false;
			}
}			
 if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('lbpageheading').textContent;
}
else
{
chmandat=document.getElementById('lbpageheading').innerText;
}
if(chmandat.indexOf('*')>= 0)
{ if(document.getElementById('txtpageheading').value=="0")
			{
				alert("Please Enter Heading");
				document.getElementById('txtpageheading').focus();
				return false;
			}
}
//			else if(document.getElementById('txtvalidtill').value=="")
//			{
//				alert("Please Select Valid To Date");
//				document.getElementById('txtvalidtill').focus();
//				return false;
//			}
			
			
			if(document.getElementById('drpedition').value!="0")
			{
			kprapp=0;
			if ((document.getElementById('CheckBox1').disabled==false) && (document.getElementById('CheckBox1').checked!=true))
			kprapp++;
			if ((document.getElementById('CheckBox2').disabled==false) &&  (document.getElementById('CheckBox2').checked!=true ))
			kprapp++;
			if ((document.getElementById('CheckBox3').disabled==false) && (document.getElementById('CheckBox3').checked!=true))
			kprapp++;
			if((document.getElementById('CheckBox4').disabled==false)  && (document.getElementById('CheckBox4').checked!=true))
			kprapp++;
			if((document.getElementById('CheckBox5').disabled==false)  && (document.getElementById('CheckBox5').checked!=true))
			kprapp++;
			if((document.getElementById('CheckBox6').disabled==false) && (document.getElementById('CheckBox6').checked!=true))
			kprapp++;
			if((document.getElementById('CheckBox7').disabled==false) && (document.getElementById('CheckBox7').checked!=true ))
			kprapp++;
			 if(kprapp=="7")      
			     {
                alert("Please Select Premium Applicable Day..");
                return false;
                 }
         }
        
			   varchk=0;
				var companycode=document.getElementById('hiddencomcode').value;
				var premiumcode = trim(document.getElementById('premcode').value).toUpperCase();
				var premiumname=trim(document.getElementById('txtpremname').value);
					if(premiumname.indexOf("'")>=0)
			            {
			           premiumname=premiumname.replace("'","''");
			            }
	
				var advtype=document.getElementById('dradvtyp').value;
				var advcategory=document.getElementById('drpadvcat').value;
				var publication=document.getElementById('drpublication').value;
				var edition=document.getElementById('drpedition').value;
				var supplement=document.getElementById('drpsupplement').value;
			
				var color=document.getElementById('dcolor').value;
				var advsizedesc=document.getElementById('drpadvsizedesc').value;
				var pageno=document.getElementById('txtpage').value;
				var rategrp=document.getElementById('drprategrp').value;
				var position=document.getElementById('drpspecialposition').value;
				var premium=document.getElementById('drpremium').value;
				var radio1=document.getElementById('rd1').checked;
					var radio2=document.getElementById('rd2').checked;
			
				var txtpremium=trim(document.getElementById('txtpremium').value);
				
				
				var UserId=document.getElementById('hiddenuserid').value;	
				var validfrm=document.getElementById('txtvalid').value;
				var validtill=document.getElementById('txtvalidtill').value;
				var dateformat = document.getElementById('hiddendateformat').value;
				var pageheading =document.getElementById('txtpageheading').value;
				var solus="";
				if(document.getElementById('rd1').checked==true)
				{
				solus="1";
				}
				if(document.getElementById('rd2').checked==true)
				{
				solus="0";
				}		
	    	             if(dateformat=="dd/mm/yyyy")
							{   
							    var todate="";
								var txtfrom=document.getElementById('txtvalid').value;
								var txtto=document.getElementById('txtvalidtill').value;
								
								var txtfrom1=txtfrom.split("/");
								var dd=txtfrom1[0];
								var mm=txtfrom1[1];
								var yy=txtfrom1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								if(txtto!="")
								{
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								}
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtvalid').value;
								todate=document.getElementById('txtvalidtill').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtvalid').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtvalidtill').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtvalid').value;
								todate=document.getElementById('txtvalidtill').value;
							}
			
		
		
////		if(todate != "" || todate != null || todate != "undefined")
////		{
////			tdate = new Date(todate);
////			fdate= new Date(fromdate);
//			else if(tdate==fdate){
//			alert("pankaj");
//			return false;
//					
//			}






				var akh = document.getElementById('premcode').value.toUpperCase();
                 selectpubday(akh);
                 
                 
                  currdate=new Date();
			     fdate= new Date(fromdate);
							
//	              if((fdate<=currdate))
//		              	{
//			
//			         alert("Valid From Date Must Be Greater Than Current Date");
//			         return false;
//			             }
			          				
		         if(todate != "" || todate != null || todate != "undefined")
		            {   
		                currdate=new Date();
			            tdate = new Date(todate);
			            fdate= new Date(fromdate);
        			
			        if((tdate<=fdate))
			            {
            			
			            alert("Valid To Date Must Be Greater Than Valid From Date");
			            return false;
			              }
			              }
               //  fillcheckboxes(akh);
				
			//	if(k!="1" && k!=null)
				if(mod!="1" && mod!=null)
				{
//				 currdate=new Date();
//			     fdate= new Date(fromdate);
//							
//	              if((fdate<=currdate))
//		              	{
//			
//			         alert("Valid From Date Must Be Greater Than Current Date");
//			         return false;
//			             }
//			          				
//		         if(todate != "" || todate != null || todate != "undefined")
//		            {   
//		                currdate=new Date();
//			            tdate = new Date(todate);
//			            fdate= new Date(fromdate);
//        			
//			        if((tdate<=fdate))
//			            {
//            			
//			            alert("Valid To Date Must Be Greater Than Valid From Date");
//			            return false;
//			              }
		     // }
			     	
                AdvPagePositionMaster.chkadvpagecode(companycode,UserId,premiumcode,advtype,premiumname,call_saveclick);
				   
				}
			
		      else
				{
				    if(chknamemod!=document.getElementById('txtpremname').value)
                    {
		                AdvPagePositionMaster.chkadvpagecode(companycode,UserId,premiumcode,advtype,premiumname,call_modify);
		            }
		            else
		            {
		                updateAdvPage();
		            }
					
				}
			
			
			return false;
}

        //*******************************************************************************************//
        function updateAdvPage()
        {
              
                var companycode=document.getElementById('hiddencomcode').value;
                var premiumcode = trim(document.getElementById('premcode').value).toUpperCase();
				var premiumname=trim(document.getElementById('txtpremname').value);
					if(premiumname.indexOf("'")>=0)
			            {
			           premiumname=premiumname.replace("'","''");
			            }
                var advtype=document.getElementById('dradvtyp').value;
				var advcategory=document.getElementById('drpadvcat').value;
				var publication=document.getElementById('drpublication').value;
				var edition=document.getElementById('drpedition').value;
				var supplement=document.getElementById('drpsupplement').value;
			
				var color=document.getElementById('dcolor').value;
				var advsizedesc=document.getElementById('drpadvsizedesc').value;
				var pageno=document.getElementById('txtpage').value;
				var rategrp=document.getElementById('drprategrp').value;
				var position=document.getElementById('drpspecialposition').value;
				var premium=document.getElementById('drpremium').value;
				var radio1=document.getElementById('rd1').checked;
			    var radio2=document.getElementById('rd2').checked;
                var txtpremium=trim(document.getElementById('txtpremium').value);
				var UserId=document.getElementById('hiddenuserid').value;	
				var validfrm=document.getElementById('txtvalid').value;
				var validtill=document.getElementById('txtvalidtill').value;
				var dateformat = document.getElementById('hiddendateformat').value;
				  if(dateformat=="dd/mm/yyyy")
		    	{   
			    var todate="";
				var txtfrom=document.getElementById('txtvalid').value;
				var txtto=document.getElementById('txtvalidtill').value;
				
				var txtfrom1=txtfrom.split("/");
				var dd=txtfrom1[0];
				var mm=txtfrom1[1];
				var yy=txtfrom1[2];
				fromdate=mm+'/'+dd+'/'+yy;
				if(txtto!="")
				{
				var txtto1=txtto.split("/");
				var dd1=txtto1[0];
				var mm1=txtto1[1];
				var yy1=txtto1[2];
				todate=mm1+'/'+dd1+'/'+yy1;
				}
				
			}
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=document.getElementById('txtvalid').value;
				todate=document.getElementById('txtvalidtill').value;
			}
				
			else if(dateformat=="yyyy/mm/dd")
			{
				var txt=document.getElementById('txtvalid').value;
				var txt1=txt.split("/");
				var yy=txt1[0];
				var mm=txt1[1];
				var dd=txt1[2];
				fromdate=mm+'/'+dd+'/'+yy;
				var txtto=document.getElementById('txtvalidtill').value;
				var txtto1=txtto.split("/");
				var yy1=txtto1[0];
				var mm1=txtto1[1];
				var dd1=txtto1[2];
				todate=mm1+'/'+dd1+'/'+yy1;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
				alert("dateformat  is either null or undefined");
				fromdate=document.getElementById('txtvalid').value;
				todate=document.getElementById('txtvalidtill').value;
			}
				var pageheading =document.getElementById('txtpageheading').value;
				var solus="";
				if(document.getElementById('rd1').checked==true)
				{
				solus="1";
				}
				if(document.getElementById('rd2').checked==true)
				{
				solus="0";
				}		
                chk="u";
				show="0";
				AdvPagePositionMaster.advpagemodify(companycode,premiumcode,premiumname,advtype,advcategory,publication,edition,supplement,color,advsizedesc,pageno,rategrp,position,premium,txtpremium,todate,fromdate,UserId,solus,pageheading);
				
				//	selectpubdayedit();
				Advpageexecute.Tables[0].Rows[z].Premiumcode=document.getElementById('premcode').value;
				Advpageexecute.Tables[0].Rows[z].premiumname=document.getElementById('txtpremname').value;
			
					
				Advpageexecute.Tables[0].Rows[z].page_No=document.getElementById('txtpage').value;
				Advpageexecute.Tables[0].Rows[z].premium_charges=document.getElementById('txtpremium').value;
				
				//------------------------ dateformat condition-----------------------------------------------//
//					var txt=Advpageexecute.Tables[0].Rows[z].valid_from_date;
//					var dd=txt.getDate();
//					var mm=txt.getMonth() + 1;
//					var yyyy=txt.getFullYear();
//					if(Advpageexecute.Tables[0].Rows[z].valid_from_date==null)
//					{
//					   todate="";
//					}
//					else
//					{
//				     var txtto=Advpageexecute.Tables[0].Rows[z].valid_till_date ;
//					 var dd1=txtto.getDate();
//					 var mm1=txtto.getMonth()+1;
//					 var yyyy1=txtto.getFullYear();
//					if(dateformat=="dd/mm/yyyy")
//					{
//					   todate=dd1+'/'+mm1+'/'+yyyy1;
//					}
//					else if(dateformat=="mm/dd/yyyy")
//					{
//					   todate=mm1+'/'+dd1+'/'+yyyy1;
//					}
//					else if(dateformat=="yyyy/mm/dd")
//					{
//					  todate=yyyy1+'/'+mm1+'/'+dd1;
//					}
//					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
//					{
//						todate=dd1+'/'+mm1+'/'+yyyy1;			
//					}
//					
//					}			
//				if(dateformat=="dd/mm/yyyy")
//				{
//					fromdate=dd+'/'+mm+'/'+yyyy;
//					
//				}
//				else if(dateformat=="mm/dd/yyyy")
//				{
//					fromdate=mm+'/'+dd+'/'+yyyy;
//					
//				}
//				else if(dateformat=="yyyy/mm/dd")
//				{
//					fromdate=yyyy+'/'+mm+'/'+dd;
//					
//				}
//				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
//				{
//					fromdate=dd+'/'+mm+'/'+yyyy;
//					
//				}
								
			//	document.getElementById('txtvalid').value=fromdate;
			//	document.getElementById('txtvalidtill').value=todate;
			
				//--------------------------------------------------------------------------------------------//
				var fromdate1=document.getElementById('txtvalid').value;
				var todate1=document.getElementById('txtvalidtill').value;
				if(dateformat=="yyyy/mm/dd")
				{
				    var fdate=fromdate1.split('/');
				    fromdate1=fdate[1] + "/" + fdate[2] + "/" + fdate[0];
				    
				     var tdate=todate1.split('/');
				    todate1=tdate[1] + "/" + tdate[2] + "/" + tdate[0];
				}
				else if(dateformat=="dd/mm/yyyy")
				{
				    var fdate=fromdate1.split('/');
				    fromdate1=fdate[1] + "/" + fdate[0] + "/" + fdate[2];
				    
				     var tdate=todate1.split('/');
				    todate1=tdate[1] + "/" + tdate[0] + "/" + tdate[2];
				}
				Advpageexecute.Tables[0].Rows[z].valid_from_date=fromdate1;
				Advpageexecute.Tables[0].Rows[z].valid_till_date=todate1;
//				Advpageexecute.Tables[0].Rows[z].valid_from_date=document.getElementById('txtvalid').value;
//				Advpageexecute.Tables[0].Rows[z].valid_till_date=document.getElementById('txtvalidtill').value;
				Advpageexecute.Tables[0].Rows[z].adv_type_code=document.getElementById('dradvtyp').value;
				Advpageexecute.Tables[0].Rows[z].adv_cat_code=document.getElementById('drpadvcat').value;
				Advpageexecute.Tables[0].Rows[z].publication_code=document.getElementById('drpublication').value;
				Advpageexecute.Tables[0].Rows[z].edition_code=document.getElementById('drpedition').value;
				Advpageexecute.Tables[0].Rows[z].supplement_code=document.getElementById('drpsupplement').value;
			
				Advpageexecute.Tables[0].Rows[z].col_code=document.getElementById('dcolor').value;
				Advpageexecute.Tables[0].Rows[z].Adv_SizeDesc=document.getElementById('drpadvsizedesc').value;
				Advpageexecute.Tables[0].Rows[z].Rategroup=document.getElementById('drprategrp').value;
				Advpageexecute.Tables[0].Rows[z].sp_position=document.getElementById('drpspecialposition').value;
				Advpageexecute.Tables[0].Rows[z].premium_charges_type=document.getElementById('drpremium').value;
				Advpageexecute.Tables[0].Rows[z].spositionradio=solus;
				Advpageexecute.Tables[0].Rows[z].PAGEHEADING=document.getElementById('txtpageheading').value;
					
				//	selectpubdayedit();
					
				    if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                    }
                    else
                    {
                        alert(xmlObj.childNodes(0).childNodes(1).text);
                    }
					
					
					updateStatus();
					if(mdlast=="0")
					{
					document.getElementById('btnfirst').disabled=true;				
					document.getElementById('btnprevious').disabled=true;					
					}
					else if(mdlast=="1")
					{
					document.getElementById('btnnext').disabled=true;					
					document.getElementById('btnlast').disabled=true;
					}
					
					document.getElementById('premcode').disabled=true;		
					document.getElementById('txtpremname').disabled=true;		
				
				    document.getElementById('txtpage').disabled=true;
				    document.getElementById('txtpremium').disabled=true;
				    document.getElementById('txtvalid').disabled=true;
				    document.getElementById('txtvalidtill').disabled=true;
				    document.getElementById('dradvtyp').disabled=true;			
				    document.getElementById('drpadvcat').disabled=true;							
				    document.getElementById('drpublication').disabled=true;			
				    document.getElementById('drpedition').disabled=true;	
				    document.getElementById('drpsupplement').disabled=true;							
									
				    document.getElementById('dcolor').disabled=true;			
				    document.getElementById('drpadvsizedesc').disabled=true;							
				    document.getElementById('drprategrp').disabled=true;			
				    document.getElementById('drpspecialposition').disabled=true;							
				    document.getElementById('drpremium').disabled=true;	
				    						
    				document.getElementById('rd1').disabled=true;
				    document.getElementById('rd2').disabled=true;
				    document.getElementById('txtpageheading').disabled=true;
    						
			        document.getElementById('CheckBox1').disabled=true;
			        document.getElementById('CheckBox2').disabled=true;
			        document.getElementById('CheckBox3').disabled=true;
			        document.getElementById('CheckBox4').disabled=true;
			        document.getElementById('CheckBox5').disabled=true;
			        document.getElementById('CheckBox6').disabled=true;
			        document.getElementById('CheckBox7').disabled=true;
			        document.getElementById('CheckBox8').disabled=true;
					mod=0;
					k="0";
					setButtonImages();
					return false;
        }
        
        
        
        function call_modify(response)
        {
           var ds =response.value;
           if(ds==null)
           {  
                alert(response.error.description);
                return false;
           }
           
           if(ds.Tables[1].Rows.length > 0)
			{
				alert("This Premium name has already been assigned !");
				document.getElementById('txtpremname').value="";
                document.getElementById('txtpremname').focus();
				return false;
			} 
			
			updateAdvPage();
           
        }
        
        
        //*********************************************************************************************//
		//****************************Function For Delete click**************************************//
		//*******************************************************************************************//
function advpageDeleteclick()
{
                   var companycode=document.getElementById('hiddencomcode').value;
                   var premiumcode = document.getElementById('premcode').value.toUpperCase();
				var premiumname=document.getElementById('txtpremname').value;
			
				var advtype=document.getElementById('dradvtyp').value;
				var advcategory=document.getElementById('drpadvcat').value;
				var publication=document.getElementById('drpublication').value;
				var edition=document.getElementById('drpedition').value;
				var supplement=document.getElementById('drpsupplement').value;
				var color=document.getElementById('dcolor').value;
				var advsizedesc=document.getElementById('drpadvsizedesc').value;
				var pageno=document.getElementById('txtpage').value;
				var rategrp=document.getElementById('drprategrp').value;
				var position=document.getElementById('drpspecialposition').value;
				var premium=document.getElementById('drpremium').value;
				var txtpremium=document.getElementById('txtpremium').value;
				
				var txtfrom=document.getElementById('txtvalid').value;
				var txtto=document.getElementById('txtvalidtill').value;
				
				var UserId=document.getElementById('hiddenuserid').value;	
					boolReturn = confirm("Are you sure you wish to delete this?");
		        if(boolReturn==1)
			        {
			            //AdvPagePositionMaster.advpagemultidelete(companycode,premiumcode,UserId);	
			            
			            //AdvPagePositionMaster.selectpremiumdaydelete(companycode,premiumcode,UserId);
			            
			          
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
AdvPagePositionMaster.advpagedelete(companycode,premiumcode,UserId);
                        //advtype,advcategory,publication,edition,color,advsizedesc,pageno,rategrp
                        //,position,premium,txtpremium,UserId);//,txtfrom,txtto);	
                        
                        AdvPagePositionMaster.advpageexecute(companycode,glapremiumcode,glapremiumname,glaadvtype,glaadcategory,glapublication,glaedition,glasupplement,glaadsize,UserId,glacolor,glapageno,glarategroup,glaspecialposition,glapremium,delcall);
				         
			        }     
		        else
		        {
			        return false;
		        }	
	return false;
}
//*******************************************************************************//
//*******************This Is The Responce Of The Delete Button*******************//
//*******************************************************************************//
function delcall(res)
{
	 Advpageexecute= res.value;
	len=Advpageexecute.Tables[0].Rows.length;
	  chkstatus(FlagStatus);
      updateStatus();
		     
	
	if(Advpageexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		        document.getElementById('premcode').value="";
		        document.getElementById('txtpremname').value="";
		        document.getElementById('txtpage').value="";
				document.getElementById('txtpremium').value="";
				document.getElementById('txtvalid').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('dradvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpublication').value="";
				document.getElementById('drpedition').value="0";
				document.getElementById('drpsupplement').value="0";
				document.getElementById('dcolor').value="0";
				document.getElementById('drpadvsizedesc').value="0";
				document.getElementById('drprategrp').value="0";
				document.getElementById('drpspecialposition').value="0";
				document.getElementById('drpremium').value="0";
				document.getElementById('txtpageheading').value="";
				document.getElementById('CheckBox1').checked=false;
			    document.getElementById('CheckBox2').checked=false;
			    document.getElementById('CheckBox3').checked=false;
			    document.getElementById('CheckBox4').checked=false;
			    document.getElementById('CheckBox5').checked=false;
			    document.getElementById('CheckBox6').checked=false;
			    document.getElementById('CheckBox7').checked=false;
			    document.getElementById('CheckBox8').checked=false;
			    setButtonImages();
			//ascmCancelclick('AgencySubCategoryMaster');
				
		return false;
	}
	else if(z>=len || z==-1)
	{
		        document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[0].Premiumcode;
		         document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[0].premiumname;
				
				document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[0].page_No;
				
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[0].premium_charges;
				//document.getElementById('txtvalid').value=Advpageexecute.Tables[0].Rows[0].valid_from_date;
				//document.getElementById('txtvalidtill').value=Advpageexecute.Tables[0].Rows[0].valid_till_date;
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[0].adv_type_code;
				document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[0].adv_cat_code;
				document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[0].publication_code;
				//document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[0].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[0].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[0].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[0].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[0].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[0].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[0].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[0].PAGEHEADING;
				}
				
		        var dateformat = document.getElementById('hiddendateformat').value;
				var txt=Advpageexecute.Tables[0].Rows[0].valid_from_date;
				var radio=Advpageexecute.Tables[0].Rows[0].spositionradio;
		           if(radio=="1")
		           document.getElementById('rd1').checked=true;
		           else
		           document.getElementById('rd2').checked=true;
			
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute   .Tables[0].Rows[0].valid_till_date==null)
					{
					todate="";
					}
					else
					{
				var txtto=Advpageexecute.Tables[0].Rows[0].valid_till_date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
				
		        var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
			
			   addedition(Advpageexecute.Tables[0].Rows[0].publication_code);
		      cmb=Advpageexecute.Tables[0].Rows[0].edition_code;
		      
		        addsupplement(Advpageexecute.Tables[0].Rows[0].edition_code);
		      supp=Advpageexecute.Tables[0].Rows[0].supplement_code;
       
		
		       // addpackage(Advpageexecute.Tables[0].Rows[0].publication_code);
		       // cmb=Advpageexecute.Tables[0].Rows[0].edition_code;
        			
	}
	else
	{
		        document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[z].Premiumcode;
		          document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[z].premiumname;
				
				document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[z].page_No;
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[z].premium_charges;
				//document.getElementById('txtvalid').value=Advpageexecute.Tables[0].Rows[z].valid_from_date;
				//document.getElementById('txtvalidtill').value=Advpageexecute.Tables[0].Rows[z].valid_till_date;
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[z].adv_type_code;
				document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[z].adv_cat_code;
				document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[z].publication_code;
				//document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[z].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[z].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[z].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[z].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[z].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[z].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[z].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[z].PAGEHEADING;
				}
				
		        var dateformat = document.getElementById('hiddendateformat').value;
		        var radio=Advpageexecute.Tables[0].Rows[z].spositionradio;
		           if(radio=="1")
		           document.getElementById('rd1').checked=true;
		           else
		           document.getElementById('rd2').checked=true;
			
				var txt=Advpageexecute.Tables[0].Rows[z].valid_from_date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute.Tables[0].Rows[z].valid_till_date==null)
					{
					todate="";
					}
					else
					{
				var txtto=Advpageexecute.Tables[0].Rows[z].valid_till_date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
				
		        var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
		
		       addedition(Advpageexecute.Tables[0].Rows[z].publication_code);
		      cmb=Advpageexecute.Tables[0].Rows[z].edition_code;
		      
		        addsupplement(Advpageexecute.Tables[0].Rows[z].edition_code);
		      supp=Advpageexecute.Tables[0].Rows[z].supplement_code;
        	
        			
			
	}
	//alert("Data Deleted Successfully");	
	if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
    }
    else
    {
        alert(xmlObj.childNodes(0).childNodes(2).text);
    }
    setButtonImages();
return false;
}
        //*******************************************************************************************//
		//****************************Function For Cancel click**************************************//
		//*******************************************************************************************//
function advpageCancelclick(formname)
{
document.getElementById('hiddenalert').value="0";
			
				chk="0";
	            show="0";
				//getPermission(formname);
				chkstatus(FlagStatus);
                givebuttonpermission(formname);
				document.getElementById('premcode').value="";
				document.getElementById('txtpremname').value="";
			
				document.getElementById('txtpage').value="";
				document.getElementById('txtpremium').value="";
				document.getElementById('txtvalid').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('dradvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpublication').value="0";
				document.getElementById('drpedition').value="0";
				document.getElementById('drpsupplement').value="0";
			
				document.getElementById('dcolor').value="0";
				document.getElementById('drpadvsizedesc').value="0";
				document.getElementById('drprategrp').value="0";
				document.getElementById('drpspecialposition').value="0";
				document.getElementById('drpremium').value="0";
				document.getElementById('txtpageheading').value="0";

				    document.getElementById('premcode').disabled=true;	
				    document.getElementById('txtpremname').disabled=true;
					
				    document.getElementById('txtpage').disabled=true;
				    document.getElementById('txtpremium').disabled=true;
				    document.getElementById('txtvalid').disabled=true;
				    document.getElementById('txtvalidtill').disabled=true;
				    document.getElementById('dradvtyp').disabled=true;			
				    document.getElementById('drpadvcat').disabled=true;							
				    document.getElementById('drpublication').disabled=true;			
				    document.getElementById('drpedition').disabled=true;	
				    document.getElementById('drpsupplement').disabled=true;	
				      document.getElementById('rd1').checked=false;
                     document.getElementById('rd2').checked=false;
                  
				     document.getElementById('rd1').disabled=true;
                     document.getElementById('rd2').disabled=true;
                    
	
				    						
				    document.getElementById('dcolor').disabled=true;			
				    document.getElementById('drpadvsizedesc').disabled=true;							
				    document.getElementById('drprategrp').disabled=true;			
				    document.getElementById('drpspecialposition').disabled=true;							
				    document.getElementById('drpremium').disabled=true;	
				    document.getElementById('txtpageheading').disabled=true;
    				
				/*document.getElementById('btnNew').disabled=false;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;*/
				
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
			    setButtonImages();
			   if(document.getElementById('btnNew').disable==false)
				 document.getElementById('btnNew').focus();
				return false;
}


        //*******************************************************************************************//
		//*****************************Function For Query click**************************************//
		//*******************************************************************************************//
function advpageQueryclick()		
{
document.getElementById('hiddenalert').value="0";
			show="0";
			z=0;
			hiddentext="query";
			varchk=0;
							
	        document.getElementById('btnQuery').disabled=true;
	        document.getElementById('btnExecute').disabled=false;
	        document.getElementById('btnSave').disabled=true;
        		
			
			    document.getElementById('premcode').value="";
			    document.getElementById('txtpremname').value="";
			
				document.getElementById('txtpage').value="";
				document.getElementById('txtpremium').value="";
				document.getElementById('txtvalid').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('dradvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpublication').value="0";
				document.getElementById('drpedition').value="0";
				document.getElementById('drpsupplement').value="0";
			
				document.getElementById('dcolor').value="0";
				document.getElementById('drpadvsizedesc').value="0";
				document.getElementById('drprategrp').value="0";
				document.getElementById('drpspecialposition').value="0";
				document.getElementById('drpremium').value="0";
		
			
			
				document.getElementById('premcode').disabled=false;		
				document.getElementById('txtpremname').disabled=false;
				
				document.getElementById('txtpage').disabled=false;
				document.getElementById('txtpremium').disabled=true;
				document.getElementById('txtvalid').disabled=true;
				document.getElementById('txtvalidtill').disabled=true;
				document.getElementById('dradvtyp').disabled=false;			
				document.getElementById('drpadvcat').disabled=false;							
				document.getElementById('drpublication').disabled=true;			
				document.getElementById('drpedition').disabled=true;		
				document.getElementById('drpsupplement').disabled=true;		
			
									
				document.getElementById('dcolor').disabled=false;			
				document.getElementById('drpadvsizedesc').disabled=true;							
				document.getElementById('drprategrp').disabled=true;			
				document.getElementById('drpspecialposition').disabled=false;							
				document.getElementById('drpremium').disabled=true;	
				 document.getElementById('rd1').disabled=true;
                  document.getElementById('rd2').disabled=true;

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
    			chkstatus(FlagStatus);

                document.getElementById('btnQuery').disabled=true;
                document.getElementById('btnExecute').disabled=false;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('btnExecute').focus();
			setButtonImages();
			return false;
}

        //*******************************************************************************************//
		//****************************Function For Execute click*************************************//
		//*******************************************************************************************//
function advpageExecuteclick()
{
document.getElementById('hiddenalert').value="1";
	chk="e";

			
		        var companycode=document.getElementById('hiddencomcode').value;
				var premiumcode=document.getElementById('premcode').value;
				glapremiumcode=premiumcode;
				 var premiumname=document.getElementById('txtpremname').value;
				 if(premiumname.indexOf("'")>=0)
			            {
			           premiumname=premiumname.replace("'","''");
			            }
	
			     glapremiumname=premiumname;
				var advtype=document.getElementById('dradvtyp').value;
				glaadvtype=advtype;
				var advcategory=document.getElementById('drpadvcat').value;
				glaadcategory=advcategory;
				var publication=document.getElementById('drpublication').value;
				glapublication=publication;
				var edition=document.getElementById('drpedition').value;
				glaedition=edition;
			    var supplement=document.getElementById('drpsupplement').value;
				glasupplement=supplement;
			
				
				var color=document.getElementById('dcolor').value;
				glacolor=color;
				var advsizedesc=document.getElementById('drpadvsizedesc').value;
				glaadsize=advsizedesc;
				var pageno=document.getElementById('txtpage').value;
				glapageno=pageno;
				var rategrp=document.getElementById('drprategrp').value;
				glarategroup=rategrp;
				var position=document.getElementById('drpspecialposition').value;
				glaspecialposition=position;
				var premium=document.getElementById('drpremium').value;
				glapremium=premium;
				//var txtpremium=document.getElementById('txtpremium').value;
				
				var UserId=document.getElementById('hiddenuserid').value;	
				//var validfrm=document.getElementById('txtvalid').value;
				
				//AdvPagePositionMaster.advpageexecute(companycode,premiumcode,advtype,advcategory,publication,edition,advsizedesc,UserId,checkcall);
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
AdvPagePositionMaster.advpageexecute(companycode,premiumcode,premiumname,advtype,advcategory,publication,edition,supplement,advsizedesc,UserId,color,pageno,rategrp,position,premium,checkcall);
			
		    
			
			updateStatus();
			
			  document.getElementById('premcode').disabled=true;	
			      document.getElementById('txtpremname').disabled=true;
					
				document.getElementById('txtpage').disabled=true;
				document.getElementById('txtpremium').disabled=true;
				document.getElementById('txtvalid').disabled=true;
				document.getElementById('txtvalidtill').disabled=true;
				document.getElementById('dradvtyp').disabled=true;			
				document.getElementById('drpadvcat').disabled=true;							
				document.getElementById('drpublication').disabled=true;			
				document.getElementById('drpedition').disabled=true;	
			    document.getElementById('drpsupplement').disabled=true;							
									
				document.getElementById('dcolor').disabled=true;			
				document.getElementById('drpadvsizedesc').disabled=true;							
				document.getElementById('drprategrp').disabled=true;			
				document.getElementById('drpspecialposition').disabled=true;							
				document.getElementById('drpremium').disabled=true;	
			    //document.getElementById('multi').disabled=false;
							
		        document.getElementById('btnfirst').disabled=true;				
                document.getElementById('btnnext').disabled=false;					
                document.getElementById('btnprevious').disabled=true;			
                document.getElementById('btnlast').disabled=false;	
                if(document.getElementById('btnModify').disabled==false)					
                   document.getElementById('btnModify').focus();
			
								
			return false;			
}
//*******************************************************************************//
//*****************This Is The Responce Of The Execute Button*******************//
//*******************************************************************************//
function checkcall(response)
{
		Advpageexecute=response.value;
		
		if (Advpageexecute.Tables[0].Rows.length <= 0)
		{
		   	   alert("Your search can't produce any result");
		   	
		     	document.getElementById('premcode').value="";
				document.getElementById('txtpremname').value="";
			
				document.getElementById('txtpage').value="";
				document.getElementById('txtpremium').value="";
				document.getElementById('txtvalid').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('dradvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpublication').value="0";
				document.getElementById('drpedition').value="0";
				document.getElementById('drpsupplement').value="0";
			
				document.getElementById('dcolor').value="0";
				document.getElementById('drpadvsizedesc').value="0";
				document.getElementById('drprategrp').value="0";
				document.getElementById('drpspecialposition').value="0";
				document.getElementById('drpremium').value="0";
			    advpageCancelclick('AdvPagePositionMaster');
			    return false;
		}
		else
		{
		
		        document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[0].Premiumcode;
		        document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[0].premiumname;
				
				if(Advpageexecute.Tables[0].Rows[0].page_No!=null)
				{
				    document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[0].page_No;
				}
				else
				{
				    document.getElementById('txtpage').value="";
				}
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[0].premium_charges;
				var dateformat = document.getElementById('hiddendateformat').value;
				
				var txt=Advpageexecute.Tables[0].Rows[0].valid_from_date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute.Tables[0].Rows[0].valid_till_date==null)
					{
					todate="";
					}
					else
					{
				var txtto=Advpageexecute.Tables[0].Rows[0].valid_till_date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
				
				
				//document.getElementById('txtvalid').value=ds.Tables[0].Rows[0].valid_from_date;
				//document.getElementById('txtvalidtill').value=ds.Tables[0].Rows[0].valid_till_date;
				
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[0].adv_type_code;
				//category();
				//document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[0].adv_cat_code;
				
				document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[0].publication_code;
				//document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[0].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[0].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[0].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[0].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[0].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[0].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[0].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[0].PAGEHEADING;
				}
				var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
		           var radio=Advpageexecute.Tables[0].Rows[0].spositionradio;
		           if(radio=="1")
		           document.getElementById('rd1').checked=true;
		           else if(radio=="0")
		           document.getElementById('rd2').checked=true;
		           
			//	multiple();
				 cmb=Advpageexecute.Tables[0].Rows[0].edition_code;
		         supp=Advpageexecute.Tables[0].Rows[0].supplement_code;
		          addedition12();
		          
        	       supp1=Advpageexecute.Tables[0].Rows[0].adv_cat_code;
				   category();
		     
        
		         //addpublication(Advpageexecute.Tables[0].Rows[0].publication_code);
		        //cmb=Advpageexecute.Tables[0].Rows[0].edition_code;
		        
		        
		 if( Advpageexecute.Tables[0].Rows.length==1 )
		 {
		    document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;
		 }
		 setButtonImages();		
		return false;
		
		}
		
		setButtonImages();		
		return false;
}
						
////function checkcall1(response)
////{
//		        ds=response.value;
////		        document.getElementById('premcode').value=ds.Tables[0].Rows[0].Premiumcode;
////				document.getElementById('txtpage').valueds.Tables[0].Rows[0].page_No;
////				document.getElementById('txtpremium').valueds.Tables[0].Rows[0].premium_charges;
////				document.getElementById('txtvalid').value=ds.Tables[0].Rows[0].valid_from_date;
////				document.getElementById('txtvalidtill').value=ds.Tables[0].Rows[0].valid_till_date;
////				document.getElementById('dradvtyp').value=ds.Tables[0].Rows[0].adv_type_code;
////				document.getElementById('drpadvcat').value=ds.Tables[0].Rows[0].adv_cat_code;
////				document.getElementById('drpublication').value=ds.Tables[0].Rows[0].publication_code;
////				//document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition_code;
////				document.getElementById('dcolor').value=ds.Tables[0].Rows[0].col_code;
////				document.getElementById('drpadvsizedesc').value=ds.Tables[0].Rows[0].Adv_SizeDesc;
////				document.getElementById('drprategrp').value=ds.Tables[0].Rows[0].Rategroup;
////				document.getElementById('drpspecialposition').value=ds.Tables[0].Rows[0].sp_position;
////				document.getElementById('drpremium').value=ds.Tables[0].Rows[0].premium_charges_type;
////		         addpublication(ds.Tables[0].Rows[0].publication_code);
////		        //cmb=ds.Tables[0].Rows[0].edition_code;
//		return false;
//}

        //*******************************************************************************************//
		//****************************Function For Modify click**************************************//
		//*******************************************************************************************//
function advpageModifyclick()
{
document.getElementById('hiddenalert').value="0";
				chk="m";
				show="2";
				varchk=1;
				mod="1";
				
					hiddentext="modify";
					
				document.getElementById('premcode').disabled=true;	
				 document.getElementById('txtpremname').disabled=false;
						
				document.getElementById('txtpage').disabled=false;
				document.getElementById('txtpremium').disabled=false;
				document.getElementById('txtvalid').disabled=false;
				document.getElementById('txtvalidtill').disabled=false;
				document.getElementById('dradvtyp').disabled=false;			
				document.getElementById('drpadvcat').disabled=false;							
				document.getElementById('drpublication').disabled=false;			
				document.getElementById('drpedition').disabled=false;	
				document.getElementById('drpsupplement').disabled=false;							
				document.getElementById('dcolor').disabled=false;			
				document.getElementById('drpadvsizedesc').disabled=false;							
				document.getElementById('drprategrp').disabled=false;			
				document.getElementById('drpspecialposition').disabled=false;							
				document.getElementById('drpremium').disabled=false;	
				document.getElementById('rd1').disabled=false;
                document.getElementById('rd2').disabled=false;
                
                document.getElementById('txtpageheading').disabled=false;
		
			    chknamemod=	trim(document.getElementById('txtpremname').value);

				k="1";
				chkstatus(FlagStatus);

                document.getElementById('btnSave').disabled = false;
                document.getElementById('btnQuery').disabled = true;
                document.getElementById('btnExecute').disabled=true;

		
			   //multiple();
				selectpubdayedit();
				
				
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

//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			chk="s";
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Premium Code Already Exist, Try Another Code !!!!");
				document.getElementById('premcode').value="";
				document.getElementById('premcode').focus();
				return false;
			} 
			else if(ds.Tables[1].Rows.length > 0)
			{
				alert("This Premium Name Already Exist !");
				document.getElementById('txtpremname').value="";
				document.getElementById('txtpremname').focus();
				return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var premiumcode=trim(document.getElementById('premcode').value);
				var premiumname=trim(document.getElementById('txtpremname').value);
					if(premiumname.indexOf("'")>=0)
			            {
			           premiumname=premiumname.replace("'","''");
			            }
	
				var advtype=document.getElementById('dradvtyp').value;
				var advcategory=document.getElementById('drpadvcat').value;
				var publication=document.getElementById('drpublication').value;
				var edition=document.getElementById('drpedition').value;
				var supplement=document.getElementById('drpsupplement').value;
				var color=document.getElementById('dcolor').value;
				var advsizedesc=document.getElementById('drpadvsizedesc').value;
				var pageno=document.getElementById('txtpage').value;
				var rategrp=document.getElementById('drprategrp').value;
				var position=document.getElementById('drpspecialposition').value;
				var premium=document.getElementById('drpremium').value;
				var txtpremium=trim(document.getElementById('txtpremium').value);
				var UserId=document.getElementById('hiddenuserid').value;
				var validfrm=document.getElementById('txtvalid').value;
				var validtill=document.getElementById('txtvalidtill').value;
			    var radio1=document.getElementById('rd1').checked;
				var radio2=document.getElementById('rd2').checked;
				var pageheading=document.getElementById('txtpageheading').value;
			    var solus="";
				if(document.getElementById('rd1').checked==true)
				{
				solus="1";
				}
				if(document.getElementById('rd2').checked==true)
				{
				solus="0";
				}		
				
					var dateformat = document.getElementById('hiddendateformat').value;


			
		if(dateformat=="dd/mm/yyyy")
							{ 
							    var todate="";
								var txtfrom=document.getElementById('txtvalid').value;
								var txtto=document.getElementById('txtvalidtill').value;
								
								var txtfrom1=txtfrom.split("/");
								var dd=txtfrom1[0];
								var mm=txtfrom1[1];
								var yy=txtfrom1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								if(txtto!="")
								{
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								}
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtvalid').value;
								todate=document.getElementById('txtvalidtill').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtvalid').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtvalidtill').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtvalid').value;
								todate=document.getElementById('txtvalidtill').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			alert("Till Date Must Be Grater Then From Date");
			return false;
			}
//			else if(tdate==fdate)
//			{
//			alert("pankaj");
//			return false;
//			}

		}
			
				
					AdvPagePositionMaster.advpagesave(companycode,premiumcode,premiumname,advtype,advcategory,publication,edition,supplement,color,advsizedesc,pageno,rategrp,position,premium,txtpremium,todate,fromdate,UserId,solus,pageheading);
					if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                    }
                    else
                    {
                        alert(xmlObj.childNodes(0).childNodes(0).text);
                    }
					//alert("Data Saved Successfully");
					show="0";
                document.getElementById('premcode').value="";
                document.getElementById('txtpremname').value="";
			
				document.getElementById('txtpage').value="";
				document.getElementById('txtpremium').value="";
				document.getElementById('txtvalid').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('dradvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpublication').value="";
				document.getElementById('drpedition').value="0";
				document.getElementById('drpsupplement').value="0";
			    document.getElementById('dcolor').value="0";
				document.getElementById('drpadvsizedesc').value="0";
				document.getElementById('drprategrp').value="0";
				document.getElementById('drpspecialposition').value="0";
				document.getElementById('drpremium').value="0";
				document.getElementById('txtpageheading').value="0";
				
				document.getElementById('rd1').checked=false;
				document.getElementById('rd2').checked=false;
				
				document.getElementById('premcode').disabled=true;	
				document.getElementById('txtpremname').disabled=true;
					
				document.getElementById('txtpage').disabled=true;
				document.getElementById('txtpremium').disabled=true;
				document.getElementById('txtvalid').disabled=true;
				document.getElementById('txtvalidtill').disabled=true;
				document.getElementById('dradvtyp').disabled=true;			
				document.getElementById('drpadvcat').disabled=true;							
				document.getElementById('drpublication').disabled=true;			
				document.getElementById('drpedition').disabled=true;	
				document.getElementById('drpsupplement').disabled=true;							
				document.getElementById('dcolor').disabled=true;			
				document.getElementById('drpadvsizedesc').disabled=true;							
				document.getElementById('drprategrp').disabled=true;			
				document.getElementById('drpspecialposition').disabled=true;							
				document.getElementById('drpremium').disabled=true;		
				 document.getElementById('rd1').disabled=true;
                    document.getElementById('rd2').disabled=true;
                
                document.getElementById('txtpageheading').disabled=true;
							
				//document.getElementById('multi').disabled=true;
	
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
                  //ascmCancelclick('AgencySubCategoryMaster');
                  setButtonImages();
			return false;
}


        //*******************************************************************************************//
		//****************************Function For First click***************************************//
		//*******************************************************************************************//
/*function advpagefirstclick()
{				document.getElementById('hiddenalert').value="1";
               chk="f";
               z="0";
               mdlast="0";
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
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
AdvPagePositionMaster.advpagefirst(companycode,UserId,firstcall);
				
				   document.getElementById('premcode').disabled=true;	
				    document.getElementById('txtpremname').disabled=true;
					
				    document.getElementById('txtpage').disabled=true;
				    document.getElementById('txtpremium').disabled=true;
				    document.getElementById('txtvalid').disabled=true;
				    document.getElementById('txtvalidtill').disabled=true;
				    document.getElementById('dradvtyp').disabled=true;			
				    document.getElementById('drpadvcat').disabled=true;							
				    document.getElementById('drpublication').disabled=true;			
				    document.getElementById('drpedition').disabled=true;	
				    document.getElementById('drpsupplement').disabled=true;							
					document.getElementById('dcolor').disabled=true;			
				    document.getElementById('drpadvsizedesc').disabled=true;							
				    document.getElementById('drprategrp').disabled=true;			
				    document.getElementById('drpspecialposition').disabled=true;							
				    document.getElementById('drpremium').disabled=true;
				     document.getElementById('rd1').disabled=true;
                    document.getElementById('rd2').disabled=true;
				
				    			
				document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=false;
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=false;			
				document.getElementById('btnExit').disabled=false;
		
				return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//
function advpagefirstclick()
{
				//ds=response.value;
				
				document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[0].Premiumcode;
				document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[0].premiumname;
				
				if(Advpageexecute.Tables[0].Rows[0].page_No!=null)
				{
				    document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[0].page_No;
				}
				else
				{
				    document.getElementById('txtpage').value="";
				}
				//document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[0].page_No;
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[0].premium_charges;
				document.getElementById('txtvalid').value=Advpageexecute.Tables[0].Rows[0].valid_from_date;
				document.getElementById('txtvalidtill').value=Advpageexecute.Tables[0].Rows[0].valid_till_date;
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[0].adv_type_code;
				document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[0].adv_cat_code;
				document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[0].publication_code;
				//document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[0].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[0].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[0].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[0].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[0].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[0].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[0].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[0].PAGEHEADING;
				}
				
				var radio=Advpageexecute.Tables[0].Rows[0].spositionradio;
			    var solus;
				if(radio=="1")
				{
				document.getElementById('rd1').checked=true;
				}
				else if(radio=="0")
				{
				document.getElementById('rd2').checked=true;
				}
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt1=Advpageexecute.Tables[0].Rows[0].valid_from_date;
				var txt=new Date(txt1);
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute.Tables[0].Rows[0].valid_till_date==null)
					{
					todate="";
					}
					else
					{
					var txt1=Advpageexecute.Tables[0].Rows[0].valid_till_date;
				var txtto=new Date(txt1);
				
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
				
				 var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
				 cmb=Advpageexecute.Tables[0].Rows[0].edition_code;
		         supp=Advpageexecute.Tables[0].Rows[0].supplement_code;
        	
				    addedition12();
				    
				    
				     supp1=Advpageexecute.Tables[0].Rows[0].adv_cat_code;
                   category();
				    
		     	
				z=0;
				
				updateStatus();
               // multiple();
	    	    document.getElementById('btnCancel').disabled=false;
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnnext').disabled=false;
                document.getElementById('btnprevious').disabled=true;
                document.getElementById('btnlast').disabled=false;
                document.getElementById('btnExit').disabled=false;
                setButtonImages();
				return false;
}

        //*******************************************************************************************//
		//****************************Function For Previous click***********************************//
		//*******************************************************************************************//
/*function advpagepreviousclick()
{
			document.getElementById('hiddenalert').value="1";
				chk="f";
				mdlast="p";
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
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
AdvPagePositionMaster.advpageprevious(companycode,UserId,previouscall);
				
				return false;
}*/
//*******************************************************************************//
//****************This Is The Responce Of The Previous Button*******************//
//*******************************************************************************//
function advpagepreviousclick()
{
		z=z-1;
		//ds=response.value;
		var x=Advpageexecute.Tables[0].Rows.length;
	    
		
		if(z>x)
		{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=true;
				return false;
		}
		if(z!=-1 && z>=0)
		{
		if(Advpageexecute.Tables[0].Rows.length != z)
		{
				document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[z].Premiumcode;
				 document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[z].premiumname;
				
				if(Advpageexecute.Tables[0].Rows[z].page_No!=null)
				{
				    document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[z].page_No;
				}
				else
				{
				    document.getElementById('txtpage').value="";
				}
				//document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[z].page_No;
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[z].premium_charges;
				document.getElementById('txtvalid').value=Advpageexecute.Tables[0].Rows[z].valid_from_date;
				document.getElementById('txtvalidtill').value=Advpageexecute.Tables[0].Rows[z].valid_till_date;
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[z].adv_type_code;
				document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[z].adv_cat_code;
				document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[z].publication_code;
				//document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[z].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[z].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[z].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[z].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[z].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[z].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[z].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[z].PAGEHEADING;
				}
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var radio=Advpageexecute.Tables[0].Rows[z].spositionradio;
		           if(radio=="1")
		           document.getElementById('rd1').checked=true;
		           else
		           document.getElementById('rd2').checked=true;
				var txt6=Advpageexecute.Tables[0].Rows[z].valid_from_date;
				var txt=new Date(txt6);
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute.Tables[0].Rows[z].valid_till_date==null)
					{
					todate="";
					}
					else
					{
				var txtto1=Advpageexecute.Tables[0].Rows[z].valid_till_date;
				var txtto= new Date(txtto1);
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
						 cmb=Advpageexecute.Tables[0].Rows[z].edition_code;
		         supp=Advpageexecute.Tables[0].Rows[z].supplement_code;
        	
				    addedition12();
				    
				    
				    supp1=Advpageexecute.Tables[0].Rows[z].adv_cat_code;
                   category();

		   
		         //addpublication(Advpageexecute.Tables[0].Rows[z].publication_code);
		        //cmb=Advpageexecute.Tables[0].Rows[z].edition_code;
		        var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
			
					//multiple();
					
					updateStatus();
					document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
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
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;	
				setButtonImages();
				return false;		
		}	
		setButtonImages();
		return false;
		
}

        //*******************************************************************************************//
		//****************************Function For Next click****************************************//
		//*******************************************************************************************//
/*function advpagenextclick()
{
document.getElementById('hiddenalert').value="1";
		        chk="f";
		        mdlast="n";
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
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
AdvPagePositionMaster.advpagenext(companycode,UserId,nextcall);
				return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function advpagenextclick()
{		
		z++;
		
		//ds=response.value;
		var x=Advpageexecute.Tables[0].Rows.length;
		if(z <= x && z >= 0)
		{
			if(Advpageexecute.Tables[0].Rows.length != z  && z !=-1)
			{
				document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[z].Premiumcode;
				  document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[z].premiumname;
				
				if(Advpageexecute.Tables[0].Rows[z].page_No!=null)
				{
				    document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[z].page_No;
				}
				else
				{
				    document.getElementById('txtpage').value="";
				}
				//document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[z].page_No;
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[z].premium_charges;
				document.getElementById('txtvalid').value=Advpageexecute.Tables[0].Rows[z].valid_from_date;
				document.getElementById('txtvalidtill').value=Advpageexecute.Tables[0].Rows[z].valid_till_date;
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[z].adv_type_code;
				document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[z].adv_cat_code;
				document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[z].publication_code;
				//document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[z].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[z].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[z].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[z].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[z].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[z].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[z].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[z].PAGEHEADING;
				}
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var radio=Advpageexecute.Tables[0].Rows[z].spositionradio;
		           if(radio=="1")
		           document.getElementById('rd1').checked=true;
		           else
		           document.getElementById('rd2').checked=true;
				var txt6=Advpageexecute.Tables[0].Rows[z].valid_from_date;
					var txt=new Date(txt6);
			
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute.Tables[0].Rows[z].valid_till_date==null)
					{
					todate="";
					}
					else
					{
				var txtto=Advpageexecute.Tables[0].Rows[z].valid_till_date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
				
		        updateStatus();	
		         var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
						 cmb=Advpageexecute.Tables[0].Rows[z].edition_code;
						 
		         supp=Advpageexecute.Tables[0].Rows[z].supplement_code;        	
				    
				    addedition12();
				    
				      supp1=Advpageexecute.Tables[0].Rows[z].adv_cat_code;
				   category();
		     
		   
        
				 // addpublication(Advpageexecute.Tables[0].Rows[z].publication_code);
		        //cmb=Advpageexecute.Tables[0].Rows[z].edition_code;	
						//multiple();	
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
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

        //*******************************************************************************************//
		//******************************Function For Last click**************************************//
		//*******************************************************************************************//
/*function advpagelastclick()
{
document.getElementById('hiddenalert').value="1";		          
                chk="f";
                mdlast="1";
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
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
AdvPagePositionMaster.advpagelast(companycode,UserId,lastcall);
				return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The Last Button*******************//
//*******************************************************************************//
function advpagelastclick()
{
	//	ds= response.value;
     	var x=Advpageexecute.Tables[0].Rows.length;
		z=x-1;
		x=x-1;

		        document.getElementById('premcode').value=Advpageexecute.Tables[0].Rows[x].Premiumcode;
		          document.getElementById('txtpremname').value=Advpageexecute.Tables[0].Rows[x].premiumname;
				
				if(Advpageexecute.Tables[0].Rows[x].page_No!=null)
				{
				    document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[x].page_No;
				}
				else
				{
				    document.getElementById('txtpage').value="";
				}
				document.getElementById('txtpage').value=Advpageexecute.Tables[0].Rows[x].page_No;
				document.getElementById('txtpremium').value=Advpageexecute.Tables[0].Rows[x].premium_charges;
				document.getElementById('txtvalid').value=Advpageexecute.Tables[0].Rows[x].valid_from_date;
				document.getElementById('txtvalidtill').value=Advpageexecute.Tables[0].Rows[x].valid_till_date;
				document.getElementById('dradvtyp').value=Advpageexecute.Tables[0].Rows[x].adv_type_code;
				document.getElementById('drpadvcat').value=Advpageexecute.Tables[0].Rows[x].adv_cat_code;
				//document.getElementById('drpublication').value=Advpageexecute.Tables[0].Rows[x].publication_code;
				document.getElementById('drpedition').value=Advpageexecute.Tables[0].Rows[x].edition_code;
				document.getElementById('dcolor').value=Advpageexecute.Tables[0].Rows[x].col_code;
				document.getElementById('drpadvsizedesc').value=Advpageexecute.Tables[0].Rows[x].Adv_SizeDesc;
				document.getElementById('drprategrp').value=Advpageexecute.Tables[0].Rows[x].Rategroup;
				document.getElementById('drpspecialposition').value=Advpageexecute.Tables[0].Rows[x].sp_position;
				document.getElementById('drpremium').value=Advpageexecute.Tables[0].Rows[x].premium_charges_type;
				
				if(Advpageexecute.Tables[0].Rows[x].PAGEHEADING==null)
				{
				    document.getElementById('txtpageheading').value="0";
				}
				else
				{
				    document.getElementById('txtpageheading').value=Advpageexecute.Tables[0].Rows[x].PAGEHEADING;
				}
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt6=Advpageexecute.Tables[0].Rows[x].valid_from_date;
					var txt=new Date(txt6);
				var radio=Advpageexecute.Tables[0].Rows[x].spositionradio;
		           if(radio=="1")
		           document.getElementById('rd1').checked=true;
		           else
		           document.getElementById('rd2').checked=true;
					var dd=txt.getDate();
				
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(Advpageexecute.Tables[0].Rows[x].valid_till_date==null)
					{
					todate="";
					}
					else
					{
				var txtto=Advpageexecute.Tables[0].Rows[x].valid_till_date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalid').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
			
				
		   	updateStatus();
		   	 var akh=document.getElementById('premcode').value;
		           fillcheckboxes(akh);
		  	 cmb=Advpageexecute.Tables[0].Rows[x].edition_code;
		     supp=Advpageexecute.Tables[0].Rows[x].supplement_code;
        	addedition12();
        	
        	
        	 supp1=Advpageexecute.Tables[0].Rows[x].adv_cat_code;
				   category();
		     
		   
        
		   	 // addpublication(Advpageexecute.Tables[0].Rows[x].publication_code);
		        //cmb=Advpageexecute.Tables[0].Rows[x].edition_code;	
				
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;

	//	multiple();
	setButtonImages();
		return false;
}

        //*******************************************************************************************//
		//******************************Function For Exit click**************************************//
		//*******************************************************************************************//
		
		
		
		
		
		
		
		
		
		
		
		
		
		
function advpageExitclick()
{
	if(confirm("Do You Want To Skip This Page"))
	{
		//window.location.href='enterpage.aspx';
		window.close();
		return false;
	}
	else
	{
		return false;
	}
}


//****************************************************************************************************************
//********************************Select Edition on basis of Publication******************************************
//****************************************************************************************************************
function addedition()
{
var publication=document.getElementById('drpublication').value;
if(document.getElementById('drpublication').value!="0")
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
AdvPagePositionMaster.addeditionquery(publication,calledit);
return false;
}
else
{
document.getElementById('drpedition').value="0";
 editname=document.getElementById('drpedition');

    editname.options.length = 1; 
 editname.options[0]=new Option("--Select Edition--","0");
  
document.getElementById('drpsupplement').value="0";
 suppname=document.getElementById('drpsupplement');
  suppname.options.length = 1; 
  suppname.options[0]=new Option("--Select Supplement--","0");
  
disablecheck1();

}
return false;
}

function calledit(res)
{

var ds=res.value;
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
     suppname=document.getElementById('drpsupplement');

    suppname.options.length = 1; 
    suppname.options[0]=new Option("--Select Supplement--","0");

   editname=document.getElementById('drpedition');

    editname.options.length = 1; 
    editname.options[0]=new Option("--Select Edition--","0");
  
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        editname.options[editname.options.length] = new Option(res.value.Tables[0].Rows[i].Edition_Alias,res.value.Tables[0].Rows[i].Edition_Code);
        editname.options.length;
       
    }
    //alert(cityvar);
 if(cmb == undefined || cmb=="")
 {
  document.getElementById('drpedition').value="0";
 
 }
 else
 {
  document.getElementById('drpedition').value=cmb;
  cmb="";
  } 
}
else
{
if(document.getElementById('hiddenalert').value!="1")
{

alert("There is No Matching value Found");
document.getElementById('drpedition').value="0";
document.getElementById("drpublication").focus();
return false;

}
editname.options.length = 1; 
return false;

}
suppname=document.getElementById('drpsupplement');

    suppname.options.length = 1; 
    suppname.options[0]=new Option("--Select Supplement--","0");
  
	
             
return false;
} 






//****************************************************************************************************************
//********************************Select Supplement on basis of Edition******************************************
//****************************************************************************************************************
function addsupplement()
{
var edition=document.getElementById('drpedition').value;
var publication=document.getElementById('drpublication').value;
if ((document.getElementById('drpedition').value!="0") && (document.getElementById('drpublication').value!="0"))
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
AdvPagePositionMaster.addsupplementquery(edition,publication,callsupp);
selectpubdayedit();
return false;
}
else
{
//document.getElementById('drpedition').value="0";
document.getElementById('drpsupplement').value="0";
 suppname=document.getElementById('drpsupplement');
  suppname.options.length = 1; 
  suppname.options[0]=new Option("--Select Supplement--","0");
if (document.getElementById('drpedition').value=="0")
{
disablecheck();
}

}

return false;
}

function callsupp(ressupp)
{


var dssupp=ressupp.value;
if(dssupp!= null && typeof(dssupp) == "object" && dssupp.Tables[0].Rows.length > 0) 
{
   suppname=document.getElementById('drpsupplement');

    suppname.options.length = 1; 
    suppname.options[0]=new Option("--Select Supplement--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ressupp.value.Tables[0].Rows.length; ++i)
    {
        suppname.options[suppname.options.length] = new Option(ressupp.value.Tables[0].Rows[i].Supp_Name,ressupp.value.Tables[0].Rows[i].Supp_Code);
        
       suppname.options.length;
       
    }
    //alert(cityvar);
 if(supp == undefined || supp=="")
 {
  document.getElementById('drpsupplement').value="0";
 }
 else
 {
  document.getElementById('drpsupplement').value=supp;
  supp="";
  } 
}
else
{
//document.getElementById('drpsupplement').value="0";
if(document.getElementById('hiddenalert').value!="1")
{
//alert("There is No Matching value Found");
}
suppname.options.length = 1; 
return false;
}
//selectpubdayedit();
return false;
} 
//************************************For Executing Purpose*******************************************************
//****************************************************************************************************************
//********************************Select Edition on basis of Publication******************************************
//****************************************************************************************************************
function addedition12()
{
var publication=document.getElementById('drpublication').value;

if(document.getElementById('drpublication').value!="0")
{
AdvPagePositionMaster.addeditionquery(publication,calledit12);

return false;
}
else
{
document.getElementById('drpedition').value="0";
editname=document.getElementById('drpedition');

    editname.options.length = 1; 
 editname.options[0]=new Option("--Select Edition--","0");
  
document.getElementById('drpsupplement').value="0";
 suppname=document.getElementById('drpsupplement');
  suppname.options.length = 1; 
  suppname.options[0]=new Option("--Select Supplement--","0");
disablecheck1();
}

return false;
}

function calledit12(res)
{
editname=document.getElementById('drpedition');
var ds=res.value;
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
   

    editname.options.length = 1; 
    editname.options[0]=new Option("--Select Edition--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        editname.options[editname.options.length] = new Option(res.value.Tables[0].Rows[i].Edition_Alias,res.value.Tables[0].Rows[i].Edition_Code);
        editname.options.length;
       
    }
    //alert(cityvar);
 if(cmb == undefined || cmb=="")
 {
  document.getElementById('drpedition').value="0";
 
 }
 else
 {
  document.getElementById('drpedition').value=cmb;
  var edition=document.getElementById('drpedition').value;
    var publication=document.getElementById('drpublication').value;
   
   if((document.getElementById('drpedition').value!="0")&& (document.getElementById('drpublication').value!="0"))
    {
    AdvPagePositionMaster.addsupplementquery(edition,publication,callsupp12);
    selectpubdayedit();
    }
    else
    {
    //document.getElementById('drpedition').value="0";
    document.getElementById('drpsupplement').value="0";
    suppname=document.getElementById('drpsupplement');
    suppname.options.length = 1; 
     suppname.options[0]=new Option("--Select Supplement--","0");
    if (document.getElementById('drpedition').value=="0")
    {
    disablecheck();
    }

    }

  cmb="";
  } 
}
else
{
if(document.getElementById('hiddenalert').value!="1")
{
    alert("There is No Matching value Found");
    document.getElementById('drpedition').value="0";
    return false;
}
editname.options.length = 1; 
return false;

}
	
             
return false;
} 






//****************************************************************************************************************
//********************************Select Supplement on basis of Edition******************************************
//****************************************************************************************************************
function addsupplement12()
{
var edition=document.getElementById('drpedition').value;
var publication=document.getElementById('drpublication').value;

AdvPagePositionMaster.addsupplementquery(edition,publication,callsupp12);
return false;
}

function callsupp12(ressupp)
{


var dssupp=ressupp.value;
if(dssupp!= null && typeof(dssupp) == "object" && dssupp.Tables[0].Rows.length > 0) 
{
   suppname=document.getElementById('drpsupplement');

    suppname.options.length = 1; 
    suppname.options[0]=new Option("--Select Supplement--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ressupp.value.Tables[0].Rows.length; ++i)
    {
        suppname.options[suppname.options.length] = new Option(ressupp.value.Tables[0].Rows[i].Supp_Name,ressupp.value.Tables[0].Rows[i].Supp_Code);
        
       suppname.options.length;
       
    }
    //alert(cityvar);
         if(supp == undefined || supp=="")
         {
          document.getElementById('drpsupplement').value="0";
         }
         else
         {
          document.getElementById('drpsupplement').value=supp;
          supp="";
          } 
}
else
{
if(document.getElementById('hiddenalert').value!="1")
{
alert("There is No Matching value Found");

}
suppname=document.getElementById('drpsupplement')
suppname.options.length = 1; 
return false;
}
//selectpubdayedit();
return false;
} 


//function addpublication()
//{
////var publication=document.getElementById('drpublication').value;
////AdvPagePositionMaster.addpackage(publication,callcount);

//var edition=document.getElementById('drpedition').value;
//AdvPagePositionMaster.addpublicationquery(edition,callcount);
//return false;
//}

//function callcount(res)
//{

//var ds=res.value;


//if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
//{

//document.getElementById("drpublication").value=res.value.Tables[0].Rows[0].Combin_Desc;
//return false;
//}
//else
//{
//alert("There is No Matching value Found");
//return false;

//}
////alert(pkgitem);
///*
//    cmbname.options.length = 1; 
//    cmbname.options[0]=new Option("--Select Category--","0");
//    //alert(pkgitem.options.length);
//    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
//    {
//        cmbname.options[cmbname.options.length] = new Option(res.value.Tables[0].Rows[i].Package_Name,res.value.Tables[0].Rows[i].Combin_Code);
//        
//       cmbname.options.length;
//       
//    }
//    //alert(cityvar);
// if(cmb == undefined || cmb=="")
// {
//  document.getElementById('drpedition').value="0";
// 
// }
// else
// {
//  document.getElementById('drpedition').value=cmb;
//  cmb="";
//  } 
//}
//else
//{
//alert("There is No Matching value Found");
//return false;

//}*/

//return false;
//}
//************************************Check BoxDisabled*******************************************
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

		return false;

		}
//***********************************************************************************//
//****************************Function For Select Day********************************//
//***********************************************************************************//
function selectpubday(response)
{
var compcode=document.getElementById('hiddencomcode').value;
var premiumcode=document.getElementById('premcode').value;
var userid=document.getElementById('hiddenuserid').value;

AdvPagePositionMaster.checkpremiumcode(compcode,premiumcode,userid,pubcodever);

return false;
}
//**********************response of selecting premium day acc. to edition code******************************************************
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
var compcode=document.getElementById('hiddencompcode').value;
var premiumcode=document.getElementById('premcode').value;
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
chk8="Y";
chk1="Y";
chk2="Y";
chk3="Y"
chk4="Y"
chk5="Y"
chk6="Y"
chk7="Y"
chk8="Y"
}
else
{
chk8="N";
}*/

if(ds.Tables[0].Rows.length>0)
{
AdvPagePositionMaster.selectpremiumdaymodify1(compcode,premiumcode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);

return false;
}
else
{
AdvPagePositionMaster.selectpremiumdaysave1(compcode,premiumcode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
return false;
}
}





//**************************************************************************************//
//***************************Function For Fillcheckboxes*******************************//
//**************************************************************************************//
function fillcheckboxes(response)
{
var compcode=document.getElementById('hiddencompcode').value;
var premiumcode=document.getElementById('premcode').value;
var userid=document.getElementById('hiddenuserid').value;
AdvPagePositionMaster.checkpremiumcode(compcode,premiumcode,userid,fillcheck);
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
if(varchk=="0")
{
disablecheck();
}
		
}
 
}

var flag=0;
/*function updatecheck()
{
if(flag==0)
{
flag=1;
checkedunchecked();	
}
else
{
flag=0;
checkedunchecked();	
}
}
return false;
}
*/

//*******************************************************************************************//
//*****************************Checkedunchecked function*************************************//
//*******************************************************************************************//

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

	
	
		
function chknumber()
{
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
}

function charval1()
{
if((event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)
||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

//************************************************************************************//
//******************This Function for The fillcheck box corrosponding*****************//
//************************************Check boxes*************************************//
function fillcheckbox2()
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

//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
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

//*********************************************Auto Generate***********************
function advautogenerate()
 {
  if(document.getElementById('hiddenauto').value==1)
    {
    advchangeoccured();
    return ;
    }
else
    {
    userdefineonly();

   // return false;
    }
return ;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function advchangeoccured()
{
if(hiddentext=="new")
			{
	       advuppercase3();
            }
           
return false;
}

function advuppercase3()
		{
		     
		  document.getElementById('txtpremname').value=trim(document.getElementById('txtpremname').value);

	
		    if(document.getElementById('txtpremname').value!="")
                {
                var premiumname=document.getElementById('txtpremname').value;
	
             if (parseInt(premiumname)!=0)
             {
        	document.getElementById('txtpremname').value=trim(document.getElementById('txtpremname').value);

			/*str=document.getElementById('txtpremname').value;
			   if(str.indexOf("'")>=0)
			            {
			           str=str.replace("'","''");
			            }*/
	
			str=document.getElementById('txtpremname').value;
			str=str.replace("'","''");
			  AdvPagePositionMaster.chkadvpageautocode(str,advfillcall);
	    	return ;
                }
                else
                {
                alert('This premium Name can not be accepted');
                document.getElementById('txtpremname').value="";
                document.getElementById('txtpremname').focus();
    	
	            return ;
	            }
			
             
                }
		        return false;
		
}


//auto generated
//this is used for increment in code
function advfillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Premium name has already assigned !! ");
		     document.getElementById('txtpremname').value="";
		    document.getElementById('txtpremname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Premiumcode;
		                        }
		                         var str1="";
		                          if(str.indexOf("'")>=0)
		                          {
		                          	str=str.replace("''","");
		                          	str1=str.substr(0,2);
		                          	}
		                          	else
		                          	{
		                          	str1=str.substr(0,2);
		                          	}
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        //var code=newstr.substr(2,4);
		                        code++;
		                        str=str.toUpperCase();
		                          
			  
		                        document.getElementById('premcode').value=str1 + code;
		                         }
		  
		                      else
		                         {
		                            str=str.toUpperCase();
		                          document.getElementById('premcode').value=str1+ "0";
		                          }
		                      }
		   return false ;
		}
		
		
		
function userdefineonly()
    {
        if(hiddentext=="new")
        {
         document.getElementById('premcode').disabled=false;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}

function selectpubdayedit()
{
var compcode=document.getElementById('hiddencomcode').value;
//var premiumcode=document.getElementById('premcode').value;
var editcode=document.getElementById('drpedition').value;
var suppcode=document.getElementById('drpsupplement').value;
var userid=document.getElementById('hiddenuserid').value;

if((editcode!="0")&&(suppcode=="0"))
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
AdvPagePositionMaster.checkeditcode(compcode,editcode,userid,fillchk_callback);
return false;
}
else if(suppcode!="0")
{
AdvPagePositionMaster.checksuppcode(compcode,suppcode,userid,fillchk_callback);
return false;
}
return false;
}




//***********************************************************************************************************
   
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

//if(sun=="Y")
//    {
//    
//    document.getElementById('CheckBox1').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox1').disabled=true;
//     document.getElementById('CheckBox1').checked=false;
//  
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
//  
//    }
//if(tue=="Y")
//    {
//    
//    document.getElementById('CheckBox3').disabled=false;
//    }
//else
//    {
//    document.getElementById('CheckBox3').disabled=true;
//    document.getElementById('CheckBox3').checked=false;
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
//    document.getElementById('CheckBox4').checked=false;
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
//    document.getElementById('CheckBox5').checked=false;
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
//    document.getElementById('CheckBox6').checked=false;
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
//    document.getElementById('CheckBox7').checked=false;
//  
//    }
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
    }
else
    {
    if(kchk=="0")
    {
    document.getElementById('CheckBox8').disabled=true;
    }
    else
    {
    document.getElementById('CheckBox8').disabled=false;

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
    }
    if (varchk=="0")
    {
    disablecheck();
    }
   

    return false;
}

///*********************************************************************************
//*********************************chk whether premium percentage is greater than 100 or not************

function checkpr()
{
    if((document.getElementById('drpremium').value=="per") ||(document.getElementById('drpremium').value=="fixed"))
       {
chkpremium();
       }
else
    {
        alert('Please Select Premium First');
       document.getElementById('drpremium').focus();
        document.getElementById('txtpremium').value="";
        return ;
    }

return ;
}

function chkpremium()
{
    //checkpr();
    

if((document.getElementById('drpremium').value=="P")&&(document.getElementById('txtpremium').value > 200 ))
    {
			alert("Premium Percentage must be less than 200");
			document.getElementById('txtpremium').value="";
			return ;
	} 

return ;
}


function disableradio()
{
    document.getElementById('rd1').checked=false;
  //document.getElementById('rd2').checked=false;
   document.getElementById('rd1').disabled=true;
  document.getElementById('rd2').disabled=true;
  disablecheck();
  givebuttonpermission('AdvPagePositionMaster');
  return false;
 }
 
 function chkradio()
{
 if ((document.getElementById('drpspecialposition').value=="0")&&((document.getElementById('rd1').checked==true)||(document.getElementById('rd2').checked==true)))
  {
  alert("Please Select Position");
  	document.getElementById('drpspecialposition').focus();
  
			 return ;
  }
  else
  {	
  if(document.getElementById('rd1').checked==true)
      document.getElementById('rd1').checked=true;
  else if (document.getElementById('rd2').checked==true)
        document.getElementById('rd2').checked=true;
     return ;
   }   
    return false;
 }
 
 function advClientSpecialchar()
{
	if((event.keyCode==39)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}

function disablecheck1()
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
		
		//getPermission('SupplimentMaster');

		return false;

		}
		
		
//		
//		function chkalphabet()
//		{
//		   if(document.getElementById('txtpage').value!="")
//		   
//		   {
//		     if(document.getElementById('txtpage').value!=(event.keyCode>=65 && event.keyCode<=90))
//		      {
//		       alert('Pankaj12');
//		       return false;
//		      }
//		      else
//		      {
//		      alert('Pankaj');
//		       return false;
//		      }
//		   
//		   }
//		
//		 return false;
//		
//		}
//			
			
//function chkalphabet()
//{

////if(document.getElementById('txtpage').value=((event.keyCode>=65 && event.keyCode<=90) || (event.keyCode>=97 && event.keyCode<=122)))
//if(document.getElementById('txtpage').value!=(event.keyCode>=48 && event.keyCode<=57))
// {
//                alert('Please Enter The Numeric Value');
//                document.getElementById('txtpage').focus();
//                document.getElementById('txtpage').value="";
//                return false;
// 
// }
// //else
// 
// //{
//    
////if(document.getElementById('txtpage').value==((event.keyCode>=65 && event.keyCode<=90) || (event.keyCode>=97 && event.keyCode<=122)))
//// {
////                alert('Please Enter The Numeric Value');
////                document.getElementById('txtpage').focus();
////                document.getElementById('txtpage').value="";
////                return false;
////           
//// }
//// 
//// else
//// {
//// 
////                alert('Please Enter The Numeric Value');
////                document.getElementById('txtpage').focus();
////                document.getElementById('txtpage').value="";
////                return false;
////            
////  }
//// 
//// }
// return false;
//}


////        if((event.keyCode>=48 && event.keyCode<=57)&&((event.keyCode>=65 && event.keyCode<=90) || (event.keyCode>=97 && event.keyCode<=122)))
////        {
////            if((event.keyCode>=65 && event.keyCode<=90) || (event.keyCode>=97 && event.keyCode<=122))
////            {
////             
////            }
////        else
////            {
////                alert('Please Enter The Numeric Value');
////                document.getElementById('txtpage').focus();
////                document.getElementById('txtpage').value="";
////                return ;
//// 
////           // }

////        }
////        
////    else
////        {
//////         if((event.keyCode>=65 && event.keyCode<=90) || (event.keyCode>=97 && event.keyCode<=122))
//////            {
//////             
//////            }
//////        else
//////            {
//////                alert('Please Enter The Numeric Value');
//////                document.getElementById('txtpage').focus();
//////                document.getElementById('txtpage').value="";
//////                return true;
////// 
//////            }
////          }  
//// return ;
////}



function bla() 
{
//abbreviate the reference for future freqent use
//var field = document.forms[0].field1
var field = document.getElementById('txtpage').value;
 if (document.getElementById('txtpage').value==0)
	
	{
	document.getElementById('txtpage').value="";
	alert('Page No. Can not be Zero');
		
	return false;
	}
//make sure that the input will be treated as string and add
var valo = new String();
//define a string to include the allowed characters
var numere = "0123456789";
//split this in unique characters and set each character as a var
var chars = field.split("");
for (i = 0; i < chars.length; i++) 
{
//if the character input is among the allowed let it go and add it to the previous
if (numere.indexOf(chars[i]) != -1) valo += chars[i];
//else alert...
else{alert("No non-numeric allowed");
document.getElementById('txtpage').value="";
document.getElementById('txtpage').focus();
return false;

}

}
//... delete the non allowed and return the cursor after the last allowed character
if (field.value != valo) field.value = valo;
}


function chktxtpremium()
{
	if (parseInt(premiumname)==0)
	{
	alert('This premium Name can not be accepted');
	return false;
	}
			

}

/////////////////////////////////////////////////////////////////////////////
function RetCheckdate_currfrm(input)
{
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

	if (!validformat.test())
	{
		if(input.value=="")
		{
		return true;
		}
		alert(" Please Fill The Date In "+dateformat+" Format");
		document.getElementById('txtvalid').value="";
		return false;
	}
}

/////////////////////////////////////////////////////////////////////////////
function RetCheckdate_currtill(input)
{
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

	if (!validformat.test())
	{
		if(input.value=="")
		{
		return true;
		}
		alert(" Please Fill The Date In "+dateformat+" Format");
		document.getElementById('txtvalidtill').value="";
		return false;
	}
}


function chkpremiumforzero()
{
checkpr();
    var premiumname=document.getElementById('txtpremium').value;
//	if (parseInt(premiumname)==0)
//	
//	{
//	document.getElementById('txtpremium').value="";
//	alert('Premium Can not be Zero');
//	return false;
//	}
		return false;
}

//*********************************************
function allamountbullet(ab)
		{
		var fld =document.getElementById('txtpremium').value;
		var max=200;
		if(document.getElementById('drpremium').value=="per")
		if(fld>max)
		{
		alert("Premium % can not be greater than 200");
		document.getElementById('txtpremium').value="";
		document.getElementById('txtpremium').focus();
		return false;
		}
		//var fld=ab.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			chkpremiumforzero();
			return true;
			}
			else
			{
			alert("input error");
			document.getElementById('txtpremium').value="";
			//document.getElementById(ab).focus();
			ab.focus();
			return false;
			}
			
			}
	return true;
		}
		
function category()
{

	var adtypecode=document.getElementById('dradvtyp').value;

        if(document.getElementById('dradvtyp').value!="0")
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
AdvPagePositionMaster.addadvcat(adtypecode,call_back);

        return false;
        }
        else
        {
        document.getElementById('drpadvcat').value="0";
        adtype=document.getElementById('drpadvcat');

            adtype.options.length = 1; 
         adtype.options[0]=new Option("--Select Category--","0");
         }

     return false;
}
function call_back(res)
{
  var ds=res.value;
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
           adtype=document.getElementById('drpadvcat');

            adtype.options.length = 1; 
            adtype.options[0]=new Option("--Select Category--","0");
            //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        adtype.options[adtype.options.length] = new Option(res.value.Tables[0].Rows[i].Adv_Cat_Name,res.value.Tables[0].Rows[i].Adv_Cat_Code);
       adtype.options.length;
       
    }
           
}
    //document.getElementById('drpadvcat').value= Advpageexecute.Tables[0].Rows[0].adv_cat_code;
 
 //}     

else
      {
       document.getElementById('drpadvcat').value="0";
       adtype=document.getElementById('drpadvcat');
          adtype.options.length = 1; 
        adtype.options[0]=new Option("--Select Category--","0");
        return false;
        }
 
            if(supp1 == undefined || supp1=="")
            {
            document.getElementById('drpadvcat').value="0";
            }
            else
            {
            document.getElementById('drpadvcat').value=supp1;
            supp1="";
            } 
return false;
 
}
function clerprem()
{
if(document.getElementById('drpremium').value=="per" && document.getElementById('txtpremium').value > 200)
document.getElementById('txtpremium').value="";
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