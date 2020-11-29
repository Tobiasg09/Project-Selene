VAR player_name = "INPUT PLAYER NAME"
VAR hasEvacuated = false

VAR hasDiverted1 = false


PRISHA: Alright, we've arrived.
ME: I think I can see our section from here.
ME: How long until the missile impact?
SCIENTIST: A matter of seconds now..
{ hasEvacuated == false:
    PRISHA: No! Half of our people haven't managed to get out yet! 
}
CHARLOTTE: {player_name}, you still have the controller right?
CHARLOTTE: You can still change your mind about diverting the missile.. Just saying.
ME: Do I press the button to divert the missile?
    * [Press the button] ME: Here goes..
        ~hasDiverted1 = true
    * [Don't press the button] ME: I just can't.
        ~hasDiverted1 = false
-
->END