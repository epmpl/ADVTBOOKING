
function F2fillexecutivecr(event)
{

 var key=event.keyCode?event.keyCode:event.which;

if(key==113)
{
    if(document.activeElement.id=="tctexeretname")
        {      
           
            var compcode =document.getElementById('hiddencomcode').value;
            var executive =document.getElementById('tctexeretname').value;
            
            document.getElementById("div3").style.display="block";
            document.getElementById('div3').style.top=195+ "px" ;
            document.getElementById('div3').style.left=370+ "px";
            document.getElementById('lstexecutive').focus();
            Executive_team_transfer.fillF2_Creditexecutive(compcode,executive,bindexecutive_callback);
      }
          
}
}


function bindexecutive_callback(res)
{
     var ds_AccName=res.value;
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
        {
            var pkgitem = document.getElementById("lstexecutive");
            pkgitem.options.length = 0;
            pkgitem.options[0]=new Option("-Select Executive Name-","0");
            pkgitem.options.length = 1;
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Exec_name + "~" + ds_AccName.Tables[0].Rows[i].Exe_no + "~" + ds_AccName.Tables[0].Rows[i].TEAM_NAME + "~" + ds_AccName.Tables[0].Rows[i].TEAM_CODE, ds_AccName.Tables[0].Rows[i].Exe_no);        
                pkgitem.options.length;
            }
        }
        document.getElementById("lstexecutive").value="0";
        document.getElementById("div3").value="";
        document.getElementById('lstexecutive').focus();
  
        return false;

}



function Clickexecutive(event)
{

var key=event.keyCode?event.keyCode:event.which;


    if(key==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstexecutive")
        {
        if(document.getElementById('lstexecutive').value=="0")
            {
                 alert("Please select Executive Name");
                 return false;
            }
           
            var page = document.getElementById('lstexecutive').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstexecutive').length-1;k++)
            {  
                if(document.getElementById('lstexecutive').options[k].value==page)
                {
                
                     var abc;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        abc=document.getElementById('lstexecutive').options[k].innerHTML;
                    }
                    else
                    {
                          abc=document.getElementById('lstexecutive').options[k].innerText;
                    }
                  
                    var splitpub = abc;
                    var str = splitpub.split("~");
                    abc=str[0];
                    abc1 = str[1];
                    abc2 = str[2];
                    abc3 = str[3];
                    document.getElementById('tctexeretname').value = abc;
                    document.getElementById('hdnexecode').value = abc1;

                    document.getElementById('txtteamname').value = abc2;
                    document.getElementById('hdnteamcode').value = abc3;


                    document.getElementById("div3").style.display="none";
                    document.getElementById('tctexeretname').focus();
                     return false;
                   
                }
            }
        }
      }
        else if(key==27)
        {
        
            document.getElementById("div3").style.display="none";
            document.getElementById('tctexeretname').focus();
        }
        else if(key==48||key==12)
        {
            document.getElementById('tctexeretname').value="";
            document.getElementById('hdnexecode').value=""
            document.getElementById('tctexeretname').focus();
        }
  
    }
  
 
 
 
 
  
  
  function F2fillteamname(event)
{

 var key=event.keyCode?event.keyCode:event.which;

if(key==113)
{
    if(document.activeElement.id=="txtteamname")
        {      
           
            var compcode =document.getElementById('hiddencomcode').value;
            var team =document.getElementById('txtteamname').value;
            
            document.getElementById("divteam").style.display="block";
            document.getElementById('divteam').style.top=195+ "px" ;
            document.getElementById('divteam').style.left=370+ "px";
            document.getElementById('lstteamname').focus();
            document.getElementById('txtteamname').value = "";
            document.getElementById('hdnteamcode').value = "";
            Executive_team_transfer.fill_Creditteam(compcode,team,bindteam_callback);
      }
          
}
}


function bindteam_callback(res)
{
     var ds_AccName=res.value;
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
        {
            var pkgitem = document.getElementById("lstteamname");
            pkgitem.options.length = 0;
            pkgitem.options[0]=new Option("-Select team-","0");
            pkgitem.options.length = 1;
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Team_Name+"~"+ds_AccName.Tables[0].Rows[i].Team_Code,ds_AccName.Tables[0].Rows[i].Team_Code);        
                pkgitem.options.length;
            }
        }
        document.getElementById("lstteamname").value="0";
        document.getElementById("divteam").value="";
        document.getElementById('lstteamname').focus();
  
        return false;

}



function Clickteamname(event)
{

var key=event.keyCode?event.keyCode:event.which;


    if(key==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstteamname")
        {
        if(document.getElementById('lstteamname').value=="0")
            {
                 alert("Please select team");
                 return false;
            }
           
            var page = document.getElementById('lstteamname').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstteamname').length-1;k++)
            {  
                if(document.getElementById('lstteamname').options[k].value==page)
                {
                
                     var abc;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        abc=document.getElementById('lstteamname').options[k].innerHTML;
                    }
                    else
                    {
                          abc=document.getElementById('lstteamname').options[k].innerText;
                    }
                  
                    var splitpub = abc;
                    var str = splitpub.split("~");
                    abc=str[0];
                    abc1=str[1];
                    document.getElementById('txtteamname').value = abc;
                    document.getElementById('hdnteamcode').value =abc1;
                    document.getElementById("divteam").style.display="none";
                    document.getElementById('txtteamname').focus();
                     return false;
                   
                }
            }
        }
      }
         else if(key==27)
         {
        
        document.getElementById("divteam").style.display="none";
        document.getElementById('txtteamname').focus();
         }
  else if(key==48||key==12)
         {
        document.getElementById('txtteamname').value="";
        document.getElementById('hdnteamcode').value="";
        document.getElementById('txtteamname').focus();
         }
  
  
  }
  
 
  
function Clicktransfer(event) 
{
var compcode =document.getElementById('hiddencomcode').value;
var teamCode = document.getElementById('hdnteamcode').value;
var executiveCode =document.getElementById('hdnexecode').value;
var userid = document.getElementById('hiddenuserid').value;
//var creationdatetime = ""//document.getElementById('hiddendateformat').value;
var extra = "";
var extra1 = "";

var res=Executive_team_transfer.TransferForm(compcode, teamCode, executiveCode, userid, extra, extra1);
transfer_callback(res);

} 
  
  function transfer_callback(res)
{
     var ds_tran=res.value;
      
        if(ds_tran!= null)
        {
        document.getElementById('tctexeretname').value="";
        document.getElementById('txtteamname').value="";
         alert("data save successfully") 
         
         }
      else
        {
   alert("there is some error")

        }
       
}
  