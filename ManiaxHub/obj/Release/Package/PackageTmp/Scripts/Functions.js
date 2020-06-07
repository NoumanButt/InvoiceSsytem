function PRMSSBind(URL) {
    
    $("#txtSearch").autocomplete({
        source: '@Url.Action("CustomersList")',
        select: function (event, ui) {
            $("#txtSearch").val(ui.item.label);
            $.ajax({
                type: "POST",
                url: URL,
                data: { label: ui.item.value, },
                success: function (message) {
                    if (message.data = true) {
                    }
                },
                dataType: 'json'
            });
            return false;
        },
        minLength: 0,
        scroll: true
    }).focus(function () {
        $(this).autocomplete("search", "");
    });
}

// ... Show Message Function ... 
function PRMSSShowMessage(message, Validation) {
    
    if (Validation == "True") {
        $("#Status").addClass("alert-success");
        $("#Status").removeClass("alert-danger");
    }
    else if (Validation == "False") {
        $("#Status").addClass("alert-danger");
        $("#Status").removeClass("alert-success");
    }
    document.getElementById("message").innerHTML = message;
    $("#Status").show();
    window.setTimeout(function () {
        $("#Status").fadeIn(500, function () {
            $("#Status").hide();
        });
    }, 5000);
};

// ... When Date button is clicked ...
//function PRMSSDatePicker(dateArr) {
    
//    $("#txtSearch").datepicker({
//        dateFormat: 'dd-M-yy',
//        beforeShowDay: function (d) {
//            var dmy = (d.getMonth() + 1);
//            if (d.getMonth() < 9)
//                dmy = "0" + dmy;
//            dmy += "-";
//            if (d.getDate() < 10) dmy += "0";
//            dmy += d.getDate() + "-" + d.getFullYear();
//            if ($.inArray(dmy, dateArr) != -1) {
//                return [true, "", "Available"];
//            } else {
//                return [false, "", "unAvailable"];
//            }
//        }
//    });
//};

// ... When Radio Button is clicked ... 
function Search(SearchType) {
    
    if (SearchType == 'All') {
        $("#btnAllrecord").attr(":Checked", true);
    }
    var AllChecked = $("#btnAllrecord").prop("checked");

    if (AllChecked == true) {
        $("#txtSearch").attr("disabled", true);
    }
    // ... When All Record button is clicked ... 
    $("#btnAllrecord").click(function () {
        
        $("#txtSearch").val("");
        $("#txtSearch").attr("disabled", true);
        $("#txtSearch").datepicker("destroy");
        $("#txtSearch").val("");
        $("#txtSearch").autocomplete("disable");
    });
    // ... When Date button is clicked ... 
    $("#btnDateSearch").click(function () {
        
        $("#txtSearch").attr("disabled", false);
        $("#txtSearch").attr("readonly", true);
        $("#txtSearch").val("");
        $("#txtSearch").autocomplete("disable");

    });
    // When Customer button is clicked
    $("#btnCustomerSearch").click(function () {
        
        $("#txtSearch").attr("disabled", false);
        $("#txtSearch").attr("readonly", false);
        $("#txtSearch").datepicker("destroy");
        $("#txtSearch").val("");
        $("#txtSearch").autocomplete("enable");
    });

    
}


//...  When User Focusin Search Box ... 
//function PRMSSFocusin(URL) {
//    
// var EmpName = $("#btnCustomerSearch").prop("checked");
    
//    if (EmpName == true) {
//        BindEmployeeName();
//        //PRMSSBind(URL + "SearchEmployeeCode");
//    $("#txtSearch").removeClass("datepicker");
//    } 
//}
