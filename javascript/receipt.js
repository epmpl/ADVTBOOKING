// JScript File
function filldata()
{
    var custid=window.opener.document.getElementById('txtclient');
    //alert(custid.value);
    
    document.getElementById('tdnpwp').innerHTML=""
    
    var currdate=new Date();
    var date=currdate.getDate();
    var month=currdate.getMonth()+1;
    var year=currdate.getFullYear();
    document.getElementById('tdorddate').innerHTML=month+"/"+date+"/"+year;
    
    if(custid.value.indexOf('(')>0)
    {
        var custidname=custid.value.split('(');
        var custiddata=custidname[1].replace(')','');
        document.getElementById('tdcustid').innerHTML=custiddata;
        document.getElementById('tdcustname').innerHTML=custidname[0];
    }
    else
    {
        document.getElementById('tdcustname').innerHTML=custid.value;
    }
    document.getElementById('tdcustadd').innerHTML=window.opener.document.getElementById('txtclientadd').value;
    document.getElementById('tdciobookid').innerHTML=": "+window.opener.document.getElementById('txtciobookid').value;
    
    document.getElementById('tdadtitle').innerHTML=": "+"";
    
    var adtype=window.opener.document.getElementById('drpadtype');
    adtype=adtype.options[adtype.selectedIndex].text;
    document.getElementById('tdadtype').innerHTML=": "+adtype;//
    document.getElementById('tdrono').innerHTML=window.opener.document.getElementById('txtrono').value;
    
    
    document.getElementById('tdrodate').innerHTML=window.opener.document.getElementById('txtrodate').value;
    
    var uom=window.opener.document.getElementById('drpuom');
    uom=uom.options[uom.selectedIndex].text;
    document.getElementById('tduom').innerHTML=": "+uom;
    
    
    var objpack=window.opener.document.getElementById('drppackagecopy');
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
    document.getElementById('tdedition').innerHTML=": "+desc;
    
    document.getElementById('tdcardrate').innerHTML=": "+window.opener.document.getElementById('txtcardrate').value;
    
    document.getElementById('tdinsertion').innerHTML=": "+window.opener.document.getElementById('txtinsertion').value;
    
    document.getElementById('tdgrossamt').innerHTML=window.opener.document.getElementById('txtgrossamt').value;
    
    document.getElementById('tddiscrate').innerHTML=window.opener.document.getElementById('disrat0').value;
    
    var material=window.opener.document.getElementById('drpmatstat');
    material=material.options[material.selectedIndex].text;
    document.getElementById('tdmatstat').innerHTML="Material via "+material;
       document.getElementById('tdmatter').innerHTML=document.getElementById('hiddenmatter').value;
  /*  if(document.getElementById('hiddenlogo').value=="")
    {
        
        document.getElementById('tdmatter').innerHTML=document.getElementById('hiddenmatter').value;
    }
    else
    {
        //var logoname=document.getElementById('hiddenlogo').value;
        //document.getElementById('tdmatter').innerHTML="<img  align='left'  style='float:left;width=162.11;height=94.25;' src='temp logo/"+logoname+"' / > <br />"+document.getElementById('hiddenmatter').value;
          document.getElementById('tdmatter').innerHTML=document.getElementById('hiddenmatter').value;
    }
    
    */
    var grossamt=parseFloat(document.getElementById('tdgrossamt').innerHTML);
    var discrate=parseFloat(document.getElementById('tddiscrate').innerHTML);
    document.getElementById('tdtotal').innerHTML=grossamt-discrate;
    
    var vatper=document.getElementById('hiddenvat').value;
    var vatamt=parseFloat(document.getElementById('tdtotal').innerHTML)*parseFloat(vatper)/100;
    document.getElementById('tdlbvat').innerHTML="VAT "+vatper+"%";
    document.getElementById('tdvatamt').innerHTML=vatamt;
    
    var totalamt=parseFloat(document.getElementById('tdtotal').innerHTML);
    var surchar=parseFloat(document.getElementById('tdsurcharge').innerHTML); 
    var fnltotal=totalamt+surchar+vatamt;
    document.getElementById('tdfnltotal').innerHTML=fnltotal;
    
    if(window.opener.document.getElementById('txtadsize1').disabled!=false)
    {
        document.getElementById('tdlbsize').innerHTML="Lines";
        document.getElementById('tdsize').innerHTML=": "+window.opener.document.getElementById('txttotalarea').value;
    }
    else
    {
        document.getElementById('tdsize').innerHTML=": "+window.opener.document.getElementById('txtadsize1').value;
        document.getElementById('tdsize').innerHTML+= " * " + window.opener.document.getElementById('txtadsize2').value;
    }
    
    document.getElementById('tdstartwith').innerHTML="";
    var insertion=parseInt(window.opener.document.getElementById('txtinsertion').value)
    var tblrows=parseInt(window.opener.document.getElementById("bookdiv").getElementsByTagName('table')[0].rows.length)-1;
    var value=tblrows/insertion;
    for(var i=0;i<insertion;)
    {
        document.getElementById('tdstartwith').innerHTML+=window.opener.document.getElementById('Text'+i).value+", ";
        i=i+value;
    }
    
    var amtwords=toWords(document.getElementById('tdfnltotal').innerHTML);
    amtwords=amtwords.toUpperCase();
    document.getElementById('tdamtwords').innerHTML='"'+amtwords+'"';
    
    return false;//
}
