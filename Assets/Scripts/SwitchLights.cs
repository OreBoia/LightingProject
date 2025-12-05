using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchLights : MonoBehaviour
{
	public Texture2D[] darkLightmapDir, darkLightmapColor;
	public Texture2D[] brightLightmapDir, brightLightmapColor;
	
	private LightmapData[] darkLightmap, brightLightmap = new LightmapData[0];

	public LightProbeGroup lightProbeGroup;

    void Start()
    {
        BuildLightmapData();

        // Bind Input controlls
        InputSystem_Actions inputSystem = new InputSystem_Actions();

        inputSystem.LightsInputs.Light1.performed += OnLight1Switched;
        inputSystem.LightsInputs.Light2.performed += OnLight2Switched;
        inputSystem.LightsInputs.Light3.performed += OnLight3Switched;

        inputSystem.Enable();
    }

    private void BuildLightmapData()
    {
        List<LightmapData> dlightmap = new List<LightmapData>();

        for (int i = 0; i < darkLightmapDir.Length; i++)
        {
            LightmapData lmdata = new LightmapData();

            lmdata.lightmapDir = darkLightmapDir[i];
            lmdata.lightmapColor = darkLightmapColor[i];

            dlightmap.Add(lmdata);
        }

        darkLightmap = dlightmap.ToArray();

        List<LightmapData> blightmap = new List<LightmapData>();

        for (int i = 0; i < brightLightmapDir.Length; i++)
        {
            LightmapData lmdata = new LightmapData();

            lmdata.lightmapDir = brightLightmapDir[i];
            lmdata.lightmapColor = brightLightmapColor[i];

            blightmap.Add(lmdata);
        }

        brightLightmap = blightmap.ToArray();
    }

    public Light[] lights;

    
	private void OnLight1Switched(InputAction.CallbackContext ctx)
	{
        if(darkLightmap.Length == 0 || brightLightmap.Length == 0)
            BuildLightmapData();
		LightmapSettings.lightmaps = darkLightmap;
	}

    [ContextMenu("Switch Lights1")]
    public void SwitchToBrightLightmap()
    {
        if (darkLightmap == null || brightLightmap == null)
            BuildLightmapData();
        LightmapSettings.lightmaps = brightLightmap;
        
    }

	private void OnLight2Switched(InputAction.CallbackContext ctx)
	{
        if(darkLightmap.Length == 0 || brightLightmap.Length == 0)
            BuildLightmapData();
		LightmapSettings.lightmaps = brightLightmap;
	}

    [ContextMenu("Switch Lights2")]
    public void SwitchToDarkLightmap()
    {
        if (darkLightmap == null || brightLightmap == null)
            BuildLightmapData();
        LightmapSettings.lightmaps = darkLightmap;
    }
	
	private void OnLight3Switched(InputAction.CallbackContext ctx)
	{
		lights[2].enabled = !lights[2].enabled;
	}
}