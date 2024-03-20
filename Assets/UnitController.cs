using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UnitController : MonoBehaviourPunCallbacks
{
    AIPath path;
    [SerializeField]
    GameManager gameManager;
    public Vector3 target;
    public GameObject selectionCircle;
    public Unit unit;
    public int team;
    Rigidbody rb;

    public SpriteRenderer sprite;

    public float currentHealth;
    public float currentSpeed;

    public float timer;

    private float fireTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = GetComponent<AIPath>();

        gameManager = FindObjectOfType<GameManager>();
        
        path.maxSpeed = unit.speed;

        currentHealth = unit.health;
        currentSpeed = unit.speed;

        selectionCircle.SetActive(false);
        if (team == 1)
        {
            gameManager.team1.Add(transform);
            sprite.color = Color.blue + Color.white / 2;
        }
        else
        {
            gameManager.team2.Add(transform);
            sprite.color = Color.red + Color.white / 2;
        }

        sprite.sprite = unit.image;
    }

    public bool canShoot;

    private void Update()
    {
        if (team == 1)
        {
            sprite.color = Color.blue + Color.white / 2;
        }
        else
        {
            sprite.color = Color.red + Color.white / 2;
        }
        gameManager.isClosestEnemyInRange(transform, unit.range, team);
        timer -= Time.deltaTime;

        photonView.RPC("SyncHealth", RpcTarget.MasterClient, currentHealth);

        path.maxSpeed = currentSpeed;

        // Recovery
        currentSpeed = Mathf.Lerp(currentSpeed, unit.speed, Time.deltaTime / unit.recoverSpeed);

        // Firing
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0 && canShoot && PhotonNetwork.IsConnectedAndReady)
        {
            fireTimer = unit.fireRate;
            GameObject bullet = Instantiate(unit.bullet, transform.position, Quaternion.LookRotation(gameManager.getClosestEnemy(transform, team).position - transform.position, Vector3.up));
            //Vector3 random = bullet.transform.up * Random.Range(-currentAccuracy, currentAccuracy) + bullet.transform.right * Random.Range(-currentAccuracy, currentAccuracy);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * unit.bulletVelocity);
            bullet.GetComponent<BulletController>().damage = unit.damage;
            bullet.GetComponent<BulletController>().team = team;
        }

        if(timer <= 0)
        {
            selectionCircle.SetActive(false);
        }
        else
        {
            selectionCircle.SetActive(true);
        }
    }

    [PunRPC]
    public void SyncHealth(float health)
    {
        currentHealth = health;
    }

    public void SetTarget()
    {
        path.destination = target;
    }

    public void Hurt(Vector3 damageDirection, float damageForce, float damage, float speedDebuff)
    {
        // Blood Particles

        // Damage
        currentHealth -= damage;

        // Speed Debuff
        currentSpeed -= speedDebuff;

        // Push Back
        rb.AddForce(damageDirection * damageForce, ForceMode.Force);
       
        if(currentHealth <= 0)
        {
            photonView.RPC("SyncHealth", RpcTarget.MasterClient, currentHealth);
            Die();
        }
    }

    public void Die()
    {
        // Instantiate dead player

        // Destroy current object
        gameManager.DestroyUnit(transform, team);
    }
}
