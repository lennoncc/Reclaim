using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hero.Command;

namespace Hero.Command
{
    // Phase 4 Implementation: Fire2 set to Jump
    // Added private bool variable in PirateController.cs called "isStateJump" to track status of jump
    // Purpose is to prevent multiple jumps from occuring midair
    // Can only jump while touching the ground
    // Note: Added a "Ground" tag that was applied to the three Ground objects in MushroomForest, Mountains, and Graveyard
    public class JumpHero : ScriptableObject, IHeroCommand
    {
        private float force = 15.0f;


        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                // This applies a force in the upwards direction to simulate a jump
                rigidBody.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            }
        }
    }
}