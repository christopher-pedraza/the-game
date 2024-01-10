using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Spell
{
    public string name;
    public Sprite icon;
    public int cooldown;
    public int activeCooldown;
    public int damage;
    public int range;
    public KeyCode key;
}

public class Spell_Controller : MonoBehaviour
{
    public Spell[] spells;

    public float defaultDelay = 0.5f;

    private float[] delays;
    private bool[] isCasting;

    // Start is called before the first frame update
    void Start()
    {
        // Update the activeCooldown of each spell with the cooldown so they can be used the first time
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i].activeCooldown = spells[i].cooldown;
        }
        // Initialize the delays (with 0s) and isCasting (with false) arrays
        delays = new float[spells.Length];
        isCasting = new bool[spells.Length];
    }

    public void NextRound()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            Debug.Log(spells[i].name + " is casting: " + isCasting[i] + " and has " + spells[i].activeCooldown + " of cooldown");

            // If the spell is casting and the cooldown is equals to the activeCooldown
            // (the spell is not on cooldown) then cast the spell and make the cooldown 0
            if (isCasting[i] && spells[i].cooldown == spells[i].activeCooldown)
            {
                spells[i].activeCooldown = 0;
                isCasting[i] = false;
            }
            // If the spell is not casting and the cooldown is not equals to the activeCooldown
            // (the spell is on cooldown) then increase the cooldown by 1 each round
            else if (!isCasting[i] && spells[i].cooldown != spells[i].activeCooldown)
            {
                spells[i].activeCooldown += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            // If the key is pressed and the delay is 0 and the spell is not on cooldown
            if (Input.GetKey(spells[i].key) && delays[i] <= 0f && spells[i].activeCooldown == spells[i].cooldown)
            {
                // Set the delay to the default delay to prevent multiclicks of the same key
                delays[i] = defaultDelay;
                // Toggle whether the spell is casting or not
                isCasting[i] = !isCasting[i];
                Debug.Log(spells[i].key + " is casting: " + isCasting[i]);
            }
        }

        // Update the delays to prevent multiclicks of the same key
        for (int i = 0; i < delays.Length; i++)
        {
            if (delays[i] > 0f)
            {
                delays[i] -= Time.deltaTime;
            }
        }
    }
}
