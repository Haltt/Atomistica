/* Classe AtomoNitrogenio
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia o que acontece com o alvo e o tiro quando se chocam.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AtomoNitrogenio : MonoBehaviour {
	private ProgressoLevel1 status;
	private BubbleController bubbleContr;
	
	void Start () {
		bubbleContr = FindObjectOfType (typeof(BubbleController)) as BubbleController;
	}
	
	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Atomo_C") {
			status = GameObject.FindGameObjectWithTag("Status").GetComponent<ProgressoLevel1>() as ProgressoLevel1;
			status.Pontuacao(); //Chama a funçao de pontuaçao e soma a mesma.
			Destroy(gameObject); //Destroi o Alvo
			Destroy(colisor.gameObject); //Destroi o Tiro
			bubbleContr.isAlvo = true; //Libera o proximo Tiro
			bubbleContr.comb.GetComponent<CanvasGroup> ().alpha = 1; //Mensagem de Acerto
			bubbleContr.pontuacao += 14; //Valor da Ligaçao
			bubbleContr.textPlacar.GetComponent<Text> ().text = bubbleContr.pontuacao.ToString(); //Mostra a Pontuaçao na Tela
		}
	}
}
