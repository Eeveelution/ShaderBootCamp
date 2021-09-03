float u_time;

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float4 basicEffect(PS_INPUT Input) : COLOR0 {
    float4 sum = { abs(sin(u_time)), 0.0, 0.5, 1.0};

    return sum;
}

technique Uniforms {
    pass P0 {
        PixelShader = compile ps_2_0 basicEffect();
    }
}