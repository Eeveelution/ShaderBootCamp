float2 mousePos;
float2 windowSize;

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float4 basicEffect(PS_INPUT Input) : COLOR0 {
    float xPos = abs(Input.TexCoord.x * (mousePos.x / windowSize.x));
    float yPos = abs(Input.TexCoord.y * (mousePos.y / windowSize.y));

    float4 sum = { xPos, yPos, 0.0, 1.0 };

    return sum;
}

technique Uniforms {
    pass P0 {
        PixelShader = compile ps_2_0 basicEffect();
    }
}