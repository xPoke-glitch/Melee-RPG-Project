using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    [SerializeField]
    protected Transform centerAttackPoint;

    [SerializeField]
    protected float attackRange;

    protected IStats _wielder;

    protected bool _canProcessNextAttack = true;

    protected IEnumerator ProcessAttack(float seconds, int damage, Collider wielderCollider)
    {
        _canProcessNextAttack = false;
        Collider[] hitEnemies = Physics.OverlapSphere(centerAttackPoint.transform.position, attackRange);
        yield return new WaitForSeconds(seconds);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.GetComponent<IDamageable>() != null && !wielderCollider.gameObject.Equals(enemy.gameObject))
            {
                enemy.GetComponent<IDamageable>().Damage(damage);
            }
        }
        _canProcessNextAttack = true;
    }

    protected void OnDrawGizmos()
    {
        if (centerAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(centerAttackPoint.position, attackRange);
    }
}
