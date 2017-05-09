using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Animator ani;

    private bool playerMoving;

    private Vector2 lastMove;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxis("Horizontal"), 0);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.up);
            playerMoving = true;
            lastMove = new Vector2(0, Input.GetAxis("Vertical"));
        }

        ani.SetFloat("MoveY", Input.GetAxis("Vertical"));
        ani.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        ani.SetBool("PlayerMove", playerMoving);
        ani.SetFloat("LastMoveX", lastMove.x);
        ani.SetFloat("LastMoveY", lastMove.y);
    }
}
