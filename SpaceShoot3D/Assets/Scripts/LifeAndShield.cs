using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAndShield : MonoBehaviour
{
    public int maxHealth = 100,
                         curHealth;
    private bool isInvincible = false;
    [SerializeField] private int invincibilitySeconds;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getCurHealth()
    {
        return curHealth;
    }


    public void TakeDamage(int dmg = 1)
    {
        if (isInvincible) { return; }
        curHealth -= dmg;

        if (curHealth < 0)
            curHealth = 0;

        if (gameObject.tag == "Player")
            EventManager.TakeDamage(curHealth / (float)maxHealth);

        if (curHealth < 1)
        {
            GetComponent<Explosion>().BlowUp();
        }

    }

    public IEnumerator BecomeTemporarilyInvincible(MeshRenderer[] meshes)
    {
        EventManager.PickPowerUp("Invulnerabilità per " + invincibilitySeconds + " secondi");
        Debug.Log("invincible");
        isInvincible = true;

        foreach (MeshRenderer m in meshes)
        {

            m.material.color = Color.yellow;
        }

            yield return new WaitForSeconds(invincibilitySeconds);

            foreach (MeshRenderer m in meshes)
            {
                m.material.color = Color.white;
            }

            Debug.Log("No more invincible");
            isInvincible = false;
    }

}
