/* Classe Level
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia os leveis que estao ativos ou bloqueados
*/

using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public void StartLevelOne() {
		Application.LoadLevel ("Level1");
	}

	public void MenuHome() {
		Application.LoadLevel ("Menu");
	}
}
