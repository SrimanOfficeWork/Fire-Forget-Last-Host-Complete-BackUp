

         function nokeywork(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode < 127)
                 return false;
             return true;
         }


         function num(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }

        
         
         function numcharspl(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 46 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 44 || charCode > 44) && (charCode < 38 || charCode > 38))
                 return false;
             return true;
         }
           



        function char(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                 return false;
             return true;
         }


         function numchar(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                 return false;
             return true;
         }



         function Address(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 44 || charCode > 57) && (charCode < 40 || charCode > 41))
                 return false;
             return true;
         }

      

  
    function code(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }

   