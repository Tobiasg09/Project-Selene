VAR player_name = "Meredith"
VAR n_suspects = 4
VAR name_final_suspect = ""
VAR name_final_suspect_capitalised = ""

VAR isAndy = true
VAR isKwame = true
VAR isMei = true
VAR isPiotr = true


PRISHA: Thank you all for coming here despite the looming threat.
PRISHA: As some may have noticed, this morning the lights went out. 
PRISHA: This is because someone removed the quantum core from the head generator several hours before and the backup generator was starting to fail.
PRISHA: Logs show this was done between 9 and 10 this morning. We are gathering here to uncover the perpetrator of this crime.
PRISHA: The intent behind this crime seems obvious: for us to be without power so that we wouldn't be able to notice that Drump fired a missile headed for us.
PRISHA: Thus, the goal of this hearing is twofold: firstly, to uncover and correctly punish the perpetrator of this crime.
PRISHA: But also, whoever did this might know more about the incoming missile. Maybe we might still be able to stop its impact with their knowledge.
PRISHA: As the stability and safety of this facility were harmed as a direct consequence of this crime, the perpetrator will be charged with high treason.
PRISHA: And as per tradition, the crime for high treason is...
PRISHA: ... death.

PRISHA: The suspects are: Andy, Kwame, Mei and Piotr.
PRISHA: Andy is the head electrician and in charge of maintaining the quantum core, which makes him an obvious suspect.
PRISHA: Kwame was spotted hanging out at the maintenance room at the time of the crime.
PRISHA: Additionally, the core was found in Mei's room. Finally, we all know how Piotr dislikes Andy. Maybe he disabled the core to get back at him.
PIOTR: You're suspecting me cause I don't like Andy? The hell? What about {player_name}, for example?
PRISHA: I'm talking here. 

->Divert1

==Divert1
PRISHA: So, who is guilty?
{ isAndy == true:
    + [Not Andy] ME: It cannot be Andy because he... 
        ++ [was seen by a witness] ME: Andy was seen by a witness during the time of the crime.
            PRISHA: Really? Who was this witness?
            ME: Me! He asked me to go search for the quantum core.
            PRISHA: That means you saw him after the crime was already commited. This does not prove anything.
            ->Divert1
            
        ++ [has no technical skills] ME: doesn't have the required skillset in order to remove the quantum core.
            CHARLOTTE: He's the head electrician though.. 
            PRISHA: Just as Charlotte says. He has the perfect skills for this crime.
            ->Divert1
            
        ++ [has no motivation] ME: his actions don't make any sense. If he had sabotaged and removed the quantum core, then why ask me to find it? 
            ME: He would have no motivation to do so. If not for Andy, we wouldn't have known until much later.
            ME: Also, he was the one to suggest to investigate this more. 
            PRISHA: That does make sense. Alright, Andy, you are cleared of all charges.
            CHARLOTTE: Of course! Andy would never do this!
            ANDY: Thank the lord everyone came to their senses..
            ~isAndy = false
            ->Correct
        ++ [wasn't in the building] ME: he wasn't in the building during the time crime was commited.
            PRISHA: Wait, where was he then? He has no business going outside during work hours.
            ANDY: Prisha is right. I was working in the morning until the election results came in.
            ->Divert1
}
        
    
    
    
    
{ isKwame == true:
    + [Not Kwame] ME: It cannot be Kwame because he... 
        ++ [was seen by a witness] ME: was seen by witnesses this morning!
            PRISHA: Exactly. He was seen around the maintenance room. That's why he is a suspect.
            PRISHA: Let's continue.
            ->Divert1
            
        ++ [has no technical skills] ME: doesn't have the technical skills to pull this off. He's a writer and historian. What does he know about quantum cores?
            CHARLOTTE: Besides, he's so old and doesn't know how to handle technology at all!
            CHARLOTTE: We all saw him struggling to increase the volume on the beamer this morning.
            PRISHA: That seems to make sense.
            ~isKwame = false
            ->Correct
            
        ++ [has no motivation] ME: clearly has no motivation to commit this crime.
            PRISHA: Perhaps I'm judging too hard, but he might.
            PRISHA: He often speaks fondly of his time on Earth. Perhaps he is filled by nostalgia and wants to go back?
            ->Divert1
        ++ [wasn't in the building] ME: was not in our section building when the crime was commited.
            CHARLOTTE: Well I think he actually was. Didn't someone say he was spotted near the maintenance room this morning?
            PRISHA: Exactly. Come on {player_name}, don't start slacking.
            ->Divert1
}


{ isMei == true:
    + [Not Mei] ME: It cannot be Mei because she... 
        ++ [was seen by a witness] ME: was in the lab the entire day.
        MEI: That's correct. My entire lab personnel can vouch for my presence the entire morning.
        PRISHA: Well, that settles that then.
            ~isMei = false
            ->Correct
            
        ++ [has no technical skills] ME: doesn't know how to remove a quantum core.
            MEI: What are you suggesting? Of course I can. I'm your superior, if you can install a quantum core, obviously I can uninstall it.
            MEI: Don't be ridiculous.
            ME: Euhm..
            PRISHA: Right. So Mei remains a suspect.
            ->Divert1
            
        ++ [has no motivation] ME: doesn't have any real motivation to commit this crime. 
            PRISHA: Just because you think she doesn't have any motivation, doesn't mean that she didn't do it. Let's continue.
            ->Divert1
        ++ [wasn't in the building] ME: wasn't in the building this morning.
            MEI: Except that I was. I was working the entire morning.
            PRISHA: Let's keep going.
            ->Divert1
}


{ isPiotr == true:
    + [Not Piotr] ME: It cannot be Piotr because he... 
        ++ [was seen by a witness] ME: was seen by several witnesses that morning.
            PRISHA: Like who? Did anyone see him between 9 and 10?
            PIOTR: Unlikely. I was working outside, alone. 
            PRISHA: So no one to back up your story either.
            ->Divert1
            
        ++ [has no technical skills] ME: doesn't have any training to help him commit this crime. He simply doesn't know how.
            CHARLOTTE: But then again, he is an lunar surface technician and explorer. I image that he could find it out.
            PRISHA: Back to square one.
            ->Divert1
            
        ++ [has no motivation] ME: has no motivation to commit this crime.
            CHARLOTTE: Well.. Everyone knows that Piotr and Andy don't get along.
            PRISHA: Piotr might have sabotaged the quatum core in order to get Andy in trouble. 
            ->Divert1
            
        ++ [wasn't in the building] ME: very simply wasn't in the building. You can check the logs, he left before 8 and only came back around noon, right before the election results.
            PRISHA: That's easy then. Piotr is innocent.
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
PRISHA: So, only one suspect remains.
PRISHA: {name_final_suspect}, why did you do it? What did we ever do to you?

CHARLOTTE: No it cannot be! I'm sure {name_final_suspect} didn't do anything!
PRISHA: Come on Charlotte. {name_final_suspect} is the last remaining suspect. There is no one else.
{name_final_suspect_capitalised}: I didn't do anything! Trust me! I'm innocent!
PRISHA: I really hoped I wouldn't have to do this..
PRISHA: {name_final_suspect}. By the power vested in me as section leader, I sentence you to be guilty for the crime of high treason. 
PRISHA: Your sentence shall be executed de facto immediately. 
{name_final_suspect_capitalised}: NO! I cannot believe this! You all know me! How can you do this to me?
PRISHA: Before you go, you can redeem yourself and tell us if there is anything we can do to stop the missile.
PRISHA: {name_final_suspect}, not all of us have to die.
{name_final_suspect_capitalised}: I swear, I don't know anything! You are all making a mistake!
->END
    
    
    