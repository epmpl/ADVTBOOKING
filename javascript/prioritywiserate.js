 function rateenter(event)
{
//alert(event.keyCode);
    if(document.all)
    {
        if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9) ||(event.keyCode==190))
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
        if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
function loadPages()
{
if(document.getElementById('hidpriorityrateval').value=="")
{
    var pkgdesc=document.getElementById('hidpkgdesc').value;
    var priority=document.getElementById('hidpriorityrate').value;
    var res=prioritywiserate.getEditionDetail(pkgdesc);
    if(res.error!=null)
    {
        alert(res.error.description);
        return false;
    }
    var ds=res.value;
    var tableToSort=document.getElementById("tblgrid");
     newRow = tableToSort.insertRow();
        newCell = newRow.insertCell();  
        newCell.align="center";
        newCell.innerHTML = "<div class=btextsmallsize>Edition Name</div>";
        for(var j=0;j<parseInt(priority);j++)
        {
              newCell = newRow.insertCell();  
              newCell.align="center";
              var n=parseInt(j,10)+1;
              newCell.innerHTML ="<div class=btextsmallsize>Pri. "+ n.toString()+"</div>";
              newCell = newRow.insertCell();  
              newCell.align="center";
              newCell.innerHTML ="<div class=btextsmallsize>Extra Rate</div>";
        }
    for(var i=0;i<ds.Tables[0].Rows.length;i++)
    {
        var newRow = tableToSort.insertRow();
        newCell = newRow.insertCell();  
        newCell.align="center";
        newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+ds.Tables[0].Rows[i].EDITION_NAME+"' >";
        for(var j=0;j<parseInt(priority);j++)
        {
              newCell = newRow.insertCell();  
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
              
              newCell = newRow.insertCell();  
              newCell.align="center";
              newCell.innerHTML = "<input type=text class=btextsmallsize onkeypress=\"return rateenter(event);\"  >";
        }
    }
   }
   else{
     var tableToSort=document.getElementById("tblgrid");
     var arr=document.getElementById('hidpriorityrateval').value.split("$");
     var arr1;
     if(arr.length>0)
     {
        arr1=arr[0].split("~");
     
     newRow = tableToSort.insertRow();
        newCell = newRow.insertCell();  
        newCell.align="center";
        newCell.innerHTML = "<div class=btextsmallsize>Edition Name</div>";
        var t=0;
        for(var j=0;j<parseInt(arr1.length,10)-1;j++)
        {
               t=parseInt(t,10)+1;
              newCell = newRow.insertCell();  
              newCell.align="center";
              var j=parseInt(j,10)+1;
              newCell.innerHTML ="<div class=btextsmallsize>"+ t.toString()+"</div>";
              newCell = newRow.insertCell();  
              newCell.align="center";
              newCell.innerHTML ="<div class=btextsmallsize>Extra Rate</div>";
        }
    }    
    for(var i=0;i<arr.length;i++)
    {
        var   arr1=arr[i].split("~");
        var newRow = tableToSort.insertRow();
        newCell = newRow.insertCell();  
        newCell.align="center";
        newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+arr1[0].toString()+"' >";
       for(var j=0;j<parseInt(arr1.length,10)-1;j++)
        {
              newCell = newRow.insertCell();  
              newCell.align="center";
               var n=parseInt(j,10)+1;
              newCell.innerHTML = "<input type=text class=btextsmallsize value="+arr1[n].toString()+" onkeypress=\"return rateenter(event);\"  >";
              j=parseInt(j,10)+1;
              newCell = newRow.insertCell();  
              newCell.align="center";
               var n=parseInt(j,10)+1;
              newCell.innerHTML = "<input type=text class=btextsmallsize value="+arr1[n].toString()+" onkeypress=\"return rateenter(event);\"  >";
        }
    }
   }
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
            var dateI="";
            var priority=document.getElementById('hidpriorityrate').value;
            var edition=row.cells[0].childNodes[0].value;
            if(data=="")
                data= edition;
            else
                data= data + "$" + edition; 
            for(j=1;j<=parseInt(priority,10)*2;j++)
            {
            dateI = row.cells[j].childNodes[0].value;
                if(dateI=="")
                {
                 alert("Please Fill Priority Rate for Edition " + edition);
                 row.cells[1].childNodes[0].focus();
                    return false;
                }
                else{
                    data= data + "~"+dateI;     
               }     
             }
         }   
     
    if(document.getElementById('hiddenchkbtnStatus').value=="modify")
    {
        //  for(var i=1; i<rowCount; i++) {
         //   var row = tableToSort.rows[i];
          
        //  var edition = row.cells[0].childNodes[0].value;
          
              var res=prioritywiserate.insert_priority_rate(document.getElementById('hidrateid').value,data);
              opener.document.getElementById('hiddenpriorityrates').value=data;
           // }
    }
    else{
        
        opener.document.getElementById('hiddenpriorityrates').value=data;
    }
    window.close();
    return false;
  }
  function cancelClick()
  {
    window.close();
  }