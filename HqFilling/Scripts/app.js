$(function () {
    initialize();
});

function initialize() {
    try {
        $("#AssetModel_TotalDisel").attr("disabled", "disabled");
        $("#AssetModel_TotalPetrol").attr("disabled", "disabled");
        $("#AssetModel_TotalOcten").attr("disabled", "disabled");
        $("#AssetModel_TotalMobile").attr("disabled", "disabled");
        $("#AssetModel_TotalCarosin").attr("disabled", "disabled");
        $("#AssetModel_TotalGas").attr("disabled", "disabled");
        $("#AssetModel_CurrentDateTime").attr("disabled", "disabled");
        $("#AssetModel_TotalLugMobil").attr("disabled", "disabled");
        //$("#AssetModel_TotalAcidWater").attr("disabled", "disabled");
        //$("#AssetModel_TotalOthers").attr("disabled", "disabled");
        

        //===========================
        $("#MachineModelList_0__MachineVolume").attr("disabled", "disabled");
        $("#MachineModelList_1__MachineVolume").attr("disabled", "disabled");
        $("#MachineModelList_2__MachineVolume").attr("disabled", "disabled");
        $("#MachineModelList_3__MachineVolume").attr("disabled", "disabled");

        //============================
        $("#SaleRate").attr("disabled", "disabled");
        $("#TotalTaka").attr("disabled", "disabled");
        //============================
        $("#txtTotalSaleQuantityDisel").attr("disabled", "disabled");
        $("#txtTotalTakaDisel").attr("disabled", "disabled");
        $("#txtTotalSaleQuantityPetrol").attr("disabled", "disabled");
        $("#txtTotalTakaPetrol").attr("disabled", "disabled");

        $("#txtTotalSaleQuantityOcten").attr("disabled", "disabled");
        $("#txtTotalTakaOcten").attr("disabled", "disabled");
        $("#txtTotalSaleQuantityLoseMobile").attr("disabled", "disabled");
        $("#txtTotalTakaLoseMobile").attr("disabled", "disabled");

        $("#txtTotalSaleQuantityMobile").attr("disabled", "disabled");
        $("#txtTotalTakaMobile").attr("disabled", "disabled");
        $("#txtTotalSaleQuantityCarosin").attr("disabled", "disabled");
        $("#txtTotalTakaCarosin").attr("disabled", "disabled");


        $("#txtTotalSaleQuantityGas").attr("disabled", "disabled");
        $("#txtTotalTakaGas").attr("disabled", "disabled");
        $("#txtGrandTotalTaka").attr("disabled", "disabled");

        /*setInterval(function () {
            $("#AssetModel_CurrentDateTime").val(new Date());
        }, 1000);*/

        $("#txtSalesPriceDisel").attr("disabled", "disabled");
        $("#txtVatDisel").attr("disabled", "disabled");
        $("#txtSubTotalDisel").attr("disabled", "disabled");
        //$("#txtSubTotalDisel").attr("readonly", "readonly");
        //$("#optCarosin").attr("disabled", "disabled");
        $("#txtTotalSaleQuantityAcidWater").attr("disabled", "disabled");
        $("#txtTotalTakaAcidWater").attr("disabled", "disabled");
        $("#txtTotalSaleQuantityOthers").attr("disabled", "disabled");
        $("#txtTotalTakaOthers").attr("disabled", "disabled");

        window.setInterval(getCurrentDateTime, 1000);
    }
    catch (err) {
        console.log(err);
    }
}

function getCurrentDateTime() {
    $.ajax({
        url: baseUrl + "/Sale/GetCurrentDateTime",
        type: "POST",
        data: {},
        success: function (result) {
            if (result) {
                $("#AssetModel_CurrentDateTime").val(result.Message);
            }
        },
        error: ErrorHandler
    });
}

/*==============================================================*/
/*$.ajax({
url: baseUrl + "/Asset/GetAllAssetVolume",
type: "POST",
dataType: "json",
contentType: "application/json; charset=utf-8",
data: {},
success: function (data, status) {
if (data) {
$("#AssetModel_TotalDisel").val(data.TotalDisel).attr("disabled", "disabled");//.css({ 'display': 'block' });
$("#AssetModel_TotalPetrol").val(data.TotalPetrol).attr("disabled", "disabled");//.css({ 'display': 'block' });
$("#AssetModel_TotalOcten").val(data.TotalOcten).attr("disabled", "disabled"); //.css({ 'display': 'block' });
$("#AssetModel_TotalMobile").val(data.TotalMobile).attr("disabled", "disabled"); //.css({ 'display': 'block' });
$("#AssetModel_TotalCarosin").val(data.TotalCarosin).attr("disabled", "disabled"); //.css({ 'display': 'block' });
$("#AssetModel_TotalGas").val(data.TotalGas).attr("disabled", "disabled"); //.css({ 'display': 'block' });
$("#txtCurrentDateTime").val(data.CurrentDateTime).attr("disabled", "disabled"); //.css({ 'display': 'block' });
}
},
error: ErrorHandler
});*/

// add attribute
//$("#btnOK").attr("disabled", "disabled");

//remove attribute
//$("#btnOK").removeAttr("disabled");

/*==============================================================*/