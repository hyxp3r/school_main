/// <summary>
/// Trigger.
/// Ставить на триггер. Записка - дочерний объект у триггера
/// Уничтожает записку и прибавляет +1 к счету записок игрока
/// </summary>
using UnityEngine;
using System.Collections;

public class DestroyPapers : MonoBehaviour {
	
	public GameObject Papers;
	public GameObject player;
	private float direction;
	private bool trigger;
	private bool _visable;
	private GUIPapers gp;
	
	void Awake () {
		Papers = GameObject.Find("Papers");
		player = GameObject.FindGameObjectWithTag("Player");
		gp = GameObject.Find("GUIPapers").GetComponent<GUIPapers>(); //инициализируем поле
	}
	
	void Update () {
		Papers = GameObject.Find("Papers");
		if (trigger) {
			//вычисляем еденичный вектор направления к цели
			Vector3 dir = (Papers.transform.position - player.transform.position).normalized;
			//вычисляем нахождение цели в поле зрения (значение 0 или отриц - сзади. значение 1 или положительное - впереди) значение меняется от 1 до -1
			direction = Vector3.Dot(dir,transform.forward);
			if (direction > 0){
				if (Input.GetKey(KeyCode.E)) {
					if (gp != null)
      				{
         				gp.Papers++;
						gp.TimeDown = 3;
						gp._visable = true;
      				}
					Destroy(gameObject);
				}
			}
		}
	}

	public void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){	
				trigger = true;
				_visable = true;
		}
	}
	
	public void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			trigger = false;
			_visable = false;
		}
	}
	
	void OnGUI () {
		if (_visable) {
			GUI.Label ( new Rect(Screen.width/2,10,180,30), "Enter E");
		}
	}
}