VAR storyversion = 1
~storyversion = RANDOM(1,10)

PIOTR: Wanna hear a joke?
    * [Yes] ME: Sure.

    {storyversion == 1:
        PIOTR: What did the Buddhist ask the hot dog vendor?
        PIOTR: "Make me one with everything."
    }
    
    {storyversion == 2:
        PIOTR: What is green and smells like red paint?
        PIOTR: Green paint.
    }
    
    {storyversion == 3:
        PIOTR: Why don't blind people skydive?
        PIOTR: Because it is hella scary for their dogs.
    }
    
    {storyversion == 4:
        PIOTR: Why don't blind people skydive?
        PIOTR: Because it is damn scary for their dogs.
    }
    
    {storyversion == 5:
        PIOTR: What’s the difference between an oral thermometer and a rectal thermometer?
        PIOTR: The taste.
    }
    
    {storyversion == 6:
        PIOTR: What is a light-year?
        PIOTR: The same as a regular year, but with less calories.
    }
    
    {storyversion == 7:
        PIOTR: If you throw a red brick into the blue sea what it will become?
        PIOTR: Wet.
    }
    
    {storyversion == 8:
        PIOTR: What can you never eat for lunch?
        PIOTR: Dinner.
    }
    
    {storyversion == 9:
        PIOTR: What happened when the wheel was invented?
        PIOTR: It caused a revolution.
    }
    
    {storyversion == 10:
        PIOTR: Why can’t you trust atoms?
        PIOTR: They make up everything.
    }
    
    ->END
    
    
    * [No] ME: Sorry, no time.
        ->END