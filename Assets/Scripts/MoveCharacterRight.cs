using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class MoveCharacterRight : ScriptableObject, ICaptainCommand
    {
        private float speed = 20.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                // right movement would have a positive vector
                if(rigidBody.velocity.x < 1)
                {
                    rigidBody.velocity = new Vector2(this.speed, rigidBody.velocity.y);
                }
                // the sprite isn't flipped when moving right
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}