var browser=navigator.appName;
var hiddentext="new";
var auto="";
var hiddentext1="";
var next=0;
var dsexe = "";
var areacodeexe="";
var areanameexe="";
var ffexe="";
var modiflag=0;
var confdel;
/***************************************/
/*function loadXML(xmlFile) 
{
    var  httpRequest =null;

    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        //xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue
        
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

}*/


function pagerefresh()
{

    document.getElementById("drpadtype").disabled=true;
    document.getElementById("txtchargecode").disabled=true;
	document.getElementById("txtchargename").disabled= true;
	document.getElementById("txtchargealias").disabled=true;
    document.getElementById("drpchargestype").disabled= true;
    document.getElementById("txtchargeamt").disabled=true;
    document.getElementById("txtfromdate").disabled=true;
    document.getElementById("txttodate").disabled=true;
    document.getElementById("drpchargeactive").disabled=true;
    document.getElementById("drpchargeon").disabled = true;
    document.getElementById("drpadtype").value="0";
    document.getElementById("txtchargecode").value="";
	document.getElementById("txtchargename").value="";
	document.getElementById("txtchargealias").value="";
    //document.getElementById("drpchargestype").value="";
    document.getElementById("txtchargeamt").value="";
    document.getElementById("txtfromdate").value="";
    document.getElementById("txttodate").value="";
    //document.getElementById("drpchargeactive").value="";
    
  
    document.getElementById('btnNew').disabled=false;
    //document.getElementById('btnNew').focus();
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
    setButtonImages();
    return false;
    
 }
 
 
 function EnabledOnNew()
{
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        
        document.getElementById("drpadtype").disabled=false
        document.getElementById("txtchargecode").disabled=true
	    document.getElementById("txtchargename").disabled= false
	    document.getElementById("txtchargealias").disabled=false;
        document.getElementById("drpchargestype").disabled= false;
        document.getElementById("txtchargeamt").disabled=false;
        document.getElementById("txtfromdate").disabled=false;
        document.getElementById("txttodate").disabled=false;
        document.getElementById("drpchargeactive").disabled=false;
        document.getElementById("drpchargeon").disabled = false;
        document.getElementById('drpadtype').focus();
        modifyduplicacydesc="";
        modiflag=0;
        setButtonImages();
        return false;
  
}
 
 function ClearAll()
{
    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnNew').focus();
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;  
        
        
    document.getElementById("drpadtype").disabled=true;
    document.getElementById("txtchargecode").disabled=true;
	document.getElementById("txtchargename").disabled= true;
	document.getElementById("txtchargealias").disabled=true;
    document.getElementById("drpchargestype").disabled= true;
    document.getElementById("txtchargeamt").disabled=true;
    document.getElementById("txtfromdate").disabled=true;
    document.getElementById("txttodate").disabled=true;
    document.getElementById("drpchargeactive").disabled=true;
    document.getElementById("drpchargeon").disabled = true;
    document.getElementById("drpadtype").value="0";
    document.getElementById("txtchargecode").value="";
	document.getElementById("txtchargename").value="";
	document.getElementById("txtchargealias").value="";
    //document.getElementById("drpchargestype").value="";
    document.getElementById("txtchargeamt").value="";
    document.getElementById("txtfromdate").value="";
    document.getElementById("txttodate").value="";
    //document.getElementById("drpchargeactive").value="";
    
    modiflag=0;
//    new_button("")
    setButtonImages();
    return false;
}


function EnabledonQuery()
{
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
        
    document.getElementById("drpadtype").disabled=false;
    document.getElementById("txtchargecode").disabled=false;
	document.getElementById("txtchargename").disabled= false;
	document.getElementById("txtchargealias").disabled=false;
    document.getElementById("drpchargestype").disabled= false;
    document.getElementById("txtchargeamt").disabled=false;
    document.getElementById("txtfromdate").disabled=false;
    document.getElementById("txttodate").disabled=false;
    document.getElementById("drpchargeactive").disabled=false; 
    document.getElementById("drpchargeon").disabled = false;
     document.getElementById('txtchargecode').focus();
     //new_button("Query")
     setButtonImages();
     return false;
}


function check_duplicasy()     
{
  var str=document.getElementById('hdnchkdup').value;
  var str1=str.split("#");
  var compc="COMP_CODE";
  var user="USERID";
  var moden="CHARGE_CODE";
  var tabn="AD_CHARGE_MAST";
  var modename= "'"+repalcesinglequote(document.getElementById('txtchargecode').value)+"'";
  var casemodename=modename.toUpperCase();
  //var compcode = "'"+document.getElementById('hdncompcode').value+"'";
  var compcode = "'"+document.getElementById('hiddencompcode').value+"'";
  var date=document.getElementById('hiddendateformat').value;
  Ad_Translation_charge.checkdupl(compc,compcode,"","''",tabn,moden,casemodename,"","''",date,"''","''",checkforduplicacy)
  return false;
  
}

function checkforduplicacy(res)
{

  dsd=res.value;
  if(dsd.Tables[0].Rows[0].NAME>="1" || dsd.Tables[0].Rows[0].ALIAS>="1")
  {
    if(dsd.Tables[0].Rows[0].NAME>="1" && dsd.Tables[0].Rows[0].ALIAS>="1")
       {
           var desc=repalcesinglequote($('txtchargename').value);
           $('txtchargename').value=desc.toUpperCase();
           if($('txtchargename').value==modifyduplicacydesc)
                {
                ModifyArea()
                return false;
                }
          
           else if ($('txtchargename').value==modifyduplicacydesc)
           {
              alert('The Charge Code already exist.No Duplicacy is Allowed')
              return false;
           }
           
           else if ($('txtchargealias').value==modifyduplicacyalias )
           {
             alert('The Charge Code already exist.No Duplicacy is Allowed.')
             $('txtchargename').value="";
             $('txtchargename').value=modifyduplicacydesc;
             modifyduplicacydesc=$('txtchargename').value;
             $('txtchargename').focus();
             return false;
           }
          
          else
           
        {
            alert('The Charge Code already exist.No Duplicacy is Allowed')
            $('txtchargename').value="";
            $('txtchargename').value=modifyduplicacydesc;
            modifyduplicacydesc=$('txtchargename').value;
            $('txtchargename').focus();
            return false;
        }
     }
 else if (dsd.Tables[0].Rows[0].NAME>="1")
      {
      
     // if($('txtexpname').value==modifyduplicacydesc)
      if($('txtchargename').value==modifyduplicacydesc)
                {
                  ModifyArea()
                  return false;
                }
       else
       {
          alert('The Charge Code already exist.No Duplicacy is Allowed.')
          $('txtchargename').value="";
          $('txtchargename').value=modifyduplicacydesc;
          $('txtchargename').focus();
          return false;
        }
      }
 else if (dsd.Tables[0].Rows[0].ALIAS>="1")
      {
      
            if($('txtchargealias').value==modifyduplicacyalias)
                {
                ModifyArea()
                return false;
                }
                
             else
              {
                return false;
              }
      }
 }


    else if (document.getElementById('btnSave').disabled ==false)
    {
        if (modiflag==1)
            {
            ModifyArea()
            return false;
            }
        else
            {
            save_charge();
            return false;
            }
    }


}







function checkkdate(input,box)
{
var inputid1=document.activeElement.id;
    var dateformat=document.getElementById('hiddendateformat').value;
    if(dateformat=="mm/dd/yyyy") 
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/  
    }
    
    if(dateformat=="yyyy/mm/dd") 
    {
        var validformat=/^\d{4}\/\d{2}\/\d{2}$/ 
    }
    
    if(dateformat=="dd/mm/yyyy")
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ 
    }

    if (!validformat.test(input))
    {
        if(input=="")
           return true;
        
       // setTimeout(settime12,15);
       if(document.activeElement.id.indexOf('nand')<0 || document.activeElement.id!='')
        {
            alert(" Please Fill The Date In "+dateformat+" Format");
            input="";
          document.getElementById(box).value="";
           // $('txtRedemfromdate').value="";
            inputid=document.activeElement.id;
            document.getElementById(box).focus();
            return false;
        }
    }
    else
    { //Detailed check for valid date ranges
        if(dateformat=="yyyy/mm/dd")
        {
            var yearfield=input.split("/")[0]
            var monthfield=input.split("/")[1]
            var dayfield=input.split("/")[2]
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
        if(dateformat=="mm/dd/yyyy")
        {
            var yearfield=input.split("/")[2]
            var monthfield=input.split("/")[0]
            var dayfield=input.split("/")[1]
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
        
        if(dateformat=="dd/mm/yyyy")
        {
            var yearfield=input.split("/")[2]
            var monthfield=input.split("/")[1]
            var dayfield=input.split("/")[0]
            //var dayobj = new Date(dayfield, monthfield-1, yearfield)
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
    } //end of else


    var abcd= dayobj.getMonth()+1;
    var date1=dayobj.getDate();
    var year1=dayobj.getFullYear();
    if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
    {
        alert(" Please Fill The Date In "+dateformat+" Format");
        input="";
        document.getElementById(box).value="";
          document.getElementById(box).focus();
        // $('txtRedemfromdate').value="";
        return false;
    }

    
//inputid1.select();

return true

}







function save_charge()
{
if(modiflag==1)
   {
       ModifyArea();
       return false;
   }
   else
   {
   
   
  var res= checkkdate(document.getElementById('txtfromdate').value,'txtfromdate')
  if(res==false)
  {
  return false;
  }
  
  
 var res1= checkkdate(document.getElementById('txttodate').value,'txttodate')
  if(res1==false)
  {
  return false;
  }
  
   
   
   //isDate(document.getElementById('txtfromdate').value,'txtfromdate','txtfromdate',document.getElementById('hiddendateformat').value);
  var str=$('hdntblfields').value
  var str1=str.split("$~$");
  var tablename=str1[str1.length-2];
  var action=str1[str1.length-1];
  var finalaction=action.split("#");
  var insert=finalaction[0];
  var update=finalaction[1];
  var del=finalaction[2];
  var select=finalaction[3];
  
  if(trim($('drpadtype').value)=="0")
 {
     alert('Please Select Ad Type') 
     $('drpadtype').value="0";
     $('drpadtype').focus()
     return false;
 }

if(trim($('txtchargename').value)=="")
 {
     alert('Please Enter Charge Name') 
     $('txtchargename').value="";
     $('txtchargename').focus()
     return false;
 }
 
 if(trim($('drpchargestype').value)=="")
 {
     alert('Please Enter Charge Type') 
     $('drpchargestype').value="";
     $('drpchargestype').focus()
     return false;
 }
 if(trim($('txtchargeamt').value)=="")
 {
     alert('Please Enter Charge Amount') 
     $('txtchargeamt').value="";
     $('txtchargeamt').focus()
     return false;
 }
 
 if(trim($('drpchargestype').value)=="")
 {
     alert('Please Enter Charge Type') 
     $('drpchargestype').value="";
     $('drpchargestype').focus()
     return false;
 }
 
 if(trim($('txtfromdate').value)=="")
 {
     alert('Please Enter Valid From Date') 
     $('txtfromdate').value="";
     $('txtfromdate').focus()
     return false;
 }

 if (trim($('txttodate').value) == "") {
     alert('Please Enter Valid to Date')
     $('txttodate').value = "";
     $('txttodate').focus()
     return false;
 }
 
 
 
 
 if((document.getElementById('txtfromdate').value) >(document.getElementById('txttodate').value))
 {
     alert('Valid from date can note be grater then valid to date') 
     $('txtfromdate').value="";
     $('txttodate').value="";
     $('txtfromdate').focus()
     return false;
 }
 
 
 
 
 if(trim($('drpchargeactive').value)=="")
 {
     alert('Please Select Charge Active') 
     $('drpchargeactive').value="";
     $('drpchargeactive').focus()
     return false;
 }

 if (trim($('drpchargeon').value) == "") {
     alert('Please Select Charge ON')
     $('drpchargeon').value = "";
     $('drpchargeon').focus()
     return false;
 }
 
  var nma=trim($('txtchargename').value);
  nma=chksplchar ($('txtchargename').id,nma)
  if(nma==unicodespl)
     {
     }
     else if(nma=="false" && splitsign==1)
     {
     alert('You cannot Insert Special character or "$~$"')
     //$('txtexpname').focus();
     $('txtchargename').focus();
     splitsign=0;
     return false;
     }
    
     else if(nma=="false" && sql_inject==1)
     {
       alert('You cannot Insert the KEYWORDS "SELECT,MODIFY,UPDATE,DELETE"')
       $('txtchargename').focus();
       sql_inject=0;
       return false;
     }
    
     else if(nma=="false" && greatersign==1)
     {
       alert('You cannot Insert Special character or "< and >"')
       $('txtchargename').focus();
       greatersign=0;
       return false;
     }
     else
     {
      return false;
     }
     
    $('txtchargename').value=trim($('txtchargename').value);
    var userid = "'"+document.getElementById('hiddenuserid').value+"'";
    var compcode = document.getElementById('hiddencompcode').value;
    var adtype = "'"+document.getElementById('drpadtype').value+"'";
    var chargecod="'"+document.getElementById('txtchargecode').value+"'";
    var caseareacode=chargecod.toUpperCase();
    var chargename = "'"+repalcesinglequote(trim($('txtchargename').value))+"'";
    var caseareaname=chargename.toUpperCase();
    var chargenamealias = "'"+trim($('txtchargealias').value)+"'";
    var chargenamealias1=chargenamealias.toUpperCase();
    var chargetype = "'"+$('drpchargestype').value+"'";
    var chargeamt="'"+$('txtchargeamt').value+"'";
    var vfromdate = "'"+$('txtfromdate').value+"'";
    var vtodate = "'"+$('txttodate').value+"'";
    var dateformats=document.getElementById('hiddendateformat').value;
    var createtime="'"+document.getElementById('HDN_server_date').value+"'";  
    var updateby="''";  
    var updatedate="''";  
     if ($('drpchargeactive').value=="0")
     {
     var ff="'A'";
     }
     else
     {
     var ff= "'"+document.getElementById('drpchargeactive').value+"'";
     }

     

     if ($('drpchargeon').value == "0") {
         var fk = "'G'";
     }
     else
     {
         var fk = "'" + document.getElementById('drpchargeon').value + "'";
     }

     var finalval = "'" + compcode + "'" + "$~$" + adtype + "$~$" + caseareacode + "$~$" + caseareaname + "$~$" + chargenamealias1 + "$~$" + chargetype + "$~$" + chargeamt + "$~$" + vfromdate + "$~$" + vtodate + "$~$" + ff + "$~$" + userid + "$~$" + createtime + "$~$" + updateby + "$~$" + updatedate + "$~$" + fk;
     var fields=document.getElementById('hdntblfields').value.replace("$~$"+tablename,"")
     fields=fields.replace("$~$"+action,"")
     var result= Ad_Translation_charge.save_area(fields,finalval,tablename,insert,dateformats,"","")
     if(document.getElementById('drpchargeactive').value="0")
     {
       document.getElementById('drpchargeactive').value="A"
     }
     if (document.getElementById('drpchargeon').value = "0")
     {
         document.getElementById('drpchargeon').value = "G"
     }

     if(result.value=="True")
     {
       alert("Data Save Successfully");
       pagerefresh();
       setButtonImages();
       return false;
     }
     else
     {
       var myerror=result.value.split("-");
       if(myerror[0]=="ORA")
       {
            if(myerror[1].indexOf("00001")>=0)
            {
            alert("This Combination Already inserted")
            return false;
            }
            if(myerror[1].indexOf("00911")>=0)
            {
            alert("There is an Invalid Character")
            return false;
            }
            
            if(myerror[1].indexOf("01722")>=0)
            {
            alert("There is an Invalid Number in the Number Field.")
            return false;
            }
            else
            {
            alert('There is some Unknown error from database.Please Check the values and enter again.')
            return false;
            }
       }
       
       return false;
    }

    
 
     return false;
     
}

}


function autoornot()
 {
 
  if(hiddentext=="new")
  {
    if(document.getElementById('hiddenauto').value==1)
    {
      autochange();
      return false;
    }
    else
    {
      userdefine();
      return false;
    }
  }
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modifysave_charge

function autochange()
{
if(hiddentext=="new" )
			{
	
            UPPERCASE();
           
           }
            else
            {
              document.getElementById('txtchargename').value=document.getElementById('txtchargename').value.toUpperCase();
              document.getElementById('hdnchargename').value=document.getElementById('txtchargename').value;	
            }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASE()
	{
	  if(document.getElementById('btnSave').disabled==true)
      {
         return false;
      }	
		
		
		document.getElementById('txtchargename').value=document.getElementById('txtchargename').value.toUpperCase();
			
		document.getElementById('txtchargename').value=trim(document.getElementById('txtchargename').value);
		//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		document.getElementById('txtchargealias').value=trim(document.getElementById('txtchargealias').value);
		document.getElementById('txtchargealias').focus();
		lstr=document.getElementById('txtchargename').value;
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
		
		    if(document.getElementById('txtchargename').value!="")
                {
                 
        
		document.getElementById('txtchargename').value=document.getElementById('txtchargename').value.toUpperCase();
		//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
	    document.getElementById('txtchargealias').value=document.getElementById('txtchargename').value;
		//str=document.getElementById('txtagencyname').value;
		str=mstr;
		var adcattype=document.getElementById('drpadtype').value;
		Ad_Translation_charge.chkagencytype(str,adcattype,fillcall);
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
		    alert("This translation charge name has already assigned !!");
		    document.getElementById('txtchargename').value="";
			//document.getElementById('txtagencycode').value="";
			document.getElementById('txtchargealias').value="";
		
		    document.getElementById('txtchargename').focus();
    		
		    return false;
		    }
//		
//		        else
//		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].CHARGE_CODE;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        //var code=newstr.substr(2,4);
		                        str=str.toUpperCase();
		                       // code++;
		                        document.getElementById('txtchargecode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                            str=str.toUpperCase();
		                          document.getElementById('txtchargecode').value=str.substr(0,2)+ "0";
		                          }
		     //}
	return false;
		}
		
		
		

function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtchargecode').disabled=false;
        document.getElementById('txtchargename').value=document.getElementById('txtchargename').value.toUpperCase();
        document.getElementById('txtchargename').value=trim(document.getElementById('txtchargename').value);
        document.getElementById('txtchargealias').value=trim(document.getElementById('txtchargealias').value);
        document.getElementById('txtchargealias').value=document.getElementById('txtchargename').value;
        document.getElementById('txtchargealias').focus();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

//return false;
}



function trim(stringToTrim) 
 {

	return stringToTrim.replace(/^\s+|\s+$/g,"");
 }

  /////////////////////////////check special character function////////////////////////////////////////
var splitsign=0;
var greatersign=0;
var sql_inject=0;
var unicodespl="";
function chksplchar(a,b)
{
unicodespl=b;
var result="false";
var code="abcdefghijklmnopqrstuvwxyz0123456789"
var myval=b;
if(b=="")
{
return true;
}

if(b.indexOf("$~$")>=0)
{
splitsign=1;
return result
}
if(b.indexOf("^")>=0)
{
splitsign=1;
return result
}
if(b.indexOf("<")>=0||b.indexOf(">")>=0 || b.indexOf("&lt;")>=0 || b.indexOf("&LT;")>=0 || b.indexOf("&gt;")>=0 || b.indexOf("&GT;")>=0 || b.indexOf("&lt")>=0 || b.indexOf("&LT")>=0 || b.indexOf("&gt")>=0 || b.indexOf("&GT")>=0)
{
greatersign=1;
return result
}

if(b.indexOf("select ")>=0 ||b.indexOf("SELECT ")>=0 || b.indexOf("update ")>=0 || b.indexOf("UPDATE ")>=0 || b.indexOf("insert ")>=0 || b.indexOf("INSERT ")>=0 || b.indexOf("delete ")>=0 || b.indexOf("DELETE ")>=0)
{
sql_inject=1;
return result
}

code=code.toLowerCase()
myval=myval.toLowerCase()
for(i=0;i<=myval.length-1;i++)
{
for(j=0;j<=code.length-1;j++)
{
if(myval.charAt(i)==code.charAt(j))
{
result="true";
break;
}
}
}
if(myval.length=="0")
{
return "true";
}
if(result=="false")
{
alert('You cannot enter special character in the text field');
$(a).focus();
return false
}
else
{
return b;
}
}



/************************this is code for execute*********************/
function EnableExecute()
{

  next=0;
//     if(document.getElementById("hdn_user_right").value=="3" || document.getElementById("hdn_user_right").value=="5" || document.getElementById("hdn_user_right").value=="6" || document.getElementById("hdn_user_right").value=="7")
//        {
//            $('btnDelete').disabled = false;
//        }
//        else
//        {
//            $('btnDelete').disabled = true;
//        }
        $('btnNew').disabled = true;
        $('btnQuery').disabled = false;
        $('btnCancel').disabled = false;
        $('btnExit').disabled = false;
        $('btnSave').disabled = true;
        $('btnExecute').disabled = true;
        $('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = false;
        $('btnModify').disabled = false;
        $('btnprevious').disabled = true;
        $('btnDelete').disabled = false;
        document.getElementById('btnnext').disabled=false;
        
               
        document.getElementById("drpadtype").disabled=true;
        document.getElementById("txtchargecode").disabled=true;
	    document.getElementById("txtchargename").disabled= true;
	    document.getElementById("txtchargealias").disabled=true;
        document.getElementById("drpchargestype").disabled= true;
        document.getElementById("txtchargeamt").disabled=true;
        document.getElementById("txtfromdate").disabled=true;
        document.getElementById("txttodate").disabled=true;
        document.getElementById("drpchargeactive").disabled=true; 
        document.getElementById("drpchargeon").disabled = true;
        var str = $('executefields').value;
        var str1=str.split("$~$");
        var tablename = str1[str1.length-2];
       
        var action = str1[str1.length-1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];
        
        
       // var userid = "'"+document.getElementById('hiddenuserid').value+"'";
    var compcode = document.getElementById('hiddencompcode').value;
    
    var adtype = document.getElementById('drpadtype').value;//"'"+document.getElementById('drpadtype').value+"'";
    if(adtype=="0")
    {
    adtype="";
    }
    var chargecod=document.getElementById('txtchargecode').value;
    var caseareacode=chargecod.toUpperCase();
    var chargename =repalcesinglequote(trim($('txtchargename').value));
    var caseareaname=chargename.toUpperCase();
    var chargenamealias = trim($('txtchargealias').value);
    var chargenamealias1=chargenamealias.toUpperCase();
    var chargetype = $('drpchargestype').value;
    var chargeamt=$('txtchargeamt').value;
    var vfromdate = $('txtfromdate').value;
    var vtodate = $('txttodate').value;
    var dateformats=document.getElementById('hiddendateformat').value;
    if ($('drpchargeactive').value=="0")
     {
     var ff="A";
     }
     else
     {
     var ff= document.getElementById('drpchargeactive').value;
     }
     

    if ($('drpchargeon').value == "0") {
        var fk = "";
    }
    else {
        var fk =  document.getElementById('drpchargeon').value;
    }


     var fields=document.getElementById('executefields').value.replace("$~$"+tablename,"")
         fields=fields.replace("$~$"+action,"")
         fields=fields+"$~$";
          
         var finalval =  compcode+ "~" + adtype + "~" + caseareacode + "~" + caseareaname + "~" + chargenamealias1 + "~" + chargetype + "~" + chargeamt + "~" + vfromdate + "~" + vtodate + "~" + ff + "~" + fk + "~";

         $('btnModify').focus();

     Ad_Translation_charge.mode_execute(tablename,fields,finalval,select,"","","",callback_exec)
     setButtonImages();
     return false;
}


function callback_exec(res)
	{
   
    next=0;
    dsexe=res.value;
    
    record_show=5
    record_show1=1
    
    
    if(dsexe==null || dsexe=="null")
    {
        alert('There is no record Regarding your query')
        return false;
    }
    
    if(dsexe.Tables[0].Rows.length==1)
    {       
     if(dsexe.Tables[0].Rows[next].AD_TYPE==null)
	 {
	  $('drpadtype').value="";
     }
	else
	{
	 $('drpadtype').value=dsexe.Tables[0].Rows[next].AD_TYPE
    }


	if(dsexe.Tables[0].Rows[next].CHARGE_CODE==null)
	{
	$('txtchargecode').value="";
    }
	else
	{
	$('txtchargecode').value=repalcestr2quote(dsexe.Tables[0].Rows[next].CHARGE_CODE)
    }

	
    
    if(dsexe.Tables[0].Rows[next].CHARGE_NAME==null)
	{	
	$('txtchargename').value="";  
    }
	else
	{
	$('txtchargename').value=dsexe.Tables[0].Rows[next].CHARGE_NAME   
    }
    
   if(dsexe.Tables[0].Rows[next].CHARGE_ALIAS==null)
	{
    	$('txtchargealias').value="";
    }
	else
	{
	  $('txtchargealias').value=dsexe.Tables[0].Rows[next].CHARGE_ALIAS
    }



	if(dsexe.Tables[0].Rows[next].CHARGES_TYPE==null)
	{
	$('drpchargestype').value="";
    }
	else
	{
	$('drpchargestype').value=dsexe.Tables[0].Rows[next].CHARGES_TYPE
    }
    
    if(dsexe.Tables[0].Rows[next].CHARGE_AMT==null)
	{	
	$('txtchargeamt').value="";  
    }
	else
	{
	 $('txtchargeamt').value=(dsexe.Tables[0].Rows[next].CHARGE_AMT)
	 
    }
    
    
    if(dsexe.Tables[0].Rows[next].VALID_FROM_DATE==null)
	{	
	$('txtfromdate').value="";  
    }
	else
	{
	 $('txtfromdate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_FROM_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].VALID_TILL_DATE==null)
	{	
	$('txttodate').value="";  
    }
	else
	{
	 $('txttodate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_TILL_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE==null)
	{	
	$('drpchargeactive').value="";  
    }
	else
	{
	 $('drpchargeactive').value=(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE)
    }



    if (dsexe.Tables[0].Rows[next].CHARGE_ON == null) {
        $('drpchargeon').value = "";
    }
    else {
        $('drpchargeon').value = (dsexe.Tables[0].Rows[next].CHARGE_ON)
    }
    
    $('btnfirst').disabled = true;
	$('btnlast').disabled = true;
	$('btnprevious').disabled = true;
	$('btnnext').disabled = true;
    }
    
    else if(dsexe.Tables[0].Rows.length>0)
    {       
             
    if(dsexe.Tables[0].Rows[next].AD_TYPE==null)
	 {
	  $('drpadtype').value="";
     }
	else
	{
	 $('drpadtype').value=dsexe.Tables[0].Rows[next].AD_TYPE
    }


	if(dsexe.Tables[0].Rows[next].CHARGE_CODE==null)
	{
	$('txtchargecode').value="";
    }
	else
	{
	$('txtchargecode').value=repalcestr2quote(dsexe.Tables[0].Rows[next].CHARGE_CODE)
    }

	
    
    if(dsexe.Tables[0].Rows[next].CHARGE_NAME==null)
	{	
	$('txtchargename').value="";  
    }
	else
	{
	$('txtchargename').value=dsexe.Tables[0].Rows[next].CHARGE_NAME   
    }
    
   if(dsexe.Tables[0].Rows[next].CHARGE_ALIAS==null)
	{
    	$('txtchargealias').value="";
    }
	else
	{
	  $('txtchargealias').value=dsexe.Tables[0].Rows[next].CHARGE_ALIAS
    }



	if(dsexe.Tables[0].Rows[next].CHARGES_TYPE==null)
	{
	$('drpchargestype').value="";
    }
	else
	{
	$('drpchargestype').value=dsexe.Tables[0].Rows[next].CHARGES_TYPE
    }
    
    if(dsexe.Tables[0].Rows[next].CHARGE_AMT==null)
	{	
	$('txtchargeamt').value="";  
    }
	else
	{
	 $('txtchargeamt').value=(dsexe.Tables[0].Rows[next].CHARGE_AMT)
	 
    }
    
    
    if(dsexe.Tables[0].Rows[next].VALID_FROM_DATE==null)
	{	
	$('txtfromdate').value="";  
    }
	else
	{
	 $('txtfromdate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_FROM_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].VALID_TILL_DATE==null)
	{	
	$('txttodate').value="";  
    }
	else
	{
	 $('txttodate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_TILL_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE==null)
	{	
	$('drpchargeactive').value="";  
    }
	else
	{
	 $('drpchargeactive').value=(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE)
    }

    if (dsexe.Tables[0].Rows[next].CHARGE_ON == null) {
        $('drpchargeon').value = "";
    }
    else {
        $('drpchargeon').value = (dsexe.Tables[0].Rows[next].CHARGE_ON)
    }
   	return false;
	}
	
	else if(dsexe.Tables[0].Rows.length==0)
	{
	  alert("There Is no Data Regarding your query!");
      pagerefresh();
      setButtonImages();
	  return false;
	}
	return false;
	
}




/**************************this code is used for delete records**************/

function Delete_Record()
{
  

var str = $('hdntblfields').value;
var str1=str.split("$~$");
var tablename = str1[str1.length-2];
var action = str1[str1.length-1];
var finalaction = action.split("#");
var insert = finalaction[0];
var update = finalaction[1];
var del = finalaction[2];
var select = finalaction[3];


var str2 = $('deltblfields').value;
var str3=str2.split("$~$");
var delcolname="";
var deltblname=str3[str3.length-1];
    
delcolname=str2.replace("$~$"+deltblname,"")
delcolname=delcolname+"$~$";


var compcode = document.getElementById('hiddencompcode').value;
    
    var adtype = "'"+document.getElementById('drpadtype').value+"'";
    var chargecod="'"+document.getElementById('txtchargecode').value+"'";
    var caseareacode=chargecod.toUpperCase();
    var chargename = "'"+repalcesinglequote(trim($('txtchargename').value))+"'";
    var caseareaname=chargename.toUpperCase();
    var chargenamealias = "'"+trim($('txtchargealias').value)+"'";
    var chargenamealias1=chargenamealias.toUpperCase();
    var chargetype = "'"+$('drpchargestype').value+"'";
    var chargeamt="'"+$('txtchargeamt').value+"'";
    var vfromdate = "'"+$('txtfromdate').value+"'";
    var vtodate = "'"+$('txttodate').value+"'";
    var dateformats=document.getElementById('hiddendateformat').value;
    var ff= "'"+document.getElementById('drpchargeactive').value+"'";
    var fk = "'" + document.getElementById('drpchargeon').value + "'";
     var fi=$('hdntblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"");
        fi=fi+"$~$";
     
     
     var fields=document.getElementById('executefields').value.replace("$~$"+tablename,"")
         fields=fields.replace("$~$"+action,"")
         fields=fields+"$~$";
          
     var finalval="'"+compcode+"'"+"$~$"+adtype+"$~$"+caseareacode+"$~$"+caseareaname+"$~$"+chargenamealias1+"$~$"+chargetype+"$~$"+chargeamt+"$~$"+vfromdate+"$~$"+vtodate+"$~$"+ff+"$~$";
     var delcolvalue=caseareacode+"$~$";
     boolReturn = confirm("Are you sure You Want to delete this Record!");
     if(boolReturn==1)
     {
       Ad_Translation_charge.area_delete(tablename,delcolname,delcolvalue,del,"","","");
            
       alert("Data Delete Successfully!")
       pagerefresh();
       setButtonImages();
       return false;
	}
	else
	  {
	    $('btnDelete').focus();
	    return false;
	  }
   return false;
}



/*************************this is code is used for Modify Records*******************/
var modifyduplicacydesc;
var modifyduplicacyalias;

function Modify_Records()
{
    modiflag=1;
    $('btnModify').disabled = true;
    $('btnSave').disabled = false;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = true;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = true;
    
    $('drpadtype').disabled = false;
    $('txtchargecode').disabled = true;
    $('txtchargename').disabled = true;
    $('txtchargealias').disabled = true;
    
    $('drpchargestype').disabled = false;
    $('txtchargeamt').disabled = false;
    $('txtfromdate').disabled = false;
    $('txttodate').disabled = false;
    $('drpchargeactive').disabled = false;
    $('drpchargeon').disabled = false;
    modifyduplicacydesc=$('txtchargename').value;
    $('btnSave').focus();
    //new_button("Modify")
    setButtonImages();
    return false;
}



function ModifyArea()
{
modiflag=1;
var str = $('hdntblfields').value;
//var str=('hdnupdate').value;
var str1=str.split("$~$");
var tablename = str1[str1.length-2];
var action = str1[str1.length-1];
var finalaction = action.split("#");
var insert = finalaction[0];
var update = finalaction[1];
var del = finalaction[2];
var select = finalaction[3];


var str2 = $('deltblfields').value;
//var str2 = $('hdnupdate').value;
var str3=str2.split("$~$");
var modcolname="";
var modtblname=str3[str3.length-1];
modcolname=str2.replace("$~$"+modtblname,"")
modcolname=str2+"$~$";

 
// if(trim($('txtextypdes').value)=="")
//  { 
//     alert(alrtareaname)
//     $('txtextypdes').value="";
//     $('txtextypdes').focus()
//     return false;
//  }
  var nma=trim($('txtchargename').value);
  nma=chksplchar ($('txtchargename').id,nma)
  if(nma==unicodespl)
     {
     }
  else if(nma=="false" && splitsign==1)
   {
     alert('You cannot Insert Special character or "$~$"')
     $('txtchargename').focus();
     splitsign=0;
     return false;
   }
   else if(nma=="false" && sql_inject==1)
    {
      alert('You cannot Insert the KEYWORDS "SELECT,MODIFY,UPDATE,DELETE"')
      $('txtchargename').focus();
      sql_inject=0;
      return false;
    }
    else if(nma=="false" && greatersign==1)
    {
      alert('You cannot Insert Special character or "< and >"')
      $('txtchargename').focus();
      greatersign=0;
      return false;
    }
     else
     {
     return false;
     }
                       
    $('txtchargename').value=trim($('txtchargename').value);
    var userid = "'"+document.getElementById('hiddenuserid').value+"'";
    var compcode = document.getElementById('hiddencompcode').value;
    var adtype = "'"+document.getElementById('drpadtype').value+"'";
    var chargecod="'"+document.getElementById('txtchargecode').value+"'";
    var caseareacode=chargecod.toUpperCase();
    var chargename = "'"+repalcesinglequote(trim($('txtchargename').value))+"'";
    var caseareaname=chargename.toUpperCase();
    var chargenamealias = "'"+trim($('txtchargealias').value)+"'";
    var chargenamealias1=chargenamealias.toUpperCase();
    var chargetype = "'"+$('drpchargestype').value+"'";
    var chargeamt="'"+$('txtchargeamt').value+"'";
    var vfromdate = "'"+$('txtfromdate').value+"'";
    var vtodate = "'"+$('txttodate').value+"'";
    var dateformats=document.getElementById('hiddendateformat').value;
    
    /*var kk=document.getElementById('HDN_server_date').value.split("/");
    
    dd=kk[1]+"/"+kk[0]+"/"+kk[2];
    if(kk[1].length<2)
    {
    dd="0"+kk[1]+"/"+kk[0]+"/"+kk[2];
    
    }
    
    if(kk[0].length<2)
    {
     dd=kk[1]+"/"+"0"+kk[0]+"/"+kk[2];
    }
    var createtime="'"+CHKDATE(dd)+"'";*/
    
    var createtime="'"+document.getElementById('HDN_server_date').value+"'";  
    var updateby="'"+document.getElementById('hiddenuserid').value+"'";  
    var updatedate="'"+document.getElementById('HDN_server_date').value+"'"; 
     if ($('drpchargeactive').value=="0")
     {
     var ff="'A'";
     }
     else
     {
     var ff= "'"+document.getElementById('drpchargeactive').value+"'";
     }
     if ($('drpchargeon').value == "0") {
         var fk = "'A'";
     }
     else {
         var fk = "'" + document.getElementById('drpchargeon').value + "'";
     }

      
     var finalval = "'" + compcode + "'" + "$~$" + adtype + "$~$" + caseareacode + "$~$" + caseareaname + "$~$" + chargenamealias1 + "$~$" + chargetype + "$~$" + chargeamt + "$~$" + vfromdate + "$~$" + vtodate + "$~$" + ff + "$~$" + userid + "$~$" + createtime + "$~$" + updateby + "$~$" + updatedate + "$~$" + fk + "$~$";
     var fields=document.getElementById('hdntblfields').value.replace("$~$"+tablename,"")
     fields=fields.replace("$~$"+action,"")
     fields=fields+"$~$";
     
     var wherecondition=caseareacode+"$~$";
     var result= Ad_Translation_charge.area_modify(fields,finalval,tablename,update,modcolname,dateformats,"","")
    
  if(result.value=="true")
   {
     alert("Data Modify Successfully!")
     modiflag=0;
     pagerefresh();
     setButtonImages();
     return false;
   }
  else
    {
       var myerror=result.value.split("-");
       if(myerror[0]=="ORA")
       {
            if(myerror[1].indexOf("00001")>=0)
            {
            alert("This Combination Already inserted")
            return false;
            }
            if(myerror[1].indexOf("00911")>=0)
            {
            alert("There is an Invalid Character")
            return false;
            }
            
            if(myerror[1].indexOf("01722")>=0)
            {
            alert("There is an Invalid Number in the Number Field.")
            return false;
            }
            else
            {
            alert('There is some Unknown error from database.Please Check the values and enter again.')
            return false;
            }
       }
       return false;
    }

    $('txtextypcode').disabled = true;
    $('txtextypdes').disabled = true;
    $('drpfrzflag').disabled = true;
    $('btnModify').disabled = false;
    $('btnQuery').disabled = false;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnDelete').disabled = false;
    $('btnSave').disabled = true;
    $('btnModify').focus();
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnprevious').disabled=true;
   
}


/******************************************************/
function Find_NextRecord()
{
   record_show=5
   record_show1=1
   next++;
   var record= dsexe.Tables[0].Rows.length;
   if(next<=record && next>=0)
    {
    if(dsexe.Tables[0].Rows.length != next && next !=-1)
	{
	if(dsexe.Tables[0].Rows[next].AD_TYPE==null)
	 {
	  $('drpadtype').value="";
     }
	else
	{
	 $('drpadtype').value=dsexe.Tables[0].Rows[next].AD_TYPE
    }


	if(dsexe.Tables[0].Rows[next].CHARGE_CODE==null)
	{
	$('txtchargecode').value="";
    }
	else
	{
	$('txtchargecode').value=repalcestr2quote(dsexe.Tables[0].Rows[next].CHARGE_CODE)
    }

	
    
    if(dsexe.Tables[0].Rows[next].CHARGE_NAME==null)
	{	
	$('txtchargename').value="";  
    }
	else
	{
	$('txtchargename').value=dsexe.Tables[0].Rows[next].CHARGE_NAME   
    }
    
   if(dsexe.Tables[0].Rows[next].CHARGE_ALIAS==null)
	{
    	$('txtchargealias').value="";
    }
	else
	{
	  $('txtchargealias').value=dsexe.Tables[0].Rows[next].CHARGE_ALIAS
    }



	if(dsexe.Tables[0].Rows[next].CHARGES_TYPE==null)
	{
	$('drpchargestype').value="";
    }
	else
	{
	$('drpchargestype').value=dsexe.Tables[0].Rows[next].CHARGES_TYPE
    }
    
    if(dsexe.Tables[0].Rows[next].CHARGE_AMT==null)
	{	
	$('txtchargeamt').value="";  
    }
	else
	{
	 $('txtchargeamt').value=(dsexe.Tables[0].Rows[next].CHARGE_AMT)
	 
    }
    
    
    if(dsexe.Tables[0].Rows[next].VALID_FROM_DATE==null)
	{	
	$('txtfromdate').value="";  
    }
	else
	{
	 $('txtfromdate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_FROM_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].VALID_TILL_DATE==null)
	{	
	$('txttodate').value="";  
    }
	else
	{
	 $('txttodate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_TILL_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE==null)
	{	
	$('drpchargeactive').value="";  
    }
	else
	{
	 $('drpchargeactive').value=(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE)
    }
    if (dsexe.Tables[0].Rows[next].CHARGE_ON == null) {
        $('drpchargeon').value = "";
    }
    else {
        $('drpchargeon').value = (dsexe.Tables[0].Rows[next].CHARGE_ON)
    }
    
    
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = false;
        
        document.getElementById('drpadtype').disabled = true;
        document.getElementById('txtchargecode').disabled = true;
        document.getElementById('txtchargename').disabled = true;
        
        $('txtchargealias').disabled = true;  
        $('drpchargestype').disabled = true;  
        $('txtchargeamt').disabled = true; 
        
        $('txtfromdate').disabled = true;  
        $('txttodate').disabled = true;  
        $('drpchargeactive').disabled = true; 
        $('drpchargeon').disabled = true;
        
     }
 }
     
     if(next==record-1 )
     {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('drpadtype').disabled = true;
        document.getElementById('txtchargecode').disabled = true;
        document.getElementById('txtchargename').disabled = true;
        
        $('txtchargealias').disabled = true;  
        $('drpchargestype').disabled = true;  
        $('txtchargeamt').disabled = true; 
        
        $('txtfromdate').disabled = true;  
        $('txttodate').disabled = true;  
        $('drpchargeactive').disabled = true;
        $('drpchargeon').disabled = true;
        $('btnprevious').focus();
     }
     setButtonImages();
   return false;
   
}


function Find_PreRecord()
{
    record_show=5
    record_show1=1
    next--;
    var record= dsexe.Tables[0].Rows.length;
    if(next>record)
	{
		
	  document.getElementById('btnfirst').disabled=false;				
	  document.getElementById('btnprevious').disabled=false;			
	  document.getElementById('btnnext').disabled=true;					
	  document.getElementById('btnlast').disabled=false;
	  return false;
				
	}
   
 if(next!=-1 && next>=0)
  {
	if(dsexe.Tables[0].Rows.length != next)
	{
    
    if(dsexe.Tables[0].Rows[next].AD_TYPE==null)
	 {
	  $('drpadtype').value="";
     }
	else
	{
	 $('drpadtype').value=dsexe.Tables[0].Rows[next].AD_TYPE
    }


	if(dsexe.Tables[0].Rows[next].CHARGE_CODE==null)
	{
	$('txtchargecode').value="";
    }
	else
	{
	$('txtchargecode').value=repalcestr2quote(dsexe.Tables[0].Rows[next].CHARGE_CODE)
    }

	
    
    if(dsexe.Tables[0].Rows[next].CHARGE_NAME==null)
	{	
	$('txtchargename').value="";  
    }
	else
	{
	$('txtchargename').value=dsexe.Tables[0].Rows[next].CHARGE_NAME   
    }
    
   if(dsexe.Tables[0].Rows[next].CHARGE_ALIAS==null)
	{
    	$('txtchargealias').value="";
    }
	else
	{
	  $('txtchargealias').value=dsexe.Tables[0].Rows[next].CHARGE_ALIAS
    }



	if(dsexe.Tables[0].Rows[next].CHARGES_TYPE==null)
	{
	$('drpchargestype').value="";
    }
	else
	{
	$('drpchargestype').value=dsexe.Tables[0].Rows[next].CHARGES_TYPE
    }
    
    if(dsexe.Tables[0].Rows[next].CHARGE_AMT==null)
	{	
	$('txtchargeamt').value="";  
    }
	else
	{
	 $('txtchargeamt').value=(dsexe.Tables[0].Rows[next].CHARGE_AMT)
	 
    }
    
    
    if(dsexe.Tables[0].Rows[next].VALID_FROM_DATE==null)
	{	
	$('txtfromdate').value="";  
    }
	else
	{
	 $('txtfromdate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_FROM_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].VALID_TILL_DATE==null)
	{	
	$('txttodate').value="";  
    }
	else
	{
	 $('txttodate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_TILL_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE==null)
	{	
	$('drpchargeactive').value="";  
    }
	else
	{
	 $('drpchargeactive').value=(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE)
	}
    if (dsexe.Tables[0].Rows[next].CHARGE_ON == null) {
        $('drpchargeon').value = "";
    }
    else {
        $('drpchargeon').value = (dsexe.Tables[0].Rows[next].CHARGE_ON)
    }
      document.getElementById('btnnext').disabled = false;
      document.getElementById('btnprevious').disabled=false;
      document.getElementById('btnlast').disabled=false;  
      
   }
 }
     if (next==0)
     {

        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled=false;
        document.getElementById('btnnext').disabled=false;
        $('btnnext').focus();
            
     }
    setButtonImages();  
   return false;
   
}




function Find_Firstrecord()
{
    record_show=5
    record_show1=1
    next=0;
   if(dsexe.Tables[0].Rows[next].AD_TYPE==null)
	 {
	  $('drpadtype').value="";
     }
	else
	{
	 $('drpadtype').value=dsexe.Tables[0].Rows[next].AD_TYPE
    }


	if(dsexe.Tables[0].Rows[next].CHARGE_CODE==null)
	{
	$('txtchargecode').value="";
    }
	else
	{
	$('txtchargecode').value=repalcestr2quote(dsexe.Tables[0].Rows[next].CHARGE_CODE)
    }

	
    
    if(dsexe.Tables[0].Rows[next].CHARGE_NAME==null)
	{	
	$('txtchargename').value="";  
    }
	else
	{
	$('txtchargename').value=dsexe.Tables[0].Rows[next].CHARGE_NAME   
    }
    
   if(dsexe.Tables[0].Rows[next].CHARGE_ALIAS==null)
	{
    	$('txtchargealias').value="";
    }
	else
	{
	  $('txtchargealias').value=dsexe.Tables[0].Rows[next].CHARGE_ALIAS
    }



	if(dsexe.Tables[0].Rows[next].CHARGES_TYPE==null)
	{
	$('drpchargestype').value="";
    }
	else
	{
	$('drpchargestype').value=dsexe.Tables[0].Rows[next].CHARGES_TYPE
    }
    
    if(dsexe.Tables[0].Rows[next].CHARGE_AMT==null)
	{	
	$('txtchargeamt').value="";  
    }
	else
	{
	 $('txtchargeamt').value=(dsexe.Tables[0].Rows[next].CHARGE_AMT)
	 
    }
    
    
    if(dsexe.Tables[0].Rows[next].VALID_FROM_DATE==null)
	{	
	$('txtfromdate').value="";  
    }
	else
	{
	 $('txtfromdate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_FROM_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].VALID_TILL_DATE==null)
	{	
	$('txttodate').value="";  
    }
	else
	{
	 $('txttodate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_TILL_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE==null)
	{	
	$('drpchargeactive').value="";  
    }
	else
	{
	 $('drpchargeactive').value=(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE)
	}
    
    if (dsexe.Tables[0].Rows[next].CHARGE_ON == null) {
        $('drpchargeon').value = "";
    }
    else {
        $('drpchargeon').value = (dsexe.Tables[0].Rows[next].CHARGE_ON)
    }



     document.getElementById('btnnext').disabled = false;
     document.getElementById('btnfirst').disabled = true;
     document.getElementById('btnprevious').disabled = true;
     document.getElementById('btnlast').disabled=false;
     $('btnnext').focus();
     setButtonImages();
     return false;
}


function Find_Lastrecord()
{
   record_show=5
   record_show1=1
   var record=dsexe.Tables[0].Rows.length;
   next=record-1;
   record=record-1;
   if(dsexe.Tables[0].Rows[next].AD_TYPE==null)
	{
	  $('drpadtype').value="";
     }
	else
	{
	 $('drpadtype').value=dsexe.Tables[0].Rows[next].AD_TYPE
    }


	if(dsexe.Tables[0].Rows[next].CHARGE_CODE==null)
	{
	$('txtchargecode').value="";
    }
	else
	{
	$('txtchargecode').value=repalcestr2quote(dsexe.Tables[0].Rows[next].CHARGE_CODE)
    }

	
    
    if(dsexe.Tables[0].Rows[next].CHARGE_NAME==null)
	{	
	$('txtchargename').value="";  
    }
	else
	{
	$('txtchargename').value=dsexe.Tables[0].Rows[next].CHARGE_NAME   
    }
    
   if(dsexe.Tables[0].Rows[next].CHARGE_ALIAS==null)
	{
    	$('txtchargealias').value="";
    }
	else
	{
	  $('txtchargealias').value=dsexe.Tables[0].Rows[next].CHARGE_ALIAS
    }



	if(dsexe.Tables[0].Rows[next].CHARGES_TYPE==null)
	{
	$('drpchargestype').value="";
    }
	else
	{
	$('drpchargestype').value=dsexe.Tables[0].Rows[next].CHARGES_TYPE
    }
    
    if(dsexe.Tables[0].Rows[next].CHARGE_AMT==null)
	{	
	$('txtchargeamt').value="";  
    }
	else
	{
	 $('txtchargeamt').value=(dsexe.Tables[0].Rows[next].CHARGE_AMT)
	 
    }
    
    
    if(dsexe.Tables[0].Rows[next].VALID_FROM_DATE==null)
	{	
	$('txtfromdate').value="";  
    }
	else
	{
	 $('txtfromdate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_FROM_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].VALID_TILL_DATE==null)
	{	
	$('txttodate').value="";  
    }
	else
	{
	 $('txttodate').value=CHKDATE(dsexe.Tables[0].Rows[next].VALID_TILL_DATE)
	}
    
    if(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE==null)
	{	
	$('drpchargeactive').value="";  
    }
	else
	{
	 $('drpchargeactive').value=(dsexe.Tables[0].Rows[next].CHARGE_ACTIVE)
	}

    if (dsexe.Tables[0].Rows[next].CHARGE_ON == null) {
        $('drpchargeon').value = "";
    }
    else {
        $('drpchargeon').value = (dsexe.Tables[0].Rows[next].CHARGE_ON)
    }
    


     document.getElementById('btnCancel').disabled = false;
     document.getElementById('btnExit').disabled = false;
     document.getElementById('btnfirst').disabled = false;
     document.getElementById('btnlast').disabled = true;
     document.getElementById('btnprevious').disabled = false;
     document.getElementById('btnnext').disabled = true;
     $('btnprevious').focus();
     setButtonImages();
     return false;   
}






function Exit()
{
       if(confirm('Do You Want to Close This Window!'))
       {
         window.close();
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












function repalcesinglequote(val)
{
    if(val.indexOf("'")>=0)
    {
        while(val.indexOf("'")>=0)
        {
            val=val.replace("'","^");
        }
    }
    return val;
}


function repalcestr2quote(val)
{
    if(val.indexOf("^")>=0)
    {
        while(val.indexOf("^")>=0)
        {
            val=val.replace("^","'");
        }
    }
    return val;
}




function CHKDATE(userdate)
{
var mycondate=""
   
if(userdate==null || userdate=="")
{
    mycondate=""
    return mycondate
}
else
{
   
    var myDate=new Date(userdate);
    var dd = myDate.getDate();
    var d;

    if(dd<=9 && dd>=1)
    {
        d='0'+dd;
        dd=d;
    }
    var mm = myDate.getMonth()+1;
    var m;
    if(mm<=9 && mm>=1)
    {
    m='0'+mm;
    mm=m;
    }
    var year = myDate.getFullYear();
    if($('hiddendateformat').value=="mm/dd/yyyy")
        {
        mycondate= mm +"/"+ dd +"/"+ year;
        }
        else if ($('hiddendateformat').value=="dd/mm/yyyy")
        {
        mycondate=dd + "/" + mm + "/" + year;
        }
        else
        {
        mycondate=yyyy+"/"+mm+"/"+dd;
        }
        
    //mycondate=myDate.getDate()+"/"+myDate.getMonth()+"/"+myDate.getFullYear();
    //mycondate = mm +"/"+ dd +"/"+ year;
    //$('txtfromdate').value=mycondate; 
    return mycondate;
   
}
}

function tabvalueadagency(event) {

    var key = event.keyCode ? event.keyCode : event.which;


    if (key == 13) {


        if (document.activeElement.id == "drpadtype") {
            document.getElementById("txtchargename").focus();
            return false;

        }
//        if (document.activeElement.id == "txtchargecode") {
//            document.getElementById("txtchargename").focus();
//            return false;

//        }
        if (document.activeElement.id == "txtchargename") {
            document.getElementById("txtchargealias").focus();
            return false;

        }
        if (document.activeElement.id == "txtchargealias") {
            document.getElementById("drpchargestype").focus();
            return false;

        }
        if (document.activeElement.id == "drpchargestype") {
            document.getElementById("txtchargeamt").focus();
            return false;

        }
        if (document.activeElement.id == "txtchargeamt") {
            document.getElementById("txtfromdate").focus();
            return false;

        }

        if (document.activeElement.id == "txtfromdate") {
            document.getElementById("txttodate").focus();
            return false;

        }
        if (document.activeElement.id == "txttodate") {
            document.getElementById("drpchargeactive").focus();
            return false;

        }

        if (document.activeElement.id == "drpchargeactive") {
            document.getElementById("drpchargeon").focus();
            return false;

        }

        if (document.activeElement.id == "drpchargeon") {
            document.getElementById("btnSave").focus();
            return false;

        }
    }

//    if (key == 116) {

//        window.open('report2.aspx', '_self', '', false)
//        return false;
//    }


}



/******************************Date validation*******************/

var dtCh = "/";
var minYear = 1900;
var maxYear = 2100;
function ValidateForm(event, id) {
    var dt = $(id).value;
    if (isDate12(dt, id) == false) {
        $(id).focus();
        return false;
    }
    return true;
}


function isDate12(dtStr, id) {

    if ($(id).value == "" || $(id).value == $('hiddendateformat').value) {
        $(id).value = "";
    }


    else {

        if ($('hiddendateformat').value == "mm/dd/yyyy") {

            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strMonth = dtStr.substring(0, pos1);
            var strDay = dtStr.substring(pos1 + 1, pos2);
            var strYear = dtStr.substring(pos2 + 1);
            strYr = strYear;
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            month = parseInt(strMonth);
            day = parseInt(strDay);
            year = parseInt(strYr);
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : mm/dd/yyyy")
                $(id).value = "";
                $(id).focus();
                return false;
            }
        }


        else if (($('hiddendateformat').value == "dd/mm/yyyy")) {
            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strDay = dtStr.substring(0, pos1);
            var strMonth = dtStr.substring(pos1 + 1, pos2);
            var strYear = dtStr.substring(pos2 + 1);
            strYr = strYear;
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            day = parseInt(strDay);
            month = parseInt(strMonth);
            year = parseInt(strYr);
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : dd/mm/yyyy")
                $(id).value = "";
                $(id).focus();
                return false;
            }

        }
        else {
            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strYear = dtStr.substring(0, pos1);
            var strMonth = dtStr.substring(pos1 + 1, pos2);
            var strDay = dtStr.substring(pos2 + 1);
            strYr = strYear;
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            day = parseInt(strDay);
            month = parseInt(strMonth);
            year = parseInt(strYr);
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : yyyy/mm/dd")
                $(id).value = "";
                $(id).focus();
                return false;
            }
        }
        if (strMonth.length < 1 || month < 1 || month > 12) {
            alert("Please enter a valid month")
            $(id).focus();
            return false;
        }
        if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
            alert("Please enter a valid day")
            $(id).focus();
            return false;
        }

        if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
            alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear)
            $(id).focus();
            return false;
        }
        if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
            alert("Please enter a valid date")
            $(id).focus();
            return false;
        }
    }

}

function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}


function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
        this[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
        if (i == 2) { this[i] = 29 }
    }
    return this
}

