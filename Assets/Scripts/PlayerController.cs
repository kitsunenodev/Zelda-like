using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveForce = 20;
    
    public Rigidbody2D PlayerBody;
    
    public Animator Animator;
    
    public SpriteRenderer SpriteRenderer;

    private Coroutine m_coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 m_direction = new Vector2(horizontal, vertical);
        if (m_direction.magnitude > 0.1f)
        {
            if (m_direction.x > 0f)
            {
                SpriteRenderer.flipX = false;
            }
            
            else
            {
                SpriteRenderer.flipX = true;
            }

            if (m_coroutine == null)
            {
                m_coroutine = StartCoroutine(PlayFootsteps());
            }
            m_direction.Normalize();
            PlayerBody.AddForce(m_direction * MoveForce);
            Animator.SetBool("walking", true);
        }
        else
        {
            if (m_coroutine != null)
            {
                StopCoroutine(m_coroutine);
                m_coroutine = null;
            }
            Animator.SetBool("walking", false);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator PlayFootsteps()
    {
        while (enabled)
        {
           AudioManager.Instance.PlaySound(AudioManager.Instance.Clips[1].GetRandomCLip().name);
                   yield return new WaitForSeconds(0.1f); 
        }
        
    }
}
