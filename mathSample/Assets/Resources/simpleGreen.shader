Shader "Custom/SimpleWireframe"
{
    Properties
    {
        _EdgeColor ("Edge Color", Color) = (1,0,0,1)
        _FillColor ("Fill Color", Color) = (1,1,1,1) // 흰색으로 채우기
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        // Tags { "RenderType"="Transparent" } // 투명한 렌더링을 위해 RenderType을 Transparent로 변경
        LOD 100

        // Blend SrcAlpha OneMinusSrcAlpha // 알파 블렌딩 활성화
        // ZWrite Off // 깊이 버퍼에 쓰기 비활성화

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 barycentric : TEXCOORD1;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 barycentric : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.barycentric = v.barycentric;
                return o;
            }

            fixed4 _EdgeColor;
            fixed4 _FillColor;

            fixed4 frag (v2f i) : SV_Target
            {
                float edgeWidth = 20.0;
                float3 dist = fwidth(i.barycentric);
                float3 edge = smoothstep(-dist * edgeWidth, dist * edgeWidth, i.barycentric);
                float mask = 1 - min(min(edge.x, edge.y), edge.z);
                return lerp(_FillColor, _EdgeColor, mask); // 흰색 채우기와 빨간색 에지를 보간

                // float edgeWidth = 10.0; // 에지의 너비
                // float3 dist = fwidth(i.barycentric);
                // float3 edge = smoothstep(-dist * edgeWidth, dist * edgeWidth, i.barycentric);
                // float mask = 1 - min(min(edge.x, edge.y), edge.z);
                // // 에지 부분은 _EdgeColor를 사용하고, 나머지 부분은 투명하게 처리
                // fixed4 col = mask * _EdgeColor + (1 - mask) * fixed4(1, 1, 1, 0);
                // return col;
            }
            ENDCG
        }
    }
}
