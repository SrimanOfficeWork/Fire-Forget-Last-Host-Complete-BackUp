function win_hide() {

    window.parent.document.getElementById('interVeil').style.display = 'none';

}
function win_close() {
    window.parent.document.getElementById('interVeil').style.display = 'none';
    window.parent.adcodewindow.hide();
}

//ajax date edit mode when in chrome
(function () { try { var n = Sys.Extended.UI.MaskedEditBehavior.prototype, t = n._ExecuteNav; n._ExecuteNav = function (n) { var i = n.type; i == "keydown" && (n.type = "keypress"), t.apply(this, arguments), n.type = i } } catch (i) { return } })()
//ajax date edit mode when in chrome

function ShowProgress() {
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("Background");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);

}

$(window).bind("submit", function () {
    ShowProgress();
   
});

$(window).load(function () {
    
        Loading_HideImage();
});
$(function () {
    
////------------------------CHECK OUT ISALREADY LOGIN------------------------------//
//    var selectedValue = '';
//    $.ajax({
//        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CheckOut_IsAlready_Login",
//        data: "{ 'mail': '" + selectedValue + "'}",
//        dataType: "json",
//        type: "POST",
//        contentType: "application/json; charset=utf-8"

//    });
//    //------------------------CHECK OUT ISALREADY LOGIN------------------------------//
//    //------------------------Page Loading Process-----------------------------------//

    Loading_ShowImage();
    //------------------------Page Loading Process-----------------------------------//

});
function page_Loading() {

    ShowProgress();

}
function ShowImage(src) {

    document.getElementById(src).style.backgroundImage = 'url(../Loading_Images/ui-anim_basic_16x16.gif)';

    document.getElementById(src).style.backgroundRepeat = 'no-repeat';

    document.getElementById(src).style.backgroundPosition = 'right';
}
function HideImage(src) {
    document.getElementById(src).style.backgroundImage = 'none';
}
function Loading_ShowImage() {

    $('body').addClass('Background');
   
    var loading = $('#load');
    loading.show();
    var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
    var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
    loading.css({ top: top, left: left });
    //document.getElementById('load').style.display = 'block';

}
function Loading_HideImage() {
    $('body').removeClass('Background');
    var loading = $('#load');
    loading.hide();
   

}
//-----------------------------------START A TO Z FUNCTION--------------------------------------//

function Get_A_to_Z_Value_popup(val) {

    document.getElementById("hdn_A_to_Z_Search").value = val;
    document.getElementById("btn_A_TO_Z_Search").click();
}
//-----------------------------------START A TO Z FUNCTION--------------------------------------//




//-----------------------------------START HIGHLIGHT TODAY DATE FUNCTION--------------------------------------//

function CheckToday(sender, e) {
//    var format = sender._todaysDateFormat;
//    var date = new Date();
//    var formateddate = date.format(format);
//    var daycells = $get(sender.get_id() + "_body").getElementsByTagName("DIV");
//    alert(daycells);
//    for (var i = 0; i < daycells.length; i++) {
//        if (daycells[i].title.indexOf(formateddate) > -1) {
//            daycells[i].style.backgroundColor = "Red";
//            daycells[i].style.color = "White";
//            break;
//            
//        }
//        
//    }

}

//-----------------------------------END HIGHLIGHT TODAY DATE FUNCTION--------------------------------------//


//-----------------------------------START PARENT PAGE CLOSE FUNCTION--------------------------------------//

function close_button() {
    document.getElementById("btnCancel").click();
}
function Product_button() {
    document.getElementById("INVOICE").className = 'inactive';

    document.getElementById("ITEM").className = 'active';

   // document.getElementById("ITEM").click();
}
function Parent_tab_count(val) {
    
    document.getElementById("hdn_tab_count").value = val;

}
function Child_Parent_close_button1(val) {
    window.parent.close_button_IGM(val);

}

function close_button_IGM(val) {
    document.getElementById(val).click();

}

function Parent_close_button1() {
    //For main tap open and sub tab close
    if (document.getElementById("hdn_tab_count").value == '0') {
        Parent_close_button();
    }
    else {
        document.getElementById("hdn_tab_count").value = '0';
        activatables('page', ['page-1']);
      
         tab_page1('');
        //document.getElementById(val).click();
    }
    
}
function Parent_close_button() {
         window.parent.close_button();
  
}
function Product_Open_button() {

    window.parent.Product_button();
}

function Product_Open_button_Export() {

    window.parent.Product_button_Export();
}

function Product_button_Export() {
    /* hide by Chithra on 22-01-2024 for After click the Invoice to Item Link in grid  - Buttons are not visible in Item Page
    document.getElementById("INVOICE").className = 'inactive';
    document.getElementById("ITEM").className = 'active';
    // document.getElementById("ITEM").click();
    */

    /*document.getElementById("INVOICE").className = 'inactive';
    document.getElementById("ITEM").className = 'active';
    activatables('page', ['page-3']);
    tab_page3('');*/

    document.getElementById("INVOICE").className = 'inactive';
    document.getElementById("ITEM").className = 'active';


}
//-----------------------------------START FROM CHILD TO PARENT PAGE CLOSE FUNCTION--------------------------------------//

function Child_Parent_close_button() {

    window.parent.Parent_close_button();
}
//-----------------------------------END FROM CHILD TO PARENT PAGE CLOSE FUNCTION--------------------------------------//



//----------------------start- Its for - Menu tab auto open using SHORTCUT keys -------------
function Child_Parent_close_button1_Trigger_AnotherPage(val, Pagename) {
    window.parent.close_button_Trigger_AnotherPage(val, Pagename);

}

function close_button_Trigger_AnotherPage(val, pagename) {
  
    document.getElementById("hdn_source").value = pagename;
    document.getElementById(val).click();
    document.getElementById("hdn_source").value = '';
}
//----------------------end- Its for - Menu tab auto open using SHORTCUT keys -------------

    
//-----------------------------------  END PARENT PAGE CLOSE FUNCTION--------------------------------------//


//-----------------------------------START CLEAR FUNCTION FOR SINGLE DOT--------------------------------------//

function Clear_Dot(elem) {
    var firstChar = elem.value;
    if (firstChar.charAt(0) == ".") {
        elem.value = "";
    }
  
//    if (elem.value == ".")
//        elem.value = "";
}
//----------------------------------- END CLEAR FUNCTION FOR SINGLE DOT--------------------------------------//


//----------------------------------- START TEXT TRANSFORM T UPPERCASE FUNCTION--------------------------------------//
function ChangeCase(elem) {
    elem.value = elem.value.toUpperCase();
}
//----------------------------------- END TEXT TRANSFORM T UPPERCASE FUNCTION--------------------------------------//


//-----------------------------------START TEXTBOX-CHARACTER,NUMBER VALDATION FUNCTION--------------------------------------//

function notn(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 47 || charCode > 47))
        return false;
    return true;
}

function NOTNSLNO(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 65 || charCode > 91) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode < 40 || charCode > 41) && (charCode < 93 || charCode > 93))
        return false;
    return true;
}
function num5(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function numchar2(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}




function desc2(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 44 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}

function cha(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}


function numdot(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
        return false;
    return true;
}
function cur(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}
function ritc(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function rate(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
        return false;
    return true;
}
function phone(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 44 || charCode > 44))
        return false;
    return true;
}

function numcharspl1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 44 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 38 || charCode > 38) && (charCode < 40 || charCode > 41) && (charCode >= 123 || charCode <= 254))
        return false;
    return true;
}

function validatePaste(event) {   
    var paste = (event.clipboardData || window.clipboardData).getData('text');    
    var regex = /^[\x00-\x7F]+$/;    
    if (!regex.test(paste)) {
        event.preventDefault();
        alert('Check the Spl Character');
    }
}


function charnum2(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}

function int(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function numdot1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
        return false;
    return true;
}
function num1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function char1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}
function pin(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function numcharcomma(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 44 || charCode > 44))
        return false;
    return true;
}
function char2(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}
function pin1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}
function city1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 46 || charCode > 46) && (charCode < 44 || charCode > 44))
        return false;
    return true;
}

function charspl(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45))
        return false;
    return true;
}

//-----------------------------------END TEXTBOX-CHARACTER,NUMBER VALDATION FUNCTION--------------------------------------//

//-----------------------------------START TEXTBOX-MULTILINE--------------------------------------//
function checkTextAreaMaxLength(textBox, e, length) {

    var mLen = textBox["MaxLength"];
    if (null == mLen)
        mLen = length;

    var maxLength = parseInt(mLen);
    if (!checkSpecialKeys(e)) {
        if (textBox.value.length > maxLength - 1) {
            if (window.event)//IE
            {
                e.returnValue = false;
                return false;
            }
            else//Firefox
                e.preventDefault();
        }
    }

    var paste = (event.clipboardData || window.clipboardData).getData('text');
    var regex = /^[\x00-\x7F]+$/;
    if (!regex.test(paste)) {
        event.preventDefault();
        alert('Check the Spl Character');
    }
}

function checkSpecialKeys(e) {
    if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 35 && e.keyCode != 36 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
        return false;
    else
        return true;
}
//-----------------------------------END TEXTBOX-MULTILINE--------------------------------------//


//-----------------------------------START REMOVE EXTRA NUMBER AFTER SINGLE DOT OR ALLOWED SINGLE DOT NOT OTHER CHAR--------------------------------------//

function extractNumber(obj, decimalPlaces, allowNegative) {
    var temp = obj.value;




    if (temp.startsWith(".") || temp.startsWith("0") || temp.startsWith("0.")) // true
    {
        //temp.value = "0.00";
        // obj.value = "0.00";

        // alert("you can not insert dot and zero as first character");
        //temp.value = "";
    }
    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*';
    if (decimalPlaces > 0) {
        reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
    } else if (decimalPlaces < 0) {
        reg0Str += '\\.?[0-9]*';
    }
    reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) return true;

    // first replace all non numbers
    var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');

    if (allowNegative) {
        // replace extra negative
        var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
        var reg2 = /-/g;
        temp = temp.replace(reg2, '');
        if (hasNegative) temp = '-' + temp;
    }

    if (decimalPlaces != 0) {
        var reg3 = /\./g;
        var reg3Array = reg3.exec(temp);
        if (reg3Array != null) {
            // keep only first occurrence of .
            //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
            var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
            reg3Right = reg3Right.replace(reg3, '');
            reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
            temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
        }
    }

    obj.value = temp;
}
/*function blockNonNumbers(obj, e, allowDecimal, allowNegative) {

    var key;
    var isCtrl = false;
    var keychar;
    var reg;

    var charCode = (e.which) ? e.which : e.keyCode
    if (window.event) {
        key = charCode;
        isCtrl = window.event.ctrlKey
    }
    else if (e.which) {

        key = charCode;
        isCtrl = e.ctrlKey;
    }

    if (isNaN(key)) return true;
    keychar = String.fromCharCode(key);


    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

    return isFirstN || isFirstD || reg.test(keychar);
}*/

function blockNonNumbers(obj, e, allowDecimal, allowNegative) {

    var key;
    var isCtrl = false;
    var keychar;
    var reg;

    var charCode = (e.which) ? e.which : e.keyCode

    if (window.event) {
        key = charCode;
        // isCtrl = window.event.ctrlKey
        isCtrl = charCode.event.ctrlKey
    }
    else if (e.which) {

        key = charCode;
        isCtrl = e.ctrlKey;
    }

    if (isNaN(key)) return true;
    keychar = String.fromCharCode(key);

   
    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

    return isFirstN || isFirstD || reg.test(keychar);

}

//-----------------------------------END REMOVE EXTRA NUMBER AFTER SINGLE DOT OR ALLOWED SINGLE DOT NOT OTHER CHAR--------------------------------------//

//-----------------------------------START ADD 0000 AFTER SINGLE DOT--------------------------------------//

function Comma1(num) {
    var s = num.split('.');
    var beforeDecimal = s[0];
    var afterDecimal;
    var numericExpression = /^[0-9]+$/;
    var txtvalue;

    if (s.length > 1)
        afterDecimal = s[1];
    if (beforeDecimal.length > 14) {
        beforeDecimal = beforeDecimal.substring(0, 14);
    }

   
    if (num.match(numericExpression)) {
        return beforeDecimal + ".0000";
    }
    if (num == "" || num == "."  ) {
        return beforeDecimal + "00.0000";
    }
    
    if (afterDecimal.length == 0)
        afterDecimal = afterDecimal + '0000';
    if (afterDecimal.length == 1)
        afterDecimal = afterDecimal + '000';
    if (afterDecimal.length == 2)
        afterDecimal = afterDecimal + '00';
    if (afterDecimal.length == 3)
        afterDecimal = afterDecimal + '0';
    if (beforeDecimal != '' && afterDecimal.length == '')
        afterDecimal = afterDecimal + '0000';
    if (beforeDecimal.indexOf('.') && afterDecimal.length == '')
        afterDecimal = afterDecimal + '0000';

    return beforeDecimal + "." + afterDecimal;
}

function Invoice_frieght_Comma(num) {
//    var s = num.split('.');
//    var beforeDecimal = s[0];
//    var afterDecimal;
//    var numericExpression = /^[0-9]+$/;
//    var txtvalue;

//    if (s.length > 1)
//        afterDecimal = s[1];
//    if (beforeDecimal.length > 14) {
//        beforeDecimal = beforeDecimal.substring(0, 14);
//    }


//    if (num.match(numericExpression)) {
//        return beforeDecimal + ".0000";
//    }
//    if (num == "" || num == ".") {
//        return beforeDecimal + "";
//    }

//    if (afterDecimal.length == 0)
//        afterDecimal = afterDecimal + '0000';
//    if (afterDecimal.length == 1)
//        afterDecimal = afterDecimal + '000';
//    if (afterDecimal.length == 2)
//        afterDecimal = afterDecimal + '00';
//    if (afterDecimal.length == 3)
//        afterDecimal = afterDecimal + '0';
//    if (beforeDecimal != '' && afterDecimal.length == '')
//        afterDecimal = afterDecimal + '0000';
//    if (beforeDecimal.indexOf('.') && afterDecimal.length == '')
//        afterDecimal = afterDecimal + '0000';

//    return beforeDecimal + "." + afterDecimal;
}
//-----------------------------------END ADD 0000 AFTER SINGLE DOT--------------------------------------//
//-----------------------------------START LIMIT VALIDATION--------------------------------------//

function validateLimit(obj, divID, maxchar) {

    objDiv = get_object(divID);

    if (this.id) obj = this;

    var remaningChar = maxchar - trimEnter(obj.value).length;

    if (objDiv.id) {
        objDiv.innerHTML = remaningChar + "";
    }
    if (remaningChar <= 0) {
        obj.value = obj.value.substring(maxchar, 0);
        if (objDiv.id) {
            objDiv.innerHTML = "0 ";
        }
        return false;
    }
    else
    { return true; }
}

function get_object(id) {
    var object = null;
    if (document.layers) {
        object = document.layers[id];
    } else if (document.all) {
        object = document.all[id];
    } else if (document.getElementById) {
        object = document.getElementById(id);
    }
    return object;
}

function trimEnter(dataStr) {
    return dataStr.replace(/(\r\n|\r|\n)/g, "");
}
//-----------------------------------END LIMIT VALIDATION--------------------------------------//



//-- -----------------------------------------START Date Format dd/mm/yyyy ---------------------//
function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal == '')
        return false;

    //Declare Regex  
    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray == null)
        return false;

    //Checks for dd/mm/yyyy format.
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
//-- -----------------------------------------END Date Format dd/mm/yyyy ---------------------//


//-- --------------------------------START Disable Enter Key Event For Particular Control -----//
function stopRKey(evt) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
}

document.onkeypress = stopRKey;
//-- --------------------------------END Disable Enter Key Event For Particular Control -----//

//-- --------------------------------START Disable No RightClick Event ------------------------//


//var message = "Function Disabled!"; function clickIE4() { if (event.button == 2) {  return false; } } function clickNS4(e) { if (document.layers || document.getElementById && !document.all) { if (e.which == 2 || e.which == 3) {  return false; } } } if (document.layers) { document.captureEvents(Event.MOUSEDOWN); document.onmousedown = clickNS4; } else if (document.all && !document.getElementById) { document.onmousedown = clickIE4; } document.oncontextmenu = new Function("return false")

//-- --------------------------------END Disable No RightClick Event ------------------------//


//-- --------------------------------KEY CONTROL Event ------------------------//
$.ctrl = function (key, callback, args) {
    var isCtrl = false;
    var codes = { space: 32 };

    $(document).keydown(function (e) {
        if (!args) args = []; // IE barks when args is null

        if (e.ctrlKey) isCtrl = true;
        var keyCode = null;
        switch (true) {
            case typeof codes[key] == 'number':
                keyCode = codes[key];
                break;
            case typeof key == 'number':
                keyCode = key;
                break;
            default:
                keyCode = key.charCodeAt(0);
        }
        if (e.keyCode == keyCode && isCtrl) {
            callback.apply(this, args);
            return false;
        }
    }).keyup(function (e) {
        if (e.ctrlKey) isCtrl = false;
    });
};

/*$.ctrl('space', function (s) {
    //alert(s);
}, ["Control+Space pressed"]);
*/

//$.ctrl('N', function () {
//    document.getElementById("btnNew").click();
//});
//$.ctrl('S', function () {
//    document.getElementById("btnSave").click();
//});
//$.ctrl('U', function () {

//    document.getElementById("btnUpdate").click();
//});
////$.ctrl('C', function () {
//    //document.getElementById("btnCancel").click();
////});
//$.ctrl('D', function () {
//    document.getElementById("btnDelete").click();
//});
//-- --------------------------------KEY CONTROL Event ------------------------//

function roundNumber(number, decimals) { // Arguments: number to round, number of decimal places
    var newnumber = new Number(number + '').toFixed(parseInt(decimals));
    
    return parseFloat(newnumber); // Output the result to the form field (change for your purposes)
}
//-------------------------------------remve zero after decimal point----------------------
function remove_zero_after_decimal_point(str, textbox) {


//    if (str.indexOf('') != -1) {

//        for (var i = 0; i < str.length; i++) {

//            if (str.substr(str.length - 1, 1) == 0) {
//                str = str.substring(0, str.length - 1);
//            }
//        }

//        if (str.substr(str.length - 1, 1) == '.') {
//            str = str.substring(0, str.length - 1);
//        }
//    }

//    document.getElementById(textbox).value = str;


}
//-------------------------------------remve zero after decimal point----------------------
