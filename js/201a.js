
/*************************** for background color******************************/
function getScrollY()
{
    var scrOfX = 0,scrOfY=0;
    if(typeof(window.pageYOffset)=='number')
    {
        scrOfY=window.pageYOffset;scrOfX=window.pageXOffset;
    }
    else if(document.body&&(document.body.scrollLeft||document.body.scrollTop))
    {
        scrOfY=document.body.scrollTop;scrOfX=document.body.scrollLeft;
    }
    else if(document.documentElement&&(document.documentElement.scrollLeft||document.documentElement.scrollTop))
    {
        scrOfY=document.documentElement.scrollTop;scrOfX=document.documentElement.scrollLeft;
    }
    return scrOfY;
}
document.write("<style type='text/css'>.colorpicker201{visibility:hidden;display:none;position:absolute;background:#FFF;border:solid 1px #CCC;padding:4px;z-index:999;filter:progid:DXImageTransform.Microsoft.Shadow(color=#D0D0D0,direction=135);}.o5582brd{padding:0;width:12px;height:14px;border-bottom:solid 1px #DFDFDF;border-right:solid 1px #DFDFDF;}a.o5582n66,.o5582n66,.o5582n66a{font-family:arial,tahoma,sans-serif;text-decoration:underline;font-size:9px;color:#666;border:none;}.o5582n66,.o5582n66a{text-align:center;text-decoration:none;}a:hover.o5582n66{text-decoration:none;color:#FFA500;cursor:pointer;}.a01p3{padding:1px 4px 1px 2px;background:whitesmoke;border:solid 1px #DFDFDF;}</style>");
function getTop2()
    {
        csBrHt=0;
        if(typeof(window.innerWidth)=='number')
        {
            csBrHt=window.innerHeight;
        }
        else if(document.documentElement&&(document.documentElement.clientWidth||document.documentElement.clientHeight))
        {
            csBrHt=document.documentElement.clientHeight;
        }
        else if(document.body&&(document.body.clientWidth||document.body.clientHeight))
        {
            csBrHt=document.body.clientHeight;
            }
        ctop=((csBrHt/2)-115)+getScrollY();
        return ctop;
    }
    var nocol1="&#78;&#79;&#32;&#67;&#79;&#76;&#79;&#82;",clos1="&#67;&#76;&#79;&#83;&#69;",tt2="&#70;&#82;&#69;&#69;&#45;&#67;&#79;&#76;&#79;&#82;&#45;&#80;&#73;&#67;&#75;&#69;&#82;&#46;&#67;&#79;&#77;",hm2="&#104;&#116;&#116;&#112;&#58;&#47;&#47;&#119;&#119;&#119;&#46;";
    hm2+=tt2;   
    tt2="&#80;&#79;&#87;&#69;&#82;&#69;&#68;&#32;&#98;&#121;&#32;&#70;&#67;&#80;";
    function getLeft2()
    {
        var csBrWt=0;
        if(typeof(window.innerWidth)=='number')
        {
            csBrWt=window.innerWidth;
        }
        else if(document.documentElement&&(document.documentElement.clientWidth||document.documentElement.clientHeight))
        {   
            csBrWt=document.documentElement.clientWidth;
        }
        else if(document.body&&(document.body.clientWidth||document.body.clientHeight))
        {
            csBrWt=document.body.clientWidth;
        }
        cleft=(csBrWt/2)-125;
        return cleft;
    }
    function setCCbldID2(objID,val)
    {
        document.getElementById(objID).value=val;
    }
    function setCCbldSty2(objID,prop,val)
    {
   
    switch(prop)
    {
        case "bc":if(objID!='null' && objID!='editordiv')/**/
        {
            document.getElementById(objID).style.backgroundColor=val;
            document.getElementById('sampleclrbckT').style.backgroundColor=val;
            document.getElementById('sampleclrbckP').style.backgroundColor=val;
            document.getElementById('sampleclrbckL').style.backgroundColor=val;
        };
        break;
        case "vs":document.getElementById(objID).style.visibility=val;
        break;
        case "ds":document.getElementById(objID).style.display=val;
        break;
        case "tp":document.getElementById(objID).style.top=val;
        break;
        case "lf":document.getElementById(objID).style.left=val;
        break;
    }
}
function putOBJxColor2(OBjElem,Samp,pigMent)
{
//if(Samp=="outer")
//{
//    alert('You cannot fill the color Here')
//    return ;
//}
//else
//{
    if(pigMent!='x')
    {
        setCCbldID2(OBjElem,pigMent);
        setCCbldSty2(Samp,'bc',pigMent);
    }
    setCCbldSty2('colorpicker201','vs','hidden');
    setCCbldSty2('colorpicker201','ds','none');
}
//}
function showColorGrid2(OBjElem,Sam)
{
    var objX=new Array('00','33','66','99','CC','FF');
    var c=0;
    var z='"'+OBjElem+'","'+document.getElementById('myhdnval').value+'",""';
    var xl='"'+OBjElem+'","'+document.getElementById('myhdnval').value+'","x"';
    var mid='';mid+='<table bgcolor="#FFFFFF" border="0" cellpadding="0" cellspacing="0" style="border:solid 0px #F0F0F0;padding:2px;"><tr>';
    mid+="<td colspan='18' align='left' style='font-size:10px;background:#6666CC;color:#FFF;font-family:arial;'>&nbsp;BackGround Color Selection Palette</td></tr><tr><td colspan='18' align='center' style='margin:0;padding:2px;height:12px;' ><input class='o5582n66' type='text' size='12' id='o5582n66' value='#FFFFFF'><input class='o5582n66a' type='text' size='2' style='width:14px;' id='o5582n66a' onclick='javascript:alert(\"click on selected swatch below !\");' value='' style='border:solid 1px #666;'>&nbsp;|&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColor2("+z+")'><span class='a01p3'>"+nocol1+"</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColor2("+xl+")'><span class='a01p3'>"+clos1+"</span></a></td></tr><tr>";
    var br=1;
    for(o=0;o<6;o++)
    {
        mid+='</tr><tr>';
        for(y=0;y<6;y++)
        {
            if(y==3)
            {
                mid+='</tr><tr>';
            }
            for(x=0;x<6;x++)
            {
                var grid='';
                grid=objX[o]+objX[y]+objX[x];
                var b="'"+OBjElem+"', '"+document.getElementById('myhdnval').value+"','#"+grid+"'";
                mid+='<td class="o5582brd" style="background-color:#'+grid+'"><a class="o5582n66"  href="javascript:onclick=putOBJxColor2('+b+');" onmouseover=javascript:document.getElementById("o5582n66").value="#'+grid+'";javascript:document.getElementById("o5582n66a").style.backgroundColor="#'+grid+'";  title="#'+grid+'"><div style="width:12px;height:14px;"></div></a></td>';
                c++;
            }
        }
    }
    mid+="</tr><tr><td colspan='18' align='right' style='padding:2px;border:solid 1px #FFF;background:#FFF;'><a href='#' style='color:#FFFFFF;font-size:8px;font-family:arial;text-decoration:none;letter-spacing:1px;'>"+tt2+"</a></td></tr></table>";
    var ttop=getTop2();
    setCCbldSty2('colorpicker201','tp',ttop);
    document.getElementById('colorpicker201').style.left=getLeft2();
    setCCbldSty2('colorpicker201','vs','visible');
    setCCbldSty2('colorpicker201','ds','block');
    document.getElementById('colorpicker201').innerHTML=mid;
}
/************for the font color *******************/
function showColorGrid1(OBjElem,Sam)
{
    var objX=new Array('00','33','66','99','CC','FF');
    var c=0;
    var z='"'+OBjElem+'","'+Sam+'",""';
    var xl='"'+OBjElem+'","'+Sam+'","x"';
    var mid='';mid+='<table bgcolor="#FFFFFF" border="0" cellpadding="0" cellspacing="0" style="border:solid 0px #F0F0F0;padding:2px;"><tr>';
    mid+="<td colspan='18' align='left' style='font-size:10px;background:#6666CC;color:#FFF;font-family:arial;'>&nbsp;Font Color Selection Palette</td></tr><tr><td colspan='18' align='center' style='margin:0;padding:2px;height:12px;' ><input class='o5582n66' type='text' size='12' id='o5582n66' value='#FFFFFF'><input class='o5582n66a' type='text' size='2' style='width:14px;' id='o5582n66a' onclick='javascript:alert(\"click on selected swatch below...\");' value='' style='border:solid 1px #666;'>&nbsp;|&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColor1("+z+")'><span class='a01p3'>"+nocol1+"</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColor1("+xl+")'><span class='a01p3'>"+clos1+"</span></a></td></tr><tr>";
    var br=1;
    for(o=0;o<6;o++)
    {
        mid+='</tr><tr>';
        for(y=0;y<6;y++)
        {
            if(y==3)
            {
                mid+='</tr><tr>';
            }
            for(x=0;x<6;x++)
            {
                var grid='';
                grid=objX[o]+objX[y]+objX[x];
                var b="'"+OBjElem+"', '"+document.getElementById('myhdnval').value+"','#"+grid+"'";
                mid+='<td class="o5582brd" style="background-color:#'+grid+'"><a class="o5582n66"  href="javascript:onclick=putOBJxColor1('+b+');" onmouseover=javascript:document.getElementById("o5582n66").value="#'+grid+'";javascript:document.getElementById("o5582n66a").style.backgroundColor="#'+grid+'";  title="#'+grid+'"><div style="width:12px;height:14px;"></div></a></td>';
                c++;
            }
        }
    }
    mid+="</tr><tr><td colspan='18' align='right' style='padding:2px;border:solid 1px #FFF;background:#FFF;'><a href='#' style='color:#FFFFFF;font-size:8px;font-family:arial;text-decoration:none;letter-spacing:1px;'>"+tt2+"</a></td></tr></table>";
    var ttop=getTop2();
    setCCbldSty1('colorpicker201','tp',ttop);
    document.getElementById('colorpicker201').style.left=getLeft2();
    setCCbldSty1('colorpicker201','vs','visible');
    setCCbldSty1('colorpicker201','ds','block');
    document.getElementById('colorpicker201').innerHTML=mid;
}
function setCCbldSty1(objID,prop,val)
    {
    switch(prop)
    {
        case "bc":if(objID!='null'&& objID!='editordiv')
        {
           document.getElementById(objID).style.color=val;
           document.getElementById('sampleclrfont').style.backgroundColor=val;
        };
        break;
        case "vs":document.getElementById(objID).style.visibility=val;
        break;
        case "ds":document.getElementById(objID).style.display=val;
        break;
        case "tp":document.getElementById(objID).style.top=val;
        break;
        case "lf":document.getElementById(objID).style.left=val;
        break;
    }
}
function putOBJxColor1(OBjElem,Samp,pigMent)
{
    if(pigMent!='x')
    {
        setCCbldID1(OBjElem,pigMent);
        setCCbldSty1(Samp,'bc',pigMent);
    }
    setCCbldSty1('colorpicker201','vs','hidden');
    setCCbldSty1('colorpicker201','ds','none');
}
function setCCbldID1(objID,val)
    {
        document.getElementById(objID).value=val;
    }
    
/*************************** for border color******************************/
  
  
function showColorGrid3(OBjElem,Sam)
{
    var objX=new Array('00','33','66','99','CC','FF');
    var c=0;
    var z='"'+OBjElem+'","'+document.getElementById('myhdnval').value+'",""';
    var xl='"'+OBjElem+'","'+document.getElementById('myhdnval').value+'","x"';
    var mid='';mid+='<table bgcolor="#FFFFFF" border="0" cellpadding="0" cellspacing="0" style="border:solid 0px #F0F0F0;padding:2px;"><tr>';
    mid+="<td colspan='18' align='left' style='font-size:10px;background:#6666CC;color:#FFF;font-family:arial;'>&nbsp;Border Color Selection Palette</td></tr><tr><td colspan='18' align='center' style='margin:0;padding:2px;height:12px;' ><input class='o5582n66' type='text' size='12' id='o5582n66' value='#FFFFFF'><input class='o5582n66a' type='text' size='2' style='width:14px;' id='o5582n66a' onclick='javascript:alert(\"click on selected swatch below...\");' value='' style='border:solid 1px #666;'>&nbsp;|&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColor3("+z+")'><span class='a01p3'>"+nocol1+"</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColor3("+xl+")'><span class='a01p3'>"+clos1+"</span></a></td></tr><tr>";
    var br=1;
    for(o=0;o<6;o++)
    {
        mid+='</tr><tr>';
        for(y=0;y<6;y++)
        {
            if(y==3)
            {
                mid+='</tr><tr>';
            }
            for(x=0;x<6;x++)
            {
                var grid='';
                grid=objX[o]+objX[y]+objX[x];
                var b="'"+OBjElem+"', '"+document.getElementById('myhdnval').value+"','#"+grid+"'";
                mid+='<td class="o5582brd" style="background-color:#'+grid+'"><a class="o5582n66"  href="javascript:onclick=putOBJxColor3('+b+');" onmouseover=javascript:document.getElementById("o5582n66").value="#'+grid+'";javascript:document.getElementById("o5582n66a").style.backgroundColor="#'+grid+'";  title="#'+grid+'"><div style="width:12px;height:14px;"></div></a></td>';
                c++;
            }
        }
    }
    mid+="</tr><tr><td colspan='18' align='right' style='padding:2px;border:solid 1px #FFF;background:#FFF;'><a href='#' style='color:#FFFFFF;font-size:8px;font-family:arial;text-decoration:none;letter-spacing:1px;'>"+tt2+"</a></td></tr></table>";
    var ttop=getTop2();
    setCCbldSty3('colorpicker201','tp',ttop);
    document.getElementById('colorpicker201').style.left=getLeft2();
    setCCbldSty3('colorpicker201','vs','visible');
    setCCbldSty3('colorpicker201','ds','block');
    document.getElementById('colorpicker201').innerHTML=mid;
}
function setCCbldSty3(objID,prop,val)
    {
    switch(prop)
    {
        case "bc":if(objID!='null' && objID!='editordiv')/**/
        {
        document.getElementById(objID).style.borderBottomColor=val;
        document.getElementById(objID).style.borderTopColor=val;
        document.getElementById(objID).style.borderLeftColor=val;
        document.getElementById(objID).style.borderRightColor=val;
        document.getElementById('sampleclrbrdrT').style.backgroundColor=val;
        document.getElementById('sampleclrbrdrP').style.backgroundColor=val;
        };
        break;
        case "vs":document.getElementById(objID).style.visibility=val;
        break;
        case "ds":document.getElementById(objID).style.display=val;
        break;
        case "tp":document.getElementById(objID).style.top=val;
        break;
        case "lf":document.getElementById(objID).style.left=val;
        break;
    }
}
function putOBJxColor3(OBjElem,Samp,pigMent)
{
    if(pigMent!='x')
    {
        setCCbldID3(OBjElem,pigMent);
        setCCbldSty3(Samp,'bc',pigMent);
    }
    setCCbldSty3('colorpicker201','vs','hidden');
    setCCbldSty3('colorpicker201','ds','none');
}
function setCCbldID3(objID,val)
    {
        document.getElementById(objID).value=val;
    }
    /*************************************************************************************************************/
    /************for the tools fore ground color *******************/
function showColorGridT1(OBjElem,Sam)
{

    var objX=new Array('00','33','66','99','CC','FF');
    var c=0;
    var z='"'+OBjElem+'","'+Sam+'",""';
    var xl='"'+OBjElem+'","'+Sam+'","x"';
    var mid='';mid+='<table bgcolor="#FFFFFF" border="0" cellpadding="0" cellspacing="0" style="border:solid 0px #F0F0F0;padding:2px;"><tr>';
    mid+="<td colspan='18' align='left' style='font-size:10px;background:#6666CC;color:#FFF;font-family:arial;'>&nbsp;Fore Color Selection Palette</td></tr><tr><td colspan='18' align='center' style='margin:0;padding:2px;height:12px;' ><input class='o5582n66' type='text' size='12' id='o5582n66' value='#FFFFFF'><input class='o5582n66a' type='text' size='2' style='width:14px;' id='o5582n66a' onclick='javascript:alert(\"click on selected swatch below...\");' value='' style='border:solid 1px #666;'>&nbsp;|&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColorT1("+z+")'><span class='a01p3'>"+nocol1+"</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColorT1("+xl+")'><span class='a01p3'>"+clos1+"</span></a></td></tr><tr>";
    var br=1;
    for(o=0;o<6;o++)
    {
        mid+='</tr><tr>';
        for(y=0;y<6;y++)
        {
            if(y==3)
            {
                mid+='</tr><tr>';
            }
            //alert('ajay2');
            for(x=0;x<6;x++)
            {
                var grid='';
                grid=objX[o]+objX[y]+objX[x];
                var b="'"+OBjElem+"', '"+Sam+"','#"+grid+"'";
                mid+='<td class="o5582brd" style="background-color:#'+grid+'"><a class="o5582n66"  href="javascript:onclick=putOBJxColorT1('+b+');" onmouseover=javascript:document.getElementById("o5582n66").value="#'+grid+'";javascript:document.getElementById("o5582n66a").style.backgroundColor="#'+grid+'";  title="#'+grid+'"><div style="width:12px;height:14px;"></div></a></td>';
                c++;
                //document.getElementById('colorcodeT_F').style.display='none';
                //document.getElementById('colorcodeT_F').style.display='none';
            }
        }
    }
    //document.getElementById('toolsbox_fcolor').disabled=true;
    mid+="</tr><tr><td colspan='18' align='right' style='padding:2px;border:solid 1px #FFF;background:#FFF;'><a href='#' style='color:#FFFFFF;font-size:8px;font-family:arial;text-decoration:none;letter-spacing:1px;'>"+tt2+"</a></td></tr></table>";
    var ttop=getTop2();
    setCCbldStyT1('colorpicker201','tp',ttop);
    document.getElementById('colorpicker201').style.left=getLeft2();
    setCCbldStyT1('colorpicker201','vs','visible');
    setCCbldStyT1('colorpicker201','ds','block');
    document.getElementById('colorpicker201').innerHTML=mid;
    //document.getElementById('toolsbox_fcolor').disabled=true;
    //document.getElementById('colorcodeT_F').style.display='disabled';
    //document.getElementById('toolsbox_fcolor').style.display='none';
}
function setCCbldStyT1(objID,prop,val)
    {
    switch(prop)
    {
        case "bc":if(objID!='null'&& objID!='editordiv')/**/
        {
           document.getElementById(objID).style.color=val;
           document.getElementById('toolsbox_fcolor').style.backgroundColor=val;
        };
        break;
        case "vs":document.getElementById(objID).style.visibility=val;
        break;
        case "ds":document.getElementById(objID).style.display=val;
        break;
        case "tp":document.getElementById(objID).style.top=val;
        break;
        case "lf":document.getElementById(objID).style.left=val;
        break;
    }
}
function putOBJxColorT1(OBjElem,Samp,pigMent)
{
    if(pigMent!='x')
    {
        setCCbldIDT1(OBjElem,pigMent);
        setCCbldStyT1(Samp,'bc',pigMent);
    }
    setCCbldStyT1('colorpicker201','vs','hidden');
    setCCbldStyT1('colorpicker201','ds','none');
}
function setCCbldIDT1(objID,val)
    {
        document.getElementById(objID).value=val;
    }
    
    /************for the tools fore ground color *******************/
function showColorGridT2(OBjElem,Sam)
{
    var objX=new Array('00','33','66','99','CC','FF');
    var c=0;
    var z='"'+OBjElem+'","'+Sam+'",""';
    var xl='"'+OBjElem+'","'+Sam+'","x"';
    var mid='';mid+='<table bgcolor="#FFFFFF" border="0" cellpadding="0" cellspacing="0" style="border:solid 0px #F0F0F0;padding:2px;"><tr>';
    mid+="<td colspan='18' align='left' style='font-size:10px;background:#6666CC;color:#FFF;font-family:arial;'>&nbsp;Back Color Selection Palette</td></tr><tr><td colspan='18' align='center' style='margin:0;padding:2px;height:12px;' ><input class='o5582n66' type='text' size='12' id='o5582n66' value='#FFFFFF'><input class='o5582n66a' type='text' size='2' style='width:14px;' id='o5582n66a' onclick='javascript:alert(\"click on selected swatch below...\");' value='' style='border:solid 1px #666;'>&nbsp;|&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColorT2("+z+")'><span class='a01p3'>"+nocol1+"</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<a class='o5582n66' href='javascript:onclick=putOBJxColorT2("+xl+")'><span class='a01p3'>"+clos1+"</span></a></td></tr><tr>";
    var br=1;
    for(o=0;o<6;o++)
    {
        mid+='</tr><tr>';
        for(y=0;y<6;y++)
        {
            if(y==3)
            {
                mid+='</tr><tr>';
            }
            for(x=0;x<6;x++)
            {
                var grid='';
                grid=objX[o]+objX[y]+objX[x];
                var b="'"+OBjElem+"', '"+Sam+"','#"+grid+"'";
                mid+='<td class="o5582brd" style="background-color:#'+grid+'"><a class="o5582n66"  href="javascript:onclick=putOBJxColorT2('+b+');" onmouseover=javascript:document.getElementById("o5582n66").value="#'+grid+'";javascript:document.getElementById("o5582n66a").style.backgroundColor="#'+grid+'";  title="#'+grid+'"><div style="width:12px;height:14px;"></div></a></td>';
                c++;
            }
        }
    }
    mid+="</tr><tr><td colspan='18' align='right' style='padding:2px;border:solid 1px #FFF;background:#FFF;'><a href='#' style='color:#FFFFFF;font-size:8px;font-family:arial;text-decoration:none;letter-spacing:1px;'>"+tt2+"</a></td></tr></table>";
    var ttop=getTop2();
    setCCbldSty1('colorpicker201','tp',ttop);
    document.getElementById('colorpicker201').style.left=getLeft2();
    setCCbldSty1('colorpicker201','vs','visible');
    setCCbldSty1('colorpicker201','ds','block');
    document.getElementById('colorpicker201').innerHTML=mid;
}
function setCCbldStyT2(objID,prop,val)
    {
       if(document.getElementById('myhdnval').value=="" && objID == "" )
        {
            objID="outer";
            var nh=objID;
                    while(nh.indexOf('"')>=0)
                    {
                       nh=nh.replace('"',"")
                    }
                    objID=nh;
       }
      switch(prop)
      {
        case "bc":if(objID!='null'&& objID!='editordiv')
        {
        
        document.getElementById(objID).style.backgroundColor=val;
        document.getElementById('toolsbox_bgcolor').style.backgroundColor=val;
        
        };
        break;
        case "vs":document.getElementById(objID).style.visibility=val;
        break;
        case "ds":document.getElementById(objID).style.display=val;
        break;
        case "tp":document.getElementById(objID).style.top=val;
        break;
        case "lf":document.getElementById(objID).style.left=val;
        break;
    }
}
function putOBJxColorT2(OBjElem,Samp,pigMent)
{
    if(pigMent!='x')
    {
        setCCbldIDT2(OBjElem,pigMent);
        
        setCCbldStyT2(document.getElementById('myhdnval').value,'bc',pigMent);
    }
    setCCbldStyT2('colorpicker201','vs','hidden');
    setCCbldStyT2('colorpicker201','ds','none');
}
function setCCbldIDT2(objID,val)
    {
        document.getElementById(objID).value=val;
    }