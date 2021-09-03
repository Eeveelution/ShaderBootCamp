

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float plot(float2 st){
    return smoothstep(0.02, 0.0, abs(st.x - st.y));
}

float4 basicEffect(PS_INPUT Input) : COLOR0 {
    float2 st = {Input.TexCoord.x, 1.0 - Input.TexCoord.y};

    float y = st.x;

    float3 color = float3(y, y, y);

    //Plotting the Line
    float pct = plot(st);
    color = (1.0 - pct) * color + pct * float3(0.0, 1.0, 0.0);

    return float4(color, 1.0);
}

technique Uniforms {
    pass P0 {
        PixelShader = compile ps_2_0 basicEffect();
    }
}