// JScript File
var browser = navigator.appName;

function ref_fileclick() {
    if (document.getElementById('Chkpackage').checked == true) {
        if (document.getElementById('PubDate').value == "") {
            alert("Please Select Date: ");
            document.getElementById('PubDate').focus();
            return false;
        }
        if (document.getElementById('txtFilepath').value == "0") {
            alert("Please Enter Path ");
            document.getElementById('txtFilepath').focus();
            return false;
        }


        var compcode = document.getElementById('hiddencompcode').value;
        // var userid=document.getElementById('hiddenuserid').value;
        var pubdate = document.getElementById('PubDate').value;
        if (document.getElementById('ddlPublication').value == "--Select Publ Code----") {
            var pubcode = "";
        }
        else {

            var pubcode = document.getElementById('ddlPublication').value;
        }

        var logincenter = document.getElementById('hiddenlogincenter').value;

        var pubname = document.getElementById('ddlPublication').options[document.getElementById('ddlPublication').selectedIndex].text;

        var dateformat = document.getElementById('hiddendateformat').value;
        var chk = 0;
        if (document.getElementById('chkaudit').checked == true) {
            chk = 1;
        }
        var includeuom = "0";
        var tem_uom_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludeuom').options.length; ui++) {
            if (document.getElementById('drpincludeuom').options[ui].selected == true) {
                if (document.getElementById('drpincludeuom').options[ui].value != "0") {
                    tem_uom_in = document.getElementById('drpincludeuom').options[ui].value;
                    if (includeuom == "0")
                        includeuom = tem_uom_in;
                    else
                        includeuom = includeuom + "," + tem_uom_in;
                }
            }
        }
        var excludeuom = "0";
        var tem_uom_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludeuom').options.length; ui++) {
            if (document.getElementById('drpexcludeuom').options[ui].selected == true) {
                if (document.getElementById('drpexcludeuom').options[ui].value != "0") {
                    tem_uom_ex = document.getElementById('drpexcludeuom').options[ui].value;
                    if (excludeuom == "0")
                        excludeuom = tem_uom_ex;
                    else
                        excludeuom = excludeuom + "," + tem_uom_ex;
                }
            }
        }
        var includecat = "0";
        var tem_cat_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludead').options.length; ui++) {
            if (document.getElementById('drpincludead').options[ui].selected == true) {
                if (document.getElementById('drpincludead').options[ui].value != "0") {
                    tem_cat_in = document.getElementById('drpincludead').options[ui].value;
                    if (includecat == "0")
                        includecat = tem_cat_in;
                    else
                        includecat = includecat + "," + tem_cat_in;
                }
            }
        }
        var excludecat = "0";
        var tem_cat_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludead').options.length; ui++) {
            if (document.getElementById('drpexcludead').options[ui].selected == true) {
                if (document.getElementById('drpexcludead').options[ui].value != "0") {
                    tem_cat_ex = document.getElementById('drpexcludead').options[ui].value;
                    if (excludecat == "0")
                        excludecat = tem_cat_ex;
                    else
                        excludecat = excludecat + "," + tem_cat_ex;
                }
            }
        }

        var browser = navigator.appName;
        var packagecode = "";

        for (var k = 0; k <= document.getElementById("listpackage").length - 1; k++) {
            if (document.getElementById('listpackage').options[k].selected == true) {
                var page = document.getElementById('listpackage').options[k].value;
                if (browser != "Microsoft Internet Explorer") {
                    var abc = document.getElementById('listpackage').options[k].textContent;
                }
                else {
                    var abc = document.getElementById('listpackage').options[k].innerText;
                }

                if (packagecode == "") {
                    packagecode = page;
                }
                else {
                    packagecode = packagecode + "," + page;
                }



            }
        }
        var chkcenters = "";
         if (document.getElementById('chkcenters').checked == true) 
        {
            chkcenters ="L";
        }
        else
            chkcenters ="F";
            
        //genReference.ReferenceFile(compcode,pubdate,pubcode,centercode,edi,suppcode,dateformat,chk,includeuom,excludeuom,includecat,excludecat,callbackReferenceFile);
        window.open('CreateReferenceFile.aspx?compcode=' + compcode + '&pubdate=' + pubdate + '&flag=' + "1" + '&packagecode=' + packagecode + '&dateformat=' + dateformat + '&chk=' + chk + '&includeuom=' + includeuom + '&excludeuom=' + excludeuom + '&includecat=' + includecat + '&excludecat=' + excludecat + '&logincenter=' + logincenter + '&physicalpath=' + document.getElementById('txtFilepath').value + '&centername=' + centername + '&pubname=' + pubname +'&chkcenters=' + chkcenters, 'Preview', 'width=250px,height=300,resizable=0,left=200,top=0,scrollbars=yes');
        return false;

    }
    else {
        if (document.getElementById('PubDate').value == "") {
            alert("Please Select Date: ");
            document.getElementById('PubDate').focus();
            return false;
        }
        if (document.getElementById('ddlPublication').value == "0") {
            alert("Please Select Publication ");
            document.getElementById('ddlPublication').focus();
            return false;
        }
        if (document.getElementById('ddlCenter').value == "0") {
            alert("Please Select Center ");
            document.getElementById('ddlCenter').focus();
            return false;
        }
        if (document.getElementById('ddlEdition').value == "0") {
            alert("Please Select Edition ");
            document.getElementById('ddlEdition').focus();
            return false;
        }
        if (document.getElementById('ddlSupplement').value == "0") {
            alert("Please Select Supplement ");
            document.getElementById('ddlSupplement').focus();
            return false;
        }

        if (document.getElementById('txtFilepath').value == "0") {
            alert("Please Enter Path ");
            document.getElementById('txtFilepath').focus();
            return false;
        }
        var compcode = document.getElementById('hiddencompcode').value;
        // var userid=document.getElementById('hiddenuserid').value;
        var pubdate = document.getElementById('PubDate').value;
        var pubcode = document.getElementById('ddlPublication').value;
        var centercode = document.getElementById('ddlCenter').value;
        var editioncode = document.getElementById('ddlEdition').value;
        var logincenter = document.getElementById('hiddenlogincenter').value;
        var pubname = document.getElementById('ddlPublication').options[document.getElementById('ddlPublication').selectedIndex].text;
        var edi = "";
        for (var i = 0; i < document.getElementById('ddlEdition').options.length; i++) {
            if (document.getElementById('ddlEdition').options[i].selected == true) {
                if (edi == "")
                    edi = document.getElementById('ddlEdition').options[i].value;
                else
                    edi = edi + "," + document.getElementById('ddlEdition').options[i].value;
            }
        }
        var suppcode = document.getElementById('ddlSupplement').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        var chk = 0;
        if (document.getElementById('chkaudit').checked == true) {
            chk = 1;
        }
        var includeuom = "0";
        var tem_uom_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludeuom').options.length; ui++) {
            if (document.getElementById('drpincludeuom').options[ui].selected == true) {
                if (document.getElementById('drpincludeuom').options[ui].value != "0") {
                    tem_uom_in = document.getElementById('drpincludeuom').options[ui].value;
                    if (includeuom == "0")
                        includeuom = tem_uom_in;
                    else
                        includeuom = includeuom + "," + tem_uom_in;
                }
            }
        }
        var excludeuom = "0";
        var tem_uom_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludeuom').options.length; ui++) {
            if (document.getElementById('drpexcludeuom').options[ui].selected == true) {
                if (document.getElementById('drpexcludeuom').options[ui].value != "0") {
                    tem_uom_ex = document.getElementById('drpexcludeuom').options[ui].value;
                    if (excludeuom == "0")
                        excludeuom = tem_uom_ex;
                    else
                        excludeuom = excludeuom + "," + tem_uom_ex;
                }
            }
        }
        var includecat = "0";
        var tem_cat_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludead').options.length; ui++) {
            if (document.getElementById('drpincludead').options[ui].selected == true) {
                if (document.getElementById('drpincludead').options[ui].value != "0") {
                    tem_cat_in = document.getElementById('drpincludead').options[ui].value;
                    if (includecat == "0")
                        includecat = tem_cat_in;
                    else
                        includecat = includecat + "," + tem_cat_in;
                }
            }
        }
        var excludecat = "0";
        var tem_cat_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludead').options.length; ui++) {
            if (document.getElementById('drpexcludead').options[ui].selected == true) {
                if (document.getElementById('drpexcludead').options[ui].value != "0") {
                    tem_cat_ex = document.getElementById('drpexcludead').options[ui].value;
                    if (excludecat == "0")
                        excludecat = tem_cat_ex;
                    else
                        excludecat = excludecat + "," + tem_cat_ex;
                }
            }
        }
        var chkcenters = "";
         if (document.getElementById('chkcenters').checked == true) 
        {
            chkcenters ="L";
        }
        else
            chkcenters ="F";
            
        var centername = document.getElementById('ddlCenter').options[document.getElementById('ddlCenter').selectedIndex].text;
        //genReference.ReferenceFile(compcode,pubdate,pubcode,centercode,edi,suppcode,dateformat,chk,includeuom,excludeuom,includecat,excludecat,callbackReferenceFile);
        window.open('CreateReferenceFile.aspx?compcode=' + compcode + '&pubdate=' + pubdate + '&pubcode=' + pubcode + '&centercode=' + centercode + '&editioncode=' + edi + '&suppcode=' + suppcode + '&dateformat=' + dateformat + '&chk=' + chk + '&includeuom=' + includeuom + '&excludeuom=' + excludeuom + '&includecat=' + includecat + '&excludecat=' + excludecat + '&logincenter=' + logincenter + '&physicalpath=' + document.getElementById('txtFilepath').value + '&centername=' + centername + '&pubname=' + pubname +'&chkcenters=' + chkcenters, 'Preview', 'width=250px,height=300,resizable=0,left=200,top=0,scrollbars=yes');
        return false;
    }
}


var updatestatus = "";
function callbackReferenceFile(response) {
    var ds_ref = response.value;
    var fso = new ActiveXObject("Scripting.FileSystemObject");

    if (ds_ref == null) {
        alert(response.error.description);
        return false;
    }
    if (ds_ref.Tables[0].Rows.length != 0) {
        var xtg_filename = "";
        var pubdate = document.getElementById('PubDate').value;
        //Main server Path....
        var eps_path = document.getElementById('txtFilepath').value + "Category\\";

        var ref_path = document.getElementById('txtFilepath').value + "xtg\\";
        ref_path = document.getElementById('txtFilepath').value + "xtg\\"; // for mapping path
        if (fso.FolderExists(document.getElementById('txtFilepath').value + "Reffile")) {

            a = "";
        }
        else {
            var newfolder = fso.CreateFolder(document.getElementById('txtFilepath').value + "Reffile");
        }
        if (fso.FolderExists(document.getElementById('txtFilepath').value + "xtg")) {
            a = "";
        }
        else {
            var newfolder = fso.CreateFolder(ref_path);
            /* Ref path for CD*/
            var ref_path_CD = document.getElementById('txtFilepath').value + "eps\\";
            // var ref_path_CD="z:\\eps\\";
        }
        if (fso.FolderExists(document.getElementById('txtFilepath').value + "eps")) {
            a = "";
        }
        else {
            var newfolder = fso.CreateFolder(document.getElementById('txtFilepath').value + "eps");
            /* for getting month name..    */
        }
        var dt = pubdate.split("/");
        if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
            pubdate = dt[1] + "/" + dt[0] + "/" + dt[2];
        }
        else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
            pubdate = dt[1] + "/" + dt[2] + "/" + dt[0];
        }
        var my_month = new Date(pubdate);

        var month_name = new Array(12);
        month_name[0] = "JAN"
        month_name[1] = "FEB"
        month_name[2] = "MAR"
        month_name[3] = "APR"
        month_name[4] = "MAY"
        month_name[5] = "JUN"
        month_name[6] = "JUL"
        month_name[7] = "AUG"
        month_name[8] = "SEP"
        month_name[9] = "OCT"
        month_name[10] = "NOV"
        month_name[11] = "DEC"

        var mon = month_name[my_month.getMonth()]
        var dt = pubdate.split("/");
        var dd = "";
        if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
            dd = dt[1] + "-" + mon + "-" + dt[2];
        }
        else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
            dd = dt[2] + "-" + mon + "-" + dt[0];
        }
        else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
            dd = dt[1] + "-" + mon + "-" + dt[2];
        }
        //var dd=dt[1]+"-"+dt[0]+"-"+dt[2];

        var f_hd = "Ü" + dd + "Ü";
        var xtg_filename = "";

        //generate xtg file *********************************************************
        for (var i = 0; i < ds_ref.Tables[0].Rows.length; i++) {
            xtg_matter = ds_ref.Tables[0].Rows[i].xtgformat;
            //getting Ad_no & insertion number....
            var adno = ds_ref.Tables[0].Rows[i].cio_booking_id.substring(0, 3);
            adno = adno + "-" + ds_ref.Tables[0].Rows[i].cio_booking_id.substring(8);
            var insertion_no = ds_ref.Tables[0].Rows[i].no_insert;

            if (xtg_matter != null)
                xtg_matter = xtg_matter//+"<$z6>["+adno+"-"+insertion_no+"]<$>";
            if (ds_ref.Tables[0].Rows[i].UOM == "ROL") {
                while (xtg_matter.indexOf("~") >= 0) {
                    xtg_matter = xtg_matter.replace("~", String.fromCharCode(9));
                }
            }
            var localxtgpath = document.getElementById('hiddenxtgfilepath_local').value;
            //localxtgpath="z:";
            localxtgpath = document.getElementById('txtFilepath').value + "\\xtg";
            if (xtg_matter != null && xtg_matter != "0") {
                //xtg_filename=ref_path+ds_ref.Tables[0].Rows[i].file_name;
                //xtg_filename=ds_ref.Tables[0].Rows[i].IP +"\\xtg\\"+ds_ref.Tables[0].Rows[i].file_name;
                xtg_filename = localxtgpath + "\\" + ds_ref.Tables[0].Rows[i].file_name;
                if (fso.FileExists(xtg_filename))
                    var b = fso.OpenTextFile(xtg_filename, 2);
                else
                    var b = fso.CreateTextFile(xtg_filename, 2);
                while (xtg_matter.indexOf("SHREE-KAN7-0851Web") >= 0) {
                    xtg_matter = xtg_matter.replace("SHREE-KAN7-0851Web", "SHREE-KAN7-0850");
                }
                b.Write(xtg_matter);
                b.Close();
            }
            //            
            /////////////////UPDATED BY SAURABH

            //             if(xtg_matter!=null)
            //            {
            //                xtg_filename=ref_path+ds_ref.Tables[0].Rows[i].file_name;
            //                
            //                
            //                                 if(browser!="Microsoft Internet Explorer")
            //                                {
            //                                    var  httpRequest =null;
            //                                    httpRequest= new XMLHttpRequest();
            //                                    if (httpRequest.overrideMimeType) {
            //                                    httpRequest.overrideMimeType('text/xml'); 
            //                                    }
            //                                    
            //                                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
            //                         
            //                                    httpRequest.open( "GET","savereff_file.aspx?xtg_filename="+xtg_filename+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
            //                                    httpRequest.send('');
            //                                    //alert(httpRequest.readyState);
            //                                    if (httpRequest.readyState == 4) 
            //                                    {
            //                                        //alert(httpRequest.status);
            //                                        if (httpRequest.status == 200) 
            //                                        {
            //                                            strtext=httpRequest.responseText;
            //                                        }
            //                                        else 
            //                                        {
            //                                            alert('There was a problem with the request.');
            //                                        }
            //                                    }
            //                                }
            //                           else
            //                           { 
            //                                var xml = new ActiveXObject("Microsoft.XMLHTTP");
            //                                xml.Open( "GET","savereff_file.aspx?pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
            //                                    xml.Send();
            //                                 strtext=xml.responseText;
            //                           }
            //                
            //            
            //            
            //            }             

            //copying xtg into  local file path...            

            //            if(ref_path!=localxtgpath)      
            //            if(xtg_filename!="")      
            //            fso.CopyFile(xtg_filename,localxtgpath);  

        }
        //*************************************************************************
        //generate reference file  

        var catname = "";
        var subcatename = "";
        var edi = "";
        for (var i = 0; i < document.getElementById('ddlEdition').options.length; i++) {
            if (document.getElementById('ddlEdition').options[i].selected == true) {
                if (edi == "")
                    edi = document.getElementById('ddlEdition').options[i].value;
                else
                    edi = edi + "+" + document.getElementById('ddlEdition').options[i].value;
            }
        }
        if (fso.FolderExists(document.getElementById('txtFilepath').value + "Reffile")) {
            a = "";
        }
        else
            var newfolder = fso.CreateFolder(document.getElementById('txtFilepath').value + "Reffile");

        var ref_filename = document.getElementById('txtFilepath').value + "Reffile" + "\\" + edi + "-" + dd + ".txt";
        var mat_ref_filename = document.getElementById('txtFilepath').value + "Reffile" + "\\" + edi + "-" + dd + "-missing.txt";
        if (fso.FileExists(ref_filename))
            var b = fso.OpenTextFile(ref_filename, 2);
        else
            var b = fso.CreateTextFile(ref_filename, 2);

        b.WriteLine(f_hd);
        // for material missing CIOID
        if (fso.FileExists(mat_ref_filename))
            var miss = fso.OpenTextFile(mat_ref_filename, 2);
        else
            var miss = fso.CreateTextFile(mat_ref_filename, 2);

        // b.WriteBlankLines(1);   
        for (var i = 0; i < ds_ref.Tables[0].Rows.length; i++) {
            if (ds_ref.Tables[0].Rows[i].file_name == null)
                miss.WriteLine(ds_ref.Tables[0].Rows[i].cio_booking_id);
            // if(ds_ref.Tables[0].Rows[i].file_name!=null)
            //{
            if (ds_ref.Tables[0].Rows[i].file_name == null) {
                if (ds_ref.Tables[0].Rows[i].IP == null || ds_ref.Tables[0].Rows[i].IP == "")
                    xtg_filename = localxtgpath + "\\" + ds_ref.Tables[0].Rows[i].cio_booking_id + ".txt";
                else {
                    xtg_filename = ds_ref.Tables[0].Rows[i].IP + "\\xtg\\" + ds_ref.Tables[0].Rows[i].cio_booking_id + ".txt";
                    // xtg_filename=localxtgpath + "\\" +ds_ref.Tables[0].Rows[i].cio_booking_id + ".txt"; 
                }
            }
            else {
                if (ds_ref.Tables[0].Rows[i].IP == null || ds_ref.Tables[0].Rows[i].IP == "")
                    xtg_filename = localxtgpath + "\\" + ds_ref.Tables[0].Rows[i].file_name;
                else {
                    xtg_filename = ds_ref.Tables[0].Rows[i].IP + "\\xtg\\" + ds_ref.Tables[0].Rows[i].file_name;
                    // xtg_filename=localxtgpath + "\\" +ds_ref.Tables[0].Rows[i].file_name; 
                }
            }
            if (catname != ds_ref.Tables[0].Rows[i].category) {

                if (ds_ref.Tables[0].Rows[i].catfilename != null) {
                    //b.WriteLine("¶"+eps_path+ds_ref.Tables[0].Rows[i].catfilename+",0.6*1,"+"¶");
                    if (ds_ref.Tables[0].Rows[i].UOM != "ROL") {
                        b.WriteLine("¶" + ds_ref.Tables[0].Rows[i].catfilename + "¶");
                        b.WriteBlankLines(1);
                    }
                }
                else {
                    if (ds_ref.Tables[0].Rows[i].UOM != "ROL") {
                        b.WriteLine("¶" + ds_ref.Tables[0].Rows[i].category + "¶");
                        b.WriteBlankLines(1);
                    }

                }
                catname = ds_ref.Tables[0].Rows[i].category;

            }
            if (ds_ref.Tables[0].Rows[i].Subcategory != null) {
                if (subcatename != ds_ref.Tables[0].Rows[i].Subcategory) {
                    if (ds_ref.Tables[0].Rows[i].CAT2 != null && ds_ref.Tables[0].Rows[i].CAT2 != "") {
                        // if(ds_ref.Tables[0].Rows[i].UOM!="ROL")             
                        b.WriteLine("¶" + ds_ref.Tables[0].Rows[i].CAT2 + "¶");
                    }
                    else if (ds_ref.Tables[0].Rows[i].scatfilename != null && ds_ref.Tables[0].Rows[i].scatfilename != "") {
                        // if(ds_ref.Tables[0].Rows[i].UOM!="ROL")      
                        b.WriteLine("¶" + ds_ref.Tables[0].Rows[i].scatfilename + "¶");
                    }
                    else {
                        // if(ds_ref.Tables[0].Rows[i].UOM!="ROL")
                        b.WriteLine("¶" + ds_ref.Tables[0].Rows[i].Subcategory + "¶");
                    }
                    //  b.WriteBlankLines(1);
                    subcatename = ds_ref.Tables[0].Rows[i].Subcategory;
                }
            }
            //Apply classified booking

            //getting Ad no & insertion number
            // var adno=ds_ref.Tables[0].Rows[i].cio_booking_id.substring(0,3);
            //  adno=adno+"-"+ds_ref.Tables[0].Rows[i].cio_booking_id.substring(8);
            var adno = ds_ref.Tables[0].Rows[i].cio_booking_id;
            var insertion_no = ds_ref.Tables[0].Rows[i].no_insert;


            //            if(ds_ref.Tables[0].Rows[i].rate_code=="CLASS")
            //            {
            if (ds_ref.Tables[0].Rows[i].uom_desc != "CD") {
                //Bold + BGColor + Eye Catcher
                //put condition here

                //BGColor + Eye Catcher
                //////                if(ds_ref.Tables[0].Rows[i].bullet_code=="YE0" && ds_ref.Tables[0].Rows[i].bullet_code=="HA")
                //////                    b.WriteLine("æL,"+xtg_filename+".xtg,K,"+adno+","+insertion_no+","+"æ");
                //////                 
                //////                //Eye Catcher
                //////                 else if(ds_ref.Tables[0].Rows[i].bullet_code=="HA")
                //////                        b.WriteLine("æL,"+xtg_filename+",D,"+adno+","+insertion_no+","+"æ");
                //////               //Drop Char
                //////                 else if(ds_ref.Tables[0].Rows[i].bullet_code=="DR")
                //////                       b.WriteLine("æL,"+xtg_filename+",C,"+adno+","+insertion_no+","+"æ");               
                xtg_filename = xtg_filename.replace(".txt", ".xtg");
                if (ds_ref.Tables[0].Rows[i].bg_color == "YE0") {
                    if (ds_ref.Tables[0].Rows[i].bullet_code == "BO2" || ds_ref.Tables[0].Rows[i].bullet_code == "BO1")
                        b.WriteLine("æL," + xtg_filename + ",R," + adno + "," + insertion_no + ",B," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "BO3")
                        b.WriteLine("æL," + xtg_filename + ",R," + adno + "," + insertion_no + ",D," + "æ");
                    else
                        b.WriteLine("æL," + xtg_filename + ",R," + adno + "," + insertion_no + ",P," + "æ");
                }
                else {
                    if (ds_ref.Tables[0].Rows[i].bullet_code == "YE0")
                        b.WriteLine("æY," + xtg_filename + ",P," + adno + "," + insertion_no + ",P," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "TIO")
                        b.WriteLine("æL," + xtg_filename + ",Y," + adno + "," + insertion_no + ",C," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "TIO")
                        b.WriteLine("æL," + xtg_filename + ",Y," + adno + "," + insertion_no + ",B," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "TI2")
                        b.WriteLine("æL," + xtg_filename + ",Y," + adno + "," + insertion_no + ",H," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "BO0")
                        b.WriteLine("æL," + xtg_filename + ",L," + adno + "," + insertion_no + ",G," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "EY0")
                        b.WriteLine("æL," + xtg_filename + ",L," + adno + "," + insertion_no + ",G," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "BO1")
                        b.WriteLine("æL," + xtg_filename + ",L," + adno + "," + insertion_no + ",E," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "EY3")
                        b.WriteLine("æL," + xtg_filename + ",L," + adno + "," + insertion_no + ",V," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "EY3")
                        b.WriteLine("æL," + xtg_filename + ",L," + adno + "," + insertion_no + ",V," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "TI1")
                        b.WriteLine("æL," + xtg_filename + ",Y," + adno + "," + insertion_no + ",G," + "æ");
                    else if (ds_ref.Tables[0].Rows[i].bullet_code == "TI2")
                        b.WriteLine("æL," + xtg_filename + ",Y," + adno + "," + insertion_no + ",V," + "æ");

                    else {
                        if (ds_ref.Tables[0].Rows[i].UOM == "RO1") {
                            var d = "";
                            if (ds_ref.Tables[0].Rows[i].MATTER != null) {
                                var arr = ds_ref.Tables[0].Rows[i].MATTER.toString().split(" ");
                                if (arr.length > 0)
                                    d = arr[0].toString();

                            }
                            while (d.indexOf(",") >= 0) {
                                d = d.replace(",", "$$");
                            }
                            b.WriteLine("æL," + xtg_filename + ",P," + d + "*" + ds_ref.Tables[0].Rows[i].langindex + "," + insertion_no + ",G," + "æ");

                        }
                        else if (ds_ref.Tables[0].Rows[i].UOM == "RO2") {
                            var d = "";
                            if (ds_ref.Tables[0].Rows[i].MATTER != null) {
                                var arr = ds_ref.Tables[0].Rows[i].MATTER.toString().split(" "); ;
                                for (var i1 = 0; i1 < arr.length; i1++) {
                                    d = d + " " + arr[i1].toString();
                                    if (i1 == 1)
                                        i1 = arr.length;
                                }
                            }
                            while (d.indexOf(",") >= 0) {
                                d = d.replace(",", "$$");
                            }
                            b.WriteLine("æL," + xtg_filename + ",P," + d + "*" + ds_ref.Tables[0].Rows[i].langindex + "," + insertion_no + ",G," + "æ");
                        }
                        else if (ds_ref.Tables[0].Rows[i].UOM == "RO3") {
                            var d = "";
                            if (ds_ref.Tables[0].Rows[i].MATTER != null) {
                                var arr = ds_ref.Tables[0].Rows[i].MATTER.toString().split(" "); ;
                                for (var i1 = 0; i1 < arr.length; i1++) {
                                    d = d + " " + arr[i1].toString();
                                    if (i1 == 2)
                                        i1 = arr.length;
                                }
                            }
                            while (d.indexOf(",") >= 0) {
                                d = d.replace(",", "$$");
                            }
                            b.WriteLine("æL," + xtg_filename + ",P," + d + "*" + ds_ref.Tables[0].Rows[i].langindex + "," + insertion_no + ",G," + "æ");
                        }
                        else if (ds_ref.Tables[0].Rows[i].UOM == "ROL") {
                            b.WriteLine("æL," + xtg_filename + ",P," + "æ");
                        }
                        else
                            b.WriteLine("æL," + xtg_filename + ",L," + adno + "," + insertion_no + ",P," + "æ");
                    }
                }
            }
            else if (ds_ref.Tables[0].Rows[i].uom_desc == "CD") {
                var ref_path_CD_1 = "";
                if (ds_ref.Tables[0].Rows[i].file_name == null) {
                    if (ds_ref.Tables[0].Rows[i].IP == null || ds_ref.Tables[0].Rows[i].IP == "")
                        ref_path_CD_1 = ref_path_CD + ds_ref.Tables[0].Rows[i].cio_booking_id + ".jpg";
                    else {
                        ref_path_CD_1 = ds_ref.Tables[0].Rows[i].IP + "\\eps\\" + ds_ref.Tables[0].Rows[i].cio_booking_id + ".jpg";
                        //  ref_path_CD_1=ref_path_CD +ds_ref.Tables[0].Rows[i].cio_booking_id+".jpg";
                    }
                }
                else {
                    if (ds_ref.Tables[0].Rows[i].IP == null || ds_ref.Tables[0].Rows[i].IP == "")
                        ref_path_CD_1 = ref_path_CD + ds_ref.Tables[0].Rows[i].file_name;
                    else {
                        ref_path_CD_1 = ds_ref.Tables[0].Rows[i].IP + "\\eps\\" + ds_ref.Tables[0].Rows[i].file_name;
                        //  ref_path_CD_1=ref_path_CD+ds_ref.Tables[0].Rows[i].file_name;
                    }
                }
                b.WriteLine("æD," + ref_path_CD_1 + "," + ds_ref.Tables[0].Rows[i].height + "*" + ds_ref.Tables[0].Rows[i].width + "," + adno + "," + insertion_no + "," + ds_ref.Tables[0].Rows[i].cio_booking_id + ",P," + "æ");

            }


            updatestatus = updatestatus + ds_ref.Tables[0].Rows[i].cio_booking_id + "," + ds_ref.Tables[0].Rows[i].no_insert + "," + ds_ref.Tables[0].Rows[i].Edition_Code;
            updatestatus = updatestatus + ";";

            //}                    
        }  //end of for 

        //update status "PUBLISH" for booking for which reference file is generated... genReference      
        //¶nm[hOoV¶
        b.WriteLine("\r\n");

        b.Close();
        miss.Close();

        alert('Flow file generated successfully of Total Ads ' + ds_ref.Tables[0].Rows.length);
        //  uodatebookingstatus();     // for updation insert status publish in booking insert table
        //alert('Flow file generated successfully.');
    } //end of if
    else {
        alert("No Data Found");
    }
    return false;

}


function uodatebookingstatus() {
    // genReference.ReferenceFile(compcode,pubdate,pubcode,centercode,editioncode,suppcode,callbackReferenceFile);
    //genReference.updateClassified1(updatestatus,call_updateClassified12);        

    genReference.bookingstatusupdate(updatestatus, call_bookingstatusupdate);
    return false;
}

function call_bookingstatusupdate(response) {
    if (response.value == "success")
        alert('Flow file generated successfully.');
}



function exitclick() {
    if (confirm("Do you want to close this page?")) {
        window.close();
        return false;
    }
    return false;
}

//function bindEdition()
//{
//    if(document.getElementById('ddlPublication').value=="0")
//    {
//        alert("Please select Publication");
//        return false;
//    }
//    else
//    {
//        var res=genReference.bindEdition(document.getElementById('ddlPublication').value);
//        if(res.value!=null)
//        {
//            var ds=res.value;
//              var pkgitem = document.getElementById("ddlCenter");
//                pkgitem.options.length = 0; 
//                  pkgitem.options[pkgitem.options.length] = new Option('Select','0');
//                   pkgitem.options.length;
//            for(var i=0;i<ds.Tables[0].Rows.length>;i++)
//            {
//                           pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CODE);
//                            pkgitem.options.length;
//            }
//        }
//    }
//}
function bindEdition() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var centercode = document.getElementById('ddlCenter').value;
    var pub = document.getElementById('ddlPublication').value;
    var res = genReference.getCenterWiseEdition(compcode, userid, centercode, pub);
    if (res.value != null) {
        var ds = res.value;
        document.getElementById('ddlEdition').options.length = 0;
        document.getElementById('ddlEdition').options.length;
        if (ds.Tables[0].Rows.length > 0) {
            for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                document.getElementById('ddlEdition').options[document.getElementById('ddlEdition').options.length] = new Option(ds.Tables[0].Rows[i].edition_name, ds.Tables[0].Rows[i].edition_code);
                document.getElementById('ddlEdition').options.length;
            }
        }
    }
}


function CopyEdition() {

    document.getElementById("divloader").style.display = "block";
    document.getElementById('divloader').style.top = "250px";
    document.getElementById('divloader').style.left = "250px";
    //document.getElementById("divloader").style.display = "none";

    // if (browser != "Microsoft Internet Explorer") {
    if (document.getElementById('PubDate').value == "") {
        document.getElementById("divloader").style.display = "none";
        alert("Please Select Date: ");
        document.getElementById('PubDate').focus();

        return false;
    }
    if (document.getElementById('ddlPublication').value == "0") {
        document.getElementById("divloader").style.display = "none";
        alert("Please Select Publication ");
        document.getElementById('ddlPublication').focus();
        return false;
    }
    if (document.getElementById('ddlCenter').value == "0") {
        document.getElementById("divloader").style.display = "none";
        alert("Please Select Center ");
        document.getElementById('ddlCenter').focus();
        return false;
    }
    if (document.getElementById('ddlEdition').value == "0") {
        document.getElementById("divloader").style.display = "none";
        alert("Please Select Edition ");
        document.getElementById('ddlEdition').focus();

        return false;
    }
    if (document.getElementById('ddlSupplement').value == "0") {
        document.getElementById("divloader").style.display = "none";
        alert("Please Select Supplement ");
        document.getElementById('ddlSupplement').focus();
        return false;
    }

    if (document.getElementById('txtFilepath').value == "0") {
        document.getElementById("divloader").style.display = "none";
        alert("Please Enter Path ");
        document.getElementById('txtFilepath').focus();
        return false;
    }
    var pubdate = document.getElementById('PubDate').value;
    var pubcode = document.getElementById('ddlPublication').value;
    var centercode = document.getElementById('ddlCenter').value;
    var editioncode = document.getElementById('ddlEdition').value;
    var edi = "";
    var centername = document.getElementById('ddlCenter').options[document.getElementById('ddlCenter').selectedIndex].text.substring(0, 5);
    for (var i = 0; i < document.getElementById('ddlEdition').options.length; i++) {
        if (document.getElementById('ddlEdition').options[i].selected == true) {
            if (edi == "")
                edi = document.getElementById('ddlEdition').options[i].value;
            else
                edi = edi + "," + document.getElementById('ddlEdition').options[i].value;
        }
    }

    var ref_file_namefinal = "";
    var supplementcode = document.getElementById('ddlSupplement').value;
    var res = genReference.geteditionname("", editioncode, supplementcode);
    if (res.value == null) {
        return true;
    }
    else {
        var ds = res.value;
        ref_file_namefinal = ds.Tables[0].Rows[0].reffilename;
    }

    var strtext = "";
    var currdate = pubdate.split("/");
    var dd = currdate[0];
    if (currdate[0].length == 1)
        dd = "0" + currdate[0];
    var mm = currdate[1];
    if (currdate[1].length == 1)
        mm = "0" + currdate[1];
    var cdate = dd + "-" + mm + "-" + currdate[2];
    var cdatefolder = dd + mm + currdate[2];
    var flag = "1";
    var destinationpath = document.getElementById('txtFilepath').value;
    if (document.getElementById('drpincludeuom').value == "RO1") {
        var sourcepath_xtg = document.getElementById('hiddenclassified_reference').value + "\\" + centername + "\\xtg_obt";
        movefolder(sourcepath_xtg, destinationpath + "\\" + centername + "\\");
    }
    else {
        var sourcepath_xtg = document.getElementById('hiddenclassified_reference').value + "xtg\\" + cdatefolder;
        var dest = destinationpath + centername + "\\xtg\\" + cdatefolder + "\\";
        var fname = "";

        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null;;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

            httpRequest.open("GET", 'customftppage.aspx?xtg_sourcepath=' + sourcepath_xtg + '&xtg_destination=' + dest + '&filename=' + fname + '&bflag=' + flag + '&center=' + centercode + '&pubcode=' + pubcode, false);
            httpRequest.send('');
            if (httpRequest.readyState == 4) {
                if (httpRequest.status == 200) {
                    strtext = httpRequest.responseText;
                }
                else
                    alert('There was a problem with the request.');
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", 'customftppage.aspx?xtg_sourcepath=' + sourcepath_xtg + '&xtg_destination=' + dest + '&filename=' + fname + '&bflag=' + flag + '&center=' + centercode + '&pubcode=' + pubcode, false);
            xml.Send();
            strtext = xml.responseText;
        }
        //***copyfolder(sourcepath_xtg, destinationpath + "\\" + centername + "\\xtg\\", "", "1");
    }

    var sourcepath_pdf = document.getElementById('hiddenclassified_reference').value + "pdf\\" + cdatefolder;
    var dest = destinationpath + centername + "\\pdf\\" + cdatefolder + "\\";
    var fname = "";
    flag = "3";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

        httpRequest.open("GET", 'customftppage.aspx?xtg_sourcepath=' + sourcepath_pdf + '&xtg_destination=' + dest + '&filename=' + fname + '&bflag=' + flag + '&center=' + centercode + '&pubcode=' + pubcode, false);
        httpRequest.send('');

        if (httpRequest.readyState == 4) {
            if (httpRequest.status == 200) {
                strtext = httpRequest.responseText;
            }
            else
                alert('There was a problem with the request.');
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", 'customftppage.aspx?xtg_sourcepath=' + sourcepath_pdf + '&xtg_destination=' + dest + '&filename=' + fname + '&bflag=' + flag + '&center=' + centercode + '&pubcode=' + pubcode, false);
        xml.Send();
        strtext = xml.responseText;
    }
    //***copyfolder(sourcepath_pdf, destinationpath + "\\" + centername + "\\pdf\\", "", "1");

    var sourcepath_reffile = "";
    if (document.getElementById('drpincludeuom').value == "RO1") {
        sourcepath_reffile = document.getElementById('hiddenclassified_reference').value + "\\" + centername + "\\ReferenceFile\\" + "OB0" + "-" + cdate + ".txt";
        copyfolder(sourcepath_reffile, destinationpath + "\\" + centername + "\\ReferenceFile\\", "OB0" + "-" + cdate + ".txt", "2");
    }
    else {
        //sourcepath_reffile = document.getElementById('hiddenclassified_reference').value + centername + "\\ReferenceFile\\" + edi.replace(",", "-") + "-" + cdate + ".txt";
        //sourcepath_reffile = document.getElementById('hiddenclassified_reference').value + "ReferenceFile\\" + edi.replace(",", "-") + "-" + cdate + ".txt";
        sourcepath_reffile = document.getElementById('hiddenclassified_reference').value + "ReferenceFile\\" + ref_file_namefinal.replace(",", "-") + "-" + cdate + ".txt";

        dest = destinationpath + centername + "\\ReferenceFile\\";
        flag = "2";
        var fname = edi.replace(",", "-") + "-" + cdate + ".txt";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null;;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

            httpRequest.open("GET", 'customftppage.aspx?xtg_sourcepath=' + sourcepath_reffile + '&xtg_destination=' + dest + '&filename=' + fname + '&bflag=' + flag + '&center=' + centercode + '&pubcode=' + pubcode, false);
            httpRequest.send('');
            if (httpRequest.readyState == 4) {
                if (httpRequest.status == 200) {
                    document.getElementById("divloader").style.display = "none";
                    strtext = httpRequest.responseText;
                }
                else {
                    document.getElementById("divloader").style.display = "none";
                    alert('There was a problem with the request.');
                }
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", 'customftppage.aspx?xtg_sourcepath=' + sourcepath_pdf + '&xtg_destination=' + dest + '&filename=' + fname + '&bflag=' + flag + '&center=' + centercode + '&pubcode=' + pubcode, false);
            xml.Send();
            strtext = xml.responseText;
        }
        //***copyfolder(sourcepath_reffile, destinationpath + "\\" + centername + "\\ReferenceFile\\", edi.replace(",", "-") + "-" + cdate + ".txt", "2");
    }
    //alert(strtext);
    if (strtext == "Z") {
        document.getElementById("divloader").style.display = "none";
        alert("Copy Successfully Now You Can Flow the AD.");
    }
    if (strtext == "n") {
        document.getElementById("divloader").style.display = "none";
        alert("Failed to delete file on revoke. Try again!");
        return false;
    }
    if (strtext == "T") {
        document.getElementById("divloader").style.display = "none";
        alert("FTP is not defined in ftp centers details table.");
        return false;
    }
    if (strtext.indexOf("FTP") > -1) {
        document.getElementById("divloader").style.display = "none";
        alert(strtext)
    }
    //        alert("Copy Successfully Now You Can Flow the AD.");
    return false;
    //  }
}

function copyfolder(sourcefile, destdir, filefname, fflag) {
    netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');
    var aFile = Components.classes["@mozilla.org/file/local;1"]
    .createInstance(Components.interfaces.nsILocalFile);
    if (!aFile) return false;
    netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');
    // get a component for the directory to copy to
    var aDir = Components.classes["@mozilla.org/file/local;1"].createInstance(Components.interfaces.nsILocalFile);
    if (!aDir) return false;
    // next, assign URLs to the file components
    aFile.initWithPath(sourcefile);
    if (fflag == "1") {
        var pubdate = document.getElementById('PubDate').value;
        var currdate = pubdate.split("/");
        var cdatefolder = currdate[0] + currdate[1] + currdate[2];
        aDir.initWithPath(destdir + "\\" + cdatefolder);
        // if (!aDir.isDirectory())
        // aDir.remove(false);
    }
    if (fflag == "2") {
        aDir.initWithPath(destdir + filefname);
        if (aDir.exists())
            aDir.remove(false);
    }

    aDir.initWithPath(destdir);
    // finally, copy the file, without renaming it
    aFile.copyTo(aDir, null);
    alert(sourcefile + " copied successfully at:  " + destdir);
}

function movefolder(sourcefile, destdir) {
    netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');
    var aFile = Components.classes["@mozilla.org/file/local;1"].createInstance(Components.interfaces.nsILocalFile);
    if (!aFile) return false;
    netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');

    // get a component for the directory to copy to
    var aDir = Components.classes["@mozilla.org/file/local;1"].createInstance(Components.interfaces.nsILocalFile);
    if (!aDir) return false;
    // next, assign URLs to the file components
    aFile.initWithPath(sourcefile);
    // if (aFile.isDirectory()) {       
    aDir.initWithPath(destdir);
    // finally, copy the file, without renaming it
    aFile.moveTo(aDir, null);
    alert(sourcefile + " copied successfully at:  " + destdir);
    //  }
}
function report_click() {
    if (document.getElementById('Chkpackage').checked == true) {
        if (document.getElementById('PubDate').value == "") {
            alert("Please Select Date: ");
            document.getElementById('PubDate').focus();
            return false;
        }
        if (document.getElementById('txtFilepath').value == "0") {
            alert("Please Enter Path ");
            document.getElementById('txtFilepath').focus();
            return false;
        }


        var compcode = document.getElementById('hiddencompcode').value;
        // var userid=document.getElementById('hiddenuserid').value;
        var pubdate = document.getElementById('PubDate').value;
        var pubcode = document.getElementById('ddlPublication').value;

        var logincenter = document.getElementById('hiddenlogincenter').value;



        var dateformat = document.getElementById('hiddendateformat').value;
        var chk = 0;
        if (document.getElementById('chkaudit').checked == true) {
            chk = 1;
        }
        var includeuom = "0";
        var tem_uom_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludeuom').options.length; ui++) {
            if (document.getElementById('drpincludeuom').options[ui].selected == true) {
                if (document.getElementById('drpincludeuom').options[ui].value != "0") {
                    tem_uom_in = document.getElementById('drpincludeuom').options[ui].value;
                    if (includeuom == "0")
                        includeuom = tem_uom_in;
                    else
                        includeuom = includeuom + "," + tem_uom_in;
                }
            }
        }
        var excludeuom = "0";
        var tem_uom_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludeuom').options.length; ui++) {
            if (document.getElementById('drpexcludeuom').options[ui].selected == true) {
                if (document.getElementById('drpexcludeuom').options[ui].value != "0") {
                    tem_uom_ex = document.getElementById('drpexcludeuom').options[ui].value;
                    if (excludeuom == "0")
                        excludeuom = tem_uom_ex;
                    else
                        excludeuom = excludeuom + "," + tem_uom_ex;
                }
            }
        }
        var includecat = "0";
        var tem_cat_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludead').options.length; ui++) {
            if (document.getElementById('drpincludead').options[ui].selected == true) {
                if (document.getElementById('drpincludead').options[ui].value != "0") {
                    tem_cat_in = document.getElementById('drpincludead').options[ui].value;
                    if (includecat == "0")
                        includecat = tem_cat_in;
                    else
                        includecat = includecat + "," + tem_cat_in;
                }
            }
        }
        var excludecat = "0";
        var tem_cat_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludead').options.length; ui++) {
            if (document.getElementById('drpexcludead').options[ui].selected == true) {
                if (document.getElementById('drpexcludead').options[ui].value != "0") {
                    tem_cat_ex = document.getElementById('drpexcludead').options[ui].value;
                    if (excludecat == "0")
                        excludecat = tem_cat_ex;
                    else
                        excludecat = excludecat + "," + tem_cat_ex;
                }
            }
        }

        var browser = navigator.appName;
        var packagecode = "";
        var packagename = "";
        for (var k = 0; k <= document.getElementById("listpackage").length - 1; k++) {
            if (document.getElementById('listpackage').options[k].selected == true) {
                var page = document.getElementById('listpackage').options[k].value;
                if (browser != "Microsoft Internet Explorer") {
                    var abc = document.getElementById('listpackage').options[k].textContent;
                }
                else {
                    var abc = document.getElementById('listpackage').options[k].innerText;
                }

                if (packagecode == "") {
                    packagecode = page;
                    packagename = document.getElementById('listpackage').options[k].text;
                }
                else {
                    packagecode = packagecode + "," + page;
                    packagename = packagename + "," + document.getElementById('listpackage').options[k].text;
                }



            }
        }
        var flag = "1";
        window.open('classified_details_report.aspx?compcode=' + compcode + '&pubdate=' + pubdate + '&packagecode=' + packagecode + '&dateformat=' + dateformat + '&chk=' + chk + '&includeuom=' + includeuom + '&excludeuom=' + excludeuom + '&includecat=' + includecat + '&excludecat=' + excludecat + '&logincenter=' + logincenter + '&physicalpath=' + document.getElementById('txtFilepath').value + '&centername=' + centername + '&pubname=' + pubname + '&ediname=' + ediname + '&suppname=' + suppname + '&flag=' + flag + '&packagename=' + packagename);
        return false;

    }
    else {
        if (document.getElementById('PubDate').value == "") {
            alert("Please Select Date: ");
            document.getElementById('PubDate').focus();
            return false;
        }
        if (document.getElementById('ddlPublication').value == "0") {
            alert("Please Select Publication ");
            document.getElementById('ddlPublication').focus();
            return false;
        }
        if (document.getElementById('ddlCenter').value == "0") {
            alert("Please Select Center ");
            document.getElementById('ddlCenter').focus();
            return false;
        }
        if (document.getElementById('ddlEdition').value == "0") {
            alert("Please Select Edition ");
            document.getElementById('ddlEdition').focus();
            return false;
        }
        if (document.getElementById('ddlSupplement').value == "0") {
            alert("Please Select Supplement ");
            document.getElementById('ddlSupplement').focus();
            return false;
        }

        var compcode = document.getElementById('hiddencompcode').value;
        var pubdate = document.getElementById('PubDate').value;
        var pubcode = document.getElementById('ddlPublication').value;
        var pubname = document.getElementById('ddlPublication').options[document.getElementById('ddlPublication').selectedIndex].text;
        var centercode = document.getElementById('ddlCenter').value;

        var editioncode = document.getElementById('ddlEdition').value;
        var logincenter = document.getElementById('hiddenlogincenter').value;

        var edi = "";
        var ediname = "";
        for (var i = 0; i < document.getElementById('ddlEdition').options.length; i++) {
            if (document.getElementById('ddlEdition').options[i].selected == true) {
                if (edi == "") {
                    edi = document.getElementById('ddlEdition').options[i].value;
                    ediname = document.getElementById('ddlEdition').options[i].text;
                }
                else {
                    edi = edi + "," + document.getElementById('ddlEdition').options[i].value;
                    ediname = ediname + "," + document.getElementById('ddlEdition').options[i].text;
                }
            }
        }
        var suppcode = document.getElementById('ddlSupplement').value;
        var suppname = document.getElementById('ddlSupplement').options[document.getElementById('ddlSupplement').selectedIndex].text;
        var dateformat = document.getElementById('hiddendateformat').value;
        var chk = 0;
        if (document.getElementById('chkaudit').checked == true) {
            chk = 1;
        }
        var includeuom = "0";
        var tem_uom_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludeuom').options.length; ui++) {
            if (document.getElementById('drpincludeuom').options[ui].selected == true) {
                if (document.getElementById('drpincludeuom').options[ui].value != "0") {
                    tem_uom_in = document.getElementById('drpincludeuom').options[ui].value;
                    if (includeuom == "0")
                        includeuom = tem_uom_in;
                    else
                        includeuom = includeuom + "," + tem_uom_in;
                }
            }
        }
        var excludeuom = "0";
        var tem_uom_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludeuom').options.length; ui++) {
            if (document.getElementById('drpexcludeuom').options[ui].selected == true) {
                if (document.getElementById('drpexcludeuom').options[ui].value != "0") {
                    tem_uom_ex = document.getElementById('drpexcludeuom').options[ui].value;
                    if (excludeuom == "0")
                        excludeuom = tem_uom_ex;
                    else
                        excludeuom = excludeuom + "," + tem_uom_ex;
                }
            }
        }
        var includecat = "0";
        var tem_cat_in = "0";
        for (var ui = 0; ui < document.getElementById('drpincludead').options.length; ui++) {
            if (document.getElementById('drpincludead').options[ui].selected == true) {
                if (document.getElementById('drpincludead').options[ui].value != "0") {
                    tem_cat_in = document.getElementById('drpincludead').options[ui].value;
                    if (includecat == "0")
                        includecat = tem_cat_in;
                    else
                        includecat = includecat + "," + tem_cat_in;
                }
            }
        }
        var excludecat = "0";
        var tem_cat_ex = "0";
        for (var ui = 0; ui < document.getElementById('drpexcludead').options.length; ui++) {
            if (document.getElementById('drpexcludead').options[ui].selected == true) {
                if (document.getElementById('drpexcludead').options[ui].value != "0") {
                    tem_cat_ex = document.getElementById('drpexcludead').options[ui].value;
                    if (excludecat == "0")
                        excludecat = tem_cat_ex;
                    else
                        excludecat = excludecat + "," + tem_cat_ex;
                }
            }
        }
        var centername = document.getElementById('ddlCenter').options[document.getElementById('ddlCenter').selectedIndex].text;
        var flag = "0";
        window.open('classified_details_report.aspx?compcode=' + compcode + '&pubdate=' + pubdate + '&pubcode=' + pubcode + '&centercode=' + centercode + '&editioncode=' + edi + '&suppcode=' + suppcode + '&dateformat=' + dateformat + '&chk=' + chk + '&includeuom=' + includeuom + '&excludeuom=' + excludeuom + '&includecat=' + includecat + '&excludecat=' + excludecat + '&logincenter=' + logincenter + '&physicalpath=' + document.getElementById('txtFilepath').value + '&centername=' + centername + '&pubname=' + pubname + '&ediname=' + ediname + '&suppname=' + suppname + '&flag=' + flag);
        return false;
    }
}


function Cheked1() {

    if (document.getElementById('Chkpackage').checked == true) {
        document.getElementById("tdpackage1").style.display = "block";

        document.getElementById("ddlPublication").disabled = true;
        document.getElementById("ddlEdition").disabled = true;
        document.getElementById("ddlCenter").disabled = true;
        document.getElementById("ddlSupplement").disabled = true;
        var adtype = "CL0";
        var channel = "";






        var res = genReference.bindpackage_A_detail(document.getElementById('hiddencompcode').value, adtype, channel);
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
    }

    else {
        document.getElementById("tdpackage1").style.display = "none";

        document.getElementById("ddlPublication").disabled = false;
        document.getElementById("ddlEdition").disabled = false;
        document.getElementById("ddlCenter").disabled = false;
        document.getElementById("ddlSupplement").disabled = false;

    }

}