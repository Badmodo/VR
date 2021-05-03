Shader "Unlit/ObraDinnShader"
{
    Properties
    {
        _LightColor("Light Color", Color) = (0.8,0.8,0.8,1)
        _DarkColor("Dark Color", Color) = (0.2,0.2,0.2,1)
        _DotSize("Dot Size", Range(0,0.5)) = 0.25
        _Strength("Strength", Range(0,1)) = 0.5
        _Offset("Offset", Range(0, 1)) = 0.5
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Transparent"
        }

        GrabPass{}

        Pass
        {
            //Cull Off
            //ZWrite Off
            //ZTest Always
            //Blend One One
            //Blend DstColor Zero

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _DotSize;
            float _Strength;
            float _Offset;

            float calc(float2 val)
            {
                //return frac(sin(dot(val, float2(825.73452f, 33152.6829f) * 56324.47263f)));
                return cos(val.x * _DotSize) * cos(val.y * _DotSize) *_Strength;
            }

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 uvgrab : TEXCOORD1;
                float3 normal : TEXCOORD2;
                float3 wPos : TEXCOORD3;
            };


            sampler2D _MainTex;
            sampler2D _GrabTexture;
            float4 _MainTex_TexelSize, _MainTex_ST;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                fixed4 vertexUV = o.vertex;

                #if UNITY_UV_STARTS_AT_TOP
                vertexUV.y *= -sign(_MainTex_TexelSize.y);
                #endif

                o.uvgrab.xy = (float2(vertexUV.x, vertexUV.y) + vertexUV.w) * 0.5;
                o.uvgrab.zw = vertexUV.zw;

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.wPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            float4 _LightColor;
            float4 _DarkColor;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 V = normalize(_WorldSpaceCameraPos - i.wPos);
                fixed3 N = i.normal;
                fixed fresnel = dot(V, N);
                // sample the texture
                i.uvgrab.x = i.uvgrab.x * cos(i.uvgrab.x * fresnel);
                i.uvgrab.y = i.uvgrab.y * cos(i.uvgrab.y * fresnel);
                fixed4 col = tex2Dproj(_GrabTexture, i.uvgrab);
                return col;

                //fixed colAverage = (col.r + col.g + col.b) / 3;

                //return fresnel;
                //return colAverage - _Offset > calc(i.vertex) ? _LightColor : _DarkColor;
            }
            ENDCG
        }
    }
}
