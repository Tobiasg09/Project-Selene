VAR asked_question = false

ME: Hi there!
CHARLOTTE: I can't believe it! How can Drump do this?
ME: Everybody is wondering the same thing.
ME: Can I ask you something?
->Divert1

==Divert1
{
    -asked_question == false:
        CHARLOTTE: Of course! Anything.
    -else:
        CHARLOTTE: Anything else that you wanted to ask me?
}

    * [About quantum core] ME: Andy told me he was talking with you this morning about the backup generator failing?
        CHARLOTTE: What? Oh right, yeah he mentioned something like that. Why?
        ME: So you haven't given it much thought since? 
        CHARLOTTE: Uhm, not really no, I don't think so.
        
    ~asked_question = true
    ->Divert1
    
    
    * [About Piotr and Andy] ME: Piotr and Andy don't seem to get along very well.
        CHARLOTTE: That's an understatement. Piotr always thought Andy wasn't cut out for the job of head electrician. 
        CHARLOTTE: Rumour has it that Piotr was going to get that job, but Prisha decided last-minute against him.
        ME: I see..
    ~asked_question = true
    ->Divert1
    
    * [About Mei] ME: What do you think about Mei?
        CHARLOTTE: I don't think much about her. I don't see her a lot. We work in different departments and never really cross paths.
        ME: Would you suspect her of sabotaging this section?
        CHARLOTTE: Wait, wwwhat? You think someone sabotaged something?
        ME: Never mind.
    ~asked_question = true
    ->Divert1
    
    
    
    * [Leave] ME: No that's everything, thanks Charlotte.
        ->END
 
    