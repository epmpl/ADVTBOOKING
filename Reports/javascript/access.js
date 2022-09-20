// JScript File

function opendivform()
{
  document.getElementById('newdiv1').style.display="none";
  document.getElementById('newdiv4').style.display="block";
  return false;
}

function opendivform1()
{

  document.getElementById('newdiv1').style.display="block";
  document.getElementById('newdiv4').style.display="none";
  return false;
}
// bind region
function region()
{
   var compcode = document.getElementById('hdncompcode').value;
   Pam_access_rights.bind_region(compcode,callback_region)
   return false;
}

function callback_region(res)
{
  ds=res.value;
     var abc="";
        var def="";
        var ghi="";
        var jkl="";
   
        if(ds!=null && typeof(ds)=="object" && ds.Tables[0].Rows.length > 0)
        {
                
                 var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                  
                            var count  
                            var cod='selCheckbox' + i;


                            if(abc=="")
                            {
                                     
                                     abc+="<input   type='checkbox'"
                                     abc+="id=chk_"+i
                                     abc+=" onclick='chkregion(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].REGION_CODE+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].REGION_NAME+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chk_"+i
                                     abc+=" onclick='chkregion(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].REGION_CODE+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].REGION_NAME+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdregion").innerHTML=abc;
                   
                 
          }
      
}
var count=0;
var tdregion;
function chkregion(checkid) 
 {

    
    var mymumber=0; 
    var i=0;   
    var mytotallength=document.getElementById("tdregion").childNodes.length;
    
     for(i=0;i<mytotallength;i++)
    {
        if(document.getElementById('chkall').checked==1)
        {
            if(document.getElementById("tdregion").childNodes[i].id)
            {
                if(document.getElementById("tdregion").childNodes[i].checked==false)
                {
                    document.getElementById("chkall").checked=false;
                }
            }             
       }
   }
    
    
    
    for(i=0;i<mytotallength;i++)
    {
       tdregion=document.getElementById("tdregion");
        if(checkid==document.getElementById("tdregion").childNodes[i].id)
        {
            if(document.getElementById("tdregion").childNodes[i].checked==false)
            {
                document.getElementById("tdregion").childNodes[i].checked=false;
            }
            else
            {
                document.getElementById("tdregion").childNodes[i].checked=true;
              
//                var regcod = document.getElementById("tdregion").childNodes[i].value;

//                document.getElementById('hdnregion').value=regcod;

//                Pam_access_rights.bind_branch(document.getElementById('hdncompcode').value,regcod,callback_branch11)
                
            }
          }

     } 
     
 } 
 function bindbranch()
 {
    Pam_access_rights.bind_branch(document.getElementById('hdncompcode').value,callback_branch11)
    return false;
    
 }
 
// function chkregion1(checkid) 
// {

//    
//    var mymumber=0; 
//    var i=0;   
//    var mytotallength=document.getElementById("tdregion1").childNodes.length;
//    for(i=0;i<mytotallength;i++)
//    {
//    tdregion=document.getElementById("tdregion1");

//        if(checkid==document.getElementById("tdregion1").childNodes[i].id)
//        {
//            if(document.getElementById("tdregion1").childNodes[i].checked==false)
//            {
//                document.getElementById("tdregion1").childNodes[i].checked=false;
//            }
//            else
//            {
//                document.getElementById("tdregion1").childNodes[i].checked=true;
//                //callback_branch1();
//                var regcod = document.getElementById("tdregion1").childNodes[i].value;
//                 if(document.getElementById('hdnregion').value=="")
//                document.getElementById('hdnregion').value=regcod;
//                else
//                document.getElementById('hdnregion').value = document.getElementById('hdnregion').value+"$"+regcod;
//                Pam_access_rights.bind_branch(document.getElementById('hdncompcode').value,regcod,callback_branch11)
//                
//            }
//          }

//     } 
//     
//     
//     
//}

// function chkregion2(checkid) 
// {

// 
//    var mymumber=0; 
//    var i=0;   
//    var mytotallength=document.getElementById("tdregion2").childNodes.length;
//    for(i=0;i<mytotallength;i++)
//    {
//        tdregion=document.getElementById("tdregion2");
//        if(checkid==document.getElementById("tdregion2").childNodes[i].id)
//        {
//            if(document.getElementById("tdregion2").childNodes[i].checked==false)
//            {
//                document.getElementById("tdregion2").childNodes[i].checked=false;
//            }
//            else
//            {
//                document.getElementById("tdregion2").childNodes[i].checked=true;
//              
//                var regcod = document.getElementById("tdregion2").childNodes[i].value;

//                document.getElementById('hdnregion').value=regcod;
////                else
////                document.getElementById('hdnregion').value = document.getElementById('hdnregion').value+"$"+regcod;
//                Pam_access_rights.bind_branch(document.getElementById('hdncompcode').value,regcod,callback_branch11)
//                
//            }
//          }

//     } 
//     
//}

var flag=0;
function callback_branch11(res)
{
ds=res.value;
     
   
var abc="";
        var def="";
        var ghi="";
        var jkl="";
        if(ds!=null && typeof(ds)=="object" && ds.Tables[0].Rows.length > 0)
        {
               if(document.getElementById("tdbranch").innerHTML=="")
               { 
                 var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                            var count  
                            var cod='selCheckbox' + i;

                            if(abc=="")
                            {
                                     
                                     abc+="<input type='checkbox'"
                                     abc+="id=chkbrh_"+i
                                     abc+=" onclick='chkbranch(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].Branch_Code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].Branch_Name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chkbrh_"+i
                                     abc+=" onclick='chkbranch(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].Branch_Code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].Branch_Name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdbranch").innerHTML=abc;

              
                   
                   
                 
          }
          else
          {
               var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                            var count  
                            var cod='selCheckbox' + i;


                            if(abc=="")
                            {
                                     
                                     abc+="<input   type='checkbox'"
                                     abc+="id=chkbrh_"+i
                                     abc+=" onclick='chkbranch(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].Branch_Code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].Branch_Name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chkbrh_"+i
                                     abc+=" onclick='chkbranch(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].Branch_Code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].Branch_Name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdbranch").innerHTML=document.getElementById("tdbranch").innerHTML+abc;
                   

          }
        }
        
        if(flag==1)
        chkbranch123(dsrep);
    
  
}

 function chkbranch(checkid) 
 { 
    var mymumber=0; 
    var i=0;   
    var mytotallength=document.getElementById("tdbranch").childNodes.length;
     for(i=0;i<mytotallength;i++)
    {
        if(document.getElementById('chkall1').checked==1)
        {
            if(document.getElementById("tdbranch").childNodes[i].id)
            {
                if(document.getElementById("tdbranch").childNodes[i].checked==false)
                {
                    document.getElementById("chkall1").checked=false;
                }
            }             
       }
   }

    for(i=0;i<mytotallength;i++)
    {
        tdregion=document.getElementById("tdbranch");
        if(checkid==document.getElementById("tdbranch").childNodes[i].id)
        {
            if(document.getElementById("tdbranch").childNodes[i].checked==false)
            {
                document.getElementById("tdbranch").childNodes[i].checked=false;
            }
            else
            {
                document.getElementById("tdbranch").childNodes[i].checked=true;
//                var b1 = document.getElementById("tdbranch").childNodes[i].value;
//                b1=b1.split('!!');
//                var brcod = b1[0];
//                document.getElementById("hdnbranch").value = brcod;
//                Pam_access_rights.bind_Team(document.getElementById('hdncompcode').value,brcod,callback_Team)
               
                
            }
          }

     } 
     
}
function bindteam()
{
Pam_access_rights.bind_Team(document.getElementById('hdncompcode').value,callback_Team)
//return false;
}
//function chkbranch1(checkid) 
// { 
//    var mymumber=0; 
//    var i=0;   
//    var mytotallength=document.getElementById("tdbranch1").childNodes.length;
//    for(i=0;i<mytotallength;i++)
//    {
//        tdregion=document.getElementById("tdbranch1");
//        if(checkid==document.getElementById("tdbranch1").childNodes[i].id)
//        {
//            if(document.getElementById("tdbranch1").childNodes[i].checked==false)
//            {
//                document.getElementById("tdbranch1").childNodes[i].checked=false;
//            }
//            else
//            {
//                document.getElementById("tdbranch1").childNodes[i].checked=true;
//                //callback_branch2();
//                var brcod = document.getElementById("tdbranch1").childNodes[i].value;
//                Pam_access_rights.bind_Team(document.getElementById('hdncompcode').value,brcod,callback_Team)
//                
//            }
//          }

//     } 
//     
//}


function callback_Team(res)
{
       ds=res.value;
     
   
var abc="";
        var def="";
        var ghi="";
        var jkl="";
        if(ds!=null && typeof(ds)=="object" && ds.Tables[0].Rows.length > 0)
        {
               if(document.getElementById("tdteam").innerHTML=="")
               { 
                 var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                            var count  
                            var cod='selCheckbox' + i;

                            if(abc=="")
                            {
                                     
                                     abc+="<input type='checkbox'"
                                     abc+="id=chktm_"+i
                                     abc+=" onclick='chkteam(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].team_code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].team_name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chktm_"+i
                                     abc+=" onclick='chkteam(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].team_code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].team_name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdteam").innerHTML=abc;

              
                   
                   
                 
          }
          else
          {
               var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                            var count  
                            var cod='selCheckbox' + i;


                            if(abc=="")
                            {
                                     
                                     abc+="<input   type='checkbox'"
                                     abc+="id=chktm_"+i
                                     abc+=" onclick='chkteam(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].team_code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].team_name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chktm_"+i
                                     abc+=" onclick='chkteam(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].team_code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].team_name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdteam").innerHTML=document.getElementById("tdteam").innerHTML+abc;
                   

          }
        }
     if(flag==1)
        team123(dsrep);
          

}
function chkteam(checkid) 
 { 
   var mymumber=0; 
    var i=0;   
    var mytotallength=document.getElementById("tdteam").childNodes.length;
     for(i=0;i<mytotallength;i++)
    {
        if(document.getElementById('chkall2').checked==1)
        {
            if(document.getElementById("tdteam").childNodes[i].id)
            {
                if(document.getElementById("tdteam").childNodes[i].checked==false)
                {
                    document.getElementById("chkall2").checked=false;
                }
            }             
       }
   }
    for(i=0;i<mytotallength;i++)
    {
        tdregion=document.getElementById("tdteam");
        if(checkid==document.getElementById("tdteam").childNodes[i].id)
        {
            if(document.getElementById("tdteam").childNodes[i].checked==false)
            {
                document.getElementById("tdteam").childNodes[i].checked=false;
            }
            else
            {
                document.getElementById("tdteam").childNodes[i].checked=true;
//                var t1= document.getElementById("tdteam").childNodes[i].value;
//                t1=t1.split('##');
//                var temcod = t1[0];
//                document.getElementById('hdnteam').value=temcod;
//                Pam_access_rights.bind_executive(document.getElementById('hdncompcode').value,temcod,callback_executive)
                
            }
          }

     } 
    
}
function  bindexecutive()
{
Pam_access_rights.bind_executive(document.getElementById('hdncompcode').value,callback_executive)
return false;
}

function callback_executive(res)
{
   ds=res.value;
     
   
var abc="";
        var def="";
        var ghi="";
        var jkl="";
        if(ds!=null && typeof(ds)=="object" && ds.Tables[0].Rows.length > 0)
        {
               if(document.getElementById("tdexecutive").innerHTML=="")
               { 
                 var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                            var count  
                            var cod='selCheckbox' + i;

                            if(abc=="")
                            {
                                     
                                     abc+="<input type='checkbox'"
                                     abc+="id=chkexe_"+i
                                     abc+=" onclick='chkexecutive(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].exe_no+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].exec_name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chkexe_"+i
                                     abc+=" onclick='chkexecutive(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].exe_no+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].exec_name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdexecutive").innerHTML=abc;

              
                   
                   
                 
          }
          else
          {
               var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                            var count  
                            var cod='selCheckbox' + i;


                            if(abc=="")
                            {
                                     
                                     abc+="<input   type='checkbox'"
                                     abc+="id=chkexe_"+i
                                     abc+=" onclick='chkexecutive(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].exe_no+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].exec_name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chkexe_"+i
                                     abc+=" onclick='chkexecutive(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].exe_no+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].exec_name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdexecutive").innerHTML=document.getElementById("tdexecutive").innerHTML+abc;
                   

          }
        }
    if(flag==1)
        executive123(dsrep);
}
function chkexecutive(checkid) 
 { 
    var mymumber=0; 
    var i=0;   
    var mytotallength=document.getElementById("tdexecutive").childNodes.length;
     for(i=0;i<mytotallength;i++)
    {
        if(document.getElementById('chkall3').checked==1)
        {
            if(document.getElementById("tdexecutive").childNodes[i].id)
            {
                if(document.getElementById("tdexecutive").childNodes[i].checked==false)
                {
                    document.getElementById("chkall3").checked=false;
                }
            }             
       }
   }
    for(i=0;i<mytotallength;i++)
    {
        tdregion=document.getElementById("tdexecutive");
        if(checkid==document.getElementById("tdexecutive").childNodes[i].id)
        {
            if(document.getElementById("tdexecutive").childNodes[i].checked==false)
            {
                document.getElementById("tdexecutive").childNodes[i].checked=false;
            }
            else
            {
                document.getElementById("tdexecutive").childNodes[i].checked=true;
               
                
            }
          }

     } 
     
}
 var glteam="";
 var glbrch="";
 var glreg ="";
function save_access()
{
var flag=0;
if(document.getElementById('dpdrole').value=="0")
{
  alert("Please Select Role");
  document.getElementById('dpdrole').focus();
  return false;
  
}

if(document.getElementById('dpduser').value=="0")
{
  alert("Please Select user");
  document.getElementById('dpduser').focus();
  return false;
  
}

  var rolcod = document.getElementById('dpdrole').value;
  var newuid = document.getElementById('dpduser').value;
  var compcode = document.getElementById('hdncompcode').value;
  var hduid = document.getElementById('hiddenuserid').value;
  
  var totallength=document.getElementById("tdexecutive").childNodes.length;
  var totalteamlength=document.getElementById("tdteam").childNodes.length;
  var totalteamlength1=document.getElementById("tdbranch").childNodes.length;
  var totalteamlength2=document.getElementById("tdregion").childNodes.length;
  
  
  // Region

            for(var i=0; i<totalteamlength2;i++)
      {
               if(document.getElementById("tdregion").childNodes[i].checked==true)
                {
                
                    var rgcd = document.getElementById("tdregion").childNodes[i].value;
                    
                     var value="R";
                     //Sachin Verma
                    var pam = Pam_access_rights.sel_report(rgcd,rolcod,newuid,compcode,value)
                     if(pam.value!=null && pam.value.Tables[0].Rows.length==0)
                     {
                    Pam_access_rights.save_access(rgcd,rolcod,newuid,compcode,hduid,value)
                    }
                    
                }
      }
      
      
//      if(flag==2)
//{
            for(var i=0; i<totalteamlength1;i++)
      {
               if(document.getElementById("tdbranch").childNodes[i].checked==true)
                {
               
                    var branch = document.getElementById("tdbranch").childNodes[i].value;
//                 var cod = Pam_access_rights.find_code("","",branch,compcode)
//                if(cod.value!=null && cod.value.Tables[2].Rows.length>0)
//                { 


                     var bcd=branch;
                     var value="B";
//                     var rgd = cod.value.Tables[2].Rows[0].Region_code;
//                   glreg = rgd;
//                      if(glbrch!=bcd)
                       //Sachin Verma
                    var pam = Pam_access_rights.sel_report(bcd,rolcod,newuid,compcode,value)
                     if(pam.value!=null && pam.value.Tables[0].Rows.length==0)
                     {
                    Pam_access_rights.save_access(bcd,rolcod,newuid,compcode,hduid,value)
                    }
              //  }
            }
      }
      
      //Team
//if(flag==1)
//{
  for(var i=0; i<totalteamlength;i++)
  {
           if(document.getElementById("tdteam").childNodes[i].checked==true)
            {
             //flag=2;

                var tmcd= document.getElementById("tdteam").childNodes[i].value;
//                  var cod = Pam_access_rights.find_code("",tmcd,"",compcode)
//               if(cod.value!=null && cod.value.Tables[1].Rows.length>0)
//                {           
              
                var tmd = tmcd;
                var value="T";
                
//                var bcd=cod.value.Tables[1].Rows[0].branch_code;
//                var rgcd = cod.value.Tables[1].Rows[0].Region;
//                glbrch = bcd;
//                if(glteam!=tmd) 
                      //Sachin Verma
                    var pam = Pam_access_rights.sel_report(tmd,rolcod,newuid,compcode,value)
                     if(pam.value!=null && pam.value.Tables[0].Rows.length==0)
                     {               
                Pam_access_rights.save_access(tmd,rolcod,newuid,compcode,hduid,value)
                }
                //}
            }
            }
         // Executive
//if(flag==0)
//{
  for(var i=0; i<totallength;i++)
  {
           if(document.getElementById("tdexecutive").childNodes[i].checked==true)
            {
            //flag=1;
                var excod = document.getElementById("tdexecutive").childNodes[i].value;

                var execd = excod;
//                var cod = Pam_access_rights.find_code(excod,"","",compcode)
//                if(cod.value!=null && cod.value.Tables[0].Rows.length>0)
//                {
//                var tmcd= cod.value.Tables[0].Rows[0].Team_code;
//                var bcd=cod.value.Tables[0].Rows[0].Branch;
//                var rgcd = cod.value.Tables[0].Rows[0].Region;
//                glteam = tmcd;
                     var value="E";
                     //Sachin Verma
                    var pam = Pam_access_rights.sel_report(execd,rolcod,newuid,compcode,value)
                     if(pam.value!=null && pam.value.Tables[0].Rows.length==0)
                     {
                Pam_access_rights.save_access(execd,rolcod,newuid,compcode,hduid,value)
                }
                //}
            }
            
  }
  
  //sachin verma
            callback_save();
            return false;

//}
         //}  

//      callback_save();
//      return false;
  
   // return false;

  
 
         
  
  
   
    
}

function callback_save()
{
  alert("Permission Assigned");
  return false;
}
function exitclick()
{
        if(confirm("Do You Want To Skip This Page"))
        {
        window.close()
        return false;
        }
//        else 
//        {
        return false;
//        }

}

function selectall()
{
var mynumber=0;
if (document.getElementById('chkall').checked==1)
{
document.getElementById('chkall').checked=true;
var count=document.getElementById('tdregion').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if(document.getElementById('tdregion').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdregion').childNodes[i].checked=false;
                 }   
                 else
                 { 
                  document.getElementById('tdregion').childNodes[i].checked=true;
                 //chkregion(document.getElementById('tdregion').childNodes[i].id);
                 }
    
        }
document.getElementById('chkall').checked=true;
}

else
{
var count=document.getElementById('tdregion').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdregion').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdregion').childNodes[i].checked=false;
                 }   
                 else
                 { 
                   document.getElementById('tdregion').childNodes[i].checked=false;
                 }
        }

}
return true;
}

function selectall1()
{
var mynumber=0;
if (document.getElementById('chkall1').checked==1)
{
var count=document.getElementById('tdbranch').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdbranch').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdbranch').childNodes[i].checked=false;
                 }   
                 else
                 { 
                  document.getElementById('tdbranch').childNodes[i].checked=true;
                  chkbranch(document.getElementById('tdbranch').childNodes[i].id)
                  
                 }
        }
        document.getElementById('chkall1').checked=true;
        }
 else
{
var count=document.getElementById('tdbranch').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdbranch').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdbranch').childNodes[i].checked=false;
                 }   
                 else
                 { 
                   document.getElementById('tdbranch').childNodes[i].checked=false;
                 }
        }

}
}
 
 function selectall2()
{
var mynumber=0;
if (document.getElementById('chkall2').checked==1)
{
var count=document.getElementById('tdteam').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdteam').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdteam').childNodes[i].checked=false;
                 }   
                 else
                 { 
                  document.getElementById('tdteam').childNodes[i].checked=true;
                  chkteam(document.getElementById('tdteam').childNodes[i]);
                  
                 }
        }
        
        document.getElementById('chkall2').checked=true;
        }
 else
{
var count=document.getElementById('tdteam').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdteam').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdteam').childNodes[i].checked=false;
                 }   
                 else
                 { 
                   document.getElementById('tdteam').childNodes[i].checked=false;
                 }
        }

}
}
 
 function selectall3()
{
var mynumber=0;
if (document.getElementById('chkall3').checked==1)
{
var count=document.getElementById('tdexecutive').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdexecutive').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdexecutive').childNodes[i].checked=false;
                 }   
                 else
                 { 
                  document.getElementById('tdexecutive').childNodes[i].checked=true;
                 }
        }
        
         document.getElementById('chkall3').checked=true;
        }
else
{
var count=document.getElementById('tdexecutive').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdexecutive').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdexecutive').childNodes[i].checked=false;
                 }   
                 else
                 { 
                   document.getElementById('tdexecutive').childNodes[i].checked=false;
                 }
        }

}
}


function pub_center()
{
   var compcode = document.getElementById('hdncompcode').value;
   Pam_access_rights.bind_center(compcode,callback_center)
   return false;
  
}

function callback_center(res)
{
  ds=res.value;
     var abc="";
        var def="";
        var ghi="";
        var jkl="";
   
        if(ds!=null && typeof(ds)=="object" && ds.Tables[0].Rows.length > 0)
        {
                
                 var i=0
                
                  while(i<ds.Tables[0].Rows.length)
                  {
                          
                            var  dropdownnew1="dropdownnew"  
                  
                            var count  
                            var cod='selCheckbox' + i;


                            if(abc=="")
                            {
                                     
                                     abc+="<input   type='checkbox'"
                                     abc+="id=chk_"+i
                                     abc+=" onclick='chkcenter(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].Pub_cent_Code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].Pub_Cent_name+"</font></strong>"
                                   
                             }
                             else
                             {
                                   
                                     abc+="<input  type='checkbox'"
                                     abc+="id=chk_"+i
                                     abc+=" onclick='chkcenter(this.id)'"
                                     abc+=" value="+ds.Tables[0].Rows[i].Pub_cent_Code+">"
                                     abc+="<strong>"
                                     abc+="<font face='arial' size='1px'>"+ds.Tables[0].Rows[i].Pub_Cent_name+"</font></strong>"
                                    
                             }
                             i=i+1
                             abc =abc+ "<BR>"

                   }
                 
                   document.getElementById("tdcenter").innerHTML=abc;
                   
                 
          }
}

function chkcenter(checkid)
{
  var mymumber=0; 
    var i=0;   
    var mytotallength=document.getElementById("tdcenter").childNodes.length;
    
     for(i=0;i<mytotallength;i++)
    {
        if(document.getElementById('centall').checked==1)
        {
            if(document.getElementById("tdcenter").childNodes[i].id)
            {
                if(document.getElementById("tdcenter").childNodes[i].checked==false)
                {
                    document.getElementById("centall").checked=false;
                }
            }             
       }
   }
    
    
    
    for(i=0;i<mytotallength;i++)
    {
       tdregion=document.getElementById("tdcenter");
        if(checkid==document.getElementById("tdcenter").childNodes[i].id)
        {
            if(document.getElementById("tdcenter").childNodes[i].checked==false)
            {
                document.getElementById("tdcenter").childNodes[i].checked=false;
            }
            else
            {
                document.getElementById("tdcenter").childNodes[i].checked=true;
              
                var regcod = document.getElementById("tdcenter").childNodes[i].value;

                document.getElementById('tdcenter').value=regcod;

               //Pam_access_rights.bind_branch(document.getElementById('hdncompcode').value,regcod,callback_branch11)
                
            }
          }

     } 
}

function savecenter()
{
if(document.getElementById('dpdrole').value=="0")
{
  alert("Please Select Role");
  document.getElementById('dpdrole').focus();
  return false;
  
}

if(document.getElementById('dpduser').value=="0")
{
  alert("Please Select user");
  document.getElementById('dpduser').focus();
  return false;
  
}
   var rolcod = document.getElementById('dpdrole').value;
  var newuid = document.getElementById('dpduser').value;
  var compcode = document.getElementById('hdncompcode').value;
  var hduid = document.getElementById('hiddenuserid').value;
  
  var totallength=document.getElementById("tdcenter").childNodes.length;
  
  for(var i=0; i<totallength;i++)
  {
           if(document.getElementById("tdcenter").childNodes[i].checked==true)
            {
           
                var center = document.getElementById("tdcenter").childNodes[i].value;
                
                 var pam = Pam_access_rights.sel_center(rolcod,newuid,compcode,center)
                 if(pam.value.Tables[0].Rows.length==0)
                 {                
                  Pam_access_rights.save_centerrights(rolcod,newuid,compcode,hduid,center)
                  
                 }
            }
            
  }

  callback_save();
  return false;
}



function disabled_fields()

{
		document.getElementById('newdiv1').style.display="none";
		document.getElementById('newdiv4').style.display="none";
		document.getElementById('dpdrole').value="0";
		document.getElementById('dpduser').value="0";
return false;
}


function showpermission()
{

document.getElementById('newdiv4').style.display="block";
    if(document.getElementById('dpdrole').value=="0")
    {
      alert("Please Select Role");
      document.getElementById('dpdrole').focus();
      return false;
      
    }

    if(document.getElementById('dpduser').value=="0")
    {
      alert("Please Select user");
      document.getElementById('dpduser').focus();
      return false;
      
    }
     for (var i=0; i< document.getElementById("tdcenter").childNodes.length; i=i+3)
        {
                    if(document.getElementById("tdcenter").childNodes[i].checked==true)
                   document.getElementById("tdcenter").childNodes[i].checked=false;
         }
    var role =document.getElementById('dpdrole').value;
    var user = document.getElementById('dpduser').value;
    var compcode = document.getElementById('hdncompcode').value;
    
     Pam_access_rights.serachcenter(role,user,compcode,callback_center11)
     return false;

}

function callback_center11(res)
{
   ds = res.value;
   var j=0;
   document.getElementById('newdiv4').style.display="block";
   if(ds!=null && ds.Tables[0].Rows.length>0)
   {
        for (var i=0; i< document.getElementById("tdcenter").childNodes.length; i=i+3)
        {
         
             for(var j=0; j<=i;j++)
             {
               if(j<ds.Tables[0].Rows.length)
               {
                 if(ds.Tables[0].Rows[j].PUB_CENTER==document.getElementById("tdcenter").childNodes[i].value)
                 {
                  document.getElementById("tdcenter").childNodes[i].checked=true;
                  //return false;
                 }
//                 else
//                 {
//                    if(document.getElementById("tdcenter").childNodes[i].checked==true)
//                    document.getElementById("tdcenter").childNodes[i].checked=false;
//                 }
                 
               } 
              }
             
           } 
        }
   }



function updatepermission()
{
var center="";

    var role =document.getElementById('dpdrole').value;
    var user = document.getElementById('dpduser').value;
    var compcode = document.getElementById('hdncompcode').value;
    
    if(document.getElementById('dpdrole').value=="0")
    {
      alert("Please Select Role");
      document.getElementById('dpdrole').focus();
      return false;
      
    }

    if(document.getElementById('dpduser').value=="0")
    {
      alert("Please Select user"); 
      document.getElementById('dpduser').focus();
      return false;
      
    }
    for (var i=0; i< document.getElementById("tdcenter").childNodes.length; i=i+3)
        {
//            if(center=="")
//            {
              if(document.getElementById("tdcenter").childNodes[i].checked==false)
                center = document.getElementById("tdcenter").childNodes[i].value;
                if(center!="")
                {
                 var pam = Pam_access_rights.sel_center(role,user,compcode,center)
                 if(pam.value.Tables[0].Rows.length>0)
                 {
                     Pam_access_rights.update_center(role,user,compcode,center)
                     //Sachin Verma
                    // alert("Permission Updated Succefully");
                 }
                }

        }
   
    
   
    //var center=
    callback_status();
     return false;

}

function callback_status()
{
  alert("Data Updated Successfully");
  return false;
}


function selectallcenter()
{
var mynumber=0;
if (document.getElementById('centall').checked==1)
{
document.getElementById('centall').checked=true;
var count=document.getElementById('tdcenter').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if(document.getElementById('tdcenter').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdcenter').childNodes[i].checked=false;
                 }   
                 else
                 { 
                  document.getElementById('tdcenter').childNodes[i].checked=true;
                 //chkregion(document.getElementById('tdcenter').childNodes[i].id);
                 }
    
        }
document.getElementById('centall').checked=true;
}

else
{
var count=document.getElementById('tdcenter').childNodes.length;

        for(i=0;i<count;i++)
        {
            if(i==0)
            {
               mynumber=0; 
            }
            else
            {
                mynumber=i+2;
            }
                 if( document.getElementById('tdcenter').childNodes[i].value==undefined)   
                 {
                   document.getElementById('tdcenter').childNodes[i].checked=false;
                 }   
                 else
                 { 
                   document.getElementById('tdcenter').childNodes[i].checked=false;
                 }
        }

}
return true;
}
function exitclick1()
{
        if(confirm("Do You Want To Skip This Page"))
        {
        window.close()
        return false;
        }
        return false;


}

function Set_Access()
{

if(document.getElementById('dpdrole').value=="0")
{
  alert("Please Select Role");
  document.getElementById('dpdrole').focus();
  return false;
  
}

if(document.getElementById('dpduser').value=="0")
{
  alert("Please Select user");
  document.getElementById('dpduser').focus();
  return false;
  
}

  var rolcod = document.getElementById('dpdrole').value;
  var newuid = document.getElementById('dpduser').value;
  var compcode = document.getElementById('hdncompcode').value;
  var hduid = document.getElementById('hiddenuserid').value;
  
  var totallength=document.getElementById("tdexecutive").childNodes.length;
  var totalteamlength=document.getElementById("tdteam").childNodes.length;
  var totalteamlength1=document.getElementById("tdbranch").childNodes.length;
  var totalteamlength2=document.getElementById("tdregion").childNodes.length;
  
  
  // Region

            for(var i=0; i<totalteamlength2;i++)
      {
               if(document.getElementById("tdregion").childNodes[i].checked==false)
                {               
                    var rgcd = document.getElementById("tdregion").childNodes[i].value;
                    

                    var value="R";
              
                    Pam_access_rights.modify_permission(rgcd,rolcod,newuid,compcode,hduid,value)
                   
                    
                }
      }
      
 
            for(var i=0; i<totalteamlength1;i++)
      {
               if(document.getElementById("tdbranch").childNodes[i].checked==false)
                {
               
                    var branch = document.getElementById("tdbranch").childNodes[i].value;



                     var bcd=branch;
                     var value="B";

                    Pam_access_rights.modify_permission(bcd,rolcod,newuid,compcode,hduid,value)
                  
            }
      }
      
      //Team

  for(var i=0; i<totalteamlength;i++)
  {
           if(document.getElementById("tdteam").childNodes[i].checked==false)
            {
            

                var tmcd= document.getElementById("tdteam").childNodes[i].value;
         
              
                var tmd = tmcd;
                var value="T";
                
          
                Pam_access_rights.modify_permission(tmd,rolcod,newuid,compcode,hduid,value)
               
            }
            }
         // Executive

  for(var i=0; i<totallength;i++)
  {
           if(document.getElementById("tdexecutive").childNodes[i].checked==false)
            {
           
                var excod = document.getElementById("tdexecutive").childNodes[i].value;

                var execd = excod;

                     var value="E";
               
                Pam_access_rights.modify_permission(execd,rolcod,newuid,compcode,hduid,value)
               
            }
            
  }
  
 
            callback_status();
            return false;



   
}

function All_Clear()
{
  document.getElementById('dpdrole').value="0";
  document.getElementById('dpduser').value="0"
  
//  if(document.getElementById('tdbranch').childNodes.length!=0)
//  { 
// // var length = document.getElementById('tdbranch').childNodes.length;
//    for(i=document.getElementById('tdbranch').childNodes.length;i>=0;i=i-3)
//    {
//      document.getElementById('tdbranch').childNodes.remove(i);
//    }
//  }
  //document.getElementById('tdbranch').childNodes.length=0;
  
//  if(document.getElementById('tdteam').childNodes.length!=0)
//  document.getElementById('tdteam').childNodes.length=0;
//  if(document.getElementById('tdexecutive').childNodes.length!=0)
//  document.getElementById('tdexecutive').childNodes.length=0;
//  
     for (var i=0; i< document.getElementById("tdregion").childNodes.length; i=i+3)
        {
                    if(document.getElementById("tdregion").childNodes[i].checked==true)
                   document.getElementById("tdregion").childNodes[i].checked=false;
        }
        //sachin verma
        for (var i=0; i< document.getElementById("tdbranch").childNodes.length; i=i+3)
        {
                    if(document.getElementById("tdbranch").childNodes[i].checked==true)
                   document.getElementById("tdbranch").childNodes[i].checked=false;
        }
        
        for (var i=0; i< document.getElementById("tdteam").childNodes.length; i=i+3)
        {
                    if(document.getElementById("tdteam").childNodes[i].checked==true)
                   document.getElementById("tdteam").childNodes[i].checked=false;
        }
         for (var i=0; i< document.getElementById("tdexecutive").childNodes.length; i=i+3)
        {
                    if(document.getElementById("tdexecutive").childNodes[i].checked==true)
                   document.getElementById("tdexecutive").childNodes[i].checked=false;
        }
  
  return false;
}



function reportshow_prm()
{
 
    if(document.getElementById('dpdrole').value=="0")
    {
      alert("Please Select Role");
      document.getElementById('dpdrole').focus();
      return false;
      
    }

    if(document.getElementById('dpduser').value=="0")
    {
      alert("Please Select user");
      document.getElementById('dpduser').focus();
      return false;
      
    }
     for (var i=0; i< document.getElementById("tdregion").childNodes.length; i=i+3)
    {
        if(document.getElementById("tdregion").childNodes[i].checked==true)
       document.getElementById("tdregion").childNodes[i].checked=false;
    }
    var role =document.getElementById('dpdrole').value;
    var user = document.getElementById('dpduser').value;
    var compcode = document.getElementById('hdncompcode').value;
    
     Pam_access_rights.serachreport(role,user,compcode,callback_region11)
     return false;
}

var glreg="";
var glbrch="";
function callback_region11(response)
{
    dsrep = response.value;
    if(dsrep!=null && dsrep.Tables[0].Rows.length>0)
    {
      //for region
     
            for (var i=0; i< document.getElementById("tdregion").childNodes.length; i=i+3)
        {
         
             for(var j=0; j<dsrep.Tables[0].Rows.length;j++)
             {
//                if(j<dsrep.Tables[0].Rows.length)
//               {
                 if(dsrep.Tables[0].Rows[j].REGION_CODE==document.getElementById("tdregion").childNodes[i].value)
                 {
                      document.getElementById("tdregion").childNodes[i].checked=true;
                      //return false;
                 }

                 
              // } 
              }
             
           }          
      
    }
    if(dsrep!=null && dsrep.Tables[1].Rows.length>0)
    {
      //for region
     
            for (var i=0; i< document.getElementById("tdbranch").childNodes.length; i=i+3)
        {
         
             for(var j=0; j<dsrep.Tables[1].Rows.length;j++)
             {
//               if(j<dsrep.Tables[1].Rows.length)
//               {
                 if(dsrep.Tables[1].Rows[j].BRANCH_CODE==document.getElementById("tdbranch").childNodes[i].value)
                 {
                  document.getElementById("tdbranch").childNodes[i].checked=true;
                  //return false;
                 }

                 
              // } 
              }
             
           }          
      
    }   
     if(dsrep!=null && dsrep.Tables[2].Rows.length>0)
    {
      //for region
     
            for (var i=0; i< document.getElementById("tdteam").childNodes.length; i=i+3)
        {
         
             for(var j=0; j<dsrep.Tables[2].Rows.length;j++)
             {
//               if(j<dsrep.Tables[2].Rows.length)
//               {
                 if(dsrep.Tables[2].Rows[j].TEAM_CODE==document.getElementById("tdteam").childNodes[i].value)
                 {
                  document.getElementById("tdteam").childNodes[i].checked=true;
                  //return false;
                 }

                 
               //} 
              }
             
           }          
      
    } 
    if(dsrep!=null && dsrep.Tables[3].Rows.length>0)
    {
      //for region
     
            for (var i=0; i< document.getElementById("tdexecutive").childNodes.length; i=i+3)
        {
         
             for(var j=0; j<dsrep.Tables[3].Rows.length;j++)
             {
//               if(j<dsrep.Tables[3].Rows.length)
//               {
                 if(dsrep.Tables[3].Rows[j].EXEC_CODE==document.getElementById("tdexecutive").childNodes[i].value)
                 {
                  document.getElementById("tdexecutive").childNodes[i].checked=true;
                  //return false;
                 }

                 
              // } 
              }
             
           }          
      
    }
    
}

function chkbranch123(dsbr)
{
if(dsbr!=null)
{
  for(var i=0; i<dsbr.Tables[0].Rows.length; i++)
        {
           //branch
               if(dsbr.Tables[0].Rows[i].BRANCH_CODE!=null)
               {
                    for(var j=0; j<document.getElementById('tdbranch').childNodes.length; j=j+3)
                   {
                      if(dsbr.Tables[0].Rows[i].BRANCH_CODE==document.getElementById('tdbranch').childNodes[j].value)
                      {
                        document.getElementById('tdbranch').childNodes[j].checked=true;
                        var brcod = dsbr.Tables[0].Rows[i].BRANCH_CODE;
                         if(glbrch!=brcod)
                         { flag=1;
                             glbrch=brcod;
                            Pam_access_rights.bind_Team(document.getElementById('hdncompcode').value,brcod,callback_Team)
                         }
                        
                      } 
                   }
              }
           
        }
 }
}
var glteam="";
function team123(dstm)
{
  if(dstm!=null)
{
  for(var i=0; i<dstm.Tables[0].Rows.length; i++)
        {
           //branch
               if(dstm.Tables[0].Rows[i].TEAM_CODE!=null)
               {
                    for(var j=0; j<document.getElementById('tdteam').childNodes.length; j=j+3)
                   {
                      if(dstm.Tables[0].Rows[i].TEAM_CODE==document.getElementById('tdteam').childNodes[j].value)
                      {
                        document.getElementById('tdteam').childNodes[j].checked=true;
                        var tmcd = dstm.Tables[0].Rows[i].TEAM_CODE;
                         if(glteam!=tmcd)
                         { flag=1;
                             glteam=tmcd;
                            Pam_access_rights.bind_executive(document.getElementById('hdncompcode').value,tmcd,callback_executive)
                         }
                        
                      } 
                   }
              }
           
        }
 }
}

function executive123(dsex)
{
  if(dsex!=null)
    {
      for(var i=0; i<dsex.Tables[0].Rows.length; i++)
            {
               //branch
                   if(dsex.Tables[0].Rows[i].EXEC_CODE!=null)
                   {
                        for(var j=0; j<document.getElementById('tdexecutive').childNodes.length; j=j+3)
                       {
                          if(dsex.Tables[0].Rows[i].EXEC_CODE==document.getElementById('tdexecutive').childNodes[j].value)
                          {
                            document.getElementById('tdexecutive').childNodes[j].checked=true;
                            
                          } 
                       }
                  }
               
            }
     }
     
}


