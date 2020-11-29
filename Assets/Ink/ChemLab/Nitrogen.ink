VAR tookNitrogen = false

ME: I think this is the Nitrogen! But how do I make sure..
    * [Just take it] ME: Whatever, it is the only green thing around. I'll just take it.
        ~tookNitrogen = true
    * [Smell it] ME: Let's take a little whiff, just to be sure...
        ME: Damn - that smells worse than my morning breath.
        ~tookNitrogen = true
    * [Taste it] ME: I need to be sure this is the right stuff. Here goes...
        ME: Uurgh.
        ME: UUURGH.
        ME: Why did I even think of tasting fertilizer?
        ME: Sometimes I wonder how I ever got my PhD.
        ~tookNitrogen = true
    * [Keep looking] ME: Meh, this won't be it.
        ~tookNitrogen = false
    