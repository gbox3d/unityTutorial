// SimpleTextureShader.shader
Shader "Custom/SimpleTextureShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {} // 텍스처 속성 정의
    }
    SubShader {
        // 태그 섹션은 렌더링 순서나 렌더링 방식을 제어합니다.
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            // 버텍스 쉐이더와 프래그먼트 쉐이더 사용 선언
            #pragma vertex vert
            #pragma fragment frag
            
            // 텍스처와 텍스처 좌표를 위한 유니폼 변수 선언
            uniform sampler2D _MainTex;
            struct appdata {
                float4 vertex : POSITION; // 버텍스 위치
                float2 uv : TEXCOORD0; // UV 좌표
            };
            struct v2f {
                float2 uv : TEXCOORD0; // 프래그먼트 쉐이더로 전달될 UV 좌표
                float4 vertex : SV_POSITION; // 스크린 상의 버텍스 위치
            };

            // 버텍스 쉐이더
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // 오브젝트 공간에서 클립 공간으로 변환
                o.uv = v.uv; // UV 좌표 전달
                return o;
            }
            
            // 프래그먼트 쉐이더
            fixed4 frag (v2f i) : SV_Target {
                // 텍스처에서 UV 좌표에 해당하는 색상을 가져와서 픽셀 색상으로 설정
                fixed4 col = tex2D(_MainTex, i.uv);
                
                return col;
            }
            ENDCG
        }
    }
}
