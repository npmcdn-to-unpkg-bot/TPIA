/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.contentsCss = ['../../css/ckeditor.css'];
    config.width = 680;
    config.height = 150;
    config.allowedContent = true;
    //config.font_names = 'Arial;Arial Black;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana;新細明體;細明體;標楷體;微軟正黑體';
    config.undoStackSize = 50;
    config.pasteFromWordRemoveFontStyles = false;
    config.height = '220px';  //修改編輯框高度
    config.font_names = '新細明體/PMingLiU;細明體/MingLiU;標楷體/DFKai-SB;黑體/SimHei;宋體/SimSun;新宋體/NSimSun;仿宋/FangSong;楷體/KaiTi;仿宋_GB2312/FangSong_GB2312楷體_GB2312/KaiTi_GB2312;微軟正黑體/Microsoft JhengHei;微軟雅黑體/Microsoft YaHei;隸書/LiSu;幼圓/YouYuan;華文細黑/STXihei;華文楷體/STKaiti;華文宋體/STSong;華文中宋/STZhongsong;華文仿宋/STFangsong;方正舒體/FZShuTi;方正姚體/FZYaoti;華文彩雲/STCaiyun;華文琥珀/STHupo;華文隸書/STLiti;華文行楷/STXingkai;華文新魏/STXinwei;'
            + config.font_names;
};
