var count1="";
var count2="";
function tabvalue1(event)
{
var browser=navigator.appName;
if(event.keyCode==113)  
    {
    if(document.activeElement.id=="txtexecname")
        {
           if(document.getElementById('txtexecname').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtexecname').value="";
            return false;
            }
            document.getElementById("divexec").style.display="block";
              aTag = eval( document.getElementById("txtexecname"))
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
			             document.getElementById('divexec').style.top=document.getElementById("txtexecname").offsetTop + toppos + "px";
			             document.getElementById('divexec').style.left=document.getElementById("txtexecname").offsetLeft + leftpos+"px";
            multiexecselect.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecname').value.toUpperCase(),bindexecname_callback);
        }
    }else if(event.keyCode==27)
    {
        if(document.getElementById("divexec").style.display=="block")
            {
                document.getElementById("divexec").style.display="none"
                document.getElementById('txtexecname').focus();
            }
     } 
     else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
    if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
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
function bindexecname_callback(response)
    {
         ds=response.value;
         var pkgitem = document.getElementById("lstexec");
         pkgitem.options.length = 0; 
         pkgitem.options[0]=new Option("-Select Exec-","0");
         if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
         {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name,ds.Tables[0].Rows[i].exe_no);                
               pkgitem.options.length;               
            }
         }
         document.getElementById('txtexecname').value="";
         document.getElementById("lstexec").value="0";
         if(document.getElementById("lstexec").style.visibility=="hidden")
            document.getElementById("lstexec").style.visibility="visible";
         document.getElementById("lstexec").focus();
         return false;

    }
    var trid;
    function submitcl()
    { 
    var foot=0;
    var header=0;
    count1="";
    count2="";
    trid=0;
    document.getElementById('save').innerHTML="";
    if(document.getElementById('lstexec').value=="0")
            {
                alert("Please select the executive");
                return false;
            }
        var sel = document.getElementById("lstexec");
        var optsLength = sel.options.length;
        if(count1=="")
                    {
                        count1=count1+"<div style='overflow:auto;  width:1100px; margin:50px 0px 0px 30px;'>";
                    }
                    else
                    {
                        count1=count1.replace('</DIV>','');
                    } 
        for(var i=0;i<optsLength;i++)
        {
        //trid=i
            if(sel.options[i].selected == true)
            {
            trid++;
                //alert(sel.options[i].text);
                
                
                //count1=count1+" <table id='c'  cellpadding=0 cellspacing=0  border=1>";
                if(header==0)
                 {
                 count1=count1+" <table id='c'  cellpadding=0 cellspacing=0  border=1>";
                     count1=count1+"<tr id='trid'><td class=\"dtGridHd12\" bgcolor=\"#7DAAE3\" align =\"center\"></td><td bgcolor=\"#7DAAE3\" class=\"dtGridHd12\" align =\"center\">Sharing</td><td bgcolor=\"#7DAAE3\" class=\"dtGridHd12\" align =\"center\">Executive</td></tr>";
                     header=header+1;
                 }
                 count1=count1+"<tr id="+ trid +"><td><input id=str"+trid+" class=\"TextField\"  type=\"checkbox\"  style=\"top:0px\" width='5px'  ></td>";

                 count1=count1+"<td><input id=tt"+trid+" class=\"btextforgrid\" type=\"text\" MaxLength=\"10\" onblur=\"return notchar2(this);\" onblur=\"return notchar2(event);\" value=''></td>";
                 count1=count1+"<td><input id=bb"+trid+"  width='100px' disabled type=\"text\"  value='"+sel.options[i].text+"("+sel.options[i].value+")' ></td>";
                  count1=count1+"<td><input id=sd"+trid+" class=\"btextforgrid\" disabled type=\"hidden\" value='"+sel.options[i].value+"' ></td>";
                  count1=count1+"</tr>";

            }
        }
        count1=count1+"</table></div>";
        document.getElementById('gridopen').innerHTML=count1;
        if(foot==0)
{
 count2=document.getElementById('save').innerHTML;
 count2=count2+"<table style='margin:50px 0px 0px 30px;' cellpadding=0 cellspacing=0  id=\"tablebutton\">";
 count2=count2+"<tr><td></td><td></td><td></td><td><input id=\"ok\" class=\"button1\" type=\"button\" value=\"OK\" onclick=\"saverecord();\"></td>";
 count2=count2+"<td><input id=\"cancel\" class=\"button1\" style=\"display:none\" type=\"button\" value=\"Cancel\" onclick=\"clearclick_bill();\"></td>";
 count2=count2+"<td><input id=\"delete\" class=\"button1\" type=\"button\" value=\"Delete\" onclick=\"deleteclick_bill();\"></td>";
 count2=count2+"</tr></table>";
 document.getElementById('save').innerHTML=count2;
 foot=foot+1;
} 

        document.getElementById("divexec").style.display="none";
        //document.getElementById("btad").style.display="block"
           document.getElementById("btnsubmit").disabled=true;
           document.getElementById("btad").disabled=false;
        return false;
    }
    var multiselect1="";
    var multicode1="";
    function saverecord()
    {
    var flag1="";
    multiselect1="";
    multicode1="";
    for(var j=1; j<=trid; j++)
    {
    if(document.getElementById('tt'+j)!=null)
    {
//       if(document.getElementById('str'+j).checked==true)
//      {
     
      if(document.getElementById('tt'+j).value=="")
      {
          alert("Please Enter the Sharing Value.");
          return false;
      }
       flag1=1;
         if(multiselect1=="")
         {
             multiselect1=document.getElementById('tt'+j).value+"~"+document.getElementById('bb'+j).value;
             multicode1=document.getElementById('tt'+j).value+"~"+document.getElementById('sd'+j).value;
         }
         else
         {
             multiselect1=multiselect1+"$"+document.getElementById('tt'+j).value+"~"+document.getElementById('bb'+j).value;
             multicode1=multicode1+"$"+document.getElementById('tt'+j).value+"~"+document.getElementById('sd'+j).value;
         }
      }
    //}  
    }
    if(flag1!="")
    {
    window.opener.multiselect=multiselect1;
    window.opener.multicode=multicode1;
    }
    window.close();
    //document.getElementById('sd3').value
    return false;
    }
    function clearclick_bill()
    {
    multiselect1="";
    multicode1="";
    document.getElementById('gridopen').innerHTML="";
    document.getElementById('save').innerHTML="";
    return false;
    }
    
    function deleteclick_bill()
    {
    var table = document.getElementById("c");
            var rowCount = table.rows.length;
            for(var i=0; i<rowCount; i++) 
            {
                var row = table.rows[i];
                var chkbox = row.cells[0].childNodes[0];

                if(null != chkbox && true == chkbox.checked) 
                {
                
                if(document.getElementById('hiddenmod').value=="1")
                     {
                     var cioid=document.getElementById('hiddencioid').value;
                     var code=row.cells[3].childNodes[0].value;
                     deletecode(cioid,code);
                     }
                     table.deleteRow(i);
                     //trid--;
                     rowCount--;
                     i--;
                    
                     
                     
                }
            
            }
    //alete("bhanu2")
    return false;
    }
    function multiad()
    {
    var sel = document.getElementById("lstexec");
    var optsLength = sel.options.length;
      //count1=count1.replace('</table></div>','');
      var tableToSort=document.getElementById("c");
      for(var i=0;i<optsLength;i++)
        {
        for(j=1;j<tableToSort.rows.length;j++)
        {
        if(sel.options[i].value==tableToSort.rows[j].cells[3].childNodes[0].value)
        {
            alert("There is Duplicate entry in Selection")
            return false;
        }
        }
     
      
        //trid=i
            if(sel.options[i].selected == true)
            {
            trid++;
                //alert(sel.options[i].text);
                newRow = tableToSort.insertRow();
                newCell = newRow.insertCell();
                var element1 = document.createElement("input");
                element1.type = "checkbox";
                newCell.appendChild(element1);
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input id=tt"+trid+" class=\"btextforgrid\" type=\"text\" MaxLength=\"10\" onblur=\"return notchar2(this);\" value=''>";//document.getElementById("txtfrminsert").value;
              newCell.focus();
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input id=bb"+trid+"  disabled type=\"text\" value='"+sel.options[i].text+"("+sel.options[i].value+")' >";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input id=sd"+trid+" class=\"btextforgrid\" disabled type=\"hidden\" value='"+sel.options[i].value+"' >";
                
                
                
//                 count1=count1+"<tr id="+ trid +"><td><input id=str"+trid+" class=\"TextField\"  type=\"checkbox\"  style=\"top:0px\" width='5px'  ></td>";

//                 count1=count1+"<td><input id=tt"+trid+" class=\"btextforgrid\" type=\"text\" onkeypress=\"return notchar2(event);\" value=''></td>";
//                 count1=count1+"<td><input id=bb"+trid+"  disabled type=\"text\" value='"+sel.options[i].text+"("+sel.options[i].value+")' ></td>";
//                  count1=count1+"<td><input id=sd"+trid+" class=\"btextforgrid\" disabled type=\"hidden\" value='"+sel.options[i].value+"' ></td>";
//                  count1=count1+"</tr>";

            }
        }
        //count1=count1+"</table></div>";
        //document.getElementById('gridopen').innerHTML=count1;
        document.getElementById("divexec").style.display="none";
        return false;
    }
    

	function selval()
    {
        if(window.opener.multiselect!="")
        {
           var multiselect1=window.opener.multiselect;
           //var multisharing1=window.opener.multiselect;
           var splitselect=multiselect1.split("$");
           //var splitsharing1=multisharing1.split("~");
            var foot=0;
    var header=0;
    count1="";
    count2="";
    trid=0;
    document.getElementById('save').innerHTML="";
    
        //var sel = document.getElementById("lstexec");
        var optsLength = splitselect.length;
        if(count1=="")
                    {
                        count1=count1+"<div style='overflow:auto;  width:1100px; margin:50px 0px 0px 30px;'>";
                    }
                    else
                    {
                        count1=count1.replace('</DIV>','');
                    } 
           for(var i=0;i<optsLength;i++)
        {
        var sel=splitselect[i].split("~");
        var code=sel[1].split("(");
        //trid=i
//            if(sel.options[i].selected == true)
//            {
            trid++;
                //alert(sel.options[i].text);
                
                
                //count1=count1+" <table id='c'  cellpadding=0 cellspacing=0  border=1>";
                if(header==0)
                 {
                 count1=count1+" <table id='c'  cellpadding=0 cellspacing=0  border=1>";
                     count1=count1+"<tr id='trid'><td class=\"dtGridHd12\" bgcolor=\"#7DAAE3\" align =\"center\"></td><td bgcolor=\"#7DAAE3\" class=\"dtGridHd12\" align =\"center\">Sharing</td><td bgcolor=\"#7DAAE3\" class=\"dtGridHd12\" align =\"center\">Executive</td></tr>";
                     header=header+1;
                 }
                 count1=count1+"<tr id="+ trid +"><td><input id=str"+trid+" class=\"TextField\"  type=\"checkbox\"  style=\"top:0px\" width='5px'  ></td>";

                 count1=count1+"<td><input id=tt"+trid+" class=\"btextforgrid\" type=\"text\" MaxLength=\"10\" onblur=\"return notchar2(this);\" value='"+sel[0]+"'></td>";
                 count1=count1+"<td><input id=bb"+trid+"  width='100px' disabled type=\"text\" value='"+sel[1]+"' ></td>";
                  count1=count1+"<td><input id=sd"+trid+" class=\"btextforgrid\" disabled type=\"hidden\" value='"+code[1].replace(")","")+"' ></td>";
                  count1=count1+"</tr>";

            //}
        }
        count1=count1+"</table></div>";
        document.getElementById('gridopen').innerHTML=count1;
        if(foot==0)
{
 count2=document.getElementById('save').innerHTML;
 count2=count2+"<table style='margin:50px 0px 0px 30px;' cellpadding=0 cellspacing=0  id=\"tablebutton\">";
 count2=count2+"<tr><td></td><td></td><td></td><td><input id=\"ok\" class=\"button1\" type=\"button\" value=\"OK\" onclick=\"saverecord();\"></td>";
 count2=count2+"<td><input id=\"cancel\" class=\"button1\" style=\"display:none\" type=\"button\" value=\"Cancel\" onclick=\"clearclick_bill();\"></td>";
 count2=count2+"<td><input id=\"delete\" class=\"button1\" type=\"button\" value=\"Delete\" onclick=\"deleteclick_bill();\"></td>";
 count2=count2+"</tr></table>";
 document.getElementById('save').innerHTML=count2;
 foot=foot+1;
} 
           
           
        }
    }
    function deletecode(cioid,code)
    {
    var name=multiexecselect.deleteexe(document.getElementById('hiddencompcode').value,cioid,code)
    
    }
    function notchar21(event)
{
//alert(event.keyCode);
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9) || (event.which==0)|| (event.which==46))
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
    if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9) ||(event.keyCode==46) )
    {
    return true;
    }
    else
    {
    return false;
    }
}   
}

function notchar2( strValue ) {
var num=document.getElementById(strValue.id).value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById(strValue.id).value="";
document.getElementById(strValue.id).focus();

return false; 

}
    
  //return strValue;
}