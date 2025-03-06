Shader "Custom/VHSShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ScanlineIntensity ("Scanline Intensity", Range(0,1)) = 0.5
        _NoiseIntensity ("Noise Intensity", Range(0,1)) = 0.5
        _TimeSpeed ("Noise Speed", Range(0,1)) = 0.1 // Reducido para hacerlo más lento
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _ScanlineIntensity;
            float _NoiseIntensity;
            float _TimeSpeed;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);

                // Scanlines más lentas
                float scanline = sin((i.uv.y + (_Time.y * _TimeSpeed * 0.3)) * _ScreenParams.y * 2) * _ScanlineIntensity;
                col.rgb -= scanline;

                // Ruido en movimiento más lento
                float noise = (frac(sin(dot(i.uv.xy + (_Time.y * _TimeSpeed * 0.2), float2(12.9898,78.233))) * 43758.5453) - 0.5) * _NoiseIntensity;
                col.rgb += noise;

                return col;
            }
            ENDCG
        }
    }
}
