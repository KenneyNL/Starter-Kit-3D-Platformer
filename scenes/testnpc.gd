extends Node3D

var player_in_range = false

func _on_area_3d_body_entered(body):
	if body.is_in_group("player"):
		player_in_range = true
		body.current_npc = self
		
		if body.coins >= 3 and !body.dialogue_triggered:
			body.dialogue_triggered = true
			Dialogic.start("maintimeline")

func _on_area_3d_body_exited(body):
	if body.is_in_group("player"):
		player_in_range = true
		body.current_npc = null

func _process(delta):
	if player_in_range and Input.is_action_just_pressed("interact"):
		start_dialogue()

var is_talking = false

func start_dialogue():
	if is_talking:
		return

	is_talking = true
	Dialogic.start("npc_timeline")
	
	Dialogic.timeline_ended.connect(_on_dialogue_ended)
	
func _on_dialogue_ended():
	is_talking = false

const SPEED = 5.0
const JUMP_VELOCITY = 4.5

var player_in_area = false

var is_roaming = true
var is_chatting = false

func _physics_process(delta: float) -> void:
	pass
	
