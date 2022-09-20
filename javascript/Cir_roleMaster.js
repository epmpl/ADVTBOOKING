 var  modiflag=0;
 var  rolecodeexe="";
 var  rolenameexe="";
 var  frzexe="";
 var  dsexe = "";
 var  next=0;
 
 var alrtlevel="";
 var alrtrolename="";
 var alrtSaved="";
 var alrtModify="";
 var alrtDelete="";
 var alrtNoData="";
 var alrtExit="";
 var alrtConformDelete="";
 
  function loadXML(xmlFile)
{
   var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
   xmlDoc.async="false";
   xmlDoc.load(xmlFile);
   xmlObj=xmlDoc.documentElement;
   $('hdnalrt').value=xmlObj.childNodes[4].childNodes[0].text;
   
   var alert = document.getElementById('hdnalrt').value;
   var alert1=alert.split("$~$");
   
   
   alrtrolename =alert1[0];
   alrtlevel =alert1[1];
   alrtSaved =alert1[2]; 
   alrtModify =alert1[3];  
   alrtConformDelete =alert1[4];
   alrtNoData =alert1[5];
   alrtExit =alert1[6];
   alrtDelete =alert1[7];
  
  }
 
function blankfields()
{

//if(document.getElementById("hdn_user_right").value=="0" || document.getElementById("hdn_user_right").value=="")
//{
//alert("You are not Authorized to see this form")
//window.close();
//return false;
//}
//else
//{
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
        document.getElementById('txtcompcode').disabled = true;
        document.getElementById('txtcompname').disabled = true;
         
         document.getElementById('txtRoleCode').disabled = true;
        document.getElementById('txtRoleName').disabled = true;
         document.getElementById('ddlLevels').disabled = true;
        document.getElementById('drpfreezflag').disabled = true;
           
        document.getElementById('txtcompcode').value=$('hdncompcode').value
        document.getElementById('txtcompname').value=$('hdncompname').value
        document.getElementById('txtRoleCode').value = "";
        document.getElementById('txtRoleName').value = "";
        document.getElementById('ddlLevels').value = "0";
        document.getElementById('drpfreezflag').value = "0";
      
       $('button4').style.display='none';
      // new_button("New");
         return false;
//}

}
 function Enableonnew()
{
        modifyduplicacyalias="";
        modifyduplicacydesc="";
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
        
        document.getElementById ('txtcompcode').disabled=true;
        document.getElementById ('txtcompname').disabled=true;
        document .getElementById ('txtRoleCode').disabled=true ;
        document .getElementById ('txtRoleName').disabled=false ;
        document.getElementById('ddlLevels').disabled = false;
        document.getElementById('drpfreezflag').disabled = false;
         document.getElementById('drpfreezflag').value="N";
         document.getElementById('txtRoleName').focus();
        // new_button();
         return false;
}


function generatecode()
{
 var compcode=$('hdncompcode').value;
 var dateformat=$('hiddendateformat').value;
 var extra1="";
 var extra2="";
 Cir_roleMaster.generatecode(compcode ,dateformat ,extra1 ,extra2,callback_SaveRole )
 return false;
}

function callback_SaveRole(record)
{
 ds=record.value;
   if(modiflag==1)
   {
     ModifyClass();
       return false;
   }
   else
   {
     var compcode = "'"+document.getElementById('txtcompcode').value+"'";
     var unitcode="'"+document.getElementById('hdnunit').value+"'";
     var uid = "'"+document.getElementById('hdnuserid').value+"'";
     
     var str=document .getElementById ('tblfields').value;
     
     var str1=str.split("$~$");
     var tablename = str1[str1.length-2];
    
     var action = str1[str1.length-1];
     var finalaction = action.split("#");
     var insert = finalaction[0];
     var update = finalaction[1];
     var del = finalaction[2];
     var select = finalaction[3];
    if(trim($('txtRoleName').value)=="")
        {
        alert(alrtrolename );
        $('txtRoleName').focus();
        return false;
        }
         if($('ddlLevels').value=="0")
        {
        alert(alrtlevel );
        $('ddlLevels').focus();
        return false;
        }
     
  
    var nma=trim($('txtRoleName').value);
    nma=chksplchar ($('txtRoleName').id,nma)
                                                
     if(nma==unicodespl)
     {
     }
     else if(nma=="false" && splitsign==1)
     {
     alert('You cannot Insert Special character or "$~$"')
     $('txtRoleName').focus();
     splitsign=0;
     return false;
     }
    
     else if(nma=="false" && sql_inject==1)
     {
     alert('You cannot Insert the KEYWORDS "SELECT,MODIFY,UPDATE,DELETE"')
     $('txtRoleName').focus();
     sql_inject=0;
     return false;
     }
    
     else if(nma=="false" && greatersign==1)
     {
     alert('You cannot Insert Special character or "< and >"')
     $('txtRoleName').focus();
     greatersign=0;
     return false;
     }
     else if(nma==true)
     {
     return "";
     }
     else
     {
     return false;
     }
      
                                          
    
             
     document.getElementById('btnSave').focus();
     
     
        document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
       
        var rolecode = ds.Tables[0].Rows[0].VAR_CODE;
        var caserolecode=rolecode.toUpperCase();
        var rolename=repalcesinglequote(trim($('txtRoleName').value));
        var caserolename="'"+rolename .toUpperCase()+"'";
        var levelcode= "'"+document.getElementById('ddlLevels').value+"'";
             
       if ($('drpfreezflag').value=="0")
         {
         var frz="'N'";
         }
       else
         {
         var frz= "'"+document.getElementById('drpfreezflag').value+"'";
         }
    
        var finalval= compcode+"$~$"+unitcode+"$~$"+"'"+caserolecode +"'"+"$~$"+caserolename +"$~$"+levelcode+"$~$"+frz+"$~$"+uid  ;
        var fi=document.getElementById('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"")
        var result=Cir_roleMaster.save_role(fi,finalval,tablename,insert,"","","")
        if(result.value=="True")
        {
        $('txtRoleCode').value=caserolecode ; 
        alert(alrtSaved  +caserolecode);
        
        blankfields();
       
        $('txtcompcode').disabled = true;
        $('txtcompname').disabled = true;
        $('txtRoleCode').disabled = true;
        $('txtRoleName').disabled = true;
        $('ddlLevels').disabled = true;
        $('ddlLevels').value=0;
        $('drpfreezflag').disabled = true;
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
        }
       
     }

}

function trim(stringToTrim) 
 {
    //return this.replace(/^\s+|\s+$/g, "");

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

//////////////////////////////////////////////clear work//////////////////////////////////////////////////////////

function ClearAll()
{
dsexe="";
        next=0;
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
        
        
        document.getElementById('txtcompcode').disabled= true;
        document.getElementById('txtcompname').disabled= true;
        document.getElementById('txtRoleCode').disabled= true;
        document.getElementById('txtRoleName').disabled= true;
        document.getElementById('ddlLevels').disabled =true;
        document.getElementById('drpfreezflag').disabled= true;
    
        document.getElementById('Button4').disabled= true;
         $('Button4').style.display = 'none';
         $('Td14').style.display = 'none';
          $('view19').style.display = 'none';
          $('prepage').style.display='none';
          $('nextpage').style.display='none';
          $('next1').style.display='none';
          modiflag=0;
          
          document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
          document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;

      if(document.getElementById('txtRoleCode').value!="")
      { 
      document.getElementById('txtRoleCode').value="";
      }
      if(document.getElementById('txtRoleName').value!="")
      { 
      document.getElementById('txtRoleName').value="";
      }
      if(document.getElementById('ddlLevels').value!="")
      { 
      document.getElementById('ddlLevels').value="0";
      }
      if(document.getElementById('drpfreezflag').value!="")
      { 
      document.getElementById('drpfreezflag').value="0";
      }
    //  new_button();
           return false;
   }
   
   /////////////////////////////////////////////////exit work///////////////////////////////////////////////////////



 
function Exit()
{
       if(confirm(alrtExit ))
       {
         window.close();
         return false;
       }
   return false;
   
}


//////////////////////////////////////query work/////////////////////////////////////////////////////////////////

function EnabledOnQuery()
{

dsexe="";
        next=0;
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
      
        
        document.getElementById('txtcompcode').disabled = true;
        document.getElementById('txtcompname').disabled = true;
        document.getElementById('txtRoleCode').disabled = false;
        document.getElementById('txtRoleName').disabled = false;
        document.getElementById('ddlLevels').disabled = false;    
        document.getElementById('drpfreezflag').disabled = false;
        
        document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
        
        
        document.getElementById('btnExecute').focus();
        $('button4').disabled=true;
      $('Td14').style.display = 'none';
        $('view19').style.display = 'none';
        $('prepage').style.display = 'none';
        $('nextpage').style.display = 'none';
        $('next1').style.display='none';
        
         

      if(document.getElementById('txtRoleCode').value!="")
      { 
      document.getElementById('txtRoleCode').value="";
      }
      if(document.getElementById('txtRoleName').value!="")
      { 
      document.getElementById('txtRoleName').value="";
      }
      document.getElementById('ddlLevels').value="0";
     if(document.getElementById('drpfreezflag').value!="")
      { 
      document.getElementById('drpfreezflag').value="0";
      } 
    // new_button("Query");
     return false;
} 


////////////////////////////////////////////////EXECUTE WORK////////////////////////////////////////////////////
  
    
function EnableExecute()
{
     // var newnext = next;

        next=0;
//        if(document.getElementById("hdn_user_right").value=="3" || document.getElementById("hdn_user_right").value=="5" || document.getElementById("hdn_user_right").value=="6" || document.getElementById("hdn_user_right").value=="7")
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
        $('btnlast').disabled = false;
        $('btnModify').disabled = false;
        $('btnprevious').disabled = true;
        $('btnnext').disabled = false;
       // $('btnDelete').disabled = false;
        
        $('txtcompcode').disabled = true;
        $('txtcompname').disabled = true;
        $('txtRoleCode').disabled = true;
        $('txtRoleName').disabled = true;
       
        $('ddlLevels').disabled = true;
        $('drpfreezflag').disabled = true;
        $('btnModify').focus();
        
        document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
        
        
        document.getElementById('Button4').disabled= false;
        
        $('Button4').style.display ='block';
        var compcode = "'"+document.getElementById('txtcompcode').value+"'";
         var unitCode="'"+document.getElementById ('hdnunit').value+"'";
        var unit=$('hdnunit').value;
        var str = $('executefields').value;
        var str1=str.split("$~$");
        var tablename = str1[str1.length-2];
        var action = str1[str1.length-1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];
        
        rolecodeexe  = "'"+document.getElementById('txtRoleCode').value+"'";
        var caserolecodeexe=rolecodeexe.toUpperCase();
        
        rolenameexe  = "'"+repalcesinglequote(trim($('txtRoleName').value))+"'";
        var caserolenameexe=rolenameexe.toUpperCase();
        
        var levelcodeexe="'"+document .getElementById ('ddlLevels').value+"'";
       
        if ($('drpfreezflag').value=="0")
         {
         frzexe="''";
         }
         else
         {
         frzexe= "'"+document.getElementById('drpfreezflag').value+"'";
         }
        
        
        if($('ddlLevels').value=="0")
        {
        levelcodeexe="''";
        }
        else
        {
        levelcodeexe= "'"+$('ddlLevels').value+"'";
        }
         var colname="";
         colname=str.replace("$~$"+action,"")
         var ficolname=colname.replace("$~$"+tablename,"")
         ficolname=ficolname
        
         var fi=$('executefields').value.replace("$~$"+tablename,"");
         fi=fi.replace("$~$"+action,"");
         ficolname=fi+"$~$";
        var finalval = compcode+"$~$"+unitCode+"$~$"+caserolecodeexe+"$~$"+caserolenameexe+"$~$"+levelcodeexe+"$~$"+frzexe+"$~$"; 
        Cir_roleMaster.role_execute(tablename,ficolname,finalval,select,"","","",callback_exec)
       
}

     var stcd="";

	function callback_exec(res)
	{
	
	record_show=5
    record_show1=1
	next=0;
    dsexe=res.value;
   //if 
    if(dsexe.Tables[0].Rows.length==1)
    
    {       
    if(dsexe.Tables[0].Rows[next].ROLE_CODE==null)
	{
	$('txtRoleCode').value="";
    }
	else
	{
	$('txtRoleCode').value=dsexe.Tables[0].Rows[next].ROLE_CODE
    }


	if(dsexe.Tables[0].Rows[next].ROLE_DESC==null)
	{
	$('txtRoleName').value="";
    }
	else
	{
	$('txtRoleName').value=repalcestr2quote(dsexe.Tables[0].Rows[next].ROLE_DESC)
    }
    
    if(dsexe.Tables[0].Rows[next].FREEZE_FLAG==null)
	{	
	$('drpfreezflag').value="";  
    }
	else
	{
	$('drpfreezflag').value=dsexe.Tables[0].Rows[next].FREEZE_FLAG   
    }
    
    if(dsexe.Tables[0].Rows[next].LEVEL_CODE==null)
	{	
	$('ddlLevels').value="";  
    }
	else
	{
	$('ddlLevels').value=dsexe.Tables[0].Rows[next].LEVEL_CODE   
    }
    
    $('btnfirst').disabled = true;
	$('btnlast').disabled = true;
	$('btnprevious').disabled = true;
	$('btnnext').disabled = true;
	$('next1').displayed=true;
    
    }
    
    else if(dsexe.Tables[0].Rows.length>0)
    {       
     if(dsexe.Tables[0].Rows[next].ROLE_CODE==null)
	{
	$('txtRoleCode').value="";
    }
	else
	{
	$('txtRoleCode').value=dsexe.Tables[0].Rows[next].ROLE_CODE
    }


	if(dsexe.Tables[0].Rows[next].ROLE_DESC==null)
	{
	$('txtRoleName').value="";
    }
	else
	{
	$('txtRoleName').value=repalcestr2quote(dsexe.Tables[0].Rows[next].ROLE_DESC)
    }
    if(dsexe.Tables[0].Rows[next].FREEZE_FLAG==null)
	{	
	$('drpfreezflag').value="";  
    }
	else
	{
	$('drpfreezflag').value=dsexe.Tables[0].Rows[next].FREEZE_FLAG   
    }
    
    if(dsexe.Tables[0].Rows[next].LEVEL_CODE==null)
	{	
	$('ddlLevels').value="";  
    }
	else
	{
	$('ddlLevels').value=dsexe.Tables[0].Rows[next].LEVEL_CODE   
    }
    
    return false;
	}
	  
	else
	{
	alert(alrtNoData )
	$('btnfirst').disabled = true;
	$('btnlast').disabled = true;
	$('btnprevious').disabled = true;
	$('btnnext').disabled = true;
	$('next1').disabled=true;
	ClearAll();
	return false;
	}
}

var modifyduplicacydesc;
var modifyduplicacyalias;

function Modify_Records()
{
   modiflag=1;
    
//        $('btnNew').disabled = true;
//        $('btnQuery').disabled = true;
//        $('btnCancel').disabled = false;
//        $('btnExit').disabled = false;
        $('btnSave').disabled = false;
//        $('btnExecute').disabled = true;
//        $('btnfirst').disabled = true;
        $('btnlast').disabled = true;
        $('btnModify').disabled = true;
        $('btnprevious').disabled = true;
        $('btnnext').disabled = true;
       // $('btnDelete').disabled = true;
//        $('prepage').style.display ='none';
//        $('nextpage').style.display ='none';
//        $('next1').style.display ='none';
//        $('Td14').style.display = 'none';
//        $('view19').style.display = 'none';
        $('button4').disabled=true;
        document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
        document.getElementById('txtRoleCode').disabled = true;
        document.getElementById('txtRoleName').disabled = false;
        document.getElementById('drpfreezflag').disabled = false;
        document.getElementById('ddlLevels').disabled = false;
        
          //modifyduplicacydesc=$('txtregname').value;
       // modifyduplicacyalias=$('txtregalias').value;
      // $('txtregname').focus();
        $('btnSave').focus();
         //  new_button("Modify")
         
   return false;
}


/////////////////////////////////////////////modify class///////////////////////////////////////////////////////

function ModifyClass()
{
modiflag=1;
var str = $('tblfields').value;
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
var modcolname="";
var modtblname=str3[str3.length-1];
modcolname=str2.replace("$~$"+modtblname,"")
modcolname=str2+"$~$";

 
 var compcode = "'"+trim($('hdncompcode').value)+"'";
 var uid="'"+trim($('hdnuserid').value)+"'";
 var unitcode="'"+$('hdnunit').value+"'";
 if(trim($('txtRoleName').value)=="")
     {
     alert(alrtrolename)
     $('txtRoleName').focus();
     return false;
     }
     
     if($('ddlLevels').value=="0")
        {
        alert(alrtlevel );
        $('ddlLevels').focus();
        return false;
        }
        
     if ($('drpfreezflag').value=="0")
     {
     var frz="'N'";
     }
     else
     {
     var frz= "'"+document.getElementById('drpfreezflag').value+"'";
     }

     var rolecode = "'"+trim($('txtRoleCode').value)+"'";
     var caserolecode=rolecode.toUpperCase();
 
   
  
     
     var nma=trim($('txtRoleName').value);
                                    
                                                
     if(nma==unicodespl)
     {
     }
     else if(nma=="false" && splitsign==1)
     {
     alert('You cannot Insert Special character or "$~$"')
     $('txtRoleName').focus();
     splitsign=0;
     return false;
     }
    
     else if(nma=="false" && sql_inject==1)
     {
     alert('You cannot Insert the KEYWORDS "SELECT,MODIFY,UPDATE,DELETE"')
     $('txtRoleName').focus();
     sql_inject=0;
     return false;
     }
    
     else if(nma=="false" && greatersign==1)
     {
     alert('You cannot Insert Special character or "< and >"')
     $('txtRoleName').focus();
     greatersign=0;
     return false;
     }
     else if(nma==true)
     {
     return "";
     }
//     else
//     {
//     return false;
//     }
      
                      
   var rolename =repalcesinglequote(trim($('txtRoleName').value));
                                                       
  
   
     var caserolename="'"+rolename.toUpperCase()+"'";
     
     var levelcode = "'"+trim($('ddlLevels').value)+"'";
    
     var finalval = compcode+"$~$"+unitcode +"$~$"+caserolecode+"$~$"+caserolename+"$~$"+levelcode+"$~$"+frz+"$~$"+uid+"$~$"; 
    
    var fi=$('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"");
        fi = fi+"$~$";

    var wherecondition=rolecode+"$~$"+compcode+"$~$"+unitcode ;


    
    var result=Cir_roleMaster.role_modify(fi, finalval,tablename,update,modcolname,"","","")
     if(result .value=="True")
     {
         alert(alrtModify)
         modiflag="";
         blankfields();
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
             return false ;
      }
}
////////////////////////////////////////////delete work/////////////////////////////////////////////////////////



 function Delete_Record()
{
$('Td14').style.display = 'none';
       $('view19').style.display = 'none';
       $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
       document.getElementById('Button4').disabled= true;


document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
var str = $('tblfields').value;
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
delcolname =str2+"$~$";
       
       
        
        var compcode = "'"+document.getElementById('hdncompcode').value+"'";
        var uid = "'"+document.getElementById('hdnuserid').value+"'";
        var unitcode="'"+document .getElementById ('hdnunit').value+"'";
        var roleocde = "'"+trim($('txtRoleCode').value)+"'";
        var roleName = "'"+trim($('txtRoleName').value)+"'";
        var frz = "'"+trim($('drpfreezflag').value)+"'";
        var levelcode = "'"+trim($('ddlLevels').value)+"'";
        var fi=$('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"");
        fi=fi+"$~$";
        
        var finalval = compcode+"$~$"+unitcode +"$~$"+roleocde+"$~$"+roleName  +"$~$"+levelcode+"$~$"+frz+"$~$"+uid+"$~$"; 
        
        
        var delcolvalue=roleocde +"$~$"+compcode+"$~$"+unitcode +"$~$";
        
        
        boolReturn = confirm("Are you sure! You want to delete this entry.");
   
       if (boolReturn==1)
       {
        Cir_roleMaster.role_delete(tablename,delcolname,delcolvalue,del,"","","");
       
       alert(alrtDelete)
       blankfields ();
       modiflag =0;
       
       return false;

 
 
//         var str = $('executefields').value;
//        var str1=str.split("$~$");
//        var tablename = str1[str1.length-2];
//       
//        var action = str1[str1.length-1];
//        var finalaction = action.split("#");
//        var insert = finalaction[0];
//        var update = finalaction[1];
//        var del = finalaction[2];
//        var select = finalaction[3];
//        

//        var compcode = "'"+document.getElementById('hdncompcode').value+"'";
//        var uid = "'"+document.getElementById('hdnuserid').value+"'";
//        
//        var rolecode = rolecodeexe ;
//        var caserolecode=rolecode .toUpperCase();
//        
//        var rolename = rolenameexe ;
//        var caserolename=rolename .toUpperCase();
//        var frz = frzexe ;
//       // var zone=levelcode ;
//     
//        
//        var colname="";
//        colname=str.replace("$~$"+action,"")
//        var ficolname=colname.replace("$~$"+tablename,"")
//        ficolname=ficolname
//        
//        var fi=$('executefields').value.replace("$~$"+tablename,"")
//        fi=fi.replace("$~$"+action,"");
//        fi=fi+"$~$";
//        
//        var finalval = compcode+"$~$"+unitcode +"$~$"+caserolecode +"$~$"+caserolename +"$~$"+levelcode +"$~$"+frz+"$~$"; 
//        
//        Cir_roleMaster.role_execute(tablename,ficolname,finalval,select,"","","",callback_delete)
//        
        
	
		}
		else
		{
		  // $('btnModify').focus();
		  //blankfields();
		  $('btnDelete').focus();
		}
    
 

   
   return false;
}



/////////////////////////////////////callback delete work/////////////////////////////////////////////////////////

//function callback_delete(response)
//{
//next;
//  dsexe = response.value;
//  var length_del = dsexe.Tables[0].Rows.length;
//  var a=length_del-1;
//  
//   
//  if(length_del<=0)
//      {
//         alert("No more data.");
//         ClearAll();
//         return false;
//        
//      }
//      
// 
//      
//      
//   else if(next==-1 || next>= length_del)
//      {
//          document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
//          document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
//          document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[0].ROLE_CODE;
//          document.getElementById('txtRoleName').value= dsexe.Tables[0].Rows[0].ROLE_DESC;
//          document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[0].FREEZE_FLAG;
//          document.getElementById('ddlLevels').value= dsexe.Tables[0].Rows[0].LEVEL_CODE;
//         
//      
//     //$('btnModify').focus();
//    
//          
//          
//                    
//          
//          if(next==length_del)
//          {
//                     document.getElementById('btnnext').disabled = false;
//                     document.getElementById('btnlast').disabled = false;
//                     document.getElementById('btnfirst').disabled=true;
//                     document.getElementById('btnprevious').disabled=true;
//                     next=0;
//                     
//                  
//          return false;
//          }
//          
//           next=0;
//                    
//          return false;
//       }
//          
//          
//  else if ( next==length_del-1)
//  {
//           document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
//          document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
//          document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[0].ROLE_CODE;
//          document.getElementById('txtRoleName').value= dsexe.Tables[0].Rows[0].ROLE_DESC;
//          document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[0].FREEZE_FLAG;
//          document.getElementById('ddlLevels').value= dsexe.Tables[0].Rows[0].LEVEL_CODE;
//                     document.getElementById('btnnext').disabled = true;
//                     document.getElementById('btnlast').disabled = true;
//                     document.getElementById('btnfirst').disabled=false;
//                     document.getElementById('btnprevious').disabled=false;
//                     
//                //$('btnModify').focus();
//                blankfields ();
//          
//  }
//  else
//  {
//         document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
//          document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
//          document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[0].ROLE_CODE;
//          document.getElementById('txtRoleName').value= dsexe.Tables[0].Rows[0].ROLE_DESC;
//          document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[0].FREEZE_FLAG;
//          document.getElementById('ddlLevels').value= dsexe.Tables[0].Rows[0].LEVEL_CODE;
////$('btnModify').focus();
//blankfields ();
//  }
//      
// return false;
//     

//}


///////////////////////////////////////////////////next work///////////////////////////////////////////////////
 
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
			
			
			   
			      document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[next].ROLE_CODE;
                  document.getElementById('txtRoleName').value= repalcestr2quote(dsexe.Tables[0].Rows[next].ROLE_DESC);
                 
                if(dsexe.Tables[0].Rows[next].LEVEL_CODE=="")
                {
                document.getElementById('ddlLevels').value=0;
                }
                else
                {
                document.getElementById('ddlLevels').value= dsexe.Tables[0].Rows[next].LEVEL_CODE;
                }
                  
                  document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
                 
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
        document.getElementById('btnDelete').disabled = false;
       
       
       document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
       
         document.getElementById('txtRoleCode').disabled = true;
        document.getElementById('txtRoleName').disabled = true;
       document.getElementById('ddlLevels').disabled = true;
       document.getElementById('drpfreezflag').disabled = true;
       
        
        document.getElementById('Button4').disabled= false;
        
        
        $('Td14').style.display = 'none';
       $('view19').style.display = 'none';
       $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
             
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
        document.getElementById('btnDelete').disabled = false;
        
         document.getElementById('txtRoleCode').disabled = true;
        document.getElementById('txtRoleName').disabled = true;
        document.getElementById('ddlLevels').disabled = true;
        document.getElementById('drpfreezflag').disabled = true;
          $('btnprevious').focus();
                  
     }
     //new_button("Records");
   return false;
   
}

//////////////////////////////////Previous button//////////////////////////////////

function Find_PreRecord()
{
record_show=5
    record_show1=1
   next--;
   
    var record= dsexe.Tables[0].Rows.length;
     if(next>record)
		{
				document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=false;
				document.getElementById('Button4').disabled= false;
				
				$('Td14').style.display = 'none';
                $('view19').style.display = 'none';
                $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
				
				return false;
				
		}
     
     
     if(next!=-1 && next>=0)
     
		{
		if(dsexe.Tables[0].Rows.length != next)
		{
			     document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
        document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
			      document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[next].ROLE_CODE;
                  document.getElementById('txtRoleName').value= repalcestr2quote(dsexe.Tables[0].Rows[next].ROLE_DESC);
                
                   
                  if(dsexe.Tables[0].Rows[next].LEVEL_CODE==null)
	            {
	            $('ddlLevels').value=0;
                }
	            else
	            {
	            $('ddlLevels').value=dsexe.Tables[0].Rows[next].LEVEL_CODE
                }          
                  document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
                 

                  document.getElementById('btnnext').disabled = false;
                  document.getElementById('btnprevious').disabled=false;
                  document.getElementById('btnlast').disabled=false;  
                  document.getElementById('Button4').disabled= false;
                  
      $('Td14').style.display = 'none';
       $('view19').style.display = 'none';
       $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
			}
     }
     if (next==0)
     {
          document.getElementById('btnfirst').disabled = true;
           document.getElementById('btnprevious').disabled = true;
           document.getElementById('btnlast').disabled=false;
           document.getElementById('Button4').disabled= false;
            $('btnnext').focus();
           $('Td14').style.display = 'none';
       $('view19').style.display = 'none';
       $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
     }
     
      
   return false;
   
}

function Find_Firstrecord()
{

record_show=5
record_show1=1
next=0;
          
          document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
          document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
          document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[next].ROLE_CODE;
          
                if(dsexe.Tables[0].Rows[next].LEVEL_CODE==null)
	            {
	            $('ddlLevels').value="";
                }
	            else
	            {
	            $('ddlLevels').value=dsexe.Tables[0].Rows[next].LEVEL_CODE
                }
                
          document.getElementById('txtRoleName').value= dsexe.Tables[0].Rows[next].REG_DESC;
          document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
          document.getElementById('btnnext').disabled = false;
          document.getElementById('btnfirst').disabled = true;
          document.getElementById('btnprevious').disabled = true;
          document.getElementById('btnlast').disabled=false;
          document.getElementById('Button4').disabled= false;
          
          $('Td14').style.display = 'none';
          $('view19').style.display = 'none';
          $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
         $('btnnext').focus();
          
          
          return false;
}


function Find_Lastrecord()
{

record_show=5
    record_show1=1
    var record=dsexe.Tables[0].Rows.length;
		 next=record-1;
		 record=record-1;
          document.getElementById('txtcompcode').value=document.getElementById('hdncompcode').value;
          document.getElementById('txtcompname').value=document.getElementById('hdncompname').value;
          document.getElementById('txtRoleCode').value = dsexe.Tables[0].Rows[next].ROLE_CODE;
          document.getElementById('txtRoleName').value= repalcestr2quote(dsexe.Tables[0].Rows[next].ROLE_DESC);
          
          if(dsexe.Tables[0].Rows[next].LEVEL_CODE==null)
	            {
	            $('ddlLevels').value=0;
                }
	            else
	            {
	            $('ddlLevels').value=dsexe.Tables[0].Rows[next].LEVEL_CODE
                }
               
     
        document.getElementById('drpfreezflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = true;
   
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('Button4').disabled= false;
        
        
        $('Td14').style.display = 'none';
        $('view19').style.display = 'none';
        $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
         $('btnprevious').focus();



}


var record_show_j=1
var record_show_i=0
////////////////////////////////////////////paging///////////////////////////////////////////////////////////////

function fetchview()
{
     
     $('Td14').style.display ='block';
     $('view19').style.display ='block';
       $('prepage').style.display ='block';
     $('nextpage').style.display ='block';
      $('next1').style.display ='block';
      
      
Cir_roleMaster.role_allviews($('hdncompcode').value,$('hdnunit').value,"","","",callback_allview)
document.getElementById('Button4').disabled= true;

}

////////////////////////////////////////callback view///////////////////////////////////////////////////////////////////



var srt_count=1
var record_show1=1
var record_show=5	
var record_show1_other1=4;
var record_show_other=4;
var extra_record_other=0;
var divres=""; 
var check =true;


function callback_allview(res)
{
    if(check==true)
    {
    var srt_count=0
    var record_show1=1
    var record_show=3

        if(res.value!=undefined)
        {
        ds18=res.value;
        }
        else
        {
        ds18=res;
        }
    check =false;

    }
    else
    {
    var srt_count=0
    var record_show1=1
    var record_show=3	
    ds18="";

        if(res.value!=undefined)
        {
        ds18=res.value;
        }
        else
        {
        ds18=res;
        }
    }

row_count=ds18.Tables[0].Rows.length;
var valnextval=2
pagenext(valnextval);


//ds18=res.value;
var hdsview="";
var j=1
var i=0

                            


    if(ds18!=null && ds18.Tables[0].Rows.length > 0)
    {    
                     
                for( srt_count;srt_count<=record_show;srt_count++)
                {
                     hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                     hdsview+="<tr>"
                     hdsview+="<td width='30px' style='border:1px solid #7DAAE3;padding-left:5px;' align='left'>"
                     hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:middle;padding-top:4px;padding-right:5px;padding-left:5px;padding-bottom:2px;' >"+j;"</font>"
                     hdsview+="</td>"
                     
                     var ds_view_name=ds18.Tables[0].Rows[srt_count].ROLE_CODE
			         if(ds_view_name!="null")
		             {
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;' align='left'>"
                     hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].ROLE_CODE+"</font>"
                     hdsview+="</td>"
                     }
                     
                      var ds_views_str=ds18.Tables[0].Rows[srt_count].ROLE_DESC
			         if(ds_views_str!="null")
		             {
		             var role_name=repalcestr2quote(ds18.Tables[0].Rows[srt_count].ROLE_DESC.substring(0,10))
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                     hdsview+="<font class='gridview' title='"+ds18.Tables[0].Rows[srt_count].ROLE_DESC+"'>"+role_name+"</font>"
                     hdsview+="</td>"
                     }
                      
                        var ds_views_str=ds18.Tables[0].Rows[srt_count].LEVEL_CODE
			         if(ds_views_str!="null")
		             {
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                     hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].LEVEL_CODE+"</font>"
                     hdsview+="</td>"
                     }
                        j++                                  
                  }
                     
                     hdsview+="</tr>"
                     hdsview+="</table>"
                     //document.getElementById('tstank').value=hdsview
        			
        			 $('view19').innerHTML=hdsview;  
			         //j++
			         
			         //return false;
                 
        } 
		else
         {
			
			 hdsview+="<table width='755px;'>"
             hdsview+="<tr>"
             hdsview+="<td width='700px'>"
             hdsview+="<font Style='font-family:arial;font-weight:bold;font-size:18px;'>You have no detail </font></strong>"
             hdsview+="</td>"
    		 hdsview+="</tr>"
             hdsview+="</table>"
             hdsview =hdsview+ "<BR>"
			 $('view19').innerHTML=hdsview;
			    
			 return false;
        }  
}

////////////////////////////////////////////OK////////////////////////////////////////////////////////////////////
var srt_count=1
var record_show1=1
//var record_show=3	
var record_show1_other1=4;
var record_show_other=4;
var extra_record_other=0;
var divres=""; 


var srt_count_0ther=1;
function pagenext(valnext)
{
  var nextPageNumberColor=true
 divres=row_count/4;
    if(divres.valueOf(".")>="0")
    {
    divres=divres+1;
    }
    else
    {
    divres;
    }
  
var hdspage;

var aa="";
if((parseInt(record_show1)*4)-4>=row_count)
{
   // alert("End Of record")
    return false;
}
else
{
$('next1').innerHTML="";
for(srt_count=record_show1;srt_count<record_show;srt_count++)
{
    if(srt_count<divres)
    {
  
   if(srt_count==1 || nextPageNumberColor==true)
   {
    $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColorChange'  id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>"
   nextPageNumberColor=false;
   pagenumber(srt_count,this.id)
   }
   else
   {
    $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColor'  id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>"
  
   } 
     aa="aa";
    }
    else
    {
    
    aa="";
    
    //return false;
    }

}
if(aa!="")
{


record_show1=record_show; 
preval=record_show1-4
record_show=record_show1+4;
nextPageNumberColor=true;


}
else
{
record_show1=record_show; 
preval=record_show1-4
record_show=record_show1+4;
//return false;
}

}
}

//var pagenumberfirst=true;

			
function pageprev(valpre)
{
var bb="";
var hdspage;
var dfg="0"
var End_pnt="0"


if(preval<=4)
{
dfg=1

End_pnt=5
}
else
{
dfg=preval-4;
End_pnt=dfg+4;

}

if(preval<=4)
{
return false;
}
else
{
$('next1').innerHTML="";
for(srt_count=dfg;srt_count<End_pnt;srt_count++)
{
    if(srt_count!=0 )
    {
        if(srt_count!=End_pnt-1)
        {
        $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColor' id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>";
       bb="bb";
      
        }
        else
        {
        $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColorChange' id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>";
        bb="bb";
        pagenumber(srt_count,this.id)
        }
     
    }
    else
    {
    bb="";
    break;
    }
}
    if(bb!="")
    {
    record_show=record_show1
    record_show1=record_show-4
    }
    preval=preval-4
}
}





function pagenumber(valnextvalue,hdsg)
{
hdsharma=hdsg

if(hdsg!=undefined)
{
while(document.getElementById('next1').innerHTML.indexOf('paggingColorChange')>0)
{
document.getElementById('next1').innerHTML=document.getElementById('next1').innerHTML.replace('paggingColorChange','paggingColor');
}
document.getElementById(hdsg).className='paggingColorChange';
}

var flag="IN";

	            var flags="pre";
	             forlen_other=valnextvalue;
	             
	             extra_record_other = row_count%4;
	             var finalval=(forlen_other*record_show_other)-extra_record_other;
	             hdsview="";
	                
	                if(finalval!=row_count && extra_record_other!=0 && extra_record_other!=1)
	                {
	                    for(srt_count_0ther=(forlen_other*record_show_other)-record_show_other;srt_count_0ther<(forlen_other*record_show_other);srt_count_0ther++)
	                    {
	                        if(row_count!=srt_count_0ther)
	                        {
                     hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                     hdsview+="<tr>"
                    
                     var srt_count_0ther_sr= parseInt(srt_count_0ther)+1      
                             
                             
                     hdsview+="<td width='30px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                     hdsview+="<font class='gridview'>"+srt_count_0ther_sr+"</font>"
                     hdsview+="</td>"
                     
                        
                     var ds_view_code=ds18.Tables[0].Rows[srt_count_0ther].ROLE_CODE
                      if(ds_view_code!="null")
                      {
                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].ROLE_CODE+"</font>"
                             hdsview+="</td>"
                      }              
                      
                      var ds_view_SSRcode=ds18.Tables[0].Rows[srt_count_0ther].ROLE_DESC
                      if(ds_view_SSRcode!="null")
                       {        
                                 var role_name=repalcestr2quote(ds18.Tables[0].Rows[srt_count_0ther].ROLE_DESC.substring(0,10))
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                 hdsview+="<font class='gridview' title='"+ds18.Tables[0].Rows[srt_count_0ther].ROLE_DESC+"'>"+role_name+"</font>"
                                 hdsview+="</td>"
                       }  
                           
                       var ds_view_SSRcode=ds18.Tables[0].Rows[srt_count_0ther].LEVEL_CODE
                      if(ds_view_SSRcode!="null")
                       {
                                            if(ds18.Tables[0].Rows[srt_count_0ther].LEVEL_CODE==null)
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                             hdsview+="<font class='gridview'>"+""+"</font>"
                                             hdsview+="</td>"
                                             }
                                             else
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].LEVEL_CODE+"</font>"
                                             hdsview+="</td>"
                                             }
                       }  
                      
                                        
                    hdsview+="</table>"
                    hdsview+="</tr>"
                    $('view19').innerHTML=hdsview;
                    srt_count_0ther_sr++
                    }  
    	                }
    	            }
    	            else if(finalval == row_count)
	                {
	                    for(srt=(forlen_other*record_show_other)-record_show_other;srt<row_count;srt++)
                        {
	                       
	                    var srt_count_0ther_sr= parseInt(srt)+1      
                     
                         hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                         hdsview+="<tr>"
                
                             hdsview+="<td width='30px' style='border:1px solid #7DAAE3;text-align:left; padding-left:5px;'>"
                             hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:middle;'>"+srt_count_0ther_sr+"</font>"
                             hdsview+="</td>"
                
                     var ds_view_code=ds18.Tables[0].Rows[srt].ROLE_CODE
                         if(ds_view_code!="null")
                         {
                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].ROLE_CODE+"</font>"
                             hdsview+="</td>"
                          }              
                          
                     var ds_view_SSRcode=ds18.Tables[0].Rows[srt].ROLE_DESC
                      if(ds_view_SSRcode!="null")
                       {
                                 var role_name=repalcestr2quote(ds18.Tables[0].Rows[srt].ROLE_DESC.substring(0,10))
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                 hdsview+="<font class='gridview' title='"+ds18.Tables[0].Rows[srt].ROLE_DESC+"'>"+role_name+"</font>"
                                 hdsview+="</td>"
                       } 
                       
                      
                      var ds_view_SRcode=ds18.Tables[0].Rows[srt].LEVEL_CODE
                      if(ds_view_SRcode!="null")
                       {
                       if(ds18.Tables[0].Rows[srt].LEVEL_CODE==null)
                       {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                             hdsview+="<font class='gridview'>"+""+"</font>"
                                            
                                             hdsview+="</td>"
                       }
                       else
                         {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].LEVEL_CODE+"</font>"
                                 hdsview+="</td>"
                       }
                       } 
                      
                     
                            hdsview+="</table>"
                            hdsview+="</tr>"
    	                    $('view19').innerHTML=hdsview;
                            srt_count_0ther_sr++
                        }
                    
                    }
                    else
                    {
                    //((forlen_other*record_show_other)*record_show_other)
                   var finalval_other=finalval-extra_record_other;
                        if(flag=="IN")
                        {
                        for(srt=(forlen_other*record_show_other)-record_show_other;srt<(forlen_other*record_show_other);srt++)
                        {
                        if(srt!=row_count)
                        {
                        if(srt>row_count)
                        {
                        return false;
                        }
                         hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                         hdsview+="<tr>"
                             
                             var srt_count_0ther_sr= parseInt(srt)+1       
                            
                             hdsview+="<td width='30px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                             hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:middle;'>"+srt_count_0ther_sr+"</font>"
                             hdsview+="</td>"
                            
                     var ds_view_code=ds18.Tables[0].Rows[srt].ROLE_CODE
                     if(ds_view_code!="null")
                     {
                         hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                         hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].ROLE_CODE+"</font>"
                         hdsview+="</td>"
                      } 
                      
                      var ds_view_SSRcode=ds18.Tables[0].Rows[srt].ROLE_DESC
                      if(ds_view_SSRcode!="null")
                       {
                                 var role_name=repalcestr2quote(ds18.Tables[0].Rows[srt].ROLE_DESC.substring(0,10))
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                 hdsview+="<font class='gridview' title='"+ds18.Tables[0].Rows[srt].ROLE_DESC+"'>"+role_name+"</font>"
                                 hdsview+="</td>"
                       } 
                       
                      var ds_view_SSRcode=ds18.Tables[0].Rows[srt].LEVEL_CODE
                      if(ds_view_SSRcode!="null")
                       {
                                            if(ds18.Tables[0].Rows[srt].LEVEL_CODE==null)
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                             hdsview+="<font class='gridview'>"+""+"</font>"
                                             hdsview+="</td>"
                                             }
                                             
                                             else
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].LEVEL_CODE+"</font>"
                                             hdsview+="</td>"
                                             }
                       } 
                           
                     
                          hdsview+="</table>"
                          hdsview+="</tr>"
    	                  $('view19').innerHTML=hdsview;
                          srt_count_0ther_sr++  
    	                } 
    	                 }
                        }
                        flag="OUT";
                    }
}	



function chkfld(a)
{
if(a.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
if( a.keyCode=="13")
{
  
      if(document.activeElement.id=="btnNew")
          {
                if( a.keyCode=="13")
                  {
                  Enableonnew();
                  return false;
                  } 
     }
     
     
   else if(document.activeElement.id=="btnQuery")
      
       {
       
                   if( a.keyCode=="13")
                       {
                       EnabledOnQuery();
                       return false;
                       } 
            
    
       }      
else if(document.activeElement.id=="btnModify")
      
       {
       
                   if( a.keyCode=="13")
                       {
                       Modify_Records();
                       return false;
                       } 
            
    
       }     
else if(a.keyCode=="13" && document.activeElement.id=="txtRoleCode" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
     {
                   if($('txtRoleCode').value=="" || $('txtRoleCode').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('txtRoleName').focus();
                                          return false;
                                         }
                     }
    }
    
    
else if(a.keyCode=="13" && document.activeElement.id=="txtRoleName" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                
      
                    if($('txtRoleName').value=="")
                    {
                        if( a.keyCode=="13")
                         {
                          $('ddlLevels').focus();
                          return false;
                         }
                    }
              } 
              
   
               else if(a.keyCode=="13" && document.activeElement.id=="ddlLevels" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                
      
                    if($('ddlLevels').value=="0" || $('ddlLevels').value!="0"  )
                    {
                        if( a.keyCode=="13")
                         {
                          $('drpfreezflag').focus();
                          return false;
                         }
                    }
                } 
                 else if(a.keyCode=="13" && document.activeElement.id=="drpfreezflag" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                
      
                    if($('drpfreezflag').value=="0" || $('drpfreezflag').value!="0"  )
                    {
                        if( a.keyCode=="13")
                         {
                          $('btnExecute').focus();
                          return false;
                         }
                    }
                } 
                 else if(a.keyCode=="13" && document.activeElement.id=="ddlLevels" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                
      
                    if($('ddlLevels').value=="0" || $('ddlLevels').value!="0"  )
                    {
                        if( a.keyCode=="13")
                         {
                          $('drpfreezflag').focus();
                          return false;
                         }
                    }
                } 
    
     
else if((a.keyCode=="13"||a.keyCode=="9") && document.activeElement.id=="txtRoleName" && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                
                          
               
                
                    if(trim($('txtRoleName').value)=="")
                    {
                        alert(alrtrolename )
                        $('txtRoleName').focus();                 
                        return false;
                    }
                    else
                    {
                        $('ddlLevels').focus();
                        return false;
                    }
              } 
              
              
else if(a.keyCode=="13" && document.activeElement.id=="ddlLevels")
    {
                   if($('ddlLevels').value=="0")
                   {
                                    
                     
                        alert(alrtlevel )
                        $('ddlLevels').focus();
                        $('ddlLevels').select();
                        return false;
                     } 
                    else
                    {
                        $('drpfreezflag').focus();
                        return false;
                    }
                   }
   
     
     

     
     

   
    else if(a.keyCode=="13"  && document.activeElement.id=="drpfreezflag"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
                   if($('drpfreezflag').value=="" || $('drpfreezflag').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('btnsave').focus();
                                          return false;
                                         }
                   }
     } 
else if(a.keyCode=="13" && document.activeElement.id=="drpfreezflag"  && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
                   if($('drpfreezflag').value=="" || $('drpfreezflag').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('btnExecute').focus();
                                          return false;
                                         }
                   }
     }     
              
   
else if (document.activeElement.id=="btnSave")
                    {
                    generatecode();
                    return false;
                    }                
   


     
    
else if(a.keyCode=="13" && document.activeElement.id=="btnExecute")
                                {
                                EnableExecute();
                                return false;
                                }

     
          }                                      
          

}




