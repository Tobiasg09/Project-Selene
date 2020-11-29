VAR player_name = "INPUT PLAYER NAME"
VAR victimName = "Mei"
VAR victimGender = "ZZ"

VAR hasEvacuated = false

VAR notVictim1 = ""
VAR notVictim2 = ""
VAR notVictim3 = ""

VAR notVictim1uncap = ""
VAR notVictim2uncap = ""
VAR notVictim3uncap = ""

{   victimName == "Mei":
        ~victimGender = "she"
        ~notVictim1 = "PIOTR"
        ~notVictim2 = "ANDY"
        ~notVictim3 = "KWAME"
        ~notVictim1uncap = "Piotr"
        ~notVictim2uncap = "Andy"
        ~notVictim3uncap = "Kwame"
}

{   victimName == "Piotr":
        ~victimGender = "he"
        ~notVictim1 = "ANDY"
        ~notVictim2 = "KWAME"
        ~notVictim3 = "MEI"
        ~notVictim1uncap = "Andy"
        ~notVictim2uncap = "Kwame"
        ~notVictim3uncap = "Mei"
}

{   victimName == "Andy":
        ~victimGender = "he"
        ~notVictim1 = "KWAME"
        ~notVictim2 = "MEI"
        ~notVictim3 = "PIOTR"
        ~notVictim1uncap = "Kwame"
        ~notVictim2uncap = "Mei"
        ~notVictim3uncap = "Piotr"
}

{   victimName == "Kwame":
        ~victimGender = "he"
        ~notVictim1 = "MEI"
        ~notVictim2 = "PIOTR"
        ~notVictim3 = "ANDY"
        ~notVictim1uncap = "Mei"
        ~notVictim2uncap = "Piotr"
        ~notVictim3uncap = "Andy"
}


VAR hasDiverted0 = false

ME: Everyone! I'm back!
PRISHA: Oh {player_name}! Good to see you, we were assuming the worst had happened.
ME: Yeah, it took longer than expected. Anyway, I got the State access codes!

{ hasEvacuated:
    ME: Has everyone been evacuated succesfully?
    PRISHA: Yeah, everyone has left this section except the people in this room.
    ME: Great.
}

SCIENTIST: I have some bad news though. I've just learned that changing the course of  this missile won't be as easy as I thought, even with the access codes.
PRISHA: What do you mean?
SCIENTIST: It seems like they've updated the model. It's a BAMF-43, not BAMF-42.
SCIENTIST: This upgrade includes a more advanced targetting system. It's preprogrammed to only target buildings with a central heat core.
SCIENTIST: This means I can only divert it to hit another building, not just into nothing. 
CHARLOTTE: Oh no.. I knew this was going too well..
PRISHA: Any ideas?
    * [Run!] ME: Damn it! We should be jumping in all the remaining VL's and get away as fast as we can!
        CHARLOTTE: Wait! Could we divert it to the State base you've uncovered? They should have a central heat core as well!
        PRISHA: Yes! Genius!
        SCIENTIST: I think you're correct. That should work!
    
    * [The State Base!] ME: What about the State base that Alyssa and I found before? Would you be able to redirect it to there?
        PRISHA: Yes! Genius!
        SCIENTIST: I think you're correct. That should work!
-
PRISHA: But.. how many people live in that base though?
ME: It looked fairly big and I only passed through one part of it. I'd estimate that about 500-600 souls can live there.
SCIENTIST: Yeah, our drones confirm heat signatures for about 632 people.
    * [So what?] ME: So what? They're State soldiers. The State is trying to kill us. That's how wars work. Divert the missile already! 
        SCIENTIST: They're just soldiers though. Only following orders, like Charlotte.. I used to work for the State as well before I transferred here.
        SCIENTIST: Most of them probably don't even know about us or the missile..
    
    *[They're innocent!] ME: What we're suggesting is terrible. I know that they are State soldiers, but they're still innocent.
        ME: They're just following orders. Like you, Charlotte.
        CHARLOTTE: I don't care! Are you seriously suggesting to not divert the missile just to save some State soldiers?
        
        
-       
    
{ hasEvacuated:
    SCIENTST: Also, Project Selene sector 59 is only 16 miles north of the State base. They would be inside the blast radius as well. 
    PRISHA: Isn't that where {notVictim3uncap} went with their family?
    SCIENTIST: I think so, yeah.
}

PRISHA: So, what do we do?
CHARLOTTE: I think we should divert the missile.
SCIENTIST: I'm against diverting it. 
PRISHA: {player_name}?
    * [Divert] ME: Give the controller to me! We'll end it right here and now!
        PRISHA: {player_name}! What are you doing?
        SCIENTIST: Oh no! I've detected missile signatures!
        SCIENTIST: It's incoming! Quickly, {player_name}, divert the missile!
        ~hasDiverted0 = true
    
    * [Don't divert] ME: Give the controller to me! We're not going to kill innocent people, we've done that enough already.
        ME: Come on, we need to get everyone out of here as soon as possible!
        PRISHA: Right, come on everyone! Sector 23 is closest to us. Hurry!
        ~hasDiverted0 = false
        
-
->END

