/* Classe ProgressoLevel1
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia a barra de pontuaçao
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressoLevel1 : MonoBehaviour {
	private int status;
	private int contador;

	private BubbleController bubbleContr;

	public Sprite[] Images;
	
	void Start () {
		status = 11;
		bubbleContr = FindObjectOfType (typeof(BubbleController)) as BubbleController;
	}

	public bool Pontuacao() {
		if (contador < (status - 1)) {
			contador += 1;
			bubbleContr.score += 1;
			//this.transform.GetComponent<Image> ().sprite = Images [contador];
			bubbleContr.textLigacoes.GetComponent<Text> ().text = contador.ToString(); //Mostra os nº de ligaçao na Tela
			return true;
		} else {
			return false;
		}
	}
}
