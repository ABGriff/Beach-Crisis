#pragma strict

var speed = float; //Rotation speed of gun
var zdepth: float;


function Update() {
    var x = Input.mousePosition.x;
    var y = Input.mousePosition.y;
    var mousePosition = Camera.main.ScreenToWorldPoint(Vector3(x, y, zdepth));
    var rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

    transform.rotation = rot;




   //var x = Input.GetAxis("Mouse X") * Time.deltaTime * speed; //controls horizontal movement of gun
   //var y = Input.GetAxis("Mouse Y") * Time.deltaTime * speed; //controls vertical movement of gun
   // transform.Rotate(-y, x, 0);
}
