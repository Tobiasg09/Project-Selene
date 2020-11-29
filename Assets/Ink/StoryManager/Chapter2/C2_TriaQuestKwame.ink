VAR asked_question = false

KWAME: Hard to believe what we just heard..
ME: I know.
KWAME: I'm fine with dying, I've had a full life. But there are so many young people here. You're only 26 right?
->Divert1

==Divert1
{
    -asked_question == false:
        KWAME: Anyway, what can I help you with?
    -else:
        KWAME: Anything else I can help you with?
}
    * [Whereabouts this morning] ME: What were you doing this morning? I heard you were spotted around the maintenance room.
        KWAME: Why would that matter?
        KWAME: I was reading most of the morning. I like to walk around when I contemplate what I've just read.
        ME: Hmm, thanks.
        ~asked_question = true
        ->Divert1
    
    
    * [About quantum core] ME: Did you hear that the primary quantum core was displaced this morning?
        KWAME: The quantum what? Dear, I'm old and not a scientist. I have no clue what this quantum thing is.
        ME: Fair enough.
        
    ~asked_question = true
    ->Divert1
    
    
    * [Seen anything odd?] ME: Have you seen anything suspicious this morning?
        KWAME: Not really - it was a usual morning until the election results were screened.

    ~asked_question = true
    ->Divert1
    
    
    * [Leave] ME: No that'll be it, thanks. Take care Kwame.
        ->END
 
    