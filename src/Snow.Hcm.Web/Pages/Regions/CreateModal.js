var regionAppService = snow.regionManagement.admin.regions.region;
$(function () {
    var nodes = [{
        id: '111111',
        name: "父节点1",
        children: [
            { id: '22222', name: "子节点1" },
            { id: '33333', name: "子节点2" }
        ]
    }];
    $("#Region_ParentId").selectTree({
        isSimpleNode: true,
        debug: true,
        data: nodes//result.items // 后台查询的数据 返回为data
    });
    //regionAppService.getList()
    //    .then(function (result) {
    //        $("#Region_ParentId").selectTree({
    //            isSimpleNode: true,
    //            debug: true,
    //            data: nodes//result.items // 后台查询的数据 返回为data
    //        });
    //    });
    
});