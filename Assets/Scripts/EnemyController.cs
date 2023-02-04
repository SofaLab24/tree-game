using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    protected Rigidbody2D enemyR;
    protected SpriteRenderer enemySR;

    protected GameObject player;
    protected Transform playerT;

    public float health = 3f;
    public float damage = 1f;
    [Range(0, 1)]
    public float dropChance = .3f;

    public LootDropTable lootDrop;

    public AudioClip deathSound;
    
    [SerializeField]
    protected float enemySpeed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerT = player.transform;
        enemyR = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public virtual void Movement()
    {
        if (transform.position.x > playerT.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, enemySpeed * Time.deltaTime);
            enemySR.flipX = false;
        }
        else if (transform.position.x < playerT.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, enemySpeed * Time.deltaTime);
            enemySR.flipX = true;
        }
    }

    public void takeDamage(float damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            dropItem();
            SoundManager.Instance.Play(deathSound);
            Destroy(this.gameObject);
        }
    }

    private void dropItem()
    {
        float chance = Random.Range(0, 100);
        if (chance / 100 < dropChance)
        {            
            Instantiate(lootDrop.PickItem(), transform.position, transform.rotation);
        }
    }

    public void sapped(float duration)
    {
        // TODO: This
    }

    public void Root(float duration)
    {
        StartCoroutine(RootTime(duration));
    }

    IEnumerator RootTime(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Don't worry");
    //    if (other.tag.Equals("PlayerProjectile"))
    //    {
    //        Debug.Log("Be happy");
    //        Projectile proj = other.GetComponent<Projectile>();
    //        this.health -= proj.damageAmount;
    //        if (this.health <= 0) Destroy(this.gameObject);
    //    }
    //}
}
