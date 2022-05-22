using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class MoveCharacterLeft : ScriptableObject, ICaptainCommand
    {
        private float speed = 20.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                if(rigidBody.velocity.x > -1)
                {
                    rigidBody.velocity = new Vector2(-this.speed, rigidBody.velocity.y);
                }
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}