using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float Radius; // радиус взрыва
    public float Force; // сила взрыва
    public AudioSource aus; // источник звука
    public GameObject particalExplosion;  //Префаб частиц
    public GameObject textureExplosion; //Префаб текстуры взрыва
    public Transform transTexture; //Положение для текстуры
  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            Explos();//вызываем метод взрыва
        }
    }

    public void Explos(){
            ExplosForce();//вызываем метод добавления силы объектам
            aus.Play();  // воспроизводим звук        
            Destroy(gameObject); //удаляем текущий объект
            Instantiate(particalExplosion, transform.position, transform.rotation); //создаем частицы взрыва
            Instantiate(textureExplosion, transTexture.position, transform.rotation);  //создаем текстуру взрыва
        }


    public void ExplosForce(){
        Collider[] col = Physics.OverlapSphere(transform.position, Radius); //выставляем радиус проверки объектов для взаимодействия
        foreach (Collider hit in col)
        {
            Rigidbody rg = hit.GetComponent<Rigidbody>(); //задаем переменную компонента rigibody
           
            if(rg){
                
             rg.AddExplosionForce(Force, transform.position, Radius, 3f);//для всех объектов в заданом радиусе, с наличием rigidbody применяем силу взрыва
        }
    }
}
}
