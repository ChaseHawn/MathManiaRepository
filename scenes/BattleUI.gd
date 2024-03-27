extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	$Textbox1.hide()
	display_text("The battle starts")
	
func _input(event):
	if Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT) and %Textbox1.visible:
		%Textbox1.hide()

func display_text(text):
	$Textbox1.show()
	$Textbox1/LabelText.text = text

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
