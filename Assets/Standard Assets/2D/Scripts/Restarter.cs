using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public Transform StartPosition;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.transform.position = StartPosition.position;
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
