#pragma strict

function Start () {

}

function Update () {

}

var mat : Material;
function OnPostRender() {
    if (!mat) {
        Debug.LogError("Please Assign a material on the inspector");
        return;
    }
     // Draw a quad over the whole screen with the above shader
    GL.PushMatrix ();
    GL.LoadOrtho ();
    for (var i = 0; i < mat.passCount; ++i) {
        mat.SetPass (i);
        GL.Begin(GL.TRIANGLES); // Triangle
	    //GL.Color(Color(1,0,1,1));
	    GL.Vertex3(1.0,0.25,0);
	    GL.Vertex3(0.25,0.25,0);
	    GL.Vertex3(0.375,0.5,0);
	    GL.End();
	    GL.Begin( GL.LINES );
    GL.Color( Color(1,1,1,0.5) );
    GL.Vertex3( 0, 0, 0 );
    GL.Vertex3( 1, 0, 0 );
    GL.Vertex3( 0, 1, 0 );
    GL.Vertex3( 1, 1, 0 );
    GL.Color( Color(0,0,0,0.5) );
    GL.Vertex3( 0, 0, 0 );
    GL.Vertex3( 0, 1, 0 );
    GL.Vertex3( 1, 0, 0 );
    GL.Vertex3( 1, 1, 0 );
    GL.End();
    }
    GL.PopMatrix ();    
}