function validate() {
    var txtContainerNo = document.getElementById("txtContainerNo").value;
    if (txtContainerNo.length <= 0) {
        jAlert('Container No cannot be blank', 'CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });


        return false;
    }
//    if (txtContainerNo.length < 11) {
//        jAlert('Container No should be 11 Characters', 'CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });


//        return false;
//    }
    var txtSealNo = document.getElementById("txtSealNo").value;
    if (txtSealNo.length <= 0) {
        jAlert('SealNo cannot be blank', 'CONTAINER', function (r) { document.getElementById("txtSealNo").focus(); });

        return false;
    }


    var TrMode = document.getElementById("hdn_TransportMode").value;
    if (TrMode == 'Sea') {
        if (txtContainerNo.length < 11) {
            jAlert('Container No should be 11 Characters', 'CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });
            return false;
        }
    }
    else if (TrMode == 'Land') {
        if (txtContainerNo.length < 10) { // should be 10 (or) 11
            jAlert('Check - Container No Length', 'CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });
            return false;
        }
    }
    else {
    }


//    if (txtContainerNo.length == 11) {

//        var part1 = txtContainerNo.substring(0, 4);
//        var chk_str = stringContainsNumber(part1);
//        if (chk_str == true) {
//            jAlert('Check - Container Number', 'CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });
//                        return false;
//        }

//        var part2 = txtContainerNo.substring(4, 11);
//        var Result = isNumber(part2);
//        if (Result == false) {
//            jAlert('Check - Container Number', 'CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });
//            return false;
//        }

//        function isNumber(n) { return !isNaN(parseFloat(n)) && !isNaN(n - 0) }
//        function stringContainsNumber(_string) {
//            return /\d/.test(_string);
//        }
//    }


}