extends Node3D

var falling := false
var gravity := 0.0

func _process(delta):
	scale = scale.lerp(Vector3(1, 1, 1), delta * 10) # Animate scale
	
	position.y -= gravity * delta
	
	if position.y < -10:
		queue_free() # Remove platform if below threshold
	
	if falling:
		gravity += 0.25


func _on_body_entered(_body):
	if !falling:
		Audio.play("res://sounds/fall.ogg") # Play sound
		scale = Vector3(1.25, 1, 1.25) # Animate scale
		
	falling = true
