// RED = 1, GREEN = 2, BLUE = 3, YELLOW = 4

// correct order is: BLUE RED GREEN YELLOW

VAR last_pulled = "nan"
VAR n_pulled = 0
VAR still_correct = true

VAR completed = false

ME: The program wants me to push 4 buttons in the correct sequence. They're coloured in four colours: red, green, blue and yellow.
ME: The manual states that the order should be: 
ME: -... / .-.. / ..- / . / .-. / . / -.. / --. / .-. / . / . / -. / -.-- / . / .-.. / .-.. / --- / .--


->Divert1

==Divert1
ME: Which coloured button should I push?
    * [Red] ME: Let's go for red.
    ~n_pulled = n_pulled + 1
    {
        - last_pulled != "blue":
            ~still_correct = false
    }
    ~last_pulled = "red"
    {
        - n_pulled == 4:
            ->CheckCombination
        - else:
            ->Divert1
    }
    
    * [Green] ME: Green here we go.
    ~n_pulled = n_pulled + 1
    {
        - last_pulled != "red":
            ~still_correct = false
    }
    ~last_pulled = "green"
    {
        - n_pulled == 4:
            ->CheckCombination
        - else:
            ->Divert1
    }
    
    * [Blue] ME: I think it'll be blue.
    ~n_pulled = n_pulled + 1
    {
        - last_pulled != "nan":
            ~still_correct = false
    }
    ~last_pulled = "blue"
    {
        - n_pulled == 4:
            ->CheckCombination
        - else:
            ->Divert1
    }
    
    * [Yellow] ME: It should be yellow.
    ~n_pulled = n_pulled + 1
    {
        - last_pulled != "green":
            ~still_correct = false
    }
    ~last_pulled = "yellow"
    {
        - n_pulled == 4:
            ->CheckCombination
        - else:
            ->Divert1
    }
   
   
   
==CheckCombination
{
    - still_correct == true:
        ->Correct
    - else:
    //reset everything
        ~n_pulled = 0
        ~last_pulled = "nan"
        ~still_correct = true
        ->Incorrect
}
    
==Correct
~completed = true
ME: This seems to be correct! Great, I think I sent out the message!
->END

==Incorrect
ME: It is incorrect.
->END
