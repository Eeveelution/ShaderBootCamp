float u_time;

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float plot(float2 st, float pct){
    return  smoothstep( pct-0.02, pct, st.y) -
              smoothstep( pct, pct+0.02, st.y);
}

float4 basicEffect(PS_INPUT Input) : COLOR0 {
    //when converting from glsl to hlsl, remember you will sometimes have to flip the y axis because hlsl just works differently idk
    float2 st = {Input.TexCoord.x, Input.TexCoord.y};
    //this is the math function for the line
    float y = 1.0 - pow(abs(st.x) , 0.5);

    float3 color = float3(y, y, y);

    //Plotting the Line
    float pct = plot(st, y);
    color = (1.0 - pct) * color + pct * float3(0.0, 1.0, 0.0);

    return float4(color, 1.0);
}

technique Uniforms {
    pass P0 {
        PixelShader = compile ps_2_0 basicEffect();
    }
}