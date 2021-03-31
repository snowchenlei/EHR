var _regionAppService = snow.regionManagement.admin.regions.region;
$(function () {
    _regionAppService.getChildren(100000)
        .then(function (result) {
            mappingNodes(result);
            var ele = $("#Region_ParentId");            
            var treeSelect = ele.treeSelect({
                zNodes: result.items,
                height: 233,
                setting: {
                    data: {
                        key: {
                            isParent: "isLeaf"
                        }
                    },
                    async: {
                        enable: true,
                    },
                    callback: {
                        beforeAsync: function (treeId, treeNode,) {
                            // TODO:存在二次触发问题
                            _regionAppService.getChildren(treeNode.id)
                                .then(function (result) {                                    
                                    mappingNodes(result);
                                    treeSelect.zTree.removeChildNodes(treeNode);
                                    treeSelect.zTree.addNodes(treeNode, result.items);
                                });
                            return false;
                        }
                    }
                }
            });
        });
    function mappingNodes(result) {
        result.items.map(r => {
            var isP = !r.isLeaf;
            r.isLeaf = isP;
        })
    }
});