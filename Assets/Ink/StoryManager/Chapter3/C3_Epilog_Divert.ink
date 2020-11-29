VAR hasDiverted1 = false

ME: Do I press to button to divert the missile?
    * [Press the button] ME: Here goes..
        ~hasDiverted1 = true
    
    * [Don't press the button] ME: I just can't.
        ~hasDiverted1 = false
        
-
->END