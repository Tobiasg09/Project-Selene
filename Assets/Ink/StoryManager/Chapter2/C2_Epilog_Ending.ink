
VAR player_name = "INPUT PLAYER NAME"
VAR victimName = "XYZ"


VAR victimGender = "ZZ"
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

ME: What is it that you wanted to tell me?
CHARLOTTE: I just can't live with this lie anymore.. 
ME: What do you mean?
CHARLOTTE: {victimName} was innocent.
ME: Impossible. How would you know?
CHARLOTTE: Because... 
CHARLOTTE: I know {victimGender} was innocent because I took the quantum core, not {victimName}. 
ME: WHAT?!