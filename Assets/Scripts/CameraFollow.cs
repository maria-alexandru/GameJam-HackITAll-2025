using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float Yoffset, Zoffset;
    private Transform target;
    [SerializeField] float followSpeed;
  
    private BoxCollider2D bounds;
    private Camera cam;

    private float minX, maxX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = this.GetComponent<Camera>();
        bounds = GameObject.Find("CameraBounds").GetComponent<BoxCollider2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if(bounds != null) {
            assignColiderCoordinates();
        }
    }

    void assignColiderCoordinates() { 
        Vector2 size = bounds.size;
        
        // coordonate orizontale
        minX = bounds.gameObject.transform.position.x - (size.x / 2f) + cam.orthographicSize * cam.aspect;
        maxX = bounds.gameObject.transform.position.x + (size.x /2f) - cam.orthographicSize * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // limitez coordonatele
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    void FixedUpdate() 
    {
        Vector3 targetPos = target.TransformPoint(new Vector3(0, Yoffset, Zoffset));
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.fixedDeltaTime);
    }

    // limitele fara dimensiunea camerei
    public float getMinX() 
    {
        return bounds.gameObject.transform.position.x - (bounds.size.x / 2f);
    }

    public float getMaxX() 
    {
        return bounds.gameObject.transform.position.x + (bounds.size.x /2f);
    }
}

