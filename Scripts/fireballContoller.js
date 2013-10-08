#pragma strict

var lifeTime =1.0;
//prefab gameobject triggered
function Awake () {
	Destroy(gameObject,lifeTime);
}

function Update () {

}