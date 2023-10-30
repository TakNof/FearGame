using UnityEngine;

public class  PlayerMovement : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody body;

    private BoxCollider boxCollider;
    private float lastJumpTime = 0f;
    private string currentMovementAxis = "x";


    private void Awake(){
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update(){
        this.Movement();
    }

    private void Movement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * speed, body.velocity.y, body.velocity.z);
        if(horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;
        }else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Input.GetKey(KeyCode.Space) && this.isGrounded()) {
            this.Jump();
        }
        Debug.Log(this.isGrounded());
    }

    private void Jump() {
        float time = Time.time;
        if(time - this.lastJumpTime > 2 || this.lastJumpTime == 0f) {
            body.velocity = new Vector3(body.velocity.x, speed);

            lastJumpTime = time;
        }       
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector3.down, 0.1f, groundLayer);
        //RaycastHit raycastHit = Physics.BoxCast(boxCollider.center, boxCollider.size, Vector3.down);
        //return Physics.BoxCast(boxCollider.center, boxCollider.size, Vector3.down);
        return raycastHit.collider != null;
    }

    private bool hittingWall() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector3(transform.localScale.x, 0, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public void rotatePlayer(){
        transform.Rotate(0f, 90f, 0f);
    }

    public string getCurrentMovementAxis() {
        return currentMovementAxis;
    }

    public void setCurrentMovementAxis(string axis) {
        currentMovementAxis = axis;
    }
}
