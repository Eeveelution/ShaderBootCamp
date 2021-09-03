sampler samplerState;

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float4 basicEffect(PS_INPUT Input) : COLOR0 {
    float4 sum = tex2D(samplerState, Input.TexCoord);

    sum.r = 0;
    sum.g = 0;
    sum.b = 123;

    return sum;
}

technique BasicEffect {
    pass P0 {
        PixelShader = compile ps_2_0 basicEffect();
    }
}