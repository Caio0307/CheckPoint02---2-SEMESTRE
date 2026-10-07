using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMove playerMove;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();

    }


    private void Update()
    {

        animator.SetInteger("pMove", playerMove.MoveValue());
        animator.SetInteger("pJump",playerMove.JumpValue());

    }




}
