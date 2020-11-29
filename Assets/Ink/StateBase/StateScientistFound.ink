//Create a variable that is immediately randomised to generate a random story

VAR storyversion = 1
~storyversion = RANDOM(1,8)



{storyversion == 1:
    STATE SCIENTIST: Hey! You there! What are you doing?
}

{storyversion == 2:
    STATE SCIENTIST: Excuse me! You shouldn't be here.
}

{storyversion == 3:
    STATE SCIENTIST: Wait, who are you?
}

{storyversion == 4:
    STATE SCIENTIST: Well what do we have here.
}

{storyversion == 5:
    STATE SCIENTIST: Guards!
}

{storyversion == 6:
    STATE SCIENTIST: Get out of here!
}

{storyversion == 7:
    STATE SCIENTIST: How did you get in here?!
}

{storyversion == 8:
    STATE SCIENTIST: Call the guards!
}