using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    RaycastHit hit; //Переменная для удара
    public ParticleSystem Explosion; //Партиклы
    public Animator Recoil; //Анимка
    bool canShoot = true; //Переменная для задержки
    public float Delay = 0.3f; //Задержка
    public GameObject itemInRange;
    [SerializeField] EnemyVar1W enemy1;
    [SerializeField] UnityEngine.AI.NavMeshAgent enemy1navMesh;

    [SerializeField] float stun_time;

    public float speed;

    void Start()
    {
        speed = enemy1navMesh.speed;
    }

    void Update()
    {
        var Ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)); //Луч с центра камеры
        Physics.Raycast(Ray.origin, Ray.GetPoint(100), out hit); //Считывание удара с объектом
        if (Input.GetMouseButton(0) && canShoot) { //Если нажата ЛКМ и можно стрелять...
            canShoot = false; //стрелять нельзя.
            if (!IsInvoking("MakeShoot")) Invoke("MakeShoot", Delay); //но потом можна!
            Explosion.Play(); //Партиклы
            Recoil.SetTrigger("toShoot"); //Триггер для аниматора
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy" && !IsInvoking("Stun_enemy1") ) { //Если нацелен на врага и стреляет..

                itemInRange = hit.collider.gameObject;

                enemy1.enabled = false;

                enemy1navMesh.speed = 0f;
                Invoke("Stun_enemy1", stun_time);


                //...ТВОЙ КОД ЗДЕСЬ ТИПА ЧО ДЕЛАЕТ
                //Он должен делать что-либо, если луч, проведённый от центра экрана в сторону gameObject с тегом Enemy, находит его и при нажатии что-либо выполняется


            }
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy 2")
            { //Если нацелен на врага и стреляет..

                itemInRange = hit.collider.gameObject;

                

                //...ТВОЙ КОД ЗДЕСЬ ТИПА ЧО ДЕЛАЕТ
                //Он должен делать что-либо, если луч, проведённый от центра экрана в сторону gameObject с тегом Enemy, находит его и при нажатии что-либо выполняется


            }
            else itemInRange = null;

        }
    }
    void MakeShoot() { //стрелять нельзя я сказал!
        canShoot = true; //нет я говорю можна!
    }

    void Stun_enemy1()
    {
        enemy1navMesh.speed = speed;
        enemy1.enabled = true;
        Debug.Log(enemy1.enabled);
    }
}
