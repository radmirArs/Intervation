using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    RaycastHit hit; //Переменная для удара
    public ParticleSystem Explosion; //Партиклы
    bool canShoot = true; //Переменная для задержки
    public float Delay = 0.2f; //Задержка

    void Update()
    {
        var Ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)); //Луч с центра камеры
        Physics.Raycast(Ray.origin, Ray.GetPoint(100), out hit); //Считывание удара с объектом
        if (Input.GetMouseButton(0) && canShoot) { //Если нажата ЛКМ и можно стрелять...
            canShoot = false; //стрелять нельзя.
            if (!IsInvoking("MakeShoot")) Invoke("MakeShoot", Delay); //но потом можна!
            Debug.Log($"Shoot!"); //Индикатор для стрельбы
            Explosion.Play();
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy") { //Если нацелен на врага и стреляет..


                //...ТВОЙ КОД ЗДЕСЬ ТИПА ЧО ДЕЛАЕТ


            }
        }
    }
    void MakeShoot() { //стрелять нельзя я сказал!
        canShoot = true; //нет я говорю можна!
    }
}
