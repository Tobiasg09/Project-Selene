VAR alcohol = false
VAR player_name = "Meredith"

ME: Is the bar still open? I need to drown my sorrows.
BARTENDER: Of course. If there was ever a time for bars to be open, it is now.
ME: Great.
    * [Order beer] ME: Give me some beer. 
        BARTENDER: Luna is good?
        ME: Yeah, anything.
        ~alcohol = true
    
    * [Order lemonade] ME: Some lemonade would be nice.
        BARTENDER: You're going to drown sorrows with lemonade?
        ME: I'm not paying you to be witty. 
        BARTENDER: Here you go.
    
    * [Order tequila shots] ME: I need something strong. Do you have tequila shots?
        BARTENDER: Of course. Here you go.
        ~alcohol = true
        
-
{ -alcohol:
ME: ...
    ME: Uurgh, I don't feel very well. 
    ME: The world is spinning.. Is it the alcohol or the terrible news?
}

ANDY: {player_name}! Can I talk to you for a second?