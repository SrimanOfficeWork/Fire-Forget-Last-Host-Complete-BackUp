
function IGM_Status(IGM_MBLNO, Port, mode) {
    
     var PortName;
    if (mode == 'Air') {
        if(Port=='INAMD4')
        {
            PortName = 'AHEMDABAD AIR ACC (INAMD4)';
        }
        else if(Port=='INATQ4')
        {
            PortName = 'AMRITSAR ACC (INATQ4)';
        }
        else if(Port=='INBLR4')
        {
            PortName = 'BANGALORE ACC (INBLR4)';
        }
        else if (Port == 'INBBI4')
        {
            PortName = 'BHUBANESWAR AIR CARGO (INBBI4)';
        }
        else if(Port=='INCCJ4')
        {
            PortName = 'CALICUT ACC (INCCJ4)';
        }
        else if(Port=='INMAA4')
        {
            PortName = 'CHENNAI AIR CARGO ACC (INMAA4)';
        }
        else if(Port=='INCOK4')
        {
            PortName = 'COCHIN AIR CARGO ACC (INCOK4)';
        }
        else if(Port=='INCJB4')
        {
            PortName = 'COIMBATORE ACC (INCJB4)';
        }
        else if(Port=='INDEL4')
        {
            PortName = 'DELHI AIR CARGO ACC (INDEL4)';
        }
        else if(Port=='INGOI4')
        {
            PortName = 'GOA ACC (INGOI4)';
        }
        else if (Port == 'INGAU4')
        {
            PortName = 'GUWAHATI AIR CARGO (INGAU4))';
        }
        
        else if(Port=='INHYD4')
        {
            PortName = 'HYDERABAD ACC (INHYD4)';
        }
        else if(Port=='INIDR4')
        {
            PortName = 'INDORE ACC (INIDR4)';
        }
        else if(Port=='INJAI4')
        {
            PortName = 'JAIPUR ACC (INJAI4)';
        }
        else if(Port=='INJNR4')
        {
            PortName = 'JANORI ACC (INJNR4)';
        }
        else if(Port=='INCCU4')
        {
            PortName = 'KOLKATA ACC (INCCU4)';
        }
        else if (Port == 'INJGA4')
        {
            PortName = 'JAMNAGAR AIR CARGO (INJGA4)';
        }
        else if (Port == 'INLKO4')
        {
            PortName = 'LUCKNOW AIR CARGO (INLKO4)';
        }
        else if (Port == 'INLOK4')
        {
            PortName = 'LUCKNOW AIR CARGO (INLOK4)';
        }
        else if (Port == 'INIXM4')
        {
            PortName = 'MADURAI AIR CARGO (INIXM4)';
        }
        else if (Port == 'INIXE4')
        {
            PortName = 'MANGALORE AIR CARGO (INIXE4)';
        }
        else if (Port == 'INNAG4')
        {
            PortName = 'NAGPUR AIR CARGO (INNAG4)';
        }
        else if(Port=='INDPC4')
        {
            PortName = 'PCCCC BANDRA-KURLA COMPLEX (INDPC4)';
        }
        else if (Port == 'INPNQ4')
        {
            PortName = 'PUNE AIR CARGO (INPNQ4)';
        }
        else if(Port=='INBOM4')
        {
            PortName = 'SAHAR AIR CARGO ACC (INBOM4)';
        }
        else if (Port == 'INSXR4')
        {
            PortName = 'SRINAGAR AIR CARGO (INSXR4)';
        }
        else if (Port == 'INTRZ4')
        {
            PortName = 'TIRUCHIRAPALLI AIR CARGO (INTRZ4)';
        }
        else if(Port=='INTRV4')
        {
            PortName = 'TRIVANDRUM ACC (INTRV4)';
        }
        else if (Port == 'INVNS4')
        {
            PortName = 'VARANASI AIR CARGO (INVNS4)';
        }
         else if(Port=='INVTZ4')
        {
            PortName = 'VISHAKHAPATNAM AIR CARGO (INVTZ4)';
        }
   
    }
    else if (mode == 'Sea') { 

       if(Port=='INALA1')
        {
            PortName = 'ALANG SEA (INALA1)';
        }
        else if (Port == 'INAZK1')
        {
            PortName = 'AZHIKKAL PORT (INAZK1)';
        }
        else if (Port == 'INBKT1')
        {
            PortName = 'BANKOT PORT (INBKT1)';
        }
        else if(Port=='INBED1')
        {
            PortName = 'BEDI PORT SEA (INBED1)';
        }
        else if (Port == 'INBEY1')
        {
            PortName = 'BEYPORE PORT (INBEY1)';
        }
        else if (Port == 'INBHU1')
        {
            PortName = 'BHAVNAGAR SEA (INBHU1)';
        }
         else if(Port=='INMAA1')
        {
            PortName = 'CHENNAI SEA (INMAA1)';
        }
         else if(Port=='INCOK1')
        {
            PortName = 'COCHIN SEA (INCOK1)';
        }
        else if (Port == 'INCDL1')
        {
            PortName = 'CUDDALORE PORT (INCDL1)';
        }
        else if (Port == 'INDHP1')
        {
            PortName = 'DABHOL PORT (INDHP1)';
        }
        else if(Port=='INDAH1')
        {
            PortName = 'DAHEJ PORT SEA (INDAH1)';
        }
        else if (Port == 'INDHU1')
        {
            PortName = 'DHAHANU PORT (INDHU1)';
        }
        else if (Port == 'INDMA1')
        {
            PortName = 'DHAMRA PORT SEA (INDMA1)';
        }
        else if(Port=='INDMT1')
        {
            PortName = 'DHARMATAR PORT MUMBAI (INDMT1)';
        }
        else if (Port == 'INDIG1')
        {
            PortName = 'DIGHI PORT (INDIG1)';
        }
        else if(Port=='INENR1')
        {
            PortName = 'ENNOR PORT SEA (INENR1)';
        }
         else if(Port=='INGGV1')
        {
            PortName = 'GANGAVARAM PORT SEA (INGGV1)';
        }
        else if(Port=='INMRM1')
        {
            PortName = 'GOA PORT SEA (INMRM1)';
        }
        else if (Port == 'INGPR1')
        {
            PortName = 'GOPALPUR PORT (INGPR1)';
        }
        else if(Port=='INHZA1')
        {
            PortName = 'HAZIRA PORT SURAT (INHZA1)';
        }
        else if (Port == 'INJGD1')
        {
            PortName = 'JAIGARH PORT MAHARASHTRA (INJGD1)';
        }
        else if (Port == 'INJAK1')
        {
            PortName = 'JAKHAU PORT (INJAK1)';
        }
        else if(Port=='INKAK1')
        {
            PortName = 'KAKINADA SEA (INKAK1)';
        }
         else if(Port=='INKRK1')
        {
            PortName = 'KARAIKAL SEA PORT (INKRK1)';
        }
         else if(Port=='INIXY1')
        {
            PortName = 'KANDLA SEA (INIXY1)';
        }
        else if (Port == 'INKRW1')
        {
            PortName = 'KARWAR PORT (INKRW1)';
        }
        else if(Port=='INKAT1')
        {
            PortName = 'KATTUPALLI PORT SEA (INKAT1)';
        }
        else if (Port == 'INKSH1')
        {
            PortName = 'KELSHI PORT (INKSH1)';
        }
        else if (Port == 'INKDN1')
        {
            PortName = 'KODINAR PORT (INKDN1)';
        }
        else if (Port == 'INCCU1')
        {
            PortName = 'KOLKATA SEA (INCCU1)';
        }
        else if(Port=='INKUK1')
        {
            PortName = 'KOLLAM PORT SEA (INKUK1)';
        }
        else if(Port=='INKRI1')
        {
            PortName = 'KRISHNAPATNAM PORT SEA (INKRI1)';
        }
        else if(Port=='INMDA1')
        {
            PortName = 'MAGDALA PORT SEA (INMDA1)';
        }
        else if(Port=='INNML1')
        {
            PortName = 'MANGALORE SEA (INNML1)';
        }
        else if(Port=='INBOM1')
        {
            PortName = 'MUMBAI CUSTOM HOUSE SEA (INBOM1)';
        }
         else if(Port=='INMUN1')
        {
            PortName = 'MUNDRA SEA (INMUN1)';
        }
        else if(Port=='INNPT1')
        {
            PortName = 'NAGAPATTINAM CUSTOM HOUSE SEA (INNPT1)';
        }
        else if (Port == 'INNAV1')
        {
            PortName = 'NAVLAKHI PORT (INNAV1)';
        }
        else if(Port=='INNSA1')
        {
            PortName = 'NHAVA SHEVA SEA (INNSA1)';
        }
        else if (Port == 'INOKH1')
        {
            PortName = 'OKHA PORT (INOKH1)';
        }
        else if (Port == 'INIXE1')
        {
            PortName = 'OLD MANGALORE PORT (INIXE1)';
        }
        else if (Port == 'INOMU1')
        {
            PortName = 'OLD MUNDRA PORT (INOMU1)';
        }
        else if (Port == 'INPAN1')
        {
            PortName = 'PANAJI PORT (INPAN1)';
        }
        else if(Port=='INPRT1')
        {
            PortName = 'PARADEEP PORT SEA (INPRT1)';
        }
         else if(Port=='INPAV1')
        {
            PortName = 'PIPAVAV - VICTOR PORT GUJARAT SEA (INPAV1)';
        }
        else if(Port=='INPNY1')
        {
            PortName = 'PONDICHERRY CUSTOM HOUSE SEA (INPNY1)';
        }
        else if (Port == 'INPBD1')
        {
            PortName = 'PORBANDAR PORT (INPBD1)';
        }
        else if (Port == 'INRNR1')
        {
            PortName = 'RANPAR PORT RATNAGIRI MAHARASHTRA (INRNR1)';
        }
        else if (Port == 'INRED1')
        {
            PortName = 'REDI PORT (INRED1)';
        }
        else if (Port == 'INRVD1')
        {
            PortName = 'REVDANDA PORT (INRVD1)';
        }
        else if (Port == 'INSIK1')
        {
            PortName = 'SIKKA PORT (INSIK1)';
        }
        else if (Port == 'INTUN1')
        {
            PortName = 'TUNA PORT (INTUN1)';
        }
        else if(Port=='INTUT1')
        {
            PortName = 'TUTICORIN SEA (INTUT1)';
        }
        else if (Port == 'INVAD1')
        {
            PortName = 'VADINAR PORT (INVAD1)';
        }
        else if (Port == 'INVYD1')
        {
            PortName = 'VIJAYDURG PORT (INVYD1)';
        }
        else if(Port=='INVTZ1')
        {
            PortName = 'VIZAG SEA (INVTZ1)';
        }
        else if (Port == 'INVZJ1') {
            PortName = 'VIZHINJAM PORT (INVZJ1)';
        }
    }

    var title = "Royal Tech Systems";
    var igStat = window.open("", "", "height=600,width=1000,resizable=1,status=1,scrollbars=Yes");
    var html = "";
    var parameters = "";
    
    if (mode == 'Air') {
        parameters = "{'Nullparam':'NULL'}";
          url = ' https://enquiry.icegate.gov.in/enquiryatices/airIgmEntry?IGM_loc_Name=' + PortName + '&MAWB_NO=' + IGM_MBLNO + '';
    }
     else {

         parameters = "{'IGM_loc_Name':'" + PortName + "','MAWB_NO':'" + IGM_MBLNO + "'}";
         url = ' https://enquiry.icegate.gov.in/enquiryatices/seaIgmEntry';
    }

    html = ("<html><head><title>" + title + "</title></head><body style='margin:0;overflow:none;'>" +
								"<script type='text/javascript'> window.location.href=\"javascript:window.opener.post_Method(document,'" + url + "'," + parameters + ");\"; </script> " +
								"</body></html>");

    igStat.document.open();
    igStat.document.write(html);
    igStat.document.close();
    igStat.window.focus(); 

}

function post_Method(docObj, path, params, method) {
    method = method || "post"; 
    var formObj = docObj.createElement("form");
    formObj.setAttribute("method", method);
    formObj.setAttribute("action", path);

    for (var key in params) {
        var hiddenField = docObj.createElement("input");
        hiddenField.setAttribute("type", "hidden");
        hiddenField.setAttribute("name", key);
        hiddenField.setAttribute("value", params[key]);

        formObj.appendChild(hiddenField);
    }

    docObj.body.appendChild(formObj);
    formObj.submit();
};
