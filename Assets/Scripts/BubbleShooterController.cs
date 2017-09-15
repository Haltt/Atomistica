/* Classe BubbleShooterController
 * @author: Wanderson Teixeira de Souza
 * @version: 1.0
 * @copyright: Wanderson Teixeira de Souza ME (wandersonteixeira.com.br)
 * @description: Gerencia o canhao e seus movimentos
*/

using UnityEngine;
using System.Collections;

public class BubbleShooterController : MonoBehaviour {

	public bool isAiming;
	
	private float rotationSpeed = 80.0f;
	private float maxLeftAngle = 85.0f;
	private float maxRightAngle = 275.0f;

	public Transform linhaInicio;
	public Transform linhaFim;

	private BubbleController bublleC; //Classe BubbleShooterController

	void Start () {
		isAiming = true;
		bublleC = FindObjectOfType (typeof(BubbleController)) as BubbleController;
	}
	
	void Update () {
		Debug.DrawLine (linhaInicio.position, linhaFim.position, Color.red);

		if (isAiming && bublleC.controle) {
			float mouseAxisX = Input.GetAxis ("Mouse X");
			transform.Rotate (Vector3.back * mouseAxisX * this.rotationSpeed * Time.deltaTime);
			if (transform.eulerAngles.z > this.maxLeftAngle && transform.eulerAngles.z < 180.0) {
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, maxLeftAngle);
			}
			if (transform.eulerAngles.z < this.maxRightAngle && transform.eulerAngles.z > 180.0) {
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, maxRightAngle);
			}
		}
	}
}
