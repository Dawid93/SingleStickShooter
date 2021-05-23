using UnityEngine;

public class EnemyColorRandomizer
{
	public static Color GetRandomColor()
	{
		var hue = Random.value;
		var saturation = 0.6f;
		var value = 0.6f;
		return Color.HSVToRGB(hue, saturation, value);
	}
}