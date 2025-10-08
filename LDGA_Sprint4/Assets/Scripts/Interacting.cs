using UnityEngine;

public class Interacting : MonoBehaviour
{
    public float interactRange = 3f;
    public Color highlightColor = Color.red;
    private GameObject currentTarget;
    private Color originalColor;
    private Renderer targetRenderer;

    public AudioClip clip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactRange))
        {
            GameObject hitObject = hit.collider.gameObject;
            //Debug.Log(hitObject.name);
            if (hitObject.CompareTag("deletable"))
            {
                if (currentTarget != hitObject)
                {
                    ClearHighlight();
                    currentTarget = hitObject;
                    targetRenderer = currentTarget.GetComponent<Renderer>();
                    if (targetRenderer)
                    {
                        originalColor = targetRenderer.material.color;
                        targetRenderer.material.color = highlightColor;
                    }
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(currentTarget.name + " deleted!");
                    if (clip != null && audioSource != null)
                        audioSource.PlayOneShot(clip);

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
            targetRenderer.material.color = originalColor;
        }

        currentTarget = null;
        targetRenderer = null;
    }
}
