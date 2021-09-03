float u_time;

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float4 basicEffect(PS_INPUT Input) : COLOR0 {
    float4 sum = { Input.TexCoord.x, Input.TexCoord.y, 0.0, 1.0 };

    return sum;
}

technique Uniforms {
    pass P0 {
        PixelShader = compile ps_2_0 basicEffect();
    }
}