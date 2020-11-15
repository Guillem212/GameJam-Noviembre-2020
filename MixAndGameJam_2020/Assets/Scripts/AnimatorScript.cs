using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    Animator c_anim;

    // Start is called before the first frame update
    void Start()
    {
        c_anim = GetComponent<Animator>();
    }    

    public void f_HitByAPlayer()
    {
        c_anim.SetTrigger("HitByAPlayer");
    }
    public void f_HitAPlayer()
    {
        c_anim.SetTrigger("HitAPlayer");
    }
    public void f_Shoot()
    {        
        c_anim.SetTrigger("Shoot");
    }
}
