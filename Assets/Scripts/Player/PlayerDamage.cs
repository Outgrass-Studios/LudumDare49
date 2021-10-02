using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using qASIC;

public class PlayerDamage : MonoBehaviour
{
    int health = 100;

    public void Hurt(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
            Kill();
    }
    private void Kill()
    {
        qDebug.Log("Player was killed");
    }
}
