$(document).ready(function (e) {
    $('#jQueryTablesTest').dataTable(
        {
            "bServerSide": true,
            "sAjaxSource": "/Home/FillDataTablesTest",
            "bProcessing": true,

            "aoColumns" :[
                            {
                                "sName": "Activity",
                                "bsortable": false,
                                "bsearchable": false,
                                "fnRender": function (oObj) {
                                    return '<a href=\"Details/' + oObj.aData[0] + '\">View</a>';
                                }
                            },
                            { "sName" : "ID"},
                            { "sName" : "Company Name"},
                            { "sName" : "Company Address"},
                         ]
        });

});