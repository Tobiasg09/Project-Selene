VAR player_name = "Meredith"

VAR pronoun = "her"

{player_name == "Marvin":
    ~pronoun = "him"
}

ME: This is Charlotte's diary. I should definitely not be reading this.
    
    * [Read] ME: What she doesn't know won't hurt her..
        ->Divert1
    * [Put down] ME: Got to respect her privacy.
        ->END
    
    
    
== Divert1
        ME: Let's see..
            ++ [3 Nov] ME: "Andy was being so cute today! He asked me whether I wanted to go on a date with him some time next week!"
                ME: "He proposed to go see the landing site of Apollo 11! How exciting!"
                ->Divert1
            ++ [4 Nov] ME: "Terrible day. I had a big argument with {player_name}. Urgh, sometimes I just really can't stand {pronoun}."
                ME: ... Thanks, Charlotte.
                ->Divert1
            ++ [5 Nov] ME: "Drank a bit too much last night. Hope I didn't do anything stupid."
                ->Divert1
            ++ [6 Nov] ME: "Today is the big day! We'll know who won the presidential election in the State! Although I already think I know.."
                ME: Huh.
                ->Divert1
                
            ++ [Put down] ME: Got to respect her privacy.
                ->END
    