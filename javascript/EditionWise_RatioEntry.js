// JScript File
var browser = navigator.appName;    


var gleditionname="";
var gdsexecute;
var rowN=0;
var hiddentext;
var chkeditionname="";
var totalpercent="0";
function onpage_load()
{
    if( document.getElementById("btnNew").disabled ==false)
        document.getElementById("btnNew").focus();
     document.getElementById("drpedition").value="0";
     document.getElementById("drpedition").disabled=true;
     document.getElementById("tblgrid").disabled=true;
     document.getElementById("tblbutton").disabled=true;
   
     document.getElementById("tblbutton").style.display="block";
     document.getElementById("tblgrid").style.display="block";
     
     var tableToSort=document.getElementById("tblgrid");
     if(browser!="Microsoft Internet Explorer")
     {
     document.getElementById("btnok").disabled=true;
      newRow = tableToSort.insertRow(-1);
      newRow.className ="dtGridrate";
          newCell = newRow.insertCell(0);
          newCell.align="center";
          newCell.innerHTML = "";
          newCell.style.display="none";
          
          newCell = newRow.insertCell(1);
          newCell.align="center";
          newCell.innerHTML = "Edition Name";
          
          newCell = newRow.insertCell(2);
          newCell.align="center";
          newCell.innerHTML = "Publication";
          
          newCell = newRow.insertCell(3);
          newCell.align="center";
          newCell.innerHTML = "Edition Code";
          
          newCell = newRow.insertCell(4);
          newCell.align="center";
          newCell.innerHTML = "Percentage (%)";
          
          newCell = newRow.insertCell(5);
          newCell.align="center";
          newCell.innerHTML = "Effective Date";
          
          var rowlength=document.getElementById("tblgrid").rows.length;
         
          newRow = tableToSort.insertRow(rowlength);
        
          newCell = newRow.insertCell(0);
          newCell.style.display="none";
          var element1 = document.createElement("input");
          element1.type = "checkbox";
          newCell.appendChild(element1);

          newCell = newRow.insertCell(1);
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='20' disabled=true   class=btextsmallsize1  >";
          newCell = newRow.insertCell(2);
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='20' disabled=true  class=btextsmallsize  >";
          newCell = newRow.insertCell(3);
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='20' disabled=true  class=btextsmallsize  >";
          newCell = newRow.insertCell(4);
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5' disabled=true  class=btextsmallsize onkeypress=\"return rateenter(event);\" >"; // 
          newCell = newRow.insertCell(5);
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='10' disabled=true  class=btextsmallsize  OnBlur=\"return checkdate(this);\">";
       return false;
         
     }
     else
     {
     
      newRow = tableToSort.insertRow();

  
     //alert(newRow)
 
       //------ Dynamic TABLE  heading-----//
          newRow.className ="dtGridrate";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "";
          newCell.style.display="none";
          
          newCell = newRow.insertCell();
          newCell.align="center";
         
          newCell.innerHTML = "Edition Name";
          
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Publication";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Edition Code";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Percentage (%)";
          
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Effective Date";
          newRow = tableToSort.insertRow();
          
          newCell = newRow.insertCell();
          newCell.style.display="none";
          var element1 = document.createElement("input");
          element1.type = "checkbox";
          newCell.appendChild(element1);

          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='20' disabled=true  class=btextsmallsize1  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='20' disabled=true class=btextsmallsize  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='20' disabled=true class=btextsmallsize  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5' disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\" >"; // 
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='10' disabled=true class=btextsmallsize  OnBlur=\"return checkdate(this);\">";
      
           return false;   
        }
           
}


function newclick()
{
  clearclick();
  hiddentext="new";
if(browser!="Microsoft Internet Explorer")
 {
    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
        document.getElementById("tblgrid").disabled=false;
        document.getElementById("btnok").disabled=false;
        document.getElementById("tblgrid").rows[i].cells[1].children[0].disabled=false;
        document.getElementById("tblgrid").rows[i].cells[2].children[0].disabled=false;
        document.getElementById("tblgrid").rows[i].cells[3].children[0].disabled=false;
        document.getElementById("tblgrid").rows[i].cells[4].children[0].disabled=false;
        document.getElementById("tblgrid").rows[i].cells[5].children[0].disabled=false;
    }
 }
else
{
   for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
    //alert(parseInt(document.getElementById("tblgrid").rows.length))
    //alert(document.getElementById("tblgrid").rows(i).cells(1).disabled);
 
        document.getElementById("tblgrid").disabled=false;
        document.getElementById("tblgrid").rows(i).cells(1).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(2).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(3).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(4).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(5).children[0].disabled=false;
        
    }
}

  document.getElementById("drpedition").disabled=false;
  document.getElementById("tblgrid").disabled=false;
  document.getElementById("tblbutton").disabled=false;
   document.getElementById("drpedition").focus();
   
  chkstatus(FlagStatus);	
  
  setButtonImages();
  return false;
  
}

function clearclick()
{
  hiddentext="clear";
  deleteid="";
  chkstatus(FlagStatus);	
  givebuttonpermission("EditionWise_RatioEntry");
  totalpercent="0";
  hiddentext="";
   var Parent = document.getElementById("tblgrid");
   while(Parent.hasChildNodes())
   {
     Parent.removeChild(Parent.lastChild);
   }
   
   document.getElementById("drpedition").value="0";
   onpage_load();
 setButtonImages();
  return false;
}

function queryclick()
{
   clearclick();
   hiddentext="query";
   deleteid="";
   totalpercent="0";
   chkstatus(FlagStatus);
   document.getElementById('btnQuery').disabled=true;
   document.getElementById('btnExecute').disabled=false;
   document.getElementById('btnSave').disabled=true;
   document.getElementById('btnExecute').focus();
  
   document.getElementById("tblgrid").disabled=false;
   document.getElementById("drpedition").value="0";
   document.getElementById("drpedition").disabled=false;
   document.getElementById("tblbutton").disabled=true;
   rowN=0;
   setButtonImages();
   return false;
}


function modifyclick()
{
    deleteid="";
    chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true; 
    document.getElementById('btnExecute').disabled=true;
   
    document.getElementById("tblbutton").disabled=false; 
    chkeditionname= document.getElementById("drpedition").value;
    hiddentext="modify";
  
    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
    if(browser!="Microsoft Internet Explorer")
 {
    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
        document.getElementById("tblgrid").disabled=false;
        document.getElementById("tblgrid").rows[i].cells[1].children[0].disabled=true;
        document.getElementById("tblgrid").rows[i].cells[2].children[0].disabled=true;
        document.getElementById("tblgrid").rows[i].cells[3].children[0].disabled=true;
        document.getElementById("tblgrid").rows[i].cells[4].children[0].disabled=false;
        document.getElementById("tblgrid").rows[i].cells[5].children[0].disabled=false;
    }
 }
 else
 {
        document.getElementById("tblgrid").disabled=false;
        document.getElementById("tblgrid").rows(i).cells(1).children[0].disabled=true;
        document.getElementById("tblgrid").rows(i).cells(2).children[0].disabled=true;
        document.getElementById("tblgrid").rows(i).cells(3).children[0].disabled=true;
        document.getElementById("tblgrid").rows(i).cells(4).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(5).children[0].disabled=false;
 }
}
    setButtonImages();
    return false;
}



function BindSubEdition()
{
    var compcode = document.getElementById("hiddencompcode").value;
   // document.getElementById("drpmainedilist").options[document.getElementById("drpmainedilist").selectedIndex].innerText;
    var edi=document.getElementById("drpedition");
    if(browser != "Microsoft Internet Explorer")
    {
    var editioncode = edi.options[edi.selectedIndex].textContent;
    }
    else
    {
    var editioncode = edi.options[edi.selectedIndex].innerText;
    }
   
    var res=EditionWise_RatioEntry.GetSubEdition(compcode,editioncode);
    var ds=res.value;
    if(ds==null)
    {
        alert(res.error.description);
        return false;
    }
    if(ds.Tables[0].Rows.length >0)
    {
    if(browser != "Microsoft Internet Explorer")
    
    {
        document.getElementById("tblgrid").rows[1].cells[1].children[0].value=ds.Tables[0].Rows[0].Edition_Alias;
        document.getElementById("tblgrid").rows[1].cells[2].children[0].value=ds.Tables[0].Rows[0].Pub_Code;
        document.getElementById("tblgrid").rows[1].cells[3].children[0].value=ds.Tables[0].Rows[0].Edition_Code;
        document.getElementById("tblgrid").rows[1].cells[4].children[0].value="";
        document.getElementById("tblgrid").rows[1].cells[5].children[0].value="";
    }
    else
    {
        document.getElementById("tblgrid").rows(1).cells(1).children[0].value=ds.Tables[0].Rows[0].Edition_Alias;
        document.getElementById("tblgrid").rows(1).cells(2).children[0].value=ds.Tables[0].Rows[0].Pub_Code;
        document.getElementById("tblgrid").rows(1).cells(3).children[0].value=ds.Tables[0].Rows[0].Edition_Code;
        document.getElementById("tblgrid").rows(1).cells(4).children[0].value="";
        document.getElementById("tblgrid").rows(1).cells(5).children[0].value="";
    }
   }
     if(ds.Tables[0].Rows.length >1)
    {
        for(i=1;i<ds.Tables[0].Rows.length;i++)
        {
         if(browser!="Microsoft Internet Explorer")
        {
        
             var tableToSort=document.getElementById("tblgrid");
              newRow = tableToSort.insertRow(-1);
              
              newCell = newRow.insertCell(0);
              newCell.style.display="none";
              var element1 = document.createElement("input");
              element1.type = "checkbox";
              newCell.appendChild(element1);

              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text  class=btextsmallsize1 value='"+ds.Tables[0].Rows[i].Edition_Alias+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text  class=btextsmallsize value='"+ds.Tables[0].Rows[i].Pub_Code+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize value='"+ds.Tables[0].Rows[i].Edition_Code+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize value='' onkeypress=\"return rateenter(event);\" >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize value=''  OnBlur=\"return checkdate(this);\">";
       }  
        
        
        else
        {
              var tableToSort=document.getElementById("tblgrid");
              newRow = tableToSort.insertRow();
              
              newCell = newRow.insertCell();
              newCell.style.display="none";
              var element1 = document.createElement("input");
              element1.type = "checkbox";
              newCell.appendChild(element1);

              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text  class=btextsmallsize1 value='"+ds.Tables[0].Rows[i].Edition_Alias+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text  class=btextsmallsize value='"+ds.Tables[0].Rows[i].Pub_Code+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize value='"+ds.Tables[0].Rows[i].Edition_Code+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize value='' onkeypress=\"return rateenter(event);\" >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize value=''  OnBlur=\"return checkdate(this);\">";
       }  
        }
    }
    return false;
}

function checkedition()
{
    var compcode = document.getElementById("hiddencompcode").value;
    var editioncode=document.getElementById("drpedition").value;
    if(hiddentext=="query")
    {
    }
    else
    {
    var chk_res=EditionWise_RatioEntry.checkduplicateEdition(editioncode,compcode);
    if(chk_res.value== null)
    {
        alert("ERROR : \n"+responce.error.description);
        return false;
    }
    else
    {
       var ds1=chk_res.value;
       if(ds1.Tables[0].Rows.length>0)
       {
         alert("This Edition is already assigned.");
         return false;
       }
    }
    }
}


function saveclick()
{
    
    var compcode = document.getElementById("hiddencompcode").value;
    var userid=document.getElementById("hiddenuserid").value;
    var dateformat=document.getElementById("hiddendateformat").value;
    
    var maineditioncode=document.getElementById("drpedition").value;
    var lbeditionname= document.getElementById("lbleditionname").innerHTML;
    var  totalpercent=0;
    
    if((document.getElementById("drpedition").value =="0") && (lbeditionname.indexOf("*") >=0))
    {
      alert("Please Enter Editon Name." );
      document.getElementById("drpedition").focus();
      return false;
    }
   
    if(parseInt(document.getElementById("tblgrid").rows.length) == 1)
    {
        alert(parseInt(document.getElementById("tblgrid").rows.length))
       alert("Please Enter Detail for Ist Row." );
       return false;
    }
   
      for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
      {
          alert(parseInt(document.getElementById("tblgrid").rows.length))
      if(browser!= "Microsoft Internet Explorer")
      {
     
            var subeditionname =  trim(document.getElementById("tblgrid").rows[i].cells[1].children[0].value);
           
            var pubcode =   trim(document.getElementById("tblgrid").rows[i].cells[2].children[0].value);
            var subeditioncode   =   trim(document.getElementById("tblgrid").rows[i].cells[3].children[0].value);
            var percentage   =   trim(document.getElementById("tblgrid").rows[i].cells[4].children[0].value);
            var effectivedate   =   trim(document.getElementById("tblgrid").rows[i].cells[5].children[0].value);
           
      
      }
      else
      {
      
            var subeditionname =  trim(document.getElementById("tblgrid").rows(i).cells(1).children[0].value);
            var pubcode =   trim(document.getElementById("tblgrid").rows(i).cells(2).children[0].value);
            var subeditioncode   =   trim(document.getElementById("tblgrid").rows(i).cells(3).children[0].value);
            var percentage   =   trim(document.getElementById("tblgrid").rows(i).cells(4).children[0].value);
             var effectivedate   =   trim(document.getElementById("tblgrid").rows(i).cells(5).children[0].value);
      }
            if(subeditionname=="")
            {
                alert("Please Enter Edition for "+i+" Row");
                return false;
            }
            if(pubcode=="")
            {
                alert("Please Enter Publication for "+i+" Row");
                return false;
            }
            if(subeditioncode=="")
            {
                alert("Please Enter Edition Code for "+i+" Row");
                return false;
            }
             if(percentage=="")
            {
                alert("Please Enter Percentage for "+i+" Row");
                return false;
            }
            if(effectivedate =="")
            {
               alert("Please Enter Effective Date for "+i+" Row");
                return false;
            }
           
            totalpercent=parseInt(totalpercent)+parseInt(percentage);
           
         } 
         
         if(parseInt(totalpercent,10) >100)
         {
               alert("Total Percentage cannot be greater than 100.");
                return false;
         }
        if(hiddentext != "modify") 
       {
          var flag="0";
      
          for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
          {
          
           if(browser!= "Microsoft Internet Explorer")
      {
            var subeditionname =  trim(document.getElementById("tblgrid").rows[i].cells[1].children[0].value);
            
            var pubcode =   trim(document.getElementById("tblgrid").rows[i].cells[2].children[0].value);
            var subeditioncode   =   trim(document.getElementById("tblgrid").rows[i].cells[3].children[0].value);
            var percentage   =   trim(document.getElementById("tblgrid").rows[i].cells[4].children[0].value);
            var effectivedate   =   trim(document.getElementById("tblgrid").rows[i].cells[5].children[0].value);
      
      }
      else
      {
      
            var subeditionname =  trim(document.getElementById("tblgrid").rows(i).cells(1).children[0].value);
            var pubcode =   trim(document.getElementById("tblgrid").rows(i).cells(2).children[0].value);
            var subeditioncode   =   trim(document.getElementById("tblgrid").rows(i).cells(3).children[0].value);
            var percentage   =   trim(document.getElementById("tblgrid").rows(i).cells(4).children[0].value);
            var effectivedate   =   trim(document.getElementById("tblgrid").rows(i).cells(5).children[0].value);
      }
          
            EditionWise_RatioEntry.saveeditionratio(compcode, userid, maineditioncode, subeditionname, pubcode, subeditioncode, percentage, effectivedate,dateformat);
          }
        
          alert("Data Saved Successfully.");
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
         
          clearclick();
          return false;
        
    } 
    else  // in case of modify
    {
        var flag="1";
        for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
          {
            if(browser!= "Microsoft Internet Explorer")
      {
            var subeditionname =  trim(document.getElementById("tblgrid").rows[i].cells[1].children[0].value);
            
            var pubcode =   trim(document.getElementById("tblgrid").rows[i].cells[2].children[0].value);
            var subeditioncode   =   trim(document.getElementById("tblgrid").rows[i].cells[3].children[0].value);
            var percentage   =   trim(document.getElementById("tblgrid").rows[i].cells[4].children[0].value);
            var effectivedate   =   trim(document.getElementById("tblgrid").rows[i].cells[5].children[0].value);
      
      }
      else
      {
      
            var subeditionname =  trim(document.getElementById("tblgrid").rows(i).cells(1).children[0].value);
            var pubcode =   trim(document.getElementById("tblgrid").rows(i).cells(2).children[0].value);
            var subeditioncode   =   trim(document.getElementById("tblgrid").rows(i).cells(3).children[0].value);
            var percentage   =   trim(document.getElementById("tblgrid").rows(i).cells(4).children[0].value);
            var effectivedate   =   trim(document.getElementById("tblgrid").rows(i).cells(5).children[0].value);
      }
         
           
             EditionWise_RatioEntry.updateeditionratio(compcode, userid,  subeditioncode, maineditioncode, percentage, effectivedate,dateformat);
               
         }
            
       
        
         alert("Data Updated Successfully.");

         for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
       {
         if(browser != "Microsoft Internet Explorer")
         {
            document.getElementById("tblgrid").disabled=false;
            document.getElementById("tblgrid").rows[i].cells[1].children[0].disabled=true;
            document.getElementById("tblgrid").rows[i].cells[2].children[0].disabled=true;
            document.getElementById("tblgrid").rows[i].cells[3].children[0].disabled=true;
            document.getElementById("tblgrid").rows[i].cells[4].children[0].disabled=true;
            document.getElementById("tblgrid").rows[i].cells[5].children[0].disabled=true;
         }
         else
         {
            document.getElementById("tblgrid").disabled=true;
            document.getElementById("tblgrid").rows(i).cells(1).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(2).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(3).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(4).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(5).children[0].disabled=true;
         }
        }
         updateStatus();
         document.getElementById("tblbutton").disabled=true;
         var x=gdsexecute.Tables[0].Rows.length;
         y=z;	
         if (z==0)
         {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
         }
  
         if(z==(gdsexecute.Tables[0].Rows.length-1))
         {
            document.getElementById('btnNext').disabled=true;
            document.getElementById('btnLast').disabled=true;
         }
          rowN=0;
          setButtonImages();
          return false;         
    } 
}


function executeclick()
{
  
    var compcode = document.getElementById("hiddencompcode").value;
    var editioncode = document.getElementById("drpedition").value;
    gleditionname=editioncode;
    var res1=EditionWise_RatioEntry.exeditionratio(editioncode,compcode);
    executeclick_call(res1);
    
    rowN=0;

	if(document.getElementById('btnModify').disabled==false)					
	   document.getElementById('btnModify').focus();
	   
    return false;
}

function executeclick_call(responce)
{
    if(responce.error!=null)
    {
        alert("ERROR : \n"+responce.error.description);
        return false;
    }
    gdsexecute=responce.value;
    if(gdsexecute!=null)
    {
        if(gdsexecute.Tables[0].Rows.length>0)
        {
            bindctrls();
        }
        else
        {
            alert("Your Search Produces No Result");
            clearclick();
            return false;
        }
    }
    
    updateStatus();
    
    if(gdsexecute.Tables[0].Rows.length==1)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
    }
    else
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    setButtonImages();
}


function bindctrls()
{
    var dateformat=document.getElementById("hiddendateformat").value;
    var res=EditionWise_RatioEntry.executegrid(gdsexecute.Tables[0].Rows[rowN].edition_code,document.getElementById('hiddencompcode').value,dateformat);
    var ds=res.value;
    if(ds==null)
    {
        alert(res.error.description);
        return false;
    }
      var rowlength=ds.Tables[0].Rows.length;
    if(ds.Tables[0].Rows.length >0)
    {
            
        document.getElementById("drpedition").value=ds.Tables[0].Rows[0].editioncode;
        if(browser!="Microsoft Internet Explorer")
        {
        
        document.getElementById("tblgrid").rows[1].cells[1].children[0].value=ds.Tables[0].Rows[0].subedition;
        document.getElementById("tblgrid").rows[1].cells[2].children[0].value=ds.Tables[0].Rows[0].pubcode;
        document.getElementById("tblgrid").rows[1].cells[3].children[0].value=ds.Tables[0].Rows[0].subeditioncode;
        document.getElementById("tblgrid").rows[1].cells[4].children[0].value=ds.Tables[0].Rows[0].per;
        document.getElementById("tblgrid").rows[1].cells[5].children[0].value=ds.Tables[0].Rows[0].effectivedate;
        document.getElementById("drpedition").disabled=true;
        document.getElementById("tblgrid").rows[1].cells[1].children[0].disabled=true;
        document.getElementById("tblgrid").rows[1].cells[2].children[0].disabled=true;
        document.getElementById("tblgrid").rows[1].cells[3].children[0].disabled=true;
        document.getElementById("tblgrid").rows[1].cells[4].children[0].disabled=true;
        document.getElementById("tblgrid").rows[1].cells[5].children[0].disabled=true;
         
        }
        else
        {
        
        document.getElementById("tblgrid").rows(1).cells(1).children[0].value=ds.Tables[0].Rows[0].subedition;
        document.getElementById("tblgrid").rows(1).cells(2).children[0].value=ds.Tables[0].Rows[0].pubcode;
        document.getElementById("tblgrid").rows(1).cells(3).children[0].value=ds.Tables[0].Rows[0].subeditioncode;
        document.getElementById("tblgrid").rows(1).cells(4).children[0].value=ds.Tables[0].Rows[0].per;
        document.getElementById("tblgrid").rows(1).cells(5).children[0].value=ds.Tables[0].Rows[0].effectivedate;
      
       
        document.getElementById("drpedition").disabled=true;
        document.getElementById("tblgrid").rows(1).cells(1).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(2).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(3).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(4).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(5).children[0].disabled=true;
        }
        
    }
    if(ds.Tables[0].Rows.length >1)
    {
            for(i=1;i<ds.Tables[0].Rows.length;i++)
            {
            
             if(browser!="Microsoft Internet Explorer")
        {
        
              var tableToSort=document.getElementById("tblgrid");
              newRow = tableToSort.insertRow(-1);
              
              newCell = newRow.insertCell(0);
              newCell.style.display="none";
              var element1 = document.createElement("input");
              element1.type = "checkbox";
              newCell.appendChild(element1);

              newCell = newRow.insertCell(1);
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled   class=btextsmallsize1 value='"+ds.Tables[0].Rows[i].subedition+"' >";
              newCell = newRow.insertCell(2);
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled   class=btextsmallsize value='"+ds.Tables[0].Rows[i].pubcode+"' >";
              newCell = newRow.insertCell(3);
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled   class=btextsmallsize value='"+ds.Tables[0].Rows[i].subeditioncode+"'>";
              newCell = newRow.insertCell(4);
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled  class=btextsmallsize value='"+ds.Tables[0].Rows[i].per+"' onkeypress=\"return rateenter(event);\">";
              newCell = newRow.insertCell(5);
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled' class=btextsmallsize value='"+ds.Tables[0].Rows[i].effectivedate+"' OnBlur=\"return checkdate(this);\">";
            
        
        }
        else
        {
           
              var tableToSort=document.getElementById("tblgrid");
              newRow = tableToSort.insertRow();
              
              newCell = newRow.insertCell();
              newCell.style.display="none";
              var element1 = document.createElement("input");
              element1.type = "checkbox";
              newCell.appendChild(element1);

              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled   class=btextsmallsize1 value='"+ds.Tables[0].Rows[i].subedition+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled   class=btextsmallsize value='"+ds.Tables[0].Rows[i].pubcode+"' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled   class=btextsmallsize value='"+ds.Tables[0].Rows[i].subeditioncode+"'>";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled  class=btextsmallsize value='"+ds.Tables[0].Rows[i].per+"' onkeypress=\"return rateenter(event);\">";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled' class=btextsmallsize value='"+ds.Tables[0].Rows[i].effectivedate+"' OnBlur=\"return checkdate(this);\">";
       } 
            }
    }

     document.getElementById("tblgrid").disabled=true;
     document.getElementById("tblbutton").disabled=true; 
  
}

function firstclick()
{
    var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN=0;
    
    document.getElementById("btnfirst").disabled=true;
    document.getElementById("btnprevious").disabled=true;
    document.getElementById("btnnext").disabled=false;
    document.getElementById("btnlast").disabled=false;
    
    bindctrls();
   setButtonImages();
    return false;
}

function prevclick()
{
     var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN--;
    if(rowN<=0)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
        rowN=0;
    }
    else
    {
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    bindctrls();
    setButtonImages();
    return false;
}

function nextclick()
{
     var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN++;
    if(rowN>=gdsexecute.Tables[0].Rows.length-1)
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
        rowN=gdsexecute.Tables[0].Rows.length-1;
    }
    else
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
    }
    bindctrls();
    setButtonImages();
    return false;
}

function lastclick()
{
    var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN=gdsexecute.Tables[0].Rows.length-1;
    
    document.getElementById("btnfirst").disabled=false;
    document.getElementById("btnprevious").disabled=false;
    document.getElementById("btnnext").disabled=true;
    document.getElementById("btnlast").disabled=true;
    
    bindctrls();
   setButtonImages();
    return false;
}

function deleteclick()
{
  if(confirm('Are you sure you want to delete?'))
  {
     var compcode = document.getElementById("hiddencompcode").value;
     var editioncode=document.getElementById("drpedition").value;
      
     EditionWise_RatioEntry.editiondelete(editioncode, compcode);
      alert("Data Deleted Successfully");
       var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
      
    EditionWise_RatioEntry.exeditionratio(gleditionname,compcode,call_deletededicode);
    // executeclick_call(res1);
  }
  return false;
}


function call_deletededicode(response)
{
    gdsexecute=response.value;
 	var a=gdsexecute.Tables[0].Rows.length;
 	
	var y=a-1;
	
	if( gdsexecute.Tables[0].Rows.length==0 )
	{
	    alert("There Is No Data In The Database");
	   	clearclick();
	}
	else if(rowN==-1 ||rowN>a)
	{
	   bindctrls();
      return false;
	}
	else
	{
	  rowN=0;  
	  bindctrls();
	  
	}
	setButtonImages();
}

function exitclick()
{
    if(confirm("Do you want to skip this page."))
    {
       window.close();
       return false;
    }
  return false;
}


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