var _regionAppService = snow.regionManagement.admin.regions.region;
$(function () {
    _regionAppService.getChildren(100000)
        .then(function (result) {
            mappingNodes(result);
            var ele = $("#parent");
            var treeSelect = ele.treeSelect({
                zNodes: result.items,
                height: 233,
                setting: {
                    async: {
                        enable: true,
                    },
                    callback: {
                        beforeAsync: function (treeId, treeNode) {
                            // TODO:存在二次触发问题
                            _regionAppService.getChildren(treeNode.id)
                                .then(function (result) {
                                    mappingNodes(result);
                                    treeSelect.zTree.removeChildNodes(treeNode);
                                    treeSelect.zTree.addNodes(treeNode, result.items);
                                });
                            return false;
                        },
                        onClick: function (event, treeId, treeNode) {
                            var name = getNames(treeNode);
                            ele.val(name);
                            $('#Region_ParentId').val(treeNode.id);
                        }
                    }
                }
            });
        });
    function getNames(treeNode) {
        var parentNode = treeNode.getParentNode();
        if (parentNode != null) {
            return getNames(parentNode) + '-' + treeNode.name;
        } else {
            return treeNode.name;
        }
    }
    function mappingNodes(result) {
        result.items.map(r => {
            r.isParent = !r.isLeaf;
        })
    }
});