/* Classe Limites
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia o limite onde o tiro pode bater ou ser destruido
*/

using UnityEngine;
using System.Collections;

public class Limites : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Atomo_K") {
			Destroy(colisor.gameObject);
		}

		if (colisor.gameObject.tag == "Atomo_N") {
			Destroy(colisor.gameObject);
		}

		if (colisor.gameObject.tag == "Atomo_C") {
			Destroy(colisor.gameObject);
		}

		if (colisor.gameObject.tag == "Atomo_Ca") {
			Destroy(colisor.gameObject);
		}

		if (colisor.gameObject.tag == "Atomo_Ar") {
			Destroy(colisor.gameObject);
		}
	}
}
