#pragma strict

function Start () {

	CreateLineMaterial();
}

function Update () {

}

static var lineMaterial : Material;

static function CreateLineMaterial() {
    if( !lineMaterial ) {
        lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
            "SubShader { Pass { " +
            "    Blend SrcAlpha OneMinusSrcAlpha " +
            "    ZWrite Off Cull Off Fog { Mode Off } " +
            "    BindChannels {" +
            "      Bind \"vertex\", vertex Bind \"color\", color }" +
            "} } }" );
        lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
    }
}

//var mat : Material;
function OnPostRender() {
    
    GL.PushMatrix();
    
    GL.LoadOrtho();
    for (var i = 0; i < lineMaterial.passCount; ++i) {
    	lineMaterial.SetPass(i);
	    
	    GL.Begin(GL.TRIANGLES); // Triangle
	    GL.Color(Color(1,1,1,1));
	    GL.Vertex3(0.50,0.25,0);
	    GL.Vertex3(0.25,0.25,0);
	    GL.Vertex3(0.375,0.5,0);
	    GL.End();
	    
	    GL.Begin(GL.QUADS); // Quad
	    GL.Color(Color(0.5,0.5,0.5,1));
	    GL.Vertex3(0.5,0.5,0);
	    GL.Vertex3(0.5,0.75,0);
	    GL.Vertex3(0.75,0.75,0);
	    GL.Vertex3(0.75,0.5,0);
	    GL.End();
	    
	    GL.Begin(GL.LINES); // Line
	    GL.Color(Color(1,0.5,0,1));
	    GL.Vertex3(0,0,0);
	    GL.Vertex3(0.75,0.75,0);
	    GL.End();
	    
    }
    
    GL.PopMatrix();
}