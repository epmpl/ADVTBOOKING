// JScript File

  function printIt()
{
//grab the div in the html w/o the header & footer text
var content=document.getElementById('testnew');
//open a blank window
w=window.open('about:blank');
//write content var html to the window
w.document.open();
w.document.write("<html>" + content.innerHTML);
//write some javascript to make the newly opened window print itself.
w.document.writeln("<script>window.print()</"+"script>");
w.document.writeln("</html>");
w.document.close();
}

function custom_print() 
{
if (document.all) {
if (navigator.appVersion.indexOf("5.0") == -1) {
var OLECMDID_PRINT = 6;
var OLECMDEXECOPT_DONTPROMPTUSER = 2;
var OLECMDEXECOPT_PROMPTUSER = 1;
var WebBrowser = "<OBJECT ID=\"WebBrowser1\" WIDTH=0 HEIGHT=0 CLASSID=\"CLSID:8856F961-340A-11D0-A96B-00C04FD705A2\"></OBJECT>";
document.body.insertAdjacentHTML("beforeEnd", WebBrowser);
WebBrowser1.ExecWB(6, 2);
WebBrowser1.outerHTML = "";
} else {
self.print();
}
} else {
self.print();
}
}
