/// href=  "C:\Users\HP\Documents\jQueryTest\Scripts\jQuery1.7.2.js"

$(window).load(function ()
{
    //$('.flexslider').flexslider();
});

$(function () {
    $('#slider').nivoSlider();
    $('#tabs').tabs({ heightStyle: "fill" });
    //$('.myButton').button();
    $('.errorDialog').dialog();
    //$('#SearchDiv').children().addClass("myHide");
});


function ToggleSearchInputs(selectedOpt) {

    $('#SearchDiv').children().hide(); // Hide all children in div before showing 

    switch (selectedOpt.value) {
        case "Faculty": $('#Tbl_Faculty').fadeIn(); 
            break;
        case "Students": $('#Tbl_Student').fadeIn();
            break;
        case "Staff":  $('#Table_Staff').fadeIn();
            break;
        case "Contractors": $('#Table_Contractors').fadeIn();
            break;
    }
}

function showOnlyMe(tbl) {
/*
    $('#SearchDiv').children().hide();
    $('#SearchDiv').children(tbl).removeClass("myHide"); 
    $(tbl).removeClass("myHide").show();*/
}
function MultiDimSearch(buttonClicked) {
    $('#divResults').removeClass("myHide");
    $('#divResults').fadeIn(); 
    switch (buttonClicked.id) {
        case "ctl00_ContentPlaceHolder1_Btn_Faculty": showOnlyMe('#Tbl_Faculty');
            break;

    }
}