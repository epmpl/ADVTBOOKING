
// JScript File
var arrEdition_Item='';
var executequery;
var rownumEx;
var enLink="0";
///////////////////////////////////////////////////////////////////
var gbcontract_rate="";
var maxWidth=100;
var glob_area="";
///////////////////if it is 0 than we have click the main adcat drp down and if 
var mainclick="";
  // height to resize large images to
var maxHeight=100;
  // valid file types
var fileTypes=["bmp","gif","png","jpg","jpeg"];
  // the id of the preview image tag
var outImage="previewField";
  // what to display when the image is not valid
var defaultPic="spacer.gif";
var ds_sch;
var pgposprem="";  ///page premium position
var cyop_code=""; 
var cyop_desc="";
var drp_prem=0;
var spdisc=0;
var spdiscper=0;
var ddiscspace=0;
var ddiscspaceper=0;

/////////////////////////////////////////////////////////////////////
var global_code="";
var ds_adon;
var tempins;
var che_flag=0;
var check_or="0";
var txtbillarea="";
var flagrate;
var idfocus="";
var glpkgname="";
var totor=0;
var agreedrate_active=0;
var agreedamt_active=0;
///////////this is the array to chk the space availability at the timne of save
var chk_space="1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20";
var splitchk_space=chk_space.split(",");
var page_1=0;
var page_2=0;
var page_3=0;
var page_4=0;
var page_5=0;
var page_6=0;
var page_7=0;
var page_8=0;
var page_9=0;
var page_10=0;
var page_11=0;
var page_12=0;
var page_13=0;
var page_14=0;
var page_15=0;
var page_16=0;
var page_17=0;
var page_18=0;
var page_19=0;
var page_20=0;
//date_19
var date_1="";
var date_2="";
var date_3="";
var date_4="";
var date_5="";
var date_6="";
var date_7="";
var date_8="";
var date_9="";
var date_10="";
var date_11="";
var date_12="";
var date_13="";
var date_14="";
var date_15="";
var date_16="";
var date_17="";
var date_18="";
var date_19="";
var date_20="";
//edit_18
var edit_1="";
var edit_2="";
var edit_3="";
var edit_4="";
var edit_5="";
var edit_6="";
var edit_7="";
var edit_8="";
var edit_9="";
var edit_10="";
var edit_11="";
var edit_12="";
var edit_13="";
var edit_14="";
var edit_15="";
var edit_16="";
var edit_17="";
var edit_18="";
var edit_19="";
var edit_20="";

//pageno_20
var pageno_1="";
var pageno_2="";
var pageno_3="";
var pageno_4="";
var pageno_5="";
var pageno_6="";
var pageno_7="";
var pageno_8="";
var pageno_9="";
var pageno_10="";
var pageno_11="";
var pageno_12="";
var pageno_13="";
var pageno_14="";
var pageno_15="";
var pageno_16="";
var pageno_17="";
var pageno_18="";
var pageno_19="";
var pageno_20="";
////////////////
var suboradd;
var noofinsert="";
var noofinsertlo="";
var rowwhenupdate="";
var fillinsert="";
var insertval="";
var subtractrow;
var objadscat;
var globalgross;
var globalbill;
var boxpercen="";
var boxgamt;
var boxbill;
var glspedisc="0";
var glspadisc="0";
var glspeccharge="0";
var glpre="0";
var savtotid;
var getid="";
var countgridloop="";
var schemediscount="";
var gbdataset;
var globalschemedisc="";
var globalschemefrom="";
var gldisctyp="";
var insdatetemp;
var perbox="";
var perboxtype="";

var retrows="";
var flagins="";

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;
var addcomm=0;  


function loadXML(xmlFile) 
{
    var  httpRequest =null;    
    if(browser!="Microsoft Internet Explorer")
    {         
        req = new XMLHttpRequest();        
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement;        
    }

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
    {
       if(req.status == 200)
       {
           response = req.responseText;          
       }
    }
        
    var parser=new DOMParser();
    xmlDoc=parser.parseFromString(response,"text/xml"); 
    xmlObj=xmlDoc.documentElement;
}

loadXML('xml/billcycle.xml');

function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
     if (xmlDoc.readyState != 4) 
     { 
       return false; 
     } 
}


var idnew=0;
var previnsertion="0";
var repeatdate="0";

function  checkdateInsert()
{
    if(document.getElementById('txtdummydate').value=="")
    {
        alert("Please Select Publish date first");
        //document.getElementById('txtdummydate').focus();
        return false;
    }
     rateenter(event);
}


function insertRepeating()
{
}

//call when select package or enter repeating day
function onInsertionChange()
{ 
    document.getElementById('txtgrossamt').value="";
   if(document.getElementById('txtinsertion').value=="" || document.getElementById('txtinsertion').value=="0" || document.getElementById('bookdiv')==null)
   {
       
   }
   else
   {
        if(document.activeElement.id=="txtinsertion")
            subtractrow="show";
        if(document.getElementById('hiddensavemod').value=="01")
        {
            if(document.getElementById('hiddenmodifyinsert').value>document.getElementById('txtinsertion').value)
            {
                alert('You Cannot Dearease insertions(Please Cancel Bookng..)!');
                return false;
            }
        }

        var clientname=document.getElementById('txtclient').value;
        var client_split;
        if(clientname.indexOf("(")>=0)
        {
            clientname=clientname.split("(");
            client_split=clientname[1];
            client_split=client_split.replace(")","");
            clientname=client_split;
        }
        
        ///////this is to get the value into paid ins. text b0x
        if(document.getElementById('txtpaid').value!="" && document.getElementById('txtinsertion').value!="")
        {
            var paidno=document.getElementById('txtpaid').value;
            var valinsert=document.getElementById('txtinsertion').value;
            document.getElementById('txtpaid').value=(parseInt(valinsert)-parseInt(paidno))+parseInt(paidno);
        }
        
        var objpack=document.getElementById('drppackagecopy');
        var temp="";
        var tempcode="";
        var tempval="";
        var tempvalcode="";
        var desc="";
        var code="";
        var i=objpack.options.length;
        var j;

        for(j=0;j<i;j++)
        {
            if(parseInt(i)>0)
            {
                tempval=objpack[j].value;                                        
                if(temp!="")
                {
                     temp=tempval.split("@");
                     tempvalcode=temp[0];
                     tempcode=temp[1];
                     code=tempvalcode+","+code;
                     desc=tempcode+","+desc;    
                }
                else
                {
                     temp=tempval.split("@");
                     tempvalcode=temp[0];
                     tempcode=temp[1];
                     code=tempvalcode;
                     desc=tempcode;
                }
            }
                 
        }  //end of for
        
    
        if(document.getElementById('txtrepeatingdate').value!="")
        {        
            var insertval=document.getElementById('txtinsertion').value
            if(parseInt(document.getElementById('txtinsertion').value)==1)
            {
                //alert("In case of Insertion 1Repeating Day can't be greater than 1")
                 if(document.getElementById('drppackagecopy').options.length>0)
                 {
                      for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
                      {
                          if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
                          {
                               var tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                               if (tinsert>1)
                                   break;
                          }    
                      }
                 } 
                 if (tinsert<=1)  
                 {
                    document.getElementById('txtrepeatingdate').value="";             
                 }
            }
       
            repeatdate="1";
            suboradd="1";
        }
        else
        {
            repeatdate="0";
            suboradd="1";
        }
        if(parseInt(previnsertion)>parseInt(document.getElementById('txtinsertion').value))
        {
            repeatdate="1";
            suboradd="0";
        }
        if(repeatdate=="1")
        {       
            subtractrow="";
        }
        if(parseInt(document.getElementById('txtinsertion').value)>parseInt(previnsertion))
        {
            suboradd="1";
        }
      //***  previnsertion=document.getElementById('txtinsertion').value;
        var insert=document.getElementById('hiddeninserts').value;
        var adcat3=document.getElementById('drpadcat3').value;
        var adcat4=document.getElementById('drpadcat4').value;
        var adcat5=document.getElementById('drpadcat5').value;
        
        if(subtractrow=="")
        {
        //Booking_Master_temp.getData(document.getElementById('drppackage').value,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,insertLinedrop_callback);    
            if(suboradd=="1")
            {
                if(document.getElementById('chktfn').checked==false)
                {
                    document.getElementById('tblinsert').innerHTML==""
                    if(che_flag == 1)
                    {
                        desc=document.getElementById('hidval').value;
                    }
                    Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"DI0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,document.getElementById('drppageprem').value,clientname,adcat3,adcat4,adcat5,insertLinedrop_callback);
                }
                else
                {
                    document.getElementById('tblinsert').innerHTML==""
                    if(che_flag == 1)
                    {
                        desc=document.getElementById('hidval').value;
                    }
                    Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"DI0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,document.getElementById('drppageprem').value,clientname,adcat3,adcat4,adcat5,insertLinedrop_callback);
                    //check_or="0";
                }
            }
            else
            {
                if(che_flag == 1)
                {
                    desc=document.getElementById('hidval').value;
                }
                //Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"DI0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,document.getElementById('drppageprem').value,clientname,insertLinesubtract_callback);
                 insertLinesubtract_callback("",'main');
            }
        }
        else
        {       
            if(che_flag == 1)
            {
                desc=document.getElementById('hidval').value;
            }
            Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"DI0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,document.getElementById('drppageprem').value,clientname,adcat3,adcat4,adcat5,insertLine_callback);       
        }
    }
}

//***************************************

function insertLinedrop()
{
    if(document.getElementById('hiddensavemod').value!="1" && document.getElementById('drppackage').value!="0")
    {
        document.getElementById('txtinsertion').value="1";
        document.getElementById('txtpaid').value="1";
        document.getElementById('txtratecode').value="0";
        document.getElementById('txtcardrate').value="";
        document.getElementById('txtcardamt').value="";
        document.getElementById('txtagreedrate').value="";
        document.getElementById('txtagreedamt').value="";
        document.getElementById('txtdiscount').value="";
        document.getElementById('txtdiscpre').value="";
        document.getElementById('txtspedisc').value="";
        document.getElementById('txtspediscper').value="";
        document.getElementById('txtspacedisc').value="";
        document.getElementById('txtspadiscper').value="";
        document.getElementById('txtextracharges').value="";
        document.getElementById('txtgrossamt').value="";
        document.getElementById('txtbillamt').value="";

        document.getElementById('txtdealrate').value="";
        document.getElementById('txtdeviation').value="";
        document.getElementById('txtdummydate').value="";

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        var objpack=document.getElementById('drppackagecopy');
                            var temp="";
                            var tempcode="";
                            var tempval="";
                            var tempvalcode="";
                            var desc="";
                            var code="";
                            var i=objpack.options.length;
                            var j;

                                for(j=0;j<i;j++)
                                {
                                    if(parseInt(i)>0)
                                    {
                                        tempval=objpack[j].value;
                                        //tempvalcode=objpack[j].value;
                                        if(temp!="")
                                        {
                                            temp=tempval.split("@");
                                            tempvalcode=temp[0];
                                            tempcode=temp[1];
                                             cyop_code=tempvalcode+  "^"  +cyop_code;
                                            cyop_desc=tempcode+  "^"  +cyop_desc;
                                            code=tempvalcode+","+code;
                                            desc=tempcode+","+desc;
                                        }
                                        else
                                        {
                                            temp=tempval.split("@");
                                            tempvalcode=temp[0];
                                            tempcode=temp[1];
                                            code=tempvalcode;
                                            desc=tempcode;
                                             cyop_code=tempvalcode;
                                             cyop_desc=tempcode;
                                        }
                                    }
                                
                                }
                                 
                                
                global_code= code;     
    
        document.getElementById('hiddenpackage').value=code;
        var insert=document.getElementById('hiddeninserts').value;
        if(che_flag == 1)
        {
            desc=document.getElementById('hidval').value;
        }

        var clientname=document.getElementById('txtclient').value;
        var client_split;
        if(clientname.indexOf("(")>=0)
        {
            clientname=clientname.split("(");
            client_split=clientname[1];
            client_split=client_split.replace(")","");
            clientname=client_split;
        }
        var adcat3=document.getElementById('drpadcat3').value;
        var adcat4=document.getElementById('drpadcat4').value;
        var adcat5=document.getElementById('drpadcat5').value;

        Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"DI0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,document.getElementById('drppageprem').value,clientname,adcat3,adcat4,adcat5,insertLinedrop_callback);
        return ;
   } 
   return ;
}

function insertLinedrop_callback(response)
{    
    
        var ds=response.value;
        if(ds==null)
            return false;
      
        var adsubcat_vari=document.getElementById('drpadsubcategory');
        var color_vari=document.getElementById('drpcolor');
        var column_vari=document.getElementById('txtcolum');
        var uom_vari=document.getElementById('drpuom');
        var hiddenuom_vari=document.getElementById('hiddenuomdesc');
        var matsta_vari = document.getElementById('drpmatsta');
        var drppagepos_vari=document.getElementById('drppageposition');
        var adcat_vari=document.getElementById('drpadcategory');
        var pkgcopy_vari=document.getElementById('drppackagecopy');
        var totalarea_vari=document.getElementById('txttotalarea');
        var adsize1_vari=document.getElementById('txtadsize1');
        var adsize2_vari=document.getElementById('txtadsize2');	
        var areaval=document.getElementById('txttotalarea').value;

    noofinsert=ds.Tables[0].Rows.length;
    noofinsertlo=ds.Tables[0].Rows.length;
    gridItemCount=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value);
    fillinsert=ds.Tables[0].Rows.length;
    
    var getinsval=document.getElementById('txtinsertion').value;
    var totval=parseInt(noofinsert)/parseInt(getinsval);
    
    var dat="mm+"/"+"/"+dd+"/"+yyyy";
    var i=0;
    var j=0;
    var k=0;
    var l=0;
    var m=0;
    var n=0;
    var o=0;
    var p=0;
    var str="";
    var premid;
    var premper;
    var colid;
    var height;
    var width;
    var size;
    var late;
    var uomid;
    var adtypid;
    var cardid;
    var editid;
    var solorate;
    var premper1;
    var prem1id;
    var namecode;
    var inserts;
    var pagepost;
    var preall;
    var adcat;
    var adsubcat;
    var matsta;
    var filename;
    var discrate;
    var insertsta;
    var billstat;
    var repeat;
    var picfield;
    var colid;
    var paid;
    var agrred;
    var solo;
    var gross;
    var pageno_inserts;
    var remark_inserts;
    var page;
    var pageprem;
    var noofcol;
    var billamt;
    var billrate;
    var pagstr;
    var dcou=0;
    var dbill="";
    var dpaid="";
    var objedition=document.getElementById('drpedition');
   
////***    str="<div id=\"bookdiv\" runat=\"server\" style=\"OVERFLOW: auto; WIDTH: 896px; HEIGHT: 160px; \"><table cellpadding=\"1\" cellspacing=\"1\" id=\"gridtab\" width=\"1000px\" border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=\"center\" valign=\"top\" ></td><td align=\"center\" valign=\"top\" >No.</td><td align=\"center\" valign=\"top\" >Edition</td><td valign=\"top\" align=\"center\">Date</td><td align=\"center\" valign=\"top\">Ad Sub Cat.</td><td align=\"center\" valign=\"top\">Color</td><td align=\"center\" valign=\"top\">Height</td><td align=\"center\" valign=\"top\">Width</td><td align=\"center\" valign=\"top\">Col.</td><td align=\"center\" valign=\"top\">Size</td><td align=\"center\" valign=\"top\">P Pos</td><td  align=\"center\" valign=\"top\" >Page No.</td><td align=\"center\"  valign=\"top\">Status Material</td><td align=\"center\" align=\"center\" valign=\"top\">File Name</td><td  align=\"center\" valign=\"top\" style=\"cursor:pointer;color:red;\" onclick=\"uploadimageall()\">Upload</td><td  align=\"center\" valign=\"top\" >Remarks</td><td align=\"center\" valign=\"top\">Card Rate</td><td valign=\"top\" align=\"center\">Disc. Rate</td><td valign=\"top\" align=\"center\">Agreed Rate</td><td align=\"center\" valign=\"top\">Insertion Sta.</td><td align=\"center\" valign=\"top\">Latest By</td><td align=\"center\" valign=\"top\">Repeating</td><td align=\"center\" valign=\"top\">Premium</td><td align=\"center\" valign=\"top\">Pre(%)</td><td align=\"center\" valign=\"top\">Premium 1</td><td align=\"center\" valign=\"top\">Pre(%)</td><td align=\"center\" valign=\"top\">Premium 2</td><td align=\"center\" valign=\"top\">Pre(%)</td><td align=\"center\" valign=\"top\">Pre Allowed</td><td align=\"center\" valign=\"top\">Adv Cat.</td><td align=\"center\"  valign=\"top\">Bill Status</td><td  align=\"center\" valign=\"top\">Paid Ins.</td><td  align=\"center\" valign=\"top\" >Solo Rate</td><td  align=\"center\" valign=\"top\" >Gross Amt</td><td  align=\"center\" valign=\"top\" >Bill Amt</td><td  align=\"center\" valign=\"top\" >Bill Rate</td></tr>";
    str="<div id=\"bookdiv\" runat=\"server\" style=\"OVERFLOW: auto; WIDTH: 896px; HEIGHT: 160px; \"><table cellpadding=\"1\" cellspacing=\"1\" id=\"gridtab\" width=\"1000px\" border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=\"center\" valign=\"top\" ></td><td align=\"center\" valign=\"top\" >No.</td><td align=\"center\" valign=\"top\" >Edition</td><td valign=\"top\" align=\"center\">Date</td><td align=\"center\" valign=\"top\">Ad Sub Cat.</td><td align=\"center\" valign=\"top\">Color</td><td align=\"center\" valign=\"top\">Height</td><td align=\"center\" valign=\"top\">Width</td><td align=\"center\" valign=\"top\">Col.</td><td align=\"center\" valign=\"top\">Size</td><td align=\"center\" valign=\"top\">Insertion Sta.</td><td  align=\"center\" valign=\"top\" >Page No.</td><td align=\"center\"  valign=\"top\">Status Material</td><td align=\"center\" align=\"center\" valign=\"top\">File Name</td><td  align=\"center\" valign=\"top\" id='uploadA' style=\"cursor:pointer;color:red;\" onclick=\"uploadimageall()\">Upload</td><td  align=\"center\" valign=\"top\" >Remarks</td><td align=\"center\" valign=\"top\">Card Rate</td><td valign=\"top\" align=\"center\">Disc. Rate</td><td valign=\"top\" align=\"center\">Agreed Amt</td><td align=\"center\" valign=\"top\">P Pos</td><td align=\"center\" valign=\"top\">Latest By</td><td align=\"center\" valign=\"top\">Repeating</td><td align=\"center\" valign=\"top\">Premium</td><td align=\"center\" valign=\"top\">Pre(%)</td><td align=\"center\" valign=\"top\">Pre Allowed</td><td align=\"center\" valign=\"top\">Adv Cat.</td><td align=\"center\"  valign=\"top\">Bill Status</td><td  align=\"center\" valign=\"top\">Paid Ins.</td><td  align=\"center\" valign=\"top\" >Solo Rate</td><td  align=\"center\" valign=\"top\" >Gross Amt</td><td  align=\"center\" valign=\"top\" >Bill Amt</td><td  align=\"center\" valign=\"top\" >Bill Rate</td></tr>";
   
    document.getElementById('tblinsert').innerHTML=str;
    var gridtab_vari=document.getElementById('gridtab');
    document.getElementById('hiddenrowcount').value=ds.Tables[0].Rows.length;
    countGridElement=ds.Tables[0].Rows.length;
    //////this is the variable to count that first time how many rows return ed 
    retrows=ds.Tables[0].Rows.length;    

    insertval=1;
    colid="col"+i;
    var insC=document.getElementById('txtinsertion').value;
    if(insC=="")
    {
         insC="1";
    }
    dcou=0;
    retrows=parseInt(ds.Tables[0].Rows.length)/parseInt(insC);
    var inew=0;
    for(inew = 0; inew < ds.Tables[0].Rows.length; inew++)
    {
       
        var dCheck=checkValidEdition(ds.Tables[0].Rows[inew].Edition_Name);
           if(dCheck==false)
            countGridElement = parseInt(countGridElement,10)-1;
        if(dCheck==true)
        {
         
        uomid="uom"+i;
        var id="Text" + i;
        editid="edit"+i;

        inserts="ins"+i;
        colid="col"+i;
        agrred="agr"+i;
        btn_Pg_="btn_Pg_"+i;
                            
////***        str=str+"<tr>";
////        str+="<td width='40px'>";
////        str+="<input  class='buttonpgset' id='"+btn_Pg_+"' onClick='javascript:return getButtonIdGrid();' type='button' Value='PageSet' >";                           
////        str+="</td>";
        //bind button pageset for pagination
        Make_Row=document.createElement("tr");
        make_td=document.createElement("td");
        make_td.align="center";        
        str="<input  class='buttonpgset' id='"+btn_Pg_+"' type='button' Value='PageSet'>";                           
        make_td.innerHTML=str;
        Make_Row.appendChild(make_td);
        
        //bind no. and Edition
    
             insertval=parseInt(ds.Tables[0].Rows[inew].IDNUM) + 1;
                                    //str=str+"<tr ><td align=\"center\" id="+inserts+" class=\"TextField\" >"+insertval+"</td><td class=\"dtGrid\" ><input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[i].Edition_Name+"></td>";
            // Make_Row=document.createElement("tr");
             make_td=document.createElement("td");
             make_td.align="center";
             make_td.setAttribute("className","TextField");
             make_td.innerHTML=insertval;
             make_td.id=inserts;
             Make_Row.appendChild(make_td);
             // EDITION
             make_td=document.createElement("td");
             make_td.align="center";
             make_td.setAttribute("className","dtGrid");
             str="<input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[inew].Edition_Name+">";
             make_td.innerHTML=str;
             Make_Row.appendChild(make_td);


////***        if(i%noofinsert==0 || i%totval==0)
////        {
////            insertval=parseInt(ds.Tables[0].Rows[i].IDNUM) + 1;
////            str=str+"<td align=\"center\" id="+inserts+" class=\"TextField\" >"+insertval+"</td><td class=\"dtGrid\" ><input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[i].Edition_Name+"></td>";
////        }
////        else
////        {
////            insertval=parseInt(ds.Tables[0].Rows[i].IDNUM) + 1;
////            str=str+"<td align=\"center\" id="+inserts+" class=\"TextField\" >"+insertval+"</td><td class=\"dtGrid\" ><input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[i].Edition_Name+"></td>";
////        }

        if(ds.Tables[0].Rows[inew].Date==null)
        {
            ds.Tables[0].Rows[inew].Date="";
        }
        
        make_td=document.createElement("td");
        make_td.align="center";
         str="<input class=\"btextforgrid\" type=\"text\" id="+id+"  value='"+ds.Tables[0].Rows[inew].Date+"'  >";
                                //str="<input class=\"btextforgrid\" type=\"text\" id="+id+" value="+nDate+" ><img src=\"Images/cal1.gif\" height=\"14\" width=\"14\" />";
        make_td.innerHTML=str;
        Make_Row.appendChild(make_td);

////***        str=str + "<td><input class=\"btextforgrid\" type=\"text\"  id="+id+"  value="+ds.Tables[0].Rows[i].Date+" ><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\" height=\"14\" width=\"14\" /></td>";


        ////this is to bind the Ad sub cat drop down
        adsubcat="ads"+i;
        make_td=document.createElement("td");
        make_td.align="center";
        make_td.setAttribute("className","dtGrid");
        if(adsubcat_vari.value!='0')
        {
            if(i==0)
            {        
                str="<input class=\"dropdownforgrid1\" type=\"text\"  id="+adsubcat+" value="+adsubcat_vari.value+"><div id='agdiv' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglist' id='aglist' className='btextlist' size=4 Width=100px Height=50px></select></div>";
            } 
            else
            {
                str="<input class=\"dropdownforgrid1\" type=\"text\"  id="+adsubcat+" value="+adsubcat_vari.value+">";
            }
        }
        else
        {
            if(i==0)
            {  
                str="<input class=\"dropdownforgrid1\" type=\"text\"  id="+adsubcat+" value=''><div id='agdiv' style='position:absolute;display: none;' Width=100px Height=50px><select name='aglist' id='aglist' onclick='FillSubCatinGrid()' class='btextlist' size=4 Width=100px Height=50px></select></div>";
            }
            else
            {
                str="<input class=\"dropdownforgrid1\" type=\"text\"  id="+adsubcat+" value=''>";
            } 
        }
    
        make_td.innerHTML=str;
        Make_Row.appendChild(make_td);
        
//// ***       str=str+"<td><select id="+adsubcat+" class=\"dropdownforgrid1\" onchange=\"getvalueintoinserts("+adsubcat+","+inserts+","+insertval+");\">";
////        str=str+"<option value=\"0\" selected=\"true\">-select-</option>";
////        for(l=0;l<=ds.Tables[3].Rows.length-1;l++)
////        {
////            if(ds.Tables[3].Rows[l].Adv_Subcat_Code==document.getElementById('drpadsubcategory').value && document.getElementById('drpadsubcategory').value!="0")
////            {
////                str=str+"<option value="+ds.Tables[3].Rows[l].Adv_Subcat_Code+" selected="+document.getElementById('drpadsubcategory').value+">"+ds.Tables[3].Rows[l].Adv_Subcat_Code+"</option>";
////            }
////            else
////            {
////                str=str+"<option value="+ds.Tables[3].Rows[l].Adv_Subcat_Code+">"+ds.Tables[3].Rows[l].Adv_Subcat_Code+"</option>";
////            }
////        }

////        str=str+"</select></td><td><select id="+colid+" class=\"dropdownforgrid1\" onchange=\"getvalueintoinsertsforcolor("+colid+","+inserts+","+insertval+");\">";


//this is to bind the color drop down
        make_td=document.createElement("td");
        make_td.align="center";
        make_td.setAttribute("className","dropdownforgrid");
        if(color_vari.value!='0')
        {
            str="<input class=\"btextforgrid\" type=\"text\"  id="+colid+" value="+color_vari.value+">";
        }
        else
        {
            str="<input class=\"btextforgrid\" type=\"text\"  id="+colid+" value=''>";
        }
        
        make_td.innerHTML=str;
        Make_Row.appendChild(make_td);
        
////***        str=str + "<option value=\"0\" selected=\"true\">-select-</option>";
////        for(j=0;j<=ds.Tables[1].Rows.length-1;j++)
////        {
////            if(ds.Tables[1].Rows[j].col_Code==document.getElementById('drpcolor').value && document.getElementById('drpcolor').value!="0")
////            {
////                str=str + "<option value="+ds.Tables[1].Rows[j].col_Code+" selected="+document.getElementById('drpcolor').value+">"+ds.Tables[1].Rows[j].col_Name+"</option>";    
////            }
////            else
////            {
////                str=str + "<option value="+ds.Tables[1].Rows[j].col_Code+">"+ds.Tables[1].Rows[j].col_Name+"</option>";    
////            }
////        }
//********************************************* 
    premid="prem"+i;
    prem1id="premone"+i;
    height="hei"+i;
    width="wid"+i;
    size="siz"+i;
    pagepost="pagpos"+i;
    noofcol="nocol"+i;
//////// on change function is there to calculate the size 
     if(column_vari.disabled==true)  
       {
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" style=\" background-color: White;\" id="+height+"   type=\"text\"  value="+adsize1_vari.value+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" id="+width+" style=\"background-color:White;\"   type=\"text\"  value="+adsize2_vari.value+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" disabled id="+noofcol+"   type=\"text\"  value="+column_vari.value+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+areaval+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);           
           
        }
        else
        {
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" style=\" background-color: White;\" id="+height+"  type=\"text\"  value="+adsize1_vari.value+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\"  id="+width+" style=\"background-color:White;\"   type=\"text\"  value="+adsize2_vari.value+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\"  id="+noofcol+"   type=\"text\"  value="+column_vari.value+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+areaval+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td); 
        }

////***    if(document.getElementById('txtcolum').disabled==true)
////    {
////        str=str+"</select></td><td><input class=\"btextsmallsize\" id="+height+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+insertval+","+noofcol+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+document.getElementById('txtadsize1').value+"></td><td><input class=\"btextsmallsize\" id="+width+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+insertval+","+noofcol+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+document.getElementById('txtadsize2').value+"></td><td><input class=\"btextsmallsize1\" disabled id="+noofcol+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+insertval+","+noofcol+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+document.getElementById('txtcolum').value+"></td><td><input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+document.getElementById('txttotalarea').value+"></td>";
////    }
////    else
////    {
////        str=str+"</select></td><td><input class=\"btextsmallsize\" id="+height+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+insertval+","+noofcol+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+document.getElementById('txtadsize1').value+"></td><td><input class=\"btextsmallsize\"  id="+width+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+insertval+","+noofcol+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+document.getElementById('txtadsize2').value+"></td><td><input class=\"btextsmallsize1\"  id="+noofcol+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+insertval+","+noofcol+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+document.getElementById('txtcolum').value+"></td><td><input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+document.getElementById('txttotalarea').value+"></td>";    
////    }



        //insert status
           insertsta="inssta"+i;
     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input class=\"btextforgrid\"  type=\"text\" id="+insertsta+"  value='booked'>";
     Make_Row.appendChild(make_td);
    
    

    
////***    str=str+"<td><select id="+pagepost+" class=\"dropdownforgrid1\" onchange=\"return getpageprem("+pagepost+","+i+",'"+pagstr+"');\">";
////    str=str+"<option value=\"0\" selected=\"true\">-select-</option>";
////    for(p=0;p<=ds.Tables[7].Rows.length-1;p++)
////    {
////        if(ds.Tables[7].Rows[p].pos_type_code==document.getElementById('drppageposition').value && document.getElementById('drppageposition').value!="0")
////        {
////            str=str+"<option value="+ds.Tables[7].Rows[p].pos_type_code+" selected="+document.getElementById('drppageposition').value+">"+ds.Tables[7].Rows[p].pos_type_code+"</option>";
////        }
////        else
////        {
////            str=str+"<option value="+ds.Tables[7].Rows[p].pos_type_code+">"+ds.Tables[7].Rows[p].pos_type_code+"</option>";
////        }
////    }
////   str=str+"</select></td>";
    
    
   //pageno,remark,upload
    pageno_inserts="pagno"+i;
    remark_inserts="rem"+i;
////***    str=str+"<td><input class=\"btextsmallsize\"  onkeypress=\"javascript:return rateenter();\"  type=\"text\" id="+pageno_inserts+"  value=\"\"></td>";
     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input  class=\"btextforinsertright\"  type=\"text\" id="+pageno_inserts+"  value=\"\">";
     Make_Row.appendChild(make_td);

/////////////this is to bind the status material drop down
    matsta="mat"+i;
    make_td=document.createElement("td");
    make_td.align="center";
    if(matsta_vari.value!="0")
    {
        str="<input class=\"btextforgrid\"  id="+matsta+" type=\"text\"  value="+matsta_vari.value+">";
    }
    else
    {
         str="<input class=\"btextforgrid\"  id="+matsta+" type=\"text\">";
    }
    make_td.innerHTML=str;
    Make_Row.appendChild(make_td);
    
/////this is to bind the status material dropdown
////***    str=str+"<td><select id="+matsta+" class=\"dropdownforgrid\">";
////    if(document.getElementById('drpmatsta').value="0")
////    {
////         str=str+"<option value=\"0\" selected="+document.getElementById('drpmatsta').value+">Select</option>";
////    }
////    else
////    {
////         str=str+"<option value=\"0\">Select</option>";
////    }
////    if(document.getElementById('drpmatsta').value="hardcopy")
////    {
////         str=str+"<option value=\"hardcopy\" selected="+document.getElementById('drpmatsta').value+">Hard Copy</option>";
////    }
////    else
////    {
////         str=str+"<option value=\"hardcopy\">Hard Copy</option>";
////    }
////    if(document.getElementById('drpmatsta').value="softcopy")
////    {
////         str=str+"<option value=\"softcopy\" selected="+document.getElementById('drpmatsta').value+">Soft Copy</option>";
////    }
////    else
////    {
////         str=str+"<option value=\"softcopy\">Soft Copy</option>";
////    }
////    if(document.getElementById('drpmatsta').value="cd")
////    {
////        str=str+"<option value=\"cd\" selected="+document.getElementById('drpmatsta').value+">CD</option>";
////    }
////    else
////    {
////        str=str+"<option value=\"cd\">CD</option>";
////    }
////    if(document.getElementById('drpmatsta').value="other")
////    { 
////        str=str+"<option value=\"other\" selected="+document.getElementById('drpmatsta').value+">Others</option>";
////    }
////    else
////    {
////        str=str+"<option value=\"other\">Others</option>";
////    }
////    str=str+"</select></td>";



    filename="fil"+i;
    picfield="pic"+i;
    var upl="upload"+i
    make_td=document.createElement("td");
    make_td.align="center";
    str="<input class=\"btextforgrid\" type=\"text\" id="+filename+" disabled  value=\"\">";
    make_td.innerHTML=str;
    Make_Row.appendChild(make_td);   
    

    //str=str+"<td width=\"50px\"><input  class=\"button1\" type=\"button\" Value=\"Attachment\" onclick=\"uploadimage('"+picfield+"','"+insertval+"','"+editid+"','"+filename+"','"+i+"')\">";
     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input  class=\"button1\" type=\"button\"  id="+upl+" Value=\"Attachment\">";
     Make_Row.appendChild(make_td);

    
    //bind Remark
     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input  class=\"btextforgrid\"    type=\"text\" id="+remark_inserts+"  value=\"\">";
     Make_Row.appendChild(make_td);
     
////***    str=str+"<td><input class=\"btextforgrid\" type=\"text\" id="+filename+" disabled  value=\"\"></td>";

////    str=str+"<td width=\"50px\"><input  class=\"button1\" type=\"button\" Value=\"Attachment\" onclick=\"uploadimage('"+picfield+"','"+insertval+"','"+editid+"','"+filename+"')\">";

////    str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+remark_inserts+"  value=\"\"></td>";
        
    cardid="card"+i;

//this is the function cretaed to get the solo edition rate break up with referrence  to the package selected 
    var cs=0;
    for(cs=0;cs<=ds.Tables[8].Rows.length-1;cs++)
    {
       if(ds.Tables[0].Rows[inew].Edition_Name!=undefined )
       {
          if(ds.Tables[0].Rows[inew].Edition_Name==ds.Tables[8].Rows[cs].Edition_Name)
          {
                //str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[8].Rows[cs].weekrate+">";
             make_td=document.createElement("td");
             make_td.align="center";
             make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[8].Rows[cs].weekrate+">";
             Make_Row.appendChild(make_td); 
          }
       }    
    }
///////////////////////

    if(ds.Tables[8].Rows.length == 0)
    {
        //str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value=\"\">";
          make_td=document.createElement("td");
          make_td.align="center";
          make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value=\"\">";
          Make_Row.appendChild(make_td); 
    }

/* if(objedition.options.length>=1)
    {
//        objedition.options.length = 0; 
//        objedition.options[0]=new Option("-Select-","0");
        if(ds.Tables[0].Rows[i].Edition_Name!=undefined )
        {
            objedition.options[objedition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Name,ds.Tables[0].Rows[i].Edition_Name);
            objedition.options.length;
        }   
    }*/
    
    
////***    str=str+"<td>";
////    var cs=0;
////    if(objedition.options.length<=1)
////    {
////        objedition.options.length = 0; 
////        objedition.options[0]=new Option("-Select-","0");
////        if(ds.Tables[0].Rows[i].Edition_Name!=undefined )
////        {
////            objedition.options[objedition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Name,ds.Tables[0].Rows[i].Edition_Name);
////            objedition.options.length;
////        }   
////    }
////    for(cs=0;cs<=ds.Tables[8].Rows.length-1;cs++)
////    {
////        if(ds.Tables[0].Rows[i].Edition_Name!=undefined )
////        {
////            if(ds.Tables[0].Rows[i].Edition_Name==ds.Tables[8].Rows[cs].Edition_Name)
////            {
////                str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[8].Rows[cs].weekrate+">";
////            }
////        }
////    }
////    if(ds.Tables[8].Rows.length == 0)
////    {
////        str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value=\"\">";
////    }
//********************************************

    discrate="disrat"+i;
    insertsta="inssta"+i;
    billstat="bill"+i;
    
////////this is to bind the status of insertion drop down  agrred

     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+discrate+"  value=\"\">";
     Make_Row.appendChild(make_td);

   // str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=\"\"></td>";
     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=\"\">";
     Make_Row.appendChild(make_td);
     
     
     ////this loop is to bind the page position
    pagstr="fir";
    make_td=document.createElement("td");
    make_td.align="center";
    if(drppagepos_vari.value=='0')
    {
         make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+pagepost+"  value=\"\">";
    }
    else
    {
         make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+pagepost+"  value='"+drppagepos_vari.value+"'>";
    }
        
    Make_Row.appendChild(make_td);
    
    

////***    str=str+"</td><td><input class=\"btextforgrid\" disabled type=\"text\" id="+discrate+"  value=\"\"></td>";
////    str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=\"\"></td>";
////    str=str+"<td><select id="+insertsta+" class=\"dropdownforgrid\" onchange=\"javascript:return chkpublishdate('"+insertsta+"','"+id+"');\">"; 
////    if(browser!="Microsoft Internet Explorer")
////    {
////        var b=0; 
////        for(b=1;b<=xmlObj.childNodes[19].childNodes.length-1;)
////        {
////            if(xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue=="booked")
////            {
////                str=str+"<option value="+xmlObj.childNodes[19].childNodes[b+2].childNodes[0].nodeValue+" selected=\"true\">"+xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue+"</option>";
////            }
////            else
////            {
////                str=str+"<option value="+xmlObj.childNodes[19].childNodes[b+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue+"</option>";                                
////            }                                    
////            b=b+4;
////        } 
////    }
////    else
////    {
////        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
////        loadXML('xml/billcycle.xml');
////        var b=0;

////        for(b=0;b<=xmlObj.childNodes(9).childNodes.length-1;b++)
////        {
////            if(xmlObj.childNodes(9).childNodes(b+1).text=="booked")
////            {
////                str=str+"<option value="+xmlObj.childNodes(9).childNodes(b+1).text+" selected=\"true\">"+xmlObj.childNodes(9).childNodes(b).text+"</option>";
////            }
////            else
////            {
////                str=str+"<option value="+xmlObj.childNodes(9).childNodes(b+1).text+">"+xmlObj.childNodes(9).childNodes(b).text+"</option>";
////            }
////            b=b+1;
////        } 
////    }

////////////this is to for larest date

    late="lat"+i;
    repeat="rep"+i;
    var dat="mm+"/"+"/"+dd+"/"+yyyy";
    make_td=document.createElement("td");
    make_td.align="center";
    make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" id="+late+"   value=\"\" >";
    Make_Row.appendChild(make_td);

    make_td=document.createElement("td");
    make_td.align="center";
    make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" id="+repeat+"  value=\"\">";
    Make_Row.appendChild(make_td);

    namecode="one";
    
////***    str=str+"</select></td><td><input class=\"btextforgrid\" type=\"text\" id="+late+"  value=\"\" onchange=\"javascript:return checkdate(Form1."+late+");\" onkeypress=\"return dateenter();\"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+late+", Form1."+late+", "+dat+");\" height=\"14\" width=\"14\" /> </td><td><input class=\"btextforgrid\" type=\"text\" id="+repeat+"  value=\"\" onchange=\"javascript:return checkdate(Form1."+repeat+");\" onkeypress=\"return dateenter();\"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+repeat+", Form1."+repeat+", "+dat+");\" height=\"14\" width=\"14\" /></td>";
////   
////    str=str+"<td><select id="+premid+" class=\"dropdownforgrid\" onchange=\"return getpercenprem("+premid+","+i+",'"+namecode+"');\"  >";

////    ///this is to bind the premium drop down
////    str=str+"  <option value=\"0\" selected=\"true\">select</option>";
////    for(k=0;k<=ds.Tables[2].Rows.length-1;k++)
////    {
////    ////////on click function is there to get the prem % on premium drop down change
////        str=str+"  <option value="+ds.Tables[2].Rows[k].Premiumcode+">"+ds.Tables[2].Rows[k].premiumname+"</option>"
////    }

    premper="premper"+i;
    premper1="premperone"+i;
    adtypid="adtyp"+i;
    var namecode2="two";
    preall="preall"+i;
    adcat="adcat"+i;
    page="pgpre"+i;
    pageprem="pagper"+i;
    var h;
    ///this is to bind the page prem 2 drp down
    pagstr="sec"    
    
    
////***    str=str+"</select></td><td><input class=\"btextsmallsize\" disabled type=\"text\" id="+premper+" value=\"\"></td>"
////    str=str+"<td><select id="+prem1id+" class=\"dropdownforgrid\" onchange=\"return getpercenprem("+prem1id+","+i+",'"+namecode2+"');\"  >";
////            /////this is to bind the premium 2 drop down
////    str=str+"  <option value=\"0\" selected=\"true\">Select</option>";
////    for(k=0;k<=ds.Tables[2].Rows.length-1;k++)
////    {
////            ////////on click function is there to get the prem % on premium drop down change
////        str=str+"  <option value="+ds.Tables[2].Rows[k].Premiumcode+">"+ds.Tables[2].Rows[k].premiumname+"</option>"
////    }

////    str=str+"</select></td><td><input class=\"btextsmallsize\" disabled type=\"text\" id="+premper1+" value=\"\"></td>"
////            ///this is to bind the page prem 2 drp down
////    pagstr="sec"
////    str=str+"<td><select id="+page+" class=\"dropdownforgrid\" onchange=\"return getpageprem("+page+","+i+",'"+pagstr+"');\"  >";
////            /////this is to bind the premium 2 drop down
////    str=str+"  <option value=\"0\" selected=\"true\">Select</option>";
////    for(h=0;h<=ds.Tables[7].Rows.length-1;h++)
////    {
////            ////////on click function is there to get the prem % on premium drop down change
////        str=str+"  <option value="+ds.Tables[7].Rows[h].pos_type_code+">"+ds.Tables[7].Rows[h].pos_type+"</option>"
////    }
////            ////this is to bind the per for page premium
////    str=str+"</select></td><td><input disabled class=\"btextsmallsize\" type=\"text\" id="+pageprem+" value=\"\"></td>"
////        
///////////////////////////////////////////////

     make_td=document.createElement("td");
     make_td.align="center";
     //   str="</select></td><td><input disabled class=\"btextsmallsize\" type=\"text\" id="+pageprem+" value=\"\"></td>"
     make_td.innerHTML="<input  class=\"btextsmallsize\" type=\"text\" id="+premid+" value=\"\">";
     Make_Row.appendChild(make_td);
     make_td=document.createElement("td");
     make_td.align="center";
     make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id="+premper+" value=\"\">";
     Make_Row.appendChild(make_td);
//////////////this is to bind the drop down for accepting the premium
    make_td=document.createElement("td");
    make_td.align="center";
    str="<select id="+preall+" disabled class=\"dropdownforgrid\">";
    str=str+"<option value=\"0\">Select</option>";
    str=str+"<option value=\"1\">Yes</option>";
    str=str+"<option value=\"2\">No</option>";
    make_td.innerHTML=str;
    Make_Row.appendChild(make_td);
    
    //to bind the ad category    
    make_td=document.createElement("td");
    make_td.align="center";
    if(adcat_vari.value!='0')
    {
        make_td.innerHTML="<input  class=\"dropdownforgrid\" type=\"text\" id="+adcat+" value='"+adcat_vari.value+"'>";
    }
    else
    {
        make_td.innerHTML="<input  class=\"dropdownforgrid\" type=\"text\" id="+adcat+" >";
    }    
    Make_Row.appendChild(make_td);
        
////    str=str+"</td></select><td><select id="+adcat+" class=\"dropdownforgrid\" onchange=\"filladsubgrid("+adcat+","+adsubcat+")\">";
////    ///this loop is to bind the ad category
////    str=str+"  <option value=\"0\" selected=\"true\">-select-</option>";
////    for(o=0;o<=ds.Tables[6].Rows.length-1;o++)
////    {
////        if(ds.Tables[6].Rows[o].adv_cat_code==document.getElementById('drpadcategory').value && document.getElementById('drpadcategory').value!="0")
////        {
////            str=str+"<option value="+ds.Tables[6].Rows[o].adv_cat_code+" selected="+document.getElementById('drpadcategory').value+">"+ds.Tables[6].Rows[o].adv_cat_name+"</option>";
////        }
////        else
////        {
////            str=str+"<option value="+ds.Tables[6].Rows[o].adv_cat_code+">"+ds.Tables[6].Rows[o].adv_cat_name+"</option>";
////        }
////    }
////    str=str+"</select></td>";
    
    
        if(browser!="Microsoft Internet Explorer")
        {
            if(dbill=="")
            {
                make_td=document.createElement("td");
                make_td.align="center";
                dbill=dbill+"<select id="+billstat+" class=\"dropdownforgrid\">";
                 /////////////this function is to bind the bill status dropdown
                 var c=0;
                 for(c=1;c<=xmlObj.childNodes[3].childNodes.length-1;c=c+4)
                 {   
                     dbill=dbill+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";
                 }
                 dbill=dbill+"</select>";
                 make_td.innerHTML=dbill;
                 Make_Row.appendChild(make_td); 
             }
             else
             {
                // str=str+dbill.replace("bill"+dcou,billstat);          
                make_td=document.createElement("td");
                make_td.align="center";
                str=dbill.replace("bill"+dcou,billstat);  
                make_td.innerHTML=str;
                Make_Row.appendChild(make_td);
             }    
        }        
        else
        {        
           if(dbill=="")
           {
              make_td=document.createElement("td");
              make_td.align="center";
              dbill=dbill+"<select id="+billstat+" class=\"dropdownforgrid\">";
              var c=0;
              if(xmlObj.childNodes(1)==null)
              {
                loadXML('xml/billcycle.xml');
              }
              for(c=0;c<=xmlObj.childNodes(1).childNodes.length-1;c++)
              {
                   dbill=dbill+"<option value="+xmlObj.childNodes(1).childNodes(c+1).text+">"+xmlObj.childNodes(1).childNodes(c).text+"</option>";
                   c=c+1;
              }               
                  
              dbill=dbill+"</select>";
              make_td.innerHTML=dbill;
              Make_Row.appendChild(make_td); 
           }
           else
            {           
                make_td=document.createElement("td");
                make_td.align="center";
                str=dbill.replace("bill"+dcou,billstat);  
                make_td.innerHTML=str;
                Make_Row.appendChild(make_td);
            }    
               
         }
    
////***    str=str+"<td><select id="+billstat+" class=\"dropdownforgrid\">";
////        /////////////this function is to bind the bill status dropdown
////    if(browser!="Microsoft Internet Explorer")
////    {
////    //loadXML('xml/billcycle.xml');

////        var c=0;
////        //setTimeout("Func2()", 3000);
////        //alert("Delay");
////        for(c=1;c<=xmlObj.childNodes[3].childNodes.length-1;)
////        {
////            str=str+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";
////            c=c+4;
////        }
////    }
////    else
////    {
////        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 

////        loadXML('xml/billcycle.xml');

////        var c=0;

////        for(c=0;c<=xmlObj.childNodes(1).childNodes.length-1;c++)
////        {

////            str=str+"<option value="+xmlObj.childNodes(1).childNodes(c+1).text+">"+xmlObj.childNodes(1).childNodes(c).text+"</option>";
////            c=c+1;
////        } 
////    }
    paid="pai"+i;
    solo="sol"+i;
    gross="gro"+i;
        ///////////////this is to bind the drop down for paid/free insertion
     if(ds.Tables[9].Rows[0].Paid_permission=="0")
     {
         if(browser!="Microsoft Internet Explorer")
         {
             if(dpaid=="")
             {
                make_td=document.createElement("td");
                make_td.align="center";
                dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\" disabled>"; 
                dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                dpaid=dpaid+"<option value=\"N\">No</option>";
                dpaid=dpaid+"</select>";
                make_td.innerHTML=dpaid;
                Make_Row.appendChild(make_td);
              }
              else
              {
                make_td=document.createElement("td");
                make_td.align="center";
                str=dpaid.replace("pai"+dcou,paid);    
                make_td.innerHTML=str;
                Make_Row.appendChild(make_td);                 
              }
         }
         else
         {
            if(dpaid=="")
            {
                  make_td=document.createElement("td");
                  make_td.align="center";
                  dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\" disabled >";
                  dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                  dpaid=dpaid+"<option value=\"N\">No</option>";
                  dpaid=dpaid+"</select>";
                  make_td.innerHTML=dpaid;
                  Make_Row.appendChild(make_td);
             }
             else
             {
                make_td=document.createElement("td");
                make_td.align="center";
                str=dpaid.replace("pai"+dcou,paid);    
                make_td.innerHTML=str;
                Make_Row.appendChild(make_td);
              }     
         }
     }
     else
     {
          if(browser!="Microsoft Internet Explorer")
          {
               if(dpaid=="")
                {
                   make_td=document.createElement("td");
                   make_td.align="center";
                   dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\">";
                   dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                   dpaid=dpaid+"<option value=\"N\">No</option>";
                   dpaid=dpaid+"</select>";
                   make_td.innerHTML=dpaid;
                   Make_Row.appendChild(make_td);
                }
                else
                {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str=dpaid.replace("pai"+dcou,paid);    
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                }
           }
           else
           {                
               if(dpaid=="")
               {
                      make_td=document.createElement("td");
                      make_td.align="center";
                      dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\" >";
                      dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                      dpaid=dpaid+"<option value=\"N\">No</option>";
                      dpaid=dpaid+"</select>";
                      make_td.innerHTML=dpaid;
                      Make_Row.appendChild(make_td);
                }
                else
                {
                   make_td=document.createElement("td");
                   make_td.align="center";
                   str=dpaid.replace("pai"+dcou,paid);    
                   make_td.innerHTML=str;
                   Make_Row.appendChild(make_td);
                }   
               
            }
      }  
        
        
////***    if(ds.Tables[9].Rows[0].Paid_permission=="0")
////    {
////        str=str+"</select></td><td><select id="+paid+" class=\"dropdownforgridsmall\" disabled \">";//onchange=\"putpaidintoinsert("+paid+","+inserts+","+insertval+");\">";
////    }
////    else
////    {
////        str=str+"</select></td><td><select id="+paid+" class=\"dropdownforgridsmall\">";//onchange=\"putpaidintoinsert("+paid+","+inserts+","+insertval+");\">";
////    }

////    str=str+"<option value=\"Y\">Yes</option>";
////    str=str+"<option value=\"N\">No</option>";

   
    billamt="ba"+i;
    billrate="br"+i;    
    str=str+"</select></td>";
    
     make_td=document.createElement("td");
     make_td.align="center";  
     make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+solo+"  value=\"\">";
     Make_Row.appendChild(make_td);

    //str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value=\"\"></td>";
     make_td=document.createElement("td");
     make_td.align="center";  
     make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value=\"\">";
     Make_Row.appendChild(make_td);     
     
   // str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billamt+"  value=\"\"></td>";
    make_td=document.createElement("td");
    make_td.align="center";
    make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+billamt+"  value=\"\">";
    Make_Row.appendChild(make_td);
    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
    make_td=document.createElement("td");
    make_td.align="center";
    make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+billrate+"  value=\"\">";
    Make_Row.appendChild(make_td);
    
////***    str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+solo+"  value=\"\"></td>";
////    str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value=\"\"></td>";
////    str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+billamt+"  value=\"\"></td>";
////    str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+billrate+"  value=\"\"></td>";

                    showid="sho"+i;
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextforgrid\" style=\"display:none;\" type=\"text\" id="+showid+"  value='0'>";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);


        pkgcodegrid='hiddenpckcode'+i;    
        make_td=document.createElement("td");
        make_td.align="center";
        make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkgcodegrid+"' value="+ds.Tables[0].Rows[inew].EDITION_CODE+">";
        Make_Row.appendChild(make_td);
    
////***    str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkgcodegrid+"' value="+ds.Tables[0].Rows[i].EDITION_CODE+"></td>";
    
    //This below code for  puting the number of occurance of packages into grid
    var pkg_ins='pkg_ins'+i;
    for(var countpkg=0;countpkg<pkgcopy_vari.length;countpkg++)
    {
        var pkgcopy=pkgcopy_vari.options[countpkg].value;
        var arrpkgcopy=pkgcopy.split('@')
        var pkgcopycode=arrpkgcopy[0];
        var arr_pkg_ins_value=arrpkgcopy[1].split('(');
        var pkg_ins_value=arr_pkg_ins_value[1].replace(')','');
        if(pkgcopycode==ds.Tables[0].Rows[inew].EDITION_CODE)
        {
           // str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+pkg_ins_value+"></td>";
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+pkg_ins_value+">";
            Make_Row.appendChild(make_td);
        }
    }

           
        pkg_alias='pkg_alias'+i;    
        make_td=document.createElement("td");
        make_td.align="center";
        make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_alias+"' value='"+ds.Tables[0].Rows[inew].PKGNAME+"'>";
        Make_Row.appendChild(make_td);            
   
        gridtab_vari.getElementsByTagName("tbody")[0].appendChild(Make_Row);   
        i=parseInt(i,10) + 1;
        }  
}
   idnew=ds.Tables[0].Rows.length;
////   document.getElementById('tblinsert').innerHTML=str;
   //subtractrow="show";
   previnsertion=document.getElementById('txtinsertion').value;
    for ( i = 0; i < gridtab_vari.getElementsByTagName("tbody")[0].rows.length-1; i++)
    { 
                
               var height="hei"+i;
               var late="lat"+i;
               var repeat="rep"+i;
               var page="pagpos"+i;
               var pagstr="sec";
               var adcat="adcat"+i;
               var adsubcat="ads"+i;
               var premid="prem"+i;
                var id="Text" + i;
                var width="wid"+i;
                var  noofcol="nocol"+i;
                inserts="ins"+i;
                
                var insertval=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[i+1].cells[1].innerHTML;
                var height_vari=document.getElementById(height);
                var par1=(height_vari.parentNode).parentNode;
                if(browser!="Microsoft Internet Explorer")
                    {
                    document.getElementById(height).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                document.getElementById(width).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                 document.getElementById(noofcol).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
            
                document.getElementById(late).onchange=new Function("return checkdate(Form1."+late+");");
                document.getElementById(repeat).onchange=new Function("return checkdate(Form1."+repeat+");");
               document.getElementById(page).onchange="return getpageprem('"+page+"',"+i+",'"+pagstr+"');" ;
               document.getElementById(id).onchange=new Function("return chkDateforGrid();");
               document.getElementById(premid).onchange=new Function("getpercenprem('"+premid+"',"+i+",'"+namecode+"')");
                    }
               else
               {
                par1.all[height].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                par1.all[width].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                 par1.all[noofcol].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
            
                par1.all[late].onchange=new Function("return checkdate(Form1."+late+");");
                par1.all[repeat].onchange=new Function("return checkdate(Form1."+repeat+");");
               par1.all[page].onchange="return getpageprem('"+page+"',"+i+",'"+pagstr+"');" ;
               par1.all[id].onchange=new Function("return chkDateforGrid();");
               par1.all[premid].onchange=new Function("getpercenprem('"+premid+"',"+i+",'"+namecode+"')");
               }
       }   
     /*   var objinsert=document.getElementById('drpinsertion');
        if(objinsert.options.length <=1)
        {
            objinsert.options.length = 0; 
            objinsert.options[0]=new Option("-Select-","0");
            for(var i=1;i<=document.getElementById('txtinsertion').value;i++)
            {
                objinsert.options[objinsert.options.length] = new Option(i,i);
                objinsert.options.length;
            }
        }     
     */
   return false;
}

function insertLine_callback(response)
{
    var ds=response.value;
    fillinsert=ds.Tables[0].Rows.length;         
    var i=0;
    var str="";
     var adsubcat_vari=document.getElementById('drpadsubcategory');
    var color_vari=document.getElementById('drpcolor');
    var column_vari=document.getElementById('txtcolum');
    var uom_vari=document.getElementById('drpuom');
    var hiddenuom_vari=document.getElementById('hiddenuomdesc');
    var matsta_vari = document.getElementById('drpmatsta');
    var drppagepos_vari=document.getElementById('drppageposition');
    var adcat_vari=document.getElementById('drpadcategory');
    var pkgcopy_vari=document.getElementById('drppackagecopy'); 
      var gridtab_vari=document.getElementById('gridtab');  
    var dat="mm+"/"+"/"+dd+"/"+yyyy";
    var j=0;
    var k=0;
    var l=0;
    var m=0;
    var n=0;
    var o=0;
    var p=0;
    var premid;
    var premper;
    var colid;
    var height;
    var width;
    var size;
    var late;
    var adtypid;
    var uomid;
    var cardid;
    var premper1;
    var prem1id;
    var name;
    var inserts;
    var pagepost;
    var preall;
    var adcat;
    var adsubcat;
    var matsta;
    var filename;
    var discrate;
    var insertsta;
    var billstat;
    var editid;
    var repeat;
    var picfieldl;
    var colid;
    var paid;
    var agrred;
    var solo;
    var gross;
    var s;
    var count;
    var len="bookdiv";
    var pageno_inserts;
    var remark_inserts;
    var page;
    var pageprem;
    var billamt;
    var billrate;
    var pagstr;
    //new change for bind grid line
    var dcat1="";
    var dcol="";
    var dinsert="";
    var dstatus="";
    var dposition="";
    var dprem1="";
    var dpre="";
    var dmcat="";
    var dbill="";
    var dadcat3="";
    var dadcat4="";
    var dadcat5="";
    var dpaid="";
    var dcou=0;
   //***************************
    var objedition=document.getElementById('drpedition');
if(document.getElementById('hiddensavemod').value!="0")
   {
        count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
        idnew=parseInt(count);
        document.getElementById('hiddenrowcount').value=count;
        //insertval=count;
        if(document.getElementById('hiddeninsertion').value!="")
        {
            gridItemCount=parseInt(count)/parseInt(document.getElementById('hiddeninsertion').value);
            insertval=document.getElementById('hiddeninsertion').value;
            tempins=document.getElementById('hiddeninsertion').value;
             count = parseInt(ds.Tables[0].Rows.length,10) / parseInt(document.getElementById('txtinsertion').value,10);
             count = parseInt(count) * parseInt(document.getElementById('hiddeninsertion').value);
            document.getElementById('hiddeninsertion').value=""
        }
        
       
    }
    else
    {
        count=document.getElementById('hiddenrowcount').value;   
        document.getElementById('hiddenrowcount').value=ds.Tables[0].Rows.length;
    }
   // count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
    if(document.getElementById('txtrepeatingdate').value!="")
    {
         count=0;
    }

    var temp=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1; 
    //i=count;
    i=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
    var adsize1val=document.getElementById('txtadsize1').value;
    var adsize2val=document.getElementById('txtadsize2').value;
    var colval=document.getElementById('txtcolum').value;
    var areaval=document.getElementById('txttotalarea').value;
    dcou=i;
    for(s = count; s < ds.Tables[0].Rows.length; s++)
    {  
                    
        if(getid!="" && parseInt(i)<parseInt(getid))
        {
            i=getid;
           // i=parseInt(i)+1;
        }  
        var vvalue="";
        if(checkflag==1)
        {
            caldate[cali]=dateSelected;
	        caldatemonth[cali]=parseInt(monthSelected)+1;
	        caldateyear[cali]=yearSelected;    
	        cali=cali+1;
	    }        
	   var dCheck=checkValidEdition(ds.Tables[0].Rows[s].Edition_Name);     
	   if(dCheck==true)
	   {
       var id="Text" + i;
       uomid="uom"+i;
       inserts="ins"+i;
       editid="edit"+i;
       colid="col"+i;
       agrred="agr"+i;
       btn_Pg_="btn_Pg_"+i;    
       //bind button pageset for pagination
       Make_Row=document.createElement("tr");
       make_td=document.createElement("td");
       make_td.align="center";        
       str="<input  class='buttonpgset' id='"+btn_Pg_+"' type='button' Value='PageSet'>";                           
       make_td.innerHTML=str;
       Make_Row.appendChild(make_td);
       
             
       insertval=parseInt(ds.Tables[0].Rows[s].IDNUM)+1;        
      // Make_Row=document.createElement("tr");
       make_td=document.createElement("td");
       make_td.align="center";
       make_td.setAttribute("class","TextField");
       make_td.innerHTML=insertval;
       make_td.id=inserts;
       Make_Row.appendChild(make_td);
     
       // edition
      make_td=document.createElement("td");
      make_td.align="center";
      make_td.setAttribute("class","dtGrid");
      str="<input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[s].Edition_Name+">";
      make_td.innerHTML=str;
      Make_Row.appendChild(make_td);
    
     //date
      var nDate="";
      if(ds.Tables[0].Rows[s].Date!=null)
      {
         nDate=ds.Tables[0].Rows[s].Date;
      }
      make_td=document.createElement("td");
      make_td.align="center";
      //str="<input class=\"btextforgrid\" type=\"text\" id="+id+"   onfocus=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\"  onkeydown=\"return nodateentry(event);\" value="+nDate+" ><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\" height=\"14\" width=\"14\" />";      
      str="<input class=\"btextforgrid\" type=\"text\" id="+id+"    value="+nDate+">";
      make_td.innerHTML=str;
      Make_Row.appendChild(make_td); 
      
      // Ad Sub Cat
      adsubcat="ads"+i;
      make_td=document.createElement("td");
      make_td.align="center";
      make_td.setAttribute("class","dtGrid");
      if(adsubcat_vari.value!='0')
      {
         str="<input class=\"btextforgrid\" type=\"text\"  id="+adsubcat+" value="+adsubcat_vari.value+">";
      }
      else
      {
         str="<input class=\"btextforgrid\" type=\"text\"  id="+adsubcat+" value=''>";
      }
    
      make_td.innerHTML=str;
      Make_Row.appendChild(make_td);
     
     //color
      make_td=document.createElement("td");
      make_td.align="center";
      make_td.setAttribute("class","dropdownforgrid");
      if(color_vari.value!='0')
      { 
         str="<input class=\"btextforgrid\" type=\"text\"  id="+colid+" value="+color_vari.value+">";
      }
      else
      {
         str="<input class=\"btextforgrid\" type=\"text\"  id="+colid+" value=''>";
      }
    
      make_td.innerHTML=str;
      Make_Row.appendChild(make_td);  
      
      premid="prem"+i;
      prem1id="premone"+i;
      height="hei"+i;
      width="wid"+i;
      size="siz"+i;
      pagepost="pagpos"+i;
      noofcol="nocol"+i;
      //*************bind siz and col
       if(column_vari.disabled==true)  
       {
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" style=\" background-color: White;\" id="+height+"   type=\"text\"  value="+adsize1val+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" id="+width+" style=\"background-color:White;\"   type=\"text\"  value="+adsize2val+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" disabled id="+noofcol+"   type=\"text\"  value="+colval+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+areaval+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);           
           
        }
        else
        {
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" style=\" background-color: White;\" id="+height+"  type=\"text\"  value="+adsize1val+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\"  id="+width+" style=\"background-color:White;\"   type=\"text\"  value="+adsize2val+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\"  id="+noofcol+"   type=\"text\"  value="+colval+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+areaval+">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td); 
        }
       
       
         //insert status
            insertsta="inssta"+i;
              make_td=document.createElement("td");
             make_td.align="center";
             make_td.innerHTML="<input class=\"btextforgrid\"  type=\"text\" id="+insertsta+"  value='booked'>";
             Make_Row.appendChild(make_td);
            //pageno,remark,upload
            pageno_inserts="pagno"+i;
            remark_inserts="rem"+i; 
            picfield="pic"+i;         
            
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input  class=\"btextforinsertright\"   type=\"text\" id="+pageno_inserts+"  value=\"\">";
            Make_Row.appendChild(make_td);
            
            /////////////this is to bind the status material drop down
            matsta="mat"+i;
            make_td=document.createElement("td");
            make_td.align="center";
            if(matsta_vari.value!="0")
            {
                str="<input class=\"btextforgrid\"  id="+matsta+" type=\"text\"  value="+matsta_vari.value+">";
            }
            else
            {
                 str="<input class=\"btextforgrid\"  id="+matsta+" type=\"text\">";
            }
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);            
            
            filename="fil"+i;
            var upl="upload"+i
            make_td=document.createElement("td");
            make_td.align="center";
            str="<input class=\"btextforgrid\" type=\"text\" id="+filename+" disabled  value=\"\">";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);  
    
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input  class=\"button1\" type=\"button\"  id="+upl+" Value=\"Attachment\">";
            Make_Row.appendChild(make_td);
    
          //bind Remark
           make_td=document.createElement("td");
           make_td.align="center";
           make_td.innerHTML="<input  class=\"btextforgrid\"    type=\"text\" id="+remark_inserts+"  value=\"\">";
           Make_Row.appendChild(make_td);
           
           cardid="card"+i;
        //this is the function cretaed to get the solo edition rate break up with referrence  to the package selected 
            var cs=0;
            for(cs=0;cs<=ds.Tables[8].Rows.length-1;cs++)
            {
               if(ds.Tables[0].Rows[i].Edition_Name!=undefined )
               {
                  if(ds.Tables[0].Rows[i].Edition_Name==ds.Tables[8].Rows[cs].Edition_Name)
                  {
                        //str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[8].Rows[cs].weekrate+">";
                     make_td=document.createElement("td");
                     make_td.align="center";
                     make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[8].Rows[cs].weekrate+">";
                     Make_Row.appendChild(make_td); 
                  }
               }    
            }
        ///////////////////////

            if(ds.Tables[8].Rows.length == 0)
            {
                //str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value=\"\">";
                  make_td=document.createElement("td");
                  make_td.align="center";
                  make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value=\"\">";
                  Make_Row.appendChild(make_td); 
            }
            
            discrate="disrat"+i;
            insertsta="inssta"+i;
            billstat="bill"+i;
            
        ////////this is to bind the status of insertion drop down  agrred

             make_td=document.createElement("td");
             make_td.align="center";
             make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+discrate+"  value=\"\">";
             Make_Row.appendChild(make_td);

           // str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=\"\"></td>";
             make_td=document.createElement("td");
             make_td.align="center";
             make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=\"\">";
             Make_Row.appendChild(make_td);
             
             
                 ////this loop is to bind the page position
            pagstr="fir";
            make_td=document.createElement("td");
            make_td.align="center";
            if(drppagepos_vari.value=='0')
            {
                 make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+pagepost+"   value=\"\">";
            }
            else
            {
                 make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+pagepost+"   value='"+drppagepos_vari.value+"'>";
            }
                
            Make_Row.appendChild(make_td);
            
            
          
             
             ////////////this is to for larest date

            late="lat"+i;
            repeat="rep"+i;
            var dat="mm+"/"+"/"+dd+"/"+yyyy";
            make_td=document.createElement("td");
            make_td.align="center";
           // make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" id="+late+"  value=\"\" onkeydown=\"return nodateentry(event);\"  onchange=\"javascript:return checkdate(Form1."+late+");\" onkeypress=\"return dateenter();\"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+late+", Form1."+late+", "+dat+");\" height=\"14\" width=\"14\" />";
           make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" id="+late+"  value=''>";
            Make_Row.appendChild(make_td);

            make_td=document.createElement("td");
            make_td.align="center";
           //make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" id="+repeat+"  value=\"\" onkeydown=\"return nodateentry(event);\"  onchange=\"javascript:return checkdate(Form1."+repeat+");\" onkeypress=\"return dateenter();\"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+repeat+", Form1."+repeat+", "+dat+");\" height=\"14\" width=\"14\" />";
            make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" id="+repeat+"  value='' >";
            Make_Row.appendChild(make_td);

            namecode="one";
            
            premper="premper"+i;
            premper1="premperone"+i;
            adtypid="adtyp"+i;
            var namecode2="two";
            preall="preall"+i;
            adcat="adcat"+i;
            page="pgpre"+i;
            pageprem="pagper"+i;
            var h;
    ///this is to bind the page prem 2 drp down
            pagstr="sec" 
            make_td=document.createElement("td");
            make_td.align="center";            
            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+premid+" value=\"\">";
            Make_Row.appendChild(make_td);
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id="+premper+" value=\"\">";
            Make_Row.appendChild(make_td);
        //////////////this is to bind the drop down for accepting the premium
            make_td=document.createElement("td");
            make_td.align="center";
            str="<select id="+preall+" disabled class=\"dropdownforgrid\">";
            str=str+"<option value=\"0\">Select</option>";
            str=str+"<option value=\"1\">Yes</option>";
            str=str+"<option value=\"2\">No</option>";
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
            
            //to bind the ad category    
            make_td=document.createElement("td");
            make_td.align="center";
            if(adcat_vari.value!='0')
            {
                make_td.innerHTML="<input  class=\"dropdownforgrid\" type=\"text\" id="+adcat+" value='"+adcat_vari.value+"'>";
            }
            else
            {
                make_td.innerHTML="<input  class=\"dropdownforgrid\" type=\"text\" id="+adcat+" >";
            }    
            Make_Row.appendChild(make_td);  
            
            if(browser!="Microsoft Internet Explorer")
            {
                if(dbill=="")
                {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    dbill=dbill+"<select id="+billstat+" class=\"dropdownforgrid\">";
                 /////////////this function is to bind the bill status dropdown
                    var c=0;
                    for(c=1;c<=xmlObj.childNodes[3].childNodes.length-1;c=c+4)
                    {   
                        dbill=dbill+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";
                    }
                    dbill=dbill+"</select>";
                    make_td.innerHTML=dbill;
                    Make_Row.appendChild(make_td); 
                }
                else
                {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str=dbill.replace("bill"+dcou,billstat);  
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                }    
            }        
            else
            {        
                if(dbill=="")
                {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    dbill=dbill+"<select id="+billstat+" class=\"dropdownforgrid\">";
                    var c=0;
                    for(c=0;c<=xmlObj.childNodes(1).childNodes.length-1;c++)
                    {
                        dbill=dbill+"<option value="+xmlObj.childNodes(1).childNodes(c+1).text+">"+xmlObj.childNodes(1).childNodes(c).text+"</option>";
                        c=c+1;
                    }               
                  
                    dbill=dbill+"</select>";
                    make_td.innerHTML=dbill;
                    Make_Row.appendChild(make_td); 
                }
                else
                {           
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str=dbill.replace("bill"+dcou,billstat);  
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                }
            }
            
            paid="pai"+i;
            solo="sol"+i;
            gross="gro"+i;
            ///////////////this is to bind the drop down for paid/free insertion
            if(ds.Tables[9].Rows[0].Paid_permission=="0")
            {
                if(browser!="Microsoft Internet Explorer")
                {
                    if(dpaid=="")
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\" disabled>"; 
                        dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                        dpaid=dpaid+"<option value=\"N\">No</option>";
                        dpaid=dpaid+"</select>";
                        make_td.innerHTML=dpaid;
                        Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str=dpaid.replace("pai"+dcou,paid);    
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);                 
                    }
                }
                else
                {
                    if(dpaid=="")
                    {
                          make_td=document.createElement("td");
                          make_td.align="center";
                          dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\" disabled >";
                          dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                          dpaid=dpaid+"<option value=\"N\">No</option>";
                          dpaid=dpaid+"</select>";
                          make_td.innerHTML=dpaid;
                          Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str=dpaid.replace("pai"+dcou,paid);    
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);
                    }     
                }
            }
            else
            {
                if(browser!="Microsoft Internet Explorer")
                {
                    if(dpaid=="")
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\">";
                        dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                        dpaid=dpaid+"<option value=\"N\">No</option>";
                        dpaid=dpaid+"</select>";
                        make_td.innerHTML=dpaid;
                        Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str=dpaid.replace("pai"+dcou,paid);    
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);
                    }
                }
                else
                {                
                    if(dpaid=="")
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        dpaid=dpaid+"<select id="+paid+" class=\"dropdownforgridsmall\" >";
                        dpaid=dpaid+"<option value=\"Y\">Yes</option>";
                        dpaid=dpaid+"<option value=\"N\">No</option>";
                        dpaid=dpaid+"</select>";
                        make_td.innerHTML=dpaid;
                        Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str=dpaid.replace("pai"+dcou,paid);    
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);
                    }
                }
            }  
        
            billamt="ba"+i;
            billrate="br"+i;    
            str=str+"</select></td>";
            
            make_td=document.createElement("td");
            make_td.align="center";  
            make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+solo+"  value=\"\">";
            Make_Row.appendChild(make_td);

            //str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value=\"\"></td>";
            make_td=document.createElement("td");
            make_td.align="center";  
            make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value=\"\">";
            Make_Row.appendChild(make_td);     
             
           // str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billamt+"  value=\"\"></td>";
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+billamt+"  value=\"\">";
            Make_Row.appendChild(make_td);
            //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+billrate+"  value=\"\">";
            Make_Row.appendChild(make_td);
                     
                      showid="sho"+i;
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextforgrid\" style=\"display:none;\" type=\"text\" id="+showid+"  value='0'>";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                    
           pkgcodegrid='hiddenpckcode'+i;    
           make_td=document.createElement("td");
           make_td.align="center";
           make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkgcodegrid+"' value="+ds.Tables[0].Rows[s].EDITION_CODE+">";
           Make_Row.appendChild(make_td);
    
    
            //This below code for  puting the number of occurance of packages into grid
            var pkg_ins='pkg_ins'+i;
            for(var countpkg=0;countpkg<pkgcopy_vari.length;countpkg++)
            {
                var pkgcopy= pkgcopy_vari.options[countpkg].value;
                var arrpkgcopy=pkgcopy.split('@');
                var pkgcopycode=arrpkgcopy[0];
                var arr_pkg_ins_value=arrpkgcopy[1].split('(');
                var pkg_ins_value=arr_pkg_ins_value[1].replace(')','');
                if(pkgcopycode==ds.Tables[0].Rows[s].EDITION_CODE)
                {
                   // str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+pkg_ins_value+"></td>";
                    make_td=document.createElement("td");
                    make_td.align="center";
                    make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+pkg_ins_value+">";
                    Make_Row.appendChild(make_td);
                }
            }
         
            pkg_alias='pkg_alias'+i;    
            make_td=document.createElement("td");
            make_td.align="center";
            make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_alias+"' value='"+ds.Tables[0].Rows[s].PKGNAME+"'>";
            Make_Row.appendChild(make_td);            
   
            gridtab_vari.getElementsByTagName("tbody")[0].appendChild(Make_Row);
            idnew=parseInt(idnew)+1;                    
       
            i=parseInt(i)+1;   
           }   
     
    } //end of for    
    
    for ( i = count; i < gridtab_vari.getElementsByTagName("tbody")[0].rows.length-1; i++)
    { 
                
                 var height="hei"+i;
               var late="lat"+i;
               var repeat="rep"+i;
               var page="pagpos"+i;
               var pagstr="sec";
               var adcat="adcat"+i;
               var adsubcat="ads"+i;
               var premid="prem"+i;
                var id="Text" + i;
                var width="wid"+i;
                var  noofcol="nocol"+i;
                inserts="ins"+i;
                var insertval=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(i,10)+1].cells[1].innerHTML;
                var height_vari=document.getElementById(height);
                var par1=(height_vari.parentNode).parentNode;
                if(browser!="Microsoft Internet Explorer")
                    {
                   document.getElementById(height).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                document.getElementById(width).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                 document.getElementById(noofcol).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
            
                document.getElementById(late).onchange=new Function("return checkdate(Form1."+late+");");
                document.getElementById(repeat).onchange=new Function("return checkdate(Form1."+repeat+");");
               document.getElementById(page).onchange="return getpageprem('"+page+"',"+i+",'"+pagstr+"');" ;
               document.getElementById(id).onchange=new Function("return chkDateforGrid();");
               document.getElementById(premid).onchange=new Function("getpercenprem('"+premid+"',"+i+",'"+namecode+"')");
                    }
                    else
                    {
                par1.all[height].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                par1.all[width].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                 par1.all[noofcol].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
            
                par1.all[late].onchange=new Function("return checkdate(Form1."+late+");");
                par1.all[repeat].onchange=new Function("return checkdate(Form1."+repeat+");");
               par1.all[page].onchange="return getpageprem('"+page+"',"+i+",'"+pagstr+"');" ;
               par1.all[id].onchange=new Function("return chkDateforGrid();");
               par1.all[premid].onchange=new Function("getpercenprem('"+premid+"',"+i+",'"+namecode+"')");
               }
         if(repeatdate=="0" || repeatdate=="1")
        {  
            var id="Text" + temp;
            if(document.getElementById('Text'+temp)==null)
                return false;
            if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	        {
	            vvalue=caldatemonth[temp] + "/" + dateSelected + "/" + yearSelected;
	        }
	        else if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	        {
	            vvalue=dateSelected + "/" + caldatemonth[temp] + "/" + yearSelected;;
	        }
	        else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
	        {
	            vvalue=yearSelected + "/" + caldatemonth[temp] + "/" + dateSelected;;
	        }
	        
	        
	        if(dateSelected!=undefined && checkflag==1)
	        {
                document.getElementById('Text'+temp).value=vvalue;
            }
        }          
        temp=parseInt(temp)+1;    
   }
   checkflag="0";
   previnsertion=document.getElementById('txtinsertion').value;
   fillcopyfilename();
   return false;  
}


function insertLine()
{
            //////////////this code is to split the code as well as ites description   
    var objpack=document.getElementById('drppackagecopy');
    var temp="";
    var tempcode="";
    var tempval="";
    var tempvalcode="";
    var desc="";
    var code="";
    var i=objpack.options.length;
    var j;

    for(j=0;j<i;j++)
    {
        if(parseInt(i)>0)
        {
              tempval=objpack[j].value;
              //tempvalcode=objpack[j].value;
              if(temp!="")
              {
                  temp=tempval.split("@");
                  tempvalcode=temp[0];
                  tempcode=temp[1];
                  code=tempvalcode+","+code;
                  desc=tempcode+","+desc;
              }
              else
              {
                  temp=tempval.split("@");
                  tempvalcode=temp[0];
                  tempcode=temp[1];
                  code=tempvalcode;
                  desc=tempcode;
              }
        }
              
    }
    
    //////////////////////////////////////////////////////////////////
            
    var insert=document.getElementById('hiddeninserts').value;

    if(checkflag==1)
    {
        document.getElementById('txtinsertion').value=parseInt(document.getElementById('txtinsertion').value)+1;
        document.getElementById('txtpaid').value=document.getElementById('txtinsertion').value;
     }   
    var clientname=document.getElementById('txtclient').value;
    var client_split;
    if(clientname.indexOf("(")>=0)
    {
        clientname=clientname.split("(");
        client_split=clientname[1];
        client_split=client_split.replace(")","");
        clientname=client_split;

    }
        var adcat3=document.getElementById('drpadcat3').value;
        var adcat4=document.getElementById('drpadcat4').value;
        var adcat5=document.getElementById('drpadcat5').value;
    //Booking_Master_temp.getData(document.getElementById('drppackage').value,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,insertLine_callback);
     if(che_flag == 1)
     {
          desc=document.getElementById('hidval').value;
     }
    Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"DI0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,document.getElementById('drppageprem').value,clientname,adcat3,adcat4,adcat5,insertLine_callback);       
}

function checkValidation()
{
    var chmandat="";
      var adsize1_vari=document.getElementById('txtadsize1');
            var adsize2_vari=document.getElementById('txtadsize2');
    ////////////////THIS IS THE XML CREATED TO MAKE THE MANDATORY FROM XML
         var drpag_vari=document.getElementById('drpagscode');
        var agency_vari=document.getElementById('txtagency');
        var rostatus_vari=document.getElementById('drprostatus');
       var rono_vari=document.getElementById('txtrono');
       var rodate_vari=document.getElementById('txtrodate')
    if(browser!="Microsoft Internet Explorer")
    {
        loadXML('xml/bookingmaster.xml');
        /////////////////////////////////////////////////////
        chmandat=document.getElementById('lbagency').textContent;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
            if(agency_vari.value=="") 
            {
                 alert("Please Fill The Agency Code");
                 agency_vari.focus();
                 return false;   
            }
        }
        
        chmandat=document.getElementById('lbagescode').textContent;
        if(chmandat.indexOf('*')>= 0)
        {       
            if(drpag_vari.value=="" || drpag_vari.value=="0") 
            {
                alert("Please Fill Agency Sub Code");
                drpag_vari.focus();
                return false;   
            }
        }
          chmandat=document.getElementById('lbclient').textContent;
        if(chmandat.indexOf('*')>= 0)
        {       
            if(document.getElementById('txtclient').value=="" || document.getElementById('txtclient').value=="0") 
            {
                alert("Please Enter Client");
                document.getElementById('txtclient').focus();
                return false;   
            }
        }
        chmandat=rostatus_vari.textContent;
        if(chmandat.indexOf('*')>= 0)
        {       
            if(rostatus_vari.value=="0") 
            {
                alert("Please Fill ro status");
                rostatus_vari.focus();
                return false;   
            }
        }
    }
    else
    {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
        loadXML('xml/bookingmaster.xml');
        /////////////////////////////////////////////////////
        chmandat=document.getElementById('lbagency').innerText;
        if(chmandat.indexOf('*')>= 0)
        {
           if(agency_vari.value=="") 
           {
                alert("Please Fill The Agency Code");
                agency_vari.focus();
                return false;   
           }
        }
        chmandat=document.getElementById('lbagescode').innerText;
        if(chmandat.indexOf('*')>= 0)
        {       
            if(drpag_vari.value=="" || drpag_vari.value=="0") 
            {
                 alert("Please Fill Agency Sub Code");
                 drpag_vari.focus();
                 return false;   
            }
        }
          chmandat=document.getElementById('lbclient').innerText;
        if(chmandat.indexOf('*')>= 0)
        {       
            if(document.getElementById('txtclient').value=="" || document.getElementById('txtclient').value=="0") 
            {
                alert("Please Enter Client");
                document.getElementById('txtclient').focus();
                return false;   
            }
        }
        chmandat=rostatus_vari.innerText;
        if(chmandat.indexOf('*')>= 0)
        {       
            if(rostatus_vari.value=="0") 
            {
                 alert("Please Fill ro status");
                 rostatus_vari.focus();
                 return false;   
            }
        }
    }
      if(rostatus_vari.value=="2" && rono_vari.value=="")
    {
                alert("Please fill RO No");
              rono_vari.focus();
              return false;
    }
     if(rostatus_vari.value=="2" && rodate_vari.value=="")
    {
                alert("Please fill RO Date");
              rodate_vari.focus();
              return false;
    }
    if(rono_vari.value!="")
    {
        if(rodate_vari.value=="")
        {
            alert("Please fill RO date");
            rodate_vari.focus();
            return false;
        }
    }
    
     if(rodate_vari.value!="")
     {
          if(rono_vari.value=="")
          {
              alert("Please fill RO no");
              rono_vari.focus();
              return false;
          }
     }
    
    if(browser!="Microsoft Internet Explorer")
    {
        chmandat=document.getElementById('lbececname').textContent;
    }
    else
    {        
        chmandat=document.getElementById('lbececname').innerText;
    }
    if(chmandat.indexOf('*')>= 0)
    {
        if(document.getElementById('txtexecname').value=="" && (document.getElementById('drpretainer').value=="0" || document.getElementById('drpretainer').value==""))
        {
             alert('Please Enter '+(chmandat.replace('*', ""))+' or Select Retainer');
	         document.getElementById('txtexecname').focus();
	         return false;
        }
    }
    if(document.getElementById('txtexecname').value!="")
    {
        if(browser!="Microsoft Internet Explorer")
        {
             chmandat=document.getElementById('lbexeczone').textContent;
        }
        else
        {        
             chmandat=document.getElementById('lbexeczone').innerText;
        }
        if (chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtexeczone').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
	             document.getElementById('txtexeczone').focus();
	             return false;
            } 
        }   
    }
   if(document.getElementById('drpbooktype').value=="0")
{
    alert("Please Select Booking Type");
    return false;
}    
if(browser!="Microsoft Internet Explorer")
    {
        chmandat=document.getElementById('lbcolor').textContent;
    }
    else
    {        
        chmandat=document.getElementById('lbcolor').innerText;
    }
    if(chmandat.indexOf('*')>= 0)
    {
        if(document.getElementById('drpcolor').value=="0")
        {
               
             document.getElementById('divpopup').style.display="block";
		     document.getElementById('hidehref').innerHTML="Hide";
           //  changediv();
              alert('Please Enter Color');
	        // document.getElementById('drpcolor').focus();
	         return false;
        }
    }
if(document.getElementById('drpadcategory').value=="0")
{
    alert("Please Select Ad Category");
    return false;
}   

  var adcategory= document.getElementById('drpadcategory').value;
    if(adcategory!="0")
    {
              var res=Booking_Master_temp.getRegClientCheck(adcategory);
             if(res.value!=null)
             {
                if(res.value=="Y")
                {
                    if(document.getElementById('txtclient').value.lastIndexOf('(')<0)
                    {
                        alert("For Category "+document.getElementById('drpadcategory').options[document.getElementById('drpadcategory').selectedIndex].text + ", You can take only Registered Client");
                        document.getElementById('txtclient').focus();
                        return false;
                    }
                }
             }
       }   
                               
                               
 if(browser!="Microsoft Internet Explorer")
    {
        chmandat=document.getElementById('lbproduct').textContent;
    }
    else
    {        
        chmandat=document.getElementById('lbproduct').innerText;
    }       
    if(chmandat.indexOf('*')>= 0)
    {
         if(document.getElementById('txtproduct').value=="")
         {
              alert('Please Enter '+(chmandat.replace('*', "")));
              changediv();
	          document.getElementById('txtproduct').focus();
	          return false;
         }
    }
    
    if(browser!="Microsoft Internet Explorer")
    {
        chmandat=document.getElementById('lbbrand').textContent;
    }
    else
    {        
        chmandat=document.getElementById('lbbrand').innerText;
    }
    if(chmandat.indexOf('*')>= 0)
    {
        if(document.getElementById('drpbrand').value=="0")
        {
             alert('Please Enter '+(chmandat.replace('*', "")));
             changediv();
	         document.getElementById('drpbrand').focus();
	         return false;
        } 
    }
  if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbuom').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbuom').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpuom').value=="0")
            {
                 alert('Please Enter Uom');
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                
	             document.getElementById('drpuom').focus();
	             return false;
            }  
    
        }
 if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbcurrency').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbcurrency').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpcurrency').value=="0")
            {
                 alert('Please Enter Currency');
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changepackage();
	            document.getElementById('drpcurrency').focus();
	             return false;
            }  
    
        }
if(document.getElementById('drppackagecopy').options.length==0)
{
    alert("Please Select Package");
    return false;
}  
if(document.getElementById('txtdummydate').value=="")
{
    alert("Please Enter Date");
    return false;
} 
   
    
 
     if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbnoofins').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbnoofins').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtinsertion').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		        document.getElementById('hidehref').innerHTML="Hide";
                changepackage();
	            document.getElementById('txtinsertion').focus();
	            return false;
            }  
    
        }
       if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbpagepost').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbpagepost').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drppageposition').value=="0")
            {
                 alert('Please Enter Page Details');
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
            //     changediv1();
	             document.getElementById('drppageposition').focus();
	             return false;
            }  
    
        }
 
    if(document.getElementById('hiddenuomdesc').value=="CD")
    {
        if(adsize1_vari.value=="")
        {
             alert('Please enter height');
             document.getElementById('divpopup').style.display="block";
		     document.getElementById('hidehref').innerHTML="Hide";
             changediv1();
	         adsize1_vari.focus();
	         return false;
        }
        if(adsize1_vari.value!="")
        {
            if(adsize2_vari.value=="" && document.getElementById('txtcolum').value=="")
            {
                 alert('Please enter width');
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changediv1();
	             adsize1_vari.focus();
	             return false;            
            }
        }
    }
    else 
    {
          if(document.getElementById('txttotalarea').value=="")
          {
               alert('Please Enter Number of lines');
               document.getElementById('divpopup').style.display="block";
		       document.getElementById('hidehref').innerHTML="Hide";
               changediv1();
	           //document.getElementById('txtadsize1').focus();
	           return false;
          }        
    }
    
    
        if(document.getElementById('txtadsize1').disabled==true)
        {
              if(document.getElementById('txttotalarea').value=="")
              {
                   alert('Please Enter Number of lines');
                   document.getElementById('divpopup').style.display="block";
		           document.getElementById('hidehref').innerHTML="Hide";
                   changediv1();
	               adsize1_vari.focus();
	               return false;
              }  
        }
    
      
    
       if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbscheme').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbscheme').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpscheme').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changedivrate();
	             document.getElementById('drpscheme').focus();
	             return false;
            }  
    
        }
            if(document.getElementById('txtratecode').value=="0")
            {
                 changedivrate();
                 alert("Please Enter Rate Code");
	             document.getElementById('txtratecode').focus();
	             return false;
            }  
             if(document.getElementById('txtgrossamt').value=="")
            {
                 changedivrate();
                  alert("Please Enter Gross Amount");
                  if(document.getElementById('txtgrossamt').disabled==false)
	             document.getElementById('txtgrossamt').focus();
	             return false;
            }  
    
      
    
      
    
     

     
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblcardamt').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblcardamt').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtcardamt').value=="")
            {
                alert('Please Enter '+(chmandat.replace('*', "")));
	             //document.getElementById('drppackage').focus();
	            return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbagreed').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbagreed').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtagreedrate').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changedivrate();
	             document.getElementById('txtagreedrate').focus();
	             return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbagreamo').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbagreamo').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtagreedamt').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changedivrate();
	             document.getElementById('txtagreedamt').focus();
	             return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbldiscount').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbldiscount').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtdiscount').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changedivrate();
	             document.getElementById('txtdiscount').focus();
	             return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbldiscpre').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbldiscpre').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtdiscpre').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changedivrate();
	             document.getElementById('txtdiscpre').focus();
	             return false;
            }  
    
        }
    
    
    
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblbillcycle').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblbillcycle').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpbillcycle').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('drpbillcycle').focus();
	             return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblrevenuecenter').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblrevenuecenter').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
           if(document.getElementById('drprevenue').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 changebilldiv();
	             document.getElementById('drprevenue').focus();
	            return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblpaymenttype').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblpaymenttype').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drppaymenttype').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 changebilldiv();
	             document.getElementById('drppaymenttype').focus();
	            return false;
            }  
          
    
        }
       //check info
            if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0"   || document.getElementById('drppaymenttype').value=='PO0')
            {
                if(document.getElementById('ttextchqno').value == "" || document.getElementById('ttextchqdate').value == "" || document.getElementById('ttextchqamt').value == "" || document.getElementById('ttextbankname').value == "")
                {
                    alert('Please fill all fields of Cheque/DD.');
                    document.getElementById('ttextchqno').focus;
                    return false; 
                }
            }
            else if(document.getElementById('drppaymenttype').value=="CR0")
            {
                if(document.getElementById('txtcardname').value!="" || document.getElementById('drptype').value!="0" || document.getElementById('drpmonth').value!="0" || document.getElementById('drpyear').value!="0" || document.getElementById('txtcardno').value!="")
                {
                    alert('Please fill all fields of Credit Card.');
                    document.getElementById('txtcardname').focus;
                    return false; 
                }
            }    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbbillstatus').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbbillstatus').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpbillstatus').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('drpbillstatus').focus();
	             return false;
            }  
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblbillsize').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblbillsize').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtbillwidth').value=="" || document.getElementById('txtbillheight').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 changebilldiv();
	             document.getElementById('txtbillwidth').focus();
	             return false;
            }  
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblbillto').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblbillto').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpbillto').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('drpbillto').focus();
	             return false;
            }  
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblinvoice').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblinvoice').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtinvoice').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('txtinvoice').focus();
	             return false;
             }
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblvts').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblvts').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtvts').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('txtvts').focus();
	             return false;
            }
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblbilladdress').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblbilladdress').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtbilladdress').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 changebilldiv();
	             document.getElementById('txtbilladdress').focus();
	             return false;
            }
    }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbltradedisc').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbltradedisc').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txttradedisc').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('txttradedisc').focus();
	             return false;
             }
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbbillamt').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbbillamt').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtbillamt').value=="" || document.getElementById('txtbillamt').value=="0")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 changebilldiv();
	             //document.getElementById('drppackage').focus();
	             return false;
            }
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lblagencyoutstand').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lblagencyoutstand').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtagencyoutstand').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 document.getElementById('divpopup').style.display="block";
		         document.getElementById('hidehref').innerHTML="Hide";
                 changebilldiv();
	             document.getElementById('txtagencyoutstand').focus();
	             return false;
            }  
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbboxcode').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbboxcode').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('drpboxcode').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 openboxpopup();
	             document.getElementById('drpboxcode').focus();
	             return false;
            }  
    
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbboxno').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbboxno').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtboxno').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 openboxpopup();
	             document.getElementById('txtboxno').focus();
	             return false;
            } 
        }
    
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbboxadd').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbboxadd').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtboxaddress').value=="")
            {
                 alert('Please Enter '+(chmandat.replace('*', "")));
                 openboxpopup();
	             document.getElementById('txtboxaddress').focus();
	             return false;
            } 
        }
    
       
    
    
    ////////////////////////////this is to chk that agency code,agency sub code and ro no should be unique if they are not
    ////////than dont allow booking hiddensavemod
   if(document.getElementById('txtrono').value!="" && document.getElementById('hiddensavemod').value!="01")
    {
        var rono=document.getElementById('txtrono').value;
        var cioid=document.getElementById('txtciobookid').value;
        var agencycode=document.getElementById('hiddenagency').value;
        var agencyscode=document.getElementById('hiddensubcode').value;
        var savemod=document.getElementById('hiddensavemod').value
        var compcode=document.getElementById('hiddencompcode').value
        var keyno=document.getElementById('txtkeyno').value;
        var val1="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","chkuniqueforbook.aspx?keyno="+keyno+"&rono="+rono+"&cioid="+cioid+"&agencycode="+agencyscode+"&agencyscode="+agencycode+"&savemod="+savemod+"&compcode="+compcode, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    val1=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","chkuniqueforbook.aspx?keyno="+keyno+"&rono="+rono+"&cioid="+cioid+"&agencycode="+agencyscode+"&agencyscode="+agencycode+"&savemod="+savemod+"&compcode="+compcode, false );
            xml.Send();
            val1=xml.responseText;
        }
            if(val1=="0")
            {
                alert("The Agency Code,Agency Sub Code and Ro no. should be unique");
                return false;
            }
             if(val1=="1")
            {
                alert("The Agency Code,Agency Sub Code and Key No. is not unique");
              //  return false;
            }
    }
    
    if(document.getElementById('txtgrossamt').value=="")
    {
        alert("Please get the original rate ");
        return false;
    }
     /////////////////////////this check is used to check from the main values that this pck exists or not
       
      
        var val="";
     //////////////////////////////////////////////////////////////////////////////////////////////////////
          
     
            if(document.getElementById('tblinsert').innerHTML=="")
            {
                alert("Please Fill the grid");
                return false;
            }
            ////////////////this is to chk the mandatory field of grid whether they are selected or fill or not
             var len="bookdiv";
             var id; 
             var height;
             var width;
             var pagepost;
             var matsta;
             var insertsta;
             var editdate;
             var size;
             var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
             savtotid=totid
             var y;
            
                 y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
             var cardid;
             var editid;
             //var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
             var i;
             var k=0;
             var i=0;
             var adsize1_vari=document.getElementById('txtadsize1');
            var adsize2_vari=document.getElementById('txtadsize2');
             for(k=0;k<y-1;k++)
             {             

                id=document.getElementById("Text" + i);
                var par1=(id.parentNode).parentNode;
                if(browser!="Microsoft Internet Explorer")
                    {
                    height=document.getElementById("hei"+i);
                width=document.getElementById("wid"+i);
                pagepost= document.getElementById("pgpre"+i); //"pagpos"+i;
                matsta=document.getElementById("mat"+i);
                insertsta=document.getElementById("inssta"+i);
                cardid=document.getElementById("card"+i);
                editid=document.getElementById("edit"+i);
                editdate=document.getElementById("Text" + i);
               size=document.getElementById("siz"+i);
                var adcat=document.getElementById("adcat"+i);
                var col=document.getElementById("col"+i);
                    }
                    else
                    {
                height=par1.all["hei"+i];
                width=par1.all["wid"+i];
                pagepost= par1.all["pgpre"+i]; //"pagpos"+i;
                matsta=par1.all["mat"+i];
                insertsta=par1.all["inssta"+i];
                cardid=par1.all["card"+i];
                editid=par1.all["edit"+i];
                editdate=par1.all["Text" + i];
               size=par1.all["siz"+i];
                var adcat=par1.all["adcat"+i];
                var col=par1.all["col"+i];
                }
                if(id.value=="")
                {
                    alert("Please Fill the insertion date");
                    id.focus();
                    return false;
                }
                 else if(cardid.value=="" )
                {
                    alert("Please get the card rate");
                    
                    return false;
                    
                }
                else if(insertsta.value=="" || insertsta.value=="0")
                {
                    alert("Please select insertion status");
                    insertsta.focus();
                    return false;
                    
                }
                  
                 else if(col.value=="" || col.value=="0")
                {
                    alert("Please Enter Color");
                    col.focus();
                    return false;
                }  
                else if(adcat!=null && (adcat.value=="" || adcat.value=="0"))
                {
                    alert("Please select Ad Category");
                    adcat.focus();
                    
                    return false;
                }
                else if(height.value=="")
                {
                    if(adsize1_vari.disabled==false)
                    {
                        alert("Please fill height into grid");
                        height.focus();
                        return false;
                    }
                
                }
                else if(width.value=="")
                {
                    if(adsize2_vari.disabled==false)
                    {    
                        alert("Please fill width into grid");
                        width.focus();
                        return false;
                    }
                } 
                else if(size.value=="")
                {
                     if(adsize2_vari.disabled==true)
                     {    
                          alert("Please fill size into grid");
                          width.focus();
                          return false;
                      }
                } 
            i=i+1; 
          }            
          //*25Aug*
           if(document.getElementById('txtagencypaymode').value=="CA0" || (document.getElementById('txtagencypaymode').value=="CR1" && document.getElementById('creditreceipt_allow').value=="Y")) // for credit 
          {
            if(confirm("Do You Want To Print The Receipt"))
             {
                if(document.getElementById('txtclient').value=="")
                   {
                       alert("Please Fill the Client Name");
                       document.getElementById('txtclient').focus();
                       return false;
                   }
                   
                  if(document.getElementById('txtagencypaymode').value=="")
                  {
                    alert("Please Agency pay mode.");
                    return false;
                  } 
                   if(document.getElementById('txtagencypaymode').selectedIndex!=-1)
                   document.getElementById('hiddenpaymode').value=document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').selectedIndex].text;
                   document.getElementById('hiddenprint_rec').value="Y";
             }
             else
             {
                   document.getElementById('hiddenprint_rec').value="";
             }
            }
             document.getElementById('hiddenratecode').value=document.getElementById('txtratecode').value
             //***************
             saveClick();
             return false;
}


function disabledokit()
{
    if(trim(document.getElementById('txtrono').value)!="")
    {
        document.getElementById('txtdockitno1').value="";
        document.getElementById('drprostatus').value="1";
        document.getElementById('txtdockitno1').disabled=true;
    
    }
    else
    {
    document.getElementById('txtdockitno1').disabled=false;
    
    }

}

function disablerono()
{
    if(document.getElementById('txtdockitno1').value!="")
    {
        document.getElementById('txtrono').value="";
        document.getElementById('txtrono').disabled=true;
    
    }
    else
    {
        document.getElementById('txtrono').disabled=false;    
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
    if(event.keyCode==113) 
        event.keyCode= 81;
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

function getPremPageIns_callBack(res)
{
    var len="bookdiv";
    var ds=res.value;
    if(ds!=null)
    {
         if(ds.Tables[0].Rows.length>0)
         {
            var p_no="pagno"+ds.Tables[0].Rows[0].id;
            document.getElementById(p_no).value=ds.Tables[0].Rows[0].page_no;
         }  
    }     
}

/////////////this function is to get the percentage when on selected change of premium dropdown
function getpercenprem(premid,id,name)
{
 /////////////////this is the function which is to chk whether premium pkg rate is there if it exists than
 //////////////do not add the premium and if it is not than add
    var p_no="pagno"+id;
    if(document.getElementById('tblinsert').innerHTML!="")
    {
         Booking_Master_temp.getPremPage(document.getElementById(premid.id).value,id,getPremPageIns_callBack);
    }
    if(document.getElementById('txtgrossamt').value=="")
    {
        alert("Please get the gross amount");
        return false;
    }
 
 //////////////this code is to split the code as well as ites description 
    
        var adtype="DI0";
        var color = document.getElementById('drpcolor').value;
        var adcat = document.getElementById('drpadcategory').value;
        var adsucat = document.getElementById('drpadsubcategory').value;
        var currency = document.getElementById('drpcurrency').value;
        var ratecode = document.getElementById('txtratecode').value;
        var package1 = document.getElementById('drppackage').value;
        var prem_insert=document.getElementById('drppageprem').value;
        var uomvalue=document.getElementById('drpuom').value;        
        var prem_insert;                
        var valforpkg="";        
        if(browser!="Microsoft Internet Explorer")
        {
             var  httpRequest =null;;
             httpRequest= new XMLHttpRequest();
             if (httpRequest.overrideMimeType) 
             {
                httpRequest.overrideMimeType('text/xml'); 
             }
                
             httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

             httpRequest.open( "GET","chkpkgrate.aspx?adtype="+adtype+"&color="+color+"&adcat="+adcat+"&adsucat="+adsucat+"&currency="+currency+"&ratecode="+ratecode+"&package1="+global_code+"&uomvalue="+uomvalue+"&prem_insert="+document.getElementById('drppageprem').value, false );
             httpRequest.send('');
             if (httpRequest.readyState == 4) 
             {
                 if (httpRequest.status == 200) 
                 {
                       valforpkg=httpRequest.responseText;
                 }
                 else 
                 {
                      alert('There was a problem with the request.');
                 }
             }
        }
        else
        {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");                
            xml.Open( "GET","chkpkgrate.aspx?adtype="+adtype+"&color="+color+"&adcat="+adcat+"&adsucat="+adsucat+"&currency="+currency+"&ratecode="+ratecode+"&package1="+global_code+"&uomvalue="+uomvalue+"&prem_insert="+document.getElementById(premid.id).value ,false );
            xml.Send();
            valforpkg=xml.responseText; 
        }
 
        if(valforpkg!="1")
        {
            premid=premid.id;

            ///////////this page is created to get the value of selected premium
            var page=document.getElementById(premid).value;          
            var val="";        
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) 
                {
                    httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","getpremium.aspx?page="+page, false );
                httpRequest.send('');                
                if (httpRequest.readyState == 4) 
                {
                    if (httpRequest.status == 200) 
                    {
                        val=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                 var xml = new ActiveXObject("Microsoft.XMLHTTP");
                 xml.Open( "GET","getpremium.aspx?page="+page, false );
                 xml.Send();
                 val=xml.responseText;
            }
             val=val.split("^");
             val=val[0];
             var premper="premper"+id;
             var premper1="premperone"+id;
             var cardid="card"+id;
             var solo="sol"+id;
             var agrred="agr"+id;
             var discrate="disrat"+id;
             var gross="gro"+id;
             var size="siz"+id;
             /////////////////////////////////
             var pageprem="pagper"+id;
             var premperfirst="premper"+id;
             var premsec="premperone"+id;
             //////////////////////////////////
             if(document.getElementById(cardid).value=="")
             {
                alert("Please get the card rate");
                return false;             
             }
             
             if(name=="one")
             {
                document.getElementById(premper).value=val;
              
                    //when we change the premium than card effects automatically only when card rate and agreed are equal
                 if(parseFloat(document.getElementById('txtcardrate').value)==parseFloat(document.getElementById('txtagreedrate').value))
                 {             
                        if(document.getElementById('hiddenpremtype').value=="per")
                        { 
                            var grossamt=parseFloat(document.getElementById(cardid).value)*parseFloat(document.getElementById(size).value);
                            if(document.getElementById(pageprem).value=="")
                            {
                                document.getElementById(pageprem).value="0";
                            }
                            if(document.getElementById(premsec).value=="")
                            {
                                document.getElementById(premsec).value="0";
                            }
                            var valper=parseFloat(document.getElementById(premper).value)+parseFloat(document.getElementById(pageprem).value)+parseFloat(document.getElementById(premsec).value);
                            var gramt=parseFloat(grossamt)+(parseFloat(grossamt)*parseFloat(valper)/100);
                            document.getElementById(gross).value=gramt.toFixed(2);                                    
                        }
                        else
                        {
                            var grossamt=parseFloat(document.getElementById(cardid).value)*parseFloat(document.getElementById(size).value);
                            if(document.getElementById(pageprem).value=="")
                            {
                                document.getElementById(pageprem).value="0";
                            }
                            if(document.getElementById(premsec).value=="")
                            {
                                document.getElementById(premsec).value="0";
                            }
                            var valper=parseFloat(document.getElementById(premper).value)+parseFloat(document.getElementById(pageprem).value)+parseFloat( document.getElementById(premsec).value);
                            document.getElementById(gross).value=(parseFloat(grossamt)+parseFloat(valper)).toFixed(2);
                                                            
                        }
                    }
                    else
                    {
                             //document.getElementById(agrred).value=document.getElementById('txtagreedrate').value;                    
                    }                    
             }
             else
             {
                 document.getElementById(premper1).value=val;                 
                 if(parseFloat(document.getElementById('txtcardrate').value)==parseFloat(document.getElementById('txtagreedrate').value))
                 {
                      if(document.getElementById('hiddenpremtype').value=="per")
                      {
                            var grossamt=parseFloat(document.getElementById(cardid).value)*parseFloat(document.getElementById(size).value);
                            if(document.getElementById(pageprem).value=="")
                            {
                                document.getElementById(pageprem).value="0";
                            }
                            if(document.getElementById(premperfirst).value=="")
                            {
                                document.getElementById(premperfirst).value="0";
                            }
                            var valper=parseFloat(document.getElementById(premper1).value)+parseFloat(document.getElementById(pageprem).value)+parseFloat(document.getElementById(premperfirst).value);
                            var gramt=parseFloat(grossamt)+(parseFloat(grossamt)*parseFloat(valper)/100);
                            document.getElementById(gross).value=gramt.toFixed(2);                        
                        }
                        else
                        {
                            var grossamt=parseFloat(document.getElementById(cardid).value)*parseFloat(document.getElementById(size).value);
                            if(document.getElementById(pageprem).value=="")
                            {
                                document.getElementById(pageprem).value="0";
                            }
                            if(document.getElementById(premperfirst).value=="")
                            {
                                document.getElementById(premperfirst).value="0";
                            }
                            var valper=parseFloat(document.getElementById(premper1).value)+parseFloat(document.getElementById(pageprem).value)+parseFloat(document.getElementById(premperfirst).value);
                            document.getElementById(gross).value=(parseFloat(grossamt)+parseFloat(valper)).toFixed(2);                                                   
                        }                      
                    }
                    else
                    {                    
                    
                    }
                     
             }
             
             if(noofinsert!="")
             {                 
                  y=parseInt(noofinsert)   
                  totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
             }
             else
             {
                  y=rowwhenupdate;
                  totid=parseInt(rowwhenupdate)/parseInt(document.getElementById('txtinsertion').value)
             }
                
             for(k=0;k<y;k++)
             {
                 while(document.getElementById("card"+i)==null)
                 {
                      i=i+totid;
                 }
                 var gross1="gro"+i;
                 totor=parseFloat(totor)+parseFloat(document.getElementById(gross1).value);
                 i=i+1;
             }
                       
             var grossamt;
             if(document.getElementById('hiddenvat').value=="grossamount")
             {
                var strtext="";        
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) 
                    {
                        httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                    httpRequest.open( "GET","getvatrate.aspx?grossamt="+totor, false );
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) 
                    {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) 
                        {
                            strtext=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                {
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
                
                    xml.Open( "GET","getvatrate.aspx?grossamt="+totor, false );
                    xml.Send();
                    strtext=xml.responseText;   
                }
                document.getElementById('txtgrossamt').value=formatDecimal(parseFloat(strtext),true,2)
                var trdisc=document.getElementById('txttradedisc').value
                if(trdisc=="")
                    trdisc=0;
                var trdisc1=trdisc;
                addcomm =0;
                if(document.getElementById('txtaddagencycommrate')!=null) 
                {
                    addcomm=document.getElementById('txtaddagencycommrate').value;
                }
                if(addcomm=="")
                {
                    addcomm="0";
                }
                if(addcomm!="0")
                {
                    trdisc1=parseInt(trdisc) + parseInt(addcomm);
                }
                 var billval=0;
                if(document.getElementById('agncomm_seq_com').value!="S")
                     billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc1)/100);
                else
                {
                     billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc)/100);    
                    if(addcomm!="0" && addcomm!="")
                    {
                         billval=parseFloat(billval)-(parseFloat(billval)*parseFloat(addcomm)/100);    
                    }
                }      
                document.getElementById('txtbillamt').value=formatDecimal(billval,true,2);
                totor=0;
            }
         else if(document.getElementById('hiddenvat').value=="netamount")
         {
                document.getElementById('txtgrossamt').value=formatDecimal(parseFloat(totor),true,2)
                 var trdisc=document.getElementById('txttradedisc').value
                if(trdisc=="")
                    trdisc=0;
                var trdisc1=trdisc;
                addcomm =0;
                if(document.getElementById('txtaddagencycommrate')!=null) 
                {
                    addcomm=document.getElementById('txtaddagencycommrate').value;
                }
                if(addcomm=="")
                {
                    addcomm="0";
                }
                if(addcomm!="0")
                {
                    trdisc1=parseInt(trdisc) + parseInt(addcomm);
                }
                 var billval=0;
                if(document.getElementById('agncomm_seq_com').value!="S")
                     billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc1)/100);
                else
                {
                     billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc)/100);    
                    if(addcomm!="0" && addcomm!="")
                    {
                         billval=parseFloat(billval)-(parseFloat(billval)*parseFloat(addcomm)/100);    
                    }
                }                           
                var strtext="";        
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) 
                    {
                        httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                    httpRequest.open( "GET","getvatrate.aspx?grossamt="+billval, false );
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) 
                    {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) 
                        {
                            strtext=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                {
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
                    xml.Open( "GET","getvatrate.aspx?grossamt="+billval, false );
                    xml.Send();
                    strtext=xml.responseText;   
                }
                            
                document.getElementById('txtbillamt').value=formatDecimal(strtext,true,2);
                totor=0;
                     
             }
             else if(document.getElementById('hiddenvat').value=="no")
             {
                  document.getElementById('txtgrossamt').value=formatDecimal(parseFloat(totor),true,2)
                 var trdisc=document.getElementById('txttradedisc').value
                if(trdisc=="")
                    trdisc=0;
                var trdisc1=trdisc;
                addcomm =0;
                if(document.getElementById('txtaddagencycommrate')!=null) 
                {
                    addcomm=document.getElementById('txtaddagencycommrate').value;
                }
                if(addcomm=="")
                {
                    addcomm="0";
                }
                if(addcomm!="0")
                {
                    trdisc1=parseInt(trdisc) + parseInt(addcomm);
                }
                 var billval=0;
                if(document.getElementById('agncomm_seq_com').value!="S")
                     billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc1)/100);
                else
                {
                     billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc)/100);    
                    if(addcomm!="0" && addcomm!="")
                    {
                         billval=parseFloat(billval)-(parseFloat(billval)*parseFloat(addcomm)/100);    
                    }
                }           
                    document.getElementById('txtbillamt').value=formatDecimal(totor,true,2);
                    totor=0;
             
             }
         }
  }
            //////this function is to get the total size on change of grids width textbox
function gettotalsize(h,w,id,ins,insval,c)
{
    document.getElementById('txtgrossamt').value="";
    var cardid="card"+id;

    if(document.getElementById(cardid).value=="")
    {
        alert("Please get the card rate in the insertion grid");
        changedivrate();
        document.getElementById('btnshgrid').focus();
        return false;
    }

    //h=h.id;

    if(document.getElementById(h).value=="")
    {
        alert("Please Enter the height");
        document.getElementById(h).focus();
        return false;
    }

   // w=w.id;
   // c=c.id;

    var height=document.getElementById(h).value;
    var width=document.getElementById(w).value;
    var column=document.getElementById(c).value;

    var size="siz"+id;
    var filename="fil"+id;
    if(document.getElementById(filename)!=null)
        document.getElementById(filename).value="";
    if(column=="" || column=="NaN")
    {
        document.getElementById(size).value=parseFloat(height)*parseFloat(width);
    }
    else
    {
        document.getElementById(size).value=parseFloat(height)*parseFloat(column);
    }
//getgrossamt(w,ins,insval);

//             agreed="agr"+id;
//             gross="gro"+id;
//             totarea="siz"+id;
//             solo="sol"+id;
//                        //var totgross=parseFloat(document.getElementById(totarea).value)*parseFloat(document.getElementById(agreed).value)
//                        //document.getElementById(gross).value=totgross.toFixed(2);
//            if(document.getElementById('txtcardrate').value==document.getElementById('txtagreedrate').value)
//            {
//                 var soagr=document.getElementById(solo).value;
//                      //document.getElementById(gross).value=(parseFloat(agr)*parseFloat(totsiz)).toFixed(2);
//                 var totareawithrate=parseFloat(soagr)*parseFloat(document.getElementById(totarea).value)
//                 var totamt=parseFloat(totareawithrate)+parseFloat(glpre)-parseFloat(glspedisc)-parseFloat(glspadisc)+parseFloat(glspeccharge)
//                 document.getElementById(gross).value=(parseFloat(totamt)).toFixed(2);
//             }
//             else
//             {
//                 var totgross=parseFloat(document.getElementById(totarea).value)*parseFloat(document.getElementById(agreed).value)
//                 document.getElementById(gross).value=totgross.toFixed(2);
//             }
//            var y;
//            var totid;
//            if(noofinsert!="")
//            {                 
//                  y=parseInt(noofinsert)   
//                  totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
//            }
//            else
//            {
//                y=rowwhenupdate;
//                totid=parseInt(rowwhenupdate)/parseInt(document.getElementById('txtinsertion').value)
//            }
//                
//                 var k;
//                 var adgross
//                 var totgross;   
//                 var paid;
//                 var grossamt="";
//                 for(k=0;k<y;k++)
//                    {
//                         
//                            while(document.getElementById("card"+i)==null && i<y)
//                            {
//                                i=i+totid;
//               
//                            }
//                            
//                               if(i>=y)
//                                 {
//                                 break;
//                                 }
//                            
//                            adgross="gro"+i;
//                            paid="pai"+i;
//                            
//                            totgross=document.getElementById(adgross).value 
//                        if(document.getElementById(paid).value=="Y") 
//                        {
//                            if(grossamt!="")
//                            {
//                            grossamt=parseFloat(totgross)+parseFloat(grossamt);
//                            }
//                            else
//                            {
//                            grossamt=parseFloat(totgross);
//                            }
//                            
//                        }
//                        i=parseInt(i)+1;   
//                    }
//                    if(grossamt!="")
//                 {
//                    document.getElementById('txtgrossamt').value=grossamt.toFixed(2);
//                    var trdisc = document.getElementById('txttradedisc').value;
//                    var trdisc1=trdisc;
//                    addcomm =0;
//                    if(document.getElementById('txtaddagencycommrate')!=null)
//                    {
//                         addcomm=document.getElementById('txtaddagencycommrate').value;
//                    }
//                    if(addcomm=="")
//                    {
//                          addcomm="0";
//                    }
//                    if(addcomm!="0")
//                    {
//                          trdisc1=parseInt(trdisc) + parseInt(addcomm);
//                    }
//                            
//                    document.getElementById('txtbillamt').value=parseFloat(grossamt)-parseFloat(grossamt)*parseFloat(trdisc1)/100;
//                 }
//                 if(document.getElementById('txtgrossamt').value=="NaN")
//                 {
//                    document.getElementById('txtgrossamt').value="";
//                 
//                 }
//                 if(document.getElementById('txtbillamt').value=="NaN")
//                 {
//                    document.getElementById('txtbillamt').value="";                 
//                 }


}

function callcal(b,c)
{

}

function getcardamou()
{
    var totaladarea=parseFloat(document.getElementById('txttotalarea').value);
    var cardrate=parseFloat(document.getElementById('txtcardrate').value);
    var tot=totaladarea*cardrate;
    document.getElementById('txtcardamt').value=tot.tofixed(2);

}

function chkheight()
{
document.getElementById('txtgrossamt').value='';
    if(document.getElementById('drppackagecopy').options.length==0)
    {
        alert("Please select the package");
       // document.getElementById('drppackage').focus();
        return false;
        
    }

    if(document.getElementById('drpuom').value=="0")
    {
        alert("Please select uom");
        document.getElementById('txtadsize1').value=""
        document.getElementById('txtadsize2').value=""
       // document.getElementById('drpuom').focus();
        return false;        
    }
    var value=chkamount('txtadsize1');
    if(value=="f")
    {
        return false;
    }
        
    if(parseFloat(document.getElementById('txtadsize1').value)==0)
    {
        alert("0 is not accepted");
        var idrem=document.activeElement.id;
        return false;
    }
 
    var objpack=document.getElementById('drppackagecopy');
    var temp="";
    var tempcode="";
    var tempval="";
    var tempvalcode="";
    var desc="";
    var code="";
    var codesplit="";
    var i=objpack.options.length;
    var j;

    for(j=0;j<i;j++)
    {
        if(parseInt(i)>0)
        {
            tempval=objpack[j].value;
            //tempvalcode=objpack[j].value;
            if(temp!="")
            {
                temp=tempval.split("@");
                tempvalcode=temp[0];
                tempcode=temp[1];
                desc=tempcode+"+"+desc;
            }
            else
            {
                temp=tempval.split("@");
                tempvalcode=temp[0];
                tempcode=temp[1];
                desc=tempcode;
                
            }
        }
    
    }
                                
    Booking_Master_temp.getwidthforcoll(desc,document.getElementById('txtcolum').value,document.getElementById('hiddencompcode').value,call_chkheight);

}

function call_chkheight(res)
{
    var ds=res.value;
    var ds=res.value;
    if(ds.Tables[1].Rows.length>0)
    {
         var height_=document.getElementById('txtadsize1').value;
         var ds_height=ds.Tables[1].Rows[0].size_height;
         if(parseFloat(height_)>parseFloat(ds_height))
         {
                alert("Height exceeds with edition total height");
                document.getElementById('txtadsize1').value="";
                document.getElementById('txtadsize1').focus();
                return false;
         }  
         if(ds.Tables[1].Rows.length>0)
         {
                glob_area=ds.Tables[1].Rows[0].edition_area;
         }  
        
    }
        
    if(document.getElementById('txtadsize1').value!="" && document.getElementById('txtadsize2').value!="")
    {
            var h_=document.getElementById('txtadsize1').value;
            var w_=document.getElementById('txtadsize2').value;
            document.getElementById('txttotalarea').value=formatDecimal(parseFloat(h_)*parseFloat(w_),true,2);
            document.getElementById('txtbillwidth').value=h_;
            document.getElementById('txtbillheight').value=w_;            
    }
    else if(document.getElementById('txtadsize1').value!="" && document.getElementById('txttotalarea').value!="")
    {
         var h_=document.getElementById('txtadsize1').value;
         var area_=document.getElementById('txttotalarea').value;
         document.getElementById('txtadsize2').value=formatDecimal(parseFloat(area_)/parseFloat(h_),true,2);
         document.getElementById('txtbillwidth').value=h_;
         document.getElementById('txtbillheight').value=document.getElementById('txtadsize2').value;
    }        
       
    if( document.getElementById('tblinsert').innerHTML!="" && document.getElementById('txtadsize2').value!="")
    {    
        var hei=document.getElementById('txtbillheight').value
        if(document.getElementById('txtbillheight').value=="NaN")
        {
            hei="";
        }
        var wid=document.getElementById('txtbillwidth').value   
        if(document.getElementById('txtbillwidth').value=="NaN")
        {
            wid="";
        }     
        getpageareaintogrid(hei,wid);
    }    

}

function chkwidth()
{
document.getElementById('txtgrossamt').value='';
    if(document.getElementById('drppackagecopy').options.length==0)
    {
         alert("Please select the package");
         return false;
    }
    if(document.getElementById('drpuom').value=="0")
    {
         alert("Please select uom");
         document.getElementById('txtadsize1').value=""
         document.getElementById('txtadsize2').value=""
         document.getElementById('drpuom').focus();
         return false;
    }
    var value=chkamount('txtadsize2');
    if(value=="f")
    {
        return false;
    }

    if(parseFloat(document.getElementById('txtadsize2').value)==0 )
    {
        alert("0 is not accepted");
        var idrem=document.activeElement.id;                
        return false;
    }
    var objpack=document.getElementById('drppackagecopy');
    var temp="";
    var tempcode="";
    var tempval="";
    var tempvalcode="";
    var desc="";
    var code="";
    var codesplit="";
    var i=objpack.options.length;
    var j;

    for(j=0;j<i;j++)
    {
        if(parseInt(i)>0)
        {
            tempval=objpack[j].value;
            //tempvalcode=objpack[j].value;
            if(temp!="")
            {
                temp=tempval.split("@");
                tempvalcode=temp[0];
                tempcode=temp[1];
                desc=tempcode+"+"+desc;
            }
            else
            {
                temp=tempval.split("@");
                tempvalcode=temp[0];
                tempcode=temp[1];
                desc=tempcode;
                
            }
        }
    
    }
                                
   Booking_Master_temp.getwidthforcoll(desc,document.getElementById('txtcolum').value,document.getElementById('hiddencompcode').value,call_chkwidth);

}

function call_chkwidth(res)
{
    var ds=res.value;
    if(ds.Tables[1].Rows.length>0)
    {
         var width_=document.getElementById('txtadsize2').value;
         var ds_height=ds.Tables[1].Rows[0].size_width;
         if(parseFloat(width_)>parseFloat(ds_height))
         {
            document.getElementById('txtadsize2').focus();
            alert("Width exceeds with edition total width");
            document.getElementById('txtadsize2').value="";
            return false;
         }  
         if(ds.Tables[1].Rows.length>0)
         {
              glob_area=ds.Tables[1].Rows[0].edition_area;
         }  
        
     }
        
     if(document.getElementById('txtadsize2').value!="" && document.getElementById('txtadsize1').value!="")
     {
        var height=parseFloat(document.getElementById('txtadsize1').value);
        var width=parseFloat(document.getElementById('txtadsize2').value);
        document.getElementById('txtbillwidth').value=height;
        document.getElementById('txtbillheight').value=width;
        var totarval=height*width;
        document.getElementById('txttotalarea').value=totarval.toFixed(2);
        document.getElementById('txtcolum').value="";
        document.getElementById('txtcolum').disabled=true;
        //document.getElementById('txtbillarea').value=document.getElementById('txttotalarea').value;
     }
     else
     {
        //document.getElementById('txttotalarea').value="";
        document.getElementById('txtcolum').value="";
        document.getElementById('txtcolum').disabled=false;
     
     }
    if(document.getElementById('txtadsize2').value!="" && document.getElementById('txttotalarea').value!="")
    {
         var width=document.getElementById('txtadsize2').value;
         var area_=document.getElementById('txttotalarea').value
         document.getElementById('txtadsize1').value   =formatDecimal(parseFloat(area_)/parseFloat(width),true,2);
          document.getElementById('txtbillwidth').value=document.getElementById('txtadsize1').value;
            document.getElementById('txtbillheight').value=width;
    }      
        

         ///////when there is a change in page area when there is insertion grid than it also changes in insertion grid automatically
    
    if( document.getElementById('tblinsert').innerHTML!="" && document.getElementById('txtadsize2').value!="")
    {    
       var hei=document.getElementById('txtbillheight').value
        if(document.getElementById('txtbillheight').value=="NaN")
        {
            hei="";
        }
        var wid=document.getElementById('txtbillwidth').value   
        if(document.getElementById('txtbillwidth').value=="NaN")
        {
            wid="";
        }  
        getpageareaintogrid(hei,wid);
    }  

}


///////////////////this is the function created to get the solo rate break up with referrence to the pacakage selected
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
              return false; // cancel the default behavior since 
                            // we have selected our own value 
            } 
      } 
  // reset initial key to be inline with default behavior 
    dropdownlist.keypressBuffer = key; 
    return true; // give default behavior 
} 

///this function is to chk or unchk the cliend and agency address chk box in the box details tab
function agencychk()
{
    if(document.getElementById('chkage').checked==true)
    {
        document.getElementById('chkclie').checked=false;
        document.getElementById('txtboxaddress').value="";
        document.getElementById('txtboxaddress').value=document.getElementById('txtagencyaddress').value;
         //document.getElementById('txtboxaddress').disabled=true;
    }
    if(document.getElementById('chkage').checked==false)
    {
     document.getElementById('txtboxaddress').value="";
      //document.getElementById('txtboxaddress').disabled=false;
    }
    

}
function clientchk()
{
    if(document.getElementById('chkclie').checked==true)
    {
        document.getElementById('chkage').checked=false;
        document.getElementById('txtboxaddress').value="";
        document.getElementById('txtboxaddress').value=document.getElementById('txtclientadd').value;
    }
    if(document.getElementById('chkclie').checked==false)
    {
        document.getElementById('txtboxaddress').value="";      
    }

}
///////////////////////////////////////this is the call back function to bind the grid when we subtract the insertion date
function insertLinesubtract_callback(packagename,check)
{
                        // get No of Insertion
                        var rowCount=parseInt(document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length);
                    var finsert=1;    
                    var insertion=document.getElementById('txtinsertion').value;
                    if(check=='main')
                    {
                        if(document.getElementById('drppackagecopy').options.length>0)
                        {
                            for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
                            {
                                 rowCount=parseInt(document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length);
                                if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
                                {
                                    tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                                }    
                                   /* if(parseInt(tinsert)>parseInt(finsert))
                                    {
                                        finsert=tinsert;
                                    }
                                    insertion = parseInt(insertion) * parseInt(tinsert);
                                    
                                else
                                {
                                     insertion = parseInt(document.getElementById('txtinsertion').value);
                                }*/
                                var dInsert=(parseInt(previnsertion) * parseInt(tinsert))-(parseInt(insertion) * parseInt(tinsert));
                                var insid="";
                                for(var d=parseInt(rowCount)-2;d>=0;d--)
                                {
                                      var id=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[d+1].cells[1].id.substr(3,document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[d+1].cells[1].id.length-3);
                                       
                                    if(insid!="")
                                    {
                                        if(insid!=document.getElementById("ins"+id).innerHTML)
                                        {
                                             dInsert=parseInt(dInsert)-1;
                                        }
                                     }   
                                    if(dInsert==0)
                                        break;
                                     var strid = document.getElementById('drppackagecopy').options[insertCou].value;
                                     var strid1=strid.split('@');
                                     var pkgid=strid1[0];
                                     var pkgcodegrid=document.getElementById("hiddenpckcode"+id).value;
                                     if(pkgcodegrid == pkgid)
                                     {
                                         insid=document.getElementById("ins"+id).innerHTML;
                                        document.getElementById('gridtab').deleteRow(d+1);
                                       
                                     }
                                }
                            }
                        } 
                        
                    }
                    else
                    {
                        if(document.getElementById('drppackagecopy').options.length>0)
                        {
                            for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
                            {
                                  rowCount=parseInt(document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length);
                                if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
                                {
                                    tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                                }    
//                                   /* if(parseInt(tinsert)>parseInt(finsert))
//                                    {
//                                        finsert=tinsert;
//                                    }
//                                    insertion = parseInt(insertion) * parseInt(tinsert);
//                                    
//                                else
//                                {
//                                     insertion = parseInt(document.getElementById('txtinsertion').value);
//                                     
//                                }*/
//                                var prevtinsert = tinsert;
                                if(packagename==document.getElementById('drppackagecopy').options[insertCou].value)
                                {
                                    var prevtinsert=parseInt(tinsert) + 1;
                                    var insid="";
                                       var dInsert=(parseInt(previnsertion) * parseInt(prevtinsert))-(parseInt(insertion) * parseInt(tinsert));
                                  for(n=0;n<dInsert;n++)
                                  {     
                                    for(var d=parseInt(rowCount)-2;d>=0;d--)
                                    {
                                         var strid = document.getElementById('drppackagecopy').options[insertCou].value;
                                         var strid1=strid.split('@');
                                         var pkgid=strid1[0];
                                         var id=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[d+1].cells[0].id.substr(3,document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[d+1].cells[0].id.length-3);
                                         var pkgcodegrid=document.getElementById("hiddenpckcode"+id).value;
                                         if(insid!="")
                                         {
                                         
                                            if(insid!=document.getElementById("ins"+id).innerHTML && n==dInsert-1)
                                            {
                                                return false;
                                            }
                                         }
                                         if(pkgcodegrid == pkgid)
                                         {
                                             if(insid!="")
                                             {
                                                  if(insid!=document.getElementById("ins"+id).innerHTML )
                                                    {
                                                        n = parseInt(n,10)+1;
                                                    }
                                              } 
                                             insid=document.getElementById("ins"+id).innerHTML;
                                             document.getElementById('gridtab').deleteRow(d+1);
                                         }
                                    }
                                  }  
                                }

                            }
                        } 
                    }
                    previnsertion=document.getElementById('txtinsertion').value;
                    document.getElementById('hiddenrowcount').value=parseInt(document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length) - 1;
                   return false;

}

//this is to save the insertion lines into the database

function saveinsertion()
{
    var len="bookdiv";
    var insertno;
    var premid;
    var premper;
    var colid;
    var heightid;
    var widthid;
    var size;
    var late;
   //var uomid;
   //var adtypid;
    var cardid;
    var editid;
    var solorate;
    var premper1;
   var prem1id;
   var namecode;
   var inserts;
   var pagepost;
   var preall;
   var adcat;
   var adsubcat;
   var matsta;
   var filename;
   var discrate;
   var insertsta;
   var billstat;
   var id;
   var repeat;
   var i=0;
   var paid;
   var agrred;
   var solo;
   var gross;
   var insert="0";
   var pageno_inserts;
   var remark_inserts;
   var page;
   var pageprem;
   var noofcol;
   var billamt;
   var billrate;
   var insert_id;
   var compcode=document.getElementById('hiddencompcode').value;
   var userid =document.getElementById('hiddenuserid').value;
   var cioid=document.getElementById('txtciobookid').value;
 //var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
  var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
   var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;  
  var k;
   var dateformat=document.getElementById('hiddendateformat').value;
    for(k=0;k<y;k++)
    {
       
 
             
        insert_id="sho"+i;
        id="Text" + i;
        editid="edit"+i;
        premid="prem"+i;
        prem1id="premone"+i;
        colid="col"+i;
        heightid="hei"+i;
        widthid="wid"+i;
        size="siz"+i;
        pagepost="pagpos"+i;
        namecode="one";
        premper="premper"+i;
        premper1="premperone"+i;
        //adtypid="adtyp"+i;
        namecode="two";
        preall="preall"+i;
        adcat="adcat"+i;
        late="lat"+i;
        matsta="mat"+i;
        cardid="card"+i;   
        filename="fil"+i;
        discrate="disrat"+i;
        insertsta="inssta"+i;
        billstat="bill"+i;
        adsubcat="ads"+i;
        repeat="rep"+i;
        insertno="ins"+i;
        paid="pai"+i
        agrred="agr"+i;
        solo="sol"+i;
        gross="gro"+i;
        pageno_inserts="pagno"+i;;
        remark_inserts="rem"+i;
        page="pgpre"+i;
        pageprem="pagper"+i;
        noofcol="nocol"+i;
        billamt="ba"+i;
        billrate="br"+i;
        var edit_vari=document.getElementById(editid);
        var par1=(edit_vari.parentNode).parentNode;
   if(browser!="Microsoft Internet Explorer")
       {
       var insernum=document.getElementById(insertno).innerHTML;
        var insertdate=document.getElementById(id).value;
        var edition=document.getElementById(editid).value;
        var premium1=document.getElementById(premid).value;
        var premium2=""; //document.getElementById(prem1id).value;
        var height=document.getElementById(heightid).value;
        var width=document.getElementById(widthid).value;
        var totalsize=document.getElementById(size).value;
        var pagepost=document.getElementById(pagepost).value;
        var color=document.getElementById(colid).value;
        var premper11='';
        if(document.getElementById(premper)!=undefined)
             premper11=document.getElementById(premper).value;
        var premper2=""; //document.getElementById(premper1).value;
        var premallow=document.getElementById(preall).value;
        var adcategory=document.getElementById(adcat).value;
        var latestdate=document.getElementById(late).value;
        var material=document.getElementById(matsta).value;
        var cardrate=document.getElementById(cardid).value;
        var filename=document.getElementById(filename).value;
        var discrate=document.getElementById(discrate).value;
        var insertstatus=document.getElementById(insertsta).value;
        var billstatus=document.getElementById(billstat).value;
        var adsubcat=document.getElementById(adsubcat).value;
        var repdate=document.getElementById(repeat).value;
        var paidins=document.getElementById(paid).value;
        var insagreedrate=document.getElementById(agrred).value;
        var inssolo=document.getElementById(solo).value;
        var grossrate=document.getElementById(gross).value;
        var insert_pageno=document.getElementById(pageno_inserts).value;
        var insert_remark=document.getElementById(remark_inserts).value;
        var page_code=""; //document.getElementById(page).value;
        var page_per=""; //document.getElementById(pageprem).value;
        var no_ofcol=document.getElementById(noofcol).value;
        var bill_amt=document.getElementById(billamt).value;
        var bill_rate=document.getElementById(billrate).value;
      
        var insertid='0';
        //26sep09
        var pkgcodegrid_value="";
        var pkginsgrid_value="";
        var pkg_alias_value="";
        var pkgcodegrid="hiddenpckcode"+i;
        
        var pkg_ins="pkg_ins"+i;
        
        var pkg_alias="pkg_alias"+i;
        if(document.getElementById(pkgcodegrid)!=null)
        {
            pkgcodegrid_value=document.getElementById(pkgcodegrid).value;
        }
        
        if(document.getElementById(pkg_ins)!=null)
        {
            pkginsgrid_value=document.getElementById(pkg_ins).value;
        }
        
        if(document.getElementById(pkg_alias)!=null)
        {
            pkg_alias_value=trim(document.getElementById(pkg_alias).value);
        }
        
        if(document.getElementById(insert_id)!=null)
            insertid=document.getElementById(insert_id).value;
       }
       else
       {
        var insernum=par1.all[insertno].innerHTML;
        var insertdate=par1.all[id].value;
        var edition=par1.all[editid].value;
        var premium1=par1.all[premid].value;
        var premium2=""; //document.getElementById(prem1id).value;
        var height=par1.all[heightid].value;
        var width=par1.all[widthid].value;
        var totalsize=par1.all[size].value;
        var pagepost=par1.all[pagepost].value;
        var color=par1.all[colid].value;
        var premper11='';
        if(par1.all[premper]!=undefined)
             premper11=par1.all[premper].value;
        var premper2=""; //document.getElementById(premper1).value;
        var premallow=par1.all[preall].value;
        var adcategory=par1.all[adcat].value;
        var latestdate=par1.all[late].value;
        var material=par1.all[matsta].value;
        var cardrate=par1.all[cardid].value;
        var filename=par1.all[filename].value;
        var discrate=par1.all[discrate].value;
        var insertstatus=par1.all[insertsta].value;
        var billstatus=par1.all[billstat].value;
        var adsubcat=par1.all[adsubcat].value;
        var repdate=par1.all[repeat].value;
        var paidins=par1.all[paid].value;
        var insagreedrate=par1.all[agrred].value;
        var inssolo=par1.all[solo].value;
        var grossrate=par1.all[gross].value;
        var insert_pageno=par1.all[pageno_inserts].value;
        var insert_remark=par1.all[remark_inserts].value;
        var page_code=""; //document.getElementById(page).value;
        var page_per=""; //document.getElementById(pageprem).value;
        var no_ofcol=par1.all[noofcol].value;
        var bill_amt=par1.all[billamt].value;
        var bill_rate=par1.all[billrate].value;
      
        var insertid='0';
        //26sep09
        var pkgcodegrid_value="";
        var pkginsgrid_value="";
        var pkg_alias_value="";
        var pkgcodegrid="hiddenpckcode"+i;
        
        var pkg_ins="pkg_ins"+i;
        
        var pkg_alias="pkg_alias"+i;
        if(par1.all[pkgcodegrid]!=null)
        {
            pkgcodegrid_value=par1.all[pkgcodegrid].value;
        }
        
        if(par1.all[pkg_ins]!=null)
        {
            pkginsgrid_value=par1.all[pkg_ins].value;
        }
        
        if(par1.all[pkg_alias]!=null)
        {
            pkg_alias_value=trim(par1.all[pkg_alias].value);
        }
        
        if(par1.all[insert_id]!=null)
            insertid=par1.all[insert_id].value;
      }
       insertid='0';
        var res=Booking_Master_temp.insertinsertion(insertdate,edition,premium1,premium2,premallow,adcategory,latestdate,material,cardrate,filename,discrate,insertstatus,billstatus,adsubcat,compcode,userid,cioid,height,width,totalsize,pagepost,premper11,premper2,color,repdate,insernum,paidins,insagreedrate,inssolo,grossrate,insert,insert_pageno,insert_remark,page_code,page_per,no_ofcol,bill_amt,bill_rate,insertid, dateformat,pkgcodegrid_value,pkginsgrid_value,pkg_alias_value);
         if(res.error!=null)
           {
            alert(res.error.description);
            return false;
           }
        
        i=i+1;
    }
    
        document.getElementById('tblinsert').innerHTML="" 
    
        document.getElementById('tblrate').style.display="none";
		document.getElementById('tblbill').style.display="none";
		//document.getElementById('tblsize').style.display="none";
		document.getElementById('addetails').style.display="none";
		document.getElementById('pagedetail').style.display="none";
		document.getElementById('tblpackage').style.display="none";   
		document.getElementById('tbbox').style.display="none";
		document.getElementById('txtciobookid').value="";
		document.getElementById('LinkButton1').disabled=true;
		document.getElementById('LinkButton2').disabled=true;
		document.getElementById('LinkButton3').disabled=true;
		document.getElementById('LinkButton4').disabled=true;
		document.getElementById('LinkButton5').disabled=true;
		document.getElementById('LinkButton6').disabled=true;
		document.getElementById('LinkButton7').disabled=true;
		var flagrate;
////////////////

         noofinsert="";
         noofinsertlo="";
         rowwhenupdate="";
         fillinsert="";
         insertval="";
         boxpercen="";
         boxgamt;
         boxbill;
         glspedisc="0";
         glspadisc="0";
         glspeccharge="0";
         glpre="0";
         savtotid;
         getid="";
         countgridloop="";
         schemediscount="";
         subtractrow="0";

    
        return false;
 

}

/*
function for uploading the images
*/
function preview(what){
  //var source=what.value;
  var id=document.getElementById(what);
  var source=document.getElementById(what).value;
  var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
  for (var i=0; i<fileTypes.length; i++) if (fileTypes[i]==ext) break;
  globalPic=new Image();
  if (i<fileTypes.length) globalPic.src=source;
  else {
    globalPic.src=defaultPic;
    alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n"+fileTypes.join(", "));
  }
  //setTimeout("applyChanges()",200);
  
  ////////////////this is the page created to save the image uploaded in the folder on the server side
  
            //var page=document.getElementById(premid).value;
            //var abc=new Object();
            //abc.xyz=source;
            Booking_Master_temp.saveimage(id);
            //alert("hi");
            
                var val="";        
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                    httpRequest.open( "GET","chkpkgrate.aspx?adtype="+adtype+"&color="+color+"&adcat="+adcat+"&adsucat="+adsucat+"&currency="+currency+"&ratecode="+ratecode+"&package1="+global_code+"&uomvalue="+uomvalue+"&prem_insert="+document.getElementById('drppageprem').value, false );
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) 
                    {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) 
                        {
                            val=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                {
                     var xml = new ActiveXObject("Microsoft.XMLHTTP");
                     xml.Open( "GET","saveimage.aspx?source="+source, false );
                     xml.Send();  
                     val=xml.responseText;
                }
  alert(val);
}
var globalPic;
function applyChanges(){
  var field=document.getElementById(outImage);
  var x=parseInt(globalPic.width);
  var y=parseInt(globalPic.height);
  if (x>maxWidth) {
    y*=maxWidth/x;
    x=maxWidth;
  }
  if (y>maxHeight) {
    x*=maxHeight/y;
    y=maxHeight;
  }
  //field.style.display=(x<1 || y<1)?"none":"";
  field.src=globalPic.src;
  field.width=x;
  field.height=y;
}

function uploadimage(id,ins,edition,fileid)
{
    var ival = parseInt(ins)-1;
    var edit=document.getElementById(edition).value;
    var ciobookid=document.getElementById('txtciobookid').value;
    var adheight= document.getElementById('hei'+ival).value;
    var adwidth= document.getElementById('wid'+ival).value;
    var insertid=ival;
    if(adheight=='')
    {
        alert("Please enter Ad Height");
        document.getElementById('hei'+ival).focus();
        return false;
    }
    else if(adwidth=='')
    {
        alert("Please enter Ad Width");
        document.getElementById('wid'+ival).focus();
        return false;
    }
    window.open('default3.aspx?adheight='+adheight+'&adwidth='+adwidth+'&no='+insertid+'&ins='+ins+'&edition='+edit+'&ciobookid='+ciobookid+'&fileid='+fileid,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
    return false;
}
//this is the function to open the upload pop up when the image is uploaded for all
function uploadimageall()
{
    if(document.getElementById('tblinsert').innerHTML=="")
    {
        alert("please fill insertion grid");
        return false;
    }
    var ins="0";
    var edit="All";
    var ciobookid=document.getElementById('txtciobookid').value;
    var fileid="bookdiv";
    if(document.getElementById('txtadsize1').value=='')
    {
         alert("Please enter Ad Height");
                   // document.getElementById('txtadsize1').focus();
         return false;
    }
    else if(document.getElementById('txtadsize2').value=='')
    {
         alert("Please enter Ad Width");
                  //  document.getElementById('txtadsize2').focus();
         return false;
    }
    window.open('default3.aspx?adheight='+document.getElementById('txtadsize1').value+'&adwidth='+document.getElementById('txtadsize2').value+'&ins='+ins+'&edition='+edit+'&ciobookid='+ciobookid+'&fileid='+fileid,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
    return false;
}

///////////////this is the function created to chk taht insert date should be greater than current date and
/////////////./when late by data is selected than it should be grater than select date 

function chkdateforbook(id,val12)
{
    if(id==undefined)
    {
        return false;
    }
    if(document.getElementById('tblinsert').innerHTML!="")
    {   
        var idval=id.value;
        if(id.id.indexOf("Text")>=0)
        {
            var bookingdate=document.getElementById('txtdatetime').value;
            var rodate=id.value;

            var dateformat=document.getElementById('hiddendateformat').value;           
            if(dateformat=="dd/mm/yyyy")
            {
                 if(bookingdate != "")
                 {
                     if(bookingdate.indexOf('-')>=0)
                     {
                          var txt=bookingdate;
                          var txt1=txt.split("-");
                          var dd=txt1[0];
                          var mm1=txt1[1];
                          var mm = getMonthNo(mm1);
                          var yy=txt1[2];
                          bookingdate=mm+'/'+dd+'/'+yy;
                     }
                    else
                    {
                        var txt=bookingdate;
                        var txt1=txt.split("/");
                        var dd=txt1[0];
                        var mm1=txt1[1];
                        var mm = txt1[1];//getMonthNo(mm1);
                        var yy=txt1[2];
                        bookingdate=mm+'/'+dd+'/'+yy;
                    }
                }
                else
                {
                    bookingdate=bookingdate;
                }

            }
            
            if(dateformat=="yyyy/mm/dd")
            {
                if(bookingdate!="")
                {
                    var txt=bookingdate;
                    var txt1=txt.split("/");
                    var yy=txt1[0];
                    var mm=txt1[1];
                    var dd=txt1[2];
                    bookingdate=mm+'/'+dd+'/'+yy;
                }
                else
                {
                    bookingdate=bookingdate;
                }
            }
            
            if(dateformat=="mm/dd/yyyy")
            {
                bookingdate=bookingdate;
            }                
                
            if(dateformat=="dd/mm/yyyy")
            {
                if(rodate != "")
                {
                    if(rodate.indexOf('-')>=0)
                    {
                        var txt=rodate;
                        var txt1=txt.split("-");
                        var dd=txt1[0];
                        var mm1=txt1[1];
                        var mm = getMonthNo(mm1);
                        var yy=txt1[2];
                        rodate=mm+'/'+dd+'/'+yy;
                    }
                    else
                    {
                        var txt=rodate;
                        var txt1=txt.split("/");
                        var dd=txt1[0];
                        var mm1=txt1[1];
                        var mm = txt1[1];//getMonthNo(mm1);
                        var yy=txt1[2];
                        rodate=mm+'/'+dd+'/'+yy;
                    }
                }
                else
                {
                    rodate=rodate;
                }

            }
                
            if(dateformat=="yyyy/mm/dd")
            {
                if(rodate!="")
                {
                    var txt=rodate;
                    var txt1=txt.split("/");
                    var yy=txt1[0];
                    var mm=txt1[1];
                    var dd=txt1[2];
                    rodate=mm+'/'+dd+'/'+yy;
                }
                else
                {
                    rodate=rodate;
                }
            }
                
            if(dateformat=="mm/dd/yyyy")
            {
                rodate=rodate;
            }
            
            var bookdate=new Date(bookingdate);
            var rdate=new Date(rodate);

            if(rdate<bookdate &&  (document.getElementById('hiddenbackdatebook').value=="0" || document.getElementById('hiddenbackdatebook').value=="N"))
            {
                alert("Insertion date should be greater than Publish date");
                id.value=val12;
                
                id.focus();
                return false;
            }
               
            
        }
        else if(id.id.indexOf("lat")>=0)
        {
            var editid=id.id.replace("lat","Text");
            var editdate=document.getElementById(editid).value;
            var latdate=idval;
            var ldate=new Date(latdate);
    		var edate=new Date(editdate);
    		if(latdate!="")
    		{
    		    if(ldate>edate)
		        {}
		        else
		        {
		            alert("Latest Date Should Be Greater Than Edition Date");
		            //document.getElementById(late).value="";
		            id.value=val12;
		            return false;
		        }
    		}
        
        }
            
   }

}

///this is the function created to fill the value in file name when we click on attachment button

function givefilename(ins,edi,cioid,filid)
{
    var val=cioid + "-" +ins + "-" +edi;
    //opener.document.getElementById(filid).value=val; 
    return false;
}
///////////this is the function to check whether the ro date is greater than bookind date if it than give alert

function chkratedate()
{
    var bookingdate=document.getElementById('txtdatetime').value;
    var rodate=document.getElementById('txtrodate').value;
    var dateformat=document.getElementById('hiddendateformat').value;
     if(dateformat=="yyyy/mm/dd")
    {
    var yearfield=bookingdate.split("/")[0]
    var monthfield=bookingdate.split("/")[1]
    var dayfield=bookingdate.split("/")[2]
    var bookdate = new Date(yearfield, monthfield-1, dayfield)
    }
    if(dateformat=="mm/dd/yyyy")

    {
    var yearfield=bookingdate.split("/")[2]
    var monthfield=bookingdate.split("/")[0]
    var dayfield=bookingdate.split("/")[1]
    //var dayobj = new Date(monthfield-1, dayfield, yearfield)
    var bookdate = new Date(yearfield, monthfield-1, dayfield)

    }
    if(dateformat=="dd/mm/yyyy")
    {
    var yearfield=bookingdate.split("/")[2]
    var monthfield=bookingdate.split("/")[1]
    var dayfield=bookingdate.split("/")[0]
    //var dayobj = new Date(dayfield, monthfield-1, yearfield)
    var bookdate = new Date(yearfield, monthfield-1, dayfield)
    }

      if(dateformat=="yyyy/mm/dd")
    {
    var yearfield=rodate.split("/")[0]
    var monthfield=rodate.split("/")[1]
    var dayfield=rodate.split("/")[2]
    var rdate = new Date(yearfield, monthfield-1, dayfield)
    }
    if(dateformat=="mm/dd/yyyy")

    {
    var yearfield=rodate.split("/")[2]
    var monthfield=rodate.split("/")[0]
    var dayfield=rodate.split("/")[1]
    //var dayobj = new Date(monthfield-1, dayfield, yearfield)
    var rdate = new Date(yearfield, monthfield-1, dayfield)

    }
    if(dateformat=="dd/mm/yyyy")
    {
    var yearfield=rodate.split("/")[2]
    var monthfield=rodate.split("/")[1]
    var dayfield=rodate.split("/")[0]
    //var dayobj = new Date(dayfield, monthfield-1, yearfield)
    var rdate = new Date(yearfield, monthfield-1, dayfield)
    }

   // var bookdate=new Date(bookingdate);
  //  var rdate=new Date(rodate);

    if(rdate>bookdate)
    {
        alert("RO date should be lesser or equal to Booking date");
        document.getElementById('txtrodate').value="";
        return false;
    }

}

function getsubcode()
{
    document.getElementById('hiddensubcode').value=document.getElementById('drpagscode').value
    return false;
}




function getbrand()
{
    document.getElementById('hiddenbrand').value=document.getElementById('drpbrand').value;
    return false;
}
function getzone()
{
    document.getElementById('hiddenzone').value=document.getElementById('txtexeczone').value;
    return false;
}

//this is the function to show the grid during execution mode

function showgridexecute()
{
       var msg=checkSession();
         if(msg==false)
         {
            window.location.href="login.aspx";
            return false;
         } 
    if(document.getElementById('txtciobookid').value=='')
    {
        document.getElementById('txtciobookid').value=document.getElementById('hiddencioid').value;
    }
    var cioid=document.getElementById('txtciobookid').value;
    var compcode=document.getElementById('hiddencompcode').value;

    Booking_Master_temp.showgridforexe(cioid,compcode,call_showgrid);
    return false;
}

function call_showgrid(res)
{
    Make_Row='';
    var ds=res.value;
    var str="";
    var editid;
    var inserts;
    var adsubcat;
    var dat="mm+"/"+dd+"/"+yyyy";
    var l;
    var j;
    var colid;
    var height;
    var width;
    var size;
    var pagepost;
    var p;
    var cardid;
    var matsta;
    var filename;
    var discrate;
    var insertsta;
    var billstat;
    var late;
    var repeat;
    var premid;
    var premper;
    var premper1;
    var adtypid;
    var namecode;
    var preall;
    var adcat;
    var picfield;
    var agrred;
    var paid;
    var solo;
    var gross;
    var showid;
    var pageno_inserts;
    var remark_inserts;
    var page;
    var pageprem;
    var noofcol;
    var billamt;
    var billrate;
    var pagstr;
    var dbill="";
    var dcou=0;
    var objedition=document.getElementById('drpedition');
    var showordisable=document.getElementById('hiddensavemod').value;
    var noinsertgrid=document.getElementById('txtinsertion').value;
  var drppagepos_vari=document.getElementById('drppageposition');
  arrEdition_Item="";
    noofinsertlo=parseInt(ds.Tables[0].Rows.length)/parseInt(noinsertgrid)
    rowwhenupdate=ds.Tables[0].Rows.length;
    insertval=1;
    if(ds!=null && typeof(ds)=="object" && ds.Tables[0].Rows.length>0)
    {
        //this is the for loop we are implementing so that the rows appear the same as the rows in tbl_booking_insert table
         var count=ds.Tables[0].Rows.length-1;
         countgridloop=ds.Tables[0].Rows.length;
         retrows=ds.Tables[0].Rows.length-1;
         var i=0;
         str="<div id=\"bookdiv\" runat=\"server\" style=\"OVERFLOW: auto; WIDTH: 896px; HEIGHT: 160px; \"><table cellpadding=\"1\" cellspacing=\"1\" id=\"gridtab\" width=\"1000px\" border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=\"center\" valign=\"top\" ></td><td align=\"center\" valign=\"top\" >No.</td><td align=\"center\" valign=\"top\" >Edition</td><td valign=\"top\" align=\"center\">Date</td><td align=\"center\" valign=\"top\">Ad Sub Cat.</td><td align=\"center\" valign=\"top\">Color</td><td align=\"center\" valign=\"top\">Height</td><td align=\"center\" valign=\"top\">Width</td><td align=\"center\" valign=\"top\">Col.</td><td align=\"center\" valign=\"top\">Size</td><td align=\"center\" valign=\"top\">Insertion Sta.</td><td valign=\"top\" >Page No.</td><td valign=\"top\">Status Material</td><td align=\"center\" valign=\"top\">File Name</td>";
         if(showordisable=="1")
         {
            str=str+"<td valign=\"top\" disabled id='uploadA' >Upload</td>";
         }
         else
         {
           str=str+"<td valign=\"top\" style=\"cursor:pointer;color:red;\"id='uploadA'>Upload</td>";
         }
                        
         str=str+"<td valign=\"top\" >Remarks</td><td align=\"center\" valign=\"top\">Card Rate</td><td valign=\"top\" align=\"center\">Disc. Rate</td><td valign=\"top\" align=\"center\">Agreed Amt</td><td align=\"center\" valign=\"top\">P Pos</td><td align=\"center\" valign=\"top\">Latest By</td><td align=\"center\" valign=\"top\">Repeating</td><td align=\"center\" valign=\"top\">Premium</td><td align=\"center\" valign=\"top\">Pre(%)</td><td align=\"center\" valign=\"top\">Pre Allowed</td><td align=\"center\" valign=\"top\">Adv Cat.</td><td valign=\"top\">Bill Status</td><td valign=\"top\">Paid Ins.</td><td valign=\"top\" >Solo Rate</td><td valign=\"top\" >Gross Amt</td><td valign=\"top\" >Bill Amt</td><td valign=\"top\" >Bill Rate</td>";
        
         str=str+"</tr></table></div>";
         document.getElementById('tblinsert').innerHTML=str;
         var gridtab_vari=document.getElementById('gridtab');
         for(i=0;i<=count;i++)
         {
          if(showordisable!="1")
                    document.getElementById('btnshgrid').disabled=false;

            var id="Text" + i;
            editid="edit"+i;
            inserts="ins"+i;
            btn_Pg_="btn_Pg_"+i;
////            str=str+"<tr>";
////            str+="<td width='40px'>";
////            str+="<input  class='buttonpgset' id='"+btn_Pg_+"' type='button' onClick='javascript:return getButtonIdGrid();' Value='PageSet' >";
////            str+="</td>";
            
            Make_Row=document.createElement("tr");
            make_td=document.createElement("td");
            make_td.align="center";        
            str="<input  class='buttonpgset' id='"+btn_Pg_+"'  type='button' Value='PageSet'>";                           
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);        
            
            //////this is to bind the no of inserts and edition
           
////                str=str+"<td align=\"center\" id="+inserts+" class=\"TextField\" >"+ds.Tables[0].Rows[i].no_insert+"</td><td class=\"dtGrid\" ><input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[i].Edition+"></td>";            

// new change 31 dec 09
if(ds.Tables[0].Rows[i].no_insert=="1")
{
    if(arrEdition_Item=="")
        arrEdition_Item = ds.Tables[0].Rows[i].Edition;
    else
        arrEdition_Item = arrEdition_Item + "," + ds.Tables[0].Rows[i].Edition;
}
                 insertval=ds.Tables[0].Rows[i].no_insert;
                 make_td=document.createElement("td");
                 make_td.align="center";
                 make_td.setAttribute("class","TextField");
                 make_td.innerHTML=ds.Tables[0].Rows[i].no_insert;
                 make_td.id=inserts;
                 Make_Row.appendChild(make_td);
                  // EDITION
                 make_td=document.createElement("td");
                 make_td.align="center";
                 make_td.setAttribute("class","dtGrid");
                 str="<input class=\"btextforgrid\" type=\"text\" disabled id="+editid+" value="+ds.Tables[0].Rows[i].Edition+">";
                 make_td.innerHTML=str;
                 Make_Row.appendChild(make_td);
          
                //////this is to bind the insertion date   publish
            var mode="1";   
            var insdat= ds.Tables[0].Rows[i].Insert_date   
            
            var getdateforexe=savedateinto(ds.Tables[0].Rows[i].Insert_date,mode);    
            if(showordisable=="1")
            {
////                str=str + "<td><input class=\"btextforgrid\"  type=\"text\" disabled id="+id+" value="+getdateforexe+"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\" height=\"14\" width=\"14\" /></td>";
                make_td=document.createElement("td");
                make_td.align="center";
                str="<input class=\"btextforgrid\" type=\"text\" disabled id="+id+"  value="+getdateforexe+" >";
                make_td.innerHTML=str;
                Make_Row.appendChild(make_td);
            }
            else
            {
////                str=str + "<td><input class=\"btextforgrid\"  type=\"text\" id="+id+" value="+getdateforexe+" ><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\" height=\"14\" width=\"14\" /></td>";
                make_td=document.createElement("td");
                make_td.align="center";
                 str = "<input class=\"btextforgrid\" type=\"text\" id="+id+" onchange=\"return chkDateforGrid();\"   value="+getdateforexe+" >";
                make_td.innerHTML=str;
                Make_Row.appendChild(make_td);
            }
                
                ////this is to bind the Ad sub cat drop down
            adsubcat="ads"+i;
            var adsubcatval='';
            if(ds.Tables[0].Rows[i].Ad_sub_cat!=null)
                adsubcatval=ds.Tables[0].Rows[i].Ad_sub_cat;
            if(showordisable=="1")
            {
////                str=str+"<td><select disabled id="+adsubcat+" class=\"dropdownforgrid1\" >";
                 make_td=document.createElement("td");
                 make_td.align="center";
                 make_td.setAttribute("class","dtGrid");
                 if(i==0)
                 {        
                     str="<input class=\"btextforgrid\" disabled type=\"text\"  id="+adsubcat+" value="+adsubcatval+"><div id='agdiv' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglist'  id='aglist' CssClass='btextlist' size=4 Width=100px Height=50px></select></div>";
                 }
                 else
                 {
                    str="<input class=\"btextforgrid\" disabled type=\"text\"  id="+adsubcat+" value="+adsubcatval+">";
                 }
            }
            else
            {
                 make_td=document.createElement("td");
                 make_td.align="center";
                 make_td.setAttribute("class","dtGrid");
////                str=str+"<td><select id="+adsubcat+" class=\"dropdownforgrid1\" onchange=\"getvalueintoinserts("+adsubcat+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\">";
                if(i==0)
                {        
                    str="<input class=\"btextforgrid\"  type=\"text\"  id="+adsubcat+" value="+adsubcatval+"><div id='agdiv' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglist'   id='aglist' CssClass='btextlist' size=4 Width=100px Height=50px></select></div>";
                } 
                else
                {
                    str="<input class=\"btextforgrid\"  type=\"text\"  id="+adsubcat+" value="+adsubcatval+">";
                }
            }
             make_td.innerHTML=str;
             Make_Row.appendChild(make_td);
               
                // this is to bind adv sub cat drop down  
////             if(ds.Tables[0].Rows[i].Ad_sub_cat=="0")
////             {  
////                str=str+"<option value=\"0\" selected=\"true\">select</option>";
////             }
////             else
////             {
////                str=str+"<option value=\"0\" >select</option>";
////             }
               
////                for(l=0;l<=ds.Tables[3].Rows.length-1;l++)
////                {
////                    if(ds.Tables[3].Rows[l].Adv_Subcat_Code==ds.Tables[0].Rows[i].Ad_sub_cat && ds.Tables[0].Rows[i].Ad_sub_cat!="0")
////                    {
////                    str=str+"<option value="+ds.Tables[3].Rows[l].Adv_Subcat_Code+" selected="+ds.Tables[0].Rows[i].Ad_sub_cat+">"+ds.Tables[3].Rows[l].Adv_Subcat_Name+"</option>";
////                    }
////                    else 
////                    {
////                    str=str+"<option value="+ds.Tables[3].Rows[l].Adv_Subcat_Code+">"+ds.Tables[3].Rows[l].Adv_Subcat_Name+"</option>";
////                    }
////                    
////                }
                        
               colid="col"+i;
               if(showordisable=="1")
               {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    make_td.setAttribute("class","dropdownforgrid");                 
                    str="<input class=\"btextforgrid\" disabled type=\"text\"  id="+colid+" value="+ds.Tables[0].Rows[i].Col_code+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
               }
               else
               {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    make_td.setAttribute("class","dropdownforgrid");
                    str="<input class=\"btextforgrid\"  type=\"text\"  id="+colid+" value="+ds.Tables[0].Rows[i].Col_code+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);                 
               } 
               
////               if(showordisable=="1"  || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////               {   
////                    str=str+"</select></td><td><select disabled id="+colid+" class=\"dropdownforgrid1\" >";
////               }
////               else
////               {
////                    str=str+"</select></td><td><select id="+colid+" class=\"dropdownforgrid1\" onchange=\"getvalueintoinsertsforcolor("+colid+","+inserts+","+ds.Tables[0].Rows[i].no_insert+")\";>";
////               } 
////                    //this is to bind the color drop down
////                    str=str+"<option value=\"0\" selected=\"true\">select</option>";
////                for(j=0;j<=ds.Tables[1].Rows.length-1;j++)
////                {
////                    
////                     if(ds.Tables[1].Rows[j].col_Code==ds.Tables[0].Rows[i].Col_code && ds.Tables[0].Rows[i].Col_code!="0")
////                     {
////                        str=str + "<option value="+ds.Tables[1].Rows[j].col_Code+" selected="+ds.Tables[0].Rows[i].Col_code+">"+ds.Tables[1].Rows[j].col_Name+"</option>";    
////                     }
////                     else
////                     {
////                        str=str + "<option value="+ds.Tables[1].Rows[j].col_Code+">"+ds.Tables[1].Rows[j].col_Name+"</option>";    
////                     }                      
////                
////                }
                
               premid="prem"+i;
               prem1id="premone"+i;
               height="hei"+i;
               width="wid"+i;
               size="siz"+i;
               pagepost="pagpos"+i;
               noofcol="nocol"+i;
               var widthexe;               
               var noofexe;
               if(ds.Tables[0].Rows[i].Width==null)
               {
                   widthexe=""
               }
               else
               {
                   widthexe=ds.Tables[0].Rows[i].Width
               }
               
               if(ds.Tables[0].Rows[i].No_ofcolumn==null)
               {
                   noofexe="";
               }
               else
               {  
                   noofexe=ds.Tables[0].Rows[i].No_ofcolumn;
               }
                            
              if(showordisable=="1")
              {
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextsmallsize\" disabled id="+height+"  type=\"text\" value="+ds.Tables[0].Rows[i].Height+"> ";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                    
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextsmallsize\" disabled id="+width+"  type=\"text\"  value="+widthexe+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                      
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextsmallsize\" disabled id="+noofcol+" type=\"text\"  value="+noofexe+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                      
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+ds.Tables[0].Rows[i].Size_book+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
              }
              else
              {
                 make_td=document.createElement("td");
                 make_td.align="center";
                 str="<input class=\"btextsmallsize\" style=\" background-color: White;\" id="+height+"   type=\"text\"  value="+ds.Tables[0].Rows[i].Height+">";
                 make_td.innerHTML=str;
                 Make_Row.appendChild(make_td);
                
                 make_td=document.createElement("td");
                 make_td.align="center";
                 str="<input class=\"btextsmallsize\"  id="+width+" style=\"background-color:White;\"   type=\"text\"  value="+widthexe+">";
                 make_td.innerHTML=str;
                 Make_Row.appendChild(make_td);
                
                 make_td=document.createElement("td");
                 make_td.align="center";
                 str="<input class=\"btextsmallsize\"  id="+noofcol+" type=\"text\"  value="+noofexe+">";
                 make_td.innerHTML=str;
                 Make_Row.appendChild(make_td);
                
                 make_td=document.createElement("td");
                 make_td.align="center";
                 str="<input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+ds.Tables[0].Rows[i].Size_book+">";
                 make_td.innerHTML=str;
                 Make_Row.appendChild(make_td);
              }     
////                    str=str+"</select></td><td><input class=\"btextsmallsize\" disabled id="+height+" type=\"text\"  value="+ds.Tables[0].Rows[i].Height+"></td><td><input class=\"btextsmallsize\" disabled id="+width+"  type=\"text\"  value="+widthexe+"></td><td><input class=\"btextsmallsize1\" disabled id="+noofcol+"  type=\"text\"  value="+noofexe+"></td><td><input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+ds.Tables[0].Rows[i].Size_book+"></td>";
////              }
////              else
////              {
////                     if(ds.Tables[0].Rows[i].Width!="" && ds.Tables[0].Rows[i].Width!=null)
////                     {   
////                        str=str+"</select></td><td><input class=\"btextsmallsize\"  id="+height+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+ds.Tables[0].Rows[i].Height+"></td><td><input class=\"btextsmallsize\" id="+width+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+widthexe+"></td><td><input disabled class=\"btextsmallsize1\" disabled id="+noofcol+"  type=\"text\"  value="+noofexe+"></td><td><input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+ds.Tables[0].Rows[i].Size_book+"></td>";
////                     }
////                     else
////                     {
////                        str=str+"</select></td><td><input class=\"btextsmallsize\"  id="+height+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+ds.Tables[0].Rows[i].Height+"></td><td><input class=\"btextsmallsize\" id="+width+" onchange=\"return gettotalsize("+height+","+width+","+i+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\" onkeypress=\"javascript:return rateenter();\" type=\"text\"  value="+widthexe+"></td><td><input  class=\"btextsmallsize1\" disabled id="+noofcol+"  type=\"text\"  value="+noofexe+"></td><td><input class=\"btextsmallsize\" disabled id="+size+" type=\"text\"  value="+ds.Tables[0].Rows[i].Size_book+"></td>";
////                     }
////              
////              }      
                   ////this loop is to bind the insert status
                    insertsta="inssta"+i;
                  if(showordisable=="1")
                    { 
                        make_td=document.createElement("td");
                        make_td.align="center";
                        make_td.innerHTML="<input class=\"btextforgrid\" disabled  type=\"text\" id="+insertsta+"  value="+ds.Tables[0].Rows[i].Insert_status+">";
                        Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        make_td.innerHTML="<input class=\"btextforgrid\"   type=\"text\" id="+insertsta+"  value="+ds.Tables[0].Rows[i].Insert_status+">";
                        Make_Row.appendChild(make_td);
                    } 
                                            
////                   if(showordisable=="1"  || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                   {                               
////                         str=str+"<td><select disabled id="+pagepost+" class=\"dropdownforgrid1\">";
////                   }
////                   else
////                   {
////                         str=str+"<td><select id="+pagepost+" class=\"dropdownforgrid1\" onchange=\"return getpageprem("+pagepost+","+i+",'"+pagstr+"');\">";
////                   }
////                 
////              
////                    str=str+"<option value=\"0\" selected=\"true\">select</option>";
////                    for(p=0;p<=ds.Tables[7].Rows.length-1;p++)
////                    {
////                        if(ds.Tables[7].Rows[p].pos_type_code==ds.Tables[0].Rows[i].Page_post && ds.Tables[0].Rows[i].Page_post!="0")
////                        {
////                              str=str+"<option value="+ds.Tables[7].Rows[p].pos_type_code+" selected="+ds.Tables[0].Rows[i].Page_post+">"+ds.Tables[7].Rows[p].pos_type+"</option>";
////                        }
////                        else
////                        {
////                              str=str+"<option value="+ds.Tables[7].Rows[p].pos_type_code+">"+ds.Tables[7].Rows[p].pos_type+"</option>";
////                        }
////                    }   
////                        str=str+"</select></td>";                                
                                
                        pageno_inserts="pagno"+i;
                        
                        //for pageno,Remark,Upload..
                       if(showordisable=="1")
                       {
////                            str=str+"<td><input class=\"btextsmallsize\" disabled onkeypress=\"javascript:return rateenter();\"   type=\"text\" id="+pageno_inserts+"  value="+ds.Tables[0].Rows[i].Page_no+"></td>";
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input  class=\"btextforinsertright\" disabled  type=\"text\" id="+pageno_inserts+"  value="+ds.Tables[0].Rows[i].Page_no+">";
                            Make_Row.appendChild(make_td);
                       }
                       else
                       {
////                            str=str+"<td><input class=\"btextsmallsize\" onkeypress=\"javascript:return rateenter();\"   type=\"text\" id="+pageno_inserts+"  value="+ds.Tables[0].Rows[i].Page_no+"></td>";
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input  class=\"btextforinsertright\"  type=\"text\" id="+pageno_inserts+"  value="+ds.Tables[0].Rows[i].Page_no+">";
                            Make_Row.appendChild(make_td);
                       }       
                                                       
                        /////////////this is to bind the status material drop down
                       matsta="mat"+i; 
                       if(showordisable=="1")         
                       {      
                            make_td=document.createElement("td");
                            make_td.align="center";
                            if(ds.Tables[0].Rows[i].Status_material!=null)
                            {
                                 str="<input class=\"btextforgrid\" disabled  id="+matsta+" type=\"text\"  value="+ds.Tables[0].Rows[i].Status_material+">";
                            }    
                            else
                            {
                                 str="<input class=\"btextforgrid\" disabled  id="+matsta+" type=\"text\"  value=''>";
                            }
                            make_td.innerHTML=str;
                            Make_Row.appendChild(make_td);  
                       }
                       else
                       {
                            make_td=document.createElement("td");
                            make_td.align="center";
                            if(ds.Tables[0].Rows[i].Status_material==null)
                            {
                                str="<input class=\"btextforgrid\"   id="+matsta+" type=\"text\"  value=''>";
                            }
                            else
                            {
                                str="<input class=\"btextforgrid\"   id="+matsta+" type=\"text\"  value="+ds.Tables[0].Rows[i].Status_material+">";
                            }    
                            make_td.innerHTML=str;
                            Make_Row.appendChild(make_td); 
                        }
                                             
                                
////                       if(showordisable=="1"  || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")         
////                       {        
////                             str=str+"<td><select disabled id="+matsta+" class=\"dropdownforgrid\" >";
////                       }
////                       else
////                       {
////                            str=str+"<td><select id="+matsta+" class=\"dropdownforgrid\">";
////                       }
                            /////this is to bind the status material dropdown
////                        if(ds.Tables[0].Rows[i].Status_material=="0")
////                        {
////                            str=str+"<option value=\"0\" selected="+ds.Tables[0].Rows[i].Status_material+">Select</option>";
////                        }
////                        else
////                        {
////                             str=str+"<option value=\"0\">Select</option>";
////                        }
////                        if(ds.Tables[0].Rows[i].Status_material=="hardcopy")
////                        {
////                            str=str+"<option value=\"hardcopy\" selected="+ds.Tables[0].Rows[i].Status_material+">Hard Copy</option>";
////                        }
////                        else
////                        {
////                            str=str+"<option value=\"hardcopy\">Hard Copy</option>";
////                        }
////                        if(ds.Tables[0].Rows[i].Status_material=="softcopy")
////                        {
////                            str=str+"<option value=\"softcopy\" selected="+ds.Tables[0].Rows[i].Status_material+">Soft Copy</option>";
////                        }
////                        else
////                        {
////                            str=str+"<option value=\"softcopy\">Soft Copy</option>";
////                        }
////                        if(ds.Tables[0].Rows[i].Status_material=="cd")
////                        {
////                            str=str+"<option value=\"cd\" selected="+ds.Tables[0].Rows[i].Status_material+">CD</option>";
////                        }
////                        else
////                        {
////                             str=str+"<option value=\"cd\">CD</option>";
////                        }
////                        if(ds.Tables[0].Rows[i].Status_material=="other")
////                        {
////                            str=str+"<option value=\"other\" selected="+ds.Tables[0].Rows[i].Status_material+">Others</option>";
////                        }
////                        else
////                        {
////                            str=str+"<option value=\"other\">Others</option>";
////                        }
////                str=str+"</select></td>";
                
                //////////// for file name
                     filename="fil"+i; 
                     if(ds.Tables[0].Rows[i].File_name==null)
                     {
                         ds.Tables[0].Rows[i].File_name="";
                     }
                     make_td=document.createElement("td");
                     make_td.align="center";
                     str="<input class=\"btextforgrid\" type=\"text\" disabled id="+filename+" disabled  value="+ds.Tables[0].Rows[i].File_name+">";
                     make_td.innerHTML=str;
                     Make_Row.appendChild(make_td);                           
////                     if(ds.Tables[0].Rows[i].File_name == null)
////                     {
////                         ds.Tables[0].Rows[i].File_name="";
////                     }
////                     if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                     {
////                         str=str+"<td><input class=\"btextforgrid\" type=\"text\" disabled id="+filename+" disabled  value="+ds.Tables[0].Rows[i].File_name+"></td>";
////                     }
////                     else
////                     {
////                         str=str+"<td><input class=\"btextforgrid\" type=\"text\" id="+filename+" disabled  value="+ds.Tables[0].Rows[i].File_name+"></td>";
////                     }     
                    picfield="pic"+i;           
                    var upl="upload"+i
                    if(showordisable=="1")
                    {  
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input disabled  class=\"button1\" type=\"button\" id="+upl+" Value=\"Attachment\" >";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);
                    } 
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input  class=\"button1\" type=\"button\" id="+upl+" Value=\"Attachment\">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);
                    } 
////                        str=str+"<td width=\"50px\"><input disabled  class=\"button1\" type=\"button\" Value=\"Attachment\" onclick=\"uploadimage('"+picfield+"','"+ds.Tables[0].Rows[i].no_insert+"','"+editid+"','"+filename+"')\">";
////                    }
////                    else
////                    {
////                        str=str+"<td width=\"50px\"><input  class=\"button1\" type=\"button\" Value=\"Attachment\" onclick=\"uploadimage('"+picfield+"','"+ds.Tables[0].Rows[i].no_insert+"','"+editid+"','"+filename+"')\">";
////                    } 
                    remark_inserts="rem"+i;           
                    if(ds.Tables[0].Rows[i].Remarks==null)
                    {
                         ds.Tables[0].Rows[i].Remarks="";
                    } 
                    if(showordisable=="1")
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input  class=\"btextforgrid\"  disabled  type=\"text\" id="+remark_inserts+"  value="+ds.Tables[0].Rows[i].Remarks+">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input  class=\"btextforgrid\"   type=\"text\" id="+remark_inserts+"  value="+ds.Tables[0].Rows[i].Remarks+">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td); 
                    }    
                                      
////                         str=str+"<td><input class=\"btextforinsertright\" disabled class=\"btextsmallsize\" onkeypress=\"javascript:return rateenter();\"  type=\"text\" id="+remark_inserts+"  value="+ds.Tables[0].Rows[i].Remarks+"></td>";
////                    }
////                    else
////                    {
////                         str=str+"<td><input  class=\"btextforgrid\"   type=\"text\" id="+remark_inserts+"  value="+ds.Tables[0].Rows[i].Remarks+"></td>";
////                    }  
                        
                    //this is to fill card rate
                    cardid="card"+i;  
                    make_td=document.createElement("td");
                    make_td.align="center";
                    make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[0].Rows[i].Card_rate+">";
                    Make_Row.appendChild(make_td);          
////                    str=str+"<td>";
////                    if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                    {
////                         str=str+"<input class=\"btextforgrid\" disabled type=\"text\" disabled id="+cardid+" value="+ds.Tables[0].Rows[i].Card_rate+">";
////                    }
////                    else
////                    {
////                         str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[0].Rows[i].Card_rate+">";
////                    }
                    //// this is for the discount rate
                    discrate="disrat"+i;
                   
                    billstat="bill"+i;
                    agrred="agr"+i;
                    make_td=document.createElement("td");
                    make_td.align="center";
                    if(ds.Tables[0].Rows[i].Disc_rate!=null)
                        make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" disabled id="+discrate+"  value="+ds.Tables[0].Rows[i].Disc_rate+">";
                    else
                        make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" disabled id="+discrate+"  value=''>";    
                    
                    Make_Row.appendChild(make_td);
                    make_td=document.createElement("td");
                    make_td.align="center";
                    if(ds.Tables[0].Rows[i].Agreed_rate!=null)
                        make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value="+ds.Tables[0].Rows[i].Agreed_rate+">";
                    else
                        make_td.innerHTML="<input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=''>";    
                    Make_Row.appendChild(make_td);
                    
////                    if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                    {
////                         str=str+"</td><td><input class=\"btextforgrid\" type=\"text\" disabled id="+discrate+"  value="+ds.Tables[0].Rows[i].Disc_rate+"></td>";
////                    }
////                    else
////                    {
////                         str=str+"</td><td><input class=\"btextforgrid\" type=\"text\" disabled id="+discrate+"  value="+ds.Tables[0].Rows[i].Disc_rate+"></td>";                       
////                    }  
////                    if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                    {   
////                        str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" disabled id="+agrred+"  value="+ds.Tables[0].Rows[i].Agreed_rate+"></td>";
////                    }
////                    else
////                    {
////                        str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value="+ds.Tables[0].Rows[i].Agreed_rate+"></td>";
////                    }   
   ////this loop is to bind the page position
                   pagstr="fir"  
                   if(showordisable=="1")
                   {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        if(drppagepos_vari.value=='0')
                        {
                            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+pagepost+"   value=\"\">";
                        }
                        else
                        {
                            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+pagepost+"   value='"+drppagepos_vari.value+"'>";
                        }
                
                        Make_Row.appendChild(make_td); 
                    
                   }
                   else
                   {
                        make_td=document.createElement("td");
                        make_td.align="center";
                        if(drppagepos_vari.value=='0')
                        {
                            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" disabled id="+pagepost+"   value=\"\">";
                        }
                        else
                        {
                            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" disabled id="+pagepost+"  value='"+drppagepos_vari.value+"'>";
                        }
                
                        Make_Row.appendChild(make_td); 
                   }
                   
////                        str=str+"<td><select disabled id="+insertsta+" class=\"dropdownforgrid\">";
////                    }
////                    else
////                    {
////                        str=str+"<td><select id="+insertsta+" class=\"dropdownforgrid\" onchange=\"javascript:return chkpublishdate('"+insertsta+"','"+id+"')\">";
////                    }
                            ////////this is to bind the status of insertion drop down
                            
////                    if(browser!="Microsoft Internet Explorer")
////                    {
////                        var b=0;
////                        for(b=1;b<=xmlObj.childNodes[19].childNodes.length-1;)
////                        {
////                            if(xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue=="booked")
////                            {
////                                str=str+"<option value="+xmlObj.childNodes[19].childNodes[b+2].childNodes[0].nodeValue+" selected="+ds.Tables[0].Rows[i].Insert_status+">"+xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue+"</option>";
////                            }
////                            else
////                            {
////                                str=str+"<option value="+xmlObj.childNodes[19].childNodes[b+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue+"</option>";                                
////                            }                                    
////                            b=b+4;
////                        } 
////                    }
////                    else
////                    {
////                         var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
////                         loadXML('xml/billcycle.xml');
////                         var b=0;
////                         for(b=0;b<=xmlObj.childNodes(9).childNodes.length-1;b++)
////                         {
////                             if(xmlObj.childNodes(9).childNodes(b+1).text==ds.Tables[0].Rows[i].Insert_status)
////                             {
////                                 str=str+"<option value="+xmlObj.childNodes(9).childNodes(b+1).text+" selected="+ds.Tables[0].Rows[i].Insert_status+">"+xmlObj.childNodes(9).childNodes(b).text+"</option>";
////                             }
////                             else
////                             {
////                                 str=str+"<option value="+xmlObj.childNodes(9).childNodes(b+1).text+">"+xmlObj.childNodes(9).childNodes(b).text+"</option>";                                
////                             }                                    
////                             b=b+1;
////                         }    
////                    }    
                    late="lat"+i;
                    repeat="rep"+i;
                    var latdate;
                    var repeatdat;
                    if(ds.Tables[0].Rows[i].Latest_by==null)
                    {
                         latdate="";
                    }
                    else
                    {
                         latdate=ds.Tables[0].Rows[i].Latest_by;
                    }
                    if(ds.Tables[0].Rows[i].Repeating_date==null)
                    {
                         repeatdat=""
                    }
                    else
                    {
                         repeatdat=ds.Tables[0].Rows[i].Repeating_date
                    }
                    if(showordisable=="1")
                    { 
                        var latedate="latdate"+i;
                        var repeatdate="repdate"+i;
                        make_td=document.createElement("td");
                        make_td.align="center";
                        make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" disabled id="+late+"  value="+latdate+">";
                        Make_Row.appendChild(make_td);

                        make_td=document.createElement("td");
                        make_td.align="center";
                        make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\" disabled id="+repeat+"  value="+repeatdat+">";
                        Make_Row.appendChild(make_td);
                    }
                    else
                    {
                        var latedate="latdate"+i;
                        var repeatdate="repdate"+i;
                        make_td=document.createElement("td");
                        make_td.align="center";
                        make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\"  id="+late+"  value="+latdate+">";
                        Make_Row.appendChild(make_td);

                        make_td=document.createElement("td");
                        make_td.align="center";
                        make_td.innerHTML="<input class=\"btextforgrid\" type=\"text\"  id="+repeat+"  value="+repeatdat+">";
                        Make_Row.appendChild(make_td);
                    }  
////                         str=str+"</select></td><td><input class=\"btextforgrid\" type=\"text\" disabled id="+late+"  value="+latdate+"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+late+", Form1."+late+", "+dat+");\" height=\"14\" width=\"14\" /> </td><td><input class=\"btextforgrid\" type=\"text\" disabled id="+repeat+"  value="+repeatdat+"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+repeat+", Form1."+repeat+", "+dat+");\" height=\"14\" width=\"14\" /></td>";
////                    }
////                    else
////                    {
////                         str=str+"</select></td><td><input class=\"btextforgrid\" type=\"text\" id="+late+"  value='"+latdate+"'  onkeypress=\"return dateenter();\" onchange=\"javascript:return checkdate(Form1."+late+");\"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+late+", Form1."+late+", "+dat+");\" height=\"14\" width=\"14\" /> </td><td><input class=\"btextforgrid\" type=\"text\" id="+repeat+"  value='"+repeatdat+"'  onkeypress=\"return dateenter();\" onchange=\"javascript:return checkdate(Form1."+repeat+");\"><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+repeat+", Form1."+repeat+", "+dat+");\" height=\"14\" width=\"14\" /></td>";                        
////                    }
                    namecode="one";                                           
////                    if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                    { 
////                        str=str+"<td><select disabled id="+premid+" class=\"dropdownforgrid\" onchange=\"return getpercenprem("+premid+","+i+",'"+namecode+"');\"  >";
////                    }
////                    else
////                    {
////                        str=str+"<td><select id="+premid+" class=\"dropdownforgrid\" onchange=\"return getpercenprem("+premid+","+i+",'"+namecode+"');\"  >";
////                    }    
////                    var k;
////                    ///this is to bind the premium drop down
////                    str=str+"<option value=\"0\" selected=\"true\">select</option>";
////                        for(k=0;k<=ds.Tables[2].Rows.length-1;k++)
////                        {
////                        ////////on click function is there to get the prem % on premium drop down change
////                            if(ds.Tables[2].Rows[k].Premiumcode==ds.Tables[0].Rows[i].Premium1 && ds.Tables[0].Rows[i].Premium1!="0")
////                            {
////                                    str=str+"  <option value="+ds.Tables[2].Rows[k].Premiumcode+" selected="+ds.Tables[0].Rows[i].Premium1+">"+ds.Tables[2].Rows[k].premiumname+"</option>"
////                            }   
////                            else
////                            {
////                                    str=str+"  <option value="+ds.Tables[2].Rows[k].Premiumcode+">"+ds.Tables[2].Rows[k].premiumname+"</option>"
////                            }                                         
////                        }

                            premper="premper"+i;
                            premper1="premperone"+i;
                            adtypid="adtyp"+i;
                            namecode="two";
                            preall="preall"+i;
                            adcat="adcat"+i;
                            paid="pai"+i;
                            page="pgpre"+i;
                            pageprem="pagper"+i;
                            var h;
                            var prempercent1;
                            
////                            if(ds.Tables[0].Rows[i].Prem_per1==null)
////                            {
////                                prempercent1="";
////                            }
////                            else
////                            {
////                                prempercent1=ds.Tables[0].Rows[i].Prem_per1
////                            }                           
                         if(ds.Tables[0].Rows[i].Premium1==null)
                            ds.Tables[0].Rows[i].Premium1="";
                               
                         if(showordisable=="1")
                         { 
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id="+premid+" value="+ds.Tables[0].Rows[i].Premium1+">";
                            Make_Row.appendChild(make_td);                        
                          
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input disabled class=\"btextsmallsize\" type=\"text\" id="+premper+" value=\"\">";
                            Make_Row.appendChild(make_td);
//////////////this is to bind the drop down for accepting the premium
                            make_td=document.createElement("td");
                            make_td.align="center";
                            str="<select disabled id="+preall+" class=\"dropdownforgrid\">";
                            str=str+"<option value=\"0\">Select</option>";
                            str=str+"<option value=\"1\">Yes</option>";
                            str=str+"<option value=\"2\">No</option>";
                            make_td.innerHTML=str;
                            Make_Row.appendChild(make_td);
                         }
                         else
                         {
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+premid+" value="+ds.Tables[0].Rows[i].Premium1+">";
                            Make_Row.appendChild(make_td);                        
                          
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input class=\"btextsmallsize\" type=\"text\" id="+premper+" value=\"\">";
                            Make_Row.appendChild(make_td);

                            make_td=document.createElement("td");
                            make_td.align="center";
                            str="<select id="+preall+" class=\"dropdownforgrid\">";
                            str=str+"<option value=\"0\">Select</option>";
                            str=str+"<option value=\"1\">Yes</option>";
                            str=str+"<option value=\"2\">No</option>";
                            make_td.innerHTML=str;
                            Make_Row.appendChild(make_td);
                         }
                            
////                        if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                        {    
////                            str=str+"</select></td><td><input class=\"btextsmallsize\" type=\"text\" disabled id="+premper+" value="+prempercent1+"></td><td><select disabled id="+prem1id+" class=\"dropdownforgrid\" onchange=\"return getpercenprem("+prem1id+","+i+",'"+namecode+"');\"  >";
////                        }
////                        else
////                        {
////                            str=str+"</select></td><td><input class=\"btextsmallsize\" type=\"text\" id="+premper+" value="+prempercent1+"></td><td><select id="+prem1id+" class=\"dropdownforgrid\" onchange=\"return getpercenprem("+prem1id+","+i+",'"+namecode+"');\"  >";
////                        }                             
////                            /////this is to bind the premium 2 drop down
////                              str=str+"<option value=\"0\" selected=\"true\">select</option>";
////                             for(k=0;k<=ds.Tables[2].Rows.length-1;k++)
////                                {
////                                ////////on click function is there to get the prem % on premium drop down change
////                                    if(ds.Tables[2].Rows[k].Premiumcode==ds.Tables[0].Rows[i].Premium2 && ds.Tables[0].Rows[i].Premium2!="0")
////                                    {
////                                        str=str+"  <option value="+ds.Tables[2].Rows[k].Premiumcode+" selected="+ds.Tables[0].Rows[i].Premium2+">"+ds.Tables[2].Rows[k].premiumname+"</option>"
////                                    }
////                                    else
////                                    {
////                                        str=str+"  <option value="+ds.Tables[2].Rows[k].Premiumcode+">"+ds.Tables[2].Rows[k].premiumname+"</option>"
////                                    }
////                                }
////                            var prempercentage2;
////                            if(ds.Tables[0].Rows[i].Prem_per2==null)
////                            {
////                                prempercentage2="";
////                            }
////                            else
////                            {
////                                prempercentage2=ds.Tables[0].Rows[i].Prem_per2
////                            }
////                            
////                            
////                        if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
////                        {
////                            str=str+"</select></td><td><input class=\"btextsmallsize\" type=\"text\" disabled id="+premper1+" value="+prempercentage2+"></td>"
////                            str=str+"<td><select id="+page+" class=\"dropdownforgrid\" disabled  >";
////                            /////this is to bind the premium 2 drop down
////                            str=str+"  <option value=\"0\" selected=\"true\">Select</option>";
////                             for(h=0;h<=ds.Tables[7].Rows.length-1;h++)
////                                {
////                                ////////on click function is there to get the prem % on premium drop down change
////                                    if(ds.Tables[7].Rows[h].pos_type_code==ds.Tables[0].Rows[i].Page_prem && ds.Tables[0].Rows[i].Page_prem!="0")
////                                    {
////                                        str=str+"  <option value="+ds.Tables[7].Rows[h].pos_type_code+" selected="+ds.Tables[0].Rows[i].Page_prem+">"+ds.Tables[7].Rows[h].pos_type+"</option>"
////                                    }
////                                    else
////                                    {
////                                        str=str+"  <option value="+ds.Tables[7].Rows[h].pos_type_code+">"+ds.Tables[7].Rows[h].pos_type+"</option>"
////                                    }
////                                }
////                                ////this is to bind the per for page premium
////                                if(ds.Tables[0].Rows[i].page_per==null)
////                                {
////                                  ds.Tables[0].Rows[i].page_per="";
////                                }
////                                str=str+"</select></td><td><input disabled class=\"btextsmallsize\" type=\"text\" id="+pageprem+" value="+ds.Tables[0].Rows[i].page_per+"></td>"

////                                ///////////////////////////////////////////////    
////                                str=str+"<td><select disabled id="+preall+" class=\"dropdownforgrid\">";
////                        }
////                        else
////                        {
////                            pagstr="sec";
////                            str=str+"</select></td><td><input class=\"btextsmallsize\" type=\"text\" id="+premper1+" value="+prempercentage2+"></td>"
////                            str=str+"<td><select id="+page+" class=\"dropdownforgrid\" onchange=\"return getpageprem("+page+","+i+",'"+pagstr+"');\"  >";
////                            /////this is to bind the premium 2 drop down
////                            str=str+"  <option value=\"0\" selected=\"true\">Select</option>";
////                            for(h=0;h<=ds.Tables[7].Rows.length-1;h++)
////                                {
////                                ////////on click function is there to get the prem % on premium drop down change
////                                     if(ds.Tables[7].Rows[h].pos_type_code==ds.Tables[0].Rows[i].Page_prem && ds.Tables[0].Rows[i].Page_prem!="0")
////                                    {
////                                        str=str+"  <option value="+ds.Tables[7].Rows[h].pos_type_code+" selected="+ds.Tables[0].Rows[i].Page_prem+">"+ds.Tables[7].Rows[h].pos_type+"</option>"
////                                    }
////                                    else
////                                    {
////                                        str=str+"  <option value="+ds.Tables[7].Rows[h].pos_type_code+">"+ds.Tables[7].Rows[h].pos_type+"</option>"
////                                    }
////                                }
////                                ////this is to bind the per for page premium
////                            if(ds.Tables[0].Rows[i].page_per==null)
////                            {
////                              ds.Tables[0].Rows[i].page_per="";
////                            }
////                            str=str+"</select></td><td><input disabled class=\"btextsmallsize\" type=\"text\" id="+pageprem+" value="+ds.Tables[0].Rows[i].page_per+"></td>"

////                            ///////////////////////////////////////////////    
////                            str=str+"<td><select id="+preall+" class=\"dropdownforgrid\">";
////                        }     
////                        
////                         //////////////this is to bind the drop down for accepting the premium

////                            str=str+"<option value=\"0\">Select</option>";
////                            str=str+"<option value=\"1\">Yes</option>";
////                            str=str+"<option value=\"2\">No</option>";
                            
                       if(showordisable=="1")
                        {    
////                            str=str+"</td></select><td><select disabled id="+adcat+" class=\"dropdownforgrid\">";
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input disabled class=\"dropdownforgrid\" type=\"text\" id="+adcat+" value='"+ds.Tables[0].Rows[i].Ad_cat+"'>";
                            Make_Row.appendChild(make_td);
                        }
                        else
                        {
////                            str=str+"</td></select><td><select id="+adcat+" class=\"dropdownforgrid\">"; 
                            make_td=document.createElement("td");
                            make_td.align="center";
                            make_td.innerHTML="<input  class=\"dropdownforgrid\" type=\"text\" id="+adcat+" value='"+ds.Tables[0].Rows[i].Ad_cat+"'>";
                            Make_Row.appendChild(make_td);   
                        }    
                        var o;
                            ///this loop is to bind the ad category
////                        str=str+"<option value=\"0\" selected=\"true\">select</option>";
////                        for(o=0;o<=ds.Tables[6].Rows.length-1;o++)
////                        {
////                            if(ds.Tables[6].Rows[o].adv_cat_code==ds.Tables[0].Rows[i].Ad_cat && ds.Tables[0].Rows[i].Ad_cat!="0")
////                            {
////                                str=str+"<option value="+ds.Tables[6].Rows[o].adv_cat_code+" selected="+ds.Tables[0].Rows[i].Ad_cat+">"+ds.Tables[6].Rows[o].adv_cat_name+"</option>";
////                            }
////                            else
////                            {
////                                str=str+"<option value="+ds.Tables[6].Rows[o].adv_cat_code+">"+ds.Tables[6].Rows[o].adv_cat_name+"</option>";
////                            }
////                        }
////                        str=str+"</select></td>";
                                
//////                        if(showordisable=="1" || ds.Tables[0].Rows[i].Insert_status=="billed" || ds.Tables[0].Rows[i].Insert_status=="publish")
//////                        {     
//////////                              str=str+"<td><select disabled id="+billstat+" class=\"dropdownforgrid\">";
//////                            make_td=document.createElement("td");
//////                            make_td.align="center";
//////                            str="<select disabled id="+billstat+" class=\"dropdownforgrid\">";
//////                        }
//////                        else
//////                        {
//////                            make_td=document.createElement("td");
//////                            make_td.align="center";
//////                            str="<select id="+billstat+" class=\"dropdownforgrid\">";                            
//////                        }
//////                                    /////////////this function is to bind the bill status dropdown
//////                                    
//////                        if(browser!="Microsoft Internet Explorer")
//////                        {
//////                            //loadXML('xml/billcycle.xml');

//////                             var c=0;                               
//////                             for(c=1;c<=xmlObj.childNodes[3].childNodes.length-1;c=c+4)
//////                             {
//////                                  str=str+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";
//////                                  if(xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue==ds.Tables[0].Rows[i].Bill_status)
//////                                  {
//////                                      str=str+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+" selected="+ds.Tables[0].Rows[i].Bill_status+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";                                                    
//////                                  }
//////                                  else
//////                                  {
//////                                     str=str+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";                                                    
//////                                  }
//////                                              
//////                             }
//////                        }
//////                        else
//////                        { 
//////                            var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
//////                            loadXML('xml/billcycle.xml');
//////                            var c=0;
//////                            for(c=0;c<=xmlObj.childNodes(1).childNodes.length-1;c++)
//////                            {
//////                                if(xmlObj.childNodes(1).childNodes(c+1).text==ds.Tables[0].Rows[i].Bill_status)
//////                                {
//////                                     str=str+"<option value="+xmlObj.childNodes(1).childNodes(c+1).text+" selected="+ds.Tables[0].Rows[i].Bill_status+">"+xmlObj.childNodes(1).childNodes(c).text+"</option>";                                        
//////                                }
//////                                else
//////                                {
//////                                     str=str+"<option value="+xmlObj.childNodes(1).childNodes(c+1).text+">"+xmlObj.childNodes(1).childNodes(c).text+"</option>";                                        
//////                                }
//////                                c=c+1;
//////                            } 
//////                        }

    if(browser!="Microsoft Internet Explorer")
    {
        
        if(dbill=="")
        {
         make_td=document.createElement("td");
          make_td.align="center";
          if(showordisable=="1")
                dbill=dbill+"<select id="+billstat+" disabled class=\"dropdownforgrid\">";
          else      
                  dbill=dbill+"<select id="+billstat+"  class=\"dropdownforgrid\">";

             /////////////this function is to bind the bill status dropdown
             
             var c=0;
             BILL_STATUS='';
               if(ds.Tables[0].Rows[i].Bill_status=="1")
                       dbill=dbill+"<option value='1' selected='1'>Daily</option>";
                    else
                        dbill=dbill+"<option value='1'>Daily</option>";
                     if(ds.Tables[0].Rows[i].Bill_status=="2")    
                        dbill=dbill+"<option value='2' selected='2'>Weekly</option>";
                     else
                        dbill=dbill+"<option value='2'>Weekly</option>";  
                     if(ds.Tables[0].Rows[i].Bill_status=="3")      
                        dbill=dbill+"<option value='3' selected='3'>Fortnight</option>";
                     else
                        dbill=dbill+"<option value='3'>Fortnight</option>";   
                     if(ds.Tables[0].Rows[i].Bill_status=="4")    
                         dbill=dbill+"<option value='4' selected='4'>Monthly</option>";
                     else
                         dbill=dbill+"<option value='4'>Monthly</option>";       
                     
                    BILL_STATUS=BILL_STATUS+"<option value=1>Daily</option>";
                    BILL_STATUS=BILL_STATUS+"<option value=2>Weekly</option>";
                    BILL_STATUS=BILL_STATUS+"<option value=3>Fortnight</option>";
                    BILL_STATUS=BILL_STATUS+"<option value=4>Monthly</option>";
//             for(c=1;c<=xmlObj.childNodes[3].childNodes.length-1;c=c+4)
//             {   
//                 dbill=dbill+"<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";
//                 BILL_STATUS = BILL_STATUS + "<option value="+xmlObj.childNodes[3].childNodes[c+2].childNodes[0].nodeValue+">"+xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue+"</option>";
//             }
             dbill=dbill+"</select>";
             make_td.innerHTML=dbill;
             Make_Row.appendChild(make_td); 
             //str=str+dbill;
         }
         else
         {
            // str=str+dbill.replace("bill"+dcou,billstat);          
             make_td=document.createElement("td");
            make_td.align="center";
            str=dbill.replace("bill"+dcou,billstat);  
            make_td.innerHTML=str;
            Make_Row.appendChild(make_td);
         }    
    }    
  else
        {        
            if(dbill=="")
            {
               if(xmlObj.childNodes(1)==null)
               {
                loadXML('xml/billcycle.xml');
               }
                 make_td=document.createElement("td");
                 make_td.align="center";
                    if(showordisable=="1")
                        dbill=dbill+"<select id="+billstat+" disabled class=\"dropdownforgrid\">";
                    else      
                          dbill=dbill+"<select id="+billstat+"  class=\"dropdownforgrid\">";
                 var c=0;
                 for(c=0;c<=xmlObj.childNodes(1).childNodes.length-1;c++)
                 {
                      dbill=dbill+"<option value="+xmlObj.childNodes(1).childNodes(c+1).text+">"+xmlObj.childNodes(1).childNodes(c).text+"</option>";
                      c=c+1;
                 }               
                      
                  dbill=dbill+"</select>";
                  //str=str+dbill;   
                  make_td.innerHTML=dbill;
                  Make_Row.appendChild(make_td); 
             }
             else
             {
                 // str=str+dbill.replace("bill"+dcou,billstat);             
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str=dbill.replace("bill"+dcou,billstat);  
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
              }    
               
         }

                      
                        str="";
                        if(showordisable=="1")
                        {
////                            str=str+"</select></td><td><select disabled id="+paid+" class=\"dropdownforgridsmall\" >";
                            make_td=document.createElement("td");
                            make_td.align="center";
                            str="<select disabled id="+paid+" class=\"dropdownforgridsmall\" >";
                        }
                        else
                        {
                            if(ds.Tables[8].Rows[0].Paid_permission=="0")
                            {
////                                str=str+"</select></td><td><select id="+paid+" disabled class=\"dropdownforgridsmall\" \">";//onchange=\"putpaidintoinsert("+paid+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\">";
                                make_td=document.createElement("td");
                                make_td.align="center";
                                str="<select id="+paid+" disabled class=\"dropdownforgridsmall\">";  
                            }
                            else
                            {
////                                str=str+"</select></td><td><select id="+paid+" class=\"dropdownforgridsmall\" \">";//onchange=\"putpaidintoinsert("+paid+","+inserts+","+ds.Tables[0].Rows[i].no_insert+");\">";                                    
                                 make_td=document.createElement("td");
                                make_td.align="center";
                                str="<select id="+paid+" class=\"dropdownforgridsmall\">"; 
                            }
                        }
                        if(ds.Tables[0].Rows[i].Pai_free_ins=="Y")
                        {
                            str=str+"<option value=\"Y\" selected="+ds.Tables[0].Rows[i].Pai_free_ins+">Yes</option>";
                        }
                        else
                        {
                            str=str+"<option value=\"Y\" >Yes</option>";
                        }
                        if(ds.Tables[0].Rows[i].Pai_free_ins=="N")
                        {
                            str=str+"<option value=\"N\" selected="+ds.Tables[0].Rows[i].Pai_free_ins+">No</option>";
                        }
                        else
                        {
                            str=str+"<option value=\"N\">No</option>";
                        }
                        str=str+"</select></td>";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td); 

//this is to upload the image

                    picfield="pic"+i;
                    str=str+"</select></td>";

                    solo="sol"+i;
                    gross="gro"+i;
                    if(showordisable=="1")
                    {
////                        str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" disabled id="+solo+"  value="+ds.Tables[0].Rows[i].Solo_rate+"></td>";
////                        str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" disabled id="+gross+"  value="+ds.Tables[0].Rows[i].Gross_rate+"></td>";
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input class=\"btextforgrid\" disabled type=\"text\" disabled id="+solo+"  value="+ds.Tables[0].Rows[i].Solo_rate+">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td); 
                         
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input class=\"btextforgrid\" disabled type=\"text\" disabled id="+gross+"  value="+ds.Tables[0].Rows[i].Gross_rate+">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td); 
                     }
                     else
                     {
////                        str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+solo+"  value="+ds.Tables[0].Rows[i].Solo_rate+"></td>";
////                        str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value="+ds.Tables[0].Rows[i].Gross_rate+"></td>";
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input class=\"btextforgrid\" disabled type=\"text\" disabled id="+solo+"  value="+ds.Tables[0].Rows[i].Solo_rate+">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td); 
                         
                        make_td=document.createElement("td");
                        make_td.align="center";
                        str="<input class=\"btextforgrid\" disabled type=\"text\" disabled id="+gross+"  value="+ds.Tables[0].Rows[i].Gross_rate+">";
                        make_td.innerHTML=str;
                        Make_Row.appendChild(make_td); 
//                                str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+solo+"  value="+ds.Tables[0].Rows[i].Solo_rate+"></td>";
//                                str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value="+ds.Tables[0].Rows[i].Gross_rate+"></td>";

                     }   
                             

                      billamt="ba"+i;
                      billrate="br"+i;
                                    
                      var grid_billamt=ds.Tables[0].Rows[i].Bill_Amt
                      var grid_billrate=ds.Tables[0].Rows[i].Bill_rate
                      if(grid_billamt==null)
                      {
                         grid_billamt="";
                      }
                      if(grid_billrate==null)
                      {
                         grid_billrate="";
                      }
                      make_td=document.createElement("td");
                      make_td.align="center";
                      str="<input disabled class=\"btextsmallsize\" type=\"text\" id="+billamt+"  value="+grid_billamt+">";
                      make_td.innerHTML=str;
                      Make_Row.appendChild(make_td); 
                      
                      make_td=document.createElement("td");
                      make_td.align="center";
                      str="<input disabled class=\"btextsmallsize\"  type=\"text\" id="+billrate+"  value="+grid_billrate+">";
                      make_td.innerHTML=str;
                      Make_Row.appendChild(make_td); 
                      
////                    str=str+"<td><input class=\"btextforinsertright\" disabled class=\"btextsmallsize\" onkeypress=\"javascript:return rateenter();\"  type=\"text\" id="+billamt+"  value="+grid_billamt+"></td>";
////                    str=str+"<td><input class=\"btextforinsertright\" disabled class=\"btextsmallsize\" onkeypress=\"javascript:return rateenter();\"  type=\"text\" id="+billrate+"  value="+grid_billrate+"></td>";
                                             
                    showid="sho"+i;
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input class=\"btextforgrid\" style=\"display:none;\" type=\"text\" id="+showid+"  value="+ds.Tables[0].Rows[i].insert_id+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                              
                    pkgcodegrid='hiddenpckcode'+i;
                    //This is a hidden field in the insertion grid which holds the Package Code for internal processing only
                            
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkgcodegrid+"' value="+ds.Tables[0].Rows[i].PACKAGE_CODE+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                            
                    var pkg_ins='pkg_ins'+i;
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+ds.Tables[0].Rows[i].INSERTS+">";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
                            
                    pkg_alias='pkg_alias'+i;
                    make_td=document.createElement("td");
                    make_td.align="center";
                    str="<input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_alias+"' value='"+ds.Tables[0].Rows[i].PKG_ALIAS+"'>";
                    make_td.innerHTML=str;
                    Make_Row.appendChild(make_td);
            
                    gridtab_vari.getElementsByTagName("tbody")[0].appendChild(Make_Row); 
////                    str=str+"<td><input class=\"btextforgrid\" style=\"display:none;\" type=\"text\" id="+showid+"  value="+ds.Tables[0].Rows[i].insert_id+"></td>";

////                    pkgcodegrid='hiddenpckcode'+i;
////                    //This is a hidden field in the insertion grid which holds the Package Code for internal processing only
////                    str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkgcodegrid+"' value="+ds.Tables[0].Rows[i].PACKAGE_CODE+"></td>";
////                    var pkg_ins='pkg_ins'+i;
////                    str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+ds.Tables[0].Rows[i].INSERTS+"></td>";
////                            
////                    pkg_alias='pkg_alias'+i;
////                    str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_alias+"' value='"+ds.Tables[0].Rows[i].PKG_ALIAS+"'></td>";
////            
////                    str=str+"</td></tr>";
                                                           
////                    if(objedition.options.length <=1)
////                    {
////                          objedition.options.length = 0; 
////                          objedition.options[0]=new Option("-Select-","0");
////                          if(ds.Tables[0].Rows[i].Edition!=undefined )
////                          {
////                               objedition.options[objedition.options.length] = new Option(ds.Tables[0].Rows[i].Edition,ds.Tables[0].Rows[i].Edition);
////                               objedition.options.length;
////                           }   
////                    }       
                  /*if(objedition.options.length >=1)
                        {
    //                          objedition.options.length = 0; 
    //                          objedition.options[0]=new Option("-Select-","0");
                              if(ds.Tables[0].Rows[i].Edition!=undefined )
                              {
                                   objedition.options[objedition.options.length] = new Option(ds.Tables[0].Rows[i].Edition,ds.Tables[0].Rows[i].Edition);
                                   objedition.options.length;
                               }   
                        }                */
            
            }
            
////           str= str + "</table></div>";
////           document.getElementById('tblinsert').innerHTML=str;
           for(i=0;i<=count;i++)
           {
                var height="hei"+i;
               var late="lat"+i;
               var repeat="rep"+i;
               var page="pagpos"+i;
               var pagstr="sec";
               var adcat="adcat"+i;
               var adsubcat="ads"+i;
               var premid="prem"+i;
                var id="Text" + i;
                var width="wid"+i;
                var  noofcol="nocol"+i;
                inserts="ins"+i;
                var insertval=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[i+1].cells[1].innerHTML;
                var height_vari=document.getElementById(height);
                var par1=(height_vari.parentNode).parentNode;
                if(browser!="Microsoft Internet Explorer")
       {
                  document.getElementById(height).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                  document.getElementById(width).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                  document.getElementById(noofcol).onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
            
                  document.getElementById(late).onchange=new Function("return checkdate(Form1."+late+");");
                  document.getElementById(repeat).onchange=new Function("return checkdate(Form1."+repeat+");");
                  document.getElementById(page).onchange="return getpageprem('"+page+"',"+i+",'"+pagstr+"');" ;
                  document.getElementById(id).onchange=new Function("return chkDateforGrid();");
                  document.getElementById(premid).onchange=new Function("getpercenprem('"+premid+"',"+i+",'"+namecode+"')");
       }
       else
       {
                par1.all[height].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                par1.all[width].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
                 par1.all[noofcol].onchange=new Function("return gettotalsize('"+height+"','"+width+"',"+i+",'"+inserts+"',"+insertval+",'"+noofcol+"');");
            
                par1.all[late].onchange=new Function("return checkdate(Form1."+late+");");
                par1.all[repeat].onchange=new Function("return checkdate(Form1."+repeat+");");
               par1.all[page].onchange="return getpageprem('"+page+"',"+i+",'"+pagstr+"');" ;
               par1.all[id].onchange=new Function("return chkDateforGrid();");
               par1.all[premid].onchange=new Function("getpercenprem('"+premid+"',"+i+",'"+namecode+"')");
         }
           }
             arrangeArrayItems();
            
       }
       ////        // add insertion
     /*   var objinsert=document.getElementById('drpinsertion');
        if(objinsert.options.length <=1)
        {
            objinsert.options.length = 0; 
            objinsert.options[0]=new Option("-Select-","0");
            for(var i=1;i<=document.getElementById('txtinsertion').value;i++)
            {
                objinsert.options[objinsert.options.length] = new Option(i,i);
                objinsert.options.length;
            }
        }*/
       
       }
         //add edition
////        var objpack=document.getElementById('drppackagecopy');

////        // add insertion
////        var objinsert=document.getElementById('drpinsertion');
////        if(objinsert.options.length <=1)
////        {
////            objinsert.options.length = 0; 
////            objinsert.options[0]=new Option("-Select-","0");
////            for(var i=1;i<=document.getElementById('txtinsertion').value;i++)
////            {
////                objinsert.options[objinsert.options.length] = new Option(i,i);
////                objinsert.options.length;
////            }
////        }

////}



//////////////this is the function for dateformat as the dateformat likewise the date will be shown if id==1and if it is 0 than will return the 
///////date in mm/dd/yyyy format

function savedateinto(dat,id)
{
var sadate=dat;
var setdate;
var dateformat=document.getElementById('hiddendateformat').value;
    if(id=="0")
    {
        if(sadate!="")
        {
                if(dateformat=="mm/dd/yyyy")
			    {
			    return setdate=sadate;
			    }
			    if(dateformat=="dd/mm/yyyy")
			    {
			        var txt1=sadate;
			        var txt2=txt1.split("/");
			        var dd=txt2[0];
			        var mm=txt2[1];
			        var yy=txt2[2];
			      return setdate=mm+'/'+dd+'/'+yy;
			    }
			     if(dateformat=="yyyy/mm/dd")
			    {
			        var txt1=sadate;
			        var txt2=txt1.split("/");
			        var yy=txt2[0];
			        var mm=txt2[1];
			        var dd=txt2[2];
			     return   setdate=mm+'/'+dd+'/'+yy;
			    
			    }
      }	
    }  
    if(id=="1")
    {
            var currdate=new Date(sadate);
			
			
			var dd=currdate.getDate();
			var mm=currdate.getMonth() + 1;
			var yyyy=currdate.getFullYear();
			if(mm.toString().length==1)
			    mm="0"+mm;
			if(dd.toString().length==1)
			    dd="0"+dd;    
			var currdate1=mm+'/'+dd+'/'+yyyy;
			var currda=dd+'/'+mm+'/'+yyyy;
			var curryear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			    return currdate1;
			
			}
			else if(dateformat=="dd/mm/yyyy")
			{
			    return currda;
			
			}
			if(dateformat=="yyyy/mm/dd")
			{
			    return curryear;
			
			}
    
    
    
    }


}

///////////////////////////////////////////////////////////////////////////////////////////
//this function is called to fill the ad s cat for grid on change of ad cat

function filladsubgrid(adcat,adsubcat)
{
         var len="bookdiv";
         var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
         var i;
         var compcode=document.getElementById('hiddencompcode').value;
         var adcategory=adcat.value;
         if(adcategory=="0")
         {
            alert("Please select the value");
            return false;
         }
         objadscat=adsubcat;
         //var adcategory=document.getElementById('drpadcategory').value;
         var agencytypecode=document.getElementById('hiddencattype').value
         Booking_Master_temp.getadsubcat(compcode,adcategory,agencytypecode,call_filladscat)

}
function call_filladscat(res)
{
    var ds=res.value;
    if(ds.Tables[1].Rows.length>0)
    {
        if(mainclick!="")
        {
            document.getElementById('txttradedisc').value=ds.Tables[1].Rows[0].Comm_Rate
            mainclick="";
        }        
    }
    else
    {
        mainclick="";
        document.getElementById('txttradedisc').value=gbtradedisc
    }
    objadscat.options.length = 0; 
    objadscat.options[0]=new Option("-Select-","0");
    //alert(pkgitem.options.length);
    objadscat.options.length = 1; 
    for (var i = 0 ; i < ds.Tables[0].Rows.length; ++i)
    {
        objadscat.options[objadscat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);        
        objadscat.options.length;       
    }
        /*
        //////////////////this is to bind the ad s cat  of grid on change of ad category
            if(document.getElementById('tblinsert').innerHTML!="")
            {
                       var len="bookdiv";
                        var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;  
                        var k;
                        var adsubcat;
                        var i=0;
     
                    for(k=0;k<y-1;k++)
                    {
           
                            while(document.getElementById("card"+i)==null)
                            {
                                i=i+savtotid;
                   
                            }
                           adsubcat="ads"+i;
                           var gridadscat=document.getElementById(adsubcat)
                            //alert(gridadscat.options.length);
                            gridadscat.options.length = 0; 
                            gridadscat.options[0]=new Option("-Select-","0");
        
                            gridadscat.options.length = 1; 
                            
                            for (var z = 0  ; z < ds.Tables[0].Rows.length; ++z)
                            {
                                gridadscat.options[gridadscat.options.length] = new Option(ds.Tables[0].Rows[z].Adv_Subcat_Name,ds.Tables[0].Rows[z].Adv_Subcat_Code);
            
                                gridadscat.options.length;
           
                            }
                            
                            i=parseInt(i)+1;
                     
                   }
                 
            
            } */
    
}
////////////////////this is the function to bind the ad s cat on change of ad cat from main form


    function filladsubcatmain()
    {
        var compcode=document.getElementById('hiddencompcode').value;
        var adcategory=document.getElementById('drpadcategory').value;
        if(adcategory=="0")
        {
            alert("Please select the value");
            mainclick="";
            document.getElementById('txttradedisc').value=gbtradedisc            
            return false;
         }
         var res=Booking_Master_temp.getRegClientCheck(adcategory);
         if(res.value!=null)
         {
            if(res.value=="Y")
            {
                if(document.getElementById('txtclient').value.lastIndexOf('(')<0)
                {
                    alert("For Category "+document.getElementById('drpadcategory').options[document.getElementById('drpadcategory').selectedIndex].text + ", You can take only Registered Client");
                    document.getElementById('txtclient').focus();
                    return false;
                }
            }
         }
         objadscat=document.getElementById('drpadsubcategory');
         var agencytypecode=document.getElementById('hiddencattype').value
         Booking_Master_temp.getadsubcat(compcode,adcategory,agencytypecode,call_filladscat);
         mainclick="0";
         //////this is to chk that whether grid is visible than on change of ad cat from main it effects into the grid also
         
        if(document.getElementById('tblinsert').innerHTML!="")
        {
              var len="bookdiv";
              var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;  
              var k;
              var adcat;
              var i=0;
            
              for(k=0;k<y-1;k++)
              {
                 
                  adcat="adcat"+i;
                  document.getElementById(adcat).value=adcategory;
                  i=parseInt(i)+1;
              }
        }       
         
        bindrategroupvode(adcategory);
        return false;
    }



/////this function is to chk the duplicacy of agency 

function chkagency()
{
    var agency="0";
    var product="0";
    var execname="0";
    var retainer="0";
       if(document.getElementById('txtproduct').value=="")
       {
        document.getElementById('drpbrand').options.length=0;
         document.getElementById('drpvarient').options.length=0;
        }
    var compcode=document.getElementById('hiddencompcode').value;
    if(document.activeElement.id=="txtagency")
    {
         agency=document.getElementById('txtagency').value;
    }    
    if(document.activeElement.id=="txtproduct")
    {
         product=document.getElementById('txtproduct').value;
    }  
    if(document.activeElement.id=="txtexecname")
    {
        execname=document.getElementById('txtexecname').value;
    }
      if(document.activeElement.id=="drpretainer")
        {
            retainer=document.getElementById('drpretainer').value;
        }
    Booking_Master_temp.chkagencycode(agency,compcode,product,execname,retainer,call_chkagency);
    return false;
}

function call_chkagency(res)
{
    var ds=res.value;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {}
        else
        {
            alert('This name doesnt exists');
            var idrem=document.activeElement.id;
            document.getElementById(idrem).value="";
            return false;
        }
    }
}

function disbledinsertion()
{
    if(document.getElementById('chktfn').checked==true)
    {
        if(document.getElementById('drppackagecopy').options.length==0)
        {
            alert("Please fill package");
            document.getElementById('drppackage').focus();
            return false;
        }
        else if(document.getElementById('txtrepeatingdate').value=="")
        {
            alert("Please fill repeating day");
            if(document.getElementById('txtrepeatingdate').disabled==false)
            {
                document.getElementById('txtrepeatingdate').focus();
            }
            return false;    
        }
        document.getElementById('txtinsertion').disabled=true;
        var tfnval=document.getElementById('hiddentfn').value;
        var repdate=document.getElementById('txtrepeatingdate').value;
    
        if(parseInt(repdate)>parseInt(tfnval))
        {
            alert("Repeating days cannot be greater than TFN");
            return false;
        }
    
        var totval=parseInt(tfnval)/parseInt(repdate)
        document.getElementById('txtinsertion').value=parseInt(totval);
        onInsertionChange();
    }
    else
    {
     //document.getElementById('txtinsertion').value="";
        document.getElementById('txtinsertion').disabled=false;
    }
}

function getpremper()
{       
    var len="bookdiv";
    document.getElementById('txtagreedrate').value="";
    document.getElementById('txtagreedamt').value="";
   // if(document.getElementById('drppageprem').value!="0")
    {
         Booking_Master_temp.getPremPage(document.getElementById('drppageprem').value,'0',getPremPage_callBack);
    }
      
//     var page=document.getElementById('drppageprem').value;
//     if(page=="0")
//     {
//          document.getElementById('txtpremper').value="";        
//          return false;
//     }
//        
//        var val="";
//        if(browser!="Microsoft Internet Explorer")
//        {
//            var  httpRequest =null;;
//            httpRequest= new XMLHttpRequest();
//            if (httpRequest.overrideMimeType) {
//            httpRequest.overrideMimeType('text/xml'); 
//            }
//            
//            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

//            httpRequest.open( "GET","getpremium.aspx?page="+page, false );
//            httpRequest.send('');
//            //alert(httpRequest.readyState);
//            if (httpRequest.readyState == 4) 
//            {
//                //alert(httpRequest.status);
//                if (httpRequest.status == 200) 
//                {
//                    val=httpRequest.responseText;
//                }
//                else 
//                {
//                    alert('There was a problem with the request.');
//                }
//            }
//        }
//        else
//        {
//            var xml = new ActiveXObject("Microsoft.XMLHTTP");
//            xml.Open( "GET","getpremium.aspx?page="+page, false );
//            xml.Send();
//            val=xml.responseText;
//        }
//        val=val.split("^");
//        val=val[0];
//        document.getElementById('txtpremper').value=val;
//        if(document.getElementById('tblinsert').innerHTML!="")
//        {
//             flagins="0";
//        }
}

function getPremPage_callBack(res)
{
    var len="bookdiv";
    var ds=res.value;
    document.getElementById('txtpremper').value="";
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
         {
            if(ds.Tables[0].Rows[0].page_no!=null)
            document.getElementById('txtpageno').value=ds.Tables[0].Rows[0].page_no;
            document.getElementById('txtpremper').value=ds.Tables[0].Rows[0].premium_charges;
         }
    }   
    if(document.getElementById('tblinsert').innerHTML!="")
    {
        //var y=parseInt(noofinsertlo)   
        var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
        var k;
        var colid;
        var p_no;
        var i=0;
        var pageprem_var=document.getElementById('drppageprem');
        var pageno_var=document.getElementById('txtpageno');
        for(k=0;k<y-1;k++)
        {
            colid="prem"+i;
            var colid_var=document.getElementById(colid);
            p_no="pagno"+i;
            if(drp_prem==colid_var.value || colid_var.value=='' || colid_var.value=="0")
            {
                 colid_var.value=pageprem_var.value;
                 document.getElementById(p_no).value=pageno_var.value;
            }
            i=parseInt(i)+1;
        }
        drp_prem=pageprem_var.value;
    }
}

function getpageamt()
{
    var len="bookdiv";
    document.getElementById('txtagreedrate').value="";
    document.getElementById('txtagreedamt').value="";
    if(document.getElementById('tblinsert').innerHTML!="")
    {
        //var y=parseInt(noofinsertlo)   
        var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
        var k;
        var colid;
        var i=0;
        var pagepos_var=document.getElementById('drppageposition');
        for(k=0;k<y-1;k++)
        {
            colid="pagpos"+i;
            document.getElementById(colid).value=pagepos_var.value
            i=parseInt(i)+1;
        }
    }
   
    var pagename=document.getElementById('drppageposition').value;
    var compcode=document.getElementById('hiddencompcode').value;
    if(pagename!="0")
    {
       Booking_Master_temp.getpageamount(pagename,compcode,call_getpageamt);
    }
    else
    {
       document.getElementById('txtpageamt').value="";
       
    }     
}

//get premium page position
function call_getpageamt(res)
{
    var ds=res.value;
    if(ds.Tables[0].Rows.length>0)
    {
        document.getElementById('txtpageamt').value=ds.Tables[0].Rows[0].Amount;     
        pgposprem=ds.Tables[0].Rows[0].Premium;
    }
    if(document.getElementById('tblinsert').innerHTML!="")
    {
         flagins="0";
    }
    

}

////this is the function cretaed when we select the ad sub cat from the iserts line than it will effect on its item lines
/////and also chk tahat whether taht package is cretaed 

function getvalueintoinserts(id,insval,no)
{

    var idval=id.value;
    var getint=id.id.split("ads");
    var z=getint[1];
    var adsubcat;
    var inserts;
    var tot=parseInt(fillinsert)/parseInt(document.getElementById('txtinsertion').value);
    var i=z;
    var k;
    var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
    if(z%noofinsertlo==0)
    {
         var x=parseInt(z)+parseInt(noofinsertlo);
         i=z;
         for (k=0;k<noofinsertlo;k++)
         {
            while(document.getElementById("card"+i)==null )
             {
                i=parseInt(i)+parseInt(totid);
             }
              adsubcat= "ads"+i;
              document.getElementById(adsubcat).value=idval;
              i=parseInt(i)+1;                    
         }       
     }
     else if(z>=noofinsertlo)
     {
            var x=parseInt(z)+parseInt(noofinsertlo);
            var modval=z%noofinsertlo;
            var totmod=parseInt(z)-parseInt(modval);
            i=totmod;
            for(k=0;k<noofinsertlo;k++)
            {
                while(document.getElementById("card"+i)==null )
                 {
                    i=parseInt(i)+parseInt(totid);
                 }
         
                 adsubcat= "ads"+i;
                 document.getElementById(adsubcat).value=idval;
                 i=parseInt(i)+1;
            }
        
        }
        else if(z<noofinsertlo)
        {
            var modval=noofinsertlo%z;
            var totmod=parseInt(z)-parseInt(modval);
            i=totmod;
            for(k=0;k<noofinsertlo;k++)
            {
                while(document.getElementById("card"+i)==null )
                 {
                    i=parseInt(i)+parseInt(totid);
                 }
          
                adsubcat= "ads"+i;
                document.getElementById(adsubcat).value=idval;
                i=parseInt(i)+1;
            }        
        }
    
}

///this is to get the gross amount as the user fill thw width
function getgrossamt(id,insval,no)
{
    var idval=id.value;
    var gross;
    var agreed;
    var totarea;    
    var getint=id.split("wid");
    var z=getint[1];
    var paid;
    var inserts;
    var tot=parseInt(fillinsert)/parseInt(document.getElementById('txtinsertion').value);
    var i;
    var i=z;
    var k;
    var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
    if(z%noofinsert==0)
    {
        var x=parseInt(z)+parseInt(noofinsert);
        for (k=z;k<x;k++)
        {
             while(document.getElementById("card"+i)==null && i<x)
             {
                  i=parseInt(i)+parseInt(totid);
             }
             if(i>=x)
             {
                 break;
             }
            agreed="agr"+i;
            gross="gro"+i;
            totarea="siz"+i;
            var totgross=parseFloat(document.getElementById(totarea).value)*parseFloat(document.getElementById(agreed).value)
            document.getElementById(gross).value=totgross.toFixed(2);
            i=parseInt(i)+1;
         }       
     }
     else if(z>=noofinsert)
     {
            var x=parseInt(z)+parseInt(noofinsert);
            var modval=z%noofinsert;
            var totmod=parseInt(z)-parseInt(modval);
            i=totmod;
            var tomax=parseInt(totmod)+parseInt(noofinsert);
            for(k=totmod;k<tomax;k++)
            {
                while(document.getElementById("card"+i)==null && i<tomax)
                 {
                    i=parseInt(i)+parseInt(totid);
                 }
                 
                 if(i>=tomax)
                 {
                    break;
                 }
               agreed="agr"+i;
               gross="gro"+i;
               totarea="siz"+i;
               var totgross=parseFloat(document.getElementById(totarea).value)*parseFloat(document.getElementById(agreed).value)
               document.getElementById(gross).value=totgross.toFixed(2);
               i=parseInt(i)+1;
            }
        
        }
        else if(z<noofinsert)
        {
            i=0;
            for(k=0;k<noofinsert;k++)
            {
                while(document.getElementById("card"+i)==null && i<noofinsert)
                {
                    i=parseInt(i)+parseInt(totid);
                }
                if(i>=noofinsert)
                {
                    break;
                }
                            
                agreed="agr"+i;
                gross="gro"+i;
                totarea="siz"+i;
                var totgross=parseFloat(document.getElementById(totarea).value)*parseFloat(document.getElementById(agreed).value)
                document.getElementById(gross).value=totgross.toFixed(2);
                i=parseInt(i)+1;
            }
        
        }
}




///// this is to fill the color into the inserts line

function getvalueintoinsertsforcolor(id,insval,no)
{
    var idval=id.value;
    var colid;
    var getint=id.id.split("col");
    var z=getint[1];
    var adsubcat;
    var inserts;
    var tot=parseInt(fillinsert)/parseInt(document.getElementById('txtinsertion').value);
    var i=0;
    var k;
    var i=z;
    var k;
    var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
//    
   
        if(z%noofinsertlo==0)
        {
                 var x=parseInt(z)+parseInt(noofinsertlo);
                i=z;
                for (k=0;k<noofinsertlo;k++)
                {
                
                        while(document.getElementById("card"+i)==null )
                         {
                            i=parseInt(i)+parseInt(totid);
       
                         }
//                         if(i>=noofinsertlo)
//                         {
//                         break;
//                         }
               
                
                        colid="col"+i;
                        document.getElementById(colid).value=idval;
                        i=parseInt(i)+1;
                    
                }       
        }
        else if(z>=noofinsertlo)
        {
             var x=parseInt(z)+parseInt(noofinsertlo);
              var modval=z%noofinsertlo;
              var totmod=parseInt(z)-parseInt(modval);
              i=totmod;
//            var tomax=parseInt(totmod)+parseInt(noofinsertlo);
               
              
                
            for(k=0;k<noofinsertlo;k++)
            {
                        while(document.getElementById("card"+i)==null )
                         {
                            i=parseInt(i)+parseInt(totid);
       
                         }
//                         if(i>=tomax)
//                         {
//                         break;
//                         }
                         
                colid="col"+i;
                document.getElementById(colid).value=idval;
                 i=parseInt(i)+1;
            }
        
        }
        else if(z<noofinsertlo)
        {
             var modval=noofinsertlo%z;
             var totmod=parseInt(z)-parseInt(modval);
             i=totmod;
           
         
             for(k=0;k<noofinsertlo;k++)
            {
                while(document.getElementById("card"+i)==null )
                         {
                            i=parseInt(i)+parseInt(totid);
       
                         }
//                         if(i>=noofinsertlo)
//                         {
//                         break;
//                         }
                         
               colid="col"+i;
                document.getElementById(colid).value=idval;
                 i=parseInt(i)+1;
            }
        
        }

}

///this is to chk whether the value selected in the grid has a valid package or not

function checkadsubcat(val)
{
                    var adtype="DI0";
        var color = document.getElementById('drpcolor').value;
        var adcat = document.getElementById('drpadcategory').value;
        var adsucat = document.getElementById(val).value;
        var currency = document.getElementById('drpcurrency').value;
        var ratecode = document.getElementById('txtratecode').value;
        var package1 = document.getElementById('drppackage').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        var selecdate;
        
        
        if(document.getElementById('txtdummydate').value!="")
        {
                if(dateformat=="mm/dd/yyyy")
			    {
			    selecdate=document.getElementById('txtdummydate').value;
			    }
			    if(dateformat=="dd/mm/yyyy")
			    {
			        var txt1=document.getElementById('txtdummydate').value;
			        var txt2=txt1.split("/");
			        var dd=txt2[0];
			        var mm=txt2[1];
			        var yy=txt2[2];
			       selecdate=mm+'/'+dd+'/'+yy;
			    }
			     if(dateformat=="yyyy/mm/dd")
			    {
			        var txt1=document.getElementById('txtdummydate').value;
			        var txt2=txt1.split("/");
			        var yy=txt2[0];
			        var mm=txt2[1];
			        var dd=txt2[2];
			        selecdate=mm+'/'+dd+'/'+yy;
			    
			    }
      }	
      else
      {
        selecdate="";
      }
      
      var clientname=document.getElementById('txtclient').value;
        var client_split;
        if(clientname.indexOf("(")>=0)
        {
            clientname=clientname.split("(");
            client_split=clientname[1];
            client_split=client_split.replace(")","");
            clientname=client_split;

        }
      
      Booking_Master_temp.getratevalue(adtype, color, adcat, adsucat, currency, ratecode, package1, selecdate, document.getElementById('hiddencompcode').value,document.getElementById('drpuom').value,clientname,call_checkadsubcat);		    


}

function call_checkadsubcat(res)
{
var ds=res.value;
var flagrate;
if(ds.Tables[0].Rows.length>0)
    {
    flagrate="1";
    return flagrate;
    }
    else
    {
     flagrate="0";
    return flagrate;
    }

}

//*6Aug* Get retainer name
function showretainervalue()
{    
 if(document.getElementById('lstretainer').value=="0")
    {
          alert("Please Select Retainer");
                return false;
    }
    document.getElementById('drpretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")";
    document.getElementById('txtaddagencycommrateamt').value="";
    document.getElementById('txtaddagencycommrate').value="";
    document.getElementById('lstretainer').options.length=0
    document.getElementById("divretainer").style.display="none";       
        if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0")
        {
            document.getElementById('txtRetainercomm').value="";
            var retain_name=document.getElementById('drpretainer').value.split('(');
            var retain_code=retain_name[1].replace(')','');
            var ds_ret=Booking_Master_temp.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
            
            if(ds_ret.value==null)
                return false;
               
            if(ds_ret.value.Tables[0].Rows.length>0)
            {
                document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                document.getElementById('txtRetainercomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
                else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
            }    
               
        }
        changediv();
    return false;
   
}


////////////////this function is called when we open the list box of agency than on mouse click it get the agency

function insertagency()
{
    if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
            alert("Please select the client");
            return false;
        }
        document.getElementById("divclient").style.display="none";
        var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
     
        var page=document.getElementById('lstclient').value;
       
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
             xml.Send();
             id=xml.responseText;
        }
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var namecode=split[0];
         var add=split[1];

        
        document.getElementById('txtclient').value=namecode;
      
         
        if(document.getElementById('hiddensavemod').value=="0")
        {
            document.getElementById('txtclientadd').value=add;        
            document.getElementById('txtclientadd').focus();
        }
         bind_agen_bill();
        //document.getElementById('txtagencyaddress').focus();
        
        return false;
    }
    else if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0" || document.getElementById('hiddensavemod').value=="01")
    {
        alert("Please select the agency code");
        return false;
    }
        document.getElementById("div1").style.display="none";
        var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstagency').value;
        document.getElementById('hiddenagency').value=page;
        agencycodeglo=page;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {          
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
             xml.Send();
             id=xml.responseText;
        }
          if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd=split[1];
                
        document.getElementById('txtagency').value=nameagen;
        
        if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
        {
              document.getElementById('txtagencyaddress').value=agenadd;
                
              document.getElementById('txtclient').focus();
              Booking_Master_temp.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
        }
        return false;
    }
    ///////////////for product
    
    else if(document.activeElement.id=="lstproduct")
    {
        if(document.getElementById('lstproduct').value=="0")
        {
            alert("Please select the product");
            return false;
        }
        document.getElementById("divproduct").style.display="none";
        var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address and if 2 than its for product
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstproduct').value;
        //agencycodeglo=page;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
             if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
        }
        else
        {
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
             xml.Send();
             id=xml.responseText;
        }
         
          if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         
        
        document.getElementById('txtproduct').value=id;
        
        
        document.getElementById('drpbrand').focus();
        Booking_Master_temp.getbrand(page,document.getElementById('hiddencompcode').value,call_bindproduct);
        return false;
    }
    ///this is for exec name
    else if(document.activeElement.id=="lstexec")
    {
     if(document.getElementById('lstexec').value=="0")
        {
        alert("Please select the executive");
        return false;
        }
        document.getElementById("divexec").style.display="none";
           var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address and if 2 than its for product and 3 for exec
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstexec').value;
        //agencycodeglo=page;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
             xml.Send();
             id=xml.responseText;
        }
         
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
        document.getElementById('txtexecname').value=id;
        
        
        document.getElementById('txtexeczone').focus();
        Booking_Master_temp.getexeczone(page,document.getElementById('hiddencompcode').value,call_bindexeczone);
        return false;
    }

}


function getboxno()
{
    var branchname=document.getElementById('txtbranch').value;
    branchname=branchname.substring(0,2)
    // var branchname=document.getElementById('hiddenbranch').value;
    //branchname=branchname.substring(0,2)
    var branch=document.getElementById('drpboxcode').value;
    
    if(branch=="0" && boxpercen!="")
    {
          
//document.getElementById('txtbillamt').value=parseFloat(amtbill)-(parseFloat(amtbill)*parseFloat(boxpercen))/100
 document.getElementById('txtboxno').value="";              

    }
    
    if(branch!="0")
    {
        Booking_Master_temp.getboxnovalue(document.getElementById('hiddencompcode').value,branchname,branch,call_getvalbox);
    }
    return false;

}
function call_getvalbox(res)
{
    var ds=res.value;
    var count="0";
    var branchname=document.getElementById('txtbranch').value;
     document.getElementById('txtgrossamt').value="";
    branchname=branchname.substring(0,2)
    if(ds.Tables[0].Rows.length>0 && ds.Tables[0].Rows[0].boxno!=null && ds.Tables[0].Rows[0].boxno!="")
    {
        var boxval=ds.Tables[0].Rows[0].boxno;
        var cou=parseInt(boxval);
        cou++;
        document.getElementById('txtboxno').value=branchname+cou;
        document.getElementById('hiddenboxno').value=branchname+cou;
        //boxgamt=globalgross;
            //boxbill=globalbill;
    
    }
    else
    {
        document.getElementById('txtboxno').value=branchname+count;
        document.getElementById('hiddenboxno').value=branchname+count;
    }
   
   
        
//            var amtgross=document.getElementById('txtgrossamt').value
//            var amtbill=document.getElementById('txtbillamt').value
//            var per=ds.Tables[1].Rows[0].Box_Charges_Native;
//            perbox=ds.Tables[1].Rows[0].Box_Charges_Native;
//            perboxtype=ds.Tables[1].Rows[0].Box_Charges_Type;
//           // document.getElementById('txtgrossamt').value=parseFloat(amtgross)+(parseFloat(amtgross)*parseFloat(per))/100
//           // document.getElementById('txtbillamt').value=parseFloat(amtbill)+(parseFloat(amtbill)*parseFloat(per))/100
//           
//            if(document.getElementById('txtgrossamt').value=="NaN")
//            {
//                document.getElementById('txtgrossamt').value="";
//            }
//             if(document.getElementById('txtbillamt').value=="NaN")
//            {
//                document.getElementById('txtbillamt').value="";
//            }
            
       
  
    
    
     boxpercen=ds.Tables[1].Rows[0].Box_Charges_Native;
    document.getElementById('hiddenboxchrgtype').value=ds.Tables[1].Rows[0].Box_Charges_Type;
    

}





function chkrodate()
{
    if(document.getElementById('txtrono').value!="")
    {
        if(document.getElementById('txtrodate').value=="")
        {
            alert("Please fill ro date");
            document.getElementById('txtrodate').focus();
            return false;
            
        }
       
    
    }


}

////this is the function to get the billable area on change of bill height

function getbiilablearea()
{
    if(document.getElementById('txtbillwidth').value=="")
    {
        alert("Please fill bill width");
        document.getElementById('txtbillwidth').focus();
        return false;
        
    }
    
    else if(document.getElementById('txtbillwidth').value=="" || document.getElementById('txtbillheight').value=="")
    {
        document.getElementById('txtbillwidth').value=document.getElementById('txtadsize1').value
        
        if(document.getElementById('txtadsize2').value!="")
        {
            document.getElementById('txtbillheight').value=document.getElementById('txtadsize2').value
        }
        else
        {
            document.getElementById('txtbillheight').value=document.getElementById('txtcolum').value
        }
    
    }
    else if(parseFloat(document.getElementById('txtbillwidth').value)==0 || parseFloat(document.getElementById('txtbillheight').value)==0 )
    {
        alert("0 is not accepted");
        var idrem=document.activeElement.id;       
        return false;
    
    }
    var value=chkamount('txtbillwidth');
    if(value=="f")
    {
        return false;
    }
    var value=chkamount('txtbillheight');
    if(value=="f")
    {
        return false;
    }
   
    var billwidth=document.getElementById('txtbillwidth').value;
    var billhei=document.getElementById('txtbillheight').value;
    var totbill=parseFloat(billwidth)*parseFloat(billhei);
    txtbillarea=totbill;
    
    ///////////this is to fill the disc ,disc per,
    
    var totarea=parseFloat(document.getElementById('txtbillwidth').value)*parseFloat(document.getElementById('txtbillheight').value);;
    var toadarea=parseFloat(document.getElementById('txttotalarea').value);
  /*  var agrrrate=parseFloat(document.getElementById('txtagreedrate').value);
   
    document.getElementById('txtagreedamt').value=(totarea*agrrrate).toFixed(2);
    var agreeamou=parseFloat(document.getElementById('txtagreedamt').value);
    var cardrate=parseFloat(document.getElementById('txtcardrate').value);
    
    document.getElementById('txtagreedrate').value=(agreeamou/totarea).toFixed(2);
    var agrrate=parseFloat(document.getElementById('txtagreedrate').value);
    var disrate=document.getElementById('txtdiscount').value=(cardrate-agrrate).toFixed(2);
    
    var tot=(disrate/cardrate)*100;
    document.getElementById('txtdiscpre').value=tot.toFixed(2);*/
    if( document.getElementById('tblinsert').innerHTML!="")
    {    
        var hei=document.getElementById('txtbillheight').value
        var wid=document.getElementById('txtbillwidth').value     
        getpageareaintogrid(hei,wid);
    }    

}

function chkpckforcurr()
{
     if(document.getElementById('hiddensavemod').value=="0")
    {
        if(document.getElementById('drppackage').value=="0" && document.getElementById('txtratecode').value!="0")
        {
            alert("Please select the package");
            document.getElementById('txtratecode').value="0"
            return false;
        }
        if(document.getElementById('txtadsize1').value=="" && document.getElementById('txtratecode').value!="0")
        {
            alert("Please select the Height");
            document.getElementById('txtratecode').value="0"
            return false;
        }
        if(document.getElementById('txtbillheight').value=="" && document.getElementById('txtratecode').value!="0")
        {
            alert("Please select the width ");
            document.getElementById('txtratecode').value="0"
            return false;
        }
        if(document.getElementById('drppageprem').value=="0" && document.getElementById('txtratecode').value!="0")
        {
            alert("Please select the page Premium");
            document.getElementById('txtratecode').value="0"
            return false;
        }
        if(document.getElementById('drppageposition').value=="0" && document.getElementById('txtratecode').value!="0")
        {
            alert("Please select the Position premium ");
            document.getElementById('txtratecode').value="0"
            return false;

        }
        if(document.getElementById('txtratecode').value=="0")
        {
            alert("Please select rate code");
            document.getElementById('drpcurrency').value=document.getElementById('hiddencurrency').value;
            return false;    
        }

            //////////////this code is to split the code as well as ites description 
    
         var objpack=document.getElementById('drppackagecopy');
         var temp="";
         var tempcode="";
         var tempval="";
         var tempvalcode="";
         var desc="";
         var codepck="";
         var i=objpack.options.length;
         var j;

             for(j=0;j<i;j++)
             {
                 if(parseInt(i)>0)
                 {
                     tempval=objpack[j].value;
                     //tempvalcode=objpack[j].value;
                     if(temp!="")
                     {
                         temp=tempval.split("@");
                         tempvalcode=temp[0];
                         tempcode=temp[1];
                         codepck=tempvalcode+","+codepck;
                         desc=tempcode+","+desc;
                         
                         
                     }
                     else
                     {
                         temp=tempval.split("@");
                         tempvalcode=temp[0];
                         tempcode=temp[1];
                         codepck=tempvalcode;
                         desc=tempcode;
                    }
                }
                                
           }
    
    //////////////////////////////////////////////////////////////////


var adtype="DI0";
var color = document.getElementById('drpcolor').value;
var adcat = document.getElementById('drpadcategory').value;
var adsucat = document.getElementById('drpadsubcategory').value;
var adcat3=document.getElementById('drpadcat3').value;
var adcat4=document.getElementById('drpadcat4').value;
var adcat4=document.getElementById('drpadcat5').value;
var currency = document.getElementById('drpcurrency').value;
var ratecode = document.getElementById('txtratecode').value;
var package1 = codepck;
var dateformat=document.getElementById('hiddendateformat').value;
var selecdate;
        if(document.getElementById('txtdummydate').value!="")
        {
                if(dateformat=="mm/dd/yyyy")
			    {
			    selecdate=document.getElementById('txtdummydate').value;
			    }
			    if(dateformat=="dd/mm/yyyy")
			    {
			        var txt1=document.getElementById('txtdummydate').value;
			        var txt2=txt1.split("/");
			        var dd=txt2[0];
			        var mm=txt2[1];
			        var yy=txt2[2];
			       selecdate=mm+'/'+dd+'/'+yy;
			    }
			     if(dateformat=="yyyy/mm/dd")
			    {
			        var txt1=document.getElementById('txtdummydate').value;
			        var txt2=txt1.split("/");
			        var yy=txt2[0];
			        var mm=txt2[1];
			        var dd=txt2[2];
			        selecdate=mm+'/'+dd+'/'+yy;
			    
			    }
      }	
      else
      {
        selecdate="";
      }
      
        var clientname=document.getElementById('txtclient').value;
var client_split;
if(clientname.indexOf("(")>=0)
{
    clientname=clientname.split("(");
    client_split=clientname[1];
    client_split=client_split.replace(")","");
    clientname=client_split;

}
      
      Booking_Master_temp.getratevalue(adtype, color, adcat, adsucat, currency, ratecode, package1, selecdate, document.getElementById('hiddencompcode').value,document.getElementById('drpuom').value,clientname,call_chkpckforcurr);		    
    }


}

function call_chkpckforcurr(res)
{
    var ds=res.value;
    if(ds.Tables[0]==undefined)
    {
        alert("Package is not valid");
        document.getElementById('txtratecode').value="0";
    document.getElementById('txtcardrate').value="";
    document.getElementById('txtcardamt').value="";
        return false;
    
    }
    if(ds.Tables[0].Rows.length>0)
    {}
    else
    {
    alert("Package is not valid");
    document.getElementById('txtratecode').value="0";
    document.getElementById('txtcardrate').value="";
    document.getElementById('txtcardamt').value="";
    return false;
    }


}

function LTrim( value )
 {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) {
	
	return LTrim(RTrim(value));
	
}

function chkamount(e)
{
var flag="";
//return allamount121(e);
e=document.getElementById(e);//.value;
//alert(e);
//alert(e.value);
//var fld=e.value;
var fld=e.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			//return true;
			//checkpackagerate();
			flag="t";
			return flag;
			}
			else
			{
			alert("Input Error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			flag="f";
			//e.id.focus();
			return flag;
			}
			}
			
			}
			
			function chkamountgrid(e)
{
//return allamount121(e);
//e=document.getElementById(e);//.value;
//alert(e);
//alert(e.value);
//var fld=e.value;
var fld=e.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			return true;
			//checkpackagerate();
			}
			else
			{
			alert("Input Error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			//e.id.focus();
			return false;
			}
			}
			
			}
			
			
			
	function getbillzero()
	{
	   if(document.getElementById('txtbillamt').value!="")
	   {
	       if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")  
	       {
	           document.getElementById('txtbillamt').value="";
	           return false;
	        }
	    }
	}
			
			
			/////////////update into booking child table
			
				function modifyinsertion()
			{
			
			var len="bookdiv";
    var insertno;
    var premid;
   var premper;
   var colid;
   var height;
   var width;
   var size;
   var late;
   //var uomid;
   //var adtypid;
   var cardid;
   var editid;
   var solorate;
   var premper1;
   var prem1id;
   var namecode;
   var inserts;
   var pagepost;
   var preall;
   var adcat;
   var adsubcat;
   var matsta;
   var filename;
   var discrate;
   var insertsta;
   var billstat;
   var id;
   var repeat;
   var i=0;
   var paid;
   var agrred;
   var solo;
   var gross;
   var showid;
    var pageno_inserts;
      var  remark_inserts;
   var page;
   var pageprem;
   var billamt;
   var billrate;
   var compcode=document.getElementById('hiddencompcode').value;
   var userid =document.getElementById('hiddenuserid').value;
   var cioid=document.getElementById('txtciobookid').value;
 //var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
  var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
  var y=parseInt(noofinsert)   
 var k;
 
    for(k=0;k<y;k++)
    {
       
       while(document.getElementById("card"+i)==null)
                    {
                        i=i+savtotid;
               
                    }
             
       showid="sho"+i; 
       id="Text" + i;
        editid="edit"+i;
        premid="prem"+i;
        prem1id="premone"+i;
        colid="col"+i;
        height="hei"+i;
        width="wid"+i;
        size="siz"+i;
        pagepost="pagpos"+i;
        namecode="one";
        premper="premper"+i;
        premper1="premperone"+i;
        //adtypid="adtyp"+i;
        namecode="two";
        preall="preall"+i;
        adcat="adcat"+i;
        late="lat"+i;
        matsta="mat"+i;
         cardid="card"+i;   
         filename="fil"+i;
         discrate="disrat"+i;
        insertsta="inssta"+i;
        billstat="bill"+i;
        adsubcat="ads"+i;
        repeat="rep"+i;
        insertno="ins"+i;
        paid="pai"+i
        agrred="agr"+i;
        solo="sol"+i;
        gross="gro"+i;
         pageno_inserts="pagno"+i;;
        remark_inserts="rem"+i;
        page="pgpre"+i;
        pageprem="pagper"+i;
        billamt="ba"+i;
        billrate="br"+i;
        var insernum=document.getElementById(insertno).innerHTML;
        var insertdate=document.getElementById(id).value;
        var edition=document.getElementById(editid).value;
        var premium1=document.getElementById(premid).value;
        var premium2=document.getElementById(prem1id).value;
        var height=document.getElementById(height).value;
        var width=document.getElementById(width).value;
        var totalsize=document.getElementById(size).value;
        var pagepost=document.getElementById(pagepost).value;
        var color=document.getElementById(colid).value;
        var premper11=document.getElementById(premper).value;
        var premper2=document.getElementById(premper1).value;
        var premallow=document.getElementById(preall).value;
        var adcategory=document.getElementById(adcat).value;
        var latestdate=document.getElementById(late).value;
        var material=document.getElementById(matsta).value;
        var cardrate=document.getElementById(cardid).value;
        var filename=document.getElementById(filename).value;
        var discrate=document.getElementById(discrate).value;
        var insertstatus=document.getElementById(insertsta).value;
        var billstatus=document.getElementById(billstat).value;
        var adsubcat=document.getElementById(adsubcat).value;
        var repdate=document.getElementById(repeat).value;
        var paidins=document.getElementById(paid).value;
        var insagreedrate=document.getElementById(agrred).value;
        var inssolo=document.getElementById(solo).value;
        var grossrate=document.getElementById(gross).value;
         var insert_pageno=document.getElementById(pageno_inserts).value;
        var insert_remark=document.getElementById(remark_inserts).value;
         var page_code=document.getElementById(page).value;
        var page_per=document.getElementById(pageprem).value;
        var bill_amt=document.getElementById(billamt).value;
        var bill_rate=document.getElementById(billrate).value;
        var insert_id="sho"+i;
          var insertid='0';
        if(document.getElementById(insert_id)!=null)
            insertid=document.getElementById(insert_id).value;
        //Booking_Master_temp.modifygridinsert(insertdate,edition,premium1,premium2,premallow,adcategory,latestdate,material,cardrate,filename,discrate,insertstatus,billstatus,adsubcat,compcode,userid,cioid,height,width,totalsize,pagepost,premper11,premper2,color,repdate,insernum,paidins,insagreedrate,inssolo,grossrate,modid);
        var oldbillno='';
        var oldbilldate='';
        oldbillno=document.getElementById('hiddenbillNo').value;
        Booking_Master_temp.modifygridinsert(insertdate,edition,premium1,premium2,premallow,adcategory,latestdate,material,cardrate,filename,discrate,insertstatus,billstatus,adsubcat,compcode,userid,cioid,height,width,totalsize,pagepost,premper11,premper2,color,repdate,insernum,paidins,insagreedrate,inssolo,grossrate,insert_pageno,insert_remark,page_code,page_per,bill_amt,bill_rate,insertid,oldbillno,oldbilldate);
        i=i+1;
    }
    
        if(document.getElementById('hiddensavemod').value=="0")
        {
            document.getElementById('tblinsert').innerHTML="" 
            document.getElementById('tblrate').style.display="none";
		    document.getElementById('tblbill').style.display="none";
		    //document.getElementById('tblsize').style.display="none";
		    document.getElementById('addetails').style.display="none";
		    document.getElementById('pagedetail').style.display="none";
		    document.getElementById('tblpackage').style.display="none";   
		    document.getElementById('tbbox').style.display="none";
		    document.getElementById('txtciobookid').value="";
		    document.getElementById('LinkButton1').disabled=true;
		    document.getElementById('LinkButton2').disabled=true;
		    document.getElementById('LinkButton3').disabled=true;
		    document.getElementById('LinkButton4').disabled=true;
		    document.getElementById('LinkButton5').disabled=true;
		    document.getElementById('LinkButton6').disabled=true;
		    document.getElementById('LinkButton7').disabled=true;
		 }   
    
    return false;
			
			
			}
			
		////////////////this is the function to open the div for deal div
			
		function showdealvalue()
		{
		
		    if(document.getElementById('drpscheme').value!="")
		    {
		        alert("Scheme or contract can be choosen");
		        return false;
		    }
		    var dealtype=document.getElementById('hiddentype').value
            var agency=document.getElementById('txtagency').value
            var agencyarr=agency.split("(");
            var agencysplit=agencyarr[1];
            agencysplit=agencysplit.replace(")","");
            var subagency=document.getElementById('drpagscode').value;
            var client=document.getElementById('txtclient').value;
            var clientarr=client.split("(");
            var clientsplit=clientarr[1];
            if(clientsplit!=undefined)
            {
                clientsplit=clientsplit.replace(")","");
            }
            else
            {
                clientsplit="0";
            }
            var bookingdate=document.getElementById('txtdummydate').value;
            var color=document.getElementById('drpcolor').value;
            var curr=document.getElementById('drpcurrency').value;
            var adcat=document.getElementById('drpadcategory').value;
            var compcode=document.getElementById('hiddencompcode').value            
             
            var product=document.getElementById('txtproduct').value;
            var clientarr=product.split("(");
            var prod=clientarr[1];
            if(prod!=undefined)
            {
                prod=prod.replace(")","");
            }
            else
            {
                prod="0";
            }
            var col=document.getElementById('drpcolor').value
            var adtype="DI0";
            //var pkg_code=document.getElementById('drpcolor').value
            
            var objpack=document.getElementById('drppackagecopy');
                            var temp="";
                            var tempcode="";
                            var tempval="";
                            var tempvalcode="";
                            var desc="";
                            var code="";
                            var i=objpack.options.length;
                            var j;

                                for(j=0;j<i;j++)
                                {
                                    if(parseInt(i)>0)
                                    {
                                        tempval=objpack[j].value;
                                        //tempvalcode=objpack[j].value;
                                        if(temp!="")
                                        {
                                            temp=tempval.split("@");
                                            tempvalcode=temp[0];
                                            tempcode=temp[1];
                                            code=tempvalcode+","+code;
                                            desc=tempcode+","+desc;
                                            
                                            
                                        }
                                        else
                                        {
                                            temp=tempval.split("@");
                                            tempvalcode=temp[0];
                                            tempcode=temp[1];
                                            code=tempvalcode;
                                            desc=tempcode;
                                        }
                                    }
                                
                                }
            var rate_cod="0";
            
            //alert(document.getElementById('drpcurrency').style.visibility);
            document.getElementById('divdeal').innerHTML="";
        //tdpck
            //document.getElementById('divdeal').style.top=parseInt(document.getElementById('txtpaid').offsetTop) + parseInt(document.getElementById('tdpaid').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
            //document.getElementById('divdeal').style.top=parseInt(document.getElementById('txtpaid').offsetTop) + parseInt(document.getElementById('tdpaid').offsetTop) + parseInt(document.getElementById('tdpck').offsetTop)+ parseInt(document.getElementById('OuterTable').offsetTop) + 195;
            document.getElementById('divdeal').style.top=parseInt(document.getElementById('txtpaid').offsetTop) +  parseInt(document.getElementById('tdpck').offsetTop)+ parseInt(document.getElementById('OuterTable').offsetTop) + 328;
            //document.getElementById('divdeal').style.left=parseInt(document.getElementById('txtpaid').offsetLeft) + parseInt(document.getElementById('tdpaid').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9;
            document.getElementById('divdeal').style.left=parseInt(document.getElementById('txtpaid').offsetLeft) +   parseInt(document.getElementById('tdpck').offsetLeft) +12;
            //when value is 0 than we bind the list box and when it is 1 than we calculate the discount
            Booking_Master_temp.binddealtype(compcode,agencysplit,subagency,bookingdate,color,curr,adcat,clientsplit,prod,col,code,rate_cod,adtype,call_binddealtype);

		    return false;
		
		}
		function call_binddealtype(res)
		{
		    var ds=res.value;
		    var dealstr;
		    var str;
		        
		    if(ds.Tables[0]!=undefined && ds!= null  && ds.Tables[0].Rows.length > 0 ) 
            {
  

                    document.getElementById("divdeal").style.display="block";
                    document.getElementById('lbcoupan').style.visibility="hidden";
                    document.getElementById('chkcoupan').style.visibility="hidden";
                    document.getElementById('drppackage').style.visibility="hidden";
                    document.getElementById('lbpackage').style.visibility="hidden";
                    document.getElementById('drppackage').style.visibility="hidden";
                    document.getElementById('drppackagecopy').style.visibility="hidden";
                    document.getElementById('btncopy').style.visibility="hidden";
                    document.getElementById('btndel').style.visibility="hidden";
                    document.getElementById('Img3').style.visibility="hidden";
                    ///document.getElementById('dealdivscroll').style.display="none"; 
                    document.getElementById('lbselectdate').style.visibility="hidden";
                    document.getElementById('txtdummydate').style.visibility="hidden";
                    document.getElementById('lbad').style.visibility="hidden";
                    document.getElementById('chktfn').style.visibility="hidden";
                      document.getElementById('lbcurrency').style.visibility="hidden";
                    document.getElementById('drpcurrency').style.visibility="hidden";
                    document.getElementById('drppackage').style.visibility="hidden";
                    document.getElementById('drppackagecopy').style.visibility="hidden";
                    document.getElementById('drpcurrency').style.visibility="hidden";
            ///////////////////////////////////////////////////////////////////
                var srcimg="Images\\close.gif";
                dealstr="<div style=\"OVERFLOW: auto; Position: absolute; WIDTH: 465px; HEIGHT: 100px;\"><table cellpadding=\"1\" cellspacing=\"1\" id=\"griddeal\" width=\"440px\" border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=\"center\" valign=\"top\" ><img id=\"close\" src="+srcimg+" style=\"cursor:pointer;\" onclick=\"javascript:return closedeal();\"/></td><td align=\"center\" valign=\"top\" >Code</td><td valign=\"top\" align=\"center\" width=\"100px\">Contract Code</td><td align=\"center\" valign=\"top\" width=\"100px\">Deal Rate</td><td align=\"center\" valign=\"top\" width=\"100px\">Deal Name</td><td align=\"center\" valign=\"top\" width=\"100px\">Contract Name</td><td align=\"center\" valign=\"top\">Valid Till</td></tr>";
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                str="chk"+i;
                    dealstr=dealstr+"<tr><td id="+ds.Tables[0].Rows[i].code+" class=\"TextField\"><input type='checkbox' style=\"top:0px\" width='5px' id=" + str + "  onclick=\"javascript:return getdealrate("+ds.Tables[0].Rows[i].code+",'"+ds.Tables[0].Rows[i].dealname+"','"+ds.Tables[0].Rows[i].contractname+"');\"  /></td><td class=\"TextField\">"+ds.Tables[0].Rows[i].code+"</td><td class=\"TextField\">"+ds.Tables[0].Rows[i].contractcode+"</td><td class=\"TextField\">"+ds.Tables[0].Rows[i].deal_rate+"</td>";
                    dealstr=dealstr+"<td class=\"TextField\">"+ds.Tables[0].Rows[i].dealname+"</td><td class=\"TextField\">"+ds.Tables[0].Rows[i].contractname+"</td><td class=\"TextField\">"+ds.Tables[0].Rows[i].todate+"</td>";
                
                }
                
                dealstr=dealstr+"</tr></table></div>";
                document.getElementById('divdeal').innerHTML=dealstr;
                
                
                
           
                
             }
             else
             {
                alert("On this Contract Rate doesnot exists");
		       document.getElementById("divdeal").style.display="none";
		         document.getElementById('lbcoupan').style.visibility="visible";
            document.getElementById('chkcoupan').style.visibility="visible";
            document.getElementById('drppackage').style.visibility="visible";
            document.getElementById('lbpackage').style.visibility="visible";
             document.getElementById('drppackage').style.visibility="visible";
            document.getElementById('drppackagecopy').style.visibility="visible";
            document.getElementById('btncopy').style.visibility="visible";
            document.getElementById('btndel').style.visibility="visible";
            document.getElementById('Img3').style.visibility="visible";
          //  document.getElementById('dealdivscroll').style.display="block";
            document.getElementById('lbselectdate').style.visibility="visible";
            document.getElementById('txtdummydate').style.visibility="visible";
            document.getElementById('lbad').style.visibility="visible";
            document.getElementById('chktfn').style.visibility="visible";
            document.getElementById('lbcurrency').style.visibility="visible";
            document.getElementById('drpcurrency').style.visibility="visible";
		        //document.getElementById('tblpackage').style.display="block";
		        return false;
             
             }
             fillrateintogrid();
		    
		
		
		}
		function closedeal()
		{
		    document.getElementById("divdeal").style.display="none";
		      document.getElementById('lbcoupan').style.visibility="visible";
            document.getElementById('chkcoupan').style.visibility="visible";
            document.getElementById('drppackage').style.visibility="visible";
            document.getElementById('lbpackage').style.visibility="visible";
              document.getElementById('drppackage').style.visibility="visible";
            document.getElementById('drppackagecopy').style.visibility="visible";
            document.getElementById('btncopy').style.visibility="visible";
            document.getElementById('btndel').style.visibility="visible";
            document.getElementById('Img3').style.visibility="visible";
        //    document.getElementById('dealdivscroll').style.display="block";
            document.getElementById('lbselectdate').style.visibility="visible";
            document.getElementById('txtdummydate').style.visibility="visible";
            document.getElementById('lbad').style.visibility="visible";
            document.getElementById('chktfn').style.visibility="visible";
              document.getElementById('lbcurrency').style.visibility="visible";
            document.getElementById('drpcurrency').style.visibility="visible";
		    //document.getElementById('tblpackage').style.display="block";
		        return false;
		}
		
		function getdealrate(val,detyp,conneme)
		{
		//document.getElementById('txtdealrate').value=document.getElementById('lstdealtype').value;
		  document.getElementById('txtcontracttype').value=detyp;
          document.getElementById('txtcontractname').value=conneme;
		document.getElementById("divdeal").style.display="none";
		  document.getElementById('lbcoupan').style.visibility="visible";
            document.getElementById('chkcoupan').style.visibility="visible";
            document.getElementById('drppackage').style.visibility="visible";
            document.getElementById('lbpackage').style.visibility="visible";
              document.getElementById('drppackage').style.visibility="visible";
            document.getElementById('drppackagecopy').style.visibility="visible";
            document.getElementById('btncopy').style.visibility="visible";
            document.getElementById('btndel').style.visibility="visible";
            document.getElementById('Img3').style.visibility="visible";
        //    document.getElementById('dealdivscroll').style.display="block";
            document.getElementById('lbselectdate').style.visibility="visible";
            document.getElementById('txtdummydate').style.visibility="visible";
            document.getElementById('lbad').style.visibility="visible";
            document.getElementById('chktfn').style.visibility="visible";
              document.getElementById('lbcurrency').style.visibility="visible";
            document.getElementById('drpcurrency').style.visibility="visible";
            
		    var agency=document.getElementById('txtagency').value
            var agencyarr=agency.split("(");
            var agencysplit=agencyarr[1];
            agencysplit=agencysplit.replace(")","");
            var subagency=document.getElementById('drpagscode').value;
            var compcode=document.getElementById('hiddencompcode').value
            var dealcode=val;
            /////
            var client=document.getElementById('txtclient').value;
            var clientarr=client.split("(");
            var clientsplit=clientarr[1];
           if(clientsplit!=undefined)
            {
                clientsplit=clientsplit.replace(")","");
            }
            else
            {
                clientsplit="0";
            }
            ///////
            
            Booking_Master_temp.allowdisc(dealcode,compcode,agencysplit,subagency,clientsplit,call_allowdisc);
		
		return false;
		
		}
		function call_allowdisc(res)
		{
		    var ds=res.value;
		    //
		    if(ds.Tables[0].Rows.length>0)
		    {

		                document.getElementById('txtdealrate').value=ds.Tables[0].Rows[i].resul
		                if(document.getElementById('txtcardrate').value!="")
		                {
		                    document.getElementById('txtdeviation').value=parseFloat(document.getElementById('txtcardrate').value)-parseFloat(document.getElementById('txtdealrate').value);
		                }
//		                if(document.getElementById('txtgrossamt').value!="")
//		                {
//		                    getagrredamou();
//		                }
		                if(document.getElementById('tblinsert').innerHTML!="")
                        {
                            flagins="0";
                        }
		            //}
		     }
		     else
		     {
		        alert("On this Contract Rate doesnot exists");
		        document.getElementById("divdeal").style.display="none";
		        return false;
		        
		     
		     }
		
		
		}
		
		
		/////this function is made when on change of scheme drop down we get the scheme 
		
		
		
		
		///////////this is the function which fills into grid on change of ad s cat when grid is visibile
		function filladscatingrid()
		{
		    if(document.getElementById('tblinsert').innerHTML!="")
            {       
            	var len="bookdiv";
                var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;  
                var k;
                var adsubcat;
                var i=0;
                var adsubcat_var=document.getElementById('drpadsubcategory');
                for(k=0;k<y-1;k++)
                {       
                    while(document.getElementById("card"+i)==null)
                    {
                        i=i+savtotid;               
                    }
                    adsubcat="ads"+i;
                    document.getElementById(adsubcat).value=adsubcat_var.value
                    i=parseInt(i)+1;                 
               }
           }
            bindadscat3();
		
		}
			///////////this is the function which fills into grid on change of color when grid is visibile
			function fillcoloringrid()
			{
			//alert(noofinsertlo)
			    var len="bookdiv";
			    if(document.getElementById('tblinsert').innerHTML!="")
                {
                    //var y=parseInt(noofinsertlo)   
                    var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
                    var k;
                    var colid;
                    var i=0;
                    var col_var=document.getElementById('drpcolor');
                        for(k=0;k<y-1;k++)
                        {               
                            while(document.getElementById("card"+i)==null)
                            {
                                i=i+savtotid;
                            }
                            colid="col"+i;
                            document.getElementById(colid).value=col_var.value
                            i=parseInt(i)+1;
                         
                        }                   
        
                } 
                var adcat=document.getElementById('drpadcategory').value;
                var adscat=document.getElementById('drpadsubcategory').value;
                var uomchk=document.getElementById('drpuom').value;
                //var linesword=document.getElementById('txttotalarea').value;
                var curr=document.getElementById('drpcurrency').value;
                var ratecode=document.getElementById('txtratecode').value;
                var insertsno=document.getElementById('txtinsertion').value;
                //////////////this code is to split the code as well as ites description 
    
////               var objpack=document.getElementById('drppackagecopy');                            
////                                
////                  if(objpack.options.length>0 && adcat!="0" && adscat!="0" && uomchk!="0"  && curr!="0" && ratecode!="0" && insertsno!="")
////                  {
////                    gettherate();                  
////                  }
			
			}
			
			function getmodifygrid()
			{
			    var len="bookdiv";
                var insertno;
                var premid;
               var premper;
               var colid;
               var heightid;
               var widthid;
               var size;
               var late;
               //var uomid;
               //var adtypid;
               var cardid;
               var editid;
               var solorate;
               var premper1;
               var prem1id;
               var namecode;
               var inserts;
               var pagepost;
               var preall;
               var adcat;
               var adsubcat;
               var matsta;
               var filename;
               var discrate;
               var insertsta;
               var billstat;
               var id;
               var repeat;
               var i=0;
               var paid;
               var agrred;
               var solo;
               var gross;
               var showid;
               var pageno_inserts;
               var remark_inserts;
               var page;
               var pageprem;
               var noofcol;
               var billamt;
               var billrate;
               var compcode=document.getElementById('hiddencompcode').value;
               var userid =document.getElementById('hiddenuserid').value;
               var cioid=document.getElementById('txtciobookid').value;
               var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
               var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
              //var y=parseInt(noofinsert)   
               var k;
              var dateformat =document.getElementById('hiddendateformat').value;
               for(k=0;k<y-1;k++)
                {
              
                         
                   showid="sho"+i; 
                   id="Text" + i;
                    editid="edit"+i;
                    premid="prem"+i;
                    prem1id="premone"+i;
                    colid="col"+i;
                    heightid="hei"+i;
                    widthid="wid"+i;
                    size="siz"+i;
                    pagepost="pagpos"+i;
                    namecode="one";
                    premper="premper"+i;
                    premper1="premperone"+i;
                    adtypid="adtyp"+i;
                    namecode="two";
                    preall="preall"+i;
                    adcat="adcat"+i;
                    late="lat"+i;
                    matsta="mat"+i;
                    cardid="card"+i;   
                    filename="fil"+i;
                    discrate="disrat"+i;
                    insertsta="inssta"+i;
                    billstat="bill"+i;
                    adsubcat="ads"+i;
                    repeat="rep"+i;
                    insertno="ins"+i;
                    paid="pai"+i
                    agrred="agr"+i;
                    solo="sol"+i;
                    gross="gro"+i;
                    pageno_inserts="pagno"+i;;
                    remark_inserts="rem"+i;
                    page="pgpre"+i;
                    pageprem="pagper"+i;
                    noofcol="nocol"+i;
                    billamt="ba"+i;
                    billrate="br"+i;
                    var editid_var=document.getElementById(editid);
                    var par1=(editid_var.parentNode).parentNode;
                if(browser!="Microsoft Internet Explorer")
                {
                   var insernum=document.getElementById(insertno).innerHTML;
                    var insertdate=document.getElementById(id).value;
                    var edition=document.getElementById(editid).value;
                    var premium1=document.getElementById(premid).value;
                    var premium2="";  //document.getElementById(prem1id).value;
                    var height=document.getElementById(heightid).value;
                    var width=document.getElementById(widthid).value;
                    var totalsize=document.getElementById(size).value;
                    var pagepost=document.getElementById(pagepost).value;
                    var color=document.getElementById(colid).value;
                    var premper11=document.getElementById(premper).value;
                    var premper2=""; // document.getElementById(premper1).value;
                    var premallow=document.getElementById(preall).value;
                    var adcategory=document.getElementById(adcat).value;
                    var latestdate=document.getElementById(late).value;
                    var material=document.getElementById(matsta).value;
                    var cardrate=document.getElementById(cardid).value;
                    var filename=document.getElementById(filename).value;
                    var discrate=document.getElementById(discrate).value;
                    var insertstatus=document.getElementById(insertsta).value;
                    var billstatus=document.getElementById(billstat).value;
                    var adsubcat=document.getElementById(adsubcat).value;
                    var repdate=document.getElementById(repeat).value;
                    var paidins=document.getElementById(paid).value;
                    var insagreedrate=document.getElementById(agrred).value;
                    var inssolo=document.getElementById(solo).value;
                    var grossrate=document.getElementById(gross).value;
                    var insert_pageno=document.getElementById(pageno_inserts).value;
                    var insert_remark=document.getElementById(remark_inserts).value;
                    var page_code=""; //document.getElementById(page).value;
                    var page_per=""; //document.getElementById(premid).value;
                    var no_ofcol=document.getElementById(noofcol).value;
                    var bill_amt=document.getElementById(billamt).value;
                    var bill_rate=document.getElementById(billrate).value;
                   
                    var insert_id="sho"+i;
                    var insertid='0';
                    var pkgcodegrid_value="";
                    var pkginsgrid_value="";
                    var pkg_alias_value="";
                    var pkgcodegrid="hiddenpckcode"+i;
                    
                    var pkg_ins="pkg_ins"+i;
                    
                    var pkg_alias="pkg_alias"+i;
                    if(document.getElementById(pkgcodegrid)!=null)
                    {
                        pkgcodegrid_value=document.getElementById(pkgcodegrid).value;
                    }
                    
                    if(par1.all[pkg_ins]!=null)
                    {
                        pkginsgrid_value=document.getElementById(pkg_ins).value;
                    }
                    
                    if(document.getElementById(pkg_alias)!=null)
                    {
                        pkg_alias_value=trim(document.getElementById(pkg_alias).value);
                    }
                    if(document.getElementById(insert_id)!=null)
                        insertid=document.getElementById(insert_id).value;
                }
                else
                {
                    var insernum=par1.all[insertno].innerHTML;
                    var insertdate=par1.all[id].value;
                    var edition=par1.all[editid].value;
                    var premium1=par1.all[premid].value;
                    var premium2="";  //document.getElementById(prem1id).value;
                    var height=par1.all[heightid].value;
                    var width=par1.all[widthid].value;
                    var totalsize=par1.all[size].value;
                    var pagepost=par1.all[pagepost].value;
                    var color=par1.all[colid].value;
                    var premper11=par1.all[premper].value;
                    var premper2=""; // document.getElementById(premper1).value;
                    var premallow=par1.all[preall].value;
                    var adcategory=par1.all[adcat].value;
                    var latestdate=par1.all[late].value;
                    var material=par1.all[matsta].value;
                    var cardrate=par1.all[cardid].value;
                    var filename=par1.all[filename].value;
                    var discrate=par1.all[discrate].value;
                    var insertstatus=par1.all[insertsta].value;
                    var billstatus=par1.all[billstat].value;
                    var adsubcat=par1.all[adsubcat].value;
                    var repdate=par1.all[repeat].value;
                    var paidins=par1.all[paid].value;
                    var insagreedrate=par1.all[agrred].value;
                    var inssolo=par1.all[solo].value;
                    var grossrate=par1.all[gross].value;
                    var insert_pageno=par1.all[pageno_inserts].value;
                    var insert_remark=par1.all[remark_inserts].value;
                    var page_code=""; //document.getElementById(page).value;
                    var page_per=""; //document.getElementById(premid).value;
                    var no_ofcol=par1.all[noofcol].value;
                    var bill_amt=par1.all[billamt].value;
                    var bill_rate=par1.all[billrate].value;
                   
                    var insert_id="sho"+i;
                    var insertid='0';
                    var pkgcodegrid_value="";
                    var pkginsgrid_value="";
                    var pkg_alias_value="";
                    var pkgcodegrid="hiddenpckcode"+i;
                    
                    var pkg_ins="pkg_ins"+i;
                    
                    var pkg_alias="pkg_alias"+i;
                    if(par1.all[pkgcodegrid]!=null)
                    {
                        pkgcodegrid_value=par1.all[pkgcodegrid].value;
                    }
                    
                    if(par1.all[pkg_ins]!=null)
                    {
                        pkginsgrid_value=par1.all[pkg_ins].value;
                    }
                    
                    if(par1.all[pkg_alias]!=null)
                    {
                        pkg_alias_value=trim(par1.all[pkg_alias].value);
                    }
                    if(par1.all[insert_id]!=null)
                        insertid=par1.all[insert_id].value;
                }
                  var oldbillno='';
                var oldbilldate='';
                oldbillno=document.getElementById('hiddenbillNo').value;
                    //var modid=document.getElementById(showid).value
                    //Booking_Master_temp.modifygridinsert(insertdate,edition,premium1,premium2,premallow,adcategory,latestdate,material,cardrate,filename,discrate,insertstatus,billstatus,adsubcat,compcode,userid,cioid,height,width,totalsize,pagepost,premper11,premper2,color,repdate,insernum,paidins,insagreedrate,inssolo,grossrate,modid);
                    Booking_Master_temp.modifygridinsert(insertdate,edition,premium1,premium2,premallow,adcategory,latestdate,material,cardrate,filename,discrate,insertstatus,billstatus,adsubcat,compcode,userid,cioid,height,width,totalsize,pagepost,premper11,premper2,color,repdate,insernum,paidins,insagreedrate,inssolo,grossrate,insert_pageno,insert_remark,page_code,page_per,no_ofcol,bill_amt, bill_rate,"0","0","0", dateformat,pkgcodegrid_value,pkginsgrid_value,pkg_alias_value,insertid,oldbillno,oldbilldate);
                    i=i+1;
                }
                
                if(document.getElementById('hiddensavemod').value=="0")
                {
                    document.getElementById('tblinsert').innerHTML="" 
                    document.getElementById('tblrate').style.display="none";
	                document.getElementById('tblbill').style.display="none";
	                //document.getElementById('tblsize').style.display="none";
	                document.getElementById('addetails').style.display="none";
	                document.getElementById('pagedetail').style.display="none";
	                document.getElementById('tblpackage').style.display="none";   
	                document.getElementById('tbbox').style.display="none";
	                document.getElementById('txtciobookid').value="";
	                document.getElementById('LinkButton1').disabled=true;
	                document.getElementById('LinkButton2').disabled=true;
	                document.getElementById('LinkButton3').disabled=true;
	                document.getElementById('LinkButton4').disabled=true;
	                document.getElementById('LinkButton5').disabled=true;
	                document.getElementById('LinkButton6').disabled=true;
	                document.getElementById('LinkButton7').disabled=true;
	             }   
                
                return false;                          
			
			
			}
			
			function bindvarient()
			{
			    var brandval=document.getElementById('drpbrand').value;
			    document.getElementById('hiddenbrand').value=brandval
			    var compcode=document.getElementById('hiddencompcode').value;
			      var pkgitem = document.getElementById("drpvarient");
                    pkgitem.options.length = 0; 
			    if(brandval!="")
			    {
			        Booking_Master_temp.fillvarient(brandval,compcode,call_fillvarient);
			    }
			    return false;
			}
			
			function call_fillvarient(res)
			{
			    var ds=res.value;
		        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                {
                    var pkgitem = document.getElementById("drpvarient");
                    pkgitem.options.length = 0; 
                    pkgitem.options[0]=new Option("-Select varient-","0");
                    //alert(pkgitem.options.length);
                    pkgitem.options.length = 1; 
                    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                    {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].varient_name,ds.Tables[0].Rows[i].varient_code);                        
                        pkgitem.options.length;                       
                    }

                }
			
			}
			
	function getvarval()
	{
		document.getElementById('hiddenvar').value=document.getElementById('drpvarient').value
	}
			
	function chkcasualclient()
	{
		   if(document.getElementById('txtclient').value!="")
		   {
		        var client=document.getElementById('txtclient').value;
		        if (client.indexOf("(".toString()) > 0)
                {                   
                    client =  client.split('(')[0];                   
                }
		        var compcode=document.getElementById('hiddencompcode').value;
		        Booking_Master_temp.chkcasualcli(client,compcode,call_chkcasualcli);
		        return false;
		   }
	}
		    
    function call_chkcasualcli(res)
	{
	 if(document.getElementById('txtclient').value.lastIndexOf(")")<0)
	 {
	    var ds=res.value;
	    if(ds.Tables[0]!=undefined && ds.Tables[0].Rows[0].custname!=undefined)
	    {
	        /*  if(ds.Tables[0].Rows.length>0 && ds.Tables[0].Rows[0].custname!="0")
	          {
	               document.getElementById('txtclient').value=ds.Tables[0].Rows[0].custname;
	               if(ds.Tables[0].Rows[0].add1!=null)
	               {
		                document.getElementById('txtclientadd').value=ds.Tables[0].Rows[0].add1;
	               }
              }*/
	          //else
	          //{
                    if(confirm('Do you want to register this client?'))
	                {
		                  var frombooking="1";
		                  var clientname=document.getElementById('txtclient').value;
		                  window.open('ClientMaster.aspx?frombooking='+frombooking+'&clientname='+clientname,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
        		    }
        		    else
        		    {
        		          // new change for check registered client
                            var adcategory= document.getElementById('drpadcategory').value;
                            if(adcategory!="0")
                            {
                                      var res=Booking_Master_temp.getRegClientCheck(adcategory);
                                     if(res.value!=null)
                                     {
                                        if(res.value=="Y")
                                        {
                                            if(document.getElementById('txtclient').value.lastIndexOf('(')<0)
                                            {
                                                alert("For Category "+document.getElementById('drpadcategory').options[document.getElementById('drpadcategory').selectedIndex].text + ", You can take only Registered Client");
                                                document.getElementById('txtclient').focus();
                                                return false;
                                            }
                                        }
                                     }
                               }      
        		    }
    		   //}
		 }
		 else
		 {
		   
		      if(confirm('Do you want to register this client?'))
		      {
		           var frombooking="1";
		           var clientname=document.getElementById('txtclient').value;
		           window.open('ClientMaster.aspx?frombooking='+frombooking+'&clientname='+clientname,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    	       }
    	      
		  }
		 bind_agen_bill();  
		 }
	}
		    
		    function getinsertscheme()
		    {
		         if(document.getElementById('drppackage').value=="0")
		         {
		            alert("Please select the package");		            
		            globalschemedisc="";
		            globalschemefrom="";
		            gldisctyp="";
		            return false;
		         }
		        
		            if(document.getElementById('drpscheme').value!="0")
		            {
		                var schemecode=document.getElementById('drpschemepck').value;
		                var compcode=document.getElementById('hiddencompcode').value;
		                document.getElementById('drpscheme').value=document.getElementById('drpschemepck').value
		                globalschemedisc="";
		                Booking_Master_temp.getinsertionscheme(schemecode,compcode,call_getinsertionscheme);
    		            
		            }
		            else
		            {
		                document.getElementById('txtinsertion').disabled=false;
		                document.getElementById('txtinsertion').value="1";
		                document.getElementById('txtrepeatingdate').value="";
		                onInsertionChange();
		            
		            }
		            globalschemedisc="";
		            globalschemefrom="";
		            gldisctyp="";
		            return false;
		    }
		    
	function call_getinsertionscheme(response)
	{
		    var ds=response.value;
		    ds_sch=response.value;
	        if(ds.Tables[0].Rows.length>0)
	        {
		            document.getElementById('txtinsertion').value=ds.Tables[0].Rows[0].to_insertion_no
		            document.getElementById('txtinsertion').disabled=true;
		            
		            globalschemedisc=ds.Tables[0].Rows[0].discount
		            globalschemefrom=ds.Tables[0].Rows[0].From_Insertion_No
		            gldisctyp=ds.Tables[0].Rows[0].discount_type
		            onInsertionChange();
	        }
		    
	}


//new change bind package name
function addpkgname()
{
    
    document.getElementById('txtcardrate').value="";
	document.getElementById('txtgrossamt').value="";
	document.getElementById('drppageprem').value="0";
	document.getElementById('drppageposition').value="0";
	
    if(document.getElementById('drpadcategory').value=="0")
    {
        alert("Please select the category");
        document.getElementById('drpadcategory').focus();
        return false;
    }
    if(document.getElementById('drppackage').value=="0")
    {
        alert("Please select the package");
        document.getElementById('drppackage').focus();
        return false;
    }
    var dCheck=openSelectionEdiionDiv();
    if(dCheck==false)
        return false;
    var obj=document.getElementById('drppackagecopy');
    subtractrow="";
    for(var x=0;x<obj.options.length;x++)
    {
        if(document.getElementById('drppackage').value==obj[x].value.substring(0,obj[x].value.indexOf('(')))
        {
           // alert("This package is already shifted");
           var insertCount = 1;
           if(obj[x].value.indexOf('(')>=0)
           {
                insertCount=obj[x].value.substring(obj[x].value.indexOf('(')+1,obj[x].value.length-1);
           }
           insertCount=parseInt(insertCount) + 1;
           obj[x].value = obj[x].value.substring(0,obj[x].value.indexOf('(')) + '('+insertCount+')';
           obj[x].text =  obj[x].text.substring(0,obj[x].text.indexOf('(')) + '('+insertCount+')';
           onInsertionChange();
           return false;
        }
    }
    var strid = document.getElementById('drppackage').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var strid1=strid.split('@');
    var pkgid=strid1[0];
    var pkgname=strid1[1];
    glpkgname=pkgname;
    var value="0";
    var dateday="";
    var strtext="";
    var code="";
    var desc="";    
    
    if(browser!="Microsoft Internet Explorer")
    {
         var  httpRequest =null;
         httpRequest= new XMLHttpRequest();
         if (httpRequest.overrideMimeType) 
         {
            httpRequest.overrideMimeType('text/xml'); 
         }
            
         httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
         var adcat=document.getElementById('drpadcategory').value;
         httpRequest.open( "GET","packagename.aspx?adcat="+adcat+"&pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
         httpRequest.send('');
         
         if (httpRequest.readyState == 4) 
         {
             if (httpRequest.status == 200) 
             {
                  strtext=httpRequest.responseText;
             }
             else 
             {
                 alert('There was a problem with the request.');
             }
          }
      }
      else
      { 
           var xml = new ActiveXObject("Microsoft.XMLHTTP");
           var adcat=document.getElementById('drpadcategory').value;
           xml.Open( "GET","packagename.aspx?adcat="+adcat+"&pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
           xml.Send();
           strtext=xml.responseText;
      }
      document.getElementById('pkgname').value=strtext;
      if(document.getElementById('drppackagecopy').options.length == 0)
      {
          che_flag = 0;
      }
      if(che_flag == 1)
      {
            alert("Can't select multiple Package");
            return false;
      }
      else if((document.getElementById('drppackagecopy').options.length>0) && (pkgname.indexOf(" or ")>=0))
      {
            alert("Can't select this Package");
            return false;
      }
      else
      {
        if(pkgname.indexOf(" or ")>=0)
        {  
             che_flag=1;
             Booking_Master_temp.bindTable(pkgname,bindTable_callback);
             check_or="1";
        }
        var val_="";
        var agencytype="DI0"; // document.getElementById('drpadtype').value;
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) 
            {
                httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","gettheinsertionfromcombin.aspx?desc="+glpkgname+"&code="+pkgid+"&agencytype="+agencytype, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    val_=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","gettheinsertionfromcombin.aspx?desc="+glpkgname+"&code="+pkgid+"&agencytype="+agencytype, false );
            xml.Send();
            val_=xml.responseText;            
        }
              
        if(val_!="" && val_!="0" && val_!=null)
        {
            document.getElementById('txtinsertion').value=val_
        }
        
        if(che_flag == 0)
        {
            if(strtext!="0")
            {
                AddItem(document.getElementById('drppackagecopy'), strtext, strid);
            }
            document.getElementById('txtdummydate').focus();
        }
        }
      
   // document.getElementById('drpuom').focus();
    document.getElementById('txtgrossamt').value="";
    return false;
}


function AddItem(objListBox, strText, strId)
{
    suboradd="1";
    previnsertion="0";
    getid="";
    if(strText.indexOf('(')<0)
    {
        strText = strText + '(1)';
        strId   = strId + '(1)';  
    }
 if (objListBox.length > 0)
{

var arr = new Array();
var arr1=new Array();
for(j=0;j<=objListBox.length-1;j++)
{ arr[j] = objListBox.options(j).text;
arr1[j] = objListBox.options(j).value;
 }

for(k=objListBox.length-1;k>=0;k--)
{ objListBox.remove(k); }

var opt = document.createElement("OPTION");
opt.text = strText;
opt.value = strId;
objListBox.add(opt);

var x=0;
for(x in arr)
{
if(x!="remove")
{
var option = document.createElement("OPTION");
option.text = arr[x];
option.value = arr1[x];
objListBox.add(option);
}
}

}
else
{

var opt = document.createElement("OPTION");
opt.text = strText;
opt.value = strId;
objListBox.add(opt);


} 
   // objListBox.options[objListBox.options.length] = new Option(strText,strId);
   // objListBox.options.length;
    document.getElementById('hiddencalendar').value="0";
    document.getElementById('txtrepeatingdate').value="";
    insertLinedrop();
}   


function removepkgname()
{

    if(document.getElementById('drppackagecopy').options.length==0)
    {
        alert("There is no item to delete");
        cali=0;
        arrEdition_Item='';
        return false;
    
    }
    
    else if(document.getElementById('drppackagecopy').value=="")
    {
         alert("Please select the package for delete");
         document.getElementById('chktfn').focus();
        return false;
    }
        var strId = document.getElementById('drppackagecopy').value;
     
         //insertLinesubtract_callback(document.getElementById('drppackagecopy').value,'child');
        RemoveItem(document.getElementById('drppackagecopy'), strId);
        if(document.getElementById('drppackagecopy').options.length!==0)
        {
            document.getElementById('hiddencalendar').value="0";
            insertLinedrop();
        }
        else
        {
            document.getElementById('tblinsert').innerHTML="";
            document.getElementById('hiddencalendar').value="0";
            //document.getElementById('drpscheme').value="0";
            document.getElementById('drpscheme').value="0";
            globalschemedisc="";
            check_or="0";
            cali=0;
        }
           if(document.getElementById('drppackagecopy').options.length==0)
          {
              cali=0;
             arrEdition_Item='';
             document.getElementById('txtdummydate').value="";
          }
        return false;
}

 function GetItemIndex(objListBox, strId)
 {
     for (var i = 0; i < objListBox.children.length; i++)
     {
        var strCurrentValueId = objListBox.children[i].value;
        if (strId == strCurrentValueId)
        {
          return i;
        }
     }
     return -1;
 }
 
function RemoveItem(objListBox, strId)
{
    var intIndex = GetItemIndex(objListBox, strId);
    if(strId.indexOf('(')>=0)
    {
        var no=strId.substring(strId.indexOf('(')+1,strId.indexOf(')'));
        if(parseInt(no)!=1)
        {
            no=parseInt(no) - 1;
            objListBox.options[intIndex].value=objListBox.options[intIndex].value.substring(0,objListBox.options[intIndex].value.indexOf('('))  + '('+no+')';
            objListBox.options[intIndex].text=objListBox.options[intIndex].text.substring(0,objListBox.options[intIndex].text.indexOf('('))  + '('+no+')';
        }
        else
        {
            if (intIndex != -1)
            objListBox.remove(intIndex);
        }
    }
    else
    {
        if (intIndex != -1)
            objListBox.remove(intIndex);
    }
}

    ///this is the function which changes the background color on focus
    function changebackcolor(e)
    {
        var idfoc=e.id;
        if(idfocus!="")
        {
            document.getElementById(idfocus).style.backgroundColor="";
        }
            document.getElementById(idfoc).style.backgroundColor="#FFFF80";
            
            idfocus=e.id;    
    }
    
    function chkpublishdate(idval,iddat)
    {
        var pub=document.getElementById(idval).value;
        if(pub=="publish")
        {
            var pubdate=new Date(document.getElementById(iddat).value);
            var currdate=new Date();
            if(currdate<pubdate)
            {
                alert("For publication current date should be less");
                document.getElementById(idval).value="booked";
            }
        }
        return false;
    
    }
    
    ////////////////////////when we select the credit from the dropdown than on change credit detail div opens 
      function showcreditdetail()
    {

            
        document.getElementById('txtagencypaymode').value=document.getElementById('drppaymenttype').value;
        if(document.getElementById('txtagencypaymode').selectedIndex!=-1)
        document.getElementById('hiddenpaymode').value=document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').selectedIndex].text;
        if(document.getElementById('drppaymenttype').value=="CR0")  //CR0 is Credit Card code
        {          
            document.getElementById('tdcarname').style.display="";
            document.getElementById('tdtxtcarname').style.display="";
            document.getElementById('tdtype').style.display="";
            document.getElementById('tddrptyp').style.display="";
            document.getElementById('tdexdat').style.display="";
            
            document.getElementById('tdtxtexdat').style.display="";
            document.getElementById('tdcardno').style.display="";
            document.getElementById('tdtxtcarno').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
             document.getElementById('txtcardname').disabled=false;
            document.getElementById('drptype').disabled=false;
            document.getElementById('drpmonth').disabled=false;
            document.getElementById('drpyear').disabled=false;
            document.getElementById('txtcardno').disabled=false;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
             document.getElementById('tdourbank').style.display="none";
         
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none"; 
                document.getElementById('tdtextourbank').style.display="none";            
             
            document.getElementById("txtreceipt").value=""; 
        }
        else if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0"   || document.getElementById('drppaymenttype').value=='PO0')  //CR0 is Credit Card code and DD0 is demand draft
        {          
            document.getElementById('ttextchqno').disabled = false;  
             document.getElementById('drpourbank').disabled=false;                      
            document.getElementById('ttextchqdate').disabled = false;
            document.getElementById('ttextchqamt').disabled = false;
            document.getElementById('ttextbankname').disabled = false;
            document.getElementById('tdchqno').style.display="";
            document.getElementById('tdchqdate').style.display="";
            document.getElementById('tdchqamt').style.display="";
            document.getElementById('tdbankname').style.display="";
            document.getElementById('tdourbank').style.display="";
            
            
            document.getElementById('tdtextchqno').style.display="";            
            document.getElementById('tdtextchqdate').style.display="";
            document.getElementById('tdtextchqamt').style.display="";
            document.getElementById('tdtextbankname').style.display="";
             document.getElementById('tdtextourbank').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
             
             document.getElementById("txtreceipt").value=""; 
        }
        else
        {
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
            
            document.getElementById('txtcardname').value="";
            document.getElementById('drptype').value="0";
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpyear').value="0";
            document.getElementById('txtcardno').value="";
            document.getElementById("txtreceipt").value="";
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            document.getElementById('tdourbank').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";
              document.getElementById('tdtextourbank').style.display="none";
              
            document.getElementById('ttextchqno').value="";  
             document.getElementById('drpourbank').value="0";               
            document.getElementById('ttextchqdate').value="";   
            document.getElementById('ttextchqamt').value="";   
            document.getElementById('ttextbankname').value="";   
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
        }
        return false;    
    }  
    
    
    //////if on query it is to show that if in the database the value is credit card than show the card no,name and other inf.
    function showcardinfo(caval)
    {
        if(caval=="CR0")
        {          
            document.getElementById('tdcarname').style.display="";
            document.getElementById('tdtxtcarname').style.display="";
            document.getElementById('tdtype').style.display="";
            document.getElementById('tddrptyp').style.display="";
            document.getElementById('tdexdat').style.display="";            
            document.getElementById('tdtxtexdat').style.display="";
            document.getElementById('tdcardno').style.display="";
            document.getElementById('tdtxtcarno').style.display="";          
            
            return false;
        }
        else
        {
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";            
            
            return false;       
        
        }
    }
    function getvalueintohidden()
    {
        document.getElementById('hiddenbillto').value= document.getElementById('drpbillto').value
        return false;    
    }
    
    function exitbook()
    {
         if(confirm("Do You Want To Skip This Page"))
         {
              window.close();
         }
         return false;    
    }
    
    function disablelistbox()
    {               
        document.getElementById("div1").style.display="none"
        document.getElementById("divclient").style.display="none"
        document.getElementById("divproduct").style.display="none"
        document.getElementById("divexec").style.display="none"
    }
    
    function getintohidden()
    {
        document.getElementById('hiddenpay').value=document.getElementById('txtagencypaymode').value;
        return false;    
    }
    
    function chkmonth()
    {
        var curdat=document.getElementById('txtdatetime').value;
        var chkcurrdate=new Date(curdat);
        var month=chkcurrdate.getMonth()+1;
        var year=chkcurrdate.getFullYear();
    
        if(parseInt(document.getElementById('drpmonth').value)<parseInt(month))
        {
            alert("Month should be greater than current month");
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpmonth').focus();
            return false;
        }
    }
    
   function chkyear()
    {
         var curdat=document.getElementById('txtdatetime').value;
           var txt=curdat.split("/");
            if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	        {
	            curdat=txt[0] + "/" + txt[1] + "/" + txt[2];
	        }
	        else if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	        {
	            curdat=txt[1] + "/" + txt[0] + "/" + txt[2];;
	        }
	        else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
	        {
	            curdat=txt[1] + "/" + txt[2] + "/" + txt[0];;
	        }
        var chkcurrdate=new Date(curdat);
        var month=chkcurrdate.getMonth()+1;
        var year=chkcurrdate.getFullYear();

        if(parseInt(document.getElementById('drpyear').value)<parseInt(year))
        {
            alert("Year should be greater than or equal to current Year");
            document.getElementById('drpyear').value="0";
            document.getElementById('drpyear').focus();
            return false;
            
        
        }
         if(parseInt(document.getElementById('drpyear').value)==parseInt(year) && parseInt(document.getElementById('drpmonth').value,10)<parseInt(month,10))
        {
             alert("Month should be greater than current month");
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpmonth').focus();
            return false;
        }
    }
    
    function printreceipt()
    {
        var billamt=document.getElementById('txtbillamt').value
        var cli=document.getElementById('txtclient').value;
        var curr=document.getElementById('drpcurrency').value;
        var packagedetail=document.getElementById('drpcurrency').value;
        var objpack=document.getElementById('drppackagecopy');
        var temp="";
        var tempcode="";
        var tempval="";
        var tempvalcode="";
        var desc="";
        var code="";
        var i=objpack.options.length;
        var j;

        for(j=0;j<i;j++)
        {
           if(parseInt(i)>0)
           {
               tempval=objpack[j].value;
                         //tempvalcode=objpack[j].value;
                if(temp!="")
                {
                    temp=tempval.split("@");
                    tempvalcode=temp[0];
                    tempcode=temp[1];
                    code=tempvalcode+","+code;
                    desc=tempcode+","+desc; 
                 }
                 else
                 {
                    temp=tempval.split("@");
                    tempvalcode=temp[0];
                    tempcode=temp[1];
                    code=tempvalcode;
                    desc=tempcode;
                 }
             }
                                
         }
                                ///////////////this is to call the print page to print the receipt no
        if(billamt!="")
        {
            window.open('printreceipt.aspx?billamt='+billamt+'&cli='+cli+'&curr='+curr+'&desc='+desc,'','width=500px,height=500px,resizable=1,left=0,top=0,scrollbars=yes');
        }    
        else
        {
            alert("Please get the bill amount");
        }
        return false;
    
    }
  
  function printwindow()
  {
        document.getElementById('Button1').style.display="none";
        window.print();
        document.getElementById('Button1').style.display="block";
  }
  
  function getpageareaintogrid(w,h)
  {
        var len="bookdiv";
        var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
        var i=0;
        var k;
        var height;
        var width;
        var size;
         var file_nam;
        for(k=0;i<y-1;k++)
        {
             
                
                height="hei"+i;
                width="wid"+i;
                size="siz"+i;
                file_nam="fil"+i;
                var height_var=document.getElementById(height);
                var par1=(height_var.parentNode).parentNode;
                if(browser!="Microsoft Internet Explorer")
                {
                 if(document.getElementById(height)!=null)
                {
                    document.getElementById(height).value=h;
                    document.getElementById(width).value=w;
                    document.getElementById(size).value=parseFloat(h)*parseFloat(w);
                    if(document.getElementById(file_nam)!=null)
                        document.getElementById(file_nam).value="";
                }
               
                }
                else
                {
                    if(par1.all[height]!=null)
                    {
                        par1.all[height].value=h;
                        par1.all[width].value=w;
                        par1.all[size].value=parseFloat(h)*parseFloat(w);
                        if(par1.all[file_nam]!=null)
                         par1.all[file_nam].value="";
                    }
                }
                i++;
                
        
        } 
        
  }
  /////////////////this is to get the page premium
  
  function getpageprem(premid,id,str)
  {
        premid=premid.id;

            ///////////this page is created to get the value of selected premium
        var page=document.getElementById(premid).value;
            
         var val="";
         if(browser!="Microsoft Internet Explorer")
         {
              var  httpRequest =null;;
              httpRequest= new XMLHttpRequest();
              if (httpRequest.overrideMimeType)
              {
                httpRequest.overrideMimeType('text/xml'); 
              }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","getpremium.aspx?page="+page, false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        val=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                 var xml = new ActiveXObject("Microsoft.XMLHTTP");
                 xml.Open( "GET","getpremium.aspx?page="+page, false );
                 xml.Send();
                 val=xml.responseText;
            }
             val=val.split("^");
             val=val[1];
             var premper="pagper"+id;
             var cardid="card"+id;
             var solo="sol"+id;
             var agrred="agr"+id;
             var discrate="disrat"+id;
             var gross="gro"+id;
             var size="siz"+id;
             //var pageprem="pageprem"+id;
             var premperfirst="premper"+id;
             var premsec="premperone"+id;
             if(document.getElementById(cardid).value=="")
             {
                alert("Please get the card rate");
                return false;
             
             }
              if(str!="fir")
              {
                    if(val==null || val=="null")
                    {
                        document.getElementById(premper).value="0";
                        val="0";
                    }
                    else
                    {
                       document.getElementById(premper).value=val;
                    } 
               }
               if(val==null || val=="null")
               {
                    val="0";
               }
                    //when we change the premium than card effects automatically only when card rate and agreed are equal
                if(parseFloat(document.getElementById('txtcardrate').value)==parseFloat(document.getElementById('txtagreedrate').value))
                {
                    if(document.getElementById('hiddenpremtype').value=="per")
                     {
                         var grossamt=parseFloat(document.getElementById(cardid).value)*parseFloat(document.getElementById(size).value);
                         if(document.getElementById(premsec).value=="")
                         {
                            document.getElementById(premsec).value="0";
                         }
                         if(document.getElementById(premperfirst).value=="")
                         {
                             document.getElementById(premperfirst).value="0";
                         }
                         var valper=parseFloat(val)+parseFloat(document.getElementById(premsec).value)+parseFloat(document.getElementById(premperfirst).value);
                         var gramt=parseFloat(grossamt)+(parseFloat(grossamt)*parseFloat(valper)/100);
                         document.getElementById(gross).value=gramt.toFixed(2);
                                
                       }
                       else
                        {
                             var grossamt=parseFloat(document.getElementById(cardid).value)*parseFloat(document.getElementById(size).value);
                             if(document.getElementById(premsec).value=="")
                              {
                                   document.getElementById(premsec).value="0";
                               }
                               if(document.getElementById(premperfirst).value=="")
                               {
                                    document.getElementById(premperfirst).value="0";
                               }
                                    var valper=parseFloat(val)+parseFloat(document.getElementById(premsec).value)+parseFloat(document.getElementById(premperfirst).value);
                                    document.getElementById(gross).value=(parseFloat(grossamt)+parseFloat(valper)).toFixed(2);                                        
                                
                         }   
                    
                    }
                    
                      if(noofinsert!="")
                      {                 
                           y=parseInt(noofinsert)   
                           totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
                      }
                      else
                      {
                         y=rowwhenupdate;
                         totid=parseInt(rowwhenupdate)/parseInt(document.getElementById('txtinsertion').value)
                      }
                  
                
                    for(k=0;k<y;k++)
                    {
                       while(document.getElementById("card"+i)==null)
                       {
                           i=i+totid;
               
                       }
                       var gross1="gro"+i;
                       totor=parseFloat(totor)+parseFloat(document.getElementById(gross1).value);
                       i=i+1;
                    }
                    
                    //document.getElementById('txtgrossamt').value=formatDecimal(totor,true,2);
                    var grossamt;
                   
                    var strtext="";
                    if(document.getElementById('hiddenvat').value=="grossamount")
                    {
                            var strtext="";
                            if(browser!="Microsoft Internet Explorer")
                            {
                                var  httpRequest =null;;
                                httpRequest= new XMLHttpRequest();
                                if (httpRequest.overrideMimeType) {
                                httpRequest.overrideMimeType('text/xml'); 
                            }
                                
                                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                                httpRequest.open( "GET","getvatrate.aspx?grossamt="+totor, false );
                                httpRequest.send('');
                                //alert(httpRequest.readyState);
                                if (httpRequest.readyState == 4) 
                                {
                                    //alert(httpRequest.status);
                                    if (httpRequest.status == 200) 
                                    {
                                        strtext=httpRequest.responseText;
                                    }
                                    else 
                                    {
                                        alert('There was a problem with the request.');
                                    }
                                }
                            }
                            else
                            {
                                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                            
                                xml.Open( "GET","getvatrate.aspx?grossamt="+totor, false );
                                xml.Send();
                                strtext=xml.responseText;   
                            }
                                document.getElementById('txtgrossamt').value=formatDecimal(parseFloat(strtext),true,2)
                            var trdisc=document.getElementById('txttradedisc').value
                        if(trdisc=="")
                            trdisc=0;
                        var trdisc1=trdisc;
                        addcomm =0;
                        if(document.getElementById('txtaddagencycommrate')!=null) 
                        {
                            addcomm=document.getElementById('txtaddagencycommrate').value;
                        }
                        if(addcomm=="")
                        {
                            addcomm="0";
                        }
                        if(addcomm!="0")
                        {
                            trdisc1=parseInt(trdisc) + parseInt(addcomm);
                        }
                         var billval=0;
                        if(document.getElementById('agncomm_seq_com').value!="S")
                             billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc1)/100);
                        else
                        {
                             billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc)/100);    
                            if(addcomm!="0" && addcomm!="")
                            {
                                 billval=parseFloat(billval)-(parseFloat(billval)*parseFloat(addcomm)/100);    
                            }
                        }      
                            document.getElementById('txtbillamt').value=formatDecimal(billval,true,2);
                            totor=0;
                     }
                     else if(document.getElementById('hiddenvat').value=="netamount")
                     {
                     
                     
                            document.getElementById('txtgrossamt').value=formatDecimal(parseFloat(totor),true,2)
                            var trdisc=document.getElementById('txttradedisc').value
                            if(trdisc=="")
                                trdisc=0;
                            var trdisc1=trdisc;
                            addcomm =0;
                            if(document.getElementById('txtaddagencycommrate')!=null) 
                            {
                                addcomm=document.getElementById('txtaddagencycommrate').value;
                            }
                            if(addcomm=="")
                            {
                                addcomm="0";
                            }
                            if(addcomm!="0")
                            {
                                trdisc1=parseInt(trdisc) + parseInt(addcomm);
                            }
                             var billval=0;
                            if(document.getElementById('agncomm_seq_com').value!="S")
                                 billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc1)/100);
                            else
                            {
                                 billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc)/100);    
                                if(addcomm!="0" && addcomm!="")
                                {
                                     billval=parseFloat(billval)-(parseFloat(billval)*parseFloat(addcomm)/100);    
                                }
                            }      
                            
                            var strtext="";
                            if(browser!="Microsoft Internet Explorer")
                            {
                                var  httpRequest =null;;
                                httpRequest= new XMLHttpRequest();
                                if (httpRequest.overrideMimeType) {
                                httpRequest.overrideMimeType('text/xml'); 
                                }
                                
                                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                                httpRequest.open( "GET","getvatrate.aspx?grossamt="+billval, false );
                                httpRequest.send('');
                                //alert(httpRequest.readyState);
                                if (httpRequest.readyState == 4) 
                                {
                                    //alert(httpRequest.status);
                                    if (httpRequest.status == 200) 
                                    {
                                        strtext=httpRequest.responseText;
                                    }
                                    else 
                                    {
                                        alert('There was a problem with the request.');
                                    }
                                }
                            }
                            else
                            {
                                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                            
                                xml.Open( "GET","getvatrate.aspx?grossamt="+billval, false );
                                xml.Send();
                                strtext=xml.responseText;   
                            }
                            document.getElementById('txtbillamt').value=formatDecimal(strtext,true,2);
                            totor=0;
                     
                     }
                     else if(document.getElementById('hiddenvat').value=="no")
                     {
                          
                            document.getElementById('txtgrossamt').value=formatDecimal(parseFloat(totor),true,2)
                           var trdisc=document.getElementById('txttradedisc').value
                            if(trdisc=="")
                                trdisc=0;
                            var trdisc1=trdisc;
                            addcomm =0;
                            if(document.getElementById('txtaddagencycommrate')!=null) 
                            {
                                addcomm=document.getElementById('txtaddagencycommrate').value;
                            }
                            if(addcomm=="")
                            {
                                addcomm="0";
                            }
                            if(addcomm!="0")
                            {
                                trdisc1=parseInt(trdisc) + parseInt(addcomm);
                            }
                             var billval=0;
                            if(document.getElementById('agncomm_seq_com').value!="S")
                                 billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc1)/100);
                            else
                            {
                                 billval=parseFloat(document.getElementById('txtgrossamt').value)-(parseFloat(document.getElementById('txtgrossamt').value)*parseFloat(trdisc)/100);    
                                if(addcomm!="0" && addcomm!="")
                                {
                                     billval=parseFloat(billval)-(parseFloat(billval)*parseFloat(addcomm)/100);    
                                }
                            }      
                            document.getElementById('txtbillamt').value=formatDecimal(totor,true,2);
                            totor=0;
                     
                     }
        

}

function bindTable_callback(response)
{
    //alert(response.value);
    var ds=response.value;
    var output = "";
    output = "<table cellpadding=0 cellspacing=0 border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=center>Select</td><td align=center width=\"100px\">Edition</td></tr>";
    for (var i = 0; i < ds.Tables[0].Rows.length; i++)
    {
       output = output + "<tr><td class=\"dtGrid\" align=center><input type=checkbox onclick=\"checkCount('chk" + i + "','" + ds.Tables[0].Rows[i].flag + "');\" value='" + ds.Tables[0].Rows[i].flag+ "' id=chk" + i + " /></td><td align=center class=\"dtGrid\" width=\"100px\" id=td" + i + ">" + ds.Tables[0].Rows[i].Edition_Name + "</td></tr>";
    }
    output=output+"<tr><td></td><td align=right><input type='button' class=\"buttonsmall\" value='Ok' onClick=\"okClick();\"><input type='button' class=\"buttonsmall\" value='Cancel' onClick=\"cancelClick();\"></td></tr>";
    output = output + "</table>";
    document.getElementById('divpkg').innerHTML=output;
    document.getElementById('divpkg').style.display="block";
    document.getElementById('divpkg').style.top=parseInt(document.getElementById('txtpaid').offsetTop) +  parseInt(document.getElementById('tdpck').offsetTop)+ parseInt(document.getElementById('OuterTable').offsetTop) + 328;
    document.getElementById('divpkg').style.left=parseInt(document.getElementById('txtpaid').offsetLeft) +   parseInt(document.getElementById('tdpck').offsetLeft) +200;
}
function okClick()
{
 //   alert("Ok");
 var temp="";
  temp=document.getElementById('hidval').value.split(",");
  //alert(temp.length);
  if(temp.length<parseInt(document.getElementById('hidcount').value))
  {
    alert("Please select "+document.getElementById('hidcount').value + " Edition in this Package");
    return false;
  }
    document.getElementById('divpkg').style.display="none";
    var strid = document.getElementById('drppackage').value;
    AddItem(document.getElementById('drppackagecopy'), document.getElementById('pkgname').value, strid);
}

function cancelClick()
{
    document.getElementById('divpkg').style.display="none";
    
}

function checkCount(id,count)
{
  //  alert(count);
    //alert(document.getElementById('tdtable').getElementsByTagName('table')[0].rows.length-1); 
    

document.getElementById('hidcount').value=count;  
    var i = 0;
    var tot=0;
    document.getElementById('hidval').value="";
    for(i=0;i<document.getElementById('divpkg').getElementsByTagName('table')[0].rows.length-2;i++)
    {
        if(document.getElementById('chk'+i).checked==true)
        {
        tot=tot + 1;
            if(tot>count)
            {
                alert("Can't select more Edition");
                document.getElementById(id).checked=false;
                return false;
            }
            else
            {
            if(document.getElementById('hidval').value=="")
            {
                if(browser!="Microsoft Internet Explorer")
                {
                    document.getElementById('hidval').value=document.getElementById('td'+i).textContent;
                }
                else
                {
                    document.getElementById('hidval').value=document.getElementById('td'+i).innerText;
                }
            }
            else
            {
                if(browser!="Microsoft Internet Explorer")
                {
                    document.getElementById('hidval').value=document.getElementById('hidval').value + "," + document.getElementById('td'+i).textContent;
                }
                else
                {
                    document.getElementById('hidval').value=document.getElementById('hidval').value + "," + document.getElementById('td'+i).innerText;
                }
            }
            }
        }
    }
}
/////////////this is a function to rond of the digit to 2 decimal places
  function formatDecimal(argvalue, addzero, decimaln) {
  var numOfDecimal = (decimaln == null) ? 2 : decimaln;
  var number = 1;

  number = Math.pow(10, numOfDecimal);

  argvalue = Math.round(parseFloat(argvalue) * number) / number;
  // If you're using IE3.x, you will get error with the following line.
  // argvalue = argvalue.toString();
  // It works fine in IE4.
  argvalue = "" + argvalue;

  if (argvalue.indexOf(".") == 0)
    argvalue = "0" + argvalue;

  if (addzero == true) {
    if (argvalue.indexOf(".") == -1)
      argvalue = argvalue + ".";

    while ((argvalue.indexOf(".") + 1) > (argvalue.length - numOfDecimal))
      argvalue = argvalue + "0";
  }

  return argvalue;
}

//////to get the uom in label name
function getlabeluom()
{
        var uomlab=document.getElementById('drpuom').value;
        //var uomsplit=uomlab.split("+");
        document.getElementById('lbmeasure').innerHTML = uomlab;
        document.getElementById('lbbilluom').innerHTML = uomlab;
        document.getElementById('lbmeasuretotal').innerHTML= "Sq" + "&nbsp;" + uomlab;
        
        
	  
        
        return false;

}
/////////this is to bind the rate code drp down

function bindrategroupvode(adcat)
{

    Booking_Master_temp.bindratecode(adcat,document.getElementById('hiddencompcode').value,call_bindrategroupvode);
    return false;
}

function call_bindrategroupvode(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("txtratecode");
     pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {


//alert(pkgitem);

   
    //alert(pkgitem.options.length);
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].rate_mast_code,ds.Tables[0].Rows[i].rate_mast_code);
            
           pkgitem.options.length;
           
        }
    
    }
    document.getElementById('hiddenratecode').value=document.getElementById("txtratecode").value;

}

function getrateoncurrchang()
{
                var adcat=document.getElementById('drpadcategory').value;
                var adscat=document.getElementById('drpadsubcategory').value;
                var uomchk=document.getElementById('drpuom').value;
                //var linesword=document.getElementById('txttotalarea').value;
                var curr=document.getElementById('drpcurrency').value;
                var ratecode=document.getElementById('txtratecode').value;
                var insertsno=document.getElementById('txtinsertion').value;
                //////////////this code is to split the code as well as ites description 
                document.getElementById('hiddencurrency').value=curr;
               var objpack=document.getElementById('drppackagecopy');
                            
                                
                  if(objpack.options.length>0 && adcat!="0" && adscat!="0" && uomchk!="0"  && curr!="0" && ratecode!="0" && insertsno!="")
                  {
                    //gettherate();
                  
                  }


}
function setmatstatus()
{
            var len="bookdiv";
			        if(document.getElementById('tblinsert').innerHTML!="")
                {
                    //var y=parseInt(noofinsertlo)   
                    var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
                    var k;
                    var colid;
                    var i=0;
                    var matsta_var=document.getElementById('drpmatsta');
                        for(k=0;k<y-1;k++)
                        {
                                matsta="mat"+i;
                                document.getElementById(matsta).value=matsta_var.value
                               
                                
                                i=parseInt(i)+1;
                         
                       }
                     
        
                } 

}

//////////////////////this is for davp ad where user enter height and collumn and width comes automatically from 
    //////lay out x table and from that total area comes
    function getwidth()
    {
      
        
//        if(parseInt(document.getElementById('txtcolum').value)>8)
//        {
//            document.getElementById('txtadsize2').disabled=true;
//        }
        
        if(document.getElementById('txtcolum').value!="")
        {
            document.getElementById('txtadsize2').disabled=true;
        }
        else
        {
            document.getElementById('txtadsize2').value="";
            document.getElementById('txttotalarea').value="";
                 document.getElementById('txtbillwidth').value="";
            document.getElementById('txtbillheight').value="";
            document.getElementById('txtadsize2').disabled=false;
             if(document.getElementById('tblinsert').innerHTML!="")
                         {
                            var size;
                            var len="bookdiv";
                            var width;
                            var noofcol;
                            var i=0;
                            var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
                            var y_=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1; 
                                for(k_=0;k_<y_;k_++)
                                {
                                
                              
                                      
                                     size="siz"+i;
                                     width="wid"+i;
                                     noofcol="nocol"+i;
                                     var size_var=document.getElementById(size);
                                     var par1=(size_var.parentNode).parentNode;
                                  if(browser!="Microsoft Internet Explorer")
                             {
                                     document.getElementById(size).value="";
                                     document.getElementById(width).value="";
                                     document.getElementById(width).disabled=false;
                                     document.getElementById(noofcol).value="";
                             }
                             else
                             {
                                     par1.all[size].value="";
                                     par1.all[width].value="";
                                     par1.all[width].disabled=false;
                                     par1.all[noofcol].value="";
                                  }   
                                     
                                     i++;
                                     
                                }   
    
    
                            }
        }
        
        var objpack=document.getElementById('drppackagecopy');
                            var temp="";
                            var tempcode="";
                            var tempval="";
                            var tempvalcode="";
                            var desc="";
                            var code="";
                            var codesplit="";
                            var i=objpack.options.length;
                            var j;

                                for(j=0;j<i;j++)
                                {
                                    if(parseInt(i)>0)
                                    {
                                        tempval=objpack[j].value;
                                        //tempvalcode=objpack[j].value;
                                        if(temp!="")
                                        {
                                            temp=tempval.split("@");
                                            tempvalcode=temp[0];
                                            tempcode=temp[1];
                                            desc=tempcode+"+"+desc;
                                              desc=tempcode.substr(0,tempcode.lastIndexOf("("))+"+"+desc;
                                            
                                        }
                                        else
                                        {
                                            temp=tempval.split("@");
                                            tempvalcode=temp[0];
                                            tempcode=temp[1];
                                            desc=tempcode;
                                             desc=tempcode.substr(0,tempcode.lastIndexOf("("));
                                        }
                                    }
                                
                                }
                                document.getElementById('drppageposition').focus();
              Booking_Master_temp.getwidthforcoll(desc,document.getElementById('txtcolum').value,document.getElementById('hiddencompcode').value,call_getwidthforcoll);
              return false;
    
    }
    function call_getwidthforcoll(res)
    {
        var ds=res.value
        if(ds.Tables[0].Rows.length>0)
        {//formatDecimal(totor,true,2);
           
                document.getElementById('txtadsize2').value=ds.Tables[0].Rows[0].col_cc
            if(document.getElementById('txtadsize1').value!="")
            {
                document.getElementById('txttotalarea').value=formatDecimal(parseFloat(document.getElementById('txtadsize1').value)*parseFloat(document.getElementById('txtadsize2').value),true,2);
                document.getElementById('txtbillwidth').value=document.getElementById('txtadsize1').value;
                document.getElementById('txtbillheight').value=document.getElementById('txtadsize2').value;
            }
             if(ds.Tables[1].Rows.length>0)
            {
                glob_area=ds.Tables[1].Rows[0].edition_area;
            }
            
        
        }
        else 
        {
            alert("Booking not be possible");
            return false;
        
        }
        
        if(document.getElementById('tblinsert').innerHTML!="")
        {
            var size;
            var len="bookdiv";
            var width;
            var noofcol;
            var height;
            var i=0;
            var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
            y=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1; 
            var totalarea_var=document.getElementById('txttotalarea');
            var adsize2_var=document.getElementById('txtadsize2');
            var adsize1_var=document.getElementById('txtadsize1');
            var col_var=document.getElementById('txtcolum');
                                for(k=0;k<y;k++)
                                {
                                
                              
                                      
                                     size="siz"+i;
                                     width="wid"+i;
                                     noofcol="nocol"+i;
                                     height="hei"+i;
                                     var size_var=document.getElementById(size);
                                     var par1=(size_var.parentNode).parentNode;
                                     if(browser!="Microsoft Internet Explorer")
                             {
                                     document.getElementById(size).value=totalarea_var.value;
                                     document.getElementById(width).value=adsize2_var.value;
                                     document.getElementById(height).value=adsize1_var.value;
                                     document.getElementById(noofcol).value=col_var.value;
                             
                             }
                             else
                             {
                                     par1.all[size].value=totalarea_var.value;
                                     par1.all[width].value=adsize2_var.value;
                                     par1.all[height].value=adsize1_var.value;
                                     par1.all[noofcol].value=col_var.value;
                                     
                                }     
                                     i++;
                                     
                                }   
    
    
        }
        
    
    
    
    }
    
    
    
    /////this is to fill the rol or row into the insertion grid if it is visibile
function fillnooflineintogrid()
{

    if(document.getElementById('drppackagecopy').options.length==0)
        {
            alert("Please select the package");
            return false;
            
        }

//////if uom is cd and booking is on no. of column and total area in that case if the user fill only no of column and 
//////total area than hei and wid comes automatically
    if(document.getElementById('drpuom').value=="0")
    {
        alert("Please select uom");
        document.getElementById('txttotalarea').value="";
       // document.getElementById('drpuom').focus();
        return false;
    
    }
   
      
        
        
            if(glob_area!="")
            {
                if(parseFloat(document.getElementById('txttotalarea').value)>parseFloat(glob_area))
                {
                            alert("Total area exceeds with edition area");
                            return false;
                }
            }
                    if(document.getElementById('txtcolum').value!="")
                    {  
                            var totare=document.getElementById('txttotalarea').value
                            var wid=document.getElementById('txtadsize2').value
                            document.getElementById('txtadsize1').value=formatDecimal(parseFloat(totare)/parseFloat(wid),true,2);
                            document.getElementById('txtbillwidth').value=document.getElementById('txtadsize1').value;
                            document.getElementById('txtbillheight').value=document.getElementById('txtadsize2').value;
                    }
                     else if(document.getElementById('txtadsize1').value!="" && document.getElementById('txtadsize2').value=="")
                    {
                            var totare=document.getElementById('txttotalarea').value
                            var h_=document.getElementById('txtadsize1').value
                            document.getElementById('txtadsize1').value=formatDecimal(parseFloat(totare)/parseFloat(h_),true,2);
                            document.getElementById('txtbillwidth').value=document.getElementById('txtadsize1').value;
                            document.getElementById('txtbillheight').value=document.getElementById('txtadsize2').value;
                    
                    }
                    else if(document.getElementById('txtadsize2').value!="" && document.getElementById('txtadsize1').value=="")
                    {
                            var totare=document.getElementById('txttotalarea').value
                            var wid=document.getElementById('txtadsize2').value
                            document.getElementById('txtadsize1').value=formatDecimal(parseFloat(totare)/parseFloat(wid),true,2);
                            document.getElementById('txtbillwidth').value=document.getElementById('txtadsize1').value;
                            document.getElementById('txtbillheight').value=document.getElementById('txtadsize2').value;
                    
                    
                    }
                    
   

                    var len="bookdiv";
                    var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
                    var k;
                    var i=0;
                    var width;
                    var noofcol;
                    var height;
                    var totid=parseInt(noofinsert)/parseInt(document.getElementById('txtinsertion').value)
                     var totalarea_var=document.getElementById('txttotalarea');
                    var adsize2_var=document.getElementById('txtadsize2');
                    var adsize1_var=document.getElementById('txtadsize1');
                    var col_var=document.getElementById('txtcolum');
                    if(document.getElementById('tblinsert').innerHTML!="")
                    {
                                                for(k=0;k<y;k++)
                                                {
                                                
                                              
                                                 
                                                      
                                                     size="siz"+i;
                                                     width="wid"+i;
                                                     noofcol="nocol"+i;
                                                     height="hei"+i;
                                                    var size_var=document.getElementById(size);
                                                     var par1=(size_var.parentNode).parentNode;
                                            if(browser!="Microsoft Internet Explorer")
                                                {
                                                     document.getElementById(size).value=totalarea_var.value;
                                                     document.getElementById(width).value=adsize2_var.value;
                                                     document.getElementById(height).value=adsize1_var.value;
                                                     document.getElementById(noofcol).value=col_var.value;
                                                }
                                            else
                                                {
                                                     par1.all[size].value=totalarea_var.value;
                                                     par1.all[width].value=adsize2_var.value;
                                                     par1.all[height].value=adsize1_var.value;
                                                     par1.all[noofcol].value=col_var.value;
                                                }
                                     
                                                     i++;
                                                     
                                                }   
                    
                    
                    }
                               

}

 function contractapply()
           {
                if(document.getElementById('chkcontract').checked==false)
                {
                    document.getElementById('txtcontractname').value=""
                    document.getElementById('txtcontracttype').value=""
                    document.getElementById('txtdealrate').value="";
                    document.getElementById('txtdeviation').value="";
                    if(document.getElementById('txtgrossamt').value!="")
                    {
                        fillrateintogrid();
                    }
                
                }
                return;
            
           }
           
function changediv()
{
    if(document.getElementById('LinkButton1').disabled==true)
        return false;
    //*25Aug* check for retainer or Executive
    if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
    {
        alert('Please fill Execute Name or Retainer.');
        document.getElementById('drpretainer').focus();
        return false;
    }
    //
        if(enLink=="1")
        {
            document.getElementById('LinkButton1').disabled=false;
            document.getElementById('LinkButton2').disabled=false;
            document.getElementById('LinkButton3').disabled=false;
            document.getElementById('LinkButton4').disabled=false;
            document.getElementById('LinkButton5').disabled=false;
            document.getElementById('LinkButton6').disabled=false;
            document.getElementById('LinkButton7').disabled=false;
        }
		if(document.getElementById('LinkButton1').disabled==false)
		{
		
		if(document.getElementById('txtagency').value=="")
		{
		    alert("Please fill the Agency Code");
		    document.getElementById('txtagency').focus();
		    return false;
		}
		else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
		{
		    alert("Please select the agency sub code");
		    document.getElementById('drpagscode').focus();
		    return false;
		
		}
		if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
        {
            if(document.getElementById('txtrodate').value=="")
            {
                alert("Please fill ro date");
                document.getElementById('txtrodate').focus();
                return false;            
            }
    
        }
		
		document.getElementById('LinkButton1').style.fontWeight="bold";
		document.getElementById('LinkButton1').style.color="#FFFF80";
		document.getElementById('LinkButton3').style.fontWeight="normal";
		document.getElementById('LinkButton3').style.color="White";
		document.getElementById('LinkButton2').style.fontWeight="normal";
		document.getElementById('LinkButton2').style.color="White";
		document.getElementById('LinkButton5').style.fontWeight="normal";
		document.getElementById('LinkButton5').style.color="White";
		document.getElementById('LinkButton4').style.fontWeight="normal";
		document.getElementById('LinkButton4').style.color="White";
		document.getElementById('LinkButton6').style.fontWeight="normal";
		document.getElementById('LinkButton6').style.color="White";
		document.getElementById('LinkButton7').style.fontWeight="normal";
		document.getElementById('LinkButton7').style.color="White";
		document.getElementById('tblrate').style.display="none";
		document.getElementById('tblbill').style.display="none";
		//alert(document.getElementById('LinkButton1').click);
		document.getElementById('addetails').style.display="block";
		if(document.getElementById('drpbooktype').disabled==false)
		{
		    document.getElementById('drpbooktype').focus();
		}
		document.getElementById('pagedetail').style.display="none";
		//document.getElementById('tblsize').style.display="none";
		document.getElementById('tblpackage').style.display="none";
		document.getElementById('tbbox').style.display="none";
		document.getElementById('tbvts').style.display="none";
		return false;
	}
}

    function changediv1()
    {
    
        if(document.getElementById('LinkButton2').disabled==true)
            return false;
        //*25Aug* check for retainer or Executive
        if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
        {
            alert('Please fill Execute Name or Retainer.');
            return false;
        }
        //////////////
		if(enLink=="1")
        {
            document.getElementById('LinkButton1').disabled=false;
            document.getElementById('LinkButton2').disabled=false;
            document.getElementById('LinkButton3').disabled=false;
            document.getElementById('LinkButton4').disabled=false;
            document.getElementById('LinkButton5').disabled=false;
            document.getElementById('LinkButton6').disabled=false;
            document.getElementById('LinkButton7').disabled=false;
        }
		if(document.getElementById('LinkButton2').disabled==false)
		{
		    if(document.getElementById('txtagency').value=="")
		    {
		        alert("Please fill the Agency Code");
		        document.getElementById('txtagency').focus();
		        return false;
		    }
		    else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
		    {
		        alert("Please select the Agency Sub Code");
		        document.getElementById('drpagscode').focus();
		        return false;
		
		    }
		    if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
            {
                if(document.getElementById('txtrodate').value=="")
                {
                    alert("Please fill ro date");
                    document.getElementById('txtrodate').focus();
                    return false;            
                }
    
            }
		if(document.getElementById('drpbooktype').value=="0")
{
    alert("Please Select Booking Type");
    return false;
}    
if(document.getElementById('drpcolor').value=="0")
{
    alert("Please Select Color");
    return false;
}   
if(document.getElementById('drpadcategory').value=="0")
{
    alert("Please Select Ad Category");
    return false;
}   
if(document.getElementById('drpuom').value=="0")
{
    alert("Please Select UOM");
    return false;
}  
if(document.getElementById('drppackagecopy').options.length==0)
{
    alert("Please Select Package");
    return false;
}  
if(document.getElementById('txtdummydate').value=="")
{
    alert("Please Enter Date");
    return false;
} 
if(document.getElementById('drpcurrency').value=="0")
{
    alert("Please Select Currency");
    return false;
} 

		    document.getElementById('LinkButton2').style.fontWeight="bold";
		    document.getElementById('LinkButton2').style.color="#FFFF80";
		    document.getElementById('LinkButton3').style.fontWeight="normal";
		    document.getElementById('LinkButton3').style.color="White";
		    document.getElementById('LinkButton4').style.fontWeight="normal";
		    document.getElementById('LinkButton4').style.color="White";
		    document.getElementById('LinkButton5').style.fontWeight="normal";
		    document.getElementById('LinkButton5').style.color="White";
		    document.getElementById('LinkButton1').style.fontWeight="normal";
		    document.getElementById('LinkButton1').style.color="White";
		    document.getElementById('LinkButton6').style.fontWeight="normal";
		    document.getElementById('LinkButton6').style.color="White";
	        document.getElementById('LinkButton7').style.fontWeight="normal";
		    document.getElementById('LinkButton7').style.color="White";
		    document.getElementById('tblrate').style.display="none";
		    document.getElementById('tblbill').style.display="none";
		//alert(document.getElementById('LinkButton1').click);
		    document.getElementById('pagedetail').style.display="block";
		    if(document.getElementById('drpadstype').disabled==false)
		    {
		        document.getElementById('drpadstype').focus();
		    }
		    document.getElementById('addetails').style.display="none";
		    //document.getElementById('tblsize').style.display="none";
		    document.getElementById('tblpackage').style.display="none";
		    document.getElementById('tbbox').style.display="none";
		    document.getElementById('tbvts').style.display="none";
		    return false;
		}
    }
           
           
    function newclick()
    {
           var msg=checkSession();
         if(msg==false)
         {
            window.location.href="login.aspx";
            return false;
         } 
        enLink="1";
        cali=0;
        document.getElementById('hiddenprint_rec').value="";
        document.getElementById('hiddenreceiptno').value="";
        document.getElementById('hiddensavemod').value = "0";
         document.getElementById('txtdatetime').value=document.getElementById('currdate').value;
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton2').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton5').disabled = false;
        document.getElementById('LinkButton6').disabled = false;
        document.getElementById('LinkButton7').disabled = false;
        document.getElementById('btnshgrid').disabled = false;
        
        document.getElementById('drpbooktype').disabled = false;
        document.getElementById('txtciobookid').disabled = true;
        document.getElementById('txtrono').disabled = false;
        document.getElementById('txtrodate').disabled = false;
        document.getElementById('drpbillstatus').disabled = false;
        document.getElementById('drprostatus').disabled = false;
        document.getElementById('txtagency').disabled = false;
        document.getElementById('txtclient').disabled = false;
        if(document.getElementById('hiddenaddAgencyComm').value=="Y" && document.getElementById('txtaddagencycommrate')!=null)
        {
            document.getElementById('txtaddagencycommrate').disabled = false;
            document.getElementById('txtaddagencycommrateamt').disabled = false;
        }    
        document.getElementById('txtRetainercomm').disabled=false;
        document.getElementById('drppagetype').disabled = false;
        document.getElementById('drppagetype').value="0";
        document.getElementById('txtpageno').disabled = false;
        document.getElementById('txtpageno').value="";
        document.getElementById('drpadstype').disabled=false;
        document.getElementById('drpadstype').value="0";
        document.getElementById('txtspedisc').disabled=false;
       
        document.getElementById('txtspacedisc').disabled=false;
        document.getElementById('txtspediscper').disabled=false;
         document.getElementById('txtspediscper').value="";
        document.getElementById('txtspadiscper').disabled=false;
        document.getElementById('txtspadiscper').value="";
        document.getElementById('txtcaption').disabled=false;
        document.getElementById('txtcaption').value="";
        
        document.getElementById('txtcamp').disabled=false;
        document.getElementById('drppageprem').disabled=false;
        document.getElementById('drppageprem').value="0";
        document.getElementById('chkcoupan').disabled=false;
        document.getElementById('txtclientadd').disabled = false;
        document.getElementById('drpagscode').disabled = false;
        document.getElementById('txtdockitno1').disabled = true;
        document.getElementById('txtexecname').disabled = false;
        document.getElementById('txtexeczone').disabled = false;
        document.getElementById('txtproduct').disabled = false;
        document.getElementById('drpbrand').disabled = false;
        document.getElementById('txtkeyno').disabled = false;        
        document.getElementById('txtbillremark').disabled = false;
        document.getElementById('txtprintremark').disabled = false;
        document.getElementById('drppackage').disabled = false;
        document.getElementById('txtinsertion').disabled = false;
        document.getElementById('txtdummydate').disabled = false;
        document.getElementById('txtrepeatingdate').disabled = false;
        document.getElementById('drpbooktype').disabled = false;
        document.getElementById('drpadcategory').disabled = false;
        document.getElementById('drpadsubcategory').disabled = false;
        document.getElementById('drpcolor').disabled = false;        
        document.getElementById('drpuom').disabled = false;
        document.getElementById('drppageposition').disabled = false;
        document.getElementById('txtratecode').disabled = false;
        document.getElementById('drpscheme').disabled = false;        
        document.getElementById('drpcurrency').disabled = false;
        document.getElementById('txtagreedrate').disabled = false;
        document.getElementById('txtagreedamt').disabled = false;
        document.getElementById('txtextracharges').disabled = false;
        document.getElementById('drpvarient').disabled = false;
        document.getElementById('drpvarient').value="0";
        
        document.getElementById('txtdatetime').disabled = true;
        document.getElementById('txtrepeatingdate').disabled = false;
        document.getElementById('drpbillcycle').disabled = false;
        document.getElementById('drprevenue').disabled = false;
        document.getElementById('drpbillstatus').disabled = false;
        document.getElementById('drppaymenttype').disabled = false;
        document.getElementById('txtinvoice').disabled = false;
        document.getElementById('txtvts').disabled = false;
        
        document.getElementById('txtbillwidth').disabled = false;
        document.getElementById('txtbillheight').disabled = false;
        document.getElementById('drpbillto').disabled = false;
        document.getElementById('txttradedisc').disabled = false;
        document.getElementById('txtagencyoutstand').disabled = true;
        document.getElementById('txtcardrate').disabled = true;
        document.getElementById('txtcardamt').disabled = true;
        document.getElementById('txtdiscount').disabled = true;
        document.getElementById('txtdiscpre').disabled = true;
        document.getElementById('txtadsize2').disabled = false;
        document.getElementById('txtadsize1').disabled = false;        
        document.getElementById('txttotalarea').disabled = true;
        document.getElementById('txtbilladdress').disabled = false;
        document.getElementById('drpboxcode').disabled = false;        
        document.getElementById('txtboxaddress').disabled = false;        
        document.getElementById('txtbillamt').disabled = true;
        document.getElementById('txtgrossamt').disabled = true;       
        document.getElementById('chkage').disabled = false;
        document.getElementById('chkclie').disabled = false;
        document.getElementById('chktfn').disabled = false;        
        
        document.getElementById('txtinsertion').disabled = false;
        document.getElementById('txtcolum').disabled = false;
        document.getElementById('txtcardname').disabled = false;
        document.getElementById('drptype').disabled = false;
        document.getElementById('drpmonth').disabled = false;
        document.getElementById('drpyear').disabled = false;
        
        document.getElementById('txtcardno').disabled = false;
        document.getElementById('txtagencypaymode').disabled = true;
        document.getElementById('btncopy').disabled = false;
        document.getElementById('btnshgrid').disabled = false;
        document.getElementById('btndeal').disabled = false;
        document.getElementById('drpadcat3').disabled = false;
        document.getElementById('drpadcat3').value="0";
        document.getElementById('drpadcat4').disabled = false;
        document.getElementById('drpadcat3').options.length=0;
        document.getElementById('drpadcat4').options.length=0;
        document.getElementById('drpadcat4').value="0";
       // document.getElementById('drpbgcolor').disabled = false;
        document.getElementById('drpadcat5').disabled = false;
        document.getElementById('drpadcat5').options.length=0;
        document.getElementById('drpadcat5').value="0";
       // document.getElementById('drpbgcolor').value = "0";
       // document.getElementById('drpbullet').disabled = false;
       
        document.getElementById('ttextchqno').disabled = false;    
         document.getElementById('drpourbank').disabled=false;                    
        document.getElementById('ttextchqdate').disabled = false;
        document.getElementById('ttextchqamt').disabled = false;
        document.getElementById('ttextbankname').disabled = false;
      
        document.getElementById('drpmatsta').value = "0";       
        document.getElementById('drpmatsta').disabled = false;

        document.getElementById('drpretainer').disabled = false;
        if(document.getElementById('txtaddagencycommrate')!=null)
        {
            document.getElementById('txtaddagencycommrate').disabled = false;
            document.getElementById('txtaddagencycommrate').value = "";
        }
         if(document.getElementById('txtaddagencycommrateamt')!=null)
        {
            document.getElementById('txtaddagencycommrateamt').disabled = false;
            document.getElementById('txtaddagencycommrateamt').value = "";
        }
        document.getElementById('drpmatsta').value = "0";

        document.getElementById('txtcontractname').value =  "";
        document.getElementById('txtcontracttype').value =  "";
        document.getElementById('txtcardname').value =  "";
        document.getElementById('drptype').value =   "0";
        document.getElementById('drpmonth').value =  "0";
        document.getElementById('drpyear').value = "0";
        document.getElementById('txtcardno').Text = "";
        //////////////////////////////

        document.getElementById('txtcolum').value = "";        
        document.getElementById('txtbillamt').value = "";        
        document.getElementById('txtrono').value = "";
        document.getElementById('txtbilladdress').value = "";
        document.getElementById('txtrodate').value = "";
        
        document.getElementById('drpbillstatus').value = "0";
        document.getElementById('drprostatus').value = "1";
        document.getElementById('txtagency').value = "";
        document.getElementById('txtclient').value = "";
        document.getElementById('txtagencyaddress').value = "";
        document.getElementById('txtclientadd').value = "";
        document.getElementById('drpagscode').value = "0";
        document.getElementById('txtdockitno1').value = "";
        document.getElementById('txtexecname').value = "";
        document.getElementById('txtexeczone').value = "";
        document.getElementById('txtproduct').value = "";
        document.getElementById('drpbrand').value = "0";
        document.getElementById('txtkeyno').value = "";
        document.getElementById('txtbillremark').value = "";
        document.getElementById('txtprintremark').value = "";     
        document.getElementById('txtinsertion').value = "";
        document.getElementById('txtdummydate').value = "";
        document.getElementById('txtrepeatingdate').value = "";

        document.getElementById('drpadcategory').value = "0";
        document.getElementById('drpadsubcategory').value = "0";
        document.getElementById('drpcolor').value = "0";
        document.getElementById('drpuom').value = "0";
        document.getElementById('drppageposition').value = "0";
        document.getElementById('txtratecode').value = "0";
        document.getElementById('drpscheme').value = "";
  
        document.getElementById('drpcurrency').value = "0";
        document.getElementById('txtagreedrate').value = "";
        document.getElementById('txtagreedamt').value = "";
 
        document.getElementById('txtextracharges').value = "";
        document.getElementById('drpbillcycle').value = "0";
      //  document.getElementById('drprevenue').value = "0";
       
        document.getElementById('drpbillstatus').value = "0";
      
        document.getElementById('txtagencypaymode').options.length=0;
        document.getElementById('drppaymenttype').options.length=0;
        document.getElementById('txtinvoice').value = "";
        document.getElementById('txtvts').value = "";
        document.getElementById('txtbillwidth').value = "";
        document.getElementById('txtbillheight').value = "";
    
        document.getElementById('drpbillto').options.length=0;
        document.getElementById('txttradedisc').value = "";
        document.getElementById('txtagencyoutstand').value = "";
        document.getElementById('txtcardrate').value = "";
        document.getElementById('txtcardamt').value = "";
        document.getElementById('txtdiscount').value = "";
        document.getElementById('txtdiscpre').value = "";
        document.getElementById('txtadsize2').value = "";
        document.getElementById('txtadsize1').value = "";
        document.getElementById('txttotalarea').value = "";
        document.getElementById('drpboxcode').value = "0";
        document.getElementById('txtboxno').value = "";
        document.getElementById('txtboxaddress').value = "";
        
        document.getElementById('txtgrossamt').value = "";
        document.getElementById('drppackage').value = "0";
        document.getElementById('drppackagecopy').options.length=0;

        document.getElementById('drpboxcode').value = "0";
        document.getElementById('chkage').checked = false;
        document.getElementById('chkclie').checked = false;
        document.getElementById('chktfn').checked = false;
        document.getElementById('chkcoupan').checked = false;
        document.getElementById('txtboxaddress').value = "";
        document.getElementById('txtinsertion').value = "";
        document.getElementById('drpbooktype').value = "3";
        
        document.getElementById('drpretainer').value = "";
       
        document.getElementById('ttextchqno').value = "";
         document.getElementById('drpourbank').value="0";            
        document.getElementById('ttextchqdate').value = "";
        document.getElementById('ttextchqamt').value = "";
        document.getElementById('ttextbankname').value = "";
        
        //credit info
         document.getElementById('tdcarname').style.display="none";
         document.getElementById('tdtxtcarname').style.display="none";
         document.getElementById('tdtype').style.display="none";
         document.getElementById('tddrptyp').style.display="none";
         document.getElementById('tdexdat').style.display="none";
            
         document.getElementById('tdtxtexdat').style.display="none";
         document.getElementById('tdcardno').style.display="none";
         document.getElementById('tdtxtcarno').style.display="none";  

         document.getElementById('txtcardname').value="";
         document.getElementById('drptype').value=0;
         document.getElementById('drpmonth').value=0;
         document.getElementById('drpyear').value=0;
         document.getElementById('txtcardno').value="";
        
        /////////if 0 than autogenerate the cio booking id and if 1 than autogenerate dockit no.
        autogenerated("0");
        rownumEx=0;

        chkstatus(document.getElementById('hiddenbuttonidcheck').value);
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnsavepaginate').disabled = true;
       
        document.getElementById('drpcurrency').value = document.getElementById('hiddencurrency').value;
       // document.getElementById('drpuom').value=document.getElementById('hiddenuom').value;
        if(document.getElementById('drpuom').selectedIndex!=-1 && document.getElementById('drpuom').selectedIndex!=0)
        {
        document.getElementById('lbmeasure').value = document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;
        document.getElementById('lbbilluom').value = document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;
        document.getElementById('lbmeasuretotal').value = "Sq" + "&nbsp;" + document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;
        }
         if(document.getElementById('drprevenue').selectedIndex!="-1")
        {
        document.getElementById('hiddenbranch').value = document.getElementById('drprevenue').options[document.getElementById('drprevenue').selectedIndex].text;//drprevenue.SelectedItem.Text.ToString();
        }
        document.getElementById('btndel').disabled=false;
        document.getElementById('tblinsert').innerHTML='';
        document.getElementById('txtagency').focus();
    return false;
}


function autogenerated(no)
{
   //Booking id
    if (no == "0")
    {
         var dt= new Date()
         var auto = "";
         var cen = document.getElementById('hiddencenter').value;
         cen = cen.substring(0, 3);            
         var year = dt.getFullYear();
         var zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
        if (document.getElementById('hiddencioidformat').value == "1")
        {
            auto = cen + year;
        }
        else if (document.getElementById('hiddencioidformat').value == "2")
        {
            auto = cen + year + document.getElementById('hiddenuserid').value;
        }

        var autogen = auto + "0";
        var res=Booking_Master_temp.getBookingIdNo(document.getElementById('hiddencompcode').value,auto,no,document.getElementById('txtciobookid').value);
        var da=res.value;
        if(da==null)
        {
            alert(res.error.description);
            return false;
        }   
        if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].ID != "")
        {
            var ab = da.Tables[0].Rows[0].ID;
            var cou1 = parseInt(ab,10);           
            var countlen = cou1.toString().length;
            if (countlen == 1)
            {
                zeros = "0000000" + cou1;
            }
            else if (countlen == 2)
            {
                zeros = "000000" + cou1;
            }
            else if (countlen == 3)
            {
                zeros = "00000" + cou1;
            }
            else if (countlen == 4)
            {
                zeros = "0000" + cou1;
            }
            else if (countlen == 5)
            {
                zeros = "000" + cou1;
            }
            else if (countlen == 6)
            {
                zeros = "00" + cou1;
            }
            else if (countlen == 7)
            {
                zeros = "0" + cou1;
            }
            else if (countlen == 8)
            {
                zeros = "0" + cou1;
            }

            document.getElementById('txtciobookid').value = auto + zeros;
        }
        else
        {
            document.getElementById('txtciobookid').value = autogen;

        }
    }
    //Dokit number
    else if (no == "1")
    {
         var auto = "DN";
         var autogen = auto + "0";
         var res=Booking_Master_temp.getBookingIdNo(document.getElementById('hiddencompcode').value,auto,no,document.getElementById('txtciobookid').value);
         var da=res.value;
         if(da==null)
         {
               alert(res.error.description);
               return false;
          }   
          if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].ID != "")
          {
                var ab = da.Tables[0].Rows[0].ID;
                var cou1 = parseInt(ab,10);
                cou1++;
                document.getElementById('txtdockitno1').value = auto + cou1;
          }
          else
          {
                document.getElementById('txtdockitno1').value = autogen;
          }

     }
     else if (no == "2")
     {
          var auto = "BN";
          var autogen = auto + "0";
          var res=Booking_Master_temp.getBookingIdNo(document.getElementById('hiddencompcode').value,auto,no,document.getElementById('txtciobookid').value);
          var da=res.value;
          if(da==null)
          {
               alert(res.error.description);
               return false;
          }   
          if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].boxno != "" && da.Tables[0].Rows[0].boxno!=undefined)
          {
               var ab = da.Tables[0].Rows[0].boxno;
               var cou1 = parseInt(ab,10);
               cou1++;
               document.getElementById('txtboxno').value = auto + cou1;
          }
          else
          {
               document.getElementById('txtboxno').value = autogen;
          }


     }

        //get max receipt number 
     else if (no == "3")
     {
          var res=Booking_Master_temp.getBookingIdNo(document.getElementById('hiddencompcode').value,"",no,document.getElementById('txtciobookid').value);
          var da=res.value;
            //***************************************
           if(da==null)
           {
               alert(res.error.description);
               return false;
           }   
           var max_number = "0";
           if (da.Tables[0].Rows[0].recno.toString().length == 1)
                max_number = "000" + da.Tables[0].Rows[0].recno;
           else if (da.Tables[0].Rows[0].recno.toString().length == 2)
                max_number = "00" + da.Tables[0].Rows[0].recno;
           else if (da.Tables[0].Rows[0].recno.toString().length == 3)
                max_number = "0" + da.Tables[0].Rows[0].recno;
           else
                max_number = da.Tables[0].Rows[0].recno;
                 //for sambad only
           if (document.getElementById('hiddenprereceipt').value == "6")
           {
               
               document.getElementById('txtreceipt').value = "D-BHU-" + max_number;
               document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
           }
           else //for sambad only    
            if (document.getElementById('hiddenpaymode').value == "CASH")
            {
                document.getElementById('txtreceipt').value = "R/" + document.getElementById('hiddenhidReceipt').value + max_number;
                document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
            }
            else
            {
                document.getElementById('txtreceipt').value = document.getElementById('hiddenhidReceipt').value + max_number;
                document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
            }
        }
    
    }


function chkstatus(FlagStatus)
{
    if (FlagStatus == 0 || FlagStatus == 8)
    {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnsavepaginate').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnCancel').disabled = true;
        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnExit').disabled = true;
    }
        if (FlagStatus == 1 || FlagStatus == 9)
        {
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnExecute').disabled = true;            
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled=false;
            document.getElementById('btnsavepaginate').disabled = true;
            document.getElementById('btnCancel').disabled = false;

        }
        if (FlagStatus == 2 || FlagStatus == 10)
        {
            document.getElementById('btnExecute').disabled = false;   
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnsavepaginate').disabled =true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;           
        }

        if (FlagStatus == 3 || FlagStatus == 11)
        {
            document.getElementById('btnExecute').disabled = false;   
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = false;
            document.getElementById('btnsavepaginate').disabled =false;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;            
           
        }

        if (FlagStatus == 4 || FlagStatus == 12)
        {
            document.getElementById('btnExecute').disabled = false;   
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnsavepaginate').disabled =true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true; 
           
        }
        if (FlagStatus == 5 || FlagStatus == 13)
        {
            document.getElementById('btnExecute').disabled = false;   
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnsavepaginate').disabled =true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true; 
            
        }
        if (FlagStatus == 6 || FlagStatus == 14)
        {
            document.getElementById('btnExecute').disabled = false;   
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnsavepaginate').disabled =true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;             
          
        }
        if (FlagStatus == 7 || FlagStatus == 15)
        {
            document.getElementById('btnExecute').disabled = false;   
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = false;
            document.getElementById('btnsavepaginate').disabled =true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;           
        }

    }

// fill page no in  insertion   grid....
function fillpgnogrid()
{
    var len="bookdiv";
    if(document.getElementById('tblinsert').innerHTML!="")
    {
        //var y=parseInt(noofinsertlo)   
        var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
        var k;
        var colid;
        var i=0;
        var pageno_var=document.getElementById('txtpageno');
        for(k=0;k<y-1;k++)
        {
            colid="pagno"+i;
            document.getElementById(colid).value=pageno_var.value
            i=parseInt(i)+1;
        }
    }    
}

function checkro()
{
    
    if(document.getElementById('txtrono').value=="")
    {
        if(confirm('Are you sure you want to create Dokit Booking?'))
        {
           
        }
        else
        {
            document.getElementById('txtrono').focus();
        }        
    }
}



function bindadscat3()
{

    var adscat=document.getElementById('drpadsubcategory').value;
    var compcode=document.getElementById('hiddencompcode').value;
    ///if 0 than it is to bind ad cat3 drp down
    var res=Booking_Master_temp.bindadcat3(adscat,compcode,"0");
    call_bindadcat3(res);
    return false;


}


function call_bindadcat3(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("drpadcat3");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select ad s cat-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        for(var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
            pkgitem.options.length;
        }
    
    }
    document.getElementById('hiddenadscat3').value=document.getElementById("drpadcat3").value;
    document.getElementById("drpadcat4").value="0";
    document.getElementById("drpadcat4").options.length=1;
    document.getElementById("drpadcat5").value="0";
    document.getElementById("drpadcat5").options.length=1;
}


///this is to bind the adcat 4 drop down on change of adcat 3 dropdown

function bindadscat4()
{
    document.getElementById('txtcardrate').value="";
    document.getElementById('txtgrossamt').value="";
    var adscat=document.getElementById('drpadcat3').value;
    document.getElementById('hiddenadscat3').value=document.getElementById("drpadcat3").value;
    document.getElementById('hiddenadscat4').value="";
    document.getElementById('hiddenadscat5').value="";
    var compcode=document.getElementById('hiddencompcode').value;
    document.getElementById('drpadcat5').options.length=0;
    var res=Booking_Master_temp.bindadcat3(adscat,compcode,"1");
    ///if 1 than it is to bind ad cat4 drp down 
    call_bindadcat4(res);
    return false;
}

function call_bindadcat4(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("drpadcat4");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select ad s cat-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
            pkgitem.options.length;

        }
    }
    document.getElementById('hiddenadscat4').value=document.getElementById("drpadcat4").value;
}

///////this is to bind the adcat 5 drop down on change of adcat 4 drop down

function bindadcat5()
{
    document.getElementById('txtcardrate').value="";
	document.getElementById('txtgrossamt').value="";
    var adscat=document.getElementById('drpadcat4').value;
    document.getElementById('hiddenadscat4').value=document.getElementById("drpadcat4").value;
    document.getElementById('hiddenadscat5').value="";
    var compcode=document.getElementById('hiddencompcode').value;
    var res=Booking_Master_temp.bindadcat3(document.getElementById("drpadcat4").value,compcode,"2");
    
    ///if 2 than it is to bind ad cat5 drp down 
    call_bindadcat5(res);
    return false;

}

function call_bindadcat5(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("drpadcat5");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select ad s cat-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                pkgitem.options.length;
            }
    }
    document.getElementById('hiddenadscat5').value=document.getElementById("drpadcat5").value;
}

//used for additional commission
function getAddlAgencyComm()
{
    if(document.getElementById('txtgrossamt').value=='')
    {
        document.getElementById('txtaddagencycommrate').value="";
        document.getElementById('txtaddagencycommrateamt').value="";
    }
    if(document.getElementById('txtaddagencycommrateamt')!=null && document.getElementById('txtaddagencycommrateamt').value=="" || document.getElementById('txtaddagencycommrateamt').value=="0")
    {
        document.getElementById('btnshgrid').focus();
        return false;
    }
     if(document.getElementById('txtaddagencycommrateamt').value!="" && document.getElementById('txtgrossamt').value!="")
    {
        var agcommamt=(parseFloat(document.getElementById('txtaddagencycommrateamt').value)/parseFloat(document.getElementById('txtgrossamt').value)) * 100;
        document.getElementById('txtaddagencycommrate').value=agcommamt.toFixed(2);
    } 
     if(document.getElementById('hiddenafency_retainer').value=="Y")
    {
        if(document.getElementById('drpretainer').value=="")
        {
            document.getElementById('btnshgrid').focus();
            return false;
        }
        else
        {
            //get retainer code *6Aug*
            if(document.getElementById('drpretainer').value==null || document.getElementById('drpretainer').value=="" || document.getElementById('drpretainer').value=="0")
            {
                document.getElementById('btnshgrid').focus();  //*25Aug*
                return false;
            }
            else
            {
                var retain_name=document.getElementById('drpretainer').value.split('(');
                var retain_code=retain_name[1].replace(')','');
            }    
          //*6Aug*  var response = Booking_Master_temp.getRetainerComm(document.getElementById('drpretainer').value,document.getElementById('hiddencompcode').value);
            var response = Booking_Master_temp.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
            if(response!=null)
            {
                var ds=response.value;
                if(ds==null)
                    return false;
                 if(ds.Tables[0].Rows.length>0)
                 {
                    if(ds.Tables[0].Rows[0].retainercomm==null)
                    {
                        var retainercomm=0;
                    }   
                    else
                    {
                        retainercomm=ds.Tables[0].Rows[0].retainercomm;
                    }
                    if(retainercomm!="0")
                    {
                        if(parseInt(document.getElementById('txtaddagencycommrate').value)>parseInt(retainercomm))
                        {
                            alert("Agency Commission can't be greater than Retainer Commission.");
                            document.getElementById('txtaddagencycommrate').value="";
                             document.getElementById('txtaddagencycommrateamt').value="";
                            document.getElementById('txtaddagencycommrate').focus();
                            return false;
                        }  
                    }
                 }
            }
        }
    }
    else
    {
        document.getElementById('btnshgrid').focus();
        return false;
    }
  
    document.getElementById('txtgrossamt').value='';
}
function addagencycomm()
{
    if(document.getElementById('txtgrossamt').value=='')
    {
        document.getElementById('txtaddagencycommrate').value="";
        document.getElementById('txtaddagencycommrateamt').value="";
    }
    if(document.getElementById('txtaddagencycommrate')!=null && document.getElementById('txtaddagencycommrate').value=="" || document.getElementById('txtaddagencycommrate').value=="0")
    {
        document.getElementById('btnshgrid').focus();
         document.getElementById('txtgrossamt').value='';
        return false;
    }
      if(document.getElementById('txtaddagencycommrate').value!="" && document.getElementById('txtgrossamt').value!="")
    {
        var agcommamt=parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtaddagencycommrate').value) /100;
        document.getElementById('txtaddagencycommrateamt').value=agcommamt.toFixed(2);
    } 
    if(document.getElementById('hiddenafency_retainer').value=="Y")
    {
        if(document.getElementById('drpretainer').value=="")
        {
            document.getElementById('btnshgrid').focus();
             document.getElementById('txtgrossamt').value='';
            return false;
        }
        else
        {
            //get retainer code *6Aug*
            if(document.getElementById('drpretainer').value==null || document.getElementById('drpretainer').value=="" || document.getElementById('drpretainer').value=="0")
            {
                document.getElementById('btnshgrid').focus(); 
                 document.getElementById('txtgrossamt').value=''; //*25Aug*
                return false;
            }
            else
            {
                var retain_name=document.getElementById('drpretainer').value.split('(');
                var retain_code=retain_name[1].replace(')','');
            }    
          //*6Aug*  var response = Booking_Master_temp.getRetainerComm(document.getElementById('drpretainer').value,document.getElementById('hiddencompcode').value);
            var response = Booking_Master_temp.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
            if(response!=null)
            {
                var ds=response.value;
                if(ds==null)
                {
                 document.getElementById('txtgrossamt').value='';
                    return false;
                    
                 }   
                 if(ds.Tables[0].Rows.length>0)
                 {
                    if(ds.Tables[0].Rows[0].retainercomm==null)
                    {
                        var retainercomm=0;
                    }   
                    else
                    {
                        retainercomm=ds.Tables[0].Rows[0].retainercomm;
                    }
                    if(retainercomm!="0")
                    {
                        if(parseInt(document.getElementById('txtaddagencycommrate').value)>parseInt(retainercomm))
                        {
                            alert("Agency Commission can't be greater than Retainer Commission.");
                              document.getElementById('txtaddagencycommrateamt').value="";
                            document.getElementById('txtaddagencycommrate').value="";
                            document.getElementById('txtaddagencycommrate').focus();
                             document.getElementById('txtgrossamt').value='';
                            return false;
                        }  
                    }
                 }
            }
        }
    }
    else
    {
        document.getElementById('btnshgrid').focus();
        return false;
    }
  
    document.getElementById('txtgrossamt').value='';
}
function chkRetainer()
{
    if(document.getElementById('txtexecname').value!='')
    {
        if(document.getElementById('drpretainer').value!="0")
        {
               if(confirm('Are you sure you want to Take Executive'))
                {
                   document.getElementById('drpretainer').value="0";
                   if(document.getElementById('txtRetainercomm')!=null)
                   {
                    document.getElementById('txtRetainercomm').value="";
                    document.getElementById('txtRetainercommamt').value="";
                    }
                }
            else
            {
                document.getElementById('txtexecname').value="";
                 document.getElementById('drpretainer').focus();
            }
        }
    }
    return false;
}

function chkExecutive()
{
    //*6Aug*
   // document.getElementById("divretainer").style.display="none";
    if(document.getElementById('drpretainer').value!='0')
    {
        if(document.getElementById('txtexecname').value!="")
        {
               if(confirm('Are you sure you want to Take Retainer'))
                {
                   document.getElementById('txtexecname').value="";
                   document.getElementById('txtexeczone').value="";
                  // document.getElementById('drpretainer').focus();
                   
                }
            else
            {
                document.getElementById('drpretainer').value="0";
              
            }
        }
    }
    return false;
}

function rateRefresh()
{
    document.getElementById('drpscheme').value="";
    document.getElementById('txtgrossamt').value="";
//    document.getElementById('txtaddagencycommrateamt').value="";
    document.getElementById('txtdiscount').value="";
    document.getElementById('txtdiscpre').value=""; 
    
    document.getElementById('txtcardamt').value="";
    document.getElementById('txtcardrate').value="";

    document.getElementById('txtagreedrate').value="";
    document.getElementById('txtagreedamt').value="";    

    document.getElementById('txtspedisc').value="";
    document.getElementById('txtspediscper').value="";

    document.getElementById('txtspacedisc').value="";
    document.getElementById('txtspadiscper').value="";

    document.getElementById('txtextracharges').value=""; 
    document.getElementById('txtbillamt').value="";
//    if(document.getElementById('txtaddagencycommrate')!=null)
//    document.getElementById('txtaddagencycommrate').value=""
    agreedrate_active=0;
    agreedamt_active=0;
    return false;
}

function ResetPaidInsertion()
{

    var agreedrate_vari=document.getElementById('txtagreedrate');
    var agreedamt_vari=document.getElementById('txtagreedamt');
    var drppackagecopy_vari=document.getElementById('drppackagecopy');
    if((agreedrate_vari.value!="" && agreedrate_vari.value!="0") || (agreedamt_vari.value!="" &&  agreedamt_vari.value!="0"))
    {
        var len="bookdiv";
        var count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
        for ( var s = 0; s < count; s++)
        {
           var pai_vari=document.getElementById('pai'+s);
           if(pai_vari!=null)
           { 
                pai_vari.value='Y';
           }
        }  
            // get paid Insertion
            var paidCount=document.getElementById('txtinsertion').value;
            var finsert=1;
            var tinsert=0;
            if(drppackagecopy_vari.options.length>0)
            {
                for(var insertCou=0;insertCou<drppackagecopy_vari.options.length;insertCou++)
                {
                    if(drppackagecopy_vari.options[insertCou].value.indexOf('(')>=0)
                    {
                        tinsert=drppackagecopy_vari.options[insertCou].value.substring(drppackagecopy_vari.options[insertCou].value.indexOf('(')+1,drppackagecopy_vari.options[insertCou].value.indexOf(')'));
                        if(parseInt(tinsert)>parseInt(finsert))
                        {
                            finsert=tinsert;
                        }
                        paidCount = parseInt(paidCount) * parseInt(tinsert);
                    }    
                }
            } 
        document.getElementById('txtpaid').value=paidCount; 
    }
    
}





//new change 26sep09

function checkGridDate_Validation()
{
     var rowcount=document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length - 1;     
     var len="bookdiv";
     var id; 
     var height;
     var width;
     var pagepost;
     var matsta;
     var insertsta;
     var editdate;
     var size;
     var inserts;
        var gross_var=document.getElementById('txtgrossamt');
     var ratecode_var=document.getElementById("txtratecode");
     var adsize1_var=document.getElementById('txtadsize1');
     var adsize2_var=document.getElementById('txtadsize2');
      if(document.getElementById('txttotalarea').value=="")
    {
        alert("Please Enter Size/Lines");
        return false;
    }  
    for(var itemCount=0;itemCount<parseInt(rowcount);itemCount++)
    {
        id="Text" + itemCount;
        height="hei"+itemCount;
        width="wid"+itemCount;
        pagepost="pagpos"+itemCount;
        matsta="mat"+itemCount;
        insertsta="inssta"+itemCount;
        cardid="card"+itemCount;
        editid="edit"+itemCount;
        editdate="Text" + itemCount;
        size="siz"+itemCount;
        inserts="ins"+itemCount;
        var file_nam="fil"+itemCount;
        var noofcol="nocol"+itemCount;
        var alertLine=parseInt(itemCount)+1;
         var par1;    
         var id_var=document.getElementById(id);
         par1=(id_var.parentNode).parentNode;
        
          if(browser!="Microsoft Internet Explorer")
            {
         //   alert(document.getElementById(height).value);
            if(document.getElementById(id).value=="" )
                {
                    alert("Please Fill the insertion date for Item Line "+alertLine);
                    document.getElementById(id).focus();
                    gross_var.value='';
                    return false;
                }              
             else if(document.getElementById(height).value=="" && adsize1_var.disabled==false)
                {
                    alert("Please fill height for Item Line "+alertLine);
                    document.getElementById('txtgrossamt').focus();
                    gross_var.value='';
                    return false;
                }
                
            else if((document.getElementById(width).value=="" && document.getElementById(noofcol).value=="") && adsize2_var.disabled==false)
                {
                    alert("Please fill width or Columns for Item Line "+alertLine);
                    
                    gross_var.value='';
                    return false;
                }
                
            else if(document.getElementById(size).value==""  && adsize2_var.disabled==true)
                {
                    alert("Please fill size for Item Line "+alertLine);
                    gross_var.value='';
                    return false;
                }
            else if(ratecode_var!=null)
               {
                   if(ratecode_var.value=="0")
                      {
                        alert("Please Select RateCode");
                        return false;
                      }
               }
            else if(document.getElementById(matsta)!=null)
                {
                    if(document.getElementById(matsta).value=="" || document.getElementById(matsta).value=="0")
                      {
                        alert("Please select material status for  Item Line "+alertLine);
                        document.getElementById(matsta).focus();
                        return false;
                
                      }
                }
        
           else if(document.getElementById(insertsta)!=null)
               {
                    if(document.getElementById(insertsta).value=="" || document.getElementById(insertsta).value=="0")
                      {
                        alert("Please select material status for  Item Line "+alertLine);
                        document.getElementById(matsta).focus();
                        return false;
                
                      }
              }
            
             }
            else
            {
        if(par1.all[id].value=="")
        {
          alert("Please Fill the insertion date for Item Line "+alertLine);
          par1.all[id].focus();
           gross_var.value='';
          return false;
        }
       
        else if(par1.all[height].value=="" && adsize1_var.disabled==false)
        {
          alert("Please fill height for Item Line "+alertLine);
          document.getElementById('txtgrossamt').value='';
          return false;        
        }
        
        else if((par1.all[width].value=="" && par1.all[noofcol].value=="") && adsize2_var.disabled==false)
        {    
          alert("Please fill width or Columns for Item Line "+alertLine);
           gross_var.value='';
          return false;
        } 
        else if(par1.all[size].value==""  && adsize2_var.disabled==true)
        {
          alert("Please fill size for Item Line "+alertLine);
          gross_var.value='';
          return false;                   
        }    
      /*   else if(document.getElementById(file_nam).value=="")
        {
           alert("Please upload Material for Item Line "+alertLine);
           return false;
        } */
        else if(ratecode_var!=null)
        {
            if(ratecode_var.value=="0")
            {
                alert("Please Select RateCode");
                return false;
            }
        }
        else if(par1.all[matsta]!=null)
        {
            if(par1.all[matsta].value=="" || par1.all[matsta].value=="0")
            {
                alert("Please select material status for  Item Line "+alertLine);
                par1.all[matsta].focus();
                return false;
                
            }
        }
        else if(par1.all[insertsta].value=="" || par1.all[insertsta].value=="0")
        {
            alert("Please select insertion status for  Item Line "+alertLine);
            par1.all[insertsta].focus();
            return false;
            
        }
        }
    } 
  
   ResetPaidInsertion(); 
   bindFinalRate(); 
 //special charges  
   getspecialdisc();  //special discount   
    getspacedisc();
      getsplcharge(); 
      getRetainerCommAmt(); 
   return false;       
}

function bindFinalRate()
{
        
        getagreedamt_Rate();
        //calculate trade discount
           var tradisc=document.getElementById('txttradedisc').value;
           if(tradisc=="")
            tradisc=0;
            var trdisc1=tradisc;
            var addcomm =0;
            if(document.getElementById('txtaddagencycommrate')!=null)
            {
                addcomm=document.getElementById('txtaddagencycommrate').value;
            }
            if(addcomm=="")
            {
                addcomm="0";
            }
            if(addcomm!="0")
            {
                trdisc1=parseInt(tradisc) + parseFloat(addcomm);
            }
                        
        var billamount = 0;                
        var bullet_var=document.getElementById('drpbullet');
        var scheme_var=document.getElementById('drpscheme');
        var noofinsertion=document.getElementById('txtinsertion').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var uom=document.getElementById('drpuom').value;
        var adtype="DI0";
        var currency=document.getElementById('hiddencurrency').value;
        var ratecode=document.getElementById('txtratecode').value;
        var clientcode="";//getclientcode();
        var uomdesc=document.getElementById('hiddenuomdesc').value;
        var agencycode=document.getElementById('hiddenagency').value;
        var agency_vari=document.getElementById('txtagency');
        var drppackage_vari=document.getElementById('drppackagecopy');
        if(agency_vari.value!="")
        {
            agencycode=agency_vari.value.substring(agency_vari.value.lastIndexOf("(")+1,agency_vari.value.lastIndexOf(")"));
        }
        var center="0";//document.getElementById('hiddencenter').value;
        var ratepremtype=document.getElementById('hiddenratepremtype').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        var eyecatchtype='';
        if(document.getElementById('hiddenbulletpremtype')!=null)
            eyecatchtype=document.getElementById('hiddenbulletpremtype').value;
        var bPrem='';    
        if(document.getElementById('hiddenbullprem')!=null)
             bPrem=document.getElementById('hiddenbullprem').value;//eyecatcher premium value
        var boxchargeInsertionwise=document.getElementById('hiddeninsertwise').value;
        var boxcharge=0;
        if(document.getElementById('txtboxchrg')!=null)
            boxpercen=document.getElementById('txtboxchrg').value;
        if(boxpercen!=null && boxpercen!="" && boxpercen!="0")
        {
            boxcharge = parseInt(boxpercen);
        }   
    flagins="1";
    var grossamtfinal=0;
    var cardamt=0;
    var newcode="";
       var agreedcancelAmt=0;
     var grossamtfinalAgreed=0;
    var res=null;
    len="bookdiv";
    var query='';
    var rowcount=document.getElementById(len).getElementsByTagName('table')[0].rows.length - 1;     
    var editionname='';
    var pkgcode='';
    var color='';
    var cat1='';
    var cat2='';
    var cat3='';
    var cat4='';
    var cat5='';
    var line='';
    var insert_date='';
    var ratecheck_date='';
   
    var k=0;
    var cntrfill=0;
    var counter=0;
    var counterT=0;
    var cardrate=0;
    var finsert=1;
    var tinsert=0;
    var pkg_insertion='';
    var ad_width='';
    var pkg_alias='';
    var pagepost='';
    var premiumno='';
    var paidCount=document.getElementById('txtinsertion').value;
    if(drppackage_vari.options.length>0)
    {
        for(var insertCou=0;insertCou<drppackage_vari.options.length;insertCou++)
        {
            if(drppackage_vari.options[insertCou].value.indexOf('(')>=0)
            {
                tinsert=drppackage_vari.options[insertCou].value.substring(drppackage_vari.options[insertCou].value.indexOf('(')+1,drppackage_vari.options[insertCou].value.indexOf(')'));
                if(parseInt(tinsert)>parseInt(finsert))
                {
                    finsert=tinsert;
                }
                paidCount = parseInt(paidCount) * parseInt(tinsert);
            }    
        }
    } 
    document.getElementById('txtpaid').value=paidCount;
    finsert = parseInt(finsert) * parseInt(document.getElementById('txtinsertion').value);
     var gridItemCount=parseInt(rowcount)/parseInt(finsert);
     var freeIns="N";
      var flag_agreed=0;
     var paid_var=document.getElementById('txtpaid');
     var color_vari=document.getElementById('drpcolor');
    var drpadcat_vari=document.getElementById('drpadcategory');
    var drpadsubcat_vari=document.getElementById('drpadsubcategory');
    var drpadcat3_vari=document.getElementById('drpadcat3');
    var drpadcat4_vari=document.getElementById('drpadcat4');
    var drpadcat5_vari=document.getElementById('drpadcat5');
    var totalarea_vari=document.getElementById('txttotalarea');
    var agreedrate_vari=document.getElementById('txtagreedrate');
    var agreedamt_vari=document.getElementById('txtagreedamt');
    var hiddenbox_vari=document.getElementById('hiddenboxchrgtype');
    for(var i=0; i <parseInt(finsert);i++)
    {
         if(freeIns=="Y")
         {
            paid_var.value=parseInt(paid_var.value) - 1;
         }        
         freeIns="N";
         counterT=counter;        
         editionname='';
         pkgcode='';
         color='';
         cat1='';
         cat2='';
         cat3='';
         cat4='';
         cat5='';
         pkg_insertion='';
         ad_width='';
         line='';
         insert_date='';
         ratecheck_date='';
       
         pkg_alias='';
         ad_width='';
         pagepost='';
         premiumno='';
         var tCount=0;
         var insval;
         var ins_vari=document.getElementById('ins'+counterT);
         if(ins_vari!=null)
         {
            while(parseInt(ins_vari.innerHTML)==parseInt(i)+1)
            {
                tCount = parseInt(tCount) + 1;
                counterT = parseInt(counterT) + 1;
                ins_vari=document.getElementById('ins'+counterT);
                if(ins_vari==null)
                    break;
            }       
         }   
         gridItemCount=tCount;  //get gridcount
        
        for(var j=0;j<parseInt(gridItemCount);j++)
        {
           var par1;
            var edit_vari=document.getElementById('edit'+k);
            par1=(edit_vari.parentNode).parentNode;
            //var col_vari=document.getElementById('col'+k);
        if(browser!="Microsoft Internet Explorer")
              {
              var col_vari=document.getElementById('col'+k);
            var adcat_vari=document.getElementById('adcat'+k);
            var cat2_vari=document.getElementById('ads'+k);
            var cat3_vari=document.getElementById('adscat3'+k);
            var cat4_vari=document.getElementById('adscat4'+k);
            var cat5_vari=document.getElementById('adscat5'+k);
        
//            
            var siz_vari;
             siz_vari=document.getElementById('siz'+k);

            var text_vari;
             text_vari=document.getElementById('Text'+k);
            
          
              var pkgins_vari=document.getElementById('pkg_ins'+k);
              var wid_vari;
              wid_vari=document.getElementById('wid'+k);
            
             var pkgalias_vari=document.getElementById('pkg_alias'+k);
             var pgpre_vari=document.getElementById('pagpos'+k);
             var prem_vari=document.getElementById('prem'+k);
             var hiddenpck_vari=document.getElementById('hiddenpckcode'+k);
              }
        else
        {
            var col_vari=par1.all['col'+k];
            var adcat_vari=par1.all['adcat'+k];
            var cat2_vari=par1.all['ads'+k];
            var cat3_vari=par1.all['adscat3'+k];
            var cat4_vari=par1.all['adscat4'+k];
            var cat5_vari=par1.all['adscat5'+k];
        
//            var adcat_vari=document.getElementById('adcat'+k);
//            var cat2_vari=document.getElementById('ads'+k);
//            var cat3_vari=document.getElementById('adscat3'+k);
//            var cat4_vari=document.getElementById('adscat4'+k);
//            var cat5_vari=document.getElementById('adscat5'+k);
            var siz_vari;
             siz_vari=par1.all['siz'+k];

            var text_vari;
             text_vari=par1.all['Text'+k];
            
          //  var pkgins_vari=document.getElementById('pkg_ins'+k);
              var pkgins_vari=par1.all['pkg_ins'+k];
              var wid_vari;
              wid_vari=par1.all['wid'+k];
            
             var pkgalias_vari=par1.all['pkg_alias'+k];
             var pgpre_vari=par1.all['pagpos'+k];
             var prem_vari=par1.all['prem'+k];
             var hiddenpck_vari=par1.all['hiddenpckcode'+k];
        }
            
//            var pkgalias_vari=document.getElementById('pkg_alias'+k);
//            var pgpre_vari=document.getElementById('pgpre'+k);
//            var prem_vari=document.getElementById('prem'+k);
//            var hiddenpck_vari=document.getElementById('hiddenpckcode'+k);

            if(edit_vari!=null)
            {   
                if(editionname=='')
                {
                    editionname=edit_vari.value;
                }
                else
                {
                     editionname=editionname + ',' + edit_vari.value;
                }
                
               if(pkgcode=='')
                {
                    pkgcode=hiddenpck_vari.value;
                }
                else
                {
                     pkgcode=pkgcode + ',' + hiddenpck_vari.value;
                }
                
                  if(color=='')
                {
                    if(col_vari!=null)
                    {
                        if(col_vari.value!="")
                            color=col_vari.value;
                        else
                            color="0";    
                    }   
                    else
                        color=color_vari.value;
                }
                else
                {    if(col_vari!=null)
                      {
                        if(col_vari.value!="")
                             color=color + ',' + col_vari.value;
                        else
                            color=color + ',' + "0"; 
                      }   
                    else
                        color=color + ',' + col_vari.value;
                }
                
                if(cat1=='')
                {
                    if(adcat_vari!=null)
                    {
                        if(adcat_vari.value!="")
                            cat1=adcat_vari.value;
                        else
                            cat1="0";    
                    }       
                    else
                        cat1=drpadcat_vari.value;
                }
                else
                {
                    if(adcat_vari!=null)
                    {
                      if(adcat_vari.value!="")
                            cat1=cat1 + ',' + adcat_vari.value;
                        else
                            cat1=cat1 + ',' + "0";  
                    }
                    else
                        cat1=cat1 + ',' + drpadcat_vari.value;
                }
                
              if(cat2=='')
                {
                    if(cat2_vari!=null)
                    {
                        if(cat2_vari.value!='')
                        {
                            cat2=cat2_vari.value;
                        }
                        else
                        {
                            cat2="0";
                        }
                     }   
                    else
                    {
                        if(drpadsubcat_vari.value=="")
                        {
                            cat2="0";
                        }
                        else
                        {
                            cat2=drpadsubcat_vari.value;
                        }    
                    }   
                }
                else
                {
                    if(cat2_vari!=null)
                    {
                         if(cat2_vari.value!='')
                        {
                             cat2=cat2 + ',' + cat2_vari.value;
                        }
                        else
                        {
                            cat2=cat2 + ',' +"0";
                        }
                       
                      }  
                    else
                    {
                         if(drpadsubcat_vari.value=="")
                         {
                            cat2=cat2 + ',' + "0";
                         }
                         else
                         {
                            cat2=cat2 + ',' + drpadsubcat_vari.value;
                         }                          
                    }    
                }
                
                if(cat3=='')
                {
                    if(cat3_vari!=null)
                    {
                        if(cat3_vari.value=='')
                        {
                            cat3="0";
                        }
                        else
                        {
                            cat3=cat3_vari.value;
                         }   
                    }
                    else
                    {
                        if(drpadcat3_vari.value=="")
                        {
                            cat3="0";
                        }   
                        else
                        {
                            cat3=drpadcat3_vari.value;
                        }
                    }    
                }
                else
                {
                    if(cat3_vari!=null)
                    {
                         if(cat3_vari.value=='')
                        {
                            cat3=cat3 + ',' +"0";
                        }
                        else
                        {
                            cat3=cat3 + ',' + cat3_vari.value;
                         }  
                    }
                        
                    else
                    {
                        if(drpadcat3_vari.value=="")
                        {
                            cat3=cat3 + ',' + "0";
                        }
                        else
                        {
                            cat3=cat3 + ',' + drpadcat3_vari.value;
                        }
                     }   
                }
                
                if(cat4=='')
                {
                    if(cat4_vari!=null)
                    {
                        if(cat4_vari.value=="")
                        {
                            cat4="0";
                        }
                        else
                        {
                             cat4=cat4_vari.value;
                        }
                    }
                       
                    else
                    {
                        if(drpadcat4_vari.value=="")
                        {
                            cat4="0";
                        }
                        else
                        {
                            cat4=drpadcat4_vari.value;
                        }    
                     }   
                }
                else
                {
                    if(cat4_vari!=null)
                    {
                         if(cat4_vari.value=="")
                        {
                            cat4=cat4 + ',' + "0";
                        }
                        else
                        {
                            cat4=cat4 + ',' + cat4_vari.value;
                        }
                        
                    }
                    else
                    {
                        if(drpadcat4_vari.value=="")
                        {
                            cat4=cat4 + ',' + "0";
                        }    
                        else
                        {
                            cat4=cat4 + ',' + drpadcat4_vari.value;
                        }
                    }   
                }
                
                if(cat5=='')
                {
                    if(cat5_vari!=null)
                    {
                        if(cat5_vari.value=="")
                        {
                            cat5="0";
                        }
                        else
                        {
                            cat5=cat5_vari.value;
                        }
                    }
                        
                    else
                    {
                         if(drpadcat5_vari.value=="")
                         {
                            cat5="0";
                         }
                         else
                         {
                             cat5=drpadcat5_vari.value;
                         }  
                     }     
                }
                else
                {
                    if(cat5_vari!=null)
                    {
                         if(cat5_vari.value=="")
                        {
                            cat5=cat5 + ',' + "0";
                        }
                        else
                        {
                            cat5=cat5 + ',' + cat5_vari.value;
                        }
                    }
                        
                    else
                      {
                          if(drpadcat5_vari.value=="")
                           {
                                cat5=cat5 + ',' + "0";
                           }
                           else
                           {
                                cat5=cat5 + ',' + drpadcat5_vari.value;
                           }
                       }         
                }
                
                if(line=='')
                {
                    if(siz_vari!=null)
                        line=siz_vari.value;
                    else
                        line=totalarea_vari.value;
                }
                else
                {
                    if(siz_vari!=null)
                        line=line + ',' + siz_vari.value;
                    else
                        line=line + ',' + totalarea_vari.value;
                }
                
                if(insert_date=='')
                {
                    insert_date=date_frmt_orcl(dateformat,text_vari.value);
                }
                else
                {
                    var datestr=date_frmt_orcl(dateformat,text_vari.value);
                    insert_date=insert_date + ',' + datestr;
                }
                
                if(document.getElementById('hiddenratecheckdate').value=='i')
                {
                    if(ratecheck_date=='')
                    {
                        ratecheck_date=date_frmt_orcl(dateformat,text_vari.value);
                    }
                    else
                    {
                        var datestr=date_frmt_orcl(dateformat,text_vari.value);
                        ratecheck_date=ratecheck_date + ',' + datestr;
                        
                    }
                }
                else
                {
                    if(ratecheck_date=='')
                    {
                        ratecheck_date=date_frmt_orcl(dateformat,document.getElementById('txtdatetime').value);
                    }
                    else
                    {
                        var datestr=date_frmt_orcl(dateformat,document.getElementById('txtdatetime').value);
                        ratecheck_date=ratecheck_date + ',' + datestr;
                        
                    }
                }
               if(pkg_insertion=='')
                {
                    if(pkgins_vari.value=="")
                    {
                        pkg_insertion="1";
                     }
                     else
                     {
                         pkg_insertion=pkgins_vari.value;
                     }   
                }
               else
                {
                     if(pkgins_vari.value=="")
                     {
                        pkg_insertion=pkg_insertion + ',' + "0";
                     }
                     else
                     {
                        pkg_insertion=pkg_insertion + ',' + pkgins_vari.value;
                     }
                }   
             if(ad_width=='')
               {
                    if(wid_vari.value=='')
                    {
                        ad_width='0';
                    }
                    else
                    {
                        ad_width=wid_vari.value;
                    }    
               }
             else
              {
                     if(wid_vari.value=='')
                    {
                        ad_width=ad_width + ',' + '0';
                    }
                    else
                    {
                        ad_width=ad_width + ',' + wid_vari.value;
                    }    
               } 
              if(pkg_alias=='')
               {
                 pkg_alias=pkgalias_vari.value;
               }
              else
              {
                pkg_alias=pkg_alias + ',' + pkgalias_vari.value;
              }   
              
               if(pagepost=='')
               {
                    if(pgpre_vari!=null && pgpre_vari.value!='')
                    {
                        pagepost=pgpre_vari.value;
                    }   
                    else
                    {
                        pagepost='0';
                    }
               }
              else
              {
                    if(pgpre_vari!=null && pgpre_vari.value!='')
                    { 
                        pagepost=pagepost + ',' + pgpre_vari.value;
                    }
                    else
                    {
                        pagepost=pagepost + ',' + '0';
                    }    
              } 
              //for premium if any
              if(premiumno=='')
               {
                    if(prem_vari!=null && prem_vari.value!='')
                    {
                        premiumno=prem_vari.value;
                    }   
                    else
                    {
                        premiumno='0';
                    }
               }
              else
              {
                    if(prem_vari!=null && prem_vari.value!='')
                    { 
                        premiumno=premiumno + ',' + prem_vari.value;
                    }
                    else
                    {
                        premiumno=premiumno + ',' + '0';
                    }    
              }                
            }
            k++;
        }// end of first loop
      
        newcode=editionname + "$" + pkgcode + "$" + color + "$" + cat1 + "$" + cat2 + "$" + cat3 + "$" + cat4 + "$" + cat5 + "$" + line + "$" + insert_date + "$" + ratecheck_date + "$" + pkg_insertion + "$" + ad_width + "$" + pkg_alias + "$" + pagepost + "$" + premiumno;
    //    alert(newcode);
      
        res=Booking_Master_temp.get_rate(noofinsertion,dateformat,compcode,uom,adtype,currency,ratecode,clientcode,uomdesc,agencycode,newcode,center,ratepremtype,'0',document.getElementById('hiddenschemetype').value);
        cntrfill=0;
    
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
           var schemeCount=0;
     
        var chkscheme_Type=0;
        for(;cntrfill<parseInt(gridItemCount);cntrfill++)
        {
              var pkgcode=document.getElementById("hiddenpckcode"+counter);
             if(pkgcode==null)
                 break;
         
            if(ds.Tables[0].Rows.length<=0)
            {
                var par1;
                cardid=document.getElementById("card"+counter);
                par1=(cardid.parentNode).parentNode;
             if(browser!="Microsoft Internet Explorer")
                {
                solo=document.getElementById("sol"+counter);
                
                gross=document.getElementById("gro"+counter);
                var paidno= document.getElementById("pai"+counter);
                 var billrate= document.getElementById("ba"+counter);
                var agrred=document.getElementById("agr"+counter);
                var insertsta= document.getElementById("inssta"+counter);    
                var eyecatchRate=0;      
                var pkgalias=document.getElementById("pkg_alias"+counter);
                }
             else
              {
                solo=par1.all["sol"+counter];
                gross=par1.all["gro"+counter];
                var paidno= par1.all["pai"+counter];
                var billrate= par1.all["ba"+counter];
                var agrred=par1.all["agr"+counter];
                var insertsta= par1.all["inssta"+counter];    
                var eyecatchRate=0;      
                var pkgalias=par1.all["pkg_alias"+counter]; 
               }      
               // NEW CHANGE 19 NOV 09
                schemeCount=0;
                        if(ds.Tables[2].Rows.length>0 && agreedamt_vari.value!='' && agreedamt_vari.value!='0')
                        {
                            for(var t=0;t<ds.Tables[2].Rows.length;t++)
                            {
                                if(ds.Tables[2].Rows[t].PKG_CODE==ds.Tables[1].Rows[cntrfill].PCODE)
                                {
                                schemeCount=parseInt(schemeCount) + parseInt(ds.Tables[2].Rows[t].TO_INS) - parseInt(ds.Tables[2].Rows[t].FROM_INSERT) + 1;
                                scheme_var=ds.Tables[2].Rows[t].SCHEMENAME;
                                }
                            }
                        }
                 if(pkgcode.value==ds.Tables[1].Rows[cntrfill].PCODE && LTrim(RTrim(pkgalias.value))==LTrim(RTrim(ds.Tables[1].Rows[cntrfill].PKG_ALIAS)))
                 {
                          var scheme="";
                          var edicount=cntrfill;
                           if((agreedrate_vari.value== '' || agreedrate_vari.value== '0') && (agreedamt_vari.value=='' || agreedamt_vari.value=='0') && chkscheme_Type==0)
                           {        //----3-----------
                                chkscheme_Type=1;
                                for(var scicount=0;scicount<ds.Tables[2].Rows.length;scicount++)
                                {       //----4-----------
                                    if(pkgcode.value==ds.Tables[2].Rows[scicount].PKG_CODE && (parseInt(i)+1>=ds.Tables[2].Rows[scicount].FROM_INSERT && parseInt(i)+1<=ds.Tables[2].Rows[scicount].TO_INS))
                                    {           //----5-----------
                                        chkscheme_Type=0;
                                        if(uomdesc=='CD')
                                        {
                                            cardid.value=ds.Tables[1].Rows[edicount].EXTRARATE;
                                            solo.value=ds.Tables[1].Rows[edicount].EXTRARATE;
                                        }    
                                        else
                                        {
                                            cardid.value=ds.Tables[1].Rows[edicount].CARDRATE;
                                            solo.value=ds.Tables[1].Rows[edicount].SOLORATE;
                                        }
                                        var gridgross=gross.value=ds.Tables[1].Rows[edicount].FCARDRATE;
                                        cardamt=parseFloat(cardamt) + parseFloat(ds.Tables[1].Rows[edicount].FCARDRATE);
                                        if(ds.Tables[2].Rows[scicount].TYPE=="per")
                                        {
                                            gridgross=parseFloat(gridgross) - (parseFloat(gridgross) * parseFloat(ds.Tables[2].Rows[scicount].AMT)/100);
                                            if(parseInt(gridgross)==0)
                                            {
                                                freeIns="Y";
                                            }
                                            grossamtfinal=parseFloat(grossamtfinal)+ parseFloat(gridgross);//+gridgross;
                                            //agreed rate
                                            gross.value = gridgross.toFixed(2);
                                        }
                                        else
                                        {
                                            grossamtfinal=parseFloat(grossamtfinal) + (parseFloat(gridgross) - parseFloat(ds.Tables[2].Rows[scicount].AMT)) ;
                                            gross.value = parseFloat(gridgross) - parseFloat(ds.Tables[2].Rows[scicount].AMT);
                                        }
                                        scheme_var.value=ds.Tables[2].Rows[scicount].SCHEMENAME;
                                        if(bullet_var!=null)
                                        {
                                                if(bullet_var.value!='0')
                                                {
                                                    if(eyecatchtype!='S')
                                                    {
                                                        if(eyecatchtype=='P')
                                                        {
                                                            if(bPrem.indexOf('%')>0)
                                                                bPrem=bPrem.split('%')[0];
                                                            eyecatchRate =  (parseFloat(grossamtfinal) * parseFloat(bPrem))/100;
                                                            grossamtfinal=parseFloat(grossamtfinal) + parseFloat(eyecatchRate);
                                                            gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                                        }
                                                        else if(eyecatchtype=='F')
                                                        {
                                                            if(bPrem.indexOf('%')>0)
                                                                bPrem=bPrem.split('%')[0];
                                                            eyecatchRate =  parseFloat(grossamtfinal) + parseFloat(bPrem);
                                                            grossamtfinal=parseFloat(grossamtfinal) + eyecatchRate;
                                                            gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                                        }
                                                    }
                                                }
                                          }      
                                        // for insertion wise box charges
                                        if(boxchargeInsertionwise=='yes')
                                        {
                                            var tboxcharge=0;
                                                tboxcharge=boxcharge;
                                            if(hiddenbox_vari.value=='2')
                                            {
                                                tboxcharge=(parseFloat(grossamtfinal) * parseFloat(boxcharge))/100;
                                            }
                                            grossamtfinal=parseFloat(grossamtfinal) + tboxcharge;
                                            gross.value = parseFloat(gross.value) + parseFloat(tboxcharge);
                                        }
                                                                   
                                        if(paidno!=null &&  ds.Tables[2].Rows[scicount].TYPE=="per" && ds.Tables[2].Rows[scicount].AMT=="100")
                                        {
                                            paidno.value='N';
                                        } 
                                        else if(paidno!=null)
                                        {
                                             paidno.value='Y';
                                        }
                                        scheme='Y';
                                        edicount=gridItemCount;
                                        if(i==0)
                                        {
//                                            if(uomdesc=='CD')
//                                            {
                                                cardrate=parseFloat(cardrate) + parseFloat(ds.Tables[1].Rows[cntrfill].EXTRARATE);
//                                            }
//                                            else
//                                            {
//                                                cardrate=parseFloat(cardrate) + parseFloat(ds.Tables[1].Rows[cntrfill].CARDRATE);
//                                            }    
                                        }
                                        break;
                                    }  //----5-----------
                                
                                }    //----4-----------   
                            }     //----3-----------  
                            if(scheme=='')
                            {
                                if(uomdesc=='CD')
                                {
                                     cardid.value=ds.Tables[1].Rows[cntrfill].EXTRARATE;
                                     solo.value=ds.Tables[1].Rows[cntrfill].EXTRARATE;
                                }
                                else
                                {
                                     cardid.value=ds.Tables[1].Rows[cntrfill].CARDRATE;
                                     solo.value=ds.Tables[1].Rows[cntrfill].SOLORATE;
                                }   
                                var gridgross=0;
                                 cardamt=parseFloat(cardamt) + parseFloat(ds.Tables[1].Rows[cntrfill].FCARDRATE);
                                  if((agreedrate_vari.value!= '' && agreedrate_vari.value!= '0') && (agreedamt_vari.value!='' && agreedamt_vari.value!='0'))
                                   {
                                     if(agreedrate_active==0 && agreedamt_active==0)
                                     {
                                        agreedamt_active=1;
                                        flag_agreed = 2;
                                      }  
                                   }
                                if(agreedrate_active==1 || agreedamt_active==1)
                                {
                                     var rowcountNum=rowcount;
                                     if(schemeCount>0 )
                                    {
                                        rowcountNum = parseInt(rowcount) - (parseInt(schemeCount) * parseInt(gridItemCount));
                                        if(flag_agreed!=2)
                                            flag_agreed=1;
                                    }
                                    if(flag_agreed==1)
                                    {
                                        var num=(parseFloat(parseFloat(agreedamt_vari.value) / parseInt(finsert))).toFixed(2);
                                        agreedamt_vari.value=parseFloat(agreedamt_vari.value) - (parseFloat(num) * parseFloat(schemeCount));
                                        flag_agreed=2;
                                    }
                                    agrred.value = (parseFloat(parseFloat(agreedamt_vari.value) / parseInt(rowcountNum))).toFixed(2);
                                    if(counter==parseInt(rowcount) - 1)
                                    {
                                        agrred.value = (parseFloat(agreedamt_vari.value) - parseFloat(grossamtfinalAgreed)).toFixed(2) ;
                                    }
                                    // for applying scheme in Agreed Amount
                                   if(schemeCount>0)
                                   {
                                     var diffcount=parseInt(finsert) - parseInt(schemeCount);
                                          //  if(pkgcode.value==ds.Tables[2].Rows[0].PKG_CODE && (parseInt(i)+1>parseInt(diffcount)))
                                             if((parseInt(i)+1>parseInt(diffcount)))
                                        { 
                                                 freeIns="Y";
                                                 gross.value =0;
                                                  paidno.value='N';
                                                   //scheme_var.value=ds.Tables[2].Rows[0].SCHEMENAME;
                                        }   
                                        else
                                        {
                                             gross.value = (parseFloat(agrred.value)).toFixed(2);
                                        }     
                                   }
                                   else
                                   {
                                    gross.value = (parseFloat(agrred.value)).toFixed(2);
                                   } 
                                   if(insertsta.value=='cancel')
                                   {
                                                agreedcancelAmt=parseFloat(agreedcancelAmt) + parseFloat(agrred.value);
                                                freeIns="Y";
                                                 gross.value =0;
                                                  paidno.value='N';
                                   }
                                    gridgross=gross.value=parseFloat(gross.value).toFixed(2);
                                    edicount=gridItemCount;  //by nand on 2 oct
                                    if(i==0)
                                    {
//                                        if(uomdesc=='CD')
//                                        {
                                             cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].EXTRARATE;
//                                        }
//                                        else
//                                        {
//                                             cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].CARDRATE;
//                                        }    
                                    }
                                    var grossValue = parseFloat(gross.value);
                                    grossamtfinal=parseFloat(grossamtfinal)+parseFloat(gridgross);
                                       grossamtfinalAgreed=parseFloat(grossamtfinalAgreed)+parseFloat(gridgross);
                                    // for box charges in agreed amount
                                    if(paidno.value=="N")
                                        boxcharge="0";
                                      if(boxchargeInsertionwise=='yes' && paidno.value!='N')
                                    {
                                        var tboxcharge=0;
                                           tboxcharge=boxcharge;
                                        if(hiddenbox_vari.value=='2')
                                        {
                                             tboxcharge=(parseFloat(gridgross) * parseFloat(boxcharge))/100;
                                        }  
                                        grossamtfinal=parseFloat(grossamtfinal) + tboxcharge;
                                        gross.value = parseFloat(gross.value) + parseFloat(tboxcharge);
                                    }
                                }
                                else
                                {
                                    gridgross=gross.value=ds.Tables[1].Rows[cntrfill].FCARDRATE;
                                    grossamtfinal=grossamtfinal+gridgross;
                                    if(bullet_var!=null && bullet_var.value!='0')
                                    {
                                        if(eyecatchtype!='S')
                                        {
                                            if(eyecatchtype=='P')
                                            {
                                                if(bPrem.indexOf('%')>0)
                                                    bPrem=bPrem.split('%')[0]
                                                 eyecatchRate =  (parseFloat(gridgross) * parseFloat(bPrem))/100;
                                                 gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                                 grossamtfinal=parseFloat(grossamtfinal) + parseFloat(eyecatchRate);
                                            }
                                            else if(eyecatchtype=='F')
                                            {
                                                if(bPrem.indexOf('%')>0)
                                                    bPrem=bPrem.split('%')[0]
                                                 eyecatchRate =  parseFloat(gridgross) + parseFloat(bPrem);
                                                 grossamtfinal=parseFloat(grossamtfinal) + eyecatchRate;
                                                 gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                            }
                                        }
                                    }
                                    // for insertion wise Box Charges 
                                    if(boxchargeInsertionwise=='yes' && hiddenbox_vari!=null)
                                    {
                                         var tboxcharge=0;
                                            tboxcharge=boxcharge;
                                        if(hiddenbox_vari.value=='2')
                                        {
                                             tboxcharge=(parseFloat(gridgross) * parseFloat(boxcharge))/100;
                                        }  
                                        grossamtfinal=parseFloat(grossamtfinal) + tboxcharge;
                                        gross.value = parseFloat(gross.value) + parseFloat(tboxcharge);
                                    }
                                    
                                    edicount=gridItemCount;
                                    if(i==0)
                                    {
//                                        if(uomdesc=='CD')
//                                        {
                                            cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].EXTRARATE;
//                                        }
//                                        else
//                                        {
//                                            cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].CARDRATE;
//                                        }    
                                    }
                                    var grossValue = parseFloat(gross.value);
                                    gross.value = grossValue.toFixed(2);
                                   // break;
                                } 
                            } 
                            if(insertsta.value=='cancel')
                            {
                                gross.value=0;
                                freeIns="Y";
                                if(boxchargeInsertionwise=='yes')
                                {
                                    grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate) + parseFloat(boxcharge));
                                }
                                else
                                {
                                    grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate));
                                }   
                                var paidno= "pai"+counter;
                                if(paidno!=null)
                                {
                                    paidno.value='N';
                                }    
                            }
                            else if(paidno!=null)
                            {
                                if(paidno.value=='N')
                                {
                                    gross.value=0;
                                    if(boxchargeInsertionwise=='yes')
                                    {
                                        grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate) + parseFloat(boxcharge));
                                    }
                                    else
                                    {
                                        grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate));
                                    }  
                                }   
                            }
                            if(billrate!=null)
                            {
                                 var tradisc=document.getElementById('txttradedisc').value;
                                    if(tradisc=="")
                                        tradisc=0;
                                    var trdisc1=tradisc;
                                    var addcomm =0;
                                    if(document.getElementById('txtaddagencycommrate')!=null)
                                    {
                                        addcomm=document.getElementById('txtaddagencycommrate').value;
                                    }
                                    if(addcomm=="")
                                    {
                                        addcomm="0";
                                    }
                                    if(addcomm!="0")
                                    {
                                        trdisc1=parseInt(tradisc) + parseFloat(addcomm);
                                    }
                                    var billamt=0;
                                      if(document.getElementById('agncomm_seq_com').value!="S")
                                        billamt=parseFloat(gross.value) - (parseFloat(gross.value) * parseFloat(trdisc1)/100);
                                      else
                                      {
                                               billamt=parseFloat(gross.value)-parseFloat(gross.value)*parseFloat(tradisc)/100;
                                              if(addcomm!="0" && addcomm!="")
                                              {
                                                 billamt=parseFloat(billamt)-parseFloat(billamt)*parseFloat(addcomm)/100;
                                              }
                                      }  
                                //var billamt=parseFloat(gross.value) - (parseFloat(gross.value) * parseFloat(trdisc1)/100);
                                    billrate.value=billamt;
                                if(billrate.value!="" &&  counter !=parseInt(rowcount)-1)
                                {
                                    billamount=parseFloat(billamount)+parseFloat(billrate.value);
                                }   
                               if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")  
                                   billrate.value=0;      
                            }
                            
                            counter++;
                       
                 }
                 else
                 {
                      for(var edicount=0;edicount<parseInt(gridItemCount);edicount++)
                      {               //----1-----------
                       
                        if(pkgcode.value==ds.Tables[1].Rows[edicount].PCODE && LTrim(RTrim(pkgalias.value))==LTrim(RTrim(ds.Tables[1].Rows[edicount].PKG_ALIAS)))
                        {           //----2-----------
                           var scheme="";
                           if((agreedrate_vari.value== '' || agreedrate_vari.value== '0') && (agreedamt_vari.value=='' || agreedamt_vari.value=='0'))
                           {        //----3-----------
                                for(var scicount=0;scicount<ds.Tables[2].Rows.length;scicount++)
                                {       //----4-----------
                                    if(pkgcode.value==ds.Tables[2].Rows[scicount].PKG_CODE && (parseInt(i)+1>=ds.Tables[2].Rows[scicount].FROM_INSERT && parseInt(i)+1<=ds.Tables[2].Rows[scicount].TO_INS))
                                    {           //----5-----------
                                        if(uomdesc=='CD')
                                        {
                                            cardid.value=ds.Tables[1].Rows[edicount].EXTRARATE;
                                            solo.value=ds.Tables[1].Rows[edicount].EXTRARATE;
                                        }    
                                        else
                                        {
                                            cardid.value=ds.Tables[1].Rows[edicount].CARDRATE;
                                            solo.value=ds.Tables[1].Rows[edicount].SOLORATE;
                                        }
                                        var gridgross=gross.value=ds.Tables[1].Rows[edicount].FCARDRATE;
                                        cardamt=parseFloat(ds.Tables[1].Rows[edicount].FCARDRATE) + parseFloat(cardamt);
                                        if(ds.Tables[2].Rows[scicount].TYPE=="per")
                                        {
                                            gridgross=parseFloat(gridgross) - (parseFloat(gridgross) * parseFloat(ds.Tables[2].Rows[scicount].AMT)/100);
                                            if(parseInt(gridgross)==0)
                                            {
                                                freeIns="Y";
                                            }
                                            grossamtfinal=parseFloat(grossamtfinal)+ parseFloat(gridgross);//+gridgross;
                                            //agreed rate
                                            gross.value = gridgross.toFixed(2);
                                        }
                                        else
                                        {
                                            grossamtfinal=parseFloat(grossamtfinal) + (parseFloat(gridgross) - parseFloat(ds.Tables[2].Rows[scicount].AMT)) ;
                                            gross.value = parseFloat(gridgross) - parseFloat(ds.Tables[2].Rows[scicount].AMT);
                                        }
                                        scheme_var.value=ds.Tables[2].Rows[scicount].SCHEMENAME;
                                         if(bullet_var!=null && bullet_var.value!='0')
                                        {
                                            if(eyecatchtype!='S')
                                            {
                                                if(eyecatchtype=='P')
                                                {
                                                    if(bPrem.indexOf('%')>0)
                                                        bPrem=bPrem.split('%')[0];
                                                    eyecatchRate =  (parseFloat(grossamtfinal) * parseFloat(bPrem))/100;
                                                    grossamtfinal=parseFloat(grossamtfinal) + parseFloat(eyecatchRate);
                                                    gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                                }
                                                else if(eyecatchtype=='F')
                                                {
                                                    if(bPrem.indexOf('%')>0)
                                                        bPrem=bPrem.split('%')[0];
                                                    eyecatchRate =  parseFloat(grossamtfinal) + parseFloat(bPrem);
                                                    grossamtfinal=parseFloat(grossamtfinal) + eyecatchRate;
                                                    gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                                }
                                            }
                                        }
                                        // for insertion wise box charges
                                        if(boxchargeInsertionwise=='yes' && hiddenbox_vari!=null)
                                        {
                                             var tboxcharge=0;
                                            tboxcharge=boxcharge;
                                            if(hiddenbox_vari.value=='2')
                                            {
                                                tboxcharge=(parseFloat(grossamtfinal) * parseFloat(boxcharge))/100;
                                            }
                                            grossamtfinal=parseFloat(grossamtfinal) + tboxcharge;
                                            gross.value = parseFloat(gross.value) + parseFloat(tboxcharge);
                                        }
                                                                   
                                        if(paidno!=null &&  ds.Tables[2].Rows[scicount].TYPE=="per" && ds.Tables[2].Rows[scicount].AMT=="100")
                                        {
                                            paidno.value='N';
                                        } 
                                        else if(paidno!=null)
                                        {
                                             paidno.value='Y';
                                        }
                                        scheme='Y';
                                        
                                        if(i==0)
                                        {
//                                            if(uomdesc=='CD')
//                                            {
                                                cardrate=parseFloat(cardrate) + parseFloat(ds.Tables[1].Rows[edicount].EXTRARATE);
//                                            }
//                                            else
//                                            {
//                                                cardrate=parseFloat(cardrate) + parseFloat(ds.Tables[1].Rows[cntrfill].CARDRATE);
//                                            }    
                                        }
                                        edicount=gridItemCount;
                                        break;
                                    }  //----5-----------
                                
                                }    //----4-----------   
                            }     //----3-----------  
                            if(scheme=='')
                            {
                                if(uomdesc=='CD')
                                {
                                     cardid.value=ds.Tables[1].Rows[edicount].EXTRARATE;
                                     solo.value=ds.Tables[1].Rows[edicount].EXTRARATE;
                                }
                                else
                                {
                                     cardid.value=ds.Tables[1].Rows[edicount].CARDRATE;
                                     solo.value=ds.Tables[1].Rows[edicount].SOLORATE;
                                }   
                                cardamt=parseFloat(ds.Tables[1].Rows[edicount].FCARDRATE) + parseFloat(cardamt);
                                var gridgross=0;
                                  if((agreedrate_vari.value!= '' && agreedrate_vari.value!= '0') && (agreedamt_vari.value!='' && agreedamt_vari.value!='0'))
                                   {
                                     if(agreedrate_active==0 && agreedamt_active==0)
                                     {
                                        agreedamt_active=1;
                                        flag_agreed = 2;
                                     }   
                                   }
                                if(agreedrate_active==1 || agreedamt_active==1)
                                {
                                    var rowcountNum=rowcount;
                                  if(schemeCount>0 )
                                    {
                                        rowcountNum = parseInt(rowcount) - (parseInt(schemeCount) * parseInt(gridItemCount));
                                        if(flag_agreed!=2)
                                            flag_agreed=1;
                                    }
                                    if(flag_agreed==1)
                                    {
                                        var num=(parseFloat(parseFloat(agreedamt_vari.value) / parseInt(finsert))).toFixed(2);
                                        agreedamt_vari.value=parseFloat(agreedamt_vari.value) - (parseFloat(num) * parseFloat(schemeCount));
                                        flag_agreed=2;
                                    }
                                    agrred.value = (parseFloat(parseFloat(agreedamt_vari.value) / parseInt(rowcountNum))).toFixed(2);
                                    if(counter==parseInt(rowcount) - 1)
                                    {
                                        agrred.value = (parseFloat(agreedamt_vari.value) - parseFloat(grossamtfinalAgreed)).toFixed(2) ;
                                    }
                                    // for applying scheme in Agreed Amount
                                   if(schemeCount>0)
                                   {
                                     var diffcount=parseInt(finsert) - parseInt(schemeCount);
                                         //   if(pkgcode.value==ds.Tables[2].Rows[0].PKG_CODE && parseInt(i)+1>diffcount)
                                            if((parseInt(i)+1>parseInt(diffcount)))
                                        { 
                                                 freeIns="Y";
                                                 gross.value =0;
                                                  paidno.value='N';
                                                  // scheme_var.value=ds.Tables[2].Rows[0].SCHEMENAME;
                                        }   
                                        else
                                        {
                                             gross.value = (parseFloat(agrred.value)).toFixed(2);
                                        }     
                                   }
                                   else
                                   {
                                    gross.value = (parseFloat(agrred.value)).toFixed(2);
                                   } 
                                      if(insertsta.value=='cancel')
                                   {
                                                agreedcancelAmt=parseFloat(agreedcancelAmt) + parseFloat(agrred.value);
                                                freeIns="Y";
                                                 gross.value =0;
                                                  paidno.value='N';
                                   }
                                    gridgross=gross.value=parseFloat(gross.value).toFixed(2);
                                    edicount=gridItemCount;  //by nand on 2 oct
                                    if(i==0)
                                    {
//                                        if(uomdesc=='CD')
//                                        {
                                             cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].EXTRARATE;
//                                        }
//                                        else
//                                        {
//                                             cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].CARDRATE;
//                                        }    
                                    }
                                    var grossValue = parseFloat(gross.value);
                                    grossamtfinal=parseFloat(grossamtfinal)+parseFloat(gridgross);
                                       grossamtfinalAgreed=parseFloat(grossamtfinalAgreed)+parseFloat(gridgross);
                                    // for box charges in agreed amount
                                    if(paidno.value=="N")
                                        boxcharge="0";
                                      if(boxchargeInsertionwise=='yes' && paidno.value!='N')
                                    {
                                        var tboxcharge=0;
                                           tboxcharge=boxcharge;
                                        if(hiddenbox_vari.value=='2')
                                        {
                                             tboxcharge=(parseFloat(gridgross) * parseFloat(boxcharge))/100;
                                        }  
                                        grossamtfinal=parseFloat(grossamtfinal) + tboxcharge;
                                        gross.value = parseFloat(gross.value) + parseFloat(tboxcharge);
                                    }
                                }
                                else
                                {
                                    gridgross=gross.value=ds.Tables[1].Rows[edicount].FCARDRATE;
                                    grossamtfinal=grossamtfinal+gridgross;
                                    if(bullet_var!=null && bullet_var.value!='0')
                                    {
                                        if(eyecatchtype!='S')
                                        {
                                            if(eyecatchtype=='P')
                                            {
                                                if(bPrem.indexOf('%')>0)
                                                    bPrem=bPrem.split('%')[0]
                                                 eyecatchRate =  (parseFloat(gridgross) * parseFloat(bPrem))/100;
                                                 gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                                 grossamtfinal=parseFloat(grossamtfinal) + parseFloat(eyecatchRate);
                                            }
                                            else if(eyecatchtype=='F')
                                            {
                                                if(bPrem.indexOf('%')>0)
                                                    bPrem=bPrem.split('%')[0]
                                                 eyecatchRate =  parseFloat(gridgross) + parseFloat(bPrem);
                                                 grossamtfinal=parseFloat(grossamtfinal) + eyecatchRate;
                                                 gross.value = parseFloat(gross.value) + parseFloat(eyecatchRate);
                                            }
                                        }
                                    }
                                    // for insertion wise Box Charges 
                                    if(boxchargeInsertionwise=='yes')
                                    {
                                        var tboxcharge=0;
                                            tboxcharge=boxcharge;
                                        if(hiddenbox_vari.value=='2')
                                        {
                                             tboxcharge=(parseFloat(gridgross) * parseFloat(boxcharge))/100;
                                        }  
                                        grossamtfinal=parseFloat(grossamtfinal) + tboxcharge;
                                        gross.value = parseFloat(gross.value) + parseFloat(tboxcharge);
                                    }
                                    
                                    edicount=gridItemCount;
                                    if(i==0)
                                    {
//                                        if(uomdesc=='CD')
//                                        {
                                            cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].EXTRARATE;
//                                        }
//                                        else
//                                        {
//                                            cardrate=parseFloat(cardrate) + ds.Tables[1].Rows[cntrfill].CARDRATE;
//                                        }    
                                    }
                                    var grossValue = parseFloat(gross.value);
                                    gross.value = grossValue.toFixed(2);
                                   // break;
                                } 
                            } 
                            if(insertsta.value=='cancel')
                            {
                                gross.value=0;
                                freeIns="Y";
                                if(boxchargeInsertionwise=='yes')
                                {
                                    grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate) + parseFloat(boxcharge));
                                }
                                else
                                {
                                    grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate));
                                }   
                                var paidno= "pai"+counter;
                                if(paidno!=null)
                                {
                                    paidno.value='N';
                                }    
                            }
                            else if(paidno!=null)
                            {
                                if(paidno.value=='N')
                                {
                                    gross.value=0;
                                    if(boxchargeInsertionwise=='yes')
                                    {
                                        grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate) + parseFloat(boxcharge));
                                    }
                                    else
                                    {
                                        grossamtfinal=parseFloat(grossamtfinal) - (parseFloat(gridgross) + parseFloat(eyecatchRate));
                                    }  
                                }   
                            }
                             if(billrate!=null)
                            {
                                    var tradisc=document.getElementById('txttradedisc').value;
                                    if(tradisc=="")
                                        tradisc=0;
                                    var trdisc1=tradisc;
                                    var addcomm =0;
                                    if(document.getElementById('txtaddagencycommrate')!=null)
                                    {
                                        addcomm=document.getElementById('txtaddagencycommrate').value;
                                    }
                                    if(addcomm=="")
                                    {
                                        addcomm="0";
                                    }
                                    if(addcomm!="0")
                                    {
                                        trdisc1=parseInt(tradisc) + parseFloat(addcomm);
                                    }
                                    var billamt=0;
                                      if(document.getElementById('agncomm_seq_com').value!="S")
                                        billamt=parseFloat(gross.value) - (parseFloat(gross.value) * parseFloat(trdisc1)/100);
                                      else
                                      {
                                               billamt=parseFloat(gross.value)-parseFloat(gross.value)*parseFloat(tradisc)/100;
                                              if(addcomm!="0" && addcomm!="")
                                              {
                                                 billamt=parseFloat(billamt)-parseFloat(billamt)*parseFloat(addcomm)/100;
                                              }
                                      }  
                                //var billamt=parseFloat(gross.value) - (parseFloat(gross.value) * parseFloat(trdisc1)/100);
                                    billrate.value=billamt;
                                if(billrate.value!="" &&  counter !=parseInt(rowcount)-1)
                                {
                                    billamount=parseFloat(billamount)+parseFloat(billrate.value);
                                }   
                                 if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")  
                                 billrate.value=0;
                            }
                            counter++;
                        }
                        
                    }
                 }
               // END
              
               
            }
            else
            {
                alert(ds.Tables[0].Rows[0].MESSAGE);
                 return false;
            }
          
        }
         
    }
     if(scheme_var!="[object]")
    {
        document.getElementById('drpscheme').value=scheme_var;
    }   
     if(freeIns=="Y")
         {
            document.getElementById('txtpaid').value=parseInt(document.getElementById('txtpaid').value) - 1;
         }  
    if(hiddenbox_vari!=null)
    {
        if(boxchargeInsertionwise=='no')
        {
          if(hiddenbox_vari.value=='2')
          {
              boxcharge=(parseFloat(grossamtfinal) * parseFloat(boxcharge))/100;
          }
           grossamtfinal=parseFloat(grossamtfinal) + parseFloat(boxcharge);   
        }  
     }   
   if(agreedrate_active==1 || agreedamt_active==1)
   {
        document.getElementById('txtgrossamt').value=document.getElementById('txtagreedamt').value;   
        document.getElementById('txtgrossamt').value = parseFloat(document.getElementById('txtgrossamt').value) - parseFloat(agreedcancelAmt);
   }     
    else    
    document.getElementById('txtgrossamt').value=grossamtfinal.toFixed(2);   
    document.getElementById('txtcardrate').value=cardrate.toFixed(2);
   // document.getElementById('txtcardamt').value=grossamtfinal.toFixed(2);
   document.getElementById('txtgrossamt').value=parseFloat(document.getElementById('txtgrossamt').value).toFixed(2);
   if(cardamt!="" && (document.getElementById('txtpremper').value!='' || document.getElementById('txtpageamt').value!=''))
   {
    var premtot=0;
    var pageprem=0;
    var posprem=1;
      if(document.getElementById('txtpremper').value!='')
    {
        premtot= parseFloat(premtot) + parseFloat(document.getElementById('txtpremper').value);
        pageprem=parseFloat(document.getElementById('txtcardrate').value) * parseFloat(document.getElementById('txttotalarea').value) * parseFloat(premtot) / 100;
        // cardamt = parseFloat(cardamt)  -  (parseFloat(pageprem) + parseFloat(document.getElementById('txtcardrate').value) * parseFloat(document.getElementById('txttotalarea').value)) / 100;
     }  
      premtot=0;
      if(document.getElementById('txtpageamt').value!='')// pos prem
      {
       // premtot= parseFloat(premtot) + parseFloat(document.getElementById('txtpageamt').value);  
       
       posprem = document.getElementById('txtpageamt').value;
       }
       if(posprem!='1')
       {
        cardamt = parseFloat(cardamt)  -  ((parseFloat(pageprem) + parseFloat(document.getElementById('txtcardrate').value) * parseFloat(document.getElementById('txttotalarea').value)) * posprem / 100);
        
       } 
      // else
        cardamt = parseFloat(cardamt)  -  parseFloat(pageprem);
     
   // cardamt = parseFloat(cardamt) - parseFloat(document.getElementById('txtcardrate').value) * parseFloat(document.getElementById('txttotalarea').value) * parseFloat(premtot) / 100;
   }
    document.getElementById('txtcardamt').value=cardamt.toFixed(2);
    cardamt=0;
    // Bill Calculation
      if(document.getElementById('txtcardamt').value!="" && document.getElementById('txttradedisc').value!="")
        {
            var caramt=document.getElementById('txtgrossamt').value;
            var tradisc=document.getElementById('txttradedisc').value;
            if(tradisc=="")
                tradisc=0;
            var trdisc1=tradisc;
            var addcomm =0;
            if(document.getElementById('txtaddagencycommrate')!=null)
            {
                addcomm=document.getElementById('txtaddagencycommrate').value;
            }
            if(addcomm=="")
            {
                addcomm="0";
            }
            if(addcomm!="0")
            {
                trdisc1=parseInt(tradisc) + parseFloat(addcomm);
            }
            var tot=0;
            if(document.getElementById('agncomm_seq_com').value!="S")
                 tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(trdisc1)/100;
            else
            {
                 tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(tradisc)/100;
                if(addcomm!="0" && addcomm!="")
                {
                    tot=parseFloat(tot)-parseFloat(tot)*parseFloat(addcomm)/100;
                }
            }        
            document.getElementById('txtbillamt').value=tot.toFixed(2);
        } 
        if(boxchargeInsertionwise=='yes')
        {
        var lastItem="ba"+ (parseInt(counter)-1).toString();
        var fAmt= parseFloat(document.getElementById('txtbillamt').value)-parseFloat(billamount);
        if(document.getElementById(lastItem)!=null)
            document.getElementById(lastItem).value=fAmt;
         }
         if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")  
        {  
             var lastItem="ba"+ (parseInt(counter)-1).toString();
              if(document.getElementById(lastItem)!=null)
                document.getElementById(lastItem).value=0;
            document.getElementById('txtbillamt').value = 0;
         }    
    return false;
}
function date_frmt_orcl(dateformat,value1)
{
    var dd="";
    var mm="";
    var yy="";
    var newdate="";
    if(dateformat=="dd/mm/yyyy")
    {
        var arrvalue1=value1.split('/');
        dd=arrvalue1[0];
        mm=arrvalue1[1];
        yy=arrvalue1[2];        
    }
    else if(dateformat=="mm/dd/yyyy")
    {
        var arrvalue1=value1.split('/');
        dd=arrvalue1[1];
        mm=arrvalue1[0];
        yy=arrvalue1[2];        
    }
    else if(dateformat=="yyyy/mm/dd")
    {
        var arrvalue1=value1.split('/');
        dd=arrvalue1[2];
        mm=arrvalue1[1];
        yy=arrvalue1[0];        
    }
    mm=getmonthstr(mm);
    
    newdate=dd + "-" + mm + "-" + yy;
    
    return newdate;
    
}
function getmonthstr(m_value)
{
    var month="";
    switch(m_value)
    {
        case "1":
            month="JAN";
            break;
            
        case "2":
            month="FEB";
            break;
            
        case "3":
            month="MAR";
            break;
            
        case "4":
            month="APR";
            break;
            
        case "5":
            month="MAY";
            break;
            
        case "6":
            month="JUN";
            break;
            
        case "7":
            month="JUL";
            break;
            
        case "8":
            month="AUG";
            break;
            
        case "9":
            month="SEP";
            break;
            
        case "10":
            month="OCT";
            break;
            
        case "11":
            month="NOV";
            break;
            
        case "12":
            month="DEC";
            break;
            
        ////////////////
        
        case "01":
            month="JAN";
            break;
            
        case "02":
            month="FEB";
            break;
            
        case "03":
            month="MAR";
            break;
            
        case "04":
            month="APR";
            break;
            
        case "05":
            month="MAY";
            break;
            
        case "06":
            month="JUN";
            break;
            
        case "07":
            month="JUL";
            break;
            
        case "08":
            month="AUG";
            break;
            
        case "09":
            month="SEP";
            break;
    }
    
    return month;
}

//on Agreed rate and Agreed amount 24 sep
function getagreedamt()
{
    if(document.getElementById('txtagreedamt').value!="")
    {
        if(parseInt(document.getElementById('txtagreedamt').value)=="0")
        {
            document.getElementById('txtagreedamt').value="";
            document.getElementById('txtagreedrate').value="";
            agreedrate_active=0;
            agreedamt_active=0;
        }
    }
    

    //***********
    document.getElementById('txtgrossamt').value="";
    document.getElementById('drpscheme').value="";
    document.getElementById('txtdiscount').value="";
    document.getElementById('txtdiscpre').value="";
    if(document.getElementById('txtspedisc').value!="" && document.getElementById('txtspediscper').value!="")
    {
        document.getElementById('txtspediscper').value="";
        document.getElementById('txtspedisc').value="";
    }
    var paidCount=document.getElementById('txtinsertion').value;
    var finsert=1;
    var tinsert=0;
    if(document.getElementById('drppackagecopy').options.length>0)
    {
        for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
        {
            if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
            {
                tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                if(parseInt(tinsert)>parseInt(finsert))
                {
                    finsert=tinsert;
                }
                paidCount = parseInt(paidCount) * parseInt(tinsert);
            }    
        }
    } 
    if(document.activeElement.id=='txtagreedrate' && document.getElementById('txtagreedrate').value!="" &&  document.getElementById('txtagreedrate').value!="0")
    {
        agreedrate_active=1;
        agreedamt_active=0;
        if(document.getElementById('txttotalarea').value!="" && document.getElementById('txttotalarea').value!="NaN")
        {           
            document.getElementById('txtagreedamt').value=(parseInt((paidCount),10)*parseFloat(document.getElementById('txtagreedrate').value)*parseFloat(document.getElementById('txttotalarea').value)).toFixed(3);   
            if(document.getElementById('txtcardrate').value!="")
            {
                document.getElementById('txtdiscount').value=(parseFloat(document.getElementById('txtcardrate').value)-parseFloat(document.getElementById('txtagreedrate').value)).toFixed(2);
                document.getElementById('txtdiscpre').value=(parseFloat(document.getElementById('txtdiscount').value)*100/parseFloat(document.getElementById('txtcardrate').value)).toFixed(2);           
            }
        }            
        
    }
    if(document.activeElement.id=='txtagreedamt' && document.getElementById('txtagreedamt').value!="" &&  document.getElementById('txtagreedamt').value!="0")
    {
        agreedrate_active=0;
        agreedamt_active=1;
        if(document.getElementById('txttotalarea').value!="" && document.getElementById('txttotalarea').value!="NaN")
        {
            document.getElementById('txtagreedrate').value=(parseFloat(document.getElementById('txtagreedamt').value)/ (parseInt((paidCount),10)*parseFloat(document.getElementById('txttotalarea').value))).toFixed(3);
            if(document.getElementById('txtcardrate').value!="")
            {
                document.getElementById('txtdiscount').value=(parseFloat(document.getElementById('txtcardrate').value)-parseFloat(document.getElementById('txtagreedrate').value)).toFixed(2);
                document.getElementById('txtdiscpre').value=(parseFloat(document.getElementById('txtdiscount').value)*100/parseFloat(document.getElementById('txtcardrate').value)).toFixed(2);
            }
        }
    }
    else  if(document.activeElement.id=='txtagreedamt' && document.getElementById('txtagreedamt').value=="" &&  document.getElementById('txtagreedamt').value!="0")
    {
        document.getElementById('txtagreedrate').value="";
    }
    if((document.getElementById('txtagreedrate').value=="" || document.getElementById('txtagreedrate').value=="NaN" )&& (document.getElementById('txtagreedamt').value=="" || document.getElementById('txtagreedamt').value=="NaN"))
    {
        agreedrate_active=0;
        agreedamt_active=0;
    }
    if(document.getElementById('hiddenuserdisc').value!="" && document.getElementById('hiddenuserdisc').value!="0" && document.getElementById('txtdiscpre').value!="" && document.getElementById('txtdiscpre').value!="0")
    {
        if(parseFloat(document.getElementById('txtdiscpre').value)>parseFloat(document.getElementById('hiddenuserdisc').value))
        {
            alert("User Allowed Commission can't be greater than " + document.getElementById('hiddenuserdisc').value);
            document.getElementById('txtagreedrate').value="";
            document.getElementById('txtagreedamt').value="";
            document.getElementById('txtdiscpre').value="";
            document.getElementById('txtdiscount').value="";
            agreedrate_active=0;
            agreedamt_active=0;
            document.getElementById('txtagreedrate').focus();
            return false;
        }
    }
}
//*******************************************
function getagreedamt_Rate()
{

    if(document.getElementById('txtagreedrate').value!="")
    {
        if(parseFloat(document.getElementById('txtagreedrate').value)=="0" || parseFloat(document.getElementById('txtagreedrate').value)=="0.00")
        {
            document.getElementById('txtagreedamt').value="";
            document.getElementById('txtagreedrate').value="";
            agreedrate_active=0;
            agreedamt_active=0;
        }
    }
    else
    {
        document.getElementById('txtagreedamt').value="";
        document.getElementById('txtagreedrate').value="";
        agreedrate_active=0;
        agreedamt_active=0;
    }       
    var paidCount=document.getElementById('txtinsertion').value;
    var finsert=1;
    var tinsert=0;
    document.getElementById('txtgrossamt').value="";
    if(document.getElementById('drppackagecopy').options.length>0)
    {
        for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
        {
            if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
            {
                tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                if(parseInt(tinsert)>parseInt(finsert))
                {
                    finsert=tinsert;
                }
                paidCount = parseInt(paidCount) * parseInt(tinsert);
            }    
        }
    } 
    if(agreedrate_active==1)
    {
        agreedrate_active=1;
        agreedamt_active=0;
        if(document.getElementById('txttotalarea').value!="" && document.getElementById('txttotalarea').value!="NaN"    && document.getElementById('txtagreedrate').value!="" && document.getElementById('txtagreedrate').value!="0")
        {           
            document.getElementById('txtagreedamt').value=(parseInt((paidCount),10)*parseFloat(document.getElementById('txtagreedrate').value)*parseFloat(document.getElementById('txttotalarea').value)).toFixed(2);   
            if(document.getElementById('txtcardrate').value!="")
            {
                document.getElementById('txtdiscount').value=(parseFloat(document.getElementById('txtcardrate').value)-parseFloat(document.getElementById('txtagreedrate').value)).toFixed(2);
                document.getElementById('txtdiscpre').value=(parseFloat(document.getElementById('txtdiscount').value)*100/parseFloat(document.getElementById('txtcardrate').value)).toFixed(2);            
            }
        }    
       
    }
    if(agreedamt_active==1)
    {
        agreedrate_active=0;
        agreedamt_active=1;
        if(document.getElementById('txttotalarea').value!="" && document.getElementById('txttotalarea').value!="NaN" && document.getElementById('txtagreedamt').value!="" && document.getElementById('txtagreedamt').value!="0")
        {
             document.getElementById('txtagreedrate').value=(parseFloat(document.getElementById('txtagreedamt').value)/ (parseInt((paidCount),10)*parseFloat(document.getElementById('txttotalarea').value))).toFixed(2);
             if(document.getElementById('txtcardrate').value!="")
             {
                document.getElementById('txtdiscount').value=(parseFloat(document.getElementById('txtcardrate').value)-parseFloat(document.getElementById('txtagreedrate').value)).toFixed(2);
                document.getElementById('txtdiscpre').value=(parseFloat(document.getElementById('txtdiscount').value)*100/parseFloat(document.getElementById('txtcardrate').value)).toFixed(2);
             }
        }
   
    }

}


function getsplcharge()
{
   
    if(document.getElementById('txtextracharges').value!="")
    {
      
        
        var grossamt_var=document.getElementById('txtgrossamt');
        var br_spcharge=0;
        var splcharges= document.getElementById('txtextracharges').value;   
        var grossAmt=grossamt_var.value;
        var len="bookdiv";
        var ratio=0;
        var count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
        for ( var s = 0; s < count; s++)
        {
            var gross_var=document.getElementById('gro'+s);
           if(gross_var!=null)  
           { 
            if(s==count-1)
            {
                gross_var.value = (parseFloat(gross_var.value) + (parseFloat(splcharges)-parseFloat(br_spcharge))).toFixed(2);
            }
            else{
               ratio = (parseFloat(gross_var.value) * parseFloat(splcharges)) / parseFloat(grossAmt)
               gross_var.value = (parseFloat(gross_var.value) + parseFloat(ratio)).toFixed(2);
               br_spcharge = (parseFloat(br_spcharge) + parseFloat(ratio)).toFixed(2);
             }  
           }
        }  
        grossamt_var.value=(parseFloat(grossamt_var.value)+parseFloat(splcharges)).toFixed(2);
        }
    
}


//new change for special discount calculation
function getspecialdisc()
{

    br_spcharge=0;
    var totalarea_var=document.getElementById('txttotalarea');
    var pkg_copy=document.getElementById('drppackagecopy');
    if(document.getElementById('txtagreedrate').value!="" && document.getElementById('txtagreedamt').value!="")
    {
        document.getElementById('txtspedisc').value="";
        document.getElementById('txtspediscper').value=""; 
       // alert('Special discount can not applied in case of agreed rate.' );
        return false;
    }
    var cardrate=document.getElementById('txtcardrate').value;
    if(document.activeElement.id=="txtspedisc" && document.getElementById('txtspedisc').value!="")
    {
        document.getElementById('txtgrossamt').value="";
        if(parseFloat(cardrate)<parseFloat(document.getElementById('txtspedisc').value))
        {
           // alert('Special discount can not be greated than card rate');
            document.getElementById('txtspedisc').value="";
            return false;
        }
        spdisc=1;
        spdiscper=0;
        document.getElementById('txtspediscper').value=((parseFloat(document.getElementById('txtspedisc').value)/parseFloat(cardrate))*100).toFixed(2);
    }
    
    if(document.activeElement.id=="txtspediscper" && document.getElementById('txtspediscper').value!="")
    {
        document.getElementById('txtgrossamt').value="";
        if(parseFloat(document.getElementById('txtspediscper').value)>100)
        {
            alert('Special discount can not be greated than 100%');
            document.getElementById('txtspediscper').value="";
            return false;
        }
        spdisc=0;
        spdiscper=1;
        document.getElementById('txtspedisc').value=(parseFloat(cardrate)*parseFloat(document.getElementById('txtspediscper').value)/100).toFixed(2);
    }
    if(document.getElementById('txtspedisc').value=="" || document.getElementById('txtspediscper').value=="")
    {
       spdisc=0;
       spdiscper=0; 
    }
    else
    {
        var paidCount=document.getElementById('txtinsertion').value;
        var finsert=1;
        var tinsert=0;
        var br_spcharge=0;
        document.getElementById('txtgrossamt').value="";
        if(pkg_copy.options.length>0)
        {
            for(var insertCou=0;insertCou<pkg_copy.options.length;insertCou++)
            {
                    if(pkg_copy.options[insertCou].value.indexOf('(')>=0)
                    {
                        tinsert=pkg_copy.options[insertCou].value.substring(pkg_copy.options[insertCou].value.indexOf('(')+1,pkg_copy.options[insertCou].value.indexOf(')'));
                        if(parseInt(tinsert)>parseInt(finsert))
                        {
                            finsert=tinsert;
                        }
                        paidCount = parseInt(paidCount) * parseInt(tinsert);
                    }    
                }
            }
        var splcharges= document.getElementById('txtspedisc').value; 
        var grossAmt=(parseFloat(cardrate)-parseFloat(splcharges))*parseInt(paidCount,10)*parseFloat(document.getElementById('txttotalarea').value);     
        if(spdisc==1)
        { 
            var len="bookdiv";
            var count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
            for ( var s = 0; s < count; s++)
            {
                var gross_var=document.getElementById('gro'+s);
                var splcharges_grid=(parseFloat(document.getElementById('card'+s).value) / parseFloat(document.getElementById('txtcardrate').value)) * splcharges;
               if(gross_var!=null)
               { 
                    gross_var.value = (parseFloat(gross_var.value) - (parseFloat(splcharges_grid)*parseFloat(totalarea_var.value))).toFixed(2);                       
                    br_spcharge = (parseFloat(br_spcharge) + parseFloat(gross_var.value)).toFixed(2);
               }
            } 
        } 
        
        
        if(spdiscper==1)
        {
          //  var br_spcharge=0;
            var splcharges= document.getElementById('txtspediscper').value;   
            var grossAmt=document.getElementById('txtgrossamt').value;
            var len="bookdiv";
            var ratio=0;
            var count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
            for ( var s = 0; s < count; s++)
            {
                  var gross_var=document.getElementById('gro'+s);
               if(gross_var!=null)
               { 
//                    if(s==count-1)
//                    {
//                        document.getElementById('gro'+s).value = (parseFloat(document.getElementById('gro'+s).value) - ((parseFloat(splcharges)*parseFloat(cardrate)/100)-parseFloat(br_spcharge))).toFixed(2);
//                    }
//                    else
//                    {
//                       ratio = (parseFloat(document.getElementById('gro'+s).value) * (parseFloat(splcharges)*parseFloat(cardrate)*parseFloat(document.getElementById('txttotalarea').value)/100) / parseFloat(grossAmt))
                        var splcharges_grid=(parseFloat(document.getElementById('card'+s).value) * splcharges) / 100;
                       gross_var.value = (parseFloat(gross_var.value) - (parseFloat(splcharges_grid)*parseFloat(totalarea_var.value))).toFixed(2);
                       br_spcharge = (parseFloat(br_spcharge) + parseFloat(gross_var.value)).toFixed(2);
//                    }  
               }
            } 
        } 
              if(br_spcharge==0)
                br_spcharge=grossAmt;
            document.getElementById('txtgrossamt').value=parseFloat(br_spcharge);
             if(document.activeElement.id=="txtspedisc" || document.activeElement.id=="txtspediscper")
                 document.getElementById('txtgrossamt').value="";
    }
    
     if(document.getElementById('txtspediscper').value!="")
    {
        var spacedisc=document.getElementById('txtspediscper').value;
         if(document.getElementById('txtspadiscper').value!="")
        {
            spacedisc = parseFloat(spacedisc) + parseFloat(document.getElementById('txtspadiscper').value);
        }
        if(document.getElementById('hiddenuserdisc').value!="" && document.getElementById('hiddenuserdisc').value!="0")
        {
            if(parseFloat(spacedisc)>parseFloat(document.getElementById('hiddenuserdisc').value))
            {
                alert("User Allowed Commission can't be greater than "+ document.getElementById('hiddenuserdisc').value);
                document.getElementById('txtspediscper').value="";
                document.getElementById('txtspedisc').value="";
                return false;
            }
        }
        
    }
}

//new change for space discount calculation
function getspacedisc()
{

var totalarea_var=document.getElementById('txttotalarea');
    if(document.getElementById('txtagreedrate').value!="" && document.getElementById('txtagreedamt').value!="")
    {
        document.getElementById('txtspacedisc').value="";
        document.getElementById('txtspadiscper').value=""; 
       // alert('Special discount can not applied in case of agreed rate.' );
        return false;
    }
    var cardrate=document.getElementById('txtcardrate').value;
    if(document.activeElement.id=="txtspacedisc" && document.getElementById('txtspacedisc').value!="")
    {
        document.getElementById('txtgrossamt').value="";
        if(parseFloat(cardrate)<parseFloat(document.getElementById('txtspacedisc').value))
        {
           // alert('Special discount can not be greated than card rate');
            document.getElementById('txtspacedisc').value="";
            return false;
        }
        spdisc=1;
        spdiscper=0;
        document.getElementById('txtspadiscper').value=((parseFloat(document.getElementById('txtspacedisc').value)/parseFloat(cardrate))*100).toFixed(2);
    }
    
    if(document.activeElement.id=="txtspadiscper" && document.getElementById('txtspadiscper').value!="")
    {
        document.getElementById('txtgrossamt').value="";
        if(parseFloat(document.getElementById('txtspadiscper').value)>100)
        {
            alert('Space discount can not be greated than 100%');
            document.getElementById('txtspadiscper').value="";
            return false;
        }
        spdisc=0;
        spdiscper=1;
        document.getElementById('txtspacedisc').value=(parseFloat(cardrate)*parseFloat(document.getElementById('txtspadiscper').value)/100).toFixed(2);
    }
    if(document.getElementById('txtspacedisc').value=="" || document.getElementById('txtspadiscper').value=="")
    {
       spdisc=0;
       spdiscper=0; 
    }
    else
    {
        var paidCount=document.getElementById('txtinsertion').value;
        var finsert=1;
        var tinsert=0;
        var br_spcharge=0;
        document.getElementById('txtgrossamt').value="";
        if(document.getElementById('drppackagecopy').options.length>0)
        {
            for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
            {
                    if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
                    {
                        tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                        if(parseInt(tinsert)>parseInt(finsert))
                        {
                            finsert=tinsert;
                        }
                        paidCount = parseInt(paidCount) * parseInt(tinsert);
                    }    
                }
            }
        var splcharges= document.getElementById('txtspacedisc').value; 
        var grossAmt=(parseFloat(cardrate)-parseFloat(splcharges))*parseInt(paidCount,10)*parseFloat(totalarea_var.value);     
        if(spdisc==1)
        { 
            var len="bookdiv";
            var count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
            for ( var s = 0; s < count; s++)
            {
                var gross_var=document.getElementById('gro'+s);
                 var splcharges_grid=(parseFloat(document.getElementById('card'+s).value) / parseFloat(document.getElementById('txtcardrate').value)) * splcharges;
               if(gross_var!=null)
               { 
               
                    gross_var.value = (parseFloat(gross_var.value) - (parseFloat(splcharges_grid)*parseFloat(totalarea_var.value))).toFixed(2);                       
                    br_spcharge = (parseFloat(br_spcharge) + parseFloat(gross_var.value)).toFixed(2);
               }
            } 
        } 
        
        
        if(spdiscper==1)
        {
          //  var br_spcharge=0;
            var splcharges= document.getElementById('txtspadiscper').value;   
            var grossAmt=document.getElementById('txtgrossamt').value;
            var len="bookdiv";
            var ratio=0;
            var count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
            for ( var s = 0; s < count; s++)
            {
                var gross_var=document.getElementById('gro'+s);
               if(gross_var!=null)
               { 
               
//                    if(s==count-1)
//                    {
//                        document.getElementById('gro'+s).value = (parseFloat(document.getElementById('gro'+s).value) - ((parseFloat(splcharges)*parseFloat(cardrate)/100)-parseFloat(br_spcharge))).toFixed(2);
//                    }
//                    else
//                    {
//                       ratio = (parseFloat(document.getElementById('gro'+s).value) * (parseFloat(splcharges)*parseFloat(cardrate)*parseFloat(document.getElementById('txttotalarea').value)/100) / parseFloat(grossAmt))
                        var splcharges_grid=(parseFloat(document.getElementById('card'+s).value) * splcharges) / 100;
                       gross_var.value = (parseFloat(gross_var.value) - (parseFloat(splcharges_grid)*parseFloat(totalarea_var.value))).toFixed(2);
                       br_spcharge = (parseFloat(br_spcharge) + parseFloat(gross_var.value)).toFixed(2);
//                    }  
               }
            } 
        } 
            if(br_spcharge==0)
                br_spcharge=grossAmt;
            document.getElementById('txtgrossamt').value=parseFloat(br_spcharge);
            if(document.activeElement.id=="txtspacedisc" || document.activeElement.id=="txtspadiscper" )
                document.getElementById('txtgrossamt').value="";
    }
    if(document.getElementById('txtspadiscper').value!="")
    {
        var spacedisc=document.getElementById('txtspadiscper').value;
         if(document.getElementById('txtspediscper').value!="")
        {
            spacedisc = parseFloat(spacedisc) + parseFloat(document.getElementById('txtspediscper').value);
        }
        if(document.getElementById('hiddenuserdisc').value!="" && document.getElementById('hiddenuserdisc').value!="0")
        {
            if(parseFloat(spacedisc)>parseFloat(document.getElementById('hiddenuserdisc').value))
            {
                alert("User Allowed Commission can't be greater than "+ document.getElementById('hiddenuserdisc').value);
                document.getElementById('txtspadiscper').value="";
                document.getElementById('txtspacedisc').value="";
                return false;
            }
        }
        
    }
}

    function FillSubCatinGrid()
    {
        if(activeid.indexOf("adcat")==0)
        {
            var id=activeid.replace("adcat","ads");
            document.getElementById(id).value="";
        }
         document.getElementById('txtgrossamt').value="";
        document.getElementById(activeid).value=document.getElementById('aglist').value;
        document.getElementById(activeid).style.backgroundColor="#FFFFFF";
        document.getElementById('agdiv').style.display="none";
    }
	
	function enableGridItems()
	{	    
	   var count1=document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length-1;
	   for(var i=0;i<count1;i++)
	   {
	       var noofcol="nocol"+i;      
           var height="hei"+i;
           var width="wid"+i;
           var late="lat"+i;
           var repeat="rep"+i;
           var paid="pai"+i;
           var premid="prem"+i;
           var remark_inserts="rem"+i; 
           var pageno_inserts="pagno"+i;   
           var page="pagpos"+i;
           var pagstr="sec";
           var adcat="adcat"+i;
           var adsubcat="ads"+i;
           var matsta="mat"+i;
           var insertsta="inssta"+i;
           var colid="col"+i;
            var upl="upload"+i;
            document.getElementById('uploadA').style.color="red";
            document.getElementById('uploadA').style.cursor="pointer";
            document.getElementById('uploadA').disabled=false;
            document.getElementById(upl).disabled=false;
           document.getElementById(colid).disabled=false;
           document.getElementById(adcat).disabled=false;
           document.getElementById(adsubcat).disabled=false;
           document.getElementById(late).disabled=false;
           document.getElementById(repeat).disabled=false;
           document.getElementById(matsta).disabled=false;
           document.getElementById(insertsta).disabled=false;
           document.getElementById(page).disabled=false;
           document.getElementById(paid).disabled=false;
           document.getElementById(height).disabled=false;
           document.getElementById(width).disabled=false;
           document.getElementById(premid).disabled=false;
           document.getElementById(remark_inserts).disabled=false;
           document.getElementById(pageno_inserts).disabled=false;
	   }
	}
	 
	 
    function clearClick()	
    {   
        cali=0;
        //credit info
        if(document.getElementById("divspace")!=null)
            document.getElementById("divspace").style.display="none";
         if(document.getElementById('Panel1')!=null)   
            document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';
            
            arrEdition_Item='';
            document.getElementById('hiddenprint_rec').value="";
             document.getElementById('txtdatetime').value=document.getElementById('currdate').value;
            document.getElementById('txtpageamt').value="";
            document.getElementById('hiddenreceiptno').value="";
             document.getElementById('hiddentradedisc').value="";
            document.getElementById('retcommtype').value="";
            document.getElementById('retcomm').value="";
            document.getElementById('txtaddagencycommrateamt').disabled = true;
            document.getElementById('txtRetainercomm').disabled=true;
            document.getElementById('txtRetainercommamt').value="";
            document.getElementById('txtRetainercomm').value="";
            document.getElementById('showselectedition').style.display='none'
            document.getElementById('ttextchqno').value="";  
             document.getElementById('drpourbank').value="0";                      
            document.getElementById('ttextchqdate').value="";   
            document.getElementById('ttextchqamt').value="";   
            document.getElementById('ttextbankname').value="";  
              document.getElementById('hiddenboxchrgtype').value = "";
            document.getElementById('txtcardname').value="";
            document.getElementById('drptype').value=0;
            document.getElementById('drpmonth').value=0;
            document.getElementById('drpyear').value=0;
            document.getElementById('txtcardno').value="";
            
         document.getElementById('drpagscode').options.length=0;
         document.getElementById('tdcarname').style.display="none";
         document.getElementById('tdtxtcarname').style.display="none";
         document.getElementById('tdtype').style.display="none";
         document.getElementById('tddrptyp').style.display="none";
         document.getElementById('tdexdat').style.display="none";
            
         document.getElementById('tdtxtexdat').style.display="none";
         document.getElementById('tdcardno').style.display="none";
         document.getElementById('tdtxtcarno').style.display="none";  

         document.getElementById('txtcardname').value="";
         document.getElementById('drptype').value=0;
         document.getElementById('drpmonth').value=0;
         document.getElementById('drpyear').value=0;
         document.getElementById('txtcardno').value="";
        document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
        document.getElementById('hiddencalendar').value = "0";
        document.getElementById('hiddensavemod').value = "0";
        document.getElementById('LinkButton1').disabled = true;
        document.getElementById('LinkButton2').disabled = true;
        document.getElementById('LinkButton3').disabled = true;
        document.getElementById('LinkButton4').disabled = true;
        document.getElementById('LinkButton5').disabled = true;
        document.getElementById('LinkButton6').disabled = true;
        document.getElementById('LinkButton7').disabled = true;
        document.getElementById('drpretainer').value = "";
        document.getElementById('drpretainer').disabled = true;
        document.getElementById('btnshgrid').disabled = true;        

        document.getElementById('txtciobookid').disabled = true;
        if(document.getElementById('hiddenaddAgencyComm').value=="Y")
        {
            document.getElementById('txtaddagencycommrate').disabled = false;
            document.getElementById('txtaddagencycommrateamt').disabled = false;
        }    
          document.getElementById('txtpageno').disabled=true;
            document.getElementById('drppagetype').disabled=true;
        document.getElementById('txtrono').disabled = true;
        document.getElementById('txtrodate').disabled = true;
        document.getElementById('txtcaption').disabled==true;
        document.getElementById('txtcaption').value="";        
        document.getElementById('drpbillstatus').disabled = true;
        document.getElementById('drprostatus').disabled = true;
        document.getElementById('txtagency').disabled = true;
        document.getElementById('txtclient').disabled = true;
        document.getElementById('txtagencyaddress').disabled = true;
        document.getElementById('txtclientadd').disabled = true;
        
        document.getElementById('drpagscode').disabled = true;
        document.getElementById('txtdockitno1').disabled = true;
        document.getElementById('txtexecname').disabled = true;
        document.getElementById('txtexeczone').disabled = true;
        document.getElementById('txtproduct').disabled = false;
        document.getElementById('drpbrand').disabled = true;
        document.getElementById('txtkeyno').disabled = true;
        document.getElementById('txtbillremark').disabled = true;
        document.getElementById('txtprintremark').disabled = true;
        document.getElementById('drppackage').disabled = true;
        document.getElementById('txtinsertion').disabled = true;
        document.getElementById('txtdummydate').disabled = true;
        document.getElementById('txtrepeatingdate').disabled = true;
        document.getElementById('drpbooktype').disabled = true;
        document.getElementById('drpadcategory').disabled = true;
        document.getElementById('drpadsubcategory').disabled = true;
        document.getElementById('drpcolor').disabled = true;
        document.getElementById('drpuom').disabled = true;
        document.getElementById('drppageposition').disabled = true;
        
        // txtadsizetypeheight.Enabled = false;
        //txtadsizetypewidth.Enabled = false;
        document.getElementById('txtratecode').disabled = true;
        document.getElementById('drpscheme').disabled = true;
 //       drpschemepck.Enabled = false;
        document.getElementById('drpcurrency').disabled = true;
        document.getElementById('txtagreedrate').disabled = true;
        document.getElementById('txtagreedamt').disabled = true;

        document.getElementById('txtextracharges').disabled = true;
        document.getElementById('txtdatetime').disabled = true;
        document.getElementById('txtrepeatingdate').disabled = true;

        document.getElementById('txtadsize1').disabled = true;
        document.getElementById('txtadsize2').disabled = true;
        document.getElementById('txttotalarea').disabled = true;
        document.getElementById('txtcardrate').disabled = true;
        document.getElementById('txtcardamt').disabled = true;
        document.getElementById('txtdiscount').disabled = true;
        document.getElementById('txtdiscpre').disabled = true;
        document.getElementById('txtrepeatingdate').disabled = true;
        document.getElementById('drpbillcycle').disabled = true;
        document.getElementById('drprevenue').disabled = true;
        document.getElementById('drppaymenttype').disabled = true;
        document.getElementById('txtbillheight').disabled = true;
        document.getElementById('txtbillwidth').disabled = true;
        document.getElementById('drpbillto').disabled = true;
        document.getElementById('txtinvoice').disabled = true;
        document.getElementById('txtvts').disabled = true;
        document.getElementById('txtbilladdress').disabled = true;
        document.getElementById('txttradedisc').disabled = true;
        document.getElementById('txtagencyoutstand').disabled = true;        
        
        document.getElementById('drpboxcode').disabled = true;
        document.getElementById('chkage').disabled = true;
        document.getElementById('chkclie').disabled = true;
        document.getElementById('chktfn').disabled = true;
        
        document.getElementById('txtboxaddress').disabled = true;
        document.getElementById('txtinsertion').disabled = true;

        document.getElementById('txtcolum').disabled = true;  

        ///////////////////////
        document.getElementById('txtcontractname').disabled = true;
        document.getElementById('txtcontracttype').disabled = true;
        document.getElementById('txtcardname').disabled = true;
        document.getElementById('drptype').disabled = true;
        document.getElementById('drpmonth').disabled = true;
        document.getElementById('drpyear').disabled = true;
        document.getElementById('txtcardno').disabled = true;
        document.getElementById('btncopy').disabled = true;
        document.getElementById('btndel').disabled = true;

        document.getElementById('drpadcat3').disabled = true;
        document.getElementById('drpadcat4').disabled = true;
        document.getElementById('drpadcat3').options.length=0;
        document.getElementById('drpadcat4').options.length=0;
        
        document.getElementById('drpadcat5').disabled = true;
        document.getElementById('drpretainer').disabled = true;
        if(document.getElementById('txtaddagencycommrate')!=null)
        {
        document.getElementById('txtaddagencycommrate').disabled = true;
        document.getElementById('txtaddagencycommrate').value = "";
        }
         if(document.getElementById('txtaddagencycommrateamt')!=null)
        {
        document.getElementById('txtaddagencycommrateamt').disabled = true;
        document.getElementById('txtaddagencycommrateamt').value = "";
        }
        document.getElementById('drpadcat5').options.length=0;
        
////        document.getElementById('drpbgcolor').disabled = true;
////        document.getElementById('drpbgcolor').value = "0";
////        document.getElementById('drpbullet').disabled = true;
////        document.getElementById('drpbullet').value = "0";

        document.getElementById('drpmatsta').disabled = true;
        document.getElementById('drpmatsta').value = "0";

        document.getElementById('txtcontractname').value = "";
        document.getElementById('txtcontracttype').value = "";
        document.getElementById('txtcardname').value = "";
        document.getElementById('drptype').value = "0";
        document.getElementById('drpmonth').value = "0";
        document.getElementById('drpyear').value = "0";
        document.getElementById('txtcardno').value = "";
        //////////////////////////////

        document.getElementById('txtcolum').value = "";
       
        document.getElementById('txtciobookid').value = "";       
        document.getElementById('txtrono').value = "";
        document.getElementById('txtrodate').value = "";
        
        document.getElementById('drpbillstatus').value = "0";
        document.getElementById('drprostatus').value = "0";
        document.getElementById('txtagency').value = "";
        document.getElementById('txtclient').value = "";
        document.getElementById('txtagencyaddress').value = "";
        document.getElementById('txtclientadd').value = "";
        document.getElementById('drpagscode').value = "0";
        document.getElementById('txtdockitno1').value = "";
        document.getElementById('txtexecname').value = "";
        document.getElementById('txtexeczone').value = "";
        document.getElementById('txtproduct').value = "";
        document.getElementById('drpbrand').value = "0";
        document.getElementById('txtkeyno').value =  "";
        document.getElementById('txtbillremark').value =  "";
        document.getElementById('txtprintremark').value =  "";
        document.getElementById('txtcreditperiod').value="";
        //drppackage.SelectedValue = "0";
        //drppackage.Items.Clear();
        ///////////on the click of clear button bind the grid again to uncheck
        document.getElementById('txtinsertion').value =  "";
        document.getElementById('txtdummydate').value = "";
        document.getElementById('txtrepeatingdate').value =  "";
        document.getElementById('drpbooktype').value =  "0";
        document.getElementById('drpadcategory').value =  "0";
        document.getElementById('drpadsubcategory').value =  "0";
        document.getElementById('drpcolor').value =  "0";
        document.getElementById('drpuom').value =  "0";
        document.getElementById('drppageposition').value =  "0";

        document.getElementById('txtratecode').value =  "0";
        document.getElementById('drpscheme').value =  "";
     //   drpschemepck.SelectedValue = "0";
        document.getElementById('drpcurrency').value =  "0";
        document.getElementById('txtagreedrate').value =  "";
        document.getElementById('txtagreedamt').value =  "";
 
        document.getElementById('txtextracharges').value = "";

        document.getElementById('txtagencytype').value =  "";
        document.getElementById('txtagencystatus').value =  "";
        //txtagencypaymode.Items.Clear();
        document.getElementById('txtagencypaymode').options.length=0;
        document.getElementById('txtadsize1').value =  "";
        document.getElementById('txtadsize2').value =  "";
        document.getElementById('txttotalarea').value =  "";
        document.getElementById('txtcardrate').value =  "";
        document.getElementById('txtcardamt').value =  "";
        document.getElementById('txtdiscount').value =  "";
        document.getElementById('txtdiscpre').value =  "";
        document.getElementById('txtrepeatingdate').value =  "";
        document.getElementById('drpbillcycle').value = "0";
        //document.getElementById('drprevenue').value = "0";
        document.getElementById('drppaymenttype').options.length=0;
        document.getElementById('txtbillheight').value = "";
        document.getElementById('txtbillwidth').value = "";
        //drpbillto.SelectedValue = "0";
        document.getElementById('drpbillto').options.length=0;
        document.getElementById('txtinvoice').value = "";
        document.getElementById('txtvts').value ="";
        document.getElementById('txtbilladdress').value ="";
        document.getElementById('txttradedisc').value = "";
        document.getElementById('txtagencyoutstand').value = "";
        
        document.getElementById('txtpageamt').value = "";
        
        document.getElementById('drpboxcode').value = "0";
        document.getElementById('chkage').checked = false;
        document.getElementById('chkclie').checked = false;
        document.getElementById('chktfn').checked = false;
        
        document.getElementById('txtboxaddress').value = "";
        document.getElementById('txtinsertion').value = "";

       //*14Aug* drpretainer.SelectedValue = "0";

        document.getElementById('drppackage').value = "0";
        document.getElementById('drppackagecopy').options.length=0;
        document.getElementById('btndel').disabled=true;
        document.getElementById('tblinsert').innerHTML=''
        document.getElementById('tblrate').style.display='none';
        document.getElementById('tblbill').style.display='none';
        document.getElementById('addetails').style.display='none';
        document.getElementById('pagedetail').style.display='none';
        document.getElementById('tblpackage').style.display='none';
        document.getElementById('tbbox').style.display='none';
        disablelistbox();

        document.getElementById('hiddensavemod').value = "01";        
        getbuttoncheck(document.getElementById('hiddenbuttonidcheck').value);
        if(document.getElementById('btnNew').disabled==false)
        {
            document.getElementById('btnNew').focus();
        }    
      var res=Booking_Master_temp.getPrevBookId();
     if(res.value!=null)
     {
        if(res.value.Tables[0].Rows.length>0)
        {
            document.getElementById('txtprevbook').value=res.value.Tables[0].Rows[0].cio_booking_id;
        }
     }
        return false;
}

function disablelistbox()
{             
    document.getElementById("div1").style.display="none"
    document.getElementById("divclient").style.display="none"
    document.getElementById("divproduct").style.display="none"
    document.getElementById("divexec").style.display="none"
}

function getbuttoncheck(id)
{
    if (id == "0" || id == "8")
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = true;
        document.getElementById("btnExit").disabled = true;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;

    }
    if (id == "1" || id == "9")
    {
        document.getElementById("btnNew").disabled = false;
        document.getElementById("btnQuery").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnExecute").disabled = true;

        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;

    }
    if (id == "2" || id == "10")
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnModify").disabled = false;

        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExit").disabled = false;
    }
    if (id == "3" || id == "11")
    {
        document.getElementById("btnNew").disabled = false;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnCancel").disabled = true;
        document.getElementById("btnExit").disabled = true;
        document.getElementById("btnDelete").disabled = true;


        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;

    }
    if (id == "4" || id == "12")
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExecute").disabled = true;

        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;


        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;

    }
    if (id == "5" || id == "13")
    {
        document.getElementById("btnNew").disabled = false;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnModify").disabled = true;

    }
    if (id == "6" || id == "14")
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExecute").disabled = true;
    }
    if (id == "7" || id == "15")
    {
        document.getElementById("btnNew").disabled = false;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnExit").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExecute").disabled = true;
    }
}


function saveClick()
{
       var msg=checkSession();
         if(msg==false)
         {
            window.location.href="login.aspx";
            return false;
         } 
    var prev_cioid = "";
    var prev_receipt = "";
    var prev_ga = 0;
    var srtcancel = "0";
    var auditstatus = "";
    document.getElementById('hiddenclientname').value = document.getElementById('txtclient').value;
   // autogenerated("3");
   /* if (document.getElementById('txtagencypaymode').value == "CA0" || document.getElementById('txtagencypaymode').value == "DD0" || document.getElementById('txtagencypaymode').value == "CH0")
    {
        if (document.getElementById('hiddenprevamt').value != "" && document.getElementById('hiddenprevamt').value != null)
        {
            if (parseFloat(document.getElementById('hiddenprevamt').value) != parseFloat(document.getElementById('txtgrossamt').value))
            {
                 prev_cioid = document.getElementById('txtciobookid').value;
                 prev_receipt = document.getElementById('txtreceipt').value;
                 prev_receipt = document.getElementById('hiddenreceiptno').value;
                 prev_ga = (parseFloat(document.getElementById('txtgrossamt').value) - parseFloat(document.getElementById('hiddenprevamt').value));
                 document.getElementById('hiddensavemod').value = "0";
                 autogenerated("0");
                  if(document.getElementById('hiddenprint_rec').value == "Y")
                    autogenerated("3");
                 srtcancel = "1";
            }
        }

    }*/
    
    if (document.getElementById('hiddenaudit').value == "n")
    {
        if (document.getElementById('txtcardamt').value != document.getElementById('txtagreedamt').value)
            auditstatus = "Not Approved";
        else
            auditstatus = "Approved";
    }
    else
    {
        auditstatus = "Not Approved";
    } 
        
    var branch = document.getElementById('txtbranch').value;
    var booked_by =document.getElementById('txtbookedby').value;
    var prevbook = document.getElementById('txtprevbook').value;
    var res=Booking_Master_temp.getdateCHK(document.getElementById('hiddendateformat').value, document.getElementById('txtdatetime').value);
    if(res.error!=null)
    {
        alert(res.error.description);
        return false;
    }
    var date_time = document.getElementById('txtdatetime').value = res.value;
    var ciobookid = document.getElementById('txtciobookid').value; 
    
    var approvedby = "";
    var audit = "";
    var rono = document.getElementById('txtrono').value;

    var rodate = "";
    if (document.getElementById('txtrodate').value != "")
    {
        res=null;
        res=Booking_Master_temp.getdateCHK(document.getElementById('hiddendateformat').value, document.getElementById('txtrodate').value);
         if(res.error!=null)
        {
            alert(res.error.description);
            return false;
        }
        rodate = document.getElementById('txtrodate').value = res.value;
    }
    rodate = document.getElementById('txtrodate').value;
    
    var caption=document.getElementById('txtcaption').value;
    var billstatus = document.getElementById('drpbillstatus').value;
    var rostatus = document.getElementById('drprostatus').value;
    var agencycod = document.getElementById('txtagency').value;
    
    //////////////this is to split the  and get the code   
//    var myarray = agencycod.split('(');
//    var agencycode = myarray[1];
//    agencycode = agencycode.replace(")", "");
  agencycode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.length  + document.getElementById('txtagency').value.lastIndexOf('('));
             agencycode = agencycode.replace(")", "");
    document.getElementById('hiddenagency').value = agencycode;
    var clientcode = document.getElementById('txtclient').value;
    var client;
    
    ///this is to split and get the client code
    if (clientcode.indexOf("(".toString()) > 0)
    {
        var myarray1 = clientcode.split('(');
        client = myarray1[1];
        client = client.replace(")", '');

        /////this is to chk whether this code exixts in the database if exists than it is a register client else
        res=null;
        res=Booking_Master_temp.chkwalkinClient(client,document.getElementById('hiddencompcode').value);
        var dcl = res.value;
        if(dcl==null)
        {
            alert(res.error.description);
            return false;
        }
        if (dcl.Tables[0].Rows.length > 0)
        {

        }
        else
        {
            client = clientcode;
        }
    }
    else
    {
        client = clientcode;
    }
    
    ///////////////////////////
    var agencyaddress = document.getElementById('txtagencyaddress').value;
    var clientaddresses = document.getElementById('txtclientadd').value;
    var agency = document.getElementById('drpagscode').value;
    agency = document.getElementById('hiddensubcode').value;
    var dockitno = document.getElementById('txtdockitno1').value;
    var execnamecode = document.getElementById('txtexecname').value;
    
    var execname = "";
    if (execnamecode != "")
    {
         var myarrayex = execnamecode.split('(');
         execname = myarrayex[1];
         execname = execname.replace(")", "");
    }
    var execzone = document.getElementById('txtexeczone').value;
   // execzone = document.getElementById('hiddenzone').value;
    var productcode = document.getElementById('txtproduct').value;
    var myarraypr;
    var product;
    if (productcode != "")
    {
        myarraypr = productcode.split('(');
        product = myarraypr[1];
        product = product.replace(")", "");
    }
    else
    {
        product = "";
    }
   
    var brand = document.getElementById('drpbrand').value;
   // brand = document.getElementById('hiddenbrand').value;
    var keyno = document.getElementById('txtkeyno').value;
    var billremark = document.getElementById('txtbillremark').value;
    var printremark = document.getElementById('txtprintremark').value;
    var package=document.getElementById('hiddenpackage').value;   
    var insertion = document.getElementById('txtinsertion').value;

    var startdate = "";
    if (document.getElementById('txtdummydate').value != "")
    {
////         res=null;
////         res=Booking_Master_temp.getdateCHK(document.getElementById('hiddendateformat').value, document.getElementById('txtdummydate').value);
////         if(res.error!=null)
////         {
////            alert(res.error.description);
////            return false;
////         }
////         startdate = res.value;
        startdate=document.getElementById('txtdummydate').value;
    }
    else
    {
        startdate = "";
    }
    var repeatdate = document.getElementById('txtrepeatingdate').value;
    var adtype = "DI0";
    var bookingtype = document.getElementById('drpbooktype').value;
    var adcategory = document.getElementById('drpadcategory').value;
    var subcategory = document.getElementById('drpadsubcategory').value;
    var color = document.getElementById('drpcolor').value;
    var uom = document.getElementById('drpuom').value;
    var pageposition = document.getElementById('drppageposition').value;
    var pagetype =document.getElementById('drppagetype').value;
    var pageno = document.getElementById('txtpageno').value;
    var adsizheight = document.getElementById('txtadsize1').value;
    var adsizwidth = document.getElementById('txtadsize2').value;
    var ratecode = document.getElementById('txtratecode').value;
//    ratecode = document.getElementById('hiddenratecode').value;
    var scheme = document.getElementById('drpscheme').value;
//    scheme = document.getElementById('hiddenscheme').value;
    var currency = document.getElementById('drpcurrency').value;
    var agreedrate = document.getElementById('txtagreedrate').value;
    var agreedamt = document.getElementById('txtagreedamt').value;
    var spedisc ="";
    var spacedisx = "";
    var adsizetype = "0";
    var specialcharges = document.getElementById('txtextracharges').value;
    var agencytype = document.getElementById('txtagencytype').value;
    var agencystatus =  document.getElementById('hiddenstatus').value;   
    var paymode = document.getElementById('drppaymenttype').value;
    var agencredit = document.getElementById('txtcreditperiod').value;
    var cardrate = document.getElementById('txtcardrate').value;
    var cardamount = document.getElementById('txtcardamt').value;
    var discount = document.getElementById('txtdiscount').value;
    var discountper = document.getElementById('txtdiscpre').value;
    var billaddress = document.getElementById('txtbilladdress').value;
    var totarea = document.getElementById('txttotalarea').value;
    var billcycle = document.getElementById('drpbillcycle').value;
    var revenuecenter = document.getElementById('drprevenue').value;    
    var billpay = document.getElementById('hiddenbillpay').value;
    var billheight = document.getElementById('txtbillheight').value;
    var billwidth = document.getElementById('txtbillwidth').value;
    var billto = document.getElementById('drpbillto').value;
   // var billto = document.getElementById('hiddenbillto').value;
    var invoices = document.getElementById('txtinvoice').value;
    var vts = document.getElementById('txtvts').value;
    var tradedisc = document.getElementById('txttradedisc').value;
    var agencyout = document.getElementById('txtagencyoutstand').value;
    var boxcode = document.getElementById('drpboxcode').value;
    var boxno = document.getElementById('txtboxno').value;
    var boxaddress = document.getElementById('txtboxaddress').value;
    var boxagency;
    var boxclient;
    var tfn;
    var coupan="";
    var campaign = document.getElementById('txtcamp').value;
     if(document.getElementById('txtcardamt').value!="" && document.getElementById('txttradedisc').value!="")
		            {
		                var caramt=document.getElementById('txtgrossamt').value;
		                var tradisc=document.getElementById('txttradedisc').value;
		                if(tradisc=="")
		                    tradisc=0;
		                var trdisc1=tradisc;
                        var addcomm =0;
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        {
                            addcomm=document.getElementById('txtaddagencycommrate').value;
                        }
                        if(addcomm=="")
                        {
                            addcomm="0";
                        }
                        if(addcomm!="0")
                        {
                            trdisc1=parseInt(tradisc) + parseFloat(addcomm);
                        }
                        var tot=0;
                        if(document.getElementById('agncomm_seq_com').value!="S")
                            tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(trdisc1)/100;
                        else
                        {
		                 tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(tradisc)/100;
		                  if(addcomm!="0" && addcomm!="")
                            {
		                    tot=parseFloat(tot)-parseFloat(tot)*parseFloat(addcomm)/100;
		                    } 
		                }
		                document.getElementById('txtbillamt').value=tot.toFixed(2);
		                if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")  
		                     document.getElementById('txtbillamt').value = "0";
		                bill_amt = document.getElementById('txtbillamt').value;
                    }
        else
        {
         bill_amt = document.getElementById('txtbillamt').value;
         }  
    var pageprem = document.getElementById('drppageprem').value;
    var pageamt = document.getElementById('txtpageamt').value;
    var premper =  document.getElementById('txtpremper').value;
    var grossamt = document.getElementById('txtgrossamt').value;
    var adsizcolumn = document.getElementById('txtcolum').value;
    var billcolumn = "";
    var billarea;
    if (document.getElementById('txtbillwidth').value != "")
    {
        billarea = parseFloat(document.getElementById('txtbillwidth').value) * parseFloat(document.getElementById('txtbillheight').value);
    }
    else
    {
        billarea = 0;
    }
    
    var specdiscper = document.getElementById('txtspediscper').value;
    var spacediscper = document.getElementById('txtspadiscper').value;
        spedisc  = document.getElementById('txtspedisc').value;
        spacedisx =document.getElementById('txtspacedisc').value; 
    var paidins = document.getElementById('txtpaid').value;
    var dealrate = document.getElementById('txtdealrate').value;
    var deviation = document.getElementById('txtdeviation').value;
    var varient = "";
    if (document.getElementById('drpvarient').options.length > 0)
    {
          varient = document.getElementById('drpvarient').value;
    }
   // var varient = document.getElementById('hiddenvar').value;

    var contractname = document.getElementById('txtcontractname').value;
    var dealtyp = document.getElementById('txtcontracttype').value;
    var cardname = document.getElementById('txtcardname').value;
    var cardtype = document.getElementById('drptype').value;
    var cardmonth = document.getElementById('drpmonth').value;
    var cardyear = document.getElementById('drpyear').value;
    var cardno = document.getElementById('txtcardno').value;
    var receiptno = document.getElementById('hiddenreceiptno').value;
    var caption = document.getElementById('txtcaption').value;
    var campaign = "";
   
    var adscat3 = document.getElementById('drpadcat3').value;
  //  adscat3 = document.getElementById('hiddenadscat3').value;
    var adscat4 = document.getElementById('drpadcat4').value;
  //  adscat4 = document.getElementById('hiddenadscat4').value;
    var adscat5 = document.getElementById('drpadcat5').value;
  //  adscat5 = document.getElementById('hiddenadscat5').value;
    var bgcolor = "0";
    var bulletcode = "0";
    var bulletprm = "";
  //  bulletprm = document.getElementById('hiddenbullprem').value;
    var material = document.getElementById('drpmatsta').value;
    if (document.getElementById('chkage').checked == true)
    {
        boxagency = "1";
    }
    else
    {
        boxagency = "0";
    }
    if (document.getElementById('chkclie').checked == true)
    {
        boxclient = "1";
    }
    else
    {
        boxclient = "0";
    }

    if (document.getElementById('chktfn').checked == true)
    {
        tfn = "1";
    }
    else
    {
        tfn = "0";
    }
    if (document.getElementById('chkcoupan').checked == true)
    {
        coupan = "1";
    }
    else
    {
        coupan = "0";
    }

    var retainer = document.getElementById('drpretainer').value;
    var addagencycommVar=0;
    if(document.getElementById('txtaddagencycommrate')!=null)
     addagencycommVar = document.getElementById('txtaddagencycommrate').value;
    if (document.getElementById('hiddensavemod').value == "0")
    {
        if(document.getElementById('hiddenprint_rec').value == "Y")
            autogenerated("3");
        receiptno=document.getElementById('hiddenreceiptno').value;
        ciobookid = document.getElementById('txtciobookid').value;
        res=null;
        res=Booking_Master_temp.bookidchk(document.getElementById('hiddencompcode').value,document.getElementById('txtciobookid').value,agency, agencycode, rono, "0",document.getElementById('txtkeyno').value);
        var dck = res.value;
        if(dck==null)
        {
            alert(res.error.description);
            return false;
        }
        if (dck.Tables[0].Rows.length >= 1)
        {
            message = "This Booking Id Has Been Assigned";
            alert(message);
            clearClick();
            return false;
        }
        if (document.getElementById('txtrono').value == "")
        {
            autogenerated("1");
            dockitno = document.getElementById('txtdockitno1').value;
            if (document.getElementById('hiddenrostatus').value == "1")
            {
                document.getElementById('drprostatus').value = "1";
                rostatus = document.getElementById('drprostatus').value;
            }
        }
        if(rostatus=="0")
            rostatus="1";
        res=null;
        res=Booking_Master_temp.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, "DI0", document.getElementById('hiddencompcode').value, agency, client,document.getElementById('hiddendateformat').value);
        var dgr = res.value;
        if(dgr==null)
        {
            alert(res.error.description);
            return false;
        }
        if (dgr.Tables[0].Rows.length > 0)
        {
            rategr = dgr.Tables[0].Rows[0].Rate_Gr_Code;
        }
        if (dgr.Tables[2].Rows.length > 0)
        {
            agencyrate = dgr.Tables[2].Rows[0].client;
        }
        if (dgr.Tables[1].Rows.length > 0)
        {
            clientrate = dgr.Tables[1].Rows[0].rate;
        }
        
        res=null;
        var txtaddagencycommrate=0;
        if(document.getElementById('txtaddagencycommrate')!=null)
        {
            txtaddagencycommrate=document.getElementById('txtaddagencycommrate').value;
        }
        var addlamt="";
        var retamt="";
        var retper="";
        if(document.getElementById('txtaddagencycommrateamt')!=null)
        {
            addlamt=document.getElementById('txtaddagencycommrateamt').value;
        }
        if(document.getElementById('txtRetainercommamt')!=null)
        {
            retamt=document.getElementById('txtRetainercommamt').value;
        }
          if(document.getElementById('txtRetainercomm')!=null)
                {
                    retper=document.getElementById('txtRetainercomm').value;
                }
          
        res=Booking_Master_temp.insertBooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, billarea, specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, prev_ga, "0", "0", "0", "0", "0", "0", "0", document.getElementById('hiddendateformat').value, retainer, txtaddagencycommrate,srtcancel,auditstatus,addlamt,retamt,retper);
        
        if(res.error!=null)
           {
            alert(res.error.description);
            return false;
           }
           
        saveinsertion();
        //save cheque/dd information
        
        if(document.getElementById('drppaymenttype').value=='CH0' || document.getElementById('drppaymenttype').value=='DD0' || document.getElementById('drppaymenttype').value=='PO0')
        {
           if(document.getElementById('ttextchqno').value == "" || document.getElementById('ttextchqdate').value == "" || document.getElementById('ttextchqamt').value == "" || document.getElementById('ttextbankname').value == "")
           {}
           else
           {
               var ag_subcode=agencycode.split(agency)[1];
                 var retainercode="0";
            if(retainer.lastIndexOf("(")>=0)
            retainercode=retainer.substring(retainer.indexOf("(")+1,retainer.length-1);
               var resRe=Booking_Master_temp.getRepresenttaive(document.getElementById('hiddencompcode').value,execname,retainercode);      
               if(resRe.value==null)
               {
                alert(resRe.error.description);
                return false;
               }
               var repcode="";
               if(resRe.value.Tables[0].Rows.length>0)
                repcode=resRe.value.Tables[0].Rows[0].REPRESENTATIVE;
                if(repcode==null)
                    repcode="";
               Booking_Master_temp.Insert_rcpthdr(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value,document.getElementById('hiddenreceiptno').value,date_time,document.getElementById('ttextchqno').value,document.getElementById('ttextchqdate').value,document.getElementById('ttextchqamt').value,document.getElementById('ttextbankname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,document.getElementById('hiddendateformat').value,"",document.getElementById('drpourbank').value,repcode); 
               Booking_Master_temp.Insert_rcptdet(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value,document.getElementById('hiddenreceiptno').value,date_time,document.getElementById('ttextchqno').value,document.getElementById('ttextchqdate').value,document.getElementById('ttextchqamt').value,document.getElementById('ttextbankname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,document.getElementById('hiddendateformat').value,""); 
               Booking_Master_temp.Insert_outstand(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value,document.getElementById('hiddenreceiptno').value,date_time,document.getElementById('ttextchqno').value,document.getElementById('ttextchqdate').value,document.getElementById('ttextchqamt').value,document.getElementById('ttextbankname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,document.getElementById('hiddendateformat').value); 
           }
        }
        else if(document.getElementById('drppaymenttype').value=='CR0')
            {
                if(document.getElementById('txtcardname').value!="" && document.getElementById('drptype').value!="0" && document.getElementById('drpmonth').value!="0" && document.getElementById('drpyear').value!="0" && document.getElementById('txtcardno').value!="")
                {
                    var ag_subcode=agencycode.split(agency)[1];
                    var cDate=""
                    if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
                    {
                        cDate="28" + "/" +  document.getElementById('drpmonth').value + "/" +  document.getElementById('drpyear').value;
                    }
                    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                    {
                        cDate=document.getElementById('drpmonth').value + "/" + "28" + "/" +  document.getElementById('drpyear').value;
                    }
                    if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                    {
                        cDate=document.getElementById('drpyear').value + "/" + document.getElementById('drpmonth').value + "/"+ "28";
                    }
                     var retainercode="0";
            if(retainer.lastIndexOf("(")>=0)
            retainercode=retainer.substring(retainer.indexOf("(")+1,retainer.length-1);
                     var resRe=Booking_Master_temp.getRepresenttaive(document.getElementById('hiddencompcode').value,execname,retainercode);      
                       if(resRe.value==null)
                       {
                        alert(resRe.error.description);
                        return false;
                       }
                       var repcode="";
                       if(resRe.value.Table[0].Rows.length>0)
                        repcode=resRe.value.Tables[0].Rows[0].REPRESENTATIVE;
                         if(repcode==null)
                            repcode="";
                    Booking_Master_temp.Insert_rcpthdr(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value,document.getElementById('hiddenreceiptno').value,date_time,document.getElementById('txtcardno').value,cDate,"0",document.getElementById('txtcardname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,document.getElementById('hiddendateformat').value,document.getElementById('drptype').value,document.getElementById('drpourbank').value,repcode); 
                    Booking_Master_temp.Insert_rcptdet(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value,document.getElementById('hiddenreceiptno').value,date_time,document.getElementById('txtcardno').value,cDate,"0",document.getElementById('txtcardname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,document.getElementById('hiddendateformat').value,document.getElementById('drptype').value); 
                    Booking_Master_temp.Insert_outstand(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value,document.getElementById('hiddenreceiptno').value,date_time,document.getElementById('txtcardno').value,cDate,"0",document.getElementById('txtcardname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,document.getElementById('hiddendateformat').value); 
                }
            }
        ////////////////////////////////////////////   
        if(browser!="Microsoft Internet Explorer")
        {
             var  httpRequest =null;
             httpRequest= new XMLHttpRequest();
             if (httpRequest.overrideMimeType) 
             {
                httpRequest.overrideMimeType('text/xml'); 
             }
                
             httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             var adcat=document.getElementById('drpadcategory').value;
             httpRequest.open( "GET","saveImageBooking.aspx?cioid="+document.getElementById('txtciobookid').value, false );
             httpRequest.send('');
             
             if (httpRequest.readyState == 4) 
             {
                 if (httpRequest.status == 200) 
                 {
                      strtext=httpRequest.responseText;
                 }
                 else 
                 {
                     alert('There was a problem with the request.');
                 }
              }
         }
        else
        { 
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             var adcat=document.getElementById('drpadcategory').value;
             xml.open( "GET","saveImageBooking.aspx?cioid="+document.getElementById('txtciobookid').value, false );
             xml.Send();               
        }
         document.getElementById('hiddencioid').value = ciobookid;
        document.getElementById('txtprevbook').value=ciobookid;     
        if(document.activeElement.id=="btnsavepaginate")
        {
            
            executeClick();
            Paginate();
            
        }   
        else
        {
        clearClick();
         document.getElementById('tblinsert').innerHTML=''
        }
        message = "Data Saved Sucessfully with CIO Id " + ciobookid + "";
        alert(message);
        document.getElementById('hiddencioid').value = ciobookid;
        document.getElementById('txtprevbook').value=ciobookid;     
 
        getbuttoncheck(document.getElementById('hiddenbuttonidcheck').value);
       
        if (document.getElementById('hiddenprint_rec').value == "Y")
        {
            printreceipt_display();
        }     
    }
    else  //modify
    {
        //update check info
          if(document.getElementById('hiddenprint_rec').value == "Y" && document.getElementById('txtreceipt').value=="")
                autogenerated("3");
         if(paymode=="CH0" || paymode=="DD0")
         {
            var ag_subcode=agencycode.split(agency)[1];
            var retainercode="0";
            if(retainer.lastIndexOf("(")>=0)
            retainercode=retainer.substring(retainer.indexOf("(")+1,retainer.length-1);
              var resRe=Booking_Master_temp.getRepresenttaive(document.getElementById('hiddencompcode').value,execname,retainercode);      
                       if(resRe.value==null)
                       {
                        alert(resRe.error.description);
                        return false;
                       }
                       var repcode="";
                       if(resRe.value.Tables[0].Rows.length>0)
                        repcode=resRe.value.Tables[0].Rows[0].REPRESENTATIVE;
                         if(repcode==null)
                    repcode="";
            Booking_Master_temp.update_chqinfo(document.getElementById('hiddencompcode').value,receiptno,document.getElementById('ttextchqno').value,document.getElementById('ttextchqdate').value,document.getElementById('ttextchqamt').value,document.getElementById('ttextbankname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,"RCR",date_time,document.getElementById('hiddendateformat').value,"",document.getElementById('drpourbank').value,repcode);
            
         }
         else if(paymode=="CR0")
         {
            var ag_subcode=agencycode.split(agency)[1];
             var cDate=""
            if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
            {
                cDate="28" + "/" +  document.getElementById('drpmonth').value + "/" +  document.getElementById('drpyear').value;
            }
            if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
            {
                cDate=document.getElementById('drpmonth').value + "/" + "28" + "/" +  document.getElementById('drpyear').value;
            }
            if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
            {
                cDate=document.getElementById('drpyear').value + "/" + document.getElementById('drpmonth').value + "/"+ "28";
            }
            Booking_Master_temp.update_chqinfo(document.getElementById('hiddencompcode').value,receiptno,document.getElementById('txtcardno').value,cDate,"0",document.getElementById('txtcardname').value,agencycode,agency,ag_subcode,document.getElementById('drppaymenttype').value,"RCR",date_time,document.getElementById('hiddendateformat').value,document.getElementById('drptype').value,document.getElementById('drpourbank').value);
            
         }
        //**************
        
//        if (document.getElementById('txtciobookid').value != "")
//        {
//            res=null;
//            Booking_Master_temp.InsertintoTemp(document.getElementById('txtciobookid').value,document.getElementById('hiddencompcode').value);          
//            res=Booking_Master_temp.deleteid(document.getElementById('txtciobookid').value,document.getElementById('hiddencompcode').value);          
//        }
        res=null;
        var txtaddagencycommrate=0;
        if(document.getElementById('txtaddagencycommrate')!=null)
        {
            txtaddagencycommrate=document.getElementById('txtaddagencycommrate').value;
        }
               var addlamt="";
                var retamt="";
                if(document.getElementById('txtaddagencycommrateamt')!=null)
                {
                    addlamt=document.getElementById('txtaddagencycommrateamt').value;
                }
                if(document.getElementById('txtRetainercommamt')!=null)
                {
                    retamt=document.getElementById('txtRetainercommamt').value;
                }
                  if(document.getElementById('txtRetainercomm')!=null)
                {
                    retper=document.getElementById('txtRetainercomm').value;
                }
                 receiptno=document.getElementById('txtreceipt').value;
        res=Booking_Master_temp.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, billarea, specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus,retainer,txtaddagencycommrate,document.getElementById('hiddendateformat').value,addlamt,retamt,retper);           
        if(res.value==null)
        {
            alert("Update Process is not completed successfully. Please Login again and then Modify");
            return false;
         }   
        Booking_Master_temp.deletefromtemp(document.getElementById('txtciobookid').value,document.getElementById('hiddencompcode').value);          
        getmodifygrid();
        
        var savename = "";
        if(browser!="Microsoft Internet Explorer")
        {
             var  httpRequest =null;
             httpRequest= new XMLHttpRequest();
             if (httpRequest.overrideMimeType) 
             {
                httpRequest.overrideMimeType('text/xml'); 
             }
            
             httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             var adcat=document.getElementById('drpadcategory').value;
             httpRequest.open( "GET","saveImageBooking.aspx?cioid="+document.getElementById('txtciobookid').value, false );
             httpRequest.send('');
         
             if (httpRequest.readyState == 4) 
             {
                 if (httpRequest.status == 200) 
                 {
                      strtext=httpRequest.responseText;
                 }
                 else 
                 {
                     alert('There was a problem with the request.');
                 }
              }
        }
        else
        { 
           var xml = new ActiveXObject("Microsoft.XMLHTTP");
           var adcat=document.getElementById('drpadcategory').value;
           xml.open( "GET","saveImageBooking.aspx?cioid="+document.getElementById('txtciobookid').value, false );
           xml.Send();           
        }
        document.getElementById('hiddencioid').value = ciobookid;
        document.getElementById('hiddencalendar').value = "0";
        document.getElementById('txtciobookid').value=gciobookid;    
        document.getElementById('txtdockitno1').value=gdockitno;   
        document.getElementById('txtkeyno').value=gkeyno;  
        document.getElementById('txtrono').value=grono;
        alert("Data Updated Successfully");
        executeClick();
           
        if (document.getElementById('hiddenprint_rec').value == "Y")
        {
           printreceipt_display();
        }
     
    }
}


    function executeClick()
    {
           var msg=checkSession();
           if(rownumEx==undefined || rownumEx=="undefined")
                rownumEx=0;
         if(msg==false)
         {
            window.location.href="login.aspx";
            return false;
         } 
        document.getElementById('tblinsert').innerHTML='';
        document.getElementById('hiddensavemod').value = "1";
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton2').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton5').disabled = false;
        document.getElementById('LinkButton6').disabled = false;
        document.getElementById('LinkButton7').disabled = false;

        //////////////////////////////////////////////////////////////////////////

        document.getElementById('btnshgrid').disabled = true;
        //btnupload.Enabled = false;

        document.getElementById('drpbooktype').disabled = true;
        document.getElementById('txtciobookid').disabled = true;
        // txtappby.Enabled = true;
        //txtaudit.Enabled = true;
        document.getElementById('txtrono').disabled = true;
        document.getElementById('txtrodate').disabled = true;
        document.getElementById('txtcaption').disabled=true;
        
        document.getElementById('drpbillstatus').disabled = true;
        document.getElementById('drprostatus').disabled = true;
        document.getElementById('txtagency').disabled = true;
        document.getElementById('txtclient').disabled = true;
        // txtagencyaddress.Enabled = true;
        document.getElementById('txtclientadd').disabled = true;
        document.getElementById('drpagscode').disabled = true;
        document.getElementById('txtdockitno1').disabled = true;
        document.getElementById('txtexecname').disabled = true;
        document.getElementById('txtexeczone').disabled = true;
        document.getElementById('txtproduct').disabled = true;
        document.getElementById('drpbrand').disabled = true;
        document.getElementById('txtkeyno').disabled = true;
        document.getElementById('txtbillremark').disabled = true;
        document.getElementById('txtprintremark').disabled = true;
        document.getElementById('drppackage').disabled = true;
        document.getElementById('txtinsertion').disabled = true;
        document.getElementById('txtdummydate').disabled = true;
        document.getElementById('txtrepeatingdate').disabled = true;
        document.getElementById('drpbooktype').disabled = true;
        document.getElementById('drpadcategory').disabled = true;
        document.getElementById('drpadsubcategory').disabled = true;
        document.getElementById('drpcolor').disabled = true;
        document.getElementById('drpuom').disabled = true;
        document.getElementById('drppageposition').disabled = true;
        document.getElementById('drppagetype').disabled = true;
        document.getElementById('txtpageno').disabled = true;
        document.getElementById('drpadstype').disabled=false;
       document.getElementById('txtRetainercommamt').disabled=true;
       document.getElementById('txtaddagencycommrateamt').disabled=true;

        document.getElementById('txtratecode').disabled = true;
        document.getElementById('drpscheme').disabled = true;
        document.getElementById('drpcurrency').disabled = true;
        document.getElementById('txtagreedrate').disabled = true;
        document.getElementById('txtagreedamt').disabled = true;
        document.getElementById('txtspedisc').disabled = true;
        document.getElementById('txtspacedisc').disabled = true;
        
        document.getElementById('txtextracharges').disabled = true;
        document.getElementById('txtdatetime').disabled = true;
        document.getElementById('txtrepeatingdate').disabled = true;

        document.getElementById('drpbillcycle').disabled = true;
        document.getElementById('drprevenue').disabled = true;
        //drpbilltype.Enabled = true;
        document.getElementById('drpbillstatus').disabled = true;
        //drpbillcurrency.Enabled = true;
        document.getElementById('drppaymenttype').disabled = true;
        document.getElementById('txtinvoice').disabled = true;
        document.getElementById('txtvts').disabled = true;
        document.getElementById('txtbillwidth').disabled = true;
        document.getElementById('txtbillheight').disabled = true;
        document.getElementById('drpbillto').disabled = true;
        document.getElementById('txttradedisc').disabled = true;
        document.getElementById('txtagencyoutstand').disabled = true;
        document.getElementById('txtcardrate').disabled = true;
        document.getElementById('txtcardamt').disabled = true;
        document.getElementById('txtdiscount').disabled = true;
        document.getElementById('txtdiscpre').disabled = true;
        document.getElementById('txtadsize2').disabled = true;
        document.getElementById('txtadsize1').disabled = true;
        document.getElementById('txttotalarea').disabled = true;
        document.getElementById('txtbilladdress').disabled = true;
        
        document.getElementById('drpboxcode').disabled = true;
        //txtboxno.Enabled = true;
        document.getElementById('txtboxaddress').disabled = true;
        document.getElementById('txtcamp').disabled = true;
        document.getElementById('txtbillamt').disabled = true;
        document.getElementById('drppageprem').disabled=true;
        document.getElementById('txtgrossamt').disabled = true;   
        
        document.getElementById('drpboxcode').disabled = true;
        document.getElementById('chkage').disabled = true;
        document.getElementById('chkclie').disabled = true;
        document.getElementById('chktfn').disabled = true;
        document.getElementById('chkcoupan').disabled = true;
       
        document.getElementById('txtinsertion').disabled = true;

        document.getElementById('txtcolum').disabled = true;
        document.getElementById('txtspediscper').disabled = true;
        document.getElementById('txtspadiscper').disabled = true;
        document.getElementById('txtboxno').disabled = true;        
        document.getElementById('txtcontractname').disabled = true;
        document.getElementById('txtcontracttype').disabled = true;
        document.getElementById('txtcardname').disabled = true;
        document.getElementById('drptype').disabled = true;
        document.getElementById('drpmonth').disabled = true;
        document.getElementById('drpyear').disabled = true;
        document.getElementById('txtcardno').disabled = true;
        document.getElementById('txtagencypaymode').disabled = true;

        document.getElementById('btncopy').disabled = true;
        document.getElementById('btndel').disabled = true;        
        document.getElementById('btndeal').disabled = true;
        document.getElementById('drpmatsta').disabled = true;

        document.getElementById('drpretainer').disabled = true;
        if(document.getElementById('txtaddagencycommrate')!=null)
        {
            document.getElementById('txtaddagencycommrate').disabled = true;           
        }  

        //checkinfo
        document.getElementById('ttextchqno').disabled = true;     
         document.getElementById('drpourbank').disabled=true;                   
        document.getElementById('ttextchqdate').disabled = true;
        document.getElementById('ttextchqamt').disabled = true;
        document.getElementById('ttextbankname').disabled = true;
        ///////////////////////////////////////////////////////////////////////////

        var ciobookid = document.getElementById('hiddencioid').value=document.getElementById('txtciobookid').value;
        gciobookid = ciobookid;
        var docno = document.getElementById('txtdockitno1').value;
        gdockitno = docno;
        var keyno = document.getElementById('txtkeyno').value;
        gkeyno = keyno;
        var rono = document.getElementById('txtrono').value;
        grono = rono;

        var agencycod = document.getElementById('txtagency').value;
        var agencycode = "";
        //////////////this is to split the  and get the code
        if (agencycod != "")
        {
            var myarray = agencycod.split('(');
            agencycode = myarray[1];
            agencycode = agencycode.replace(")", "");
            gagencyscode = agencycode;
        }
        ////for client
        var clientcode = document.getElementById('txtclient').value;
        var client = "";
        ///this is to split and get the client code

        if (clientcode.indexOf("(".toString()) > 0 && clientcode != "")
        {
            var myarray1 = clientcode.split('(');
            client = myarray1[1];
            client = client.replace(")", '');
            var res=Booking_Master_temp.chkwalkinClient(client,document.getElementById('hiddencompcode').value);
            var dcl = res.value;
            if(dcl==null)
            {
                alert(res.error.description);
                return false;
            }
            if (dcl.Tables[0].Rows.length > 0)
            {

            }
            else
            {
                client = clientcode;
            }
        }
        else
        {
            client = clientcode;
        }
        gclient = client;
        ////////////////////////////////////////////////////////////////////////////////////////
        var res1 = Booking_Master_temp.executeBooking(document.getElementById('hiddencompcode').value, ciobookid, docno, keyno, rono, agencycode, client, "DI0",document.getElementById('hiddendateformat').value,document.getElementById('txtbranch').value);
        executequery=res1.value;
        if(executequery==null)
        {
            alert(res1.error.description);
            return false;
        }
           // dateinsert getdatechk = new dateinsert();
        if (executequery.Tables[0].Rows.length > 0)
        {
             if(executequery.Tables[0].Rows[rownumEx].prev_booking!=null && executequery.Tables[0].Rows[rownumEx].prev_booking!="")
                {
                    var res = Booking_Master_temp.checkCIOIDReference(document.getElementById('hiddencompcode').value,executequery.Tables[0].Rows[0].cio_booking_id);
                    if(res.value!=null)
                    {
                        if(executequery.Tables[0].Rows[0].cio_booking_id!=res.value)
                        {
                            alert("CIO ID " + executequery.Tables[0].Rows[0].cio_booking_id + " has been ReScheduled to New CIO ID " + res.value);
                            return false;
                        }    
                    }
                }
            if(executequery.Tables[0].Rows[0].branch!=null)
            {
                 document.getElementById('txtbranch').value = executequery.Tables[0].Rows[0].branch;
            }    
                if(executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM_AMT!=null)
                {
                    document.getElementById('txtaddagencycommrateamt').value=executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM_AMT;
                }
                else
                {
                     document.getElementById('txtaddagencycommrateamt').value="";
                }
                  if(executequery.Tables[0].Rows[rownumEx].RETAINER_COMM_AMT!=null)
                {
                    document.getElementById('txtRetainercommamt').value=executequery.Tables[0].Rows[rownumEx].RETAINER_COMM_AMT;
                }
                else
                {
                    document.getElementById('txtRetainercommamt').value="";
                }
                   if(executequery.Tables[0].Rows[rownumEx].RETAINER_COMM!=null)
                {
                    document.getElementById('txtRetainercomm').value=executequery.Tables[0].Rows[rownumEx].RETAINER_COMM;
                }
                else
                {
                    document.getElementById('txtRetainercomm').value="";
                }
            if(executequery.Tables[0].Rows[0].booked_by!=null)
            {
                 document.getElementById('txtbookedby').value = executequery.Tables[0].Rows[0].booked_by;
            }
            if(executequery.Tables[0].Rows[0].prev_booking!=null)
            {    
                 document.getElementById('txtprevbook').value = executequery.Tables[0].Rows[0].prev_booking;
            }    
             if(executequery.Tables[0].Rows[0].boxchrg!=null)
                  {
                    boxpercen=executequery.Tables[0].Rows[0].boxchrg;
                    document.getElementById('hiddenboxchrgtype').value=executequery.Tables[0].Rows[0].boxchargetype;
                  }  
            var datetime = executequery.Tables[0].Rows[0].DATE_TIME;
            if(datetime!=null)
            {
                document.getElementById('txtdatetime').value = datetime;//getdatechk.getDate(dateformat, datetime);
            }   
            if(executequery.Tables[0].Rows[0].cio_booking_id!=null)
            {
                document.getElementById('txtciobookid').value = executequery.Tables[0].Rows[0].cio_booking_id;
            }  
                
            if(executequery.Tables[0].Rows[0].RO_No!=null)
            {
                document.getElementById('txtrono').value = executequery.Tables[0].Rows[0].RO_No;
            }   
            var ro_date = executequery.Tables[0].Rows[0].RO_Date;
            if(ro_date!=null)
            {  
                document.getElementById('txtrodate').value = ro_date;//getdatechk.getDate(dateformat, ro_date);
            }   
            if(executequery.Tables[0].Rows[0].bill_status!=null)
            {
                document.getElementById('drpbillstatus').value = executequery.Tables[0].Rows[0].bill_status;
            }   
            if(executequery.Tables[0].Rows[0].ro_status!=null)
            {
                document.getElementById('drprostatus').value = executequery.Tables[0].Rows[0].ro_status;
            }    
            if(executequery.Tables[0].Rows[0].AgencyName!=null)
            {
                document.getElementById('txtagency').value = document.getElementById('hiddenagency').value=executequery.Tables[0].Rows[0].AgencyName;
            }    
                            
            var res2=Booking_Master_temp.bindsubagency(executequery.Tables[0].Rows[0].Agency_sub_code, document.getElementById('hiddencompcode').value);
            
            var dsbsa = res2.value;
            if(dsbsa==null)
            {
                alert(res2.error.description);
                return false;
            }
            document.getElementById('drpagscode').options.length=0;
            document.getElementById('drpagscode').options[0]=new Option("Select Agency","0");
            document.getElementById('drpagscode').options.length = 1; 
            for (var i = 0  ; i < dsbsa.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drpagscode').options[document.getElementById('drpagscode').options.length] = new Option(dsbsa.Tables[0].Rows[i].agency_name,dsbsa.Tables[0].Rows[i].Agency_Code);                
                document.getElementById('drpagscode').options.length;       
            }


            //////////////////////////////////////////////////////
             if(executequery.Tables[0].Rows[0].Client!=null)
            {
                if(executequery.Tables[0].Rows[0].client_code!=null)
                {
                    if(executequery.Tables[0].Rows[0].Client=="")
                        document.getElementById('txtclient').value = executequery.Tables[0].Rows[0].client_code;
                    else
                        document.getElementById('txtclient').value = executequery.Tables[0].Rows[0].Client + "(" +executequery.Tables[0].Rows[0].client_code+")";
                   
                            
                }    
                else    
                    document.getElementById('txtclient').value = executequery.Tables[0].Rows[0].Client;     //.ItemArray[14].ToString();
            }    
            else
            {
                document.getElementById('txtclient').value = "";
            }
//            if(executequery.Tables[0].Rows[0].Client!=null)
//            {
//                document.getElementById('txtclient').value = document.getElementById('hiddenclientname').value=executequery.Tables[0].Rows[0].Client;     //.ItemArray[14].ToString();
//            }    
            if(executequery.Tables[0].Rows[0].Agency_address!=null)
            {
                document.getElementById('txtagencyaddress').value = executequery.Tables[0].Rows[0].Agency_address;
            }    
            if(executequery.Tables[0].Rows[0].Client_address!=null)
            {
                document.getElementById('txtclientadd').value = executequery.Tables[0].Rows[0].Client_address;
            }    
            if(executequery.Tables[0].Rows[0].Agency_code!=null)
            {
                document.getElementById('hiddensubcode').value = document.getElementById('drpagscode').value = executequery.Tables[0].Rows[0].Agency_code;
            }    
            if(executequery.Tables[0].Rows[0].Dockit_no!=null)
            {
                document.getElementById('txtdockitno1').value = executequery.Tables[0].Rows[0].Dockit_no;
            }   
            if(executequery.Tables[0].Rows[0].execname!=null)
            { 
                document.getElementById('txtexecname').value = executequery.Tables[0].Rows[0].execname;
            }    
            if(executequery.Tables[0].Rows[0].Executive_zone!=null)
            {
                document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value = executequery.Tables[0].Rows[0].Executive_zone;
            }    
            if(executequery.Tables[0].Rows[0].product!=null)
            {
                document.getElementById('txtproduct').value = executequery.Tables[0].Rows[0].product;
            }    
            
            /////////////////////////////////////////////this is to bind the brand drop down
            res2=null;
            if(executequery.Tables[0].Rows[0].Product_code!=null)
            {
                res2=Booking_Master_temp.brandbind(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].Product_code);
                var dsbrand = res2.value;
                if(dsbrand==null)
                {
                    alert(res2.error.description);
                    return false;
                }
            
                document.getElementById('drpbrand').options.length=0;
                document.getElementById('drpbrand').options[0]=new Option("Select Brand","0");
                document.getElementById('drpbrand').options.length = 1; 
                for (var i = 0  ; i < dsbrand.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drpbrand').options[document.getElementById('drpbrand').options.length] = new Option(dsbrand.Tables[0].Rows[i].brand_name,dsbrand.Tables[0].Rows[i].brand_code);                
                    document.getElementById('drpbrand').options.length;       
                }                
           }
           
           if (executequery.Tables[0].Rows[0].Brand_code==null || executequery.Tables[0].Rows[0].Brand_code.toString() == "")
           {
                document.getElementById('drpbrand').options.length=0;
                document.getElementById('hiddenbrand').value = "";
           }
           else
           {
                if(executequery.Tables[0].Rows[0].Brand_code!=null)
                {
                    document.getElementById('hiddenbrand').value = document.getElementById('drpbrand').value = executequery.Tables[0].Rows[0].Brand_code.toString();
                }    
           }
           
           res2=Booking_Master_temp.varientbind(document.getElementById('hiddencompcode').value, document.getElementById('hiddenbrand').value);
           var dsvarient = res2.value;
           if(dsvarient==null)
           {
                alert(res2.error.description)
                return false;
           }
           document.getElementById('drpvarient').options.length=0;
           document.getElementById('drpvarient').options[0]=new Option("Select Varient","0");
           document.getElementById('drpvarient').options.length = 1; 
           for (var i = 0  ; i < dsvarient.Tables[0].Rows.length; ++i)
           {
                document.getElementById('drpvarient').options[document.getElementById('drpvarient').options.length] = new Option(dsvarient.Tables[0].Rows[i].varient_name,dsvarient.Tables[0].Rows[i].varient_code);                
                document.getElementById('drpvarient').options.length;    
                if(executequery.Tables[0].Rows[0].Brand_code!=null && executequery.Tables[0].Rows[0].Variant_code==document.getElementById('drpvarient').options[i].value)
                {
                    document.getElementById('hiddenvar.Value').value = document.getElementById('drpvarient').value = executequery.Tables[0].Rows[0].Variant_code.toString();
                }     
           } 
           if (executequery.Tables[0].Rows[0].Variant_code==null || executequery.Tables[0].Rows[0].Variant_code.toString() == "")
           {
                document.getElementById('drpvarient').options.length=0;
                document.getElementById('hiddenvar').value = "";
           }
          
            ////////////////////////////////////////////////////////////////////////////////
            if(executequery.Tables[0].Rows[0].Key_no!=null)
            {
                document.getElementById('txtkeyno').value = executequery.Tables[0].Rows[0].Key_no;
            }    
            if(executequery.Tables[0].Rows[0].Bill_remarks!=null)
            {
                document.getElementById('txtbillremark').value = executequery.Tables[0].Rows[0].Bill_remarks;
            }    
            if(executequery.Tables[0].Rows[0].Print_remark!=null)
            {
                document.getElementById('txtprintremark').value = executequery.Tables[0].Rows[0].Print_remark;
            }    
            if(executequery.Tables[0].Rows[0].Package_code!=null)
            {
                var listpck = executequery.Tables[0].Rows[0].Package_code;
                document.getElementById('hiddenpackage').value = listpck;
            //////////////////this is to bind the package grid on what the value is saved in the database

                res2=null;
                res2=Booking_Master_temp.bindpacforexe(document.getElementById('hiddencompcode').value, listpck);
                var dsexecut = res2.value;
                if(dsexecut==null)
                {
                    alert(res2.error.description);
                    return false;
                }
                document.getElementById('drppackagecopy').options.length=0;
                for (i = 0; i <= dsexecut.Tables[0].Rows.length - 1; i++)
                {
                    if (dsexecut.Tables[0].Rows[i].pck_code.toString() != "")
                    {
                        if (dsexecut.Tables[0].Rows[i].pck_code.toString() != "0")
                        {
                            var arrfor_uom = dsexecut.Tables[0].Rows[i].pck_code.toString().split('@');
                            var res3=Booking_Master_temp.getPackageInsert(arrfor_uom[0].toString(), document.getElementById('txtciobookid').value);
                            var dsinsert = res3.value;
                            if(dsinsert==null)
                            {
                                alert(res3.error.description);
                                return false;
                            }
                            var T=dsexecut.Tables[0].Rows[i].Package_Name + "(" + dsinsert.Tables[0].Rows[0].inserts + ")";
                            var V=dsexecut.Tables[0].Rows[i].pck_code + "(" + dsinsert.Tables[0].Rows[0].inserts + ")";
                             if(dsinsert.Tables[0].Rows[0].inserts!=null)
                            {
                            document.getElementById('drppackagecopy').options[document.getElementById('drppackagecopy').options.length] = new Option(T,V);                
                            document.getElementById('drppackagecopy').options.length;   
                            }
                        }
                    }
                }

            }
                
            if(executequery.Tables[0].Rows[0].No_of_insertion!=null)
            {
                document.getElementById('txtinsertion').value = executequery.Tables[0].Rows[0].No_of_insertion;
                document.getElementById('hiddeninsertion').value = executequery.Tables[0].Rows[0].No_of_insertion;
            }   
            
            var start_date = executequery.Tables[0].Rows[0].Insertion_date;
            if(start_date!=null)
            {
                document.getElementById('txtdummydate').value = start_date;//getdatechk.getDate(dateformat, start_date);
            }    
            if(executequery.Tables[0].Rows[0].Repeating_day!=null)
            {
                document.getElementById('txtrepeatingdate').value = executequery.Tables[0].Rows[0].Repeating_day;
            }    
            if(executequery.Tables[0].Rows[0].Booking_type!=null)
            {
                document.getElementById('drpbooktype').value = executequery.Tables[0].Rows[0].Booking_type;
            }   
            if(executequery.Tables[0].Rows[0].Ad_cat_code!=null)
            {
                document.getElementById('drpadcategory').value = executequery.Tables[0].Rows[0].Ad_cat_code;
            } 
//            if (executequery.Tables[0].Rows[0].Ad_sub_cat_code==null || executequery.Tables[0].Rows[0].Ad_sub_cat_code == "" || executequery.Tables[0].Rows[0].Ad_sub_cat_code=="0")
//            {
//                document.getElementById('drpadsubcategory').options.length=0;
//                document.getElementById('hiddenadsubcategory').value = "";
//            }
//            else
//            {
        if(executequery.Tables[0].Rows[0].Ad_cat_code!=null)
            {
                var ds_adsubcat=null;
                ds_adsubcat=Booking_Master_temp.getadsubcat(document.getElementById('hiddencompcode').value,executequery.Tables[0].Rows[0].Ad_cat_code,document.getElementById('hiddencattype').value);                
                var dacat = ds_adsubcat.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }
               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadsubcategory').options.length=0;
               document.getElementById('drpadsubcategory').options[0]=new Option("Select","0");
                for (var k = 0; k < dacat.Tables[0].Rows.length; k++)
                {
                     document.getElementById('drpadsubcategory').options[document.getElementById('drpadsubcategory').options.length] = new Option(dacat.Tables[0].Rows[k].Adv_Subcat_Name,dacat.Tables[0].Rows[k].Adv_Subcat_Code);                 
                     document.getElementById('drpadsubcategory').options.length; 
                }

          }   
            if(executequery.Tables[0].Rows[0].Ad_sub_cat_code!=null)
            {
                document.getElementById('hiddenadsubcategory').value=document.getElementById('drpadsubcategory').value = executequery.Tables[0].Rows[0].Ad_sub_cat_code;
            }
            if(executequery.Tables[0].Rows[0].Color_code!=null)
            {
                document.getElementById('drpcolor').value = executequery.Tables[0].Rows[0].Color_code;
            }   
            if(executequery.Tables[0].Rows[0].Uom_code!=null)
            {
                document.getElementById('drpuom').value = executequery.Tables[0].Rows[0].Uom_code;
            }
            if(executequery.Tables[0].Rows[0].Page_position_code!=null)
            {
                document.getElementById('drppageposition').value = executequery.Tables[0].Rows[0].Page_position_code;
            }   
            if (executequery.Tables[0].Rows[0].Page_type_code != null)
            {
                 document.getElementById('drppagetype').value = executequery.Tables[0].Rows[0].Page_type_code;
            }
            if (executequery.Tables[0].Rows[0].Page_no != null)
            {
                 document.getElementById('txtpageno').value = executequery.Tables[0].Rows[0].Page_no;
            }
            
            res3=null;
            res3 = Booking_Master_temp.gettheuom_desc(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].Uom_code);  
            var ds_uom_=res3.value;
            if(ds_uom_==null)
            {
                alert(res3.error.description);
                return false;
            }
            if(ds_uom_.Tables[0].Rows.length>0)
            {
                document.getElementById('hiddenuomdesc').value = ds_uom_.Tables[0].Rows[0].uom_desc;   
            }
           
            if(executequery.Tables[0].Rows[0].Ad_size_height!=null)
            {
                document.getElementById('txtadsize1').value = executequery.Tables[0].Rows[0].Ad_size_height;
            }   
            if(executequery.Tables[0].Rows[0].Ad_size_width!=null)
            {
                document.getElementById('txtadsize2').value = executequery.Tables[0].Rows[0].Ad_size_width;
            }    
            ////this is to bind the ratecode drpdown
            res3=null
            if(executequery.Tables[0].Rows[0].Ad_cat_code!=null)
            {
                res3=Booking_Master_temp.ratebind(executequery.Tables[0].Rows[0].Ad_cat_code, document.getElementById('hiddencompcode').value);
                var dx = res3.value;
                if(dx==null)
                {   
                    alert(res3.error.description);
                    return false;
                }
                document.getElementById('txtratecode').options.length=0;
                document.getElementById('txtratecode').options[0]=new Option("-Select Rate Code-","0");
                document.getElementById('txtratecode').options.length = 1;                 
                for (var i = 0  ; i < dx.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('txtratecode').options[document.getElementById('txtratecode').options.length] = new Option(dx.Tables[0].Rows[i].rate_mast_code,dx.Tables[0].Rows[i].rate_mast_code);                
                    document.getElementById('txtratecode').options.length;       
                }                
           }
           if(executequery.Tables[0].Rows[0].Rate_code!=null)
           {
                document.getElementById('txtratecode').value = executequery.Tables[0].Rows[0].Rate_code;
           }    
           if(executequery.Tables[0].Rows[0].Scheme_type_code!=null)
           {
               document.getElementById('drpscheme').value = executequery.Tables[0].Rows[0].Scheme_type_code;
           }   
           if(executequery.Tables[0].Rows[0].Scheme_type_code!=null)
           { 
               document.getElementById('hiddenscheme').value = executequery.Tables[0].Rows[0].Scheme_type_code;
           }    
     
           if(executequery.Tables[0].Rows[0].Currency_code!=null)
           {
                document.getElementById('drpcurrency').value = executequery.Tables[0].Rows[0].Currency_code;
           }    
           if(executequery.Tables[0].Rows[0].Agrred_rate!=null)
           {
                document.getElementById('txtagreedrate').value = executequery.Tables[0].Rows[0].Agrred_rate;
           }    
           if(executequery.Tables[0].Rows[0].Agreed_amount!=null)
           {
                document.getElementById('txtagreedamt').value = executequery.Tables[0].Rows[0].Agreed_amount;
           }    
    
           if(executequery.Tables[0].Rows[0].Special_charges!=null)
           {
               document.getElementById('txtextracharges').value = executequery.Tables[0].Rows[0].Special_charges;
           }   
            if(executequery.Tables[0].Rows[0].Agency_status!=null)
            {
                document.getElementById('hiddenstatus').value = document.getElementById('txtagencystatus').value = executequery.Tables[0].Rows[0].Agency_status;
            }    
            if(executequery.Tables[0].Rows[0].Agency_type!=null)
            {
                document.getElementById('txtagencytype').value = executequery.Tables[0].Rows[0].Agency_type;
            }    
            
            res3=null;
            if(executequery.Tables[0].Rows[0].Agency_sub_code!=null)
            {
                res3=Booking_Master_temp.getstatuspaymode(executequery.Tables[0].Rows[0].Agency_sub_code, executequery.Tables[0].Rows[0].Agency_code, document.getElementById('hiddencompcode').value, document.getElementById('txtdatetime').value,document.getElementById('hiddendateformat').value,"DI0");
                var dch = res3.value;
                if(dch==null)
                {
                    alert(res3.error.description);
                    return false;
                }

                document.getElementById('txtagencypaymode').options.length=0;
                if (dch.Tables[5].Rows.length > 0)
                {
                    for (var i = 0; i < dch.Tables[5].Rows.length; i++)
                    {
                        document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);                
                        document.getElementById('txtagencypaymode').options.length;
                    }
                }
           } 
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            if(executequery.Tables[0].Rows[0].Agency_pay!=null)
            {
                document.getElementById('hiddenpay').value = document.getElementById('txtagencypaymode').value = executequery.Tables[0].Rows[0].Agency_pay;
                 if(document.getElementById('txtagencypaymode').selectedIndex!=-1)
                document.getElementById('hiddenpaymode').value=document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').selectedIndex].text;
            }    
            if(executequery.Tables[0].Rows[0].Agency_credit!=null)
            {
                document.getElementById('txtcreditperiod').value = executequery.Tables[0].Rows[0].Agency_credit;
            }    
            if(executequery.Tables[0].Rows[0].Total_area!=null)
            {
                document.getElementById('txttotalarea').value = executequery.Tables[0].Rows[0].Total_area;
            }    
            if(executequery.Tables[0].Rows[0].Card_rate!=null)
            {
                document.getElementById('txtcardrate').value = executequery.Tables[0].Rows[0].Card_rate;
            }    
            if(executequery.Tables[0].Rows[0].Card_amount!=null)
            {
                document.getElementById('txtcardamt').value = executequery.Tables[0].Rows[0].Card_amount;
            }    
            if(executequery.Tables[0].Rows[0].Discount!=null)
            {
                document.getElementById('txtdiscount').value = executequery.Tables[0].Rows[0].Discount;
            }    
            if(executequery.Tables[0].Rows[0].Discount_per!=null)
            {
                document.getElementById('txtdiscpre').value = executequery.Tables[0].Rows[0].Discount_per;
            }    
            if(executequery.Tables[0].Rows[0].Bill_cycle!=null)
            {
                document.getElementById('drpbillcycle').value = executequery.Tables[0].Rows[0].Bill_cycle;
            }    
            if(executequery.Tables[0].Rows[0].Revenue_center!=null)
            {
                document.getElementById('drprevenue').value = executequery.Tables[0].Rows[0].Revenue_center;
            }    

            ////this is to bind the bill pay mode
            document.getElementById('drppaymenttype').options.length=0;
            if (dch.Tables[5].Rows.length > 0)
            {
                for (var i = 0;  i< dch.Tables[5].Rows.length; i++)
                {
                   document.getElementById('drppaymenttype').options[document.getElementById('drppaymenttype').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);                
                   document.getElementById('drppaymenttype').options.length; 
                }
            }
            if(executequery.Tables[0].Rows[0].Bill_pay!=null)
            {    
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value = executequery.Tables[0].Rows[0].Bill_pay;
            } 
            if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0" ||  document.getElementById('drppaymenttype').value=='PO0')  //CR0 is Credit Card code and DD0 is demand draft
            {          
                document.getElementById('tdchqno').style.display="";
                document.getElementById('tdchqdate').style.display="";
                document.getElementById('tdchqamt').style.display="";
                document.getElementById('tdbankname').style.display="";
                 document.getElementById('tdourbank').style.display="";
                
                
                document.getElementById('tdtextchqno').style.display="";            
                document.getElementById('tdtextchqdate').style.display="";
                document.getElementById('tdtextchqamt').style.display="";
                document.getElementById('tdtextbankname').style.display="";
                 document.getElementById('tdtextourbank').style.display="";
            }
            if(document.getElementById('drppaymenttype').value=="CR0")  //CR0 is Credit Card code
            {          
                document.getElementById('tdcarname').style.display="";
                document.getElementById('tdtxtcarname').style.display="";
                document.getElementById('tdtype').style.display="";
                document.getElementById('tddrptyp').style.display="";
                document.getElementById('tdexdat').style.display="";
                
                document.getElementById('tdtxtexdat').style.display="";
                document.getElementById('tdcardno').style.display="";
                document.getElementById('tdtxtcarno').style.display="";
//                document.getElementById('txtcardname').value=executequery.Tables[0].Rows[rownumEx].Card_name;
//                document.getElementById('drptype').value=executequery.Tables[0].Rows[rownumEx].Card_type;
//                document.getElementById('txtcardno').value=executequery.Tables[0].Rows[rownumEx].Card_number;  
//                document.getElementById('drpmonth').value=executequery.Tables[0].Rows[rownumEx].Card_month;  
//                document.getElementById('drpyear').value=executequery.Tables[0].Rows[rownumEx].Card_year;
                
                document.getElementById('tdchqno').style.display="none";
                document.getElementById('tdchqdate').style.display="none";
                document.getElementById('tdchqamt').style.display="none";
                document.getElementById('tdbankname').style.display="none";
                 document.getElementById('tdourbank').style.display="none";
                
                document.getElementById('tdtextchqno').style.display="none";            
                document.getElementById('tdtextchqdate').style.display="none";
                document.getElementById('tdtextchqamt').style.display="none";
                document.getElementById('tdtextbankname').style.display="none";             
                  document.getElementById('tdtextourbank').style.display="";
               
            }   
            if(executequery.Tables[0].Rows[0].Bill_height!=null)
            {
                document.getElementById('txtbillheight').value = executequery.Tables[0].Rows[0].Bill_height;
            }    
            if(executequery.Tables[0].Rows[0].Bill_width!=null)
            {
                document.getElementById('txtbillwidth').value = executequery.Tables[0].Rows[0].Bill_width;
            }    
            //////////////this is to bind the bill to 
            res3=null;
            if(executequery.Tables[0].Rows[0].Agency_sub_code!=null)
            {
                res3=Booking_Master_temp.getbillval(executequery.Tables[0].Rows[0].Agency_sub_code, document.getElementById('hiddencompcode').value);
                var dbt = res3.value;
                if(dbt==null)
                {
                    alert(res3.error.description);
                    return false;
                }          
                
                ////////////////////////////////////////////////////
                document.getElementById('drpbillto').options.length=0;
                var client_val=document.getElementById('txtclient').value;
                 var client_name=document.getElementById('txtclient').value;
                 if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                {
                    client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                    client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                 }  
                document.getElementById('drpbillto').options[0] = new Option(client_name,client_val);                
                for (var k = 0; k < dbt.Tables[0].Rows.length; k++)
                {
                    if(dbt.Tables[0].Rows[k].bill_to=="")
                    document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name,dbt.Tables[0].Rows[k].SUB_agency_code);                
                    else
                    document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name,dbt.Tables[0].Rows[k].bill_to);                
                    document.getElementById('drpbillto').options.length; 
                }
            }
            if(executequery.Tables[0].Rows[rownumEx].Bill_to!=null)
            {
                document.getElementById('hiddenbillto').value = executequery.Tables[0].Rows[rownumEx].Bill_to;
            }    
            if(executequery.Tables[0].Rows[0].Bill_to!=null)
            {
                document.getElementById('drpbillto').value = executequery.Tables[0].Rows[0].Bill_to;
            }    
            if(executequery.Tables[0].Rows[0].Invoices!=null)
            {
                document.getElementById('txtinvoice').value = executequery.Tables[0].Rows[0].Invoices;
            }    
            if(executequery.Tables[0].Rows[0].Vts!=null)
            {
                document.getElementById('txtvts').value = executequery.Tables[0].Rows[0].Vts;
            }    
            if(executequery.Tables[0].Rows[0].Bill_add!=null)
            {
                document.getElementById('txtbilladdress').value = executequery.Tables[0].Rows[0].Bill_add;
            }    
            if(executequery.Tables[0].Rows[0].Trade_disc!=null)
            {
                document.getElementById('txttradedisc').value = executequery.Tables[0].Rows[0].Trade_disc;
                document.getElementById('hiddentradedisc').value= executequery.Tables[0].Rows[0].Trade_disc;
            }
            if(executequery.Tables[0].Rows[0].Agency_out!=null)
            {
                document.getElementById('txtagencyoutstand').value = executequery.Tables[0].Rows[0].Agency_out;
            }  
            //recorrect it
            if(executequery.Tables[0].Rows[0].Campaign!=null)  
                document.getElementById('txtcamp').value= executequery.Tables[0].Rows[0].Campaign;
            if(executequery.Tables[0].Rows[0].Page_prem!=null)
                document.getElementById('drppageprem').value = executequery.Tables[0].Rows[0].Page_prem;
            if(executequery.Tables[0].Rows[0].Prem_per!=null)
            {
                document.getElementById('txtpremper').value = executequery.Tables[0].Rows[0].Prem_per;
            }    
            
            //***
            
            if(executequery.Tables[0].Rows[0].Page_amount!=null)
            {
                document.getElementById('txtpageamt').value = executequery.Tables[0].Rows[0].Page_amount;
            }   
            if(executequery.Tables[0].Rows[0].Gross_amount!=null)
            {
                document.getElementById('txtgrossamt').value = executequery.Tables[0].Rows[0].Gross_amount;
            }    

            //Inserting in hidden field to compare new and  Previous amount 
            if(executequery.Tables[0].Rows[0].Gross_amount!=null)
            {
                document.getElementById('hiddenprevamt').value = executequery.Tables[0].Rows[0].Gross_amount;
            }   

            if(executequery.Tables[0].Rows[0].Bill_amount!=null)
            {
                document.getElementById('txtbillamt').value = executequery.Tables[0].Rows[0].Bill_amount;
            }    
            if(executequery.Tables[0].Rows[0].Box_code!=null)
            {
                document.getElementById('drpboxcode').value = executequery.Tables[0].Rows[0].Box_code;
            }   
            if(executequery.Tables[0].Rows[0].Box_no!=null)
            {
                document.getElementById('txtboxno').value = executequery.Tables[0].Rows[0].Box_no;
            }    
            if (executequery.Tables[0].Rows[0].Box_agency.toString() == "1")
            {
                document.getElementById('chkage').checked = true;
            }
            else
            {
                document.getElementById('chkage').checked = false;
            }
            if (executequery.Tables[0].Rows[0].Box_client.toString() == "1")
            {
                document.getElementById('chkclie').checked = true;
            }
            else
            {
                document.getElementById('chkclie').checked = false;
            }
            if(executequery.Tables[0].Rows[0].Box_address!=null)
            {
                document.getElementById('txtboxaddress').value = executequery.Tables[0].Rows[0].Box_address;
            }    
            if (executequery.Tables[0].Rows[0].Tfn == "1")
            {
                document.getElementById('chktfn').value = true;
            }
            else
            {
                document.getElementById('chktfn').value= false;
            }
            if(executequery.Tables[0].Rows[0].Ad_size_column!=null)
            {
                document.getElementById('txtcolum').value = executequery.Tables[0].Rows[0].Ad_size_column;
            } 
            //recorrect it
            if(executequery.Tables[0].Rows[0].Special_disc_per!=null)
            {
                document.getElementById('txtspediscper').value = executequery.Tables[0].Rows[0].Special_disc_per;
            }
            if(executequery.Tables[0].Rows[0].Space_disc_per!=null)
            {    
                document.getElementById('txtspadiscper').value = executequery.Tables[0].Rows[0].Space_disc_per;
            }    
            //***
                 if(executequery.Tables[0].Rows[0].Special_discount!=null)
            {
                document.getElementById('txtspedisc').value = executequery.Tables[0].Rows[0].Special_discount;
            }
            if(executequery.Tables[0].Rows[0].Space_discount!=null)
            {
                document.getElementById('txtspacedisc').value = executequery.Tables[0].Rows[0].Space_discount;
            }
            if(executequery.Tables[0].Rows[0].Paid_ins!=null)
            {          
                document.getElementById('txtpaid').value = executequery.Tables[0].Rows[0].Paid_ins;
            }    
            if(executequery.Tables[0].Rows[0].Contract_rate!=null)
            {
                document.getElementById('txtdealrate').value = executequery.Tables[0].Rows[0].Contract_rate;
            }    
            if(executequery.Tables[0].Rows[0].Deviation!=null)
            {
                document.getElementById('txtdeviation').value = executequery.Tables[0].Rows[0].Deviation;
            }    
            if(executequery.Tables[0].Rows[0].Contract_name!=null)
            {          
                document.getElementById('txtcontractname').value = executequery.Tables[0].Rows[0].Contract_name;
            }    
            if(executequery.Tables[0].Rows[0].Contract_type!=null)
            {
                document.getElementById('txtcontracttype').value = executequery.Tables[0].Rows[0].Contract_type;
            }
            if (executequery.Tables[0].Rows[0].Variant_code == "")
            {
                document.getElementById('drpvarient').options.length=0;
            } 
            document.getElementById('hiddenvar').value=document.getElementById('drpvarient').value = executequery.Tables[0].Rows[0].Variant_code;   
            
            if(executequery.Tables[0].Rows[0].Card_name!=null)
            {
                document.getElementById('txtcardname').value = executequery.Tables[0].Rows[0].Card_name;
             }   
             if(executequery.Tables[0].Rows[0].Card_type!=null)
             {
                document.getElementById('drptype').value = executequery.Tables[0].Rows[0].Card_type;
             }   
             if(executequery.Tables[0].Rows[0].Card_month!=null)
             {
                document.getElementById('drpmonth').value = executequery.Tables[0].Rows[0].Card_month;
             }   
             if(executequery.Tables[0].Rows[0].Card_year!=null)
             {
                document.getElementById('drpyear').value = executequery.Tables[0].Rows[0].Card_year;
             }   
             if(executequery.Tables[0].Rows[0].Card_number!=null)
             {
                document.getElementById('txtcardno').value = executequery.Tables[0].Rows[0].Card_number;
             }   
            if(executequery.Tables[0].Rows[0].Receipt_no!=null)
            { 
                document.getElementById('hiddenreceiptno').value =  document.getElementById('txtreceipt').value = executequery.Tables[0].Rows[0].Receipt_no;
                //get check info
               if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0"   || document.getElementById('drppaymenttype').value=='PO0')            
                {
                    var ds_chq=Booking_Master_temp.ChequeInfo(document.getElementById('hiddencompcode').value,document.getElementById('txtreceipt').value);
                    if(ds_chq.value!=null)
                    {
                        if(ds_chq.value.Tables[0].Rows.length>0)
                        {
                            if(ds_chq.value.Tables[0].Rows[0].chno!=null)
                                document.getElementById('ttextchqno').value=ds_chq.value.Tables[0].Rows[0].chno;  
                            else
                                document.getElementById('ttextchqno').value="";    
                            var cDate="";
                            if(ds_chq.value.Tables[0].Rows[0].chdt!=null)
                            {
                                    if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
                                    {
                                        cDate=ds_chq.value.Tables[0].Rows[0].chdt;  
                                    }          
                                    else if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                                    {
                                        var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                                        cDate=txt[1] + "/" + txt[0] + "/" + txt[2];
                                    }
                                      else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                                    {
                                        var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                                        cDate=txt[2] + "/" + txt[1] + "/" + txt[0];
                                    }
                            }        
                            document.getElementById('ttextchqdate').value=cDate; 
                            if(ds_chq.value.Tables[0].Rows[0].amount!=null) 
                                document.getElementById('ttextchqamt').value=ds_chq.value.Tables[0].Rows[0].amount;  
                            else
                                document.getElementById('ttextchqamt').value="";    
                            if(document.getElementById('ttextchqamt').value.indexOf("-")>=0)
                                document.getElementById('ttextchqamt').value=document.getElementById('ttextchqamt').value.replace("-","");
                            if(ds_chq.value.Tables[0].Rows[0].bank!=null)    
                                document.getElementById('ttextbankname').value=ds_chq.value.Tables[0].Rows[0].bank;                          
                            else
                                document.getElementById('ttextbankname').value="";   
                                
                                 if(ds_chq.value.Tables[0].Rows[0].cashbank!=null)    
                                document.getElementById('drpourbank').value=ds_chq.value.Tables[0].Rows[0].cashbank;                          
                            else
                                document.getElementById('drpourbank').value="0";  
                                 
                        }
                    }
                }
               else if(document.getElementById('drppaymenttype').value=="CR0")
               {
                    var ds_chq=Booking_Master_temp.ChequeInfo(document.getElementById('hiddencompcode').value,document.getElementById('txtreceipt').value);
                    if(ds_chq.value!=null)
                    {
                        if(ds_chq.value.Tables[0].Rows.length>0)
                        {
                            if(ds_chq.value.Tables[0].Rows[0].bank!=null)
                                document.getElementById('txtcardname').value=ds_chq.value.Tables[0].Rows[0].bank;
                            else
                                document.getElementById('txtcardname').value="";    
                            if(ds_chq.value.Tables[0].Rows[0].remark!=null)    
                                document.getElementById('drptype').value=ds_chq.value.Tables[0].Rows[0].remark;
                            else
                                document.getElementById('drptype').value="";    
                            if(ds_chq.value.Tables[0].Rows[0].chno!=null)    
                                document.getElementById('txtcardno').value=ds_chq.value.Tables[0].Rows[0].chno;                          
                            else
                                document.getElementById('txtcardno').value="";  
                            if(ds_chq.value.Tables[0].Rows[0].chdt!=null)
                            {      
                                var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                                document.getElementById('drpmonth').value=parseInt(txt[1],10);
                                document.getElementById('drpyear').value=txt[2];
                           } 
                        }
                     }   
               }
                //*********************
            }    
            if(executequery.Tables[0].Rows[0].Material_status!=null)
            {
                document.getElementById('drpmatsta').value = executequery.Tables[0].Rows[0].Material_status;
            }    

            

            if (executequery.Tables[0].Rows[0].Ad_sub_cat_code==null) // || executequery.Tables[0].Rows[0].Ad_Subcat3.toString() == "")
            {
                document.getElementById('drpadcat3').options.length=0;
                document.getElementById('hiddenadscat3').value = "";
            }
            else
            {
                res3=null;
                res3=Booking_Master_temp.getvalfromadcat3(executequery.Tables[0].Rows[0].Ad_sub_cat_code,document.getElementById('hiddencompcode').value,"0");
                var dacat = res3.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }
               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadcat3').options.length=0;
               document.getElementById('drpadcat3').options[0]=new Option("Select","0");
                for (var k = 0; k < dacat.Tables[0].Rows.length; k++)
                {
                     document.getElementById('drpadcat3').options[document.getElementById('drpadcat3').options.length] = new Option(dacat.Tables[0].Rows[k].catname,dacat.Tables[0].Rows[k].catcode);                    
                     document.getElementById('drpadcat3').options.length; 
                }

            }
           
            if(executequery.Tables[0].Rows[0].Ad_Subcat3!=null)
            {
                document.getElementById('hiddenadscat3').value = document.getElementById('drpadcat3').value = executequery.Tables[0].Rows[0].Ad_Subcat3;
            }    
           
            ////////////////////this is to bind the adcat4 drp down
            if (executequery.Tables[0].Rows[0].Ad_Subcat3 == null || executequery.Tables[0].Rows[0].Ad_Subcat3.toString() == "")
            {
                document.getElementById('drpadcat4').options.length=0;
                document.getElementById('hiddenadscat4').value = "";
            }
            else
            {
                ////////////when 1 than bind the adscat4 drp down
                res3=null;
                res3=Booking_Master_temp.getvalfromadcat3(executequery.Tables[0].Rows[0].Ad_Subcat3,document.getElementById('hiddencompcode').value,"1");
                var dacat = res3.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }

               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadcat4').options.length=0;
               document.getElementById('drpadcat4').options[0]=new Option("Select","0");
               for (var k = 0; k < dacat.Tables[0].Rows.length; k++)
               {
                   document.getElementById('drpadcat4').options[document.getElementById('drpadcat4').options.length] = new Option(dacat.Tables[0].Rows[k].Cat_Name,dacat.Tables[0].Rows[k].Cat_Code);                    
                   document.getElementById('drpadcat4').options.length; 
               }
            }
            if(executequery.Tables[0].Rows[0].Ad_Subcat4!=null)
            {
                document.getElementById('hiddenadscat4').value = document.getElementById('drpadcat4').value = executequery.Tables[0].Rows[0].Ad_Subcat4;
            }    
          
            ///bind adcat5 drpdown
            if (executequery.Tables[0].Rows[0].Ad_Subcat4==null || executequery.Tables[0].Rows[0].Ad_Subcat4.toString() == "")
            {
                document.getElementById('drpadcat5').options.length=0;
                document.getElementById('hiddenadscat5').value = "";
            }
            else
            {
                ////////////when 1 than bind the adscat4 drp down
               res3=null;
               res3=Booking_Master_temp.getvalfromadcat3(executequery.Tables[0].Rows[0].Ad_Subcat4,document.getElementById('hiddencompcode').value,"2");
               var dacat = res3.value;
               if(dacat==null)
               {
                   alert(dacat.error.description);
                   return false;
               }

               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadcat5').options.length=0;
               document.getElementById('drpadcat5').options[0]=new Option("Select","0");
               for (var k = 0; k < dacat.Tables[0].Rows.length; k++)
               {
                   document.getElementById('drpadcat5').options[document.getElementById('drpadcat5').options.length] = new Option(dacat.Tables[0].Rows[k].Cat_Name,dacat.Tables[0].Rows[k].Cat_Code);                    
                   document.getElementById('drpadcat5').options.length; 
               }
            }
            if(executequery.Tables[0].Rows[0].Ad_subcat5!=null)
            {
                document.getElementById('hiddenadscat5').value = document.getElementById('drpadcat5').value = executequery.Tables[0].Rows[0].Ad_subcat5;
            }    


            //////bind the bg color drp down 
////            if(executequery.Tables[0].Rows[0].Bg_color!=null)
////            {
////                document.getElementById('drpbgcolor').value = executequery.Tables[0].Rows[0].Bg_color;
////            }    
////            if(executequery.Tables[0].Rows[0].Bullet_code!=null)
////            {
////                document.getElementById('drpbullet').value = executequery.Tables[0].Rows[0].Bullet_code;
////            }    
////            if(executequery.Tables[0].Rows[0].Bullet_premium!=null)
////            {
////                document.getElementById('txtbullprem').value = executequery.Tables[0].Rows[0].Bullet_premium;
////            }   
           
            if(executequery.Tables[0].Rows[0].RETAINER1!=null)
            {
                document.getElementById('drpretainer').value = executequery.Tables[0].Rows[0].RETAINER1;
            }    
            if(executequery.Tables[0].Rows[0].ADD_AGENCY_COMM!=null)
            {
                if(document.getElementById('txtaddagencycommrate')!=null)
                {
                    document.getElementById('txtaddagencycommrate').value = executequery.Tables[0].Rows[0].ADD_AGENCY_COMM;
                }
             }   
           
        }

        else
        {
            alert("Your Search Produces No Result");
            clearClick();
            return false;
        }

       // }
        updateStatus();
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;        

        if (executequery.Tables[0].Rows.length - 1 == 0)
        {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
        }
        ////// we have called a javascript function to show the grid during execution mode
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "cc", "bindpackage()", true);
        document.getElementById('btndel').disabled=true;
       
        showcardinfo(executequery.Tables[0].Rows[0].Bill_pay);
        showgridexecute();
         document.getElementById('txtRetainercomm').disabled = true;
            document.getElementById('txtaddagencycommrateamt').disabled = true;
              document.getElementById('txtaddagencycommrate').disabled = true;
               document.getElementById('drpadstype').disabled = true;
//        if (document.getElementById('hiddenaudit').value != "")
//        {
//            modifyClick();
//        }        
     
        return false;
    }
    
//    function updateStatus()
//    {
//        chkstatus(document.getElementById('hiddenbuttonidcheck').value);
//        if (document.getElementById('hiddenbuttonidcheck').value == 2 || document.getElementById('hiddenbuttonidcheck').value == 3)
//        {
//            document.getElementById('btnQuery').disabled = false;
//            document.getElementById('btnExecute').disabled = true;
//            document.getElementById('btnSave').disabled = true;
//            document.getElementById('btnModify').disabled = false;
//            document.getElementById('btnfirst').disabled = false;
//            document.getElementById('btnnext').disabled = false;
//            document.getElementById('btnprevious').disabled = false;
//            document.getElementById('btnlast').disabled = false;
//            document.getElementById('btnDelete').disabled = true;
//        }
//        if (document.getElementById('hiddenbuttonidcheck').value == 4)
//        {
//            document.getElementById('btnDelete').disabled = false;
//            document.getElementById('btnExecute').disabled = true;
//            document.getElementById('btnSave').disabled = true;
//            document.getElementById('btnQuery').disabled = false;
//            document.getElementById('btnModify').disabled = true;
//            document.getElementById('btnfirst').disabled = false;
//            document.getElementById('btnnext').disabled = false;
//            document.getElementById('btnprevious').disabled = false;
//            document.getElementById('btnlast').disabled = false;

//        }
//        if (document.getElementById('hiddenbuttonidcheck').value == 5)
//        {
//            document.getElementById('btnDelete').disabled = false;
//            document.getElementById('btnExecute').disabled = true;
//            document.getElementById('btnSave').disabled = true;
//            document.getElementById('btnQuery').disabled = false;
//            document.getElementById('btnModify').disabled = true;
//            document.getElementById('btnfirst').disabled = false;
//            document.getElementById('btnnext').disabled = false;
//            document.getElementById('btnprevious').disabled = false;
//            document.getElementById('btnlast').disabled = false;

//        }
//        if (document.getElementById('hiddenbuttonidcheck').value == 6 || document.getElementById('hiddenbuttonidcheck').value == 7 || document.getElementById('hiddenbuttonidcheck').value == 15)
//        {
//            document.getElementById('btnDelete').disabled = false;
//            document.getElementById('btnExecute').disabled = true;
//            document.getElementById('btnSave').disabled = true;
//            document.getElementById('btnQuery').disabled = false;
//            document.getElementById('btnModify').disabled = false;
//            document.getElementById('btnfirst').disabled = false;
//            document.getElementById('btnnext').disabled = false;
//            document.getElementById('btnprevious').disabled = false;
//            document.getElementById('btnlast').disabled = false;

//        }
//      
//    }
    
    
    function modifyClick()
    {
        document.getElementById('hiddensavemod').value = "01";
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton2').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton5').disabled = false;
        document.getElementById('LinkButton6').disabled = false;
        document.getElementById('LinkButton7').disabled = false;
        if(document.getElementById('txtaddagencycommrate')!=null)
        document.getElementById('txtaddagencycommrate').disabled = false;
        document.getElementById('hiddenmodifyinsert').value = document.getElementById('txtinsertion').value;

        /////if in the insertion grid record insertion status is publish or hold or cancel than the main form except the 
        ////insert grid record cannot modify
        res=null;
        res=Booking_Master_temp.showgridforexe(document.getElementById('txtciobookid').value,document.getElementById('hiddencompcode').value);
        var dex=res.value;
        if(dex==null)
        {
            alert(res.error.description);
            return false;
        }        

        for (var j = 0; j <= dex.Tables[0].Rows.length - 1; j++)
        {
            if (dex.Tables[0].Rows[j].Insert_status == "publish")
            {
                insertstatus = "2";
                break;
            }
            else if (dex.Tables[0].Rows[j].Insert_status == "billed")
            {
                insertstatus = "1";
              //  document.getElementById('hiddensavemod').value = "1";
                break;
            }
            else
            {
                insertstatus = "0";
            }
        }
		 insertstatus = "0";
        if (insertstatus == "2")
        {
            document.getElementById('btndeal').disabled = true;
            document.getElementById('btnshgrid').disabled = true;
           
            document.getElementById('drpbooktype').disabled = true;
            document.getElementById('txtciobookid').disabled = true;
            
            document.getElementById('txtrono').disabled = false;
            document.getElementById('txtrodate').disabled = false;
            document.getElementById('txtcaption').disabled = false;
            document.getElementById('drpbillstatus').disabled = false;
            document.getElementById('drprostatus').disabled = false;
            document.getElementById('txtagency').disabled = false;
            document.getElementById('txtclient').disabled = false;
            document.getElementById('txtagencypaymode').disabled = false;
            
            document.getElementById('txtclientadd').disabled = false;
            document.getElementById('drpagscode').disabled = false;
            document.getElementById('txtdockitno1').disabled = true;
            document.getElementById('txtexecname').disabled = false;
            document.getElementById('txtexeczone').disabled = false;
            document.getElementById('txtproduct').disabled = false;
            document.getElementById('drpbrand').disabled = false;
            document.getElementById('txtkeyno').disabled = false;
            document.getElementById('txtbillremark').disabled = false;
            document.getElementById('txtprintremark').disabled = false;
            document.getElementById('txtpageno').disabled=false;
            document.getElementById('drppagetype').disabled=false;
            document.getElementById('drpvarient').disabled = false;
            document.getElementById('drppackage').disabled = true;
            document.getElementById('txtinsertion').disabled = true;
            document.getElementById('txtdummydate').disabled = true;
            document.getElementById('txtrepeatingdate').disabled = true;
            document.getElementById('drpbooktype').disabled = true;
            document.getElementById('drpadcategory').disabled = true;
            document.getElementById('drpadsubcategory').disabled = false;
            document.getElementById('drpadcat3').disabled = true;
            document.getElementById('drpadcat4').disabled = true;
            document.getElementById('drpadcat5').disabled = true;
            document.getElementById('drpcolor').disabled = true;
            document.getElementById('drpuom').disabled = true;
            document.getElementById('drppageposition').disabled = true;
         
            document.getElementById('txtpageno').disabled = false;
            document.getElementById('drpadstype').disabled = true;
            document.getElementById('drppagetype').disabled = false;
            document.getElementById('txtratecode').disabled = true;
            document.getElementById('drpscheme').disabled = true;
          //  drpschemepck.Enabled = false;
            document.getElementById('drpcurrency').disabled = true;
            document.getElementById('txtagreedrate').disabled = true;
            document.getElementById('txtagreedamt').disabled = true;
            document.getElementById('txtspedisc').disabled = true;
            document.getElementById('txtspacedisc').disabled = true;
            document.getElementById('txtspediscper').disabled = true;
            document.getElementById('txtspadiscper').disabled = true;
        
            document.getElementById('txtextracharges').disabled = true;
            document.getElementById('txtdatetime').disabled = true;
            document.getElementById('txtrepeatingdate').disabled = true;

            document.getElementById('drppageprem').disabled = true;
            document.getElementById('drpbillcycle').disabled = true;
            document.getElementById('drprevenue').disabled = true;
            //drpbilltype.Enabled = true;
            document.getElementById('drpbillstatus').disabled = true;
            //drpbillcurrency.Enabled = true;
            document.getElementById('drppaymenttype').disabled = true;
            document.getElementById('txtinvoice').disabled = true;
            document.getElementById('txtvts').disabled = true;
            document.getElementById('txtbillwidth').disabled = true;
            document.getElementById('txtbillheight').disabled = true;
            document.getElementById('drpbillto').disabled = true;
            document.getElementById('txttradedisc').disabled = false;
            document.getElementById('txtagencyoutstand').disabled = true;
            document.getElementById('txtcardrate').disabled = true;
            document.getElementById('txtcardamt').disabled = true;
            document.getElementById('txtdiscount').disabled = true;
            document.getElementById('txtdiscpre').disabled = true;
            document.getElementById('txtadsize2').disabled = true;
            document.getElementById('txtadsize1').disabled = true;
            document.getElementById('txttotalarea').disabled = true;
            document.getElementById('txtbilladdress').disabled = true;
            
            document.getElementById('drpboxcode').disabled = true;
            //txtboxno.Enabled = true;
            document.getElementById('txtboxaddress').disabled = true;
            document.getElementById('txtcamp').disabled = true;
            document.getElementById('txtbillamt').disabled = true;
            
            document.getElementById('txtgrossamt').disabled = true;
            document.getElementById('drpboxcode').disabled = true;
            document.getElementById('chkage').disabled = true;
            document.getElementById('chkclie').disabled = true;
            document.getElementById('chktfn').disabled = true;
            
            document.getElementById('txtboxaddress').disabled = true;
            document.getElementById('txtinsertion').disabled = true;
            document.getElementById('txtcolum').disabled = true;
            document.getElementById('drpmatsta').disabled = true;            
            ///////////////////////
            document.getElementById('txtcontractname').disabled = true;
            document.getElementById('txtcontracttype').disabled = true;
            document.getElementById('txtcardname').disabled = true;
            document.getElementById('drptype').disabled = true;
            document.getElementById('drpmonth').disabled = false;
            document.getElementById('drpyear').disabled = true;
            document.getElementById('txtcardno').disabled = true;
            document.getElementById('btnshgrid').disabled = true;
            document.getElementById('btndeal').disabled = true;
            //chequeinfo
            document.getElementById('ttextchqno').disabled = true;     
             document.getElementById('drpourbank').disabled=true;                   
            document.getElementById('ttextchqdate').disabled = true;
            document.getElementById('ttextchqamt').disabled = true;
            document.getElementById('ttextbankname').disabled = true;
            document.getElementById('txtRetainercomm').disabled=false;
            document.getElementById('txtaddagencycommrateamt').disabled=false;
        }
        else if (insertstatus == "1")
        {
            document.getElementById('drpbooktype').disabled = true;
            document.getElementById('txtciobookid').disabled = true;
            
            document.getElementById('txtrono').disabled = true;
            document.getElementById('txtrodate').disabled = true;
            document.getElementById('txtcaption').disabled = true;
            document.getElementById('drpbillstatus').disabled = true;
            document.getElementById('drprostatus').disabled = true;
            document.getElementById('txtagency').disabled = true;
            document.getElementById('txtclient').disabled = true;
            // txtagencyaddress.Enabled = true;
            document.getElementById('txtclientadd').disabled = true;
            document.getElementById('drpagscode').disabled = true;
            document.getElementById('txtdockitno1').disabled = true;
            document.getElementById('txtexecname').disabled = true;
            document.getElementById('txtexeczone').disabled = true;
            document.getElementById('txtproduct').disabled = true;
            document.getElementById('drpbrand').disabled = true;
            document.getElementById('txtkeyno').disabled = true;
            document.getElementById('txtbillremark').disabled = true;
            document.getElementById('txtprintremark').disabled = true;
            document.getElementById('drppackage').disabled = true;
            document.getElementById('txtinsertion').disabled = true;
            document.getElementById('txtdummydate').disabled = true;
            document.getElementById('txtrepeatingdate').disabled = true;
            document.getElementById('drpbooktype').disabled = true;
            document.getElementById('drpadcategory').disabled = true;
            document.getElementById('drpadsubcategory').disabled = true;
            document.getElementById('drpadcat3').disabled = true;
            document.getElementById('drpadcat4').disabled = true;
            document.getElementById('drpadcat5').disabled = true;
            
            document.getElementById('drpcolor').disabled = true;
            document.getElementById('drpuom').disabled = true;
            document.getElementById('drppageposition').disabled = true;
            document.getElementById('txtpageno').disabled = false;
            document.getElementById('drpadstype').disabled = true;
            document.getElementById('drppagetype').disabled = false;
            
            document.getElementById('txtratecode').disabled = true;
            document.getElementById('drpscheme').disabled = true;
          //  drpschemepck.Enabled = false;
            document.getElementById('drpcurrency').disabled = true;
            document.getElementById('txtagreedrate').disabled = true;
            document.getElementById('txtagreedamt').disabled = true;
            document.getElementById('txtspedisc').disabled = true;
            document.getElementById('txtspacedisc').disabled = true;
            document.getElementById('txtspediscper').disabled = true;
            document.getElementById('txtspadiscper').disabled = true;
            document.getElementById('txtextracharges').disabled = true;
            document.getElementById('txtdatetime').disabled = true;
            document.getElementById('txtrepeatingdate').disabled = true;

            document.getElementById('drpbillcycle').disabled = true;
            document.getElementById('drprevenue').disabled = true;
            //drpbilltype.Enabled = true;
            document.getElementById('drpbillstatus').disabled = true;
            //drpbillcurrency.Enabled = true;
            document.getElementById('drppaymenttype').disabled = true;
            document.getElementById('txtinvoice').disabled = true;
            document.getElementById('txtvts').disabled = true;
            document.getElementById('txtbillwidth').disabled = true;
            document.getElementById('txtbillheight').disabled = true;
            document.getElementById('drpbillto').disabled = true;
            document.getElementById('txttradedisc').disabled = false;
            document.getElementById('txtagencyoutstand').disabled = true;
            document.getElementById('txtcardrate').disabled = true;
            document.getElementById('txtcardamt').disabled = true;
            document.getElementById('txtdiscount').disabled = true;
            document.getElementById('txtdiscpre').disabled = true;
            document.getElementById('txtadsize2').disabled = true;
            document.getElementById('txtadsize1').disabled = true;
            document.getElementById('txttotalarea').disabled = true;
            document.getElementById('txtbilladdress').disabled = true;
            
            document.getElementById('drpboxcode').disabled = true;
            
            document.getElementById('txtbillamt').disabled = true;
            
            document.getElementById('txtgrossamt').disabled = true;
            document.getElementById('txtcamp').disabled = true;
            
            document.getElementById('drppageprem').disabled = true;
            document.getElementById('chkage').disabled = true;
            document.getElementById('chkclie').disabled = true;
            document.getElementById('chktfn').disabled = true;
            
            document.getElementById('txtboxaddress').disabled = true;
            document.getElementById('txtinsertion').disabled = true;

            document.getElementById('txtcolum').disabled = true;
     
            document.getElementById('txtboxno').disabled = true;
            document.getElementById('drpmatsta').disabled = true;  

            ///////////////////////
            document.getElementById('txtcontractname').disabled = true;
            document.getElementById('txtcontracttype').disabled = true;
            document.getElementById('txtcardname').disabled = true;
            document.getElementById('drptype').disabled = true;
            document.getElementById('drpmonth').disabled = false;
            document.getElementById('drpyear').disabled = true;
            document.getElementById('txtcardno').disabled = true;
            document.getElementById('btnshgrid').disabled = true;
            document.getElementById('btndeal').disabled = true;
            //chequeinfo
            document.getElementById('ttextchqno').disabled = true;    
             document.getElementById('drpourbank').disabled=true;                    
            document.getElementById('ttextchqdate').disabled = true;
            document.getElementById('ttextchqamt').disabled = true;
            document.getElementById('ttextbankname').disabled = true;

        }
        else if (insertstatus == "0")
        {

            document.getElementById('btndeal').disabled = false;
            document.getElementById('btnshgrid').disabled = false;
            //btnupload.Enabled = true;
            document.getElementById('drpbooktype').disabled = false;
            document.getElementById('txtciobookid').disabled = true;
            // txtappby.Enabled = true;
            //txtaudit.Enabled = true;
            document.getElementById('txtRetainercomm').disabled = false;
            document.getElementById('txtaddagencycommrateamt').disabled = false;
            document.getElementById('txtrono').disabled = false;
            document.getElementById('txtrodate').disabled = false;
            document.getElementById('txtcamp').disabled = true;
            document.getElementById('txtcaption').disabled = true;
            document.getElementById('drpbillstatus').disabled = false;
            document.getElementById('drprostatus').disabled = false;
            document.getElementById('txtagency').disabled = false;
            document.getElementById('txtclient').disabled = false;
            document.getElementById('txtagencypaymode').disabled = true;
            // txtagencyaddress.Enabled = true;
            document.getElementById('txtclientadd').disabled = false;
            document.getElementById('drpagscode').disabled = false;
            document.getElementById('txtdockitno1').disabled = true;
            document.getElementById('txtexecname').disabled = false;
            document.getElementById('txtexeczone').disabled = false;
            document.getElementById('txtproduct').disabled = false;
            document.getElementById('drpbrand').disabled = false;
            document.getElementById('txtkeyno').disabled = false;
            document.getElementById('txtbillremark').disabled = false;
            document.getElementById('txtprintremark').disabled = false;
            document.getElementById('drppackage').disabled = false;
            document.getElementById('txtinsertion').disabled = false;
            document.getElementById('txtdummydate').disabled = false;
            document.getElementById('txtrepeatingdate').disabled = false;
            document.getElementById('drpbooktype').disabled = false;
            document.getElementById('drpadcategory').disabled = false;
            document.getElementById('drpadsubcategory').disabled = false;
            document.getElementById('drpadcat3').disabled = false;
            document.getElementById('drpadcat4').disabled = false;
            document.getElementById('drpadcat5').disabled = false;
            
            document.getElementById('drpcolor').disabled = false;
            document.getElementById('drpuom').disabled = false;
            document.getElementById('drppageposition').disabled = false;
            document.getElementById('txtpageno').disabled = false;
            document.getElementById('drpadstype').disabled = true;
            document.getElementById('drppagetype').disabled = false;
            
            document.getElementById('txtratecode').disabled = false;
            document.getElementById('drpscheme').disabled = true;

            document.getElementById('drpcurrency').disabled = false;
            document.getElementById('txtagreedrate').disabled = false;
            document.getElementById('txtagreedamt').disabled = false;
            document.getElementById('txtspedisc').disabled = false;
            document.getElementById('txtspacedisc').disabled = false;
            document.getElementById('txtspediscper').disabled = false;
            document.getElementById('txtspadiscper').disabled = false;
            document.getElementById('txtextracharges').disabled = false;
            document.getElementById('txtdatetime').disabled = true;
            document.getElementById('txtrepeatingdate').disabled = false;

            document.getElementById('drpbillcycle').disabled = false;
            document.getElementById('drprevenue').disabled = false;
            //drpbilltype.Enabled = true;
            document.getElementById('drpbillstatus').disabled = false;
            //drpbillcurrency.Enabled = true;
            document.getElementById('drppaymenttype').disabled = false;
            document.getElementById('txtinvoice').disabled = false;
            document.getElementById('txtvts').disabled = false;
            document.getElementById('txtbillwidth').disabled = false;
            document.getElementById('txtbillheight').disabled = false;
            document.getElementById('drpbillto').disabled = false;
            document.getElementById('txttradedisc').disabled = false;
            document.getElementById('txtagencyoutstand').disabled = true;
            document.getElementById('txtcardrate').disabled = true;
            document.getElementById('txtcardamt').disabled = true;
            document.getElementById('txtdiscount').disabled = true;
            document.getElementById('txtdiscpre').disabled = true;
            document.getElementById('txtadsize2').disabled = false;
            document.getElementById('txtadsize1').disabled = false;
            document.getElementById('txttotalarea').disabled = true;
            document.getElementById('txtbilladdress').disabled = false;
            
            document.getElementById('drpboxcode').disabled = false;                      
            document.getElementById('txtbillamt').disabled = true;
            
            document.getElementById('txtgrossamt').disabled = true;
            document.getElementById('drpboxcode').disabled = false;
            document.getElementById('chkage').disabled = false;
            document.getElementById('chkclie').disabled = false;
            document.getElementById('chktfn').disabled = false;
            
            document.getElementById('txtboxaddress').disabled = false;
            document.getElementById('txtinsertion').disabled = false;
            document.getElementById('txtcolum').disabled = false;
            document.getElementById('drpmatsta').disabled = false;

            ///////////////////////
            document.getElementById('txtcontractname').disabled = false;
            document.getElementById('txtcontracttype').disabled = false;
            document.getElementById('txtcardname').disabled = false;
            document.getElementById('drptype').disabled = false;
            document.getElementById('drpmonth').disabled = false;
            document.getElementById('drpyear').disabled = false;
            document.getElementById('txtcardno').disabled = false;
            document.getElementById('btncopy').disabled = false;
           // document.getElementById('btndel').disabled = false;
            document.getElementById('btnshgrid').disabled = false;
            document.getElementById('btndeal').disabled = false;
           
            document.getElementById('ttextchqno').disabled = false;   
             document.getElementById('drpourbank').disabled=false;                   
            document.getElementById('ttextchqdate').disabled = false;
            document.getElementById('ttextchqamt').disabled = false;
            document.getElementById('ttextbankname').disabled = false;
            document.getElementById('drppageprem').disabled = false;
            document.getElementById('txtRetainercomm').disabled=false;
             document.getElementById('txtaddagencycommrateamt').disabled=false;
        }
        
        if (document.getElementById('txtadsize1').value != "" && document.getElementById('txtcolum').value != "")
        {
            document.getElementById('txtadsize2').disabled =true;
            document.getElementById('txtadsize1').style.backgroundColor = "#FFFFFF";
            document.getElementById('txtadsize2').style.backgroundColor = "#FFFFFF";
            document.getElementById('txtcolum').style.backgroundColor = "#FFFFFF";

        }
        else if (document.getElementById('txtadsize1').value != "" && document.getElementById('txtadsize2').value != "")
        {
            document.getElementById('txtcolum').disabled =true;
            document.getElementById('txtadsize1').style.backgroundColor = "#FFFFFF";
            document.getElementById('txtadsize2').style.backgroundColor = "#FFFFFF";
            document.getElementById('txtcolum').style.backgroundColor = "#FFFFFF";
        }        
        

        document.getElementById('drpretainer').disabled = false;
        if(document.getElementById('txtaddagencycommrate')!=null)
            document.getElementById('txtaddagencycommrate').disabled = false;       
        var listpck = document.getElementById('hiddenpackage').value;
      // enableGridItems();
          showgridexecute();

        chkstatus(document.getElementById('hiddenbuttonidcheck').value);
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnsavepaginate').disabled = true;
       
}


    function queryClick()
    {  
       // document.getElementById('hiddensavemod').value = "1";
        rownumEx = 0;
        executequery=null;
          document.getElementById('LinkButton1').disabled = true;
        document.getElementById('LinkButton2').disabled = true;
        document.getElementById('LinkButton3').disabled = true;
        document.getElementById('LinkButton4').disabled = true;
        document.getElementById('LinkButton5').disabled = true;
        document.getElementById('LinkButton6').disabled = true;
        document.getElementById('LinkButton7').disabled = true;
        document.getElementById('btnshgrid').disabled = true;
        document.getElementById('txtagencypaymode').disabled = true;
        document.getElementById('txtciobookid').value = "";
        document.getElementById('txtrono').value = "";
        document.getElementById('txtrodate').value = "";        
        document.getElementById('drpbillstatus').value = "0";
        document.getElementById('drprostatus').value = "0";
        document.getElementById('txtagency').value = "";
        document.getElementById('txtclient').value = "";
        document.getElementById('txtagencyaddress').value = "";
        document.getElementById('txtclientadd').value = "";
        document.getElementById('drpagscode').value = "0";
        document.getElementById('txtdockitno1').value = "";
        document.getElementById('txtexecname').value = "";
        document.getElementById('txtexeczone').value = "";
        document.getElementById('txtproduct').value = "";
        document.getElementById('drpbrand').value = "0";
        document.getElementById('txtkeyno').value = "";
        document.getElementById('txtbillremark').value = "";
        document.getElementById('txtprintremark').value = "";
        
        document.getElementById('txtinsertion').value = "";
        document.getElementById('txtdummydate').value = "";
        document.getElementById('txtrepeatingdate').value = "";
        document.getElementById('drpbooktype').value = "0";
        document.getElementById('drpadcategory').value = "0";
        document.getElementById('drpadsubcategory').value = "0";
        document.getElementById('drpcolor').value = "0";
        document.getElementById('drpuom').value = "0";
        document.getElementById('drppageposition').value = "0";
        document.getElementById('drppagetype').value = "0";
        
        document.getElementById('drpadstype').value = "0";
        document.getElementById('txtratecode').value = "0";
        document.getElementById('drpscheme').value = "";
        document.getElementById('txtpageno').value = "";
        document.getElementById('drpcurrency').value = "0";
        document.getElementById('txtagreedrate').value = "";
        document.getElementById('txtagreedamt').value = "";
        document.getElementById('txtspedisc').value = "";
        document.getElementById('txtspacedisc').value = "";     
        document.getElementById('txtspediscper').value = "";
        document.getElementById('txtspadiscper').value = "";           
     
        document.getElementById('txtextracharges').value = "";
        document.getElementById('txtcolum').value = "";
        
        document.getElementById('drpmatsta').disabled = true;
        document.getElementById('drpmatsta').value = "0";

        if(document.getElementById('txtaddagencycommrate')!=null)
        {
            document.getElementById('txtaddagencycommrate').value = "";
        }  
        document.getElementById('txtcontractname').value = "";
        document.getElementById('txtcontracttype').value = "";
        document.getElementById('txtcardname').value = "";
        document.getElementById('drptype').value = "0";
        document.getElementById('drpmonth').value = "0";
        document.getElementById('drpyear').value = "0";
        document.getElementById('txtcardno').value = "0";

        document.getElementById('drppackage').value = "0";
        document.getElementById('drppackagecopy').options.length=0;
        document.getElementById('txtagencypaymode').options.length=0;
        document.getElementById('drpadcat3').disabled=true
        document.getElementById('drpadcat4').disabled=true
        document.getElementById('drpadcat3').options.length=0;
        document.getElementById('drpadcat4').options.length=0;

        document.getElementById('drpadcat5').disabled = true;
        document.getElementById('drpadcat5').options.length=0;
        
        //////////////////////////////
        document.getElementById('txtdockitno1').disabled =false;
        document.getElementById('txtkeyno').disabled = false;
        document.getElementById('txtrono').disabled = false;
        document.getElementById('txtagency').disabled = false;
        document.getElementById('txtclient').disabled = false;

        document.getElementById('txtciobookid').disabled = false;

        document.getElementById('hiddensavemod').value = "01";
        chkstatus(document.getElementById('hiddenbuttonidcheck').value);

        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnExecute').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('tblinsert').innerHTML='';
        return false;
    }
    
    
    function firstClick()
    {
        rownumEx=0;
        buttonmovement(rownumEx);
        //////////////////////////////////////////////////////////////////////////
       
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
       return false; 
    }
 
    function previousClick()
    {
        rownumEx--; 
         buttonmovement(rownumEx);
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = false;
        if (rownumEx == 0)
        {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        } 
        return false;
    }
    function nextClick()
    {
       rownumEx++;
       buttonmovement(rownumEx);
       document.getElementById('btnfirst').disabled = false;
       document.getElementById('btnlast').disabled = false;
       document.getElementById('btnprevious').disabled = false;
       document.getElementById('btnnext').disabled = false; 
       var count = executequery.Tables[0].Rows.length - 1;
       if(rownumEx==count)
       {
           document.getElementById('btnnext').disabled = true;
           document.getElementById('btnlast').disabled=true; 
       }
       return false;
    }
    
    function lastClick()
    {
       rownumEx=executequery.Tables[0].Rows.length - 1;
       buttonmovement(rownumEx);
       document.getElementById('btnfirst').disabled = false;
       document.getElementById('btnlast').disabled = true;
       document.getElementById('btnprevious').disabled = false;
       document.getElementById('btnnext').disabled = true;        
       return false;
    }
 
  function buttonmovement(rownumEx)
  {
           var msg=checkSession();
         if(msg==false)
         {
            window.location.href="login.aspx";
            return false;
         } 
        clearClick();
        document.getElementById('hiddensavemod').value = "1";
        document.getElementById('tblinsert').innerHTML='';        
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton2').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton5').disabled = false;
        document.getElementById('LinkButton6').disabled = false;
        document.getElementById('LinkButton7').disabled = false;
      
        //////////////////////////////////////////////////////////////////////////
       
          if(executequery==null)
          {
            alert(res1.error.description);
            return false;
          }
          if (executequery.Tables[0].Rows.length > 0)
          {
             if(executequery.Tables[0].Rows[rownumEx].prev_booking!=null && executequery.Tables[0].Rows[rownumEx].prev_booking!="")
            {
                var res = Booking_Master_temp.checkCIOIDReference(document.getElementById('hiddencompcode').value,executequery.Tables[0].Rows[rownumEx].cio_booking_id);
                if(res.value!=null)
                {
                    if(executequery.Tables[0].Rows[rownumEx].cio_booking_id!=res.value)
                    {
                        alert("CIO ID " + executequery.Tables[0].Rows[rownumEx].cio_booking_id + " has been ReScheduled to New CIO ID " + res.value);
                        return false;
                    }    
                }
            }
              if(executequery.Tables[0].Rows[rownumEx].branch!=null)
              {
                  document.getElementById('txtbranch').value = executequery.Tables[0].Rows[rownumEx].branch;
              }
              else
              {
                   document.getElementById('txtbranch').value="";
              }    
              if(executequery.Tables[0].Rows[rownumEx].booked_by!=null)
              {
                  document.getElementById('txtbookedby').value = executequery.Tables[0].Rows[rownumEx].booked_by;
              }
              else
              {
                  document.getElementById('txtbookedby').value="";  
              }
                     if(executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM_AMT!=null)
                {
                    document.getElementById('txtaddagencycommrateamt').value=executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM_AMT;
                }
                else
                {
                     document.getElementById('txtaddagencycommrateamt').value="";
                }
                  if(executequery.Tables[0].Rows[rownumEx].RETAINER_COMM_AMT!=null)
                {
                    document.getElementById('txtRetainercommamt').value=executequery.Tables[0].Rows[rownumEx].RETAINER_COMM_AMT;
                }
                else
                {
                    document.getElementById('txtRetainercommamt').value="";
                }
                   if(executequery.Tables[0].Rows[rownumEx].RETAINER_COMM!=null)
                {
                    document.getElementById('txtRetainercomm').value=executequery.Tables[0].Rows[rownumEx].RETAINER_COMM;
                }
                else
                {
                    document.getElementById('txtRetainercomm').value="";
                }
              
               if(executequery.Tables[0].Rows[rownumEx].boxchrg!=null)
                  {
                    boxpercen=executequery.Tables[0].Rows[rownumEx].boxchrg;
                    document.getElementById('hiddenboxchrgtype').value=executequery.Tables[0].Rows[rownumEx].boxchargetype;
                  }  
              if(executequery.Tables[0].Rows[rownumEx].prev_booking!=null)
              {    
                  document.getElementById('txtprevbook').value = executequery.Tables[0].Rows[rownumEx].prev_booking;
              }
              else
              {
                  document.getElementById('txtprevbook').value="";
              }    
              var datetime = executequery.Tables[0].Rows[rownumEx].DATE_TIME;
              if(datetime!=null)
              {
                  document.getElementById('txtdatetime').value = datetime;//getdatechk.getDate(dateformat, datetime);
              }
              else
              {
                  document.getElementById('txtdatetime').value="";
              }   
              if(executequery.Tables[0].Rows[rownumEx].cio_booking_id!=null)
              {
                  document.getElementById('txtciobookid').value = executequery.Tables[0].Rows[rownumEx].cio_booking_id;
              }  
              if(executequery.Tables[0].Rows[rownumEx].RO_No!=null)
              {
                  document.getElementById('txtrono').value = executequery.Tables[0].Rows[rownumEx].RO_No;
              } 
              else
              {
                  document.getElementById('txtrono').value="";
              }  
              var ro_date = executequery.Tables[0].Rows[rownumEx].RO_Date;
              if(ro_date!=null)
              {  
                  document.getElementById('txtrodate').value = ro_date;//getdatechk.getDate(dateformat, ro_date);
              } 
              else
              {
                  document.getElementById('txtrodate').value="";
              }  
              if(executequery.Tables[0].Rows[rownumEx].bill_status!=null)
              {
                  document.getElementById('drpbillstatus').value = executequery.Tables[0].Rows[rownumEx].bill_status;
              }
              else
              {
                  document.getElementById('drpbillstatus').value="";
              }   
              if(executequery.Tables[0].Rows[rownumEx].ro_status!=null)
              {
                  document.getElementById('drprostatus').value = executequery.Tables[0].Rows[rownumEx].ro_status;
              }
              else
              {
                  document.getElementById('drprostatus').value=""; 
              }    
              if(executequery.Tables[0].Rows[rownumEx].AgencyName!=null)
              {
                  document.getElementById('txtagency').value = executequery.Tables[0].Rows[rownumEx].AgencyName;
              } 
              else
              {
                  document.getElementById('txtagency').value="";
              } 
              if(executequery.Tables[0].Rows[rownumEx].Caption!=null)
              {
                  document.getElementById('txtcaption').value = executequery.Tables[0].Rows[rownumEx].Caption;
              }
              else
              {
                  document.getElementById('txtcaption').value="";  
              }   
             
                ///////////////this is to bind the subagency drop down
            
               var res2=Booking_Master_temp.bindsubagency(executequery.Tables[0].Rows[rownumEx].Agency_sub_code, document.getElementById('hiddencompcode').value);
                
                var dsbsa = res2.value;
                if(dsbsa==null)
                {
                    alert(res2.error.description);
                    return false;
                }               

                document.getElementById('drpagscode').options.length=0;
                document.getElementById('drpagscode').options[0]=new Option("Select Agency","0");
                document.getElementById('drpagscode').options.length = 1; 
                for (var i = 0  ; i < dsbsa.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drpagscode').options[document.getElementById('drpagscode').options.length] = new Option(dsbsa.Tables[0].Rows[i].agency_name,dsbsa.Tables[0].Rows[i].Agency_Code);                
                    document.getElementById('drpagscode').options.length;       
                }

            //////////////////////////////////////////////////////
             if(executequery.Tables[0].Rows[rownumEx].Client!=null)
            {
                if(executequery.Tables[0].Rows[rownumEx].client_code!=null)
                {
                    if(executequery.Tables[0].Rows[rownumEx].Client=="")
                        document.getElementById('txtclient').value = executequery.Tables[0].Rows[rownumEx].client_code;
                    else
                        document.getElementById('txtclient').value = executequery.Tables[0].Rows[rownumEx].Client + "(" +executequery.Tables[0].Rows[rownumEx].client_code+")";
                   
                            
                }    
                else    
                    document.getElementById('txtclient').value = executequery.Tables[0].Rows[rownumEx].Client;     //.ItemArray[14].ToString();
            }    
            else
            {
                document.getElementById('txtclient').value = "";
            }
//            if(executequery.Tables[0].Rows[rownumEx].Client!=null)
//            {
//                document.getElementById('txtclient').value = executequery.Tables[0].Rows[rownumEx].Client;     //.ItemArray[14].ToString();
//            }
//            else
//            {
//            }    
            if(executequery.Tables[0].Rows[rownumEx].Agency_address!=null)
            {
                document.getElementById('txtagencyaddress').value = executequery.Tables[0].Rows[rownumEx].Agency_address;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Client_address!=null)
            {
                document.getElementById('txtclientadd').value = executequery.Tables[0].Rows[rownumEx].Client_address;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Agency_code!=null)
            {
                document.getElementById('hiddensubcode').value = document.getElementById('drpagscode').value = executequery.Tables[0].Rows[rownumEx].Agency_code;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Dockit_no!=null)
            {
                document.getElementById('txtdockitno1').value = executequery.Tables[0].Rows[rownumEx].Dockit_no;
            }   
            if(executequery.Tables[0].Rows[rownumEx].execname!=null)
            { 
                document.getElementById('txtexecname').value = executequery.Tables[0].Rows[rownumEx].execname;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Executive_zone!=null)
            {
                document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value = executequery.Tables[0].Rows[rownumEx].Executive_zone;
            }    
            if(executequery.Tables[0].Rows[rownumEx].product!=null)
            {
                document.getElementById('txtproduct').value = executequery.Tables[0].Rows[rownumEx].product;
            }    
            
            /////////////////////////////////////////////this is to bind the brand drop down
            res2=null;
            if(executequery.Tables[0].Rows[rownumEx].Product_code!=null)
            {
                res2=Booking_Master_temp.brandbind(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[rownumEx].Product_code);
                var dsbrand = res2.value;
                if(dsbrand==null)
                {
                    alert(res2.error.description);
                    return false;
                }            
                document.getElementById('drpbrand').options.length=0;
                document.getElementById('drpbrand').options[0]=new Option("Select Brand","0");
                document.getElementById('drpbrand').options.length = 1; 
                for (var i = 0; i < dsbrand.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drpbrand').options[document.getElementById('drpbrand').options.length] = new Option(dsbrand.Tables[0].Rows[i].brand_name,dsbrand.Tables[0].Rows[i].brand_code);            
                    document.getElementById('drpbrand').options.length;       
                }                
            }
            //hiddenbrand.Value=drpbrand.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[21].ToString();
            if (executequery.Tables[0].Rows[rownumEx].Brand_code==null || executequery.Tables[0].Rows[rownumEx].Brand_code.toString() == "")
            {
                document.getElementById('drpbrand').options.length=0;
                document.getElementById('hiddenbrand').value = "";
            }
            else
            {
                if(executequery.Tables[0].Rows[rownumEx].Brand_code!=null)
                {
                    document.getElementById('hiddenbrand').value = document.getElementById('drpbrand').value = executequery.Tables[0].Rows[rownumEx].Brand_code.toString();
                }    
            }
            ////////////////////this is to bind the varient dropdown
            res2=Booking_Master_temp.varientbind(document.getElementById('hiddencompcode').value, document.getElementById('hiddenbrand').value);
            var dsvarient = res2.value;
            if(dsvarient==null)
            {
                alert(res.error.description)
                return false;
           }
           document.getElementById('drpvarient').options.length=0;
           document.getElementById('drpvarient').options[0]=new Option("Select Varient","0");
           document.getElementById('drpvarient').options.length = 1; 
           for (var i = 0  ; i < dsvarient.Tables[0].Rows.length; ++i)
           {
                document.getElementById('drpvarient').options[document.getElementById('drpvarient').options.length] = new Option(dsvarient.Tables[0].Rows[i].varient_name,dsvarient.Tables[0].Rows[i].varient_code);                
                document.getElementById('drpvarient').options.length;       
           } 
          
           if (executequery.Tables[0].Rows[rownumEx].Variant_code==null || executequery.Tables[0].Rows[rownumEx].Variant_code.toString() == "")
           {
                document.getElementById('drpvarient').options.length=0;
                document.getElementById('hiddenvar').value = "";
           }
           else
           {
                if(executequery.Tables[0].Rows[rownumEx].Brand_code!=null)
                {
                    document.getElementById('hiddenvar.Value').value = document.getElementById('drpvarient').value = executequery.Tables[0].Rows[rownumEx].Variant_code.toString();
                }    
           }
            ////////////////////////////////////////////////////////////////////////////////
            if(executequery.Tables[0].Rows[rownumEx].Key_no!=null)
            {
                document.getElementById('txtkeyno').value = executequery.Tables[0].Rows[rownumEx].Key_no;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Bill_remarks!=null)
            {
                document.getElementById('txtbillremark').value = executequery.Tables[0].Rows[rownumEx].Bill_remarks;
            }    
            if(executequery.Tables[0].Rows[0].Print_remark!=null)
            {
                document.getElementById('txtprintremark').value = executequery.Tables[0].Rows[rownumEx].Print_remark;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Package_code!=null)
            {
                var listpck = executequery.Tables[0].Rows[rownumEx].Package_code;
                document.getElementById('hiddenpackage').value = listpck;
            //////////////////this is to bind the package grid on what the value is saved in the database
                res2=null;
                res2=Booking_Master_temp.bindpacforexe(document.getElementById('hiddencompcode').value, listpck);
                var dsexecut = res2.value;
                if(dsexecut==null)
                {
                    alert(res2.error.description);
                    return false;
                }
                
                document.getElementById('drppackagecopy').options.length=0;
                for (i = 0; i <= dsexecut.Tables[0].Rows.length - 1; i++)
                {
                    if (dsexecut.Tables[0].Rows[i].pck_code.toString() != "")
                    {
                        if (dsexecut.Tables[0].Rows[i].pck_code.toString() != "0")
                        {
                            var arrfor_uom = dsexecut.Tables[0].Rows[i].pck_code.toString().split('@');
                            var res3=Booking_Master_temp.getPackageInsert(arrfor_uom[0].toString(), document.getElementById('txtciobookid').value);
                            var dsinsert = res3.value;
                            if(dsinsert==null)
                            {
                                alert(res3.error.description);
                                return false;
                            }
                            var T=dsexecut.Tables[0].Rows[i].Package_Name + "(" + dsinsert.Tables[0].Rows[0].inserts + ")";
                            var V=dsexecut.Tables[0].Rows[i].pck_code + "(" + dsinsert.Tables[0].Rows[0].inserts + ")";
                            if(dsinsert.Tables[0].Rows[0].inserts!=null)
                            {
                            document.getElementById('drppackagecopy').options[document.getElementById('drppackagecopy').options.length] = new Option(T,V);
                    
                            document.getElementById('drppackagecopy').options.length; 
                           } 
                        }
                    }
                }
            }
                
            if(executequery.Tables[0].Rows[rownumEx].No_of_insertion!=null)
            {
                document.getElementById('txtinsertion').value = executequery.Tables[0].Rows[rownumEx].No_of_insertion;
                document.getElementById('hiddeninsertion').value = executequery.Tables[0].Rows[rownumEx].No_of_insertion;
            }   
            
            var start_date = executequery.Tables[0].Rows[rownumEx].Insertion_date;
            if(start_date!=null)
            {
                document.getElementById('txtdummydate').value = start_date;//getdatechk.getDate(dateformat, start_date);
            }    
            if(executequery.Tables[0].Rows[rownumEx].Repeating_day!=null)
            {
                document.getElementById('txtrepeatingdate').value = executequery.Tables[0].Rows[rownumEx].Repeating_day;
            } 
            // 
            if(executequery.Tables[0].Rows[rownumEx].Page_type_code!=null)
            {
                document.getElementById('drppagetype').value = executequery.Tables[0].Rows[rownumEx].Page_type_code;
            }
            
            if(executequery.Tables[0].Rows[rownumEx].Page_no!=null)
            {
                document.getElementById('txtpageno').value = executequery.Tables[0].Rows[rownumEx].Page_no;
            }
            //   
            if(executequery.Tables[0].Rows[rownumEx].Booking_type!=null)
            {
                document.getElementById('drpbooktype').value = executequery.Tables[0].Rows[rownumEx].Booking_type;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Ad_cat_code!=null)
            {
                document.getElementById('drpadcategory').value = executequery.Tables[0].Rows[rownumEx].Ad_cat_code;
            }    
              if(executequery.Tables[0].Rows[rownumEx].Ad_cat_code!=null)
            {
                var ds_adsubcat=null;
                ds_adsubcat=Booking_Master_temp.getadsubcat(document.getElementById('hiddencompcode').value,executequery.Tables[0].Rows[rownumEx].Ad_cat_code,document.getElementById('hiddencattype').value);                
                var dacat = ds_adsubcat.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }
               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadsubcategory').options.length=0;
               document.getElementById('drpadsubcategory').options[0]=new Option("Select","0");
                for (var k = 0; k < dacat.Tables[0].Rows.length; k++)
                {
                     document.getElementById('drpadsubcategory').options[document.getElementById('drpadsubcategory').options.length] = new Option(dacat.Tables[0].Rows[k].Adv_Subcat_Name,dacat.Tables[0].Rows[k].Adv_Subcat_Code);                 
                     document.getElementById('drpadsubcategory').options.length; 
                }

          }   
            if(executequery.Tables[0].Rows[0].Ad_sub_cat_code!=null)
            {
                document.getElementById('drpadsubcategory').value = executequery.Tables[0].Rows[rownumEx].Ad_sub_cat_code;
            }
            if(executequery.Tables[0].Rows[rownumEx].Color_code!=null)
            {
                document.getElementById('drpcolor').value = executequery.Tables[0].Rows[0].Color_code;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Uom_code!=null)
            {
                document.getElementById('drpuom').value = executequery.Tables[0].Rows[rownumEx].Uom_code;
            }    
            
            res3=null;
            res3 = Booking_Master_temp.gettheuom_desc(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[rownumEx].Uom_code);  
            var ds_uom_=res3.value;
            if(ds_uom_==null)
            {
                alert(res3.error.description);
                return false;
            }
            if(ds_uom_.Tables[0].Rows.length>0)
            {
                document.getElementById('hiddenuomdesc').value = ds_uom_.Tables[0].Rows[0].uom_desc;   
            }  
             
            if(executequery.Tables[0].Rows[rownumEx].Page_position_code!=null)
            {
                document.getElementById('drppageposition').value = executequery.Tables[0].Rows[rownumEx].Page_position_code;
             }   
       
            //string adtype=drpadstype.SelectedValue;
            if(executequery.Tables[0].Rows[rownumEx].Ad_size_height!=null)
            {
                document.getElementById('txtadsize1').value = executequery.Tables[0].Rows[rownumEx].Ad_size_height;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Ad_size_width!=null)
            {
                document.getElementById('txtadsize2').value = executequery.Tables[0].Rows[rownumEx].Ad_size_width;
            }    
            ////this is to bind the ratecode drpdown
            res3=null
            if(executequery.Tables[0].Rows[rownumEx].Ad_cat_code!=null)
            {
                res3=Booking_Master_temp.ratebind(executequery.Tables[0].Rows[rownumEx].Ad_cat_code, document.getElementById('hiddencompcode').value);
                var dx = res3.value;
                if(dx==null)
                {   
                    alert(dx.error.description);
                    return false;
                }
                document.getElementById('txtratecode').options.length=0;
                document.getElementById('txtratecode').options[0]=new Option("-Select Rate Code-","0");
                document.getElementById('txtratecode').options.length = 1; 
                
                for (var i = 0  ; i < dx.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('txtratecode').options[document.getElementById('txtratecode').options.length] = new Option(dx.Tables[0].Rows[i].rate_mast_code,dx.Tables[0].Rows[i].rate_mast_code);
                    document.getElementById('txtratecode').options.length;       
                }                
            }
            if(executequery.Tables[0].Rows[rownumEx].Rate_code!=null)
            {
                document.getElementById('txtratecode').value = executequery.Tables[0].Rows[0].Rate_code;
                document.getElementById('hiddenratecode').value  = executequery.Tables[0].Rows[0].Rate_code;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Scheme_type_code!=null)
            {
                document.getElementById('drpscheme').value = executequery.Tables[0].Rows[rownumEx].Scheme_type_code;
                document.getElementById('hiddenscheme').value = executequery.Tables[0].Rows[rownumEx].Scheme_type_code;
            }   
              
            if(executequery.Tables[0].Rows[rownumEx].Currency_code!=null)
            {
                document.getElementById('drpcurrency').value = executequery.Tables[0].Rows[rownumEx].Currency_code;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Agrred_rate!=null)
            {
                document.getElementById('txtagreedrate').value = executequery.Tables[0].Rows[rownumEx].Agrred_rate;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Agreed_amount!=null)
            {
                document.getElementById('txtagreedamt').value = executequery.Tables[0].Rows[rownumEx].Agreed_amount;
            }    
            //
            if(executequery.Tables[0].Rows[rownumEx].Special_discount!=null)
            {
                document.getElementById('txtspedisc').value = executequery.Tables[0].Rows[rownumEx].Special_discount;
            }
            if(executequery.Tables[0].Rows[rownumEx].Space_discount!=null)
            {
                document.getElementById('txtspacedisc').value = executequery.Tables[0].Rows[rownumEx].Space_discount;
            }
            if(executequery.Tables[0].Rows[rownumEx].Special_disc_per!=null)
            {
                document.getElementById('txtspediscper').value = executequery.Tables[0].Rows[rownumEx].Special_disc_per;
            }
            if(executequery.Tables[0].Rows[rownumEx].Space_disc_per!=null)
            {
                document.getElementById('txtspadiscper').value = executequery.Tables[0].Rows[rownumEx].Space_disc_per;
            }
            //
    
            if(executequery.Tables[0].Rows[rownumEx].Special_charges!=null)
            {
                document.getElementById('txtextracharges').value = executequery.Tables[0].Rows[rownumEx].Special_charges;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Agency_status!=null)
            {
                document.getElementById('hiddenstatus').value = document.getElementById('txtagencystatus').value = executequery.Tables[0].Rows[rownumEx].Agency_status;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Agency_type!=null)
            {
                document.getElementById('txtagencytype').value = executequery.Tables[0].Rows[rownumEx].Agency_type;
            }    
            //this is To the bind the the agencypaymode dropdown on execution
            res3=null;
            if(executequery.Tables[0].Rows[rownumEx].Agency_sub_code!=null)
            {
                res3=Booking_Master_temp.getstatuspaymode(executequery.Tables[0].Rows[rownumEx].Agency_sub_code, executequery.Tables[0].Rows[rownumEx].Agency_code, document.getElementById('hiddencompcode').value, document.getElementById('txtdatetime').value,document.getElementById('hiddendateformat').value,"DI0");
                var dch = res3.value;
                if(dch==null)
                {
                    alert(res3.error.description);
                    return false;
                }

                document.getElementById('txtagencypaymode').options.length=0;
                if (dch.Tables[5].Rows.length > 0)
                {
                    for (var i = 0; i < dch.Tables[5].Rows.length; i++)
                    {
                        document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);                
                        document.getElementById('txtagencypaymode').options.length;                    
                    }
                }
            } 
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            if(executequery.Tables[0].Rows[rownumEx].Agency_pay!=null)
            {
                document.getElementById('hiddenpay').value =  document.getElementById('txtagencypaymode').value = executequery.Tables[0].Rows[rownumEx].Agency_pay;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Agency_credit!=null)
            {
                document.getElementById('txtcreditperiod').value = executequery.Tables[0].Rows[rownumEx].Agency_credit;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Total_area!=null)
            {
                document.getElementById('txttotalarea').value = executequery.Tables[0].Rows[rownumEx].Total_area;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Card_rate!=null)
            {
                document.getElementById('txtcardrate').value = executequery.Tables[0].Rows[rownumEx].Card_rate;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Card_amount!=null)
            {
                document.getElementById('txtcardamt').value = executequery.Tables[0].Rows[rownumEx].Card_amount;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Discount!=null)
            {
                document.getElementById('txtdiscount').value = executequery.Tables[0].Rows[rownumEx].Discount;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Discount_per!=null)
            {
                document.getElementById('txtdiscpre').value = executequery.Tables[0].Rows[rownumEx].Discount_per;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Bill_cycle!=null)
            {
                document.getElementById('drpbillcycle').value = executequery.Tables[0].Rows[rownumEx].Bill_cycle;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Revenue_center!=null)
            {
                document.getElementById('drprevenue').value = executequery.Tables[0].Rows[rownumEx].Revenue_center;
            }    

            ////this is to bind the bill pay mode
            document.getElementById('drppaymenttype').options.length=0;
            if (dch.Tables[5].Rows.length > 0)
            {
                for (var i = 0;  i< dch.Tables[5].Rows.length; i++)
                {
                   document.getElementById('drppaymenttype').options[document.getElementById('drppaymenttype').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);                
                   document.getElementById('drppaymenttype').options.length; 
                }

            }
            if(executequery.Tables[0].Rows[rownumEx].Bill_pay!=null)
            {    
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value = executequery.Tables[0].Rows[rownumEx].Bill_pay;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Bill_height!=null)
            {
                document.getElementById('txtbillheight').value = executequery.Tables[0].Rows[rownumEx].Bill_height;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Bill_width!=null)
            {
                document.getElementById('txtbillwidth').value = executequery.Tables[0].Rows[rownumEx].Bill_width;
            }    
            //////////////this is to bind the bill to 
            res3=null;
            if(executequery.Tables[0].Rows[rownumEx].Agency_sub_code!=null)
            {
                res3=Booking_Master_temp.getbillval(executequery.Tables[0].Rows[rownumEx].Agency_sub_code, document.getElementById('hiddencompcode').value);
                var dbt = res3.value;
                if(dbt==null)
                {
                    alert(res3.error.description);
                    return false;
                }
                ////////////////////////////////////////////////////
                
               document.getElementById('drpbillto').options.length=0;
                var client_val=document.getElementById('txtclient').value;
                 var client_name=document.getElementById('txtclient').value;
                 if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                {
                    client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                    client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                 }  
                document.getElementById('drpbillto').options[0] = new Option(client_name,client_val);       
                
                for (var k = 0; k < dbt.Tables[0].Rows.length; k++)
                {
                    if(dbt.Tables[0].Rows[k].bill_to=="")
                        document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name,dbt.Tables[0].Rows[k].bill_to);                
                    else
                        document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name,dbt.Tables[0].Rows[k].SUB_agency_code);                    
                     document.getElementById('drpbillto').options.length; 
                }
            }
            if(executequery.Tables[0].Rows[rownumEx].Bill_to!=null)
            {
                document.getElementById('hiddenbillto').value = executequery.Tables[0].Rows[rownumEx].Bill_to;
                document.getElementById('drpbillto').value = executequery.Tables[0].Rows[rownumEx].Bill_to;
            }    
//            if(executequery.Tables[0].Rows[0].Bill_to!=null)
//            {
//                document.getElementById('drpbillto').value = executequery.Tables[0].Rows[0].Bill_to;
//            }    
            if(executequery.Tables[0].Rows[rownumEx].Invoices!=null)
            {
                document.getElementById('txtinvoice').value = executequery.Tables[0].Rows[rownumEx].Invoices;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Vts!=null)
            {
                document.getElementById('txtvts').value = executequery.Tables[0].Rows[rownumEx].Vts;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Page_prem!=null)
            {
                document.getElementById('drppageprem').value = executequery.Tables[0].Rows[rownumEx].Page_prem;
            } 
            if(executequery.Tables[0].Rows[rownumEx].Bill_add!=null)
            {
                document.getElementById('txtbilladdress').value = executequery.Tables[0].Rows[rownumEx].Bill_add;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Trade_disc!=null)
            {
                document.getElementById('txttradedisc').value = executequery.Tables[0].Rows[rownumEx].Trade_disc;
                 document.getElementById('hiddentradedisc').value=document.getElementById('txttradedisc').value;
            }
            if(executequery.Tables[0].Rows[rownumEx].Agency_out!=null)
            {
                document.getElementById('txtagencyoutstand').value = executequery.Tables[0].Rows[rownumEx].Agency_out;
            }    
            
            if(executequery.Tables[0].Rows[rownumEx].Page_amount!=null)
            {
                document.getElementById('txtpageamt').value = executequery.Tables[0].Rows[rownumEx].Page_amount;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Gross_amount!=null)
            {
                document.getElementById('txtgrossamt').value = executequery.Tables[0].Rows[rownumEx].Gross_amount;
            }    

            //Inserting in hidden field to compare new and  Previous amount 
            if(executequery.Tables[0].Rows[rownumEx].Gross_amount!=null)
            {
                document.getElementById('hiddenprevamt').value = executequery.Tables[0].Rows[rownumEx].Gross_amount;
            }   

            if(executequery.Tables[0].Rows[rownumEx].Bill_amount!=null)
            {
                document.getElementById('txtbillamt').value = executequery.Tables[0].Rows[rownumEx].Bill_amount;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Box_code!=null)
            {
                document.getElementById('drpboxcode').value = executequery.Tables[0].Rows[rownumEx].Box_code;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Box_no!=null)
            {
                document.getElementById('txtboxno').value = executequery.Tables[0].Rows[rownumEx].Box_no;
            }    
            if (executequery.Tables[0].Rows[rownumEx].Box_agency.toString() == "1")
            {
                document.getElementById('chkage').checked = true;
            }
            else
            {
                document.getElementById('chkage').checked = false;
            }
            if (executequery.Tables[0].Rows[rownumEx].Box_client.toString() == "1")
            {
                document.getElementById('chkclie').checked = true;
            }
            else
            {
                document.getElementById('chkclie').checked = false;
            }
            if(executequery.Tables[0].Rows[rownumEx].Box_address!=null)
            {
                document.getElementById('txtboxaddress').value = executequery.Tables[0].Rows[rownumEx].Box_address;
            }    
            if (executequery.Tables[0].Rows[rownumEx].Tfn == "1")
            {
                document.getElementById('chktfn').value = true;
            }
            else
            {
                document.getElementById('chktfn').value= false;
            }
            if(executequery.Tables[0].Rows[rownumEx].Ad_size_column!=null)
            {
                document.getElementById('txtcolum').value = executequery.Tables[0].Rows[rownumEx].Ad_size_column;
            }   
            if(executequery.Tables[0].Rows[rownumEx].Paid_ins!=null)
            {          
                document.getElementById('txtpaid').value = executequery.Tables[0].Rows[rownumEx].Paid_ins;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Contract_rate!=null)
            {
                document.getElementById('txtdealrate').value = executequery.Tables[0].Rows[rownumEx].Contract_rate;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Deviation!=null)
            {
                document.getElementById('txtdeviation').value = executequery.Tables[0].Rows[rownumEx].Deviation;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Contract_name!=null)
            {          
                document.getElementById('txtcontractname').value = executequery.Tables[0].Rows[rownumEx].Contract_name;
            }    
            if(executequery.Tables[0].Rows[rownumEx].Contract_type!=null)
            {
                document.getElementById('txtcontracttype').value = executequery.Tables[0].Rows[rownumEx].Contract_type;
            }    
//            if(executequery.Tables[0].Rows[rownumEx].Card_name!=null)
//            {
//                document.getElementById('txtcardname').value = executequery.Tables[0].Rows[rownumEx].Card_name;
//            }   
//            if(executequery.Tables[0].Rows[rownumEx].Card_type!=null)
//            {
//                document.getElementById('drptype').value = executequery.Tables[0].Rows[rownumEx].Card_type;
//            }
            if(executequery.Tables[0].Rows[rownumEx].Variant_code!=null)
            {
                document.getElementById('hiddenvar').value=document.getElementById('drpvarient').value = executequery.Tables[0].Rows[rownumEx].Variant_code;
            }
                
//             if(executequery.Tables[0].Rows[rownumEx].Card_month!=null)
//             {
//                document.getElementById('drpmonth').value = executequery.Tables[0].Rows[rownumEx].Card_month;
//             }   
//             if(executequery.Tables[0].Rows[rownumEx].Card_year!=null)
//             {
//                document.getElementById('drpyear').value = executequery.Tables[0].Rows[rownumEx].Card_year;
//             }   
//             if(executequery.Tables[0].Rows[rownumEx].Card_number!=null)
//             {
//                document.getElementById('txtcardno').value = executequery.Tables[0].Rows[rownumEx].Card_number;
//             }   
            if(executequery.Tables[0].Rows[rownumEx].Receipt_no!=null)
            { 
                document.getElementById('hiddenreceiptno').value =  document.getElementById('txtreceipt').value = executequery.Tables[0].Rows[rownumEx].Receipt_no;
            }    
            
              if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0"   || document.getElementById('drppaymenttype').value=='PO0')            
                {
                    var ds_chq=Booking_Master_temp.ChequeInfo(document.getElementById('hiddencompcode').value,document.getElementById('txtreceipt').value);
                    if(ds_chq.value!=null && ds_chq.value.Tables[0].Rows.length>0)
                    {
                        if(ds_chq.value.Tables[0].Rows[0].chno!=null)
                            document.getElementById('ttextchqno').value=ds_chq.value.Tables[0].Rows[0].chno;  
                        else
                            document.getElementById('ttextchqno').value="";    
                        var cDate="";
                        if(ds_chq.value.Tables[0].Rows[0].chdt!=null)
                        {
                                if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
                                {
                                    cDate=ds_chq.value.Tables[0].Rows[0].chdt;  
                                }          
                                else if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                                {
                                    var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                                    cDate=txt[1] + "/" + txt[0] + "/" + txt[2];
                                }
                                  else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                                {
                                    var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                                    cDate=txt[2] + "/" + txt[1] + "/" + txt[0];
                                }
                         }       
                        document.getElementById('ttextchqdate').value=cDate;  
                        if(ds_chq.value.Tables[0].Rows[0].amount!=null)
                            document.getElementById('ttextchqamt').value=ds_chq.value.Tables[0].Rows[0].amount;  
                        else
                            document.getElementById('ttextchqamt').value="";    
                        if(document.getElementById('ttextchqamt').value.indexOf("-")>=0)
                            document.getElementById('ttextchqamt').value=document.getElementById('ttextchqamt').value.replace("-","");
                        if(ds_chq.value.Tables[0].Rows[0].bank!=null)    
                            document.getElementById('ttextbankname').value=ds_chq.value.Tables[0].Rows[0].bank;                          
                        else
                            document.getElementById('ttextbankname').value="";
                         if(ds_chq.value.Tables[0].Rows[0].cashbank!=null)    
                                document.getElementById('drpourbank').value=ds_chq.value.Tables[0].Rows[0].cashbank;                          
                            else
                                document.getElementById('drpourbank').value="0";       
                    }
                }
               else if(document.getElementById('drppaymenttype').value=="CR0")
               {
                    var ds_chq=Booking_Master_temp.ChequeInfo(document.getElementById('hiddencompcode').value,document.getElementById('txtreceipt').value);
                    if(ds_chq.value!=null && ds_chq.value.Tables[0].Rows.length>0)
                    {
                        if(ds_chq.value.Tables[0].Rows[0].bank!=null)
                            document.getElementById('txtcardname').value=ds_chq.value.Tables[0].Rows[0].bank;
                        else
                            document.getElementById('txtcardname').value="";    
                        if(ds_chq.value.Tables[0].Rows[0].remark!=null)    
                            document.getElementById('drptype').value=ds_chq.value.Tables[0].Rows[0].remark;
                        else
                            document.getElementById('drptype').value="";    
                        if(ds_chq.value.Tables[0].Rows[0].chno!=null)    
                            document.getElementById('txtcardno').value=ds_chq.value.Tables[0].Rows[0].chno;                          
                        else
                            document.getElementById('txtcardno').value="";    
                        if(ds_chq.value.Tables[0].Rows[0].chdt!=null)
                        {    
                            var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                            document.getElementById('drpmonth').value=parseInt(txt[1],10);
                            document.getElementById('drpyear').value=txt[2];
                        }    
                        
                     }   
               }
               
            if(executequery.Tables[0].Rows[rownumEx].Material_status!=null)
            {
                document.getElementById('drpmatsta').value = executequery.Tables[0].Rows[rownumEx].Material_status;
            }    

            ////this is to bind the adscat3 drpdown

            if (executequery.Tables[0].Rows[rownumEx].Ad_sub_cat_code==null || executequery.Tables[0].Rows[rownumEx].Ad_sub_cat_code.toString() == "" || executequery.Tables[0].Rows[rownumEx].Ad_sub_cat_code=="0")
            {
                document.getElementById('drpadcat3').options.length=0;
                document.getElementById('hiddenadscat3').value = "";
            }
            else
            {
                res3=null;
                res3=Booking_Master_temp.getvalfromadcat3(executequery.Tables[0].Rows[rownumEx].Ad_sub_cat_code,document.getElementById('hiddencompcode').value,"0");
                var dacat = res3.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }

               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadcat3').options.length=0;
               document.getElementById('drpadcat3').options[0]=new Option("Select","0");
                for (var k = 0; k < dacat.Tables[0].Rows.length; k++)
                {
                     document.getElementById('drpadcat3').options[document.getElementById('drpadcat3').options.length] = new Option(dacat.Tables[0].Rows[k].catname,dacat.Tables[0].Rows[k].catcode);                    
                     document.getElementById('drpadcat3').options.length; 
                }

            }
           
            if(executequery.Tables[0].Rows[rownumEx].Ad_Subcat3!=null)
            {
                 document.getElementById('hiddenadscat3').value = document.getElementById('drpadcat3').value = executequery.Tables[0].Rows[rownumEx].Ad_Subcat3;
            }    
           
            ////////////////////this is to bind the adcat4 drp down
            if (executequery.Tables[0].Rows[rownumEx].Ad_Subcat3 == null || executequery.Tables[0].Rows[rownumEx].Ad_Subcat3.toString() == "" || executequery.Tables[0].Rows[rownumEx].Ad_Subcat3=="0")
            {
                document.getElementById('drpadcat4').options.length=0;
                document.getElementById('hiddenadscat4').value = "";
            }
            else
            {
                ////////////when 1 than bind the adscat4 drp down
                res3=null;
                res3=Booking_Master_temp.getvalfromadcat3(executequery.Tables[0].Rows[rownumEx].Ad_Subcat3,document.getElementById('hiddencompcode').value,"1");
                var dacat = res3.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }
               
                ////////////////////////////////////////////////////////////////
                document.getElementById('drpadcat4').options.length=0;
                document.getElementById('drpadcat4').options[0]=new Option("Select","0");
                for (var k = 0; k < dbt.Tables[0].Rows.length; k++)
                {
                     document.getElementById('drpadcat4').options[document.getElementById('drpadcat4').options.length] = new Option(dacat.Tables[0].Rows[k].Cat_Name,dacat.Tables[0].Rows[k].Cat_Code);                    
                     document.getElementById('drpadcat4').options.length; 
                }
            }
            if (executequery.Tables[0].Rows[rownumEx].Ad_Subcat4 != null)
            { 
                document.getElementById('hiddenadscat4').value = document.getElementById('drpadcat4').value = executequery.Tables[0].Rows[0].Ad_Subcat4;
            }    
          
            ///bind adcat5 drpdown
            if (executequery.Tables[0].Rows[rownumEx].Ad_Subcat4==null || executequery.Tables[0].Rows[rownumEx].Ad_Subcat4.toString() == "" || executequery.Tables[0].Rows[rownumEx].Ad_Subcat4=="0")
            {
                document.getElementById('drpadcat5').options.length=0;
                document.getElementById('hiddenadscat5').value = "";
            }
            else
            {
                ////////////when 1 than bind the adscat4 drp down

                res3=null;
                res3=Booking_Master_temp.getvalfromadcat3(executequery.Tables[0].Rows[rownumEx].Ad_Subcat4,document.getElementById('hiddencompcode').value,"2");
                var dacat = res3.value;
                if(dacat==null)
                {
                    alert(dacat.error.description);
                    return false;
                }

               
                ////////////////////////////////////////////////////////////////
               document.getElementById('drpadcat5').options.length=0;
               document.getElementById('drpadcat5').options[0]=new Option("Select","0");
                for (var k = 0; k < dbt.Tables[0].Rows.length; k++)
                {
                     document.getElementById('drpadcat5').options[document.getElementById('drpadcat5').options.length] = new Option(dacat.Tables[0].Rows[k].Cat_Name,dacat.Tables[0].Rows[k].Cat_Code);                    
                     document.getElementById('drpadcat5').options.length; 
                }
            }
            if(executequery.Tables[0].Rows[rownumEx].Ad_subcat5!=null)
            {
                document.getElementById('hiddenadscat5').value = document.getElementById('drpadcat5').value = executequery.Tables[0].Rows[rownumEx].Ad_subcat5;
            }    

            
            if(executequery.Tables[0].Rows[rownumEx].RETAINER1!=null)
            {
                document.getElementById('drpretainer').value = executequery.Tables[0].Rows[rownumEx].RETAINER1;
            }    
            if(executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM!=null)
            {
                 if(document.getElementById('txtaddagencycommrate')!=null)
                 {
                    document.getElementById('txtaddagencycommrate').value = executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM;
                  }  
             }   
          
            //grid
            updateStatus();            
            showcardinfo(executequery.Tables[0].Rows[rownumEx].Bill_pay);
            showgridexecute();
        
            if (document.getElementById('txtadsize1').value != "" && document.getElementById('txtcolum').value != "")
            {
                document.getElementById('txtadsize2').disabled =true;
                document.getElementById('txtadsize1').style.backgroundColor="#FFFFFF";
                document.getElementById('txtadsize2').style.backgroundColor="#FFFFFF";
                document.getElementById('txtcolum').style.backgroundColor="#FFFFFF";

            }
            else if (document.getElementById('txtadsize1').value != "" && document.getElementById('txtadsize2').value != "")
            {
                document.getElementById('txtcolum').disabled=true;
                document.getElementById('txtadsize1').style.backgroundColor="#FFFFFF";
                document.getElementById('txtadsize2').style.backgroundColor="#FFFFFF";
                document.getElementById('txtcolum').style.backgroundColor="#FFFFFF";

            }
       }
       return false; 
    }
 
    function checknumeric(evt)
    {
        var charCode = event.keyCode

        if((charCode>=48 && charCode<=57) || (charCode>=96 && charCode<=105)||(charCode==127)||(charCode==8)||(charCode==9)||(charCode==46))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

function nodateentry(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode
    if(charCode>=0 && charCode<=1000)
        //document.getElementById('txtdummydate').value="";
        return false;
}

function onRepeatingDate()
{
    if(document.getElementById('txtinsertion').value=="0")
    {
         alert("Insertion can't be 0");
         return false;
    }
    if(document.getElementById('txtdummydate').value=="")
    {
        alert("Please enter Date");
        document.getElementById('txtdummydate').focus();
        return false;
    }
    document.getElementById('txtgrossamt').value='';
    var adcat3=document.getElementById('drpadcat3').value;
    var adcat4=document.getElementById('drpadcat4').value;
    var adcat5=document.getElementById('drpadcat5').value;
    var clientname=document.getElementById('txtclient').value;
    var client_split;
    if(clientname.indexOf("(")>=0)
    {
         clientname=clientname.split("(");
         client_split=clientname[1];
         client_split=client_split.replace(")","");
         clientname=client_split;
    }
//////////////this code is to split the code as well as ites description 
    
    ///////this is to get the value into paid ins. text b0x
    if(document.getElementById('txtpaid').value!="")
    {
        var paidno=document.getElementById('txtpaid').value;
        var valinsert=document.getElementById('txtinsertion').value;
        document.getElementById('txtpaid').value=(parseInt(valinsert)-parseInt(paidno))+parseInt(paidno);
    }
    
    var objpack=document.getElementById('drppackagecopy');
    var temp="";
    var tempcode="";
    var tempval="";
    var tempvalcode="";
    var desc="";
    var code="";
    var i=objpack.options.length;
    var j;

    for(j=0;j<i;j++)
    {
        if(parseInt(i)>0)
        {
            tempval=objpack[j].value;
            if(temp!="")
            {
                temp=tempval.split("@");
                tempvalcode=temp[0];
                tempcode=temp[1];
                code=tempvalcode+","+code;
                desc=tempcode+","+desc;
             }
             else
             {
                temp=tempval.split("@");
                tempvalcode=temp[0];
                tempcode=temp[1];
                code=tempvalcode;
                desc=tempcode;
            }
        }
    }
    
    if(document.getElementById('txtrepeatingdate').value!="")
    {   
        var insertval=document.getElementById('txtinsertion').value
        if(parseInt(document.getElementById('txtinsertion').value)==1)
        {
            if(document.getElementById('drppackagecopy').options.length>0)
            {
                for(var insertCou=0;insertCou<document.getElementById('drppackagecopy').options.length;insertCou++)
                {
                    if(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')>=0)
                    {
                        var tinsert=document.getElementById('drppackagecopy').options[insertCou].value.substring(document.getElementById('drppackagecopy').options[insertCou].value.indexOf('(')+1,document.getElementById('drppackagecopy').options[insertCou].value.indexOf(')'));
                        if (tinsert>1)
                            break;
                    }    
                }
            } 
            if (tinsert<=1)  
            {
                document.getElementById('txtrepeatingdate').value="";
                return false;
            }
        }
       
        repeatdate="1";
        suboradd="1";
    }
    else
    {
        repeatdate="0";
        suboradd="1";
    }
    if(parseInt(previnsertion)>parseInt(document.getElementById('txtinsertion').value))
    {
        repeatdate="1";
        suboradd="0";
    }
    if(repeatdate=="1")
    {
       //document.getElementById('tblinsert').innerHTML="";
       subtractrow="";
    }
     if(parseInt(document.getElementById('txtinsertion').value)>parseInt(previnsertion))
     {
        suboradd="1";
     }

    var insert=document.getElementById('hiddeninserts').value;
    var class_insert=document.getElementById('txtinsertion').value;
 
    var center="0";

    var lines_to;
    if(document.getElementById('txtadsize1').disabled==false)
    {
        lines_to="";
    }
    else
    {
        lines_to=document.getElementById('txttotalarea').value;
    } 
    var res=Booking_Master_temp.getData(desc,document.getElementById('txtinsertion').value,document.getElementById('txtrepeatingdate').value,document.getElementById('txtdummydate').value,document.getElementById('hiddendateformat').value,document.getElementById('hiddencompcode').value,document.getElementById('drpadcategory').value,document.getElementById('drpadsubcategory').value,document.getElementById('drpcolor').value,"CL0",document.getElementById('drpcurrency').value,document.getElementById('txtratecode').value,document.getElementById('hiddenclickdate').value,insert,code,document.getElementById('txtcardrate').value,document.getElementById('drpuom').value,document.getElementById('txtdealrate').value,check_or,class_insert,lines_to,adcat3,adcat4,adcat5,clientname); //,callback_repeatingdate);
    var ds=res.value;
    var i=0;   
    var inew=0;
    for(inew=0;inew<=ds.Tables[0].Rows.length-1;inew++)
    {        
        var dCheck=checkValidEdition(ds.Tables[0].Rows[inew].Edition_Name);
        if(dCheck==true)
        {
        var val_ue="1";
        var pkg_id="0";
        var strtext="";
        pkg_id=document.getElementById('hiddenpckcode'+i).value;
        var pkgalias=document.getElementById('pkg_alias'+i).value;
        var pkgname=document.getElementById("edit"+i).value;
        pkgname=pkgname.replace("+","^");
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType)
            {
                httpRequest.overrideMimeType('text/xml'); 
            }
        
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
            var adcat=document.getElementById('drpadcategory').value;
            httpRequest.open( "GET","packagename.aspx?pkgalias="+pkgalias+"&adcat="+adcat+"&pkgid="+pkg_id+"&compcode="+document.getElementById('hiddencompcode').value+"&value="+val_ue+"&dateday="+ds.Tables[0].Rows[inew].Date+"&pkgname="+ds.Tables[0].Rows[inew].Edition_Name, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtext=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
            validuse="";
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            var adcat=document.getElementById('drpadcategory').value;
            xml.Open( "GET","packagename.aspx?pkgalias="+pkgalias+"&adcat="+adcat+"&pkgid="+pkg_id+"&compcode="+document.getElementById('hiddencompcode').value+"&value="+val_ue+"&dateday="+ds.Tables[0].Rows[inew].Date+"&pkgname="+ds.Tables[0].Rows[inew].Edition_Name, false );
            xml.Send();
            strtext=xml.responseText;
        }

        if(strtext!="" && strtext!="1" && strtext!="0" && strtext!=null)
        {
            if(document.getElementById("Text" + i)!=null)
            {
                document.getElementById("Text" + i).value=strtext;
            }    
               for(y=i+1;y<ds.Tables[0].Rows.length;y++)
               {
                    if(ds.Tables[0].Rows[y].Edition_Name==ds.Tables[0].Rows[inew].Edition_Name)
                    {
                         var mm,dd,yy;
                        if (document.getElementById("hiddendateformat").value == "dd/mm/yyyy")
                        {
                             var dk1=ds.Tables[0].Rows[y].Date.split("/")
                             var dk1=ds.Tables[0].Rows[y].Date.split("/")
                             dt=new Date(dk1[1] + '/' + dk1[0] + '/' + dk1[2]);
                             dt.setDate(dt.getDate() + 1);
                             if(dt.getDate().toString().length==1)
                                dd="0" + dt.getDate().toString();
                             else
                                 dd=dt.getDate().toString();
                                 
                              if((dt.getMonth()+1).toString().length==1)
                                mm="0" + (dt.getMonth()+1).toString();
                             else
                                 mm=(dt.getMonth()+1).toString();
                                 
                                yy=dt.getFullYear().toString();
                             ds.Tables[0].Rows[y].Date=dd + '/' + mm + '/' + yy;
                        }
                        if (document.getElementById("hiddendateformat").value == "mm/dd/yyyy")
                        {
                              dt=new Date(ds.Tables[0].Rows[y].Date);
                              dt.setDate(dt.getDate() + 1);
                              if(dt.getDate().toString().length==1)
                                dd="0" + dt.getDate().toString();
                             else
                                 dd=dt.getDate().toString();
                                 
                              if((dt.getMonth()+1).toString().length==1)
                                mm="0" + (dt.getMonth()+1).toString();
                             else
                                 mm=(dt.getMonth()+1).toString();
                                 
                                yy=dt.getFullYear().toString();
                                
                              ds.Tables[0].Rows[y].Date=mm + '/' + dd + '/' + yy;
                        }
                        if (document.getElementById("hiddendateformat").value == "yyyy/mm/dd")
                        {
                             var dk1=ds.Tables[0].Rows[y].Date.split("/")
                              dt=new Date(dk1[2] + '/' + dk1[1] + '/' + dk1[0]   );
                              dt.setDate(dt.getDate() + 1);
                              if(dt.getDate().toString().length==1)
                                dd="0" + dt.getDate().toString();
                             else
                                 dd=dt.getDate().toString();
                                 
                              if((dt.getMonth()+1).toString().length==1)
                                mm="0" + (dt.getMonth()+1).toString();
                             else
                                 mm=(dt.getMonth()+1).toString();
                                 
                                yy=dt.getFullYear().toString();
                                
                              ds.Tables[0].Rows[y].Date=yy + '/' + mm + '/' + dd ;
                        }       
       
                    }
               }
               
       }
       else
       {
            if(document.getElementById("Text" + i)!=null)
            {
                if(ds.Tables[0].Rows[inew].Date==null)
                    ds.Tables[0].Rows[inew].Date="";
                document.getElementById("Text" + i).value=ds.Tables[0].Rows[inew].Date;
            }
       }     
       i=parseInt(i,10)+1;
      } 
    }
}

//cancel the booked ad
function deleteCheck()
{
    if(document.getElementById('txtciobookid').value=="")
    {
        alert("Please Enter Booking Id");
        return false;
    }
    if(confirm("Do You Want To Delete the Booking"))
    {
        Booking_Master_temp.deleteBooking(document.getElementById('txtciobookid').value);
        alert("Booking Deleted Successfully");
        clearClick();
        return false;
    }
    else
    {
        return false;
    }
}
	function keySort(dropdownlist,caseSensitive) {
  // check the keypressBuffer attribute is defined on the dropdownlist 
      var undefined; 
      if (dropdownlist.keypressBuffer == undefined) { 
        dropdownlist.keypressBuffer = ''; 
      } 
      // get the key that was pressed 
      var key = String.fromCharCode(window.event.keyCode); 
      dropdownlist.keypressBuffer += key;
      if (!caseSensitive) {
        // convert buffer to lowercase
        dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
      }
      // find if it is the start of any of the options 
      var optionsLength = dropdownlist.options.length; 
      for (var n=0; n<optionsLength; n++) { 
        var optionText = dropdownlist.options[n].text; 
        if (!caseSensitive) {
          optionText = optionText.toLowerCase();
        }
        if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
          dropdownlist.selectedIndex = n; 
           if(document.activeElement.id=="drpadcategory")
            filladsubcatmain();
           else if(document.activeElement.id=="drpadsubcategory")
            filladscatingrid();
           else if(document.activeElement.id=="drpadcat3")
            bindadscat4();
           else if(document.activeElement.id=="drpadcat4")
            bindadcat5();
           
                
         return false; // cancel the default behavior since 
                        // we have selected our own value 
        } 
      } 
      // reset initial key to be inline with default behavior 
      dropdownlist.keypressBuffer = key; 
     
      return true; // give default behavior 
} 
function chkDateforGrid()
 {
    if(document.activeElement.id.indexOf("Text")==0 && document.activeElement.id.value!="")
    {
        var validformat='';
        var dateformat=document.getElementById('hiddendateformat').value;
        if(dateformat=="mm/dd/yyyy")
         {
             validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
         }
         if(dateformat=="yyyy/mm/dd")
         {
             validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
         }
         if(dateformat=="dd/mm/yyyy")
         {
             validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
         }
        
        var activeID=document.activeElement.id;
		var currdate=document.getElementById(activeID).value;
		var fromdate=document.getElementById('txtdatetime').value;
		var todate=currdate;
		 if (!validformat.test(currdate))
          {
            alert(" Please Fill The Date In "+dateformat+" Format");
            document.getElementById(activeID).value="";
           // document.getElementById(activeID).focus();
            return false;
          }
		//
		
		//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                var txt=fromdate;
                 var txt1;
                if(txt.indexOf("-")>=0)
                {
                     txt1=txt.split("-");
                }
                else{
                    txt1=txt.split("/");
                }
               
                var dd=txt1[0];
                var mm1=txt1[1];
                var mm;
                 if(txt.indexOf("-")>=0)
                 {
                     mm = getMonthNo(mm1);
                }
                else
                {
                    mm=mm1;
                }
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(fromdate!="")
            {
                var txt=fromdate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            fromdate=fromdate;
        }
        
        //For From Date Converssion /************************************************************/
        if(dateformat=="dd/mm/yyyy")
        {
            if(todate != "")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(todate!="")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            todate=todate;
        }
		//
		
		
		
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		if(tdate<fdate && (document.getElementById('hiddenbackdatebook').value=="0" || document.getElementById('hiddenbackdatebook').value=="N"))
		{
		    document.getElementById(activeID).value="";
		alert("Published Date can't Be Less than Current Date");
		dummydate=tempdate;
		document.getElementById(activeID).focus();
		return false;
		}
		// check valid date for grid item line
		validDate_Grid(activeID);
	}	
	  
	//	return false;
 }
  function validDate_Grid(name)
  {
       var compcode=document.getElementById('hiddencompcode').value;
                  //var strid1=strid.split('@');
                var  gtid=name.substring(4,name.length);
                editid="edit"+gtid;
                  var pkgid=document.getElementById('hiddenpckcode'+gtid).value;
                  var pkgalias=document.getElementById('pkg_alias'+gtid).value;
                  var pkgname=document.getElementById(editid).value;
                  pkgname=pkgname.replace("+","^");
                  var value="1";
                  var dateday=document.getElementById(name).value;
                  
                  var strtext="";
                  center='0';
                  if(document.getElementById('chkall')!=null)
                  {
                      if(document.getElementById('chkall').checked==false)
                      {
                        center=document.getElementById('hiddencenter').value;
                      }
                      else
                      {
                        center='0';
                      }
                  }    
                  
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
                    var adcat=document.getElementById('drpadcategory').value;
                    httpRequest.open( "GET","packagename.aspx?center="+center+"&adtype="+document.getElementById('hiddenadtype').value+"&pkgalias="+pkgalias+"&adcat="+adcat+"&pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&dateday="+dateday+"&pkgname="+pkgname, false );
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) 
                    {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) 
                        {
                            strtext=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                { 
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
                     var adcat=document.getElementById('drpadcategory').value;
                    xml.Open( "GET","packagename.aspx?center="+center+"&adtype="+document.getElementById('hiddenadtype').value+"&pkgalias="+pkgalias+"&adcat="+adcat+"&pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&dateday="+dateday+"&pkgname="+pkgname, false );
                    xml.Send();
                    strtext=xml.responseText;   
                }
               
                if(strtext=="0")
                {
                    alert("Publication day doesnot match with day for Edition "+ pkgname);
                    document.getElementById(name).value=tempdate;
                  
                }    
               if(strtext!="1" && strtext!="0")    
                {
                    //document.getElementById(name).value=strtext;
                    setTimeout("changeText('"+name+"','"+strtext+"')",5);
                }
                else
                {
                    document.getElementById(name).value=document.getElementById(name).value;
                }
  }


  function changeText(th1,val)
  {
    document.getElementById(th1).value=val;
  }
function openSelectionEdiionDiv()
{
    //alert(document.getElementById('drppackage').left);
    //arrEdition_Item='';
    document.getElementById('showselectedition').innerHTML="";
    var pkg_edi=document.getElementById('drppackage').value.split('@')[1].split('+');
    var res=Booking_Master_temp.getPkgEdition(document.getElementById('hiddencompcode').value,document.getElementById('drppackage').value.split('@')[0]);
    var str="";
    var dFlag=true;
    if(res.value!=null && res.value!="")
    {
        document.getElementById('hiddenpkgedition').value=res.value;
        if(parseInt(res.value)!=pkg_edi.length)
        {
            str="<table width=100%>";
            for(var i=0;i<parseInt(pkg_edi.length);i++)
            {
                document.getElementById('showselectedition').style.left=180;
                document.getElementById('showselectedition').style.top=420;
                str=str + "<tr><td><input type=checkbox id='chk"+i+"' onClick='editionClick(chk"+i+")'></td><td id='tdname"+i+"'>"+pkg_edi[i]+"</td></tr>";
               
            }
            str=str + "<tr valign=bottom><td ><input type=button value='OK' class='topbutton' style='width:30px' onClick='okEditionClick();'></td><td><input type=button class=topbutton value='Cancel' onClick='closeClick();'></td></tr></table>";
            document.getElementById('showselectedition').innerHTML=str;
            document.getElementById('showselectedition').style.display="block";
            dFlag=false;
        }
        else
        {
            for(var i=0;i<parseInt(pkg_edi.length);i++)
            {
                if(arrEdition_Item!="")
                {
                    arrEdition_Item = arrEdition_Item + "," + pkg_edi[i];
                }
                else
                {
                    arrEdition_Item = pkg_edi[i];
                }
            }   
        }
    }
    return dFlag;
}
function editionClick(activeid)
{var i=0;
var count=0;
    for(i=0;i<document.getElementById('showselectedition').getElementsByTagName("TBODY")[0].rows.length-1;i++)
    {
        if(document.getElementById('chk'+i).checked==true)
            count=parseInt(count,10)+1;
    }
    if(count>parseInt(document.getElementById('hiddenpkgedition').value))
    {
        alert("You Can't Select More Editions");
        activeid.checked=false;
        return false;
        
    }
//document.getElementById('showselectedition').getElementsByTagName("tbody")[0].appendChild(Make_Row);
}
function closeClick()
{
    document.getElementById('showselectedition').style.display='none';
}
function okEditionClick()
{
    var i=0;
    var count=0;
    
    for(i=0;i<document.getElementById('showselectedition').getElementsByTagName("TBODY")[0].rows.length-1;i++)
    {
        if(document.getElementById('chk'+i).checked==true)
        {
            count=parseInt(count,10)+1;
            if(arrEdition_Item=='')
                arrEdition_Item=trim(document.getElementById('tdname'+i).innerHTML);
            else
                arrEdition_Item=trim(arrEdition_Item) + ',' + trim(document.getElementById('tdname'+i).innerHTML);
        }    
    }
    if(count>parseInt(document.getElementById('hiddenpkgedition').value) || count<parseInt(document.getElementById('hiddenpkgedition').value))
    {
        alert("Please Select "+document.getElementById('hiddenpkgedition').value+" Editions.");
        return false;
        
    }
    bindGrid_Edition();
    document.getElementById('showselectedition').style.display='none';
}
function bindGrid_Edition()
{
     var obj=document.getElementById('drppackagecopy');
    for(var x=0;x<obj.options.length;x++)
    {
        if(document.getElementById('drppackage').value==obj[x].value.substring(0,obj[x].value.indexOf('(')))
        {
           // alert("This package is already shifted");
           var insertCount = 1;
           if(obj[x].value.indexOf('(')>=0)
           {
                insertCount=obj[x].value.substring(obj[x].value.indexOf('(')+1,obj[x].value.length-1);
           }
           insertCount=parseInt(insertCount) + 1;
           obj[x].value = obj[x].value.substring(0,obj[x].value.indexOf('(')) + '('+insertCount+')';
           obj[x].text =  obj[x].text.substring(0,obj[x].text.indexOf('(')) + '('+insertCount+')';
           onInsertionChange();
           return false;
        }
    }
    var strid = document.getElementById('drppackage').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var strid1=strid.split('@');
    var pkgid=strid1[0];
    var pkgname=strid1[1];
    glpkgname=pkgname;
    var value="0";
    var dateday="";
    var strtext="";
    var code="";
    var desc="";    
    
    if(browser!="Microsoft Internet Explorer")
    {
         var  httpRequest =null;
         httpRequest= new XMLHttpRequest();
         if (httpRequest.overrideMimeType) 
         {
            httpRequest.overrideMimeType('text/xml'); 
         }
            
         httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
         var adcat=document.getElementById('drpadcategory').value;
         httpRequest.open( "GET","packagename.aspx?adcat="+adcat+"&pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
         httpRequest.send('');
         
         if (httpRequest.readyState == 4) 
         {
             if (httpRequest.status == 200) 
             {
                  strtext=httpRequest.responseText;
             }
             else 
             {
                 alert('There was a problem with the request.');
             }
          }
      }
      else
      { 
           var xml = new ActiveXObject("Microsoft.XMLHTTP");
           var adcat=document.getElementById('drpadcategory').value;
           xml.Open( "GET","packagename.aspx?adcat="+adcat+"&pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
           xml.Send();
           strtext=xml.responseText;
      }
      document.getElementById('pkgname').value=strtext;
      if(document.getElementById('drppackagecopy').options.length == 0)
      {
          che_flag = 0;
      }
      if(che_flag == 1)
      {
            alert("Can't select multiple Package");
            return false;
      }
      else if((document.getElementById('drppackagecopy').options.length>0) && (pkgname.indexOf(" or ")>=0))
      {
            alert("Can't select this Package");
            return false;
      }
      else
      {
        if(pkgname.indexOf(" or ")>=0)
        {  
             che_flag=1;
             Booking_Master_temp.bindTable(pkgname,bindTable_callback);
             check_or="1";
        }
        var val_="";
        var agencytype="DI0"; // document.getElementById('drpadtype').value;
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) 
            {
                httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","gettheinsertionfromcombin.aspx?desc="+glpkgname+"&code="+pkgid+"&agencytype="+agencytype, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    val_=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","gettheinsertionfromcombin.aspx?desc="+glpkgname+"&code="+pkgid+"&agencytype="+agencytype, false );
            xml.Send();
            val_=xml.responseText;            
        }
              
        if(val_!="" && val_!="0" && val_!=null)
        {
            document.getElementById('txtinsertion').value=val_
        }
        
        if(che_flag == 0)
        {
            if(strtext!="0")
            {
                AddItem(document.getElementById('drppackagecopy'), strtext, strid);
            }
            document.getElementById('txtdummydate').focus();
        }
        }
      
   // document.getElementById('drpuom').focus();
    document.getElementById('txtgrossamt').value="";
    return false;
}
function checkValidEdition(editionName)
{
    var bFlag=false;
    if(arrEdition_Item!="")
    {
        var arr_split=arrEdition_Item.split(',');   
        for(var i=0;i<arr_split.length;i++)
        {
             if(trim(arr_split[i])==trim(editionName))
            {
                bFlag=true;
                break;
            }
        }
    }
    else
        bFlag=true;
   return bFlag;
}
	function changepackage()
		{	
		    if(document.getElementById('LinkButton5').disabled==true)
		        return false;
		   
		    if(document.getElementById('LinkButton5').disabled==false)
		    {
				if(document.getElementById('txtagency').value=="")
		        {
		            alert("Please fill the Agency Sub Code");
		            document.getElementById('txtagency').focus();
		            return false;
		        }
		        else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
		        {
		            alert("Please select the Agency Sub Code");
		            document.getElementById('drpagscode').focus();
		            return false;
		
		        }
		        if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
                {
                    if(document.getElementById('txtrodate').value=="")
                    {
                        alert("Please fill ro date");
                        document.getElementById('txtrodate').focus();
                        return false;            
                    }
                }
    //*25Aug* check for retainer or Executive
    if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
    {
        alert('Please fill Execute Name or Retainer.');
        document.getElementById('drpretainer').focus();
        return false;
    }
                if(document.getElementById('drpbooktype').value=="0")
{
    alert("Please Select Booking Type");
    return false;
}    
if(document.getElementById('drpcolor').value=="0")
{
    alert("Please Select Color");
    return false;
}   
if(document.getElementById('drpadcategory').value=="0")
{
    alert("Please Select Ad Category");
    return false;
}   
if(document.getElementById('drpuom').value=="0")
{
    alert("Please Select UOM");
    return false;
}  

		        document.getElementById('LinkButton5').style.fontWeight="bold";
		        document.getElementById('LinkButton5').style.color="#FFFF80";
		        document.getElementById('LinkButton1').style.fontWeight="normal";
		        document.getElementById('LinkButton1').style.color="White";
		        document.getElementById('LinkButton2').style.fontWeight="normal";
		        document.getElementById('LinkButton2').style.color="White";
		        document.getElementById('LinkButton3').style.fontWeight="normal";
		        document.getElementById('LinkButton3').style.color="White";
		        document.getElementById('LinkButton4').style.fontWeight="normal";
		        document.getElementById('LinkButton4').style.color="White";
		        document.getElementById('LinkButton6').style.fontWeight="normal";
		        document.getElementById('LinkButton6').style.color="White";
		        document.getElementById('LinkButton7').style.fontWeight="normal";
		        document.getElementById('LinkButton7').style.color="White";
		        //alert(document.getElementById('LinkButton1').click);
		        document.getElementById('tblrate').style.display="none";
		        document.getElementById('tblbill').style.display="none";
		        //document.getElementById('tblsize').style.display="none";
		        document.getElementById('addetails').style.display="none";
        		
		        document.getElementById('pagedetail').style.display="none";
		        document.getElementById('tblpackage').style.display="block";
		        if(document.getElementById('chkcoupan').disabled==false)
		        {
		            document.getElementById('chkcoupan').focus();
		        }
		        document.getElementById('tbbox').style.display="none";
		        document.getElementById('tbvts').style.display="none";
//		if(document.getElementById('txtrepeatingdate').value!="")
//		{
//		onInsertionChange();
//		}
		 if(document.getElementById('drpcolor').value=="0" || document.getElementById('drpcolor').value=="" )
		    {
		      //  alert('Please select Color.');
		        changediv();
		      //  document.getElementById('drpcolor').focus();
		        return false;
		    }
		    if(document.getElementById('drpadcategory').value=="0" || document.getElementById('drpadcategory').value=="" )
		    {
		      //  alert('Please select category.');
		        changediv();
		      //  document.getElementById('drpadcategory').focus();
		        return false;
		    }
		    if(document.getElementById('drpuom').value=="0" || document.getElementById('drpuom').value=="" )
		    {
		       // alert('Please select UOM.');
		        changediv();
		     //   document.getElementById('drpuom').focus();
		        return false;
		    }
		    	    
		    if(enLink=="1")
            {
                document.getElementById('LinkButton1').disabled=false;
                document.getElementById('LinkButton2').disabled=false;
                document.getElementById('LinkButton3').disabled=false;
                document.getElementById('LinkButton4').disabled=false;
                document.getElementById('LinkButton5').disabled=false;
                document.getElementById('LinkButton6').disabled=false;
                document.getElementById('LinkButton7').disabled=false;
            }
		
		//popUpCalendar(this, Form1.txtdummydate, 'mm/dd/yyyy');
		//if()
		        return false;    
		    }
		}
			
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
	function checkTrade()
	{
	 if(document.getElementById('txttradedisc').value!="" && document.getElementById('txtgrossamt').value=="")
	    {
	        document.getElementById('txttradedisc').value=document.getElementById('hiddentradedisc').value;
	    }
	    if(document.getElementById('txttradedisc').value!="" && document.getElementById('hiddentradedisc').value!="")
	    {
	        if(parseFloat(document.getElementById('txttradedisc').value)>parseFloat(document.getElementById('hiddentradedisc').value))
	        {
	            alert("Agency Commission can't be greater than " + document.getElementById('hiddentradedisc').value);
	            document.getElementById('txttradedisc').value = document.getElementById('hiddentradedisc').value;
	            return false;
	        }
	        if(document.getElementById('txtcardamt').value!="" && document.getElementById('txttradedisc').value!="")
            {
                var caramt=document.getElementById('txtgrossamt').value;
                var tradisc=document.getElementById('txttradedisc').value;
                var trdisc1=tradisc;
                var addcomm =0;
                if(document.getElementById('txtaddagencycommrate')!=null)
                {
                    addcomm=document.getElementById('txtaddagencycommrate').value;
                }
                if(addcomm=="")
                {
                    addcomm="0";
                }
                if(addcomm!="0")
                {
                    trdisc1=parseInt(tradisc) + parseFloat(addcomm);
                }
                var tot=0;
                if(document.getElementById('agncomm_seq_com').value!="S")
                    tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(trdisc1)/100;
                else
                {
                    tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(trdisc1)/100;
                     if(addcomm!="0" && addcomm!="")
                    {
                         tot=parseFloat(tot)-parseFloat(tot)*parseFloat(addcomm)/100;
                    }
                } 
                document.getElementById('txtbillamt').value=tot.toFixed(2);
            }		        
	    }
	}
	
	
	
	function getRetainerCommAmt()
	{
	
	 if(document.getElementById('txtcardamt').value!="" && document.getElementById('txttradedisc').value!="")
        {
            var caramt=document.getElementById('txtgrossamt').value;
            var tradisc=document.getElementById('txttradedisc').value;
            if(tradisc=="")
                tradisc=0;
            var trdisc1=tradisc;
            var addcomm =0;
            if(document.getElementById('txtaddagencycommrate')!=null)
            {
                addcomm=document.getElementById('txtaddagencycommrate').value;
            }
            if(addcomm=="")
            {
                addcomm="0";
            }
            if(addcomm!="0")
            {
                trdisc1=parseInt(tradisc) + parseFloat(addcomm);
            }
            var tot=0;
            if(document.getElementById('agncomm_seq_com').value!="S")
                tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(trdisc1)/100;
            else
            {
                tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(tradisc)/100;
                if(addcomm!="0" && addcomm!="")
                    {
                          tot=parseFloat(tot)-parseFloat(tot)*parseFloat(addcomm)/100;
                    }
            }
            document.getElementById('txtbillamt').value=tot.toFixed(2);
        } 
	    if(document.getElementById('drpretainer').value=="" || document.getElementById('drpretainer').value=="0" ||  document.getElementById('txtRetainercomm').value=="")
	    {
	        document.getElementById('txtRetainercomm').value="";
	        document.getElementById('txtRetainercommamt').value="";
	    }
	   if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0")
        {
            
            document.getElementById('txtRetainercommamt').value="";
            if(parseFloat(document.getElementById('txtRetainercomm').value)>parseFloat(document.getElementById('retcomm').value))
            {
                alert("Retainer Commission can't be greater than " + document.getElementById('retcomm').value);
                document.getElementById('txtRetainercomm').value=document.getElementById('retcomm').value;
                
            }
              if(document.getElementById('retcommtype').value=="")
            {
                   var retain_name=document.getElementById('drpretainer').value.split('(');
                    var retain_code=retain_name[1].replace(')','');
                    var ds_ret=Booking_Master_temp.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
                    
                    if(ds_ret.value==null)
                        return false;
                       
                    if(ds_ret.value.Tables[0].Rows.length>0)
                    {
                        document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                        document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                     }   
            }
             if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
                else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
                else
                {
                     document.getElementById('txtRetainercommamt').value="";
                      document.getElementById('txtRetainercomm').value="";
                }
               
        }
}        

function getHeightWidth()
{
  var edition="";
  var objpack=document.getElementById('drppackagecopy');
   var i=objpack.options.length;
   if(i>0)
   {
    edition=objpack[0].value;
     var temp=edition.split("@");
     edition=temp[0];
   }
  else
  {
    document.getElementById('txtadsize1').focus();
    return false;
  }
    var res=Booking_Master_temp.getHeightWidth(document.getElementById('drpadcategory').value,document.getElementById('drpcolor').value,edition,document.getElementById('hiddencompcode').value,document.getElementById('drpadstype').value,document.getElementById('drpuom').value);
    if(res.value==null)
    {
        alert(res.error.description);
        return false;
    }
    var ds=res.value;
    if(ds!=null && ds.Tables[0].Rows.length>0)
    {
        document.getElementById('txtadsize1').value=ds.Tables[0].Rows[0].max_height;
        document.getElementById('txtadsize2').value=ds.Tables[0].Rows[0].max_width;
         document.getElementById('txttotalarea').value=parseFloat(document.getElementById('txtadsize1').value) * parseFloat(document.getElementById('txtadsize2').value);
         document.getElementById('txtadsize1').focus();
         
                 var len="bookdiv";
                 var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
                 var i=0;
                 var k;
                 var height;
                 var width;
                 var size;
                var h=document.getElementById('txtadsize1').value;
                var w=document.getElementById('txtadsize2').value;
                  for(k=0;i<y-1;k++)
                        {
	                            height="hei"+i;
                                width="wid"+i;
                                size="siz"+i;
                            if(document.getElementById(height)!=null)
                                {
	                                document.getElementById(height).value=h;
                                    document.getElementById(width).value=w;
                                    document.getElementById(size).value=parseFloat(h)*parseFloat(w);
                                 }
                                  i++;
                            }
    }
}



 function fillcopyfilename()
    {
    //logonam="lnam"+i
    
        if(document.getElementById("fil0")!=null && document.getElementById("fil0").value!="")
        {
            count=document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length-1;
            itemlinecnt=parseInt(count)/parseInt(document.getElementById('txtinsertion').value);
            count=count-itemlinecnt;
            filid=itemlinecnt;
            var filemidid=2;
            //var filelastid=parseInt(itemlinecnt)+1;
            var tCount=0;
            var counterT = 0;
            var ins_vari=document.getElementById('ins'+counterT);
             if(ins_vari!=null)
             {
                while(parseInt(ins_vari.innerHTML)=="1")
                {
                    tCount = parseInt(tCount) + 1;
                    counterT = parseInt(counterT) + 1;
                    ins_vari=document.getElementById('ins'+counterT);
                    if(ins_vari==null)
                        break;
                }       
             }   
         gridItemCount=tCount;  //get gridcount
         itemlinecnt=gridItemCount;
         
            for(var i=1;i<=count;i=i+itemlinecnt)
            {
                for(var j=0;j<itemlinecnt;j++)
                {
                    if(document.getElementById("fil"+filid).value=="")
                    {
                        //var arrfile=document.getElementById("fil"+j).value.split('-');
//                        if(arrfile.length>2)
//                        {
//                            var cioid=arrfile[0];
//                            var filenamenew=arrfile[0];
//                            filenamenew+="-"+filemidid;
//                            var filelastid=filid+1;
//                            filenamenew+="-"+filelastid+".xtg";
//                            document.getElementById("fil"+filid).value=filenamenew;
//                            
//                           
//                           
////                            var xml = new ActiveXObject("Microsoft.XMLHTTP");
////                           xml.Open( "GET","copyMatter.aspx?filename="+document.getElementById("fil"+j).value+"&copyfilename="+filenamenew+"&cioid="+cioid, false );
////                           xml.Send();
////                           strtext=xml.responseText;
//                        }
//                        else
//                        {
                        //alert(document.getElementById("fil"+filid).value)
                            document.getElementById("fil"+filid).value=document.getElementById("fil"+j).value;
                            
                      //  }
                        
                    }
                    filid=filid+1;
                }
                filemidid=filemidid+1;
            }
       
        }

       
    }
    function imagetget()
    {
        try
        {
            var filename=document.getElementById('FileUpload1').value;
            var fname="";
            var fso;
            fso = new ActiveXObject("Scripting.FileSystemObject");
            if(filename.lastIndexOf(".")>=0);
            {
                fname=document.getElementById('hiddenfilename').value + filename.substring(filename.lastIndexOf("."),filename.toString().length);
            }
            if(document.getElementById('hiddenIP').value!="")
            {
                var imgpath=document.getElementById('hiddenIP').value+fname;
                fso.CopyFile(filename,imgpath,true);
            }    
        }
       catch(err) {
        alert(err);
       }
       
        return true;
    }