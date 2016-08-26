#pragma strict

function Start () {

//http://sf2009.web-bi.net/work/api/json_2.php?name=lee

	var form:WWWForm = new WWWForm();
    form.AddField( "name", "lee" );
    
    var download = new WWW( "http://sf2009.web-bi.net/work/server/post_test.php", form );

    // Wait until the download is done
    yield download;

    if(download.error) {
        print( "Error downloading: " + download.error );
        return;
    } else {
        // show the highscores
        Debug.Log(download.text);
    }
    
    
}

function Update () {

}