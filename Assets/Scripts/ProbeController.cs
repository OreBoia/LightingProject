using UnityEngine;
using UnityEngine.Rendering;

public class ProbeController : MonoBehaviour
{
    public ReflectionProbe probe;
    public KeyCode updateKey = KeyCode.R;

    void Start()
    {
        // Se non abbiamo assegnato un probe dall’Inspector, creiamo un nuovo GameObject con ReflectionProbe
        if (probe == null)
        {
            GameObject probeObj = new GameObject("Runtime Reflection Probe");
            probe = probeObj.AddComponent<ReflectionProbe>();
            probe.size = new Vector3(10f, 10f, 10f);
        }

        // Configura il probe: modalità realtime e aggiornamento manuale
        probe.mode = ReflectionProbeMode.Realtime;
        probe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
        probe.timeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces; // aggiorna una faccia per frame per ridurre l’impatto sul frame rate
        probe.cullingMask = LayerMask.GetMask("Default", "Environment"); // include solo layer rilevanti
    }

    void Update()
    {
        // Quando premi il tasto, aggiorna la cubemap
        if (Input.GetKeyDown(updateKey))
        {
            // RenderProbe restituisce un ID utile se usiamo time slicing; qui ignoriamo il valore
            probe.RenderProbe();
        }
    }
}
