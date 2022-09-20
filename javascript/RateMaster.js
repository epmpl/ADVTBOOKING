// JScript File
var browser=navigator.appName;
var chkflag="";
var value="";
//var rateuniqueid="";
var chkid="";
var chkquery="0";
var gbratecode="";
var gbadtype="";
var gbcurrency="";
var gbratetype="";
var gbcolor="";
var gbuom="";
var gbpkgcode="";
var gbcenter="";
var changeRate=0;
var gdsexecute=null;
var hiddentext="";
var rowN=0;
var gcatcode="";
function openPriorityRate()
{
    if(document.getElementById('txtpkgdesc').value=='')
    {
        alert("Please Enter Package Description");
        return false;
    }
    else if(document.getElementById('txtpriorityrate').value=='')
    {
        alert("Please Enter Maximum Priority");
        document.getElementById('txtpriorityrate').focus();
        return false;
    }
    var pkgdesc=document.getElementById('txtpkgdesc').value;
    while(pkgdesc.indexOf("+")>=0)
    {
    pkgdesc=pkgdesc.replace("+","~");
    }
     window.open("prioritywiserate.aspx?priorityval="+document.getElementById("hiddenpriorityrates").value+"&rateid="+document.getElementById("hiddenrateuniqid").value+"&chkbtnStatus="+hiddentext+"&pkgdesc="+pkgdesc+"&priority="+document.getElementById('txtpriorityrate').value+"",'Priority', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=550px,height=300px');
     return false;
}
function loadXML(xmlFile) 
{
    var  httpRequest =null;

    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        //xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }
    cancelclick();
}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
}

function verify() 
{ 
    if (xmlDoc.readyState != 4) 
    { 
        return false; 
    } 
}

//function saverate()
function validation_savedtls(rateuniqueid)
{
    /*new change ankur for agency*/
    if(document.getElementById('hiddentype_agency').value!="company")
    {
        if(document.getElementById('drpagencycode').value=="0")
        {
            alert("Please select agency")
            document.getElementById('drpagencycode').focus();
            return false;
        }

    }
    
    if(document.getElementById('txtratecode').value=="")
    {
        alert('Please Enter Rate Code');
        document.getElementById('txtratecode').focus();
        return false;
    }




    if(document.getElementById('drpadtype').value=="0")
    {
        alert('Please Select Ad Type');
        document.getElementById('drpadtype').focus();
        return false;
    }

    if(document.getElementById('drprategroupcode').value=="0")
    {
        alert('Please Select Rate Group Code');
        document.getElementById('drprategroupcode').focus();
        return false;
    }
    if(document.getElementById('drpadcategory').value=="0")
    {
        alert('Please Select Ad Category');
        document.getElementById('drpadcategory').focus();
        return false;
    }
    
       if(document.getElementById('drpcurrency').value=="0")
    {
        alert('Please Select Currency');
        document.getElementById('drpcurrency').focus();
        return false;
    }
    
    if(document.getElementById('drppkgcode').value=="0")
    {
        alert('Please Select Package');
        document.getElementById('drppkgcode').focus();
        return false;
    }
    
 

    if(document.getElementById('drpuom').value=="0")
    {
        alert('Please Select UOM');
        document.getElementById('drpuom').focus();
        return false;
    }
    
      if(document.getElementById('txtvalidfrom').value=="")
    {
        alert('Please Fill Valid From');
        document.getElementById('txtvalidfrom').focus();
        return false;
    }

    if(document.getElementById('txtvalidto').value=="")
    {
        alert('Please Fill Valid To');
        document.getElementById('txtvalidto').focus();
        return false;
    }

    var fromdate=document.getElementById('txtvalidfrom').value;
	var todate=document.getElementById('txtvalidto').value;
	var fdate;
	var tdate;
	if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	{
	    var txt=fromdate;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        fromdate=mm+'/'+dd+'/'+yy;
	    fdate=new Date(fromdate);
	    
	     txt=todate;
         txt1=txt.split("/");
         dd=txt1[0];
         mm=txt1[1];
         yy=txt1[2];
        todate=mm+'/'+dd+'/'+yy;
	    tdate=new Date(todate);
	}
	else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
	{
	    var txt=fromdate;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        fromdate=mm+'/'+dd+'/'+yy;
	    fdate=new Date(fromdate);
	    
	     txt=todate;
         txt1=txt.split("/");
         yy=txt1[0];
         mm=txt1[1];
         dd=txt1[2];
        todate=mm+'/'+dd+'/'+yy;
	    tdate=new Date(todate);
	}
	else if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	{
	    fdate=new Date(fromdate);
	    tdate=new Date(todate);
	}
	
	
	
	if(fdate>tdate)
	{
	    alert("Valid From Date Should Be Less Than Valid To Date");
	    document.getElementById('txtvalidto').value="";
	    document.getElementById('txtvalidto').focus();
	    return false;
	}

    if(document.getElementById('txtsizefrom').value!="")
    {

        if(document.getElementById('txtsizeto').value=="")
        {
            alert('Please Fill ' +document.getElementById('lblSizefrom').innerHTML);
            document.getElementById('txtsizeto').focus();
            return false;
        }
    }

    if(document.getElementById('txtsizeto').value!="")
    {
        if(document.getElementById('txtsizefrom').value=="")
        {
            alert('Please Fill '+document.getElementById('lblsizeto').innerHTML);
            document.getElementById('txtsizefrom').focus();
            return false;
        }
    }
//
    if(document.getElementById('txtfrominsert').value!="")
    {

        if(document.getElementById('txttoinsert').value=="")
        {
            alert('Please Fill to insertion');
            document.getElementById('txttoinsert').focus();
            return false;
        }
    }

    if(document.getElementById('txttoinsert').value!="")
    {
        if(document.getElementById('txtfrominsert').value=="")
        {
            alert('Please Fill from insertion');
            document.getElementById('txtfrominsert').focus();
            return false;
        }
    }
    
    if(document.getElementById('txtfrominsert').value=="")
    {
        alert('Please Fill from insertion');
        document.getElementById('txtfrominsert').focus();
        return false;
    }
    
    if(document.getElementById('txttoinsert').value=="")
    {
        alert('Please Fill to insertion');
        document.getElementById('txttoinsert').focus();
        return false;
    }

  
	
    if(document.getElementById('drpcolor').value=="0")
    {
        alert('Please Fill Color');
        document.getElementById('drpcolor').focus();
        return false;
    }


    
    
    if((document.getElementById('txtrate').value=="" || document.getElementById('txtrate').value=="0") && (document.getElementById('txtextrarate').value=="" || document.getElementById('txtextrarate').value=="0") )
    {
        alert('Please Fill Week Day Rate');
        if(document.getElementById('txtrate').disabled==false)
            document.getElementById('txtrate').focus();
        return false;
    }

    /*change ankur*/
    if(document.getElementById('hiddenuomdesc').value=="ROL" || document.getElementById('hiddenuomdesc').value=="CD" || document.getElementById('hiddenuomdesc').value=="ROW" || document.getElementById('hiddenuomdesc').value=="ROD")
    {
        if(document.getElementById('txtrate').value!="")
        {
            if(document.getElementById('txtextrarate').value=="")
            {
                alert("Please enter week extra rate");
                document.getElementById('txtextrarate').focus();
                return false;
            }
            
        }
        if(document.getElementById('txtfocusrate').value!="")
        {
            if(document.getElementById('txtextrafocus').value=="")
            {
                alert("Please enter focus extra rate");
                document.getElementById('txtextrafocus').focus();
                return false;
            }
            
        }
        if(document.getElementById('txtweekrate').value!="")
        {
            if(document.getElementById('txtweekextra').value=="")
            {
                alert("Please enter weekend extra rate");
                document.getElementById('txtweekextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratesun').value!="")
        {
            if(document.getElementById('txtratesunextra').value=="")
            {
                alert("Please enter Sunday extra rate premium");
                document.getElementById('txtratesunextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratemon').value!="")
        {
            if(document.getElementById('txtratemonextra').value=="")
            {
                alert("Please enter Monday extra rate premium");
                document.getElementById('txtratemonextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratetue').value!="")
        {
            if(document.getElementById('txtratetueextra').value=="")
            {
                alert("Please enter Tuesday extra rate premium");
                document.getElementById('txtratetueextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratewed').value!="")
        {
            if(document.getElementById('txtratewedextra').value=="")
            {
                alert("Please enter Wednesday extra rate premium");
                document.getElementById('txtratewedextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratethu').value!="")
        {
            if(document.getElementById('txtratethuextra').value=="")
            {
                alert("Please enter Thursday extra rate premium");
                document.getElementById('txtratethuextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratefri').value!="")
        {
            if(document.getElementById('txtratefriextra').value=="")
            {
                alert("Please enter Friday extra rate premium");
                document.getElementById('txtratefriextra').focus();
                return false;
            }
            
        }
        
        if(document.getElementById('txtratesat').value!="")
        {
            if(document.getElementById('txtratesatextra').value=="")
            {
                alert("Please enter Saturday extra rate premium");
                document.getElementById('txtratesatextra').focus();
                return false;
            }
            
        }

    }

    ///for checking the rate whether they are equal to package rate or not
    var adtype=document.getElementById('drpadtype').value; 
    var adcat=document.getElementById('drpadcategory').value;
    var scat=document.getElementById('drpsubcategory').value
    var color=document.getElementById('drpcolor').value;
    var pckcode=document.getElementById('drppkgcode').value
    var currency=document.getElementById('drpcurrency').value//
    var validfrom=datesplit(document.getElementById('txtvalidfrom').value)
    var validto=datesplit(document.getElementById('txtvalidto').value)

    //---------------saurabh
    var uom = document.getElementById('drpuom').value;
   if(document.getElementById("chkvat").checked==true)
        vat="1";
    else
        vat="0";

    ////splitting date

    //////
if(document.getElementById('hiddenforfrid').value!="0")
{
    if(document.getElementById('hiddenbreakup').value == "1" && document.getElementById('txtpkgdesc').value.indexOf('+')>=0)
    {

        var arrayrate="";
        var arrayfocusrate="";

        var arrayweekend="";
        var arrayweekenrate="";
         
        if(document.getElementById('gridrate') == null)
        {
            alert("Please click on GO button");
            return false;
        }
        if(document.getElementById('tdbtngo').style.display=="block")
        {
            alert("Please click on GO button");
            return false;
        }
        
        var grid=document.getElementById('gridrate').rows.length-1;

        var gridid=document.getElementById('gridrate');

        var weekdayrate=parseFloat(document.getElementById('txtrate').value);
        var weekminrate=parseFloat(document.getElementById('txtminrate').value);

        var focusdayrate=parseFloat(document.getElementById('txtfocusrate').value);
        var focusminrate=parseFloat(document.getElementById('txtfocusmin').value);

        var weekendrate=parseFloat(document.getElementById('txtweekrate').value);
        var weekendminrate=parseFloat(document.getElementById('txtweekminrate').value);
        
        var rate = "";
        var focusrate = "";
        var weekendrate1 = "";
        
        var txtBox = "";

        for(var z=0;z<=grid-1;z++)
        {
            var t=0;
            t=z;
            t=t+1;
            
            
            
            /*var text="Text"+z;
            var texta="Texta"+z;
            var textb="Textb"+z;
            var textc="Textc"+z;
            var textd="Textd"+z;
            var texte="Texte"+z;*/

            txtBox = "txtGridRate" + z;
            rate = parseFloat(document.getElementById(txtBox).value);
            
            if(rate<weekminrate)
            {
                alert("Week Day Rate Should Be Greater Than  Min. Rate");
                document.getElementById(text).focus();
                return false;
            }
            if(document.getElementById(txtBox).value=="")
            {
                alert("Week Day Rate Should Be Greater Than  Min. Rate");
                document.getElementById(text).focus();
                return false;
            }
            
            
            txtBox = "txtFRate" + z;
            focusrate = parseFloat(document.getElementById(txtBox).value);
            
            if(focusrate<focusminrate)
            {
                alert("Focus Day Rate Should Be Less Than  Min. Rate");
                document.getElementById(txtBox).focus();
                return false;
            }
            
            
            
            if(arrayrate=="")
            {
                arrayrate=rate;
            }
            else
            {
                arrayrate=rate+arrayrate;
            }
            
            /*if(document.getElementById('drpadcategory').value!="0")
            {
                if(document.getElementById(textc).value=="")
                {
                    alert("Focus Day Rate Should Be Less Than  Min. Rate");
                    document.getElementById(textc).focus();
                    return false;

                }

            }*/
            
            if(arrayfocusrate=="")
            {
                arrayfocusrate=focusrate;
            }
            else
            {
                arrayfocusrate=focusrate+arrayfocusrate;
            }
            
            if(formatDecimal(arrayfocusrate,true,2)>focusdayrate || formatDecimal(arrayfocusrate,true,2)<focusdayrate )
            {
                alert("Total Focus Day Rate Should Be Equal To Package Focus Day Rate");
                document.getElementById(txtBox).focus();
                return false;
            }
            
            txtBox = "txtWEnRate" + z;
            weekendrate1 = parseFloat(document.getElementById(txtBox).value);
            
            if(weekendrate1<weekendminrate)
            {
                alert("Weekend Rate Should Be Less Than  Min. Rate");
                document.getElementById(txtBox).focus();
                return false;

            }
            if(arrayweekend=="")
            {
                arrayweekend=weekendrate1
            }
            else
            {
                arrayweekend=weekendrate1+arrayweekend
            }
            
        }
    
        /*if(formatDecimal(arrayrate,true,2)>weekdayrate || formatDecimal(arrayrate,true,2)<weekdayrate )
        {
            if(document.getElementById('tdbtngo').style.display!="none")
            {
                alert("Please click on GO button");
                return false;
            }
        }*/
    
        
        if(formatDecimal(arrayweekend,true,2)>weekendrate || formatDecimal(arrayweekend,true,2)<weekendrate)
        {
            alert("Total Weekend Rate Should Be Equal To Package Weekend Rate");
            document.getElementById(txtBox).focus();
            return false;        
        }
    

    //////////////////////////////////////////////////////////////////////////////////////////////

 
/////////////////this is to save or modify into the rate details 

        /*if(document.getElementById('hiddenforfrid').value=="0")
        {
            var page=rateuniqueid;
            var type_=document.getElementById('hiddentype_agency').value;
            var id;
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open("GET","ratecodechk.aspx?page="+page+"&type_="+type_, false);
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
                var type_=document.getElementById('hiddentype_agency').value;
                var page=rateuniqueid
		        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        xml.Open( "GET","ratecodechk.aspx?page="+page+"&type_="+type_, false );
		        xml.Send();
		        var id=xml.responseText;
            }
            
            if(id=="Y")
            {
                alert("This rate exists in ratedetails");
                return false;
            }

            var ratecode=document.getElementById('txtratecode').value;
            var compcode=document.getElementById('hiddencompcode').value;
            var userid=document.getElementById('hiddenuserid').value
            var grid=document.getElementById('rategrid').rows.length-1;

            var gridid=document.getElementById('rategrid');

            for(var z=0;z<=grid-1;z++)
            {
                var t=0;
                t=z;
                t=t+1;
                var text="Text"+z;
                var texta="Texta"+z;
                var textb="Textb"+z;
                var textc="Textc"+z;
                var textd="Textd"+z;
                var texte="Texte"+z;

                var nameofedition=gridid.rows[t].cells[0].innerHTML; 

                var rate=document.getElementById(text).value;

                var focusrate=document.getElementById(textc).value;

            }



        }
        else*/
        if(document.getElementById('hiddenforfrid').value!="0")
        {
            /*if(chkflag!="0" &&  chkflag!="")
            { 
                var alpac=document.getElementById('txtpkgdesc').value;
                var alpac1=alpac.split("-");
                if(document.getElementById('tdbtngo').style.display=="block" && alpac1.length!=3 && document.getElementById('hiddenbreakup').value=="1")
                {
                alert("Please Click On Go Button To see The Rate Break Up");
                document.getElementById('tdbtngo').style.display="block"
                return false;

                }
                chkflag="0";
            }*/
            document.getElementById('hiddenchkforgo').value="0"
            var ratecode=document.getElementById('txtratecode').value;
            var compcode=document.getElementById('hiddencompcode').value;
            var userid=document.getElementById('hiddenuserid').value
            var grid=document.getElementById('gridrate').rows.length-1;

            var gridid=document.getElementById('gridrate');

            for(var z=0;z<=grid-1;z++)
            {
                var t=0;
                t=z;
                t=t+1;
                var text="txtGridRate"+z;
                var texta="Texta"+z;
                var textb="Textb"+z;
                //var textc="txtFRate"+z;
                  var textc="txtSWRate"+z;
                var textd="txtWEnRate"+z;
                var texte="Texte"+z;

                var textx="txtWExRate"+z;
                var texty="txtFExRate"+z;
             
                //var textz="Textz"+z;

                var Text_sun_rate="txtSunRate"+z;
                var Text_mon_rate="txtMonRate"+z;
                var Text_tue_rate="txtTueRate"+z;
                var Text_wed_rate="txtWedRate"+z;
                var Text_thu_rate="txtThuRate"+z;
                var Text_fri_rate="txtFriRate"+z;
                var Text_sat_rate="txtSatRate"+z;

                var Text_sun_rate_extra="txtSunExRate"+z;
                var Text_mon_rate_extra="txtMonExRate"+z;
                var Text_tue_rate_extra="txtTueExRate"+z;
                var Text_wed_rate_extra="txtWedExRate"+z;
                var Text_thu_rate_extra="txtThuExRate"+z;
                var Text_fri_rate_extra="txtFriExRate"+z;
                var Text_sat_rate_extra="txtSatExRate"+z;
                
                var gridedi="txtPkgName"+z;

                var nameofedition=document.getElementById(gridedi).value; 

                var rate=document.getElementById(text).value;
                var weekendrate=document.getElementById(textd).value;
                var focusrate=document.getElementById(textc).value;

                var weekextrarate=document.getElementById(textx).value;
                var focusextrarate=document.getElementById(texty).value;
                var weekendextrarate=0;//document.getElementById(textz).value;

                var sun_rate=document.getElementById(Text_sun_rate).value;
                var mon_rate=document.getElementById(Text_mon_rate).value;
                var tue_rate=document.getElementById(Text_tue_rate).value;
                var wed_rate=document.getElementById(Text_wed_rate).value;
                var thu_rate=document.getElementById(Text_thu_rate).value;
                var fri_rate=document.getElementById(Text_fri_rate).value;
                var sat_rate=document.getElementById(Text_sat_rate).value;

                var sun_rate_extra=document.getElementById(Text_sun_rate_extra).value;
                var mon_rate_extra=document.getElementById(Text_mon_rate_extra).value;
                var tue_rate_extra=document.getElementById(Text_tue_rate_extra).value;
                var wed_rate_extra=document.getElementById(Text_wed_rate_extra).value;
                var thu_rate_extra=document.getElementById(Text_thu_rate_extra).value;
                var fri_rate_extra=document.getElementById(Text_fri_rate_extra).value;
                var sat_rate_extra=document.getElementById(Text_sat_rate_extra).value;

                var adtype=document.getElementById("drpadtype").value;
                var pubcenter=document.getElementById("drppubcenter").value;
                var type_agency=document.getElementById('hiddentype_agency').value;
                rateuniqueid=document.getElementById("hiddenrateuniqid").value;
                Ratemaster.updateratedetail(rate,focusrate,ratecode,compcode,userid,nameofedition,rateuniqueid,weekendrate,type_agency,weekextrarate,focusextrarate,weekendextrarate, sun_rate, mon_rate, tue_rate, wed_rate, thu_rate, fri_rate, sat_rate,sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,adtype,pubcenter);
                
        
            }
        }
    }
  
  //////////////this is to modify the data for solorate
  
    /*if(document.getElementById('hiddensolo').value=="solo"  && document.getElementById('hiddenbreakup').value=="1")
    {
        var alpac=document.getElementById('txtpkgdesc').value;
        var alpac1=alpac.split("-");
        if(document.getElementById('tdbtngo').style.display=="block" && alpac1.length!=3 && alpac1.length>3 && document.getElementById('hiddenbreakup').value=="1" )
        {
            alert("Please Click On Go Button To see The Rate Break Up");
            document.getElementById('tdbtngo').style.display="block"
            return false;
        }
        
        var arrayrate="";
        var arrayfocusrate="";

        var arrayweekend="";
        var arrayweekenrate="";
        var grid=0;
        var gridid;
        if(document.getElementById('rategrid')!=null)
        {
            grid=document.getElementById('rategrid').rows.length-1;
            gridid=document.getElementById('rategrid');
        }

        var weekdayrate=parseFloat(document.getElementById('txtrate').value);
        var weekminrate=parseFloat(document.getElementById('txtminrate').value);

        var focusdayrate=parseFloat(document.getElementById('txtfocusrate').value);
        var focusminrate=parseFloat(document.getElementById('txtfocusmin').value);

        var weekendrate=parseFloat(document.getElementById('txtweekrate').value);
        var weekendminrate=parseFloat(document.getElementById('txtweekminrate').value);


        for(var z=0;z<=grid-1;z++)
        {
            var t=0;
            t=z;
            t=t+1;
            var text="Text"+z;
            var texta="Texta"+z;
            var textb="Textb"+z;
            var textc="Textc"+z;
            var textd="Textd"+z;
            var texte="Texte"+z; 

            var rate=parseFloat(document.getElementById(text).value);
            if(rate<weekminrate)
            {
                alert("Week Day Rate Should Be Greater Than  Min. Rate");
                document.getElementById(text).focus();
                return false;
            }
            if(document.getElementById(text).value=="")
            {
                alert("Week Day Rate Should Be Greater Than  Min. Rate");
                document.getElementById(text).focus();
                return false;
            }
            if(arrayrate=="")
            {
                arrayrate=rate;
            }
            else
            {
                arrayrate=rate+arrayrate;
            }
            
            var focusrate=parseFloat(document.getElementById(textc).value);
            
            if(focusrate<focusminrate)
            {
                alert("Focus Day Rate Should Be Less Than  Min. Rate");
                document.getElementById(textc).focus();
                return false;
            }
            if(document.getElementById('drpadcategory').value!="0")
            {
                if(document.getElementById(textc).value=="")
                {
                    alert("Focus Day Rate Should Be Less Than  Min. Rate");
                    document.getElementById(textc).focus();
                    return false;
                
                }
            }
            if(arrayfocusrate=="")
            {
                arrayfocusrate=focusrate;
            }
            else
            {
                arrayfocusrate=focusrate+arrayfocusrate;
            }
    
            var weekendrate1=parseFloat(document.getElementById(textd).value);
            if(weekendrate1<weekendminrate)
            {
                alert("Weekend Rate Should Be Less Than  Min. Rate");
                document.getElementById(textd).focus();
                return false;
            }
            
            if(arrayweekend=="")
            {
                arrayweekend=weekendrate1
            }
            else
            {
                arrayweekend=weekendrate1+arrayweekend
            }
        }
        
        if((arrayrate>weekdayrate || arrayrate<weekdayrate) &&  arrayrate!="")
        {
            alert("Total Week Day Rate Should Be Equal To Package Week Day Rate");
            document.getElementById(text).focus();
            return false;
        }
        //change ankur
        if((arrayfocusrate>focusdayrate || arrayfocusrate<focusdayrate) &&  arrayfocusrate!="")
        {
            alert("Total Focus Day Rate Should Be Equal To Package Focus Day Rate");
            document.getElementById(textc).focus();
            return false;
        }
        //change ankur
        if((arrayweekend>weekendrate || arrayweekend<weekendrate) &&  arrayweekend!="")
        {
            alert("Total Weekend Rate Should Be Equal To Package Weekend Rate");
            document.getElementById(textd).focus();
            return false;
        }
    
        var pac=document.getElementById('txtpkgdesc').value;
        var pac1=pac.split("-");
        if(document.getElementById('hiddensolo').value=="solo" && pac1.length==2 && document.getElementById('hiddenforfrid').value=="1"  && document.getElementById('hiddenbreakup').value=="1")
        {
            var ratecode=document.getElementById('txtratecode').value;
            var compcode=document.getElementById('hiddencompcode').value;
            var userid=document.getElementById('hiddenuserid').value
            var grid=document.getElementById('rategrid').rows.length-1;
            var gridid=document.getElementById('rategrid');
            var packagecode=document.getElementById('drppkgcode').value;
            var adtypecode=document.getElementById('drpadtype').value;
            var color=document.getElementById('drpcolor').value;
            var adcatcode=document.getElementById('drpadcategory').value;
            var adsucatcode=document.getElementById('drpsubcategory').value;
            var currcode=document.getElementById('drpcurrency').value;
            var validfrom=document.getElementById('txtvalidfrom').value;
            var validto=document.getElementById('txtvalidto').value;
            var uom=document.getElementById('drpuom').value;
                        
            /////////////////////this is to check at modify time  that the solo rate modify has been assigned to any package and if is then it will not modify
                        
                        

            for(var z=0;z<=grid-1;z++)
            {
                var t=0;
                t=z;
                t=t+1;
                var text="Text"+z;
                var texta="Texta"+z;
                var textb="Textb"+z;
                var textc="Textc"+z;
                var textd="Textd"+z;
                var texte="Texte"+z;

                var nameofedition=gridid.rows[t].cells[0].innerHTML; 

                var rate=document.getElementById(text).value;
                var weekendrate=document.getElementById(textd).value;
                var focusrate=document.getElementById(textc).value;
                var type_agen=document.getElementById('hiddentype_agency').value;
                //new change ankur for agency
                Ratemaster.updatesolorate(rate,focusrate,ratecode,compcode,userid,nameofedition,rateuniqueid,weekendrate,type_agen);
            }
        }
  
    }*/
}
    return true;
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



var popUpWin2=null;
function  adon()
{ 

  if(document.getElementById('lbaddon').disabled==true && document.getElementById("hiddenshow").value != "2")
  {
  return false;
  }
 
  var pkgcode=document.getElementById('drppkgcode').value;
	var ratecode=document.getElementById('txtratecode').value;
	var pkgdesc=document.getElementById('txtpkgdesc').value;
	var saveormodify=document.getElementById('hiddenforfrid').value;
	var show=document.getElementById('hiddenshow').value;
	if(document.getElementById('hiddenrateid').value!="" || document.getElementById('hiddenrateid').value!=null)
	{
    var ratesaveid=document.getElementById('hiddenrateid').value;
    }
    else
    {
     var ratesaveid=document.getElementById('txtratecode').value + document.getElementById('drpadtype').value + document.getElementById('drpadcategory').value + document.getElementById('drpsubcategory').value + document.getElementById('drpcolor').value + document.getElementById('drppkgcode').value + document.getElementById('drpcurrency').value+document.getElementById('txtvalidfrom').value+document.getElementById('txtvalidto').value;
    }
	pkgdesc=pkgdesc.replace('+','$')
	
	if(popUpWin2 && !popUpWin2.closed)
	{
	popUpWin2.focus();
	return false;
	}
	else
	{
	
	if(document.getElementById('txtratecode').value=="" || document.getElementById('txtpkgdesc').value=="" || document.getElementById('drppkgcode').value=="0"||document.getElementById('drpadtype').value=="0"||document.getElementById('drpcolor').value=="0"||document.getElementById('drpcurrency').value=="0"||document.getElementById('txtvalidto').value==""||document.getElementById('txtvalidfrom').value=="")
	
	{
	alert("Please Fill Mandatory Fields");
	return false;
	}
	//var ratesaveid=document.getElementById('txtratecode').value + document.getElementById('drpadtype').value + document.getElementById('drpadcategory').value + document.getElementById('drpsubcategory').value + document.getElementById('drpcolor').value + document.getElementById('drppkgcode').value + document.getElementById('drpcurrency').value+document.getElementById('txtvalidfrom').value+document.getElementById('txtvalidto').value;
	var ratesaveid;
	/*if(document.getElementById('hiddenadtype').value=="DISPLAY")
    {
    //new change ankur for agency
        if(document.getElementById('hiddentype_agency').value=="company")
        {
            ratesaveid=document.getElementById('txtratecode').value + document.getElementById('drpadtype').value + document.getElementById('drpadcategory').value + document.getElementById('drpsubcategory').value + document.getElementById('drpcolor').value + document.getElementById('drppkgcode').value + document.getElementById('drpcurrency').value+document.getElementById('txtvalidfrom').value+document.getElementById('txtvalidto').value+document.getElementById('drpuom').value+document.getElementById('drppremium').value+document.getElementById('txtfrominsert').value+document.getElementById('txttoinsert').value+document.getElementById('drpclientcat').value;//+document.getElementById('txtminarea').value            ;
        }
        else
        {
            ratesaveid=document.getElementById('txtratecode').value + document.getElementById('drpadtype').value + document.getElementById('drpadcategory').value + document.getElementById('drpsubcategory').value + document.getElementById('drpcolor').value + document.getElementById('drppkgcode').value + document.getElementById('drpcurrency').value+document.getElementById('txtvalidfrom').value+document.getElementById('txtvalidto').value+document.getElementById('drpuom').value+document.getElementById('drppremium').value+document.getElementById('txtfrominsert').value+document.getElementById('txttoinsert').value+document.getElementById('drpclientcat').value+document.getElementById('drpagencycode').value            ;
        }    
    }
    else
    {
        
     //new change ankur for agency
        if(document.getElementById('hiddentype_agency').value=="company")
        {
            ratesaveid=document.getElementById('txtratecode').value + document.getElementById('drpadtype').value + document.getElementById('drpadcategory').value + document.getElementById('drpsubcategory').value + document.getElementById('drpcolor').value + document.getElementById('drppkgcode').value + document.getElementById('drpcurrency').value+document.getElementById('txtvalidfrom').value+document.getElementById('txtvalidto').value+document.getElementById('drpuom').value+document.getElementById('drpadscat4').value+ document.getElementById('drpadscat5').value+ document.getElementById('drpadscat6').value+document.getElementById('drppremium').value+document.getElementById('txtsizefrom').value+document.getElementById('txtsizeto').value+document.getElementById('txtfrominsert').value+document.getElementById('txttoinsert').value+document.getElementById('drpclientcat').value;//+document.getElementById('txtminarea').value            ;      
        }
        else
        {
            ratesaveid=document.getElementById('txtratecode').value + document.getElementById('drpadtype').value + document.getElementById('drpadcategory').value + document.getElementById('drpsubcategory').value + document.getElementById('drpcolor').value + document.getElementById('drppkgcode').value + document.getElementById('drpcurrency').value+document.getElementById('txtvalidfrom').value+document.getElementById('txtvalidto').value+document.getElementById('drpuom').value+document.getElementById('drpadscat4').value+ document.getElementById('drpadscat5').value+ document.getElementById('drpadscat6').value+document.getElementById('drppremium').value+document.getElementById('txtsizefrom').value+document.getElementById('txtsizeto').value+document.getElementById('txtfrominsert').value+document.getElementById('txttoinsert').value+document.getElementById('drpclientcat').value+document.getElementById('drpagencycode').value            ;      
        }    
    }*/
	ratesaveid=document.getElementById("hiddenrateuniqid").value;
	
	
            //    popUpWin2 
            //     = window.open('bank_detail.aspx?pkgcode='+pkgcode+'&ratecode='+ratecode+'&show='+show,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=244,left=210,width=780px,height=415px'); 
/*new change ankur for agency*/
var type_age=document.getElementById('hiddentype_agency').value
            popUpWin2 
                 = window.open('addon.aspx?pkgcode='+pkgcode+'&ratecode='+ratecode+'&pkgdesc='+pkgdesc+'&savemodify='+saveormodify+'&show='+show+'&ratesaveid='+ratesaveid+'&type_age='+type_age,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=244,left=210,width=780px,height=415px'); 



              popUpWin2.focus();
     }
     return false;
 

} 



function winclose()
{
window.close();
return false;
}



function selectcomm(ab)
{

if(document.getElementById('hideshow').value=="2")
{
    if(document.getElementById(ab).checked==false)
    {
    document.getElementById(ab).checked=false;
    document.getElementById('drppub').value="0";
    document.getElementById('drpsup').value="0";
    document.getElementById('drpedition').value="0";
    document.getElementById('txtrate').value="";
     document.getElementById('txtnoofinsert').value="";
    document.getElementById('btndelete').disabled=true;
    return; 
    }
    
    
    var idz=ab;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var datagrid=document.getElementById('DataGrid1');

var jz;
var tz;
var kz=0;
var iz=document.getElementById("DataGrid1").rows.length -1;

for(jz=0;jz<iz;jz++)
	{
	
	var strz="Box1"+jz;
        document.getElementById(strz).checked=false;
        document.getElementById(idz).checked=true;
        if(idz==strz)
        {
	            if(document.getElementById(idz).checked==true)
	            {
	            kz=kz+1;
	           chkid=document.getElementById('hiddencode').value=code11=document.getElementById(idz).value;
	            chk123=document.getElementById(idz);
	            }
	    }
	}
    
     var compcode=document.getElementById('hiddencomcode').value;
   var ratecode=document.getElementById('hiddenratecode').value;
    document.getElementById('btnclear').disabled=false;
    /*new change ankur for agency*/
    var type_age= document.getElementById('hiddentype_agency').value;
      if(kz==1)
	  {
	    Addon.getdata(compcode,ratecode,code11,type_age,call_comm)
	    return ;
	  }
	  
    
return false;
}//end of execute click mode -----> next is for modify click mode-->
if(document.getElementById(ab).checked==false)
{
document.getElementById(ab).checked=false;
document.getElementById('drppub').value="0";
document.getElementById('drpsup').value="0";
document.getElementById('drpedition').value="0";
document.getElementById('txtrate').value="";
 document.getElementById('txtnoofinsert').value="";
 document.getElementById('btndelete').disabled=true;
return; 
}

var id=ab;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var datagrid=document.getElementById('DataGrid1');

var j;
var t;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	
	var str="Box1"+j;
        document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(id==str)
        {
	            if(document.getElementById(id).checked==true)
	            {
	            k=k+1;
	           chkid=document.getElementById('hiddencode').value=code11=document.getElementById(id).value;
	            chk123=document.getElementById(id);
	            }
	    }
	}
	        if(k==1)
	        {
	                document.getElementById('btndelete').disabled=false; 
	               // return false;
	        }
	        
	       
   var compcode=document.getElementById('hiddencomcode').value;
   var ratecode=document.getElementById('hiddenratecode').value;
   var pub=document.getElementById('drppub').value;
   var edition=document.getElementById('drpedition').value;
   var sup=document.getElementById('drpsup').value;
   var rate=document.getElementById('txtrate').value;

/*new change ankur for agency*/
/*new change ankur for agency*/
    var type_age= document.getElementById('hiddentype_agency').value;
    Addon.getdata(compcode,ratecode,code11,type_age,call_comm)
	        
	return ;
					
}



function call_comm(response)

{
var ds= response.value;

//alert("hi");
document.getElementById('txtrate').value=ds.Tables[0].Rows[0].Rate;
if(ds.Tables[0].Rows[0].noofinsert!=null)
    document.getElementById('txtnoofinsert').value=ds.Tables[0].Rows[0].noofinsert;
else
    document.getElementById('txtnoofinsert').value="";    
document.getElementById('txtextrarate').value=ds.Tables[0].Rows[0].EXTRARATE;
//document.getElementById('drpedition').value=ds.Tables[0].Rows[0].Edition;
//document.getElementById('drpsup').value=ds.Tables[0].Rows[0].SUPPLEMENT;
document.getElementById('drppub').value=ds.Tables[0].Rows[0].Publication;

var editobject=document.getElementById('drpedition');
var suppobject=document.getElementById('drpsup');
/////this the xml to fetch the value of edition and supplement 
        var str="0";
        var page;
        var supp;
         var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","editonforcontractaspx.aspx?page="+document.getElementById('drppub').value+"&str="+str+"&supp="+document.getElementById('drpedition').value, false);
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
		xml.Open( "GET","editonforcontractaspx.aspx?page="+document.getElementById('drppub').value+"&str="+str+"&supp="+document.getElementById('drpedition').value, false );
		xml.Send();
       var id=xml.responseText;
       }
		
		var split=id.split("+");
		var editcode=split[0];
		var editcode1=editcode.split(",");
		var editname=split[1];
		var editname1=editname.split(",");
		editobject.options.length=0;
		editobject.options[editobject.options.length]=new Option('-Select Edition-','0');
		for(z=0;z<=editcode1.length-1;z++)
		{
		    if(editcode1[z]!=",")
		    {
		      if(editcode1[z]!="0")
		        {
		        editobject.options[editobject.options.length]=new Option(editname1[z],editcode1[z]);
                editobject.options.length;
		        }
		    }
		}


document.getElementById('drpedition').value=ds.Tables[0].Rows[0].Edition;
document.getElementById('hiddenedival').value=ds.Tables[0].Rows[0].Edition;

////this is to fetch supplement

 //var str="0";
        var page;
        var tstr="1";
        var supp;
         var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","editonforcontractaspx.aspx?page="+document.getElementById('drppub').value+"&str="+tstr+"&supp="+document.getElementById('drpedition').value, false);
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
		xml.Open( "GET","editonforcontractaspx.aspx?page="+document.getElementById('drppub').value+"&str="+tstr+"&supp="+document.getElementById('drpedition').value, false );
		xml.Send();
		var idsupp=xml.responseText;
		}
		suppobject.options.length=0;
		suppobject.options[suppobject.options.length]=new Option('-Select Supplement-','0');
		var split1=idsupp.split("+");
		var suppcode=split1[0];
		var suppcode1=suppcode.split(",");
		
		var suppname=split1[1];
		var suppname1=suppname.split(",");
		
		for(t=0;t<=suppcode1.length-1;t++)
		{
		    if(suppcode1[t]!=",")
		    {
		        if(suppcode1[t]!="0")
		        {
		        suppobject.options[suppobject.options.length]=new Option(suppname1[t],suppcode1[t]);
                suppobject.options.length;
		        }
		    }
		}        


document.getElementById('drpsup').value=ds.Tables[0].Rows[0].SUPPLEMENT;
document.getElementById('hiddensupval').value=ds.Tables[0].Rows[0].SUPPLEMENT;
//;



//return false;
}

function saveclickrate()
{

 if(document.getElementById('drppub').value=="0")
{
alert("Please Select The Publication");
document.getElementById('drppub').focus();
return false;
}
else if(document.getElementById('drpedition').value=="0")
{
alert("Please Select The Edition");
document.getElementById('drpedition').focus();
return false;
}
else if((document.getElementById('txtrate').value=="") && (document.getElementById('txtextrarate').value=="" || document.getElementById('txtextrarate').value=="0"))
{
alert("Please Enter The Rate");
if(document.getElementById('txtrate').disabled==false)
document.getElementById('txtrate').focus();
return false;
}

   var compcode=document.getElementById('hiddencomcode').value;
   var ratecode=document.getElementById('hiddenratecode').value;
   var publication=document.getElementById('drppub').value;
   var edition=document.getElementById('drpedition').value;
   var supp=document.getElementById('drpsup').value;
   var rate=document.getElementById('txtrate').value;
   var code=document.getElementById('hiddencode').value;
   var pkgname=document.getElementById('txtpkg').value;
   var userid=document.getElementById('hiddenuserid').value;
   var pkgdesc=document.getElementById('txtdesc').value;
   var pkgcode=document.getElementById('hiddenpkgcode').value;
   var rateid=document.getElementById('hiddenrateuniqueid').value; 
   var extrarate=document.getElementById('txtextrarate').value;
//   if(document.getElementById("chkvat").checked==true)
//        vat="1";
//    else
//        vat="0";
   if(extrarate=="")
   {
    extrarate="0";
   }
   
   
   /*new change ankur for agency*/
   var type_age=document.getElementById('hiddentype_agency').value; 
   

        if(document.getElementById('hiidensanod').value=="0" && code=="")
        {
        ////////////////this is to chk the duplicacy in the add on pop up
       
        var flag="0";
        var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
/*new change ankur for agency*/             
                        httpRequest.open("GET","duplicacyaddon.aspx?publication="+publication+"&edition="+edition+"&supp="+supp+"&rateid="+rateid+"&flag="+flag+"&type_age="+type_age, false );
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
		/*new change ankur for agency*/
		xml.Open( "GET","duplicacyaddon.aspx?publication="+publication+"&edition="+edition+"&supp="+supp+"&rateid="+rateid+"&flag="+flag+"&type_age="+type_age, false );
		xml.Send();
		var id=xml.responseText;
		}
		if(id=="0")
		{
		alert("This Record Already Exists");
		return false;
		}
        
        return;
        }
        else if(code=="")
        {
        
        var flag="0";
         var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","duplicacyaddon.aspx?publication="+publication+"&edition="+edition+"&supp="+supp+"&rateid="+rateid+"&flag="+flag+"&type_age="+type_age, false );
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
		xml.Open( "GET","duplicacyaddon.aspx?publication="+publication+"&edition="+edition+"&supp="+supp+"&rateid="+rateid+"&flag="+flag+"&type_age="+type_age, false );
		xml.Send();
		var id=xml.responseText;
		}
		if(id=="0")
		{
		alert("This Record Already Exists");
		return false;
		}
        
        /*new change ankur for agency*/
        Addon.insert(publication, edition, supp, rate, compcode, userid, pkgcode, pkgdesc, pkgname, ratecode,rateid,type_age,extrarate,document.getElementById('txtnoofinsert').value);
        window.location=window.location;
        }
        if(code!="")
        {
    
        var flag=code11;
         var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","duplicacyaddon.aspx?publication="+publication+"&edition="+edition+"&supp="+supp+"&rateid="+rateid+"&flag="+flag+"&type_age="+type_age, false  );
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
		xml.Open( "GET","duplicacyaddon.aspx?publication="+publication+"&edition="+edition+"&supp="+supp+"&rateid="+rateid+"&flag="+flag+"&type_age="+type_age, false );
		xml.Send();
		var id=xml.responseText;
		}
		if(id=="0")
		{
		alert("This Record Already Exists");
		return false;
		}
        
        /*new change ankur for agency*/
        if(extrarate=="")
               {
                extrarate="0";
               }
        Addon.update(publication, edition, supp, rate, compcode, code, ratecode,rateid,type_age,extrarate,document.getElementById('txtnoofinsert').value);
        document.getElementById('hiddencode').value==""
        window.location=window.location;
        }
return false;
}

function chkpackage()
{
    if(confirm("This Package Name Rate Has already Been Entered Do You Want To Continue"))
		{
		
		return ;
		}
		return false;

}

function closerate()
{
    if(confirm("Do you want to skip this page"))
{
window.close();

}

return false;
}

function chksize()
{
if(document.getElementById('drpuom').value=="0")
{
alert("Please Select UOM");
document.getElementById('txtsizeto').value="";
return false;
}

if(document.getElementById('txtsizefrom').value=="")
{
alert("Please Fill Size From");
document.getElementById('txtsizefrom').focus();
return false;
}

var sizefrom=parseFloat(document.getElementById('txtsizefrom').value);
var sizeto=parseFloat(document.getElementById('txtsizeto').value);

if(sizefrom > sizeto)
{
alert("Size From should be less than Size To");
document.getElementById('txtsizeto').value="";
document.getElementById('txtsizeto').focus();
return false;


}

return ;
}
function chksizefrom()
{
if(document.getElementById('drpuom').value=="0")
{
alert("Please Select UOM");
document.getElementById('txtsizefrom').value="";
return false;
}

//if(document.getElementById('txtsizeto').value=="")
//{
////alert("Please Fill Size To");
// 
//        alert('Please Fill '+document.getElementById('lblsizeto').innerHTML);
//      
//document.getElementById('txtsizeto').focus();
//return false;
//}

var sizefrom=parseFloat(document.getElementById('txtsizefrom').value);
var sizeto=parseFloat(document.getElementById('txtsizeto').value);

if(sizefrom > sizeto)
{
alert("Size From Should be less than Size To");
document.getElementById('txtsizefrom').value="";
document.getElementById('txtsizefrom').focus();
return false;
}
}

function chkeditionfrom() {


    var edifrom = parseFloat(document.getElementById('txtedfrom').value);
    var edito = parseFloat(document.getElementById('txtedto').value);

    if (edifrom > edito) {
        alert("Edition From Should be less than Edition To");
        document.getElementById('txtedfrom').value = "";
        document.getElementById('txtedfrom').focus();
        return false;
    }


}




function chkeditionto() {


    var edifrom = parseFloat(document.getElementById('txtedfrom').value);
    var edito = parseFloat(document.getElementById('txtedto').value);

    if (edifrom > edito) {
        alert("Edition To  Should be greater than Edition From");
        document.getElementById('txtedto').value = "";
        document.getElementById('txtedto').focus();
        return false;
    }


}

function chkminsize() {


    var minsize = parseFloat(document.getElementById('txtminarea').value);
    var maxsize = parseFloat(document.getElementById('txtmaxarea').value);

    if (minsize > maxsize) {
        alert("Min Size  Should be less than Max Size");
        document.getElementById('txtminarea').value = "";
        document.getElementById('txtminarea').focus();
        return false;
    }


}



function chkmaxsize() {


    var minsize = parseFloat(document.getElementById('txtminarea').value);
    var maxsize = parseFloat(document.getElementById('txtmaxarea').value);

    if (minsize > maxsize) {
        alert("Max  Size  Should be greater  than Min Size");
        document.getElementById('txtminarea').value = "";
        document.getElementById('txtminarea').focus();
        return false;
    }


}


function chkminwidth() {


    var minsize = parseFloat(document.getElementById('txtminwidth').value);
    var maxsize = parseFloat(document.getElementById('txtmaxwidth12').value);

    if (minsize > maxsize) {
        alert("Min Width  Should be less than Max Width");
        document.getElementById('txtminwidth').value = "";
        document.getElementById('txtminwidth').focus();
        return false;
    }


}



function chkmaxwidth() {

    var minsize = parseFloat(document.getElementById('txtminwidth').value);
    var maxsize = parseFloat(document.getElementById('txtmaxwidth12').value);

    if (minsize > maxsize) {
        alert("Max  Width  Should be greater  than Min Width");
        document.getElementById('txtminwidth').value = "";
        document.getElementById('txtminwidth').focus();
        return false;
    }


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
			if(fld.match(/^\d+(\.\d{1,3})?$/i))
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
			if(fld.match(/^\d+(\.\d{1,3})?$/i))
			{
			//return true;
			checkpackagerate();
			}
			else
			{
			alert("Input Error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			//document.getElementById(str).focus();
			//e.id.focus();
			return false;
			}
			}
			
			}
			
function gridnotchar()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}

function saveintoratedetail()
{
 var id;
 /*new change ankur for agency*/
        var type_=document.getElementById('hiddentype_agency').value;
        var page=document.getElementById('txtratecode').value;
        
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","ratecodechk.aspx?page="+page+"&type_="+type_, false );
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
        /*new change ankur for agency*/
        var type_=document.getElementById('hiddentype_agency').value;
        var page=document.getElementById('txtratecode').value;
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","ratecodechk.aspx?page="+page+"&type_="+type_, false );
		xml.Send();
		var id=xml.responseText;
        }
if(id=="Y")
{
alert("This rate exists in ratedetails");
return false;
}

var ratecode=document.getElementById('txtratecode').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value
var grid=document.getElementById('rategrid').rows.length-1;

var gridid=document.getElementById('rategrid');

for(var z=0;z<=grid-1;z++)
{
var t=0;
t=z;
t=t+1;
var text="Text"+z;
var texta="Texta"+z;
var textb="Textb"+z;
var textc="Textc"+z;
var textd="Textd"+z;
var texte="Texte"+z;

var nameofedition=gridid.rows[t].cells[0].innerHTML; 

var rate=document.getElementById(text).value;
//var week=document.getElementById(texta).value;
//var weekextra=document.getElementById(textb).value;
var focusrate=document.getElementById(textc).value;
//var focusmin=document.getElementById(textd).value;
//var focusextra=document.getElementById(texte).value;
var type_agen=document.getElementById('hiddentype_agency').value
/*new change ankur for agency*/
Ratemaster.insertratedetail(rate,focusrate,ratecode,compcode,userid,nameofedition,type_agen);
}


document.getElementById('drppkgcode').value = "0";
                document.getElementById('txtratecode').value = "";
                document.getElementById('drpadtype').value = "0";
                document.getElementById('drprategroupcode').value = "0";
                document.getElementById('drpadcategory').value = "0";
                //drpcurrency.SelectedValue = "0";
                //drpcurrency.SelectedValue = Session["currency"].ToString();
                document.getElementById('drpsubcategory').value = "0";

                document.getElementById('txtpkgdesc').value = "";
                document.getElementById('drpuom').value = "0";
                document.getElementById('txtvalidfrom').value = "";
                document.getElementById('txtsizefrom').value = "";
                document.getElementById('txtvalidto').value = "";
                document.getElementById('txtsizeto').value = "";
                document.getElementById('txtconsperiod').value = "";
                document.getElementById('drpcolor').value = "0";
                document.getElementById('drpcolortyp').value = "0";
                document.getElementById('txtremarks').value = "";
                document.getElementById('txtrate').value = "";
                document.getElementById('txtminrate').value = "";
                document.getElementById('txtextrarate').value = "";
                document.getElementById('txtfocusrate').value = "";
                document.getElementById('txtfocusmin').value = "";
                document.getElementById('txtextrafocus').value = "";
                document.getElementById('txtflramount').value = "";
                document.getElementById('txtflrdiscount').value = "";
                
                document.getElementById('drpscheme').value = "0";
                 document.getElementById("chkvat").checked=false;


}


function chkrate(e)
{

var flag=chkamount(e);
if(flag=="f")
{
return false;

}

}

function chkratevalue(e)
{
changeRate=1;
var flag=chkamount(e);
if(flag=="f")
{
return false;

}

if(document.getElementById('hiddenforfrid').value!="0")
{
    chkflag="1";
}

//  
if(document.getElementById('hiddenforfrid').value=="1" &&  document.getElementById('hiddenbreakup').value=="1")
{
    document.getElementById('hiddentextchanged').value="1";
    document.getElementById('tdgrid').style.display="none";
    if(document.getElementById('txtpkgdesc').value.indexOf("+")>=0)
    document.getElementById('tdbtngo').style.display="block";

}

    var weekrate=parseFloat(document.getElementById('txtrate').value );
var weekmin=parseFloat(document.getElementById('txtminrate').value );

if(weekrate<weekmin)
    {
    alert('Week Day Rate Should be greater than Min Rate');
    document.getElementById('txtminrate').value="";
    document.getElementById('txtminrate').focus();
    return false;
    }
    

    
    return;

}

function chkratevaluefocus(e)
{
 var flag=chkamount(e);
if(flag=="f")
{
return false;

}

//if(document.getElementById('drpadcategory').value=="0")
//{
//alert("For Focus Rate Ad Category Should Be Selected");
//document.getElementById('txtfocusrate').value="";
//document.getElementById('txtfocusmin').value="";
//document.getElementById('txtextrafocus').value="";

//if(document.getElementById('drpadcategory').disabled==false)
//{
//    document.getElementById('drpadcategory').focus();
//}
//return false;

//}


if(document.getElementById('hiddenforfrid').value!="0")
{
    chkflag="1";
}

if(document.getElementById('hiddenforfrid').value=="1" && document.getElementById('hiddenbreakup').value=="1")
{
    document.getElementById('hiddentextchanged').value="1";
    document.getElementById('tdgrid').style.display="none";
    document.getElementById('tdbtngo').style.display="block";

}

var focusrate=parseFloat(document.getElementById('txtfocusrate').value );
var focusmin=parseFloat(document.getElementById('txtfocusmin').value );

if(focusrate<focusmin)
    {
    alert('Focus Day Rate Should be greater than Min Rate');
    
    document.getElementById('txtfocusmin').focus();
    document.getElementById('txtfocusmin').value="";
    return false;
    }
    
   
    
    return;

}

function chkinserts(e)
{
    if(document.getElementById('txtfrominsert').value=="" && document.getElementById('txttoinsert').value!="")
    {
        alert("Please fill From inserts");
        return false;
    }
    else
    {
        var fins=document.getElementById('txtfrominsert').value
        var tins=document.getElementById('txttoinsert').value
        if(parseInt(fins)>parseInt(tins))
        {
                alert("From insert should be less than To insert");
                document.getElementById('txtfrominsert').focus();
                return false;
        }
    }

}
function chkfrinserts()
{
    if(document.getElementById('txttoinsert').value!="")
    {
         var fins=document.getElementById('txtfrominsert').value
        var tins=document.getElementById('txttoinsert').value
        if(parseInt(fins)>parseInt(tins))
        {
                alert("From insert should be less than To insert");
                document.getElementById('txtfrominsert').focus();
                return false;
        }
    }
    chkfromdate();
    
}


function chkweekrate(e)
{
changeRate=1;
 var flag=chkamount(e);
if(flag=="f")
{
return false;

}
if(document.getElementById('hiddenforfrid').value=="1" && document.getElementById('hiddenbreakup').value=="1")
{
    document.getElementById('hiddentextchanged').value="1";
    document.getElementById('tdgrid').style.display="none";
     if(document.getElementById('txtpkgdesc').value.indexOf("+")>=0)
    document.getElementById('tdbtngo').style.display="block";

}


if(document.getElementById('hiddenforfrid').value!="0")
{
    chkflag="1";
}

var weekrate=parseFloat(document.getElementById('txtweekrate').value );
var weekmin=parseFloat(document.getElementById('txtweekminrate').value );

if(weekrate<weekmin)
    {
    alert('Weekend Rate Should be greater than Min Rate');
    document.getElementById('txtweekminrate').value="";
    document.getElementById('txtweekminrate').focus();
    return false;
    }
   
    return;

}


function updateintoratedetail()
{

var ratecode=document.getElementById('txtratecode').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value
var grid=document.getElementById('rategrid').rows.length-1;

var gridid=document.getElementById('rategrid');

for(var z=0;z<=grid-1;z++)
{
var t=0;
t=z;
t=t+1;
var text="Text"+z;
var texta="Texta"+z;
var textb="Textb"+z;
var textc="Textc"+z;
var textd="Textd"+z;
var texte="Texte"+z;

var nameofedition=gridid.rows[t].cells[0].innerHTML; 
var weekendrate=document.getElementById(textd).value;
var rate=document.getElementById(text).value;
//var week=document.getElementById(texta).value;
//var weekextra=document.getElementById(textb).value;
var focusrate=document.getElementById(textc).value;
//var focusmin=document.getElementById(textd).value;
//var focusextra=document.getElementById(texte).value;
var type_age=document.getElementById('hiddentype_agency').value
/*new change ankur for agency*/
//Ratemaster.updateratedetail(rate,focusrate,ratecode,compcode,userid,nameofedition,type_age);
Ratemaster.updateratedetail(rate,focusrate,ratecode,compcode,userid,nameofedition,rateuniqueid,weekendrate,type_agency);
}

}



function chkfocusrate()
{
if(document.getElementById('drpadcategory').value=="0")
{
alert("For Focus Rate Ad Category Should Be Selected");
document.getElementById('txtfocusrate').value="";
document.getElementById('txtfocusmin').value="";
document.getElementById('txtextrafocus').value="";

document.getElementById('drpadcategory').focus();
return false;

}


var focusrate=document.getElementById('txtfocusrate').value;
    if(focusrate=="")
    {
    alert("Please Enter The Focus Day Rate");
    document.getElementById('txtfocusrate').focus();
    return false;
    
    }

}

function checkpackagerate()
{

var arrayrate="";
var arrayfocusrate="";
var arrayweekendrate = "";
var arrayextrarate = "";
var grid=document.getElementById('gridrate').rows.length-1;

var gridid=document.getElementById('gridrate');

var weekdayrate=parseFloat(document.getElementById('txtrate').value);
var weekminrate=parseFloat(document.getElementById('txtminrate').value);
if(document.getElementById('txtfocusrate').value == "")
document.getElementById('txtfocusrate').value=0;
var focusdayrate=parseFloat(document.getElementById('txtfocusrate').value);
var focusminrate = parseFloat(document.getElementById('txtfocusmin').value);
var focusextrarate = parseFloat(document.getElementById('txtextrarate').value);

var weekenddayrate=parseFloat(document.getElementById('txtweekrate').value);
var weekendminrate=parseFloat(document.getElementById('txtweekminrate').value);

var rate="";
var focusrate="";
var weekendrate = "";
var extrarate = "";

for(var z=0;z<=grid-1;z++)
{
var t=0;
t=z;
t=t+1;
/*var text="Text"+z;
var texta="Texta"+z;
var textb="Textb"+z;
var textc="Textc"+z;
var textd="Textd"+z;
var texte="Texte"+z;*/

txtBox = "txtGridRate" + z;

//var nameofedition=gridid.rows[t].cells[0].innerHTML; 

rate=parseFloat(document.getElementById(txtBox).value);
if(rate<weekminrate)
{
alert("Week Day Rate Should Be Greater Than Week Min. Rate");
//txtid.focus();
return false;
}
    if(arrayrate=="")
    {
    arrayrate=rate;
    }
    else
    {
    arrayrate=parseFloat(rate.toFixed(2))+parseFloat(arrayrate.toFixed(2));
    }
    
txtBox = "txtFRate" + z;

focusrate=parseFloat(document.getElementById(txtBox).value);
if(focusrate<focusminrate)
{
alert("Focus Day Rate Should Be Less Than Focus Min. Rate");
//txtid.focus();
return false;

}
    if(arrayfocusrate=="")
    {
    arrayfocusrate=focusrate;
    }
    else
    {
    arrayfocusrate=parseFloat(focusrate.toFixed(2))+parseFloat(arrayfocusrate.toFixed(2));
    }

txtBox = "txtWEnRate" + z;    
weekendrate=parseFloat(document.getElementById(txtBox).value);
if(weekendrate<weekendminrate)
{
alert("Weekend Day Rate Should Be Less Than Weekend Min. Rate");
//txtid.focus();
return false;

}
    if(arrayweekendrate=="")
    {
    arrayweekendrate=weekendrate;
    }
    else
    {
    arrayweekendrate=parseFloat(weekendrate.toFixed(2))+parseFloat(arrayweekendrate.toFixed(2));
    }


    txtBox = "txtWExRate" + z;

    //var nameofedition=gridid.rows[t].cells[0].innerHTML;

    extrarate = parseFloat(document.getElementById(txtBox).value);
//    if (extrarate < focusextrarate) {
//        alert("Extra Day Rate Should Be Greater Than Week Min. Rate");
//        //txtid.focus();
//        return false;
//    }
    if (arrayextrarate == "") {
        arrayextrarate = extrarate;
    }
    else {
        arrayextrarate = parseFloat(extrarate.toFixed(2)) + parseFloat(arrayextrarate.toFixed(2));
    }
    



}
    
   // if(weekdayrate  - (arrayrate + .01) > 1 || weekdayrate - (arrayrate  + .01) < 0)
   var diff=weekdayrate  - arrayrate;
     diff = (parseFloat(diff)).toFixed(2);
   if( diff > 1 ||diff < 0)
    {
    alert("Total Week Day Rate Should Be Equal To Package Week Day Rate");
    //txtid.focus();
    return false;
    }
    
    if(arrayfocusrate>focusdayrate || arrayfocusrate<focusdayrate)
    {
    alert("Total Focus Day Rate Should Be Equal To Package Focus Day Rate");
   //txtid.focus();
    return false;
    }
    if(arrayweekendrate>weekenddayrate || arrayweekendrate<weekenddayrate)
    {
    alert("Total Weekend Day Rate Should Be Equal To Package Weekend Day Rate");
   //txtid.focus();
    return false;
    }
    if (arrayextrarate > focusextrarate || arrayextrarate < focusextrarate) {
        alert("Total Extra Rate Should Be Equal To Package Extra Day Rate");
        //txtid.focus();
        return false;
    }

    



}

/////////////////////while saving this function calls

function checkwhilesave()
{

var arrayrate="";
var arrayfocusrate="";
var grid=document.getElementById('rategrid').rows.length-1;

var gridid=document.getElementById('rategrid');

var weekdayrate=parseFloat(document.getElementById('txtrate').value);
var weekminrate=parseFloat(document.getElementById('txtminrate').value);

var focusdayrate=parseFloat(document.getElementById('txtfocusrate').value);
var focusminrate=parseFloat(document.getElementById('txtfocusmin').value);


for(var z=0;z<=grid-1;z++)
{
var t=0;
t=z;
t=t+1;
var text="Text"+z;
var texta="Texta"+z;
var textb="Textb"+z;
var textc="Textc"+z;
var textd="Textd"+z;
var texte="Texte"+z;

//var nameofedition=gridid.rows[t].cells[0].innerHTML; 

var rate=parseFloat(document.getElementById(text).value);
if(rate<weekminrate)
{
alert("Week Day Rate Should Be Greater Than Week Min. Rate");
document.getElementById(text).focus();
//txtid.focus();
return false;
}
    if(arrayrate=="")
    {
    arrayrate=rate;
    }
    else
    {
    arrayrate=rate+arrayrate;
    }
    

var focusrate=parseFloat(document.getElementById(textc).value);
if(focusrate<focusminrate)
{
alert("Focus Day Rate Should Be Less Than Focus Min. Rate");
document.getElementById(textc).focus();

//txtid.focus();
return false;

}
    if(arrayfocusrate=="")
    {
    arrayfocusrate=focusrate;
    }
    else
    {
    arrayfocusrate=focusrate+arrayfocusrate;
    }



}
    
    if(arrayrate>weekdayrate || arrayrate<weekdayrate)
    {
    alert("Total Week Day Rate Should Be Equal To Package Week Day Rate");
    document.getElementById(text).focus();
    //txtid.focus();
    return false;
    }
    
    if(arrayfocusrate>focusdayrate || arrayfocusrate<focusdayrate)
    {
    alert("Total Focus Day Rate Should Be Equal To Package Focus Day Rate");
    document.getElementById(textc).focus();
   //txtid.focus();
    return false;
    }
    

    



}

function datagridincisible()
{
document.getElementById('tdgrid').style.display="none";

if(document.getElementById('txtpkgdesc').value.indexOf("+")>=0)
{
    document.getElementById('tdbtngo').style.display="block";
}
else
{
    document.getElementById('tdbtngo').style.display="none";
}
document.getElementById('tdgrid').style.display="none";



}

function goclick()
{
document.getElementById('tdgrid').style.display="block";


document.getElementById('tdbtngo').style.display="none";

//document.getElementById('btnNew').disabled=false;
//document.getElementById('btnNew').focus();

//return false;
}

function datesplit(dateval)
{
var dateformat=document.getElementById('hiddendateformat').value;
if(dateformat=="dd/mm/yyyy")
			{
			    if(dateval!="")
			        {
			        var txt=dateval;
			        var txt1=txt.split("/");
			        var dd=txt1[0];
			        var mm=txt1[1];
			        var yy=txt1[2];
			        return mm+'/'+dd+'/'+yy;
			        }
			        else
			        {
			        return  dateval;
			        }
			
			}
			if(dateformat=="mm/dd/yyyy")
			    {
			    return dateval;
			    }
			if(dateformat=="yyyy/mm/dd")
			    {
			    if(document.getElementById('txtvalidfrom').value!="")
			        {
			        var txt=document.getElementById('txtvalidfrom').value;
			        var txt1=txt.split("/");
			        var yy=txt1[0];
			        var mm=txt1[1];
			        var dd=txt1[2];
			        return mm+'/'+dd+'/'+yy;
			        }
			    else
			        {
			        //=document.getElementById('txtvalidfrom').value;
			        return dateval;
			        }
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
      return false; // cancel the default behavior since 
                    // we have selected our own value 
    } 
  } 
  // reset initial key to be inline with default behavior 
  dropdownlist.keypressBuffer = key; 
  return true; // give default behavior 
} 

function checkarea()
{
var num=document.getElementById('txtminarea').value;
var num2=parseInt(document.getElementById('txtminarea').value);
document.getElementById('txtminarea').value=num2;

var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
document.getElementById('txtminarea').value="";
alert("Input error");
document.getElementById('txtminarea').focus();
document.getElementById('txtminarea').value="";
return false; 
}
}




function checkamount()
{

if(document.getElementById('hiddenprem').value!="fixed")
{
var sau=parseFloat(document.getElementById('txtflramount').value);
document.getElementById('txtflramount').value=sau;

if(sau>100)
{
    alert("Floor Amount should not be greater than 100");
    document.getElementById('txtflramount').value="";
    document.getElementById('txtflramount').focus();
    return false;
}

var num=document.getElementById('txtflramount').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{

if(document.getElementById('txtflramount').value=="NaN")
{
    document.getElementById('txtflramount').value="";
}


return true;
}
else
{
document.getElementById('txtflramount').value="";
alert("Input error");
document.getElementById('txtflramount').value="";
document.getElementById('txtflramount').focus();

return false; 

}

if(document.getElementById('txtflramount').value=="NaN")
{
    document.getElementById('txtflramount').value="";
}

}

else
{
    var num2=document.getElementById('txtflramount').value;
    var num=parseFloat(document.getElementById('txtflramount').value);
    document.getElementById('txtflramount').value=num;
    

var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num2))
{

if(document.getElementById('txtflramount').value=="NaN")
{
    document.getElementById('txtflramount').value="";
}



return true;
}
else
{
document.getElementById('txtflramount').value="";
alert("Input error");
document.getElementById('txtflramount').focus();
document.getElementById('txtflramount').value="";
return false; 
}


if(document.getElementById('txtflramount').value=="NaN")
{
    document.getElementById('txtflramount').value="";
}

  
}

}
//function checkamount()
//{
//if(document.getElementById('hiddenprem').value!="fixed")
//{
//var num=document.getElementById('txtflramount').value;
//var tomatch=/^\d*(\.\d{1,2})?$/;
//if (tomatch.test(num))
//{
//return true;
//}
//else
//{
//alert("Input error");
//document.getElementById('txtflramount').focus();
//document.getElementById('txtflramount').value="";
//return false; 
//}
//}
//}
//else
//{
//    var num=parseFloat(document.getElementById('txtflramount').value);
//    if(num!=0)
//    {
//        document.getElementById('txtflramount').value=num;
//    }
//    else
//    {
//        document.getElementById('txtflramount').value="";
//        alert("Floor Amount cannot Be Zero.");
//        document.getElementById('txtflramount').focus();
//    }
//}


function checkdiscount()
{

if(document.getElementById('hiddenprem').value!="fixed")
{
var sau=parseFloat(document.getElementById('txtflrdiscount').value);
document.getElementById('txtflrdiscount').value=sau;

if(sau>100)
{
    alert("Floor Discount should not be greater than 100");
    document.getElementById('txtflrdiscount').value="";
    document.getElementById('txtflrdiscount').focus();
    return false;
}

var num=document.getElementById('txtflrdiscount').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{

if(document.getElementById('txtflrdiscount').value=="NaN")
{
    document.getElementById('txtflrdiscount').value="";
}



return true;
}
else
{
document.getElementById('txtflrdiscount').value="";
alert("Input error");
document.getElementById('txtflrdiscount').value="";
document.getElementById('txtflrdiscount').focus();

return false; 

}

if(document.getElementById('txtflrdiscount').value=="NaN")
{
    document.getElementById('txtflrdiscount').value="";
}


}

else
{
    var num2=document.getElementById('txtflrdiscount').value;
    var num=parseFloat(document.getElementById('txtflrdiscount').value);
    document.getElementById('txtflrdiscount').value=num;
    

var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num2))
{

if(document.getElementById('txtflrdiscount').value=="NaN")
{
    document.getElementById('txtflrdiscount').value="";
}


return true;
}
else
{
document.getElementById('txtflrdiscount').value="";
alert("Input error");
document.getElementById('txtflrdiscount').focus();
document.getElementById('txtflrdiscount').value="";
return false; 
}

if(document.getElementById('txtflrdiscount').value=="NaN")
{
    document.getElementById('txtflrdiscount').value="";
}

  
}

}

function seeeditionrate()
{
var popup="";
var packagecode=document.getElementById('drppkgcode').value;

    if(packagecode!="0")    
    {

        popup= window.open('seealeditrate.aspx?packagecode='+packagecode,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=244,left=210,width=800px,height=415px');
        popup.focus();
    }
    else
    {
        alert("Please select the package");
        return false;
    }


}




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

function chkfromdate()
{
    var fromdate=document.getElementById('txtvalidfrom').value;
    var todate=document.getElementById('txtvalidto').value;
    if(fromdate!="")
    {
       var fdate=new Date(fromdate);
	   var tdate=new Date(todate);
	   if(fdate>tdate)
	   {
	        alert("From date should be less than To date");
	        document.getElementById('txtvalidfrom').focus();
	        return false;
	        
	   }
    }

}

/*new change ankur for agency*/
function rateforcomporagency(id)
{
    if(id=="rbHindustan")
    {
        document.getElementById('rbHindustan').checked=true;
        document.getElementById('rbagency').checked=false;
        document.getElementById('tragency').style.display="none"
          if(document.getElementById('txtratecode').disabled==false)
        {
            document.getElementById('txtratecode').focus();
        }
        document.getElementById('drpagencycode').value="0";
        //document.getElementById('drpagencysub').value="0";
        document.getElementById('hiddentype_agency').value="company";
    
    }
    else
    {
     
        document.getElementById('rbHindustan').checked=false;
        document.getElementById('rbagency').checked=true;
        document.getElementById('tragency').style.display="block"
        if(document.getElementById('drpagencycode').disabled==false)
        {
            document.getElementById('drpagencycode').focus();
        }
        document.getElementById('drpagencycode').value="0";
        //document.getElementById('drpagencysub').value="0";
        document.getElementById('hiddentype_agency').value="agency";
  
    
    }


}



function chkfields()
{
    if(chkquery!="1")
    {
        /*if(document.getElementById("drppubcenter").value=="0")
        {
            alert("Please Select Center and Ad Type");
            document.getElementById("drppubcenter").focus();
            document.getElementById("drppkgcode").value="0";
            return false;
        }*/
        if(document.getElementById("drpadtype").value=="0")
        {
            alert("Please Select Ad Type");
            document.getElementById("drpadtype").focus();
            document.getElementById("drppkgcode").value="0";
            return false;
        }
    }
}


function setchkquery(value1)
{
    chkquery=value1;
}

function nchar(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode
    if((charCode>=48 && charCode<=57)||(charCode==127)||(charCode==8)||(charCode==9))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function ncharforsize(evt)
{
    //alert(event.keyCode);
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if(document.getElementById('hiddenuomdesc').value=="ROL" || document.getElementById('hiddenuomdesc').value=="CD" || document.getElementById('hiddenuomdesc').value=="ROW" || document.getElementById('hiddenuomdesc').value=="ROD")
    {
        
        if((charCode>=48 && charCode<=57)||(charCode==127)||(charCode==8)||(charCode==9))
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
        if((charCode>=48 && charCode<=57)||(charCode==127)||(charCode==8)||(charCode==9)||(charCode==46))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

function newclick()
{
    chkquery="0";
    changeRate=0;
    hiddentext="new";
    document.getElementById("lball").disabled = false;
  
    document.getElementById("hiddenchkcount").value = "0";
    document.getElementById("hiddenshow").value = "0";
    document.getElementById("hiddenshow").value = "0";
    document.getElementById("hiddenforfrid").value = "0";
  //  document.getElementById('hiddenbreakup').value="0";
    document.getElementById("drppubcenter").value = "0";//document.getElementById("hiddenCenter").value;
    
    document.getElementById("drpadscat4").disabled = false;
    document.getElementById("drpadscat5").disabled = false;
    document.getElementById("drpadscat6").disabled = false;
    document.getElementById("txtfrominsert").disabled = false;
    document.getElementById("txttoinsert").disabled = false;
    document.getElementById("drpagentyp").disabled = false;
    document.getElementById("drpclientcat").disabled = false;
    document.getElementById("txtmaxarea").disabled = false;
    document.getElementById("drppageposition").disabled = false;
    
    
    document.getElementById("txtedfrom").disabled = false;
    document.getElementById("txtedto").disabled = false;
    document.getElementById("txtratecode").disabled = false;
    document.getElementById("txtminarea").disabled = false;
    document.getElementById("drpadtype").disabled = false;
    document.getElementById("drprategroupcode").disabled = false;
    document.getElementById("drpadcategory").disabled = false;
    document.getElementById("drpsubcategory").disabled = false;
    document.getElementById("drppkgcode").disabled = false;
    document.getElementById("txtpkgdesc").disabled = false;
    document.getElementById("drpuom").disabled = false;
    document.getElementById("txtvalidfrom").disabled = false;
    document.getElementById("txtsizefrom").disabled = false;
    document.getElementById("txtvalidto").disabled = false;
    document.getElementById("txtsizeto").disabled = false;
    document.getElementById("txtconsperiod").disabled = false;
    document.getElementById("drpcolor").disabled = false;
    document.getElementById("drpcolortyp").disabled = false;

    document.getElementById("drpscheme").disabled = false;

    document.getElementById("txtremarks").disabled = false;
    document.getElementById("txtpremiumcharges").disabled = false;
    document.getElementById("drppremium").disabled = false;
    
    document.getElementById("drpcurrency").disabled = false;
    
    document.getElementById("lbaddon").disabled = false;
    document.getElementById("txtflramount").disabled = false;
    document.getElementById("txtflrdiscount").disabled = false;

    document.getElementById("drppubcenter").disabled = false;
    document.getElementById("txtcancellationcharges").disabled = false;
    enabledayrate();
    
    clearfields();
       document.getElementById("txtpriorityrate").disabled = false;
      document.getElementById("btnpriority").disabled = false;
       document.getElementById("chkvat").disabled = false;
    chkstatusrate(parseInt(document.getElementById("hiddenFlagStatus").value));
    
    goclick();
    
    datagridincisible();
    document.getElementById('tdbtngo').style.display='none';
    
    document.getElementById("txtratecode").focus();
    
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
Ratemaster.sessionnull();
    
    gdsexecute=null;
    setButtonImages();
    return false;
}

function cancelclick()
{
    chkquery="0";
    changeRate=0;
    hiddentext="";
    document.getElementById("hiddenchkcount").value = "0";
    document.getElementById("hiddenshow").value = "0";
    document.getElementById("hiddenshow").value = "0";
    document.getElementById("hiddenforfrid").value = "0";


    document.getElementById("txtmaxwidth").value = "";
    document.getElementById("txtminwidth").value = "";
    document.getElementById("txtmaxwidth12").value = "";
    
    
    
    
  //  document.getElementById('hiddenbreakup').value="0";
    disableflds();
    disabledayrate();
    clearfields();
    document.getElementById("btnAdon").style.display = 'none';
    getbuttoncheck(parseInt(document.getElementById("hiddenFlagStatus").value));
    
    goclick();
    datagridincisible();
    document.getElementById('tdbtngo').style.display='none';
    if(FlagStatus!=2 && FlagStatus!=4 && FlagStatus!=6)
    document.getElementById('btnNew').focus();
    chkstatusrate(FlagStatus);
    gdsexecute=null;
    if(FlagStatus==7 || FlagStatus==15 || FlagStatus==11 || FlagStatus==13 || FlagStatus==9 || FlagStatus==1 || FlagStatus==5 || FlagStatus==3)
    document.getElementById('btnNew').disabled = false;
    document.getElementById("drppageposition").disabled = true;
    document.getElementById("drppageposition").value = "0";
    document.getElementById('btnSave').disabled = true;
    setButtonImages();
    
//    document.getElementById("drpAdon").style.display = 'block';
//    document.getElementById("txtref").style.display = 'block';
//    document.getElementById("btnAdon").style.display = 'block';
    return false;
}

function queryclick()
{
    chkquery="1";
    changeRate = 0;

    disabledayrate();
    clearfields();

    document.getElementById('drpsubcategory').disabled = false;
    hiddentext="query";
    document.getElementById("hiddenforfrid").value="0";
    
    //document.getElementById('hiddenbreakup').value="0";
    
    document.getElementById("drppubcenter").disabled = false;
    
    document.getElementById("txtratecode").disabled = false;
    document.getElementById("drpadtype").disabled = false;
    document.getElementById("drpcurrency").disabled = false;
    document.getElementById("drprategroupcode").disabled = false;
    document.getElementById("drpuom").disabled = false;
    document.getElementById("drpcolor").disabled = false;
    document.getElementById("drppkgcode").disabled = false;
    document.getElementById("lbaddon").disabled = true;
    document.getElementById("drpadcategory").disabled = false;
document.getElementById("txtvalidfrom").disabled = false;

    document.getElementById("txtflramount").disabled = true;
    document.getElementById("txtflrdiscount").disabled = true;

    document.getElementById("drpadscat4").disabled = true;
    document.getElementById("drpadscat5").disabled = true;
    document.getElementById("drpadscat6").disabled = true;
    document.getElementById("drppageposition").disabled = false;
    chkstatusrate(FlagStatus);
    
    document.getElementById("btnQuery").disabled = true;
    document.getElementById("btnExecute").disabled = false;
    document.getElementById("btnSave").disabled = true;
     document.getElementById("btnpriority").disabled = true;
     document.getElementById("chkvat").disabled = true;
     document.getElementById("txtcancellationcharges").disabled = true;
     
    gdsexecute=null;
    
    datagridincisible();
    document.getElementById('tdbtngo').style.display='none';
    setButtonImages();
    return false;
}

function executeclick()
{
    chkquery="0";
    disableflds();
    document.getElementById("hiddenchkforgo").Value = "0";
    document.getElementById("hiddenforfrid").value = "01";
    document.getElementById("hiddenshow").value = "2";
    
    var compcode=document.getElementById("hiddencompcode").value;
    
    var ratecode=document.getElementById("txtratecode").value.toUpperCase();
    gbratecode = ratecode;
    var adtype=document.getElementById("drpadtype").value;
    gbadtype = adtype;
    var currency=document.getElementById("drpcurrency").value;
    gbcurrency = currency;
    var rategroup=document.getElementById("drprategroupcode").value;
    gbratetype = rategroup;
    var colorcode =document.getElementById("drpcolor").value;
    gbcolor = colorcode;
    var uomcode = document.getElementById("drpuom").value;
    gbuom = uomcode;
    var pkgcode = document.getElementById("drppkgcode").value;
    gbpkgcode = pkgcode;
    var center=document.getElementById("drppubcenter").value;
    gbcenter=center;
    var adcat=document.getElementById("drpadcategory").value;
    gcatcode=adcat;


    
    rowN=0;
    var positionprem=document.getElementById('drppageposition').value;
    var positionprem = document.getElementById('drppageposition').value;
    var subcat = document.getElementById('drpsubcategory').value;


    var validfrom = document.getElementById("txtvalidfrom").value;

    var res = Ratemaster.executerate(compcode, ratecode, adtype, currency, rategroup, colorcode, uomcode, pkgcode, center, adcat, positionprem,validfrom,document.getElementById("hiddendateformat").value ,subcat)
    executeclick_call(res);
    onchange_uom();
    bindPriorityRate();
    
    document.getElementById('txtrate').disabled=true;
     document.getElementById("hiddenshow").value="2";
    return false;
}
function bindPriorityRate()
{
 var data="";
var resR=Ratemaster.fetch_priority_rate(document.getElementById("hiddenrateuniqid").value);
if(resR.error!=null)
{
    alert(resR.error.description);
    return false;
}
var ds=resR.value;
if(ds!=null && ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
{
    var editionname="";
   
    for(var i=0;i<ds.Tables[0].Rows.length;i++)
    {
        if( editionname=="")
        {
            data=ds.Tables[0].Rows[i].EDITION_NAME;
            data=data+"~"+ds.Tables[0].Rows[i].RATE; 
            data=data+"~"+ds.Tables[0].Rows[i].EXTRARATE; 
        }
        else if(editionname!="" && editionname!=ds.Tables[0].Rows[i].EDITION_NAME)
        {
            data=data+"$"+ds.Tables[0].Rows[i].EDITION_NAME;
            data=data+"~"+ds.Tables[0].Rows[i].RATE;
            data=data+"~"+ds.Tables[0].Rows[i].EXTRARATE; 
        }
        else{
            data=data+"~"+ds.Tables[0].Rows[i].RATE;
            data=data+"~"+ds.Tables[0].Rows[i].EXTRARATE; 
        }
        editionname=ds.Tables[0].Rows[i].EDITION_NAME;
    }
}
document.getElementById("hiddenpriorityrates").value=data;
}
function executeclick_call(responce)
{
    if(responce.error!=null)
    {
        alert("ERROR : \n"+responce.error.description);
        return false;
    }
    gdsexecute=responce.value;
    if(gdsexecute!=null)
    {
        if(gdsexecute.Tables[0].Rows.length>0 && gdsexecute.Tables[0].Rows[rowN]!=undefined && gdsexecute.Tables[0].Rows[rowN]!="undefined")
        {
            bindctrls();
        }
        else
        {
            alert("Your Search Produces No Result");
            cancelclick();
            return false;
        }
    }
    
    
    updateStatusRate();
    
    if(gdsexecute.Tables[0].Rows.length==1)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
    }
    else
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    setButtonImages();
}

function clearfields()
{
    document.getElementById("txtpriorityrate").value="";
    document.getElementById("btnpriority").disabled=true;
    document.getElementById("txtpriorityrate").disabled=true;
    document.getElementById("txtratecode").value="";
    document.getElementById("drpadtype").value = "0";
    if(document.getElementById("hiddenrategroupcode").value == "0")
       document.getElementById("drprategroupcode").value = "0";
     if(document.getElementById("hiddencurrency").value == "0")
       document.getElementById("drpcurrency").value = "0";
    document.getElementById("drpadcategory").value = "0";
    document.getElementById("drpsubcategory").value = "0";
    document.getElementById("drppkgcode").value = "0";
    document.getElementById("txtpkgdesc").value = "";
    document.getElementById("drpuom").value = "0";
    document.getElementById("txtvalidfrom").value = "";
    document.getElementById("txtsizefrom").value = "";
    document.getElementById("txtvalidto").value = "";
    document.getElementById("txtsizeto").value = "";
    document.getElementById("txtconsperiod").value = "";
    document.getElementById("drpcolor").value = "0";
    document.getElementById("drpcolortyp").value = "0";
    document.getElementById("txtremarks").value = "";
    document.getElementById("txtrate").value = "";
    document.getElementById("txtminrate").value = "";
    document.getElementById("txtextrarate").value = "";
    document.getElementById("txtfocusrate").value = "";
    document.getElementById("txtfocusmin").value = "";
    document.getElementById("txtextrafocus").value = "";
    document.getElementById("txtpremiumcharges").value = "";
    document.getElementById("drppremium").value = "0";
    document.getElementById("txtweekextra").value = "";
    document.getElementById("txtweekminrate").value = "";
    document.getElementById("txtweekrate").value = "";
    document.getElementById("txtminarea").value = "";
    document.getElementById("txtedfrom").value = "";
    document.getElementById("txtedto").value = "";
    document.getElementById("txtflramount").value = "";
    document.getElementById("txtflrdiscount").value = "";
    document.getElementById("drpscheme").value = "0";
    document.getElementById("drpadscat4").value = "0";
    document.getElementById("drpadscat5").value = "0";
    document.getElementById("drpadscat6").value = "0";
    document.getElementById("txtfrominsert").value = "";
    document.getElementById("txttoinsert").value = "";
    document.getElementById("drpclientcat").value = "0";
    document.getElementById("drpagentyp").value = "0";
    document.getElementById("txtmaxarea").value = "";
    document.getElementById("drpagencycode").value = "0";
    document.getElementById("drpuom").value = "0";
    document.getElementById("drppubcenter").value="0";
    
    document.getElementById("txtratesun").value = "";
    document.getElementById("txtratemon").value = "";
    document.getElementById("txtratetue").value = "";
    document.getElementById("txtratewed").value = "";
    document.getElementById("txtratethu").value = "";
    document.getElementById("txtratefri").value = "";
    document.getElementById("txtratesat").value = "";
    
    document.getElementById("txtratesunextra").value = "";
    document.getElementById("txtratemonextra").value = "";
    document.getElementById("txtratetueextra").value = "";
    document.getElementById("txtratewedextra").value = "";
    document.getElementById("txtratethuextra").value = "";
    document.getElementById("txtratefriextra").value = "";
    document.getElementById("txtratesatextra").value = "";
    document.getElementById("txtratefriextra").value = "";
//    document.getElementById("lbref").value = "";
//    document.getElementById("drpAdon").value = "N";
    
       document.getElementById("chkvat").checked=false;
       document.getElementById("txtcancellationcharges").value = "";

       hide_edition();
   
}

function enabledayrate()
{
    document.getElementById("txtratesun").disabled = false;
    document.getElementById("txtratemon").disabled = false;
    document.getElementById("txtratetue").disabled = false;
    document.getElementById("txtratewed").disabled = false;
    document.getElementById("txtratethu").disabled = false;
    document.getElementById("txtratefri").disabled = false;
    document.getElementById("txtratesat").disabled = false;

    document.getElementById("txtratesunextra").disabled = false;
    document.getElementById("txtratemonextra").disabled = false;
    document.getElementById("txtratetueextra").disabled = false;
    document.getElementById("txtratewedextra").disabled = false;
    document.getElementById("txtratethuextra").disabled = false;
    document.getElementById("txtratefriextra").disabled = false;
    document.getElementById("txtratesatextra").disabled = false;

    document.getElementById("txtmaxwidth").disabled = false;
    document.getElementById("txtminwidth").disabled = false;
    document.getElementById("txtmaxwidth12").disabled = false;
    
    document.getElementById("txtrate").disabled=false;
    document.getElementById("txtminrate").style.backgroundColor="Gray";
   // document.getElementById("txtminrate").disabled=false;
    document.getElementById("txtextrarate").disabled=false;
    //document.getElementById("txtfocusrate").disabled=false;
    document.getElementById("txtfocusrate").style.backgroundColor="Gray";
    //document.getElementById("txtfocusmin").disabled=false;
    document.getElementById("txtfocusmin").style.backgroundColor="Gray";
    //document.getElementById("txtextrafocus").disabled=false;
    document.getElementById("txtextrafocus").style.backgroundColor="Gray";
    //document.getElementById("txtweekrate").disabled=false;
    document.getElementById("txtweekrate").style.backgroundColor="Gray";
    //document.getElementById("txtweekminrate").disabled=false;
    document.getElementById("txtweekminrate").style.backgroundColor="Gray";
    //document.getElementById("txtweekextra").disabled=false;
    document.getElementById("txtweekextra").style.backgroundColor="Gray";
 //   document.getElementById("chkvat").disabled = false;
}

function disabledayrate()
{
    document.getElementById("txtratesun").disabled = true;
    document.getElementById("txtratemon").disabled = true;
    document.getElementById("txtratetue").disabled = true;
    document.getElementById("txtratewed").disabled = true;
    document.getElementById("txtratethu").disabled = true;
    document.getElementById("txtratefri").disabled = true;
    document.getElementById("txtratesat").disabled = true;

    document.getElementById("txtratesunextra").disabled = true;
    document.getElementById("txtratemonextra").disabled = true;
    document.getElementById("txtratetueextra").disabled = true;
    document.getElementById("txtratewedextra").disabled = true;
    document.getElementById("txtratethuextra").disabled = true;
    document.getElementById("txtratefriextra").disabled = true;
    document.getElementById("txtratesatextra").disabled = true;

    document.getElementById("txtmaxwidth").disabled = true;
    document.getElementById("txtminwidth").disabled = true;
    document.getElementById("txtmaxwidth12").disabled = true;
    
    document.getElementById("txtrate").disabled=true;
    document.getElementById("txtminrate").disabled=true;
    document.getElementById("txtextrarate").disabled=true;
    document.getElementById("txtfocusrate").disabled=true;
    document.getElementById("txtfocusmin").disabled=true;
    document.getElementById("txtextrafocus").disabled=true;
    document.getElementById("txtweekrate").disabled=true;
    document.getElementById("txtweekminrate").disabled=true;
    document.getElementById("txtweekextra").disabled=true;
    document.getElementById("chkvat").disabled=true;
    
}


function chkstatusrate(FlagStatus)
{
    if (FlagStatus == 0 || FlagStatus == 8)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = true;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = true;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExit").disabled = true;



    }
    if (FlagStatus == 1 || FlagStatus == 9)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnExit").disabled = false;

    }
    if (FlagStatus == 2 || FlagStatus == 10)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        
        document.getElementById("btnExit").disabled = false;

    }

    if (FlagStatus == 3 || FlagStatus == 11)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        
        document.getElementById("btnExit").disabled = false;
    }

    if (FlagStatus == 4 || FlagStatus == 12)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        
        document.getElementById("btnExit").disabled = false;
    }
    if (FlagStatus == 5 || FlagStatus == 13)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        
        document.getElementById("btnExit").disabled = false;
    }
    if (FlagStatus == 6 || FlagStatus == 14)
    {
        document.getElementById("btnNew").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnDelete").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnCancel").disabled = false;
        document.getElementById("btnModify").disabled = true;

        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        document.getElementById("btnlast").disabled = true;
        
        document.getElementById("btnExit").disabled = false;
    }
    if (FlagStatus == 7 || FlagStatus == 15)
    {

            document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
    }


}

function updateStatusRate()
{

    var FlagStatus=parseInt(document.getElementById("hiddenFlagStatus").value);
    chkstatusrate(FlagStatus);
    if (FlagStatus == 2 || FlagStatus == 3)
    {
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnModify").disabled = false;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnnext").disabled = false;
        document.getElementById("btnprevious").disabled = false;
        document.getElementById("btnlast").disabled = false;
        document.getElementById("btnDelete").disabled = true;
    }
    if (FlagStatus == 4)
    {
        document.getElementById("btnDelete").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnnext").disabled = false;
        document.getElementById("btnprevious").disabled = false;
        document.getElementById("btnlast").disabled = false;

    }
    if (FlagStatus == 5)
    {
        document.getElementById("btnDelete").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnModify").disabled = true;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnnext").disabled = false;
        document.getElementById("btnprevious").disabled = false;
        document.getElementById("btnlast").disabled = false;

    }
    if (FlagStatus == 6 || FlagStatus == 7)
    {
        document.getElementById("btnDelete").disabled = false;
        document.getElementById("btnExecute").disabled = true;
        document.getElementById("btnSave").disabled = true;
        document.getElementById("btnQuery").disabled = false;
        document.getElementById("btnModify").disabled = false;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnnext").disabled = false;
        document.getElementById("btnprevious").disabled = false;
        document.getElementById("btnlast").disabled = false;

    }
}

function disableflds()
{
    document.getElementById("lball").disabled = true;
    
    document.getElementById("drppubcenter").disabled = true;
    document.getElementById("drpadscat4").disabled = true;
    document.getElementById("drpadscat5").disabled = true;
    document.getElementById("drpadscat6").disabled = true;
    document.getElementById("txtfrominsert").disabled = true;
    document.getElementById("txttoinsert").disabled = true;
    document.getElementById("drpagentyp").disabled = true;
    document.getElementById("drpclientcat").disabled = true;
    document.getElementById("txtmaxarea").disabled = true;
    
    document.getElementById("txtedfrom").disabled = true;
    document.getElementById("txtedto").disabled = true;
    document.getElementById("txtratecode").disabled = true;
    document.getElementById("txtminarea").disabled = true;
    document.getElementById("drpadtype").disabled = true;
    document.getElementById("drprategroupcode").disabled = true;
    document.getElementById("drpadcategory").disabled = true;
    document.getElementById("drpsubcategory").disabled = true;
    document.getElementById("drppkgcode").disabled = true;
    document.getElementById("txtpkgdesc").disabled = true;
    document.getElementById("drpuom").disabled = true;
    document.getElementById("txtvalidfrom").disabled = true;
    document.getElementById("txtsizefrom").disabled = true;
    document.getElementById("txtvalidto").disabled = true;
    document.getElementById("txtsizeto").disabled = true;
    document.getElementById("txtconsperiod").disabled = true;
    document.getElementById("drpcolor").disabled = true;
    document.getElementById("drpcolortyp").disabled = true;
    document.getElementById("txtcancellationcharges").disabled = true;
    document.getElementById("drpscheme").disabled = true;

    document.getElementById("txtremarks").disabled = true;
    document.getElementById("txtpremiumcharges").disabled = true;
    document.getElementById("drppremium").disabled = true;
    document.getElementById("txtrate").disabled = true;
    document.getElementById("txtminrate").disabled = true;
    document.getElementById("txtextrarate").disabled = true;
    document.getElementById("txtfocusrate").disabled = true;
    document.getElementById("txtfocusmin").disabled = true;
    document.getElementById("txtextrafocus").disabled = true;
    document.getElementById("drpcurrency").disabled = true;

    document.getElementById("txtweekextra").disabled = true;
    document.getElementById("txtweekminrate").disabled = true;
    document.getElementById("txtweekrate").disabled = true;
    document.getElementById("lbaddon").disabled = true;
    document.getElementById("txtflramount").disabled = true;
    document.getElementById("txtflrdiscount").disabled = true;

    document.getElementById("drppubcenter").disabled = true;
    document.getElementById("chkvat").disabled = true;
    document.getElementById("drppageposition").disabled = true;
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

function bindctrls()
{    
    document.getElementById("txtratecode").value = gdsexecute.Tables[0].Rows[rowN].Rate_Mast_Code;
    document.getElementById("drpadtype").value = gdsexecute.Tables[0].Rows[rowN].Adv_Type_Code;
    hide_edition();
    if(gdsexecute.Tables[0].Rows[rowN].PRIORITY!=null)
    {
     document.getElementById("txtpriorityrate").value = gdsexecute.Tables[0].Rows[rowN].PRIORITY;
    }
    bind_pkg_adcat_uom(gdsexecute.Tables[0].Rows[rowN].Adv_Type_Code);
    
    
    document.getElementById("drprategroupcode").value = gdsexecute.Tables[0].Rows[rowN].Rate_Gr_Code;
    document.getElementById("drpcurrency").value = gdsexecute.Tables[0].Rows[rowN].Currency;
    document.getElementById("drpadcategory").value = gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code;
    if (gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code == null)
        gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code = "";
    bind_subcat(gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code);
    bind_premium(gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code);


    if (gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code != null) {
        document.getElementById("drpsubcategory").value = gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code;
    }


    if (gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code != null) {
        bind_subcat4(gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code);
    }
    if (gdsexecute.Tables[0].Rows[rowN].Ad_Subcat4 != null) {
        document.getElementById("drpadscat4").value = gdsexecute.Tables[0].Rows[rowN].Ad_Subcat4;
    }
    if (gdsexecute.Tables[0].Rows[rowN].Ad_Subcat4 != null) {

        bind_subcat5(gdsexecute.Tables[0].Rows[rowN].Ad_Subcat4);
    }
    document.getElementById("drpadscat5").value = gdsexecute.Tables[0].Rows[rowN].Ad_Subcat5;
    
    bind_subcat6(gdsexecute.Tables[0].Rows[rowN].Ad_Subcat5);
    document.getElementById("drpadscat6").value = gdsexecute.Tables[0].Rows[rowN].Ad_subcat6;
    
    document.getElementById("txtpkgdesc").value = gdsexecute.Tables[0].Rows[rowN].combin_desc;
    
    
    if(gdsexecute.Tables[0].Rows[rowN].combin_desc.indexOf('+')>0)
    {
        document.getElementById("hiddenchkcount").value = "1";
        datagridincisible();
    }
    else
    {
        document.getElementById('tdgrid').style.display="none";
        document.getElementById('tdbtngo').style.display="none";
        document.getElementById('tdgrid').style.display="none";
        document.getElementById("hiddenchkcount").value = "0";
    }
        if(gdsexecute.Tables[0].Rows[rowN].desc !=null && gdsexecute.Tables[0].Rows[rowN].desc.indexOf("+")>=0)
        {
            document.getElementById('tdbtngo').style.display="block";
        }
        else
        {
            document.getElementById('tdbtngo').style.display="none";
        }
    document.getElementById("drpuom").value = gdsexecute.Tables[0].Rows[rowN].Uom;
    document.getElementById("txtsizefrom").value = gdsexecute.Tables[0].Rows[rowN].Size_From;
    document.getElementById("txtsizeto").value = gdsexecute.Tables[0].Rows[rowN].Size_To;
    document.getElementById("drppubcenter").value = gdsexecute.Tables[0].Rows[rowN].pub_center;
    document.getElementById("drppkgcode").value = gdsexecute.Tables[0].Rows[rowN].Combin_Code;
    
    document.getElementById("txtvalidfrom").value=showDate(gdsexecute.Tables[0].Rows[rowN].Valid_From);
    document.getElementById("txtvalidto").value=showDate(gdsexecute.Tables[0].Rows[rowN].Valid_To);
    
    if(gdsexecute.Tables[0].Rows[rowN].consumption_Per==null || gdsexecute.Tables[0].Rows[rowN].consumption_Per=="null")
    {
        document.getElementById("txtconsperiod").value="";
    }
    else
    {
        document.getElementById("txtconsperiod").value=gdsexecute.Tables[0].Rows[rowN].consumption_Per;
    }
    document.getElementById("drppremium").value=gdsexecute.Tables[0].Rows[rowN].Premium;
    
    if(gdsexecute.Tables[0].Rows[rowN].Premium_Charges==null || gdsexecute.Tables[0].Rows[rowN].Premium_Charges=="null")
    {
        document.getElementById("txtpremiumcharges").value="";
    }
    else
    {
        document.getElementById("txtpremiumcharges").value=gdsexecute.Tables[0].Rows[rowN].Premium_Charges;
    }
    
    document.getElementById("drpcolor").value=gdsexecute.Tables[0].Rows[rowN].Color;
    document.getElementById("drpcolortyp").value=gdsexecute.Tables[0].Rows[rowN].Col_chr_typ;
    
    if(gdsexecute.Tables[0].Rows[rowN].Remarks==null || gdsexecute.Tables[0].Rows[rowN].Remarks=="null")
    {
        document.getElementById("txtremarks").value="";
    }
    else
    {
        document.getElementById("txtremarks").value=gdsexecute.Tables[0].Rows[rowN].Remarks;
    }
    
    document.getElementById("txtrate").value=gdsexecute.Tables[0].Rows[rowN].Week_Day_Rate;
    
    if(gdsexecute.Tables[0].Rows[rowN].Week_min_rate==null || gdsexecute.Tables[0].Rows[rowN].Week_min_rate=="null")
    {
        document.getElementById("txtminrate").value="";
    }
    else
    {
        document.getElementById("txtminrate").value=gdsexecute.Tables[0].Rows[rowN].Week_min_rate;
    }
    if(gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate==null || gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate=="null")
        document.getElementById("txtextrarate").value="";
    else    
        document.getElementById("txtextrarate").value=gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate;
    
    if(gdsexecute.Tables[0].Rows[rowN].Focus_Day_Rate==null || gdsexecute.Tables[0].Rows[rowN].Focus_Day_Rate=="null")
    {
        document.getElementById("txtfocusrate").value="";
    }
    else
    {
        document.getElementById("txtfocusrate").value=gdsexecute.Tables[0].Rows[rowN].Focus_Day_Rate;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].Focus_min_rate==null || gdsexecute.Tables[0].Rows[rowN].Focus_min_rate=="null")
    {
        document.getElementById("txtfocusmin").value="";
    }
    else
    {
        document.getElementById("txtfocusmin").value=gdsexecute.Tables[0].Rows[rowN].Focus_min_rate;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].Focus_extra_rate==null || gdsexecute.Tables[0].Rows[rowN].Focus_extra_rate=="null")
    {
        document.getElementById("txtextrafocus").value="";
    }
    else
    {
        document.getElementById("txtextrafocus").value=gdsexecute.Tables[0].Rows[rowN].Focus_extra_rate;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].weekend_extra==null || gdsexecute.Tables[0].Rows[rowN].weekend_extra=="null")
    {
        document.getElementById("txtweekextra").value="";
    }
    else
    {
        document.getElementById("txtweekextra").value=gdsexecute.Tables[0].Rows[rowN].weekend_extra;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].weekend_min_rate==null || gdsexecute.Tables[0].Rows[rowN].weekend_min_rate=="null")
    {
        document.getElementById("txtweekminrate").value="";
    }
    else
    {
        document.getElementById("txtweekminrate").value=gdsexecute.Tables[0].Rows[rowN].weekend_min_rate;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].weekend_rate==null || gdsexecute.Tables[0].Rows[rowN].weekend_rate=="null")
    {
        document.getElementById("txtweekrate").value="";
    }
    else
    {
        document.getElementById("txtweekrate").value=gdsexecute.Tables[0].Rows[rowN].weekend_rate;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].min_ad_area==null || gdsexecute.Tables[0].Rows[rowN].min_ad_area=="null")
    {
        document.getElementById("txtminarea").value="";
    }
    else
    {
        document.getElementById("txtminarea").value=gdsexecute.Tables[0].Rows[rowN].min_ad_area;
    }

    if (document.getElementById("drpadtype").value != 'EL0') {
        if (gdsexecute.Tables[0].Rows[rowN].Edition_from == null || gdsexecute.Tables[0].Rows[rowN].Edition_from == "null") {
            document.getElementById("txtedfrom").value = "";

        }
        else {
            document.getElementById("txtedfrom").value = gdsexecute.Tables[0].Rows[rowN].Edition_from;
        }
    }
    else if (document.getElementById("drpadtype").value == 'EL0') {
        if (gdsexecute.Tables[0].Rows[rowN].Edition_from == null || gdsexecute.Tables[0].Rows[rowN].Edition_from == "null") {
            document.getElementById("txtedfrom").value = "";
            document.getElementById("hdnedfrom").value = "";
        }
        else {
            document.getElementById("hdnedfrom").value = (gdsexecute.Tables[0].Rows[rowN].Edition_from);
            document.getElementById("txtedfrom").value = get_btbname(gdsexecute.Tables[0].Rows[rowN].Edition_from);
        }
    }

    if (document.getElementById("drpadtype").value != 'EL0') {
        if (gdsexecute.Tables[0].Rows[rowN].Edition_to == null || gdsexecute.Tables[0].Rows[rowN].Edition_to == "null") {
            document.getElementById("txtedto").value = "";

        }
        else {
            document.getElementById("txtedto").value = gdsexecute.Tables[0].Rows[rowN].Edition_to;
        }
    }
    else if (document.getElementById("drpadtype").value == 'EL0') {
        if (gdsexecute.Tables[0].Rows[rowN].Edition_to == null || gdsexecute.Tables[0].Rows[rowN].Edition_to == "null") {
            document.getElementById("txtedto").value = "";
            document.getElementById("hdnedto").value = "";
        }
        else {
            document.getElementById("hdnedto").value = (gdsexecute.Tables[0].Rows[rowN].Edition_to);
            document.getElementById("txtedto").value = get_progname(gdsexecute.Tables[0].Rows[rowN].Edition_to);
        }
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].floor_amount==null || gdsexecute.Tables[0].Rows[rowN].floor_amount=="null")
    {
        document.getElementById("txtflramount").value="";
    }
    else
    {
        document.getElementById("txtflramount").value=gdsexecute.Tables[0].Rows[rowN].floor_amount;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].floor_discount==null || gdsexecute.Tables[0].Rows[rowN].floor_discount=="null")
    {
        document.getElementById("txtflrdiscount").value="";
    }
    else
    {
        document.getElementById("txtflrdiscount").value=gdsexecute.Tables[0].Rows[rowN].floor_discount;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].Scheme_Name==null || gdsexecute.Tables[0].Rows[rowN].Scheme_Name=="null")
    {
        document.getElementById("drpscheme").value="0";
    }
    else
    {
        var schemeid="";
        for(var cntr=0;cntr<document.getElementById("drpscheme").options.length;cntr++)
        {
            if(document.getElementById("drpscheme").options[cntr].text==gdsexecute.Tables[0].Rows[rowN].Scheme_Name)
            {
                schemeid=document.getElementById("drpscheme").options[cntr].value;
            }
        }
        document.getElementById("drpscheme").value=schemeid;
    }
    
    document.getElementById("txtfrominsert").value=gdsexecute.Tables[0].Rows[rowN].From_insertion;
    document.getElementById("txttoinsert").value=gdsexecute.Tables[0].Rows[rowN].To_insertion;
    
    if(gdsexecute.Tables[0].Rows[rowN].Agency_type==null || gdsexecute.Tables[0].Rows[rowN].Agency_type=="null")
    {
        document.getElementById("drpagentyp").value="";
    }
    else
    {
        document.getElementById("drpagentyp").value=gdsexecute.Tables[0].Rows[rowN].Agency_type;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].Client_cat==null || gdsexecute.Tables[0].Rows[rowN].Client_cat=="null")
    {
        document.getElementById("drpclientcat").value="";
    }
    else
    {
        document.getElementById("drpclientcat").value=gdsexecute.Tables[0].Rows[rowN].Client_cat;
    }
    
    if(gdsexecute.Tables[0].Rows[rowN].Max_Area==null || gdsexecute.Tables[0].Rows[rowN].Max_Area=="null")
    {
        document.getElementById("txtmaxarea").value="";
    }
    else
    {
        document.getElementById("txtmaxarea").value=gdsexecute.Tables[0].Rows[rowN].Max_Area;
    }
    
    document.getElementById("hiddenrateuniqid").value=gdsexecute.Tables[0].Rows[rowN].rateuniqueid;
    if(gdsexecute.Tables[0].Rows[rowN].SUN_RATE!=null)
        document.getElementById("txtratesun").value=gdsexecute.Tables[0].Rows[rowN].SUN_RATE;
    else
        document.getElementById("txtratesun").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].MON_RATE!=null)    
        document.getElementById("txtratemon").value=gdsexecute.Tables[0].Rows[rowN].MON_RATE;
    else
        document.getElementById("txtratemon").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].TUE_RATE!=null)    
        document.getElementById("txtratetue").value=gdsexecute.Tables[0].Rows[rowN].TUE_RATE;
    else
        document.getElementById("txtratetue").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].WED_RATE!=null)    
        document.getElementById("txtratewed").value=gdsexecute.Tables[0].Rows[rowN].WED_RATE;
    else
        document.getElementById("txtratewed").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].THU_RATE!=null)    
        document.getElementById("txtratethu").value=gdsexecute.Tables[0].Rows[rowN].THU_RATE;
    else
        document.getElementById("txtratethu").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].FRI_RATE!=null)    
        document.getElementById("txtratefri").value=gdsexecute.Tables[0].Rows[rowN].FRI_RATE;
    else
        document.getElementById("txtratefri").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].SAT_RATE!=null)    
        document.getElementById("txtratesat").value=gdsexecute.Tables[0].Rows[rowN].SAT_RATE;
    else
        document.getElementById("txtratesat").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].SUN_RATE_EXTRA!=null)
        document.getElementById("txtratesunextra").value=gdsexecute.Tables[0].Rows[rowN].SUN_RATE_EXTRA;
    else
        document.getElementById("txtratesunextra").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].MON_RATE_EXTRA!=null)    
        document.getElementById("txtratemonextra").value=gdsexecute.Tables[0].Rows[rowN].MON_RATE_EXTRA;
    else
        document.getElementById("txtratemonextra").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].TUE_RATE_EXTRA!=null)    
        document.getElementById("txtratetueextra").value=gdsexecute.Tables[0].Rows[rowN].TUE_RATE_EXTRA;
    else
        document.getElementById("txtratetueextra").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].WED_RATE_EXTRA!=null)    
        document.getElementById("txtratewedextra").value=gdsexecute.Tables[0].Rows[rowN].WED_RATE_EXTRA;
    else
        document.getElementById("txtratewedextra").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].THU_RATE_EXTRA!=null)    
        document.getElementById("txtratethuextra").value=gdsexecute.Tables[0].Rows[rowN].THU_RATE_EXTRA;
    else
        document.getElementById("txtratethuextra").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].FRI_RATE_EXTRA!=null)    
        document.getElementById("txtratefriextra").value=gdsexecute.Tables[0].Rows[rowN].FRI_RATE_EXTRA;
    else
        document.getElementById("txtratefriextra").value="";    
    if(gdsexecute.Tables[0].Rows[rowN].SAT_RATE_EXTRA!=null)    
        document.getElementById("txtratesatextra").value=gdsexecute.Tables[0].Rows[rowN].SAT_RATE_EXTRA;
    else
        document.getElementById("txtratesatextra").value="";    
    
    if(gdsexecute.Tables[0].Rows[rowN].MAXWIDTH==null || gdsexecute.Tables[0].Rows[rowN].MAXWIDTH=="null")
    {
        document.getElementById("txtmaxwidth").value="";
    }
    else
    {
        document.getElementById("txtmaxwidth").value=gdsexecute.Tables[0].Rows[rowN].MAXWIDTH;
    }

    if (gdsexecute.Tables[0].Rows[rowN].MIN_WIDTH == null || gdsexecute.Tables[0].Rows[rowN].MIN_WIDTH == "null") {
        document.getElementById("txtminwidth").value = "";
    }
    else {
        document.getElementById("txtminwidth").value = gdsexecute.Tables[0].Rows[rowN].MIN_WIDTH;
    }





    if (gdsexecute.Tables[0].Rows[rowN].MAX_WIDTH == null || gdsexecute.Tables[0].Rows[rowN].MAX_WIDTH == "null") {
        document.getElementById("txtmaxwidth12").value = "";
    }
    else {
        document.getElementById("txtmaxwidth12").value = gdsexecute.Tables[0].Rows[rowN].MAX_WIDTH;
    }
    
    
    
    
    
    
    if(gdsexecute.Tables[0].Rows[rowN].VAT_DETAIL ==0 || gdsexecute.Tables[0].Rows[rowN].VAT_DETAIL =="0" || gdsexecute.Tables[0].Rows[rowN].VAT_DETAIL =="" || gdsexecute.Tables[0].Rows[rowN].VAT_DETAIL ==null)
   {
       document.getElementById("chkvat").checked=false;
   }
  
  else 
   {       document.getElementById("chkvat").checked=true;
   
   }

 
    if(gdsexecute.Tables[0].Rows[rowN].REF_ID==null || gdsexecute.Tables[0].Rows[rowN].REF_ID=="null")
    {
        document.getElementById("txtref").value="";
    }
    else
    {
        document.getElementById("txtref").value=gdsexecute.Tables[0].Rows[rowN].REF_ID;
    }

    if (gdsexecute.Tables[0].Rows[rowN].CANCELLATION_CHARGES == null || gdsexecute.Tables[0].Rows[rowN].CANCELLATION_CHARGES == "null") {
        document.getElementById("txtcancellationcharges").value = "";
    }
    else {
        document.getElementById("txtcancellationcharges").value = gdsexecute.Tables[0].Rows[rowN].CANCELLATION_CHARGES;
    }
 
    if(gdsexecute.Tables[0].Rows[rowN].ADON==null || gdsexecute.Tables[0].Rows[rowN].ADON=="null")
    {
        document.getElementById("drpAdon").value="N";
    }
    else
    {
        document.getElementById("drpAdon").value=gdsexecute.Tables[0].Rows[rowN].ADON;
    }
if(gdsexecute.Tables[0].Rows[rowN].POSITION_PREM==null)
document.getElementById('drppageposition').value=0;
else
document.getElementById('drppageposition').value=gdsexecute.Tables[0].Rows[rowN].POSITION_PREM;

if ( document.getElementById("txtref").value =="")
{
document.getElementById("btnAdon").style.display = 'block';
document.getElementById("addonrow").style.display = 'none';
document.getElementById("btnAdon").disabled=true;
}
else
{
document.getElementById("addonrow").style.display = 'block';
document.getElementById("btnAdon").style.display = 'none';
}

}

function onchage_adtype()
{
    var adtype = document.getElementById("drpadtype").value;
    document.getElementById("hiddenadtype").Value = document.getElementById("drpadtype").value;
    
    var drpadcat=document.getElementById("drpadcategory");
    var drpsubcategory=document.getElementById("drpsubcategory");
    var drpadscat4=document.getElementById("drpadscat4");
    var drpadscat5=document.getElementById("drpadscat5");
    var drpadscat6=document.getElementById("drpadscat6");
    
    var drpuom=document.getElementById("drpuom");
    var drppkgcode=document.getElementById("drppkgcode");
    
    drpadcat.options.length=0;
    drpadcat.options[0]=new Option("--Select Category--","0");
    
    drpsubcategory.options.length=0;
    drpsubcategory.options[0]=new Option("--Select Sub Category--","0");
    
    drpadscat4.options.length=0;
    drpadscat4.options[0]=new Option("--Select--","0");
    
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("--Select--","0");
    
    drpadscat6.options.length=0;
    drpadscat6.options[0]=new Option("--Select--","0");
    
    drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    
    drppkgcode.options.length=0;
    drppkgcode.options[0]=new Option("--Select Package--","0");

    if (adtype != "0") {
        bind_pkg_adcat_uom(adtype);
    }
    hide_edition();
    return false;
}

function bind_pkg_adcat_uom(adtype)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var center=document.getElementById("drppubcenter").value;
    var res=Ratemaster.pkg_adcat_uom_bind(compcode, adtype, center);
    var ds=res.value;
    
    var drpadcat=document.getElementById("drpadcategory");
    var drpuom=document.getElementById("drpuom");
    var drppkgcode=document.getElementById("drppkgcode");
    
    drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    
    drppkgcode.options.length=0;
    drppkgcode.options[0]=new Option("--Select Package--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadcat.options[drpadcat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                drpadcat.options.length;   
            }
        }
        
        if(ds.Tables[1].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
                drpuom.options.length;   
            }
        }
        
        if(ds.Tables[2].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[2].Rows.length; ++i)
            {
                drppkgcode.options[drppkgcode.options.length] = new Option(ds.Tables[2].Rows[i].Package_Name,ds.Tables[2].Rows[i].Combin_Code);
                drppkgcode.options.length;   
            }
        }

       
    }
}

function onchange_cat()
{
    var adcatvalue = document.getElementById("drpadcategory").value;
    
    var drpadsubcat=document.getElementById("drpsubcategory");
    var drppremium=document.getElementById("drppremium");    
    
    var drpadscat4=document.getElementById("drpadscat4");
    var drpadscat5=document.getElementById("drpadscat5");
    var drpadscat6=document.getElementById("drpadscat6");
    
    drpadsubcat.options.length=0;
    drpadsubcat.options[0]=new Option("--Select Sub Category--","0");
    
    drppremium.options.length=0;
    drppremium.options[0]=new Option("--Select Premium--","0");
    
    drpadscat4.options.length=0;
    drpadscat4.options[0]=new Option("--Select--","0");
    
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("--Select--","0");
    
    drpadscat6.options.length=0;
    drpadscat6.options[0]=new Option("--Select--","0");
    
    if(adcatvalue!="0")
    {
        bind_subcat(adcatvalue);
        bind_premium(adcatvalue);
    }
    return false;
}

function bind_subcat(adcat)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=Ratemaster.adcatclick(compcode, adcat);
    var ds=res.value;
    var drpadsubcat=document.getElementById("drpsubcategory");
    drpadsubcat.options.length=0;
    drpadsubcat.options[0]=new Option("--Select Sub Category--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadsubcat.options[drpadsubcat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
                drpadsubcat.options.length;   
            }
        }
    }
}

function bind_premium(adcat)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=Ratemaster.bindpremium(compcode, adcat);
    var ds=res.value;
    var drppremium=document.getElementById("drppremium");
    drppremium.options.length=0;
    drppremium.options[0]=new Option("--Select Premium--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drppremium.options[drppremium.options.length] = new Option(ds.Tables[0].Rows[i].premiumname,ds.Tables[0].Rows[i].Premiumcode);
                drppremium.options.length;   
            }
        }
    }
}

function onchange_subcat()
{
    var adsubcatvalue = document.getElementById("drpsubcategory").value;
    
    var drpadscat5=document.getElementById("drpadscat5");
    var drpadscat6=document.getElementById("drpadscat6");
    var drpadscat4=document.getElementById("drpadscat4");
    
    drpadscat4.options.length=0;
    drpadscat4.options[0]=new Option("--Select--","0");
    
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("--Select--","0");
    
    drpadscat6.options.length=0;
    drpadscat6.options[0]=new Option("--Select--","0");
    
    if(adsubcatvalue!="0")
    {
        bind_subcat4(adsubcatvalue);
    }
    return false;
}

function bind_subcat4(adscatvalue)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=Ratemaster.bindsubcats(compcode, adscatvalue,"0");
    var ds=res.value;
    var drpadscat4=document.getElementById("drpadscat4");
    drpadscat4.options.length=0;
    drpadscat4.options[0]=new Option("--Select--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadscat4.options[drpadscat4.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
                drpadscat4.options.length;   
            }
        }
    }
}

function onchange_cat4()
{
    var adcat4value = document.getElementById("drpadscat4").value;
    
    var drpadscat5=document.getElementById("drpadscat5");    
    var drpadscat6=document.getElementById("drpadscat6");
    
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("--Select--","0");
    
    drpadscat6.options.length=0;
    drpadscat6.options[0]=new Option("--Select--","0");
    
    if(adcat4value!="0")
    {
        bind_subcat5(adcat4value);
    }
    return false;
}

function bind_subcat5(adscatvalue)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=Ratemaster.bindsubcats(compcode, adscatvalue,"1");
    var ds=res.value;
    var drpadscat5=document.getElementById("drpadscat5");
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("--Select--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadscat5.options[drpadscat5.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                drpadscat5.options.length;   
            }
        }
    }
}

function onchange_cat5()
{
    var adcat5value = document.getElementById("drpadscat5").value;
    
    var drpadscat6=document.getElementById("drpadscat6");
    
    drpadscat6.options.length=0;
    drpadscat6.options[0]=new Option("--Select--","0");
    
    if(adcat5value!="0")
    {
        bind_subcat6(adcat5value);
    }
    return false;
}

function bind_subcat6(adscatvalue)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=Ratemaster.bindsubcats(compcode, adscatvalue,"2");
    var ds=res.value;
    var drpadscat6=document.getElementById("drpadscat6");
    drpadscat6.options.length=0;
    drpadscat6.options[0]=new Option("--Select--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadscat6.options[drpadscat6.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                drpadscat6.options.length;   
            }
        }
    }
}

function showDate(datevalue)
{
    var dateformate=document.getElementById("hiddendateformat").value;
    var datev=new Date(datevalue);
    var dd=datev.getDate();
    var mm=datev.getMonth()+1;
    var yy=datev.getFullYear();
    
    if(dd<10)
        dd="0"+dd;
        
    if(mm<10)
        mm="0"+mm;
    
    var returndate="";
    
    if(dateformate=="dd/mm/yyyy")
    {
        returndate = dd + "/" + mm + "/" + yy;
    }
    else if(dateformate=="mm/dd/yyyy")
    {
        returndate = mm + "/" + dd + "/" + yy;
    }
    else if(dateformate=="yyyy/mm/dd")
    {
        returndate = yy + "/" + mm + "/" + dd;
    }
    return returndate;
}

function firstclick()
{
    rowN=0;
    
    document.getElementById("btnfirst").disabled=true;
    document.getElementById("btnprevious").disabled=true;
    document.getElementById("btnnext").disabled=false;
    document.getElementById("btnlast").disabled=false;
    
    bindctrls();
     bindPriorityRate();
    onchange_uom();
    document.getElementById('txtrate').disabled=true;
    setButtonImages();
    return false;
}

function prevclick()
{
    rowN--;
    if(rowN<=0)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
        rowN=0;
    }
    else
    {
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    bindctrls();
     bindPriorityRate();
    onchange_uom();
    document.getElementById('txtrate').disabled=true;
    setButtonImages();
    return false;
}

function nextclick()
{
    rowN++;
    if(rowN>=gdsexecute.Tables[0].Rows.length-1)
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
        rowN=gdsexecute.Tables[0].Rows.length-1;
    }
    else
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
    }
    bindctrls();
     bindPriorityRate();
    onchange_uom();
    document.getElementById('txtrate').disabled=true;
    setButtonImages();
    return false;
}

function lastclick()
{
    rowN=gdsexecute.Tables[0].Rows.length-1;
    
    document.getElementById("btnfirst").disabled=false;
    document.getElementById("btnprevious").disabled=false;
    document.getElementById("btnnext").disabled=true;
    document.getElementById("btnlast").disabled=true;
    
    bindctrls();
     bindPriorityRate();
    onchange_uom();
    document.getElementById('txtrate').disabled=true;
    setButtonImages();
    return false;
}

function onchange_drppkgcode()
{
    if(chkquery!="1")
    {
        var compcode=document.getElementById("hiddencompcode").value;
        var drppkgcode=document.getElementById("drppkgcode").value;
        var drppubcenter=document.getElementById("drppubcenter").value;
        var drpadtype=document.getElementById("drpadtype").value;
        
        var res=Ratemaster.drppkgcode_click(compcode,drppkgcode,drppubcenter,drpadtype);
        var ds=res.value;
        
        if(ds!=null)
        {
        document.getElementById("hiddenpriorityrates").value="";
            if(ds.Tables[0].Rows.length>0)
            {
                document.getElementById("hiddenchkcount").value="1";
            }
            else
            {
                document.getElementById("hiddenchkcount").value="0";
            }
            
            if(ds.Tables[1].Rows.length>0)
            {
                document.getElementById("txtpkgdesc").value=ds.Tables[1].Rows[0].Combin_Desc;
            }
            else
            {
                document.getElementById("txtpkgdesc").value="";
            }
        }
    }
    
    return false;
}


function onchange_drppremium()
{
    var compcode=document.getElementById("hiddencompcode").value;
    var drppremium=document.getElementById("drppremium").value;
    
    var res=Ratemaster.premiumclick(compcode,drppremium);
    var ds=res.value;
    
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
             document.getElementById("txtpremiumcharges").disabled=true;
             document.getElementById("txtpremiumcharges").value=ds.Tables[0].Rows[0].premium_charges;
             document.getElementById("drpcolortyp").value=ds.Tables[0].Rows[0].premium_charges_type;
        }
        else
        {
            document.getElementById("txtpremiumcharges").disabled=true;
            document.getElementById("txtpremiumcharges").value="";
            document.getElementById("drpcolortyp").value="0";
        }
    }
    
    document.getElementById("txtrate").value="";
    document.getElementById("txtminrate").value="";
    document.getElementById("txtextrarate").value="";
    document.getElementById("txtfocusrate").value="";
    document.getElementById("txtfocusmin").value="";
    document.getElementById("txtextrafocus").value="";
    document.getElementById("txtweekrate").value="";
    document.getElementById("txtweekminrate").value="";
    document.getElementById("txtweekextra").value="";
    document.getElementById("drpcolortyp").value="0";
    
    
    
    enabledayrate();
    
    return false;
}

function modifyclick()
{
    chkquery="0";
    hiddentext="modify";
    document.getElementById("lball").disabled = false;
    document.getElementById("btnpriority").disabled = false;
    document.getElementById("txtpriorityrate").disabled = false;
    document.getElementById("hiddenshow").value="1";
    document.getElementById("hiddenforfrid").value="1";
    
    document.getElementById("btnAdon").disabled=false;
     document.getElementById("txtpremiumcharges").disabled = false;
    document.getElementById("drprategroupcode").disabled=false;
    //document.getElementById("txtpkgdesc").disabled=false;
    document.getElementById("txtconsperiod").disabled=false;
    document.getElementById("txtremarks").disabled=false;
    document.getElementById("txtminarea").disabled=false;
    document.getElementById("txtedfrom").disabled=false;
    document.getElementById("txtedto").disabled=false;
    document.getElementById("txtflramount").disabled=false;
    document.getElementById("txtflrdiscount").disabled=false;
    document.getElementById("drpagentyp").disabled=false;
    document.getElementById("drpscheme").disabled=false;
    document.getElementById("txtmaxarea").disabled=false;
    document.getElementById("txtvalidfrom").disabled=false;
    document.getElementById("txtvalidto").disabled=false;
    document.getElementById("chkvat").disabled=false;
    document.getElementById("btnAdon").disabled = false;
    document.getElementById("lbaddon").disabled = false;
    
    document.getElementById("txtcancellationcharges").disabled = false;
    chkstatusrate(FlagStatus);
    
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnQuery").disabled=true;
   document.getElementById("drppageposition").disabled=false;
    enabledayrate();
    
    if(document.getElementById("hiddenbreakup").value == "1")
    {
        datagridincisible();
    }
    if(gdsexecute.Tables[0].Rows[rowN].desc.indexOf("+")>=0)
        {
            document.getElementById('tdbtngo').style.display="block";
        }
        else
        {
            document.getElementById('tdbtngo').style.display="none";
        }
        setButtonImages();
        
    document.getElementById("btnSave").focus();
    
    return false;
}

function onchange_uom()
{
    var value = "";
    var uom_desc = "";
    
    var compcode=document.getElementById("hiddencompcode").value;
    var uom=document.getElementById("drpuom").value;
    
    var index1=document.getElementById("drpadtype").selectedIndex;
    
  
        value = "1";
        var res=Ratemaster.binduom(compcode,uom);
        var ds=res.value;
        if(ds!=null)
        {
            if (ds.Tables[0].Rows.length > 0)
                uom_desc = ds.Tables[0].Rows[0].uom_desc;
        }
        
       /* if (uom_desc == "ROW")
        {           
             // document.getElementById('txtrate').disabled=false;
              document.getElementById("txtrate").style.backgroundColor="#FFFFFF";
              document.getElementById('lblextra').innerHTML="Extra Rate";
            if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[69].childNodes[0].nodeValue;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[71].childNodes[0].nodeValue;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[149].childNodes[0].nodeValue;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[151].childNodes[0].nodeValue;
              
            }
            else
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(34).text;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(35).text;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(74).text;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(75).text;
            }

        }*/
         if (uom_desc == "ROL" )
        {
             if(hiddentext!="query")
                 enabledayrate();
               document.getElementById('txtrate').disabled=false;
               document.getElementById("txtrate").style.backgroundColor="#FFFFFF";
               document.getElementById('lblextra').innerHTML="Extra Rate";
            if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[65].childNodes[0].nodeValue;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[67].childNodes[0].nodeValue;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[145].childNodes[0].nodeValue;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[147].childNodes[0].nodeValue;
            }
            else
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(32).text;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(33).text;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(72).text;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(73).text;
            }

        }
        else if(uom_desc == "ROW")
        {
        if(hiddentext!="query")
                 enabledayrate();
               document.getElementById('txtrate').disabled=false;
               document.getElementById("txtrate").style.backgroundColor="#FFFFFF";
               document.getElementById('lblextra').innerHTML="Extra Rate";
            if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[69].childNodes[0].nodeValue;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[71].childNodes[0].nodeValue;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[149].childNodes[0].nodeValue;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[151].childNodes[0].nodeValue;
            }
            else
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(34).text;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(35).text;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(74).text;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(75).text;
            }
        }
        else if(uom_desc == "CD" || uom_desc == "ROD")
        {
        if(hiddentext!="query")
                 enabledayrate();
               document.getElementById('txtrate').disabled=false;
               document.getElementById("txtrate").style.backgroundColor="#FFFFFF";
               document.getElementById('lblextra').innerHTML="Extra Rate";
            if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[17].childNodes[0].nodeValue;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[19].childNodes[0].nodeValue;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[143].childNodes[0].nodeValue;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[97].childNodes[0].nodeValue;
            }
            else
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(8).text;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(9).text;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(71).text;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(48).text;
            }
        }
        else if(uom_desc == "ROC" )
        {
        if(hiddentext!="query")
                 enabledayrate();
               document.getElementById('txtrate').disabled=false;
               document.getElementById("txtrate").style.backgroundColor="#FFFFFF";
               document.getElementById('lblextra').innerHTML="Extra Rate";
            if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[153].childNodes[0].nodeValue;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[155].childNodes[0].nodeValue;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[157].childNodes[0].nodeValue;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[159].childNodes[0].nodeValue;
            }
            else
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(78).text;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(79).text;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(76).text;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(77).text;
            }
        }
        else
        {
        if(hiddentext!="query")
                 enabledayrate();
               document.getElementById('txtrate').disabled=false;
               document.getElementById("txtrate").style.backgroundColor="#FFFFFF";
               document.getElementById('lblextra').innerHTML="Extra Rate";
            if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[65].childNodes[0].nodeValue;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[67].childNodes[0].nodeValue;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[145].childNodes[0].nodeValue;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[147].childNodes[0].nodeValue;
            }
            else
            {
                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(32).text;
                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(33).text;
                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(72).text;
                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(73).text;
            }
        }
//////        else
//////        {
//////             
//////              document.getElementById('txtrate').disabled=true;
//////              if(hiddentext=="new" || hiddentext=="modify")
//////              document.getElementById("txtextrarate").disabled=false;
//////               if(hiddentext!="query" && hiddentext!="new" && hiddentext!="modify")
//////                 disabledayrate();
//////              document.getElementById("txtrate").style.backgroundColor="Gray";
//////              document.getElementById('lblextra').innerHTML="Rate";
//////            if(browser!="Microsoft Internet Explorer")
//////            {
//////                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes[1].childNodes[17].childNodes[0].nodeValue;
//////                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes[1].childNodes[19].childNodes[0].nodeValue;
//////                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes[1].childNodes[143].childNodes[0].nodeValue;
//////                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes[1].childNodes[97].childNodes[0].nodeValue;
//////            }
//////            else
//////            {
//////                document.getElementById("lblSizefrom").innerHTML = xmlObj.childNodes(0).childNodes(8).text;
//////                document.getElementById("lblsizeto").innerHTML = xmlObj.childNodes(0).childNodes(9).text;
//////                document.getElementById("lbminarea").innerHTML = xmlObj.childNodes(0).childNodes(71).text;
//////                document.getElementById("lbmaxarea").innerHTML = xmlObj.childNodes(0).childNodes(48).text;
//////            }
//////        }
//        document.getElementById("txtsizefrom").value = "";
//        document.getElementById("txtsizeto").value = "";
        if (document.getElementById("drpadtype").options[index1].text != "CLASSIFIED")
    {
         value = "0";
    }
    //}
//    else
//    {
//        value = "0";
//    }


    return false;
}

function onchange_center()
{
    var compcode=document.getElementById("hiddencompcode").value;
    var center=document.getElementById("drppubcenter").value;
    var adtype=document.getElementById("drpadtype").value;
    var res=Ratemaster.pkg_adcat_uom_bind(compcode, adtype, center);
    var ds=res.value;
    
    var drppkgcode=document.getElementById("drppkgcode");
    
    drppkgcode.options.length=0;
    drppkgcode.options[0]=new Option("--Select Package--","0");
    
    if(ds.Tables[2].Rows.length>0)
    {
        for (i = 0  ; i < ds.Tables[2].Rows.length; ++i)
        {
            drppkgcode.options[drppkgcode.options.length] = new Option(ds.Tables[2].Rows[i].Package_Name,ds.Tables[2].Rows[i].Combin_Code);
            drppkgcode.options.length;   
        }
    }
    
    return false;
}

function saveclick()
{
    var agency_code = document.getElementById("drpagencycode").value;
    document.getElementById("hiddenchkforgo").value = "0";
    var ratecode = document.getElementById("txtratecode").value;
    var adtype = document.getElementById("drpadtype").value;
    var rategroupcode = document.getElementById("drprategroupcode").value;
    var adcategory = document.getElementById("drpadcategory").value;
    var currency = document.getElementById("drpcurrency").value;
    var adsubcategory = document.getElementById("drpsubcategory").value;
    var packagecode = document.getElementById("drppkgcode").value;
    var packagedesc = document.getElementById("txtpkgdesc").value;
    var uom = document.getElementById("drpuom").value;
    
    var sizefrom = "";
    var sizeto = "";
    
    if (document.getElementById("txtsizefrom").value == "")
    {
        sizefrom = "0";
    }
    else
    {
        sizefrom=document.getElementById("txtsizefrom").value;
    }
    if (document.getElementById("txtsizeto").value == "")
    {
        sizeto = "0";
    }
    else
    {
        sizeto = document.getElementById("txtsizeto").value;
    }
//    if (document.getElementById('tdgrid').style.display == "block" || document.getElementById('tdbtngo').style.display == "block") {
//        checkpackagerate();
//    }
    var consumption = document.getElementById("txtconsperiod").value;
    var color = document.getElementById("drpcolor").value;
    var colorchrty = document.getElementById("drpcolortyp").value;
    var remarks = document.getElementById("txtremarks").value;
    var weekdrate = document.getElementById("txtrate").value;
    var weeminrate = document.getElementById("txtminrate").value;
    var extweerate = document.getElementById("txtextrarate").value;
    var focusdarate = document.getElementById("txtfocusrate").value;
    var focminrate = document.getElementById("txtfocusmin").value;
    var focexrate = document.getElementById("txtextrafocus").value;
    var fromdate = document.getElementById("txtvalidfrom").value;
    var tilldate = document.getElementById("txtvalidto").value;
    var scheme = document.getElementById("drpscheme").value;
    var premium = document.getElementById("drppremium").value.toUpperCase();
    var premiumval = document.getElementById("txtpremiumcharges").value;
    var weekendrate = document.getElementById("txtweekrate").value;
    var weekendmin = document.getElementById("txtweekminrate").value;
    var weekextra = document.getElementById("txtweekextra").value;
    var minadarea = document.getElementById("txtminarea").value;
    if(weekdrate=="" || weekdrate=="null")
        weekdrate="0";
    if(extweerate=="" || extweerate=="null")
        extweerate="";    
    if (minadarea == "")
    {
        minadarea = "0";
    }

    if (adtype == 'EL0') {
        var editionfrom = document.getElementById("hdnedfrom").value;
    }
    else {
        var editionfrom = document.getElementById("txtedfrom").value;
    }
    if (adtype == 'EL0') {
        var editionto = document.getElementById("hdnedto").value;
    }
    else {
        var editionto = document.getElementById("txtedto").value;
    }
    var flramount = document.getElementById("txtflramount").value;
    var flrdiscount = document.getElementById("txtflrdiscount").value;
    var adscat4 = document.getElementById("drpadscat4").value;
    var adscat5 = document.getElementById("drpadscat5").value;
    var adscat6 = document.getElementById("drpadscat6").value;
    
    var agtype = document.getElementById("drpagentyp").value;
    var clientcat = document.getElementById("drpclientcat").value;
    var pubcenter = document.getElementById("drppubcenter").value;
    
    var rate_sun = document.getElementById("txtratesun").value;
    if (rate_sun == "")
        rate_sun = "0";

    var rate_mon = document.getElementById("txtratemon").value;
    if (rate_mon == "")
        rate_mon = "0";

    var rate_tue = document.getElementById("txtratetue").value;
    if (rate_tue == "")
        rate_tue = "0";

    var rate_wed = document.getElementById("txtratewed").value;
    if (rate_wed == "")
        rate_wed = "0";

    var rate_thu = document.getElementById("txtratethu").value;
    if (rate_thu == "")
        rate_thu = "0";

    var rate_fri = document.getElementById("txtratefri").value;
    if (rate_fri == "")
        rate_fri = "0";

    var rate_sat = document.getElementById("txtratesat").value;
    if (rate_sat == "")
        rate_sat = "0";

    var rate_sun_extra = document.getElementById("txtratesunextra").value;
    var rate_mon_extra = document.getElementById("txtratemonextra").value;
    var rate_tue_extra = document.getElementById("txtratetueextra").value;
    var rate_wed_extra = document.getElementById("txtratewedextra").value;
    var rate_thu_extra = document.getElementById("txtratethuextra").value;
    var rate_fri_extra = document.getElementById("txtratefriextra").value;
    var rate_sat_extra = document.getElementById("txtratesatextra").value;

    var width_max = document.getElementById("txtmaxwidth").value;
    if (width_max == "")
        width_max = "0";



    var minwidth = document.getElementById('txtminwidth').value
    if (minwidth == "")
        minwidth = "0";
    
    var maxwidth = document.getElementById('txtmaxwidth12').value;

    if (maxwidth == "")
        maxwidth = "0";
    var max_area = document.getElementById("txtmaxarea").value;
    
    var compcode = document.getElementById("hiddencompcode").value;
    var txtfrominsert=document.getElementById("txtfrominsert").value;
    var txttoinsert=document.getElementById("txttoinsert").value;
    var drpagencycode=document.getElementById("drpagencycode").value;
    var dateformat=document.getElementById("hiddendateformat").value;
    
    var decimalvalue=document.getElementById("hiddenDecimal").value;

    var userid = document.getElementById("hiddenuserid").value;
    var cancellation = document.getElementById("txtcancellationcharges").value;
    var pageposition= document.getElementById("drppageposition").value;
    var vat;
    if(document.getElementById("chkvat").checked==true)
      {
        vat="1";
        }
    else
    {
        vat="0";
    }
     var Adon=document.getElementById("drpAdon").value;
    
    var refrence=document.getElementById("txtref").value;
    
   // var packagedesc=document.getElementById("drppkgcode").options[document.getElementById("drppkgcode").selectedIndex].text;
    
    var type_="company";
    
    var rateuniqueid = "";
    
   // if(adtype=="CL0")
    //{
        rateuniqueid = pubcenter + ratecode + adtype + adcategory + adsubcategory + color + packagecode + currency + fromdate + tilldate + uom + adscat4 + adscat5 + adscat6 + premium + sizefrom + sizeto + txtfrominsert + txttoinsert + clientcat+pageposition;
    //}
//    if(adtype=="DI0")
//    {
//        rateuniqueid = pubcenter + ratecode + adtype + adcategory + adsubcategory + color + packagecode + currency + fromdate + tilldate + uom + premium + sizefrom + sizeto + txtfrominsert + txttoinsert + clientcat;
//    }
        var returnv = validation_savedtls(rateuniqueid);
        var positionprem = document.getElementById('drppageposition').value;
    if(returnv!=false)
    {
        // Fot Saving a new record
        if (document.getElementById('tdgrid').style.display == "block" || document.getElementById('tdbtngo').style.display == "block") {
            var response = checkpackagerate();
            if (response == false) {
                return false;
            }
           
        }
        if(document.getElementById("hiddenforfrid").value=="0")
        {
            var dup_res=chkratecode_dup(compcode, ratecode, adtype, adcategory, adsubcategory, color, packagecode, currency, fromdate, tilldate, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, drpagencycode, dateformat, pubcenter);
            if(dup_res == false)
            {
                return false;
            }
            solopkgname=chksolopkg(rateuniqueid, compcode, packagecode, weekdrate, focusdarate, ratecode, adtype, adcategory, adsubcategory, color, currency, fromdate, tilldate, weekendrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, extweerate);
            if (solopkgname != "") {
                if (document.getElementById("hidsoloauto").value == "Y") {
                    //if (confirm(solopkgname + " Edition Solo Rate Has Not Been Assigned. Are You want to Create It automatically")) {
                    if (confirm("Package Edition Solo Rate Has Not Been Assigned. Are You want to Create It automatically")) {
                        //    alert("Yes");
                        while (solopkgname != "") {
                            var resedi = Ratemaster.getcombincode(solopkgname, adtype);
                            var combincode_edition = resedi.value.Tables[0].Rows[0].Combin_Code;
                            //  alert(combincode_edition);
                            var editionrateuniqueid = pubcenter + ratecode + adtype + adcategory + adsubcategory + color + combincode_edition + currency + fromdate + tilldate + uom + adscat4 + adscat5 + adscat6 + premium + sizefrom + sizeto + txtfrominsert + txttoinsert + clientcat + pageposition;
                            // alert(editionrateuniqueid);
                            Ratemaster.saverate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, combincode_edition, solopkgname, uom, sizefrom, sizeto, consumption, color, colorchrty, "1", weeminrate, "1", focusdarate, focminrate, focexrate, fromdate, tilldate, remarks, premium, premiumval, editionrateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, agtype, clientcat, max_area, type_, agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max, document.getElementById('txtpriorityrate').value, vat, Adon, refrence, cancellation, positionprem, minwidth, maxwidth);
                            solopkgname = chksolopkg(rateuniqueid, compcode, packagecode, weekdrate, focusdarate, ratecode, adtype, adcategory, adsubcategory, color, currency, fromdate, tilldate, weekendrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, extweerate);
                        }
                        alert("Package Edition Solo Rate Has Been Created");
                        return false;
                    }
                    else {
                        return false;
                    }
                 }
                else {
                    alert(solopkgname + " Edition Solo Rate Has Not Been Assigned");
                 //   return false;
                }
            }
//            else if (solopkgname == "false")
//                return false;
            
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
              var v_fromdate = "";
              var v_tilldate = "";
              if (document.getElementById('hdncon').value == "mysql") {
                  var fdd = fromdate.split("/")[0];
                  var fmm = fromdate.split("/")[1];
                  var fyy = fromdate.split("/")[2];

                  v_fromdate = fyy + "/" + fmm + "/" + fdd;

                  var tfdd = tilldate.split('/')[0];
                  var tfmm = tilldate.split('/')[1];
                  var tfyy = tilldate.split('/')[2];

                  v_tilldate = tfyy + "/" + tfmm + "/" + tfdd;
              }
              else {
                  v_fromdate = fromdate;
                  v_tilldate = tilldate;

              }
       // return false;
       Ratemaster.saverate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, packagecode, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, v_fromdate, v_tilldate, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, agtype, clientcat, max_area, type_, agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max, document.getElementById('txtpriorityrate').value, vat, Adon, refrence, cancellation,positionprem,minwidth,maxwidth);
            Ratemaster.saveratedetails(rateuniqueid, compcode, packagecode, weekdrate, focusdarate, ratecode, adtype, adcategory, adsubcategory, color, currency, fromdate, tilldate, weekendrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, "company", agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, extweerate, userid);
            Ratemaster.saveaddons(compcode, userid, type_, rateuniqueid);
            if(document.getElementById('hiddenpriorityrates').value!="")
                Ratemaster.insert_priority_rate(rateuniqueid,document.getElementById('hiddenpriorityrates').value);

            //alert("Data Saved Successfully");
           if(confirm("Data Saved Successfully.Do you want to continue."))
            {
                if (document.getElementById('hdnconfigclient').value == "PUNE")
                    executeclick();
                return false;
            }
            document.getElementById("hiddenforfrid").value = "01";
                if(document.getElementById('txtref').value != "")
                {
                    document.getElementById('txtref').value="";
                    window.close();
                }
                cancelclick();
        }
        
        //For Modification
        else
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
            rateuniqueid=document.getElementById("hiddenrateuniqid").value;
            var positionprem = document.getElementById('drppageposition').value;
            var minwidth = document.getElementById('txtminwidth').value;
            var maxwidth = document.getElementById('txtmaxwidth12').value;
            Ratemaster.modifyrate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, packagecode, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, fromdate, tilldate, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, agtype, clientcat, max_area, type_, agency_code, dateformat, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max, document.getElementById('txtpriorityrate').value, vat, Adon, refrence, cancellation,positionprem,minwidth,maxwidth);
            document.getElementById("drprategroupcode").disabled = true;
            document.getElementById("txtpriorityrate").disabled = true;
            document.getElementById("txtvalidfrom").disabled = true;
            document.getElementById("txtvalidto").disabled = true;
            document.getElementById("drpscheme").disabled = true;
            document.getElementById("txtpremiumcharges").disabled = true;
            document.getElementById("drpagentyp").disabled = true;
            document.getElementById("txtmaxwidth").disabled = true;
            document.getElementById("txtminwidth").disabled = true;
            document.getElementById("txtmaxwidth12").disabled = true;
            document.getElementById("txtminwidth").disabled = true;
            document.getElementById("txtmaxwidth12").disabled = true;
            document.getElementById("txtminarea").disabled = true;
            document.getElementById("txtmaxarea").disabled = true;
            document.getElementById("txtconsperiod").disabled = true;
            document.getElementById("txtremarks").disabled=true;
             document.getElementById("txtflramount").disabled = true;
              document.getElementById("hiddenforfrid").value = "01";
              document.getElementById("chkvat").disabled = true;
              document.getElementById("txtcancellationcharges").disabled = true;
              
            disabledayrate();
            updateStatusRate();
            var positionprem = document.getElementById('drppageposition').value;
            var subcat = document.getElementById('drpsubcategory').value;
            var validfrom = document.getElementById("txtvalidfrom").value;
            var res = Ratemaster.executerate(compcode, gbratecode, gbadtype, gbcurrency, gbratetype, gbcolor, gbuom, gbpkgcode, gbcenter, gcatcode, positionprem,validfrom,document.getElementById("hiddendateformat").value , subcat)
            executeclick_call(res);
            alert("Data Modified Successfully");
        }
    }
    //////////////////////////////////////////////////////////////////////////////
    return false;
}

function deleteclick()
{
    if(confirm('Are you sure you want to delete?'))
    {
        var compcode = document.getElementById("hiddencompcode").value;
        var rateuniqueid=document.getElementById("hiddenrateuniqid").value;
        var type_="company";
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
Ratemaster.deleterate_a(rateuniqueid, compcode, type_);
        alert("Data Deleted Successfully");
        var positionprem = document.getElementById('drppageposition').value;
        var subcat = document.getElementById('drpsubcategory').value;
        var validfrom = document.getElementById("txtvalidfrom").value;
        var res = Ratemaster.executerate(compcode, gbratecode, gbadtype, gbcurrency, gbratetype, gbcolor, gbuom, gbpkgcode, gbcenter,gcatcode,positionprem,validfrom,document.getElementById("hiddendateformat").value ,subcat)
        executeclick_call(res);
        
    }
    return false;
}

function chkratecode_dup(compcode, ratecode, adtype, adcategory, adsubcategory, color, packagecode, currency, validfrom, validto, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, drpagencycode, dateformat, pubcenter)
{
    var res=Ratemaster.chkratecode(compcode, ratecode, adtype, adcategory, adsubcategory, color, packagecode, currency, validfrom, validto, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, drpagencycode, dateformat, pubcenter)
    var ds=res.value;
    
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            alert("This rate code has been assigned");
            return false;
        }
    }
}

function chksolopkg(rateid, compcode, packagecode, weekdrate, focusdarate, ratecode, adtype, adcategory, adsubcategory, color, currency, validfrom, validto, weekendrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, extweerate)
{
    var returnvalue="";
    returnvalue=Ratemaster.getsoloname(rateid, compcode, packagecode, weekdrate, focusdarate, ratecode, adtype, adcategory, adsubcategory, color, currency, validfrom, validto, weekendrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, minadarea, "company", agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, extweerate);
    if(returnvalue!="")
        document.getElementById("hiddenchkcount").value = "1";
        if(returnvalue.error!=null)
        {
            alert(returnvalue.error.description);
                return "false";
        }
    return returnvalue.value;
}

function showdetails()
{
    var str="";
    var compcode = document.getElementById("hiddencompcode").value;
    var pkgcode = document.getElementById("drppkgcode").value;
    var drpcurrency = document.getElementById("drpcurrency").value;
    var drpcolor = document.getElementById("drpcolor").value;
    var drpuom = document.getElementById("drpuom").value;
    var drpadtype = document.getElementById("drpadtype").value;
    var drpadcategory = document.getElementById("drpadcategory").value;
    var drpsubcategory = document.getElementById("drpsubcategory").value;
    var drpadscat4 = document.getElementById("drpadscat4").value;
    var drpadscat5 = document.getElementById("drpadscat5").value;
    var drpadscat6 = document.getElementById("drpadscat6").value;
    var drppremium = document.getElementById("drppremium").value.toUpperCase();
    var drpclientcat = document.getElementById("drpclientcat").value;
    var drpagencycode = document.getElementById("drpagencycode").value;
    var drppubcenter = document.getElementById("drppubcenter").value;
    
    var rate = document.getElementById("txtrate").value;
    var focusrate = document.getElementById("txtfocusrate").value;
    var ratecode = document.getElementById("txtratecode").value;
    var ratecode = document.getElementById("txtratecode").value;
    
    var validfromdate1 = document.getElementById("txtvalidfrom").value;
    var validtill1 = document.getElementById("txtvalidto").value;
    
    var validtill1 = document.getElementById("txtvalidto").value;
    var weekrate = document.getElementById("txtweekrate").value;
    var decimalvalue = document.getElementById("hiddenDecimal").value;
    var sizefrom = document.getElementById("txtsizefrom").value;
    var sizeto = document.getElementById("txtsizeto").value;
    var frominsert = document.getElementById("txtfrominsert").value;
    var toinsert = document.getElementById("txttoinsert").value;
    var minarea = document.getElementById("txtminarea").value;
    
    var type_ = "company";
    
    var dateformat = document.getElementById("hiddendateformat").value;
    var ratesun = document.getElementById("txtratesun").value;
    var ratemon = document.getElementById("txtratemon").value;
    var ratetue = document.getElementById("txtratetue").value;
    var ratewed = document.getElementById("txtratewed").value;
    var ratethu = document.getElementById("txtratethu").value;
    var ratefri = document.getElementById("txtratefri").value;
    var ratesat = document.getElementById("txtratesat").value;
    var ratesunextra = document.getElementById("txtratesunextra").value;
    var ratemonextra = document.getElementById("txtratemonextra").value;
    var tratetueextra = document.getElementById("txtratetueextra").value;
    var ratewedextra = document.getElementById("txtratewedextra").value;
    var ratethuextra = document.getElementById("txtratethuextra").value;
    var ratefriextra = document.getElementById("txtratefriextra").value;
    var ratesatextra = document.getElementById("txtratesatextra").value;
    var extrarate = document.getElementById("txtextrarate").value;
    
    document.getElementById("hidden_drpvalus_grid").value=str;
    
    document.getElementById('tdbtngo').style.display="none";
    document.getElementById('tdgrid').style.display="block";
    
    document.getElementById('tdgrid').innerHTML = "";
    var res = null;
    if(changeRate==0)
    {
        res = Ratemaster.showratedetails(compcode, document.getElementById("hiddenrateuniqid").value);
    }
    else
    {
        res = Ratemaster.showratedetails_modi(compcode, pkgcode, rate, focusrate, ratecode, drpadtype, drpadcategory, drpsubcategory, drpcolor, drpcurrency, validfromdate1, validtill1, weekrate, decimalvalue, drpuom, drpadscat4, drpadscat5, drpadscat6, drppremium, sizefrom, sizeto, frominsert, toinsert, drpclientcat, minarea, type_, drpagencycode, dateformat, drppubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, tratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, extrarate);
        changeRate = 0;
    }
    if(res.error!=null)
    {
        alert("Error : \n" + res.error);
        return false;
    }
    
    var ds = res.value;
    var divstr = "";
    var txtBox = "";
    
    if(ds!=null)
    {
        divstr += "<table id='gridrate'>";
        divstr += "<tr>";
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Edition";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Week Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Week Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Week End Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Solo Week Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Solo Week End Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Sun Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Mon Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Tue Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Wed Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Thu Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Fri Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Sat Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Sun Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Mon Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Tue Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Wed Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Thu Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Fri Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Sat Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Focus Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Focus Extra Rate";
            divstr += "</td>";
            
            divstr += "<td class=tblFieldDayRate>";
                divstr += "Package Name";
            divstr += "</td>";
            
        divstr += "</tr>";
        
        if(document.getElementById("hiddenforfrid").value!="1")
        {
        
            for(var ds_row_cntr = 0; ds_row_cntr<ds.Tables[0].Rows.length; ds_row_cntr++)
            {
                txtBox = "txtGridEdi" + ds_row_cntr;
                divstr += "<tr>";
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].Edition_Name + "' Class=\"btextforgrid_b\" MaxLength=\"50\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtGridRate" + ds_row_cntr;//Id for Week Rate 
                     if(ds.Tables[0].Rows[ds_row_cntr].Rate == null || ds.Tables[0].Rows[ds_row_cntr].Rate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].Rate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].Rate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWExRate" + ds_row_cntr;//Id for Week Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].Week_Extra_Rate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWEnRate" + ds_row_cntr;//Id for Week End Rate
                    if(ds.Tables[0].Rows[ds_row_cntr].weekendrate == null || ds.Tables[0].Rows[ds_row_cntr].weekendrate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].weekendrate = 0;
                    }  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].weekendrate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSWRate" + ds_row_cntr;//Id for Solo Week Rate  
                    if(ds.Tables[0].Rows[ds_row_cntr].soloweekendrate == null || ds.Tables[0].Rows[ds_row_cntr].soloweekendrate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].soloweekendrate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                    if(ds.Tables[0].Rows[ds_row_cntr].soloweeraterate!=null)
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].soloweeraterate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    else
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='0' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";    
                    divstr += "</td>";
                    
                    txtBox = "txtSWEnRate" + ds_row_cntr;//Id for Solo Week End Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].soloweekendrate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSunRate" + ds_row_cntr;//Id for Sunday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].SUN_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtMonRate" + ds_row_cntr;//Id for Monday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].MON_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtTueRate" + ds_row_cntr;//Id for Tuesday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].TUE_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWedRate" + ds_row_cntr;//Id for Wednesday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].WED_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtThuRate" + ds_row_cntr;//Id for Thurseday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].THU_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFriRate" + ds_row_cntr;//Id for Friday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].FRI_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSatRate" + ds_row_cntr;//Id for Saturday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].SAT_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSunExRate" + ds_row_cntr;//Id for Sunday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].SUN_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtMonExRate" + ds_row_cntr;//Id for Monday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].MON_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtTueExRate" + ds_row_cntr;//Id for Tuesday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].TUE_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWedExRate" + ds_row_cntr;//Id for Wednesday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].WED_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtThuExRate" + ds_row_cntr;//Id for Thurseday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].THU_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFriExRate" + ds_row_cntr;//Id for Friday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].FRI_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSatExRate" + ds_row_cntr;//Id for Saturday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].SAT_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFRate" + ds_row_cntr;//Id for Focus Rate
                    if(ds.Tables[0].Rows[ds_row_cntr].focusrate == null || ds.Tables[0].Rows[ds_row_cntr].focusrate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].focusrate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].focusrate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFExRate" + ds_row_cntr;//Id for Focus Extra Rate
                    if(ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate == null || ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtPkgName" + ds_row_cntr;//Id for Package Name
                    if(ds.Tables[0].Rows[ds_row_cntr].PKGNAME == null || ds.Tables[0].Rows[ds_row_cntr].PKGNAME == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].PKGNAME = ds.Tables[0].Rows[ds_row_cntr].Edition_Name;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].PKGNAME + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                divstr += "</tr>";
            }
        }
        else
        {
            for(var ds_row_cntr = 0; ds_row_cntr<ds.Tables[0].Rows.length; ds_row_cntr++)
            {
                txtBox = "txtGridEdi" + ds_row_cntr;
                divstr += "<tr>";
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].Edition_Name + "' Class=\"btextforgrid\" MaxLength=\"50\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtGridRate" + ds_row_cntr;//Id for Week Rate 
                    divstr += "<td class=tblDayRate_Data>";
                    if(ds.Tables[0].Rows[ds_row_cntr].Rate!=null)
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" value='" + ds.Tables[0].Rows[ds_row_cntr].Rate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    else
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" value='0' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";    
                    divstr += "</td>";
                    
                    txtBox = "txtWExRate" + ds_row_cntr;//Id for Week Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" value='" + ds.Tables[0].Rows[ds_row_cntr].Week_Extra_Rate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWEnRate" + ds_row_cntr;//Id for Week End Rate
                    if(ds.Tables[0].Rows[ds_row_cntr].weekendrate == null || ds.Tables[0].Rows[ds_row_cntr].weekendrate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].weekendrate = 0;
                    }  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].weekendrate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                     if(ds.Tables[0].Rows[ds_row_cntr].soloweeraterate == null || ds.Tables[0].Rows[ds_row_cntr].soloweeraterate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].soloweeraterate = 0;
                    }  
                    txtBox = "txtSWRate" + ds_row_cntr;//Id for Solo Week Rate  
                    if(ds.Tables[0].Rows[ds_row_cntr].soloweekendrate == null || ds.Tables[0].Rows[ds_row_cntr].soloweekendrate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].soloweekendrate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].soloweeraterate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSWEnRate" + ds_row_cntr;//Id for Solo Week End Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].soloweekendrate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSunRate" + ds_row_cntr;//Id for Sunday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" value='" + ds.Tables[0].Rows[ds_row_cntr].SUN_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtMonRate" + ds_row_cntr;//Id for Monday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].MON_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtTueRate" + ds_row_cntr;//Id for Tuesday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].TUE_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWedRate" + ds_row_cntr;//Id for Wednesday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].WED_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtThuRate" + ds_row_cntr;//Id for Thurseday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].THU_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFriRate" + ds_row_cntr;//Id for Friday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].FRI_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSatRate" + ds_row_cntr;//Id for Saturday Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].SAT_RATE + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSunExRate" + ds_row_cntr;//Id for Sunday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].SUN_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtMonExRate" + ds_row_cntr;//Id for Monday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].MON_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtTueExRate" + ds_row_cntr;//Id for Tuesday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].TUE_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtWedExRate" + ds_row_cntr;//Id for Wednesday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].WED_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtThuExRate" + ds_row_cntr;//Id for Thurseday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].THU_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFriExRate" + ds_row_cntr;//Id for Friday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].FRI_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtSatExRate" + ds_row_cntr;//Id for Saturday Extra Rate  
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\"  value='" + ds.Tables[0].Rows[ds_row_cntr].SAT_RATE_EXTRA + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFRate" + ds_row_cntr;//Id for Focus Rate
                    if(ds.Tables[0].Rows[ds_row_cntr].focusrate == null || ds.Tables[0].Rows[ds_row_cntr].focusrate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].focusrate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled  value='" + ds.Tables[0].Rows[ds_row_cntr].focusrate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtFExRate" + ds_row_cntr;//Id for Focus Extra Rate
                    if(ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate == null || ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate = 0;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled  value='" + ds.Tables[0].Rows[ds_row_cntr].focus_extra_rate + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                    txtBox = "txtPkgName" + ds_row_cntr;//Id for Package Name
                    if(ds.Tables[0].Rows[ds_row_cntr].PKGNAME == null || ds.Tables[0].Rows[ds_row_cntr].PKGNAME == "null")
                    {
                        ds.Tables[0].Rows[ds_row_cntr].PKGNAME = ds.Tables[0].Rows[ds_row_cntr].Edition_Name;
                    }
                    divstr += "<td class=tblDayRate_Data>";
                        divstr += "<input id=" + txtBox + " type=\"TextBox\" disabled value='" + ds.Tables[0].Rows[ds_row_cntr].PKGNAME + "' Class=\"btextforgrid\" OnChange=\"return chkamountgrid(this);\" MaxLength=\"8\" onkeypress=\"return gridnotchar();\" />";
                    divstr += "</td>";
                    
                divstr += "</tr>";
            }
        }
        divstr += "</table>";
    }
    
    document.getElementById('tdgrid').innerHTML = divstr;
    
    return false;
}
function chkflramount()
{
var num=document.getElementById('txtflramount').value;
var tomatch=/^\d*(\.\d{1,5})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtflramount').value="";
document.getElementById('txtflramount').focus();

return false; 

}

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
function display()
{

var url =document.getElementById("hiddenurl").value;
var pas="";
var abc="";
var respass=Ratemaster.getpass(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value)
    var ds=respass.value;
    
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            pas=ds.Tables[0].Rows[0].PASSWORD;
        }
    }

window.open(url+"?password="+pas+"&type=ratemaster&qbc="+document.getElementById('hiddenbranch').value+"&center="+document.getElementById('hiddenCenter').value+"&username="+document.getElementById('hiddenuserid').value+"&refid="+document.getElementById("hiddenrateuniqid").value);
/*document.getElementById("drpAdon").style.display = 'block';
document.getElementById("txtref").style.display = 'block';
document.getElementById("lbAdon").style.display = 'block';
document.getElementById("lbref").style.display = 'block';*/
return false;
}

function openratemast()
{
//======******To open  TV rate master***********=======//
   var page;
   var abc=""; 
   var url="ratemaster.aspx"       
            var browser=navigator.appName;
            //alert(browser);
            var  httpRequest =null;
            if(browser!="Microsoft Internet Explorer")
            {
                //alert("test");
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","loginsession.aspx?username="+document.getElementById('hdnusername').value+"&password="+document.getElementById('hdnpassword').value+"&qbc="+abc+"&agency_name="+abc+"&center="+document.getElementById('hdncenter').value+"&centername="+abc, false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
//                    if (httpRequest.status == 200) 
//                    {
//                        var flag=httpRequest.responseText;   
//                        if(flag=="0")
//                        {
//                            alert("Invalid User Name or Password" );
//                            return false;
//                        }
//                        else
//                        {
//                          login.saveLoginInfo(ip);
                            window.open(url+"?refid="+(document.getElementById("hdnrefid").value));
//                        }
//                    }
//                    else 
//                    {
//                        alert('There was a problem with the request.');
//                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
               // xml.Open( "GET","loginsession.aspx?username="+document.getElementById('hiddenusername').value+"&password="+document.getElementById('hiddenbranch').value+"&qbc="+qbc+"&agency_name="+agency_name+"&center="+document.getElementById('hiddenbranch').value+"&centername="+document.getElementById('hiddenbranch').value, false );
               xml.open( "GET","loginsession.aspx?username="+document.getElementById('hdnusername').value+"&password="+document.getElementById('hdnpassword').value+"&qbc="+abc+"&agency_name="+abc+"&center="+document.getElementById('hdncenter').value+"&centername="+abc, false );
                xml.Send();
                var flag=xml.responseText;
//                if(flag=="0")
//                {
//                    alert("Invalid User Name or Password" );
//                    return false;
//                }
//                else
//                { 
                    window.location.href(url+"?refid="+(document.getElementById("hdnrefid").value));
//                }
        }
//window.open(url+"?password="+pas+"&type=ratemaster&qbc="+document.getElementById('hiddenbranch').value+"&center="+document.getElementById('hiddenCenter').value+"&username="+document.getElementById('hiddenuserid').value+"&refid="+document.getElementById("hiddenrateuniqid").value);
/*document.getElementById("drpAdon").style.display = 'block';
document.getElementById("txtref").style.display = 'block';
document.getElementById("lbAdon").style.display = 'block';
document.getElementById("lbref").style.display = 'block';*/
return false;
}
 
 
 function ratecodef2(event) {
   
   if(event.keyCode==113)
   {
  
  
//            if (document.getElementById('txtratecode').value.length <= 2) {
//                alert("Please Enter Minimum 3 Character For Searching.");
//                document.getElementById('txtclient').value = "";
//                return false;
//            }
            colName = "";
            document.getElementById("divratecode").style.display = "block";
            aTag = eval(document.getElementById("txtratecode"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divratecode').style.top = document.getElementById("txtratecode").offsetTop + toppos + "px";
            document.getElementById('divratecode').style.left = document.getElementById("txtratecode").offsetLeft + leftpos + "px";
            Ratemaster.bindbookingid(document.getElementById('hiddencompcode').value, document.getElementById('txtratecode').value.toUpperCase(), bindbookingid_callback);
   
   
   
   
   


 }

        

    }


    function bindbookingid_callback(response) {
        ds = response.value;
        //document.getElementById('drpretainer').value="";
        var pkgitem = document.getElementById("lstratecode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Rate Code-", "0");
        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            pkgitem.options.length = 1;
            //alert(pkgitem.options.length);
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].RATE_MAST_CODE, ds.Tables[0].Rows[i].RATE_MAST_CODE);
                pkgitem.options.length;
            }
        }

        // document.getElementById("lstratecode").value = "0";
    
        return false;
    }
    
    
    
    function onclicratecode(event) {

        if (event.keyCode == 13 || event.type == "click") {




            if (document.activeElement.id == "lstratecode") {
                if (document.getElementById('lstratecode').value == "0")
                {
                    alert("Please select the Rate Code");
                    return false;
                }
                document.getElementById("divratecode").style.display = "none";
                var datetime = "";
                //alert(document.getElementById('lstagency').value);

                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

                var page = document.getElementById('lstratecode').value;
                // document.getElementById('hiddenagency').value=page;
                agencycodeglo = page;
                 for (var k = 0; k <= document.getElementById("lstratecode").length - 1; k++) {
                     if (document.getElementById('lstratecode').options[k].value == page) {
                         if (browser != "Microsoft Internet Explorer") {
                             var abc = document.getElementById('lstratecode').options[k].textContent;
                         }
                         else {
                             var abc = document.getElementById('lstratecode').options[k].innerText;
                         }

                         var split = abc.split("+");
                         var nameagen = split[0];
                         var agencycode = split[1];
//                         var agencycode = nameagen.split("(");
//                         agencycode = agencycode[1].replace(")", "");
                         document.getElementById('txtratecode').value = nameagen;
//                         document.getElementById('hiddenagency').value = agenadd;
                         
                         document.getElementById('txtratecode').focus();
                         return false;
                     }
                }
            }
        }

        if (event.keyCode == 27) {
            document.getElementById("divratecode").style.display = "none";
            document.getElementById('txtratecode').focus();
        }
    }

    
    function blank(event) {


        if (event.keyCode == 8 || event.keycode == 46) {
            if (document.activeElement.id == "txtvalidfrom") {

                document.getElementById('txtvalidfrom').value="";
                return false;
            }
        }
        return false;


    }


    function blank1(event) {


        if (event.keyCode == 8 || event.keycode == 46) {
            if (document.activeElement.id == "txtvalidto") {

                document.getElementById('txtvalidto').value = "";
                return false;
            }
        }
        return false;


    }


    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }


    //--------------------------------

    function hide_edition() {
        if (document.getElementById('drpadtype').value == 'EL0') {
            document.getElementById('lbedto').innerHTML = 'Programs[F2]';
            document.getElementById('lbedto').className = 'TextField';
            document.getElementById('txtedto').value = "";
            document.getElementById('hdnedto').value = "";

            document.getElementById('lbedfrom').innerHTML = 'BTB[F2]';
            document.getElementById('lbedfrom').className = 'TextField';
            document.getElementById('txtedfrom').value = "";
            document.getElementById('hdnedfrom').value = "";

        }
        if (document.getElementById('drpadtype').value != 'EL0') {
            document.getElementById('lbedto').innerHTML = 'Edition To';
            document.getElementById('lbedto').className = 'TextField';
            document.getElementById('txtedto').value = "";
            document.getElementById('hdnedto').value = "";

            document.getElementById('lbedfrom').innerHTML = 'Edition From';
            document.getElementById('lbedfrom').className = 'TextField';
            document.getElementById('txtedfrom').value = "";
            document.getElementById('hdnedfrom').value = "";

        }
    }

    //----------------------------bind BTB---------


    function bindbtb(event) {
        if (document.getElementById('drpadtype').value == 'EL0' && document.getElementById('lbedfrom').innerText.indexOf("BTB") >= 0) {
            var key = event.keyCode ? event.keyCode : event.which;
            if (key == 8 || (event.ctrlKey == true && key == 88) || (key == 46)) {
                if (key != 113) {
                    document.getElementById('txtedfrom').value = "";
                    document.getElementById('hdnedfrom').value = "";
                    // ClientDocCode="";
                }
            }
            if (key == 113) {
                var compcode = document.getElementById('hiddencompcode').value;
                var btbdesc = document.getElementById('txtedfrom').value;
                var extra = "";
                document.getElementById("divbtb").style.display = "block";
                //        document.getElementById('divbtb').style.top=270+ "px" ;
                //        document.getElementById('divbtb').style.left=345+ "px";
                aTag = eval(document.getElementById(document.activeElement.id))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                //         var tot = document.getElementById('divbtb').scrollLeft;
                //         var scrolltop = document.getElementById('divbtb').scrollTop;
                document.getElementById('divbtb').style.left = document.getElementById(document.activeElement.id).offsetLeft + leftpos + "px";
                document.getElementById('divbtb').style.top = document.getElementById(document.activeElement.id).offsetTop + toppos + 16 + "px"; //"510px";

                var extra1 = "";
                Ratemaster.fillF2btb(compcode, btbdesc, extra, bindcredit_callback);
            }
        }
    }
    function bindcredit_callback(res) {
        var ds_AccName = res.value;

        if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
            var pkgitem = document.getElementById("lstbtb");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select Btb Name-", "0");
            pkgitem.options.length = 1;
            for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].BTB_DESC, ds_AccName.Tables[0].Rows[i].BTB_CODE);
                pkgitem.options.length;
            }
        }
        document.getElementById("lstbtb").value = "0";
        document.getElementById("divbtb").value = "";
        document.getElementById("lstbtb").focus();

        return true;
    }


    function Clickcbbtb1(event) {

        var key = event.keyCode ? event.keyCode : event.which;
        if (key == 13 || event.type == "click") {
            if (document.activeElement.id == "lstbtb") {
                if (document.getElementById('lstbtb').value == "0") {
                    alert("Please select Btb Name");
                    return true;
                }

                var page_new = document.getElementById('lstbtb').value;
                repcode = page_new;
                for (var k = 0; k <= document.getElementById('lstbtb').length - 1; k++) {
                    if (document.getElementById('lstbtb').options[k].value == page_new) {
                        if (browser == "Microsoft Internet Explorer") {
                            var abc = document.getElementById('lstbtb').options[k].innerText;
                        }
                        else {
                            var abc = document.getElementById('lstbtb').options[k].textContent;
                        }
                        document.getElementById('lstbtb').value = repcode;
                        document.getElementById('hdnedfrom').value = document.getElementById('lstbtb').value;
                        document.getElementById('txtedfrom').value = abc;
                        document.getElementById('txtedfrom').focus();
                        document.getElementById("divbtb").style.display = "none";
                        break;
                    }
                }
            }
            return false;
        }
        else if (key == 27) {
            document.getElementById("divbtb").style.display = "none";
            document.getElementById('txtedfrom').focus();
            return false;
        }
        //return false;
    }

    function get_btbname(id) {

        var btbname;
        var compcode = document.getElementById('hiddencompcode').value;
        if (compcode != null && id != null) {

            var res = Ratemaster.get_btbname(compcode, id);
            var ds = res.value;
            if (ds != null && ds.Tables[0].Rows.length > 0) {
                btbname = ds.Tables[0].Rows[0].REASON;
            }
            return btbname;
        }
        else {
            btbname = "";
            return btbname;
        }
    }

    //---------------------bind programs---------------------


    function bindprog(event) {
        if (document.getElementById('drpadtype').value == 'EL0' && document.getElementById('lbedto').innerText.indexOf("Program") >= 0) {
            var key = event.keyCode ? event.keyCode : event.which;
            if (key == 8 || (event.ctrlKey == true && key == 88) || (key == 46)) {
                if (key != 113) {
                    document.getElementById('txtedto').value = "";
                    document.getElementById('hdnedto').value = "";
                    // ClientDocCode="";
                }
            }
            if (key == 113) {
                var compcode = document.getElementById('hiddencompcode').value;
                var extra1 = "";
                var extra2 = "";
                var extra3 = "";
                var extra4 = "";
                var extra5 = "";
                document.getElementById("divprog").style.display = "block";
                //        document.getElementById('divbtb').style.top=270+ "px" ;
                //        document.getElementById('divbtb').style.left=345+ "px";
                aTag = eval(document.getElementById(document.activeElement.id))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                //         var tot = document.getElementById('divbtb').scrollLeft;
                //         var scrolltop = document.getElementById('divbtb').scrollTop;
                document.getElementById('divprog').style.left = document.getElementById(document.activeElement.id).offsetLeft + leftpos + "px";
                document.getElementById('divprog').style.top = document.getElementById(document.activeElement.id).offsetTop + toppos + 16 + "px"; //"510px";

                var extra1 = "";
                Ratemaster.fillprogram(compcode, extra1, extra2, extra3, extra4, extra5, bindprog_callback);
            }
        }
    }
    function bindprog_callback(res) {
        var ds_AccName = res.value;

        if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
            var pkgitem = document.getElementById("lstprog");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select Program Name-", "0");
            pkgitem.options.length = 1;
            for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].SHORT_NAME, ds_AccName.Tables[0].Rows[i].PRG_ID);
                pkgitem.options.length;
            }
        }
        document.getElementById("lstprog").value = "0";
        document.getElementById("divprog").value = "";
        document.getElementById("lstprog").focus();

        return true;
    }


    function Clickprog(event) {

        var key = event.keyCode ? event.keyCode : event.which;
        if (key == 13 || event.type == "click") {
            if (document.activeElement.id == "lstprog") {
                if (document.getElementById('lstprog').value == "0") {
                    alert("Please select Program.");
                    return true;
                }

                var page_new = document.getElementById('lstprog').value;
                repcode = page_new;
                for (var k = 0; k <= document.getElementById('lstprog').length - 1; k++) {
                    if (document.getElementById('lstprog').options[k].value == page_new) {
                        if (browser == "Microsoft Internet Explorer") {
                            var abc = document.getElementById('lstprog').options[k].innerText;
                        }
                        else {
                            var abc = document.getElementById('lstprog').options[k].textContent;
                        }
                        document.getElementById('lstprog').value = repcode;
                        document.getElementById('hdnedto').value = document.getElementById('lstprog').value;
                        document.getElementById('txtedto').value = abc;
                        document.getElementById('txtedto').focus();
                        document.getElementById("divprog").style.display = "none";
                        break;
                    }
                }
            }
            return false;
        }
        else if (key == 27) {
            document.getElementById("divprog").style.display = "none";
            document.getElementById('txtedto').focus();
            return false;
        }
        //return false;
    }



    function get_progname(id) {

        var progname;
        var compcode = document.getElementById('hiddencompcode').value;
        if (compcode != null && id != null) {

            var res = Ratemaster.get_progname(compcode, id);
            var ds = res.value;
            if (ds != null && ds.Tables[0].Rows.length > 0) {
                progname = ds.Tables[0].Rows[0].REASON;
            }
            return progname;
        }
        else {
            progname = "";
            return progname;
        }
    }

    
    
    