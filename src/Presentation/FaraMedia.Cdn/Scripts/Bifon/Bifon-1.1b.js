/*!
 * Copyright (c) 2012 Averta.net
 * Licensed under the MIT license.
 *
 * @author Morteza Faghih Shojaei
 * @version 1.1b
 */

 var FarsiStyle = (function() {

     var api = function() {
         return api.convert.apply(null, arguments);
     }; // Char map 
     var orginal_chars = 'ئ ء ي ی ه و ن م ل گ ك ک ق ف غ ع ظ ط ض ص ش س ژ ز ر ذ د خ ح چ ج ث ت پ ب ا أ آ';
     var isolated_chars = 'ﺉ ﺀ ﻯ ﻯ ﻩ ﻭ ﻥ ﻡ ﻝ ﮒ ﮎ ﮎ ﻕ ﻑ ﻍ ﻉ ﻅ ﻁ ﺽ ﺹ ﺵ ﺱ ﮊ ﺯ ﺭ ﺫ ﺩ ﺥ ﺡ ﭺ ﺝ ﺙ ﺕ ﭖ ﺏ ﺍ ﺍ ﺁ';
     var initial_chars = 'ﺋ ﺀ ﻳ ﻳ ﻫ ﻭ ﻧ ﻣ ﻟ ﮔ ﻛ ﻛ ﻗ ﻓ ﻏ ﻋ ﻇ ﻃ ﺿ ﺻ ﺷ ﺳ ﮊ ﺯ ﺭ ﺫ ﺩ ﺧ ﺣ ﭼ ﺟ ﺛ ﺗ ﭘ ﺑ ﺍ ﺋ ﺁ';
     var middle_chars = 'ﺌ ﺀ ﻴ ﻴ ﻬ ﻮ ﻨ ﻤ ﻠ ﮕ ﻜ ﻜ ﻘ ﻔ ﻐ ﻌ ﻈ ﻄ ﻀ ﺼ ﺸ ﺴ ﮋ ﺰ ﺮ ﺬ ﺪ ﺨ ﺤ ﭽ ﺠ ﺜ ﺘ ﭙ ﺒ ﺎ ﺌ ﺁ';
     var final_chars = 'ﺊ ﺀ ﻰ ﻰ ﻪ ﻮ ﻦ ﻢ ﻞ ﮓ ﮏ ﮏ ﻖ ﻒ ﻎ ﻊ ﻆ ﻂ ﺾ ﺺ ﺶ ﺲ ﮋ ﺰ ﺮ ﺬ ﺪ ﺦ ﺢ ﭻ ﺞ ﺚ ﺖ ﭗ ﺐ ﺎ ﺄ ﺁ';

     // replace sp_chars with sp_chars_replace on the same char index
     var sp_chars = '[](){}<>؟،۰۱۲۳۴۵۶۷۸۹٪٫»«""';
     var sp_chars_replace = '][)(}{><?,0123456789%,][""';

     // odd bidi characters 
     var farsi_chars = 'ئحكيآابپتثجچهخدذرزژسشصضطظعغفقکگلمنوهیأ';

     // all of characters that have initial mode
     var left_join_chars = 'ئحكيبپتثجچهخسشصضطظعغفقکگلمنهی';

     // number characters
     var num_chars = '0123456789۰۱۲۳۴۵۶۷۸۹';

     var sp_num_chars = '٫،٫,:.,';

     var common_chars = ' /!@#$%&*()_+=-.,\"\';:{}|[]?<>÷؟،\r';

     // remove these characters in converted text 
     var remove_chars = 'ـ\nًٌٍَُِّ';
     var input_str;

     function getChar(org_char_index) {

         var right_char = charAt(org_char_index - 1);
         var char = charAt(org_char_index);
         var left_char = charAt(org_char_index + 1);

         if (isFarsi(char)) {
             return checkLeftChar(char, left_char, !(right_char == '' || left_join_chars.indexOf(right_char) == -1));
         } else if (sp_chars.indexOf(char) != -1) {
             return getSpChars(char);
         } else {
             return char;
         }

         return '';

     }

     function checkLeftChar(char, left_char, join_to_right) {
         if (!(left_char == '' || !isFarsi(left_char))) {
             return (join_to_right) ? getFSChar(char, 'middle') : getFSChar(char, 'initial');
         } else {
             return (join_to_right) ? getFSChar(char, 'final') : getFSChar(char, 'isolated');
         }
         return '';
     }

     function getSpChars(char) {
         return sp_chars_replace.charAt(sp_chars.indexOf(char));
     }

     function getFSChar(org_char, type) {

         var index = orginal_chars.indexOf(org_char);

         switch (type) {
         case 'isolated':
             return isolated_chars.charAt(index);
             break;
         case 'initial':
             return initial_chars.charAt(index);
             break;
         case 'middle':
             return middle_chars.charAt(index);
             break;
         case 'final':
             return final_chars.charAt(index);
             break;
         }

         return '';
     }

     function isFarsi(char) {
         return farsi_chars.indexOf(char) != -1;
     }

     function charAt(index) {
         return input_str.charAt(index);
     }

     function convert(text) {
         var return_str = '';
         var en_chars_buffer = '';
         var common_chars_reverse_buffer = '';
         var num_chars_buffer = '';
         var num_self_buffer = '';
         var char;
         var org_char;

         input_str = text;

         for (var i = 0; i < input_str.length; i++) {

             if (remove_chars.indexOf(charAt(i + 1)) != -1) {
                 input_str = input_str.slice(0, i + 1) + input_str.slice(i + 2);
             }

             char = getChar(i);
             org_char = charAt(i);

             if (isFarsi(org_char)) {
                 if (common_chars_reverse_buffer == '') {
                     return_str = en_chars_buffer + return_str;
                 } else {
                     common_chars_reverse_buffer = '';
                 }
                 return_str = num_chars_buffer + return_str;
                 num_chars_buffer = '';
                 en_chars_buffer = '';
                 return_str = char + return_str;
             } else if (common_chars.indexOf(org_char) != -1) {
                 if (common_chars_reverse_buffer == '') {
                     return_str = en_chars_buffer + return_str;
                 }
                 return_str = num_chars_buffer + return_str;
                 num_chars_buffer = '';
                 return_str = char + return_str;
                 common_chars_reverse_buffer += char;
             } else if (num_chars.indexOf(org_char) != -1 && en_chars_buffer == '') {
                 if (common_chars_reverse_buffer.length == 1 && sp_num_chars.indexOf(common_chars_reverse_buffer) != -1) {
                     return_str = return_str.slice(num_self_buffer.length);
                     num_chars_buffer = num_self_buffer + common_chars_reverse_buffer + char;
                     num_self_buffer = '';
                 } else {
                     num_self_buffer += char;
                     num_chars_buffer += char;
                 }
                 common_chars_reverse_buffer = '';
             } else {
                 if (common_chars_reverse_buffer != '' && en_chars_buffer != '') {
                     return_str = return_str.slice((common_chars_reverse_buffer.length + en_chars_buffer.length));
                     en_chars_buffer += common_chars_reverse_buffer + char;
                     common_chars_reverse_buffer = '';
                 } else if (common_chars_reverse_buffer != '') {
                     common_chars_reverse_buffer = '';
                     en_chars_buffer = char;
                 } else {
                     en_chars_buffer += char;
                 }
             }
         }
         return return_str + ((common_chars_reverse_buffer == '') ? en_chars_buffer : '') + num_chars_buffer;
     }

     function getOrginalText() {
         return input_str;
     }

     api.convert = function(text) {
         return convert(text + ' ').slice(1).split(' ').reverse().join(' ');
     };
     return api;
 })();

 var Bifon = (function() {

     document.write('<style type="text/css">cufon{direction:ltr !important;}</style>');

     var api = function() {
         return api.covert.apply(null, arguments);
     };
     api.convert = function(element) {
         if (typeof(element.textContent) != "undefined")
             element.textContent = FarsiStyle.convert(element.textContent);
         else
             element.innerText = FarsiStyle.convert(element.innerText);
     };
     return api;
 })();