// JScript File
 var area = 0;
    var totrol = 0;
    var totcd = 0;
    var totcc = 0;

    var i1 = 1;
    var amt = 0;
     function fndnull(myval)
{
   if(myval=="undefined")
   {
       myval="";
   }
   else if(myval==null)
   {
    myval="";
   }
   return myval
}
 
//function bind_onscreen()
//{
//var adtyp=document.getElementById('hiddenadtyp').value;
//var adcat=document.getElementById('hiddenadcat').value; 
//var adsubcat=document.getElementById('hiddenadsubcat').value;
//var fromdt=document.getElementById('hiddenfromdt').value;
//var dateto=document.getElementById('hiddendatetoo').value;
//var publ=document.getElementById('hiddenpubl').value;
//var pubcen=document.getElementById('hiddenpubcen').value;
//var compcode=document.getElementById('hiddencompcode').value;
//var edition=document.getElementById('hiddenedition').value;
//var dateformat=document.getElementById('hiddendateformat').value;
//var cioid=document.getElementById('hiddencioid').value; 
//var ascdesc=document.getElementById('hiddenascdesc').value; 
//var temp1="";
//var temp2="";
//var temp3="";
//var temp4="";
//var agtypetext=document.getElementById('hiddenagtypetext').value; 
//reportview.onscreen(adtyp,adcat,adsubcat,fromdt,dateto,publ,pubcen,compcode,edition,dateformat,cioid,ascdesc,temp1,temp2,temp3,temp4,agtypetext,call_onscreen);
//}
function bind_onscreen()
{
var temp1="";
Reportview.onscreen(temp1,call_onscreen);
}
function call_onscreen(response)
{
var ds=response.value;
var cont = ds.Tables[0].Rows.length;
        var tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>";

        tbl = tbl + ("<tr><td  class='middle31new' width='1%' >S.</br>No</td><td class='middle31new' width='3%' align='left'>Booking</br>&nbsp;&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>Edition</td><td class='middle31new' width='3%' align='left'>Publish</br>Date</td><td class='middle31new' width='9%' align='left'>Agency</td><td class='middle31new' width='9%' align='left'>Client</td><td class='middle31new' width='7%' align='left'>Package</td><td class='middle31new' width='2%' align='right'>HT</td><td class='middle31new' width='2%' align='right'>WD</td><td class='middle31new' width='3%' align='right'>Area</td><td class='middle31new' width='1%' align='left'>Color</td><td class='middle31new' width='4%' align='left'>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='7%' align='left'>Ro No.</td><td class='middle31new' width='4%' align='left'>Ro </br>Status</td> <td class='middle31new' width='3%' align='left'>AdCat</td><td class='middle31new' width='4%' align='right'>Card</br>Rate</td><td class='middle31new' width='4%' align='right'>Agg</br>Rate</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;&nbsp;Amt</td><td class='middle31new' width='2%' colspan='2' align='left'>Caption</br>Key No.</td></tr>");

        for (var i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr>");
          var y=i+1;

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (y + "</td>");
         
               var cioid1 = "";
              var rrr = fndnull(ds.Tables[0].Rows[i]["CIOID"]).toString();
             
          if(rrr.length>9)
           cioid1=rrr.substring(0,9)+"</br>"+rrr.substring(9,rrr.length);
           else
           cioid1=rrr;
           
              tbl = tbl + ("<td class='rep_data' align='left'>");
              tbl = tbl + (cioid1 + "</td>");

              tbl = tbl + ("<td class='rep_data' align='left'>");
              tbl = tbl + ( fndnull(ds.Tables[0].Rows[i]["edition"]).toString() + "</td>");


              tbl = tbl + ("<td class='rep_data' align='left'>");
              tbl = tbl + ( fndnull(ds.Tables[0].Rows[i]["Ins.date"]).toString() + "</td>");



            var agency1 = "";
            var rrr1 = fndnull(ds.Tables[0].Rows[i]["Agency"]).toString();
      
           if(rrr1.length>16)
           agency1=rrr1.substring(0,16)+"</br>"+rrr1.substring(16,32);
           else
           agency1=rrr1;
      
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (agency1 + "</td>");

            var client1 = "";
            var rrr2 =fndnull(ds.Tables[0].Rows[i]["Client"]).toString() ;

           if(rrr2.length>16)
           client1=rrr2.substring(0,16)+"</br>"+rrr2.substring(16,32);
           else
           client1=rrr2;


            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (client1 + "</td>");

            var Package1 = "";
            var rrr3 = fndnull(ds.Tables[0].Rows[i]["Package"]).toString() ;
            
             if(rrr3.length>9)
           Package1=rrr3.substring(0,9)+"</br>"+rrr3.substring(9,18);
           else
           Package1=rrr3;
           
        
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (Package1 + "</td>");


            tbl = tbl + ("<td class='rep_data' align='right'>");
            if (fndnull(ds.Tables[0].Rows[i]["Depth"]).toString() == "")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {

                tbl = tbl + (parseFloat(fndnull(ds.Tables[0].Rows[i]["Depth"])).toString() + "</td>");

            }
            tbl = tbl + ("<td class='rep_data' align='right'>");

            if (fndnull(ds.Tables[0].Rows[i]["Width"]).toString() == "")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {
                tbl = tbl + (parseFloat(fndnull(ds.Tables[0].Rows[i]["Width"])).toString() + "</td>");

            }


                 tbl = tbl + ("<td class='rep_data' align='right'>");

                 if (fndnull(ds.Tables[0].Rows[i]["Area"]).toString() == "")
                 {
                     tbl = tbl + "" + "</td>";
                 }
                 else
                 {

                     tbl = tbl + (parseFloat(fndnull(ds.Tables[0].Rows[i]["Area"])).toString() + "</td>");
                    
                     if (fndnull(ds.Tables[0].Rows[i]["uom"]).toString() == "CD" || fndnull(ds.Tables[0].Rows[i]["uom"]).toString() == "ROD")
                         area = area + parseFloat(fndnull(ds.Tables[0].Rows[i]["Area"]));
                     else if (fndnull(ds.Tables[0].Rows[i]["uom"]).toString() == "ROL")
                         totrol = totrol + parseFloat(fndnull(ds.Tables[0].Rows[i]["Area"]));
                     else if (fndnull(ds.Tables[0].Rows[i]["uom"]).toString() == "ROC")
                         totcd = totcd + parseFloat(fndnull(ds.Tables[0].Rows[i]["Area"]));
                     else if (fndnull(ds.Tables[0].Rows[i]["uom"]).toString() == "ROW")
                         totcc = totcc + parseFloat(fndnull(ds.Tables[0].Rows[i]["Area"]));
              
                 }
        
          
           
                 tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["Color_code"]).toString() + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>&nbsp;&nbsp;");
           tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["Page"]).toString() + "</td>");


           tbl = tbl + ("<td class='rep_data' align='left'>&nbsp;&nbsp;");


           if (fndnull(ds.Tables[0].Rows[i]["PagePremium"]).toString() == "0")
           {
               tbl = tbl + "" + "</td>";
           }
           else
           {
          tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["PagePremium"]).toString() + "</td>");
           }
           tbl = tbl + ("<td class='rep_data' align='left' width='1%'>&nbsp;&nbsp;");
           if (fndnull(ds.Tables[0].Rows[i]["PositionPremium"]).toString() == "0")
           {
               tbl = tbl + "" + "</td>";
           }
           else
           {
               tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["PositionPremium"]).toString() + "</td>");
           }

           tbl = tbl + ("<td class='rep_data' align='left' width='1%'>&nbsp;&nbsp;");
           if (fndnull(ds.Tables[0].Rows[i]["BulletPremium"]).toString() == "0")
           {
               tbl = tbl + "" + "</td>";
           }
           else
           {
               tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["BulletPremium"]).toString() + "</td>");
           }

           tbl = tbl + ("<td class='rep_data' align='left'>&nbsp;&nbsp;");
            tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["RoNo."]).toString() + "</td>");


            var RoStatus1 = "";
            var rrr4 = fndnull(ds.Tables[0].Rows[i]["RoStatus"]).toString();

           if(rrr4.length>9)
           RoStatus1=rrr4.substring(0,9)+"</br>"+rrr4.substring(9,18);
           else
           RoStatus1=rrr4;
           
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (RoStatus1 + "</td>");

         

            var AdCat1 = "";
            var rrr5 = fndnull(ds.Tables[0].Rows[i]["AdCat"]).toString() ;
            if(rrr5.length>9)
           AdCat1=rrr5.substring(0,9)+"</br>"+rrr5.substring(9,18);
           else
           AdCat1=rrr5;
           
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (AdCat1 + "</td>");

            tbl = tbl + ("<td class='rep_data' align='right'>");

            if (fndnull(ds.Tables[0].Rows[i]["CardRate"]).toString() == "")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {

                tbl = tbl + (parseFloat(fndnull(ds.Tables[0].Rows[i]["CardRate"])).toString() + "</td>");
            }
                   tbl = tbl + ("<td class='rep_data' align='right'>");
            if (fndnull(ds.Tables[0].Rows[i]["AgreedRate"]).toString() == "")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {

                tbl = tbl + (parseFloat(fndnull(ds.Tables[0].Rows[i]["AgreedRate"])).toString() + "</td>");

            }
                tbl = tbl + ("<td class='rep_data' align='right'>&nbsp;&nbsp;");

                if (fndnull(ds.Tables[0].Rows[i]["Amt"]).toString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {

                    tbl = tbl + (parseFloat(fndnull(ds.Tables[0].Rows[i]["Amt"])).toString() + "</td>");
                }
           
            if (fndnull(ds.Tables[0].Rows[i]["Amt"]).toString() != "")
                amt = amt + parseFloat(fndnull(ds.Tables[0].Rows[i]["Amt"]));

            tbl = tbl + ("<td class='rep_data' colspan='2' align='left'>");
           
            tbl = tbl + fndnull(ds.Tables[0].Rows[i]["Cap"]).toString() ;

            tbl = tbl + "</br>";

            tbl = tbl + (fndnull(ds.Tables[0].Rows[i]["Key"]).toString() + "</td>");

          
            tbl = tbl + "</tr>";
            // document.getElementById('tblgrid').innerHTML+= tbl;
            // tbl = "";

        }
        
       
       tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + cont.toString() + "</td>");
        tbl = tbl + "<td class='middle13new' colspan='3'>&nbsp;</td>" ;


        tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
       var cal = parseFloat(area).toFixed(2);       
        tbl = tbl + (cal + "</td>");
       
        if (totrol > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
            var calf = parseFloat(totrol).toFixed(2);      
            tbl = tbl + (calf + "</td>");
         
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcd > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
           var calfd =parseFloat(totcd).toFixed(2);      
           tbl = tbl + (calfd + "</td>");
         
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcc > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
           var calft =parseFloat(totcc).toFixed(2);      
            tbl = tbl + (calft + "</td>");
          
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }


        tbl = tbl + ("<td  class='middle13new'  align='right' style='font-size: 13px;'><b>Amt:</b></td>");
        tbl = tbl + ("<td class='middle13new' colspan='8' style='font-size: 13px;'>");
        tbl = tbl + (amt.toFixed(2) + "</td>");  


        tbl = tbl + "</tr>";
      
        tbl = tbl + ("</table>");
        
        document.getElementById('tblgrid').innerHTML+= tbl;
}