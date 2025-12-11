using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    // Remove movementMachine field - you don't need it!

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = .2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("=== GROUND CHECK DIAGNOSTIC ===");
            Debug.Log($"GroundCheck exists: {groundCheck != null}");
            Debug.Log($"GroundCheck position: {groundCheck?.position}");
            Debug.Log($"Ground Layer value: {groundLayer.value}");
            Debug.Log($"Ground Check Radius: {groundCheckRadius}");

            // Check ALL colliders in the sphere (ignoring layer)
            Collider[] allHits = Physics.OverlapSphere(groundCheck.position, groundCheckRadius);
            Debug.Log($"Total colliders found (any layer): {allHits.Length}");
            foreach (Collider hit in allHits)
            {
                int layer = hit.gameObject.layer;
                string layerName = LayerMask.LayerToName(layer);
                Debug.Log($"  - Found: {hit.gameObject.name} on layer {layer} ({layerName})");
            }

            // Check with layer mask
            Collider[] layerHits = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
            Debug.Log($"Colliders on Ground layer: {layerHits.Length}");

            // Test the actual IsGrounded call
            bool result = isGrounded();
            Debug.Log($"IsGrounded() result: {result}");
            Debug.Log("==============================");
        }
    }
    public bool isGrounded()
    {
        if (groundCheck == null) return false;

        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

}