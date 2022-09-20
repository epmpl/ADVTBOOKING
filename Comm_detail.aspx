<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Comm_detail.aspx.cs" Inherits="Comm_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD Xhtml 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Agency Master Commission Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/contact.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/capital.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<style type="text/css">            .style3
            {
                width: 172px;
            }
            .style4
            {
                width: 133px;
            }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" language="javascript">
		
		
		
		
		
		
		function notchar2(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
            if((event.which>=48 && event.which<=57)||
            (event.which==127)||(event.which==8)||(event.which==190)||(event.which==37)||(event.which==46)||(event.which==39)||

            (event.which==9 || event.which==32 || event.which==0))
            {

            if(event.shiftKey==true && (event.which>=48 && event.which<=57))
            {
            return false
            }
            return true;
            }
            else
            {
            return false;
            }
 }
 else
 {
           if((event.keyCode>=48 && event.keyCode<=57)||
            (event.keyCode==127)||(event.keyCode==8)||(event.keyCode==190)||(event.keyCode==37)||(event.keyCode==46)||(event.keyCode==39)||

            (event.keyCode==9 || event.keyCode==32))
            {

            if(event.shiftKey==true && (event.keyCode>=48 && event.keyCode<=57))
            {
            return false
            }
            return true;
            }
            else
            {
            return false;
            } 
 }           
}
	function notchar21()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==46)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}	
		
		function delete1(a,b,c,d,code)
		{
		//alert(code);
		
		Comm_detail.delete1(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,document.getElementById(d).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete1);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete1(response)
		{
		var ds;
		ds=response.value;
		alert( " Record Deleted");
		window.location=window.location;
		
		}
		
		
//function notchar212(event)
//{
//var browser=navigator.appName;
// if(browser!="Microsoft Internet Explorer")
// {
//         if((event.which>=46 && event.which<=57)|| (event.which>=96 && event.which<=105) || (event.which==111) || (event.which==127) || (event.which==190) ||(event.which==8)||(event.which==9) || (event.which==13) || (event.which==0))
//        {
//        return true;
//        }
//        else
//        {
//        return false;
//        }
//  }   
//  else
//  {

//         if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==190) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
//        {
//        return true;
//        }
//        else
//        {
//        return false;
//        }
//  }
		//}


		function notchar212(event) {
		    //alert(event.keyCode);
		    var browser = navigator.appName;
		    if (browser != "Microsoft Internet Explorer") {
		        if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }
		    else {
		        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }
		}


function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9))
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
     if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11) || (event.which == 9))
   {

       return true;
   }
   else
   {
       return false;
   }
  }
}
		
		
		
		function issueaccelerate(a,b,c,d,code)
		{
		
		
		var fromdate=document.getElementById(a).value;
		var todate=document.getElementById(b).value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		 
		
		 if(fromdate !='' && todate !='' && fdate > tdate)
		{
		alert("To Date Must Be Greater Then From Date");
		return false;
		}
		 
		
		if(document.getElementById(d).value != "Gross" && document.getElementById(d).value != "Net")
		{
		alert("Enter Either Gross Or Net");
		return false;
		}
		
		
		/*if(abc(document.getElementById(c).value)=="")  
		{
		alert("Enter Only Digits");
		return false;
		}*/
		
		Comm_detail.update(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,document.getElementById(d).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete(response)
		{
		var ds;
		ds=response.value;
		alert( " Record Updated");
		window.location=window.location;
		
		//window.open('Comm_detail.aspx');
		}
		
		
		
		
		function notchar()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==8)||
(event.keyCode==189)||
(event.keyCode==36)||
(event.keyCode==35)||
(event.keyCode==46)||
(event.keyCode==37)||
(event.keyCode==39)||
(event.keyCode>=96 && event.keyCode<=105)||
(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

function dateenter()
{
//alert(event.keyCode);

if((event.keyCode>=47 && event.keyCode<=57))
{
return true;
}
else
{
return false;
}
}




function abc(str)
{

var a="0123456789()-";
var i=0;
do
{
var pos=0;
for(var j=0;j<a.length;j++)
if(str.charAt(i)==a.charAt(j))
{
pos=1;
break;
}
i++;

}
while(pos==1 && i<str.length)
if(pos ==0)

return false;
//alert(str);
//return true;
}

function deletemassege()
{
if (confirm("Are you sure you want to delete?")==true)  
{
return true;
}
else
{
return false;
}
/*document.getElementById('btndelete').disabled=true;*/
}





		function validate(form)
		{
		var fromdate=document.getElementById('txtefffrom').value;
		var todate=document.getElementById('txtefftill').value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		var x= document.getElementById('drpcommdetail').value;
		alert(x);
			
		if (document.getElementById('txtefffrom').value=="")
		{
		alert("Plese Fill Effective From");
		return false;
		}	
		else if (document.getElementById('txtefftill').value=="")
		{
		alert("Plese Fill Effective To");
		return false;
		}	 
		else if(fromdate !='' && todate !='' && fdate > tdate)
		{
		alert("To Date Must Be Greater Then From Date");
		document.getElementById('txtefftill').focus();
		return false;
		}					
		else if(document.getElementById('txtcommrate').value=="")
		{
		alert(" Please Fill The commission Value");
		document.getElementById('txtcommrate').focus();
		return false;
		}
		else if(document.getElementById('drpcommdetail').value=='0')
		{
		alert("Please Select value");
		document.getElementById('drpcommdetail').focus();
		return false;
		}
		else
		{
		return true;
		}
		}
		
		
		
		
function pubopen()
		{ 

  for ( var index = 0; index < 200; index++ ) 
  { 

 var show=document.getElementById('hiddenshow').value;
  var agencode=document.getElementById('hiddenagevcode').value;
  var agensubcode=document.getElementById('hiddenagensubcode').value;
    popUpWinpub 
     = window.open('pub_mast.aspx?agecode='+agencode+'&agencysubcode='+agensubcode+'&show='+show,'Ankur','resizable=1,toolbar=0,top=270,left=215,scrollbars=yes,width=775px,height=398px');
  popUpWinpub.focus();
     return false;
  } 

} 
		
	
		
	
		</script>
	</head>
	<body  onkeydown="javascript:return tabvalue(event);" onkeypress="eventcalling(event);">
		
        <form id="Form1" runat="server" method="post">
                <table id="Table4" align="center" border="1" bordercolor="#000000" cellpadding="0"
                    cellspacing="0" width="632">
                    <tr valign="middle">
                        <td>
                            <table id="Table3" align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                                width="633">
                                <tr>
                                    <td align="center" class="btnlink">
                                        Commission Detail</td>
                                </tr>
                            </table>
                            <table id="Table5" align="center" border="0" cellpadding="0" cellspacing="0" width="597">
                                <tr>
                                    <td>
                                        <table id="Table9" align="center" border="0" cellpadding="0" cellspacing="0" style="width: 615px">
                                            <tr>
                                                <td colspan="4" height="19">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Label ID="EffectiveFrom" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td class="style3">
                                                    <asp:TextBox onkeydown="return datecurr(event);" ID="txtefffrom" runat="server" MaxLength="10"   CssClass="startandenddate"></asp:TextBox>

                                                   <img src='Images/cal1.gif' id="dav1"  onclick='popUpCalendar(this, Form1.txtefffrom, "mm/dd/yyyy")' onfocus="abc()" height=14  width=14 />

                                                </td>
                                                <td>
                                                    <asp:Label ID="EffectiveTill" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox onkeydown="return datecurr(event);" ID="txtefftill" runat="server" MaxLength="10"  CssClass="startandenddate"></asp:TextBox>
                                                    
                                                    <img src='Images/cal1.gif'id="dav2"  onclick='popUpCalendar(this, Form1.txtefftill, "mm/dd/yyyy")' onfocus="abc()" height=14 width=14 /> </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Label ID="CommissionRate" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td class="style3">


                                                    <asp:TextBox ID="txtcommrate" runat="server" CssClass="numerictext" MaxLength="6" onkeypress="return notchar212(event);"></asp:TextBox></td>
                                              <td>
                                                    <asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Add. Agency Comm."></asp:Label></td>
                                                    <td>


                                                    <asp:TextBox ID="txtaddcomm" runat="server" CssClass="numerictext" MaxLength="6" onkeypress="return notchar212(event);" onpaste="return false;"></asp:TextBox></td>
                                            </tr>
                                            <tr>  <td class="style4">
                                                    <asp:Label ID="CommissionApplyOn" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td class="style3">
                                                    <asp:DropDownList ID="drpcommdetail" runat="server" CssClass="dropdown">
                                                    <asp:ListItem  Value="Net" Selected="True">Net</asp:ListItem>
                                                     <asp:ListItem Value="Gross">Gross</asp:ListItem>
                                                    </asp:DropDownList></td> 
                                                    
                                                    <td>
                                                    <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                </td>
                                                    
                                                    </tr>
                                            <tr>
                                            <td class="style4">
                                                <asp:Label ID="lbluom" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td class="style3">
                                                
                                                        <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false" >
                                                        <asp:ListItem Value="0">Select Uom</asp:ListItem>
                                                        </asp:DropDownList>
                                                </td>
                                                
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td>
                                                     <asp:DropDownList ID="drpagen" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false" >
                                                        <asp:ListItem Value="1">ON</asp:ListItem>
                                                        <asp:ListItem Value="0">OFF</asp:ListItem></asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Label ID="lblcdisc" runat="server" CssClass="TextField" Text="Cash Discount"></asp:Label></td>
                                                <td class="style3">
                                                    <asp:DropDownList ID="drpcashdis" runat="server" CssClass="dropdown">
                                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="F">Fixed</asp:ListItem>
                                                        <asp:ListItem Value="P">Percentage</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td><asp:Label ID="lblcsamt" runat="server" CssClass="TextField">Cash Amount</asp:Label></td>
                                                <td><asp:TextBox ID="txtcsamt" runat="server" CssClass="btext1" onkeypress="return notchar21();" ></asp:TextBox></td>
                                            </tr>
                                            
                                            
                                            <tr>
                                               
                                                 <td>
                                                    <asp:Label ID="lbadcat1" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dpadcat" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                </td></tr>
                                            
                                            
                                            
                                            
                                            
                                            <tr>
                                                <td class="style4">
                                                </td>
                                                <td class="style3">
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="button1" OnClick="btnSubmit_Click" /><asp:Button
                                                        ID="btnclear" runat="server" CssClass="button1" />
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                </td>
                                                <td class="style3">
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <div>
                                            <table align="center">
                                                <tr>
                                                    <td align="center">
                                                        <div  id="Divgrid1" runat="server"  style="overflow: auto; width: 600px; height: 94px">
                                                            <asp:DataGrid ID="DataGrid1" CssClass="dtGrid"  runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                Width="584px" OnSortCommand="DataGrid1_SortCommand"  >
                                                                <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                                                                <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                                                                    HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:TemplateColumn>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateColumn>
                                                                    <asp:BoundColumn DataField="Eff_from_date" HeaderText="Effective From" SortExpression="Eff_from_date">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Eff_Till_date" HeaderText="Effective To" SortExpression="Eff_Till_date">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Comm_rate" HeaderText="Commission Rate" SortExpression="Comm_rate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Discount" HeaderText="Commision Applied On" SortExpression="Discount">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="ADTYPENAME" HeaderText="Ad Type"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="COMM_CODE" HeaderText="Code" ReadOnly="True" Visible="False">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Addl_Comm_Rate" HeaderText="Add. Comm. Rate"></asp:BoundColumn>
                                                                     <asp:BoundColumn DataField="UOM" HeaderText="UOM"></asp:BoundColumn>
                                                                      <asp:BoundColumn DataField="ADDITIONAL_FLAG" HeaderText="ADDITIONAL_FLAG"></asp:BoundColumn>
                                                                      <asp:BoundColumn DataField="CASH_DISCOUNTTYPE" HeaderText="Cash Discount"></asp:BoundColumn>
                                                                      <asp:BoundColumn DataField="CASH_DISCOUNT" HeaderText="Cash Amt."></asp:BoundColumn>
                                                                      
                                                                       <asp:BoundColumn DataField="ADSUBCAT1" HeaderText="Ad sub Category" SortExpression="ADSUBCAT1">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                      
                                                                      
                                                                    <asp:TemplateColumn HeaderText="Update" Visible="False">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="Delete" Visible="False">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle HorizontalAlign="Center" />
                                                            </asp:DataGrid>
                                                            
                                                            
                                                            
                                                            
                                                            </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td>
                                                <div id="Divgrid2" runat="server" style="overflow: auto; width: 600px; height: 94px">
                                                            <asp:DataGrid ID="DataGrid2" runat="server"  CssClass="dtGrid" AllowSorting="True" AutoGenerateColumns="False"
                                                                Width="584px" OnSortCommand="DataGrid1_SortCommand"  >
                                                                <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                                                                <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                                                                    HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="Eff_from_date" HeaderText="Effective From" SortExpression="Eff_from_date">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Eff_Till_date" HeaderText="Effective To" SortExpression="Eff_Till_date">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Comm_rate" HeaderText="Commission Rate" SortExpression="Comm_rate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Discount" HeaderText="Commision Applied On" SortExpression="Discount">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="adtype" HeaderText="Ad Type"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="adtypecode" ReadOnly="True" Visible="False"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="COMM_CODE" HeaderText="Code" ReadOnly="True" Visible="False">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Addl_Comm_Rate" HeaderText="Add. Comm. Rate"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="UOM" HeaderText="UOM"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="ADDITIONAL_FLAG" HeaderText="ADDITIONAL_FLAG"></asp:BoundColumn>
                                                                      <asp:BoundColumn DataField="CASH_DISCOUNTTYPE" HeaderText="Cash Discount"></asp:BoundColumn>
                                                                      <asp:BoundColumn DataField="CASH_DISCOUNT" HeaderText="Cash Amt."></asp:BoundColumn>
                                                                      
                                                                      
                                                                      
                                                                        <asp:BoundColumn DataField="ADSUBCAT1" HeaderText="Ad sub Category" SortExpression="ADSUBCAT1">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundColumn>
                                                                      
                                                                      
                                                                    <asp:TemplateColumn HeaderText="Update" Visible="False">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="Delete" Visible="False">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle HorizontalAlign="Center" />
                                                            </asp:DataGrid></div>
                                                
                                                </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <!--<asp:LinkButton ID="lbpubmaster" runat="server" Font-Underline="True" ForeColor="#7DAAE3"
                                                            Width="117px">Publication Master</asp:LinkButton>--><input id="hiddenccode" runat="server"
                                                                name="hiddenccode" size="1" style="width: 35px; height: 22px" type="hidden" /><input
                                                                    id="hiddencomcode" runat="server" name="hiddencomcode" size="10" type="hidden" />
                                                        <input id="hiddenuserid" runat="server" name="hiddenuserid" size="9" type="hidden" />
                                                        <input id="hiddenagevcode" runat="server" name="hiddenagevcode" size="9" type="hidden" />
                                                        <input id="hiddenagensubcode" runat="server" name="hiddenagensubcode" size="3" style="width: 51px;
                                                            height: 22px" type="hidden" />
                                                            
                                                        <asp:Label ID="Label5" runat="server">Label</asp:Label></td>
                                                </tr>
                                                <tr align="right">
                                                    <td align="right">
                                                        <input id="hiddenshow" runat="server" name="hiddenccode" size="1" style="width: 35px;
                                                            height: 22px" type="hidden" /><input id="hiddendateformat" runat="server" type="hidden" /><asp:Button
                                                                ID="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click" /><asp:Button ID="btndelete"
                                                                    runat="server" CssClass="button1" Enabled="False" />
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table id="Table6" align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                                width="634">
                                <tr>
                                    <td align="center">
                                    <input id="hideshow" type="hidden" size="1" name="hideshow" runat="server"/>
                                    <input id="hiddenuom" type="hidden" size="15" name="hiddenuom" runat="server"/>
                                    <input id="hiddensubcat" type="hidden" size="15" name="hiddensubcat" runat="server"/>
                                    <input id="hiddensubcat1" type="hidden" size="15" name="hiddensubcat1" runat="server"/>
                                     <input id="hdnconntype" type="hidden" size="15" name="hdnconntype" runat="server"/>
                                    </td>
                                </tr>
                            </table>
                            <div>
                            </div>
                        </td>
                    </tr>
                </table>
                &nbsp;
            </form>
			</body>
</html>