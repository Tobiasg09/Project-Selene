VAR player_name = "Meredith"
VAR n_suspects = 4
VAR name_final_suspect = ""
VAR name_final_suspect_capitalised = ""

VAR isAndy = true
VAR isKwame = true
VAR isMei = true
VAR isPiotr = true


LEADER: Thank you all for coming here despite the looming threat.
LEADER: As some may have noticed, this morning the lights went out. This is because someone removed the quantum core from the head generator several hours before and the backup generator was starting to fail.
LEADER: Logs show this was done between 9 and 10 this morning. We are gathering here to uncover the perpetrator of this crime.
LEADER: The intent behind this crime seems obvious: for us to be without power so that we wouldn't be able to notice that Drump fired a missile headed for us.
LEADER: Thus, the goal of this hearing is twofold: firstly, to uncover and correctly punish the perpetrator of this crime.
LEADER: But also, whoever did this might know more about the incoming missile. Maybe we might still be able to stop its impact with their knowledge.
LEADER: As the stability and safety of this facility were harmed as a direct consequence of this crime, the perpetrator will be charged with high treason.
LEADER: And as per tradition, the crime for high treason is...
LEADER: ... death.

LEADER: The suspects are: Andy, Kwame, Mei and Piotr.
LEADER: Andy is the head electrician and in charge of maintaining the quantum core, which makes him an obvious suspect.
LEADER: Kwame was spotted hanging out at the maintenance room at the time of the crime.
LEADER: Additionally, the core was found in Mei's room. Finally, Piotr cause XYZ.

->Divert1

==Divert1
LEADER: So, who is guilty?
{ isAndy == true:
    + [Not Andy] ME: It cannot be Andy because he... 
        ++ [was seen by a witness] ME: Andy was seen by a witness during the time of the crime.
            LEADER: Really? Who was this witness?
            ME: Me! He asked me to go search for the quantum core.
            LEADER: That means you saw him after the crime was already commited. This does not prove anything.
            ->Divert1
            
        ++ [has no technical skills] ME: doesn't have the required skillset in order to remove the quantum core.
            CHARLOTTE: He's the head electrician though.. 
            LEADER: Just as Charlotte says. He has the perfect skills for this crime.
            ->Divert1
            
        ++ [has no motivation] ME: his actions don't make any sense. If he had sabotaged and remove the quantum core, then why ask me to find it? 
            ME: He would have no motivation to do so. If not for Andy, we wouldn't have known until much later
            ME: Also, he was the one to suggest to investigate this more. 
            LEADER: That does make sense. Alright, Andy, you are cleared of all charges.
            CHARLOTTE: Of course! Andy would never do this!
            ANDY: Thank the lord everyone came to their senses..
            ~isAndy = false
            ->Correct
        ++ [wasn't in the building] ME: he wasn't in the building during the time crime was commited.
            LEADER: Wait, where was he then? He has no business going outside during work hours.
            ANDY: Leader is right. I was working in the morning until the election results came in.
            ->Divert1
}
        
    
    
    
    
{ isKwame == true:
    + [Not Kwame] ME: It cannot be Kwame because he... 
        ++ [was seen by a witness] ME: was seen by witnesses this morning!
            LEADER: Exactly. He was seen around the maintenance room. That's why he is a suspect.
            LEADER: Let's continue.
            ->Divert1
            
        ++ [has no technical skills] ME: doesn't have the technical skills to pull this off. He's a writer and historian. What does he know about quantum cores?
            CHARLOTTE: Besides, he's so old and doesn't know how to handle technology at all!
            CHARLOTTE: We all saw him struggling to change the channel on the beamer this morning.
            LEADER: That seems to make sense.
            ~isKwame = false
            ->Correct
            
        ++ [has no motivation] ME: clearly has no motivation to commit this crime.
            LEADER: Perhaps I'm judging too hard, but he might.
            LEADER: He often speaks fondly of his time on Earth. Perhaps he is filled by nostalgia and wants to go back?
            ->Divert1
        ++ [wasn't in the building] ME: was not in our section building when the crime was commited.
            CHARLOTTE: Well I think he actually was. Didn't someone say he was spotted near the maintenance room this morning?
            LEADER: Exactly. Come on {player_name}, don't start slacking.
            ->Divert1
}


{ isMei == true:
    + [Not Mei] ME: It cannot be Mei because she... 
        ++ [was seen by a witness] ME: was in the lab the entire day.
        MEI: That's correct. My entire lab personel can vouch for my presence the entire morning.
        LEADER: Well, that settles that then.
            ~isMei = false
            ->Correct
            
        ++ [has no technical skills] ME: doesn't know how to extract 
            MEI: What are you suggesting? Of course I can. I'm your superior, if you can install a quantum core, obviously I can uninstall it.
            MEI: Don't be ridiculous.
            ME: Euhm..
            LEADER: Right. So Mei remain a suspect.
            ->Divert1
            
        ++ [has no motivation] ME: doesn't have any real motivation to commit this crime. 
            ->Divert1
        ++ [wasn't in the building] ME: wasn't in the building this morning.
            MEI: Except that I was. I was working the entire morning.
            LEADER: Let's keep going.
            ->Divert1
}


{ isPiotr == true:
    + [Not Piotr] ME: It cannot be Piotr because he... 
        ++ [was seen by a witness] ME: was seen by several witnesses that morning.
            LEADER: Like who? Did anyone see him between 9 and 10?
            PIOTR: Unlikely. I was working outside, alone. 
            LEADER: So no one to back up your story either.
            ->Divert1
            
        ++ [has no technical skills] ME: doesn't have any training to help him commit this crime. He simply doesn't know how.
            CHARLOTTE: But then again, he is an lunar surface technician and explorer. I image that he could find it out.
            LEADER: Back to square one.
            ->Divert1
            
        ++ [has no motivation] ME: has no motivation to commit this crime.
            CHARLOTTE: Well.. Everyone knows that Piotr and Andy don't get along.
            LEADER: Piotr might have sabotaged the quatum core in order to get Andy in trouble. 
            ->Divert1
            
        ++ [wasn't in the building] ME: very simply wasn't in the building. You can check the logs, he left before 8 and only came back around noon, right before the election results.
            LEADER: That's easy then. Piotr is innocent.
            ~isPiotr = false
            ->Correct
}

    


== Correct
~n_suspects -= 1
    {
    	- n_suspects != 1:
    		->Divert1
    	- else:	
    	    {
        	    - isAndy == true:
        	        ~name_final_suspect = "Andy"
        	        ~name_final_suspect_capitalised = "ANDY"
        	    - isKwame == true:
        	        ~name_final_suspect = "Kwame"
        	        ~name_final_suspect_capitalised = "KWAME"
        	    -isMei == true:
        	        ~name_final_suspect = "Mei"
        	        ~name_final_suspect_capitalised = "MEI"
        	    -isPiotr == true:
        	        ~name_final_suspect = "Piotr"
        	        ~name_final_suspect_capitalised = "PIOTR"
    	    }
    	    ->Divert2
    }
    
    
    
    
== Divert2
LEADER: So, only one suspect remains.
LEADER: {name_final_suspect}, why did you do it? What did we ever do to you?

CHARLOTTE: No it cannot be! I'm sure {name_final_suspect} didn't do anything!
LEADER: Come on Charlotte. {name_final_suspect} is the last remain suspect. There is no one else.
{name_final_suspect_capitalised}: I didn't do anything! Trust me! I'm innocent!
LEADER: I really hoped I wouldn't have to do this..
LEADER: {name_final_suspect}. By the power vested in me as section leader, I sentence you to be guilty for the crime of high treason. Your sentence shall be executed de facto immediately. 
{name_final_suspect_capitalised}: NO! I cannot believe this! You all know me! How can you do this to me?
LEADER: Before you go, you can redeem yourself and tell us if there is anything we can do to stop the missile.
LEADER: {name_final_suspect}, not all of us have to die.
{name_final_suspect_capitalised}: I swear, I don't know anything! You are all making a mistake!
->END
    
    
    