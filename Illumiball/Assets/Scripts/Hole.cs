using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string activeTag;

	void OnTriggerStay ( Collider other ){
		// コライダに触れているオブジェクトのRigitbodyコンポーネントを取得
		Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

		// ボールがどの方向にあるかを計算
		Vector3 direction = transform.position - other.gameObject.transform.position;
		direction.Normalize ();

		// タグに応じてボールに力を加える
		if (other.gameObject.tag == activeTag) {
			// 中心地点でボールを止めるために速度を減速させる
			r.velocity *= 0.9f;

			r.AddForce (direction * r.mass * 20.0f);
		} else {
			r.AddForce (-direction * r.mass * 80.0f);
		}
	}
}
