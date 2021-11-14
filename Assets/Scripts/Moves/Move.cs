using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Move : MonoBehaviour
    {
        // Update is called once per frame
        public void Movement(float speed, Animator animator)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.magnitude);

            transform.position = transform.position + movement * speed * Time.deltaTime;
        }
    }
