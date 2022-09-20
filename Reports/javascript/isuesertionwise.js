
function bindedtn()
{
var compcode=document.getElementById('hiddencompcode').value;
var publcod=document.getElementById('dppub1').value
var dateformat=document.getElementById('hiddendateformat').value
var extra1="";
var extra2="";
Reports_insertionwiserepo.bindedtn(compcode,publcod,dateformat,extra1,extra2,bindedtion)
}

function bindedtion(res)
{
var ds=res.value;
       
    var edition=document.getElementById('ddledtn');
    edition.options.length=0;
    edition.options[0]=new Option("-Select Edition-");
    document.getElementById("ddledtn").options.length = 1;
   
   if(ds!=null && ds.Tables.length>0)
   {
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias,ds.Tables[0].Rows[i].edition_code);
                edition.options.length;    
             }
    }      
 
       return false
}