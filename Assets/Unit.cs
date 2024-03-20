using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "AOW/Unit", order = 1)]
public class Unit : ScriptableObject
{
    public string unitType;
    public float health;
    public float damage;
    public float speed;
    public float range;
    public float fireRate;
    public float bulletVelocity;
    public float recoverSpeed;
    public GameObject bullet;
    public Sprite image;
}