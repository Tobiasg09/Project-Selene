VAR player_name = "Meredith"
VAR asked_a_question = false

ME: Hi Kwame, I wanted to ask you some questions.
KWAME: Of course {player_name}. Anything.
->Divert1

==Divert1
{ 
    -asked_a_question == false:
        KWAME: What can I help you with?
    -else:
        KWAME: Anything else you wanted to ask?
}

    + [About Project Selene] ME: Can you tell me a bit about Project Selene?
        KWAME: Of course! Project Selene started all the way back in 2024, in an attempt to promote international collaboration and study the Earth from afar.
        KWAME: It was named after the ancient Greek godess of the Moon. 
        KWAME: However, amid the political turmoil and environmental instability caused by Drump and other major world powers, the focus of Project Selene changed.
        KWAME: We started to focus more on developing technologies to increase sustainability and heal the environment. 
        KWAME: Additionally, more and more people moved to the Moon.
        KWAME: However, this was very expensive, and Drump didn't care much about the environment. To be fair, no one really did, until the Flood of New York in 2036.
            ** [Ask about environment] ME: Crazy that nobody cared about the enviroment.
            KWAME: It becomes even crazier when you realise that scientists knew that we had to do something about the environment several decennia before! 
            KWAME: But back then the primary economical philosophy was capitalism. And solving the environmental crisis didn't have any short term gains.
            KWAME: People thought a tree was only profitable when it is cut down, so it can be sold. Despicable.
            KWAME: If only trees produced oil instead of the air we need to breathe.
            KWAME: I believe it was 2037 when the last polar ice caps melted. In 2038, there were an unimaginable amount of environmental refugees in the world.
            KWAME: By the end of the 2030's, more people were displaced by the environment than not. 
            ** [Nod] ME: I heard from my parents that New York used to be a huge city?
                KWAME: Yeah, it was. It used to be one of the biggest cities in the world.
        --
        KWAME: Anyway, Drump cut funding for Project Selene in 2031, and after Europe collapsed in 2033, Project Selene was abandoned, leaving us stranded here.
        KWAME: Most of us didn't have a home to go back to, so we just stayed up here, continuing with our environmental research.
        ~asked_a_question = true
        ->Divert1
        
        

    + [About the State] ME: Can you tell a bit more about the State?
        KWAME: Sure! Well, this win would make it Drump's 7th term. He first got into power exactly 30 years ago, in 2016.
        KWAME: Did you know he actually lost power for a bit in 2020? Historians agree that that election was the State's last free one.
        KWAME: Although Drump himself claims that is the only one that was fake though. The irony.
        KWAME: Anyway, Drump lost the election in 2020 and only got put back in power in 2022 after the Evangelical Revolution. 
            ** [Evangelical Revolution?] ME: What do you mean with the evangelical revolution? I'm not too familiar with Earth politics around this time. 
                KWAME: Well, Evangicalism, now considered an extreme interpretation of Christianity, was the religion of Drump's main supporters back then.
                KWAME: They're weren't too happy that Drump lost the 2020 election. Drump kept edging them on until they stormed the White House.
                KWAME: And you know, Drump has been in power ever since. 
            ** [Nod] ME: Oh yeah, my dad used to tell me about that. It was supposed to be a huge massacre.
                KWAME: That it was..
            -- 
        KWAME: Anyway. In 2026 Drump amended the State constitution of the first time, allowing him to run for president again.
            ** [Didn't anyone object?] ME: Didn't anyone rise up to him? How could this have happened?
                KWAME: Of course people did. That's also when California attempted to secede. It didn't work out obviously, Drump just sent the army to occupy them.
            ** [Nod] ME: That's insane.
            -- 
        KWAME: That's also about when Drump started to show his love for annexing territories. It started with British Columbia in 2027...
        KWAME:... and it just spiralled out of control since then. Did you know the State now consists of 64 individual states?
        KWAME: Not much later he renamed the country to 'The State', which kind of reflects how he thinks about the rest of the world.
        ME: That's so terrifying. Kind of happy I'm up here now.
        ~asked_a_question = true
        ->Divert1
            
            
    + [About nuclear fallout] ME: How come there is so much nuclear fallout on Earth?
        KWAME: Well, it started when Drump was withdrawing the State from many international nuclear deals which banned the use and development of nuclear weapons.
        KWAME: I think the first nuke was Paris in '33.
        ME: How come?
        KWAME: That was during the first Euro-State war. After Drump annexed his 5th territory, Europe united and decided it couldn't stand by while Drump terrorised the world.
        KWAME: However, they didn't anticipate Drump's trigger finger. The war only lasted two weeks. 
        KWAME: Drump bombed the hell out of Paris and sent Europe straight back to the middle ages. Europe only recently started to recover again.
        ~asked_a_question = true
        ->Divert1
        
    + [Leave] ME: It was nice talking to you, Kwame. Thanks.
        KWAME: Any time!
        ->END   
        
            //+ [Ask about Project Selene]
    
    
    
    
    
    
    //todo + [What happened to Paris?]
    //+ [Evangelical Revolution?]