// JScript File
function checkBillExist()
{
    var res = billNoRevised.checkBillExist(document.getElementById('txtbill').value, document.getElementById('hiddencomcode1').value);
      if(res.value==null)
      {
            alert(res.error.description);
            return false;
      }
    else
    {
        var ds=res.value;
        if(ds.Tables[0].Rows.length>0) {
            if (ds.Tables[0].Rows[0].SUPPLIMENTARY_BILL_REQ != "O") {
                var res1 = billNoRevised.insertintoTempBooking(document.getElementById('txtbill').value, ds.Tables[0].Rows[0].cio_booking_id);
                if (res1.error != null) {
                    alert(res1.error.description);
                    return false;
                }
                var cioidnew = ds.Tables[0].Rows[0].cio_booking_id + "-" + document.getElementById('txtbill').value;
//                if (ds.Tables[0].Rows[0].Ad_type_code == "DI0") {
//                    window.location.href = "Booking_Master_temp_b.aspx?billno=" + document.getElementById('txtbill').value + "&cioid=" + cioidnew;
//                    return false;
//                }
//                else {
//                    window.location.href = "Classified_Booking_temp_b.aspx?billno=" + document.getElementById('txtbill').value + "&cioid=" + cioidnew;
//                    return false;
//                }
                if (ds.Tables[0].Rows[0].Ad_type_code == "CL0") {
                    win = window.open('Classified_Booking.aspx?cioid=' + cioidnew + '&userid=' + document.getElementById('hiddenusername').value + '&rateauditflag=rateaudit&supplimentflag=' + ds.Tables[0].Rows[0].SUPPLIMENTARY_BILL_REQ + '&billno=' + document.getElementById('txtbill').value + '&billdate=' + ds.Tables[0].Rows[0].BILL_DATE + '', '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
                    return false;
                }
                else {
                    win = window.open('Booking_master.aspx?cioid=' + cioidnew + '&userid=' + document.getElementById('hiddenusername').value + '&rateauditflag=rateaudit&supplimentflag=' + ds.Tables[0].Rows[0].SUPPLIMENTARY_BILL_REQ + '&billno=' + document.getElementById('txtbill').value + '&billdate=' + ds.Tables[0].Rows[0].BILL_DATE + '', '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
                    return false;
                }
            }
            else {
                if (ds.Tables[0].Rows[0].Ad_type_code == "CL0") {
                    win = window.open('Classified_Booking.aspx?cioid=' + ds.Tables[0].Rows[0].cio_booking_id + '&userid=' + document.getElementById('hiddenusername').value + '&rateauditflag=rateaudit&supplimentflag=' + ds.Tables[0].Rows[0].SUPPLIMENTARY_BILL_REQ + '&billno=' + document.getElementById('txtbill').value + '&billdate=' + ds.Tables[0].Rows[0].BILL_DATE + '', '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
                    return false;
                }
                else {
                    win = window.open('Booking_master.aspx?cioid=' + ds.Tables[0].Rows[0].cio_booking_id + '&userid=' + document.getElementById('hiddenusername').value + '&rateauditflag=rateaudit&supplimentflag=' + ds.Tables[0].Rows[0].SUPPLIMENTARY_BILL_REQ + '&billno=' + document.getElementById('txtbill').value + '&billdate=' + ds.Tables[0].Rows[0].BILL_DATE + '', '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
                    return false;
                }
            }   
        }
        else
        {
            alert("Bill No. Not Exist");
            return false;
        }
     }   
}

//function fillBillNo()
//{
//    document.getElementById('lstbill').options.length=0;
//    var res=billNoRevised.getBillList(document.getElementById('txtcioid').value);
//    if(res.value==null)
//        {
//            alert(res.error.description);
//            return false;
//        }
//    else
//    {
//        var ds=res.value;
//        if(ds.Tables[0].Rows.length>0)
//        {
//            for(i=0;i<ds.Tables[0].Rows.length;i++)
//            {
//                if(ds.Tables[0].Rows[0].BILL_NO!=null)
//                {
//                    document.getElementById('lstbill').options[document.getElementById('lstbill').options.length] = new Option(ds.Tables[0].Rows[0].BILL_NO,ds.Tables[0].Rows[0].BILL_NO);
//                    document.getElementById('lstbill').options.length;
//                 }   
//            }
//        }
//    } 
//    document.getElementById('lstbill').focus(); 
//    return false;  
//}