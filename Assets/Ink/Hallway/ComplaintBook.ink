VAR storyversion = 1
~storyversion = RANDOM(1,4) 

ME: "Formal complaint book". Do I want to write something down?
    * [Yes] ME: Of course! Let's see..
    
    {storyversion == 1:
        ME: "The.. hall.. needs.. better.. decoration.."
        ME: There we go.
    }
    
    {storyversion == 2:
        ME: "The.. food.. is.. terrible.."
        ME: There we go.
    }
    
    {storyversion == 3:
        ME: "These.. chemists.. are.. ********.."
        ME: There we go.
    }
    
    {storyversion == 4:
        ME: "Stop.. looping.. the.. same.. music.. all.. the.. time.."
        ME: There we go.
    }

    
        ->END
    
    
    *[No] ME: No, everything is perfect.
        ->END