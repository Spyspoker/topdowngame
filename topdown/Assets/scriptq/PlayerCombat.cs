using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.HID.HID;

public class PlayerCombat : MonoBehaviour


{
    public GameObject Sword;
    public InputActionReference attack;
    private Animator animator;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public float damage = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SwordAttack()
    {
      CanAttack = false;
      animator.SetTrigger("SwordAttack");
      StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
      yield return new WaitForSeconds(AttackCooldown);
      CanAttack = true;
    }
    
    private void OnEnable()
    {
      attack.action.performed += PerformAttack;
    }
    private void OnDisable()
    {
      attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if(CanAttack)
        {
              SwordAttack();
        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
          EnemyScript enemy = other.GetComponent<EnemyScript>();
          if (enemy != null)
          {
            enemy.Health -= damage;
          }
        }
    }
}
