using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform alvo;
    public float interpolation;

    void Update()
    {
        Vector3 posicao = alvo.position;
        //posicao.x = Mathf.Clamp(posicao.x, 0.5f, 55);    //restrição de valores do eixo x, minimo e maximo
        //posicao.y = Mathf.Clamp(posicao.y, 0.5f, 4);    //restrição de valores do eixo y, minimo e maximo
        posicao.z = transform.position.z;   //copiou a posicao do alvo, mas manteve a posicao z da camera

        posicao = Vector3.Lerp(transform.position, posicao, interpolation);    //interpolacao, posição intermediaria entre inicial e final, e porcentagem de interpolacao

        transform.position = posicao;  //alvo ja é tipo transform
    }
}
