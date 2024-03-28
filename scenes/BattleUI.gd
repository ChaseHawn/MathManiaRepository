extends Control

signal textbox_closed

@export var enemy: Resource
# Called when the node enters the scene tree for the first time.
func _ready():
	set_health($Playercontainer/PlayerHP,State.current_health, State.max_health)
	set_health($Enemy1container/Enemy1HP,enemy.health,enemy.health)
	
	$Textbox1.hide()
	$OptionsPanel.hide()
	display_text("The battle starts")
	await self.textbox_closed
	%OptionsPanel.show()
	
func set_health(progress_bar, current_health, max_health):
	progress_bar.value = current_health
	progress_bar.max_value = max_health
	progress_bar.get_node("Label").text = "HP: %d/%d" % [current_health, max_health]
	pass

func _input(event):
	if Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT) and %Textbox1.visible:
		%Textbox1.hide()

func display_text(text):
	$Textbox1.show()
	$Textbox1/LabelText.text = text

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _on_textbox_1_hidden():
	emit_signal("textbox_closed")
	pass # Replace with function body.
