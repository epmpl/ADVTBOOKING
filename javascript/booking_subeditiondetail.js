var insdate = "";
var xmlDoc=null;
var xmlObj=null;
var insertstatus="";
var req=null;
function closeWinForm()
{
    window.close();
    return false;
}
function bindSubedition()
{
    document.getElementById("trid").style.display="block";
    document.getElementById("tblgrid").style.display="block";
    var tableToSort = document.getElementById("tblgrid");
    var blankdtmod="";
    var fielddisable="";
   
    if(document.getElementById('txtdata').value=="") {
        
        var res=booking_subeditiondetail.fetchEdition(document.getElementById('txtedition').value,document.getElementById('txtcompcode').value,document.getElementById('hiddeninsertid').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddenpackage').value);
        if(res.value!=null) {            
            var ds = res.value;
            
            if(ds!= null && typeof(ds) == "object" && ds.Tables.length>0 && ds.Tables[0].Rows.length > 0) 
            {
               //=========To fill Follow Date at modified time
               if(document.getElementById('hiddeninsertstatus').value=="billed")
               for(var i=0;i<ds.Tables[0].Rows.length;i++)
                { 
                 if(ds.Tables[0].Rows[i].INSERTDATE=="null" || ds.Tables[0].Rows[i].INSERTDATE==null){
                    blankdtmod="1";
                    fielddisable="disabled=true";
                    break;
                    }
                }
                //=====================================//
                newRow = tableToSort.insertRow(0);                
                    //------ Dynamic TABLE  heading-----//                  
                newCell = newRow.insertCell(0);
                newCell.align="center";
                newCell.innerHTML = "Edition";
                
                newCell = newRow.insertCell(1);
                newCell.align="center";
                newCell.innerHTML = "Date";
                                   
                newCell = newRow.insertCell(2);
                newCell.align="center";
                newCell.innerHTML = "Height";
                
                newCell = newRow.insertCell(3);
                newCell.align="center";
                newCell.innerHTML = "Width";
              
                newCell = newRow.insertCell(4);
                newCell.align="center";
                newCell.innerHTML = "Total Area";

                newCell = newRow.insertCell(5);
                newCell.align = "center";
                newCell.innerHTML = "Page No.";
                      
                newRow.className ="dtGridrate";
                newCell = newRow.insertCell(6);
                newCell.align="center";
                newCell.innerHTML = "Insert Status";
                for(var i=0;i<ds.Tables[0].Rows.length;i++)
                {     
                    newRow = tableToSort.insertRow(i+1);                                            
                    newCell = newRow.insertCell(0);
                    newCell.align="center";
                    if(document.getElementById('hiddeninsertid').value!="" && document.getElementById('hiddeninsertid').value!="0")
                        newCell.innerHTML = "<input style='text-align:left; width:200px;' type=text  disabled=true class=btextsmallsizeE value='" + ds.Tables[0].Rows[i].EDITION + "' >";
                    else
                        newCell.innerHTML = "<input style='text-align:left; width:200px;' type=text   disabled=true class=btextsmallsizeE  value='" + ds.Tables[0].Rows[i].Edition + "' >";  
                        
                    newCell = newRow.insertCell(1);
                    newCell.align="center";
                    if (document.getElementById('hiddeninsertid').value == "" || document.getElementById('hiddeninsertid').value == "0") {
                        if(document.getElementById('txtinsertdate').value== "null" || document.getElementById('txtinsertdate').value==null)
                            insdate = "";
                        else
                            insdate = document.getElementById('txtinsertdate').value;
                        newCell.innerHTML = "<input type=text maxLength='20' value='" + insdate + "' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >"; //document.getElementById("txtfrminsert").value;
                    }
                    else {
                        if(ds.Tables[0].Rows[i].INSERTDATE=="null" || ds.Tables[0].Rows[i].INSERTDATE==null)
                        {
                            insdate = "";
                            newCell.innerHTML = "<input type=text maxLength='20' value='" + insdate + "' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >"; //document.getElementById("txtfrminsert").value;  
                        }
                        else
                        {
                            if(ds.Tables[0].Rows[i].INSERTSTATUS!="booked"&&ds.Tables[0].Rows[i].INSERTSTATUS!="hold")
                        {
                          insdate = ds.Tables[0].Rows[i].INSERTDATE;
                            newCell.innerHTML = "<input  disabled type=text maxLength='20' value='" + insdate + "' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >"; //document.getElementById("txtfrminsert").value;  
                        }
                        else
                        {
                          insdate = ds.Tables[0].Rows[i].INSERTDATE;
                            newCell.innerHTML = "<input   type=text maxLength='20' value='" + insdate + "' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\"  onblur=\"return checkdate(this)\" >"; //document.getElementById("txtfrminsert").value;  
                        }
                        }
                        
                    }
                    
                    newCell = newRow.insertCell(2);
                    newCell.align="center";
                    if(ds.Tables[0].Rows[i].HEIGHT==null)
                        ds.Tables[0].Rows[i].HEIGHT="";
                    if(ds.Tables[0].Rows[i].WIDTH==null)
                        ds.Tables[0].Rows[i].WIDTH = "";
                    if (ds.Tables[0].Rows[i].PAGE_NO == null)
                        ds.Tables[0].Rows[i].PAGE_NO = "";
                    if (document.getElementById('hiddenpageno').value == null)
                        document.getElementById('hiddenpageno').value = "";
                    if(document.getElementById('hiddeninsertid').value=="" || document.getElementById('hiddeninsertid').value=="0")
                    {
                        if(document.getElementById('hiddenuomdesc').value=="CD")
                            newCell.innerHTML = "<input style='text-align:left;width:50px;' type=text  maxLength='5' value='" + document.getElementById('txtheight').value + "'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";
                        else
                            newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  maxLength='5' disabled value='" + document.getElementById('txtheight').value + "'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";    
                       }     
                      else
                      {
                          if(ds.Tables[0].Rows[i].INSERTSTATUS!="booked" &&ds.Tables[0].Rows[i].INSERTSTATUS!="hold")
                        {
                          if(document.getElementById('hiddenuomdesc').value=="CD")
                              newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px ;'type=text disabled  maxLength='5' value='" + ds.Tables[0].Rows[i].HEIGHT + "'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";  
                          else
                              newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px ;'type=text  disabled maxLength='5' value='" + ds.Tables[0].Rows[i].HEIGHT + "'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";    
                         }
                         else
                         {
                         
                         if(document.getElementById('hiddenuomdesc').value=="CD")
                              newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px ;'type=text   maxLength='5' value='" + ds.Tables[0].Rows[i].HEIGHT + "'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";  
                          else
                              newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px ;'type=text  disabled maxLength='5' value='" + ds.Tables[0].Rows[i].HEIGHT + "'   class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\" >";    
                         }
                      }  
                    
                    newCell = newRow.insertCell(3);
                    newCell.align="center";
                    if(document.getElementById('hiddeninsertid').value=="" || document.getElementById('hiddeninsertid').value=="0")
                    {
                        if(document.getElementById('hiddenuomdesc').value=="CD")
                            newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  maxLength='5' value='" + document.getElementById('txtwidth').value + "'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; // 
                        else
                            newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  maxLength='5' disabled value='" + document.getElementById('txtwidth').value + "'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; //         
                    }        
                    else
                    {
                        if(ds.Tables[0].Rows[i].INSERTSTATUS!="booked" &&ds.Tables[0].Rows[i].INSERTSTATUS!="hold")
                        {
                        if(document.getElementById('hiddenuomdesc').value=="CD")
                            newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px;' type=text disabled maxLength='5' value='" + ds.Tables[0].Rows[i].WIDTH + "'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; //   
                        else
                            newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px;' type=text disabled maxLength='5' value='" + ds.Tables[0].Rows[i].WIDTH + "'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; //   
                            }
                            else
                            {
                             if(document.getElementById('hiddenuomdesc').value=="CD")
                            newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px;' type=text  maxLength='5' value='" + ds.Tables[0].Rows[i].WIDTH + "'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; //   
                        else
                            newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px;' type=text disabled maxLength='5' value='" + ds.Tables[0].Rows[i].WIDTH + "'  class=btextsmallsize onkeypress=\"return rateenter(event);\" onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; //   
                            }  
                    }  
                    newCell = newRow.insertCell(4);
                    newCell.align="center";
                    if(document.getElementById('hiddeninsertid').value=="" || document.getElementById('hiddeninsertid').value=="0")
                        newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  disabled=true value='" + document.getElementById('txttotarea').value + "' class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
                    else
                        newCell.innerHTML = "<input style='text-align:left; width:50px ;'type=text  disabled=true value='" + ds.Tables[0].Rows[i].TOTALAREA + "' class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
                        //New column for Page no..
                    newCell = newRow.insertCell(5);
                    newCell.align = "center";
                     if (document.getElementById('hiddeninsertid').value == "" || document.getElementById('hiddeninsertid').value == "0")
                    {
                        newCell.innerHTML = "<input  style='text-align:left; width:50px;'type=text   value='" + document.getElementById('hiddenpageno').value + "' class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
                        }
                    else
                    {
                    if(ds.Tables[0].Rows[i].INSERTSTATUS!="booked" &&ds.Tables[0].Rows[i].INSERTSTATUS!="hold")
                        {
                        newCell.innerHTML = "<input  disabled style='text-align:left;width:50px;' type=text  value='" + ds.Tables[0].Rows[i].PAGE_NO + "' class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";  
                         }
                         else
                         {
                          newCell.innerHTML = "<input "+fielddisable+" style='text-align:left;width:50px;' type=text  value='" + ds.Tables[0].Rows[i].PAGE_NO + "' class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";  
                         
                         }
                    
                    }
                    
                    newCell = newRow.insertCell(6);
                    newCell.align="center";
                    if(document.getElementById('hiddeninsertid').value=="" || document.getElementById('hiddeninsertid').value=="0")
                    {
//                        if(document.getElementById('hiddenuomdesc').value=="CD" &&  ds.Tables[1].Rows[0].Combin_Desc.indexOf('+')<=0)
//                            newCell.innerHTML = "<input type=checkbox checked=true >";
//                        else
//                            newCell.innerHTML = "<input type=checkbox>";  
                            newCell.innerHTML = "<input  style='text-align:left; width:50px;'type=text id='inssta_" + i + "'  value='" + document.getElementById('hiddeninsertstatus').value + "' class=btextsmallsize onkeydown=\"javascript:return f2bindinsert(event);\"  >";  
                    }  
                    else
                    {
                      if(ds.Tables[0].Rows[i].INSERTSTATUS!="booked" &&ds.Tables[0].Rows[i].INSERTSTATUS!="hold")
                        {
                       newCell.innerHTML = "<input disabled style='text-align:left; width:50px;'type=text id='inssta_" + i + "'  value='" + ds.Tables[0].Rows[i].INSERTSTATUS + "' class=btextsmallsize onkeydown=\"javascript:return f2bindinsert(event);\"  >";  
                           }
                           else
                           {
                           newCell.innerHTML = "<input  style='text-align:left; width:50px;'type=text id='inssta_" + i + "'  value='" + ds.Tables[0].Rows[i].INSERTSTATUS + "' class=btextsmallsize onkeydown=\"javascript:return f2bindinsert(event);\"  >";  
                           }
                       
//                        if(ds.Tables[0].Rows[i].INSERTSTATUS=="cancel")
//                            newCell.innerHTML = "<input  "+fielddisable+"  type=checkbox checked=true>";
//                        else
//                            newCell.innerHTML = "<input  "+fielddisable+"  type=checkbox>"; 
      
                    }    
                     if(ds.Tables[0].Rows[i].INSERTSTATUS=="booked")
                    {
                    insertstatus="booked";
                    
                    }                    
                    newCell = newRow.insertCell(7);
                    newCell.align="center";
                    newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+document.getElementById('hiddeninsertid').value+"' class=btextsmallsize  >";
                    newCell = newRow.insertCell(8);
                    newCell.align="center";
                    if(document.getElementById('hiddeninsertid').value=="")
                        newCell.innerHTML = "<input type=text style=\"display:none;\" class=btextsmallsize  >";
                    else
                        newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+ds.Tables[0].Rows[i].SRNO+"' class=btextsmallsize  >";
                }  
            }
        }
    }
    else{
        newRow = tableToSort.insertRow(0);
        var arr1=document.getElementById('txtdata').value.split("$");
       //------ Dynamic TABLE  heading-----//
       
        newCell = newRow.insertCell(0);
        newCell.align="center";
        newCell.innerHTML = "Edition";
        newCell = newRow.insertCell(1);
        newCell.align="center";
         
        newCell.innerHTML = "Date";        
        newCell = newRow.insertCell(2);
        newCell.align="center";
        newCell.innerHTML = "Height";
        newCell = newRow.insertCell(3);
        newCell.align="center";
        newCell.innerHTML = "Width";
          
        newCell = newRow.insertCell(4);
        newCell.align="center";
        newCell.innerHTML = "Total Area";

        newCell = newRow.insertCell(5);
        newCell.align = "center";
        newCell.innerHTML = "Page No.";
          
        newRow.className ="dtGridrate";
        newCell = newRow.insertCell(6);
        newCell.align="center";
        newCell.innerHTML = "Insert Status";
        for(var i=0;i<arr1.length;i++)
        {
            var arr=arr1[i].split("~");
            newRow = tableToSort.insertRow(i+1);
            newCell = newRow.insertCell(0);
            newCell.align="center";
            newCell.innerHTML = "<input style='text-align:left; width:200px;' type=text  disabled=true class=btextsmallsizeE value='" + arr[0].toString() + "' >";
                      
           var dateI="";           
                            if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
                {
                    var arr34=arr[1].toString().split("/");
                  if(arr34.length>1)
                        dateI=arr34[1] + "/" + arr34[0] + "/" + arr34[2];
                }
                      
            newCell = newRow.insertCell(1);
            newCell.align="center";
            newCell.innerHTML = "<input type=text maxLength='20' class=btextsmallsize1_k onkeypress=\"return datecurr(event);\" value='"+dateI+"'  onblur=\"return checkdate(this)\" >";//document.getElementById("txtfrminsert").value;
                      
            newCell = newRow.insertCell(2);
            newCell.align="center";
            if(document.getElementById('hiddenuomdesc').value=="CD")
                newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" value='" + arr[2].toString() + "' onblur=\"return getTotal(this.parentNode.parentNode)\" >";
            else
                newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text disabled maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\" value='" + arr[2].toString() + "' onblur=\"return getTotal(this.parentNode.parentNode)\" >"; 
            newCell = newRow.insertCell(3);
            newCell.align="center";
            if(document.getElementById('hiddenuomdesc').value=="CD")
                newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\"  value='" + arr[3].toString() + "' onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; // 
            else
                newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text disabled maxLength='5'  class=btextsmallsize onkeypress=\"return rateenter(event);\"  value='" + arr[3].toString() + "' onblur=\"return getTotal(this.parentNode.parentNode)\"  >"; //  
                      
            newCell = newRow.insertCell(4);
            newCell.align="center";
            newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text  disabled=true class=btextsmallsize value='" + arr[4].toString() + "' onkeypress=\"return rateenter(event);\"  >";

            newCell = newRow.insertCell(5);
            newCell.align = "center";
            newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text   class=btextsmallsize value='" + arr[5].toString() + "' onkeypress=\"return rateenter(event);\"  >";
                       
            newCell = newRow.insertCell(6);
            newCell.align="center";
            newCell.innerHTML = "<input style='text-align:left; width:50px;' type=text id='inssta_" + i + "'   class=btextsmallsize value='" + arr[6].toString() + "' onkeydown=\"javascript:return f2bindinsert(event);\"  >";
//            if(arr[6].toString()=="cancel")
//                newCell.innerHTML = "<input type=checkbox   checked=true >";
//            else
//            {
//                newCell.innerHTML = "<input type=checkbox>";        
//            }
                      
            newCell = newRow.insertCell(7);
            newCell.align="center";
            newCell.innerHTML = "<input type=text style=\"display:none;\" value='"+document.getElementById('hiddeninsertid').value+"' class=btextsmallsize  >";
              
            newCell = newRow.insertCell(8);
            newCell.align="center";
            newCell.innerHTML = "<input type=text style=\"display:none;\" class=btextsmallsize  >";
        }   
    }
         
    tableToSort.disabled=true;
    document.getElementById('btnok').disabled=true;
    if(document.getElementById('hiddenchkbtnStatus').value=="new" || ((insertstatus="booked"||document.getElementById('hdnchkdetailperm').value=="Y"||document.getElementById('hiddeninsertstatus').value=="booked" || blankdtmod=="1") && document.getElementById('hiddenchkbtnStatus').value=="modify"))
    {
        tableToSort.disabled=false;
        document.getElementById('btnok').disabled=false;
    }  
    return false;
}
function getTotal(name)
{
    try {
        var table = document.getElementById("tblgrid");
        var rowCount = table.rows.length;
        var rowindex=parseInt(name.rowIndex);
        var row1 = table.rows[rowindex];
            var height =row1.cells[2].childNodes[0].value;
            var width =  row1.cells[3].childNodes[0].value;
            if(height!="" && width!="")
            {
                row1.cells[4].childNodes[0].value = parseFloat(height) * parseFloat(width);
            }
            // for checking maximize sie
 /*     var rowCount = table.rows.length;
      var total=0;
        for(var i=1; i<rowCount; i++) {
            var row = table.rows[i];
            var totalarea = row.cells[5].childNodes[0].value;
            if(totalarea!="")
                total=parseFloat(total) + parseFloat(totalarea);
         }   
     */
//    if(parseFloat(total)>parseFloat(document.getElementById('hiddentotalarea').value))
//    {
//        row1.cells[5].childNodes[0].value ="";
//          row1.cells[4].childNodes[0].value ="";
//           row1.cells[3].childNodes[0].value ="";
//        row1.cells[3].childNodes[0].focus();
//        alert("Size Exceed.");
//        return false;
//    }
    
     }catch(e) {
    alert(e);
}
}
function checkdate(input) {
    var flagret = "T";
    var dateformat = document.getElementById('hiddendateformat').value;
    //==================To enter Date Without "/" ============================//
    var dateInitial = "20";
    var dateenter = input.value;
    if (dateenter.indexOf('/') < 0) {
        var date12 = "";
        flagret = "F";
        if (dateformat == "mm/dd/yyyy") {
            if (dateenter.length >= "8")
                date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateenter.substring(4, 8);
            else if (dateenter.length >= "6")
                date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateInitial + dateenter.substring(4, 6);
            else
                date12 = input.value;
        }
        if (dateformat == "yyyy/mm/dd") {
            if (dateenter.length >= "8")
                date12 = dateenter.substring(0, 4) + "/" + dateenter.substring(4, 6) + "/" + dateenter.substring(6, 8);
            else if (dateenter.length >= "6")
                date12 = dateInitial + dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateenter.substring(4, 6);
            else
                date12 = input.value;
        }
        if (dateformat == "dd/mm/yyyy") {
            if (dateenter.length >= "8")
                date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateenter.substring(4, 8);
            else if (dateenter.length >= "6")
                date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateInitial + dateenter.substring(4, 6);
            else
                date12 = input.value;
        }
        input.value = date12;
    }
    //==============================================================================//
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
//return returnval//****Changed by Kuldeep Bhati
if (flagret == "F")
    return false;
else
    return returnval;
}
// for saving data
 function saveClick()
  {
  var data="";
      var tableToSort=document.getElementById("tblgrid");
      var rowCount = tableToSort.rows.length;
      var total=0;
        for(var i=1; i<rowCount; i++) {
            var row = tableToSort.rows[i];
            var totalarea = row.cells[4].childNodes[0].value;
            var insstat = row.cells[6].childNodes[0].value;
            var dateI="";
            dateI = row.cells[1].childNodes[0].value;
            if (dateI == "" && document.getElementById("hdnfollodate1").value == "N")
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
            else if(insstat=="" || insstat=="0")
            {
           
                alert("Please Fill Insert Status for Row no. " + i);
                return false;
            }
            total=parseFloat(total) + parseFloat(totalarea);
            var daten=row.cells[1].childNodes[0].value;
            if(daten!="")
            {
                if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
                {
                    var arr=daten.split("/");
                   // daten=arr[1] + "/" + arr[0] + "/" + arr[2];
                    dateI=arr[1] + "/" + arr[0] + "/" + arr[2];
                }
                else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                {
                    var arr=daten.split("/");
                  //  daten=arr[0] + "/" + arr[1] + "/" + arr[2];
                   dateI=arr[1] + "/" + arr[2] + "/" + arr[0];
                }
            }
//             var chkbox = row.cells[6].childNodes[0];
               var insstatus=row.cells[6].childNodes[0].value;
//             var insstatus=document.getElementById('hiddeninsertstatus').value;
//             if(null != chkbox && true == chkbox.checked) 
//            {
//                insstatus="cancel";
//            }
            if(data=="")
                data = row.cells[0].childNodes[0].value + "~" + dateI + "~" + row.cells[2].childNodes[0].value + "~" + row.cells[3].childNodes[0].value + "~" + row.cells[4].childNodes[0].value + "~" + row.cells[5].childNodes[0].value + "~" + insstatus;
            else
                data = data + "$" + row.cells[0].childNodes[0].value + "~" + dateI + "~" + row.cells[2].childNodes[0].value + "~" + row.cells[3].childNodes[0].value + "~" + row.cells[4].childNodes[0].value + "~" + row.cells[5].childNodes[0].value + "~" + insstatus;     
         }   
//     
//    if(parseFloat(total)>=parseFloat(document.getElementById('hiddentotalarea').value))
//    {
//        alert("Size Exceed.");
//        return false;
//    }  
    if(document.getElementById('hiddenchkbtnStatus').value=="modify")
    {
         
        var insertid = document.getElementById('hiddeninsertid').value;
          for(var i=1; i<rowCount; i++) {
            var row = tableToSort.rows[i];
            var dateI="";
            var edition= row.cells[0].childNodes[0].value;
            var insstatus=row.cells[6].childNodes[0].value;
//            var chkbox = row.cells[6].childNodes[0];
//            var insstatus=document.getElementById('hiddeninsertstatus').value;
//             if(null != chkbox && true == chkbox.checked) 
//            {
//                insstatus="cancel";
//            }
            dateI = row.cells[1].childNodes[0].value;
            var height="";
            height = row.cells[2].childNodes[0].value;
            var width="";
            width = row.cells[3].childNodes[0].value;
            var totarea="";
            totarea = row.cells[4].childNodes[0].value;
            var srno = row.cells[8].childNodes[0].value;
            var pageno = row.cells[5].childNodes[0].value;
//                 if(dateI!="")
//                {
//                    if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
//                    {
//                        var arr=dateI.split("/");
//                       // dateI=arr[1] + "/" + arr[0] + "/" + arr[2];
//                        dateI=arr[1] + "/" + arr[0] + "/" + arr[2];
//                    }
//                    else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
//                    {
//                        var arr=dateI.split("/");
//                       // dateI=arr[0] + "/" + arr[1] + "/" + arr[2];
//                        dateI=arr[1] + "/" + arr[2] + "/" + arr[0];
//                    }
//                }
            if(insertid!="" && insertid !="0")
            {
             //  data="";
               var res = booking_subeditiondetail.updateData(srno, insertid, height, width, totarea, dateI, edition, document.getElementById('hiddenreceipt').value, document.getElementById('hiddendateformat').value, insstatus, pageno);
            }
        }
    }
//    else{
    if(data != "" && data != null){
        var splitdata='subedidata'+document.getElementById('hiddenidnum').value;
        opener.document.getElementById(splitdata).value=data;
        }
//    }
    window.close();
    return false;
  }
  function f2bindinsert(event) {
   var key1 = event.keyCode ? event.keyCode : event.which;
   if(key1 == 113){
    activeid = document.activeElement.id;
     id = activeid.split("_")
    var id1 = id[0];
    var id2 = id[1];
    var divid = "agdiv";
    var listboxid = "aglist";
    var objadscat = document.getElementById(listboxid);
    objadscat.options.length = 0;
    objadscat.options[0] = new Option("-Select-", "0");
     var c=1;
        var b = 0;
    if (browser != "Microsoft Internet Explorer") {
    loadXML("xml/billcycle.xml");
        for (b = 1; b <= xmlObj.childNodes[19].childNodes.length - 1; ) {
            objadscat.options[c] = new Option(xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[19].childNodes[b + 2].childNodes[0].nodeValue);
            b = b + 4;
            c = c + 1;
        }
    }
    else {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        loadXML("xml/billcycle.xml");
        for (b = 0; b <= xmlObj.childNodes(9).childNodes.length - 1; b++) {
            objadscat.options[c] = new Option(xmlObj.childNodes[9].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[9].childNodes[b + 1].childNodes[0].nodeValue);
            b = b + 1;
            c = c + 1;
        }
    }
    objadscat.options.length;
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

    var tot = document.getElementById('inssta_' + id2).scrollLeft;

    var scrolltop = document.getElementById('inssta_' + id2).scrollTop;

    document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
    document.getElementById(activeid).style.backgroundColor = "#FFFF80";
    document.getElementById(divid).style.display = "block";
    document.getElementById(listboxid).focus();

}
}
function loadXML(xmlFile) {
    var httpRequest = null;
    if (browser != "Microsoft Internet Explorer") {
        req = new XMLHttpRequest();
//        req.onreadystatechange = getMessage;
        req.open("GET", xmlFile, false);
        req.send('');
        xmlDoc=req.responseXML; 
        xmlObj = xmlDoc.documentElement;
    }
    else {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.onreadystatechange = verify;
        xmlDoc.load(xmlFile);
        xmlObj = xmlDoc.documentElement;
    }

}
function verify() {
    // 0 Object is not initialized 
    // 1 Loading object is loading data 
    // 2 Loaded object has loaded data 
    // 3 Data from object can be worked with 
    // 4 Object completely initialized 
    if (xmlDoc.readyState != 4) {
        return false;
    }
}
function fillinsert(event) {
    var key1 = event.keyCode ? event.keyCode : event.which;

    if (key1 == 13 || event.type == "click") {
        if (document.activeElement.id == "aglist") {
            if (document.getElementById('aglist').value == "0") {
                alert("Please select Insert Status");
                return false;
            }

            var page = document.getElementById('aglist').value;
            agencycodeglo = page;
            if (browser != "Microsoft Internet Explorer") {

                for (var k = 0; k <= document.getElementById("aglist").length - 1; k++) {

                    if (document.getElementById('aglist').options[k].value == page) {

//                        var abc = document.getElementById('aglist').options[k].textContent;
//                        document.getElementById(activeid).value = abc;
//                        var splitpub = abc;
//                        var str = splitpub.split("--");
//                        var pubcode = str[0];
//                        var pubspace = str[1];
                        var split = activeid.split('_');
                        document.getElementById("hiddeninsertstatus").value = page;
                        document.getElementById('inssta_' + split[1]).value = page;
                        //                        document.getElementById('hdnunit_center').value = pubspace;
                        //                        document.getElementById('hdnunit').value = pubspace;
                        document.getElementById(activeid).focus();
                        break;
                    }
                }
            }
            else {
                for (var k = 0; k <= document.getElementById("aglist").length - 1; k++) {


                    if (document.getElementById('aglist').options[k].value == page) {
                        var abc = document.getElementById('aglist').options[k].innerText;

//                        document.getElementById(activeid).value = abc;
//                        var splitpub = abc;
//                        var str = splitpub.split("--");
//                        var pubcode = str[0];
//                        var pubspace = str[1];

                        var split = activeid.split('_');
                        document.getElementById("hiddeninsertstatus").value = page;
                        document.getElementById('inssta_' + split[1]).value = page;
                        //                        document.getElementById('hdnunit_center').value = pubspace;
                        //                        document.getElementById('hdnunit').value = pubspace;
                        document.getElementById(activeid).focus();
                        //  document.getElementById('txtmaingrname').value=fival[0];

                    }
                }
            }
            document.getElementById("agdiv").style.display = 'none';
            //  document.getElementById("txtmaingrcode").focus();
            return false;
        }
    }
    else if (key1 == 27) {
    document.getElementById(activeid).focus();
        document.getElementById("agdiv").style.display = 'none';
        return false;
    }



}