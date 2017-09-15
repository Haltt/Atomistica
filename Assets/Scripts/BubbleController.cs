/* Classe BubbleController
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia o canhao e tiros
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BubbleController : MonoBehaviour {
	public Rigidbody2D[] tiro; //atomos a serem atirados
	public int numAtomos = 0; //Numero de atomos (sorteio)
	public bool isAlvo; //Libera o Tiro

	public GameObject comb; //Mensagem do Isobaro
	public GameObject textPlacar; //Pontuaçao
	public GameObject textLigacoes; //Ligacos

	public GameObject restartDialog; //Caixa de Dialogo (Reiniciar Level / Sair)
	public GameObject sucessDialog; //Caixa quando o jogador consegue seu objetivo
	public GameObject scoreFinal; //Pontuacao Final na Tela
	public int tempoGame; //Tempo de duraçao do level

	public int pontuacao; //Soma da Pontuacao
	public int score;

	private float mxDelayObjeto = 0.001f;
	private float timeObjeto = 10f;
	private int timeProxTiro = 12; //Tempo para liberar o proximo tiro caso nao acerte nenhum alvo.

	private BubbleShooterController bublleSC; //Classe BubbleShooterController
	private Level1 lv1;

	public bool controle = true; //Controla o clique do mouse para quando terminar o level bloquer o mesmo.
	private bool controleTempo = true; //Controla a caixa de reiniciar/sair para nao aparecer quando o jogo for vencido.

	void Start () {
		Cursor.visible = false; //Oculta o Mouse
		restartDialog.SetActive(false); //Caixa de Dialogo Reiniciar/Sair (Alpha 0)
		sucessDialog.SetActive(false); //Caixa de Dialogo Sucesso (Alpha 0)

		bublleSC = FindObjectOfType (typeof(BubbleShooterController)) as BubbleShooterController;

		lv1 = FindObjectOfType (typeof(Level1)) as Level1;
		lv1.ProximoTiro();
	}

	void Update () {
		tempoGame --; //Tempo decrescente do level

		//Clique do Mouse
		if(Input.GetMouseButton(0) && controle) {
			timeProxTiro --; //Tempo decrescente que libera o proximo tiro
			comb.GetComponent<CanvasGroup> ().alpha = 0; //Caixa conteundo o alerta de formaçao do Isobaro

			if (isAlvo) {
				if(timeObjeto <= mxDelayObjeto) {
					timeObjeto += Time.deltaTime;
					Rigidbody2D tiroInstance; //Instancia o tiro
					tiroInstance = Instantiate (tiro[numAtomos],bublleSC.linhaInicio.position,bublleSC.linhaInicio.rotation) as Rigidbody2D;
					tiroInstance.AddForce(bublleSC.linhaInicio.up * 810);
					isAlvo = false; //Bloqueia o proximo tiro
					lv1.ProximoTiro();
				} else {
					timeObjeto = 0;
				}
			} 

			//Proximo Tiro
			if(timeProxTiro <= 0) {
				isAlvo = true; //Libera o Tiro caso tenha errado
				timeProxTiro = 12;
			}
		}

		//Tempo do Level
		if (tempoGame <= 0 && controleTempo) {
			controle = false;
			Cursor.visible = true;
			restartDialog.SetActive (true);
		} 

		//Vencendo o Level
		if (score >= 10) {
			controleTempo = false;

			if (tempoGame <= 0) {
				controle = false;
				Cursor.visible = true;
				sucessDialog.SetActive (true);
				scoreFinal.GetComponent<Text> ().text = pontuacao.ToString(); //Mostra os pontos na caixa de dialogo
			}
		}
	}

	//Reiniciar o Level
	public void RestartGame() {
		Application.LoadLevel (Application.loadedLevelName);
	}

	//Volta para o Menu Principal
	public void ExitToMenu() {
		Application.LoadLevel ("Menu");
	}
}