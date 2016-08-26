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
    
    var mMat:Matrix4x4 = Matrix4x4.TRS(Vector3(0.5,0,0),Quaternion.identity,Vector3(1,1,1));
    var mMat2:Matrix4x4 = Matrix4x4.TRS(Vector3(-0.5,0,0),Quaternion.Euler(0,0,45),Vector3(1,1,1));
    var prjMat:Matrix4x4 = this.GetComponent.<Camera>().projectionMatrix;
    
    GL.PushMatrix();
    
    //GL.modelview = mMat;
    GL.LoadProjectionMatrix(prjMat);
    //GL.LoadOrtho();
    
    GL.modelview = this.GetComponent.<Camera>().worldToCameraMatrix * mMat;
    GL.Begin(GL.TRIANGLES); // Triangle
    GL.Color(Color(1,1,0,1));
    GL.Vertex3(0,0,0);
    GL.Vertex3(0.25,0.25,0);
    GL.Vertex3(0.5,0,0);
    GL.End();
    
    GL.modelview = this.GetComponent.<Camera>().worldToCameraMatrix * mMat2;
    GL.Begin(GL.TRIANGLES); // Triangle
    GL.Color(Color(0,1,0,1));
    GL.Vertex3(0,0,0);
    GL.Vertex3(0.25,0.25,0);
    GL.Vertex3(0.5,0,0);
    GL.End();
    
    GL.modelview = this.GetComponent.<Camera>().worldToCameraMatrix;
    GL.Begin(GL.TRIANGLES); // Triangle
    GL.Color(Color(1,0,0,1));
    GL.Vertex3(0,0,0);
    GL.Vertex3(0.25,0.25,0);
    GL.Vertex3(0.5,0,0);
    GL.End();
    
    GL.PopMatrix();
}