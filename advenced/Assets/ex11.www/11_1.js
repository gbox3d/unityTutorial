#pragma strict

var url = "http://1-ps.googleusercontent.com/x/s.html5rocks-hrd.appspot.com/www.html5rocks.com/static/images/site_title.png.pagespeed.ce.zzYa4xGl2w.png";
	
function Start () {
     // Start a download of the given URL
    var www : WWW = new WWW (url);

    // Wait for download to complete
    yield www;

    // assign texture
    GetComponent.<Renderer>().material.mainTexture = www.texture;
}

function Update () {

}