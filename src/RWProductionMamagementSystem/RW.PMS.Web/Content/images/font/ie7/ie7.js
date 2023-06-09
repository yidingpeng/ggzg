/* To avoid CSS expressions while still supporting IE 7 and IE 6, use this script */
/* The script tag referencing this file must be placed before the ending body tag. */

/* Use conditional comments in order to target IE 7 and older:
	<!--[if lt IE 8]><!-->
	<script src="ie7/ie7.js"></script>
	<!--<![endif]-->
*/

(function() {
	function addIcon(el, entity) {
		var html = el.innerHTML;
		el.innerHTML = '<span style="font-family: \'font-2\'">' + entity + '</span>' + html;
	}
	var icons = {
		'icon-glass': '&#xf000;',
		'icon-music': '&#xf001;',
		'icon-search': '&#xf002;',
		'icon-envelope-o': '&#xf003;',
		'icon-heart': '&#xf004;',
		'icon-star': '&#xf005;',
		'icon-star-o': '&#xf006;',
		'icon-user': '&#xf007;',
		'icon-film': '&#xf008;',
		'icon-th-large': '&#xf009;',
		'icon-th': '&#xf00a;',
		'icon-th-list': '&#xf00b;',
		'icon-check': '&#xf00c;',
		'icon-close': '&#xf00d;',
		'icon-search-plus': '&#xf00e;',
		'icon-search-minus': '&#xf010;',
		'icon-power-off': '&#xf011;',
		'icon-signal': '&#xf012;',
		'icon-cog': '&#xf013;',
		'icon-trash-o': '&#xf014;',
		'icon-home': '&#xf015;',
		'icon-file-o': '&#xf016;',
		'icon-clock-o': '&#xf017;',
		'icon-road': '&#xf018;',
		'icon-download': '&#xf019;',
		'icon-arrow-circle-o-down': '&#xf01a;',
		'icon-arrow-circle-o-up': '&#xf01b;',
		'icon-inbox': '&#xf01c;',
		'icon-play-circle-o': '&#xf01d;',
		'icon-repeat': '&#xf01e;',
		'icon-refresh': '&#xf021;',
		'icon-list-alt': '&#xf022;',
		'icon-lock': '&#xf023;',
		'icon-flag': '&#xf024;',
		'icon-headphones': '&#xf025;',
		'icon-volume-off': '&#xf026;',
		'icon-volume-down': '&#xf027;',
		'icon-volume-up': '&#xf028;',
		'icon-qrcode': '&#xf029;',
		'icon-barcode': '&#xf02a;',
		'icon-tag': '&#xf02b;',
		'icon-tags': '&#xf02c;',
		'icon-book': '&#xf02d;',
		'icon-bookmark': '&#xf02e;',
		'icon-print': '&#xf02f;',
		'icon-camera': '&#xf030;',
		'icon-font': '&#xf031;',
		'icon-bold': '&#xf032;',
		'icon-italic': '&#xf033;',
		'icon-text-height': '&#xf034;',
		'icon-text-width': '&#xf035;',
		'icon-align-left': '&#xf036;',
		'icon-align-center': '&#xf037;',
		'icon-align-right': '&#xf038;',
		'icon-align-justify': '&#xf039;',
		'icon-list': '&#xf03a;',
		'icon-dedent': '&#xf03b;',
		'icon-indent': '&#xf03c;',
		'icon-video-camera': '&#xf03d;',
		'icon-image': '&#xf03e;',
		'icon-pencil': '&#xf040;',
		'icon-map-marker': '&#xf041;',
		'icon-adjust': '&#xf042;',
		'icon-tint': '&#xf043;',
		'icon-edit': '&#xf044;',
		'icon-share-square-o': '&#xf045;',
		'icon-check-square-o': '&#xf046;',
		'icon-arrows': '&#xf047;',
		'icon-step-backward': '&#xf048;',
		'icon-fast-backward': '&#xf049;',
		'icon-backward': '&#xf04a;',
		'icon-play': '&#xf04b;',
		'icon-pause': '&#xf04c;',
		'icon-stop': '&#xf04d;',
		'icon-forward': '&#xf04e;',
		'icon-fast-forward': '&#xf050;',
		'icon-step-forward': '&#xf051;',
		'icon-eject': '&#xf052;',
		'icon-chevron-left': '&#xf053;',
		'icon-chevron-right': '&#xf054;',
		'icon-plus-circle': '&#xf055;',
		'icon-minus-circle': '&#xf056;',
		'icon-times-circle': '&#xf057;',
		'icon-check-circle': '&#xf058;',
		'icon-question-circle': '&#xf059;',
		'icon-info-circle': '&#xf05a;',
		'icon-crosshairs': '&#xf05b;',
		'icon-times-circle-o': '&#xf05c;',
		'icon-check-circle-o': '&#xf05d;',
		'icon-ban': '&#xf05e;',
		'icon-arrow-left': '&#xf060;',
		'icon-arrow-right': '&#xf061;',
		'icon-arrow-up': '&#xf062;',
		'icon-arrow-down': '&#xf063;',
		'icon-mail-forward': '&#xf064;',
		'icon-expand': '&#xf065;',
		'icon-compress': '&#xf066;',
		'icon-plus': '&#xf067;',
		'icon-minus': '&#xf068;',
		'icon-asterisk': '&#xf069;',
		'icon-exclamation-circle': '&#xf06a;',
		'icon-gift': '&#xf06b;',
		'icon-leaf': '&#xf06c;',
		'icon-fire': '&#xf06d;',
		'icon-eye': '&#xf06e;',
		'icon-eye-slash': '&#xf070;',
		'icon-exclamation-triangle': '&#xf071;',
		'icon-plane': '&#xf072;',
		'icon-calendar': '&#xf073;',
		'icon-random': '&#xf074;',
		'icon-comment': '&#xf075;',
		'icon-magnet': '&#xf076;',
		'icon-chevron-up': '&#xf077;',
		'icon-chevron-down': '&#xf078;',
		'icon-retweet': '&#xf079;',
		'icon-shopping-cart': '&#xf07a;',
		'icon-folder': '&#xf07b;',
		'icon-folder-open': '&#xf07c;',
		'icon-arrows-v': '&#xf07d;',
		'icon-arrows-h': '&#xf07e;',
		'icon-bar-chart': '&#xf080;',
		'icon-twitter-square': '&#xf081;',
		'icon-facebook-square': '&#xf082;',
		'icon-camera-retro': '&#xf083;',
		'icon-key': '&#xf084;',
		'icon-cogs': '&#xf085;',
		'icon-comments': '&#xf086;',
		'icon-thumbs-o-up': '&#xf087;',
		'icon-thumbs-o-down': '&#xf088;',
		'icon-star-half': '&#xf089;',
		'icon-heart-o': '&#xf08a;',
		'icon-sign-out': '&#xf08b;',
		'icon-linkedin-square': '&#xf08c;',
		'icon-thumb-tack': '&#xf08d;',
		'icon-external-link': '&#xf08e;',
		'icon-sign-in': '&#xf090;',
		'icon-trophy': '&#xf091;',
		'icon-github-square': '&#xf092;',
		'icon-upload': '&#xf093;',
		'icon-lemon-o': '&#xf094;',
		'icon-phone': '&#xf095;',
		'icon-square-o': '&#xf096;',
		'icon-bookmark-o': '&#xf097;',
		'icon-phone-square': '&#xf098;',
		'icon-twitter': '&#xf099;',
		'icon-facebook': '&#xf09a;',
		'icon-github': '&#xf09b;',
		'icon-unlock': '&#xf09c;',
		'icon-credit-card': '&#xf09d;',
		'icon-feed': '&#xf09e;',
		'icon-hdd-o': '&#xf0a0;',
		'icon-bullhorn': '&#xf0a1;',
		'icon-bell-o': '&#xf0a2;',
		'icon-certificate': '&#xf0a3;',
		'icon-hand-o-right': '&#xf0a4;',
		'icon-hand-o-left': '&#xf0a5;',
		'icon-hand-o-up': '&#xf0a6;',
		'icon-hand-o-down': '&#xf0a7;',
		'icon-arrow-circle-left': '&#xf0a8;',
		'icon-arrow-circle-right': '&#xf0a9;',
		'icon-arrow-circle-up': '&#xf0aa;',
		'icon-arrow-circle-down': '&#xf0ab;',
		'icon-globe': '&#xf0ac;',
		'icon-wrench': '&#xf0ad;',
		'icon-tasks': '&#xf0ae;',
		'icon-filter': '&#xf0b0;',
		'icon-briefcase': '&#xf0b1;',
		'icon-arrows-alt': '&#xf0b2;',
		'icon-group': '&#xf0c0;',
		'icon-chain': '&#xf0c1;',
		'icon-cloud': '&#xf0c2;',
		'icon-flask': '&#xf0c3;',
		'icon-cut': '&#xf0c4;',
		'icon-copy': '&#xf0c5;',
		'icon-paperclip': '&#xf0c6;',
		'icon-floppy-o': '&#xf0c7;',
		'icon-square': '&#xf0c8;',
		'icon-bars': '&#xf0c9;',
		'icon-list-ul': '&#xf0ca;',
		'icon-list-ol': '&#xf0cb;',
		'icon-strikethrough': '&#xf0cc;',
		'icon-underline': '&#xf0cd;',
		'icon-table': '&#xf0ce;',
		'icon-magic': '&#xf0d0;',
		'icon-truck': '&#xf0d1;',
		'icon-pinterest': '&#xf0d2;',
		'icon-pinterest-square': '&#xf0d3;',
		'icon-google-plus-square': '&#xf0d4;',
		'icon-google-plus': '&#xf0d5;',
		'icon-money': '&#xf0d6;',
		'icon-caret-down': '&#xf0d7;',
		'icon-caret-up': '&#xf0d8;',
		'icon-caret-left': '&#xf0d9;',
		'icon-caret-right': '&#xf0da;',
		'icon-columns': '&#xf0db;',
		'icon-sort': '&#xf0dc;',
		'icon-sort-desc': '&#xf0dd;',
		'icon-sort-asc': '&#xf0de;',
		'icon-envelope': '&#xf0e0;',
		'icon-linkedin': '&#xf0e1;',
		'icon-rotate-left': '&#xf0e2;',
		'icon-gavel': '&#xf0e3;',
		'icon-dashboard': '&#xf0e4;',
		'icon-comment-o': '&#xf0e5;',
		'icon-comments-o': '&#xf0e6;',
		'icon-bolt': '&#xf0e7;',
		'icon-sitemap': '&#xf0e8;',
		'icon-umbrella': '&#xf0e9;',
		'icon-clipboard': '&#xf0ea;',
		'icon-lightbulb-o': '&#xf0eb;',
		'icon-exchange': '&#xf0ec;',
		'icon-cloud-download': '&#xf0ed;',
		'icon-cloud-upload': '&#xf0ee;',
		'icon-user-md': '&#xf0f0;',
		'icon-stethoscope': '&#xf0f1;',
		'icon-suitcase': '&#xf0f2;',
		'icon-bell': '&#xf0f3;',
		'icon-coffee': '&#xf0f4;',
		'icon-cutlery': '&#xf0f5;',
		'icon-file-text-o': '&#xf0f6;',
		'icon-building-o': '&#xf0f7;',
		'icon-hospital-o': '&#xf0f8;',
		'icon-ambulance': '&#xf0f9;',
		'icon-medkit': '&#xf0fa;',
		'icon-fighter-jet': '&#xf0fb;',
		'icon-beer': '&#xf0fc;',
		'icon-h-square': '&#xf0fd;',
		'icon-plus-square': '&#xf0fe;',
		'icon-angle-double-left': '&#xf100;',
		'icon-angle-double-right': '&#xf101;',
		'icon-angle-double-up': '&#xf102;',
		'icon-angle-double-down': '&#xf103;',
		'icon-angle-left': '&#xf104;',
		'icon-angle-right': '&#xf105;',
		'icon-angle-up': '&#xf106;',
		'icon-angle-down': '&#xf107;',
		'icon-desktop': '&#xf108;',
		'icon-laptop': '&#xf109;',
		'icon-tablet': '&#xf10a;',
		'icon-mobile': '&#xf10b;',
		'icon-circle-o': '&#xf10c;',
		'icon-quote-left': '&#xf10d;',
		'icon-quote-right': '&#xf10e;',
		'icon-spinner': '&#xf110;',
		'icon-circle': '&#xf111;',
		'icon-mail-reply': '&#xf112;',
		'icon-github-alt': '&#xf113;',
		'icon-folder-o': '&#xf114;',
		'icon-folder-open-o': '&#xf115;',
		'icon-smile-o': '&#xf118;',
		'icon-frown-o': '&#xf119;',
		'icon-meh-o': '&#xf11a;',
		'icon-gamepad': '&#xf11b;',
		'icon-keyboard-o': '&#xf11c;',
		'icon-flag-o': '&#xf11d;',
		'icon-flag-checkered': '&#xf11e;',
		'icon-terminal': '&#xf120;',
		'icon-code': '&#xf121;',
		'icon-mail-reply-all': '&#xf122;',
		'icon-star-half-empty': '&#xf123;',
		'icon-location-arrow': '&#xf124;',
		'icon-crop': '&#xf125;',
		'icon-code-fork': '&#xf126;',
		'icon-chain-broken': '&#xf127;',
		'icon-question': '&#xf128;',
		'icon-info': '&#xf129;',
		'icon-exclamation': '&#xf12a;',
		'icon-superscript': '&#xf12b;',
		'icon-subscript': '&#xf12c;',
		'icon-eraser': '&#xf12d;',
		'icon-puzzle-piece': '&#xf12e;',
		'icon-microphone': '&#xf130;',
		'icon-microphone-slash': '&#xf131;',
		'icon-shield': '&#xf132;',
		'icon-calendar-o': '&#xf133;',
		'icon-fire-extinguisher': '&#xf134;',
		'icon-rocket': '&#xf135;',
		'icon-maxcdn': '&#xf136;',
		'icon-chevron-circle-left': '&#xf137;',
		'icon-chevron-circle-right': '&#xf138;',
		'icon-chevron-circle-up': '&#xf139;',
		'icon-chevron-circle-down': '&#xf13a;',
		'icon-html5': '&#xf13b;',
		'icon-css3': '&#xf13c;',
		'icon-anchor': '&#xf13d;',
		'icon-unlock-alt': '&#xf13e;',
		'icon-bullseye': '&#xf140;',
		'icon-ellipsis-h': '&#xf141;',
		'icon-ellipsis-v': '&#xf142;',
		'icon-rss-square': '&#xf143;',
		'icon-play-circle': '&#xf144;',
		'icon-ticket': '&#xf145;',
		'icon-minus-square': '&#xf146;',
		'icon-minus-square-o': '&#xf147;',
		'icon-level-up': '&#xf148;',
		'icon-level-down': '&#xf149;',
		'icon-check-square': '&#xf14a;',
		'icon-pencil-square': '&#xf14b;',
		'icon-external-link-square': '&#xf14c;',
		'icon-share-square': '&#xf14d;',
		'icon-compass': '&#xf14e;',
		'icon-caret-square-o-down': '&#xf150;',
		'icon-caret-square-o-up': '&#xf151;',
		'icon-caret-square-o-right': '&#xf152;',
		'icon-eur': '&#xf153;',
		'icon-gbp': '&#xf154;',
		'icon-dollar': '&#xf155;',
		'icon-inr': '&#xf156;',
		'icon-cny': '&#xf157;',
		'icon-rouble': '&#xf158;',
		'icon-krw': '&#xf159;',
		'icon-bitcoin': '&#xf15a;',
		'icon-file': '&#xf15b;',
		'icon-file-text': '&#xf15c;',
		'icon-sort-alpha-asc': '&#xf15d;',
		'icon-sort-alpha-desc': '&#xf15e;',
		'icon-sort-amount-asc': '&#xf160;',
		'icon-sort-amount-desc': '&#xf161;',
		'icon-sort-numeric-asc': '&#xf162;',
		'icon-sort-numeric-desc': '&#xf163;',
		'icon-thumbs-up': '&#xf164;',
		'icon-thumbs-down': '&#xf165;',
		'icon-youtube-square': '&#xf166;',
		'icon-youtube': '&#xf167;',
		'icon-xing': '&#xf168;',
		'icon-xing-square': '&#xf169;',
		'icon-youtube-play': '&#xf16a;',
		'icon-dropbox': '&#xf16b;',
		'icon-stack-overflow': '&#xf16c;',
		'icon-instagram': '&#xf16d;',
		'icon-flickr': '&#xf16e;',
		'icon-adn': '&#xf170;',
		'icon-bitbucket': '&#xf171;',
		'icon-bitbucket-square': '&#xf172;',
		'icon-tumblr': '&#xf173;',
		'icon-tumblr-square': '&#xf174;',
		'icon-long-arrow-down': '&#xf175;',
		'icon-long-arrow-up': '&#xf176;',
		'icon-long-arrow-left': '&#xf177;',
		'icon-long-arrow-right': '&#xf178;',
		'icon-apple': '&#xf179;',
		'icon-windows': '&#xf17a;',
		'icon-android': '&#xf17b;',
		'icon-linux': '&#xf17c;',
		'icon-dribbble': '&#xf17d;',
		'icon-skype': '&#xf17e;',
		'icon-foursquare': '&#xf180;',
		'icon-trello': '&#xf181;',
		'icon-female': '&#xf182;',
		'icon-male': '&#xf183;',
		'icon-gittip': '&#xf184;',
		'icon-sun-o': '&#xf185;',
		'icon-moon-o': '&#xf186;',
		'icon-archive': '&#xf187;',
		'icon-bug': '&#xf188;',
		'icon-vk': '&#xf189;',
		'icon-weibo': '&#xf18a;',
		'icon-renren': '&#xf18b;',
		'icon-pagelines': '&#xf18c;',
		'icon-stack-exchange': '&#xf18d;',
		'icon-arrow-circle-o-right': '&#xf18e;',
		'icon-arrow-circle-o-left': '&#xf190;',
		'icon-caret-square-o-left': '&#xf191;',
		'icon-dot-circle-o': '&#xf192;',
		'icon-wheelchair': '&#xf193;',
		'icon-vimeo-square': '&#xf194;',
		'icon-try': '&#xf195;',
		'icon-plus-square-o': '&#xf196;',
		'icon-space-shuttle': '&#xf197;',
		'icon-slack': '&#xf198;',
		'icon-envelope-square': '&#xf199;',
		'icon-wordpress': '&#xf19a;',
		'icon-openid': '&#xf19b;',
		'icon-bank': '&#xf19c;',
		'icon-graduation-cap': '&#xf19d;',
		'icon-yahoo': '&#xf19e;',
		'icon-google': '&#xf1a0;',
		'icon-reddit': '&#xf1a1;',
		'icon-reddit-square': '&#xf1a2;',
		'icon-stumbleupon-circle': '&#xf1a3;',
		'icon-stumbleupon': '&#xf1a4;',
		'icon-delicious': '&#xf1a5;',
		'icon-digg': '&#xf1a6;',
		'icon-pied-piper': '&#xf1a7;',
		'icon-pied-piper-alt': '&#xf1a8;',
		'icon-drupal': '&#xf1a9;',
		'icon-joomla': '&#xf1aa;',
		'icon-language': '&#xf1ab;',
		'icon-fax': '&#xf1ac;',
		'icon-building': '&#xf1ad;',
		'icon-child': '&#xf1ae;',
		'icon-paw': '&#xf1b0;',
		'icon-spoon': '&#xf1b1;',
		'icon-cube': '&#xf1b2;',
		'icon-cubes': '&#xf1b3;',
		'icon-behance': '&#xf1b4;',
		'icon-behance-square': '&#xf1b5;',
		'icon-steam': '&#xf1b6;',
		'icon-steam-square': '&#xf1b7;',
		'icon-recycle': '&#xf1b8;',
		'icon-automobile': '&#xf1b9;',
		'icon-cab': '&#xf1ba;',
		'icon-tree': '&#xf1bb;',
		'icon-spotify': '&#xf1bc;',
		'icon-deviantart': '&#xf1bd;',
		'icon-soundcloud': '&#xf1be;',
		'icon-database': '&#xf1c0;',
		'icon-file-pdf-o': '&#xf1c1;',
		'icon-file-word-o': '&#xf1c2;',
		'icon-file-excel-o': '&#xf1c3;',
		'icon-file-powerpoint-o': '&#xf1c4;',
		'icon-file-image-o': '&#xf1c5;',
		'icon-file-archive-o': '&#xf1c6;',
		'icon-file-audio-o': '&#xf1c7;',
		'icon-file-movie-o': '&#xf1c8;',
		'icon-file-code-o': '&#xf1c9;',
		'icon-vine': '&#xf1ca;',
		'icon-codepen': '&#xf1cb;',
		'icon-jsfiddle': '&#xf1cc;',
		'icon-life-bouy': '&#xf1cd;',
		'icon-circle-o-notch': '&#xf1ce;',
		'icon-ra': '&#xf1d0;',
		'icon-empire': '&#xf1d1;',
		'icon-git-square': '&#xf1d2;',
		'icon-git': '&#xf1d3;',
		'icon-hacker-news': '&#xf1d4;',
		'icon-tencent-weibo': '&#xf1d5;',
		'icon-qq': '&#xf1d6;',
		'icon-wechat': '&#xf1d7;',
		'icon-paper-plane': '&#xf1d8;',
		'icon-paper-plane-o': '&#xf1d9;',
		'icon-history': '&#xf1da;',
		'icon-circle-thin': '&#xf1db;',
		'icon-header': '&#xf1dc;',
		'icon-paragraph': '&#xf1dd;',
		'icon-sliders': '&#xf1de;',
		'icon-share-alt': '&#xf1e0;',
		'icon-share-alt-square': '&#xf1e1;',
		'icon-bomb': '&#xf1e2;',
		'icon-futbol-o': '&#xf1e3;',
		'icon-tty': '&#xf1e4;',
		'icon-binoculars': '&#xf1e5;',
		'icon-plug': '&#xf1e6;',
		'icon-slideshare': '&#xf1e7;',
		'icon-twitch': '&#xf1e8;',
		'icon-yelp': '&#xf1e9;',
		'icon-newspaper-o': '&#xf1ea;',
		'icon-wifi': '&#xf1eb;',
		'icon-calculator': '&#xf1ec;',
		'icon-paypal': '&#xf1ed;',
		'icon-google-wallet': '&#xf1ee;',
		'icon-cc-visa': '&#xf1f0;',
		'icon-cc-mastercard': '&#xf1f1;',
		'icon-cc-discover': '&#xf1f2;',
		'icon-cc-amex': '&#xf1f3;',
		'icon-cc-paypal': '&#xf1f4;',
		'icon-cc-stripe': '&#xf1f5;',
		'icon-bell-slash': '&#xf1f6;',
		'icon-bell-slash-o': '&#xf1f7;',
		'icon-trash': '&#xf1f8;',
		'icon-copyright': '&#xf1f9;',
		'icon-at': '&#xf1fa;',
		'icon-eyedropper': '&#xf1fb;',
		'icon-paint-brush': '&#xf1fc;',
		'icon-birthday-cake': '&#xf1fd;',
		'icon-area-chart': '&#xf1fe;',
		'icon-pie-chart': '&#xf200;',
		'icon-line-chart': '&#xf201;',
		'icon-lastfm': '&#xf202;',
		'icon-lastfm-square': '&#xf203;',
		'icon-toggle-off': '&#xf204;',
		'icon-toggle-on': '&#xf205;',
		'icon-bicycle': '&#xf206;',
		'icon-bus': '&#xf207;',
		'icon-ioxhost': '&#xf208;',
		'icon-angellist': '&#xf209;',
		'icon-cc': '&#xf20a;',
		'icon-ils': '&#xf20b;',
		'icon-meanpath': '&#xf20c;',
		'icon-buysellads': '&#xf20d;',
		'icon-connectdevelop': '&#xf20e;',
		'icon-dashcube': '&#xf210;',
		'icon-forumbee': '&#xf211;',
		'icon-leanpub': '&#xf212;',
		'icon-sellsy': '&#xf213;',
		'icon-shirtsinbulk': '&#xf214;',
		'icon-simplybuilt': '&#xf215;',
		'icon-skyatlas': '&#xf216;',
		'icon-cart-plus': '&#xf217;',
		'icon-cart-arrow-down': '&#xf218;',
		'icon-diamond': '&#xf219;',
		'icon-ship': '&#xf21a;',
		'icon-user-secret': '&#xf21b;',
		'icon-motorcycle': '&#xf21c;',
		'icon-street-view': '&#xf21d;',
		'icon-heartbeat': '&#xf21e;',
		'icon-venus': '&#xf221;',
		'icon-mars': '&#xf222;',
		'icon-mercury': '&#xf223;',
		'icon-intersex': '&#xf224;',
		'icon-transgender-alt': '&#xf225;',
		'icon-venus-double': '&#xf226;',
		'icon-mars-double': '&#xf227;',
		'icon-venus-mars': '&#xf228;',
		'icon-mars-stroke': '&#xf229;',
		'icon-mars-stroke-v': '&#xf22a;',
		'icon-mars-stroke-h': '&#xf22b;',
		'icon-neuter': '&#xf22c;',
		'icon-genderless': '&#xf22d;',
		'icon-facebook-official': '&#xf230;',
		'icon-pinterest-p': '&#xf231;',
		'icon-whatsapp': '&#xf232;',
		'icon-server': '&#xf233;',
		'icon-user-plus': '&#xf234;',
		'icon-user-times': '&#xf235;',
		'icon-bed': '&#xf236;',
		'icon-viacoin': '&#xf237;',
		'icon-train': '&#xf238;',
		'icon-subway': '&#xf239;',
		'icon-medium': '&#xf23a;',
		'icon-y-combinator': '&#xf23b;',
		'icon-optin-monster': '&#xf23c;',
		'icon-opencart': '&#xf23d;',
		'icon-expeditedssl': '&#xf23e;',
		'icon-battery-4': '&#xf240;',
		'icon-battery-3': '&#xf241;',
		'icon-battery-2': '&#xf242;',
		'icon-battery-1': '&#xf243;',
		'icon-battery-0': '&#xf244;',
		'icon-mouse-pointer': '&#xf245;',
		'icon-i-cursor': '&#xf246;',
		'icon-object-group': '&#xf247;',
		'icon-object-ungroup': '&#xf248;',
		'icon-sticky-note': '&#xf249;',
		'icon-sticky-note-o': '&#xf24a;',
		'icon-cc-jcb': '&#xf24b;',
		'icon-cc-diners-club': '&#xf24c;',
		'icon-clone': '&#xf24d;',
		'icon-balance-scale': '&#xf24e;',
		'icon-hourglass-o': '&#xf250;',
		'icon-hourglass-1': '&#xf251;',
		'icon-hourglass-2': '&#xf252;',
		'icon-hourglass-3': '&#xf253;',
		'icon-hourglass': '&#xf254;',
		'icon-hand-grab-o': '&#xf255;',
		'icon-hand-paper-o': '&#xf256;',
		'icon-hand-scissors-o': '&#xf257;',
		'icon-hand-lizard-o': '&#xf258;',
		'icon-hand-spock-o': '&#xf259;',
		'icon-hand-pointer-o': '&#xf25a;',
		'icon-hand-peace-o': '&#xf25b;',
		'icon-trademark': '&#xf25c;',
		'icon-registered': '&#xf25d;',
		'icon-creative-commons': '&#xf25e;',
		'icon-gg': '&#xf260;',
		'icon-gg-circle': '&#xf261;',
		'icon-tripadvisor': '&#xf262;',
		'icon-odnoklassniki': '&#xf263;',
		'icon-odnoklassniki-square': '&#xf264;',
		'icon-get-pocket': '&#xf265;',
		'icon-wikipedia-w': '&#xf266;',
		'icon-safari': '&#xf267;',
		'icon-chrome': '&#xf268;',
		'icon-firefox': '&#xf269;',
		'icon-opera': '&#xf26a;',
		'icon-internet-explorer': '&#xf26b;',
		'icon-television': '&#xf26c;',
		'icon-contao': '&#xf26d;',
		'icon-500px': '&#xf26e;',
		'icon-amazon': '&#xf270;',
		'icon-calendar-plus-o': '&#xf271;',
		'icon-calendar-minus-o': '&#xf272;',
		'icon-calendar-times-o': '&#xf273;',
		'icon-calendar-check-o': '&#xf274;',
		'icon-industry': '&#xf275;',
		'icon-map-pin': '&#xf276;',
		'icon-map-signs': '&#xf277;',
		'icon-map-o': '&#xf278;',
		'icon-map': '&#xf279;',
		'icon-commenting': '&#xf27a;',
		'icon-commenting-o': '&#xf27b;',
		'icon-houzz': '&#xf27c;',
		'icon-vimeo': '&#xf27d;',
		'icon-black-tie': '&#xf27e;',
		'icon-fonticons': '&#xf280;',
		'0': 0
		},
		els = document.getElementsByTagName('*'),
		i, c, el;
	for (i = 0; ; i += 1) {
		el = els[i];
		if(!el) {
			break;
		}
		c = el.className;
		c = c.match(/icon-[^\s'"]+/);
		if (c && icons[c[0]]) {
			addIcon(el, icons[c[0]]);
		}
	}
}());
