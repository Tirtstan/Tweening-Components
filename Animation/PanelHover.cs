using UnityEngine;

public class PanelHover : MonoBehaviour
{
    [Header("Pacing")]
    [SerializeField]
    [Range(0, 5f)]
    private float speed = 1f;

    [SerializeField]
    [Range(0, 0.5f)]
    private float amplitude = 0.05f;

    [SerializeField]
    private bool unscaledTime = true;
    private float originalY;

    private void Awake()
    {
        originalY = transform.localPosition.y;
    }

    private void Update()
    {
        float y = originalY + Mathf.Sin((unscaledTime ? Time.unscaledTime : Time.time) * speed) * amplitude;
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
}
