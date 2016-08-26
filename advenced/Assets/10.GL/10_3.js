#pragma strict

function Start () {

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

function OnPostRender() {
    CreateLineMaterial();
    // set the current material
    lineMaterial.SetPass( 0 );
    GL.PushMatrix();
    
    GL.LoadOrtho();
    
    GL.Begin( GL.LINES );
    GL.Color( Color(1,0,0,0.5) );
    
    GL.Vertex3( 0.2, 0.2, 0 );
    GL.Vertex3( 0.3, 0.3, 0 );
    
    GL.Vertex3( 0.3, 0.3, 0 );
    GL.Vertex3( 0.3, 0.2, 0 );
    
    GL.Vertex3( 0.3, 0.2, 0 );
    GL.Vertex3( 0.2, 0.2, 0 );
    
    
    GL.Color( Color(1,1,0,0.5) );
    GL.Vertex3(0.50,0.25,0);
	GL.Vertex3(0.25,0.50,0);
	
	GL.Vertex3(0.25,0.50,0);
	GL.Vertex3(0.25,0.25,0);
	
	GL.Vertex3(0.25,0.25,0);
	GL.Vertex3(0.5,0.25,0);
	    
    GL.End();
    
    GL.PopMatrix();
}