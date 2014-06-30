// SpriteBatch expects that default texture parameter will have name 'Texture'
Texture2D<float4> Texture : register(t0);

// SpriteBatch expects that default texture sampler parameter will have name 'TextureSampler'
sampler TextureSampler : register(s0);

// SpriteBatch expects that default vertex transform parameter will have name 'MatrixTransform'
row_major float4x4 MatrixTransform;

void SpriteVertexShader(inout float4 color    : COLOR0,
	inout float2 texCoord : TEXCOORD0,
	inout float4 position : SV_Position)
{
	position = mul(position, MatrixTransform);
}

float3 Rgb2Cmy(float3 rgb){
	// http://www.easyrgb.com/index.php?X=MATH&H=11#text11
	return float3(1.0 - rgb.x, 1.0 - rgb.y, 1.0 - rgb.z);
}

float4 Cmy2Cmyk(float3 cmy){
	// http://www.easyrgb.com/index.php?X=MATH&H=13#text13
	float k = 1.0;
	float c = cmy.x;
	float m = cmy.y;
	float y = cmy.z;
	if (c < k) k = c;
	if (m < k) k = m;
	if (y < k) k = y;
	if (k >= 1.0){
		c = 0.0;
		m = 0.0;
		y = 0.0;
	}
	else
	{
		c = (c - k) / (1.0 - k);
		m = (m - k) / (1.0 - k);
		y = (y - k) / (1.0 - k);
	}
	return float4(c, m, y, k);
}

float3 Cmyk2Cmy(float4 cmyk){
	// http://www.easyrgb.com/index.php?X=MATH&H=14#text14
	float k = cmyk.w;
	float c = (cmyk.x * (1.0 - k) + k);
	float m = (cmyk.y * (1.0 - k) + k);
	float y = (cmyk.z * (1.0 - k) + k);
	return float3(c, m, y);
}

float3 Cmy2Rgb(float3 cmy){
	// http://www.easyrgb.com/index.php?X=MATH&H=12#text12
	return float3(1.0 - cmy.x, 1.0 - cmy.y, 1.0 - cmy.z);
}

float4 SpritePixelShader(float4 color : COLOR0,
	float2 texCoord : TEXCOORD0) : SV_Target0
{
	float4 pixel = Texture.Sample(TextureSampler, texCoord);
	
	// rgb to cmyk
	float c = 1.0 - pixel.x;
	float m = 1.0 - pixel.y;
	float y = 1.0 - pixel.z;
	//float k = min(c, min(m, y));
	float k = min(c, m);
	if (y < k){
		k = y;
	}
	if (k > 0.0){
		c -= k;
		m -= k;
		y -= k;
	}
	float min1 = min(c, m);
	if (y < min1){ 
		min1 = y; }
	if (min1 + k > 1.0)
	{
		min1 = 1.0 - k;
	}
	c -= min1;
	m -= min1;
	y -= min1;
	k += min1;
	//cmyk to rgb
	float r = 0.0;
	if (c + k < 1.0)
	{
		r = 1 - (c + k);
	}
	float g = 0.0;
	if (m + k < 1.0)
	{
		g = 1 - (m + k);
	}
	float b = 0.0;
	if (y + k < 1.0)
	{
		b = 1 - (y + k);
	}
	float3 w = 1- float3(c, m, y) -k;
		return float4(w, 1);
	return float4(r, g, b, 1);
	//float3 a = Rgb2Cmy(pixel.rgb);
	//float4 b = Cmy2Cmyk(a);
	//float3 c = Cmyk2Cmy(b);
	//float3 d = Cmy2Rgb(c);
	//return float4(d, pixel.a);
}

technique SpriteBatch
{
	pass
	{
		VertexShader = compile vs_2_0 SpriteVertexShader();
		PixelShader = compile ps_2_0 SpritePixelShader();
	}
}
