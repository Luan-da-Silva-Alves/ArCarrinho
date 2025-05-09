﻿/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/**
 * Our car will track a reticle and collide with a <see cref="PackageBehaviour"/>.
 */
public class CarBehaviour : MonoBehaviour
{
    public ReticleBehaviour Reticle;
    public float Speed = 1.2f;
    public int Pontuacao = 0;
    public  TextMeshProUGUI pontuacaoTexto;


    private void Start()
    {
        pontuacaoTexto = GameObject.Find("pontuacaoTexto").GetComponent<TextMeshProUGUI>();
        pontuacaoTexto.text = "Pontos: " + Pontuacao.ToString();
    }
    private void Update()
    {
        var trackingPosition = Reticle.transform.position;
        if (Vector3.Distance(trackingPosition, transform.position) < 0.1)
        {
            return;
        }

        var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.position =
            Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("+10"))
        {
            Pontuacao = + 10;

        }

        if (other.gameObject.CompareTag("+20"))
        {
            Pontuacao = +20;

        }


        if (other.gameObject.CompareTag("+30"))
        {
            Pontuacao = +30;

        }


        if (other.gameObject.CompareTag("+40"))
        {
            Pontuacao = +40;

        }



       if(Pontuacao == 100) {
            SceneManager.LoadScene("TelaVitória");
        }
       pontuacaoTexto.text = "Pontos: " + Pontuacao.ToString();
        Destroy(other.gameObject);

        if(Pontuacao >= 100)
        {
            SceneManager.LoadScene("TelaVitoria");
        }
        else if(other.gameObject.CompareTag("Obstaculo")){
            SceneManager.LoadScene("TelaDerrota");

        }


    }
}
