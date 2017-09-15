/* Classe Level1
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia o Level 1
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1 : MonoBehaviour {
	public Sprite[] Images;

	private BubbleController bublleCont; //Classe BubbleShooterController

	void Start () {
		bublleCont = FindObjectOfType (typeof(BubbleController)) as BubbleController;
		bublleCont.numAtomos = 0;
	}

	public void ProximoTiro () {
		bublleCont.numAtomos = Random.Range (0, 5); //Define o proximo atomo a ser atirado
		this.transform.GetComponent<Image> ().sprite = Images [bublleCont.numAtomos];
	}
}
