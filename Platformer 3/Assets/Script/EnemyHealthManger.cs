using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManger : MonoBehaviour
{
    public int health;
    private int currentHealt;

    public float flashLength; 
    private float flashCounter; 
    private Renderer rend; 
    private Color storedColor;

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = health;
        rend = GetComponent<Renderer>(); 
        storedColor = rend.material.GetColor("_Color"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealt <= 0)
        {
            Destroy(gameObject);
        }
        if (flashCounter > 0) 
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0) 
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }
    public void HurtEnemy(int damage)
    {
        currentHealt -= damage;
        flashCounter = flashLength; 
        rend.material.SetColor("_Color", Color.white); 
    }
}
