


$("#AddButton").click(function () {
    createRowForPurchase();

});


var index = 0;
function createRowForPurchase() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#PurchaseDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden'  name='PurchaseDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var itemTd = "<td> <input type='hidden' id='ItemName" + index + "'  name='PurchaseDetailses[" + index + "].Name' value='" + selectedItem.Name + "' /> " + selectedItem.Name + " </td>";
    var qtyTd = "<td> <input type='hidden' id='ItemQty" + index + "'  name='PurchaseDetailses[" + index + "].Qty' value='" + selectedItem.Qty + "' /> " + selectedItem.Qty + " </td>";
    var costPriceTd = "<td> <input type='hidden' id='ItemCostPrice" + index + "'  name='PurchaseDetailses[" + index + "].Qty' value='" + selectedItem.Cost + "' /> " + selectedItem.Cost + " </td>";


    var newRow = "<tr>" + indexTd + slTd + itemTd + qtyTd +costPriceTd+ " </tr>";

    $("#PurchaseDetailsTable").append(newRow);
    $("#ItemName").val("");
    $("#ItemQty").val("");
    $("#ItemCostPrice").val("");

}


function getSelectedItem() {
    var name = $("#ItemName").val();
    var qty = $("#ItemQty").val();
    var cost = $("#ItemCostPrice").val();



    if (qty == "") {
        return false;
    }

    var item = {
        "Name": name,
        "Qty": qty,
        "Cost":cost
    }

    return item;
}