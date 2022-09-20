// JScript File

var browser = navigator.appName;
var listbox111 = new Array(64);
var listbox222 = new Array(64);
var j=0;
var count1=0;
//var k=0;

var listbox111datewise = new Array(27);
var listbox222datewise = new Array(27);


listbox111[0] = "Booking Id";
listbox111[1] = "Booking Date/Bill No";
listbox111[2] = "Agency Name";
listbox111[3] = "Client Name";
listbox111[4] = "RO No.";
listbox111[5] = "RO Date";
listbox111[6] = "Exe/Ret Name";
listbox111[7] = "Booking Type";
listbox111[8] = "Color";
listbox111[9] = "Ad Cat";
listbox111[10] = "Ad Subcat";
listbox111[11] = "Ad Subcat3";
listbox111[12] = "Ad Subcat4";
listbox111[13] = "Package";
listbox111[14] = "Publish Date/Bill Date";
listbox111[15] = "No of Ins.";
listbox111[16] = "Paid Ins.";
listbox111[17] = "AdSize(H*W)";
listbox111[18] = "Area";
listbox111[19] = "Page Prem.";
listbox111[20] = "Position Prem.";
listbox111[21] = "Scheme Type";
listbox111[22] = "Rate Code";
listbox111[23] = "Card Rate";
listbox111[24] = "Card Amt";
listbox111[25] = "Contract Rate";
listbox111[26] = "Deviation Amt";
listbox111[27] = "Deviation(%)";
listbox111[28] = "Agg Rate";
listbox111[29] = "Agg Amt";
listbox111[30] = "Disc Amt";
listbox111[31] = "Disc(%)";
listbox111[32] = "Post Prem Amt";
listbox111[33] = "Post Prem(%)";
listbox111[34] = "Sp. Disc Amt";
listbox111[35] = "Sp. Disc(%)";
listbox111[36] = "Space Disc Amt";
listbox111[37] = "Space Disc(%)";
listbox111[38] = "Special Charges";
listbox111[39] = "Ag. Addl. TD Amt";
listbox111[40] = "Ag. Addl. TD(%)";
listbox111[41] = "Gross Amt";
listbox111[42] = "Retainer TD Amt";
listbox111[43] = "Retainer TD(%)";
listbox111[44] = "Ag. TD Amt";
listbox111[45] = "Ag. TD(%)";
listbox111[46] = "Billing Amt";
listbox111[47] = "Ret. Comm. Amt";
listbox111[48] = "Ret. Comm(%)";
listbox111[49] = "Actual Business";
listbox111[50] = "Revenue Center";
listbox111[51] = "Uom";
listbox111[52] = "Publication";
listbox111[53] = "Edition";
listbox111[54] = "Printing Center";
listbox111[55] = "Branch";
listbox111[56] = "District";
listbox111[57] = "Taluka";
listbox111[58] = "Page No";
listbox111[59] = "Cash Disc";
listbox111[60] = "Box Code";
listbox111[61] = "Status";
listbox111[62] = "User Id";
listbox111[63] = "User Name";
listbox111[64] = "Bill Remark";
listbox111[65] = "Product";
listbox111[66] = "Brand";
listbox111[67] = "Varient";
listbox111[68] = "Caption";
listbox111[69] = "FMG Reason";
listbox111[70] = "No of Insertion";


listbox111datewise[0] = "Date";
listbox111datewise[1] = "No. Ins";
listbox111datewise[2] = "Paid Ins";
listbox111datewise[3] = "Area";
//listbox111datewise[3] = "Page Prem.";
listbox111datewise[4] = "Card Amt";
listbox111datewise[5] = "Dvtn. Amt";
listbox111datewise[6] = "Dvtn. (%)";
listbox111datewise[7] = "Agrd. Amt";
listbox111datewise[8] = "Disc Amt";
listbox111datewise[9] = "Disc (%)";
listbox111datewise[10] = "Post Prem. Amt.";
listbox111datewise[11] = "Post Prem.(%)";
listbox111datewise[12] = "Sp. Disc Amt";
listbox111datewise[13] = "Sp. Disc (%)";
listbox111datewise[14] = "Ex. Disc Amt";
listbox111datewise[15] = "Ex. Disc (%)";
listbox111datewise[16] = "Sp. Charges";
listbox111datewise[17] = "Add. Age. Td.Amt";
listbox111datewise[18] = "Add. Age. Td.(%)";
listbox111datewise[19] = "Gr. Amt";
listbox111datewise[20] = "Ret. Td.Amt";
listbox111datewise[21] = "Ret. Td.(%)";
listbox111datewise[22] = "Age. TD Amt";
listbox111datewise[23] = "Age. TD (%)";
listbox111datewise[24] = "BK.Amt";
listbox111datewise[25] = "Ret. Comm Amt";
listbox111datewise[26] = "Ret. Comm (%)";
listbox111datewise[27] = "Actl. Bus.";



function bindQBC()
{

var compcode=document.getElementById('hdncompcode').value;
var pubcent=document.getElementById('dpprintcenter').value;
var pub=document.getElementById('dppublication').value;
//billwismxls.bindedition(pub,pubcent,compcode,call_editionbind);
billwisexls.bindedition_print(pub, pubcent, compcode, call_editionbind1);

billwisexls.fillQBC(document.getElementById('dpprintcenter').value, bindQBC_callback);
}
function bindQBC_callback(response)
{
    var ds=response.value;
    agcatby = document.getElementById("dpbranch");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("Select Branch","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
       agcatby.options.length;
       
    }
    }
}


function editionbind()
{
var compcode=document.getElementById('hdncompcode').value;
var pubcent=document.getElementById('dpprintcenter').value;
var pub=document.getElementById('dppublication').value;
//if(pubcent=="0")
//billwismxls.bindedition1(compcode,pub,call_editionbind1);
//else
//billwismxls.bindedition(pub,pubcent,compcode,call_editionbind);
billwisexls.bindedition_print(pub, pubcent, compcode, call_editionbind1);
}
function call_editionbind1(response)
{

ds= response.value;
    var edition=document.getElementById('dpedition');
    edition.options.length=0;
    edition.options[0]=new Option("Select Edition");
    document.getElementById("dpedition").options.length = 1;
    

             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Alias,ds.Tables[0].Rows[i].Edition_Code);
                edition.options.length;    
             }
          
 
       return false
}


//function call_editionbind(response)
//{

//ds= response.value;
//    var edition=document.getElementById('dpedition');
//    edition.options.length=0;
//    edition.options[0]=new Option("Select Edition");
//    document.getElementById("dpedition").options.length = 1;
//    

//             for(var i=0; i<ds.Tables[0].Rows.length; i++)
//             {
//                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias,ds.Tables[0].Rows[i].edition_code);
//                edition.options.length;    
//             }
//          
// 
//       return false
//}

function citybind()
{
var compcode=document.getElementById('hdncompcode').value;
var district=document.getElementById('dpdistrict').value;
billwisexls.bindcity1(district, compcode, call_citybind);

}

function call_citybind(response)
{

ds= response.value;
    var city=document.getElementById('dpcity');
    city.options.length=0;
    city.options[0]=new Option("Select City");
    document.getElementById("dpcity").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
//                city.options[city.options.length] = new Option(ds.Tables[0].Rows[i].City_Code,ds.Tables[0].Rows[i].City_Name);
                  city.options[city.options.length] = new Option(ds.Tables[0].Rows[i].CityName,ds.Tables[0].Rows[i].CityCode);
                city.options.length;    
             }
 }         
 
       return false;
}


/////////////////////////////////////////////////
function bind_taluka()
{
var compcode=document.getElementById('hdncompcode').value;
var district=document.getElementById('dpdistrict').value;
billwisexls.bindtaluka(compcode, district, call_bind_taluka);

}

function call_bind_taluka(response)
{

ds= response.value;
    var city=document.getElementById('dptaluka');
    city.options.length=0;
    city.options[0]=new Option("Select Taluka");
    document.getElementById("dptaluka").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 city.options[city.options.length] = new Option(ds.Tables[0].Rows[i].taluname,ds.Tables[0].Rows[i].talucode);
                city.options.length;    
             }
 }         
 
       return false;
}

////////////////////////////////////////////////
function suppbind()
{

var compcode=document.getElementById('hdncompcode').value;
var edition=document.getElementById('dpedition').value;
billwisexls.bindsupp(compcode, edition, call_suppbind);
}
function call_suppbind(response)
{
ds= response.value;
    var edition=document.getElementById('dpsuppliment');
    edition.options.length=0;
    edition.options[0]=new Option("Select Supplement");
    document.getElementById("dpsuppliment").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
                edition.options.length;    
             }
 }         
 
       return false;

}


function agencybind()
{

var compcode=document.getElementById('hdncompcode').value;
var agtype=document.getElementById('dpagencytype').value;
billwisexls.bindag(compcode, agtype, call_agbind);
}
function call_agbind(response)
{
ds= response.value;
    var agency=document.getElementById('dpagency');
    agency.options.length=0;
    agency.options[0]=new Option("Select Agency");
    document.getElementById("dpagency").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 agency.options[agency.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name,ds.Tables[0].Rows[i].Agency_Code);
                agency.options.length;    
             }
 }         
 
       return false;

}
function bindbrand()
{
var compcode=document.getElementById('hdncompcode').value;
var prod=document.getElementById('dpproduct').value;
billwisexls.bindbrand(compcode, prod, call_prodbind);
}
function call_prodbind(response)
{
ds= response.value;
    var brand=document.getElementById('dpbrand');
    brand.options.length=0;
    brand.options[0]=new Option("Select Brand");
    document.getElementById("dpbrand").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].brand_name,ds.Tables[0].Rows[i].brand_code);
                brand.options.length;    
             }
 }         
 
       return false;
}

function bindvarient()
{
var compcode=document.getElementById('hdncompcode').value;
var brand=document.getElementById('dpbrand').value;
billwisexls.varientbind(compcode, brand, call_varientbind);
}
function call_varientbind(response)
{
ds= response.value;
    var brand=document.getElementById('dpvarient');
    brand.options.length=0;
    brand.options[0]=new Option("Select Varient");
    document.getElementById("dpvarient").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].varient_name,ds.Tables[0].Rows[i].varient_code);
                brand.options.length;    
             }
 }         
 
       return false;
}


function bindadcat1()
{
var compcode=document.getElementById('hdncompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
report2.adcatbnd(adtype1,compcode,call_adcatbind1);
//billwismxls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_adcatbind1(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcatgory');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                brand.options.length;    
             }
 }         
 
       return false;
}
///////////////////////////////////////////////////
function bindadcat()
{
var compcode=document.getElementById('hdncompcode').value;
var adtype1=document.getElementById('dpadtype').value;
billwisexls.adcatbnd(adtype1, compcode, call_adcatbind);
//billwismxls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_adcatbind(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcat');
    brand.options.length=0;
    brand.options[0]=new Option("Select AdCat");
    document.getElementById("dpadcat").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                brand.options.length;    
             }
 }         
 
       return false;
}
function bindsubcat()
{
var compcode=document.getElementById('hdncompcode').value;
var adcat1=document.getElementById('dpadcat').value;
billwisexls.subcatbind(compcode, adcat1, call_adsubcatbind);

}
function call_adsubcatbind(response)
{
ds= response.value;
    var brand=document.getElementById('dpadsubcat');
    brand.options.length=0;
    brand.options[0]=new Option("Select AdSubCat");
    document.getElementById("dpadsubcat").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
                brand.options.length;    
             }
 }         
 
       return false;
}

function bindsubcat345(id)
{

var compcode=document.getElementById('hdncompcode').value;
if(id=='dpadsubcat')
{
var adsubcat1=document.getElementById('dpadsubcat').value;
billwisexls.subcat345(adsubcat1, compcode, "", "", call_adsubcat345);
}
else if(id=='dpadsubcat3')
{
var adsubcat3=document.getElementById('dpadsubcat3').value;
billwisexls.subcat345("", compcode, adsubcat3, "", call_adsubcat4);
}
else if(id=='dpadsubcat4')
{
var adsubcat4=document.getElementById('dpadsubcat4').value;
billwisexls.subcat345("", compcode, "", adsubcat4, call_adsubcat5);
}

}

function call_adsubcat345(response)
{
ds= response.value;

    var brand=document.getElementById('dpadsubcat3');
    brand.options.length=0;
    brand.options[0]=new Option("Select AdSubCat3");
    document.getElementById("dpadsubcat3").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
                brand.options.length;    
             }
 }         
 
  /*var edition=document.getElementById('dpadsubcat4');
    edition.options.length=0;
    edition.options[0]=new Option("Select AdSubCat4");
    document.getElementById("dpadsubcat4").options.length = 1;
    

if(ds.Tables[1].Rows.length>0)
{
             for(var i=0; i<ds.Tables[1].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[1].Rows[i].Cat_Name,ds.Tables[1].Rows[i].Cat_Code);
                edition.options.length;    
             }
 }
             
     var agency=document.getElementById('dpadsubcat5');
    agency.options.length=0;
    agency.options[0]=new Option("Select AdSubCat5");
    document.getElementById("dpadsubcat5").options.length = 1;
    

if(ds.Tables[2].Rows.length>0)
{
             for(var i=0; i<ds.Tables[2].Rows.length; i++)
             {
                 agency.options[agency.options.length] = new Option(ds.Tables[2].Rows[i].Cat_Name,ds.Tables[2].Rows[i].Cat_Code);
                agency.options.length;    
             }
 }  */    
 
       return false;
}

function call_adsubcat4(response)
{  
     ds= response.value;
    var edition=document.getElementById('dpadsubcat4');
    edition.options.length=0;
    edition.options[0]=new Option("Select AdSubCat4");
    document.getElementById("dpadsubcat4").options.length = 1;
    

if(ds.Tables[1].Rows.length>0)
{
             for(var i=0; i<ds.Tables[1].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[1].Rows[i].Cat_Name,ds.Tables[1].Rows[i].Cat_Code);
                edition.options.length;    
             }
 }
 
  return false;
}

function call_adsubcat5(response)
{  
   ds= response.value;
    var agency=document.getElementById('dpadsubcat5');
    agency.options.length=0;
    agency.options[0]=new Option("Select AdSubCat5");
    document.getElementById("dpadsubcat5").options.length = 1;
    

if(ds.Tables[2].Rows.length>0)
{
             for(var i=0; i<ds.Tables[2].Rows.length; i++)
             {
                 agency.options[agency.options.length] = new Option(ds.Tables[2].Rows[i].Cat_Name,ds.Tables[2].Rows[i].Cat_Code);
                agency.options.length;    
             }
 }      
 
       return false;
}
//function allchk()
//{
//if(document.getElementById('chkall').checked==false)
//{
//document.getElementById('chkall').checked=false;
//document.getElementById('chkbookid').checked=false;
//document.getElementById('chkbookdate').checked=false;
//document.getElementById('chkagencyname').checked=false;
//document.getElementById('chkclientname').checked=false;
//document.getElementById('chkrono').checked=false;
//document.getElementById('chkrodate').checked=false;
//document.getElementById('chkexe').checked=false;
//document.getElementById('chkbooktype').checked=false;
//document.getElementById('chkcolor').checked=false;
//document.getElementById('chkadcat').checked=false;
//document.getElementById('chkadsubcat').checked=false;
//document.getElementById('chkadsubcat3').checked=false;
//document.getElementById('chkadsubcat4').checked=false;
//document.getElementById('chkpackage').checked=false;
//document.getElementById('chkpubdate').checked=false;
//document.getElementById('chknoins').checked=false;
//document.getElementById('chkpaidins').checked=false;
//document.getElementById('chkadsize').checked=false;
//document.getElementById('chkarea').checked=false;
//document.getElementById('chkpageprem').checked=false;
//document.getElementById('chkposprem').checked=false;
//document.getElementById('chkscheme').checked=false;
//document.getElementById('chkrate').checked=false;
//document.getElementById('chkcardrate').checked=false;
//document.getElementById('chkcardamt').checked=false;
//document.getElementById('chkcontract').checked=false;
//document.getElementById('chkdevamt').checked=false;
//document.getElementById('chkdevper').checked=false;
//document.getElementById('chkagrate').checked=false;
//document.getElementById('chkagamt').checked=false;
//document.getElementById('chkdiscamt').checked=false;
//document.getElementById('chkdiscper').checked=false;
//document.getElementById('chkpospremamt').checked=false;
//document.getElementById('chkpospremper').checked=false;
//document.getElementById('chkspdiscamt').checked=false;
//document.getElementById('chkspdiscper').checked=false;
//document.getElementById('chkspacediscamt').checked=false;
//document.getElementById('chkspacediscper').checked=false;
//document.getElementById('chkspcharge').checked=false;
//document.getElementById('chkagadtdamt').checked=false;
//document.getElementById('chkagadtdper').checked=false;
//document.getElementById('chkgrossamt').checked=false;
//document.getElementById('chkrettdamt').checked=false;
//document.getElementById('chkrettdper').checked=false;
//document.getElementById('chkagtdamt').checked=false;
//document.getElementById('chkagtdper').checked=false;
//document.getElementById('chkbillamt').checked=false;
//document.getElementById('chkretcomamt').checked=false;
//document.getElementById('chkretcomper').checked=false;
//document.getElementById('chkactbusiness').checked=false;
//document.getElementById('chkrevcenter').checked=false;


//}
//else
//{
//document.getElementById('chkall').checked=true;
//document.getElementById('chkbookid').checked=true;
//document.getElementById('chkbookdate').checked=true;
//document.getElementById('chkagencyname').checked=true;
//document.getElementById('chkclientname').checked=true;
//document.getElementById('chkrono').checked=true;
//document.getElementById('chkrodate').checked=true;
//document.getElementById('chkexe').checked=true;
//document.getElementById('chkbooktype').checked=true;
//document.getElementById('chkcolor').checked=true;
//document.getElementById('chkadcat').checked=true;
//document.getElementById('chkadsubcat').checked=true;
//document.getElementById('chkadsubcat3').checked=true;
//document.getElementById('chkadsubcat4').checked=true;
//document.getElementById('chkpackage').checked=true;
//document.getElementById('chkpubdate').checked=true;
//document.getElementById('chknoins').checked=true;
//document.getElementById('chkpaidins').checked=true;
//document.getElementById('chkadsize').checked=true;
//document.getElementById('chkarea').checked=true;
//document.getElementById('chkpageprem').checked=true;
//document.getElementById('chkposprem').checked=true;
//document.getElementById('chkscheme').checked=true;
//document.getElementById('chkrate').checked=true;
//document.getElementById('chkcardrate').checked=true;
//document.getElementById('chkcardamt').checked=true;
//document.getElementById('chkcontract').checked=true;
//document.getElementById('chkdevamt').checked=true;
//document.getElementById('chkdevper').checked=true;
//document.getElementById('chkagrate').checked=true;
//document.getElementById('chkagamt').checked=true;
//document.getElementById('chkdiscamt').checked=true;
//document.getElementById('chkdiscper').checked=true;
//document.getElementById('chkpospremamt').checked=true;
//document.getElementById('chkpospremper').checked=true;
//document.getElementById('chkspdiscamt').checked=true;
//document.getElementById('chkspdiscper').checked=true;
//document.getElementById('chkspacediscamt').checked=true;
//document.getElementById('chkspacediscper').checked=true;
//document.getElementById('chkspcharge').checked=true;
//document.getElementById('chkagadtdamt').checked=true;
//document.getElementById('chkagadtdper').checked=true;
//document.getElementById('chkgrossamt').checked=true;
//document.getElementById('chkrettdamt').checked=true;
//document.getElementById('chkrettdper').checked=true;
//document.getElementById('chkagtdamt').checked=true;
//document.getElementById('chkagtdper').checked=true;
//document.getElementById('chkbillamt').checked=true;
//document.getElementById('chkretcomamt').checked=true;
//document.getElementById('chkretcomper').checked=true;
//document.getElementById('chkactbusiness').checked=true;
//document.getElementById('chkrevcenter').checked=true;
//}

////return false;

//}

function allchk()
{
if(document.getElementById('RadioButton2').checked == true)
   
   {
   
    var listbox1j= document.getElementById('Listavilfield');
        var listbox2j= document.getElementById('Listselfield');
        for(var i=listbox2j.options.length - 1 ; i >=0; i--)
        {
         
            listbox2j.options[i] = null;
          
        }
        listbox2j.selectedIndex = -1;
//        ////////////prachi new
//        if(document.getElementById('insert').checked==true)
//        {
//        for(var j=0 ; j< 54 ; j++)
//        {    
//                listbox222[j] = "";
//        }  
//        }
//        else
//        {
//        //////old
         for(var j=0 ; j< 31 ; j++)
        {    
                listbox222datewise[j] = "";
        } 
        /////////old
        
//        } 
//        ///////////////prachi  new 
        listbox2j.options.length = 0;
    
//      if(document.getElementById('insert').checked==true)
//        {
//        for(var i=0 ; i<54; i++)
//        {

//                listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
//                listbox222[i] = listbox111[i];
//     
//        }
//        }
//        else
//        {
         for(var i=0 ; i<31; i++)
        {

                listbox2j.options[listbox2j.options.length] = new Option(listbox111datewise[i]);
                listbox222datewise[i] = listbox111datewise[i];
     
        }
       // }
       
       
       }
       else
       {


    var listbox1j= document.getElementById('Listavilfield');
        var listbox2j= document.getElementById('Listselfield');
        for(var i=listbox2j.options.length - 1 ; i >=0; i--)
        {
         
            listbox2j.options[i] = null;
          
        }
        listbox2j.selectedIndex = -1;
//        ////////////prachi new
//        if(document.getElementById('insert').checked==true)
//        {
//        for(var j=0 ; j< 54 ; j++)
//        {    
//                listbox222[j] = "";
//        }  
//        }
//        else
//        {
//        //////old
         for(var j=0 ; j< 71 ; j++)
        {    
                listbox222[j] = "";
        } 
        /////////old
        
//        } 
//        ///////////////prachi  new 
        listbox2j.options.length = 0;
    
//      if(document.getElementById('insert').checked==true)
//        {
//        for(var i=0 ; i<54; i++)
//        {

//                listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
//                listbox222[i] = listbox111[i];
//     
//        }
//        }
//        else
//        {
         for(var i=0 ; i<71; i++)
        {

                listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
                listbox222[i] = listbox111[i];
                count1=count1+1;
     
        }
       // }
       
       if(listbox222[24]=="Card Amt" || listbox222[26]=="Deviation Amt" ||listbox222[29]=="Agg Amt" ||listbox222[30]=="Disc Amt" ||listbox222[32]=="Post Prem Amt" ||listbox222[34]=="Sp. Disc Amt" || listbox222[36]=="Space Disc Amt" ||listbox222[38]=="Special Charges" || listbox222[39]=="Ag. Addl. TD Amt" || listbox222[41]=="Gross Amt" || listbox222[42]=="Retainer TD Amt" ||listbox222[44]=="Ag. TD Amt" || listbox222[46]=="Billing Amt" || listbox222[47]=="Ret. Comm. Amt" || listbox222[49]=="Actual Business")
        {
        document.getElementById('hdnamtflag').value="true"
        }
       
       document.getElementById('hdncount1').value=count1;
       }
        
        return false;
}

function chkrun()
{


if(document.getElementById('txtfromdate').value=="")
{
alert("Please Enter From Date");
document.getElementById('txtfromdate').focus();
return false;
}

if(document.getElementById('txttodate').value=="")
{
alert("Please Enter To Date");
document.getElementById('txttodate').focus();
return false;
}
if(document.getElementById('dpagency').value!="")
{
if(document.getElementById('dpagency').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}
if(document.getElementById('dpclient').value!="")
{
if(document.getElementById('dpclient').value!=document.getElementById('hdnclienttxt').value)
{
alert("Press F2 To Bind a Valid Client");
document.getElementById('dpclient').value=""
document.getElementById('dpclient').focus();
return false;
}
}
if(document.getElementById('dpexecutive').value!="")
{
if(document.getElementById('dpexecutive').value!=document.getElementById('hdnexecutivetxt').value)
{
alert("Press F2 To Bind a Valid Executive");
document.getElementById('dpexecutive').value=""
document.getElementById('dpexecutive').focus();
return false;
}
}

if(document.getElementById('dpretainer').value!="")
{
if(document.getElementById('dpretainer').value!=document.getElementById('hdnretainertxt').value)
{
alert("Press F2 To Bind a Valid Retainer");
document.getElementById('dpretainer').value=""
document.getElementById('dpretainer').focus();
return false;
}
}
//  if(document.getElementById('dppublication').value=="0")
//    {
//    alert("Please Select Publication");
//    document.getElementById('dppublication').focus();
//    return false;
//    }
/*
if(
document.getElementById('chkbookid').checked==false  &&
document.getElementById('chkbookdate').checked==false  &&
document.getElementById('chkagencyname').checked==false  &&
document.getElementById('chkclientname').checked==false  &&
document.getElementById('chkrono').checked==false  &&
document.getElementById('chkrodate').checked==false  &&
document.getElementById('chkexe').checked==false  &&
document.getElementById('chkbooktype').checked==false  &&
document.getElementById('chkcolor').checked==false  &&
document.getElementById('chkadcat').checked==false  &&
document.getElementById('chkadsubcat').checked==false  &&
document.getElementById('chkadsubcat3').checked==false  &&
document.getElementById('chkadsubcat4').checked==false  &&
document.getElementById('chkpackage').checked==false  &&
document.getElementById('chkpubdate').checked==false  &&
document.getElementById('chknoins').checked==false  &&
document.getElementById('chkpaidins').checked==false  &&
document.getElementById('chkadsize').checked==false  &&
document.getElementById('chkarea').checked==false  &&
document.getElementById('chkpageprem').checked==false  &&
document.getElementById('chkposprem').checked==false  &&
document.getElementById('chkscheme').checked==false  &&
document.getElementById('chkrate').checked==false  &&
document.getElementById('chkcardrate').checked==false  &&
document.getElementById('chkcardamt').checked==false  &&
document.getElementById('chkcontract').checked==false  &&
document.getElementById('chkdevamt').checked==false  &&
document.getElementById('chkdevper').checked==false  &&
document.getElementById('chkagrate').checked==false  &&
document.getElementById('chkagamt').checked==false  &&
document.getElementById('chkdiscamt').checked==false  &&
document.getElementById('chkdiscper').checked==false  &&
document.getElementById('chkpospremamt').checked==false  &&
document.getElementById('chkpospremper').checked==false  &&
document.getElementById('chkspdiscamt').checked==false  &&
document.getElementById('chkspdiscper').checked==false  &&
document.getElementById('chkspacediscamt').checked==false  &&
document.getElementById('chkspacediscper').checked==false  &&
document.getElementById('chkspcharge').checked==false  &&
document.getElementById('chkagadtdamt').checked==false  &&
document.getElementById('chkagadtdper').checked==false  &&
document.getElementById('chkgrossamt').checked==false  &&
document.getElementById('chkrettdamt').checked==false  &&
document.getElementById('chkrettdper').checked==false  &&
document.getElementById('chkagtdamt').checked==false  &&
document.getElementById('chkagtdper').checked==false  &&
document.getElementById('chkbillamt').checked==false  &&
document.getElementById('chkretcomamt').checked==false  &&
document.getElementById('chkretcomper').checked==false  &&
document.getElementById('chkactbusiness').checked==false  &&
document.getElementById('chkrevcenter').checked==false  

)
{
alert("Please select atleast one item to print");
return false;
}*/

document.getElementById('hdnedition').value=document.getElementById('dpedition').value;
document.getElementById('hdncity').value=document.getElementById('dpcity').value;
document.getElementById('hdnsuppliment').value=document.getElementById('dpsuppliment').value;
document.getElementById('hdnagency').value=document.getElementById('dpagency').value;
document.getElementById('hdnbrand').value=document.getElementById('dpbrand').value;
document.getElementById('hdnvarient').value=document.getElementById('dpvarient').value;
document.getElementById('hdnadcat').value=document.getElementById('dpadcat').value;
document.getElementById('hdnadsubcat').value=document.getElementById('dpadsubcat').value;
document.getElementById('hdnadsubcat3').value=document.getElementById('dpadsubcat3').value;
document.getElementById('hdnadsubcat4').value=document.getElementById('adsubcat4').value;
document.getElementById('hdnadsubcat5').value=document.getElementById('adsubcat5').value;
document.getElementById('hdntaluka').value=document.getElementById('dptaluka').value;


var selectedfields="";
if(document.getElementById('Listselfield').options.length >0)
{
 for(var i=0 ; i < document.getElementById('Listselfield').options.length ; i++)
 {
               
 selectedfields = selectedfields + document.getElementById('Listselfield').options[i].text  + ',';
 }
 document.getElementById('hdnlist').value=selectedfields;
 if(selectedfields=="Publication,Edition," ||selectedfields=="Publication,"|| selectedfields=="Edition,"|| selectedfields=="Edition,Publication," )
 {
 alert("This Field is not valid to display data");
 return false;
 }
 }
 else
 {
 alert('Please Select Atleaset One Item From Available Fields');
 return false;
 }




      var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 







}



function billbook()
{
if(document.getElementById('bill').checked==true)
{
document.getElementById('bill').checked=false;
}
if(document.getElementById('book').checked==false)
{
document.getElementById('book').checked=true;
}
if(document.getElementById('insert').checked==true)
{
document.getElementById('insert').checked=false;
}
if(document.getElementById('status').disabled==true)
{
document.getElementById('status').disabled=false;
}
if(document.getElementById('drpstatus').disabled==true)
{
document.getElementById('drpstatus').disabled=false;
}
}

function billbill()
{
if(document.getElementById('book').checked==true)
{
document.getElementById('book').checked=false;
}
if(document.getElementById('bill').checked==false)
{
document.getElementById('bill').checked=true;
}
if(document.getElementById('insert').checked==true)
{
document.getElementById('insert').checked=false;
}
if(document.getElementById('status').disabled==false)
{
document.getElementById('status').disabled=true;
}
if(document.getElementById('drpstatus').disabled==false)
{
document.getElementById('drpstatus').disabled=true;
}
}

function billinsert()
{
if(document.getElementById('book').checked==true)
{
document.getElementById('book').checked=false;
}
if(document.getElementById('bill').checked==true)
{
document.getElementById('bill').checked=false;
}
if(document.getElementById('insert').checked==false)
{
document.getElementById('insert').checked=true;
}
if(document.getElementById('status').disabled==true)
{
document.getElementById('status').disabled=false;
}
if(document.getElementById('drpstatus').disabled==true)
{
document.getElementById('drpstatus').disabled=false;
}

document.getElementById('lbdtbason').disabled = false;
document.getElementById('drpdtbasedon').disabled = false;

///////////////////////////////////////////////////////////////

//var listbox1j= document.getElementById('Listavilfield');
//   
//        listbox1j.options.length = 0;
//         
//        for(var i=0 ; i<54; i++)
//        {

//                listbox1j.options[listbox1j.options.length] = new Option(listbox111[i]);
//                //listbox222[i] = listbox111[i];
//                listbox1j.options.length;
//     
//        }
        

///////////////////////////////////////////////////////////////////


}
//////////////////////prachi
function removeallfieldname()
{

if(document.getElementById('RadioButton2').checked == true)
   
   {
   
         var listbox2j=document.getElementById('Listselfield');
        for(var i=listbox2j.options.length - 1 ; i >=0; i--)
        {
         
            listbox2j.options[i] = null;
          
        }
        listbox2j.selectedIndex = -1;
//         if(document.getElementById('insert').checked==true)
//        {
//        for(var j=0 ; j< 54 ; j++)
//        {    
//             listbox222[j] = "";
//        } 
//        }
//        else
//        {
        for(var j=0 ; j< 29 ; j++)
        {    
             listbox222datewise[j] = "";
        } 
 //       }   
 
   }
   else
   {
        var listbox2j=document.getElementById('Listselfield');
        for(var i=listbox2j.options.length - 1 ; i >=0; i--)
        {
         
            listbox2j.options[i] = null;
          
        }
        listbox2j.selectedIndex = -1;
//         if(document.getElementById('insert').checked==true)
//        {
//        for(var j=0 ; j< 54 ; j++)
//        {    
//             listbox222[j] = "";
//        } 
//        }
//        else
//        {
        for(var j=0 ; j< 66 ; j++)
        {    
             listbox222[j] = "";
        } 
 //       } 
 
 document.getElementById('hdnamtflag').value=""
 }   
        return false;
}


function removefieldname()
{

if(document.getElementById('RadioButton2').checked == true)
   
   {
   
       
       var listbox1j= document.getElementById('Listavilfield');
       var listbox2j= document.getElementById('Listselfield');
       var index1 = document.getElementById('Listselfield').options.selectedIndex;
       if(index1 == -1 )
       {
           alert('There is no value in selected field');
           return false;
       }
       
       var value1 = document.getElementById('Listselfield').options[index1].text
       var length1 = listbox2j.options.length

        listbox2j.options.length=0;
        listbox2j.value="0";
        for(var i=0 ; i<length1; i++)
        {
                if(listbox222datewise[i] != value1)
                {
                     listbox2j.options[listbox2j.options.length] = new Option(listbox222datewise[i]);
          
                }     
        }
//         if(document.getElementById('insert').checked==true)
//        {
//         for(var i=0 ; i<54; i++)
//         {
//                     if(listbox222[i] != undefined)
//                     {
//                                if(listbox222[i] == value1)
//                                {
//                                listbox222[i] = "";         
//                                } 
//                     }
//     
//         }
//         }
//         else
//         {
         for(var i=0 ; i<31; i++)
         {
                     if(listbox222datewise[i] != undefined)
                     {
                                if(listbox222datewise[i] == value1)
                                {
                                listbox222datewise[i] = "";         
                                } 
                     }
     
         }
 //        }
   }
   else
   {
       var listbox1j= document.getElementById('Listavilfield');
       var listbox2j= document.getElementById('Listselfield');
       var index1 = document.getElementById('Listselfield').options.selectedIndex;
       if(index1 == -1 )
       {
           alert('There is no value in selected field');
           return false;
       }
       
       var value1 = document.getElementById('Listselfield').options[index1].text
       var length1 = listbox2j.options.length

        listbox2j.options.length=0;
        listbox2j.value="0";
        for(var i=0 ; i<length1; i++)
        {
                if(listbox222[i] != value1)
                {
                     listbox2j.options[listbox2j.options.length] = new Option(listbox222[i]);
          
                }     
        }
//         if(document.getElementById('insert').checked==true)
//        {
//         for(var i=0 ; i<54; i++)
//         {
//                     if(listbox222[i] != undefined)
//                     {
//                                if(listbox222[i] == value1)
//                                {
//                                listbox222[i] = "";         
//                                } 
//                     }
//     
//         }
//         }
//         else
//         {
         for(var i=0 ; i<71; i++)
         {
                     if(listbox222[i] != undefined)
                     {
                                if(listbox222[i] == value1)
                                {
                                listbox222[i] = "";         
                                } 
                     }
     
         }
 //        }
 
 document.getElementById('hdnamtflag').value="";
 }

        return false;

}


function addfieldname()
{

  if(document.getElementById('RadioButton2').checked == true)
   
   {
   
          var listbox1j= document.getElementById('Listavilfield');
        var listbox2j= document.getElementById('Listselfield');
        var index1 = document.getElementById('Listavilfield').options.selectedIndex;
        if(index1 == -1)
        {
       
              alert('Please select the value ');
              document.getElementById('Listavilfield').value = 'Booking Id';
              return false;
       
        }
        var value1 = document.getElementById('Listavilfield').options[index1].text
//         if(document.getElementById('insert').checked==true)
//        {
//        for(var i=0 ; i<54; i++)
//        {
//                if(listbox222[i] == value1)
//                {
//                    alert('It is already selected');
//                    return false;
//                }    
//        }
//        
//    
//        for(var i=0 ; i<54; i++)
//        {
//                if(listbox111[i] == value1)
//                {
//                        listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
//                        listbox222[j] = listbox111[i];
//                        j++;    
//                } 

//     
//         }
//         }
//         else
//         {
          for(var i=0 ; i<31; i++)
        {
                if(listbox222datewise[i] == value1)
                {
                    alert('It is already selected');
                    return false;
                }    
        }
        
    
        for(var i=0 ; i<31; i++)
        {
                if(listbox111datewise[i] == value1)
                {
                        listbox2j.options[listbox2j.options.length] = new Option(listbox111datewise[i]);
                        listbox222datewise[j] = listbox111datewise[i];
                        j++;    
                } 

     
         }
   }
   else
   {
    
        var listbox1j= document.getElementById('Listavilfield');
        var listbox2j= document.getElementById('Listselfield');
        var index1 = document.getElementById('Listavilfield').options.selectedIndex;
        if(index1 == -1)
        {
       
              alert('Please select the value ');
              document.getElementById('Listavilfield').value = 'Booking Id';
              return false;
       
        }
        var value1 = document.getElementById('Listavilfield').options[index1].text
        if(document.getElementById('Listavilfield').options[index1].text=="Card Amt" || document.getElementById('Listavilfield').options[index1].text=="Deviation Amt" ||document.getElementById('Listavilfield').options[index1].text=="Agg Amt" ||document.getElementById('Listavilfield').options[index1].text=="Disc Amt" ||document.getElementById('Listavilfield').options[index1].text=="Post Prem Amt" ||document.getElementById('Listavilfield').options[index1].text=="Sp. Disc Amt" ||document.getElementById('Listavilfield').options[index1].text=="Space Disc Amt" ||document.getElementById('Listavilfield').options[index1].text=="Special Charges" ||document.getElementById('Listavilfield').options[index1].text=="Ag. Addl. TD Amt" ||document.getElementById('Listavilfield').options[index1].text=="Gross Amt" ||document.getElementById('Listavilfield').options[index1].text=="Retainer TD Amt" ||document.getElementById('Listavilfield').options[index1].text=="Ag. TD Amt" ||document.getElementById('Listavilfield').options[index1].text=="Billing Amt" ||document.getElementById('Listavilfield').options[index1].text=="Ret. Comm. Amt" ||document.getElementById('Listavilfield').options[index1].text=="Actual Business")
        {
        document.getElementById('hdnamtflag').value="true"
        }
//         if(document.getElementById('insert').checked==true)
//        {
//        for(var i=0 ; i<54; i++)
//        {
//                if(listbox222[i] == value1)
//                {
//                    alert('It is already selected');
//                    return false;
//                }    
//        }
//        
//    
//        for(var i=0 ; i<54; i++)
//        {
//                if(listbox111[i] == value1)
//                {
//                        listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
//                        listbox222[j] = listbox111[i];
//                        j++;    
//                } 

//     
//         }
//         }
//         else
//         {
          for(var i=0 ; i<71; i++)
        {
                if(listbox222[i] == value1)
                {
                    alert('It is already selected');
                    return false;
                }    
        }
        
    
        for(var i=0 ; i<71; i++)
        {
                if(listbox111[i] == value1)
                {
                        listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
                        listbox222[j] = listbox111[i];
                        j++;
                        count1=count1+1;    
                } 

     
         }
   //      }
   document.getElementById('hdncount1').value=count1
   
   }
        
         return false;
}

///////////////////


function keySort(dropdownlist,caseSensitive) 
 {
       // check the keypressBuffer attribute is defined on the dropdownlist
         var undefined;
         if (dropdownlist.keypressBuffer == undefined)
         {
             dropdownlist.keypressBuffer = '';
         }
         // get the key that was pressed
         var key = String.fromCharCode(window.event.keyCode);
         dropdownlist.keypressBuffer += key;
         if (!caseSensitive)
          {
              // convert buffer to lowercase
              dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
          }
          // find if it is the start of any of the options
          var optionsLength = dropdownlist.options.length;
          for (var n=0; n<optionsLength; n++) 
          {
                  var optionText = dropdownlist.options[n].text;
                  if (!caseSensitive)
                  {
                       optionText = optionText.toLowerCase();
                  }
                  if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0)
                  {
                      dropdownlist.selectedIndex = n;
                      return false; 
                      // cancel the default behavior since
                                // we have selected our own value
                  }
           }
          // reset initial key to be inline with default behavior
          dropdownlist.keypressBuffer = key;
          return true; // give default behavior
}







function F2fillagencycr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('dpagency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=350+ "px" ;//314//290
            document.getElementById('div1').style.left=278+ "px";//395//1004
            document.getElementById('lstagency').focus();
            billwisexls.fillF2_CreditAgency(compcode, agn, bindAgency_callback1);
      }
 }

}

function F2fillagencycr_allagency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('dpagency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=215+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            report2.fillF2_CreditAgency(compcode,agn,bindAgency_callback1);
      }
 }
 else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) 
    {

        if (document.activeElement.id == "dpagency")
         {
            document.getElementById('dpagency').value = "";
            document.getElementById('hdnagency1').value = "";

            //saveagencycode = "";
            //saveagencyname = "";
            //savedpcdcode = "";


            return false;
        }
        return key;
    }
 
 
 
 
 
 

}
function bindAgency_callback1(res)
{
     var ds_AccName=res.value;
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Agency Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name,ds_AccName.Tables[0].Rows[i].Agency_Code);         
                pkgitem.options.length;
            }
        }
        
             var   aTag = eval(document.getElementById('dpagency'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div1').scrollLeft;
                 var scrolltop = document.getElementById('div1').scrollTop;
                 document.getElementById('div1').style.left = document.getElementById('dpagency').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div1').style.top = document.getElementById('dpagency').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
        //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
        return false;

}


function bindAgency_callback1allad(res)
{
     var ds_AccName=res.value;
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Agency Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name,ds_AccName.Tables[0].Rows[i].Agency_Code);         
                pkgitem.options.length;
            }
        }
        
         var   aTag = eval(document.getElementById('dpagency'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div1').scrollLeft;
                 var scrolltop = document.getElementById('div1').scrollTop;
                 document.getElementById('div1').style.left = document.getElementById('dpagency').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div1').style.top = document.getElementById('dpagency').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
        //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
        return false;

}




function ClickAgaency1(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstagency")
        {
        if(document.getElementById('lstagency').value=="0")
            {
                 alert("Please select Agency Name");
                 return false;
            }
            
            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstagency').length-1;k++)
            {   
                if(document.getElementById('lstagency').options[k].value==page)
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('dpagency').value = abc;
                    document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdnagency1').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('dpagency').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('dpagency').focus();
         }
  }
  /////////////////////////////////////////////////////////////////
  function chklstagency()
  {
  if(document.activeElement.id=="lstagency" || document.activeElement.id=="dpagency")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div1").style.display="block")
         {
          document.getElementById("div1").style.display="none";
          document.getElementById('dpagency').focus();
         }
       }
  }
   if(document.activeElement.id=="lstclient" || document.activeElement.id=="dpclient")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div2").style.display="block")
         {
          document.getElementById("div2").style.display="none";
          document.getElementById('dpclient').focus();
         }
       }
  }
  
    if(document.activeElement.id=="lstexecutive" || document.activeElement.id=="dpexecutive")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div3").style.display="block")
         {
          document.getElementById("div3").style.display="none";
          document.getElementById('dpexecutive').focus();
         }
       }
  }
  
    if(document.activeElement.id=="lstretainer" || document.activeElement.id=="dpretainer")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div4").style.display="block")
         {
          document.getElementById("div4").style.display="none";
          document.getElementById('dpretainer').focus();
         }
       }
  }
         return false;
 }
         /////////////////////////////////////////////////////////////////
         
         function chklstagency1()
  {
  if(document.activeElement.id=="lstagency" || document.activeElement.id=="dpagency" )
  {
        
         if(document.getElementById("div1").style.display="block")
         {
          document.getElementById("div1").style.display="none";
          document.getElementById('dpagency').focus();
         }
       
  }
   if(document.activeElement.id=="lstclient" || document.activeElement.id=="dpclient")
  {
        
         if(document.getElementById("div2").style.display="block")
         {
          document.getElementById("div2").style.display="none";
          document.getElementById('dpclient').focus();
         }
      
  }
  
    if(document.activeElement.id=="lstexecutive" || document.activeElement.id=="dpexecutive")
  {
         if(document.getElementById("div3").style.display="block")
         {
          document.getElementById("div3").style.display="none";
          document.getElementById('dpexecutive').focus();
         }
      
  }
  
    if(document.activeElement.id=="lstretainer" || document.activeElement.id=="dpretainer")
  {
        
         if(document.getElementById("div4").style.display="block")
         {
          document.getElementById("div4").style.display="none";
          document.getElementById('dpretainer').focus();
         }
      
  }
         return false;
 }
         ///////////////////////////////////////////////////////////////////

function F2fillclientcr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="dpclient")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('dpclient').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=325+ "px" ;
            document.getElementById('div2').style.left=278+ "px";
            document.getElementById('lstclient').focus();
            billwisexls.fillF2_Creditclient(compcode, client, bindclient_callback);
      }
 }

}

function bindclient_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstclient");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Client Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name,ds_AccName.Tables[0].Rows[i].Cust_Code);         
                pkgitem.options.length;
            }
        }
        
        var   aTag = eval(document.getElementById('dpclient'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div2').scrollLeft;
                 var scrolltop = document.getElementById('div2').scrollTop;
                 document.getElementById('div2').style.left = document.getElementById('dpclient').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div2').style.top = document.getElementById('dpclient').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        document.getElementById("lstclient").value="0";
        document.getElementById("div2").value="";
        document.getElementById('lstclient').focus();
   
        return false;

}


function Clickclient(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstclient")
        {
        if(document.getElementById('lstclient').value=="0")
            {
                 alert("Please select Client Name");
                 return false;
            }
            
            var page = document.getElementById('lstclient').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstclient').length-1;k++)
            {   
                if(document.getElementById('lstclient').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstclient').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstclient').options[k].innerText;
                    }
                    document.getElementById('dpclient').value = abc;
                     document.getElementById('hdnclienttxt').value =abc;
                    document.getElementById('hdnclient1').value =page;
                    
                    document.getElementById("div2").style.display="none";
                    document.getElementById('dpclient').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('dpclient').focus();
         }
  }
  
  
  
  
  ////exe

function F2fillexecutivecr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="dpexecutive")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
             var executive =document.getElementById('dpexecutive').value;
            document.getElementById("div3").style.display="block";
            document.getElementById('div3').style.top=325+ "px" ;
            document.getElementById('div3').style.left=540+ "px";
            document.getElementById('lstexecutive').focus();
            billwisexls.fillF2_Creditexecutive(compcode, executive, bindexecutive_callback);
      }
 }

}
function bindexecutive_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstexecutive");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Executive Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Exec_name,ds_AccName.Tables[0].Rows[i].Exe_no);         
                pkgitem.options.length;
            }
        }
        
         var   aTag = eval(document.getElementById('dpexecutive'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div3').scrollLeft;
                 var scrolltop = document.getElementById('div3').scrollTop;
                 document.getElementById('div3').style.left = document.getElementById('dpexecutive').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div3').style.top = document.getElementById('dpexecutive').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        
        document.getElementById("lstexecutive").value="0";
        document.getElementById("div3").value="";
        document.getElementById('lstexecutive').focus();
   
        return false;

}


function Clickexecutive(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstexecutive")
        {
        if(document.getElementById('lstexecutive').value=="0")
            {
                 alert("Please select Executive Name");
                 return false;
            }
            
            var page = document.getElementById('lstexecutive').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstexecutive').length-1;k++)
            {   
                if(document.getElementById('lstexecutive').options[k].value==page) {


                    if (browser != "Microsoft Internet Explorer") {

                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }

                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;
                    }
                    document.getElementById('dpexecutive').value = abc;
                     document.getElementById('hdnexecutivetxt').value =abc;
                    document.getElementById('hdnexecutive1').value =page;
                    
                    document.getElementById("div3").style.display="none";
                    document.getElementById('dpexecutive').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div3").style.display="none";
        document.getElementById('dpexecutive').focus();
         }
  }
  /////////////////////////ret
  

function F2fillretainercr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
if(key==113)
{
    if(document.activeElement.id=="dpretainer")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var retainer =document.getElementById('dpretainer').value;
            document.getElementById("div4").style.display="block";
            document.getElementById('div4').style.top=325+ "px" ;
            document.getElementById('div4').style.left=816+ "px";
            document.getElementById('lstretainer').focus();
            billwisexls.fillF2_Creditretainer(compcode, retainer, bindretainer_callback);
      }
 }

}
function bindretainer_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstretainer");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Retainer Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Retain_Name,ds_AccName.Tables[0].Rows[i].Retain_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstretainer").value="0";
        document.getElementById("div4").value="";
        document.getElementById('lstretainer').focus();
   
        return false;

}


function Clickretainer(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstretainer")
        {
        if(document.getElementById('lstretainer').value=="0")
            {
                 alert("Please select Retainer Name");
                 return false;
            }
            
            var page = document.getElementById('lstretainer').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstretainer').length-1;k++)
            {   
                if(document.getElementById('lstretainer').options[k].value==page)
                {if (browser != "Microsoft Internet Explorer") {

                        var abc = document.getElementById('lstretainer').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstretainer').options[k].innerText;
                    }
                    document.getElementById('dpretainer').value = abc;
                     document.getElementById('hdnretainertxt').value =abc;
                    document.getElementById('hdnretainer1').value =page;
                    
                    document.getElementById("div4").style.display="none";
                    document.getElementById('dpretainer').focus();
                     return false; 
                    
                }
               
            }
          
        
        }
        
      }
      else if (key == 27)
         {
         
        document.getElementById("div4").style.display="none";
        document.getElementById('dpretainer').focus();
        return false;
         }
  }
  
  

 function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
//if(event.keyCode==113) 
//    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;
}

function autowidth(drpid)
{
var drp=drpid.id;
document.getElementById(drp).style.width="100";
//alert('lost focus');
}
function autowidth1(drpid)
{
//alert('got focus');
var drp=drpid.id;
document.getElementById(drp).style.width="150";


}




function compareDates()
{
var fromDate=document.getElementById('txtfromdate').value;
var toDate=document.getElementById('txttodate').value;
var splitChar="";
if(fromDate .indexOf ("/")>=0)
{
splitChar="/";
}
else if(fromDate .indexOf("-")>=0)
{
splitChar ="-";
}
else if(fromDate .indexOf(".")>=0)
{
splitChar =".";
}

var fromDateArray=fromDate .split(splitChar );
var toDateArray=toDate .split(splitChar);
if(document.getElementById('hiddendateformat').value="dd/mm/yyyy")
{
    var from_day=parseInt(fromDateArray [0],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [2],10);
    
    var to_day=parseInt(toDateArray [0],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [2],10);
}
else if(document.getElementById('hiddendateformat').value="mm/dd/yyyy")
{
    var from_day=parseInt(fromDateArray [1],10);
    var from_month=parseInt (fromDateArray  [0],10);
    var from_year=parseInt (fromDateArray  [2],10);

    var to_day=parseInt(toDateArray [1],10);
    var to_month=parseInt(toDateArray [0],10);
    var to_year=parseInt(toDateArray [2],10);

}
else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
{
    var from_day=parseInt(fromDateArray [2],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [0],10);

    var to_day=parseInt(toDateArray [2],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [0],10);

}
    if(to_year >from_year )
    {
        return true;
    }
    else
    {
        if(to_year ==from_year && to_month >from_month)
        {
            return true;
        }
        else if(to_year ==from_year && to_month ==from_month && to_day >=from_day )
            {
                return true;
                
            }
        else
        {    
        alert("From Date should be less than To date.");
                document.getElementById('txtfromdate').focus();
                return false;
        }
       
    }

}







function enable_exe()
{
if(document.getElementById('exe').checked == false)
{
document.getElementById('exe').checked =true
}
if(document.getElementById('csv').checked == true)
{
document.getElementById('csv').checked =false
}
}

function enable_csv()
{
if(document.getElementById('exe').checked == true)
{
document.getElementById('exe').checked =false
}
if(document.getElementById('csv').checked == false)
{
document.getElementById('csv').checked =true
}
}


function selectvalueagency(event)
    {
        if(document.getElementById('hdnagency1').value!="")     
    {
        alert('Please Select agency name using F2.')
        document.getElementById('dpagency').value="";
        document.getElementById('dpagency').focus();
        return false;
    }
}





function clearcompletereport() {
if(event.keyCode==116)
{
    document.getElementById('txtfromdate').value = "";
    document.getElementById('txttodate').value = "";
    //document.getElementById('dpfilterby').value = "A";

    document.getElementById('dppublication').value = "0";
    document.getElementById('dpprintcenter').value = "0";
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpsuppliment').value = "0";
    document.getElementById('dpstate').value = "0";
    document.getElementById('dpdistrict').value = "0";
    document.getElementById('dptaluka').value = "0";
    document.getElementById('dpcity').value = "0";
    document.getElementById('dpzone').value = "0";
    document.getElementById('dpregion').value = "0";
    document.getElementById('dpbranch').value = "0";
    document.getElementById('dprevcenter').value = "0";
    document.getElementById('dpadtype').value = "0";
    document.getElementById('dpadcat').value = "0";
    document.getElementById('dpadsubcat').value = "0";
    document.getElementById('dpadsubcat3').value = "0";
    document.getElementById('dpadsubcat4').value = "0";
    document.getElementById('dpadsubcat5').value = "0";
    document.getElementById('dpagencytype').value = "0";
    document.getElementById('dprostatus').value = "0";
    document.getElementById('dpclient').value = "";
    document.getElementById('dpexecutive').value = "";
    document.getElementById('dpretainer').value = "";
    document.getElementById('dppackage').value = "0";
    document.getElementById('dpagency').value = "";
    document.getElementById('dpproduct').value = "0";
    document.getElementById('dpbrand').value = "0";
    document.getElementById('dpvarient').value = "0";
    document.getElementById('dpscheme').value = "0";
    document.getElementById('dpratetype').value = "0";
    document.getElementById('dpcontractname').value = "0";
    document.getElementById('dpbooktype').value = "0";
    document.getElementById('dppagetype').value = "0";
    document.getElementById('dppageprem').value = "0";
    document.getElementById('dpposprem').value = "0";
    document.getElementById('drpstatus').value = "0";
    document.getElementById('drpinsertstatus').value = "0";
    document.getElementById('drpboxcycle').value = "0";
    document.getElementById('txtcaption').value = "";
    document.getElementById('txtbillno').value = "";
    document.getElementById('RadioButton1').focus();
    
} 
}



function tabvaluecomp (event)
{
if(browser!="Microsoft Internet Explorer")
{
if(event.which==116)
{
window.open ('billwismxls.aspx','_self','',false)
return false;
}
}
else
{
if(event.keyCode==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else
 if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
event.keyCode=13;
return event.keyCode;

}
else
{
//alert(event.keyCode);
event.keyCode=9;
//alert(event.keyCode);
return event.keyCode;
}
}

}

}

function fornumbercheck(event)
    {var browser = navigator.appName;

    if (browser != "Microsoft Internet Explorer")
    {
         if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46)||(event.which==13) || (event.which==0))
    {
        return true;
    }
    else
    {
   
                 alert('Please enter numeric numbers only.')
                 event.which=0;
                 return false;
    }
    }
    else
    {
    
         if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46)||(event.keyCode==13))
    {
        return true;
    }
    else
    {
   
                 alert('Please enter numeric numbers only.')
                 event.keyCode=0;
                 return false;
    }
    }
    }