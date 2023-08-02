using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCharacter : MonoBehaviour
{
    public GameObject[] activate;
    public GameObject[] deactivate;
    public int characterIndex;
    public void Character(int i)
    {
        foreach(GameObject g in activate)
        {
            if(characterIndex == i)
            {
                g.SetActive(true);
            }
            else
            {
                g.SetActive(false);
            }
        }

        foreach (GameObject g in deactivate)
        {
            if (characterIndex == i)
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }
}
