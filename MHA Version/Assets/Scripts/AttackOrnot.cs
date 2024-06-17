using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOrnot : MonoBehaviour
{
    public int activeOn = 0;
    public GameObject[] sprites;
    public void IsAttack(int i)
    {
        foreach(GameObject r in sprites)
        {
            if(i == activeOn)
            {
                r.SetActive(true);
            }
            else
            {
                r.SetActive(false);
            }
        }
    }
}
