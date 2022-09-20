var dDate1;
var dDate2;
var browser=navigator.appName;
var innertablehtml=new Array();
var innertablehtml1=new Array();
var activeIDNo;
function onpage_load(h)
{
var txtbussinessdate1="";
var txtbussinessdate12="";
var dateformat=document.getElementById('hiddateformate').value;
        if(dateformat=="dd/mm/yyyy")
			{
                if(document.getElementById('txtfrom').value!="")
                {
	                var txt1=document.getElementById('txtfrom').value;
	                var txt2=txt1.split("/");
	                var dd=txt2[0];
	                var mm=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate1=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate1=document.getElementById('txtfrom').value;
	            }
    			
	        }
            if(dateformat=="mm/dd/yyyy")
            {
	                txtbussinessdate1=document.getElementById('txtfrom').value;
	        }
            if(dateformat=="yyyy/mm/dd")
            {
	            if(document.getElementById('txtfrom').value!="")
	            {
	                var txt1=document.getElementById('txtfrom').value;
	                var txt2=txt1.split("/");
	                var yy=txt2[0];
	                var mm=txt2[1];
	                var dd=txt2[2];
	                txtbussinessdate1=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate1=document.getElementById('txtfrom').value;
	            }
			}
        if(dateformat=="dd/mm/yyyy")
			{
                if(document.getElementById('txtto').value!="")
                {
	                var txt1=document.getElementById('txtto').value;
	                var txt2=txt1.split("/");
	                var dd=txt2[0];
	                var mm=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate12=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate12=document.getElementById('txtto').value;
	            }
    			
	        }
            if(dateformat=="mm/dd/yyyy")
            {
	                txtbussinessdate12=document.getElementById('txtto').value;
	        }
            if(dateformat=="yyyy/mm/dd")
            {
	            if(document.getElementById('txtto').value!="")
	            {
	                var txt1=document.getElementById('txtto').value;
	                var txt2=txt1.split("/");
	                var yy=txt2[0];
	                var mm=txt2[1];
	                var dd=txt2[2];
	                txtbussinessdate12=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate12=document.getElementById('txtto').value;
	            }
			}					
  if(document.getElementById('txtfrom').value==""|| document.getElementById('txtto').value=="")
    {
      alert("please fill Date firest")
      return false;
    }
if(document.activeElement.type=="text" || document.activeElement.type==undefined )
return false;

        if(document.getElementById("tblgrid"+h).style.display=="none")
        {
                if(innertablehtml.length==0)
                    innertablehtml[h]="";
                if(innertablehtml1.length==0)
                    innertablehtml1[h]="";
         if(innertablehtml[h]==""  || innertablehtml[h]==undefined)
          {
          var chanel=document.getElementById("root"+h).value.split('(');
          var chanelcode=chanel[0];
          var locationcode=chanel[1].replace(')','');
             document.getElementById("tblgrid"+h).style.display="block";
             var tableToSort=document.getElementById("tblgrid"+h);
             newRow = tableToSort.insertRow();
         
               //------ Dynamic TABLE  heading-----//
                  newRow.className ="dtGridrate_tv";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "Tape Id";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "BTB CD";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "UOM";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "From Bnd Cd";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "To Bnd Cd";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "Program";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "Adv Type";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "Paid";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "Ad Category";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "chanel";
                  newCell.style.display="none";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "location";
                  newCell.style.display="none";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "ROSTIME";
                  newCell.style.display="none";
                  
                  
                  
                  dDate1=new Date(txtbussinessdate1);
                  dDate2=new Date(txtbussinessdate12) ;
                        newCell = newRow.insertCell();
                        newCell.align="center";
                        newCell.innerHTML = dDate1.getDate();
                        newCell.title = (dDate1.getMonth()+1)+"/"+dDate1.getDate()+"/"+dDate1.getFullYear();
                  dDatebetween=new Date(dDate1.getTime()+86400000);
                    var nBox=1
                    while (dDatebetween<=dDate2)
                    {
                        newCell = newRow.insertCell();
                        newCell.align="center";
                        newCell.innerHTML = dDatebetween.getDate();
                        newCell.title = (dDatebetween.getMonth()+1)+"/"+dDatebetween.getDate()+"/"+dDatebetween.getFullYear();;
                        nBox++
                        dDatebetween=new Date(dDatebetween.getTime()+86400000)
                    }
                  
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "Total";
                  
                  //newCell.style.display="none";
                  newRow = tableToSort.insertRow();
                  
                  //newCell = newRow.insertCell();
        //          var element1 = document.createElement("input");
        //          element1.type = "checkbox";
        //          newCell.appendChild(element1);

                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b  >";//document.getElementById("txtfrminsert").value;
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b   >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b   >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b   >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >"; // 
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text class=btextsmallsize1_b value=" + chanelcode + " >";
                  newCell.style.display="none";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text  class=btextsmallsize1_b value=" + locationcode + ">";
                  newCell.style.display="none";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text  class=btextsmallsize1_b >";
                  newCell.style.display="none";
                  
                  dDate1=new Date(txtbussinessdate1);
                  dDate2=new Date(txtbussinessdate12) ;
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML ="<input type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c Onchange=\"return adtotal(this.parentNode.parentNode,event,"+h+");\">";
                  dDatebetween=new Date(dDate1.getTime()+86400000);
                    var nBox=1
                    while (dDatebetween<dDate2)
                    {
                        newCell = newRow.insertCell();
                        newCell.align="center";
                        newCell.innerHTML = "<input type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c Onchange=\"return adtotal(this.parentNode.parentNode,event,"+h+");\">";
                        nBox++
                        dDatebetween=new Date(dDatebetween.getTime()+86400000)
                    }
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c Onchange=\"return adtotal(this.parentNode.parentNode,event,"+h+");\"  >";//OnChange=\"return adrow("+h+");\"
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input disabled  type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c  >";
                  
                  ////second table////
                  document.getElementById("tblgrid1"+h).style.display="block";
                  var tableToSort=document.getElementById("tblgrid1"+h);
                  newRow = tableToSort.insertRow();
                  
                  dDate1=new Date(txtbussinessdate1);
                  dDate2=new Date(txtbussinessdate12) ;
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML ="<input disabled type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c >";
                  dDatebetween=new Date(dDate1.getTime()+86400000);
                    var nBox=1
                    while (dDatebetween<dDate2)
                    {
                        newCell = newRow.insertCell();
                        newCell.align="center";
                        newCell.innerHTML = "<input disabled type=text onkeypress=\"return ClientisNumber(event);\" class=btextsmallsize1_c >";
                        nBox++
                        dDatebetween=new Date(dDatebetween.getTime()+86400000)
                    }
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input disabled type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c >";
                  newCell = newRow.insertCell();
                  newCell.align="center";
                  newCell.innerHTML = "<input disabled type=text style='width:27px' onkeypress=\"return ClientisNumber(event);\" class=btextsmallsize1_c  >";
         }
         else 
            {    
               document.getElementById("tblgrid"+h).style.display="block";
               document.getElementById("tblgrid1"+h).style.display="block";
                //document.getElementById("tblgrid"+h).innerHTML;//=innertablehtml[h]; 
                //document.getElementById("tblgrid1"+h).innerHTML;//=innertablehtml1[h]; 
            }
            
   }
   else
   {
        innertablehtml[h]=document.getElementById("tblgrid"+h).innerHTML;
        document.getElementById("tblgrid"+h).style.display="none";
        innertablehtml1[h]=document.getElementById("tblgrid1"+h).innerHTML;
        document.getElementById("tblgrid1"+h).style.display="none";
   }
     return false;  
}
function adrow(h)
{
if(confirm("Do You Want increase the row ?"))
{
        var chanel=document.getElementById("root"+h).value.split('(');
        var chanelcode=chanel[0];
        var locationcode=chanel[1].replace(')','');
      var tableToSort=document.getElementById("tblgrid"+h);
      newRow = tableToSort.insertRow();
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  onkeyup=\"return f2query(event);\" class=btextsmallsize1_b  >";//document.getElementById("txtfrminsert").value;
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  onkeyup=\"return f2query(event);\"  class=btextsmallsize1_b  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  onkeyup=\"return f2query(event);\"  class=btextsmallsize1_b  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  onkeyup=\"return f2query(event);\"  class=btextsmallsize1_b >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  onkeyup=\"return f2query(event);\"  class=btextsmallsize1_b >"; // 
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text onkeyup=\"return f2query(event);\" class=btextsmallsize1_b >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text class=btextsmallsize1_b value=" + chanelcode + " >";
          newCell.style.display="none";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  class=btextsmallsize1_b value=" + locationcode + " >";
          newCell.style.display="none";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  class=btextsmallsize1_b >";
          newCell.style.display="none";
          
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML ="<input type=text onkeypress=\"return ClientisNumber(event);\"  class=btextsmallsize1_c  Onchange=\"return adtotal(this.parentNode.parentNode,event,"+h+");\">";
          dDatebetween=new Date(dDate1.getTime()+86400000);
            var nBox=1
            while (dDatebetween<dDate2)
            {
                newCell = newRow.insertCell();
                newCell.align="center";
                newCell.innerHTML = "<input type=text onkeypress=\"return ClientisNumber(event);\" class=btextsmallsize1_c Onchange=\"return adtotal(this.parentNode.parentNode,event,"+h+");\">";
                nBox++
                dDatebetween=new Date(dDatebetween.getTime()+86400000)
            }
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text onkeypress=\"return ClientisNumber(event);\" class=btextsmallsize1_c Onchange=\"return adtotal(this.parentNode.parentNode,event,"+h+");\" >";//Onchange=\"return adrow("+h+");\"
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input disabled type=text onkeypress=\"return ClientisNumber(event);\" class=btextsmallsize1_c    >";
 }
          //return false;  
}

function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11)||(event.which==8))
     {

       return true;
     }
    else
     {
       return false;
     }
 }
 else
 {
   if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
   {

       return true;
   }
   else
   {
       return false;
   }
  }
}
 function adtotal(name,e,h)
 {
    var table = document.getElementById("tblgrid"+h);
    var rowCount = table.rows.length;
    var cellCount=name.cells.length
    var rowindex=parseInt(name.rowIndex);
    var cell=e.srcElement.parentNode.cellIndex;
    if(table.rows[rowindex].cells[0].childNodes[0].value=="")
    {
        alert("Please Select Tape ID");
        table.rows[rowindex].cells[cell+3].childNodes[0].value="";
        table.rows[rowindex].cells[0].childNodes[0].focus();
        return false;
    }
    if(table.rows[rowindex].cells[1].childNodes[0].value=="")
    {
        alert("Please Select BTB Code");
        table.rows[rowindex].cells[cell+3].childNodes[0].value="";
        table.rows[rowindex].cells[1].childNodes[0].focus();
        return false;
    }
    if(table.rows[rowindex].cells[2].childNodes[0].value=="")
    {
        alert("Please Select UOM");
        table.rows[rowindex].cells[cell+3].childNodes[0].value="";
        table.rows[rowindex].cells[2].childNodes[0].focus();
        return false;
    }
    if(table.rows[rowindex].cells[3].childNodes[0].value=="")
    {
        alert("Please Select From Time Band");
        table.rows[rowindex].cells[cell+3].childNodes[0].value="";
        table.rows[rowindex].cells[3].childNodes[0].focus();
        return false;
    }
    if(table.rows[rowindex].cells[4].childNodes[0].value=="")
    {
        alert("Please Select To Time Band");
        table.rows[rowindex].cells[cell+3].childNodes[0].value="";
        table.rows[rowindex].cells[4].childNodes[0].focus();
        return false;
    }
    if(table.rows[rowindex].cells[7].childNodes[0].value=="")
    {
        alert("Please Select Paid");
        table.rows[rowindex].cells[cell+3].childNodes[0].value="";
        table.rows[rowindex].cells[7].childNodes[0].focus();
        return false;
    }
    if(cell==cellCount-5 && rowCount-1==rowindex)
    {
        adrow(h);
    }
    var rowtot="";
    var rowtot1="";
    var rowtot11="";
    var rowtot12="";
    var rowtot111="";
    var rowtot121="";
    for(var i=12; i<cellCount-1; i++)
    {
    if(table.rows[rowindex].cells[i].childNodes[0].value=="")
        rowtot1=0;
        else
        rowtot1=parseInt(table.rows[rowindex].cells[i].childNodes[0].value)
     if(rowtot=="")
      {
        rowtot=rowtot1;
      }
      else
      rowtot=rowtot+rowtot1;
     
    }
    if(rowtot!=0)
    table.rows[rowindex].cells[i].childNodes[0].value=rowtot;
    ///////
    
    for(var j=1; j<rowCount; j++)
    {
        if(table.rows[j].cells[cell+3].childNodes[0].value=="")
        rowtot12=0;
        else
        rowtot12=parseInt(table.rows[j].cells[cell+3].childNodes[0].value)
     if(rowtot11=="")
      {
        rowtot11=rowtot12;
      }
      else
      rowtot11=rowtot11+rowtot12;
     
    }
    var table1 = document.getElementById("tblgrid1"+h);
    if(rowtot11!=0)
       table1.rows[0].cells[cell-9].childNodes[0].value=rowtot11;
    
    for(var j=1; j<rowCount; j++)
    {
        if(table.rows[j].cells[cellCount-1].childNodes[0].value=="")
        rowtot121=0;
        else
        rowtot121=parseInt(table.rows[j].cells[cellCount-1].childNodes[0].value)
     if(rowtot111=="")
      {
        rowtot111=rowtot121;
      }
      else
      rowtot111=rowtot111+rowtot121;
     
    }
    var table1 = document.getElementById("tblgrid1"+h);
    if(rowtot111!=0)
       table1.rows[0].cells[cellCount-13].childNodes[0].value=rowtot111;
       
     var tapid=  table.rows[rowindex].cells[0].childNodes[0].value;
     var btbcode=table.rows[rowindex].cells[1].childNodes[0].value;
     var ratetype=table.rows[rowindex].cells[2].childNodes[0].value;
     if(ratetype.indexOf("(")>0)
       ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));
     var frbtbcode=table.rows[rowindex].cells[3].childNodes[0].value;
     var tobtbcode=table.rows[rowindex].cells[4].childNodes[0].value;
     var prgid=table.rows[rowindex].cells[5].childNodes[0].value;
     if(prgid.indexOf("(")>0)
       prgid=prgid.substring(prgid.lastIndexOf('(')+1,prgid.lastIndexOf(')'));
     var adtype=table.rows[rowindex].cells[6].childNodes[0].value;
     if(adtype.indexOf("(")>0)
       adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
     var paidbonus=table.rows[rowindex].cells[7].childNodes[0].value;
     if(paidbonus.indexOf("(")>0)
       paidbonus=paidbonus.substring(paidbonus.lastIndexOf('(')+1,paidbonus.lastIndexOf(')'));
     var channel=table.rows[rowindex].cells[9].childNodes[0].value;
     var location=table.rows[rowindex].cells[10].childNodes[0].value;
     var dur="";//table.rows[rowindex].cells[10].childNodes[0].value;
     var airdate=table.rows[0].cells[cell+3].title;
     var noofspot=table.rows[rowindex].cells[cell+3].childNodes[0].value;
     var returndata="N";
     var fromdate=document.getElementById('txtfrom').value;
     var todate=document.getElementById('txtto').value;
     var dareformat=document.getElementById('hiddateformate').value;
     var category=table.rows[rowindex].cells[8].childNodes[0].value;
     if(category.indexOf("(")>0)
       category=category.substring(category.lastIndexOf('(')+1,category.lastIndexOf(')'));
       bookingschedule.getgrid(channel, location, adtype, airdate, document.getElementById('hiddendealco').value, btbcode, frbtbcode, tobtbcode, paidbonus, dur, tapid, prgid, noofspot, ratetype, returndata,'','',fromdate,todate,dareformat,category);
    //return false;
    
 }
 var element1;
 function fatchdata()
 {
   var fachdata=bookingschedule.getgrid('', '', '', '', '', '', '', '', '', '', '', '', '', '', "Y",'','','','','','');
   window.opener.document.getElementById("tblGridelecbook").outerHTML="<TABLE id=tblGridelecbook style=\"BORDER-COLLAPSE: collapse\" borderColor=#7daae5 width=1000 cellSpacing=0 cellPadding=0 border=1 name=\"tblGridelec\"><TBODY></TBODY><THEAD><TR bgColor=#7daae3><TD class=tdcls align=middle width=100>Channel</TD><TD class=tdcls align=middle width=100>Location</TD><TD class=tdcls align=middle width=100>Adv Type</TD><TD class=tdcls align=middle width=100>Rate Type(UOM)</TD><TD class=tdcls align=middle width=100>Schedule Date</TD><TD class=tdcls align=middle width=80>BTB</TD><TD class=tdcls align=middle width=100>From Band</TD><TD class=tdcls align=middle width=100>To Band</TD><TD class=tdcls align=middle width=80>Break</TD><TD class=tdcls align=middle width=100>Position</TD><TD class=tdcls align=middle width=80>Program</TD><TD class=tdcls align=middle width=100>Paid/ Bonus</TD><TD class=tdcls align=middle width=100>No Of Spot</TD><TD class=tdcls align=middle width=80>Tape Id</TD><TD class=tdcls align=middle width=100>Duration</TD><TD class=tdcls align=middle width=80>Rate</TD><TD class=tdcls align=middle width=100>Gross Amt</TD><TD class=tdcls align=middle width=100>InsertId</TD><TD class=tdcls align=middle width=100>Status</TD><TD class=tdcls align=middle width=100>Ad Category</TD></TR></THEAD><TBODY><TR><TD class=tdcls>0</TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD></TR></TBODY></TABLE>";
   window.opener.document.getElementById("div_electronicbook").style.display="block";
   element1 = window.opener.document.getElementById ('tblGridelecbook');
   var ds_tv=fachdata.value;
   if(ds_tv!=null)
   {
        if(ds_tv.Tables[0].Rows.length>0)
        {
           for(var i=0;i<ds_tv.Tables[0].Rows.length;i++)
             { 
               if(i>0)
                {
                  addRow('','','','','','','','','','','','','','','','','','','','');
                }
                if(ds_tv.Tables[0].Rows[i].CHANNEL!=null)
                    element1.rows[i+1].cells[0].innerHTML=ds_tv.Tables[0].Rows[i].CHANNEL;
                else
                    element1.rows[i+1].cells[0].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].LOCCD!=null)
                    element1.rows[i+1].cells[1].innerHTML=ds_tv.Tables[0].Rows[i].LOCCD;
                else
                    element1.rows[i+1].cells[1].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].AD_TYPE!=null)
                    element1.rows[i+1].cells[2].innerHTML=ds_tv.Tables[0].Rows[i].AD_TYPE;
                else
                    element1.rows[i+1].cells[2].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].RATE_TYPE!=null)
                    element1.rows[i+1].cells[3].innerHTML=ds_tv.Tables[0].Rows[i].RATE_TYPE;
                else
                    element1.rows[i+1].cells[3].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].AIR_DATE!=null)
                    {
                    
                if(document.getElementById('txtfrom').value!="")
                {
	                var txt1=ds_tv.Tables[0].Rows[i].AIR_DATE;
	                var txt2=txt1.split("/");
	                var mm=txt2[0];
	                var dd=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate1=dd+'/'+mm+'/'+yy;
	            }
                        element1.rows[i+1].cells[4].innerHTML=txtbussinessdate1;
                    }
                else
                    element1.rows[i+1].cells[4].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].BTB_CODE!=null)
                    element1.rows[i+1].cells[5].innerHTML=ds_tv.Tables[0].Rows[i].BTB_CODE;
                else
                    element1.rows[i+1].cells[5].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].FR_BND_CODE!=null)
                    element1.rows[i+1].cells[6].innerHTML=ds_tv.Tables[0].Rows[i].FR_BND_CODE;
                else
                    element1.rows[i+1].cells[6].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].TO_BND_CODE!=null)
                    element1.rows[i+1].cells[7].innerHTML=ds_tv.Tables[0].Rows[i].TO_BND_CODE;
                else
                    element1.rows[i+1].cells[7].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].BRK_CODE!=null)
                    element1.rows[i+1].cells[8].innerHTML=ds_tv.Tables[0].Rows[i].BRK_CODE;
                else
                    element1.rows[i+1].cells[8].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].POS!=null)
                    element1.rows[i+1].cells[9].innerHTML=ds_tv.Tables[0].Rows[i].POS;
                else
                    element1.rows[i+1].cells[9].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].PRG_ID!=null)
                    element1.rows[i+1].cells[10].innerHTML=ds_tv.Tables[0].Rows[i].PRG_ID;
                else
                    element1.rows[i+1].cells[10].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].PAID_BONUS!=null)
                    element1.rows[i+1].cells[11].innerHTML=ds_tv.Tables[0].Rows[i].PAID_BONUS;
                else
                    element1.rows[i+1].cells[11].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].NO_OF_SPOT!=null)
                    element1.rows[i+1].cells[12].innerHTML=ds_tv.Tables[0].Rows[i].NO_OF_SPOT;
                else
                    element1.rows[i+1].cells[12].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].CLIP_ID!=null)
                    element1.rows[i+1].cells[13].innerHTML=ds_tv.Tables[0].Rows[i].CLIP_ID;
                else
                    element1.rows[i+1].cells[13].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].DUR!=null)
                    element1.rows[i+1].cells[14].innerHTML=ds_tv.Tables[0].Rows[i].DUR;
                else
                    element1.rows[i+1].cells[14].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].RATE!=null)
                    element1.rows[i+1].cells[15].innerHTML=ds_tv.Tables[0].Rows[i].RATE;
                else
                    element1.rows[i+1].cells[15].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].GRS_AMT!=null)
                    element1.rows[i+1].cells[16].innerHTML=ds_tv.Tables[0].Rows[i].GRS_AMT;
                else
                    element1.rows[i+1].cells[16].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].INSERT_ID!=null)
                    element1.rows[i+1].cells[17].innerHTML=ds_tv.Tables[0].Rows[i].INSERT_ID;
                else
                    element1.rows[i+1].cells[17].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].BOOK_STATUS!=null)
                    element1.rows[i+1].cells[18].innerHTML=ds_tv.Tables[0].Rows[i].BOOK_STATUS;
                else
                    element1.rows[i+1].cells[18].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].CATEGORY_CODE!=null)
                    element1.rows[i+1].cells[19].innerHTML=ds_tv.Tables[0].Rows[i].CATEGORY_CODE;
                else
                    element1.rows[i+1].cells[19].innerHTML="";
                
             }
        }
        if(ds_tv.Tables[1].Rows[0].CARD_RATE!=null && ds_tv.Tables[1].Rows[0].CARD_RATE!="")
           {
            window.opener.document.getElementById("txtcardrate").value=ds_tv.Tables[1].Rows[0].CARD_RATE;
           }
           if(ds_tv.Tables[1].Rows[0].CARD_AMOUNT!=null && ds_tv.Tables[1].Rows[0].CARD_AMOUNT!="")
           {
            window.opener.document.getElementById("txtcardamt").value=ds_tv.Tables[1].Rows[0].CARD_AMOUNT;
           }
           if(ds_tv.Tables[1].Rows[0].CONTRACT_RATE!=null && ds_tv.Tables[1].Rows[0].CONTRACT_RATE!="")
           {
           window.opener.document.getElementById("txtdealrate").value=ds_tv.Tables[1].Rows[0].CONTRACT_RATE;
           }
           if(ds_tv.Tables[1].Rows[0].DEVIATION!=null && ds_tv.Tables[1].Rows[0].DEVIATION!="")
           {
           window.opener.document.getElementById("txtdeviation").value=ds_tv.Tables[1].Rows[0].DEVIATION;
           }
           if(ds_tv.Tables[1].Rows[0].DISC_AMT!=null && ds_tv.Tables[1].Rows[0].DISC_AMT!="")
           {
           window.opener.document.getElementById("txtdiscount").value=ds_tv.Tables[1].Rows[0].DISC_AMT;
           }
           if(ds_tv.Tables[1].Rows[0].DISC_PER!=null && ds_tv.Tables[1].Rows[0].DISC_PER!="")
           {
           window.opener.document.getElementById("txtdiscpre").value=ds_tv.Tables[1].Rows[0].DISC_PER;
           }
           if(ds_tv.Tables[1].Rows[0].PREM_AMT!=null && ds_tv.Tables[1].Rows[0].PREM_AMT!="")
           {
           window.opener.document.getElementById("txtpageamt").value=ds_tv.Tables[1].Rows[0].PREM_AMT;
           }
           if(ds_tv.Tables[1].Rows[0].PREM_PER!=null && ds_tv.Tables[1].Rows[0].PREM_PER!="")
           {
           window.opener.document.getElementById("txtpremper").value=ds_tv.Tables[1].Rows[0].PREM_PER;
           }
           window.opener.document.getElementById("txtspedisc").value="";
           window.opener.document.getElementById("txtspediscper").value=""; 
           window.opener.document.getElementById("txtextracharges").value=""; 
           if(ds_tv.Tables[1].Rows[0].ADDL_AGENCY_COMM_AMT!=null && ds_tv.Tables[1].Rows[0].ADDL_AGENCY_COMM_AMT!="")
           {
           window.opener.document.getElementById("txtaddagencycommrate").value=ds_tv.Tables[1].Rows[0].ADDL_AGENCY_COMM_AMT; 
           }
           if(ds_tv.Tables[1].Rows[0].ADDLAGENCY_COMM_PER!=null && ds_tv.Tables[1].Rows[0].ADDLAGENCY_COMM_PER!="")
           {
           window.opener.document.getElementById("txtaddagencycommrateamt").value=ds_tv.Tables[1].Rows[0].ADDLAGENCY_COMM_PER; 
           }
           if(ds_tv.Tables[1].Rows[0].GROSS_AMT!=null && ds_tv.Tables[1].Rows[0].GROSS_AMT!="")
           {
           window.opener.document.getElementById("txtgrossamt").value=ds_tv.Tables[1].Rows[0].GROSS_AMT; 
           }
           if(ds_tv.Tables[1].Rows[0].RETAINER_COMM_AMT!=null && ds_tv.Tables[1].Rows[0].RETAINER_COMM_AMT!="")
           {
           window.opener.document.getElementById("txtRetainercomm").value=ds_tv.Tables[1].Rows[0].RETAINER_COMM_AMT; 
           }
           if(ds_tv.Tables[1].Rows[0].RETAINER_COMM_PER!=null && ds_tv.Tables[1].Rows[0].RETAINER_COMM_PER!="")
           {
           window.opener.document.getElementById("txtRetainercommamt").value=ds_tv.Tables[1].Rows[0].RETAINER_COMM_PER;
           }
           if(ds_tv.Tables[1].Rows[0].AGENCY_COMM_AMT!=null && ds_tv.Tables[1].Rows[0].AGENCY_COMM_AMT!="")
           {
           window.opener.document.getElementById("txttradedisc").value=ds_tv.Tables[1].Rows[0].AGENCY_COMM_AMT;  
           }
           if(ds_tv.Tables[1].Rows[0].BILL_AMOUNT!=null && ds_tv.Tables[1].Rows[0].BILL_AMOUNT!="")
           {
           window.opener.document.getElementById("txtbillamt").value=ds_tv.Tables[1].Rows[0].BILL_AMOUNT;    
           }         
   }
   window.opener.document.getElementById("hiddendaelfromdate").value=document.getElementById('txtfrom').value;
   window.opener.document.getElementById("hiddendaeltodate").value=document.getElementById('txtto').value;
   window.opener.innertablehtmlforbook=document.getElementById("tree1").outerHTML;
   window.opener.document.getElementById("txtMobile").focus();
   window.close();       
   return false;
 }
   function addRow ()
  {
    var objTR = window.opener.document.createElement ("TR");
    var objTD = window.opener.document.createElement ("TD");

    for (var i = 0; i < addRow.arguments.length; i++) 
    {
      objTD = window.opener.document.createElement ("TD");
      objTD.className="tdcls";
      objTD.appendChild (window.opener.document.createTextNode ((arguments[i]=="")?"":arguments[i]));
      objTR.insertAdjacentElement ("beforeEnd", objTD);
    }

    objTBody = element1.tBodies [1];
    objTBody.insertAdjacentElement ("beforeEnd", objTR);

    resizeDivs ();
  }
  var intColCount = 0;
  function resizeDivs ()
  {
    for (var i = 0; i < intColCount; i++)
    {  
      var objDiv = element1.window.opener.document.getElementById ("DragMark" + (i));
      var objTD = element1.tHead.childNodes[0].childNodes[i];

      if ((!objDiv) || (!objTD) || (objTD.tagName != "TD")) return;
      objDiv.style.height = (element1.tBodies[0].childNodes.length + 1) * (objTD.offsetHeight - 1);
    }
  }
function ClientisNumber(event)
{
var browser=navigator.appName;
//alert(event.which);
if(event.shiftKey==true)
    return false;
 if(browser!="Microsoft Internet Explorer")
 {
	if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==0) || (event.which==8) ||(event.which==11)|| (event.which==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}
else
{
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}	
	
}
 function getEventCell ()
  {
    var srcElem = window.event.srcElement;
    while (srcElem!=null && srcElem.tagName != "TD" && srcElem.tagName != "TABLE")
    {
      srcElem = srcElem.parentNode;
    }
    return srcElem;
  }
function tabvalueforschdule(event)
{
if(event.keyCode==113)
    {
        if(event.srcElement.offsetParent.offsetParent.id!="" && event.srcElement.offsetParent.offsetParent.id!=null)
        {
            activeIDNo=document.activeElement.uniqueID;
            var tblid=event.srcElement.offsetParent.offsetParent.id;
            var ele = document.getElementById(tblid);
            var srcElem = getEventCell();
            var cellindex=srcElem.cellIndex;
            var rowindex=parseInt(srcElem.parentNode.rowIndex);
            var colname=ele.rows[0].cells[cellindex].innerHTML
            if(colname=="Tape Id")
            {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //            alert("Please Enter Minimum 3 Character For Searching.");
    //            document.getElementById(activeIDNo).value="";
    //            return false;
    //            }
                document.getElementById("divtapeid").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divtapeid').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divtapeid').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                bookingschedule.bindtapeid(document.getElementById(document.activeElement.uniqueID).value,"N",bindtapeid_callback);
            }
            else if(colname=="BTB CD")
             {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //            alert("Please Enter Minimum 3 Character For Searching.");
    //            document.getElementById(activeIDNo).value="";
    //            return false;
    //            }
            var channel=ele.rows[rowindex].cells[9].childNodes[0].value;
                document.getElementById("divbtb").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divbtb').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divbtb').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                bookingschedule.bindbtb(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,channel,"N",bindbtb_callback);
             }
             else if(colname=="UOM")
             {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //            alert("Please Enter Minimum 3 Character For Searching.");
    //            document.getElementById(activeIDNo).value="";
    //            return false;
    //            }
                document.getElementById("divuom").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divuom').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divuom').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                bookingschedule.binduom(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"N",binduom_callback);
             }
             else if(colname=="Program")
             {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //            alert("Please Enter Minimum 3 Character For Searching.");
    //            document.getElementById(activeIDNo).value="";
    //            return false;
    //            }
                document.getElementById("divprogram").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divprogram').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divprogram').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                bookingschedule.bindprogram(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"N",bindprogram_callback);
             }
             else if(colname=="Adv Type")
             {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //            alert("Please Enter Minimum 3 Character For Searching.");
    //            document.getElementById(activeIDNo).value="";
    //            return false;
    //            }
                document.getElementById("divadtype").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divadtype').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divadtype').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                bookingschedule.bindadtype(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"N",bindadtype_callback);
             }
             else if(colname=="Ad Category")
             {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //            alert("Please Enter Minimum 3 Character For Searching.");
    //            document.getElementById(activeIDNo).value="";
    //            return false;
    //            }
                document.getElementById("divadcat").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divadcat').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divadcat').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                bookingschedule.bindadcat(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"N",bindadcat_callback);
             }
             else if(colname=="From Bnd Cd" || colname=="To Bnd Cd")
             {
    //            if(document.getElementById(document.activeElement.uniqueID).value.length <=2)
    //            {
    //                alert("Please Enter Minimum 3 Character For Searching.");
    //                document.getElementById(activeIDNo).value="";
    //                return false;
    //            }
                var btbcode=ele.rows[rowindex].cells[1].childNodes[0].value;
                var uom=ele.rows[rowindex].cells[2].childNodes[0].value;
                 var ros=ele.rows[rowindex].cells[11].childNodes[0].value;
                 if(uom.indexOf("(")>0)
                uom=uom.substring(uom.lastIndexOf('(')+1,uom.lastIndexOf(')'));
                var channel=ele.rows[rowindex].cells[9].childNodes[0].value;
                document.getElementById("divfrombandcd").style.display="block";
                  aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divfrombandcd').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divfrombandcd').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
                if(colname=="From Bnd Cd")
                         bookingschedule.bindfromtoband(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,btbcode,uom,ros,channel,"N",bindfromband_callback);
                   else
                         bookingschedule.bindfromtoband(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,btbcode,uom,ros,channel,"N",bindtoband_callback);
             
             }
            else if(colname=="Paid")
             {
                document.getElementById("divpaid").style.display="block";
                aTag = eval( document.getElementById(document.activeElement.uniqueID))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divpaid').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
			                 document.getElementById('divpaid').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
			                 if(event.keyCode==40)
                                {
                                    document.getElementById("lstpaid").focus();
                                    return false;
                                }
                
             }
         }
    }
    else if(event.keyCode==27)
    {
        if(document.getElementById("divtapeid").style.display=="block")
            {
                document.getElementById("divtapeid").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            } 
            if(document.getElementById("divbtb").style.display=="block")
            {
                document.getElementById("divbtb").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            }
            if(document.getElementById("divfrombandcd").style.display=="block")
            {
                document.getElementById("divfrombandcd").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            }
            if(document.getElementById("divpaid").style.display=="block")
            {
                document.getElementById("divpaid").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            }
            if(document.getElementById("divuom").style.display=="block")
            {
                document.getElementById("divuom").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            }
            if(document.getElementById("divprogram").style.display=="block")
            {
                document.getElementById("divprogram").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            }
            if(document.getElementById("divadtype").style.display=="block")
            {
                document.getElementById("divadtype").style.display="none"
                if(document.getElementById(activeIDNo)!=null)
                    document.getElementById(activeIDNo).focus();
                activeIDNo="";
            }
            else
                return false;
    }
    else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
    if(document.activeElement.id=="lsttapeid")
        {
            if(document.getElementById('lsttapeid').value=="0" || document.getElementById('lsttapeid').value=="")
            {
                alert("Please select the Tape Id");
                return false;
            }
            document.getElementById("divtapeid").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lsttapeid').options[document.getElementById('lsttapeid').selectedIndex].text;
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstbtb")
        {
            if(document.getElementById('lstbtb').value=="0" || document.getElementById('lstbtb').value=="")
            {
                alert("Please select the BTB Code");
                return false;
            }
            document.getElementById("divbtb").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].value;
            if(document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.indexOf("(")>0)
            {
                  var rostime=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.substring(document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.lastIndexOf('(')+1,document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.lastIndexOf(')')); 
            document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[11].childNodes[0].value=rostime;                
            document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[2].childNodes[0].value="ROD(ROD)";
            document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[2].childNodes[0].focus();
            }
            else
            {
              document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[2].childNodes[0].value="ROS(ROS)";
              document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[2].childNodes[0].focus();
            }
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstfrombandcd")
        {
            if(document.getElementById('lstfrombandcd').value=="0" || document.getElementById('lstfrombandcd').value=="")
            {
                alert("Please select the From Band Code");
                return false;
            }
            document.getElementById("divfrombandcd").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstfrombandcd').options[document.getElementById('lstfrombandcd').selectedIndex].text;
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstpaid")
        {
            if(document.getElementById('lstpaid').value=="0" || document.getElementById('lstpaid').value=="")
            {
                alert("Please select the Paid");
                return false;
            }
            document.getElementById("divpaid").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstpaid').options[document.getElementById('lstpaid').selectedIndex].text+"("+document.getElementById('lstpaid').value+")";
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstprogram")
        {
            if(document.getElementById('lstprogram').value=="0" || document.getElementById('lstprogram').value=="")
            {
                alert("Please select the Paid");
                return false;
            }
            document.getElementById("divprogram").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstprogram').options[document.getElementById('lstprogram').selectedIndex].text;
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstadtype")
        {
            if(document.getElementById('lstadtype').value=="0" || document.getElementById('lstadtype').value=="")
            {
                alert("Please select the Paid");
                return false;
            }
            document.getElementById("divadtype").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstadtype').options[document.getElementById('lstadtype').selectedIndex].text;
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstadcat")
        {
            if(document.getElementById('lstadcat').value=="0" || document.getElementById('lstadcat').value=="")
            {
                alert("Please select the Ad Category");
                return false;
            }
            document.getElementById("divadcat").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstadcat').options[document.getElementById('lstadcat').selectedIndex].text;
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.id=="lstuom")
        {
            if(document.getElementById('lstuom').value=="0" || document.getElementById('lstuom').value=="")
            {
                alert("Please select the Paid");
                return false;
            }
            document.getElementById("divuom").style.display="none";
            document.getElementById(activeIDNo).value=document.getElementById('lstuom').options[document.getElementById('lstuom').selectedIndex].text+"("+document.getElementById('lstuom').value+")";
            document.getElementById(activeIDNo).focus();
            activeIDNo="";
            event.keyCode=9;                     
            return event.keyCode;
        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image" || document.activeElement.type==undefined)
        {
            event.keyCode=13;
            return event.keyCode;
        }
        else
        {
            var idcursor;
            if(event.shiftKey==false)
            {
                event.keyCode=9;                     
                return event.keyCode;
            }    
        }
     }
}
function f2query(event)
{
        activeIDNo=document.activeElement.uniqueID;
        var tblid=event.srcElement.offsetParent.offsetParent.id;
        var ele = document.getElementById(tblid);
        var srcElem = getEventCell ();
        var cellindex=srcElem.cellIndex;
        var rowindex=parseInt(srcElem.parentNode.rowIndex);
        var colname=ele.rows[0].cells[cellindex].innerHTML
    if(agnf2=="Y" && event.keyCode!=113)
    {
    if(colname=="Tape Id")
        {
        if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divtapeid").style.display=="block")
            {
                document.getElementById("divtapeid").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lsttapeid").focus();
            return false;
        }
         document.getElementById("divtapeid").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divtapeid').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divtapeid').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
            bookingschedule.bindtapeid(document.getElementById(document.activeElement.uniqueID).value,"Y",bindtapeid_callback);
      }
      else if(colname=="BTB CD")
        {
        if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divbtb").style.display=="block")
            {
                document.getElementById("divbtb").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstbtb").focus();
            return false;
        }
        var channel=ele.rows[rowindex].cells[9].childNodes[0].value;
         document.getElementById("divbtb").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divbtb').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divbtb').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
            bookingschedule.bindbtb(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,channel,"Y",bindbtb_callback);
      }
      else if(colname=="UOM")
        {
        if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divuom").style.display=="block")
            {
                document.getElementById("divuom").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstuom").focus();
            return false;
        }
         document.getElementById("divuom").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divuom').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divuom').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
            bookingschedule.binduom(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"Y",binduom_callback);
      }
      if(colname=="Program")
        {
        if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divprogram").style.display=="block")
            {
                document.getElementById("divprogram").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstprogram").focus();
            return false;
        }
         document.getElementById("divprogram").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divprogram').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divprogram').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
            bookingschedule.bindprogram(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"Y",bindprogram_callback);
      }
      if(colname=="Adv Type")
        {
        if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divadtype").style.display=="block")
            {
                document.getElementById("divadtype").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstadtype").focus();
            return false;
        }
         document.getElementById("divadtype").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divadtype').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divadtype').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
            bookingschedule.bindadtype(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"Y",bindadtype_callback);
      }
      if(colname=="Ad Category")
        {
        if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divadcat").style.display=="block")
            {
                document.getElementById("divadcat").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstadcat").focus();
            return false;
        }
         document.getElementById("divadcat").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divadcat').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divadcat').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
            bookingschedule.bindadcat(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,"Y",bindadcat_callback);
      }
      else if(colname=="From Bnd Cd" || colname=="To Bnd Cd")
         {
         if(document.getElementById(document.activeElement.uniqueID).value=="")
        {
           if(document.getElementById("divfrombandcd").style.display=="block")
            {
                document.getElementById("divfrombandcd").style.display="none"
                document.getElementById(document.activeElement.uniqueID).focus();
                return false;
            }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstfrombandcd").focus();
            return false;
        }
        var btbcode=ele.rows[rowindex].cells[1].childNodes[0].value;
        var uom=ele.rows[rowindex].cells[2].childNodes[0].value;
         var ros=ele.rows[rowindex].cells[11].childNodes[0].value;
         if(uom.indexOf("(")>0)
            uom=uom.substring(uom.lastIndexOf('(')+1,uom.lastIndexOf(')'));
            var channel=ele.rows[rowindex].cells[9].childNodes[0].value;
         document.getElementById("divfrombandcd").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                     document.getElementById('divfrombandcd').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
	                     document.getElementById('divfrombandcd').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
	           if(colname=="From Bnd Cd")
                     bookingschedule.bindfromtoband(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,btbcode,uom,ros,channel,"Y",bindfromband_callback);
               else
                     bookingschedule.bindfromtoband(document.getElementById("hiddendealco").value,document.getElementById(document.activeElement.uniqueID).value,btbcode,uom,ros,channel,"Y",bindtoband_callback);
      }
      else if(colname=="Paid")
         {
//         if(document.getElementById(document.activeElement.uniqueID).value=="")
//        {
//           if(document.getElementById("divpaid").style.display=="block")
//            {
//                document.getElementById("divpaid").style.display="none"
//                document.getElementById(document.activeElement.uniqueID).focus();
//                if(event.keyCode==40)
//                {
//                    document.getElementById("lstpaid").focus();
//                    return false;
//                }
//                return false;
//            }
//                return false;
//        }
        if(event.keyCode==40)
        {
            document.getElementById("lstpaid").focus();
            return false;
        }
         document.getElementById("divpaid").style.display="block";
              aTag = eval( document.getElementById(document.activeElement.uniqueID))
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
         document.getElementById('divpaid').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + (toppos+15) + "px";
         document.getElementById('divpaid').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
	    }	
   }     
}
function bindtapeid_callback(response)
{         
    ds=response.value;
    var pkgitem = document.getElementById("lsttapeid");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Tape Id-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].CLIP_ID,ds.Tables[0].Rows[i].CLIP_ID);
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstdeal").focus();  //uncomment
    }
    document.getElementById("lsttapeid").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lsttapeid").focus();
    }
     return false;
}
function bindbtb_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstbtb");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select BTB Code-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            if(ds.Tables[0].Rows[i].ROS_CODE==null)
            {
              ds.Tables[0].Rows[i].ROS_CODE="";
              pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BTB_CODE,ds.Tables[0].Rows[i].BTB_CODE);
            }
            else
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BTB_CODE+"("+ds.Tables[0].Rows[i].ROS_CODE+")",ds.Tables[0].Rows[i].BTB_CODE);
            }
        
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstbtb").focus();  //uncomment
    }
    document.getElementById("lstbtb").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstbtb").focus();
    }
     return false;
}
function binduom_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstuom");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select UOM Code-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].RATE_TYPE,ds.Tables[0].Rows[i].RATE_TYPE);
        
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstuom").focus();  //uncomment
    }
    document.getElementById("lstuom").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstuom").focus();
    }
     return false;
}
function bindadtype_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstadtype");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Ad Type Code-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].AD_TYPE,ds.Tables[0].Rows[i].AD_TYPE);
        
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstadtype").focus();  //uncomment
    }
    document.getElementById("lstadtype").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstadtype").focus();
    }
     return false;
}
function bindadcat_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstadcat");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Ad Category-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].AD_CTG,ds.Tables[0].Rows[i].AD_CTG);
        
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstadcat").focus();  //uncomment
    }
    document.getElementById("lstadcat").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstadcat").focus();
    }
     return false;
}
function bindprogram_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstprogram");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Program Code-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].PRG_CODE,ds.Tables[0].Rows[i].PRG_CODE);
        
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstprogram").focus();  //uncomment
    }
    document.getElementById("lstprogram").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstprogram").focus();
    }
     return false;
}
function bindfromband_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstfrombandcd");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select From Id-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BND_CODE,ds.Tables[0].Rows[i].BND_CODE);
            if(ds.Tables[0].Rows[i].COLOR=="1")
                pkgitem.options[pkgitem.options.length-1].style.background = "green"
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstfrombandcd").focus();  //uncomment
    }
    document.getElementById("lstfrombandcd").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstfrombandcd").focus();
    }
     return false;
}
function bindtoband_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstfrombandcd");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select To Id-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
       pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BND_CODE,ds.Tables[0].Rows[i].BND_CODE);
        
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById(activeIDNo).value="";
        document.getElementById("lstfrombandcd").focus();  //uncomment
    }
    document.getElementById("lstfrombandcd").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById(activeIDNo).value=="") 
    {
     document.getElementById("lstfrombandcd").focus();
    }
     return false;
}
function bindonclick()
{
    if(document.activeElement.id=="lsttapeid")
        {
            if(document.getElementById('lsttapeid').value=="0" ||document.getElementById('lsttapeid').value=="" )
            {
                alert("Please select the Tape Id");
                return false;
            }
            document.getElementById("divtapeid").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lsttapeid').options[document.getElementById('lsttapeid').selectedIndex].text;
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[1].childNodes[0].focus()
            }    
            activeIDNo="";
        }
        else if(document.activeElement.id=="lstbtb")
        {
            if(document.getElementById('lstbtb').value=="0" ||document.getElementById('lstbtb').value=="")
            {
                alert("Please select the BTB Code");
                return false;
            }
            document.getElementById("divbtb").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].value;
                if(document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.indexOf("(")>0)
                {
                  var rostime=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.substring(document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.lastIndexOf('(')+1,document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text.lastIndexOf(')')); 
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[11].childNodes[0].value=rostime;
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[2].childNodes[0].value="ROD(ROD)";
            }
            else
            {
              document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[2].childNodes[0].value="ROS(ROS)";
            }
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[3].childNodes[0].focus();
            }   
            activeIDNo="";
        }
        else if(document.activeElement.id=="lstuom")
        {
            if(document.getElementById('lstuom').value=="0" || document.getElementById('lstuom').value=="")
            {
                alert("Please select the UOM");
                return false;
            }
            document.getElementById("divuom").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstuom').options[document.getElementById('lstuom').selectedIndex].text;
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[3].childNodes[0].focus()
            }    
            activeIDNo="";
        }
         else if(document.activeElement.id=="lstprogram")
        {
            if(document.getElementById('lstprogram').value=="0" || document.getElementById('lstprogram').value=="")
            {
                alert("Please select the Program");
                return false;
            }
            document.getElementById("divprogram").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstprogram').options[document.getElementById('lstprogram').selectedIndex].text;
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[6].childNodes[0].focus()
            }    
            activeIDNo="";
        }
         else if(document.activeElement.id=="lstadtype")
        {
            if(document.getElementById('lstadtype').value=="0" || document.getElementById('lstadtype').value=="")
            {
                alert("Please select the Ad Type");
                return false;
            }
            document.getElementById("divadtype").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstadtype').options[document.getElementById('lstadtype').selectedIndex].text;
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[7].childNodes[0].focus()
            }
            activeIDNo="";
        }
        else if(document.activeElement.id=="lstfrombandcd")
        {
            if(document.getElementById('lstfrombandcd').value=="0" || document.getElementById('lstfrombandcd').value=="")
            {
                alert("Please select the From Band Code");
                return false;
            }
            document.getElementById("divfrombandcd").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstfrombandcd').options[document.getElementById('lstfrombandcd').selectedIndex].text;
                if(document.getElementById(activeIDNo).parentNode.cellIndex==4)
                    document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[5].childNodes[0].focus()
                else
                    document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[4].childNodes[0].focus()
            }
            activeIDNo="";
        }
        else if(document.activeElement.id=="lstpaid")
        {
            if(document.getElementById('lstpaid').value=="0" || document.getElementById('lstpaid').value=="")
            {
                alert("Please select the Paid");
                return false;
            }
            document.getElementById("divpaid").style.display="none";
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstpaid').options[document.getElementById('lstpaid').selectedIndex].text+"("+document.getElementById('lstpaid').value+")";
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[8].childNodes[0].focus()
            }
            activeIDNo="";
        }
        else if(document.activeElement.id=="lstadcat")
        {
            if(document.getElementById('lstadcat').value=="0" || document.getElementById('lstadcat').value=="")
            {
                alert("Please select the Ad Category");
                return false;
            }
            document.getElementById("divadcat").style.display="none";
            if(document.getElementById(activeIDNo)!=null)
            {
                document.getElementById(activeIDNo).value=document.getElementById('lstadcat').options[document.getElementById('lstadcat').selectedIndex].text;
                document.getElementById(document.getElementById(activeIDNo).parentNode.offsetParent.id).rows[document.getElementById(activeIDNo).parentNode.parentElement.rowIndex].cells[12].childNodes[0].focus()
            }
            activeIDNo="";
        }         
}
function changedate()
{
var txtbussinessdate1="";
var txtbussinessdate12="";
var dateformat=document.getElementById('hiddateformate').value;
        if(dateformat=="dd/mm/yyyy")
			{
                if(document.getElementById('txtfrom').value!="")
                {
	                var txt1=document.getElementById('txtfrom').value;
	                var txt2=txt1.split("/");
	                var dd=txt2[0];
	                var mm=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate1=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate1=document.getElementById('txtfrom').value;
	            }    			
	        }
            if(dateformat=="mm/dd/yyyy")
            {
	                txtbussinessdate1=document.getElementById('txtfrom').value;
	        }
            if(dateformat=="yyyy/mm/dd")
            {
	            if(document.getElementById('txtfrom').value!="")
	            {
	                var txt1=document.getElementById('txtfrom').value;
	                var txt2=txt1.split("/");
	                var yy=txt2[0];
	                var mm=txt2[1];
	                var dd=txt2[2];
	                txtbussinessdate1=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate1=document.getElementById('txtfrom').value;
	            }
			}
			if(dateformat=="dd/mm/yyyy")
			{
	            if(document.getElementById('hidfromdate').value!="")
	            {
	                var txt1=document.getElementById('hidfromdate').value;
	                var txt2=txt1.split("/");
	                var dd=txt2[0];
	                var mm=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate12=mm+'/'+dd+'/'+yy;
	            }
	            else
                {
                    txtbussinessdate12=document.getElementById('hidfromdate').value;
                }    			
	        }
            if(dateformat=="mm/dd/yyyy")
            {
                txtbussinessdate12=document.getElementById('hidfromdate').value;
            }
            if(dateformat=="yyyy/mm/dd")
                {
                    if(document.getElementById('hidfromdate').value!="")
                    {
                        var txt1=document.getElementById('hidfromdate').value;
                        var txt2=txt1.split("/");
                        var yy=txt2[0];
                        var mm=txt2[1];
                        var dd=txt2[2];
                        txtbussinessdate12=mm+'/'+dd+'/'+yy;
                    }
                    else
                    {
                        txtbussinessdate12=document.getElementById('hidfromdate').value;
                    }
			}
    var fromdate=txtbussinessdate1;
    var hidfdate=txtbussinessdate12;
    var res=datechk(fromdate,hidfdate);
    if(res==false)
    {
        alert("From date Should be Equal or Greater for Deal Date");
        document.getElementById('txtfrom').focus();
        return false;
    }
}
function datechk(date1,date2)
{
    var endate=new Date(date1);
    var bdate=new Date(date2);
    if(endate <= bdate)
    {
        return false;
    }    
}
function changedate1()
{
    var txtbussinessdate1="";
    var txtbussinessdate12="";
    var dateformat=document.getElementById('hiddateformate').value;
        if(dateformat=="dd/mm/yyyy")
			{
                if(document.getElementById('txtto').value!="")
                {
	                var txt1=document.getElementById('txtto').value;
	                var txt2=txt1.split("/");
	                var dd=txt2[0];
	                var mm=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate1=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate1=document.getElementById('txtto').value;
	            }
    			
	        }
            if(dateformat=="mm/dd/yyyy")
            {
	                txtbussinessdate1=document.getElementById('txtto').value;
	        }
            if(dateformat=="yyyy/mm/dd")
            {
	            if(document.getElementById('txtto').value!="")
	            {
	                var txt1=document.getElementById('txtto').value;
	                var txt2=txt1.split("/");
	                var yy=txt2[0];
	                var mm=txt2[1];
	                var dd=txt2[2];
	                txtbussinessdate1=mm+'/'+dd+'/'+yy;
	            }
	            else
	            {
	                txtbussinessdate1=document.getElementById('txtto').value;
	            }
			}
			if(dateformat=="dd/mm/yyyy")
			{
	            if(document.getElementById('hidtodate').value!="")
	            {
	                var txt1=document.getElementById('hidtodate').value;
	                var txt2=txt1.split("/");
	                var dd=txt2[0];
	                var mm=txt2[1];
	                var yy=txt2[2];
	                 txtbussinessdate12=mm+'/'+dd+'/'+yy;
	            }
	            else
                {
                    txtbussinessdate12=document.getElementById('hidtodate').value;
                }
    			
	        }
            if(dateformat=="mm/dd/yyyy")
            {
            txtbussinessdate12=document.getElementById('hidtodate').value;
            }
                if(dateformat=="yyyy/mm/dd")
                {
                    if(document.getElementById('hidfromdate').value!="")
                    {
                        var txt1=document.getElementById('hidtodate').value;
                        var txt2=txt1.split("/");
                        var yy=txt2[0];
                        var mm=txt2[1];
                        var dd=txt2[2];
                        txtbussinessdate12=mm+'/'+dd+'/'+yy;
                    }
                    else
                    {
                        txtbussinessdate12=document.getElementById('hidtodate').value;
                    }
			}
    var todate=txtbussinessdate1;
    var hidfdate=txtbussinessdate12;
    var res=datechk1(todate,hidfdate);
    if(res==false)
    {
        alert("To date Should be Equal or Less than for Deal End Date");
        document.getElementById('txtto').focus();
        return false;
    }
     else
    {
        event.keyCode=9;                     
        return event.keyCode;
    }
}
function datechk1(date1,date2)
{
    var endate=new Date(date1);
    var bdate=new Date(date2);
    if(endate >= bdate)
    {
        return false;
    }
    
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
function onlode()
{
    if(window.opener.innertablehtmlforbook!="" && window.opener.innertablehtmlforbook!=undefined)
    {
        document.getElementById("tree1").outerHTML=window.opener.innertablehtmlforbook;
        var dareformat=document.getElementById('hiddateformate').value;
        var fromdealdate=document.getElementById('txtfrom').value=window.opener.document.getElementById('hiddendaelfromdate').value;
        var todealdate=document.getElementById('txtto').value=window.opener.document.getElementById('hiddendaeltodate').value;
        for(var i=1;i<window.opener.document.getElementById('tblGridelecbook').rows.length;i++)
        {
            var channel=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[0].innerHTML;
            if(channel.indexOf("(")>0)
                channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
            var location=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[1].innerHTML;
            if(location.indexOf("(")>0)
                location=location.substring(location.lastIndexOf('(')+1,location.lastIndexOf(')'));
            var adtype=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[2].innerHTML;
            if(adtype.indexOf("(")>0)
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
            var airdate=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[4].innerHTML;
               var txt2=airdate.split("/");
               var mm=txt2[0];
               var dd=txt2[1];
               var yy=txt2[2];
               airdate=dd+'/'+mm+'/'+yy;
            var btbcode=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[5].innerHTML;
            var frbtbcode=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[6].innerHTML;
            var tobtbcode=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[7].innerHTML;
            var paidbonus=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[11].innerHTML;
            var dur="";
            var tapid=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[13].innerHTML;
            var prgid=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[10].innerHTML;
            if(prgid.indexOf("(")>0)
                prgid=prgid.substring(prgid.lastIndexOf('(')+1,prgid.lastIndexOf(')'));
            var noofspot=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[12].innerHTML;
            var ratetype=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[3].innerHTML;
            var insertid=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[17].innerHTML;
            var bookstatus=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[18].innerHTML;
            var returndata="N";
            var category=window.opener.document.getElementById('tblGridelecbook').rows[i].cells[19].innerHTML
            bookingschedule.getgrid(channel, location, adtype, airdate, document.getElementById('hiddendealco').value, btbcode, frbtbcode, tobtbcode, paidbonus, dur, tapid, prgid, noofspot, ratetype, returndata,insertid,bookstatus,fromdealdate,todealdate,dareformat,category);            
        }
    }
}