﻿/*
* 	Character Count Plugin - jQuery plugin
* 	Dynamic character count for text areas and input fields
*	 written by Alen Grakalic
*	 http://cssglobe.com/
*
*
* Updated to work with Twitter Bootstrap 2.0 styles by Shawn Crigger <@svizion>
* http://blog.s-vizion.com
* Mar-13-2011
*
*	Copyright (c) 2009 Alen Grakalic (http://cssglobe.com)
*	Dual licensed under the MIT (MIT-LICENSE.txt)
*	and GPL (GPL-LICENSE.txt) licenses.
*
*	Built for jQuery library
*	http://jquery.com
*
*
*/

(function ($) {

    $.fn.charCount = function (options) {
        var defaults = {
            allowed: 140,
            warning: 25,
            css: 'help-inline',
            counterElement: 'span',
            cssWarning: 'textarea-warning',
            cssExceeded: 'textarea-danger',
            counterText: 'Caracteres: '
        };
        var options = $.extend(defaults, options);

        function calculate(obj) {
            var count = $(obj).val().length;
            var charLimit = $(obj).attr("data-val-maxlength-max");
            var warning = charLimit * 0.10;
            var available = charLimit - count;
            if (available <= warning && available >= 0) {
                //Since the error/warning field is actually in the first div, we jump 2 parent classes up to find it.
                //$(obj).next().parent().parent().addClass(options.cssWarning);
                $(obj).addClass(options.cssWarning);
            } else {
                $(obj).removeClass(options.cssWarning);
            }
            if (available < 0) {
                $(obj).addClass(options.cssExceeded);
            } else {
                $(obj).removeClass(options.cssExceeded);
            }
            $(obj).next().html(options.counterText + count + " / " + charLimit);
        };

        this.each(function () {
            $(this).after('<' + options.counterElement + ' class="' + options.css + '" style="padding-left:0px; color:#999; font-size:0.9em;">' + options.counterText + '');
            calculate(this);
            $(this).keyup(function () { calculate(this) });
            $(this).change(function () { calculate(this) });
        });

    };
})(jQuery);
