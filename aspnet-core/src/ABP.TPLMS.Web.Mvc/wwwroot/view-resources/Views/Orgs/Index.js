//------------------------系统管理-->组织信息--------------------------------//
//刷新数据
//function initable() {
//    $("#dgOrg").datagrid({
//        url: "/Orgs/list",
//        title: "组织管理",
//        pagination: true,
//        pagesize: 10,
//        pagelist: [10, 20, 30],
//        fit: true,
//        fitcolumns: false,
//        loadmsg: "正在加载组织信息...",
//        nowarp: false,
//        border: false,
//        idfield: "Id",
//        sortname: "Id",
//        toolbar: "#dg-button",
//        sortorder: "asc",
//        frozencolumns: [[//冻结列
//            {
//                field: "chk", checkbox: true, align: "left", width: 50
//            }
//        ]],
//        columns: [[
//            { title: "编号1", field: "Id", width: 50, sortable: true },
//            { title: "组织名称", field: "Name", width: 200, sortable: true },
//            { title: "代码", field: "BizCode", width: 100, sortable: true },
//            { title: "海关代码", field: "CustomCode", width: 100, sortable: true },
//            { title: "状态", field: "Status", width: 80, sortable: false },
//            { title: "类型", field: "Type", width: 80, sortable: false },
//            { title: '创建时间', field: 'CreationTime', width: 130, align: 'center' }

//        ]]
//    });
//}

function initable() {
    //$('#dgOrg').treegrid({
    //    url: '/Orgs/List',
    //    title: '组织管理',
    //    singleSelect: true,
    //    idField: 'Id',  //关键字段来标识树节点，不能重复  
    //    treeField: 'Name',  //树节点字段，也就是树节点的名称
    //    sortName: "Id",
    //    sortOrder: "asc",
    //    fitColumns: false,
    //    loadMsg: '正在加载组织信息',
    //    nowarp: false,
    //    border: false,
    //    animate: true,//在节点展开或折叠的时候是否显示动画效果
    //    lines: true,//显示treegrid行
    //    frozenColumns: [[//冻结列
    //        {
    //            field: "chk", checkbox: true, align: "left", width: 50
    //        }
    //    ]],
    //    columns: [[
    //        { title: "编号", field: "Id", width: 50, sortable: true },
    //        { title: "组织名称", field: "Name", width: 200, sortable: true },
    //        { title: "代码", field: "BizCode", width: 100, sortable: true },
    //        { title: "海关代码", field: "CustomCode", width: 100, sortable: true },
    //        { title: "状态", field: "Status", width: 80, sortable: false },
    //        { title: "类型", field: "Type", width: 80, sortable: false },
    //        { title: '创建时间', field: 'CreationTime', width: 130, align: 'center' }

    //    ]],
    //    onLoadSuccess: function (data) {
    //        $('#dgOrg').treegrid('expandAll');//全部展开树节点
    //    }
    //});
   

    $("#dgOrg").treegrid({
        url: "/Orgs/List",
        title: "组织管理",
        pagination: false,
        fit: true,
        fitColumns: false,
        loadMsg: "正在加载组织信息...",
        nowarp: false,
        border: false,
        idField: "Id",
        sortName: "Id",
        sortOrder: "asc",
        treeField: "Name",
        frozenColumns: [[//冻结列
            {
                field: "chk", checkbox: true, align: "left", width: 50
            }
        ]],
        columns: [[
            { title: "编号", field: "Id", width: 50, sortable: true },
            { title: "组织名称", field: "Name", width: 200, sortable: true },
            { title: "代码", field: "BizCode", width: 100, sortable: true },
            { title: "海关代码", field: "CustomCode", width: 100, sortable: true },
            { title: "状态", field: "Status", width: 80, sortable: false },
            { title: "类型", field: "Type", width: 80, sortable: false },
            { title: '创建时间', field: 'CreationTime', width: 130, align: 'center' }

        ]]
    });
}

function reloaded() {   //reload
    $("#reload").click(function () {
        //
        $('#dgOrg').treegrid('reload');
    });

}

//清空文本框

function clearAll() {
    $("#IDUpdate").val("");
    $("#UpdBizCode").val("");
    $(':disabled[name]', this).each(function () {
        $(this).val("");
    });
}

var _orgService = abp.services.app.org;
var _$modal = $('#divAddUpdOrg');
var _$form = _$modal.find('form');

//弹出 添加组织信息的对话框
function showOrgDialog() {

    $("#add").click(function () {
        clearAll();
        BindTree();

        $("#divAddUpdOrg").dialog({
            closed: false,

            title: "添加组织信息",
            modal: true,
            width: 600,
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
        if (!_$form.valid()) {
            return;
        }


        var id = $("#IDUpdate").val();
        if (id == "" || id == undefined || id == "0") {

            //验证
            $.messager.confirm('确认', '您确认要保存吗？', function (r) {
                if (r) {

                    $("#IDUpdate").val("0");
                    var postData = _$form.serializeFormToObject();
                    //serializeFormToObject is defined in main.js
                    if (postData == null || postData == undefined || postData.Name == ""
                        || postData.BizCode == "") {
                        $.messager.alert('提示', ' 请填写相关必填项！', 'warning');
                        return;
                    }

                    abp.ui.setBusy(_$modal);
                    _orgService.create(postData).done(function () {
                        $("#IDUpdate").val("");
                        _$modal.modal('hide');
                        $("#divAddUpdOrg").dialog("close");
                        initable(); //reload page to see new user!
                    }).always(function () {
                        abp.ui.clearBusy(_$modal);
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

        var postData = GetOrg();
        if (postData == null || postData == undefined || postData.BizCode == ""
            || postData.Name == "") {
            $.messager.alert('提示', ' 请填写相关必填项！', 'warning');
            return;
        }

        $.post("/Orgs/Update", postData, function (data) {
            // alert(data);
            if (data == "OK") {
                $.messager.alert("提示", "修改成功！");
                $("#divAddUpdOrg").dialog("close");
                initable();
            }

            else {
                $.messager.alert("提示", data.msg);
                return;
            }

        });
    })
}

function BindTree() {

    $('#AddTree').combotree({
        url: '/Orgs/GetJsonTree',
        valueField: 'Id',
        textField: 'Name',

        multiple: false,
        editable: false,
        method: 'get',

        panelHeight: 'auto',
        checkbox: false,

        //required: true,
        //全部折叠

        onLoadSuccess: function (node, data) {
            $('#AddTree').combotree('tree').tree("expandAll"); //collapseAll

        },
        onSelect: function (node) {
            $('#UpdParentId').val(node.id);
            // alert(node.id);
        }
    });

}