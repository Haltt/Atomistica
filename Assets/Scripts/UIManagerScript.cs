/* Classe UIManagerScript
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia menus, opçoes e botoes do game em geral
*/

using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {
	public Animator contentPanel;
	public Animator gearImage;

	void Start () {
		RectTransform transform = contentPanel.gameObject.transform as RectTransform;
		Vector2 position = transform.anchoredPosition;
		position.y -= transform.rect.height;
		transform.anchoredPosition = position;
	}

	//Inicia o Game e mostra os leveis disponiveis
	public void StartGame() {
		Application.LoadLevel ("Level");
	}

	//Menu Toggle (Informaçoes, Conquistas, Placar de Lideres)
	public void ToggleMenu() {
		contentPanel.enabled = true;
		bool isHidden = contentPanel.GetBool ("IsHidden");
		contentPanel.SetBool ("IsHidden", !isHidden);

		gearImage.enabled = true;
		gearImage.SetBool ("IsHidden", !isHidden);
	}
}
