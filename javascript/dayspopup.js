var browser = navigator.appName;


function checkedunchecked(q) {
    var status = document.getElementById('CheckBox8').checked;
    if (status == true) {
        document.getElementById('CheckBox8').checked = true;
        if (document.getElementById('CheckBox1').disabled == false) {
            document.getElementById('CheckBox1').checked = true;
        }
        if (document.getElementById('CheckBox2').disabled == false) {
            document.getElementById('CheckBox2').checked = true;
        }
        if (document.getElementById('CheckBox3').disabled == false) {
            document.getElementById('CheckBox3').checked = true;
        }
        if (document.getElementById('CheckBox4').disabled == false) {
            document.getElementById('CheckBox4').checked = true;
        }
        if (document.getElementById('CheckBox5').disabled == false) {
            document.getElementById('CheckBox5').checked = true;
        }
        if (document.getElementById('CheckBox6').disabled == false) {
            document.getElementById('CheckBox6').checked = true;
        }
        if (document.getElementById('CheckBox7').disabled == false) {
            document.getElementById('CheckBox7').checked = true;
        }
        document.getElementById('CheckBox8').checked = true;
        return;

    }
    else {
        document.getElementById('CheckBox1').checked = false;
        document.getElementById('CheckBox2').checked = false;
        document.getElementById('CheckBox3').checked = false;
        document.getElementById('CheckBox4').checked = false;
        document.getElementById('CheckBox5').checked = false;
        document.getElementById('CheckBox6').checked = false;
        document.getElementById('CheckBox7').checked = false;
        document.getElementById('CheckBox8').checked = false;
        return;
    }
    return;


}
function fillchk_chkbox() {
    lchk = 0;
    if ((document.getElementById('CheckBox1').disabled == false) && (document.getElementById('CheckBox1').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }

    if ((document.getElementById('CheckBox2').disabled == false) && (document.getElementById('CheckBox2').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox3').disabled == false) && (document.getElementById('CheckBox3').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox4').disabled == false) && (document.getElementById('CheckBox4').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox5').disabled == false) && (document.getElementById('CheckBox5').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox6').disabled == false) && (document.getElementById('CheckBox6').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox7').disabled == false) && (document.getElementById('CheckBox7').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox1').disabled == false) && (document.getElementById('CheckBox1').checked == true)) {
        lchk++;
    }

    if ((document.getElementById('CheckBox2').disabled == false) && (document.getElementById('CheckBox2').checked == true)) {
        lchk++;
    }
    if ((document.getElementById('CheckBox3').disabled == false) && (document.getElementById('CheckBox3').checked == true)) {
        lchk++;
    }
    if ((document.getElementById('CheckBox4').disabled == false) && (document.getElementById('CheckBox4').checked == true)) {
        lchk++;
    }
    if ((document.getElementById('CheckBox5').disabled == false) && (document.getElementById('CheckBox5').checked == true)) {
        lchk++;
    }
    if ((document.getElementById('CheckBox6').disabled == false) && (document.getElementById('CheckBox6').checked == true)) {
        lchk++;
    }
    if ((document.getElementById('CheckBox7').disabled == false) && (document.getElementById('CheckBox7').checked == true)) {
        lchk++;
    }

    if (lchk == kchk) {
      document.getElementById('CheckBox8').checked = true;
    }
    return;
}
 