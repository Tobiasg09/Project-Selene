VAR player_name = "INPUT PLAYER NAME"
VAR victimName = "Mei"
VAR victimGender = "ZZ"

VAR hasEvacuated = false

VAR notVictim1 = ""
VAR notVictim2 = ""
VAR notVictim3 = ""

{   victimName == "Mei":
        ~victimGender = "she"
        ~notVictim1 = "PIOTR"
        ~notVictim2 = "ANDY"
        ~notVictim3 = "KWAME"
}

{   victimName == "Piotr":
        ~victimGender = "he"
        ~notVictim1 = "ANDY"
        ~notVictim2 = "KWAME"
        ~notVictim3 = "MEI"
}

{   victimName == "Andy":
        ~victimGender = "he"
        ~notVictim1 = "KWAME"
        ~notVictim2 = "MEI"
        ~notVictim3 = "PIOTR"
}

{   victimName == "Kwame":
        ~victimGender = "he"
        ~notVictim1 = "MEI"
        ~notVictim2 = "PIOTR"
        ~notVictim3 = "ANDY"
}

VAR star = "*"

{notVictim1}: What's all this noise?
ME: How could you?!
PRISHA: What's happening?
ME: Tell them! Tell them what you told me!
CHARLOTTE: I'm really sorry!
{notVictim2}: I'm confused.
CHARLOTTE: It's about {victimName}. I wanted to tell you that {victimGender} is innocent.
CHARLOTTE: I disabled the quantum core, not {victimName}.
{notVictim3}: WHAT?! How could you? We almost died for you!
ME: {victimName} actually did die for you! I killed an innocent person!
PRISHA: That's impossible..
ME: Why did you do it?
CHARLOTTE: I didn't know Drump would fire a missile! I'm sorry!
{notVictim1}: What do you mean?
CHARLOTTE: You know, my family still lives in British Columbia right?
CHARLOTTE: I got a message from the State a week ago - saying that Britsh Columbia would vote against Drump. It was all a setup.
CHARLOTTE: The message said that Drump would order a revenge strike on BC and that the only way to stop it was for me to disable this quantum core..
CHARLOTTE: {star}sniffing{star}
CHARLOTTE: I didn't ask any questions - how could I? My family was in danger! I was only following orders..
CHARLOTTE: And I certainly never suspected any attack on our damn section! I'm so sorry everyone.. I feel so guilty for {victimName}..
PRISHA: As you should. I can't believe it. This has never happened before. We will proceed with appropriate punishment immediately.
    * [Interrupt] ME: Wait! 
        PRISHA: What is it, {player_name}?
            ** [Mention State base] ME: This might sound crazy, but hear me out.
                ME: Alyssa and I found something strange on the surface. We think it's an old State base.
                ME: If Charlotte was working together with the State, she might know more about it! We should hear her out first.
                ->ScientistTalk
            
            ** [Never mind] ME: ... I'm not sure. I guess I just feel bad for Charlotte.
                ->StayQuiet
    
    * [Stay quiet] ME: ...
        ->StayQuiet
    
==StayQuiet
ALYSSA: Hold up. If Charlotte worked with the State, perhaps she knows more about the base we discovered, {player_name}?
PRISHA: What? You've found a State base? On the lunar surface?
ME: Yeah we did. About 50 miles east of here.
->ScientistTalk


==ScientistTalk
SCIENTIST: A State base? Shit, this might be it! You might have saved us all!
ME: Who?
SCIENTIST: I've identified the type of missile that Drump fired. It's a BAMF-42. They're especially manoeuvrable and highly effective.
PRISHA: And how is this good news?
SCIENTIST: Because I helped develop them, before I was assigned to Project Selene!
SCIENTIST: If I can connect to it, I can reprogram its course so that it doesn't hit us!
{notVictim1}: WHAT ARE YOU WAITING FOR?!
SCIENTIST: Because in order to connect to it, I need a long-range transmitter with State access codes.
SCIENTIST: The long-range transmitter is not hard to make - the State access codes are. But maybe.. They can be found in the State that base you uncovered?
CHARLOTTE: Actually.. I knew about this base before, and I have good and bad news.
CHARLOTTE: The good news is that I know that they have a communication facility, which should have State access codes.
CHARLOTTE: The bad news is that it is still an active base, built to monitor us..
ME: So we'll have to sneak in and take the access codes.
PRISHA: That'll be dangerous. Who will be able to do this?
    *[Me!] ME: I'll do it. I've got nothing to lose.
        PRISHA: Are you sure?
        ME: Yeah, trust me. I'm an Engineer.
        CHEMIST: Only a Bio-Engineer.. Just saying.
        PRISHA: It is decided.
        
    *[Stay silent] ME: ...
        PRISHA: Any volunteers?
        {notVictim2}: ...
        CHARLOTTE: ...
        EVERYBODY: ...
        CHEMIST: {player_name} can do it!
        ME: What?
        CHEMIST: {player_name} sneaked in our lab earlier and stole some nitrogen. We only realised a couple of hours later, when we intended to use it.
        ME: Not cool.
        CHEMIST: So {player_name} has plenty of experience sneaking around.
        PRISHA: It is decided.
        ME: Why do I have to do everything here? I'm only a Bio-Engineer!
-


PRISHA: Before you leave, we have another matter that we should settle first. 
PRISHA: The other sections haven't been shot at yet, so we can assume we are Drump's first target.
PRISHA: This also means that we have the option to evacuate this section. Sections 23, 37 and 59 are close enough for us to go to, if we start evacuating people now.
SCIENTIST: Wait - what is the point of retrieving the access codes if we're forfeiting the building anyway and evacuating everyone?
PRISHA: We wouldn't evacuate everyone - I will stay behind together with anyone else that is necessary for this plan to succeed. 
SCIENTIST: That is still too much! We need everyone to help build this transmitter while {player_name} is gone! Every additional pair of hands will be helpful.
PRISHA: That's annoying. So the choice is either to evacuate, but risk not being able to complete the transmitter in time...
PRISHA: ... or not evacuate to make sure it is finished in a timely manner. What should we do?
    * [Evacuate] ME: I think it's safer to evacuate. We don't even know if I can actually find the State's access codes.
        PRISHA: I see everyone nodding. Then it's decided, we will start evacuating the building immediately. 
        PRISHA: Only a handful of people should remain to work on the transmitter while {player_name} is stealing the access codes.
        ~hasEvacuated = true
    
    * [Not evacuate] ME: What's the point of me risking my neck while robbing a high-tech State base if the transmitter is not ready when I return?
        ME: I don't think we should evacuate. Everyone should work on building the transmitter.
        PRISHA: I see everyone nodding. Then it is decided, we will not evacuate and focus all our efforts on building this transmitter.
        ~hasEvacuated = false
        
-
PRISHA: Any other questions before we start?
SCIENTIST: I hate to be that guy.. But what if this doesn't work?
PRISHA: If what doesn't work?
SCIENTIST: This crazy moonshot idea to divert a missile shot by Drump using access codes that we have to steal by sneaking into a highly secured State base...
SCIENTIST: ... which, in addition, may not even be there. 
SCIENTIST: If that doesn't work, what then? Shouldn't we at least make sure that, if we all die and this whole base is destroyed, it is not in vain?
ME: What do you mean?
SCIENTIST: We have all the evidence right here that Drump fired this missile and intends to kill us.  We have logs, missile trajectories, ...
SCIENTIST: I propose that, before we do anything else, we send that data to all the remaining governments on Earth, so that nobody can deny that Drump killed us.
PRISHA: I can appreciate your sentiment. But time is of the essence. We only have a couple of hours left before impact.
PRISHA: Trying to stay alive is more important than telling people how we died.
    * [Agree] ME: I'm afraid Prisha is right.
    SCIENTIST: Well.. If anyone changes their mind, come find me in the maintenance room.
    
    * [Disagree] ME: I actually think he has a point. If we all die, we need to make sure that Drump is held accountable.
        PRISHA: Hmm. If you really think that, better help him before you leave for the State Base. And do it quick.
        PRISHA: But I urge you not to waste time.
        SCIENTIST: Come find me in the maintenance room if you want to help me.


-
PRISHA: I'm happy we have a plan. Everyone, get to it.
->END

