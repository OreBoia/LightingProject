using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableLightmapData
{
    public Texture2D lightmapColor;
    public Texture2D lightmapDir;
    public Texture2D shadowMask;
}

[CreateAssetMenu(fileName = "LightmapSO", menuName = "ScriptableObjects/LightmapSO", order = 1)]
public class LightmapSO : ScriptableObject
{
    public List<SerializableLightmapData> dayLightmaps;
    public List<SerializableLightmapData> nightLightmaps;
}
