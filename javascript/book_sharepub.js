function onpage_load()
{
        document.getElementById("tblgrid").style.display="block";
        var tableToSort=document.getElementById("tblgrid");
        newRow = tableToSort.insertRow();

        //------ Dynamic TABLE  heading-----//
        newRow.className ="dtGridrate";
        newCell = newRow.insertCell();
        newCell.align="center";
        newCell.innerHTML = "Publication";

        newCell = newRow.insertCell();
        newCell.align="center";

        newCell.innerHTML = "Sharing";
        if(document.getElementById('hiddensharepub').value=="")
        {
             var res=booking_sharepub.getPubSharing(document.getElementById('hiddenpackagecode').value,document.getElementById('hiddencompcode').value,document.getElementById('hiddencioid').value);
            if(res.error!=null)
            {
                alert(res.error.description);
                return false;
            }
            var ds=res.value;
            if(ds!=null)
            {
                 if(ds.Tables[0].Rows.length>0 && ds.Tables[0].Rows[0].TYPE!=null)
                {
                    document.getElementById('drpsharingtype').value=ds.Tables[0].Rows[0].TYPE;
                }
                  for(var i=0;i<ds.Tables[0].Rows.length;i++)
                  {
                   
                    newRow = tableToSort.insertRow();
                    newCell = newRow.insertCell();
                    newCell.align="center";
                    newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+ds.Tables[0].Rows[i].PUBLICATION+"' >";
                    
                    newCell = newRow.insertCell();
                    newCell.align="center";
                     if(document.getElementById('hiddeninsertstatus').value=="0")
                     {
                        if(ds.Tables[0].Rows[i].SHARING==null)
                            newCell.innerHTML = "<input type=text  maxLength='8'  class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
                        else
                            newCell.innerHTML = "<input type=text  maxLength='8'  class=btextsmallsize value='"+ds.Tables[0].Rows[i].SHARING+"' onkeypress=\"return rateenter(event);\" >";    
                     }   
                     else{
                         if(ds.Tables[0].Rows[i].SHARING==null)
                            newCell.innerHTML = "<input type=text disabled  maxLength='8'  class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
                        else
                            newCell.innerHTML = "<input type=text disabled  maxLength='8'  class=btextsmallsize value='"+ds.Tables[0].Rows[i].SHARING+"' onkeypress=\"return rateenter(event);\" >";    
                     }    
                }
            }
          }
          else{
            var arr=document.getElementById('hiddensharepub').value.split("$");
            if(arr.length>0)
            {
                document.getElementById('drpsharingtype').value=arr[0].split("~")[2];
            }
             for(var i=0;i<arr.length;i++)
              {
                    newRow = tableToSort.insertRow();
                    newCell = newRow.insertCell();
                    newCell.align="center";
                    newCell.innerHTML = "<input type=text   disabled=true class=btextsmallsize value='"+arr[i].split("~")[0]+"' >";

                    newCell = newRow.insertCell();
                    newCell.align="center";
                    if(document.getElementById('hiddeninsertstatus').value=="0")
                        newCell.innerHTML = "<input type=text  maxLength='8'  class=btextsmallsize value='"+arr[i].split("~")[1]+"' onkeypress=\"return rateenter(event);\" >";
                    else
                        newCell.innerHTML = "<input type=text disbabled  maxLength='8'  class=btextsmallsize value='"+arr[i].split("~")[1]+"' onkeypress=\"return rateenter(event);\" >";    
              }
          }  
        
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
            sharepre = row.cells[1].childNodes[0].value;
            if(sharepre=="")
            {
             alert("Please Fill Sharing for Row No. " + i);
             row.cells[1].childNodes[0].focus();
                return false;
            }
            total=parseFloat(sharepre) + parseFloat(total);
            if(data=="")
                data= row.cells[0].childNodes[0].value + "~" + sharepre+"~"+document.getElementById('drpsharingtype').value;
            else
                data= data + "$" + row.cells[0].childNodes[0].value +"~"+ sharepre+"~"+document.getElementById('drpsharingtype').value;    
        }
        if(document.getElementById('hiddenagreedamt').value!="" && document.getElementById('hiddenagreedamt').value!="0" && parseFloat(document.getElementById('hiddenagreedamt').value)!=parseFloat(total))
        {
            alert("Sharing Amount should be equal to Agreed Amount");  
            return false; 
        }
        opener.sharepub=data;
        opener.document.getElementById('txtgrossamt').value="";
        if(opener.document.getElementById('txtbillamt')!=null)
            opener.document.getElementById('txtbillamt').value="";
         if(opener.document.getElementById('txttotalamt')!=null)
            opener.document.getElementById('txttotalamt').value="";    
        window.close();
        return false;
  }