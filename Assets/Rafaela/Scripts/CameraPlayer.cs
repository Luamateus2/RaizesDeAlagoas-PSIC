using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

	private Transform player;
	public float velocidade = 4f;

	// Use this for initialization
	void Start() {
		player = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update() {
		Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);
		Debug.Log(novaPosicao);
		transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.deltaTime * velocidade);
	}
}
