Shader "Custom/keyItem"
{

	Properties
	{
		_alphaFloat ("alphaFloat", Float) = 1.5
	}
	SubShader 
	{		
		Tags { "Queue"="Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard alpha:fade
		#pragma target 3.0

		//求めた内積にFloatをかけて完全な透明にしたり輪郭を濃くしたりしてみる。
		float _alphaFloat;

		//参考:https://docs.unity3d.com/ja/current/Manual/SL-SurfaceShaderExamples.html	
		struct Input
		{
			float3 worldNormal;
      		float3 viewDir;
		};
		
		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = fixed4(1, 1, 1, 1);
			//a*b=0 ⇔ a⊥b　なので垂直なら透明に近づく。
			//ドット積の関数を用いる。
			float alpha = 1 - (abs(dot(IN.viewDir, IN.worldNormal)));
			
     			o.Alpha = alpha*_alphaFloat;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
			