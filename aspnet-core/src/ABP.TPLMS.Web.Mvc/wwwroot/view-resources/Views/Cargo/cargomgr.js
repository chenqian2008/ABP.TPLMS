//------------------------系统功能-->货物信息--------------------------------//
//刷新数据
function initable() {
    $("#dgCargo").datagrid({
        url: "/Cargo/List",
        title: "货物管理",
        pagination: true,
        pageSize: 10,
        pageList: [10, 20, 30],
        fit: true,
        fitColumns: false,
        loadMsg: "正在加载货物信息...",
        nowarp: false,
        border: false,
        idField: "Id",
        sortName: "Id",
        toolbar: "#dg-button",
        sortOrder: "asc",
        frozenColumns: [[//冻结列
            { field: "ck", checkbox: true, align: "left", width: 50 }
        ]],

        columns: [[
            { title: "编号", field: "Id", width: 50, sortable: true },
            { title: "供应商", field: "SupplierId", width: 80, sortable: true },
            { title: "商品编码", field: "HSCode", width: 100, sortable: true },
            { title: "货物代码", field: "CargoCode", width: 100, sortable: true },
            { title: "货物名称", field: "CargoName", width: 80, sortable: false },
            { title: "规格型号", field: "Spcf", width: 100, sortable: false },
            { title: "产销国", field: "Country", width: 80, sortable: false },
            { title: "计量单位", field: "Unit", width: 100, sortable: false },
            { title: "包装", field: "Package", width: 100, sortable: false },
            { title: "单价", field: "Price", width: 100, sortable: false },
            { title: "币制", field: "Curr", width: 80, sortable: false },
            {
                title: "长宽高", field: "Length", width: 100, sortable: false, formatter: function (value, row, index) {
                    return row.Length + '*' + row.Width + '*' + row.Height;
                }
            },
            { title: "体积", field: "Vol", width: 80, sortable: false },
            { title: "备注", field: "Remark", width: 80, sortable: false },
            { title: '创建时间', field: 'CreationTime', width: 200, align: 'center' }
        ]]
    });
}
function reloaded() {   //reload
    $("#reload").click(function () {
        $('#dgCargo').datagrid('reload');
    });
}

//修改点击按钮事件
function updCargoInfo() {
    $("#edit").click(function () {
        var row = $("#dgCargo").datagrid('getSelected');

        if (row) {
            $.messager.confirm('编辑', '您想要编辑吗？', function (r) {
                if (r) {
                    showCargo(row);
                    //打开对话框编辑
                    $("#divAddUpdCargo").dialog({
                        closed: false,
                        title: "修改货物信息",
                        modal: true,
                        width: 700,
                        height: 450,
                        collapsible: true,
                        minimizable: true,
                        maximizable: true,
                        resizable: true,
                    });
                }
            });

        } else {
            $.messager.alert('提示', ' 请选择要编辑的行！', 'warning');
        }
    });
}

//删除
function deleteCargo() {
    $("#del").click(function () {
        var rows = $("#dgCargo").datagrid("getSelections");
        if (rows.length > 0) {
            $.messager.confirm("提示", "确定要删除吗?", function (res) {
                if (res) {
                    var codes = []; //重要不是{}
                    for (var i = 0; i < rows.length; i++) {
                        codes.push(rows[i].Id);
                    }
                    $.post("/Cargo/Delete", { "ids": codes.join(',') }, function (data) {
                        if (data == "OK") {
                            $.messager.alert("提示", "删除成功！");
                            $("#dgCargo").datagrid("clearChecked");
                            $("#dgCargo").datagrid("clearSelections");
                            $("#dgCargo").datagrid("load", {});
                        }
                        else if (data == "NO") {
                            $.messager.alert("提示", "删除失败！");
                            return;
                        }
                    });
                }
            });
        }
    })
}

//查询
function Search() {
    var _$form = $('form[name=searchform]');
    var params = _$form.serializeFormToObject();
    $('#dgCargo').datagrid({ queryParams: params });
}

//清空文本框
function clearAll() {
    $("#IDUpdate").val("");
    $("#UpdCargoCode").val("");
    $("#CreateTimeUpdate").val(getNowFormatDate());

    $("#UnitUpdate").val("");
    $("#CargoNameUpdate").val("");
}

//获取当前时间，格式YYYY-MM-DD
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = year + seperator1 + month + seperator1 + strDate;
    return currentdate;
}

//弹出 添加货物信息的对话框
function showCargoDialog() {
    $("#add").click(function () {
        clearAll();

        $("#divAddUpdCargo").dialog({
            closed: false,
            title: "添加货物信息",
            modal: true,
            width: 700,
            height: 450,
            collapsible: true,
            minimizable: true,
            maximizable: true,
            resizable: true
        });
    });

    $("#btnSave").click(function () {
        //  alert('1');
        //启用
        //保存
        var id = $("#IDUpdate").val();
        if (id == "" || id == undefined) {
            //验证
            $.messager.confirm('确认', '您确认要保存吗？', function (r) {
                if (r) {
                    var postData = GetCargo();
                    if (postData == null || postData == undefined || postData.SupplierId == "" || postData.CargoCode == "" || postData.CargoName == "" || postData.Unit == "") {
                        $.messager.alert('提示', ' 请填写相关必填项！', 'warning');
                        return;
                    }
                    $.post("/Cargo/Add", postData, function (data) {
                        // alert(data);
                        var obj = JSON.parse(data);
                        if (obj.result == "OK") {
                            $("#IDUpdate").val(obj.Id)
                            $("#divAddUpdCargo").dialog("close");
                            $.messager.alert("提示", "保存成功！");
                            initable();
                        }
                        else if (obj.result == "NO") {
                            $.messager.alert("提示", "保存失败！");
                            return;
                        }
                    });
                }
            })
        }
        else {
            saveDetail();
        }
    });
}

function saveDetail() {
    $.messager.confirm('确认', '您确认要修改吗？', function (r) {
        var postData = GetCargo();
        if (postData == null || postData == undefined || postData.SupplierId == "" || postData.CargoCode == "") {
            $.messager.alert('提示', ' 请填写相关必填项！', 'warning');
            return;
        }
        $.post("/Cargo/Update", postData, function (data) {
            // alert(data); 
            var obj = JSON.parse(data);
            if (obj.result == "OK") {
                $.messager.alert("提示", "修改成功！");
                $("#divAddUpdCargo").dialog("close");
                initable();
            }
            else if (obj.result == "NO") {
                $.messager.alert("提示", "修改失败！");
                return;
            }
        });
    })
}

function GetCargo() {
    var postData = {
        "id": $("#IDUpdate").val(),
        "CargoName": $("#CargoNameUpdate").val(),
        "CargoCode": $("#UpdCargoCode").val(),
        "CreationTime": $("#CreateTimeUpdate").val(),
        "SupplierId": $("#SupplierIdUpdate").val(),
        "Brand": $("#BrandUpdate").val(),
        "Country": $("#CountryUpdate").val(),
        "Curr": $("#CurrUpdate").val(),
        "GrossWt": $("#GrossWtUpdate").val(),
        "Height": $("#HeightUpdate").val(),
        "HSCode": $("#HSCodeUpdate").val(),
        "Length": $("#LengthUpdate").val(),
        "MaxNum": $("#MaxNumUpdate").val(),

        "MinNum": $("#MinNumUpdate").val(),
        "NetWt": $("#NetWtUpdate").val(),
        "Package": $("#PackageUpdate").val(),
        "Price": $("#PriceUpdate").val(),
        "Remark": $("#RemarkUpdate").val(),
        "Spcf": $("#SpcfUpdate").val(),
        "Unit": $("#UnitUpdate").val(),
        "UpdateTime": $("#CreateTimeUpdate").val(),

        "Vol": $("#VolUpdate").val(),
        "Width": $("#WidthUpdate").val(),
        "UpdOper": $("#SupplierIdUpdate").val()
    };
    return postData;

}

function showCargo(row) {

    $("#IDUpdate").val(row.Id);
    $("#CargoNameUpdate").val(row.CargoName);
    $("#UpdCargoCode").val(row.CargoCode);
    $("#CreateTimeUpdate").val(row.UpdateTime);
    $("#BrandUpdate").val(row.Brand);
    $("#CountryUpdate").val(row.Country);
    $("#CurrUpdate").val(row.Curr);
    $("#GrossWtUpdate").val(row.GrossWt);
    $("#HeightUpdate").val(row.Height);
    $("#HSCodeUpdate").val(row.HSCode);
    $("#LengthUpdate").val(row.Length);
    $("#MaxNumUpdate").val(row.MaxNum);
    $("#MinNumUpdate").val(row.MinNum);
    $("#NetWtUpdate").val(row.NetWt);
    $("#PackageUpdate").val(row.Package);
    $("#PriceUpdate").val(row.Price);
    $("#RemarkUpdate").val(row.Remark);
    $("#SpcfUpdate").val(row.Spcf);
    $("#UnitUpdate").val(row.Unit);
    $("#VoleUpdate").val(row.Vol);
    $("#WidthUpdate").val(row.Width);
}

function calcSumVol() {
    var vol = 0;
    var len = $("#LengthUpdate").val();
    var height = $("#HeightUpdate").val();
    var width = $("#WidthUpdate").val();

    //计算体积
    var l = parseFloat(len);
    var h = parseFloat(height);
    var w = parseFloat(width);
    vol = ((l * h * w) / (100 * 100 * 100)).toFixed(3);

    $("#VolUpdate").val(vol);
}

function init() {
    $("#LengthUpdate").blur(function () {
        calcSumVol();
    });
    $("#HeightUpdate").blur(function () {
        calcSumVol();
    });
    $("#WidthUpdate").blur(function () {
        calcSumVol();
    });
}

//------------------------系统功能-->货物信息结束----------------------------//