// JScript File
function logsubmitclick()
{  // document.getElementById('DataGrid2').style.display="block";
     if(document.getElementById('drptabname').options.length=="0" || document.getElementById('drptabname').value=="0")
      {
      alert("Please Select Table Name ");
      document.getElementById('drptabname').focus();
      document.getElementById('DataGrid2').style.display="none";
      return false;
      }
 // check date validation
 /*if(document.getElementById('txtdate').value != "")
 {
 if(document.getElementById('hiddendateformat').value="dd/mm/yyyy")
 {
 date2=date1.split("/")[1] + '/' + date1.split("/")[0] + '/' + date1.split("/")[2];
 }
 else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
 {
 date2=date1.split("/")[1] + '/' + date1.split("/")[2] + '/' + date1.split("/")[0];
 }
 else if(document.getElementById('hiddendateformat').value="mm/dd/yyyy")
 {
 date2=document.getElementById('txtdate').value; 
 }
 }
 else
 date2=document.getElementById('txtdate').value; 
 LogView.logexecute(compcode,tabname,trxtype,username,date2);*/
 //return false;
 }
 function callexec(responce)
 {
 if(responce.error!=null)
    {
        alert("ERROR : \n"+responce.error.description);
        return false;
    }
    gdsexecute=responce.value;
    if(gdsexecute == null)
    {
    alert("Your Search Produces No Result");
    return false;
    }
    else
    document.getElementById('txttabname').value=document.getElementById('drptabname').value; 
   // tabcol=gdsexecute.Tables[0].Rows.length;
   // GridView1.DataSource = gdsexecute.Tables[0];
       // GridView1.DataBind();
 }