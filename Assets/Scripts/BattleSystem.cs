using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public Animator WeaponAnimator;
    public GameObject WeaponGameobject;

    public Inventory player;

    public SpriteRenderer playerRenderer;
    public Slider healthBar;
    
    public float hp = 100;
    public float maxHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = WeaponGameobject.GetComponent<SpriteRenderer>();
        playerRenderer.sprite = player.mainHand.texture;
        playerRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRenderer.enabled = true;
            WeaponAnimator.SetTrigger("swing");
        }

        healthBar.value = hp / maxHp;
    }



    public void dealDamage(float damage)
    {
        hp -= damage;
    }
}
