extends Node3D

var falling := false
var fall_velocity := 0.0

func _physics_process(delta):
	scale = scale.lerp(Vector3(1, 1, 1), delta * 10) # Animate scale
	
	if falling:
		fall_velocity += 15.0 * delta
		position.y -= fall_velocity * delta
	else:
		fall_velocity = 0.0
	
	if position.y < -10:
		queue_free() # Remove platform if below threshold

func _on_body_entered(_body):
	if !falling:
		Audio.play("res://sounds/fall.ogg") # Play sound
		scale = Vector3(1.25, 1, 1.25) # Animate scale
		
	falling = true
