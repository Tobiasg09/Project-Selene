//Create a variable that is immediately randomised to generate a random story

VAR storyversion = 1
~storyversion = RANDOM(1,6)



{storyversion == 1:
    CHEMIST: Hey! You there! What are you doing?
}

{storyversion == 2:
    CHEMIST: Excuse me! You shouldn't be here.
}

{storyversion == 3:
    CHEMIST: Wait, you are not a chemist?
}

{storyversion == 4:
    CHEMIST: Amanda, could you give me the dihydrogen monoxide?
    ME: ...
    CHEMIST: Wait, you're not Amanda.
}


{storyversion == 5:
    CHEMIST: No running in the lab!
}

{storyversion == 6:
    CHEMIST: Get out of here!
}