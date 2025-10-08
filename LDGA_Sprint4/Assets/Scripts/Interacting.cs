using UnityEngine;

public class Interacting : MonoBehaviour
{
    public float interactRange = 3f;
    public Color highlightColor = Color.grey;
    private GameObject currentTarget;
    private Color originalColor;
    private Renderer targetRenderer;
    public Transform tran;

    public AudioClip clip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        if (Physics.Raycast(tran.position, tran.forward, out RaycastHit hit, interactRange))
        {
            GameObject hitObject = hit.collider.gameObject;
            //Debug.Log(hitObject.name);
            if (hitObject.CompareTag("Interactable") || hitObject.CompareTag("deletable")) //including deletable just in case it's being used. Should be depreciated though.
            {
                if (currentTarget != hitObject)
                {
                    ClearHighlight();
                    currentTarget = hitObject;
                    targetRenderer = currentTarget.GetComponent<Renderer>();
                    if (targetRenderer)
                    {
                        originalColor = targetRenderer.material.GetColor("_EMISSION_COLOR");
                        targetRenderer.material.SetColor("_EMISSION_COLOR", highlightColor);

                    }
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(currentTarget.name + " deleted!");
                    if (clip != null && audioSource != null)
                        audioSource.PlayOneShot(clip, 0.5f);

                    TextTrigger textTrigger = currentTarget.GetComponent<TextTrigger>();
                    if (textTrigger == null)
                    {
                        Destroy(currentTarget);
                        currentTarget = null;
                    }
                    
                    textTrigger.TryLoad();
                    
                }
            }
            else
            {
                ClearHighlight();
            }
        }
        else
        {
            ClearHighlight();
        }
    }

    void ClearHighlight()
    {
        if (currentTarget && targetRenderer)
        {
            targetRenderer.material.SetColor("_EMISSION_COLOR", originalColor);
        }

        currentTarget = null;
        targetRenderer = null;
    }
}
