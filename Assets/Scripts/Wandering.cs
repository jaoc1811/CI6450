using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{

    public agent character;

    public float maxRotation;

    // Update is called once per frame
    void Update()
    {
        character.velocity = character.maxSpeed * character.asVector(character.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        character.rotation = Random.Range(-1f,1f) * maxRotation;
    }
}
