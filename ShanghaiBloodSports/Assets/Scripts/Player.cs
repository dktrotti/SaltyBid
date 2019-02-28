using Assets.Scripts.Moves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private State state = State.NEUTRAL;
    private bool grounded = false;
    private MockInputBuffer inputBuffer;

    private Move currentMove;
    public Move CurrentMove {
        get {
            return currentMove;
        }
        set {
            if (currentMove == null ^ value == null)
            {
                currentMove = value;
            }
            else
            {
                Debug.LogError($"Unexpected change to CurrentMove " +
                    $"OldVal: {currentMove} NewVal: {value}");
            }
        }
    }
    public Animator Animator { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        inputBuffer = GetComponent<MockInputBuffer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grounded)
        {
            state = State.MIDAIR;
        }
        else if (inputBuffer.Peek(KeyCode.A))
        {
            state = State.BACK_WALK;
            rb.velocity = new Vector3(-1 * speed, rb.velocity.y, 0);
        }
        else if (inputBuffer.Peek(KeyCode.D))
        {
            state = State.FORWARD_WALK;
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        else
        {
            state = State.NEUTRAL;
        }

        UpdateAnimator();

        if (inputBuffer.Match(KeyCode.Space) && state != State.MIDAIR)
        {
            rb.AddForce(new Vector3(0, 300, 0));
        }

        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("neutral"))
        {
            if (inputBuffer.Match(KeyCode.J))
            {
                Punch.StartAnimation(Animator);
            }

            if (inputBuffer.Match(KeyCode.K))
            {
                LowKick.StartAnimation(Animator);
            }

            if (inputBuffer.Match(KeyCode.I))
            {
                HighKick.StartAnimation(Animator);
            }

            if (inputBuffer.Peek(KeyCode.O))
            {
                Animator.SetBool("high_block", true);
            }

            if (inputBuffer.Peek(KeyCode.L))
            {
                Animator.SetBool("low_block", true);
            }
        }

        if (!inputBuffer.Peek(KeyCode.O))
        {
            Animator.SetBool("high_block", false);
        }

        if (!inputBuffer.Peek(KeyCode.L))
        {
            Animator.SetBool("low_block", false);
        }
    }

    private void UpdateAnimator()
    {
        switch (state)
        {
            case State.NEUTRAL:
                Animator.SetBool("back_walk", false);
                Animator.SetBool("forward_walk", false);
                Animator.SetBool("midair", false);
                break;
            case State.MIDAIR:
                Animator.SetBool("back_walk", false);
                Animator.SetBool("forward_walk", false);
                Animator.SetBool("midair", true);
                break;
            case State.BACK_WALK:
                Animator.SetBool("back_walk", true);
                Animator.SetBool("forward_walk", false);
                Animator.SetBool("midair", false);
                break;
            case State.FORWARD_WALK:
                Animator.SetBool("back_walk", false);
                Animator.SetBool("forward_walk", true);
                Animator.SetBool("midair", false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            grounded = false;
        }
    }

    public void onAnimationEvent(string eventName)
    {
        currentMove?.OnAnimationEvent(eventName);
        if (currentMove == null)
        {
            Debug.LogError($"Received animation event with no current move: {eventName}");
        }
    }
    
    public void setHitboxState(HitboxPath hitboxPath, bool state)
    {
        Hitbox hitbox = transform.Find(hitboxPath.Path)?.gameObject?.GetComponent<Hitbox>();
        if (hitbox == null)
        {
            Debug.LogError($"Unknown hitbox path: {hitboxPath}");
        }
        else
        {
            hitbox.Active = state;
        }
    }

    public enum State
    {
        NEUTRAL,
        MIDAIR,
        BACK_WALK,
        FORWARD_WALK
    };

    public class HitboxPath
    {
        public string Path { get; private set; }

        private HitboxPath(string path)
        {
            Path = path;
        }

        public static HitboxPath UPPER_BODY = new HitboxPath("Hitboxes/UpperBody");
        public static HitboxPath HEAD = new HitboxPath("Hitboxes/UpperBody/Head");
        public static HitboxPath LEFT_UPPER_ARM = new HitboxPath("Hitboxes/UpperBody/LeftArm/UpperLeftArm");
        public static HitboxPath LEFT_LOWER_ARM = new HitboxPath("Hitboxes/UpperBody/LeftArm/UpperLeftArm/LowerLeftArm");
        public static HitboxPath LEFT_HAND = new HitboxPath("Hitboxes/UpperBody/LeftArm/UpperLeftArm/LowerLeftArm/LeftHand");
        public static HitboxPath RIGHT_UPPER_ARM = new HitboxPath("Hitboxes/UpperBody/RightArm/UpperRightArm");
        public static HitboxPath RIGHT_LOWER_ARM = new HitboxPath("Hitboxes/UpperBody/RightArm/UpperRightArm/LowerRightArm");
        public static HitboxPath RIGHT_HAND = new HitboxPath("Hitboxes/UpperBody/RightArm/UpperRightArm/LowerRightArm/RightHand");
        public static HitboxPath LOWER_BODY = new HitboxPath("Hitboxes/LowerBody");
        public static HitboxPath LEFT_UPPER_LEG = new HitboxPath("Hitboxes/LowerBody/LeftLeg/UpperLeftLeg");
        public static HitboxPath LEFT_LOWER_LEG = new HitboxPath("Hitboxes/LowerBody/LeftLeg/UpperLeftLeg/LowerLeftLeg");
        public static HitboxPath LEFT_FOOT = new HitboxPath("Hitboxes/LowerBody/LeftLeg/UpperLeftLeg/LowerLeftLeg/LeftFoot");
        public static HitboxPath RIGHT_UPPER_LEG = new HitboxPath("Hitboxes/LowerBody/RightLeg/UpperRightLeg");
        public static HitboxPath RIGHT_LOWER_LEG = new HitboxPath("Hitboxes/LowerBody/RightLeg/UpperRightLeg/LowerRightLeg");
        public static HitboxPath RIGHT_FOOT = new HitboxPath("Hitboxes/LowerBody/RightLeg/UpperRightLeg/LowerRightLeg/RightFoot");
    }
}
