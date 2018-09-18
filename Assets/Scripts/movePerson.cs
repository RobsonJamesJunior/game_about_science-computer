﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePerson : MonoBehaviour {

    CharacterController objetoCharControler;
	float giro = 300.0f;
	Vector3 vetorDirecao = new Vector3(0,0,0);
	float velocidade = 5.0f;
	private float pulo = 5.0f;
	
	public GameObject jogador;
	public Animation animacao;

	// Use this for initialization
	void Start () {
		objetoCharControler = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * velocidade;
		transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * giro * Time.deltaTime,0));
		objetoCharControler.Move(forward * Time.deltaTime);
		objetoCharControler.SimpleMove(Physics.gravity);

		if (Input.GetButton("Jump")){
			if(objetoCharControler.isGrounded == true) {
				vetorDirecao.y = pulo;
				jogador.GetComponent<Animation>().Play("Pulando");			
			}
		} else {
			if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
				if (!animacao.IsPlaying("Pulando")){
					jogador.GetComponent<Animation>().Play("Andando");
				}
			} else {
				if(objetoCharControler.isGrounded == true) {
					jogador.GetComponent<Animation>().Play("Parado");		
				}
			}
		}

		vetorDirecao.y -= 3.0f * Time.deltaTime;
		objetoCharControler.Move(vetorDirecao * Time.deltaTime);

	}
}
