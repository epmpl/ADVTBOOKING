<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newlayout.ascx.cs" Inherits="newlayout" %>

<script type="text/javascript" src="js/enterortab.js"></script>

<script type="text/javascript" src="js/ctrl.js"></script>

<div id="newdialog" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; width: 210px;height:350px; left: 2px;" unselectable="on">
    <%--onpropertychange="javascript:onloadtxt();">--%>
    <table onkeydown="javascript:tabvalue();" cellpadding="0" cellspacing="0">
        <%--<table id="layouttab" border="0">--%>
        <tr>
            <td colspan="2" style="width: 208px">
                <img src="images/global-library.jpg" usemap="#closemapN" width="203px" unselectable=on  />
                <map id="closemapN" name="closemapN" class="handcursor">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closepropN();" />
                </map>
            </td>
        </tr>
        <%--<tr>
        <td>
         <asp:Label ID="lblcatname" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px" Text=" ChooseCategory" Width="62px"></asp:Label>
         </td>
          <td align="center" style="width: 92px"><asp:DropDownList ID="catname" runat="server"   CssClass="dropdowns" Width="82px"></asp:DropDownList>
           </td>
          </tr>--%>
        <tr>
            <td colspan="2" style="width: 208px">
                <%--style="height: 362px"--%>
                <!-- td for the layout content -->
                <div id="Div1" runat="server" style="overflow: auto; height: 300px" nowrap="noWrap">
                    <table border="1" cellpadding="0" cellspacing="0" style="background-color: ButtonFace">
                        <%--style="width: 29%; height: 50%">--%>
                        <tr>
                            <td id="img1" style="border: solid;">
                                <%--<asp:ImageButton ID="t000" ImageUrl="~/images/images0.png" runat="server" OnClick="javascript:closeme()" />--%>
                                <img id="i1" name="i1" src="images/images00.png" ondblclick="javascript:newdocument(this);document.getElementById('newdialog').style.display='none';"
                                    onclick="javascript:getselect(this);" onmouseover="if(currentid==null)document.getElementById('img1').style.borderColor='blue';"
                                    onmouseout="if(currentid==null)document.getElementById('img1').style.borderColor='buttonface';" oncontrolselect="javascript:return ajay();" /></td>
                            <td>
                                <span class="proplbl">Create a Blank Template </span>
                            </td>
                        </tr>
                        <tr>
                            <td id="img2" style="border: solid;">
                                <%--<asp:ImageButton ID="t001" ImageUrl="~/images/images1.png" runat="server" />--%>
                                <img id="i2" name="i2" src="images/images11.PNG" ondblclick="javascript:createnew2();document.getElementById('newdialog').style.display='none';"
                                    onclick="javascript:getselect(this);" onmouseover="if(currentid==null)document.getElementById('img2').style.borderColor='blue';"
                                    onmouseout="if(currentid==null)document.getElementById('img2').style.borderColor='buttonface';" /></td>
                            <td>
                                <span class="proplbl">Blank Template with a Picture Box and a text Below </span>
                            </td>
                        </tr>
                        <%--<tr>
                                <td id = img3 style="width: 200px;border:solid;">
                                   <%-- <asp:ImageButton ID="t002" ImageUrl="~/images/images2.png" runat="server" />
                                    <img name=i3 src="images/images2.PNG" ondblclick="javascript:createnew3();"onclick="javascript:getselect();" onmouseover="if(currentid==null)document.getElementById('img3').style.borderColor='blue';" onmouseout="if(currentid==null)document.getElementById('img3').style.borderColor='buttonface';"/></td>
                            </tr>--%>
                        <tr>
                            <td id="img4" style="border: solid;">
                                <%-- <asp:ImageButton ID="t003" ImageUrl="~/images/images3.png" runat="server" />--%>
                                <img id="i4" name="i4" src="images/images33.PNG" ondblclick="javascript:createnew4();document.getElementById('newdialog').style.display='none';"
                                    onclick="javascript:getselect(this);" onmouseover="if(currentid==null)document.getElementById('img4').style.borderColor='blue';"
                                    onmouseout="if(currentid==null)document.getElementById('img4').style.borderColor='buttonface';" /></td>
                            <td>
                                <span class="proplbl">Template with TextBox and Address Box contain lower TextBox </span>
                            </td>
                        </tr>
                        <tr>
                            <td id="img5" style="border: solid;">
                                <%--<asp:ImageButton ID="t004" ImageUrl="~/images/images4.png" runat="server" />--%>
                                <img id="i5" name="i5" src="images/images44.PNG" ondblclick="javascript:createnew5();document.getElementById('newdialog').style.display='none';"
                                    onclick="javascript:getselect(this);" onmouseover="if(currentid==null)document.getElementById('img5').style.borderColor='blue';"
                                    onmouseout="if(currentid==null)document.getElementById('img5').style.borderColor='buttonface';" /></td>
                            <td>
                                <span class="proplbl">Template with Two Picture box and TextBox </span>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <%--<td align="right" style="width: 198px; height: 21px">
                    <!-- td for the create button  
                    <asp:Button ID="create" Text="Create New" ToolTip="click to create" runat="server"
                        Width="83px" /> -->
                </td>--%>
            <td atomicselection="true" align="right" style="height: 26px">
                <!-- td for the cancel button  -->
                <input type="button" id="opennew" value="Open" onclick="javascript:newdocument(this);" class="inputbutton" />
                <%--<input type="checkbox" id="cattmp" runat="server" value="Category Name" class="proplbl" onclick="javascript:return catwise(this);" />
                <input type="checkbox" id="gllib" runat="server" value="GloBLib" class="proplbl" />--%>
                <%--<asp:CheckBox ID="cattmp" runat="server" Text="CatWise" CssClass="proplbl" onclick="javascript:return catwise();" />
                <asp:CheckBox ID="gllib" runat="server" Text="GloBLib" CssClass="proplbl" />--%>
                <%--<input type="button" id="cancel" value="Cancel" onclick="document.getElementById('newdialog').display='none';" class="inputbutton" />--%>
            </td>
        </tr>
    </table>
</div>
