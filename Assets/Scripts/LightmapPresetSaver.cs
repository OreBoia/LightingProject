#if UNITY_EDITOR
using UnityEngine;

public class LightmapPresetSaver : MonoBehaviour
{
    public LightmapSO lightmapSO;

    [ContextMenu("Salva preset Giorno")]
    void SaveDay()
    {
        foreach (var lm in LightmapSettings.lightmaps)
        {
            Debug.Log($"Lightmap Color: {lm.lightmapColor}, Dir: {lm.lightmapDir}, ShadowMask: {lm.shadowMask}");

            var serializableLM = new SerializableLightmapData
            {
                lightmapColor = lm.lightmapColor,
                lightmapDir = lm.lightmapDir,
                shadowMask = lm.shadowMask
            };
            lightmapSO.dayLightmaps.Add(serializableLM);
        }
        Debug.Log($"Salvate {lightmapSO.dayLightmaps.Count} lightmap per GIORNO");
    }

    [ContextMenu("Salva preset Notte")]
    void SaveNight()
    {
        foreach (var lm in LightmapSettings.lightmaps)
        {
            Debug.Log($"Lightmap Color: {lm.lightmapColor}, Dir: {lm.lightmapDir}, ShadowMask: {lm.shadowMask}");

            var serializableLM = new SerializableLightmapData
            {
                lightmapColor = lm.lightmapColor,
                lightmapDir = lm.lightmapDir,
                shadowMask = lm.shadowMask
            };
            lightmapSO.nightLightmaps.Add(serializableLM);
        }
        Debug.Log($"Salvate {lightmapSO.nightLightmaps.Count} lightmap per NOTTE");
    }
}
#endif
