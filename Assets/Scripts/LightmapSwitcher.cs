using UnityEngine;

public class LightmapSwitcher : MonoBehaviour
{
    // Popolati in Editor (vedi script di prima o a mano)
    public LightmapSO lightmapSO;

    public enum LightmapMode
    {
        Day,
        Night
    }

    public LightmapMode startMode = LightmapMode.Day;

    void Start()
    {
        // ApplyLightmaps(startMode);
    }

    [ContextMenu("Applica lightmaps")]
    public void ApplyLightmaps()
    {
        switch (startMode)
        {
            case LightmapMode.Day:
                if (lightmapSO.dayLightmaps != null && lightmapSO.dayLightmaps.Count > 0)
                {
                    LightmapData[] daylm = new LightmapData[lightmapSO.dayLightmaps.Count];
                    for (int i = 0; i < lightmapSO.dayLightmaps.Count; i++)
                    {
                        var lmData = lightmapSO.dayLightmaps[i];
                        LightmapData lm = new LightmapData
                        {
                            lightmapColor = lmData.lightmapColor,
                            lightmapDir = lmData.lightmapDir,
                            shadowMask = lmData.shadowMask
                        };
                        // Here you would typically assign lm to LightmapSettings.lightmaps array
                        daylm[i] = lm;
                    }
                    LightmapSettings.lightmaps = daylm;
                }
                    // LightmapSettings.lightmaps = lightmapSO.dayLightmaps;

                else
                    Debug.LogWarning("Day lightmaps non impostate!");
                break;

            case LightmapMode.Night:
                if (lightmapSO.nightLightmaps != null && lightmapSO.nightLightmaps.Count > 0)
                {
                    LightmapData[] nightlm = new LightmapData[lightmapSO.nightLightmaps.Count];
                    for (int i = 0; i < lightmapSO.nightLightmaps.Count; i++)
                    {
                        var lmData = lightmapSO.nightLightmaps[i];
                        LightmapData lm = new LightmapData
                        {
                            lightmapColor = lmData.lightmapColor,
                            lightmapDir = lmData.lightmapDir,
                            shadowMask = lmData.shadowMask
                        };
                        nightlm[i] = lm;
                    }
                    LightmapSettings.lightmaps = nightlm;
                }
                else
                    Debug.LogWarning("Night lightmaps non impostate!");
                break;
        }
    }
}

