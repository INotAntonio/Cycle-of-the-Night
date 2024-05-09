Shader "Skybox/GradientSkybox"
{
    Properties
    {
        _TopOTheWorld("TopOTheWorld", Color) = (0.3, 0.6, 1, 1)
        _Bottom("Bottom", Color) = (0.3,0.3,0.3, 1)
    }
        SubShader
    {
        Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
        Cull Off
        ZWrite Off
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            uniform half3 _TopOTheWorld;
            uniform half3 _Bottom;
            struct appdata_t
            {
                float4 vertex : POSITION;

                //ttps://docs.unity3d.com/2021.3/Documentation/Manual/SinglePassInstancing.html
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct v2f
            {
                float4  pos              : SV_POSITION;
                float3  posWS            : TEXCOORD0;

                // https://docs.unity3d.com/2021.3/Documentation/Manual/SinglePassInstancing.html
                UNITY_VERTEX_OUTPUT_STEREO
            };

            v2f vert(appdata_t v)
            {
                v2f OUT;

                // https://docs.unity3d.com/2021.3/Documentation/Manual/SinglePassInstancing.html
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, OUT);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

                OUT.pos = UnityObjectToClipPos(v.vertex);
                OUT.posWS = mul((float3x3)unity_ObjectToWorld, v.vertex.xyz);
                return OUT;
            }
            half4 frag(v2f IN) : SV_Target
            {
                float3 normPos = normalize(IN.posWS);
                float val = smoothstep(-0.1, 0.2, normPos.y);
                half3 col = lerp(_Bottom, _TopOTheWorld, val);
                return half4(col,1.0);
            }
            ENDCG
        }
    }
}