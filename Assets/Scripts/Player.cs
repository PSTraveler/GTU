using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public CanvasGroup deadGroup;

    public Transform groundChkFront;  // 바닥 체크 position 
    public Transform groundChkBack;   // 바닥 체크 position 

    // 벽타기
    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask w_Layer;
    bool isWall;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump;

    // 조이스틱
    public JoystickValue value;

    // 캐릭터 체력
    [SerializeField]
    private Slider hpBar = null;
    private const float maxHp = 100;
    private float curHp = 100;
    float tempHp;

    // 캐릭터 피격
    bool isHurt;
    public float shotSpeed;

    // 롱점, 숏점
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJump;

    // 피격 시 색상 변경
    SpriteRenderer sr;
    Color halfA = new Color(1, 1, 1, 0.5f);
    Color fullA = new Color(1, 1, 1, 1);

    public float runSpeed;  // 이동 속도
    float isRight = 1;  // 바라보는 방향 1 = 오른쪽 , -1 = 왼쪽

    float input_x;
    bool isGround;
    public float chkDistance;
    public float jumpPower = 1;
    public LayerMask g_Layer;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tempHp = (float)curHp / (float)maxHp;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            input_x = Input.GetAxis("Horizontal");
        else input_x = value.joyTouch.x;

        // 캐릭터의 앞쪽과 뒤쪽의 바닥 체크를 진행
        bool ground_front = Physics2D.Raycast(groundChkFront.position, Vector2.down, chkDistance, g_Layer);
        bool ground_back = Physics2D.Raycast(groundChkBack.position, Vector2.down, chkDistance, g_Layer);

        // 점프 상태에서 앞 또는 뒤쪽에 바닥이 감지되면 바닥에 붙어서 이동하게 변경
        if (!isGround && (ground_front || ground_back))
            rigid.velocity = new Vector2(rigid.velocity.x, 0);

        // 앞 또는 뒤쪽의 바닥이 감지되면 isGround 변수를 참으로!
        if (ground_front || ground_back)
            isGround = true;
        else
            isGround = false;

        anim.SetBool("isGround", isGround);

        // 벽타기
        isWall = Physics2D.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, w_Layer);
        anim.SetBool("isSliding", isWall);

        // 스페이스바가 눌리면 점프 애니메이션을 동작
        if (Input.GetAxis("Jump") != 0 || value.jumpTouch == true)
        {
            anim.SetTrigger("jump");
        }

        // 캐릭터 롱점프 & 점프
        if (isGround == true && (Input.GetKey(KeyCode.Space) || value.jumpTouch == true))
        {
            isJump = true;
            jumpTimeCounter = jumpTime;
            rigid.velocity = Vector2.up * jumpPower;
        }
        if ((Input.GetKey(KeyCode.Space) || value.jumpTouch == true) && isJump == true)
        {
            if (jumpTimeCounter > 0)
            {
                rigid.velocity = Vector2.up * jumpPower;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || value.jumpTouch == false)
        {
            isJump = false;
        }
        tempHp = (float)curHp / (float)maxHp;

        // 방향키가 눌리는 방향과 캐릭터가 바라보는 방향이 다르다면 캐릭터의 방향을 전환.
        if (!isWallJump)
            if ((input_x > 0 && isRight < 0) || (input_x < 0 && isRight > 0))
            {
                FlipPlayer();
                anim.SetBool("run", true);
            }
            else if (input_x == 0)
            {
                anim.SetBool("run", false);
            }
        HandleHp();
    }

    private void FixedUpdate()
    {
        // 캐릭터 이동
        if (!isWallJump)
        {
            rigid.velocity = (new Vector2((input_x) * runSpeed, rigid.velocity.y));
            anim.SetBool("run", true);
        }

        // 벽타기
        if (isWall)
        {
            isWallJump = false;
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * slidingSpeed);
            if (Input.GetAxis("Jump") != 0 || value.jumpTouch == true)
            {
                isWallJump = true;
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(-isRight * 50f * wallJumpPower, 100f * wallJumpPower));
                FlipPlayer();
                Invoke(nameof(FreezeX), 0.3f); // 벽점프 후 0.3초 이동 불가
            }
        }
    }

    void FreezeX()
    {
        isWallJump = false;
    }

    void FlipPlayer()
    {
        // 방향을 전환.
        transform.eulerAngles = new Vector3(0, Mathf.Abs(transform.eulerAngles.y - 180), 0);
        isRight *= -1;
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, tempHp, Time.deltaTime * 10);
    }

    // 캐릭터 피격
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Enemy"))
        // {
        //     Debug.Log("아파요");
        //     Hurt(collision.GetComponentInParent<Enemy>().damage, collision.transform.position);
        // }
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("아파요");
            Hurt(collision.GetComponentInParent<Bullet>().damage, collision.transform.position);
        }
    }
    public void Hurt(int damage, Vector2 pos)
    {
        if (!isHurt)
        {
            isHurt = true;
            curHp -= damage;
            if (curHp <= 0)
            {
                Destroy(this.gameObject);
                BtnType.IsPause();
                CanvasGroupOn(deadGroup);
            }
            else
            {
                float x = transform.position.x - pos.x;
                if (x < 0) x = 1;
                else x = -1;

                StartCoroutine(Knockback(x)); // 넉백
                StartCoroutine(HurtRoutine()); // 일정시간 무적
                StartCoroutine(Alphablink()); // 피격 시 깜빡임
            }
        }
    }

    IEnumerator Knockback(float dir)
    {
        float ctime = 0;
        while (ctime < 0.2f)
        {
            if (transform.rotation.y == 0)
            {
                transform.Translate(Vector2.left * shotSpeed * Time.deltaTime * dir);
            }
            else
            {
                transform.Translate(Vector2.left * shotSpeed * Time.deltaTime * -1f * dir);
            }
            ctime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(3f);
        isHurt = false;
    }
    IEnumerator Alphablink()
    {
        while (isHurt)
        {
            yield return new WaitForSeconds(0.1f);
            sr.color = halfA;
            yield return new WaitForSeconds(0.1f);
            sr.color = fullA;
        }
    }

    // 사망 패널
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    // 바닥 체크 Ray를 씬화면에 표시
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundChkFront.position, Vector2.down * chkDistance);
        Gizmos.DrawRay(groundChkBack.position, Vector2.down * chkDistance);
    }
}