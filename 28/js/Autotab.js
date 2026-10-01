
        var nav = window.Event ? true : false;
        var keyCode
        if (nav) {
            window.captureEvents(Event.KEYDOWN);
            window.onkeydown = NetscapeEventHandler_KeyDown;
        } else {
            document.onkeydown = MicrosoftEventHandler_KeyDown;
        }



        function autotab(textbox) {
            if (keyCode == 8 || keyCode == 9 || keyCode == 13 || keyCode == 16 || keyCode == 35 || keyCode == 37 || keyCode == 38 || keyCode == 39 || keyCode == 40 || keyCode == 46) {

                return true;
            }
            else {
                if (textbox.value.length == textbox.getAttribute('Maxlength')) {
                    getNext(textbox).focus();
                } 
            } 
        }


        function getNext(textbox) {
            var i = 0;
            while (i < textbox.form.elements.length - 1) {
                if (textbox.form.elements[i] == textbox) {
                    return textbox.form.elements[i + 1];
                } else {
                    i++;
               } 
         }
          

            return document.links[document.links.length - 1];
        } 
