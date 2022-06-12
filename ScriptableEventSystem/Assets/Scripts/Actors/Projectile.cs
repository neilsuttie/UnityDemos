using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Physics Settings")]

    [Tooltip("The magnitude of the force applied to the game object on spawn")]
    public float force = 10f;

    [Header("Projectile Settings")]
    
    [Tooltip("The number of seconds until this projectile despawns")]
    public float lifeTime = 3.0f;

    [Header("Projectile Damage Settings")]

    [Tooltip("The minimum damage associated with this projectile")]
    public float minDamage = 5.00f;

    [Tooltip("The maximum damage associated with this projectile")]
    public float maxDamage = 15.0f;

    public string targetTag = "";

    private float damage;

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);

        Invoke("Despawn", lifeTime);

        //Decide the damage of this particular bullet
        damage = Random.Range(minDamage, maxDamage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        Despawn();
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
