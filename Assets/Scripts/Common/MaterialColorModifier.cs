using UnityEngine;

public class MaterialColorModifier : MonoBehaviour
{
	private int colorId;
	private MaterialPropertyBlock materialBlock;
	private Renderer objectRenderer;
	
	public void Setup(Renderer objectRenderer)
	{
		this.objectRenderer = objectRenderer;
		materialBlock = new MaterialPropertyBlock();
		colorId = Shader.PropertyToID("_BaseColor");
	}

	public void SetColor(Color color)
	{
		objectRenderer.GetPropertyBlock(materialBlock);
		materialBlock.SetColor(colorId, color);
		objectRenderer.SetPropertyBlock(materialBlock);
	}
}