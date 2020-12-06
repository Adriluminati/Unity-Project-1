using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float actualHealth;

    private bool inmortal = false;
    public float inmortalTime = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        inmortal = false;
        actualHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }

        if (actualHealth <= 0)
        {
            Dead();
        }
    }

    public void restHealth(float Damage)
    {
        if (inmortal) return;

        actualHealth -= Damage;

        StartCoroutine(InmortalTimeFuncion());
    }

    public void addHealth(float Health)
    {
        actualHealth += Health;
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }

    IEnumerator InmortalTimeFuncion()
    {
        inmortal = true;
        yield return new WaitForSeconds(inmortalTime);
        inmortal = false;
    }
}
