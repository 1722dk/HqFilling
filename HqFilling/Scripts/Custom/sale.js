
// for item type change
$(function () {
    $("#optItemType").change(function () {
        var selectedItemType = $("#optItemType option:selected").val();
        if (selectedItemType == 1) {
            //alert($("#optItemType option:selected").text());
        }
    });

    $("#optPaymentType").change(function () {
        var selectedPaymentType = $("#optPaymentType option:selected").val();
        if (selectedPaymentType == 1 || selectedPaymentType == 0) {
            $("#divSaleTo").hide();
        } else {
            $("#divSaleTo").show();
        }
    });

    //Test - 05-04-2013
    var keypress = 0;
    var oldSelectedOption = 0;
    var currentSelectedOption = 0;
    var oldQuantity = 0;
    var currentQuantity = 0;

    $("#DiselModelList_0__DdlModel").change(function () {
        currentSelectedOption = $("#DiselModelList_0__DdlModel option:selected").val();
    });
    //DiselModelList_0__IsDisel
    $("#DiselModelList_0__IsDisel").click(function () {
        if ($("#DiselModelList_0__IsDisel").is(":checked")) {
            $("#DiselModelList_0__CostModelList_0__SalesPrice").val("");
            $("#DiselModelList_0__CostModelList_0__Vat").val("");

            $("#DiselModelList_0__CostModelList_0__SalesPrice").val("68.00");
            $("#DiselModelList_0__CostModelList_0__Vat").val("5");
        }
    });
    $("#chkDisel").click(function () {
        if ($("#chkDisel").is(":checked")) {
            $("#txtSalesPriceDisel").val("");
            $("#txtVatDisel").val("");

            $("#txtSalesPriceDisel").val("68.00");
            $("#txtVatDisel").val("5");
        }
    });
    /*$("#DiselModelList_0__CostModelList_0__Quantity").change(function (event) {
    //CalculateSubTotal();
    });*/

    $("#DiselModelList_0__CostModelList_0__Quantity").keypress(function (event) {
        var code = (event.keyCode ? event.keyCode : event.which); 
        if (code == 13 || code == 9) {
            event.preventDefault();

            if (!$("#DiselModelList_0__IsDisel").is(":checked")) {
                alert('Please check the disel checkbox.');
                return; 
            }
            if (keypress == 0) {
                CalculateSubTotal();
            } else {
                currentQuantity = $("#DiselModelList_0__CostModelList_0__Quantity").val();
                currentSelectedOption = $("#DiselModelList_0__DdlModel option:selected").val();
                if (!IsDoubleEntry(currentQuantity, currentSelectedOption)) {
                    CalculateSubTotal();
                }
            }
            keypress++;
        }
    });
});

function getUnitSalesPrice(opt) {
    $.ajax({
        url: baseUrl + "/Sale/GetUnitSalesPrice",
        type: "POST",
        data: { assetType: opt },
        success: function (result) {
            if (result) {
                //$("#AssetModel_CurrentDateTime").val(result.Message);
            }
        },
        error: ErrorHandler
    });
}

function IsDoubleEntry(currentQuantity, currentSelectedOption) {
    var isTwice = false;
    if (currentQuantity == oldQuantity && currentSelectedOption == oldSelectedOption) {
        isTwice = true;
    }
    return isTwice;
}
function CalculateSubTotal() {
    if ($("#DiselModelList_0__IsDisel").is(":checked") && $("#DiselModelList_0__CostModelList_0__SalesPrice").val() != "" && $("#DiselModelList_0__CostModelList_0__Quantity").val() != "") {
        var salesPrice = $("#DiselModelList_0__CostModelList_0__SalesPrice").val();
        var vatRate = $("#DiselModelList_0__CostModelList_0__Vat").val();
        var quantity = $("#DiselModelList_0__CostModelList_0__Quantity").val();
        var subTotal = salesPrice * quantity;

        $("#DiselModelList_0__CostModelList_0__SubTotal").val("");
        $("#DiselModelList_0__CostModelList_0__SubTotal").val(subTotal);
        //$("#DiselModelList_0__CostModelList_0__SubTotal").attr("readonly", "readonly");

        //Take effect on overall aspect
        CalculateOvarAll(quantity, subTotal); 
    }
}

function CalculateOvarAll(quantity,subTotal) {
    /*var machine1 = $("#MachineModelList_0__MachineVolume").val();
    var machine2 = $("#MachineModelList_1__MachineVolume").val();
    var machine3 = $("#MachineModelList_2__MachineVolume").val();
    */
    var machine = 0;
    var totalDisel = $("#AssetModel_TotalDisel").val();
    if (totalDisel == "") { totalDisel = "0.00"; }

    var totalSalesQtyDisel = $("#txtTotalSaleQuantityDisel").val();
    if (totalSalesQtyDisel == "") { totalSalesQtyDisel = "0.00"; }

    var totalSalesCostTaka = $("#txtTotalTakaDisel").val();
    if (totalSalesCostTaka == "") { totalSalesCostTaka = "0.00"; }

    //now for machine 1
    if ($("#DiselModelList_0__DdlModel option:selected").val() == "1") {
        machine = $("#MachineModelList_0__MachineVolume").val();
        if (machine == "") {machine = "0.00";}
        $("#MachineModelList_0__MachineVolume").val(parseFloat(machine) + parseFloat(quantity));
     }
    if ($("#DiselModelList_0__DdlModel option:selected").val() == "2") {
        machine = $("#MachineModelList_1__MachineVolume").val();
        if (machine == "") { machine = "0.00"; }
        $("#MachineModelList_1__MachineVolume").val(parseFloat(machine) + parseFloat(quantity));
    }
    if ($("#DiselModelList_0__DdlModel option:selected").val() == "3") {
        machine = $("#MachineModelList_2__MachineVolume").val();
        if (machine == "") { machine = "0.00"; }
        $("#MachineModelList_2__MachineVolume").val(parseFloat(machine) + parseFloat(quantity));
    }
    machine = parseFloat(machine) + parseFloat(quantity);
    totalDisel = parseFloat(totalDisel) - parseFloat(quantity);
    totalSalesQtyDisel = parseFloat(totalSalesQtyDisel) + parseFloat(quantity);
    totalSalesCostTaka = parseFloat(totalSalesCostTaka) + parseFloat(subTotal);


    //Now set values to all the total fields
    $("#AssetModel_TotalDisel").val(totalDisel);
    $("#txtTotalSaleQuantityDisel").val(totalSalesQtyDisel);
    $("#txtTotalTakaDisel").val(totalSalesCostTaka)


    oldSelectedOption = $("#DiselModelList_0__DdlModel option:selected").val();
    oldQuantity = quantity;
}

