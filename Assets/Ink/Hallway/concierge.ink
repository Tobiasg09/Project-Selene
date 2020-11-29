VAR player_name = "Meredith"

CONCIERGE: Hi there {player_name}! Hope all is well.
->Divert1

==Divert1
CONCIERGE: What can I help you with?
+ [Directions] ME: I need to ask you about directions.
    ++ [Bar] ME: Can you tell me how to get to the bar?
        CONCIERGE: You just keep going down. Hard to miss.
        ->Divert1
        
    ++ [Maintenance room] ME: I need to get to the maintenance room.
        CONCIERGE: It's just opposite the lobby. You can see it from here.
        ->Divert1
        
    ++ [Living quarters] ME: Where do all the people live?
        CONCIERGE: Just behind me. The entire east wing is dedicated to luxurious apartments. They're connected by a big loop.
        ->Divert1
    
    ++ [Chemistry lab] ME: I need to go to the chemistry lab
        CONCIERGE: That's the westernmost room. Just go up and keep going left. 
        CONCIERGE: They usually don't allow non-chemists to enter though.
        ->Divert1
        
    ++ [Bio-Engineering lab] ME: Can you point me towards the Bio-Engineering lab? 
        CONCIERGE: Don't you work there? Just keep going up and you'll find it.
        ->Divert1
        
    ++ [Greenhouse] ME: I'm not sure where to find the greenhouse.
        CONCIERGE: It's up the ladder in the Bio-Engineering lab.
        ->Divert1
        
    ++ [Lunar surface] ME: How do I go to the lunar surface?
        CONCIERGE: Go through the top-left room. Don't forget to put on your helmet though.
        ->Divert1
        
    ++ [Leave] ME: Thanks!
        ->END
    
+[Leave] ME: Thanks!
    ->END