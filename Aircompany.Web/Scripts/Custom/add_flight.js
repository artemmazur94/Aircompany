﻿$(document).ready(function () {
    loadSeatTypes();

    $("#PlaneId").change(loadSeatTypes);

    $("#submit-btn").click(function() {
        if (validateInputs()) {
            $("#add-flight-form").submit();
        }
    });

    $("#Date").focus(function() {
        $(this).parent().removeClass("has-error");
        $("#date-label").addClass("hidden");
    });

    $("#seat-prices-constainer").on('focus', '.price-input', function () {
        $(this).parent().parent().removeClass("has-error");
        $(this).parent().parent().find(".help-block").addClass("hidden");
    });
});

function validateInputs() {
    var valid = true;
    if (!validateDate($("#DepartureDate").val())) {
        $("#DepartureDate").parent().addClass("has-error");
        $("#departure-date-label").removeClass("hidden");
        valid = false;
    }
    if (!validateDate($("#ArivingDate").val())) {
        $("#ArivingDate").parent().addClass("has-error");
        $("#ariving-date-label").removeClass("hidden");
        valid = false;
    }
    $(".price-input").each(function() {
        if ($(this).val() <= 0) {
            $(this).parent().parent().addClass("has-error");
            $(this).parent().parent().find(".help-block").removeClass("hidden");
            valid = false;
        }
    });
    return valid;
}

function loadSeatTypes() {
    $.ajax({
        url: window.ActionUrl,
        type: 'GET',
        data: {
            'planeId': $("#PlaneId").val()
        },
        accept: 'application/json',
        success: function (data) {
            $("#seat-prices-constainer").empty().append(data);
        }
    });
}