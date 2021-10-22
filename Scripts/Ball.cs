using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 24f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [Range(0.01f, 1f)] [SerializeField] float volume;
    [Range(0.1f, 10f)] [SerializeField] float ballSpeed = 1f;
    [SerializeField] float randomFactor = 0.2f;


    //State
    Vector2 paddleToBallVector;
    public bool hasStarted = false;

    //Cached Component References
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    public void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

        Time.timeScale = ballSpeed;
    }

    public void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }

    }


    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor), 
            Random.Range(0f, randomFactor)); 

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip, volume);
            myRigidBody2D.velocity += velocityTweak; 
        }
    }
}
