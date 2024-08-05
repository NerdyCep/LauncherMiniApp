Shader "Custom/AlphaBlurShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0.0, 10.0)) = 1.0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BlurSize;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 offset = float2(_BlurSize / _ScreenParams.x, _BlurSize / _ScreenParams.y);

                fixed4 col = tex2D(_MainTex, uv) * 0.2;
                col += tex2D(_MainTex, uv + offset) * 0.2;
                col += tex2D(_MainTex, uv - offset) * 0.2;
                col += tex2D(_MainTex, uv + float2(offset.x, -offset.y)) * 0.2;
                col += tex2D(_MainTex, uv + float2(-offset.x, offset.y)) * 0.2;

                // Preserve the alpha channel
                col.a = tex2D(_MainTex, uv).a;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent/Diffuse"
}
