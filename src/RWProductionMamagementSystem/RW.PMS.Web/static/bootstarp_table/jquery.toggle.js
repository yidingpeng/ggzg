/*!
 * 由于jquery1.9以上的版本已移除 两个同名的toggle() ， 而之后的版本把第一个toggle()函数给去掉了，导致用于调用切换功能时会把元素隐藏了。
 *第一种 .toggle( handler(eventObject), handler(eventObject) [, handler(eventObject) ] ) 
 *第二种 .toggle( [duration ] [, complete ] ) 
 *官方说明 Note: This method signature was deprecated in jQuery 1.8 and removed in jQuery 1.9. jQuery also provides an animation methodnamed .toggle() that toggles the visibility of elements. Whether the animation or the event method is fired depends on the set of argumentspassed.
 */
 
$.fn.toggle = function( fn, fn2 ) {
    var args = arguments,guid = fn.guid || $.guid++,i=0,
    toggler = function( event ) {
      var lastToggle = ( $._data( this, "lastToggle" + fn.guid ) || 0 ) % i;
      $._data( this, "lastToggle" + fn.guid, lastToggle + 1 );
      event.preventDefault();
      return args[ lastToggle ].apply( this, arguments ) || false;
    };
    toggler.guid = guid;
    while ( i < args.length ) {
      args[ i++ ].guid = guid;
    }
    return this.click( toggler );
}