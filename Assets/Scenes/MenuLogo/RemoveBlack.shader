// RemoveBlack.shader
Shader "Custom/RemoveBlack" {
    Properties {
        _MainTex ("Texture", 2D) = "blackgo" {}
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 color = tex2D(_MainTex, IN.uv_MainTex);

            // If the pixel is black, make it transparent
            if (color.rgb == float3(0, 0, 0)) {
                clip(-1);
            }

            o.Albedo = color.rgb;
            o.Alpha = color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
