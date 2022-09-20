// JScript File

function printreceipt()
{
   
     var ds_mode="";
     var paymode="";
     var recptno=document.getElementById('txtrecpt').value;
     var res=Receipt_Form.getcioid(recptno);
     var ds =res.value;
    if(ds != null)
    {
      if(ds.Tables[0].Rows.length > 0)
        var cioid= ds.Tables[0].Rows[0].CIOID;
    }
   // var cioid='AUR2011ADM00161767'; //document.getElementById('hiddencioid').value;
   /*var paymode=document.getElementById('hiddenpaymode').value;
    var clientname=document.getElementById('hiddenclientname').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var rcptno=document.getElementById('hiddenreceiptno').value;
   
    if(clientname.indexOf("(")>=0)
    {
         clientname=clientname.split("(");
         client_split=clientname[1];
         client_split=client_split.replace(")","");
         clientname=client_split;
         ds_mode=Receipt_Form.getclientinfo(compcode,clientname);  
    } 
    else
       ds_mode=Receipt_Form.getclientinfo(compcode,clientname); 
       */
     var  cls_matter="";
    if(cioid!="")
    {
        if(ds_mode==undefined || ds_mode=="")
          window.open('classifiedreceipt_bill.aspx?cioid='+cioid+'&clsmatter='+cls_matter,'','width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        else
        {
            if(paymode=="Cash" || paymode=="CASH" || paymode=="cash")
                window.open('classifiedreceipt_bill.aspx?cioid='+cioid+'&clsmatter='+cls_matter,'','width=700px,height=550px,resizable=1,left=0,top=0,menubar=yes,scrollbars=yes');
                
            else
                window.open('Receiptonly.aspx?cioid='+cioid+'&rcptno='+rcptno+'&compcode='+compcode,'','width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        }
    }    
    else
    {
         alert("Please get the Booking id");
    }
    return false;
}