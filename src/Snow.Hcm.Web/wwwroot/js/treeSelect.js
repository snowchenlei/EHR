; (function ($) {
    $.fn.treeSelect = function (options) {
        return new TreeSelect(this, options)
    };
    var TreeSelect = function (el, options) {
        this.$el = $(el);
        if (!Function.prototype.bind) {
            Function.prototype.bind = function (obj) {
                var _self = this
                    , args = arguments;
                return function () {
                    _self.apply(obj, Array.prototype.slice.call(args, 1));
                }
            }
        }
        this.options = options;
        this.init();
    };
    TreeSelect.prototype = {
        constructor: TreeSelect,
        init: function () {
            this.render();
            this.zTree = $.fn.zTree.init(this.tree_el, this.options.setting, this.options.zNodes);
            this.bindEvent();
        },
        randomID: function (randomLength) {
            return Number(Math.random().toString().substr(3, randomLength) + new Date().getTime()).toString(36)
        },
        render: function () {
            this.$el.css({ display: 'block' });
            this.container = this.$el.wrap('<div class="mts-container ' + this.options.containerClass + '"/>').parent();
            var height = this.options.height + (this.options.height == "auto" ? "" : "px");
            this.tree_el = $('<ul class="ztree" style="height:' + height + '; width:' + (this.$el.outerWidth() - 2) + 'px;"></ul>');

            this.dropdown_container = $('<div class="dropdown_container"></div>');
            this.dropdown_container.append(this.tree_el);
            this.container.append(this.dropdown_container);
            this.id = this.randomID(3);
            this.dropdown_container.attr("id", this.id);
            this.tree_el.attr("id", this.randomID(3));
            return this.container;
        },
        bindEvent: function () {
            this.bindDrawerEventClick();
        },
        ifSlideUp: function () {
            var _this = this;
            if (_this.options.direction == 'auto') {
                /*元素高度*/
                var elH = _this.$el.height();
                /*元素距离顶部高度*/
                var el2top = _this.$el.offset().top;
                /*下拉框高度*/
                var drowdownHeight = _this.dropdown_container.height();

                /*滚动条位置*/
                var scrollTop = $(document).scrollTop();
                /*下拉框底部距离窗口底部的距离*/
                var height2top = el2top - scrollTop;
                /*窗口高度*/
                var wh = window.innerHeight;
                var height2bottom = wh - el2top - elH;

                if (height2bottom >= drowdownHeight) {
                    return false;
                }
                if (height2top > height2bottom) {
                    return true;
                } else {
                    return false;
                }
            } else if (_this.options.direction != 'up') {
                return false;
            } else {
                return true;
            }

        },
        bindDrawerEventClick: function () {
            var dropdown_container = this.dropdown_container;
            /*计算抽屉方向*/
            var _this = this;
            var onBodyMusedown = function (event) {
                if (!$(event.target).parents("#" + _this.id).length > 0) {
                    dropdown_container.fadeOut("fast");
                    $("body").unbind("mousedown", onBodyMusedown);
                }
            };
            this.$el.click(function () {
                if (_this.ifSlideUp()) {
                    dropdown_container.addClass("up")
                    dropdown_container.css("bottom", _this.$el.outerHeight());
                    dropdown_container.css("top", '');
                } else {
                    dropdown_container.css("bottom", '');
                    dropdown_container.css("top", _this.$el.outerHeight());
                }
                if (!dropdown_container.is(':visible')) {
                    dropdown_container.slideDown("fast");
                    $("body").bind("mousedown", onBodyMusedown);
                } else {
                    dropdown_container.fadeOut("fast");
                    $("body").unbind("mousedown", onBodyMusedown);
                }
            });
        },
    }
})(jQuery);