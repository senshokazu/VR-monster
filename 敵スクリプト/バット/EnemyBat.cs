using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBat : Enemy
{
    protected override void Update()
    {
        anim.SetBool("BatAttack", false);
        anim.SetBool("BatRun", false);
        float x = (transform.position.x) - (cameracollider.transform.position.x);
        float z = (transform.position.z) - (cameracollider.transform.position.z);
        if ((x * x) + (z * z) < 250f && Enemybool == false)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);
            transform.position += ((new Vector3(cameracollider.transform.position.x, 0, cameracollider.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z))).normalized * Time.deltaTime * 1.0f;
            anim.SetBool("BatRun", true);
        }
        if ((x * x) + (z * z) < 9f)
        {
            Enemybool = true;
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);
            anim.SetBool("BatRun", false);
            anim.SetBool("BatAttack", true);
            StartCoroutine("CEnemyAttack");
        }
        if ((x * x) + (z * z) >= 16f && (x * x) + (z * z) < 17f)
        {
            Enemybool = false;
        }
    }

    protected override IEnumerator CEnemyAttack()
    {
        if (IsRunning == true)
        {
            yield break;
        }
        else
        {
            IsRunning = true;
            Invoke("EnemyAttack", 0.8f);
            yield return new WaitForSeconds(2.458333f);
            IsRunning = false;//必ずアニメーションのHasExitTimeのExitTimeを１にして、durationを0にする
        }
    }

    protected override void OnTriggerEnter(Collider other)
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
                anim.SetBool("Batdie", true);
                animatorHand.SetBool("Slash", false);
                Destroy(boxCollider);
                Invoke("destroyslime", 1.5f);
                Destroy(hpObj);
            }
        }
    }
}