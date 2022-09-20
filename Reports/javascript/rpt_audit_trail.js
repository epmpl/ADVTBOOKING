

var bame = "";
var browser = navigator.appName;


function CallBindColumn() {
//alert("1")
    var compcode = document.getElementById('hiddencompcode').value;
    var unit = document.getElementById('hiddenunit').value;
    var cha = document.getElementById('hiddenunit').value;
    var repo = document.getElementById('DrpLogSelection').value;
    //var ds_1 = rpt_audit_trail.bindreport(compcode, unit, cha, repo);
    var repot = "";
//    for (var i = 0; i < ds_1.value.Tables[0].Rows.length; ++i)
//    {
//        if (repot == "") 
//        {
//            repot = ds_1.value.Tables[0].Rows[i].SEQ_NO;
//        }
//        else 
//        {
//            repot = repot + "," + ds_1.value.Tables[0].Rows[i].SEQ_NO;
//        }
    //    }
    repot = document.getElementById('DrpLogSelection').value;
    bindlist(repot);
    if (document.getElementById('DrpLogSelection').value == "TBL_BOOKING_MAST,TBL_BOOKING_INSERT") {
        document.getElementById('tr1').style.display = "block";
        document.getElementById('tr2').style.display = "none";
        LoadModalDiv();
    }
    else if (document.getElementById('DrpLogSelection').value == "0")
     {
        document.getElementById('tr1').style.display = "none";
        document.getElementById('tr2').style.display = "none";
        LoadModalDiv();
        //document.getElementById('ListBox4').value = "";
    }
    else {
        document.getElementById('tr1').style.display = "none";
        document.getElementById('tr2').style.display = "block";
        LoadModalDiv();
        //document.getElementById('ListBox4').value = "";
    }
}

function bindlist(repot) {
            var browser = navigator.appName;
           
            
            var extra1 = document.getElementById(document.activeElement.id).value;
            var compcode = document.getElementById('hiddencompcode').value;
            var unit = document.getElementById('hiddenunit').value;
            var cha = document.getElementById('hiddenunit').value;
            var repo = repot;
            var activeid = document.activeElement.id;
    
            var ds_1 = rpt_audit_trail.bindlis(compcode, unit, cha, repo);
            if (ds_1.value == null) {
                alert(ds_1.error.description);
                return false;
            }

            if (document.getElementById('DrpLogSelection').value == "TBL_BOOKING_MAST,TBL_BOOKING_INSERT") {
                var listboxid1 = "ListBox3";
                var objchannel = document.getElementById(listboxid1);
                var divid = "div3";
                objchannel.options.length = 0;
                for (var i = 0; i < ds_1.value.Tables[1].Rows.length; ++i) {
                    objchannel.options[objchannel.options.length] = new Option(ds_1.value.Tables[1].Rows[i].COL, ds_1.value.Tables[1].Rows[i].TABLE_NAME);
                    objchannel.options.length;

                }
            }
            else {
                var listboxid1 = "ListBox3";
                var objchannel = document.getElementById(listboxid1);
                var divid = "div3";
                objchannel.options.length = 0;
                for (var i = 0; i < ds_1.value.Tables[0].Rows.length; ++i) {
                    objchannel.options[objchannel.options.length] = new Option(ds_1.value.Tables[0].Rows[i].COL, ds_1.value.Tables[0].Rows[i].TABLE_NAME);
                    objchannel.options.length;

                }
            }


          
            //document.getElementById(drtype).focus();
        }


 function addfieldname()
{


        var sda = document.getElementById('ListBox3');
        var len = sda.length;
        var sda1 = document.getElementById('ListBox4');
        var sda2 = document.getElementById('ListBox1');
        
        for(var j=0; j<len-6; j++) {
        
            if(sda[j].selected) {
               // alert(sda.options[j].value);
            var tmp = sda.options[j].text;
            var tmp1 = sda.options[j].value;
           // sda.remove(j);j--;
            var y=document.createElement('option');
            y.text=tmp;
            var x = document.createElement('option');
            x.text = tmp1;
         
            sda1.add(y, null);
            sda2.add(x, null)
          

            }
        }
        //alert("1");
        return false ;
        //alert("TBL_BOOKING_MAST,TBL_BOOKING_INSERT");
    }


    function removefield() {

      
        var sda = document.getElementById('ListBox3');
        var sda1 = document.getElementById('ListBox4');
        var len = sda1.length;
     
        for (var j = 0; j < len; j++) {



           var tmp = document.getElementById('ListBox4').options[j].text;
//                
                sda1.remove(j);j--;
                var y = document.createElement('option');
              y.text = tmp;

               sda.add(y, null);


        }
        //alert("1");
        return false;
        //alert("TBL_BOOKING_MAST,TBL_BOOKING_INSERT");
    }
    function StringBuffer() {
        this.buffer = [];
    }

    StringBuffer.prototype.append = function append(string) {
        this.buffer.push(string);
        return this;
    };

    StringBuffer.prototype.toString = function toString() {
        return this.buffer.join("");
    };


    function bindgrid() {
        // alert("1");
        if (document.getElementById('DrpLogSelection').value == "TBL_BOOKING_MAST,TBL_BOOKING_INSERT") {
            if (document.getElementById('txtbookid').value == "") {
                alert("Please Enter Booking Id");
                return false;
            }
        }
        else {
            if (document.getElementById('txtfrom').value == "") {
                alert("Please Enter From Date");
                return false;
            }
            if (document.getElementById('txtto').value == "") {
                alert("Please Enter To Date");
                return false;
            }
        }
        var compcode=document.getElementById('hiddencompcode').value;
        var bookingid=document.getElementById('txtbookid').value;
        var fromdate=document.getElementById('txtfrom').value;
        var todate=document.getElementById('txtto').value;
        var val = document.getElementById('DrpLogSelection').value;
        var selectedfields = "";
        var selectedfields1 = "";
        if (document.getElementById('ListBox4').options.length > 0) {
            for (var i = 0; i < document.getElementById('ListBox4').options.length; i++) {

                if (selectedfields == "") {
                    selectedfields = document.getElementById('ListBox4').options[i].value;
                }
                else {
                    selectedfields = selectedfields + ',' + document.getElementById('ListBox4').options[i].value;
                }
            }
            document.getElementById('hdnlist').value = selectedfields;
            // alert(document.getElementById('hdnlist').value);
        }
        else {
            alert("Please Select At Least One Column Name");
            return false;
        }
        if (document.getElementById('ListBox1').options.length > 0) {
            for (var i = 0; i < document.getElementById('ListBox1').options.length; i++) {
                
                if (selectedfields1 == "") {
                    selectedfields1 = document.getElementById('ListBox1').options[i].value;
                }
                else {
                    selectedfields1 = selectedfields1 + ',' + document.getElementById('ListBox1').options[i].value;
                }
            }
            document.getElementById('hdnlist1').value = selectedfields1;
           // alert(document.getElementById('hdnlist1').value);
        }
        var res = rpt_audit_trail.bindgriddata(compcode, bookingid, fromdate, todate, val, document.getElementById('hdnlist').value, document.getElementById('hdnlist1').value)

            document.getElementById("tblgrid1").innerHTML = res.value;
        return false;
    }


    function abc(a, b, c) {
        
        var compcode = document.getElementById('hiddencompcode').value;
        var bookingid = document.getElementById('txtbookid').value;
        var fromdate = document.getElementById('txtfrom').value;
        var todate = document.getElementById('txtto').value;
        var val = "";
        var tblval = c  + "_log"+ "." + '"'+b+'"';        
        var extra1 = document.getElementById('DrpLogSelection').value;
        var res = rpt_audit_trail.bindlogndetail(compcode, tblval, bookingid, fromdate, todate, "", "")
        var bcgDiv = document.getElementById("divlogdetail");
        bcgDiv.style.display = "block";

        var aTag = eval(document.getElementById(a))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        var tot = document.getElementById('divlogdetail').scrollLeft;
        var scrolltop = document.getElementById('divlogdetail').scrollTop;
        document.getElementById('divlogdetail').style.left = document.getElementById(a).offsetLeft + leftpos - tot + "px";
        document.getElementById('divlogdetail').style.top = document.getElementById(a).offsetTop + toppos - scrolltop + "px";
        
        document.getElementById("tblgrid2").innerHTML = res.value;
        return false;
       // showModalPopUp(res)

    }

    function LoadModalDiv() {
//        var bcgDiv = document.getElementById("divBackground");
        //        bcgDiv.style.display = "block";
        var bcgDiv = document.getElementById("divlogdetail");
        bcgDiv.style.display = "none";
        document.getElementById("tblgrid2").innerHTML = "";
        document.getElementById("tblgrid1").innerHTML = "";
        document.getElementById('ListBox4').options.length = 0;
        document.getElementById('ListBox1').options.length = 0;
        document.getElementById('txtbookid').value = "";
      
        return false;
    }


    function HideModalDiv() {
        var bcgDiv = document.getElementById("divlogdetail");
        bcgDiv.style.display = "none";
        document.getElementById('hdnlist1').value = "";
        document.getElementById('hdnlist').value = "";
        document.getElementById('ListBox1').value = "";
        document.getElementById('ListBox3').value = "";
        document.getElementById('ListBox4').value = "";
        document.getElementById("tblgrid2").innerHTML = "";
        document.getElementById("tblgrid1").innerHTML = "";
        document.getElementById('DrpLogSelection').value = "0"
        document.getElementById('txtbookid').value = "";
        document.getElementById('tr1').style.display = "none";
        document.getElementById('tr2').style.display = "none";
        document.getElementById('ListBox1').options.length = 0;
        document.getElementById('ListBox3').options.length = 0;
        document.getElementById('ListBox4').options.length = 0;
        //document.getElementById('ListBox4').value = "";
  
        return false;
    }

    var popUpObj;
    function showModalPopUp(res) {
        popUpObj = window.open("PopUp.htm","ModalPopUp","toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=100," + "height=100," + "left = 490," + "top=300");
        popUpObj.focus();
        LoadModalDiv();
    }