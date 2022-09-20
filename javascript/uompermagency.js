// JScript File
var chk123="";
var modify="0";
var cate;
var uom;
var code10;
function filladcat()
{
var comcode=document.getElementById('hiddencomcode').value;
	var adtype=document.getElementById('drpadtype').value;
	var center="";
	uompermagency.adcat(comcode,adtype,center,callcount);
	return false;
}

function callcount(res)
{
	var ds=res.value;
	
	var pkgitem = document.getElementById("drpcat");
	if(ds.Tables[0].Rows.length==0)
	{
	 pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Category--","0");
    alert("Matching Value Not Found");

  	document.getElementById('drpuom').focus();
	return false;
	}
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Category--","0");
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Adv_Cat_Name,res.value.Tables[0].Rows[i].Adv_Cat_Code);
       pkgitem.options.length;
    }
    
    //alert(city);
    if(cate == undefined || cate=="")
 {
  document.getElementById('drpcat').value="0";
 
 }
 else
 {
  document.getElementById('drpcat').value=cate;
  cate="";
}
filluom();
}

function submitdata()
{           if(document.getElementById('drpadtype').value=="0")
			{
			alert("Please Enter the Adtype ");
			document.getElementById('drpadtype').focus();
			return false;
			}
            else if(document.getElementById('drpcat').value=="0")
			{
			alert("Please Enter the Category");
			document.getElementById('drpcat').focus();
			return false;
			}
			else if(document.getElementById('drpuom').value=="0")
			{
			alert("Please Enter the Uom name");
			document.getElementById('drpuom').focus();
			return false;
			}

			var adtype=document.getElementById('drpadtype').value;
			var category=document.getElementById('drpcat').value;
			var uom=document.getElementById('drpuom').value;
		    var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var agencode=document.getElementById('hiddenagencycode').value;
			var subagncode=document.getElementById('hiddenagensubcode').value;
			
			document.getElementById('hiddenuom').value=uom;
			document.getElementById('hiddencate').value=category;
			document.getElementById('hiddenadtyp').value=adtype;

			if(opener.document.getElementById('hiddensaurabh').value!="modify")
			{
			    uompermagency.insert(compcode, userid, uom, category, adtype, agencode, subagncode, "")
			    window.location = window.location;
			    return false;
				}
             else
			    {
			        if (document.getElementById('hiddenseq').value == "")//opener.document.getElementById('hiddenchk').value
                   {
                   
                    uompermagency.insert(compcode, userid, uom, category, adtype, agencode, subagncode, "")
                    window.location = window.location;
                    return false;
			       }  
			       else
			       {
                    var seq=document.getElementById('hiddenseq').value;
			        uompermagency.update(compcode, userid, uom, category, adtype, agencode, subagncode, seq)
 				    window.location=window.location;
 				    return false;
			       }  

			    }
 
			        

			   
	return false;
}

function selected(ab)
	{
	var id=ab;
	//alert('id');
	if(document.getElementById(id).checked==false)
        {
            cleardata();
            return ;
        }
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var agencode=document.getElementById('hiddenagencycode').value;
			var subagncode=document.getElementById('hiddenagensubcode').value;
			var datagrid=document.getElementById('DataGrid1');
			var j;
			var k=0;
		
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
				
					var str="DataGrid1__ctl_CheckBox1"+j;
					//alert(str);
					document.getElementById(str).checked=false;
                    document.getElementById(id).checked=true;
                    if(id==str)
                    {		
                    //alert(id);
						if(document.getElementById(id).checked==true)
						{
							k=k+1;
							code10=document.getElementById(id).value;
							chk123=document.getElementById(id);
						}
				    }
				}
		if(k==1)
			{
					document.getElementById('btndelete').disabled=false;
					uompermagency.bandcontact(compcode,userid,agencode,subagncode,code10,call_select);
					return false;
			}
		else if(k==0)
	    {
		
					document.getElementById('drpadtype').value="0";
			document.getElementById('drpcat').value="0";
		    document.getElementById('drpuom').value="0";
				return false;
				}
		return false;
}


function call_select(res)
{
var ds= res.value;
chk123.checked=true;

var y=ds.Tables[0].Rows.length;
var z=0;
var j;
var t;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	t=j;
	t++;
	t++;
	var str="DataGrid1__ctl_CheckBox1"+t;
	
	var chk=str;
	chk=true;
	if(chk==true)
	{
	z=j;
	
	}
	
	}
    if(z.length > 1)
	{
	return false;
	}

           document.getElementById('drpadtype').value = ds.Tables[0].Rows[0].adtype;

			//document.getElementById('drpcat').value=ds.Tables[0].Rows[0].category;
			document.getElementById('drpuom').value=ds.Tables[0].Rows[0].uom_name;

			filladcat();
			cate=ds.Tables[0].Rows[0].category;
			document.getElementById('hiddenseq').value=ds.Tables[0].Rows[0].seq_no;

			if (document.getElementById('hiddensaurabh').value == "0") {
            document.getElementById('btnsubmit').disabled = true;
            document.getElementById('btndelete').disabled = true;
            document.getElementById('drpuom').disabled = true;
            document.getElementById('drpcat').disabled = true;
            document.getElementById('drpadtype').disabled = true;
            
}

return false;
}


function cleardata()
{
			document.getElementById('drpadtype').value="0";
			document.getElementById('drpcat').value="0";
			document.getElementById('drpuom').value = "0";
			document.getElementById('hiddenseq').value = "";
			chk123.checked=false;
return false;
}

function closewindow()
{
			window.close();
			return false;
return false;
}



function deleted() {

    var compcode = document.getElementById('hiddencomcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var agencode = document.getElementById('hiddenagencycode').value;
    var subagncode = document.getElementById('hiddenagensubcode').value;
    var codebk = document.getElementById('hiddenseq').value;
    
    var datagrid = document.getElementById('DataGrid1')

    var j;
    var k = 0;
    //var DataGrid1__ctl_CheckBox1= new Array();
    var i = document.getElementById("DataGrid1").rows.length - 1;

    for (j = 0; j < i; j++) {
        var str = "DataGrid1__ctl_CheckBox1" + j;
        //alert(str);
        //	alert(document.getElementById(str));

        if (document.getElementById(str).checked == true) {
            k = k + 1;

        }
    }
    if (k == 1) {
        //var hiddendelete=document.getElementById('hiddendelete').value; 
        boolReturn = confirm("Are you sure you wish to delete this?");
        if (boolReturn == 1) {
            uompermagency.dele(compcode, userid, codebk);
        }
        else {
            return false;
        }
        alert("Data Deleted Successfully");
        document.getElementById('btndelete').disabled = true;
        window.location = window.location;
        return false;

    }
    else {
        alert("You Should Select One Row");
        return false;
    }
    return false;

}

function filluom() {
    var comcode = document.getElementById('hiddencomcode').value;
    var adtype = document.getElementById('drpadtype').value;
    var center = "";
    uompermagency.binduomdrop(comcode, adtype, center,returnuom);
    return false;
}
function returnuom(res) {
    var ds = res.value;

    var pkgitem = document.getElementById("drpuom");
    if (ds.Tables[0].Rows.length == 0) {
        pkgitem.options.length = 1;
        pkgitem.options[0] = new Option("--Select UOM--", "0");
        //alert("Matching Value Not Found");

        document.getElementById('drpuom').focus();
        return false;
    }
    pkgitem.options.length = 1;
    pkgitem.options[0] = new Option("--Select UOM--", "0");
    for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Uom_Name, res.value.Tables[0].Rows[i].Uom_Code);
        pkgitem.options.length;
    }

    //alert(city);
    if (uom == undefined || uom == "") {
        document.getElementById('drpuom').value = "0";

    }
    else {
        document.getElementById('drpuom').value = uom;
        uom = "";
    }
    
}