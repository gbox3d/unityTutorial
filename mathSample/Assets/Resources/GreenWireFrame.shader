Shader "Custom/GreenWireframeUsingBarycentric" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 barycentric : TEXCOORD0; // Barycentric 좌표 추가
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float3 barycentric : TEXCOORD0;
            };

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.barycentric = v.barycentric;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // 에지 근처인지 판단하고 녹색으로 색칠
                float edgeWidth = 0.01; // 에지 폭 조정
                float isEdge = step(edgeWidth, i.barycentric.x) * step(edgeWidth, i.barycentric.y) * step(edgeWidth, i.barycentric.z);
                return lerp(fixed4(0,1,0,1), fixed4(0,0,0,1), isEdge); // 배경은 검은색
            }
            ENDCG
        }
    }
}
