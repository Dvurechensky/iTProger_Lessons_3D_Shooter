using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    [SyncVar]
    private float currHealth;

    private void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float _DAMAGE)
    {
        currHealth -= _DAMAGE;
        Debug.Log(transform.name + " healt " + currHealth);
    }
}
