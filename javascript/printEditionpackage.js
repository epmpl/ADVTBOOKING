var lengNew = "";
var dscombin_code = "";
var connectionString = "";

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
var buf = new StringBuffer();
var buf1 = new StringBuffer();
function trim(stringToTrim) 
 {
	return stringToTrim.replace(/^\s+|\s+$/g,"");
 }
function newclick()
{
chkquery="0";
    changeRate=0;
    hiddentext="new";
    //document.getElementById("lball").disabled = false;
  
    document.getElementById("hiddenchkcount").value = "0";
    document.getElementById("hiddenshow").value = "0";
    document.getElementById("hiddenshow").value = "0";
    document.getElementById("hiddenforfrid").value = "0";
  //  document.getElementById('hiddenbreakup').value="0";
    //document.getElementById("drppubcenter").value = "0";//document.getElementById("hiddenCenter").value;
    
    document.getElementById("drpadtype").disabled = false;
    document.getElementById("drppkgcode").disabled = false;
    document.getElementById("btnNew").disabled = true;
    document.getElementById("btnupdate").style.display = "none";
    //document.getElementById("lball").disabled = false;
    document.getElementById('tableId').style.display = "none";
    document.getElementById('save').style.display = "block";
    document.getElementById('drpadtype').value = "0";
    document.getElementById('drppkgcode').value = "0";
    document.getElementById('drppkgcode').style.display="block"
    //printEditionPackage.bindpackage();
    bindAdType();
    setButtonImages()
    return false;
}
function cancelclick()
{
        document.getElementById("btnupdate").style.display = "none";
    //document.getElementById("lball").disabled = false;
    document.getElementById('tableId').style.display = "none";
    document.getElementById('save').style.display = "none";
    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById("btnExecute").disabled = true;
    //document.getElementById("btnExecute").disabled = true;
    document.getElementById('drpadtype').value="0"
    document.getElementById('drppkgcode').value="0"
    //bindAdType();
    setButtonImages();
    return false;
}
function closerate()
{
    if(confirm("Do you want to skip this page"))
{
window.close();

}
}

function bindAdType()
{
    document.getElementById('drpadtype').value = "0";
    document.getElementById('drppkgcode').value = "0";
    //var res =
     //printEditionPackage.bindpackage();
//    var ds=res.value;
//    
//    var drpadcat=document.getElementById("btnupdate");
//    var i;
//    if(ds!=null)
//    {
//        if(ds.Tables[0].Rows.length>0)
//        {
//            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
//            {
//                drpadcat.options[drpadcat.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name+"+"+ds.Tables[0].Rows[i].combin_code,ds.Tables[0].Rows[i].Combin_Code);
//                drpadcat.options.length;   
//            }
//        }
//    }
    return false;
    

}

function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}

function onchage_adtype()
{
    var adtype = document.getElementById("drpadtype").value;
    //document.getElementById("hiddenadtype").Value = document.getElementById("drpadtype").value;
    
    var drpadcat=document.getElementById("drppkgcode");
    //var drpsubcategory=document.getElementById("drpsubcategory");
    //var drpadscat4=document.getElementById("drpadscat4");
    //var drpadscat5=document.getElementById("drpadscat5");
    //var drpadscat6=document.getElementById("drpadscat6");
    
    //var drpuom=document.getElementById("drpuom");
    //var drppkgcode=document.getElementById("drppkgcode");
    //alert("HI");
    drpadcat.options.length=0;
    drpadcat.options[0]=new Option("--Select Package Name--","0");
    
//    drpsubcategory.options.length=0;
//    drpsubcategory.options[0]=new Option("--Select Sub Category--","0");
//    
//    drpadscat4.options.length=0;
//    drpadscat4.options[0]=new Option("--Select--","0");
//    
//    drpadscat5.options.length=0;
//    drpadscat5.options[0]=new Option("--Select--","0");
//    
//    drpadscat6.options.length=0;
//    drpadscat6.options[0]=new Option("--Select--","0");
//    
//    drpuom.options.length=0;
//    drpuom.options[0]=new Option("--Select UOM--","0");
//    
//    drppkgcode.options.length=0;
//    drppkgcode.options[0]=new Option("--Select Package--","0");

    if (adtype != "0") {
        bind_pkg_adcat_uom(adtype);
    }
    hide_edition();
    return false;
}
function bindPackage()
{
    var adtype = document.getElementById("drpadtype").value;
    printEditionPackage.bindpackage()
    return false;
}

function bind_pkg_adcat_uom(adtype)
{
    var compcode=document.getElementById("hiddencompcode").value;
    //var center=document.getElementById("drppubcenter").value;
  //  printEditionPackage.pkg_adcat_uom_bind(compcode, adtype);
    var res = printEditionPackage.pkg_adcat_uom_bind(compcode, adtype);
    var ds=res.value;
    
    var drpadcat=document.getElementById("drppkgcode");
    var i;
    drpadcat.options.length = ""; 
    drpadcat.options.length=0;
    drpadcat.options[0]=new Option("--Select Package Name--","0");
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadcat.options[drpadcat.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name+"~"+ds.Tables[0].Rows[i].Combin_Code,ds.Tables[0].Rows[i].Combin_Code);
                drpadcat.options.length;   
            }
        }
        
////        if(ds.Tables[1].Rows.length>0)
////        {
////            for (i = 0  ; i < ds.Tables[1].Rows.length; ++i)
////            {
////                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
////                drpuom.options.length;   
////            }
////        }
////        
////        if(ds.Tables[2].Rows.length>0)
////        {
////            for (i = 0  ; i < ds.Tables[2].Rows.length; ++i)
////            {
////                drppkgcode.options[drppkgcode.options.length] = new Option(ds.Tables[2].Rows[i].Package_Name,ds.Tables[2].Rows[i].Combin_Code);
////                drppkgcode.options.length;   
////            }
////        }

//       
    }
return false;
}

function hide_edition() {
        if (document.getElementById('drpadtype').value == 'EL0') {

        }
        if (document.getElementById('drpadtype').value != 'EL0') {


        }
    }
    var g_len="";
 function onchange_drppkgcode()
 {
 var packeg ="";
 var comcin_code = "";
 var noInput = "";

    var adtype = document.getElementById("hiddencompcode").value;
    connectionString = document.getElementById("hiddenrateuniqid").value;
        var mp1 = document.getElementById("drppkgcode").selectedIndex;
    if (mp1 != -1)
        var pack = document.getElementById("drppkgcode").options[mp1].text;
    else
        var pack = "";
    //var pack = document.getElementById("drppkgcode").value;
    var var1 = pack.split('~');
    var len1=var1.length;
    
        packeg = var1[0];
        comcin_code = var1[1];

    var adtype = document.getElementById("drpadtype").value;
    var ds ;
    ds = "";
    ds=  printEditionPackage.getPack( packeg,comcin_code);
    var ss = ds.value;
    if(ss!=null)
    {
    var s=ss.Tables[0].Rows[0].COMBIN_DESC.split('+');
    var tblc = ss.Tables[0].Rows[0];
    var len=s.length;
   g_len =len;
    var creathtml = "";
    var creathtml1 = "";
    for(var j=0;j<len ;j++)
      {
      if(s[j] == "Already added")
      {
          document.getElementById('tableId').style.display = "none";
          document.getElementById('save').style.display = "none";
          alert(s[j])
      }
      else
      {
        creathtml += "<tr>";
        creathtml += "<td style='border:0px solid #7DAAE3;height:50px;'>";
           creathtml += "<input style='width:210px;' type='text' readonly size='10' id='name_" + j + "' value= '"+s[j]+"' font face='arial'   />";
          
           creathtml += "</td>";

       
//         creathtml1 += "</tr>";
//         creathtml1 += "<tr>";
            creathtml1 += "<td style='border:0px solid #7DAAE3;height:75px;'>";
           creathtml1 += " <select id=drop_" + j + " style='height:22px' ><option  value=Y>Yes</option><option value=N>No</option></select>";
            
           creathtml1 += "</td>";
        
 creathtml1 += "</tr>";
      document.getElementById('tableId').style.display = "block";
    document.getElementById('save').style.display="block";
    document.getElementById('slId').style.display="none";
    document.getElementById('slhed').style.display="none";
 }
 }
 
   

   execute_data = 0;
    
   document.getElementById("name").innerHTML =  creathtml;
    document.getElementById("drop").innerHTML =  creathtml1;
    document.getElementById("bindAllPackege").enable = true;
}
    return false;
     
}


function insertEditPackeg()
 {
 var packeg ="";
 var comcin_code = "";
 var noInput = "";
 var comp_code = document.getElementById("hiddencompcode").value;
 var adtype = document.getElementById("drpadtype").value;
    var getName = document.getElementById('name');
    var flag = document.getElementById('drop');
//    var pack = document.getElementById("drppkgcode").value;
var mp1 = document.getElementById("drppkgcode").selectedIndex;
    if (mp1 != -1)
        var pack = document.getElementById("drppkgcode").options[mp1].text;
    else
        var pack = "";
    var var1 = pack.split('~');
    var len1=var1.length;
    
        packeg = var1[0];
        comcin_code = var1[1];
    for (var i = 0  ; i < g_len; i++)
     {
       //var namepackage = document.getElementById('slId_' + i).value;
       var namepackage = document.getElementById('name_' + i).value;
       var flag1 = document.getElementById('drop_' + i).value;
       var gg ="";
       gg = printEditionPackage.insertPack(namepackage,flag1,packeg,comcin_code,adtype,comp_code)
     }
     alert("Save Successfully")
     return false;
    
 }
 
 function queryclick1()
{
    
    document.getElementById("drpadtype").disabled = false;
    document.getElementById("drppkgcode").disabled = false;
    document.getElementById("btnNew").disabled = true;
    document.getElementById("btnQuery").disabled = true;
    document.getElementById("btnupdate").style.display="none";
    document.getElementById('tableId').style.display = "none";
    document.getElementById('save').style.display = "none";
    setButtonImages()
    document.getElementById("btnExecute").disabled = false;
    setButtonImages();
    return false;
}

function executeclick()
{
    var packeg ="";
 var comcin_code = "";
 var noInput = "";
 var res ="";
 var res1 ="";
  var ds1 = "";
 var ds2 = "";
 var leng = "";
 var creathtml = "";
 var creathtml1 = "";
 var creathtml2 = "";
 var comp_code = document.getElementById("hiddencompcode").value;
 var adtype=document.getElementById('drpadtype').value;
 var drpadcat=document.getElementById("drppkgcode");
 var drppkgcode=document.getElementById('drppkgcode').value;

    lengNew = 0;
    bindAdtypeddl();
    //document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].combin_code;
    //document.getElementById('drppkgcode').value = dscombin_code.Tables[0].Rows[lengNew].package_name;

      bindGrid();
    
    document.getElementById('tableId').style.display = "block";
    document.getElementById('save').style.display="none";
    document.getElementById('slId').style.display="block";
    document.getElementById('slhed').style.display="block";
    document.getElementById("btnupdate").style.display="block";
    //document.getElementById('btnfirst').style.display = "block";
    //document.getElementById('btnprevious').style.display="block";
    document.getElementById("drpadtype").disabled = true;
    document.getElementById("drppkgcode").disabled = true;
    document.getElementById("btnnext").disabled = false;
    document.getElementById("btnlast").disabled = false;
    setButtonImages();
 return false;
 }
 
 function bindAdtypeddl()
 {
   var comp_code = document.getElementById("hiddencompcode").value;
   connectionString = document.getElementById("hiddenrateuniqid").value;
   var ds1 = "";
   ds1 = printEditionPackage.getTableOnQuery(comp_code);
   var drpadcat=document.getElementById("drppkgcode");
    //adtype=document.getElementById('drpadtype').value;
    dscombin_code=ds1.value;
    //drpadcat.options.length = 0;
        
        if(dscombin_code!=null)
        {
        if(dscombin_code.Tables[0].Rows.length>0)
            {
                for (i = 0  ; i < dscombin_code.Tables[0].Rows.length; ++i)
                {
                    drpadcat.options[drpadcat.options.length] = new Option(dscombin_code.Tables[0].Rows[i].PACKAGE_NAME,dscombin_code.Tables[0].Rows[i].COMBIN_CODE);
                    drpadcat.options.length;   
                }
            }
            document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].ADTYPE;
          document.getElementById("drppkgcode").value = dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE;
        }
    
     
 }


function updateEditPackeg()
 {
 var packeg ="";
 var comcin_code = "";
 var noInput = "";
    var getName = document.getElementById('name');
    var flag = document.getElementById('drop');
    var mp1 = document.getElementById("drppkgcode").selectedIndex;
    if (mp1 != -1)
        var pack = document.getElementById("drppkgcode").options[mp1].text;
    else
        var pack = "";
    //var pack = document.getElementById("drppkgcode").name;
    var var1 = pack.split('~');
    var len1=var1.length;
    
        packeg = var1[0];
        comcin_code = var1[1];
    for (var i = 0  ; i < g_len; i++)
     {
       var id = document.getElementById('slId_' + i).value;
       var namepackage = document.getElementById('name_' + i).value;
       var flag1 = document.getElementById('drop_' + i).value;
       var ds = printEditionPackage.updatePack(flag1,id)
     }
     alert("Save Successfully")
     return false;
    
 }
 
 function bindGrid()
 {
     var packeg ="";
 var comcin_code = "";
 var noInput = "";
 var res ="";
 var res1 ="";
  var ds1 = "";
 var ds2 = "";
 var leng = "";
 var creathtml = "";
 var creathtml1 = "";
 var creathtml2 = "";
          var comp_code = document.getElementById("hiddencompcode").value;
      res1 = printEditionPackage.executePrintEdition(comp_code,"",dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE);
      ds2 = res1.value;
      g_len = ds2.Tables[0].Rows.length;
      if(ds2!=null)
      {
        
        for(var j=0;j<ds2.Tables[0].Rows.length ;j++)
      {

           creathtml2 += "<tr>";
           creathtml2 += "<td style='border:0px solid #7DAAE3;height:50px;'>";
           creathtml2 += "<input  style='width:50px;'  type='text' readonly size='10' id='slId_" + j + "' value= '"+ds2.Tables[0].Rows[j].ID+"' font face='arial'   />";
          
           creathtml2 += "</td>";
           creathtml += "<td style='border:0px solid #7DAAE3;height:50px;'>";
           creathtml += "<input style='width:210px;' type='text' readonly  size='10' id='name_" + j + "' value= '"+ds2.Tables[0].Rows[j].PACK_NAME+"' font face='arial'   />";
          
           creathtml += "</td>";

       
       
            creathtml1 += "<td style='border:0px solid #7DAAE3;height:75px;'>";
            if(trim(ds2.Tables[0].Rows[j].FLAG) =="Y")
            {
                creathtml1 += " <select id=drop_" + j + " style='height:22px' ><option  value=Y>Yes</option><option value=N>No</option></select>";
            }
            else
            {
            
                creathtml1 += " <select id=drop_" + j + " style='height:22px' ><option value=N>No</option><option  value=Y>Yes</option></select>";
            }
            creathtml1 += "</td>";
        
            creathtml1 += "</tr>";
      }
      //document.getElementById('btnupdate').style.display="none";
      document.getElementById("slId").innerHTML =  creathtml2; 
      document.getElementById("name").innerHTML =  creathtml;
      document.getElementById("drop").innerHTML =  creathtml1;
      document.getElementById("bindAllPackege").enable = true;
    }
 }
 
 function nextclick()
{
    lengNew++;
    if(lengNew>=dscombin_code.Tables[0].Rows.length-1)
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
        document.getElementById('save').disabled = true;
        document.getElementById('btnupdate').style.display="block";
        document.getElementById("drpadtype").disabled = true;
        document.getElementById("drppkgcode").disabled = true;
        document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].ADTYPE;
        document.getElementById("drppkgcode").value = dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE;
        //lengNew=dscombin_code.Tables[0].Rows.length-1;
       // bindAdtypeddl();
    }
    else
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
        document.getElementById('btnupdate').style.display="block";
        document.getElementById("drpadtype").disabled = true;
        document.getElementById("drppkgcode").disabled = true;
        document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].ADTYPE;
        document.getElementById("drppkgcode").value = dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE;
    }
    bindGrid();
    setButtonImages();
    return false;
}

function prevclick()
{
    lengNew--;
    if(lengNew<=0)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
        document.getElementById("drpadtype").disabled = true;
        document.getElementById('btnupdate').style.display="block";
        document.getElementById("drppkgcode").disabled = true;
        document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].ADTYPE;
        document.getElementById("drppkgcode").value = dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE;
        lengNew=0;
    }
    else
    {
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
        document.getElementById("drpadtype").disabled = true;
        document.getElementById('btnupdate').style.display="block";
        document.getElementById("drppkgcode").disabled = true;
        document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].ADTYPE;
        document.getElementById("drppkgcode").value = dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE;
    }
    bindGrid();
    setButtonImages()
    return false;
}

function lastclick()
{
    lengNew=dscombin_code.Tables[0].Rows.length-1
    
    document.getElementById("btnfirst").disabled=false;
    document.getElementById("btnprevious").disabled=false;
    document.getElementById("btnnext").disabled=true;
    document.getElementById("btnlast").disabled=true;
    document.getElementById("drpadtype").disabled = true;
    document.getElementById('btnupdate').style.display="block";
    document.getElementById("drppkgcode").disabled = true;
    document.getElementById('drpadtype').value = dscombin_code.Tables[0].Rows[lengNew].ADTYPE;
        document.getElementById("drppkgcode").value = dscombin_code.Tables[0].Rows[lengNew].COMBIN_CODE;
    bindGrid();
    setButtonImages();
    return false;
}

function firstclick()
{
    lengNew=0;
    
    document.getElementById("btnfirst").disabled=true;
    document.getElementById("btnprevious").disabled=true;
    document.getElementById("btnnext").disabled=false;
    document.getElementById("btnlast").disabled=false;
    document.getElementById("drpadtype").disabled = true;
    document.getElementById("drppkgcode").disabled = true;
    document.getElementById('btnupdate').style.display="block";
    bindGrid();
    setButtonImages();
    return false;
}




function onload1() {


    document.getElementById("btnNew").disabled = false;
   

    document.getElementById("btnQuery").disabled = false;
    document.getElementById("btnSave").disabled = true;
    document.getElementById("btnModify").disabled = true;
    
    document.getElementById("btnExecute").disabled = true;
    document.getElementById("btnfirst").disabled = true;
    document.getElementById("btnprevious").disabled = true;
    document.getElementById("btnnext").disabled = true;
    document.getElementById("btnlast").disabled = true;
    document.getElementById("btnDelete").disabled = true;
    document.getElementById('btnCancel').disabled = false;

    document.getElementById('save').style.display = "none"
    document.getElementById('btnupdate').style.display = "none"
    document.getElementById('drpadtype').value = ""
    document.getElementById('drppkgcode').value = ""
    document.getElementById('tableId').style.display = "none"
    
    document.getElementById('tableId').style.display = "none"
    document.getElementById('tableId').style.display = "none"
    document.getElementById("drpadtype").disabled = true;
    document.getElementById("drppkgcode").disabled = true;

    setButtonImages();

}