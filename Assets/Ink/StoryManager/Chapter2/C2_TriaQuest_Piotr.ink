VAR asked_question = false

ME: Hi Piotr, how are you doing?
PIOTR: There's a missile headed straight to us and we don't know what to do. How do you think I'm doing?
ME: It was rhetorical.
->Divert1

==Divert1
{
    -asked_question == false:
        PIOTR: Hmpf. You look like you have some questions.
    -else:
        PIOTR: Anything else you wanted to ask me?
}
    * [Whereabouts this morning] ME: Where were you this morning?
        PIOTR: What is this, a hearing?
        PIOTR: Just kidding. I was doing my job. I was on the surface removing some debris until the election results got announced. 
        ME: Do you have anything to back that story up?
        PIOTR: I'm sure the entry-exit logs show when I left and came back if you really want to know.
        ~asked_question = true
        ->Divert1
    
    
    * [About quantum core] ME: Have you heard that the quantum core got displaced this morning?
        PIOTR: Wait, so that was what that brief electrical outage was?
        PIOTR: Typical of Andy to let that happen.
        
        
    ~asked_question = true
    ->Divert1
    
    
    * [Who don't you trust?] ME: Let's say, hypothetically, I suspect someone from this sector to be in line with Drump, but don't know who.
        PIOTR: And you want me to name someone? You know me better than that.
        PIOTR: Although, hypothetically, I'm not a big fan of Andy. He just seems to be too reckless to have such a high position.
        PIOTR: I'm not sure why Prisha appointed him.
    ~asked_question = true
    ->Divert1
    
    
    * [Leave] ME: No that's all. See you around!
        ->END
 
    