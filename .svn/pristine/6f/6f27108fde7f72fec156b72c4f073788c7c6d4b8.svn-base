
function g(o){
return document.getElementById(o);
} 
function HoverLi(n){ 
for(var i=1;i<=5;i++)
{
   g('tb_'+i).className='normaltab';g('tbc_0'+i).className='undis';
}
g('tbc_0'+n).className='dis';g('tb_'+n).className='hovertab'; 
} 

function publicTab(name,cursel,n,css1,css2){
 for(i=1;i<=n;i++){
  var menu=document.getElementById(name+"_"+i);
  var con=document.getElementById("con_"+name+"_"+i);
  menu.className=i==cursel?css1:css2;
  con.style.display=i==cursel?"block":"none";
 }
} 
