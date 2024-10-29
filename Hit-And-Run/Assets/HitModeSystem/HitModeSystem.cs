using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임의 주요 기능 중 하나인 타격 모드 관련 시스템 기능 클래스.
/// </summary>
public class HitModeSystem : MonoBehaviour
{
    public Animator playerAnimator;

    public Camera playerCamera;

    private void ToggleHitMode()
    {
        /// SpaceBar 관련
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerAnimator.GetBool("IsHitMode"))
            {
                playerAnimator.SetBool("IsHitMode", false);
            }
            else
            {
                playerAnimator.SetBool("IsHitMode", true);
            }
        }

        /// HitMode 도중 움직일 경우
        if (playerAnimator.GetBool("IsMoving") && playerAnimator.GetBool("IsHitMode"))
        {
            playerAnimator.SetBool("IsHitMode", false);
        }
    }
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleHitMode();
    }
}
