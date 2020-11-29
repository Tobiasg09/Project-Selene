VAR asked_question = false

ME: Hi there. Still working?
MEI: Not really - just cleaning everything up. Helps me cope I guess.
->Divert1

==Divert1
{
    -asked_question == false:
        MEI: Anything you wanted to ask?
    -else:
        MEI: Anything else you wanted to ask?
}
    * [Whereabouts this morning] ME: I was wondering where you were this morning.
        MEI: What do you mean? In the lab of course. Trying to fix up this nitrogen issue, which you helped me with in the afternoon.
        MEI: My entire lab personnel can confirm this.
        MEI: Where were you in the morning?
        ME: Errm. Sleeping.
        ~asked_question = true
        ->Divert1
    
    
    * [About Andy] ME: I was wondering, what do you think of Andy?
        MEI: That's an odd question. I think he's a nice, hardworking guy. Sometimes forgetful. I suspect Charlotte of having a crush on him. Why?
        ME: Nothing, just wondering. Not sure I should trust him.
        MEI: Depends with what, I guess.
    ~asked_question = true
    ->Divert1
    
    
    * [About quantum core] ME: You are aware that a quantum core was found in your room?
        MEI: Yeah, I heard about that. Extremely odd. 
        ME: Any idea on how it ended up there?
        MEI: I have no clue. Guess I should be more careful with locking my door in the future.
        ME: In the next 48 hours, you mean.
        MEI: Thanks for reminding me.
    ~asked_question = true
    ->Divert1
    
    
    * [Leave] ME: No that's all, thanks.
        ->END
 
    