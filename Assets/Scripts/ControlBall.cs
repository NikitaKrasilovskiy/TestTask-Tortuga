using UnityEngine;

public class ControlBall : MonoBehaviour
{
    private static event OnSwipeInput SwipeEvent;
    private delegate void OnSwipeInput(Vector3 direction);
    private Vector3 tapPosition, swipeDelta;

    private float deadZone = 80;

    private bool isSwiping, isMobile, IsGround;
    private Rigidbody rb;
    private AudioSource audioSource;
    private void Awake()
    { rb = GetComponent<Rigidbody>(); }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isMobile = Application.isMobilePlatform;
        SwipeEvent += Move;
    }
    void Update()
    {
        Jump();

        if (!isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            { ResetSwipe(); }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isSwiping = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                { ResetSwipe(); }
            }
        }

        CheckSwipe();
    }
    public void Jump()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit rh;

        if (Physics.Raycast(ray, out rh, 0.6f))
        { IsGround = true; }
        else
        { IsGround = false; }

        if (Input.touchCount > 0 && IsGround)
        {
            rb.AddRelativeForce(Vector3.up * 150);
            rb.AddRelativeForce(Vector3.right * -15);
            audioSource.Play();
        }
    }
    private void Move(Vector3 direction)
    {
        if (this != null)
        {
            if (this.GetComponent<Rigidbody>())
            { rb.AddRelativeForce(direction * 500); }
        }
    }
    private void CheckSwipe()
    {
        swipeDelta = Vector3.zero;
        if (isSwiping)
        {
            if (!isMobile && Input.GetMouseButton(0))
            { swipeDelta = (Vector3)Input.mousePosition - tapPosition; }
            else if (Input.touchCount > 0)
            { swipeDelta = (Vector3)Input.GetTouch(0).position - tapPosition; }
        }

        if (swipeDelta.magnitude > deadZone)
        {
            if (SwipeEvent != null)
            {
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                { SwipeEvent(swipeDelta.x > 0 ? Vector3.forward : Vector3.back); }
                //else { SwipeEvent(swipeDelta.y > 0 ? Vector3.up : Vector3.down); }
            }

            ResetSwipe();
        }
    }
    private void ResetSwipe()
    {
        isSwiping = false;
        tapPosition = Vector3.zero;
        swipeDelta = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        { Destroy(this.gameObject); }
    }
}