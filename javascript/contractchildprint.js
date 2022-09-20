var browser = navigator.appName;

function tabvalue(event) {
var browser = navigator.appName;
    if (document.activeElement.id != "lstcommon") {
        colName = document.activeElement.id;
        if (event.keyCode == 113 && document.activeElement.id != "listpackage" && document.activeElement.id != "txtcardprem" && document.activeElement.id != "txtcontractperm" && document.activeElement.id != "txtcardpositionprem" && document.activeElement.id != "txtcontarctpositionprem" && document.activeElement.id != "txtcontractamount" && document.activeElement.id != "txtdiscper" && document.activeElement.id != "txtminsize" && document.activeElement.id != "txtmaxsize" && document.activeElement.id != "txtvaluefrom" && document.activeElement.id != "txtvalueto" && document.activeElement.id != "txtinsertion" && document.activeElement.id != "txttotalrate" && document.activeElement.id != "txtincentive" && document.activeElement.id != "txtremarks" && document.activeElement.id != "txtcontractrate" && document.activeElement.id != "txtcardrate" && document.activeElement.id != "txtdeviation"&& document.activeElement.id != "txtinsert") {
            //        var srcElem = getEventCell();
            //        var cellindex = srcElem.cellIndex;
            colName = document.activeElement.id;
            if (colName == "txtadtype" || colName == "txtbarter" || colName == "txthue" || colName == "txtumo" || colName == "txtcategory" || colName == "txtcurrency" || colName == "txtstatus" || colName == "txtpremium" || colName == "txtpositiomprem" || colName == "txtdisctype" || colName == "txtdiscon" || colName == "txtday" || colName == "txtdealstart" || colName == "txtratecode" || colName == "txtcomallow") {
                //activeIDNo = document.activeElement;

                document.getElementById("divcommon").style.display = "block";


                //aTag = eval( document.getElementById(document.activeElement.uniqueID))
                aTag = eval(document.getElementById(colName))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('divcommon').style.top = document.getElementById(colName).offsetTop + toppos + "px";
                document.getElementById('divcommon').style.left = document.getElementById(colName).offsetLeft + leftpos + "px";

                //	                     document.getElementById('divcommon').style.top=(document.getElementById(document.activeElement.uniqueID).offsetTop + toppos - scrolltop) + "px";
                //	                     document.getElementById('divcommon').style.left=(document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos - tot) + "px";
                //            document.getElementById('divcommon').style.top = (document.activeElement.offsetTop + toppos - scrolltop) + "px";
                //            document.getElementById('divcommon').style.left = (document.activeElement.offsetLeft + leftpos - tot) + "px";
                bindListBox(colName);
                return false;
            }
        }
        if (event.keyCode == 13||event.keyCode == 9) {
        if(colName=="txtadtype" || colName=="txthue" || colName=="txtumo" || colName==="txtcategory" || colName=="txtcurrency" || colName=="listpackage" || colName=="txtratecode")
        {
        get_rate();
        }
            if (document.activeElement.id == "txtadtype") {
                document.getElementById("txthue").focus();
                return false;
            }
            else if (document.activeElement.id == "txthue") {
                document.getElementById("txtumo").focus();
                return false;
            }
            else if (document.activeElement.id == "txtumo") {
                document.getElementById("txtcategory").focus();
                return false;
            }
            else if (document.activeElement.id == "txtcategory") {
                document.getElementById("listpackage").focus();
                return false;
            }
            else if (document.activeElement.id == "listpackage") {
                document.getElementById("txtcurrency").focus();
                return false;
            }
            else if (document.activeElement.id == "txtcurrency") {
                document.getElementById("txtstatus").focus();
                return false;
            }
            else if (document.activeElement.id == "txtstatus") {
                document.getElementById("txtpremium").focus();
                return false;
            }
            else if (document.activeElement.id == "txtpremium") {
            document.getElementById("txtcontractperm").focus();
                return false;
            }
//            else if (document.activeElement.id == "txtcardprem") {
//                document.getElementById("txtcontractperm").focus();
//                return false;
//            }
            else if (document.activeElement.id == "txtcontractperm") {
                document.getElementById("txtcomallow").focus();
                return false;
            }
            else if (document.activeElement.id == "txtcomallow") {
                document.getElementById("txtpositiomprem").focus();
                return false;
            }
            else if (document.activeElement.id == "txtpositiomprem") {
            document.getElementById("txtcontarctpositionprem").focus();
                return false;
            }
             else if (document.activeElement.id == "txtcardpositionprem") {
                document.getElementById("txtcontarctpositionprem").focus();
                return false;
            }
            else if (document.activeElement.id == "txtcontarctpositionprem") {
                document.getElementById("txtratecode").focus();
                return false;
            }
            else if (document.activeElement.id == "txtratecode") {
                document.getElementById("txtcontractrate").focus();
                return false;
            }
            else if (document.activeElement.id == "txtcontractrate") {
            document.getElementById("txtdealstart").focus();
                return false;
            }
//            else if (document.activeElement.id == "txtcardrate") {
//                document.getElementById("txtdeviation").focus();
//                return false;
//            }
//            else if (document.activeElement.id == "txtdeviation") {
//                document.getElementById("txtdealstart").focus();
//                return false;
//            }
            else if (document.activeElement.id == "txtdealstart") {
                document.getElementById("txtcontractamount").focus();
                return false;
            }
            else if (document.activeElement.id == "txtcontractamount") {
                document.getElementById("txtdisctype").focus();
                return false;
            }
            else if (document.activeElement.id == "txtdisctype") {
                document.getElementById("txtdiscper").focus();
                return false;
            }
            else if (document.activeElement.id == "txtdiscper") {
                document.getElementById("txtdiscon").focus();
                return false;
            }
            else if (document.activeElement.id == "txtdiscon") {
                document.getElementById("txtminsize").focus();
                return false;
            }
            else if (document.activeElement.id == "txtminsize") {
                document.getElementById("txtmaxsize").focus();
                return false;
            }
            else if (document.activeElement.id == "txtmaxsize") {
                document.getElementById("txtvaluefrom").focus();
                return false;
            }
            else if (document.activeElement.id == "txtvaluefrom") {
                document.getElementById("txtvalueto").focus();
                return false;
            }

            else if (document.activeElement.id == "txtvalueto") {
                document.getElementById("txtday").focus();
                return false;
            }
            else if (document.activeElement.id == "txtday") {
                document.getElementById("txtinsertion").focus();
                return false;
            }
            else if (document.activeElement.id == "txtinsertion") {
                document.getElementById("txttotalrate").focus();
                return false;
            }
            else if (document.activeElement.id == "txttotalrate") {
                document.getElementById("txtincentive").focus();
                return false;
            }
            else if (document.activeElement.id == "txtincentive") {
                document.getElementById("txtremarks").focus();
                return false;
            }
            
            else if (document.activeElement.id == "txtremarks") {
                document.getElementById("btnOk").focus();
                return false;
            }
        }
        if (colName == "txtadtype" || colName == "txthue" || colName == "txtumo" || colName == "txtcategory" || colName == "txtcurrency" || colName == "txtstatus" || colName == "txtpremium" || colName == "txtpositiomprem" || colName == "txtdisctype" || colName == "txtdiscon" || colName == "txtday" || colName == "txtdealstart" || colName == "txtratecode" || colName == "txtcomallow") {
            if (event.keyCode == 37 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40 || event.keyCode == 8 || event.keyCode==9||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode>=65 && event.keyCode<=90)) {
                return true;
            }
            else {
                return false;
            }
        }
        if (colName == "txtcardprem" || colName == "txtcontractperm" || colName == "txtcardpositionprem" || colName == "txtcontarctpositionprem" || colName == "txtcontractamount" || colName == "txtdiscper" || colName == "txtminsize" || colName == "txtmaxsize" || colName == "txtvaluefrom" || colName == "txtvalueto" || colName == "txtinsertion" || colName == "txttotalrate" || colName == "txtincentive" || colName == "txtcontractrate" || colName == "txtcardrate" || colName == "txtdeviation")
    
        var browser = navigator.appName;
        if(event.shiftKey==true)
    return false;
        if (browser != "Microsoft Internet Explorer" && browser!="undefined")
        
        
 {
   //  if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) { 
    	if ((event.which>=65 && event.which<=90)||(event.which>=48 && event.which<=57)||(event.which >= 96 && event.which <= 105)||(event.which==9)|| event.keyCode == 38  || (event.keyCode == 40) || (event.which==0) || (event.which==8) ||(event.which==11)|| (event.which==13))
    	{
         return true;
     }
     else 
     {
     return false;
     }
 }
 else {

 
        //   if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) 
           if ((event.keyCode>=65 && event.keyCode<=90)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode==9)|| event.keyCode == 38 || (event.keyCode == 40)||(event.keyCode==11)|| (event.keyCode==13)||(event.keyCode==8))
             {
                  return true;
            }
            else 
            {
                return false;
            }
        }
 
 if ((colName == "txtcardpositionprem" || colName == "txtcardprem" || colName == "txtcardrate" || colName == "txtdeviation") && (event.keyCode != 9 && event.keyCode != 13)) {
          
                return false;
            
        }
        
        
    }
    else {

 
        //   if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) 
           if ((event.keyCode>=65 && event.keyCode<=90)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode==9)|| event.keyCode == 38 || (event.keyCode == 40)||(event.keyCode==11)|| (event.keyCode==13)||(event.keyCode==8))
             {
                  return true;
            }
            else 
            {
                return false;
            }
        }
        if ((colName == "txtcardpositionprem" || colName == "txtcardprem" || colName == "txtcardrate" || colName == "txtdeviation") && (event.keyCode != 9 && event.keyCode != 13)) {
          
                return false;
            
        }
}

function bindListBox(colName) {
    if (colName == "txtadtype") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var res = contractchildprint.bindadtype_detail(document.getElementById('hiddencompcode').value);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Type_Name, ds.Tables[0].Rows[i].Adv_Type_Code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
//    else if (colName == "Section Code") {
//        var val_ = "";
//        var res = contractchildprint.getSectionCode(val_);
//        var ds = res.value;
//        var pkgitem = document.getElementById("lstcommon");
//        pkgitem.multiple = false;
//        pkgitem.options.length = 0;
//        // pkgitem.options[0]=new Option("-Select-","0");

//        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
//            //  pkgitem.options.length = 1; 
//            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
//                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME, ds.Tables[0].Rows[i].CODE);
//                pkgitem.options.length;
//            }

//        }
//        document.getElementById("lstcommon").focus();
//        return false;
//    }
//    else if (colName == "Resource No") {
//        var val_ = "";
//        var res = contractchildprint.getResourceNo(val_);
//        var ds = res.value;
//        var pkgitem = document.getElementById("lstcommon");
//        pkgitem.multiple = false;
//        pkgitem.options.length = 0;
//        // pkgitem.options[0]=new Option("-Select-","0");

//        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
//            //  pkgitem.options.length = 1; 
//            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
//                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME, ds.Tables[0].Rows[i].CODE);
//                pkgitem.options.length;
//            }

//        }
//        document.getElementById("lstcommon").focus();
//        return false;
//    }
    else if (colName == "txthue") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var res = contractchildprint.bindcolor_detail(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Col_Name, ds.Tables[0].Rows[i].Col_Code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
//    else if (colName == "Source") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
//        var res = contractchildprint.bindSource_TV_Contract(document.getElementById('hiddencompcode').value);
//        var ds = res.value;
//        var pkgitem = document.getElementById("lstcommon");
//        pkgitem.multiple = false;
//        pkgitem.options.length = 0;
//        // pkgitem.options[0]=new Option("-Select-","0");

//        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
//            //  pkgitem.options.length = 1; 
//            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
//                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME, ds.Tables[0].Rows[i].SOURCE_TYPE);
//                pkgitem.options.length;
//            }

//        }
//        document.getElementById("lstcommon").focus();
//        return false;
//    }
    else if (colName == "txtumo") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
    //        activeRow = srcElm.rowIndex;
    var adtype = document.getElementById("hiddenadtype").value;

        var res = contractchildprint.binduom_A_detail(document.getElementById('hiddencompcode').value, adtype, document.getElementById('hiddenuserid').value);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].UOM_Name, ds.Tables[0].Rows[i].UOM_Code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
//    else if (colName == "Rate Type") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
//        var adtype = "EL0";
//        var res = contractchildprint.binduom_A_detail(document.getElementById('hiddencompcode').value, adtype, document.getElementById('hiddenuserid').value);
//        var ds = res.value;
//        var pkgitem = document.getElementById("lstcommon");
//        pkgitem.multiple = false;
//        pkgitem.options.length = 0;
//        // pkgitem.options[0]=new Option("-Select-","0");

//        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
//            //  pkgitem.options.length = 1; 
//            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
//                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].UOM_Name, ds.Tables[0].Rows[i].UOM_Code);
//                pkgitem.options.length;
//            }

//        }
//        document.getElementById("lstcommon").focus();
//        return false;
//    }
    else if (colName == "Package") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var adtype = "";
        var channel = "";

        adtype = document.getElementById("hiddenadtype").value;
      
 

  
        var res = contractchildprint.bindpackage_A_detail(document.getElementById('hiddencompcode').value, adtype, channel);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name, ds.Tables[0].Rows[i].Combin_Code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtcategory") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var adtype = "";
 
        adtype = document.getElementById("hiddenadtype").value;
      
        var res = contractchildprint.bindadvcategory_A_detail(adtype, document.getElementById('hiddencompcode').value);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name, ds.Tables[0].Rows[i].Adv_Cat_Code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtpremium") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var adtype = "";

        adtype = document.getElementById("hiddenadtype").value;
      
        var res = contractchildprint.bindpremium_A_detail(document.getElementById('hiddencompcode').value, adtype);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].premiumname, ds.Tables[0].Rows[i].Premiumcode);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtdisctype") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        pkgitem.options[pkgitem.options.length] = new Option("Free", "1");
        pkgitem.options[pkgitem.options.length] = new Option("Discounted", "2");
        pkgitem.options[pkgitem.options.length] = new Option("Fixed Rate", "3");
        pkgitem.options.length;
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtdiscon") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        pkgitem.options[pkgitem.options.length] = new Option("Discount On Bill", "1");
        pkgitem.options[pkgitem.options.length] = new Option("Discount through Credit Note", "2");
        pkgitem.options.length;
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtdealstart") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        pkgitem.options[pkgitem.options.length] = new Option("After Target Achived", "A");
        pkgitem.options[pkgitem.options.length] = new Option("From Begining", "B");
        pkgitem.options.length;
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtstatus") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        pkgitem.options[pkgitem.options.length] = new Option("Active", "Y");
        pkgitem.options[pkgitem.options.length] = new Option("Inactive", "N");
        pkgitem.options.length;
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtcomallow") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        pkgitem.options[pkgitem.options.length] = new Option("Yes", "Y");
        pkgitem.options[pkgitem.options.length] = new Option("No", "N");
        pkgitem.options.length;
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtday") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = true;
        pkgitem.options.length = 0;
        pkgitem.options[pkgitem.options.length] = new Option("SUN", "sun");
        pkgitem.options[pkgitem.options.length] = new Option("MON", "mon");
        pkgitem.options[pkgitem.options.length] = new Option("TUE", "tue");
        pkgitem.options[pkgitem.options.length] = new Option("WED", "wed");
        pkgitem.options[pkgitem.options.length] = new Option("THU", "thu");
        pkgitem.options[pkgitem.options.length] = new Option("FRI", "fri");
        pkgitem.options[pkgitem.options.length] = new Option("SAT", "sat");
        pkgitem.options.length;
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtcurrency") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var adtype = "";

        adtype = document.getElementById("hiddenadtype").value;
      
        var res = contractchildprint.bindcurrency_detail(document.getElementById('hiddencompcode').value, adtype, document.getElementById('hiddenuserid').value);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Curr_Name, ds.Tables[0].Rows[i].Curr_Code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtratecode") {
//        var srcElm1 = getEventCell();
//        activeCell = srcElm1.cellIndex;
//        var srcElm = getEventRow();
//        activeRow = srcElm.rowIndex;
        var adtype = "";

  
      
        var res = contractchildprint.bindratecode_detail(document.getElementById('hiddencompcode').value, adtype);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].rate_mast_code, ds.Tables[0].Rows[i].rate_mast_code);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "txtpositiomprem") {

        var prem = "";


      //  prem = document.getElementById("hiddenprem").value;

        var res = contractchildprint.pagebindpremium_A_detail(document.getElementById('hiddencompcode').value, prem);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].POS_TYPE, ds.Tables[0].Rows[i].POS_TYPE_CODE);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }

    else if (colName == "txtbarter")
     {

        var prem = "";

//var agnnd= document.getElementById('hidagency').value + document.getElementById('hdnsubcod').value;

        var agnnd = document.getElementById('hidagency').value;
        var res = contractchildprint.pagebindpremium_A_detail(document.getElementById('hiddencompcode').value, prem);
        res=contractchildprint.getBarter(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,document.getElementById('hdnagency').value,agnnd,document.getElementById('hdncltcod').value);
         if(res.value!=null && res.value.Tables.length>0)
            { 
                var ds=res.value;
            var objciragency=document.getElementById("lstcommon");
            objciragency.options.length = 0; 
            objciragency.options[0]=new Option("-Select-","0");            
            objciragency.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                var name=ds.Tables[0].Rows[i].BARTE_DESC;
                var value=ds.Tables[0].Rows[i].BARTER_CODE+"û"+ds.Tables[0].Rows[i].BARTER_AMOUNT+"û"+ds.Tables[0].Rows[i].STOPBOOKING;
                objciragency.options[objciragency.options.length] = new Option(name,value);            
                objciragency.options.length;       
            }
            objciragency.focus();
            }
        document.getElementById("lstcommon").focus();
        return false;
    }

}

function onclicklist(event) {

    if (event.keyCode == 13 || event.type == "click") {




            document.getElementById("divcommon").style.display = "none";
            var datetime = "";
           

            var page = document.getElementById('lstcommon').value;
    
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstcommon").length - 1; k++) {
                if (document.getElementById('lstcommon').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstcommon').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstcommon').options[k].innerText;
                    }
                    if (colName == "txtadtype") {
//                        var split = abc.split("+");
//                        var nameagen = split[0];
//                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                        //                         agencycode = agencycode[1].replace(")", "");
                        abc = abc + "(" + page + ")";
                        document.getElementById('txtadtype').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenadtype').value = page;
                        packagebind();
                        document.getElementById(colName).focus();                 
                        return false;
                    }
                    else if (colName == "txthue") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txthue').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenhue').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }
                    else if (colName == "txtumo") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtumo').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddeumo').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }
                    else if (colName == "txtcategory") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtcategory').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddencategory').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtcurrency") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtcurrency').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddencurrency').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtstatus") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtstatus').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenstatus').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtpremium") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtpremium').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenprem').value = page;
                        bindPremCharges(document.getElementById("lstcommon").value);
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtpositiomprem") {
                        //                        var split = abc.split("+");
                        //                        var nameagen = split[0];
                        //                        var agencycode = split[1];
                        //                         var agencycode = nameagen.split("(");
                    //                         agencycode = agencycode[1].replace(")", "");
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtpositiomprem').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenposiprem').value = page;
                        bindpositionPremCharges(document.getElementById("lstcommon").value);
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtdisctype") {
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtdisctype').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddendisctype').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtdiscon") {
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtdiscon').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddendiscon').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtday") {
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtday').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenday').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtcomallow") {
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtcomallow').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddencommallow').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }

                    else if (colName == "txtdealstart") {
                    abc = abc + "(" + page + ")";
                        document.getElementById('txtdealstart').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddendealstart').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }
                  else if (colName == "txtratecode") {
                  abc = abc + "(" + page + ")";
                        document.getElementById('txtratecode').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hiddenratecode').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }
                    else if (colName == "txtbarter") {
                  abc = abc + "(" + page + ")";
                        document.getElementById('txtbarter').value = abc;
                        //                         document.getElementById('hiddenagency').value = agenadd;
                        document.getElementById('hdnbarter').value = page;
                        document.getElementById(colName).focus();
                        return false;
                    }
                    
                }
            }
        }
    

    if (event.keyCode == 27) {
        document.getElementById("divcommon").style.display = "none";
        document.getElementById(colName).focus();
    }
}

function bindPremCharges(premcode) {
    var res = contractchildprint.getPremPage_detail(premcode);
    var ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var cardprem = ds.Tables[0].Rows[0].premium_charges;

        document.getElementById("txtcardprem").value = cardprem;
     
          
    }
}

function bindpositionPremCharges(premcode) {
    var res = contractchildprint.pagebindpremium(document.getElementById("hiddencompcode").value, premcode);
    var ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var cardprem = ds.Tables[0].Rows[0].Amount;

        document.getElementById("txtcardpositionprem").value = cardprem;

    }
}
function setData(event) {
    var res=validation();
    if (res == false) {
        return false;
    }
    
    var o = new Object();
     var packagecode="";
     for (var k = 0; k <= document.getElementById("listpackage").length - 1; k++) {
      if (document.getElementById('listpackage').options[k].selected == true)
            {
        var page=  document.getElementById('listpackage').options[k].value;  


    
//    o.txtadtype = document.getElementById('txtadtype').value;
//    o.txthue = document.getElementById('txthue').value;
//    o.txtumo = document.getElementById('txtumo').value;
//    o.txtcategory = document.getElementById('txtcategory').value;
//      var page = document.getElementById('listpackage').value;


//      for (var k = 0; k <= document.getElementById("listpackage").length - 1; k++) {
//          if (document.getElementById('listpackage').options[k].value == page) {

              if (browser != "Microsoft Internet Explorer") {
                  var abc = document.getElementById('listpackage').options[k].textContent;
              }
              else {
                  var abc = document.getElementById('listpackage').options[k].innerText;
              }
              if(packagecode=="")
              {
              packagecode=abc + "(" + page + ")";
              }
              else
              {
                packagecode=packagecode+","+abc + "(" + page + ")";
              }
              
          }
      }
    o.txtadtype = document.getElementById('txtadtype').value;
    o.txthue = document.getElementById('txthue').value;
    o.txtumo = document.getElementById('txtumo').value;
    o.txtcategory = document.getElementById('txtcategory').value;
     
             //        abc = abc + "(" + page + ")";
  //  o.listpackage = abc;
    o.listpackage = packagecode;
    o.txtcurrency = document.getElementById('txtcurrency').value;
    o.txtstatus = document.getElementById('txtstatus').value;
    o.txtpremium = document.getElementById('txtpremium').value;
    o.txtcardprem = document.getElementById('txtcardprem').value;
    o.txtcontractperm = document.getElementById('txtcontractperm').value;
    o.txtpositiomprem = document.getElementById('txtpositiomprem').value;
    o.txtcardpositionprem = document.getElementById('txtcardpositionprem').value;
    o.txtcontarctpositionprem = document.getElementById('txtcontarctpositionprem').value;
    o.txtcontractrate = document.getElementById('txtcontractrate').value;
    o.txtcardrate = document.getElementById('txtcardrate').value;
    o.txtdeviation = document.getElementById('txtdeviation').value;
    o.txtcontractamount = document.getElementById('txtcontractamount').value;
    o.txtdisctype = document.getElementById('txtdisctype').value;
    o.txtdiscper = document.getElementById('txtdiscper').value;
    o.txtdiscon = document.getElementById('txtdiscon').value;
    o.txtminsize = document.getElementById('txtminsize').value;
    o.txtmaxsize = document.getElementById('txtmaxsize').value;
    o.txtvaluefrom = document.getElementById('txtvaluefrom').value;
    o.txtvalueto = document.getElementById('txtvalueto').value;
    o.txtday = document.getElementById('txtday').value;
    o.txtinsertion = document.getElementById('txtinsertion').value;
    o.txtcomallow = document.getElementById('txtcomallow').value;
    o.txtdealstart = document.getElementById('txtdealstart').value;
    o.txtratecode = document.getElementById('txtratecode').value;
    o.txttotalrate = document.getElementById('txttotalrate').value;
    o.txtincentive = document.getElementById('txtincentive').value;
    o.txtremarks = document.getElementById('txtremarks').value;
    o.txtinsert = document.getElementById('txtinsert').value;
    o.txtbarter = document.getElementById('txtbarter').value;
    window.returnValue = o;
    window.close();
    return false;
}

function packagebind() {

    var adtype = "";
    var channel = "";

    adtype = document.getElementById("hiddenadtype").value;




    var res = contractchildprint.bindpackage_A_detail(document.getElementById('hiddencompcode').value, adtype, channel);
    var ds = res.value;
    var pkgitem = document.getElementById("listpackage");
    pkgitem.multiple = true;
    pkgitem.options.length = 0;
    // pkgitem.options[0]=new Option("-Select-","0");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        //  pkgitem.options.length = 1; 
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name, ds.Tables[0].Rows[i].Combin_Code);
            pkgitem.options.length;
        }

    }
//    document.getElementById("listpackage").focus();
    return false;

}

function validation() {
    if (document.getElementById('txtadtype').value == "") {
        alert("Please Enter Ad Type");
        document.getElementById('txtadtype').focus();
        return false;
    }

//    var category = document.getElementById('txtcategory').value;
//    if (category.indexOf("(") > 0)
//        category = category.substring(category.lastIndexOf('(') + 1, category.lastIndexOf(')'));
//    if (category == "") {
//        alert("Category can't be blank in Print Details");
//        document.getElementById('txtcategory').focus();
//        return false;
 var alrt;
    
     alrt=document.getElementById('lbctegory').innerHTML;
   
    if(alrt.indexOf('*')>=0)
    {
        var category = document.getElementById('txtcategory').value;
        if (category.indexOf("(") > 0)
            category = category.substring(category.lastIndexOf('(') + 1, category.lastIndexOf(')'));
        if (category == "") {
            alert("Category can't be blank in Print Details");
            document.getElementById('txtcategory').focus();
            return false;
        }
        
    }
//    if (document.getElementById('txtcategory').value == "") {
//        alert("Category can't be blank in Print Details");
//        return false;
//    }

alrt=document.getElementById('lbhue').innerHTML;
   
    if(alrt.indexOf('*')>=0)
    {
    var hue = document.getElementById('txthue').value;
    if (hue.indexOf("(") > 0)
        hue = hue.substring(hue.lastIndexOf('(') + 1, hue.lastIndexOf(')'));
    if (hue == "") {
        alert("Hue can't be blank in Print Details");
        document.getElementById('txthue').focus();
        return false;
    }
    }
    var package = document.getElementById('listpackage').value;
   alrt=document.getElementById('lbpackage').innerHTML;
   
    if(alrt.indexOf('*')>=0)
    { 
    if (package == "") {
        alert("Package can't be blank in Print Details");
        document.getElementById('listpackage').focus();
        return false;
    }}

    var contrate = document.getElementById('txtcontractrate').value;
    var cardrate = document.getElementById('txtcardrate').value;
   alrt=document.getElementById('lbcardrate').innerHTML
      if(alrt.indexOf('*')>=0)
    {  
    if (cardrate == "" || cardrate=="0") {
        alert("Card Rate can't be blank in Print Details");
        document.getElementById('txtcontractrate').focus();
        return false;
    }
    }
    
     
     alrt=document.getElementById('lbcontractrate').innerHTML
      if(alrt.indexOf('*')>=0)
    {  
    if (contrate == "") {
        alert("Contract Rate can't be blank in Print Details");
        document.getElementById('txtcardrate').focus();
        return false;
    }
    }
    var day = document.getElementById('txtday').value;
    var insertion = document.getElementById('txtinsertion').value;
    var mins = document.getElementById('txtminsize').value;;
    var maxs = document.getElementById('txtmaxsize').value;
    var valuef = document.getElementById('txtvaluefrom').value;
    var valuet =  document.getElementById('txtvalueto').value;

 
//    arr[i - 1][0] = category;
//    arr[i - 1][1] = hue;
//    arr[i - 1][2] = package;
//    arr[i - 1][3] = day;
//    arr[i - 1][4] = insertion;
//    arr[i - 1][5] = mins;
//    arr[i - 1][6] = maxs;
//    arr[i - 1][7] = valuef;
//    arr[i - 1][8] = valuet;

//    for (var j = 0; j < arr.length; j++) {
//        var category = arr[j][0];
//        var hue = arr[j][1];
//        var package = arr[j][2];
//        var day = arr[j][3];
//        var insertion = arr[j][4];
//        var mins = arr[j][5];
//        var maxs = arr[j][6];
//        var valuef = arr[j][7];
//        var valuet = arr[j][8];
//        for (var i = 0; i < arr.length; i++) {
//            if (i != j) {
//                if (valuet = arr[i][8] && valuef == arr[i][7] && maxs == arr[i][6] && mins == arr[i][5] && category == arr[i][0] && hue == arr[i][1] && package == arr[i][2] && day == arr[i][3] && insertion == arr[i][4]) {
//                    alert("Category, Hue, Package, Day, Min Size, Max Size, Value From and Value To should be unique in Print Details.");
//                    return false;
//                }
//            }
      //  }

 //   }
}

function deviation() {
    var contractrate = document.getElementById('txtcontractrate').value;
    var cardrate = document.getElementById('txtcardrate').value;
    if (contractrate != "" && cardrate != "") {
        var dev = parseFloat(cardrate) - parseFloat(contractrate);
        var res=  contractchildprint.chk_null(dev)
        document.getElementById('txtdeviation').value =res.value;
    }
}

function greater() {
    var mins = document.getElementById('txtminsize').value; ;
    var maxs = document.getElementById('txtmaxsize').value;
 
    if (parseInt(mins, 10) > parseInt(maxs, 10)) {
        alert("Min Size can'be greater than Max Size");
        document.getElementById('txtmaxsize').focus();
        return false;
    }

}
function checkFromTo() {
    var valuef = document.getElementById('txtvaluefrom').value;
    var valuet = document.getElementById('txtvalueto').value;
    if (valuef != "" && valuet != "") {
        if (parseInt(valuef, 10) > parseInt(valuet, 10)) {
            alert("Value From can'be greater than Value To");
            document.getElementById('txtvalueto').focus();
            return false;
        }
    }
//    get_rate();
}

function execute() {

var pkgitem = document.getElementById("listpackage");
    pkgitem.multiple = true;
//    document.getElementById('txtcardprem').disabled == true;

//    document.getElementById('txtcardpositionprem').disabled == true;

//    document.getElementById('txtcardrate').disabled == true;
//    document.getElementById('txtdeviation').disabled == true;
//    if (document.getElementById('txtadtype').value != "") {

//        var adtye = document.getElementById('txtadtype').value;
//        adtye = adtye.split("(");
//        adtye = adtye[1].replace(")", "");
//        document.getElementById('hiddenadtype').value = adtye;
//        packagebind();
//        var packagetype=document.getElementById('hiddenpackagecode').value;
//        packagetype = packagetype.split("(");
//        packagetype = packagetype[1].replace(")", "");
//        document.getElementById('listpackage').value = packagetype;
//        document.getElementById('listpackage').focus();
//    }


//    return false;

}
function get_rate() {
    var pkgcode = document.getElementById('listpackage').value
    var validfrom = document.getElementById('hiddenvalidfrom').value

    var validto = document.getElementById('hiddenvalidto').value

    var compcode = document.getElementById('hiddencompcode').value

    var dateformat = document.getElementById('hiddendateformat').value
    var adtype=document.getElementById('txtadtype').value;
     if (adtype.indexOf("(") > 0)
            adtype = adtype.substring(adtype.lastIndexOf('(') + 1, adtype.lastIndexOf(')'));
    var umo =document.getElementById('txtumo').value;
     if (umo.indexOf("(") > 0)
            umo = umo.substring(umo.lastIndexOf('(') + 1, umo.lastIndexOf(')'));
         var category = document.getElementById('txtcategory').value;
    var currency= document.getElementById('txtcurrency').value;
    if (currency.indexOf("(") > 0)
            currency = currency.substring(currency.lastIndexOf('(') + 1, currency.lastIndexOf(')'));
         var category = document.getElementById('txtcategory').value;
        if (category.indexOf("(") > 0)
            category = category.substring(category.lastIndexOf('(') + 1, category.lastIndexOf(')'));
    
    
     var hue = document.getElementById('txthue').value;
     if (hue.indexOf("(") > 0)
        hue = hue.substring(hue.lastIndexOf('(') + 1, hue.lastIndexOf(')'));
      var premium = document.getElementById('txtpremium').value;
       if (premium.indexOf("(") > 0)
        premium = premium.substring(premium.lastIndexOf('(') + 1, premium.lastIndexOf(')'));
     
    var res = contractchildprint.getrateforcontract_detail(category, pkgcode, hue, currency, umo,adtype, validfrom, validto, compcode, dateformat,premium)
    var ds2 = res.value;
    if (res.value != null && res.value != "" && ds2.Tables.length>0 && ds2.Tables[0].Rows.length>0) {
        document.getElementById('txtcardrate').value = ds2.Tables[0].Rows[0].Week_Day_Rate;

    }
    deviation();
}