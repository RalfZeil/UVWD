extends CharacterBody2D

# REFERENCES
@onready var standingCollision = $"Standing Collision"
@onready var crouchingCollision = $"Crouching Collision"

@onready var animatedSprite2D = $AnimatedSprite2D

const SPEED = 300.0
const JUMP_VELOCITY = -400.0

var isCrouching: bool = false

# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func UpdateAnimations():
	if(isCrouching):
		animatedSprite2D.play("Crouching")

func SwitchCollisions(_isCrouching):
	standingCollision.disabled = _isCrouching
	crouchingCollision.disabled = !_isCrouching

func _physics_process(delta):
	# Add the gravity.
	if not is_on_floor():
		velocity.y += gravity * delta

	# Handle jump.
	if Input.is_action_just_pressed("Up") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	if Input.is_action_pressed("Down"):
		isCrouching = true;
		SwitchCollisions(isCrouching)
	else:
		isCrouching = false;
		SwitchCollisions(isCrouching)
		
	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction = Input.get_axis("Left", "Right")
	if direction && !isCrouching:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()
	UpdateAnimations()
