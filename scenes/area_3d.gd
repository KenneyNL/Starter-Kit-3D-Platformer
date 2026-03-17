extends Area3D

func start_dialogue():
	Dialogic.start(dialogue_resource)

@export var dialogue_resource : Resource
var triggered = false

		
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_body_entered(body):
	if body.name == "Player" and !triggered:
		triggered = true
		Dialogic.start("battimeline")
		
		
