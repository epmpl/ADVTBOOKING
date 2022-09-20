
var global_ds;
var popup;
var chk="0";;
var gladtype;
var show="0";
//this is for to check , to update
var modify;
var chknamemod;
//-------------------------------------------
var news=0;
//This is for to first previous next and last

var z=0;
//-----------------
//this flag is for permission
var flag="";

function Bindpackage()
{
uombind();
  var adtype=document.getElementById('txtadvtype').value;
  var compcode=document.getElementById('hiddencompcode').value;
  
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
         
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
           
            if (httpRequest.readyState == 4) 
            {
              
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                   
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
var res= Adsize_master.adduomAjax(compcode,adtype);    
var ds=res.value;
  if(ds==null)
 {
   alert(res.error.description);
   return false;
 }/*
 //document.getElementById('drpuomnew').options.length=0;
 document.getElementById('drpuomnew').options[0]=new Option("--Select UOM--","0");
 if(ds.Tables[0].Rows.length !=null && ds.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=ds.Tables[0].Rows.length-1;++i) 
	{
        document.getElementById('drpuomnew').options[i+1] = new Option("SHUBHAM", "SH0");//new Option(ds.Tables[0].Rows[i].Uom_Name, ds.Tables[0].Rows[i].Uom_Code);
		
	}
 }*/
  document.getElementById('drpuom').disabled = false;
  document.getElementById('drpuom').options[0] = new Option("-----Select UOM-----", "0");
  document.getElementById('drpuomnew').options[0] = new Option("-----Select UOM-----", "0");
 if (ds.Tables[0].Rows.length != null && ds.Tables[0].Rows.length > 0) {
     for (var i = 0; i <= ds.Tables[0].Rows.length - 1; ++i) {
         document.getElementById('drpuom').options[i + 1] = new Option(ds.Tables[0].Rows[i].Uom_Name, ds.Tables[0].Rows[i].Uom_Code);//drpuomnew
         document.getElementById('drpuomnew').options[i + 1] = new Option(ds.Tables[0].Rows[i].Uom_Name, ds.Tables[0].Rows[i].Uom_Code);//
         //name.options.length;
     }
 }
Adsize_master.packagebind(compcode,adtype,callback_bind);


 
}





function callback_bind(res)
{
 var ds=res.value;
 if(ds==null)
 {
   alert(res.error.description);
   return false;
 }
 
// var name=document.getElementById('drpedition');
// name.options.length=1;
 document.getElementById('drpedition').options[0]=new Option("-----Select Package-----","0");
 if(ds.Tables[1].Rows.length !=null && ds.Tables[1].Rows.length>0)
 {
    for(var i=0;i<=ds.Tables[1].Rows.length-1;++i) 
	{
		document.getElementById('drpedition').options[i+1]=new Option(ds.Tables[1].Rows[i].Package_Name,ds.Tables[1].Rows[i].Combin_Code);
		//name.options.length;
	}
//	if(gladtype == undefined || gladtype=="")
//     {
//      document.getElementById('drpedition').value="0";
//     
//     }
//     else
//     {
//      document.getElementById('drpedition').value=gladtype;
//      gladtype="";
//      } 	
 }
  else
 {
   document.getElementById('drpedition').options.length="0";
   document.getElementById('drpedition').options[0]=new Option("-----Select Package-----","0");
 }
 onchage_adtype();
 return false;
 
}

function newclick()
{
chk="n";
show="1";
				
document.getElementById('txtadvtype').value="0";
document.getElementById('lbadcategory').value="0";
document.getElementById('drpedition').value="0";
document.getElementById('txtadvsizecode').value="";
document.getElementById('txtadvdescription').value="";
document.getElementById('drpcolor').value="0";
document.getElementById('drpuom').value="0";
document.getElementById('txtremarks').value="";
document.getElementById('txtwidth1').value="";
//document.getElementById('txtwidth2').value="";
document.getElementById('txtheight1').value="";
document.getElementById('txtcol').value="";
//document.getElementById('txtheight2').value="";

document.getElementById('txtadvtype').disabled=false;
document.getElementById('lbadcategory').disabled=false;
document.getElementById('drpedition').disabled=false;
document.getElementById('txtadvsizecode').disabled=false;
document.getElementById('txtadvdescription').disabled=false;
document.getElementById('drpcolor').disabled=false;
document.getElementById('drpuom').disabled=false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('txtwidth1').disabled=false;
document.getElementById('txtcol').disabled=false;
//document.getElementById('txtwidth2').disabled=false;
document.getElementById('txtheight1').disabled=false;
//document.getElementById('txtheight2').disabled=false;
document.getElementById('txtadvtype').focus();
news="1";
modify="0";

chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
document.getElementById('btnNew').disabled = true;	
document.getElementById('btnQuery').disabled=true;
flag=0;
setButtonImages();
return false;
}

function submitclick()
{
document.getElementById('txtadvsizecode').value=trim(document.getElementById('txtadvsizecode').value);
document.getElementById('txtadvdescription').value=trim(document.getElementById('txtadvdescription').value);
if(document.getElementById('txtadvtype').value=="0")
{
alert("Please Select The Type");
document.getElementById('txtadvtype').focus();
return false;

}
else if(document.getElementById('lbadcategory').value=="0" || document.getElementById('lbadcategory').value=="")
{
alert("Please Select The Category");
document.getElementById('lbadcategory').focus();
return false;

}
else if(document.getElementById('drpedition').value=="0" || document.getElementById('drpedition').value=="")
{
alert("Please Select The Package");
document.getElementById('drpedition').focus();
return false;

}
else if(document.getElementById('drpedition').value=="0")
{
alert("Please Select The Edition");
document.getElementById('drpedition').focus();
return false;
}
else if(document.getElementById('txtadvsizecode').value=="")
{
alert("Please Select The Size Code");
document.getElementById('txtadvsizecode').focus();
return false;
}
else if(document.getElementById('txtadvdescription').value=="")
{
alert("Please Select The Description");
document.getElementById('txtadvdescription').focus();
return false;
}
else if(document.getElementById('drpcolor').value=="0")
{
 var saurabh_ag="";
if(browser!="Microsoft Internet Explorer")
    {
        saurabh_ag=document.getElementById('Label12').textContent;
    }
    else
    {
       saurabh_ag=document.getElementById('Label12').innerText;
    }
    if(saurabh_ag.indexOf('*')>=0)
	{
	  if(document.getElementById('drpcolor').value=="0" || document.getElementById('drpcolor').value=="")
	   {
            alert("Please Select The Color");
            document.getElementById('drpcolor').focus();
            return false;
       }
    }
}


else if (document.getElementById('drpuom').value == "0")
{
alert("Please Select The UOM");
document.getElementById('drpuom').focus();
return false;
}

//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 


if(modify == "1")
{
     var compcode=document.getElementById('hiddencompcode').value;
     var userid=document.getElementById('hiddenuserid').value;
     var advsizecode=document.getElementById('txtadvsizecode').value;
     var description=document.getElementById('txtadvdescription').value;
      if(chknamemod==document.getElementById('txtadvdescription').value)
      {
        updateadsize();
      }
      else
      {
        Adsize_master.checksizecode(description,advsizecode,compcode,userid,call_modifyclick);
        return false;
      }

}
else {

    if (document.getElementById('drpuom').value == "0")
{
alert("Please Select The UOM");
document.getElementById('drpuom').focus();
return false;
}
    var advtype=document.getElementById('txtadvtype').value;
    var badcategory=document.getElementById('lbadcategory').value;
    var edition=document.getElementById('drpedition').value;
    var advsizecode=document.getElementById('txtadvsizecode').value;
    var description=document.getElementById('txtadvdescription').value;
    var color=document.getElementById('drpcolor').value;
    var uom=document.getElementById('drpuom').value;
    var remarks=trim(document.getElementById('txtremarks').value);
    var width1=document.getElementById('txtwidth1').value;
    //var width2=document.getElementById('txtwidth2').value;
    var height1=document.getElementById('txtheight1').value;
    var col=document.getElementById('txtcol').value;
    //var height2=document.getElementById('txtheight2').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;

    Adsize_master.checksizecode(description,advsizecode,compcode,userid,saveclick);
    return false;
 }
}

//---------------------------------------------------------------------//

function call_modifyclick(response)
{
    var ds=response.value;
    if(ds.Tables[1].Rows.length > 0)
    {
        alert("This Description  Has Been Assigned");
        return false;
    }
    updateadsize();
}

function updateadsize()
{
    chk="u";
    var advtype=document.getElementById('txtadvtype').value;
    var advsizecode=document.getElementById('txtadvsizecode').value;
    var description=document.getElementById('txtadvdescription').value;
    var color=document.getElementById('drpcolor').value;
    var uom=document.getElementById('drpuom').value;
    var remarks=document.getElementById('txtremarks').value;
    var width1=document.getElementById('txtwidth1').value;
    var height1=document.getElementById('txtheight1').value;
     var col=document.getElementById('txtcol').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;

//============================================================================//
var length=document.getElementById('lbadcategory').options.length;
 var abc = "";
        for(var li=0;  li< length; li++)
        {

            if (document.getElementById('lbadcategory').options[li].selected == true)
            {
                if (document.getElementById('lbadcategory').options[li].value != "")
                {
                    if(abc=="")
                        abc=document.getElementById('lbadcategory').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('lbadcategory').options[li].value;
                }

            }
        }
  var badcategory=abc;
        
//  ----------------- for package--------------------------//

var pckglen=document.getElementById('drpedition').options.length;
 var choose = "";
        for(var li1=0;  li1< pckglen; li1++)
        {
           if (document.getElementById('drpedition').options[li1].selected == true)
            {
                if (document.getElementById('drpedition').options[li1].value != "")
                {
                    if(choose=="")
                        choose=document.getElementById('drpedition').options[li1].value;
                    else
                        choose = choose + "," + document.getElementById('drpedition').options[li1].value;
                }
            }
        }
 var edition=choose;
//============================================================================//

    Adsize_master.update(advtype,badcategory,edition,advsizecode,description,color,uom,remarks,width1,"",height1,"",compcode,userid,col);
    flag=0;
    updateStatus();
    alert("Data Updated Successfully");
       
    global_ds.Tables[0].Rows[z].Adv_size_code=document.getElementById('txtadvsizecode').value;
	global_ds.Tables[0].Rows[z].Adv_type=document.getElementById('txtadvtype').value;
	global_ds.Tables[0].Rows[z].Adv_category=badcategory
	global_ds.Tables[0].Rows[z].edition=edition
	global_ds.Tables[0].Rows[z].Adv_Size_description=document.getElementById('txtadvdescription').value;
	
	global_ds.Tables[0].Rows[z].color=document.getElementById('drpcolor').value;
	global_ds.Tables[0].Rows[z].uom=document.getElementById('drpuom').value;
	global_ds.Tables[0].Rows[z].remarks=document.getElementById('txtremarks').value;
	global_ds.Tables[0].Rows[z].max_width=document.getElementById('txtwidth1').value;
	global_ds.Tables[0].Rows[z].max_height=document.getElementById('txtheight1').value;
	global_ds.Tables[0].Rows[z].COLOUMN=document.getElementById('txtcol').value;
     if (z==0)
        {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=false;
    	document.getElementById('btnlast').disabled=false;
        
        }
        else if(z==(global_ds.Tables[0].Rows.length-1))
        {
         document.getElementById('btnnext').disabled=true;
    	document.getElementById('btnlast').disabled=true;
    	 document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        }
        
        
        if(global_ds.Tables[0].Rows.length==1)
        {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=true;
    	document.getElementById('btnlast').disabled=true;
        }	
    show="0";
					
    document.getElementById('txtadvtype').disabled=true;
    document.getElementById('lbadcategory').disabled=true;
    document.getElementById('drpedition').disabled=true;
    document.getElementById('txtadvsizecode').disabled=true;
    document.getElementById('txtadvdescription').disabled=true;
    document.getElementById('drpcolor').disabled=true;
    document.getElementById('drpuom').disabled=true;
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtwidth1').disabled=true;
    document.getElementById('txtheight1').disabled=true;
    document.getElementById('txtcol').disabled=true;
    setButtonImages();
     return false;
}
//====================bhati==========================//
function chkheight()
{
var num=document.getElementById('txtheight1').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtheight1').value="";
document.getElementById('txtheight1').focus();

return false; 
}
}

function chkwidth()
{
var num=document.getElementById('txtwidth1').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtwidth1').value="";
document.getElementById('txtwidth1').focus();

return false; 
}
}


function onchage_adtype()
{
  var adtype=document.getElementById('txtadvtype').value;
  var compcode=document.getElementById('hiddencompcode').value;
  //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Adsize_master.addlistbox(compcode,adtype,callback_bind1);
  }
  
  
function callback_bind1(res1)
{
 var ds=res1.value;
 if(ds==null)
 {
   alert(res1.error.description);
   return false;
 }
 
// var name=document.getElementById('drpedition');
// name.options.length=1;
 document.getElementById('lbadcategory').options[0]=new Option("-----Select Category-----","0");
 if(ds.Tables[0].Rows.length !=null && ds.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=ds.Tables[0].Rows.length-1;++i) 
	{
		document.getElementById('lbadcategory').options[i+1]=new Option(ds.Tables[0].Rows[i].adv_cat_name,ds.Tables[0].Rows[i].adv_cat_code);
		//name.options.length;
	}
//	if(gladtype == undefined || gladtype=="")
//     {
//      document.getElementById('drpedition').value="0";
//     
//     }
//     else
//     {
//      document.getElementById('drpedition').value=gladtype;
//      gladtype="";
//      } 	
 }
  else
 {
   document.getElementById('lbadcategory').options.length="0";
   document.getElementById('lbadcategory').options[0]=new Option("-----Select Category-----","0");
 }
 return false;
 
}
//--------------------------------------------------------------------//
function saveclick(response)
{
chk="s";
news="0";
var ds=response.value;

if(ds.Tables[0].Rows.length > 0)
{
alert("This Code  Has Been Assigned");
return false;
}

if(ds.Tables[1].Rows.length > 0)
{
alert("This Description  Has Been Assigned");
return false;
}
var advtype=document.getElementById('txtadvtype').value;

var length=document.getElementById('lbadcategory').options.length;
 var abc = "";
        for(var li=0;  li< length; li++)
        {

            if (document.getElementById('lbadcategory').options[li].selected == true)
            {
                if (document.getElementById('lbadcategory').options[li].value != "")
                {
                    if(abc=="")
                        abc=document.getElementById('lbadcategory').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('lbadcategory').options[li].value;
                }

            }
        }
        var badcategory=abc;
        
//  ----------------- for package--------------------------//

var pckglen=document.getElementById('drpedition').options.length;
 var choose = "";
        for(var li1=0;  li1< pckglen; li1++)
        {
           if (document.getElementById('drpedition').options[li1].selected == true)
            {
                if (document.getElementById('drpedition').options[li1].value != "")
                {
                    if(choose=="")
                        choose=document.getElementById('drpedition').options[li1].value;
                    else
                        choose = choose + "," + document.getElementById('drpedition').options[li1].value;
                }
            }
        }
        var edition=choose;
 //---------------------------------------------------------//       
//var edition=document.getElementById('drpedition').value;
    var advsizecode=document.getElementById('txtadvsizecode').value;
    var description=document.getElementById('txtadvdescription').value;
    var color=document.getElementById('drpcolor').value;
    var uom=document.getElementById('drpuom').value;

    var remarks=document.getElementById('txtremarks').value;
    var width1=document.getElementById('txtwidth1').value;
    //var width2=document.getElementById('txtwidth2').value;
    var height1=document.getElementById('txtheight1').value;
     
    //var height2=document.getElementById('txtheight2').value;

    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
   var col=document.getElementById('txtcol').value;
    Adsize_master.insertadsize(advtype,badcategory,edition,advsizecode,description,color,uom,remarks,width1,"",height1,"",compcode,userid,col);

    show="0";

	document.getElementById('btnNew').disabled=false;
	document.getElementById('btnQuery').disabled=false;
	document.getElementById('btnCancel').disabled=false;		
	document.getElementById('btnExit').disabled=false;	
	document.getElementById('btnSave').disabled=true;
	document.getElementById('btnModify').disabled=true;
	document.getElementById('btnDelete').disabled=true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=true;			
	document.getElementById('btnlast').disabled=true;
	
	alert("Data Saved successfully");
					
    document.getElementById('txtadvtype').value="0";
    document.getElementById('lbadcategory').value="0";
    document.getElementById('drpedition').value="0";
    document.getElementById('txtadvsizecode').value="";
    document.getElementById('txtadvdescription').value="";
    document.getElementById('drpcolor').value="0";
    document.getElementById('drpuomnew').value="0";
    document.getElementById('txtremarks').value="";
    document.getElementById('txtwidth1').value="";
    //document.getElementById('txtwidth2').value="";
    document.getElementById('txtheight1').value="";
    //document.getElementById('txtheight2').value="";
   document.getElementById('txtcol').value="";
    document.getElementById('txtadvtype').disabled=true;
    document.getElementById('lbadcategory').disabled=true;
    document.getElementById('drpedition').disabled=true;
    document.getElementById('txtadvsizecode').disabled=true;
    document.getElementById('txtadvdescription').disabled=true;
    document.getElementById('drpcolor').disabled=true;
    document.getElementById('drpuomnew').disabled=true;
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtwidth1').disabled=true;
    document.getElementById('txtcol').disabled=true;
    //document.getElementById('txtwidth2').disabled=true;
    document.getElementById('txtheight1').disabled=true;
    //document.getElementById('txtheight2').disabled=true;
    cancelclick('Adsize_master');
    return false;

}


function executeclick()
{
    chk="e";
    var advtype=document.getElementById('txtadvtype').value;
    var badcategory=document.getElementById('lbadcategory').value;
    //var badcategory=document.getElementById('txtcate').value;
    var edition=document.getElementById('drpedition').value;
    var advsizecode=document.getElementById('txtadvsizecode').value;
    var description=document.getElementById('txtadvdescription').value;
    var color=document.getElementById('drpcolor').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;

    var ds_ex=Adsize_master.excutesize(advtype,badcategory,edition,advsizecode,description,color,compcode,userid);
    
	if(ds_ex.value==null)
    {
        alert(ds_ex.error.description);
        return false;
    }
      global_ds=ds_ex.value;

    if(global_ds.Tables[0].Rows.length <= 0)
    {
        alert("Your Search Criteria Doesn't Produce Any Result!!!!!");
        cancelclick('Adsize_master');        
        return false;
    }
    else
    {
        if(global_ds.Tables[0].Rows[0].Adv_type!=null)
        {
            document.getElementById('txtadvtype').value=global_ds.Tables[0].Rows[0].Adv_type;
            gladtype=global_ds.Tables[0].Rows[0].Adv_type;
        }
        else
        {
            document.getElementById('txtadvtype').value="";
        }
        //bind ad category if multi seleceted
        /*onchage_adtype();
         var length1=document.getElementById('lbadcategory').options.length;
         for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
         {
             document.getElementById('lbadcategory').options[t].selected=false;
         }
        if(global_ds.Tables[0].Rows[0].Adv_category!=null)
        {
            var adcat=global_ds.Tables[0].Rows[0].Adv_category;           
            var len=adcat.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<length1; i++)
                {
                    if(document.getElementById('lbadcategory').options[i].value==len[a])
                    {
                       document.getElementById('lbadcategory').options[i].selected = true;
                    }
                }
            }
        }
        
       */
       var resu= Adsize_master.adduomAjax(compcode,global_ds.Tables[0].Rows[0].Adv_type);    
var dsu=resu.value;
  if(dsu==null)
 {
   alert(resu.error.description);
   return false;
 }
 document.getElementById('drpuom').options.length=0;
 document.getElementById('drpuom').options[0]=new Option("--Select UOM--","0");
 if(dsu.Tables[0].Rows.length !=null && dsu.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=dsu.Tables[0].Rows.length-1;++i) 
	{
		document.getElementById('drpuom').options[i+1]=new Option(dsu.Tables[0].Rows[i].Uom_Name,dsu.Tables[0].Rows[i].Uom_Code);
		//name.options.length;
	}
}	


       var ds2 =Adsize_master.addlistbox(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[0].Adv_type);
       document.getElementById('lbadcategory').options[0]=new Option("-----Select Category-----","0");
        if(ds2.value!==null)
        {
            if(ds2.value.Tables[0].Rows.length !=null && ds2.value.Tables[0].Rows.length>0)
            {
                for(var i=0;i<=ds2.value.Tables[0].Rows.length-1;++i) 
	            {
		            document.getElementById('lbadcategory').options[i+1]=new Option(ds2.value.Tables[0].Rows[i].adv_cat_name,ds2.value.Tables[0].Rows[i].adv_cat_code);
		          
	            }	
            }
        }
        //----------------------------------------------------//
        
          var adcatlen=document.getElementById('lbadcategory').options.length;
         for(var t2=0;t2<document.getElementById('lbadcategory').options.length;t2++)
         {
             document.getElementById('lbadcategory').options[t2].selected=false;
         }
        if(global_ds.Tables[0].Rows[0].Adv_category!=null)
        {
            var adcat=global_ds.Tables[0].Rows[0].Adv_category;            
           var  len1=adcat.split(",");
            for(var a1=0; a1<len1.length; a1++)
            {
                for(var j=1; j<adcatlen; j++)
                {
                    if(document.getElementById('lbadcategory').options[j].value==len1[a1])
                    {
                       document.getElementById('lbadcategory').options[j].selected = true;
                    }
                }
            }

        }
        
        //----------------------------------------------------------//
        
        var ds1 =Adsize_master.packagebind(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[0].Adv_type);
        document.getElementById('drpedition').options[0]=new Option("-----Select Package-----","0");
        if(ds1.value!==null)
        {
            if(ds1.value.Tables[0].Rows.length !=null && ds1.value.Tables[0].Rows.length>0)
            {
                for(var i=0;i<=ds1.value.Tables[0].Rows.length-1;++i) 
	            {
		            document.getElementById('drpedition').options[i+1]=new Option(ds1.value.Tables[0].Rows[i].Package_Name,ds1.value.Tables[0].Rows[i].Combin_Code);
		          
	            }	
            }
        }

         var pckglen=document.getElementById('drpedition').options.length;
         for(var t1=0;t1<document.getElementById('drpedition').options.length;t1++)
         {
             document.getElementById('drpedition').options[t1].selected=false;
         }
        if(global_ds.Tables[0].Rows[0].edition!=null)
        {
            var edition=global_ds.Tables[0].Rows[0].edition;            
            len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<pckglen; i++)
                {
                    if(document.getElementById('drpedition').options[i].value==len[a])
                    {
                       document.getElementById('drpedition').options[i].selected = true;
                    }
                }
            }

        }
        if(global_ds.Tables[0].Rows[0].Adv_size_code!=null)
        {
            document.getElementById('txtadvsizecode').value=global_ds.Tables[0].Rows[0].Adv_size_code;
        }
        if(global_ds.Tables[0].Rows[0].Adv_Size_description!=null)
        {
            document.getElementById('txtadvdescription').value=global_ds.Tables[0].Rows[0].Adv_Size_description;
        }
        if(global_ds.Tables[0].Rows[0].color!=null)
        {
            document.getElementById('drpcolor').value=global_ds.Tables[0].Rows[0].color;
        }
        if(global_ds.Tables[0].Rows[0].uom!=null)
        {
            document.getElementById('drpuom').value = global_ds.Tables[0].Rows[0].uom;
        }
        if(global_ds.Tables[0].Rows[0].remarks!=null)
        {
            document.getElementById('txtremarks').value=global_ds.Tables[0].Rows[0].remarks;
        }
        if(global_ds.Tables[0].Rows[0].max_width!=null)
        {
            document.getElementById('txtwidth1').value=global_ds.Tables[0].Rows[0].max_width;
        }
//        if(global_ds.Tables[0].Rows[0].min_width!=null)
//        {
//        //document.getElementById('txtwidth2').value=global_ds.Tables[0].Rows[0].min_width;
//        }
        if(global_ds.Tables[0].Rows[0].max_height!=null)
        {
            document.getElementById('txtheight1').value=global_ds.Tables[0].Rows[0].max_height;
        }
//        if(global_ds.Tables[0].Rows[0].min_height!=null)
//        {
//        //document.getElementById('txtheight2').value=global_ds.Tables[0].Rows[0].min_height;
//        }

        //return false;
        if (global_ds.Tables[0].Rows[0].COLOUMN == "" || global_ds.Tables[0].Rows[0].COLOUMN == null) {
            document.getElementById('txtcol').value = "";
        }
        else {
            document.getElementById('txtcol').value = global_ds.Tables[0].Rows[0].COLOUMN;
        }
        
    }
    
    
		                
   updateStatus();
						
    document.getElementById('txtadvtype').disabled=true;
    document.getElementById('lbadcategory').disabled=true;
    document.getElementById('drpedition').disabled=true;
    document.getElementById('txtadvsizecode').disabled=true;
    document.getElementById('txtadvdescription').disabled=true;
    document.getElementById('drpcolor').disabled=true;
    document.getElementById('drpuomnew').disabled=true;
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtwidth1').disabled=true;
    //document.getElementById('txtwidth2').disabled=true;
    document.getElementById('txtheight1').disabled=true;
    //document.getElementById('txtheight2').disabled=true;
   document.getElementById('txtcol').disabled=true;
    document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnnext').disabled=false;					
	document.getElementById('btnprevious').disabled=true;			
	document.getElementById('btnlast').disabled=false;
	if(global_ds.Tables[0].Rows.length==1)
    {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
        document.getElementById('btnprevious').disabled=true;

    }
	setButtonImages();	
	if(document.getElementById('btnModify').disabled==false)					
	   document.getElementById('btnModify').focus();

z=0;
news="0";					
return false;

}


function modifyclick()
{
chk="m";
show="2";
				
document.getElementById('txtadvtype').disabled=false;
document.getElementById('lbadcategory').disabled=false;
document.getElementById('drpedition').disabled=false;
document.getElementById('txtadvsizecode').disabled=true;
document.getElementById('txtadvdescription').disabled=false;
document.getElementById('drpcolor').disabled=false;
document.getElementById('drpuom').disabled = false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('txtwidth1').disabled=false;
//document.getElementById('txtwidth2').disabled=false;
document.getElementById('txtheight1').disabled=false;
//document.getElementById('txtheight2').disabled=false;
document.getElementById('txtcol').disabled=false;
chknamemod=document.getElementById('txtadvdescription').value;
chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled = true;
document.getElementById('btnExecute').disabled=true;
flag=1;		


modify="1";
setButtonImages();
return false;

}

function firstclick()
{
//chk="f";
//Adsize_master.searchfirst(call_first);

	updateStatus();

    document.getElementById('btnCancel').disabled=false;
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnlast').disabled=false;
    document.getElementById('btnExit').disabled=false;
				
    z=0;
     document.getElementById('txtadvtype').value=global_ds.Tables[0].Rows[z].Adv_type;
        var length=document.getElementById('lbadcategory').options.length;
        for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
        {
            document.getElementById('lbadcategory').options[t].selected=false;
        }
        
        if(global_ds.Tables[0].Rows[z].Adv_category!=null)
        {
             var adcat=global_ds.Tables[0].Rows[z].Adv_category;
             var len =new Array();
             len=adcat.split(",");
            for(var a=0; a<len.length; a++)
            {
                    for(var i=1; i<length; i++)
                    {
                       if(document.getElementById('lbadcategory').options[i].value==len[a])
                        {
                            // document.getElementById('lbadcategory').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                             document.getElementById('lbadcategory').options[i].selected = true;
                           //  document.getElementById('lbadcategory').options[0].selected = false;
                        }

                    }
            }
         }
       //  --------------------------------------///
                  var resu= Adsize_master.adduomAjax(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);    
var dsu=resu.value;
  if(dsu==null)
 {
   alert(resu.error.description);
   return false;
 }
 document.getElementById('drpuomnew').options.length=0;
 document.getElementById('drpuomnew').options[0]=new Option("--Select UOM--","0");
 if(dsu.Tables[0].Rows.length !=null && dsu.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=dsu.Tables[0].Rows.length-1;++i) 
	{
		document.getElementById('drpuomnew').options[i+1]=new Option(dsu.Tables[0].Rows[i].Uom_Name,dsu.Tables[0].Rows[i].Uom_Code);
		//name.options.length;
	}
}

       var ds1 =Adsize_master.packagebind(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);
        if(ds1.value!==null)
        {
            if(ds1.value.Tables[1].Rows.length !=null && ds1.value.Tables[1].Rows.length>0)
             {
                for(var i=0;i<=ds1.value.Tables[1].Rows.length-1;++i) 
	            {
		            document.getElementById('drpedition').options[i]=new Option(ds1.value.Tables[1].Rows[i].Package_Name,ds1.value.Tables[1].Rows[i].Combin_Code);
		            //name.options.length;
	            }	
             }
        }
        
         var pckglen=document.getElementById('drpedition').options.length;
         for(var t1=0;t1<document.getElementById('drpedition').options.length;t1++)
        {
             document.getElementById('drpedition').options[t1].selected=false;
        }
        
        if(global_ds.Tables[0].Rows[z].edition!=null)
        {
            var edition=global_ds.Tables[0].Rows[z].edition;            
            len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<pckglen; i++)
                {
                    if(document.getElementById('drpedition').options[i].value==len[a])
                    {
                        // document.getElementById('drpedition').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                         document.getElementById('drpedition').options[i].selected = true;
                       //  document.getElementById('drpedition').options[0].selected = false;
                    }
                }
            }

        }
    //  ----------------------------------------------------------------------------------------------------///    
       // document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition; 
         document.getElementById('txtadvsizecode').value=global_ds.Tables[0].Rows[z].Adv_size_code;
         document.getElementById('txtadvdescription').value=global_ds.Tables[0].Rows[z].Adv_Size_description;
         document.getElementById('drpcolor').value=global_ds.Tables[0].Rows[z].color;
         document.getElementById('drpuom').value=global_ds.Tables[0].Rows[z].uom;

         document.getElementById('txtremarks').value=global_ds.Tables[0].Rows[z].remarks;
         document.getElementById('txtwidth1').value=global_ds.Tables[0].Rows[z].max_width;
         //document.getElementById('txtwidth2').value=global_ds.Tables[0].Rows[z].min_width;
         document.getElementById('txtheight1').value=global_ds.Tables[0].Rows[z].max_height;
         if (global_ds.Tables[0].Rows[z].COLOUMN == "" || global_ds.Tables[0].Rows[z].COLOUMN == null) {
             document.getElementById('txtcol').value = "";
         }
         else {
             document.getElementById('txtcol').value = global_ds.Tables[0].Rows[z].COLOUMN;
         }
         
        // document.getElementById('txtheight2').value=global_ds.Tables[0].Rows[z].min_height;
        setButtonImages();
		return false;

}




function lastclick()
{
//chk="f";
//Adsize_master.searchfirst(call_last);
       var x=global_ds.Tables[0].Rows.length;
		z=x-1;
		x=x-1;
         
         document.getElementById('txtadvtype').value=global_ds.Tables[0].Rows[z].Adv_type;
            var length=document.getElementById('lbadcategory').options.length;
             for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
            {
                document.getElementById('lbadcategory').options[t].selected=false;
            }
          
          if(global_ds.Tables[0].Rows[z].Adv_category!=null)
         {
            var adcat=global_ds.Tables[0].Rows[z].Adv_category;
             var len =new Array();
             len=adcat.split(",");
            for(var a=0; a<len.length; a++)
            {
                    for(var i=1; i<length; i++)
                    {
                       if(document.getElementById('lbadcategory').options[i].value==len[a])
                        {
                             //document.getElementById('lbadcategory').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                             document.getElementById('lbadcategory').options[i].selected = true;
                            // document.getElementById('lbadcategory').options[i].selected = false;
                        }

                    }
            }
         }
        
    //  -----------------------------------------------------------------------------------------------------///
               var resu= Adsize_master.adduomAjax(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);    
var dsu=resu.value;
  if(dsu==null)
 {
   alert(resu.error.description);
   return false;
 }
 document.getElementById('drpuom').options.length=0;
 document.getElementById('drpuom').options[0]=new Option("--Select UOM--","0");
 if(dsu.Tables[0].Rows.length !=null && dsu.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=dsu.Tables[0].Rows.length-1;++i) 
	{
		document.getElementById('drpuom').options[i+1]=new Option(dsu.Tables[0].Rows[i].Uom_Name,dsu.Tables[0].Rows[i].Uom_Code);
		//name.options.length;
	}
}
       var ds1 =Adsize_master.packagebind(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);
        if(ds1.value!==null)
        {
            if(ds1.value.Tables[0].Rows.length !=null && ds1.value.Tables[0].Rows.length>0)
             {
                for(var i=0;i<=ds1.value.Tables[0].Rows.length-1;++i) 
	            {
		            document.getElementById('drpedition').options[i]=new Option(ds1.value.Tables[0].Rows[i].Package_Name,ds1.value.Tables[0].Rows[i].Combin_Code);
		            //name.options.length;
	            }	
             }
        }
        
        var pckglen=document.getElementById('drpedition').options.length;
         for(var t1=0;t1<document.getElementById('drpedition').options.length;t1++)
        {
             document.getElementById('drpedition').options[t1].selected=false;
        }
        
        if(global_ds.Tables[0].Rows[z].edition!=null)
        {
            var edition=global_ds.Tables[0].Rows[z].edition;            
            len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<pckglen; i++)
                {
                    if(document.getElementById('drpedition').options[i].value==len[a])
                    {
                        // document.getElementById('drpedition').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                         document.getElementById('drpedition').options[i].selected = true;
                       //  document.getElementById('drpedition').options[0].selected = false;
                    }
                }
            }

        }
   //---------------------------------------------------------------------------------------------------///   
       //  document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition; 
         document.getElementById('txtadvsizecode').value=global_ds.Tables[0].Rows[z].Adv_size_code;
         document.getElementById('txtadvdescription').value=global_ds.Tables[0].Rows[z].Adv_Size_description;
         document.getElementById('drpcolor').value=global_ds.Tables[0].Rows[z].color;
         document.getElementById('drpuom').value=global_ds.Tables[0].Rows[z].uom;

         document.getElementById('txtremarks').value=global_ds.Tables[0].Rows[z].remarks;
         document.getElementById('txtwidth1').value=global_ds.Tables[0].Rows[z].max_width;
        // document.getElementById('txtwidth2').value=global_ds.Tables[0].Rows[z].min_width;
         document.getElementById('txtheight1').value=global_ds.Tables[0].Rows[z].max_height;
         //document.getElementById('txtheight2').value=global_ds.Tables[0].Rows[z].min_height;
         if (global_ds.Tables[0].Rows[z].COLOUMN == "" || global_ds.Tables[0].Rows[z].COLOUMN == null) {
             document.getElementById('txtcol').value = "";
         }
         else {
             document.getElementById('txtcol').value = global_ds.Tables[0].Rows[z].COLOUMN;
         }
        
       // document.getElementById('btnModify').focus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;

setButtonImages();
return false;

}



function nextclick()
{

    z++;
	var x=global_ds.Tables[0].Rows.length;
	var a=x;
	
	if(z <= x && z!=-1)

	{
    	if(global_ds.Tables[0].Rows.length != z && z>=0)
	   {
		   document.getElementById('txtadvtype').value=global_ds.Tables[0].Rows[z].Adv_type;
           var length=document.getElementById('lbadcategory').options.length;
           for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
           {
              document.getElementById('lbadcategory').options[t].selected=false;
           }
           if(global_ds.Tables[0].Rows[z].Adv_category!=null)
           {
              var adcat=global_ds.Tables[0].Rows[z].Adv_category;
              var len =new Array();
              len=adcat.split(",");
              for(var a=0; a<len.length; a++)
              {
                    for(var i=1; i<length; i++)
                    {
                       if(document.getElementById('lbadcategory').options[i].value==len[a])
                        {
                            // document.getElementById('lbadcategory').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                             document.getElementById('lbadcategory').options[i].selected = true;
                           //  document.getElementById('lbadcategory').options[0].selected = false;
                        }

                    }
              }
            }
              var resu= Adsize_master.adduomAjax(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);    
var dsu=resu.value;
  if(dsu==null)
 {
   alert(resu.error.description);
   return false;
 }
 document.getElementById('drpuom').options.length=0;
 document.getElementById('drpuom').options[0]=new Option("--Select UOM--","0");
 if(dsu.Tables[0].Rows.length !=null && dsu.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=dsu.Tables[0].Rows.length-1;++i) 
	{
		document.getElementById('drpuom').options[i+1]=new Option(dsu.Tables[0].Rows[i].Uom_Name,dsu.Tables[0].Rows[i].Uom_Code);
		//name.options.length;
	}
}	

       //-------------------------------------------------------------------------------------------------------///
       var ds1 =Adsize_master.packagebind(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);
        if(ds1.value!==null)
        {
            if(ds1.value.Tables[0].Rows.length !=null && ds1.value.Tables[0].Rows.length>0)
             {
                for(var i=0;i<=ds1.value.Tables[0].Rows.length-1;++i) 
	            {
		            document.getElementById('drpedition').options[i]=new Option(ds1.value.Tables[0].Rows[i].Package_Name,ds1.value.Tables[0].Rows[i].Combin_Code);
		            //name.options.length;
	            }	
             }
        }
        
        var pckglen=document.getElementById('drpedition').options.length;
        for(var t1=0;t1<document.getElementById('drpedition').options.length;t1++)
        {
             document.getElementById('drpedition').options[t1].selected=false;
        }
        
        if(global_ds.Tables[0].Rows[z].edition!=null)
        {
            var edition=global_ds.Tables[0].Rows[z].edition;            
            len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<pckglen; i++)
                {
                    if(document.getElementById('drpedition').options[i].value==len[a])
                    {
                       document.getElementById('drpedition').options[i].selected = true;
                    }
                }
            }

        }
  //-----------------------------------------------------------------------------------------------------///   
         //document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition; 
         document.getElementById('txtadvsizecode').value=global_ds.Tables[0].Rows[z].Adv_size_code;
         document.getElementById('txtadvdescription').value=global_ds.Tables[0].Rows[z].Adv_Size_description;
         document.getElementById('drpcolor').value=global_ds.Tables[0].Rows[z].color;
         document.getElementById('drpuom').value=global_ds.Tables[0].Rows[z].uom;

         document.getElementById('txtremarks').value=global_ds.Tables[0].Rows[z].remarks;
         document.getElementById('txtwidth1').value=global_ds.Tables[0].Rows[z].max_width;
        //document.getElementById('txtwidth2').value=global_ds.Tables[0].Rows[z].min_width;
         document.getElementById('txtheight1').value = global_ds.Tables[0].Rows[z].max_height;
         if (global_ds.Tables[0].Rows[z].COLOUMN == "" || global_ds.Tables[0].Rows[z].COLOUMN == null) {
             document.getElementById('txtcol').value = "";
         }
         else {
             document.getElementById('txtcol').value = global_ds.Tables[0].Rows[z].COLOUMN;
         }
         
         updateStatus();
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
        // document.getElementById('txtheight2').value=global_ds.Tables[0].Rows[z].min_height;
	 }
		 
		 else
			{
		        document.getElementById('btnfirst').disabled=false;				
	   			document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=false;			
     			document.getElementById('btnlast').disabled=true;
				//document.getElementById('btnModify').focus();
				setButtonImages();
			    return false;
					
			}
	}				
		else
					{
					document.getElementById('btnfirst').disabled=false;				
								document.getElementById('btnnext').disabled=true;					
								document.getElementById('btnprevious').disabled=false;			
								document.getElementById('btnlast').disabled=true;
								setButtonImages();
								return false;
					
					}
//chk="f";
//Adsize_master.searchfirst(call_next);
   if(z==x-1)
	{
	    document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
	}
	setButtonImages();
	    return false;
}


function prevclick()
	{
	
	//chk="f";
	//Adsize_master.searchfirst(call_prev);
	
    z--;
	var x=global_ds.Tables[0].Rows.length;
	
	        if(z>x)
			{
						document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						setButtonImages();
						return false;
			}
			
			
			
			if(z!=-1 && z>=0)
				{
					if(global_ds.Tables[0].Rows.length != z)
					{
                       
                      document.getElementById('txtadvtype').value=global_ds.Tables[0].Rows[z].Adv_type;
                       var length=document.getElementById('lbadcategory').options.length;
                       for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
                       {
                          document.getElementById('lbadcategory').options[t].selected=false;
                       }
                     if(global_ds.Tables[0].Rows[z].Adv_category!=null)
                    {
                        
                        var adcat=global_ds.Tables[0].Rows[z].Adv_category;
                         var len =new Array();
                         len=adcat.split(",");
                        for(var a=0; a<len.length; a++)
                        {
                                for(var i=1; i<length; i++)
                                {
                                   if(document.getElementById('lbadcategory').options[i].value==len[a])
                                    {
                                         document.getElementById('lbadcategory').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                                         document.getElementById('lbadcategory').options[i].selected = true;
                                         document.getElementById('lbadcategory').options[0].selected = false;
                                    }

                                }
                        }
                    }
    //------------------------------------------------------------------------------------------------///
    
           var resu= Adsize_master.adduomAjax(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);    
var dsu=resu.value;
  if(dsu==null)
 {
   alert(resu.error.description);
   return false;
 }
 document.getElementById('drpuom').options.length=0;
 document.getElementById('drpuom').options[0]=new Option("--Select UOM--","0");
 if(dsu.Tables[0].Rows.length !=null && dsu.Tables[0].Rows.length>0)
 {
    for(var i=0;i<=dsu.Tables[0].Rows.length-1;++i) 
	{
		document.getElementById('drpuom').options[i+1]=new Option(dsu.Tables[0].Rows[i].Uom_Name,dsu.Tables[0].Rows[i].Uom_Code);
		//name.options.length;
	}
}	



       var ds1 =Adsize_master.packagebind(document.getElementById('hiddencompcode').value,global_ds.Tables[0].Rows[z].Adv_type);
        if(ds1.value!==null)
        {
            if(ds1.value.Tables[0].Rows.length !=null && ds1.value.Tables[0].Rows.length>0)
             {
                for(var i=0;i<=ds1.value.Tables[0].Rows.length-1;++i) 
	            {
		            document.getElementById('drpedition').options[i]=new Option(ds1.value.Tables[0].Rows[i].Package_Name,ds1.value.Tables[0].Rows[i].Combin_Code);
		            //name.options.length;
	            }	
             }
        }
         var pckglen=document.getElementById('drpedition').options.length;
        for(var t1=0;t1<document.getElementById('drpedition').options.length;t1++)
        {
             document.getElementById('drpedition').options[t1].selected=false;
        }
        
        if(global_ds.Tables[0].Rows[z].edition!=null)
        {
            var edition=global_ds.Tables[0].Rows[z].edition;            
            len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<pckglen; i++)
                {
                    if(document.getElementById('drpedition').options[i].value==len[a])
                    {
                        // document.getElementById('drpedition').options[i].value=len[a]; //global_ds.Tables[0].Rows[0].Adv_category;
                         document.getElementById('drpedition').options[i].selected = true;
                       //  document.getElementById('drpedition').options[0].selected = false;
                    }
                }
            }

        }
    //--------------------------------------------------------------------------------------------------------///   
                   //  document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition; 
                     document.getElementById('txtadvsizecode').value=global_ds.Tables[0].Rows[z].Adv_size_code;
                     document.getElementById('txtadvdescription').value=global_ds.Tables[0].Rows[z].Adv_Size_description;
                     document.getElementById('drpcolor').value=global_ds.Tables[0].Rows[z].color;
                     document.getElementById('drpuom').value=global_ds.Tables[0].Rows[z].uom;

                     document.getElementById('txtremarks').value=global_ds.Tables[0].Rows[z].remarks;
                     document.getElementById('txtwidth1').value=global_ds.Tables[0].Rows[z].max_width;
                   //  document.getElementById('txtwidth2').value=global_ds.Tables[0].Rows[z].min_width;
                     document.getElementById('txtheight1').value=global_ds.Tables[0].Rows[z].max_height;
                    // document.getElementById('txtheight2').value=global_ds.Tables[0].Rows[z].min_height;
                     if (global_ds.Tables[0].Rows[z].COLOUMN == "" || global_ds.Tables[0].Rows[z].COLOUMN == null) {
                         document.getElementById('txtcol').value = "";
                     }
                     else {
                         document.getElementById('txtcol').value = global_ds.Tables[0].Rows[z].COLOUMN;
                     }
                    
                    updateStatus();
		            document.getElementById('btnfirst').disabled=false;				
		            document.getElementById('btnnext').disabled=false;				
		            document.getElementById('btnprevious').disabled=false;				
		            document.getElementById('btnlast').disabled=false;			
		            document.getElementById('btnExit').disabled=false;

                    }
                    
                    else
					{
						document.getElementById('btnnext').disabled=true;
						document.getElementById('btnlast').disabled=false;
						document.getElementById('btnfirst').disabled=true;
						document.getElementById('btnprevious').disabled=false;
						document.getElementById('btnModify').focus();
						setButtonImages();
						return false;
		
					}
				}
				else
				{
		                document.getElementById('btnnext').disabled=false;
			            document.getElementById('btnlast').disabled=false;
			            document.getElementById('btnfirst').disabled=true;
			            document.getElementById('btnprevious').disabled=true;
			            setButtonImages();
			            return false;
		        }
			      
			        if (z<=0)
			        {
			        document.getElementById('btnfirst').disabled=true;				
			        document.getElementById('btnnext').disabled=false;					
			        document.getElementById('btnprevious').disabled=true;			
			        document.getElementById('btnlast').disabled=false;
			        setButtonImages();	
			        return false;	
			        }
			        setButtonImages();
			return false;	

}

	



	function deleteclick()
	{
	var edition=document.getElementById('drpedition').value;
   var advsizecode=document.getElementById('txtadvsizecode').value;
   var compcode=document.getElementById('hiddencompcode').value;
  var userid=document.getElementById('hiddenuserid').value;
  
  if(confirm("Are you Sure you wish to delete this ?"))
  {
  
  //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Adsize_master.deletesize(advsizecode,compcode,userid);
  alert("Data Deleted successfully");
  Adsize_master.searchfirst(call_delete);
  
  
  }
  return false;

	
	}
	
	function call_delete(response)
	{
	var ds=response.value;
	var a=ds.Tables[0].Rows.length;
	global_ds=response.value;
	var y=a-1;
	
	if( a <=0 )
	{
	alert("No more data is here to be deleted");
	
	document.getElementById('btnfirst').disabled=true;
			
			document.getElementById('txtadvtype').value="0";
document.getElementById('lbadcategory').value="0";
document.getElementById('drpedition').value="0";
document.getElementById('txtadvsizecode').value="";
document.getElementById('txtadvdescription').value="";
document.getElementById('drpcolor').value="0";
document.getElementById('drpuomnew').value="0";
document.getElementById('txtremarks').value="";
document.getElementById('txtwidth1').value="";
//document.getElementById('txtwidth2').value="";
document.getElementById('txtheight1').value="";
//document.getElementById('txtheight2').value="";
	document.getElementById('txtcol').value="";		
			cancelclick('Adsize_master');
			
			//document.getElementById('btnprevious').disabled=true;
			//document.getElementById('btnnext').disabled=true;
			//document.getElementById('btnlast').disabled=true;
			return false;
	
	}
	
	else if(z==-1 ||z>=a)
	{
	document.getElementById('txtadvtype').value=ds.Tables[0].Rows[0].Adv_type;

document.getElementById('lbadcategory').value=ds.Tables[0].Rows[0].Adv_category;

document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition;
document.getElementById('txtadvsizecode').value=ds.Tables[0].Rows[0].Adv_size_code;
document.getElementById('txtadvdescription').value=ds.Tables[0].Rows[0].Adv_Size_description;
document.getElementById('drpcolor').value=ds.Tables[0].Rows[0].color;
document.getElementById('drpuomnew').value=ds.Tables[0].Rows[0].uom;

document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
document.getElementById('txtwidth1').value=ds.Tables[0].Rows[0].max_width;
//document.getElementById('txtwidth2').value=ds.Tables[0].Rows[0].min_width;
document.getElementById('txtheight1').value=ds.Tables[0].Rows[0].max_height;
//document.getElementById('txtheight2').value=ds.Tables[0].Rows[0].min_height;
if (global_ds.Tables[0].Rows[0].COLOUMN == "" || global_ds.Tables[0].Rows[0].COLOUMN == null) {
    document.getElementById('txtcol').value = "";
}
else {
    document.getElementById('txtcol').value = global_ds.Tables[0].Rows[0].COLOUMN;
}
	
	}
	else
	{
	document.getElementById('txtadvtype').value=ds.Tables[0].Rows[z].Adv_type;

document.getElementById('lbadcategory').value=ds.Tables[0].Rows[z].Adv_category;

document.getElementById('drpedition').value=ds.Tables[0].Rows[z].edition;
document.getElementById('txtadvsizecode').value=ds.Tables[0].Rows[z].Adv_size_code;
document.getElementById('txtadvdescription').value=ds.Tables[0].Rows[z].Adv_Size_description;
document.getElementById('drpcolor').value=ds.Tables[0].Rows[z].color;
document.getElementById('drpuomnew').value=ds.Tables[0].Rows[z].uom;

document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;
document.getElementById('txtwidth1').value=ds.Tables[0].Rows[z].max_width;
//document.getElementById('txtwidth2').value=ds.Tables[0].Rows[z].min_width;
document.getElementById('txtheight1').value=ds.Tables[0].Rows[z].max_height;

if (global_ds.Tables[0].Rows[z].COLOUMN == "" || global_ds.Tables[0].Rows[z].COLOUMN == null) {
    document.getElementById('txtcol').value = "";
}
else {
    document.getElementById('txtcol').value = global_ds.Tables[0].Rows[z].COLOUMN;
}
//document.getElementById('txtheight2').value=ds.Tables[0].Rows[z].min_height;
	}
	setButtonImages();
	return false;
	
	
	}
	
	function queryclick()
	{
	show="0";
	if(document.getElementById('hiddenpermission').value=="zero")
    {
    alert("You Are Noe Authorised To See This Form");
    return false;
    }
	
	z=0;
	document.getElementById('txtadvtype').disabled=false;
    document.getElementById('lbadcategory').disabled=false;
    document.getElementById('drpedition').disabled=false;
    document.getElementById('txtadvsizecode').disabled=false;
    document.getElementById('txtadvdescription').disabled=false;
    document.getElementById('drpcolor').disabled=false;
    //document.getElementById('drpuomnew').disabled=true;
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtwidth1').disabled=true;
    //document.getElementById('txtwidth2').disabled=true;
    document.getElementById('txtheight1').disabled=true;
    //document.getElementById('txtheight2').disabled=true;
    document.getElementById('txtcol').disabled=true;
    document.getElementById('lbadcategory').options.length=0;
    document.getElementById('drpedition').options.length=0;
    document.getElementById('txtadvtype').value="0";
    //document.getElementById('lbadcategory').value="0";
   // document.getElementById('drpedition').value="0";
    document.getElementById('txtadvsizecode').value="";
    document.getElementById('txtadvdescription').value="";
    document.getElementById('drpcolor').value="0";
    //document.getElementById('drpuomnew').value="0";
    document.getElementById('txtremarks').value="";
    document.getElementById('txtwidth1').value="";
    //document.getElementById('txtwidth2').value="";
    document.getElementById('txtheight1').value="";
    //document.getElementById('txtheight2').value="";
   document.getElementById('txtcol').value="";


    chkstatus(FlagStatus);

    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=false;
    document.getElementById('btnSave').disabled=true;
	
	modify="0";
	setButtonImages();
	return false;
}
	
	
	
function cancelclick(formname)
{
	chk="0";
	show="0";
	 for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
    {
         document.getElementById('lbadcategory').options[t].selected=false;
    }
      for(var t1=0;t1<document.getElementById('drpedition').options.length;t1++)
    {
         document.getElementById('drpedition').options[t1].selected=false;
    }
	document.getElementById('txtadvtype').disabled=true;
    document.getElementById('lbadcategory').disabled=true;
    document.getElementById('drpedition').disabled=true;
    document.getElementById('txtadvsizecode').disabled=true;
    document.getElementById('txtadvdescription').disabled=true;
    document.getElementById('drpcolor').disabled=true;
    document.getElementById('drpuom').disabled=true;
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtwidth1').disabled=true;
    document.getElementById('txtcol').disabled=true;
    //document.getElementById('txtwidth2').disabled=true;
    document.getElementById('txtheight1').disabled=true;
    document.getElementById('lbadcategory').options.length=0;
    document.getElementById('drpedition').options.length=0;
    //document.getElementById('txtheight2').disabled=true;
    news="0";
    z=0;



    document.getElementById('txtadvtype').value="0";
    document.getElementById('lbadcategory').value="0";
    document.getElementById('drpedition').value="0";
    document.getElementById('txtadvsizecode').value="";
    document.getElementById('txtadvdescription').value="";
    document.getElementById('drpcolor').value="0";
    document.getElementById('drpuom').value="0";
    document.getElementById('txtremarks').value="";
    document.getElementById('txtwidth1').value="";
    //document.getElementById('txtwidth2').value="";
    document.getElementById('txtheight1').value="";
    //document.getElementById('txtheight2').value="";
   document.getElementById('txtcol').value="";
    givebuttonpermission(formname);
//getPermission(formname); // comment by gaurav
document.getElementById('drpuom').options.length=0;

    modify="0";
    setButtonImages();
    return false;
	
}

	
	function exitclick()
	{
	//alert(document.getElementById(popup));
	//window.close('','xyz');
	if(confirm("Do You Want To Skip This Page"))
	{
	if(typeof(popUpWin)!="undefined")
	{
	popUpWin.close();
	}
	if(typeof(popup)!="undefined")
	{
	popup.close();
	}
	window.close();
	//window.location.href='EnterPage.aspx';
	return false;
	}
	
	return false;
	
	}
	
	function multi()
	{
	
	
	if(modify=="0")
	{
	document.getElementById('btnupdate').disabled=true;
	document.getElementById('btnupdate').disabled=true;
	//document.getElementById('btnupdate').style.visibility="hidden";
	document.getElementById('btnupdate').style.display="none";
	
	}
	if(modify=="1")
	{
	//document.getElementById('btnupdate').style.visibility="visible";
	document.getElementById('btnupdate').style.display="block";
	document.getElementById('btnsubmit').style.display="none";
	//document.getElementById('btnupdate').disabled=false;
	}
	if(news=="1")
	{
	document.getElementById('btnsubmit').style.visibility="visible";
	}
	return false;
	}
	function multinew(me)
	{
	if(me=="new")
	{
	document.getElementById('btnsubmit').style.visibility="visible";
	}
	return false;
	}
	function multiple()
		{
		var adsize=document.getElementById('txtadvsizecode').value;
		
		var ab;
		if(adsize!=null && adsize!="")
		{
		
		for ( var index = 0; index < 200; index++ ) 
           { 
  
		
		popup=window.open('multi_adsize.aspx?adsize='+adsize+'&chk='+chk+'&show='+show,'xyz','status=0,toolbar=0,resizable=0,top=190,left=580,width=200px,height=130px');
		
		popup.focus();
		
		return false;
			}
		}
		else
		{
		alert("Please Fill Ad Size Code");
		return false;
		}
		
		}
	
	
	
	function popupdisplay()
		{
		
			 for ( var index = 0; index < 200; index++ ) 
				{ 
		var adsize=document.getElementById('txtadvsizecode').value;
		
		if(adsize != "")
		{		
		
		//else if(document.getElementById('txtadvtype').value=="AT02")
		
		popUpWin=window.open('Dispay_Ad.aspx?adsize='+adsize+'&show='+show,'Ankur','status=0,toolbar=0,resizable=1,top=244,left=180,scrollbars=yes,width=820px,height=415px');
		popUpWin.focus();
		return false;
		
		
		}
		else
		{
		alert("Size Code Field Should Not Be Blank");
		return false;
		
		}
			}
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

function clearaddsize() {
    cancelclick('Adsize_master');
    givebuttonpermission('Adsize_master');


}



//function adcat_bind()
//    {
//     uombind();
//     
//   }
    
      function uombind()
    {
    
var comp_code=document.getElementById('hiddencompcode').value;
 var adtype=document.getElementById('txtadvtype').value;
 var uomdesc="";
    Adsize_master.uom_bind(comp_code,adtype,uomdesc,call_bind_uom); 
 
    }
    
      function call_bind_uom(response)
{

     ds= response.value;
    var edition=document.getElementById('drpuomnew');
    edition.options.length=0;
    edition.options[0]=new Option("--Select UOM Name--");
   if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code);
                edition.options.length;  
               document.getElementById("hiddenuom").value= ds.Tables[0].Rows[i].Uom_Code; 
             }
             }
          //  document.getElementById("hiddenuom").value=  document.getElementById("drpuomnew").value
        return false
        
}