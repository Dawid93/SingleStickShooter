using UnityEngine;

public class MaterialColorModifier : MonoBehaviour
{
	private int colorId;
	private MaterialPropertyBlock materialBlock;
	private Renderer renderer;
	
	public void Setup(Renderer renderer)
	{
		this.renderer = renderer;
		materialBlock = new MaterialPropertyBlock();
		colorId = Shader.PropertyToID("_BaseColor");
	}

	public void SetColor(Color color)
	{
		renderer.GetPropertyBlock(materialBlock);
		materialBlock.SetColor(colorId, color);
		renderer.SetPropertyBlock(materialBlock);
	}
}