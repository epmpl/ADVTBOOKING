// JScript File

function parentclild()
{

//document.getElementById('parent').style.display="block";
Default2.parent(callparent);
return false;
}

function callparent(res)
{
var ds=res.value;
var generate="";
var parentname="";
var newparent=""
for(var i=0;i<=ds.Tables[0].Rows.length-1;i++)
{
var tdname="td"+i;
    //parentname="<tr><td id=\"td"+i+"\"><input type=\"Label\" id="+ds.Tables[0].Rows[i].Agency_Code+" value="+ds.Tables[0].Rows[i].Agency_Name+" OnClick=\"javascript:return openchild('"+ds.Tables[0].Rows[i].Agency_Code+"','"+tdname+"');\"></td><td></td></tr>";
   parentname="<li id=\"td"+i+"\"><input type=\"Label\" id="+ds.Tables[0].Rows[i].Agency_Code+" value="+ds.Tables[0].Rows[i].Agency_Name+" OnClick=\"javascript:return openchild('"+ds.Tables[0].Rows[i].Agency_Code+"','"+tdname+"');\"></Li>"
    
     newparent=parentname+newparent;
}
generate="<table>"+newparent+"</table>";
//document.getElementById('parent').style.display="block";

document.getElementById('parent').innerHTML=generate;
//alert(document.getElementById('parent').innerHTML);

return false;
}
var idpar;
function openchild(a,id)
{
idpar=id;
Default2.child(a,callchild);


return false;
}

function callchild(res)
{
var ds=res.value;
var generate="";
var parentname="";
var newparent=""
for(var i=0;i<=ds.Tables[0].Rows.length-1;i++)
{

    parentname="<Ui><input type=\"Label\" id="+ds.Tables[0].Rows[i].SUB_Agency_Code+" value='"+ds.Tables[0].Rows[i].Agency_Name+" '></Ui>";
    
    
     newparent=parentname+newparent;
}
//generate="<Ui>"+newparent+"</Ui>";
//document.getElementById('parent').style.display="block";
//alert(document.getElementById(childdiv));
document.getElementById(idpar).innerHTML=newparent;

return false;
}