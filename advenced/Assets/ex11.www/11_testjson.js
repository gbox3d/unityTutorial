#pragma strict

var parsed_name : String = "connecting....";

var download_text : String = "connecting....";

//class
/*
public class CTest extends System.Object {
	var name;
	var text;
	function test () {
	}
};
*/
function Start () {

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
        download_text = download.text;
        
        
       var parsed = JSONParse.JSONParse(download.text);
       
        
       Debug.Log(parsed["name"]);
       parsed_name = parsed["name"];
       
       //Debug.Log(parseObject["name"]);
        
        
    }
    

}


function OnGUI() {
	

	GUI.Label(Rect(100,100,120,30),parsed_name);
	GUI.Label(Rect(100,130,120,300),download_text);

}




