var jq = jQuery.noConflict();
jq(document).on('focus', ':input', function () {
    jq(this).attr('autocomplete', 'off');
}).on('paste', ':input', function () {
    if (this.accept == "numeric" || this.accept == "decimal") {
        return false;
    }
}).on('drop', ':input', function () {
    if (this.accept == "numeric" || this.accept == "decimal") {
        return false;
    }
}).on('keypress', ':input', function (e) {
    if (this.accept == "numeric") {
        var keyCode = e.which ? e.which : e.keyCode
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(46);//Delete
        if (e.char == ".")
            return false;

        if ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1) {
            return true;
        }
        else {
            return false;
        }
    }
    else if (this.accept == "decimal") {
        var keyCode = e.which ? e.which : e.keyCode
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(46);//Delete
        if (e.char == ".") {
            if ((this.value) && (this.value.indexOf('.') >= 0))
                return false;
            else
                return true;
        }
        if (keyCode != 8 && keyCode != 46 && keyCode != 37 && keyCode != 39) {
            if (this.value.indexOf('.') >= 0) {
                var str = this.value.split('.');
                if (str[1].length > 1) {
                    return false;
                }
            }
        }
        if ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1) {
            return true;
        }
        else {
            return false;
        }
    }
}).on('blur', ':input', function (e) {
    if (this.accept == "date") {
        var txtVal = this.value;
        if (txtVal == '')
            return false;
        if (CheckDate(txtVal) == false) {
            alert('The date format should be : dd/mm/yyyy');
            this.value = "";
            jq('#' + this.id).focus();
            setTimeout(function () {
                jq('#' + this.id).focus();
            }, 1);
            return false;
        }
    }
});
function fndnull(val) {
    if (val == null || val == "null" || val == undefined || val == "undefined")
        val = ""
    return val
}
function blank_space(val) {
    if (val == "" || val == null || val == undefined || val == "null" || val == "undefined") {
        val = "&nbsp";
    }
    return val
}
function blank_to_zero(val) {
    if (val == "" || val == null || val == undefined || val == "null" || val == "undefined") {
        val = 0
    }
    return val
}
function CheckDate(txtDate) {
    var currVal = txtDate;
    if (currVal == '')
        return false;

    var rxDatePattern = /^(\d{2,2})(\/|)(\d{2,2})(\/|)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern);

    if (dtArray == null)
        return false;

    dtDay = dtArray[1];
    dtMonth = dtArray[3];
    dtYear = dtArray[5];

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }
    return true;
}
function CheckDateForGrid(id) {
    var currVal = document.getElementById(id).value;
    if (currVal == '')
        return false;

    var rxDatePattern = /^(\d{2,2})(\/|)(\d{2,2})(\/|)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern);

    if (dtArray == null) {
        alert('The date format should be : dd/mm/yyyy');
        jq('#' + id).val('')
        jq('#' + id).focus();
        return false;
    }
    dtDay = dtArray[1];
    dtMonth = dtArray[3];
    dtYear = dtArray[5];

    if (dtMonth < 1 || dtMonth > 12) {
        alert('The date format should be : dd/mm/yyyy');
        jq('#' + id).val('')
        jq('#' + id).focus();
        return false;
    }
    else if (dtDay < 1 || dtDay > 31) {
        alert('The date format should be : dd/mm/yyyy');
        jq('#' + id).val('')
        jq('#' + id).focus();
        return false;
    }
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
        alert('The date format should be : dd/mm/yyyy');
        jq('#' + id).val('')
        jq('#' + id).focus();
        return false;
    }
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap)) {
            alert('The date format should be : dd/mm/yyyy');
            jq('#' + id).val('')
            jq('#' + id).focus();
            return false;
        }
    }
    return true;
}
function offset(activeid, divid, listboxid) {
    jq('#' + listboxid).empty();
    document.getElementById(divid).style.top = jq("#" + activeid).position().top + 18 + "px";
    document.getElementById(divid).style.left = jq("#" + activeid).position().left + "px";
    jq('#' + divid).show("slow");
    document.getElementById(listboxid).focus();
}
function OffSetForGrid(activeid, divid, listboxid, griddivid) {
    jq('#' + listboxid).empty();
    document.getElementById(divid).style.top = jq("#" + activeid).position().top + 18 + "px";
    document.getElementById(divid).style.left = jq("#" + activeid).position().left + "px";
    jq('#' + divid).show("slow");
    document.getElementById(listboxid).focus();
}
function offSetForGridChildDiv(activeid, divid, listboxid, griddivid) {
    jq('#' + listboxid).empty();
    document.getElementById(divid).style.top = jq("#" + activeid).position().top + jq("#" + griddivid).position().top + 18 + "px";
    document.getElementById(divid).style.left = jq("#" + activeid).position().left + jq("#" + griddivid).position().left + "px";
    jq('#' + divid).show("slow");
    document.getElementById(listboxid).focus();
}
function check_mendetory(id) {
    var label_text = jq('#' + id).text();
    return label_text;
}

(function ($) {
    $.fn.check_mendetory_star = function () {
        if (this.text().indexOf('*') >= 0)
            return true;
        else
            return false;
    };
    $.fn.get_lable_text = function () {
        return this.text().split('*', 1);
    };
}(jQuery));

function OnClickExit() {
    if (confirm('Do you want skip the page')) {
        window.close();
        return false;
    }
    return false;
}

function ConvertJsonDate(dt) {
    var newdt = CHKDATE(eval(dt.replace(/\/Date\((\d+)\)\//gi, "new Date($1)")));
    return newdt;
}

function CHKDATE(userdate) {
    var mycondate = ""
    if (userdate == null || userdate == "") {
        mycondate = ""
        userdate = "";
        return mycondate
    }
    var dateformate = document.getElementById('hiddendateformat').value;
    if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
        var spmonth = "'" + userdate + "'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate = new Date(userdate);
        var date = myDate.getDate();

        if (date == 1 || date == 2 || date == 3 || date == 4 || date == 5 || date == 6 || date == 7 || date == 8 || date == 9)
            date = "0" + date;
        var month = myDate.getMonth() + 1;
        if (month == 1 || month == 2 || month == 3 || month == 4 || month == 5 || month == 6 || month == 7 || month == 8 || month == 9)
            month = "0" + month;
        var year = myDate.getFullYear();
        mycondate = date + "/" + month + "/" + year;
        return mycondate;
    }
    else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
        var spmonth = "'" + userdate + "'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate = new Date(userdate);
        var date = myDate.getDate();
        var month = myDate.getMonth() + 1;
        var year = myDate.getFullYear();
        mycondate = month + "/" + date + "/" + year;
        return mycondate;
    }
    else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
        var spmonth = "'" + userdate + "'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate = new Date(userdate);
        var date = myDate.getDate();
        var month = myDate.getMonth() + 1;
        var year = myDate.getFullYear();
        mycondate = year + "/" + month + "/" + date;
        return mycondate;
    }
}


function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function setButtonImages() {
    if (document.getElementById('btnNew').disabled == true)
        document.getElementById('btnNew').src = "btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src = "btimages/new.jpg";

    if (document.getElementById('btnSave').disabled == true)
        document.getElementById('btnSave').src = "btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src = "btimages/save.jpg";

    if (document.getElementById('btnModify').disabled == true)
        document.getElementById('btnModify').src = "btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src = "btimages/modify.jpg";

    if (document.getElementById('btnQuery').disabled == true)
        document.getElementById('btnQuery').src = "btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src = "btimages/query.jpg";

    if (document.getElementById('btnExecute').disabled == true)
        document.getElementById('btnExecute').src = "btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src = "btimages/execute.jpg";

    if (document.getElementById('btnCancel').disabled == true)
        document.getElementById('btnCancel').src = "btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src = "btimages/clear.jpg";

    if (document.getElementById('btnfirst').disabled == true)
        document.getElementById('btnfirst').src = "btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src = "btimages/first.jpg";

    if (document.getElementById('btnprevious').disabled == true)
        document.getElementById('btnprevious').src = "btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src = "btimages/previous.jpg";

    if (document.getElementById('btnnext').disabled == true)
        document.getElementById('btnnext').src = "btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src = "btimages/next.jpg";

    if (document.getElementById('btnlast').disabled == true)
        document.getElementById('btnlast').src = "btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src = "btimages/last.jpg";

    if (document.getElementById('btnDelete').disabled == true)
        document.getElementById('btnDelete').src = "btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src = "btimages/delete.jpg";

    if (document.getElementById('btnExit').disabled == true)
        document.getElementById('btnExit').src = "btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src = "btimages/exit.jpg";
}
function EnterTab(evt, id) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.className != "btextlist") && ((node.type == "text") || (node.type == "select-one") || (node.type == "radio") || (node.type == "checkbox"))) {
        getNextElement(node).focus();
        return false;
    }
}
function getNextElement(field) {
    var form = field.form;
    for (var e = 0; e < form.elements.length; e++) {
        if (field == form.elements[e]) {
            break;
        }
    }
    e++;
    while (form.elements[e % form.elements.length].type == undefined || form.elements[e % form.elements.length].type == "hidden" || form.elements[e % form.elements.length].disabled == true || form.elements[e % form.elements.length].id == "BtnTransporterDetail" || form.elements[e % form.elements.length].id.split('_')[0] == "btnshowstock" || form.elements[e % form.elements.length].type == "fieldset") {
        e++;
    }
    return form.elements[e % form.elements.length];
}
function compare_date(pfromdate, ptodate) {
    var pfrdt = document.getElementById(pfromdate).value
    var stodate = pfrdt.split("/");
    var dd = stodate[0];
    var mm = stodate[1];
    var yy = stodate[2];

    var ptodt = document.getElementById(ptodate).value
    var stfrdate = ptodt.split("/");
    var day = stfrdate[0];
    var month = stfrdate[1];
    var year = stfrdate[2];

    if ((year < yy) || ((dd > day && mm >= month) && year <= yy) || ((dd < day && mm > month) && year <= yy)) {
        alert("Invalid Date Range!\n'To Date should be  greater than From Date!")
        document.getElementById(ptodate).value = "";
        document.getElementById(ptodate).focus();
        return false;
    }
    else {
        return true;
    }
}
(function ($) {
    $.fn.extend({
        center: function () {
            return this.each(function () {
                var top = ($(window).height() - $(this).outerHeight()) / 2;
                var left = ($(window).width() - $(this).outerWidth()) / 2;
                $(this).css({ position: 'absolute', margin: 0, top: (top > 0 ? top : 0) + 'px', left: (left > 0 ? left : 0) + 'px' });
            });
        }
    });
})(jq);