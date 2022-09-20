//this flag is for permission
var flag="";
var z=0;
var pubcode="";
var forupdate;
var codepub="";
var total="";
var dsexecombin="";
var valofchkbox="";
var hiddentext=""
var gettotaledi="";
var gsplit="";
var global_ds;
var flag2="0";

var gediname;
var gsun;
var gmon;
var gtue;
var gwed;
var gthu;
var gfri;
var gsat;
var gfocus;
var gallday;

var btnsubmitclk=0;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

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
    cancelclick('CombinationMaster');

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


// for any day check

function anydaychk(columncheck,rownum,checkId)
{
var len="uniquename"+rownum;
var y=0;
//////	if(document.getElementById(len).getElementsByTagName('table').length>0)
//////         y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;

if(document.getElementById(checkId).checked==true || document.getElementById(checkId).disabled==true)
    {
	    for(var w=0;w<y-1;w++)
	    {
	    var stra1 = parseInt(rownum,10)+parseInt(columncheck,10) + parseInt(w,10);
	    document.getElementById(stra1).checked=true;
	    }
    }
    
  else
	 {
	    for(var w=0;w<y-1;w++)
	    {
	        var stra1 = parseInt(rownum,10)+parseInt(columncheck,10) + parseInt(w,10);
	        if( document.getElementById(stra1).disabled==false)
	        {
	         document.getElementById(stra1).checked=false;
	        }
	     }
	  }
	  
}



// this show or hise the child grid


function focusdaychk(columncheck,rownum,checkId)
{
var len="uniquename"+rownum;
var y=0;
////if(document.getElementById(len).getElementsByTagName('table').length>0)
//// y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
if(document.getElementById(checkId).checked==true || document.getElementById(checkId).disabled==true)
    {
	    for(var w=0;w<y-1;w++)
	    {
	    var stra1 = parseInt(rownum,10)+parseInt(columncheck,10) + parseInt(w,10);
	    document.getElementById(stra1).checked=true;
	    }
    }
    
  else
	 {
	    for(var w=0;w<y-1;w++)
	    {
	        var stra1 = parseInt(rownum,10)+parseInt(columncheck,10) + parseInt(w,10);
	        if( document.getElementById(stra1).disabled==false)
	        {
	         document.getElementById(stra1).checked=false;
	        }
	     }
	  }
}

function columncheck(columncheck,rownum,checkId)
{

//alert(columncheck);
//alert(rownum);

	var len="uniquename"+rownum;
	//alert(len);
	//alert(document.getElementById(len).getElementsByTagName('table')[0].rows.length);
	var y=0;
//	if(document.getElementById(len).getElementsByTagName('table').length>0)
//	{
//         y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
//    }     

    if(document.getElementById(checkId).checked==true || document.getElementById(checkId).disabled==true)
    {
	    for(var w=0;w<y-1;w++)
	    {
	        var stra1 = parseInt(rownum,10)+parseInt(columncheck,10) + parseInt(w,10);
	        if(document.getElementById(stra1).disabled==false)
	        {
	            document.getElementById(stra1).checked=true;
	        }
	        
	        if((document.getElementById(stra1).checked==true || document.getElementById(stra1).disabled==true) && (document.getElementById(rownum+ "1a" +w).checked==true || document.getElementById(rownum+ "1a" +w).disabled==true) && (document.getElementById(rownum+ "1b" +w).checked==true || document.getElementById(rownum+ "1b" +w).disabled==true) && (document.getElementById(rownum+ "1c" +w).checked==true || document.getElementById(rownum+ "1c" +w).disabled==true) && (document.getElementById(rownum+ "1d" +w).checked==true || document.getElementById(rownum+ "1d" +w).disabled==true ) && (document.getElementById(rownum+ "1e" +w).checked==true || document.getElementById(rownum+ "1e" +w).disabled==true) && (document.getElementById(rownum+ "1f" +w).checked==true || document.getElementById(rownum+ "1f" +w).disabled==true) )
                {
                document.getElementById(rownum+ "1k" +w).checked=true;
                }
                else
                {
                document.getElementById(rownum+ "1k" +w).checked=false;
                }
                
                
           
	    }
	    
	     if((document.getElementById("DataGrid1__ctl_CheckBox"+"1" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1" + rownum).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1a" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1a" + rownum).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1b" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1b" + rownum).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1c" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1c" + rownum).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1d" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1d" + rownum).disabled==true ) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1e" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1e" + rownum).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1f" + rownum).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1f" + rownum).disabled==true) )
                {
                document.getElementById("DataGrid1__ctl_CheckBox"+"1k" + rownum).checked=true;
                }
                else
                {
                document.getElementById("DataGrid1__ctl_CheckBox"+"1k" + rownum).checked=false;
                }
	 }   
	 else
	 {
	    for(var w=0;w<y-1;w++)
	    {
	        var stra1 = parseInt(rownum,10)+parseInt(columncheck,10) + parseInt(w,10);
	        if( document.getElementById(stra1).disabled==false)
	        {
	        document.getElementById(stra1).checked=false;
	        document.getElementById(rownum+"1k" + w).checked=false;
	        }
	    }  
	    
	    //DataGrid1__ctl_CheckBox 
	    document.getElementById("DataGrid1__ctl_CheckBox"+"1k" + rownum).checked=false;
	 }
}



function unchk (idstr,val,j)
{


	var len="uniquename"+j;
	var str="DataGrid1__ctl_CheckBox"+val+ j;
    var y=0;//////document.getElementById(len).getElementsByTagName('table')[0].rows.length;
	var chk_box=0;
for(var w=0;w<y-1;w++)
	    {
	    var stra1=parseInt(j,10)+ parseInt(val,10) +parseInt(w,10);
    if(document.getElementById(stra1).disabled==false)
    {
         //var str="DataGrid1__ctl_CheckBox"+val+ j;
	         if(document.getElementById(stra1).checked==true)
	         {
	            if(chk_box==0)
	            {
	        	document.getElementById(str).checked=true;
	        	chk_box=0;
	        	   	
                }
               
                
                
                if((document.getElementById(j+ "1" +w).checked==true || document.getElementById(j+ "1" +w).disabled==true) && (document.getElementById(j+ "1a" +w).checked==true || document.getElementById(j+ "1a" +w).disabled==true) && (document.getElementById(j+ "1b" +w).checked==true || document.getElementById(j+ "1b" +w).disabled==true) && (document.getElementById(j+ "1c" +w).checked==true || document.getElementById(j+ "1c" +w).disabled==true) && (document.getElementById(j+ "1d" +w).checked==true || document.getElementById(j+ "1d" +w).disabled==true ) && (document.getElementById(j+ "1e" +w).checked==true || document.getElementById(j+ "1e" +w).disabled==true) && (document.getElementById(j+ "1f" +w).checked==true || document.getElementById(j+ "1f" +w).disabled==true) )
                {
                document.getElementById(j+ "1k" +w).checked=true;
                }
                else
                {
                document.getElementById(j+ "1k" +w).checked=false;
                }
                
                
                
                
	     }
	     else
	     {
	     chk_box=1;
	        //if(document.getElementById(str).checked==false)
	        //{
	     document.getElementById(str).checked=false;
	     document.getElementById(j+ "1k" +w).checked=false;
	        //}
	     }
	}
	    }
	    
	    if(str.indexOf("1k")>=0 && document.getElementById(str).checked==true)
                {
                var chksel= "DataGrid1__ctl_CheckBox1k" + j;
                selectall(chksel,j)
                }
                
                if((document.getElementById("DataGrid1__ctl_CheckBox"+"1" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1" + j).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1a" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1a" + j).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1b" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1b" + j).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1c" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1c" + j).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1d" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1d" + j).disabled==true ) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1e" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1e" + j).disabled==true) && (document.getElementById("DataGrid1__ctl_CheckBox"+"1f" + j).checked==true || document.getElementById("DataGrid1__ctl_CheckBox"+"1f" + j).disabled==true) )
                {
                document.getElementById("DataGrid1__ctl_CheckBox"+"1k" + j).checked=true;
                }
                else
                {
                document.getElementById("DataGrid1__ctl_CheckBox"+"1k" + j).checked=false;
                }

}


//function changeimage(b,c)
function childchangeimage(id,path,rowno)
{

//        var len="uniquename"+rowno;
//        var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;

    
    if(document.getElementById(id).src.indexOf("UnChecked")>=0)
    {
        document.getElementById(id).src=document.getElementById(id).src.replace("UnChecked","Checked");
       
        
        for(var w=0;w<y-1;w++)
	    {
	    var stra1 = rowno+ "imgtrichild"+w;
	    document.getElementById(stra1).src=document.getElementById(stra1).src.replace("UnChecked","Checked");
	     
	    }
	    
	    
    }
    else if(document.getElementById(id).src.indexOf("Checked")>=0)
    {
        document.getElementById(id).src=document.getElementById(id).src.replace("Checked","UnDefined");
         for(var w=0;w<y-1;w++)
	    {
	    var stra1 = rowno+ "imgtrichild"+w;
	    document.getElementById(stra1).src=document.getElementById(stra1).src.replace("Checked","UnDefined");
	    }
    }
    else if(document.getElementById(id).src.indexOf("UnDefined")>=0)
    {
        document.getElementById(id).src=document.getElementById(id).src.replace("UnDefined","UnChecked");
        for(var w=0;w<y-1;w++)
	    {
	    var stra1 = rowno+ "imgtrichild"+w;
	    if(document.getElementById(stra1).src.indexOf("UnDefined")>=0)
	    {
	    document.getElementById(stra1).src=document.getElementById(stra1).src.replace("UnDefined","UnChecked");
	    }
	    else
	    {
	    document.getElementById(stra1).src=document.getElementById(stra1).src.replace("Checked","UnChecked");
	    }
	    }
    }


}


//function changeimage(b,c)
function changeimage(id,path,j)
{
//alert(document.getElementById('DataGrid1').disabled);
if(document.getElementById('DataGrid1').disabled==true)
{
return false;
}
         
    if(document.getElementById(id).src.indexOf("UnChecked")>=0)
    {
        document.getElementById(id).src=document.getElementById(id).src.replace("UnChecked","UnDefined");
        var str="DataGrid1__ctl_CheckBox1k" + j;
        document.getElementById(str).checked=true;
        selectall(str,j);
     }
    else if(document.getElementById(id).src.indexOf("UnDefined")>=0)
    {
        document.getElementById(id).src=document.getElementById(id).src.replace("UnDefined","Checked");
         var str="DataGrid1__ctl_CheckBox1k" + j;
        document.getElementById(str).checked=true;
        selectall(str,j);
    }
    else if(document.getElementById(id).src.indexOf("Checked")>=0)
    {
        document.getElementById(id).src=document.getElementById(id).src.replace("Checked","UnChecked");
        //cancelgrid();
        var str="DataGrid1__ctl_CheckBox1k" + j;
        document.getElementById(str).checked=false;
        selectall(str,j);
        
    }


}


function openGrid(str,imgname)
{
    //alert("hi");hiddenplussign.Value = "0";
    if(document.getElementById('hiddenplussign').value=="1")
    {
        if(document.getElementById(imgname).src.indexOf("plus.gif",0)>=0)
        {
            document.getElementById(imgname).src=document.getElementById(imgname).src.replace("plus","minus");
            document.getElementById(str).style.display="block";
        }
        else
        {
          document.getElementById(imgname).src=document.getElementById(imgname).src.replace("minus","plus");
          document.getElementById(str).style.display="none";
          
        }
    }
      
  
}



function submitfromgrid(DataGrid1)
{
    if(document.getElementById('drpadtype').value=="0")
    {
        alert("Please Enter AdType");
        return false;
    }

    btnsubmitclk=1;

    var j,ja,js,jd,jf,jg,jh,jj,jk,jl;
    var k,x;
    var v="";
    var m="";
    var b="";
    var p="";
    var h="";
    var g="";
    var c="";
    var pp="";
    var ff="";

    var k1,x1;
    var v1="";
    var m1="";
    var b1="";
    var p1="";
    var h1="";
    var g1="";
    var c1="";
    var pp1="";
    var ff1="";


    var abc=new Array();
    var Mon=new Array();
    var tue=new Array();
    var wed=new Array();
    var thu=new Array();
    var fri=new Array();
    var sat=new Array();
    var focus=new Array();
    var anyday=new Array();

    var childabc=new Array();
    var childMon=new Array();
    var childtue=new Array();
    var childwed=new Array();
    var childthu=new Array();
    var childfri=new Array();
    var childsat=new Array();
    var childfocus=new Array();
    var childanyday=new Array();

    gediname=null;
    gsun=null;
    gmon=null;
    gtue=null;
    gwed=null;
    gthu=null;
    gfri=null;
    gsat=null;
    gfocus=null;
    gallday=null;

    gediname=new Array();
    gsun=new Array();
    gmon=new Array();
    gtue=new Array();
    gwed=new Array();
    gthu=new Array();
    gfri=new Array();
    gsat=new Array();
    gfocus=new Array();
    gallday=new Array();


    var i=document.getElementById("DataGrid1").rows.length -1;
    var arr_sun=0;
    var arr_mon=0;
    var arr_tue=0;
    var arr_wed=0;
    var arr_thu=0;
    var arr_fri=0;
    var arr_sat=0;
    var arr_any=0;
    var arr_focus=0;
    for(j=0;j<i/2;j++)
	{
	    var id1="imgtri" + j;
        if(document.getElementById(id1).src.indexOf("UnChecked")<=0)
        {
	        var str="DataGrid1__ctl_CheckBox1"+j;
	        var str1="DataGrid1__ctl_CheckBox1a" + j;
	        var str2="DataGrid1__ctl_CheckBox1b" + j;
	        var str3="DataGrid1__ctl_CheckBox1c" + j;
	        var str4="DataGrid1__ctl_CheckBox1d" + j;
	        var str5="DataGrid1__ctl_CheckBox1e" + j;
	        var str6="DataGrid1__ctl_CheckBox1f" + j;
	        var str7="DataGrid1__ctl_CheckBox1g" + j;
	        //var str8="DataGrid1__ctl_CheckBox1h" + j;
	        var str9="DataGrid1__ctl_CheckBox1k" + j;
       
            selectdays(j);
            if(document.getElementById(str).checked==true)
            {
                k=document.getElementById(str).value;
                abc[j]=k+"(SUN)";
            }
    	
            if(document.getElementById(str1).checked==true)
            {
                k=document.getElementById(str1).value;
                Mon[j]=k+"(Mon)";
            }
    	
            if(document.getElementById(str2).checked==true)
            {
                k=document.getElementById(str2).value;
                tue[j]=k+"(Tue)";
            }
    	
            if(document.getElementById(str3).checked==true)
            {
                k=document.getElementById(str3).value;
                wed[j]=k+"(Wed)";
            }
    	
            if(document.getElementById(str4).checked==true)
            {
                k=document.getElementById(str4).value;
                thu[j]=k+"(Thu)";
            }
    	
            if(document.getElementById(str5).checked==true)
            {
                k=document.getElementById(str5).value;
                fri[j]=k+"(Fri)";
            }
    	
            if(document.getElementById(str6).checked==true)
            {
                k=document.getElementById(str6).value;
                sat[j]=k+"(Sat)";
            }
    	
            if(document.getElementById(str7).checked==true)
            {
                k=document.getElementById(str7).value;
                focus[j]=k+"(FocusDay)";
            }
    	
	        /////for any day check
    	
	        if(document.getElementById(str9).checked==true)
	        {
	            k=document.getElementById(str9).value;
	            anyday[j]=k+"(AnyDay)";
	        }
    	
	        var len="uniquename"+j;
    	 var y=0;
////    	 if(document.getElementById(len).getElementsByTagName('table').length>0)
////             y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
    	
    	    for(a=0;a<y-1;a++)
	        {
                var stra = parseInt(j,10)+1 + parseInt(a,10);
                //alert(document.getElementById(stra).value)
                var stra1 = j+"1a" + a;
                var stra2 = j+"1b" + a;
                var stra3 = j+"1c" + a;
                var stra4 = j+"1d" + a;
                var stra5 = j+"1e" + a;
                var stra6 = j+"1f" + a;
                var stra7 = j+"1g" + a;
                //var stra8 = j+"1h" + a;
                var stra9 = j+"1k" + a;
                
                if((document.getElementById(stra).checked==true) &&  (document.getElementById(str).checked==false))
                {
                    k1=document.getElementById(stra).value;
                    childabc[arr_sun]=k1+"(SUN)";
                    arr_sun=parseInt(arr_sun)+1;
                }
                        	
                if((document.getElementById(stra1).checked==true) && (document.getElementById(str1).checked==false))
                {
                    k1=document.getElementById(stra1).value;
                    childMon[arr_mon]=k1+"(Mon)";
                    arr_mon=parseInt(arr_mon)+1;
                }
                                    	
                if((document.getElementById(stra2).checked==true) && (document.getElementById(str2).checked==false))
                {

                    k1=document.getElementById(stra2).value;
                    childtue[arr_tue]=k1+"(Tue)";
                    arr_tue=parseInt(arr_tue)+1;
                }
                        	
                if((document.getElementById(stra3).checked==true) &&  (document.getElementById(str3).checked==false))
                {
                    k1=document.getElementById(stra3).value;
                    childwed[arr_wed]=k1+"(Wed)";
                    arr_wed=parseInt(arr_wed)+1;
                }
                        	
                if((document.getElementById(stra4).checked==true) &&  (document.getElementById(str4).checked==false))
                {
                    k1=document.getElementById(stra4).value;
                    childthu[arr_thu]=k1+"(Thu)";
                    arr_thu=parseInt(arr_thu)+1;
                }
                        	
                if((document.getElementById(stra5).checked==true) &&  (document.getElementById(str5).checked==false))
                {
                    k1=document.getElementById(stra5).value;
                    childfri[arr_fri]=k1+"(Fri)";
                    arr_fri=parseInt(arr_fri)+1;
                }
                        	
                if((document.getElementById(stra6).checked==true) &&  (document.getElementById(str6).checked==false))
                {
                    k1=document.getElementById(stra6).value;
                    childsat[arr_sat]=k1+"(Sat)";
                    arr_sat=parseInt(arr_sat)+1;
                }
                        	
                if((document.getElementById(stra7).checked==true)  &&  (document.getElementById(str7).checked==false))
                { 
                    k1=document.getElementById(stra7).value;
                    childfocus[arr_focus]=k1+"(FocusDay)";
                    arr_focus=parseInt(arr_focus)+1;
                }
                ///////////////for any day check

                if((document.getElementById(stra9).checked==true)  &&  (document.getElementById(str9).checked==false))
                {
                    k1=document.getElementById(stra9).value;
                    childanyday[arr_any]=k1+"(AnyDay)";
                    arr_any=parseInt(arr_any)+1;
                }
            }
        }
	}
	var grid=document.getElementById("DataGrid1");
	
	
	
	
	
	var check_sun="";
	var check_mon=""; 
	var check_tue=""; 
	var check_wed=""; 
	var check_thu=""; 
	var check_fri=""; 
	var check_sat=""; 
	var check_focus=""; 
	var check_any="";  
	        for(x=0;(x<=abc.length-1)||(x==0) ;x++)
	        {
	        if(abc[x]==undefined)
	        {}
	         else
	         {
	         v=v+abc[x]+"+";
        	 check_sun=v+v1;
	         }
        	
	                for(x1=0;x1<=childabc.length-1;x1++)
	                {
        	            if(abc[x]==undefined || childabc[x1].toString().indexOf(abc[x])<0)
        	               {
        	                if(childabc[x1]==undefined)
	                        {}
	                         else
	                         {
	                         v1=v1+childabc[x1]+"+";
	                        // childabc[x1]
	                         }
            	           }
        	                
	                }
	                        if(v != "")
	                        {
	                        v1="";
	                       // check_sun=v;
	                        }
	                        else
	                        {
	                         check_sun=v1+check_sun;
	                        }
	         }
	 
	 
	 
	 for(x=0;(x<=Mon.length-1)||(x==0);x++)
	{
	if(Mon[x]==undefined)
	{}
	 else
	 {
	 m=m+Mon[x]+"+";
	 check_mon=m+m1;
	 }
	 
	 for(x1=0;x1<=childMon.length-1;x1++)
	{
	if(childMon[x1]==undefined)
	{}
	 else
	 {
	 m1=m1+childMon[x1]+"+";
	 }
	 }
	 
	 if(m!="")
	 {
	 m1="";
	 
	 }
	 else
	 {
	 check_mon=m1+check_mon;
	 }
	 }
	 
	         for(x=0;(x<=tue.length-1)||(x==0);x++)
	        {
	        if(tue[x]==undefined)
	        {}
	         else
	         {
	         b=b+tue[x]+"+";
	          check_tue=b+b1;
	         }
        	 
	         for(x1=0;x1<=childtue.length-1;x1++)
	        {
	        if(childtue[x1]==undefined)
	        {}
	         else
	         {
	         b1=b1+childtue[x1]+"+";
	         }
	         }
	                 if(b!="")
	                 {
	                 b1="";
	                
	                 }
	                 else
	                 {
	                 check_tue=b1+check_tue;
	                 }
	         }
	 
	 for(x=0;(x<=wed.length-1)||(x==0);x++)
	{
	if(wed[x]==undefined)
	{}
	 else
	 {
	 p=p+wed[x]+"+";
	 check_wed=p+p1;
	 }
	 
	 for(x1=0;x1<=childwed.length-1;x1++)
	{
	if(childwed[x1]==undefined)
	{}
	 else
	 {
	 p1=p1+childwed[x1]+"+";
	 
	 }
	 }
	 
	 if(p!="")
	 {
	 p1="";
	 
	 }
	 else
	 {
	 p1;
	 check_wed=p1+check_wed;
	 }
	 }
	 
	                     for(x=0;(x<=thu.length-1)||(x==0);x++)
	                    {
	                    if(thu[x]==undefined)
	                    {}
	                     else
	                     {
	                     h=h+thu[x]+"+";
	                      check_thu=h+h1;
	                     }
	                     for(x1=0;x1<=childthu.length-1;x1++)
	                    {
	                    if(childthu[x1]==undefined)
	                    {}
	                     else
	                     {
	                     h1=h1+childthu[x1]+"+";
	                     }
	                     }
                    	 
	                             if(h!="")
	                             {
	                             h1="";
	                            
	                             }
	                             else
	                             {
	                             h1;
	                             check_thu=h1+check_thu;
	                             }
	                     }
                    	 
	 for(x=0;(x<=fri.length-1)||(x==0);x++)
	{
	if(fri[x]==undefined)
	{}
	 else
	 {
	 g=g+fri[x]+"+";
	 check_fri=g+g1;
	 }
	 for(x1=0;x1<=childfri.length-1;x1++)
	{
	if(childfri[x1]==undefined)
	{}
	 else
	 {
	 g1=g1+childfri[x1]+"+";
	 }
	 }
	 if(g!="")
	{
	g1="";
	
	}
	else
	{
	c1;
	check_fri=g1+check_fri;
	}
	 }
	 
	         for(x=0;(x<=sat.length-1)||(x==0);x++)
	        {
	        if(sat[x]==undefined)
	        {}
	         else
	         {
	         c=c+sat[x]+"+";
	          check_sat=c+c1;
	         }
	          for(x1=0;x1<=childsat.length-1;x1++)
	        {
	        if(childsat[x1]==undefined)
	        {}
	         else
	         {
	         c1=c1+childsat[x1]+"+";
	         }
	         }
        	
	        if(c!="")
	        {
	        c1="";
	       
	        }
	        else
	        {
	        c1;
	        check_sat=c1+check_sat;
	        }
	         }
	 
	                     for(x=0;(x<=focus.length-1)||(x==0);x++)
	                    {
	                    if(focus[x]==undefined)
	                    {}
	                     else
	                     {
	                     ff=ff+focus[x]+"+";
	                     check_focus=ff+ff1;
	                     }
	                     for(x1=0;x1<=childfocus.length-1;x1++)
	                    {
	                    if(childfocus[x1]==undefined)
	                    {}
	                     else
	                     {
	                     ff1=ff1+childfocus[x1]+"+";
	                     }
	                     }
	                                 if(ff!="")
	                                 {
	                                 ff1="";
	                                 
	                                 }
	                                 else
	                                 {
	                                 ff1;
	                                 check_focus=ff1+check_focus;
	                                 }
	                     }
            
            /////////for any day check
                    	 
	 for(x=0;(x<=anyday.length-1)||(x==0);x++)
	{
	if(anyday[x]==undefined)
	{}
	 else
	 {
	 pp=pp+anyday[x]+"+";
	  check_any=pp+pp1;
	 }
	 for(x1=0;x1<=childanyday.length-1;x1++)
	{
	if(childanyday[x1]==undefined)
	{}
	 else
	 {
	 pp1=pp1+childanyday[x1]+"+";
	 }
	 }
	 if(pp!="")
	 {
	 pp1="";
	
	 }
	 else
	 {
	 pp1;
	 check_any=pp1+check_any;
	 }
	 }
	 
	 
	 
	 
	 
	 
	 
	 
	 
	// var tot=m+b+p+h+g+c+pp+ff;
	 var childtot=check_sun+check_mon+check_tue+check_wed+check_thu+check_fri+check_sat+check_focus+check_any;
	 var tot="";
	 
	 var abc=""
	 var browser=navigator.appName;
	 //document.getElementById('imgtri0').value=check_box;
	 for(var w=0;w<i/2;w++)
	 {
	 
 
    var id= "imgtri" +w;
	 //alert(document.getElementById('imgtri0'));
	 //alert(document.getElementById('imgtri0').title);
	         if(document.getElementById(id).src.indexOf("UnDefined") >=0)
	         {
	         if(tot=="")
	         {
	         if(browser!="Microsoft Internet Explorer")
	         {
	             tot=document.getElementById(id).title;
	         }
	         else
	         {
	          tot=document.getElementById(id).value;
	        }
	          
	          
	         }
	         else
	         {
	          if(browser!="Microsoft Internet Explorer")
	          {
	          tot=document.getElementById(id).title+ " + " + tot;
	          }
	         else
	          {
	          tot=document.getElementById(id).value+ " + " + tot;
	          }
	          
	        }
	      }
	         else if(document.getElementById(id).src.indexOf("UnChecked")<=0 && document.getElementById(id).src.indexOf("UnDefined")<=0)
	         {
	         if(abc=="")
	         {
	         if(browser!="Microsoft Internet Explorer")
	         {
	         abc= document.getElementById(id).title ;
	         }
	         else
	         {
	          abc= document.getElementById(id).value ;
	          }
	        }
	          else
	          {
	          if(browser!="Microsoft Internet Explorer")
	          {
	          abc= abc+ " or " + document.getElementById(id).title;
	          }
	          else
	          {
	          abc= abc+ " or " + document.getElementById(id).value;
	          }
	        }
	       }
	 }
	 
	 if(tot=="")
	 {
	 alert("Please Select The Edition From Grid");
	 document.getElementById('btncomname').value="";
	 document.getElementById('noofedi').value="";
	 return false;
	 }
	 //alert(tot);
	 if(tot!="")
	 {
	 var plussplit=tot.split("+");
	var orsplit=abc.split("or");
	if(abc.indexOf("or")>=0)
	{
	 gettotaledi=parseInt(plussplit.length)+1;
	 }
	 else
	 {
	 gettotaledi=parseInt(plussplit.length);
	 }
	    //alert("Please enter No Of Edition");
	    document.getElementById('noofedi').value=gettotaledi;
	 }
	 
     valofchkbox=document.getElementById('getvalofcheck').value=childtot;
	document.getElementById('btncomname').value="";
	if(abc=="")
	{
	document.getElementById('btncomname').value=tot
	}
	else
	{
	var mytool_array=abc.split("or"); 
	//alert("length " + mytool_array.length);
	if(abc!="" && abc.indexOf("or") < 0 )
	{
	document.getElementById('noofedi').value="";
	alert("You cant select single edition when we are using or case");
	return false;
	}
	
	else if(document.getElementById('noofedi').value=="" || parseInt(gettotaledi)<parseInt(document.getElementById('noofedi').value))
	{
	if(tot!="")
	{
	var plussplit=tot.split("+");
	var orsplit=abc.split("or");
	if(abc.indexOf("or")>=0)
	{
	 gettotaledi=parseInt(plussplit.length)+1;
	}
	else
	{
	gettotaledi=parseInt(plussplit.length);
	}
	    //alert("Please enter No Of Edition");
	    document.getElementById('noofedi').value=gettotaledi;
	 }   
	}
	//else if(parseInt(mytool_array.length)<parseInt(document.getElementById('noofedi').value))
	else if(parseInt(gettotaledi)<parseInt(document.getElementById('noofedi').value))
	{
	     alert("Please enter correct No Of Edition");
	     // document.getElementById('noofedi').focus();
	    return false;
	}
	
	document.getElementById('btncomname').value=tot+" + " + abc ;
	}
	document.getElementById('btnsubmit').disabled=false;
	return false;



}

function selectall(stri,j)

{
var str9=stri;
var str="DataGrid1__ctl_CheckBox1" + j;
var str1="DataGrid1__ctl_CheckBox1a" +j;
var str2="DataGrid1__ctl_CheckBox1b"+j;
var str3="DataGrid1__ctl_CheckBox1c"+j;

var str4="DataGrid1__ctl_CheckBox1d"+j;
var str5="DataGrid1__ctl_CheckBox1e"+j;
var str6="DataGrid1__ctl_CheckBox1f"+j;
var str7="DataGrid1__ctl_CheckBox1g"+j;
//var str8="DataGrid1__ctl_CheckBox1h"+j;

if(document.getElementById(str9).checked==true)
{

                if(document.getElementById(str).disabled==false)
                {
                document.getElementById(str).checked=true;
                columncheck("1",j,str);
                }
        if(document.getElementById(str1).disabled==false)
        {
        document.getElementById(str1).checked=true;
         columncheck("1a",j,str);
        }
                if(document.getElementById(str2).disabled==false)
                {
                document.getElementById(str2).checked=true;
                 columncheck("1b",j,str);
                }
        if(document.getElementById(str3).disabled==false)
        {
        document.getElementById(str3).checked=true;
         columncheck("1c",j,str);
        }
                if(document.getElementById(str4).disabled==false)
                {
                document.getElementById(str4).checked=true;
                 columncheck("1d",j,str);
                }
        if(document.getElementById(str5).disabled==false)
        {
        document.getElementById(str5).checked=true;
         columncheck("1e",j,str);
        }
                if(document.getElementById(str6).disabled==false)
                {
                document.getElementById(str6).checked=true;
                 columncheck("1f",j,str);
                }
//        if(document.getElementById(str7).disabled==false)
//        {
//        document.getElementById(str7).checked=true;
          //  columncheck("1",j,str);
//        }
//                if(document.getElementById(str8).disabled==false)
//                {
//                document.getElementById(str8).checked=true;
//                 columncheck("1h",j,str);
//                }
        if(document.getElementById(str9).disabled==false)
        {
        document.getElementById(str9).checked=true;
        columncheck("1k",j,str);
        }
                
   
}



if(document.getElementById(str9).checked==false)
{
document.getElementById(str).checked=false;
document.getElementById(str1).checked=false;
document.getElementById(str2).checked=false;
document.getElementById(str3).checked=false;
document.getElementById(str4).checked=false;
document.getElementById(str5).checked=false;
document.getElementById(str6).checked=false;
document.getElementById(str7).checked=false;
//document.getElementById(str8).checked=false;

var len="uniquename"+j;
var y=0;
////if(document.getElementById(len).getElementsByTagName('table').length>0)
//// y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;

 for(var w=0;w<y-1;w++)
	    {
	 var stra1 = parseInt(j,10)+1 + parseInt(w,10);
	document.getElementById(stra1).checked=false;
	
	 var stra2 = j+"1a" + w;
	document.getElementById(stra2).checked=false;
	
	 var stra3 = j+"1b" + w;
	document.getElementById(stra3).checked=false;
	
	 var stra4 = j+"1c" + w;
	document.getElementById(stra4).checked=false;
	
	 var stra5 =j+ "1d" + w;
	document.getElementById(stra5).checked=false;
	
	 var stra6 =j+"1e" + w;
	document.getElementById(stra6).checked=false;
	
	 var stra7 = j+"1f" + w;
	document.getElementById(stra7).checked=false;
	
//	 var stra8 = j+"1g" + w;
//	document.getElementById(stra8).checked=false;
	
//	 var stra9 = j+"1h" + w;
//	document.getElementById(stra9).checked=false;
	
	 var stra10 = j+"1k" + w;
	document.getElementById(stra10).checked=false;
	
	
	}


      
//	        var stra1 = rownum+columncheck + w;
//	        document.getElementById(stra1).checked=false;
//	    } 

}

}



function checkuncheck(str,j,a)
{

        var stra =parseInt(j,10)+1 +parseInt(a,10);
        var stra1 =j+"1a" + a;
        var stra2 =j+"1b" + a;
        var stra3 =j+"1c" + a;
        var stra4 =j+"1d" + a;
        var stra5 =j+"1e" + a;
        var stra6 =j+"1f" + a;
        var stra7 =j+"1g" + a;
        //var stra8 =j+"1h" + a;
        var stra9 =j+"1k" + a;

if(document.getElementById(str).checked==true)
{
//alert(str);

  if(document.getElementById(stra).disabled==false)
                {
                document.getElementById(stra).checked=true;
                }
        if(document.getElementById(stra1).disabled==false)
        {
        document.getElementById(stra1).checked=true;
        }
                if(document.getElementById(stra2).disabled==false)
                {
                document.getElementById(stra2).checked=true;
                }
        if(document.getElementById(stra3).disabled==false)
        {
        document.getElementById(stra3).checked=true;
        }
                if(document.getElementById(stra4).disabled==false)
                {
                document.getElementById(stra4).checked=true;
                }
        if(document.getElementById(stra5).disabled==false)
        {
        document.getElementById(stra5).checked=true;
        }
                if(document.getElementById(stra6).disabled==false)
                {
                document.getElementById(stra6).checked=true;
                }
//        if(document.getElementById(stra7).disabled==false)
//        {
//        document.getElementById(stra7).checked=true;
//        }
//                if(document.getElementById(stra8).disabled==false)
//                {
//                document.getElementById(stra8).checked=true;
//                }
        if(document.getElementById(stra9).disabled==false)
        {
        document.getElementById(stra9).checked=true;
        }
        
        unchk (stra9,"1k",j);
}


if(document.getElementById(str).checked==false)
{
document.getElementById(stra).checked=false;
document.getElementById(stra1).checked=false;
document.getElementById(stra2).checked=false;
document.getElementById(stra3).checked=false;
document.getElementById(stra4).checked=false;
document.getElementById(stra5).checked=false;
document.getElementById(stra6).checked=false;
document.getElementById(stra7).checked=false;
//document.getElementById(stra8).checked=false;
document.getElementById(stra9).checked=false;


    var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	
	var str1="DataGrid1__ctl_CheckBox1a"+j;
	document.getElementById(str1).checked=false;
	
	var str2="DataGrid1__ctl_CheckBox1b"+j;
	document.getElementById(str2).checked=false;
	
	var str3="DataGrid1__ctl_CheckBox1c"+j;
	document.getElementById(str3).checked=false;
	
	var str4="DataGrid1__ctl_CheckBox1d"+j;
	document.getElementById(str4).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1e"+j;
	document.getElementById(str5).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1f"+j;
	document.getElementById(str5).checked=false;
	
	var str6="DataGrid1__ctl_CheckBox1g"+j;
	document.getElementById(str6).checked=false;
	
//	var str7="DataGrid1__ctl_CheckBox1h"+j;
//	document.getElementById(str7).checked=false;
//	
	var str8="DataGrid1__ctl_CheckBox1k"+j;
	document.getElementById(str8).checked=false;


}


}


function getthefocus()
{
document.getElementById('drpadtype').focus();
return false;
}


function newclick()
{

var i=document.getElementById("DataGrid1").rows.length -1;
document.getElementById("hiddenshow").value = "0";
document.getElementById('hiddenshow').value = "0";
document.getElementById("lbaddon").disabled = false;
	flag2="0";


for(j=0;j<i/2;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	
	var str1="DataGrid1__ctl_CheckBox1a"+j;
	document.getElementById(str1).checked=false;
	
	var str2="DataGrid1__ctl_CheckBox1b"+j;
	document.getElementById(str2).checked=false;
	
	var str3="DataGrid1__ctl_CheckBox1c"+j;
	document.getElementById(str3).checked=false;
	
	var str4="DataGrid1__ctl_CheckBox1d"+j;
	document.getElementById(str4).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1e"+j;
	document.getElementById(str5).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1f"+j;
	document.getElementById(str5).checked=false;
	
	var str6="DataGrid1__ctl_CheckBox1g"+j;
	document.getElementById(str6).checked=false;
	
//	var str7="DataGrid1__ctl_CheckBox1h"+j;
//	document.getElementById(str7).checked=false;
	
	var str8="DataGrid1__ctl_CheckBox1k"+j;
	document.getElementById(str8).checked=false;
	
	var len="uniquename"+j;
	//alert(len);
	//alert(document.getElementById(len).getElementsByTagName('table')[0].rows.length);
	
    var y=0;//////document.getElementById(len).getElementsByTagName('table')[0].rows.length;

    
	for(w=0;w<y-1;w++)
	{
	 var stra1 = parseInt(j,10)+1 + parseInt(w,10);
	document.getElementById(stra1).checked=false;
	
	 var stra2 = j+"1a" + w;
	document.getElementById(stra2).checked=false;
	
	 var stra3 = j+"1b" + w;
	document.getElementById(stra3).checked=false;
	
	 var stra4 = j+"1c" + w;
	document.getElementById(stra4).checked=false;
	
	 var stra5 =j+ "1d" + w;
	document.getElementById(stra5).checked=false;
	
	 var stra6 =j+"1e" + w;
	document.getElementById(stra6).checked=false;
	
	 var stra7 = j+"1f" + w;
	document.getElementById(stra7).checked=false;
	
	 var stra8 = j+"1g" + w;
	document.getElementById(stra8).checked=false;
	
//	 var stra9 = j+"1h" + z;
//	document.getElementById(stra9).checked=false;
	
	 var stra10 = j+"1k" + w;
	document.getElementById(stra10).checked=false;
	}
	
	}

document.getElementById('DataGrid1').disabled=false;
document.getElementById('btntextcomcode').value="";
document.getElementById('btextalias').value="";
document.getElementById('btnpackname').value="";
document.getElementById('btncomname').value="";

				
document.getElementById('btntextcomcode').disabled=false;
document.getElementById('btextalias').disabled=false;
document.getElementById('btnpackname').disabled=false;
document.getElementById('btncomname').disabled=false;

//chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
flag=0;

return false;

}

function cancelclick(formname)
{

var i=document.getElementById("DataGrid1").rows.length -1;
document.getElementById("hiddenshow").value = "0";
document.getElementById('hiddenshow').value = "0";
   flag2="0";
document.getElementById("lbaddon").disabled = true;
	


for(j=0;j<i/2;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	if(document.getElementById(str)!=null)
	{
	document.getElementById(str).checked=false;
	
	var str1="DataGrid1__ctl_CheckBox1a"+j;
	document.getElementById(str1).checked=false;
	
	var str2="DataGrid1__ctl_CheckBox1b"+j;
	document.getElementById(str2).checked=false;
	
	var str3="DataGrid1__ctl_CheckBox1c"+j;
	document.getElementById(str3).checked=false;
	
	var str4="DataGrid1__ctl_CheckBox1d"+j;
	document.getElementById(str4).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1e"+j;
	document.getElementById(str5).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1f"+j;
	document.getElementById(str5).checked=false;
	
	var str6="DataGrid1__ctl_CheckBox1g"+j;
	document.getElementById(str6).checked=false;
	
	}
//	var str7="DataGrid1__ctl_CheckBox1h"+j;
//	document.getElementById(str7).checked=false;
//	
//	var str8="DataGrid1__ctl_CheckBox1k"+j;
//	document.getElementById(str8).checked=false;

	var len="uniquename"+j;
	//alert(len);
	//alert(document.getElementById(len).getElementsByTagName('table')[0].rows.length);
	var y=0;
//////	if(document.getElementById(len).getElementsByTagName('table').length>0)
//////	{
//////     y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
//////    }

    
	for(w=0;w<y-1;w++)
	{
	 var stra1 = parseInt(j,10)+1 + parseInt(w,10);
	document.getElementById(stra1).checked=false;
	
	 var stra2 = j+"1a" + w;
	document.getElementById(stra2).checked=false;
	
	 var stra3 = j+"1b" + w;
	document.getElementById(stra3).checked=false;
	
	 var stra4 = j+"1c" + w;
	document.getElementById(stra4).checked=false;
	
	 var stra5 =j+ "1d" + w;
	document.getElementById(stra5).checked=false;
	
	 var stra6 =j+"1e" + w;
	document.getElementById(stra6).checked=false;
	
	 var stra7 = j+"1f" + w;
	document.getElementById(stra7).checked=false;
	
	 var stra8 = j+"1g" + w;
	document.getElementById(stra8).checked=false;
	
//	 var stra9 = j+"1h" + z;
//	document.getElementById(stra9).checked=false;
	
	 var stra10 = j+"1k" + w;
	document.getElementById(stra10).checked=false;
	}
	
	}


document.getElementById('DataGrid1').disabled=true;
document.getElementById('btntextcomcode').value="";
document.getElementById('btextalias').value="";
document.getElementById('btnpackname').value="";
document.getElementById('btncomname').value="";


document.getElementById('btntextcomcode').disabled=true;
document.getElementById('btextalias').disabled=true;
document.getElementById('btnpackname').disabled=true;
document.getElementById('btncomname').disabled=true;
document.getElementById('drpadtype').disabled=true;
document.getElementById('drpadcategory').disabled=true;
document.getElementById('drpsubcategory').disabled=true;

document.getElementById('drppubcenter').disabled = true;
document.getElementById('txtoldcode').disabled = true;
document.getElementById('txtoldcode').value = "";
document.getElementById('drppubcenter').value="0";

//    alert(document.getElementById('drpadtype').value);



//-------------------------------------------------------------------------

		document.getElementById('btnNew').disabled=false;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
			
document.getElementById('hidenvarupdate').value="0";
total="";

//getPermission(formname);
			
//------------------------------------saurabh added------------------------			
	setButtonImages();		
return false;
}

function exitclick()
{
if(confirm("Do You Want To Skip This Page"))
{
window.close();
return false;
}

return false;

}



function submittedclick()

{
    var browser=navigator.appName;
    var bc="";

    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblpubcenter').textContent;
    }
    else
    {
        bc=document.getElementById('lblpubcenter').innerText;
    }

    if(bc.indexOf('*')>= 0 )
    {
        if(trim(document.getElementById('drppubcenter').value)== "0" )
        {   
            alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drppubcenter').focus();
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbloldpkgcode').textContent;
    }
    else {
        bc = document.getElementById('lbloldpkgcode').innerText;
    }

    
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtoldcode').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtoldcode').focus();
            return false;
        }
    }
if(document.getElementById('drpadtype').value=="0")
{
alert("Please Select Ad Type");
if(document.getElementById('btntextcomcode').disabled==false)
    document.getElementById('drpadtype').focus();
return false;
}
else if(trim(document.getElementById('btntextcomcode').value)=="" && document.getElementById('hiddenauto').value== "0")
{
alert("Please Enter The Package Code");
document.getElementById('btntextcomcode').value=trim(document.getElementById('btntextcomcode').value);
if(document.getElementById('btntextcomcode').disabled==false)
    document.getElementById('btntextcomcode').focus();
return false;
}
else if(document.getElementById('btnpackname').value=="")
{
alert("Please Enter The Package Name");
if(document.getElementById('btnpackname').disabled==false)
    document.getElementById('btnpackname').focus();
return false;
}
else if(document.getElementById('btextalias').value=="")
{
alert("Please Enter The Alias Name");
if(document.getElementById('btextalias').disabled==false)
    document.getElementById('btextalias').focus();
return false;
}

else if(document.getElementById('btncomname').value=="")
{
alert("Please Enter The Combination Name");
//document.getElementById('btncomname').focus();
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
var comcode=trim(document.getElementById('btntextcomcode').value);
var alias=trim(document.getElementById('btextalias').value);
var packagename=document.getElementById('btnpackname').value;
var combinationname=document.getElementById('btncomname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var cat=document.getElementById('drpadcategory').value;
var adtype=document.getElementById('drpadtype').value;
var subcat=document.getElementById('drpsubcategory').value;
var split=document.getElementById('drpsplit').value;
var consumption=document.getElementById('txtconsum').value;

valofchkbox=document.getElementById('getvalofcheck').value;

var pubcenter=document.getElementById('drppubcenter').value;

var noedition=document.getElementById('noofedi').value;
/*change ankur*/
var no_ofinsert=document.getElementById('txtnoofinserts').value;
/////////////////////////////////////////////////////////
forupdate=document.getElementById('hidenvarupdate').value;

var combindesc=document.getElementById('btncomname').value;
var values1="";
var len=parseInt(document.getElementById('btnoptionbutton').getElementsByTagName('TBODY')[0].getElementsByTagName('TR')[0].getElementsByTagName('TD').length);

if(document.getElementById('btncomname').value!=document.getElementById('btnpackname').value)
{
    for(var rdcount=0;rdcount<len;rdcount++)
    {
        var rdid='btnoptionbutton_'+rdcount;
        if(document.getElementById(rdid).checked==true)
        {
            values1=document.getElementById(rdid).value;
            break;
        }
    }
}
else
{
    values1=4;
}
if(forupdate != "1" && forupdate!=null)
{

CombinationMaster.checkcode(comcode,compcode,userid,combinationname,adtype,cat,subcat,pubcenter,combindesc,values1,call_saveclick);
}
else
{
    if(document.getElementById('hidden_b').value!=document.getElementById('btnpackname').value)
    {
        var chkname=CombinationMaster.chkpackagename(packagename,compcode,document.getElementById('drpadtype').value);
        if(chkname.value.Tables[0].Rows.length>0)
        {
            alert("This name already in Use");
            return false;
        }
     //   return false;
    }
    
    savedays();
//CombinationMaster.updatecomm(comcode,alias,packagename,combinationname,compcode,userid,total);
    /*change ankur*/
    var olddpkg = document.getElementById('txtoldcode').value;
    CombinationMaster.updatecomm(comcode, alias, packagename, combinationname, compcode, userid, total, cat, subcat, adtype, noedition, valofchkbox, no_ofinsert, split, consumption, olddpkg);
///////////////////////////////////////////////////////////////////////////

document.getElementById('hidenvarupdate').value="0";
					document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;	
					
					document.getElementById('DataGrid1').disabled=true;	
					
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					
					
					document.getElementById('btntextcomcode').disabled=true;
					document.getElementById('btextalias').disabled=true;
					document.getElementById('btnpackname').disabled=true;
					document.getElementById('btncomname').disabled=true;
					document.getElementById('btncancelgrid').disabled=true;
					document.getElementById('btnsubmit').disabled=true;
					document.getElementById('drpsplit').disabled=true;
					document.getElementById('txtconsum').disabled=true;
					
					/*change ankur*/
					document.getElementById('txtnoofinserts').disabled=true;
					//////////////////////////////////
					
					updateStatus();
					
					var i=document.getElementById("DataGrid1").rows.length -1;
					
					//-----------------------saurabh added------------------------------------------- global_ds
					
					 //var x=dsexecombin.Tables[0].Rows.length;
					 var x=global_ds.Tables[0].Rows.length;
					var sag=x-1;
					sag=sag-1;
					if (z==0)
                    {
                        document.getElementById('btnfirst').disabled=true;
                        document.getElementById('btnprevious').disabled=true;
                    }

                    if(z==sag)
                    {
                       document.getElementById('btnnext').disabled=true;
                    	document.getElementById('btnlast').disabled=true;
                    }
                    setButtonImages();
                      document.getElementById('btnModify').focus();
					
					//-------------------------------------------------------------------

//for(j=0;j<i;j++)
//	{
//	var str="DataGrid1__ctl_CheckBox1"+j;
//	document.getElementById(str).checked=false;
//	
//	}
//					
					
					//alert("Value Updated Sucessfully");
	if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
					// alert(xmlObj.childNodes(0).childNodes(1).text);
					flag=0;
					
}
return false;
}

function call_saveclick(response)
{
var ds=response.value;
var comcode=trim(document.getElementById('btntextcomcode').value);
var alias=trim(document.getElementById('btextalias').value);
var packagename=document.getElementById('btnpackname').value;
var combinationname=document.getElementById('btncomname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var cat=document.getElementById('drpadcategory').value;

//var share=document.getElementById('drpshare').value;

var subcat=document.getElementById('drpsubcategory').value;
var adtype=document.getElementById('drpadtype').value;
var noedition=document.getElementById('noofedi').value;
var split=document.getElementById('drpsplit').value;
var consumption=document.getElementById('txtconsum').value;

/*change ankur*/
var no_ofinsert=document.getElementById('txtnoofinserts').value;
/////////////////////////////////////////////////////////

valofchkbox=document.getElementById('getvalofcheck').value;

var pubcenter=document.getElementById('drppubcenter').value;

var editiontype="";
//=document.getElementById('btnoptionbutton_0').value;
//alert(document.getElementById('btnoptionbutton_0').checked)
        if(document.getElementById('btnoptionbutton_0').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_0').value;
        }
        if(document.getElementById('btnoptionbutton_1').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_1').value;
        }
        if(document.getElementById('btnoptionbutton_2').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_2').value;

        }
        if(document.getElementById('btnoptionbutton_3').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_3').value;

        }


        



if(ds.Tables[0].Rows.length > 0)
	{
	alert("This code has been assigned");
	return false;
	}
if(ds.Tables.count>2)
{	
if(ds.Tables[2].Rows.length > 0)
{
    alert(ds.Tables[2].Rows[0].MESSAGE + " for center " + document.getElementById('drppubcenter').options[document.getElementById('drppubcenter').selectedIndex].text);
    return false;
}
}	
//	if(ds.Tables[1].Rows.length > 0)
//	{
//	alert("This Combination Name Has Already Been Assigned With Package Name "+ds.Tables[1].Rows[0].package_name+"");
//	return false;
//	}
	
	
    /*change ankur*/
//var oldcode = document.getElementById('txtoldcode').value;
CombinationMaster.insertcomm(comcode, alias, packagename, combinationname, compcode, userid, total, cat, subcat, adtype, noedition, editiontype, valofchkbox, no_ofinsert, pubcenter, split, consumption);

savedays();
saveadonpopup();
/////////////////////////////
total="";

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
					
					
					
					var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i/2;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	
	}
	
	//alert("Value Save Sucessfuly");
		//alert(xmlObj.childNodes(0).childNodes(0).text);
		if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}

                    document.getElementById('btntextcomcode').value="";
					document.getElementById('btextalias').value="";
					document.getElementById('btnpackname').value="";
					document.getElementById('btncomname').value="";
					document.getElementById('noofedi').value="";

                    /*change ankur*/
                    document.getElementById('txtnoofinserts').value="";
					document.getElementById('txtnoofinserts').disabled=true;
					document.getElementById('txtconsum').value="";
					document.getElementById('txtconsum').disabled=true;
                    ///////////////////////////////////////////

					document.getElementById('btntextcomcode').disabled=true;
					document.getElementById('btextalias').disabled=true;
					document.getElementById('btnpackname').disabled=true;
					document.getElementById('btncomname').disabled=true;
					document.getElementById('drpshare').disabled=true;
					
					document.getElementById('drpadtype').value="0";
					document.getElementById('drpadcategory').value="0";
					document.getElementById('drpsubcategory').value="0";
					//document.getElementById('drpshare').value="0";

					document.getElementById('btnsubmit').disabled=true;
					document.getElementById('btncancelgrid').disabled=true;
				
					cancelgrid();
					cancelclick('CombinationMaster');
					document.getElementById('btnsubmit').disabled=true;
					document.getElementById('drpshare').disabled=true;
					document.getElementById('drpshare').value="0";
					//updateStatus();


return false;


}
function cancelgrid()
{
document.getElementById('btnsubmit').disabled=false;


var i=document.getElementById("DataGrid1").rows.length -1;
//document.getElementById("DataGrid1").disabled=false;
for(j=0;j<i/2;j++)
	{
    
	    
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str + document.getElementById(str));
	document.getElementById(str).checked=false;
	
	var str1="DataGrid1__ctl_CheckBox1a"+j;
	document.getElementById(str1).checked=false;
	
	var str2="DataGrid1__ctl_CheckBox1b"+j;
	document.getElementById(str2).checked=false;
	
	var str3="DataGrid1__ctl_CheckBox1c"+j;
	document.getElementById(str3).checked=false;
	
	var str4="DataGrid1__ctl_CheckBox1d"+j;
	document.getElementById(str4).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1e"+j;
	document.getElementById(str5).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1f"+j;
	document.getElementById(str5).checked=false;
	
	var str6="DataGrid1__ctl_CheckBox1g"+j;
	document.getElementById(str6).checked=false;
	
	
	var str6="DataGrid1__ctl_CheckBox1k"+j;
	document.getElementById(str6).checked=false;
	
	var imgid="imgtri"+j;
	
	if(document.getElementById(imgid).src.indexOf("UnChecked")>=0)
    {
        document.getElementById(imgid).src=document.getElementById(imgid).src.replace("UnChecked","UnChecked");
     }
    else if(document.getElementById(imgid).src.indexOf("Checked")>=0)
    {
        document.getElementById(imgid).src=document.getElementById(imgid).src.replace("Checked","UnChecked");
    }
    else if(document.getElementById(imgid).src.indexOf("UnDefined")>=0)
    {
        document.getElementById(imgid).src=document.getElementById(imgid).src.replace("UnDefined","UnChecked");
    }
	
	
	var len="uniquename"+j;
	var y=0;
////	if(document.getElementById(len).getElementsByTagName('table').length>0)
////     y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;

    
////////	for(w=0;w<y-1;w++)
////////	{

//////// 
////////	
////////	 var stra1 = parseInt(j,10)+1 + parseInt(w,10);
////////	document.getElementById(stra1).checked=false;
////////	
////////	 var stra2 = j+"1a" + w;
////////	document.getElementById(stra2).checked=false;
////////	
////////	 var stra3 = j+"1b" + w;
////////	document.getElementById(stra3).checked=false;
////////	
////////	 var stra4 = j+"1c" + w;
////////	document.getElementById(stra4).checked=false;
////////	
////////	 var stra5 =j+ "1d" + w;
////////	document.getElementById(stra5).checked=false;
////////	
////////	 var stra6 =j+"1e" + w;
////////	document.getElementById(stra6).checked=false;
////////	
////////	 var stra7 = j+"1f" + w;
////////	document.getElementById(stra7).checked=false;
////////	
////////	 var stra8 = j+"1g" + w;
////////	document.getElementById(stra8).checked=false;
////////	
//////////	 var stra9 = j+"1h" + w;
//////////	document.getElementById(stra9).checked=false;
////////	
////////	 var stra10 = j+"1k" + w;
////////	document.getElementById(stra10).checked=false;
////////	}
	
	}


document.getElementById('btncomname').value="";
document.getElementById('noofedi').value="";
//document.getElementById('btntextcomcode').value="";
//document.getElementById('btnpackname').value="";
//document.getElementById('btextalias').value="";
//document.getElementById("DataGrid1").disabled=true;
//window.location=window.location;
total="";
return false;

return false;
}

function modifyclick()
{
document.getElementById("hiddenshow").value="1";
flag2="1";
document.getElementById("lbaddon").disabled = false;
document.getElementById('txtconsum').disabled=false;
document.getElementById('DataGrid1').disabled=false;
document.getElementById('btntextcomcode').disabled=true;
document.getElementById('btextalias').disabled=false;
document.getElementById('btnpackname').disabled=false;
document.getElementById('btncomname').disabled=true;
document.getElementById('drpadtype').disabled=true;
document.getElementById('drpadcategory').disabled=true;
document.getElementById('drpsubcategory').disabled=true;

document.getElementById('btnsubmit').disabled=false;
document.getElementById('btncancelgrid').disabled=false;
document.getElementById('btnoptionbutton').disabled=false;
document.getElementById('drpsplit').disabled = false;
document.getElementById('txtoldcode').disabled = false;
/*change ankur*/
document.getElementById('txtnoofinserts').disabled=false;
///////////////////////////////////////
document.getElementById('hidden_b').value=document.getElementById('btnpackname').value;
document.getElementById('hidenvarupdate').value="1";
document.getElementById('hiddenplussign').value="1"

//chkstatus(FlagStatus);

                document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled = true;
flag=1;		
setButtonImages();			
document.getElementById('btnSave').focus();
return false;

}
function queryclick()
{

document.getElementById("lbaddon").disabled =true;
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i/2;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	
	var str1="DataGrid1__ctl_CheckBox1a"+j;
	document.getElementById(str1).checked=false;
	
	var str2="DataGrid1__ctl_CheckBox1b"+j;
	document.getElementById(str2).checked=false;
	
	var str3="DataGrid1__ctl_CheckBox1c"+j;
	document.getElementById(str3).checked=false;
	
	var str4="DataGrid1__ctl_CheckBox1d"+j;
	document.getElementById(str4).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1e"+j;
	document.getElementById(str5).checked=false;
	
	var str5="DataGrid1__ctl_CheckBox1f"+j;
	document.getElementById(str5).checked=false;
	
	var str6="DataGrid1__ctl_CheckBox1g"+j;
	document.getElementById(str6).checked=false;
	
//	var str7="DataGrid1__ctl_CheckBox1h"+j;
//	document.getElementById(str7).checked=false;
	
//	var str8="DataGrid1__ctl_CheckBox1k"+j;
//	document.getElementById(str8).checked=false;
	
	var len="uniquename"+j;
	//alert(len);
	//alert(document.getElementById(len).getElementsByTagName('table')[0].rows.length);
	var y=0;
////	if(document.getElementById(len).getElementsByTagName('table').length>0)
////     y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;

//////    
//////	for(w=0;w<y-1;w++)
//////	{
//////	 var stra1 = parseInt(j,10)+1 + parseInt(w,10);
//////	document.getElementById(stra1).checked=false;
//////	
//////	 var stra2 = j+"1a" + w;
//////	document.getElementById(stra2).checked=false;
//////	
//////	 var stra3 = j+"1b" + w;
//////	document.getElementById(stra3).checked=false;
//////	
//////	 var stra4 = j+"1c" + w;
//////	document.getElementById(stra4).checked=false;
//////	
//////	 var stra5 =j+ "1d" + w;
//////	document.getElementById(stra5).checked=false;
//////	
//////	 var stra6 =j+"1e" + w;
//////	document.getElementById(stra6).checked=false;
//////	
//////	 var stra7 = j+"1f" + w;
//////	document.getElementById(stra7).checked=false;
//////	
//////	 var stra8 = j+"1g" + w;
//////	document.getElementById(stra8).checked=false;
//////	
////////	 var stra9 = j+"1h" + z;
////////	document.getElementById(stra9).checked=false;
//////	
//////	 var stra10 = j+"1k" + w;
//////	document.getElementById(stra10).checked=false;
//////	}
	
	}


document.getElementById('DataGrid1').disabled=true;
document.getElementById('btntextcomcode').disabled=false;
document.getElementById('btextalias').disabled=false;
document.getElementById('btnpackname').disabled=false;
document.getElementById('btncomname').disabled=true;
document.getElementById('txtconsum').disabled=true;
z=0;

			document.getElementById('btntextcomcode').value="";
			document.getElementById('btextalias').value="";
			document.getElementById('btnpackname').value="";
			document.getElementById('btncomname').value="";
			document.getElementById('txtconsum').value="";
			document.getElementById('txtoldcode').value = "";
//chkstatus(FlagStatus);

document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;			
			
return false;
}

var gcomcode="";
var galias="";
var gpackagename="";
var gcombinationname=""
var gcompcode="";
var guserid="";
var geditiontype="";
var gadtype="";
var gpubcenter="";


function executeclick()
{
//document.getElementById('DataGrid1').disabled=true;
var comcode=document.getElementById('btntextcomcode').value;
document.getElementById("hiddenshow").value = "2";
//gcomcode=comcode;
gcomcode=document.getElementById('hiddengcomcode').value=comcode;
var alias=document.getElementById('btextalias').value;
//galias=alias;
galias=document.getElementById('hiddengalias').value=alias;
var packagename=document.getElementById('btnpackname').value;
//gpackagename=packagename;
gpackagename=document.getElementById('hiddengpackcode').value=packagename;
var combinationname=document.getElementById('btncomname').value;
//gcombinationname=combinationname;
gcombinationname=document.getElementById('hiddengcombncode').value=combinationname;
var compcode=document.getElementById('hiddencompcode').value;
gcompcode=compcode;
var userid=document.getElementById('hiddenuserid').value;
guserid=userid;
var adtype=document.getElementById('drpadtype').value;
//gadtype=adtype;
gadtype=document.getElementById('hiddengadtype').value=adtype;
var split=document.getElementById('drpsplit').value;
gsplit=split;

var pubcenter=document.getElementById('drppubcenter').value;
gpubcenter=pubcenter;

var editiontype;
        if(document.getElementById('btnoptionbutton_0').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_0').value;
        }
        if(document.getElementById('btnoptionbutton_1').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_1').value;
        }
        if(document.getElementById('btnoptionbutton_2').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_2').value;
        }
        if(document.getElementById('btnoptionbutton_3').checked)
        {
         editiontype=document.getElementById('btnoptionbutton_3').value;
        }
        // geditiontype=editiontype;
        geditiontype=document.getElementById('hiddengeditiontype').value

z=0;
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
              //var oldpkgcode = document.getElementById('txtoldcode').value;
              CombinationMaster.executecomm(comcode, alias, packagename, compcode, userid, editiontype, adtype, pubcenter, split, call_execute);


						document.getElementById('btntextcomcode').disabled=true;
						document.getElementById('btextalias').disabled=true;
						document.getElementById('btnpackname').disabled=true;
						document.getElementById('btncomname').disabled=true;
						document.getElementById('btnsubmit').disabled=true;
						document.getElementById('drpadtype').disabled=true;
						document.getElementById('drpadcategory').disabled=true;
						document.getElementById('drpsubcategory').disabled=true;
						document.getElementById('drpshare').disabled=true;
						document.getElementById('noofedi').disabled=true;
						document.getElementById('drpsplit').disabled=true;
						document.getElementById('txtconsum').disabled=true;
						


//document.getElementById('btnfirst').disabled=true;
			//document.getElementById('btnprevious').disabled=true;	
		//	document.getElementById('btnModify').disabled=false;
		    //document.getElementById('btnModify').focus();	

return false;

}
function call_execute(response)
{
 global_ds=response.value;
 
 

if(global_ds.Tables[0].Rows.length > 0)


	{
	fillcheckboxwhenexecute(global_ds.Tables[0].Rows[0].Edition_Combin_Code,global_ds.Tables[0].Rows[0].Combin_Code);
	
document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[0].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[0].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[0].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[0].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[0].Ad_Type_code;
bind_pkg_adcat_uom(global_ds.Tables[0].Rows[0].Ad_Type_code);
document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].pub_center;

if(global_ds.Tables[0].Rows[0].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[0].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[0].CONSUM_PERIOD;
}

if(document.getElementById('drpadcategory').value=="" || document.getElementById('drpadcategory').value==null)
{
        document.getElementById('drpadcategory').value="0";
}
else
{
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[0].Ad_Cat_Code;
}
if(global_ds.Tables[0].Rows[0].SPLIT=="" || global_ds.Tables[0].Rows[0].SPLIT==null)
{
        document.getElementById('drpsplit').value="0";
}
else
{
document.getElementById('drpsplit').value=global_ds.Tables[0].Rows[0].SPLIT;
}
if(global_ds.Tables[0].Rows[0].Ad_Cat_Code !=null)
   bind_pkg_adsubcat(global_ds.Tables[0].Rows[0].Ad_Cat_Code);
   
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[0].Ad_Subcat_code;
if(global_ds.Tables[0].Rows[0].No_Of_Edition!=null && global_ds.Tables[0].Rows[0].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[0].No_Of_Edition;
}
else
{
    document.getElementById('noofedi').value="";
}
document.getElementById('drpshare').value=global_ds.Tables[0].Rows[0].Share_Distribution;

if(global_ds.Tables[0].Rows[0].No_of_inserts==null || global_ds.Tables[0].Rows[0].No_of_inserts=="null")
{
document.getElementById('txtnoofinserts').value="";
}
else
{
/*change bhanu*/
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[0].No_of_inserts;
}
/////////////////////////////////////////////////






       
        

//                        document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
//						document.getElementById('btnModify').disabled=false;
//						document.getElementById('btnDelete').disabled=false;
						document.getElementById('btnQuery').disabled=false;
//						document.getElementById('btnExecute').disabled=true;
//						document.getElementById('btnCancel').disabled=false;		
//						document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
//						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;	
//						document.getElementById('btnExit').disabled=false;
/*change ankur*/
if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled=false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
           document.getElementById('btnDelete').disabled=false;
document.getElementById('txtnoofinserts').disabled=true;
//////////////////////////////////////////

document.getElementById('btnsubmit').disabled=true;

if(global_ds.Tables[0].Rows.length-1==0)
{
                        document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=true;	

}
setButtonImages();

return false;

	
	
	}
	else
	{
	alert("Your Search Criteria Does Not Produce Any Result!!!");
	
	document.getElementById('drpadtype').value="0";
document.getElementById('drpadcategory').value="0";
document.getElementById('drpsubcategory').value="0";
document.getElementById('drpshare').value="0";
document.getElementById('drpsplit').value="0";
document.getElementById('txtconsum').value="";
/*change ankur*/
document.getElementById('txtnoofinserts').value="";
	////////////////////
	cancelclick('CombinationMaster');
	return false;
	}

}

function firstclick()
{
//CombinationMaster.firstcomm(call_firstclick);
			
			
			document.getElementById('btntextcomcode').disabled=true;
						document.getElementById('btextalias').disabled=true;
						document.getElementById('btnpackname').disabled=true;
						document.getElementById('btncomname').disabled=true;

			
			
			
//return false;

//}

//function call_firstclick(response)
//{
z=0;
fillcheckboxwhenexecute(global_ds.Tables[0].Rows[0].Edition_Combin_Code,global_ds.Tables[0].Rows[0].Combin_Code);
document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[0].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[0].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[0].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[0].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[0].Ad_Type_code;
bind_pkg_adcat_uom(global_ds.Tables[0].Rows[0].Ad_Type_code);
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[0].Ad_Cat_Code;


if(global_ds.Tables[0].Rows[0].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[0].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[0].CONSUM_PERIOD;
}

if(global_ds.Tables[0].Rows[0].Ad_Cat_Code !=null)
  bind_pkg_adsubcat(global_ds.Tables[0].Rows[0].Ad_Cat_Code);
  
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[0].Ad_Subcat_code;

document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].pub_center;

if(global_ds.Tables[0].Rows[0].No_Of_Edition!=null && global_ds.Tables[0].Rows[0].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[0].No_Of_Edition;
 }
 else
 {
    document.getElementById('noofedi').value="";
 }   
if(global_ds.Tables[0].Rows[0].SPLIT=="" || global_ds.Tables[0].Rows[0].SPLIT==null)
{
        document.getElementById('drpsplit').value="0";
}
else
{
document.getElementById('drpsplit').value=global_ds.Tables[0].Rows[0].SPLIT;
}
/*change ankur*/
if(global_ds.Tables[0].Rows[0].No_of_inserts==null || global_ds.Tables[0].Rows[0].No_of_inserts=="null")
{
document.getElementById('txtnoofinserts').value="";
}
else
{
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[0].No_of_inserts;
}
///////////////////////////////////////////////////////////////////////////////


updateStatus();

    document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;
	 document.getElementById('btnnext').disabled=false;				
	document.getElementById('btnlast').disabled=false;	
	
	document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						//document.getElementById('btnModify').disabled=false;
						//document.getElementById('btnDelete').disabled=false;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnExit').disabled=false;
						
						document.getElementById('drpadtype').disabled=true;
						document.getElementById('drpadcategory').disabled=true;
						document.getElementById('drpsubcategory').disabled=true;
						document.getElementById('noofedi').disabled=true;
						document.getElementById('btnsubmit').disabled=true;
						document.getElementById('drpsplit').disabled=true;
						document.getElementById('txtconsum').disabled=true;

	
setButtonImages();	
return false;
}

function lastclick()
{
//CombinationMaster.firstcomm(call_lastclick);
			
			
			            document.getElementById('btntextcomcode').disabled=true;
						document.getElementById('btextalias').disabled=true;
						document.getElementById('btnpackname').disabled=true;
						document.getElementById('btncomname').disabled=true;
			
			
			
//return false;

//}
//function call_lastclick(response)
//{
var y=global_ds.Tables[0].Rows.length;
var a=y-1;
z=a;
fillcheckboxwhenexecute(global_ds.Tables[0].Rows[a].Edition_Combin_Code,global_ds.Tables[0].Rows[a].Combin_Code);
document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[a].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[a].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[a].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[a].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[a].Ad_Type_code;
bind_pkg_adcat_uom(global_ds.Tables[0].Rows[a].Ad_Type_code);
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[a].Ad_Cat_Code;

if(global_ds.Tables[0].Rows[a].Ad_Cat_Code !=null)
  bind_pkg_adsubcat(global_ds.Tables[0].Rows[a].Ad_Cat_Code);
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[a].Ad_Subcat_code;

document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[a].pub_center;

if(global_ds.Tables[0].Rows[a].No_Of_Edition!=null && global_ds.Tables[0].Rows[a].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[a].No_Of_Edition;
 }
 else
 {
    document.getElementById('noofedi').value="";
 }   
if(global_ds.Tables[0].Rows[a].SPLIT=="" || global_ds.Tables[0].Rows[a].SPLIT==null)
{
        document.getElementById('drpsplit').value="0";
}
else
{
document.getElementById('drpsplit').value=global_ds.Tables[0].Rows[a].SPLIT;
}

if(global_ds.Tables[0].Rows[a].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[a].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[a].CONSUM_PERIOD;
}
/*change bhanu*/
if(global_ds.Tables[0].Rows[a].No_of_inserts==null || global_ds.Tables[0].Rows[a].No_of_inserts=="null")
{
document.getElementById('txtnoofinserts').value="";
}
else
{
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[a].No_of_inserts;
}
//document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[a].No_of_inserts;
///////////////////////////////////////////////////////////////////////////////

//z--;

updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;	
	
	document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						//document.getElementById('btnModify').disabled=false;
						//document.getElementById('btnDelete').disabled=false;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnExit').disabled=false;
						
						
						document.getElementById('drpadtype').disabled=true;
						document.getElementById('drpadcategory').disabled=true;
						document.getElementById('drpsubcategory').disabled=true;
						document.getElementById('noofedi').disabled=true;
						document.getElementById('btnsubmit').disabled=true;
						document.getElementById('drpsplit').disabled=true;
						document.getElementById('txtconsum').disabled=true;
						/*change ankur*/
						document.getElementById('txtnoofinserts').disabled=true;
						/////////////////////
setButtonImages();
return false;

}

function nextclick()
{
//CombinationMaster.firstcomm(call_nextclick);

document.getElementById('btntextcomcode').disabled=true;
						document.getElementById('btextalias').disabled=true;
						document.getElementById('btnpackname').disabled=true;
						document.getElementById('btncomname').disabled=true;




//return false;
//}
//function call_nextclick(response)
//{
var a=parseInt(global_ds.Tables[0].Rows.length);
z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		updateStatus();
		fillcheckboxwhenexecute(global_ds.Tables[0].Rows[z].Edition_Combin_Code,global_ds.Tables[0].Rows[z].Combin_Code );
		document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[z].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[z].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[z].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[z].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[z].Ad_Type_code;
bind_pkg_adcat_uom(global_ds.Tables[0].Rows[z].Ad_Type_code);
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[z].Ad_Cat_Code;

if(global_ds.Tables[0].Rows[z].Ad_Cat_Code !=null)
  bind_pkg_adsubcat(global_ds.Tables[0].Rows[z].Ad_Cat_Code);
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[z].Ad_Subcat_code;

document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].pub_center;

if(global_ds.Tables[0].Rows[z].No_Of_Edition!=null && global_ds.Tables[0].Rows[z].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[z].No_Of_Edition;
 }
 else
 {
    document.getElementById('noofedi').value="";
 }   

if(global_ds.Tables[0].Rows[z].SPLIT=="" || global_ds.Tables[0].Rows[z].SPLIT==null)
{
        document.getElementById('drpsplit').value="0";
}
else
{
document.getElementById('drpsplit').value=global_ds.Tables[0].Rows[z].SPLIT;
}
if(global_ds.Tables[0].Rows[z].No_of_inserts==null || global_ds.Tables[0].Rows[z].No_of_inserts=="null")
{
document.getElementById('txtnoofinserts').value="";
}
else
{
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[z].No_of_inserts;
}
if(global_ds.Tables[0].Rows[z].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[z].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[z].CONSUM_PERIOD;
}
/*change bhanu*/
//document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[z].No_of_inserts;
///////////////////////////////////////////////////////////////////////////////

		document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;

		}
		else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		
	
	
	}
	else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		document.getElementById('btnnext').disabled=false;
			            document.getElementById('btnlast').disabled=false;
		if(z==a-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			}
			
			
			
			            document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						//document.getElementById('btnModify').disabled=false;
						//document.getElementById('btnDelete').disabled=false;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnExit').disabled=false;


                        document.getElementById('drpadtype').disabled=true;
						document.getElementById('drpadcategory').disabled=true;
						document.getElementById('drpsubcategory').disabled=true;
						document.getElementById('noofedi').disabled=true;
						document.getElementById('btnsubmit').disabled=true;
						/*change ankur*/
						document.getElementById('txtnoofinserts').disabled=true;
						document.getElementById('drpsplit').disabled=true;
						document.getElementById('txtconsum').disabled=true;
						
						
						
setButtonImages();
	return false;


}
function previousclick()
{
//CombinationMaster.firstcomm(call_previousclick);

document.getElementById('btntextcomcode').disabled=true;
						document.getElementById('btextalias').disabled=true;
						document.getElementById('btnpackname').disabled=true;
						document.getElementById('btncomname').disabled=true;




//return false;
//}
//function call_previousclick(response)
//{
var a=global_ds.Tables[0].Rows.length;
z--;
if(z != -1)
		{
			if(z >= 0 && z<= a)
			{
			updateStatus();
			fillcheckboxwhenexecute(global_ds.Tables[0].Rows[z].Edition_Combin_Code,global_ds.Tables[0].Rows[z].Combin_Code);
			
			document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[z].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[z].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[z].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[z].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[z].Ad_Type_code;
bind_pkg_adcat_uom(global_ds.Tables[0].Rows[z].Ad_Type_code);
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[z].Ad_Cat_Code;

if(global_ds.Tables[0].Rows[z].Ad_Cat_Code !=null)
  bind_pkg_adsubcat(global_ds.Tables[0].Rows[z].Ad_Cat_Code);
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[z].Ad_Subcat_code;

document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].pub_center;

if(global_ds.Tables[0].Rows[0].No_Of_Edition!=null && global_ds.Tables[0].Rows[0].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[z].No_Of_Edition;
    if(document.getElementById('noofedi').value=='null')
        document.getElementById('noofedi').value="";
}
else
{
    document.getElementById('noofedi').value="";
}
if(global_ds.Tables[0].Rows[z].SPLIT=="" || global_ds.Tables[0].Rows[z].SPLIT==null)
{
        document.getElementById('drpsplit').value="0";
}
else
{
document.getElementById('drpsplit').value=global_ds.Tables[0].Rows[z].SPLIT;
}
if(global_ds.Tables[0].Rows[z].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[z].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[z].CONSUM_PERIOD;
}
/*change bhanu*/
if(global_ds.Tables[0].Rows[z].No_of_inserts==null || global_ds.Tables[0].Rows[z].No_of_inserts=="null")
{
document.getElementById('txtnoofinserts').value="";
}
else
{
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[z].No_of_inserts;
}
//document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[z].No_of_inserts;
///////////////////////////////////////////////////////////////////////////////

			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
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
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		
		document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						//document.getElementById('btnModify').disabled=false;
						//document.getElementById('btnDelete').disabled=false;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnExit').disabled=false;
						
						document.getElementById('drpadtype').disabled=true;
						document.getElementById('drpadcategory').disabled=true;
						document.getElementById('drpsubcategory').disabled=true;
						document.getElementById('noofedi').disabled=true;
						document.getElementById('btnsubmit').disabled=true;
						document.getElementById('drpsplit').disabled=true;
						document.getElementById('txtconsum').disabled=true;
						/*change ankur*/
						document.getElementById('txtnoofinserts').disabled=true;
						/////////////////////////////////////////
setButtonImages();
		return false;	

}
function deleteclick()
{
var comcode=document.getElementById('btntextcomcode').value;
var alias=document.getElementById('btextalias').value;
var packagename=document.getElementById('btnpackname').value;
var combinationname=document.getElementById('btncomname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
 if(confirm("Are You Sure To Delete The Data"))
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
CombinationMaster.deletecomm(comcode,compcode,userid);
 // alert("Value Deleted Sucessfully");
 if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
 // alert(xmlObj.childNodes(0).childNodes(2).text);
  //CombinationMaster.firstcomm(call_deleteclick);
     //call_deleteclick();
 //var oldpkgcode = document.getElementById('txtoldcode').value;
  CombinationMaster.executecomm(gcomcode,galias,gpackagename,gcompcode,guserid,geditiontype,gadtype,gpubcenter,gsplit,"",call_deleteclick);
  }
  return false;
}
function call_deleteclick(response)
{
global_ds=response.value;
	var a=global_ds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("There Is No Data");
			document.getElementById('btntextcomcode').value="";
		    document.getElementById('btextalias').value="";
			document.getElementById('btnpackname').value="";
			document.getElementById('btncomname').value="";
			document.getElementById('drpadtype').value="0";
			document.getElementById('noofedi').value="";
			document.getElementById('btnsubmit').disabled=true;
			document.getElementById('drpadcategory').value="0";
			document.getElementById('drpsubcategory').value="0";
			document.getElementById('txtnoofinserts').value="";
			document.getElementById('txtconsum').value="";
			cancelgrid();
			cancelclick('CombinationMaster');
			document.getElementById('btnsubmit').disabled=true;
			document.getElementById('drpshare').disabled=true;
			document.getElementById('drpshare').value="0";
			return false;
	}
	
	else if(z==-1 ||z>=a)
	{
	fillcheckboxwhenexecute(global_ds.Tables[0].Rows[0].Edition_Combin_Code,global_ds.Tables[0].Rows[0].Combin_Code );
	document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[0].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[0].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[0].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[0].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[0].Ad_Type_code;
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[0].Ad_Cat_Code;
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[0].Ad_Subcat_code;

document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].pub_center;

if(global_ds.Tables[0].Rows[0].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[0].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[0].CONSUM_PERIOD;
}

if(global_ds.Tables[0].Rows[0].No_Of_Edition!=null && global_ds.Tables[0].Rows[0].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[0].No_Of_Edition;
}
else
{
    document.getElementById('noofedi').value=="";
}
/*change ankur*/
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[0].No_of_inserts;
///////////////////////////////////////////////////////////////////////////////
	}
	else
	
		{
		
		fillcheckboxwhenexecute(global_ds.Tables[0].Rows[z].Edition_Combin_Code,global_ds.Tables[0].Rows[z].Combin_Code);
			document.getElementById('btntextcomcode').value=global_ds.Tables[0].Rows[z].Combin_Code ;
document.getElementById('btextalias').value=global_ds.Tables[0].Rows[z].Package_Alias;
document.getElementById('btnpackname').value=global_ds.Tables[0].Rows[z].Package_Name;
document.getElementById('btncomname').value=global_ds.Tables[0].Rows[z].Combin_Desc;
document.getElementById('drpadtype').value=global_ds.Tables[0].Rows[z].Ad_Type_code;
document.getElementById('drpadcategory').value=global_ds.Tables[0].Rows[z].Ad_Cat_Code;
document.getElementById('drpsubcategory').value=global_ds.Tables[0].Rows[z].Ad_Subcat_code;

document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].pub_center;

if(global_ds.Tables[0].Rows[z].No_Of_Edition!=null && global_ds.Tables[0].Rows[0].No_Of_Edition!="null")
{
    document.getElementById('noofedi').value=global_ds.Tables[0].Rows[z].No_Of_Edition;
}
else
{
    document.getElementById('noofedi').value="";
}

if(global_ds.Tables[0].Rows[z].CONSUM_PERIOD=="" || global_ds.Tables[0].Rows[z].CONSUM_PERIOD==null)
{
        document.getElementById('txtconsum').value="";
}
else
{
document.getElementById('txtconsum').value=global_ds.Tables[0].Rows[z].CONSUM_PERIOD;
}
/*change ankur*/
document.getElementById('txtnoofinserts').value=global_ds.Tables[0].Rows[z].No_of_inserts;
///////////////////////////////////////////////////////////////////////////////

	}
	
	document.getElementById('drpshare').disabled=true;
document.getElementById('btnsubmit').disabled=true;
setButtonImages();
	//updatestatus();
	return false;
}




function fillcheckboxwhenexecute(combdesc,combincode)
{
cancelgrid();
  document.getElementById('getvalofcheck').value=combdesc;


       // alert(document.getElementById("DataGrid1").innerHTML);
       var abc=document.getElementById("DataGrid1").innerHTML;
       //alert(abc);
       var newcombdesc='';
       if(combdesc!=null)
       {
 newcombdesc=combdesc.split("+");
}
       document.getElementById("DataGrid1").disabled=false;  
            for(var q=0;q<newcombdesc.length;q++)
            {
            var i=document.getElementById("DataGrid1").rows.length -1;

            
     for(var j=0;j<i/2;j++)
         {          
            var strv="DataGrid1__ctl_CheckBox1" + j;
            var strv1="DataGrid1__ctl_CheckBox1a" +j;
            var strv2="DataGrid1__ctl_CheckBox1b"+j;
            var strv3="DataGrid1__ctl_CheckBox1c"+j;

            var strv4="DataGrid1__ctl_CheckBox1d"+j;
            var strv5="DataGrid1__ctl_CheckBox1e"+j;
            var strv6="DataGrid1__ctl_CheckBox1f"+j;
            var strv7="DataGrid1__ctl_CheckBox1g"+j;
            //var strv8="DataGrid1__ctl_CheckBox1h"+j;
            var strv9="DataGrid1__ctl_CheckBox1k"+j;



            var len="uniquename"+j;
            var y=0;
//////	        if(document.getElementById(len).getElementsByTagName('table').length>0)
//////             y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;

            
           // if(newcombdesc[q].indexOf(document.getElementById(strv).value)>=0)
           if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv).value)
            {
                if(newcombdesc[q].indexOf("SUN")>=0)
                {
                document.getElementById(strv).checked=true;
                
                        for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1" +w).disabled==false)
                                {
                                document.getElementById(j+ "1" +w).checked=true
                                }
                        }
                
                }
                
            }
            
             //if(newcombdesc[q].indexOf(document.getElementById(strv1).value)>=0)
             if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv1).value)
            {
                if(newcombdesc[q].indexOf("Mon")>=0)
                {
                document.getElementById(strv1).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1a" +w).disabled==false)
                                {
                                document.getElementById(j+ "1a" +w).checked=true
                                }
                        }
                }
            }
            
             //if(newcombdesc[q].indexOf(document.getElementById(strv2).value)>=0)
             if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv2).value)
            {
                if(newcombdesc[q].indexOf("Tue")>=0)
                {
                document.getElementById(strv2).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1b" +w).disabled==false)
                                {
                                document.getElementById(j+ "1b" +w).checked=true
                                }
                        }
                }
            }
            
           //  if(newcombdesc[q].indexOf(document.getElementById(strv3).value)>=0)
            if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv3).value)
            {
                if(newcombdesc[q].indexOf("Wed")>=0)
                {
                document.getElementById(strv3).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1c" +w).disabled==false)
                                {
                                document.getElementById(j+ "1c" +w).checked=true
                                }
                        }
                }
            }
            
            // if(newcombdesc[q].indexOf(document.getElementById(strv4).value)>=0)
              if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv4).value)
            {
                if(newcombdesc[q].indexOf("Thu")>=0)
                {
                document.getElementById(strv4).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1d" +w).disabled==false)
                                {
                                document.getElementById(j+ "1d" +w).checked=true
                                }
                        }
                }
            }
            
          //  if(newcombdesc[q].indexOf(document.getElementById(strv5).value)>=0)
           if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv5).value)
            {
                if(newcombdesc[q].indexOf("Fri")>=0)
                {
                document.getElementById(strv5).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1e" +w).disabled==false)
                                {
                                document.getElementById(j+ "1e" +w).checked=true
                                }
                        }
                }
            }
            
           // if(newcombdesc[q].indexOf(document.getElementById(strv6).value)>=0)
           if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv6).value)
            {
                if(newcombdesc[q].indexOf("Sat")>=0)
                {
                document.getElementById(strv6).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1f" +w).disabled==false)
                                {
                                document.getElementById(j+ "1f" +w).checked=true
                                }
                        }
                }
            }
            ///////////////for focus day chk
            
            //if(newcombdesc[q].indexOf(document.getElementById(strv7).value)>=0)
             if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv7).value)
            {
                if(newcombdesc[q].indexOf("FocusDay")>=0)
                {
                document.getElementById(strv7).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1g" +w).disabled==false)
                                {
                                document.getElementById(j+ "1g" +w).checked=true
                                }
                        }
                }
            }
            
            
            
            ///////for any day check
           // if(newcombdesc[q].indexOf(document.getElementById(strv9).value)>=0)
            if(newcombdesc[q].substring(0,newcombdesc[q].lastIndexOf("("))==document.getElementById(strv9).value)
            {
                if(newcombdesc[q].indexOf("AnyDay")>=0)
                {
                document.getElementById(strv9).checked=true;
                
                for(var w=0;w<y-1;w++)
                        {
                                if(document.getElementById(j+ "1k" +w).disabled==false)
                                {
                                document.getElementById(j+ "1k" +w).checked=true
                                }
                        }
                }
            }
            ///////////////////////////////////
            
            
            
                       
            
    }
    
    
    
     
//        var page=combdesc;
//        
//		var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		xml.Open( "GET","bindimagecheck.aspx?page="+page, false );
//		xml.Send();
//		var id=xml.responseText;
//		
//            
            
  }
  
  //////////////////to get triple chk box check in case of execute
         var page=combincode;
         var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","bindimagecheck.aspx?page="+page, false);
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
		xml.Open( "GET","bindimagecheck.aspx?page="+page, false );
		xml.Send();
		var id=xml.responseText;
		}
		var idsplit=id.split(",");
		idsplit=idsplit.reverse();
		
  
  
            var grid=document.getElementById("DataGrid1");
           
            var cont=document.getElementById("DataGrid1").rows.length -1;
            var f;
            var chkforOR=0;
            for(f=0;f<=cont;f++)
            {
            if(f%2!=0)
            {
             var nameofedition=grid.rows[f].cells[2].innerHTML; 
             
             for(var k=0;k<=idsplit.length-1;k++)
             {
             
//                if(chkforOR==1)
//                {
//                    if(nameofedition==RTrim(trim(idsplit[k].replace("or",""))))
//                    {
//                        var x=(parseInt(f)+1)/2;
//                        var t=parseInt(x)-1;
//                        var id1="imgtri" + t;
//                        document.getElementById(id1).src=document.getElementById(id1).src.replace("UnChecked","Checked");
//                    }
//                }
//                else
//                {
                    var indexof=RTrim(trim(idsplit[k])).indexOf("or");
                    if(indexof<0)
                    {
                        if(nameofedition==RTrim(trim(idsplit[k])))
                        {
                       
                        var x=(parseInt(f)+1)/2;
                        var t=parseInt(x)-1;
                        var id1="imgtri" + t;
                        document.getElementById(id1).src=document.getElementById(id1).src.replace("UnChecked","UnDefined");
                        }
                    
                    }
                    if(indexof>=0)
                    {
                        if(nameofedition==RTrim(trim(idsplit[k].replace("or",""))))
                        {
                        var x=(parseInt(f)+1)/2;
                        var t=parseInt(x)-1;
                        var id1="imgtri" + t;
                        document.getElementById(id1).src=document.getElementById(id1).src.replace("UnChecked","Checked");
                        chkforOR=1;
                        }
                    
                    }
               // }
             }
             
            }
            
            }
            
            
  
  
   document.getElementById("DataGrid1").disabled=true;
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





function autoornot()
 {
 
// if(document.getElementById('hidenvarupdate').value=="0")
// {
// var packname=document.getElementById('btnpackname').value;
// var compcode=document.getElementById('hiddencompcode').value;
// CombinationMaster.chkpackagename(packname,compcode,call_chkpacka);
//    
// }
 document.getElementById('btnpackname').value=trim(document.getElementById('btnpackname').value.toUpperCase())
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    return ;
    }
else
    {
    userdefine();

    return false;
    }
return false;
}

//function call_chkpacka(response)
//{
//    var ds=response.value;
//    if(ds.Tables[0].Rows.length > 0)
//    {
//        alert("This Package Name Has Already Been Assigned");
//        return false;
//    }
//}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(document.getElementById('hidenvarupdate').value=="0")
			{
	
            uppercase3();
           
           }
            else
            {
            //document.getElementById('txtstatename').value=document.getElementById('txtstatename').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		    if(document.getElementById('btnpackname').value!="")
            {
                if(document.getElementById('drpadtype').value=="0")
                {
                    alert("Please select Ad Type");
                    document.getElementById('btnpackname').value="";
                    document.getElementById('drpadtype').focus();
                    return false;
                }
                //document.getElementById('btnpackname').value=document.getElementById('btnpackname').value.toUpperCase();
	            document.getElementById('btextalias').value=document.getElementById('btnpackname').value;
	            str = trim(document.getElementById('btnpackname').value.toUpperCase());
	            str = str.replace(/,/gi, '');
	            str = str.replace(/&/gi, '');
	            str = str.replace('+', '');
	            str = str.replace('+', '');
		        CombinationMaster.chkstatcodename(str,document.getElementById('drpadtype').value,document.getElementById('drppubcenter').value,fillcall);
		        return false;
            }
		       
               
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		   if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Package Name Has Already Been Assigned !! ");
		    document.getElementById('btnpackname').value="";
		    document.getElementById('btextalias').value="";
		    document.getElementById('btnpackname').focus();
    		
		    return false;
		    }
		
		        else
		       {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Combin_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;//.substr(2,4);
		                        str=str.toUpperCase();
		                        code++;
		                        document.getElementById('btntextcomcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                           str=str.toUpperCase();
		                          document.getElementById('btntextcomcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(document.getElementById('hidenvarupdate').value=="0")
        {
        if(document.getElementById('drpadtype').value=="0")
        {
            alert("Please select Ad Type");
            document.getElementById('btnpackname').value="";
            document.getElementById('drpadtype').focus();
            return false;
        }
        document.getElementById('btntextcomcode').disabled=false;
        document.getElementById('btnpackname').value=document.getElementById('btnpackname').value.toUpperCase();
        document.getElementById('btextalias').value=document.getElementById('btnpackname').value;
        auto=document.getElementById('hiddenauto').value;
        str=trim(document.getElementById('btnpackname').value);
		CombinationMaster.chkstatcodename(str,document.getElementById('drpadtype').value,document.getElementById('drppubcenter').value,fillcalluser);
         return false;
        }

return false;
}
function checkuncheckfocusday(str,j,a)
{
var stra =parseInt(j,10)+1 + parseInt(a,10);
        var stra1 =j+"1a" + a;
        var stra2 =j+"1b" + a;
        var stra3 =j+"1c" + a;
        var stra4 =j+"1d" + a;
        var stra5 =j+"1e" + a;
        var stra6 =j+"1f" + a;
        var stra7 =j+"1g" + a;
        //var stra8 =j+"1h" + a;
        var stra9 =j+"1k" + a;

if(document.getElementById(str).checked==true)
{
//alert(str);
var len="uniquename"+j;
var str1="DataGrid1__ctl_CheckBox"+"1g"+ j;
var y=0;
////////	if(document.getElementById(len).getElementsByTagName('table').length>0)
////////         y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
 // var stra1=j+ val +w;
 var chk_box=0;
 for(var w=0;w<y-1;w++)
	    {
	    var stra1=j+ "1g" +w;
    if(document.getElementById(stra1).disabled==false)
    {
         //var str="DataGrid1__ctl_CheckBox"+val+ j;
	         if(document.getElementById(stra1).checked==true)
	         {
	            if(chk_box==0)
	            {
	        	document.getElementById(str1).checked=true;
	        	chk_box=0;
	        	   	
                }
                 
               
                
                
                
                
	     }
	     else
	     {
	     chk_box=1;
	        if(document.getElementById(stra1).checked==false)
	        {
	     document.getElementById(str1).checked=false;
	     //document.getElementById(j+ "1g" +w).checked=false;
	        }
	     }
	}
	    }
	
                                    
        
        
}


if(document.getElementById(str).checked==false)
{

document.getElementById(stra7).checked=false;

	
	var str6="DataGrid1__ctl_CheckBox1g"+j;
	document.getElementById(str6).checked=false;
	
//	
}
}

function focusadcat()
{
if(document.getElementById('drpadcategory').disbled==false)
    {
        document.getElementById('drpadcategory').focus();
        
    }
}


function selectdays(j)
{
    //var i=document.getElementById("DataGrid1").rows.length -1;
    //for(j=0;j<i/2;j++)
	//{
	
    var str="DataGrid1__ctl_CheckBox1"+j;
    var str1="DataGrid1__ctl_CheckBox1a" + j;
    var str2="DataGrid1__ctl_CheckBox1b" + j;
    var str3="DataGrid1__ctl_CheckBox1c" + j;
    var str4="DataGrid1__ctl_CheckBox1d" + j;
    var str5="DataGrid1__ctl_CheckBox1e" + j;
    var str6="DataGrid1__ctl_CheckBox1f" + j;
    var str7="DataGrid1__ctl_CheckBox1g" + j;
    //var str8="DataGrid1__ctl_CheckBox1h" + j;
    var str9="DataGrid1__ctl_CheckBox1k" + j;
    
    if(document.getElementById(str).checked==true)
    {
        gsun[j]="Y";
        gediname[j]=document.getElementById(str).value;
    }
    else
    {
        gsun[j]="N";
    }
    
    if(document.getElementById(str1).checked==true)
    {
        gmon[j]="Y";
        gediname[j]=document.getElementById(str1).value;
    }
    else
    {
        gmon[j]="N";
    }
    
    if(document.getElementById(str2).checked==true)
    {
        gtue[j]="Y";
        gediname[j]=document.getElementById(str2).value;
    }
    else
    {
        gtue[j]="N";
    }
    
    if(document.getElementById(str3).checked==true)
    {
        gwed[j]="Y";
        gediname[j]=document.getElementById(str3).value;
    }
    else
    {
        gwed[j]="N";
    }
    
    if(document.getElementById(str4).checked==true)
    {
        gthu[j]="Y";
        gediname[j]=document.getElementById(str4).value;
    }
    else
    {
        gthu[j]="N";
    }
    
    if(document.getElementById(str5).checked==true)
    {
        gfri[j]="Y";
        gediname[j]=document.getElementById(str5).value;
    }
    else
    {
        gfri[j]="N";
    }
    
    if(document.getElementById(str6).checked==true)
    {
        gsat[j]="Y";
        gediname[j]=document.getElementById(str6).value;
    }
    else
    {
        gsat[j]="N";
    }
    
    if(document.getElementById(str7).checked==true)
    {
        gfocus[j]="Y";
        gediname[j]=document.getElementById(str7).value;
    }
    else
    {
        gfocus[j]="N";
    }
    
    if(document.getElementById(str9).checked==true)
    {
        gallday[j]="Y";
        gediname[j]=document.getElementById(str9).value;
    }
    else
    {
        gallday[j]="N";
    }
	//}
}


function savedays()
{
    var compcode=document.getElementById("hiddencompcode").value;
    var combincode=document.getElementById("btntextcomcode").value;
    var cnt=0;
    if(btnsubmitclk==1)
    {
        for(var i=0;i<gsun.length;i++)
        {
            if(gediname[i]!=null)
            {
                var ediname1="";
                ediname1=gediname[i].toString();
                var sun=gsun[i].toString();
                var mon=gmon[i].toString();
                var tue=gtue[i].toString();
                var wed=gwed[i].toString();
                var thu=gthu[i].toString();
                var fri=gfri[i].toString();
                var sat=gsat[i].toString();
                var focus=gfocus[i].toString();
                var allday=gallday[i].toString();
                CombinationMaster.savedays1(compcode,combincode,ediname1,sun,mon,tue,wed,thu,fri,sat,focus,allday,cnt);
                cnt++;
            }
        }
    }
    btnsubmitclk=0;
}

function chkchar(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which == 44) || (event.shiftKey == true && event.which == 38) || (event.shiftKey == true && event.which == 43) || (event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 9 || event.which == 8 || event.which == 0 || event.which == 32) || (event.which >= 65 && event.which <= 90) || event.which == 45 || event.which == 95)
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
    if ((event.keyCode == 44)||(event.shiftKey == true && event.keyCode == 38) || (event.shiftKey == true && event.keyCode == 43) || (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || event.keyCode == 45 || event.keyCode == 95)
	{
		return true;
	}
	else
	{
		return false;
	}
}	
}



function fillcalluser(res)
{
    var ds=res.value;
    if(ds.Tables[0].Rows.length!=0)
    {
        alert("This Package Name Has Already Been Assigned !! ");
        document.getElementById('btnpackname').value="";
        document.getElementById('btextalias').value="";
        document.getElementById('btnpackname').focus();
        return false;
    }
}

function chkradiopkg()
{
    var values1="";
    var len=parseInt(document.getElementById('btnoptionbutton').getElementsByTagName('TBODY')[0].getElementsByTagName('TR')[0].getElementsByTagName('TD').length);

    
    
    for(var rdcount=0;rdcount<len;rdcount++)
    {
        var rdid='btnoptionbutton_'+rdcount;
        if(document.getElementById(rdid).checked==true)
        {
            values1=document.getElementById(rdid).value;
            break;
        }
    }
    
    
    if(document.getElementById("drpadtype").value=="0" && values1=="4")
    {
        alert("Please Select Ad Type");
        if(document.getElementById("drpadtype").disabled==false)
        document.getElementById("drpadtype").focus();
        return false;
    }
    
}
function checkedition()
{
   if(document.getElementById('noofedi').value!="" && gettotaledi!="")
   {
        if(parseInt(document.getElementById('noofedi').value,10)>parseInt(gettotaledi,10))
        {
            alert("No Of Edition can't be greater than selected Edition's");
            return false;
        }
  } 
}


//-------------------- ad by rinki (bind adcategory on adtype change)--------------------------------//

function onchage_adtype()
{
    var adtype = document.getElementById("drpadtype").value;
    //document.getElementById("hiddenadtype").Value = document.getElementById("drpadtype").value;
    
    var drpadcat=document.getElementById("drpadcategory");
    var drpsubcategory=document.getElementById("drpsubcategory");
  
    
       
    drpadcat.options.length=0;
    drpadcat.options[0]=new Option("--Select Category--","0");
    
    drpsubcategory.options.length=0;
    drpsubcategory.options[0]=new Option("--Select Sub Category--","0");
    
      
    if(adtype!="0")
        bind_pkg_adcat_uom(adtype);
    return false;
}

function bind_pkg_adcat_uom(adtype)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var center="0";//document.getElementById("drppubcenter").value;
    var res=CombinationMaster.pkg_adcat_uom_bind(compcode, adtype, center);
    var ds=res.value;
    
    var drpadcat=document.getElementById("drpadcategory");

 
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
        
       
    }
}

//============================ bind subcategory on the basis of adcategory=======================================//

function bind_pkg_adsubcat(adcat)
{
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    var center="0";//document.getElementById("drppubcenter").value;
    var res=CombinationMaster.bindSubCat(compcode, userid, adcat);
    var ds=res.value;
    
    var drpadsubcat=document.getElementById("drpsubcategory");
    var ds=res.value;
    var pkgitem = document.getElementById("drpsubcategory");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        pkgitem.options[0]=new Option("-Select Adv  sub  Category-","0");
         for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Adv_Subcat_Name,res.value.Tables[0].Rows[i].Adv_Subcat_Code);
            
           pkgitem.options.length;
           
        }
    }
}
//===========  For Adon Popup =====================//
var popUpWin2=null;
function  adon()
{ 

  if(document.getElementById('lbaddon').disabled==true && document.getElementById("hiddenshow").value != "2")
  {
  return false;
  }
 
//  var pkgcode=document.getElementById('drppkgcode').value;
//	var ratecode=document.getElementById('txtratecode').value;
//	var pkgdesc=document.getElementById('txtpkgdesc').value;
	var saveormodify="";//document.getElementById('hiddenforfrid').value;
	var show=document.getElementById('hiddenshow').value;
	var adtype1 = document.getElementById('drpadtype').value;
	popUpWin2 = window.open('Combin_Addon.aspx?pkgcode=' + trim(document.getElementById('btntextcomcode').value) + '&adtype=' + adtype1 + '&pkgdesc=' + "" + '&savemodify=' + saveormodify + '&show=' + show, 'Bhati', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=244,left=210,width=780px,height=415px'); 
  popUpWin2.focus();
//     }
     return false;
 

} 

function saveclickrate()
{

// if(document.getElementById('drppub').value=="0")
//{
//alert("Please Select The Publication");
//document.getElementById('drppub').focus();
//return false;
//}
//else 
if(document.getElementById('drpedition').value=="0")
{
alert("Please Select The Edition");
document.getElementById('drpedition').focus();
return false;
}var iz = 0;
 //if (document.getElementById("DataGrid1") == null) {

//    iz = document.getElementById("DataGrid2").rows.length;
//    if (iz > 1) {
//        alert("Only One Record is Allowed.");
//        return false;
//    }
//}
//else {
//    iz = document.getElementById("DataGrid1").rows.length;
//    if (iz > 2 && flag2 == "0") {
//        alert("Only One Record is Allowed.");
//        return false;
//    }
//}

var PCOMP_CODE = document.getElementById('hiddencomcode').value;
var PCOMBIN_CODE = document.getElementById('hiddencombincode').value;
    var PPACKAGE_CODE=document.getElementById('drpedition').value;
    var PPUBLICATION=document.getElementById('drppub').value;
    var PNO_OF_INSERT=document.getElementById('txtnoofinsert').value;
    var PUSERID=document.getElementById('hiddenuserid').value;
    var PTRN_TYPE = "";
    var PACKAGE_NAME = "";
    if (document.getElementById('drpedition').value != "0")
        PACKAGE_NAME = document.getElementById('drpedition').options[document.getElementById('drpedition').selectedIndex].text;
    var PADON_CODE = document.getElementById('hiddencode').value;

    if (window.opener.document.getElementById("hiddenshow").value == "1")
       {
            if(flag2=="1")
            {
                PTRN_TYPE="U";
                Combin_Addon.insupddelcombinadon(PCOMP_CODE, PCOMBIN_CODE, PADON_CODE, PPACKAGE_CODE, PPUBLICATION, PNO_OF_INSERT, PUSERID, PTRN_TYPE, PACKAGE_NAME);
                window.location=window.location;
                return false;
            }
            else
            {
                PTRN_TYPE="I";
                Combin_Addon.insupddelcombinadon(PCOMP_CODE, PCOMBIN_CODE, "", PPACKAGE_CODE, PPUBLICATION, PNO_OF_INSERT, PUSERID, PTRN_TYPE, PACKAGE_NAME);
                window.location=window.location;
                return false;
            }
       }
       else
       {
           //retainercommsstructure.setviewstatevalue();
		    return ;
       }
       
}
function selectcomm(ab)
{

//if(document.getElementById('hiddenshow').value=="2")
    flag2 = "1";
    document.getElementById('drppub').disabled = true;
    document.getElementById('drpedition').disabled = true;
    
    if(document.getElementById(ab).checked==false)
    {
    flag2="0";
    document.getElementById(ab).checked=false;
    document.getElementById('drppub').value="0";
    document.getElementById('drpedition').value="0";
     document.getElementById('txtnoofinsert').value="";
     document.getElementById('btndelete').disabled = true;
     document.getElementById('drppub').disabled = false;
     document.getElementById('drpedition').disabled = false;
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
      if(kz==1) {
          //var res1 =
          Combin_Addon.getdata12(compcode, code11, call_comm);
	     // call_comm(res1);
	    return ;
	  }
	  
    
return false;
//}//end of execute click mode -----> next is for modify click mode-->
if(document.getElementById(ab).checked==false)
{
document.getElementById(ab).checked=false;
document.getElementById('drppub').value="0";
document.getElementById('drpedition').value="0";
 document.getElementById('txtnoofinsert').value="";
 document.getElementById('btndelete').disabled=true;
return; 
}


}
function call_comm(res11) {
    var ds = res11.value;
    if (ds.Tables[0].Rows.length > 0) {
        document.getElementById('drppub').value = ds.Tables[0].Rows[0].Pubcode;
        document.getElementById('drpedition').options.length = 0;
        document.getElementById('drpedition').options[0] = new Option(ds.Tables[0].Rows[0].PACKAGE_NAME, ds.Tables[0].Rows[0].Edition_code);
        document.getElementById('drpedition').value = ds.Tables[0].Rows[0].Edition_code;
        document.getElementById('txtnoofinsert').value = ds.Tables[0].Rows[0].NO_OF_INSERT;
    }
    return false;
}
function saveadonpopup()
{
//    var PCOMP_CODE=document.getElementById('hiddencomcode').value;
    var PCOMBIN_CODE=trim(document.getElementById('btntextcomcode').value);
//    var PADON_CODE=document.getElementById('hiddenrateuniqueid').value; 
//    var PPACKAGE_CODE=document.getElementById('drpedition').value;
//    var PPUBLICATION=document.getElementById('drppub').value;
//    var PNO_OF_INSERT=document.getElementById('txtnoofinsert').value;
//    var PUSERID=document.getElementById('hiddenuserid').value;
//    var PTRN_TYPE="";
               
    CombinationMaster.insertcombinadonsession(PCOMBIN_CODE);//PCOMP_CODE,PCOMBIN_CODE,PADON_CODE,PPACKAGE_CODE,PPUBLICATION,PNO_OF_INSERT,PUSERID,PTRN_TYPE);
//    window.location=window.location;
               
return false;
}

//================================***************=============================//
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
/*----------------------*/
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

