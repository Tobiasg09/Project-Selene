VAR Female = true
VAR star = "*"

... (press space to continue)
...
{star}muffled sounds{star}
...
MALE VOICE: ... and ever since, we've been trying to get the emergency power back online, but no luck so far.
FEMALE VOICE: I really hope someone will find what went wrong or figure out who is responsible for this..

FEMALE VOICE: Hmm, I wonder when Meredith is going to wake up, she is about the miss the conference.
    * [Open your eyes] ME: Yeah yeah, I'll wake up!
        ~Female = true
        ME: What time is it?
        ME: Urgh, can't believe I slept this long. Better hurry up and go outside.
        -> Divert1
    * [Ignore] FEMALE VOICE: Well she's in the same lab as Marvin isn't she? At the Bio-Engingeering department? 
        ~Female = false
        FEMALE VOICE: Let him wake her up, she's always grumpy in the morning.
        MALE VOICE: Good idea, I'll knock on his door.
        {star}KNOCK KNOCK{star}
        MALE VOICE: Marvin!
        ME: Can't you both keep it down?
        -> Divert1
        
  
  
== Divert1      
-> END