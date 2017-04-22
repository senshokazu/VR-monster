using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Animator anim;
    public Animator animatorHand;//手
    public BoxCollider boxCollider;
    public int hp ;
    public int atacck;
    public int fullHp;
    public int attackPower;
    public Image hpGauge;
    public GameObject hpObj;
    public RayManager raymanager;
    public GameObject Hand;
    public CameraCollider cameracollider;
    public HandController handcontroller;
    public  bool Enemybool = false;
    public Image playerImage;
    public GameObject Image;
    public GameObject EnemyHit;
    public GameObject MoveStopCollider;
    public ParticleSystem SlashEffect;
    public AudioClip EnemyAttackSound;
    public AudioSource audiosource;

    // Use this for initialization
   protected void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.clip = EnemyAttackSound;
        SlashEffect = EnemyHit.GetComponent<ParticleSystem>();
        playerImage = Image.GetComponent<Image>();
        anim = GetComponent<Animator>();
        animatorHand = Hand.GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        fullHp = hp;
    }
    // Update is called once per frame
      protected virtual void Update()
    {
         anim.SetBool("--",false);
         anim.SetBool("--", false);
        float x = (transform.position.x) - (cameracollider.transform.position.x);
        float z = (transform.position.z) - (cameracollider.transform.position.z);
        if ((x * x) + (z * z) < 250f && Enemybool == false)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);
            transform.position += ((new Vector3(cameracollider.transform.position.x, 0, cameracollider.transform.position.z) -
            new Vector3(transform.position.x, 0, transform.position.z))).normalized * Time.deltaTime * 1.0f;
            anim.SetBool("--", true);
        }
        if ((x * x) + (z * z) < 9f)
        {
            Enemybool = true;
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);
            anim.SetBool("--", false);
            anim.SetBool("--", true);
            StartCoroutine("CEnemyAttack");
        }
        if ((x * x) + (z * z) >= 16f && (x * x) + (z * z) < 17f)
        {
            Enemybool = false;
        }
    }
    public  bool IsRunning = false;

    protected virtual IEnumerator CEnemyAttack()
    {
        if (IsRunning == true)
        {
            yield break;
        }
        else
        {
            IsRunning = true;
            Invoke("EnemyAttack", 0);
            yield return new WaitForSeconds(0);
            IsRunning = false;//必ずアニメーションのHasExitTimeのExitTimeを１にして、durationを0にする
        }
    }


   protected void EnemyAttack()
    {
        audiosource.Play();
        playerImage.enabled = true;
        Invoke("PlayerImagefalse", 0.25f);
        handcontroller.hp -= atacck;
        handcontroller.HpGauge.fillAmount = (float)handcontroller.hp / handcontroller.fullhp;
    }

   protected void PlayerImagefalse()
    {
        playerImage.enabled = false;
    }

   protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "test_sword")
        {
            attackPower = other.GetComponent<Weapon>().power;
            hp -= attackPower;
            hpGauge.fillAmount = (float)hp / fullHp; //(float)型変換
            print(hp);
            if (hp <= 0)
            {
                MoveStopCollider = null;
                EnemyHit = null;
                SlashEffect.Clear();
                StopCoroutine("CEnemyAttack");
                cameracollider.Slashmotion = false;
                anim.SetBool("--", true);
                animatorHand.SetBool("Slash", false);
                Destroy(boxCollider);
                Invoke("destroyslime", 1.5f);
                Destroy(hpObj);
            }
        }
    }

   protected void destroyslime()
    {
        Destroy(this.gameObject);
        raymanager.Movestop = false;

    }

}


