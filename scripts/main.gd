extends Node3D


func _ready() -> void:
	Dialogic.start("maintimeline")
	if RenderingServer.get_current_rendering_method() == "gl_compatibility":
		# Reduce background and sun brightness when using the Compatibility renderer;
		# this tries to roughly match the appearance of Forward+.
		# This compensates for the different color space and light rendering for lights with shadows enabled.
		$Sun.light_energy = 0.24
		$Sun.shadow_opacity = 0.85
		$Environment.environment.background_energy_multiplier = 0.25


func _on_chat_detect_body_entered(body: Node3D) -> void:
	pass # Replace with function body.


func _on_area_2_body_entered(body: Node3D) -> void:
	pass # Replace with function body.


func _on_area_uno_body_entered(body: Node3D) -> void:
	pass # Replace with function body.
