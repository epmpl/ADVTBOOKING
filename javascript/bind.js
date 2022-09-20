

function hello(a)
{


 eval(a).BindDataGrid(call_res);

return false;
}
function call_res(res)
{
var ds=res.value;
//alert(document.getElementById("divGrid"));

alert(ds);
document.getElementById("divGrid").innerHTML = ds;
return false;
}

function giveboxdet()
		{
		//alert(document.getElementById('box01').checked);
		if(document.getElementById('box01').checked==true)
		{
		document.getElementById('box01').checked=true;
		document.getElementById('boxdetail').style.display="block";
		//return false;
		}
		else if(document.getElementById('box01').checked==false)
		{
		document.getElementById('boxdetail').style.display="none";
		}
		return false;
		
		}
		
		function retainer(a)
		{
		//document.getElementById('retdet').style.display="block";
		
		for(var i=1; i<=6; i++)
		{
			var pnlid="details"+i;
			if(i==a)
			{
				document.getElementById(pnlid).style.display="block";
			}
			else
			{
				document.getElementById(pnlid).style.display="none";
			}
		}
		
		document.getElementById('pay').style.display="none"
		return false;
		}
		function detail()
		{
		document.getElementById('pay').style.display="block"
		return false;
		}