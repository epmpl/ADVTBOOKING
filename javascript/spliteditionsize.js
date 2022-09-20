// JScript File

//---------------- On addclick Create New Rows -------------------//
function addClick()
{
      if(document.getElementById('tblbutton').disabled ==true)
         return false;
      var tableToSort=document.getElementById("tblgrid");
      var rowCount = tableToSort.rows.length;
      var total=0;
        for(var i=1; i<rowCount; i++) {
            var row = tableToSort.rows[i];
            var totalarea = row.cells[5].childNodes[0].value;
            var dateI="";
            dateI = row.cells[1].childNodes[0].value;
            if(dateI=="")
            {
             alert("Please Fill Publish Date for Row No. " + i);
             row.cells[1].childNodes[0].focus();
                return false;
            }
            else if(totalarea=="")
            {
           
                alert("Please Fill Total Area for Row no. " + i);
                return false;
            }
            total=parseFloat(total) + parseFloat(totalarea);
         }   
     
    if(parseFloat(total)>=parseFloat(document.getElementById('hiddentotalarea').value))
    {
        return false;
    }
      
//    if(n==parseInt(document.getElementById("tblgrid").rows.length))
//    {
        
       newRow = tableToSort.insertRow();
          
          newCell = newRow.insertCell();
          var element1 = document.createElement("input");
          element1.type = "checkbox";
          newCell.appendChild(element1);

          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='20' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >";//document.getElementById("txtfrminsert").value;
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+document.getElementById('hiddenedition').value+"' >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; // 
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text style=\"display:none;\" class=btextsmallsize  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text style=\"display:none;\" class=btextsmallsize  >";
      return false;
}
function onpage_load()
{
     document.getElementById("tblbutton").style.display="block";
     document.getElementById("tblgrid").style.display="block";
     var tableToSort=document.getElementById("tblgrid");
     if(document.getElementById('hiddeninsertid').value=="" || document.getElementById('hiddeninsertid').value=="0")
     {
        newRow = tableToSort.insertRow();
 
       //------ Dynamic TABLE  heading-----//
          newRow.className ="dtGridrate";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "";
          
          newCell = newRow.insertCell();
          newCell.align="center";
         
          newCell.innerHTML = "Date";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Edition";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Height";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Width";
          
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Total Area";
          
          newRow = tableToSort.insertRow();
          
          newCell = newRow.insertCell();
          var element1 = document.createElement("input");
          element1.type = "checkbox";
          newCell.appendChild(element1);

          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='20' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >";//document.getElementById("txtfrminsert").value;
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+document.getElementById('hiddenedition').value+"' >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; // 
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+document.getElementById('hiddeninsertid').value+"' class=btextsmallsize  >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text style=\"display:none;\" class=btextsmallsize  >";
         }
         else
         {
            var res=spliteditionsize.fetchinsertdata(document.getElementById('hiddeninsertid').value,document.getElementById('hiddendateformat').value);
            if(res.value!=null)
            {
                var ds=res.value;
                  if(ds!= null && typeof(ds) == "object" && ds.Tables.length>0 && ds.Tables[0].Rows.length > 0) 
                  {
                     newRow = tableToSort.insertRow();
 
                   //------ Dynamic TABLE  heading-----//
                      newRow.className ="dtGridrate";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "";
                      
                      newCell = newRow.insertCell();
                      newCell.align="center";
                     
                      newCell.innerHTML = "Date";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "Edition";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "Height";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "Width";
                      
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "Total Area";
                    for(var i=0;i<ds.Tables[0].Rows.length;i++)
                    {
                       
                      
                      newRow = tableToSort.insertRow();
                      
                      newCell = newRow.insertCell();
                      var element1 = document.createElement("input");
                      element1.type = "checkbox";
                      newCell.appendChild(element1);

                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text maxLength='20' value='"+ds.Tables[0].Rows[i].INSERTDATE+"' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >";//document.getElementById("txtfrminsert").value;
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+document.getElementById('hiddenedition').value+"' >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text  maxLength='5' value='"+ds.Tables[0].Rows[i].HEIGHT+"'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text  maxLength='5' value='"+ds.Tables[0].Rows[i].WIDTH+"'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; // 
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text  disabled=true value='"+ds.Tables[0].Rows[i].AREA+"' class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+document.getElementById('hiddeninsertid').value+"' class=btextsmallsize  >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+ds.Tables[0].Rows[i].SRNO+"' class=btextsmallsize  >";
                    }  
                  }
                  else{
                   newRow = tableToSort.insertRow();
 var arr1=document.getElementById('hiddeninsertid').value.split("$");
       //------ Dynamic TABLE  heading-----//
          newRow.className ="dtGridrate";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "";
          
          newCell = newRow.insertCell();
          newCell.align="center";
         
          newCell.innerHTML = "Date";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Edition";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Height";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Width";
          
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Total Area";
           for(var i=0;i<arr1.length;i++)
            {
                        var arr=arr1[i].split("~");
                      newRow = tableToSort.insertRow();
                      
                      newCell = newRow.insertCell();
                      var element1 = document.createElement("input");
                      element1.type = "checkbox";
                      newCell.appendChild(element1);

                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text maxLength='20' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\" value='"+arr[0].toString()+"'  onblur=\"return checkdate(this)\" >";//document.getElementById("txtfrminsert").value;
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+document.getElementById('hiddenedition').value+"' >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" value='"+arr[2].toString()+"' onblur=\"return getTotal(this.parentNode.parentNode)\" >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\"  value='"+arr[3].toString()+"' onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; // 
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text  disabled=true class=btextsmallsize value='"+arr[4].toString()+"' onkeypress=\"return rateenter(event);\"  >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+document.getElementById('hiddeninsertid').value+"' class=btextsmallsize  >";
                      newCell = newRow.insertCell();
                      newCell.align="center";
                      newCell.innerHTML = "<input type=text style=\"display:none;\" class=btextsmallsize  >";
                   }   
                  }
            }
         }
          tableToSort.disabled=true;
          if(document.getElementById('hiddenchkbtnStatus').value=="new" || (document.getElementById('hiddeninsertstatus').value=="booked" && document.getElementById('hiddenchkbtnStatus').value=="modify"))
            tableToSort.disabled=false;
          return false;     
}

function getTotal(name)
{
    try {
        var table = document.getElementById("tblgrid");
        var rowCount = table.rows.length;
        var rowindex=parseInt(name.rowIndex);
        var row1 = table.rows[rowindex];
            var height =row1.cells[3].childNodes[0].value;
            var width =  row1.cells[4].childNodes[0].value;
            if(height!="" && width!="")
            {
                row1.cells[5].childNodes[0].value = parseFloat(height) * parseFloat(width);
            }
            // for checking maximize sie
      var rowCount = table.rows.length;
      var total=0;
        for(var i=1; i<rowCount; i++) {
            var row = table.rows[i];
            var totalarea = row.cells[5].childNodes[0].value;
            if(totalarea!="")
                total=parseFloat(total) + parseFloat(totalarea);
         }   
     
    if(parseFloat(total)>parseFloat(document.getElementById('hiddentotalarea').value))
    {
        row1.cells[5].childNodes[0].value ="";
          row1.cells[4].childNodes[0].value ="";
           row1.cells[3].childNodes[0].value ="";
        row1.cells[3].childNodes[0].focus();
        alert("Size Exceed.");
        return false;
    }
    
     }catch(e) {
    alert(e);
}
}
function checkdate(input)
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

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
//alert(document.activeElement.id);
 alert(" Please Fill The Date In "+document.getElementById('hiddendateformat').value+" Format");
//popUpCalendar(document.activeElement,document.activeElement,dateformat);
input.value="";
input.focus();
return false;
//return false;
return;
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
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}
var fromdate=opener.document.getElementById('txtdatetime').value;
var todate=input.value;
 
 	//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                var txt=fromdate;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(fromdate!="")
            {
                var txt=fromdate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            fromdate=fromdate;
        }
        
        //For From Date Converssion /************************************************************/
        if(dateformat=="dd/mm/yyyy")
        {
            if(todate != "")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(todate!="")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            todate=todate;
        }
		//
		
		
		
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		if(tdate<fdate && (opener.document.getElementById('hiddenbackdatebook').value=="0" || opener.document.getElementById('hiddenbackdatebook').value=="N"))
		{
		alert("Published Date can't Be Less than Current Date");
		input.value="";
        input.focus();
		return false;
		}
		
returnval=true
 


if (returnval==false) 

input.select()
return returnval

}

function deleteRow()
 {
  try {
          
            var flag =0;
             if(document.getElementById('tblbutton').disabled ==true)
             return false;
            var table = document.getElementById("tblgrid");
            var rowCount = table.rows.length;

        for(var i=1; i<rowCount; i++) {
            var row = table.rows[i];
            var chkbox = row.cells[0].childNodes[0];
              var srno=row.cells[7].childNodes[0].value;
            if(null != chkbox && true == chkbox.checked) 
            {
                 flag=1;
                var schemeid=row.cells[5].childNodes[0].value;
                if(document.getElementById('hiddenchkbtnStatus').value=="new")
                {
                    table.deleteRow(i);
                    rowCount--;
                    i--;
                }
                else
                {
                    if(document.getElementById('hiddenchkbtnStatus').value=="modify" && srno!="")
                    {
                        spliteditionsize.deleteRecord(srno,document.getElementById('hiddeninsertid').value);
                    }
                   table.deleteRow(i);
                  
                   //Scheme_Master_CD.deletegrid(schemeid,document.getElementById('hiddencompcode').value);
                   rowCount--;
                   i--;
                }
            }

        }
        }catch(e) {
            alert(e);
        }
        if(flag==0)
        {
          alert("Please select checkbox for delete row.")
        }
        return false;
  }
  function closepopup()
  {
    window.close();
    return false;
  }
  function saveClick()
  {
  var data="";
      var tableToSort=document.getElementById("tblgrid");
      var rowCount = tableToSort.rows.length;
      var total=0;
        for(var i=1; i<rowCount; i++) {
            var row = tableToSort.rows[i];
            var totalarea = row.cells[5].childNodes[0].value;
            var dateI="";
            dateI = row.cells[1].childNodes[0].value;
            if(dateI=="")
            {
             alert("Please Fill Publish Date for Row No. " + i);
             row.cells[1].childNodes[0].focus();
                return false;
            }
            else if(totalarea=="")
            {
           
                alert("Please Fill Total Area for Row no. " + i);
                return false;
            }
            total=parseFloat(total) + parseFloat(totalarea);
            var daten=row.cells[1].childNodes[0].value;
            if(daten!="")
            {
                if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                {
                    var arr=daten.split("/");
                    daten=arr[1] + "/" + arr[0] + "/" + arr[2];
                }
                else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                {
                    var arr=daten.split("/");
                    daten=arr[0] + "/" + arr[1] + "/" + arr[2];
                }
            }
            if(data=="")
                data= daten + "~"+row.cells[2].childNodes[0].value+"~" +row.cells[3].childNodes[0].value+"~"+row.cells[4].childNodes[0].value+"~"+row.cells[5].childNodes[0].value;
            else
               data= data + "$" + daten + "~"+row.cells[2].childNodes[0].value+"~" +row.cells[3].childNodes[0].value+"~"+row.cells[4].childNodes[0].value+"~"+row.cells[5].childNodes[0].value;     
         }   
     
    if(parseFloat(total)>=parseFloat(document.getElementById('hiddentotalarea').value))
    {
        alert("Size Exceed.");
        return false;
    }  
    if(document.getElementById('hiddenchkbtnStatus').value=="modify")
    {
          for(var i=1; i<rowCount; i++) {
            var row = tableToSort.rows[i];
            var insertid = document.getElementById('hiddeninsertid').value;
            var dateI="";
            dateI = row.cells[1].childNodes[0].value;
            var height="";
            height = row.cells[3].childNodes[0].value;
            var width="";
            width = row.cells[4].childNodes[0].value;
            var totarea="";
            totarea = row.cells[5].childNodes[0].value;
            var srno=row.cells[7].childNodes[0].value;
                 if(dateI!="")
                {
                    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                    {
                        var arr=dateI.split("/");
                        dateI=arr[1] + "/" + arr[0] + "/" + arr[2];
                    }
                    else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                    {
                        var arr=dateI.split("/");
                        dateI=arr[0] + "/" + arr[1] + "/" + arr[2];
                    }
                }
              var res=spliteditionsize.updateData(srno,insertid,height,width,totarea,dateI,document.getElementById('hiddencioid').value,document.getElementById('hiddenreceiptno').value)
            }
    }
    else{
        var splitdata='spltdata'+document.getElementById('hiddenidnum').value;
        opener.document.getElementById(splitdata).value=data;
    }
    window.close();
    return false;
  }
  